using System.Diagnostics;
using MAUIGameLauncher.Model;

namespace MAUIGameLauncher.Data
{
    public class Games
    {
        public List<Game> games = new List<Game>();
        public List<Drive> steamPaths = new List<Drive>();


        public void startupCheckGames()
        {
            checkSteam();
            getSteamPaths();
            getSteamGames();
            getEpicPaths();
            getUbiPaths();
        }
        //Steam Methods
        public void getSteamPaths()
        {
            var Drives = new List<Drive>();
            try
            {
                //Festplatten auflisten
                DriveInfo[] Drive = DriveInfo.GetDrives();
                //festplatten namen in eine Liste schreiben
                foreach (var d in Drive)
                {
                    Drives.Add(new Drive() { name = d.Name });
                }
                foreach (var d2 in Drives)
                {
                    string path1 = d2.name + "Steam";
                    string path2 = d2.name + "SteamLibrary";
                    if (Directory.Exists(path2))
                    {
                        //Console.WriteLine(path2);
                        steamPaths.Add(new Drive() { name = path2 });
                    }
                    else if (Directory.Exists(path1))
                    {
                        //Console.WriteLine(path1);
                        steamPaths.Add(new Drive() { name = path1 });
                    }
                    foreach (string d in Directory.GetDirectories(d2.name))
                    {
                        string path3 = d + "\\Steam";
                        string path4 = d + "\\SteamLibrary";
                        if (Directory.Exists(path3))
                        {
                            //Console.WriteLine(path3);
                            steamPaths.Add(new Drive() { name = path3 });
                        }
                        else if (Directory.Exists(path4))
                        {
                            //(Console.WriteLine(path4);
                            steamPaths.Add(new Drive() { name = path4 });
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
            }
        }
        public void getSteamGames()
        {
            string gamePath;
            string launchPath;
            string gameName;
            List<Drive> commonPaths = new List<Drive>();
            foreach (var file in steamPaths)
            {
                string path = file.name + "\\steamapps\\common";
                if (Directory.Exists(path))
                {
                    //Console.WriteLine(path);
                    commonPaths.Add(new Drive() { name = path });
                    foreach (string gameDir in Directory.GetDirectories(path))
                    {
                        //Game Ablage Holen
                        gamePath = gameDir;
                        //LaunchPath holen 
                        if (Directory.EnumerateFiles(gameDir, "*.exe").Any())
                        {
                            launchPath = Directory.GetFiles(gameDir, "*.exe").First();
                            //Console.WriteLine(launchPath);
                            //GameName holen                       
                            string[] name = gameDir.Split("\\");
                            gameName = name.Last();
                            games.Add(new Game()
                            {
                                gameName = gameName,
                                gameLaunchPath = launchPath,
                                gamepath = gamePath,
                                LauncherId = 0
                                //gameIcon = ExtractGameIcon(launchPath)
                            });
                        };
                    }
                }
            }
        }
        public void checkSteam()
        {
            var Drives = new List<Drive>();
            DriveInfo[] Drive = DriveInfo.GetDrives();
            if (Process.GetProcessesByName("steam").Any(p => p.ProcessName.Contains("steam")))
            {
                Console.WriteLine("Steam is running");
            }
            else
            {
                try
                {
                    foreach (var d in Drive)
                    {
                        Drives.Add(new Drive() { name = d.Name });
                    }
                    foreach (var d2 in Drives)
                    {
                        string path1 = d2.name + "Steam";
                        if (Directory.Exists(path1))
                        {
                            ;
                            Process.Start(path1 + "\\steam.exe");
                        }
                        foreach (string d in Directory.GetDirectories(d2.name))
                        {
                            string path3 = d + "\\Steam";
                            if (Directory.Exists(path3))
                            {
                                Process.Start(path3 + "\\steam.exe");
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.Message);
                }


            }
        }
        //Epic Games Methods
        public void getEpicPaths()
        {
            var Drives = new List<Drive>();

            try
            {
                //Festplatten auflisten
                DriveInfo[] Drive = DriveInfo.GetDrives();
                //festplatten namen in eine Liste schreiben
                foreach (var d in Drive)
                {
                    Drives.Add(new Drive() { name = d.Name });
                }
                foreach (var dir in Drives)
                {
                    Search(dir.name);
                }

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
            }
        }
        public void Search(string dirName)
        {
            string gamePath;
            string launchPath;
            string gameName;
            List<Drive> gamePaths = new List<Drive>();

            foreach (string f in Directory.GetDirectories(dirName))
            {

                string gname = f.Split("\\").Last();
                string fo = f + "\\.egstore";
                if (Directory.Exists(fo))
                {
                    if (Directory.EnumerateFiles(f, gname + ".exe", SearchOption.AllDirectories).Any())
                    {
                        string gpath = Directory.EnumerateFiles(f, gname + ".exe", SearchOption.AllDirectories).First();
                        games.Add(new Game() { gameLaunchPath = gpath, gameName = gname, gamepath = f , LauncherId = 1});
                    }

                }
            }

            //wenn ein Epic Games Ordner Existiert
            foreach (string f in Directory.EnumerateDirectories(dirName))
            {
                string path = f + "\\Epic Games";
                if (Directory.Exists(path) && !path.Contains("Programme"))
                {
                    //Console.WriteLine(path);
                    gamePaths.Add(new Drive() { name = path });
                    foreach (string gameDir in Directory.GetDirectories(path))
                    {
                        //Game Ablage Holen
                        gamePath = gameDir;
                        //LaunchPath holen 
                        if (Directory.EnumerateFiles(gameDir, "*.exe").Any())
                        {
                            launchPath = Directory.GetFiles(gameDir, "*.exe").First();
                            //Console.WriteLine(launchPath);
                            //GameName holen                       
                            string[] name = gameDir.Split("\\");
                            gameName = name.Last();
                            games.Add(new Game()
                            {
                                gameName = gameName,
                                gameLaunchPath = launchPath,
                                gamepath = gamePath,
                                LauncherId = 1
                                //gameIcon = ExtractGameIcon(launchPath)
                            });
                        }
                        else if (Directory.EnumerateFiles(gameDir, "*Client-Win64-Shipping.exe", SearchOption.AllDirectories).Any())
                        {
                            launchPath = Directory.EnumerateFiles(gameDir, "*Client-Win64-Shipping.exe", SearchOption.AllDirectories).First();
                            gameName = gameDir.Split("\\").Last();
                            //Console.WriteLine(launchPath + " " + gameName);
                            games.Add(new Game() { gameName = gameName, gameLaunchPath = launchPath, gamepath = gameDir, LauncherId = 1 });
                        }
                        games.RemoveAll(g => g.gameName.Contains("DirectX"));
                        games.RemoveAll(g => g.gameName.Contains("Online Service"));
                        games.RemoveAll(g => g.gameName.Contains("Launcher"));

                    }

                }
            }
        }
        //Ubisoft Methods
        public void getUbiPaths()
        {
            var Drives = new List<Drive>();
            string gamePath;
            string launchPath;
            string gameName;
            try
            {
                //Festplatten auflisten
                DriveInfo[] Drive = DriveInfo.GetDrives();
                //festplatten namen in eine Liste schreiben
                foreach (var d in Drive)
                {
                    Drives.Add(new Drive() { name = d.Name });
                }
                foreach (var dir in Drives)
                {
                    UbiGameOndrive(dir.name);
                    UbiGameFolder(dir.name);
                }

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
            }
        }
        public void UbiGameOndrive(string dirName)
        {

            List<Drive> gamePaths = new List<Drive>();

            foreach (string f in Directory.GetDirectories(dirName))
            {

                string gname = f.Split("\\").Last();
                string fo = f + "\\uplay_install.state";
                if (File.Exists(fo))
                {

                    if (Directory.EnumerateFiles(f, "bin\\*.exe", SearchOption.AllDirectories).Any())
                    {
                        string gpath = Directory.EnumerateFiles(f, "bin\\*.exe", SearchOption.AllDirectories).First();
                        games.Add(new Game() { gameLaunchPath = gpath, gameName = gname, gamepath = f, LauncherId = 3 });
                    }

                }
            }
        }
        public void UbiGameFolder(string dirName)
        {
            string gamePath = null;
            string launchPath;
            string gameName;
            foreach (string f in Directory.EnumerateDirectories(dirName))
            {
                string path1 = f + "\\Ubisoft";
                if (Directory.Exists(path1))     //&& !path.Contains("Programme")
                {
                    foreach (string gameDir in Directory.GetDirectories(path1))
                    {
                        string path2 = gameDir + "\\games";
                        if (Directory.Exists(path2))
                        {
                            foreach (string gameDir2 in Directory.GetDirectories(path2))
                            {
                                gamePath = gameDir2;
                                if (Directory.EnumerateFiles(gameDir2, "*.exe").Any())
                                {
                                    launchPath = Directory.GetFiles(gameDir2, "*.exe").First();
                                    //Console.WriteLine(launchPath);
                                    //GameName holen                       
                                    string[] name = gameDir2.Split("\\");
                                    gameName = name.Last();
                                    games.Add(new Game()
                                    {
                                        gameName = gameName,
                                        gameLaunchPath = launchPath,
                                        gamepath = gamePath,
                                        LauncherId = 3
                                        //gameIcon = ExtractGameIcon(launchPath)
                                    });
                                }
                            }
                        }
                    }

                }
                string path3 = f + "\\Ubisoft Game Launcher";
                if (Directory.Exists(path3))
                {
                    foreach (string gameDir in Directory.GetDirectories(path3))
                    {
                        string path4 = gameDir + "\\games";
                        if (Directory.Exists(path4))
                        {
                            foreach (string gameDir2 in Directory.GetDirectories(path4))
                            {
                                if (Directory.EnumerateFiles(gameDir2, "*.exe").Any())
                                {
                                    launchPath = Directory.GetFiles(gameDir2, "*.exe").First();
                                    //Console.WriteLine(launchPath);
                                    //GameName holen                       
                                    string[] name = gameDir2.Split("\\");
                                    gameName = name.Last();
                                    games.Add(new Game()
                                    {
                                        gameName = gameName,
                                        gameLaunchPath = launchPath,
                                        gamepath = gamePath,
                                        LauncherId = 3
                                        //gameIcon = ExtractGameIcon(launchPath)
                                    });
                                }
                            }
                        }
                    }
                }

            }
        }
    }
}
