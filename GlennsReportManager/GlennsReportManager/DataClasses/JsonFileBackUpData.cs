using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlennsReportManager
{
    public class JsonFileBackUpData
    {
        public string FileName;
        public string FilePath;
        public string DefaultJson;

        public JsonFileBackUpData(string fname, string pname, string jdata)
        {
            this.FileName = fname;
            this.FilePath = pname;
            this.DefaultJson = jdata;
        }
    }
}
