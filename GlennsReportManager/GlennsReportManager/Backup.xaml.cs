using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using Newtonsoft.Json;
using System.Media;
using System.IO.Compression;
using System.ComponentModel;
using System.Reflection;
namespace GlennsReportManager
{

    public partial class Backup : Window
    {
        public List<string> BDirectories = new List<string>();
        private readonly BackgroundWorker worker = new BackgroundWorker();

        public Backup()
        {
            InitializeComponent();
            DriveContain.SetTitle("Available Drives");
            DriveContain.SetNoDataMessage("No drives found!\n Plug in a storage drive and refresh the drives.");
            LoadDrives();
            worker.DoWork += ZipBackgroundWork;
            worker.ProgressChanged += ZipWorkProgress;
            worker.RunWorkerCompleted += ZipWorkDone;
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            TXTBackDate.Text = Properties.Settings.Default.LastBackup;
        }

        //Refreshes the list of removable drives
        private void BTRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadDrives();
        }


        //Refreshes the list of removable drives
        private void LoadDrives()
        {
            DriveContain.Clear();
            DriveInfo[] allDrives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in allDrives)
            {
                if (drive.IsReady && drive.DriveType.ToString() == "Removable")
                {
                    DriveContain.Add(drive.VolumeLabel, drive.Name, drive.AvailableFreeSpace, drive.TotalSize);

                }
            }

