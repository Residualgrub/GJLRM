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
            D = DTP.SelectedDate ?? DateTime.Now;
            this.DialogResult = true;
            this.Close();
        }

        private void BTCan_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
