using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//These classes hold data relevant to the sales reports 
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

    //This class is passed through the background worker in the SR Main Menu
    public class SRInitData
    {
        public List<SRData> Srdata = new List<SRData>();
        public List<int> Years = new List<int>();
        public DBManager DB { get; set; }
        public SRInitData(List<SRData> data, List<int> years, DBManager db )
        {
            this.Srdata = data;
            this.Years = years;
            this.DB = db;
        }
    }

    //Class for an individual transaction
    public class SRTran
    {
        string EM { get; set; }
        DateTime Date { get; set; }
        string Type { get; set; }
        string Cust { get; set; }
        decimal Sale { get; set; }
        decimal Cost { get; set; }
        decimal Labor { get; set; }
        decimal Margin { get; set; }
        decimal Profit { get; set; }
        bool Comish { get; set; }
        decimal ComPercent { get; set; }
        bool Tax { get; set; }
        public SRTran(string em, DateTime date, string type, string cust, decimal sale, decimal cost, decimal labor, decimal margin, 
            decimal profit, bool comish, decimal compercent, bool tax)
        {
            this.EM = em;
            this.Date = date;
            this.Type = type;
            this.Cust = cust;
            this.Sale = sale;
            this.Cost = cost;
            this.Labor = labor;
            this.Margin = margin;
            this.Profit = profit;
            this.Comish = comish;
            this.ComPercent = compercent;
            this.Tax = tax;
        }
    }

    public class SRReport
    {
        public List<SRTran> Trans = new List<SRTran>();
        public List<SRTaxBracket> Taxes = new List<SRTaxBracket>();

        public SRReport( List<SRTran> trans, List<SRTaxBracket> taxes)
        {
            this.Trans = trans;
            this.Taxes = taxes;
        }
    }
}
