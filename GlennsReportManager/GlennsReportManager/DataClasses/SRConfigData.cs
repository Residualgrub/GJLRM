using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GlennsReportManager
{
    //This is the main container for the Sales Report config data
    public class SRConfigData
    {
        public decimal Statetax { get; set; }
        public decimal Countytax { get; set; }
        public decimal Citytax { get; set; }
        public decimal Pprtatax { get; set; }
        public List<SRTransType> Transtypes { get; set; }


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
}
