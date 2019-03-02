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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
namespace GlennsReportManager.UserControls
{
    /// <summary>
    /// Interaction logic for DriveItem.xaml
    /// </summary>
    public partial class DriveItem : UserControl
    {
        public string VolName { get; set; }
        public string DLetter { get; set; }
        public long Freespace { get; set; }
        public long TotalSpace { get; set; }
        public bool Selected { get; set; }
        public DriveItem(string name, string letter, long free, long total)
        {
            InitializeComponent();
            this.VolName = name;
            this.DLetter = letter;
            this.Freespace = free;
            this.TotalSpace = total;
            this.Selected = false;
            LBLVolume.Text = this.DLetter + " " + this.VolName;
            LBLSpace.Text = Helper.FormatBytes(this.Freespace) + "/" + Helper.FormatBytes(this.TotalSpace);

            LBLBack.Text = "No Back Up";
            if (Directory.Exists(this.DLetter + @"gjlrmdata\"))
            {
                var info = new DirectoryInfo(this.DLetter + "gjlrmdata");

                foreach (var file in info.GetFiles("*"))
                {
                    if (file.Name.Contains("gjlrm_backup")){
                        LBLBack.Text = "Last Back Up:\n " + file.Name.Substring(13, 10);
                    }
                }
            }
        }

        private void CKSele_Click(object sender, RoutedEventArgs e)
        {
            if (CKSele.IsChecked ?? false)
            {
                this.Selected = true;
            }
            else
            {
                this.Selected = false;
            }
        }
    }
}
