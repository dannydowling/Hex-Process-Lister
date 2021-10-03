using System.Diagnostics;

public class hexLister
{
    public record ProcessRecord(string ProcessName, string ProcessId);

    public static void Main()
    {
        Process[] processList = Process.GetProcesses();

        foreach (var process in processList)
        {
            ProcessRecord processRecord = new(process.ProcessName,
                                                                           (Convert.ToString((process.Id), 16)));
            Console.WriteLine(processRecord);
            // output: Process { ProcessName = csrss, ProcessId = 18F4 }
        }
    }
}


