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
using System.Media;


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
            var item = new TTypeItem(data.Name, data.Taxable, data.Commission, data.Commpercent, data.Minimum);
            item.Margin = new Thickness(10, 20, 20, 10);
            SPData.Children.Add(item);

        }

        //New function for Sales Report Transaction Types
        public void NewTranType()
        {
            try
            {
                SReport.SRConfigTranAddEditWindow dialog = new SReport.SRConfigTranAddEditWindow();
                if (dialog.ShowDialog().Value)
                {
                    foreach (TTypeItem ele in SPData.Children)
                    {
                        if (ele.LBLType.Text.ToLower() == dialog.Type.ToLower() & Helper.GetSRTaxBool(ele.LBLTax.Text) == dialog.Tax & ele.Commission == dialog.Commission)
                        {
                            throw new System.NullReferenceException(string.Format("There is already a transaction type named \"{0}\" that also shares the same tax and commission properties!", dialog.Type));
                        }
                    }
                    Add(new SRTransType(dialog.Type, dialog.Tax, dialog.Commission, dialog.Commpercent, dialog.Minimum));
                }

            }
            catch (Exception ex)
            {
                SystemSounds.Exclamation.Play();
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        //This will start the editing process for all seleccted Trans Types
        public void StartTranEdit()
        {
            foreach (TTypeItem ele in SPData.Children){
                if (ele.CKSele.IsChecked ?? false)
                {

                    bool tax = true;
                    if (ele.LBLTax.Text == "Non-Taxable")
                    {
                        tax = false;
                    }

                    SReport.SRConfigTranAddEditWindow dialog = new SReport.SRConfigTranAddEditWindow(ele.LBLType.Text, tax, ele.Commission, ele.Commpercent, ele.Minimum);
                    if (dialog.ShowDialog().Value)
                    {
                        ele.Update(dialog.Type, dialog.Tax);
                    }

                    ele.CKSele.IsChecked = false;
                }
            }

        }

        //This will start the Delete process for all seleccted Trans Types
        public void StartTranDelete(object sender)
        {
            List<TTypeItem> removed = new List<TTypeItem>();

            foreach (TTypeItem ele in SPData.Children)
            {
                if (ele.CKSele.IsChecked ?? false)
                {
                    removed.Add(ele);
                }
            }

            if (removed.Count == SPData.Children.Count)
            {
                SystemSounds.Question.Play();
                var result = System.Windows.Forms.MessageBox.Show("All transaction types are set to be removed! If you do this you will not be able to add any new transactions to reports. Are you sure you want to do this?", "Warning", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Exclamation);
                if (result == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
            }

            foreach (TTypeItem ele in removed)
            {
                   SPData.Children.Remove(ele);
            }

            if (SPData.Children.Count <= 0)
            {
                LBLNoData.Visibility = Visibility.Visible;
            }

        }





        private static T FindParent<T>(DependencyObject dependencyObject) where T : DependencyObject
        {
            var parent = VisualTreeHelper.GetParent(dependencyObject);

            if (parent == null) return null;

            var parentT = parent as T;
            return parentT ?? FindParent<T>(parent);
        }

    }
}
