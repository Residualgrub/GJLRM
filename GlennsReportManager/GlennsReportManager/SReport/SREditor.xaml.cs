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
using System.ComponentModel;

namespace GlennsReportManager.SReport
{
    /// <summary>
    /// Interaction logic for SREditor.xaml
    /// </summary>
    public partial class SREditor : Window
    {
        decimal TotalTax;
        decimal TotalNonTax;
        SRReport Report { get; set; }
        SRConfigData Config { get; set; }
        public List<string> headers = new List<string>();
        private readonly BackgroundWorker InitWorker = new BackgroundWorker();
        private LoadingWindow load = new LoadingWindow();
        DateTime RDate { get; set; }
        public SREditor(DateTime rdate)
        {
            headers.Add("Employee");
            headers.Add("Date");
            headers.Add("Type");
            headers.Add("Customer");
            headers.Add("Sales");
            headers.Add("Cost");
            headers.Add("Labor");
            headers.Add("G. Margin");
            headers.Add("%");
            InitializeComponent();
            TranContain.BuildHeaders(headers);
            Report = new SRReport();
            InitWorker.DoWork += InitDoWorkNew;
            InitWorker.RunWorkerCompleted += InitWorkDoneNew;
            load.Show();
            load.ChnageText("Prepareing Report");
            this.IsEnabled = false;
            InitWorker.RunWorkerAsync();
            RDate = rdate;
            TranContain.SetTitle(RDate.ToString("MMMM yyyy"));
        }

        private void BTAdd_Click(object sender, RoutedEventArgs e)
        {
            TranContain.NewTran(Config.Transtypes);
        }







        //Background worker functions
        public void InitDoWorkNew(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            SRConfigData config = SRConfigData.GetSRConfig();

            foreach(SRTaxBracket tax in config.TaxBrackets)
            {
                Application.Current.Dispatcher.BeginInvoke(new Action(() => {
                    var lbl = new TextBlock();
                    lbl.Text = tax.Name;
                    lbl.Margin = new Thickness(0, 5, 0, 0);

                    var txt = new TextBox();
                    txt.Height = 18;
                    txt.Width = 200;
                    txt.Margin = new Thickness(0, 5, 0, 0);

                    SPNames.Children.Add(lbl);
                    SPBoxes.Children.Add(txt);
                



                }));
            }
            e.Result = config;
            return;
        }

        public void InitWorkDoneNew(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            var config = (SRConfigData)e.Result;
            Application.Current.Dispatcher.BeginInvoke(new Action(() => {
                load.Hide();
                this.Config = config;
                this.IsEnabled = true;

            }));
        }


    }
}
