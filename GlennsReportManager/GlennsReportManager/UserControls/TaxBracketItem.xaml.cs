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
    /// Interaction logic for TaxBracketItem.xaml
    /// </summary>
    public partial class TaxBracketItem : UserControl
    {
        public string Name { get; set;}
        public decimal Rate { get; set; }

        public TaxBracketItem(string name, decimal rate)
        {
            InitializeComponent();
            this.Name = name;
            this.Rate = rate;
            LBLType.Text = name;
            LBLTax.Text = string.Format("{0}%", rate.ToString());
        }

        public void Update(string name, decimal rate)
        {
            this.Name = name;
            this.Rate = rate;
            LBLType.Text = name;
            LBLTax.Text = string.Format("{0}%", rate.ToString());
        }
    }
}
