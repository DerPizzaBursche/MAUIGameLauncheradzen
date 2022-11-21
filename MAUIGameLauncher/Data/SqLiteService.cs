using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Reflection;
using System.IO;

namespace MAUIGameLauncher.Data
{
    public class SqLiteService
    {
        public void DBCheck()
        {
            var syspath = System.AppDomain.CurrentDomain.BaseDirectory;
            string path = syspath + "Games.db";
            if(!File.Exists(path))
                using (FileStream fs = File.Create(path));
        }
    }

}
