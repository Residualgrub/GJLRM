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
namespace GlennsReportManager
{
    //Working on multi threading the backup process
    //Try to make the UI update properly
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

        private void BTRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadDrives();
        }


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

        private void BTBack_Click(object sender, RoutedEventArgs e)
        {
            var SelectedDrives = DriveContain.GetSelectedDrives();
            
            try
            {
                if (SelectedDrives.Count <= 0) { throw new NullReferenceException("No drives are selected! Please select at least one drive."); }

                worker.RunWorkerAsync();

            }
            catch (Exception ex)
            {

                SystemSounds.Exclamation.Play();
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

        }


        private void ZipBackgroundWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            //Find all directories in the data folder
            string[] dirs = Directory.GetDirectories(@".\", "*", SearchOption.AllDirectories);
            List<string> files = new List<string>();
            foreach (string Direct in dirs)
            {
                BDirectories.Add(Direct);
                DirectoryInfo d = new DirectoryInfo(Direct);

                foreach (var file in d.GetFiles("*"))
                {
                    files.Add(string.Format(@"{0}\{1}", Direct, file.Name));
                }
            }

            worker.ReportProgress(25);
            int curfile = 0;
            using (ZipArchive zip = ZipFile.Open("backup.zip", ZipArchiveMode.Create))
            {
                foreach (string file in files)
                {
                    curfile += 1;
                    worker.ReportProgress(Helper.Remap(curfile, 0, 25, files.Count, 75));
                    zip.CreateEntryFromFile(file, file);
                }
            }

        }

        private void ZipWorkProgress(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {

            PBBar.Value = e.ProgressPercentage;
        }

        private void ZipWorkDone(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

        }
    }
}
