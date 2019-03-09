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
using System.ComponentModel;
namespace GlennsReportManager.SReport
{
    /// <summary>
    /// Interaction logic for SReportMain.xaml
    /// </summary>
    public partial class SReportMain : Window
    {
        List<SRData> Data = new List<SRData>();
        List<int> Years = new List<int>();
        SRConfigData Config;
        int CurYear;
        DBManager DB { get; set; }
        LoadingWindow load = new LoadingWindow();
        private readonly BackgroundWorker InitWorker = new BackgroundWorker();
        private readonly BackgroundWorker QueryWorker = new BackgroundWorker();
        public SReportMain()
        {
            
            InitWorker.DoWork += InitBackgroundWork;
            InitWorker.RunWorkerCompleted += InitBackgroundWorkDone;
            QueryWorker.DoWork += QueryBackgroundWork;
            QueryWorker.RunWorkerCompleted += QueryBackgroundWorkDone;
            InitializeComponent();
            load.ShowInTaskbar = false;
            load.Show();

            InitWorker.RunWorkerAsync();
            this.IsEnabled = false;
            this.CurYear = Int16.Parse(DateTime.Now.Year.ToString());
        }


        //UI event functions


        private void BNTSearch_Click(object sender, RoutedEventArgs e)
        {
            CurYear = Int16.Parse(CMBYear.SelectedValue.ToString());
            QueryWorker.RunWorkerAsync(argument: CurYear);
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

        private void BNTView_Click(object sender, RoutedEventArgs e)
        {

        }

        public void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            load.Close();
        }



        //Operation Functions

        public void LoadConfig()
        {
            try
            {
                string rawjson = File.ReadAllText("data/config/sreportcfg.json");
                this.Config = JsonConvert.DeserializeObject<SRConfigData>(rawjson);
            }
            catch (Exception e)
            {

                System.Windows.Forms.MessageBox.Show(string.Format("There was an error reading the configueration file! ERROR: {0}", e.Message), "Error!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void InitDataView()
        {
            SPReports.Children.Clear();
            LblHeader.Text = string.Format("Showing Reports From {0}", CurYear.ToString());
            if (this.Data.Count <= 0)
            {
                LBLNoData.Visibility = Visibility.Visible;
                LBLNoData.Text = string.Format("There is no data avalible for {0}", CurYear.ToString());
            }
            else
            {
                GDNoData.Visibility = Visibility.Hidden;
                SVData.Visibility = Visibility.Visible;

            }
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

        //BG Worker Functions


        //Init Background worker
        private void InitBackgroundWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() => { load.ChnageText("Connecting To Database"); }));

            DBManager DB = new DBManager();
            int CurYear = Int16.Parse(DateTime.Now.Year.ToString());
            Application.Current.Dispatcher.BeginInvoke(new Action(() => { load.ChnageText("Grabbing Reports"); }));
            List<SRData> Data = DB.CheckForSR(CurYear);
            List<int> Years = DB.GetSRYears();
            Years.Sort((x, y) => y.CompareTo(x));
            SRInitData report = new SRInitData(Data, Years, DB);

            e.Result = report;
            return;
        }

        private void InitBackgroundWorkDone(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            SRInitData report = (SRInitData)e.Result;
            Application.Current.Dispatcher.BeginInvoke(new Action(() => {
                this.Data = report.Srdata;
                this.Years = report.Years;
                this.DB = report.DB;
                LoadConfig();
                InitComboBox();
                InitDataView();
                load.Visibility = Visibility.Hidden;
                this.IsEnabled = true;
            }));
        }

        //Query Worker
        private void QueryBackgroundWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            int CurYear = (int)e.Argument;
            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                load.Visibility = Visibility.Visible;
                load.ChnageText("Gathering Reports");
                this.IsEnabled = false;
                SPReports.Children.Clear();
            }));
            List<SRData> Data = DB.CheckForSR(CurYear);

            e.Result = Data;

        }

        private void QueryBackgroundWorkDone(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            List<SRData> Data = (List<SRData>)e.Result;

            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                SPReports.Children.Clear();
                InitDataView();
                this.IsEnabled = true;
                load.Visibility = Visibility.Hidden;
            }));

        }


    }
}
