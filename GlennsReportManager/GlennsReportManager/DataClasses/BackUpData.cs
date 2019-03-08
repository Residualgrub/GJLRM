using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlennsReportManager
{
    //This is just a data container for drives that are being backed up to
    public class Drives
    {
        public string Letter { get; set; }
        public string VolLable { get; set; }
        public long FreeSpace { get; set; }

        public Drives(string name, string letter, long free)
        {
            this.Letter = letter;
            this.VolLable = name;
            this.FreeSpace = free;
        }
    }

    public class BackUpManifest
    {
        public string VerInfo { get; set; }
        public List<string> Files { get; set;}
        public List<string> Directories { get; set;}
        public BackUpManifest(string verinfo, List<string> files, List<string> directories)
        {
            this.VerInfo = verinfo;
            this.Files = files;
            this.Directories = directories;

        }
    }

    public class BackupReport
    {
        public List<string> minor = new List<string>();
        public List<string> major = new List<string>();
        public List<string> success = new List<string>();

    }
}
