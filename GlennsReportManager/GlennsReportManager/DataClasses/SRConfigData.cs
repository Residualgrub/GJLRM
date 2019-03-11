using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
namespace GlennsReportManager
{
    //This is the main container for the Sales Report config data
    public class SRConfigData
    {
        public List<SRTaxBracket> TaxBrackets { get; set; }
        public List<SRTransType> Transtypes { get; set; }

        public static SRConfigData GetSRConfig()
        {
            string rawjson = File.ReadAllText("data/config/sreportcfg.json");
            SRConfigData result = JsonConvert.DeserializeObject<SRConfigData>(rawjson);

            return result;
        }

    }
    //This is the container for diffrent transaction types
    public class SRTransType
    {
        public string Name { get; set; }
        public bool Taxable { get; set; }
        public bool Commission { get; set; }
        public decimal Commpercent { get; set; }
        public int Minimum { get; set; }

        public SRTransType(string name, bool tax, bool commission, decimal commpercent, int minimum)
        {
            this.Name = name;
            this.Taxable = tax;
            this.Commission = commission;
            this.Commpercent = commpercent;
            this.Minimum = minimum;

        }
    }

    //This is the container class for sales tax brackets
    public class SRTaxBracket
    {
        public string Name { get; set; }
        public decimal Percent { get; set; }

        public SRTaxBracket(string name, decimal percent)
        {
            this.Name = name;
            this.Percent = percent;
        }

    }
}
