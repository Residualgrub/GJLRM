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
        public float Statetax { get; set; }
        public float Countytax { get; set; }
        public float Citytax { get; set; }
        public float Pprtatax { get; set; }
        public float Commission { get; set; }
        public List<SRTransType> Transtypes { get; set; }


    }
    //This is the container for diffrent transaction types
    public class SRTransType
    {
        public string Name { get; set; }
        public bool Taxable { get; set; }

        public SRTransType(string name, bool tax)
        {
            this.Name = name;
            this.Taxable = tax;

        }
    }
}
