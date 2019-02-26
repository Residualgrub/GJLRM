using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlennsReportManager
{
    class Helper
    {
        public static bool GetSRTaxBool(string val)
        {
            bool tax = false;

            if (val == "Taxable")
            {
                tax = true;
            }


            return tax; 
        }
    }
}
