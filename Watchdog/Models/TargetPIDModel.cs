using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watchdog.Models
{
    public class TargetPIDModel
    {
        public int? PID { get; set; }

        public TargetPIDModel(string[] args)
        {
            if (args.Length > 0 && int.TryParse(args[0], out int pid))
            {
                PID = pid;
            }
            else
            {
                PID = null;
            }
        }
    }
}
