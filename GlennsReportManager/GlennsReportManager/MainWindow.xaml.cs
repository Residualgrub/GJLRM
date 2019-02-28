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
using System.IO;
using Newtonsoft.Json;

namespace GlennsReportManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<JsonFileBackUpData> DFiles = new List<JsonFileBackUpData>();
        public MainWindow()
        {
            InitializeComponent();
            DFiles.Add(new JsonFileBackUpData("sreportcfg", "data/config", "{\"TaxBrackets\":[{\"Name\":\"CO State\", \"Percent\":0.029},{\"Name\":\"Elpaso County\", \"Percent\":0.0123},{\"Name\":\"CO Springs\", \"Percent\":0.0312},{\"Name\":\"PPRTA\", \"Percent\":0.01}],\"Transtypes\":[{\"Name\":\"Retail\",\"Taxable\":true,\"Commission\":true,\"Commpercent\":0.03,\"Minimum\":0},{\"Name\":\"Repair\",\"Taxable\":true,\"Commission\":true,\"Commpercent\":0.03,\"Minimum\":200},{\"Name\":\"ESP\",\"Taxable\":false,\"Commission\":true,\"Commpercent\":0.1,\"Minimum\":0},{\"Name\":\"Gold\",\"Taxable\":false,\"Commission\":false,\"Commpercent\":0.0,\"Minimum\":0}]}"));
            ValidateJsonConfigs();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SReport.SReportMain ReportWindow = new SReport.SReportMain();
            this.Hide();
            ReportWindow.ShowDialog();
            this.Show();
        }



        //This makes sure that all json config files are present and in the proper directory and recreates them with default values if they arn't
        private void ValidateJsonConfigs()
        {
            if (!Directory.Exists("data"))
            {
                Directory.CreateDirectory("data");
            }

            foreach (var file in DFiles)
            {
                if (File.Exists(string.Format("{0}/{1}.json", file.FilePath, file.FileName)))
                {

                }
                else
                {
                    if (!Directory.Exists(file.FilePath))
                    {
                        Directory.CreateDirectory(file.FilePath);
                    }

                    File.WriteAllText(string.Format("{0}/{1}.json", file.FilePath, file.FileName), file.DefaultJson);
                }
            }
        }

        private void BTNSettings_Click(object sender, RoutedEventArgs e)
        {
            settings Settingwindow = new settings();
            this.Hide();
            Settingwindow.ShowDialog();
            this.Show();
        }

        private void BTBackup_Click(object sender, RoutedEventArgs e)
        {
            Backup Backupwindow = new Backup();
            this.Hide();
            Backupwindow.ShowDialog();
            this.Show();
        }
    }
}
