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


    public partial class DataContainer : UserControl
    {

        List<TTypeItem> TranListItem = new List<TTypeItem>();




        public DataContainer()
        {
            InitializeComponent();

        }

        public void SetTitle(string title)
        {
            LBLTitle.Text = title;
        }

        public void SetNoDataMessage(string msg)
        {
            LBLNoData.Text = msg;
        }


        //Add function for Sales Report Transaction Types
        public void Add(SRTransType data)
        {
            if (LBLNoData.Visibility == Visibility.Visible)
            {
                LBLNoData.Visibility = Visibility.Hidden;
            }
            var item = new TTypeItem(data.Name, data.Taxable);
            item.Margin = new Thickness(10, 20, 20, 10);
            SPData.Children.Add(item);

        }

        //New function for Sales Report Transaction Types
        public void NewTranType()
        {
            SReport.SRConfigTranAddEditWindow dialog = new SReport.SRConfigTranAddEditWindow();
            if (dialog.ShowDialog().Value)
            {
                Add(new SRTransType(dialog.Type, dialog.Tax));
            }
        }

    }
}
