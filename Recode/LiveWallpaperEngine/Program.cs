using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LiveWallpaperEngine
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            Console.WriteLine("Live Wallpaper Engine");
            Console.WriteLine("Copyright (c) 2022 Lukas C. Schmid, FlawCra");
            Console.WriteLine("");
            Console.WriteLine("Starting WebServer...");
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = Application.StartupPath + "\\miniweb\\miniweb.exe",
                UseShellExecute = false,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden,
                WorkingDirectory = Application.StartupPath + "\\miniweb\\"
            };
            
            if(args.Length > 0)
            {
                psi.Arguments = "-r " + args[0];
            }
            Process.Start(psi);
            Console.WriteLine("WebServer started!");
            Screen[] allScreens = Screen.AllScreens;
            foreach (Screen screen in allScreens)
            {
                Console.WriteLine("Starting WallpaperRuntime for " + screen.DeviceName);
                string text = screen.DeviceName.Replace("\\\\.\\DISPLAY", "");
                Process.Start(new ProcessStartInfo
                {
                    Arguments = text + " http://localhost:8000",
                    FileName = Application.StartupPath + "\\x86\\LiveWallpaper.exe",
                    WorkingDirectory = Application.StartupPath + "\\x86\\"
                });
                Console.WriteLine("WallpaperRuntime for " + screen.DeviceName + " started!");
            } }
    }
}
