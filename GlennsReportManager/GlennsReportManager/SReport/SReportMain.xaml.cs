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

namespace GlennsReportManager.SReport
{
    /// <summary>
    /// Interaction logic for SReportMain.xaml
    /// </summary>
    public partial class SReportMain : Window
    {
        List<SRData> Data = new List<SRData>();
        List<int> Years = new List<int>();
        DBManager DB = new DBManager();
        int CurYear;
        public SReportMain()
        {
            InitializeComponent();
            this.CurYear = Int16.Parse(DateTime.Now.Year.ToString());
            this.Data = this.DB.CheckForSR(this.CurYear);
            this.Years = this.DB.GetSRYears();
            this.Years.Sort((x, y) => y.CompareTo(x));
            InitComboBox();
            InitDataView();
            LblHeader.Text = string.Format("Showing Reports From {0}", CurYear.ToString());
        }


        private void InitComboBox()
        {
            if (this.Years.Count <= 0)
            {
                CMBYear.Items.Add(2019);
                CMBYear.SelectedIndex = 0;
            }
            else
            {
                CMBYear.ItemsSource = this.Years;
                CMBYear.SelectedIndex = 0;
            }
        }


        private void InitDataView()
        {
            if (this.Data.Count <= 0)
            {
                LBLNoData.Visibility = Visibility.Visible;
                LBLNoData.Text = string.Format("There is no data avalible for {0}", CurYear.ToString());
            }
            else {
                GDNoData.Visibility = Visibility.Hidden;
                SVData.Visibility = Visibility.Visible;

            }
        }

        private void BNTNew_Click(object sender, RoutedEventArgs e)
        {
            var time = DateTime.Now;
            if (this.DB.DoesSRReportExsist(time.Month, time.Year))
            {
                System.Windows.Forms.MessageBox.Show("A report for this month already exists! Please edit the existing report.", "Error!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            else
            {
                
            }
        }

        public void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
        }
    }
}
