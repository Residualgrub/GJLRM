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
using System.IO;
using Newtonsoft.Json;

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
            RDate = rdate;
            InitWorker.RunWorkerAsync(argument: RDate);
            TranContain.SetTitle(RDate.ToString("MMMM yyyy"));
            TXTTotal.Text = "$0";
            TXTTotalNTax.Text = "$0";
            TXTTotalTax.Text = "$0";
        }

        private void BTAdd_Click(object sender, RoutedEventArgs e)
        {
            var loop = true;

            while (loop)
            {
                var tran = TranContain.NewTran(Config.Transtypes);
                if (tran != null)
                {
                    UpdateBoxes(tran);
                }
                else
                {
                    return;
                }
                var res = System.Windows.Forms.MessageBox.Show("Would you like to add another report?", "Question", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question);

                if(res == System.Windows.Forms.DialogResult.No) {
                    loop = false;
                }
            }
        }

        private void BTEdit_Click(object sender, RoutedEventArgs e)
        {
            
            TranContain.StartTranEdit(Config.Transtypes);
            load.ChnageText("Recalculating Taxes");
            load.Show();
            FullBoxUp();
            load.Hide();
        }

        private void BTDel_Click(object sender, RoutedEventArgs e)
        {
            load.ChnageText("Deleting Transactions");
            load.Show();
            TranContain.StartTranDelete();
            load.ChnageText("Recalculating Taxes");
            FullBoxUp();
            load.Hide();
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

        //Does a full re calculation of transactions for taxes
        private void FullBoxUp()
        {
            TotalNonTax = 0;
            TotalTax = 0;
            TotalTaxes = 0;

            foreach(UserControls.SRTranItem item in TranContain.SPData.Children)
            {
                bool tax = true;
                foreach (var taxes in Config.Transtypes)
                {
                    if (taxes.Name == item.Type)
                    {
                        tax = taxes.Taxable;
                    }

                }

                if (tax)
                {
                    TotalTax += item.Sale;
                }
                else
                {
                    TotalNonTax += item.Sale;
                }
            }

            foreach (var tax in TxtBoxes)
            {
                var amm = TotalTax * tax.Rate;
                TotalTaxes += amm;
                tax.Txtbox.Text = "$" + (amm).ToString("#.##");
            }

            TXTTotalNTax.Text = "$" + TotalNonTax.ToString("#.##");
            TaxTotalTXT.Text = "$" + TotalTaxes.ToString("#.##");
            TXTTotalTax.Text = "$" + TotalTax.ToString("#.##");
            TXTTotal.Text = "$" + (TotalTax + TotalNonTax).ToString("#.##");

        }


        //Background worker functions
        public void InitDoWorkNew(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            SRConfigData config = SRConfigData.GetSRConfig();
            DateTime date = (DateTime)e.Argument;
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

            var writereport = new SRReport();
            writereport.Config = config;
            writereport.Trans = new List<SRTran>();

            string rawjson = JsonConvert.SerializeObject(writereport);
            if (!Directory.Exists("data/transmngr"))
            {
                Directory.CreateDirectory("data/transmngr");
            }

            File.WriteAllText("data/transmngr/" + date.ToString("mmyy") + ".json", rawjson);
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
