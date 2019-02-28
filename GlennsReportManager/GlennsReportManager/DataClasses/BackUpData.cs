using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlennsReportManager
{
    //This is just a data container for drives that are being backed up to
    public class Drives
    {
        public string Letter { get; set; }
        public string VolLable { get; set; }
        public long FreeSpace { get; set; }

        public Drives(string name, string letter, long free)
        {
            this.Letter = letter;
            this.VolLable = name;
            this.FreeSpace = free;
        }
    }
}
