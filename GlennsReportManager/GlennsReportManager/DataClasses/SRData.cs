using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
//These classes hold data relevant to the sales reports 
namespace GlennsReportManager
{
    //This class holds data from the SQL containing details about reports
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

    //This class is passed through the background worker in the SREditor
    public class SREditInitData
    {
        public DateTime Date { get; set; }
        public DBManager DB { get; set; }

        public SREditInitData(DateTime date, DBManager db)
        {
            // need to set this up for the db init of the editor
        }
    }

    //Class for an individual transaction
    public class SRTran
    {
        public string EM { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string Cust { get; set; }
        public decimal Sale { get; set; }
        public decimal Cost { get; set; }
        public decimal Labor { get; set; }
        public bool Comish { get; set; }
        public decimal ComPercent { get; set; }
        public bool Tax { get; set; }
        public SRTran(string em, DateTime date, string type, string cust, decimal sale, decimal cost, decimal labor)
        {
            this.EM = em;
            this.Date = date;
            this.Type = type;
            this.Cust = cust;
            this.Sale = sale;
            this.Cost = cost;
            this.Labor = labor;
        }
    }

    //This is a class returned by the add transaction menu to the editor
    public class SRReturnData
    {
        public decimal Sale { get; set; }
        public bool Tax { get; set; }

        public SRReturnData(decimal sale, bool tax)
        {
            this.Sale = sale;
            this.Tax = tax;
        }
    }

    public class SRReport
    {
        public List<SRTran> Trans = new List<SRTran>();
        public SRConfigData Config { get; set; }

        public SRReport( List<SRTran> trans, SRConfigData config)
        {
            this.Trans = trans;
            this.Config = config;
        }
        public SRReport()
        {
        }
    }

    //This is not a stored class. This just holds a text box and a tax reate for operational refrence.
    public class SRTaxData
    {
        public TextBox Txtbox { get; set; }
        public decimal Rate { get; set; }

        public SRTaxData(TextBox txt, decimal rate)
        {
            this.Txtbox = txt;
            this.Rate = rate;
        }
    }
}
