using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Decimal_to_Hex
{
   public class GetProcesses
    {
        public Dictionary<string, List<string>> ListProcesses()
        {
            Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();

            Process[] processlist = Process.GetProcesses();

            foreach (Process theprocess in processlist)
            {
                if (result.ContainsKey(theprocess.ProcessName))
                {
                    List<string> values = new List<string>();
                    values.Add(Convert.ToString((theprocess.Id), 16));
                    result.Remove(theprocess.ProcessName);
                    result.Add(theprocess.ProcessName, values);
                   }
                else
                {
                    List<string> values = new List<string>();
                    values.Add(Convert.ToString((theprocess.Id), 16));
                    result.Add(theprocess.ProcessName, values);
                }
        
                Console.WriteLine("Process added: {0}, {1}", theprocess.ProcessName,
                    (Convert.ToString((theprocess.Id), 16)));
            }
            return result;
        }
    }
}

