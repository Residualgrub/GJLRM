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

    public partial class TTypeItem : UserControl
    {
        public bool Commission { get; set; }
        public decimal Commpercent { get; set; }
        public int Minimum { get; set; }
        public TTypeItem(string Name, bool Tax, bool commission, decimal commpercent, int minimum)
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
            this.Commission = commission;
            this.Commpercent = commpercent;
            this.Minimum = minimum;

            if (this.Commission)
            {
                LBLComm.Text = "Commissionable";
            }
            else
            {
                LBLComm.Text = "Non-Commissionable";
            }
        }
        public void Update(string Name, bool Tax, bool commission, decimal commpercent, int minimum)
        {
            LBLType.Text = Name;
            if (Tax)
            {
                LBLTax.Text = "Taxable";
            }
            else
            {
                LBLTax.Text = "Non-Taxable";
            }
            this.Commission = commission;
            this.Commpercent = commpercent;
            this.Minimum = minimum;

            if (this.Commission)
            {
                LBLComm.Text = "Commissionable";
            }
            else
            {
                LBLComm.Text = "Non-Commissionable";
            }

        }
    }
}
