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

namespace GlennsReportManager
{
    public partial class settings : Window
    {
        public bool EditMade = false;
        public bool Init = false;
        SRConfigData SRConfig;
        public settings()
        {
            InitializeComponent();
            TypeContain.SetTitle("Transaction Types");
            TypeContain.SetNoDataMessage("No types found!");
            InitSRSettings();
        }

        private void BTSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTCan_Click(object sender, RoutedEventArgs e)
        {

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
                TxtComish.Text = this.SRConfig.Commission.ToString();

                foreach (var type in this.SRConfig.Transtypes)
                {
                    TypeContain.Add(type);
                }
            }
            catch (Exception e)
            {

                System.Windows.Forms.MessageBox.Show(string.Format("There was an error reading the configueration file! ERROR: {0}", e.Message), "Error!", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void BTSRAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTSREdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BTSRDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
