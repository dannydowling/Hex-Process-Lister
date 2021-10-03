using System;
using System.Globalization;

class ProcessLister
{
    static void Main(string[] args)
    {
        var processes = new Decimal_to_Hex.GetProcesses();
        var convert = new Decimal_to_Hex.ConvertToHex();
        var processDictionary = processes.ListProcesses();
       var result =  convert.ToHex(processDictionary);
        Console.WriteLine(result);
        Console.ReadLine();
    }
}