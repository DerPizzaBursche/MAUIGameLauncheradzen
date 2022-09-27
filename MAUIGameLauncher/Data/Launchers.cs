using Microsoft.Maui.ApplicationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAUIGameLauncher.Model;
using Launcher = MAUIGameLauncher.Model.Launcher;

namespace MAUIGameLauncher.Data
{
    public class Launchers
    {
        public List<Launcher> launchers = new List<Launcher>();
        
        public void LaunchersSeedData()
        {
            launchers.Add(new Launcher() { Id = 0, Name = "Steam" });
            launchers.Add(new Launcher() { Id = 1, Name = "Epic Games" });
            launchers.Add(new Launcher() { Id = 2, Name = "Blattle.net" });
            launchers.Add(new Launcher() { Id = 3, Name = "Ubisoft Connect" });
            launchers.Add(new Launcher() { Id = 4, Name = "Xbox" });
        }



    }
}
