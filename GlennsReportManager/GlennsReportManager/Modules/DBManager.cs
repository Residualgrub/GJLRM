using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace GlennsReportManager
{
    public class DBManager
    {
        private SqlConnection DBConn = new SqlConnection();

        public DBManager()
        {
            this.DBConn = new SqlConnection(Properties.Settings.Default.grmdbkey);
        }





        //Start DB functions for the Sales Report Manager


        //This gets the record files for a given year


        //Data Fetching Functions
        public List<SRData> CheckForSR(int year)
        {
            List<SRData> Data = new List<SRData>();
            try
            {
                this.DBConn.Open();
                SqlDataReader Reader = null;
                var YearParam = new SqlParameter("Param1", System.Data.SqlDbType.Int, 16);
                YearParam.Value = year;
                SqlCommand Comm = new SqlCommand("SELECT * FROM SalesReportFiles WHERE Year = @Param1", this.DBConn);
                Comm.Parameters.Add(YearParam);

                Reader = Comm.ExecuteReader();
                while (Reader.Read())
                {
                    int Year = Int32.Parse(Reader["Year"].ToString());
                    int Month = Int32.Parse(Reader["Month"].ToString());
                    string File = Reader["File"].ToString();
                    Data.Add(new SRData(Year, Month, File));
                }

                this.DBConn.Close();
            }
            catch (Exception e)
            {

                System.Windows.Forms.MessageBox.Show(e.Message);
            }


            return Data;

        }

        public List<int> GetSRYears()
        {
            var Data = new List<int>();
            try
            {
                this.DBConn.Open();
                SqlDataReader Reader = null;
                SqlCommand Comm = new SqlCommand("SELECT * FROM SalesReportsYears", this.DBConn);

                Reader = Comm.ExecuteReader();
                while (Reader.Read())
                {
                    int Year = Int32.Parse(Reader["Year"].ToString());
                    Data.Add(Year);
                }

                this.DBConn.Close();
            }
            catch (Exception e)
            {

                System.Windows.Forms.MessageBox.Show(e.Message);
            }



            return Data;
        }


        //Data Bool Checking
        public bool DoesSRReportExsist(int month, int year)
        {
            bool exsists = false;
            try
            {
                this.DBConn.Open();
                SqlDataReader Reader = null;
                var YearParam = new SqlParameter("year", System.Data.SqlDbType.Int, 16);
                YearParam.Value = year;
                var MonthParam = new SqlParameter("month", System.Data.SqlDbType.Int, 16);
                MonthParam.Value = month;
                SqlCommand Comm = new SqlCommand("SELECT * FROM SalesReportFiles WHERE Year = @year AND Month = @month", this.DBConn);
                Comm.Parameters.Add(YearParam);
                Comm.Parameters.Add(MonthParam);
                Reader = Comm.ExecuteReader();
                while (Reader.Read())
                {
                    int ID = Int32.Parse(Reader["ID"].ToString());
                    if (ID > 0){
                        exsists = true;
                    }
                    
                }

                this.DBConn.Close();
            }
            catch (Exception e)
            {

                System.Windows.Forms.MessageBox.Show(e.Message);
            }



            return exsists;
        }
    }
}
