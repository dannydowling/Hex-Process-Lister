using System;
using System.Collections.Generic;
using System.Text;

namespace Decimal_to_Hex
{
    public class ConvertToHex
    {
        public Dictionary<string, string> ToHex(Dictionary<string, List<int>> processes)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            foreach (var process in processes)
            {
                for (int i = 0; i < processes.Values.Count; i++)
                {
                    int decimalNumber = 0;
                    int rem = 0;

                    string hexNum = "";
                    while (decimalNumber != 0)
                    {
                        rem = i % 16;
                        if (rem < 10)
                            rem = rem + 48;
                        else
                            rem = rem + 55;
                    }

                    hexNum += Convert.ToChar(rem);
                    result.Add(process.Key, hexNum);
                }             
            }
            return result;
        }
    }
}
