using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace GlennsReportManager
{
    class Helper
    {

        //This file contains a bunch of helper functions that are used through out the application.

        private static readonly Regex _regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text

        public static bool GetSRTaxBool(string val)
        {
            bool tax = false;

            if (val == "Taxable")
            {
                tax = true;
            }


            return tax; 
        }


        public static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);

        }
    
}
}
