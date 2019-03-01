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
using System.Media;

namespace GlennsReportManager.UserControls
{
    /// <summary>
    /// Interaction logic for DataContainerWide.xaml
    /// </summary>
    public partial class DataContainerWide : UserControl
    {
        public DataContainerWide()
        {
            InitializeComponent();
        }

        public void SetTitle(string title)
        {
            LBLTitle.Text = title;
        }

        public void SetNoDataMessage(string msg)
        {
            LBLNoData.Text = msg;
        }


        //Functions for backup items

        //Add function for Drives
        public void Add(string name, string letter, long free, long total)
        {
            if (LBLNoData.Visibility == Visibility.Visible)
            {
                LBLNoData.Visibility = Visibility.Hidden;
            }

            var item = new DriveItem(name, letter, free, total);
            item.Margin = new Thickness(10, 20, 20, 10);
            SPData.Children.Add(item);
        }

        public void Clear()
        {
            SPData.Children.Clear();
        }

        //Checks to see if there are drive entries. If not show the no drive message
        public void CheckForDrives()
        {
            if(SPData.Children.Count <= 0)
            {
                LBLNoData.Visibility = Visibility.Visible;
            }

        }

        public List<Drives> GetSelectedDrives()
        {
            List<Drives> SelectedDrives = new List<Drives>();
            
            foreach(DriveItem drive in SPData.Children)
            {
                if (drive.Selected)
                {
                    SelectedDrives.Add(new Drives(drive.VolName, drive.DLetter, drive.Freespace));
                }
            }

            return SelectedDrives;

        }
    }
}
