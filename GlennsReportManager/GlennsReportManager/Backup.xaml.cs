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

        //TODO: The main portion of the backup work is done. The final clean up and updating of the UI plus error reporting needs to be completed.
        private void ZipBackgroundWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            //Find all directories in the data folder
            BackupReport report = new BackupReport();
            string[] dirs = Directory.GetDirectories(@".\", "*", SearchOption.AllDirectories);
            List<string> files = new List<string>();
            List<Drives> drives = new List<Drives>();
            drives = (List <Drives>)e.Argument;

            NewText("Scanning Directories");

            //We need to scan for all sub folders and files in the data directory so we know what we need to backup
            foreach (string Direct in dirs)
            {
                BDirectories.Add(Direct);
                DirectoryInfo d = new DirectoryInfo(Direct);

                foreach (var file in d.GetFiles("*"))
                {
                    files.Add(string.Format(@"{0}\{1}", Direct, file.Name));
                }
            }
            files.Add("grmdb.mdf");
            files.Add("grmdb_log.ldf");
            worker.ReportProgress(25);
            int curfile = 0;
            string filename = "gjlrm_backup_" + DateTime.Today.ToString("dd-MM-yyyy") + ".zip";
            if (File.Exists(filename)) { File.Delete(filename); } //Make sure there isn't a backup file of the same name already in directory.


            using (ZipArchive zip = ZipFile.Open(filename, ZipArchiveMode.Create))//Loop through all of our files and load them into the zip directory
            {
                foreach (string file in files)
                {
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

            long length = new System.IO.FileInfo(filename).Length;

            //This starts the operation of moving the back up to the selected drives
            foreach (Drives drive in drives)
            {
                if (drive.FreeSpace > length)//We need to make sure the drive has enough space for the back up.
                {
                    NewText("Backing Up To " + drive.VolLable);
                    string direct = drive.Letter + "gjlrmdata";
                    if (Directory.Exists(direct)) { Directory.Delete(direct, true); }
                    Directory.CreateDirectory(direct);
                    File.Copy(filename, drive.Letter + @"gjlrmdata\" + filename);

                }
                else
                {
                    report.minor.Add(string.Format("{0}{1}"));
                }

            }

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

        }


        private void NewText(string msg)
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() => { TXTStep.Text = msg; }));
        }

        
    }
}
