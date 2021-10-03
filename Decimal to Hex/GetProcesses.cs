using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Decimal_to_Hex
{
   public class GetProcesses
    {
        public Dictionary<string, List<int>> ListProcesses()
        {
            Dictionary<string, List<int>> result = new Dictionary<string, List<int>>();

            Process[] processlist = Process.GetProcesses();

            foreach (Process theprocess in processlist)
            {
                if (result.ContainsKey(theprocess.ProcessName))
                {
                    List<int> values = new List<int>();
                    values.Add(theprocess.Id);
                    result.Remove(theprocess.ProcessName);
                    result.Add(theprocess.ProcessName, values);
                   }
                else
                {
                    List<int> values = new List<int>();
                    values.Add(theprocess.Id);
                     result.Add(theprocess.ProcessName, values);
                }
        
                Console.WriteLine("Process added: {0}, {1}", theprocess.ProcessName, theprocess.Id);
            }
            return result;
        }
    }
}

