using System.Diagnostics;


public class ProcessChecker
{    
    public record ProcessRecord(string ProcessName,bool Responding, string Id, string HandleCount);

    public static void Main()
    {
        Process[] processList = Process.GetProcesses();
        List<ProcessRecord> list = new List<ProcessRecord>();

        foreach (var process in processList)
        {
            //iterate the processes in the list and create a new record for each
            ProcessRecord processRecord = new(process.ProcessName,
                                                                           process.Responding,
                                                                           (Convert.ToString((process.Id), 16)),
                                                                           Convert.ToString(process.HandleCount));
            list.Add(processRecord);
        }

        foreach (var processRecord in list)
        {
            if (processRecord.Responding == false)
            {
                string output = (
                   ($"Process:", processRecord.ProcessName),
                   ($"Number of Handles:", processRecord.HandleCount),
                  ($"Process Id in Hex:", processRecord.Id)).ToString();

               
                Console.WriteLine(output);
                Console.ReadKey();
            }
        }
    }
}


