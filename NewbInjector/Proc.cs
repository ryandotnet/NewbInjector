using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;

namespace NewbInjector
{
    class Proc
    {
        public static Process[] processList;
        public static bool procExists = false;
        public static List<int> procIDs = new List<int>();

        public static void getProcesses()
        {
            processList = Process.GetProcesses().OrderBy(p => p.ProcessName).ToArray();
        }
        
        public static bool checkProcess(string procName)
        {
            if (Process.GetProcessesByName(procName).Any())
            {
                procExists = true;
                return true;
            }

            else
            {
                procExists = false;
                return false;
            }
        }
    }
}
