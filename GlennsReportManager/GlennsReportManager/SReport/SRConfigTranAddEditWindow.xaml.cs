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
using System.Windows.Shapes;

namespace GlennsReportManager.SReport
{
    /// <summary>
    /// Interaction logic for SRConfigTranAddEditWindow.xaml
    /// </summary>
    public partial class SRConfigTranAddEditWindow : Window, IDisposable
    {
        public string Type { get; set; }
        public bool Tax { get; set; }
        public bool Commission { get; set; }
        public decimal Commpercent { get; set; }
        public int Minimum { get; set; }

        public SRConfigTranAddEditWindow()
        {
            
            InitializeComponent();
            this.Title = "New Transaction Type";
        }

        public SRConfigTranAddEditWindow(string type, bool tax, bool commission, decimal commpercent, int minimum)
        {
            InitializeComponent();
            this.Title = "Edit Transaction Type";
            TXTType.Text = type;
            CKTax.IsChecked = tax;
            CKComm.IsChecked = commission;
            TXTRate.Text = commpercent.ToString();
            TXTMin.Text = minimum.ToString();

            if (!CKComm.IsChecked ?? false)
            {
                TXTRate.IsEnabled = false;
                TXTMin.IsEnabled = false;
            }
        }

        private void BTSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TXTType.Text.Length == 0)
                {
                    throw new System.NullReferenceException("No transaction type was given! Please provide a transaction type.");
                }

                if (CKComm.IsChecked ?? false & TXTRate.Text.Length <= 0)
                {
                    throw new System.NullReferenceException("No commission rate was provided! Please provide a commission rate.");
                }

                if (CKComm.IsChecked ?? false & TXTMin.Text.Length <= 0)
                {
                    throw new System.NullReferenceException("No minimum transaction amount was provided! Please provide a minimum transaction amount.");
                }

                this.Type = TXTType.Text;
                this.Tax = CKTax.IsChecked ?? false;
                this.Commission = CKComm.IsChecked ?? false;
                this.Commpercent = decimal.Parse(TXTRate.Text);
                this.Minimum = Int32.Parse(TXTMin.Text);
                this.DialogResult = true;
                this.Close();
            }
            catch (Exception error)
            {

                System.Windows.Forms.MessageBox.Show(string.Format("An error has occured. ERROR: {0}", error.Message), "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }
        public void Dispose()
        {
            /* here you'd remove any references you don't need */
        }
    }
}
