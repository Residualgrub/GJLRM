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
using Newtonsoft.Json;
using System.IO;
using System.Text.RegularExpressions;
using System.Media;

namespace GlennsReportManager
{
    public partial class settings : Window
    {
        private static readonly Regex _regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
        public bool EditMade = false;
        public bool SREdit = false;
        public bool Init = false;
        SRConfigData SRConfig;
        public settings()
        {
            InitializeComponent();
            TypeContain.SetTitle("Transaction Types");
            TypeContain.SetNoDataMessage("No types found!");
            TaxContain.SetTitle("Tax Brackets");
            TaxContain.SetNoDataMessage("No brackets found!");
            InitSRSettings();

            Init = true;
        }

        private void BTSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SRSaveSettings();


                EditMade = false;
                this.Close();
            }
            catch (Exception ex)
            {
                SystemSounds.Exclamation.Play();
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (EditMade)
            {
                SystemSounds.Question.Play();
                var result = System.Windows.Forms.MessageBox.Show("Your changes have not been saved! Do you wish to continue?", "Warning", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Warning);
                if (result == System.Windows.Forms.DialogResult.No)
                {
                    e.Cancel = true;
                }
            }

        }


        //Sales Report Settings Start

        private void InitSRSettings()
        {
            try
            {
                string rawjson = File.ReadAllText("data/config/sreportcfg.json");
                this.SRConfig = JsonConvert.DeserializeObject<SRConfigData>(rawjson);

                foreach (var type in this.SRConfig.TaxBrackets)
                {
                    TaxContain.Add(type);
                }

                foreach (var type in this.SRConfig.Transtypes)
                {
                    TypeContain.Add(type);
                }
            }
            catch (Exception e)
            {
                SystemSounds.Exclamation.Play();
                System.Windows.Forms.MessageBox.Show(string.Format("There was an error reading the configueration file! ERROR: {0}", e.Message), "Error!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }


        //Buttons for trans types
        private void BTSRAdd_Click(object sender, RoutedEventArgs e)
        {
            TypeContain.NewTranType();
            EditMade = true;
        }

        private void BTSREdit_Click(object sender, RoutedEventArgs e)
        {
            TypeContain.StartTranEdit();
            EditMade = true;
        }

        private void BTSRDelete_Click(object sender, RoutedEventArgs e)
        {
            TypeContain.StartTranDelete(sender);
        }



        //This function handles saving the Sales Report config data
        private void SRSaveSettings()
        {
            //Check to see if the text boxes are empty if they aren't then assign the new values to the config.
            //If they are empty the config will keep its old values as contingency.
            List<SRTaxBracket> brackets = new List<SRTaxBracket>();

            foreach (UserControls.TaxBracketItem ele in TaxContain.SPData.Children)
            {
                brackets.Add(new SRTaxBracket(ele.Name, ele.Rate));
            }

            List<SRTransType> types = new List<SRTransType>();

            foreach (UserControls.TTypeItem ele in TypeContain.SPData.Children)
            {
                types.Add(new SRTransType(ele.LBLType.Text, Helper.GetSRTaxBool(ele.LBLTax.Text), ele.Commission, ele.Commpercent, ele.Minimum));
            }

            SRConfig.Transtypes.Clear();
            SRConfig.Transtypes = types;
            SRConfig.TaxBrackets.Clear();
            SRConfig.TaxBrackets = brackets;
            string rawjson = JsonConvert.SerializeObject(SRConfig);
            File.WriteAllText("data/config/sreportcfg.json", rawjson);
        }

        private void BTSRTAdd_Click(object sender, RoutedEventArgs e)
        {
            TaxContain.NewTaxType();
            EditMade = true;
        }

        private void BTSRTEdit_Click(object sender, RoutedEventArgs e)
        {
            TaxContain.StartTaxEdit();
            
        }

        private void BTSRTDelete_Click(object sender, RoutedEventArgs e)
        {
            TaxContain.StartTaxDelete(sender);
            EditMade = true;
        }
    }
}