            DriveContain.CheckForDrives();
        }

        //Starts the backup process
        private void BTBack_Click(object sender, RoutedEventArgs e)
        {
            var SelectedDrives = DriveContain.GetSelectedDrives();
            
            try
            {
                if (SelectedDrives.Count <= 0) { throw new NullReferenceException("No drives are selected! Please select at least one drive."); }

                worker.RunWorkerAsync(argument: SelectedDrives);

            }
            catch (Exception ex)
            {

                SystemSounds.Exclamation.Play();
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

        }

        //This function is the work horse for the backup operation itself.
        //It handles scanning for files, zipping, and transfering the backups
        //I am using multiple try statements in here to encase different aspects of the operation as different actions need to be taken to recover from an error.
        //There are cancel monitoring statements in every loop and transition between try statements
        private void ZipBackgroundWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

            //Find all directories in the data folder
            BackupReport report = new BackupReport();
            string[] dirs = Directory.GetDirectories(@".\", "*", SearchOption.AllDirectories);
            List<string> files = new List<string>();
            List<Drives> drives = new List<Drives>();
            drives = (List<Drives>)e.Argument;

            if (ShouldCanWork())
            {
                EndWork("", e);
                e.Result = report;
                return;
            }

            //Try statement for scanning directories
            try
            { 

                NewText("Scanning Directories");

                //We need to scan for all sub folders and files in the data directory so we know what we need to backup
                foreach (string Direct in dirs)
                {
                    BDirectories.Add(Direct);
                    DirectoryInfo d = new DirectoryInfo(Direct);

                    foreach (var file in d.GetFiles("*"))
                    {
                        files.Add(string.Format(@"{0}\{1}", Direct, file.Name));
                        if (ShouldCanWork()){
                            EndWork("", e);
                            e.Result = report;
                            return;
                        }
                    }
                }
                files.Add("grmdb.mdf");
                files.Add("grmdb_log.ldf");
                worker.ReportProgress(25);
            }
            catch (Exception er)
            {
                report.major.Add("There was an un-recoverable error while scanning for files! Error: " + er.GetType().ToString() + " " + er.Message);
                EndWork("");
                e.Result = report;
                return;
            }

            int curfile = 0;
            string filename = "gjlrm_backup_" + DateTime.Today.ToString("MM-dd-yyyy") + ".zip";

            if (ShouldCanWork())
            {
                EndWork(filename, e);
                e.Result = report;
                return;
            }

            //Try statement for zip compression
            try
            {
                
                if (File.Exists(filename)) { File.Delete(filename); } //Make sure there isn't a backup file of the same name already in directory.


                using (ZipArchive zip = ZipFile.Open(filename, ZipArchiveMode.Create))//Loop through all of our files and load them into the zip directory
                {
                    foreach (string file in files)
                    {
                        if (ShouldCanWork())
                        {
                            EndWork(filename, e);
                            return;
                        }
                        curfile += 1;
                        worker.ReportProgress(Helper.Remap(curfile, 0, 25, files.Count, 75));
                        var fname = System.IO.Path.GetFileName(file);
                        NewText("Compressing " + fname);
                        zip.CreateEntryFromFile(file, file);
                    }
                    //We need to make the backup manifest
                    NewText("Writing Manifest");
                    string ver = Assembly.GetExecutingAssembly().GetName().Version.ToString();
                    BackUpManifest Manifest = new BackUpManifest(ver, files, BDirectories);
                    string rawjson = JsonConvert.SerializeObject(Manifest);
                    File.WriteAllText("manifest.json", rawjson);
                    zip.CreateEntryFromFile("manifest.json", "manifest.json");
                }
            }
            catch (Exception er)
            {
                report.major.Add("There was an un-recoverable error while compressing files! Error: " + er.GetType().ToString() + " " + er.Message);
                EndWork(filename);
                e.Result = report;
                return;
            }

            long length = new System.IO.FileInfo(filename).Length;

            if (ShouldCanWork())
            {
                EndWork(filename, e);
                e.Result = report;
                return;
            }

            //Try statement for backup transfer
            try
            {

                //This starts the operation of moving the back up to the selected drives
                foreach (Drives drive in drives)
                {
                    if (drive.FreeSpace > length)//We need to make sure the drive has enough space for the back up.
                    {
                        if (ShouldCanWork())
                        {
                            EndWork(filename, e);
                            return;
                        }

                        NewText("Backing Up To " + drive.VolLable);
                        string direct = drive.Letter + "gjlrmdata";
                        if (Directory.Exists(direct)) {
                            DirectoryInfo d = new DirectoryInfo(direct);

                            foreach (var file in d.GetFiles())
                            {
                                File.Delete(direct + @"\" + file.Name);
                            }
                        }
                        else
                        {
                            Directory.CreateDirectory(direct);
                        }
                        File.Copy(filename, drive.Letter + @"gjlrmdata\" + filename);
                        report.success.Add(drive.Letter + drive.VolLable);
                    }
                    else
                    {
                        report.minor.Add(string.Format("{0}{1} does not have enough space for the backup! Current space: {2} Needed Space: {3}", 
                            drive.Letter, drive.VolLable, Helper.FormatBytes(drive.FreeSpace), Helper.FormatBytes(length)));
                    }

                }
            }
            catch (Exception er)
            {
                report.major.Add("There was an un-recoverable error while backing up to drives! Error: " + er.GetType().ToString() + " " + er.Message);
                EndWork(filename);
                e.Result = report;
                return;
            }

            e.Result = report;
            NewText("Cleaning Up");
            File.Delete(filename);
            File.Delete("manifest.json");
        }

        private void ZipWorkProgress(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {

            PBBar.Value = e.ProgressPercentage;
        }

        private void ZipWorkDone(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            BackupReport report = (BackupReport) e.Result;
            if (e.Cancelled)//Was the op canned?
            {
                if (report.success.Count > 0)//Even though it was canned did we still have some backups completed?
                {
                    var msg = "";
                    foreach (var drive in report.success)
                    {
                        msg += "\n" + drive + " was sucesfully backed up!";
                    }
                    SystemSounds.Question.Play();
                    System.Windows.Forms.MessageBox.Show("The back up was canceled however some back up operations where already completed." + msg, "Success!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("The back up was canceled.", "Success!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                }
            }
            else//Was the op completed?
            {

                if (report.major.Count > 0)//Was it ended because of a major error?
                {
                    SystemSounds.Exclamation.Play();
                    System.Windows.Forms.MessageBox.Show(report.major[0], "Error!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
                else
                {
                    var msg = "The Operation has completed. \n \n";
                    if (report.success.Count > 0)
                    {
                        foreach (var drive in report.success)
                        {
                            msg += drive + " ";
                        }
                        var word = "was ";
                        if (report.success.Count > 1) { word = "were "; }

                        msg += word + "successfully backed up!";
                        Properties.Settings.Default.LastBackup = DateTime.Today.ToString("MM-dd-yyyy");
                        Properties.Settings.Default.Save();
                        TXTBackDate.Text = Properties.Settings.Default.LastBackup; 
                    }
                   
                    if (report.minor.Count > 0)
                    {
                        msg += "\n Some minor errors did occur during the operaton.";

                        foreach (var er in report.minor)
                        {
                            msg += "\n" + er;
                        }
                    }
                    SystemSounds.Asterisk.Play();
                    System.Windows.Forms.MessageBox.Show(msg, "Operation Completed!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                }

            }
            LoadDrives();

        }

        // Window specific helper functions 

        private void NewText(string msg)
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() => { TXTStep.Text = msg; }));
        }

        private bool ShouldCanWork()
        {
            return worker.CancellationPending;
        }

        private void EndWork(string zip, System.ComponentModel.DoWorkEventArgs e)
        {
            if (File.Exists(zip)) { File.Delete(zip); }
            if (File.Exists("manifest.json")) { File.Delete("manifest.json"); }
            e.Cancel = true;
            worker.ReportProgress(0);
        }

        private void EndWork(string zip)
        {
            if (File.Exists(zip)) { File.Delete(zip); }
            if (File.Exists("manifest.json")) { File.Delete("manifest.json"); }
            worker.ReportProgress(0);
        }
    }
}
