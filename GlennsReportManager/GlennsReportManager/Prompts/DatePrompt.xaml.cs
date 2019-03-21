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

namespace GlennsReportManager.Prompts
{
    /// <summary>
    /// Interaction logic for DatePrompt.xaml
    /// </summary>
    public partial class DatePrompt : Window, IDisposable
    {
        public DateTime D { get; set; }
        private bool Set = false;
        public DatePrompt()
        {
            InitializeComponent();
        }



        public void Dispose()
        {
            /* here you'd remove any references you don't need */
        }

        private void BTCon_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                D = DTP.SelectedDate ?? DateTime.Now;
                if (D > DateTime.Now) { throw new ArgumentOutOfRangeException("A report can not be created for a future date!"); }
                Set = true;
                this.DialogResult = true;
                this.Close();
            }
            catch (Exception ex)
            {

                Helper.ThrowError(ex.Message);
            }
        }

        private void BTCan_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Set is false)
            {
                this.DialogResult = false;
            }
        }
    }
}
