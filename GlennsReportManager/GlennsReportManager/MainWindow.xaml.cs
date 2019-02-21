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
            DFiles.Add(new JsonFileBackUpData("sreportcfg", "data/config", "['STax':0.029, 'CityTax':0.0312, 'CountyTax':0.0123, 'TransTypes':{1:{Name:'Retail', 'Taxable':true}, 2:{Name:'Repair', 'Taxable':false}, 3:{Name:'Repair Taxable', 'Taxable':true}, 4:{Name:'ESP', 'Taxable':false}, 5:{Name:'Gold', 'Taxable':false}}]"));
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
    }
}
