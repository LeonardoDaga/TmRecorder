using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ATmRecorderCleaner
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo di = new DirectoryInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "AppData\\Roaming\\TmRecorder"));
            di.Delete(true);
        }
    }
}
