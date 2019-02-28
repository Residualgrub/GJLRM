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
    /// Interaction logic for SRConfigTaxAddEditWindow.xaml
    /// </summary>
    public partial class SRConfigTaxAddEditWindow : Window, IDisposable
    {
        public string Name;
        public decimal Rate;
        public SRConfigTaxAddEditWindow()
        {
            InitializeComponent();
            this.Title = "New Tax Bracket";
            this.Icon = new BitmapImage(new Uri("pack://application:,,,/icons/cog_add.ico"));
        }

        public SRConfigTaxAddEditWindow(string name, decimal rate)
        {
            InitializeComponent();
            this.Title = "Edit Tax Bracket";
            TXTRate.Text = rate.ToString();
            TXTType.Text = name;
            this.Icon = new BitmapImage(new Uri("pack://application:,,,/icons/cog_edit.ico"));
        }

        private void BTSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TXTType.Text.Length <= 0) { throw new System.NullReferenceException("No name was given for this tax bracket. Please provide a name."); }
                if (TXTRate.Text.Length <= 0) { throw new System.NullReferenceException("No tax rate was given for this tax bracket. Please provide a tax rate."); }
                this.Name = TXTType.Text;
                this.Rate = decimal.Parse(TXTRate.Text);
                this.DialogResult = true;
                this.Close();

            }
            catch (Exception error)
            {
                SystemSounds.Exclamation.Play();
                System.Windows.Forms.MessageBox.Show(error.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }



        private void TXTRate_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Helper.IsTextAllowed(e.Text))
            {
                SystemSounds.Exclamation.Play();
                e.Handled = true;
                return;
            }

        }

        private void TXTRate_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!Helper.IsTextAllowed(text))
                {
                    SystemSounds.Exclamation.Play();
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        public void Dispose()
        {
            /* here you'd remove any references you don't need */
        }
    }
}
