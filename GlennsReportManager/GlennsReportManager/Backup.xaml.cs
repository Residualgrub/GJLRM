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
namespace GlennsReportManager
{

    public partial class Backup : Window
    {
        public List<string> BDirectories = new List<string>();
        public Backup()
        {
            InitializeComponent();
            DriveContain.SetTitle("Available Drives");
            DriveContain.SetNoDataMessage("No drives found!\n Plug in a storage drive and refresh the drives.");
            LoadDrives();
            string[] dirs = Directory.GetDirectories(@".\", "*", SearchOption.AllDirectories);
            foreach (string Direct in dirs)
            {
                BDirectories.Add(Direct);
            }
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
            List<Drives> SelectedDrives = DriveContain.GetSelectedDrives();
            
            try
            {
                if (SelectedDrives != null && SelectedDrives.Count <= 0) { throw new NullReferenceException("No drives are selected! Please select at least one drive."); }

                
            }
            catch (Exception ex)
            {

                SystemSounds.Exclamation.Play();
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

        }
    }
}
