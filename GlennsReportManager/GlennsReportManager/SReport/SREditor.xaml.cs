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
        decimal TotalTaxes;
        SRReport Report { get; set; } //The saved report data
        SRConfigData Config { get; set; }//Loaded Config Data

        List<SRTaxData> TxtBoxes = new List<SRTaxData>();
        TextBox TaxTotalTXT;
        public List<string> headers = new List<string>();//Headers for the data container

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
            TXTTotal.Text = "$0";
            TXTTotalNTax.Text = "$0";
            TXTTotalTax.Text = "$0";
        }

        private void BTAdd_Click(object sender, RoutedEventArgs e)
        {
            var tran = TranContain.NewTran(Config.Transtypes);
            if(tran != null){
                UpdateBoxes(tran);
            }
        }

        private void BTEdit_Click(object sender, RoutedEventArgs e)
        {
            foreach (UserControls.SRTranItem item in TranContain.SPData.Children)
            {
                if(item.CKSele.IsChecked ?? false) {
                    var editwin = new SRAddEditTran(Config.Transtypes, new SRTran(item.EM, item.Date, item.Type, item.Cust, item.Sale, item.Cost, item.Labor));
                    var res = editwin.ShowDialog();

                }
                
            }
        }


        //Operation Functions 

        //Called when a new transaction is added and sets all the applicable text boxes
        private void UpdateBoxes(SRReturnData tran)
        {
            if (tran.Tax is false)
            {
                TotalNonTax += tran.Sale;
                TXTTotalNTax.Text = "$" + TotalNonTax.ToString("#.##");
            }
            else
            {
                TotalTax += tran.Sale;
                TXTTotalTax.Text = "$" + TotalTax.ToString("#.##");
                TotalTaxes = 0;
                foreach (var tax in TxtBoxes)
                {
                    var amm = TotalTax * tax.Rate;
                    TotalTaxes += amm;
                    tax.Txtbox.Text = "$" + (TotalTax * tax.Rate).ToString("#.##");
                }

            }
            TXTTotal.Text = "$" + (TotalNonTax + TotalTax).ToString("#.##");
            TaxTotalTXT.Text = "$" + TotalTaxes.ToString("#.##");
        }


        //Background worker functions
        public void InitDoWorkNew(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            SRConfigData config = SRConfigData.GetSRConfig();

            //Added all the fields for different tax brackets.
            foreach (SRTaxBracket tax in config.TaxBrackets)
            {
                Application.Current.Dispatcher.BeginInvoke(new Action(() => {
                    var lbl = new TextBlock();
                    lbl.Text = tax.Name;
                    lbl.Margin = new Thickness(0, 5, 0, 0);

                    var txt = new TextBox();
                    txt.Height = 18;
                    txt.Width = 200;
                    txt.Margin = new Thickness(0, 5, 0, 0);
                    txt.Text = "$0";
                    txt.IsReadOnly = true;

                    SPNames.Children.Add(lbl);
                    SPBoxes.Children.Add(txt);
                    
                    TxtBoxes.Add(new SRTaxData(txt, tax.Percent));
                }));
            }
            //Add the total feild
            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                var lbl = new TextBlock();
                lbl.Text = "Total Tax";
                lbl.Margin = new Thickness(0, 5, 0, 0);

                TaxTotalTXT = new TextBox();
                TaxTotalTXT.Height = 18;
                TaxTotalTXT.Width = 200;
                TaxTotalTXT.Margin = new Thickness(0, 5, 0, 0);
                TaxTotalTXT.Text = "$0";
                TaxTotalTXT.IsReadOnly = true;

                SPNames.Children.Add(lbl);
                SPBoxes.Children.Add(TaxTotalTXT);
            }));
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
