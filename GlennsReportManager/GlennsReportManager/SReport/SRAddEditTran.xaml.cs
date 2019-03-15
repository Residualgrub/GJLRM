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
using System.Media;

namespace GlennsReportManager.SReport
{
    /// <summary>
    /// Interaction logic for SRAddEditTran.xaml
    /// </summary>
    public partial class SRAddEditTran : Window, IDisposable
    {
        public string EM { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string Cust { get; set; }
        public decimal Sale { get; set; }
        public decimal Cost { get; set; }
        public decimal Labor { get; set; }

        public SRAddEditTran(List<SRTransType> types)
        {
            InitializeComponent();
            DTDate.SelectedDate = DateTime.Now;
            TXTEM.Focus();

            foreach(SRTransType type in types)
            {
                CMBType.Items.Add(type.Name);   
            }
            CMBType.SelectedIndex = 0;
            this.Title = "Add New Transaction";
        }

        private void BTDone_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(TXTEM.Text.Length <= 0){ throw new NullReferenceException("No employee name was given!"); }
                this.EM = TXTEM.Text;
                if(DTDate.SelectedDate > DateTime.Now) { throw new ArgumentOutOfRangeException("The transaction date can not be in the future!"); }
                this.Date = DTDate.SelectedDate ?? DateTime.Now;
                if(TXTCust.Text.Length <= 0) { throw new NullReferenceException("No customer name was given!"); }
                this.Cust = TXTCust.Text;
                if(TXTSale.Text.Length <= 0) { throw new NullReferenceException("No sale price was given!"); }
                this.Sale = decimal.Parse(TXTSale.Text);

                if (TXTCost.Text.Length <= 0 || TXTCost.Text == "-")
                {
                    this.Cost = -1;
                }
                else
                {
                    this.Cost = decimal.Parse(TXTCost.Text);
                }

                if(TXTLabor.Text.Length <= 0 || TXTLabor.Text == "-")
                {
                    this.Labor = -1;
                }
                else
                {
                    this.Labor = decimal.Parse(TXTLabor.Text);
                }

                this.Type = CMBType.SelectedValue.ToString();
                this.DialogResult = true;
                this.Close();

            }
            catch (Exception ex)
            {
                SystemSounds.Exclamation.Play();
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }


        public void Dispose()
        {
            /* here you'd remove any references you don't need */
        }
    }
}
