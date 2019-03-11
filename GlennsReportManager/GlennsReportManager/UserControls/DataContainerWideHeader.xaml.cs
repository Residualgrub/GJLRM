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

namespace GlennsReportManager.UserControls
{
    /// <summary>
    /// Interaction logic for DataContainerWideHeader.xaml
    /// </summary>
    public partial class DataContainerWideHeader : UserControl
    {
        public DataContainerWideHeader()
        {
            InitializeComponent();
        }

        public void BuildHeaders(List<string> headers)
        {
            foreach(string header in headers)
            {
                var lbl = new TextBlock();
                lbl.FontSize = 16;
                lbl.VerticalAlignment = VerticalAlignment.Center;
                lbl.HorizontalAlignment = HorizontalAlignment.Center;
                lbl.Text = header;
                GRHeader.ColumnDefinitions.Add(new ColumnDefinition());
                GRHeader.Children.Add(lbl);
                Grid.SetColumn(lbl, GRHeader.ColumnDefinitions.Count - 1);
            }
        }

        private void CKSele_Click(object sender, RoutedEventArgs e)
        {

        }



        //Add function for Transaction
        public void Add(SRTran data)
        {
            if (LBLNoData.Visibility == Visibility.Visible)
            {
                LBLNoData.Visibility = Visibility.Hidden;
            }
            var item = new SRTranItem(data.EM, data.Date, data.Type, data.Cust, data.Sale, data.Cost, data.Labor, data.Comish, data.ComPercent, data.Tax);
            item.Margin = new Thickness(10, 10, 10, 0);
            SPData.Children.Add(item);
        }

    }
}
