using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace GlennsReportManager
{
    class DBManager
    {
        private SqlConnection DBConn = new SqlConnection();

        public DBManager()
        {
            DBConn = new SqlConnection(Properties.Settings.Default.grmdbkey);
        }
    }
}
