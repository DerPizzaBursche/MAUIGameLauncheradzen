using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace MAUIGameLauncher.Data
{
    public class SqLiteService
    {
        public void DBCheck()
        {
            string path = @"C:\Users\nickr\Desktop\MAUIGameLauncher\MAUIGameLauncher\Data\Games.db";
            if(!File.Exists(path))
                using (FileStream fs = File.Create(path));
        }
    }
}
