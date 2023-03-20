using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using Watchdog.Models;

namespace Watchdog.ViewModels
{
    internal class WatchDog
    {
        private Timer timer;

        public WatchDog(MainWindowViewModel vm)
        {
            timer = new Timer(500);
            timer.Elapsed += (sender, e) =>
            {
                if (!vm.TargetPID.HasValue || !IsProcessAlive(vm.TargetPID.Value))
                {
                    vm.TargetPID = RespawnProcess();
                }
            };
            timer.Start();
        }

        public static bool IsProcessAlive(int pid)
        {
            Process? process = null;
            try
            {
                process = Process.GetProcessById(pid);
            }
            catch (ArgumentException)
            {
                return false;
            }

            return !process.HasExited;
        }

        public static int? RespawnProcess()
        {
            var currentProc = Process.GetCurrentProcess();
            string? appPath = currentProc?.MainModule?.FileName;
            int? pid = currentProc?.Id;

            if (appPath != null && pid.HasValue)
            {
                ProcessStartInfo startInfo = new ProcessStartInfo(appPath);
                startInfo.ArgumentList.Add(pid.Value.ToString());
                var newProc = Process.Start(startInfo);
                return newProc?.Id;
            }

            return null;
        }
    }
}
