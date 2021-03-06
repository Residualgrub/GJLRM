﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Media;
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

        //Formats bytes into a human readable string. Yeet.
        public static string FormatBytes(long bytes)
        {
            string[] Suffix = { "B", "KB", "MB", "GB", "TB" };
            int i;
            double dblSByte = bytes;
            for (i = 0; i < Suffix.Length && bytes >= 1024; i++, bytes /= 1024)
            {
                dblSByte = bytes / 1024.0;
            }

            return String.Format("{0:0.##} {1}", dblSByte, Suffix[i]);
        }

        //Remap one number range to another
        public static int Remap(int val, int Start1, int Start2, int End1, int End2)
        {
            return (val - Start1) / (End1 - Start1) * (End2 - Start2) + Start2;
        }


        public static void ThrowError(string msg)
        {
            SystemSounds.Exclamation.Play();
            System.Windows.Forms.MessageBox.Show(msg, "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }
    }
}
