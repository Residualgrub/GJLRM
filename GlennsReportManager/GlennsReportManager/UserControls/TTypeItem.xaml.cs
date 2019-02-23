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
    /// Interaction logic for TTypeItem.xaml
    /// </summary>
    public partial class TTypeItem : UserControl
    {
        public TTypeItem(string Name, bool Tax)
        {
            InitializeComponent();
            LBLType.Text = Name;
            if (Tax)
            {
                LBLTax.Text = "Taxable";
            }
            else
            {
                LBLTax.Text = "Non-Taxable";
            }
        }
    }
}
