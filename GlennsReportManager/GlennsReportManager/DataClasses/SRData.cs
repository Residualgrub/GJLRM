using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlennsReportManager
{
    public class SRData
    {
        public int Year;
        public int Month;
        public string File;

        public SRData(int year, int month, string file)
        {
            this.Year = year;
            this.Month = month;
            this.File = file;
        }

    }
}
