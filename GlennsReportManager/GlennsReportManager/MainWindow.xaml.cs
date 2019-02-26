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
            DFiles.Add(new JsonFileBackUpData("sreportcfg", "data/config", "{\"statetax\":0.029, \"countytax\":0.0123, \"citytax\":0.0312, \"pprtatax\":0.01, \"transtypes\":[{\"name\":\"Retail\", \"taxable\":true, \"commission\":true, \"commpercent\":0.03, \"minimum\":0}, {\"name\":\"Repair\", \"taxable\":true, \"commission\":true, \"commpercent\":0.03, \"minimum\":200}, {\"name\":\"ESP\", \"taxable\":false, \"commission\":true, \"commpercent\":0.1, \"minimum\":0}, {\"name\":\"Gold\", \"taxable\":false, \"commission\":false, \"commpercent\":0, \"minimum\":0}]}"));
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
    }
}
