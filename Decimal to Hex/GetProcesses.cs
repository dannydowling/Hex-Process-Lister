using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Decimal_to_Hex
{
   public class GetProcesses
    {
        public Dictionary<string, int> ListProcesses()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            Process[] processlist = Process.GetProcesses();

            foreach (Process theprocess in processlist)
            {
                result.Add(theprocess.ProcessName, theprocess.Id);
                Console.WriteLine("Process added: {0}, {1}", theprocess.ProcessName, theprocess.Id);
            }
            return result;
        }
    }
}

