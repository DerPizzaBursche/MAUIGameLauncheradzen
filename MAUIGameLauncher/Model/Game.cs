using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIGameLauncher.Model
{
    public class Game
    {
        public int Id { get; set; }
        public string gameName { get; set; }
        public string gamepath { get; set; }
        //public string gameIcon { get; set; }
        public string gameLaunchPath { get; set; }
        public int LauncherId { get; set; }
    }
}
