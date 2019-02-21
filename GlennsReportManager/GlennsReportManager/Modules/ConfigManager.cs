using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace GlennsReportManager.Modules
{
    class ConfigManager
    {
        public ConfigManager()
        {
            if (!File.Exists("config.json"))
            {
                return;
            }


        }
    }
}
