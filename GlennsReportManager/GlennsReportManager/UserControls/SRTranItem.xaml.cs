﻿using System;
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
    /// Interaction logic for SRTranItem.xaml
    /// </summary>
    public partial class SRTranItem : UserControl
    {
        public string EM { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string Cust { get; set; }
        public decimal Sale { get; set; }
        public decimal Cost { get; set; }
        public decimal Labor { get; set; }
        public decimal GMargin { get; set; }
        public decimal Profit { get; set; }
        public bool Comish { get; set; }
        decimal ComPercent { get; set; }
        bool Tax { get; set; }

        public SRTranItem(string em, DateTime date, string type, string cust, decimal sale, decimal cost, decimal labor)
        {
            InitializeComponent();

            Update(em, date, type, cust, sale, cost, labor);
            
            
        }

        public void Update(string em, DateTime date, string type, string cust, decimal sale, decimal cost, decimal labor)
        {
            bool nocalc = false;
            this.EM = em;
            this.Date = date;
            this.Type = type;
            this.Cust = cust;
            this.Sale = sale;
            this.Cost = cost;
            this.Labor = labor;
            LBLEM.Text = em;
            LBLDate.Text = string.Format("{0}-{1}", this.Date.ToString("dd"), this.Date.ToString("MMMM").Substring(0, 3));
            LBLType.Text = this.Type;
            LBLCust.Text = this.Cust;
            LBLSale.Text = "$" + this.Sale;

            LBLCost.Text = "$" + this.Cost;
            if (this.Cost < 0)
            {
                LBLCost.Text = "-";
                nocalc = true;
            }

            LBLLabor.Text = "$" + this.Labor;
            if (this.Labor < 0)
            {
                LBLLabor.Text = "-";
                nocalc = true;
            }

            if (!nocalc)
            {
                this.GMargin = (this.Sale - this.Cost - this.Labor);
                LBLMargin.Text = "$" + this.GMargin.ToString();
                this.Profit = (this.GMargin / this.Sale);
                LBLProfit.Text = this.Profit.ToString("#.###");
            }
            else
            {
                LBLMargin.Text = "-";
                LBLProfit.Text = "-";
            }

        }
    }
}
