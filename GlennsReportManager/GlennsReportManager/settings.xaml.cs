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
            InitSRSettings();

            Init = true;
        }

        private void BTSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SRSaveSettings();
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
                TxtCity.Text = this.SRConfig.Citytax.ToString();
                TxtCounty.Text = this.SRConfig.Countytax.ToString();
                TxtState.Text = this.SRConfig.Statetax.ToString();
                TxtPP.Text = this.SRConfig.Pprtatax.ToString();

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
            //Check to see if the text boxes are empty and if they are reset them to their previous values
            if (TxtCity.Text.Length <= 0)
            {
                TxtCity.Text = SRConfig.Citytax.ToString();
            }

            if (TxtState.Text.Length <= 0)
            {
                TxtState.Text = SRConfig.Statetax.ToString();
            }

            if (TxtCounty.Text.Length <= 0)
            {
                TxtCounty.Text = SRConfig.Countytax.ToString();
            }

            if (TxtPP.Text.Length <= 0)
            {
                TxtPP.Text = SRConfig.Pprtatax.ToString();
            }

        }

        private void TxtState_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!IsTextAllowed(e.Text))
            {
                e.Handled = true;
                return;
            }
            EditMade = true;
        }

        private void TxtState_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!IsTextAllowed(text))
                {
                    e.CancelCommand();
                }
                EditMade = true;
            }
            else
            {
                e.CancelCommand();
            }

        }


        
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
            
        }
    }
}
