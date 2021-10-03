using System;
using System.Globalization;

class ProcessLister
{
    static void Main(string[] args)
    {
        var processes = new Decimal_to_Hex.GetProcesses();
        var processDictionary = processes.ListProcesses();     
        
        Console.ReadLine();
    }
}