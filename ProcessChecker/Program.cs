using System.Diagnostics;


public class ProcessChecker
{
    public record ProcessRecord(string ProcessName, bool Responding, string Id, string HandleCount);


    static void Main(string[] arg)
    {
        var _arg = arg.FirstOrDefault();
        Console.WriteLine("This app will list the processes that are running, or only ones that aren't responding.");
        Console.WriteLine("It will give the Process Id in Hex, which can be used in WinDbg with the command !process {processId}");
        Console.WriteLine("");
        Console.WriteLine("Please choose from the following options...");
        Console.WriteLine("1: List all running processes");
        Console.WriteLine("2: Check for abandoned processes");
        Console.WriteLine("3: Poll for abandoned processes with 5 seconds of delay");
        Console.WriteLine("");
        Console.WriteLine("Enter your selected option and press Enter...");

        _arg = Console.ReadLine();

        Process[] processList = Process.GetProcesses();

        List<ProcessRecord> list = new List<ProcessRecord>();

        foreach (var process in processList)
        {
            //iterate the processes in the process list and create a new record for each
            ProcessRecord processRecord = new(process.ProcessName,
                                                                           process.Responding,
                                                                           (Convert.ToString((process.Id), 16)),
                                                                           Convert.ToString(process.HandleCount));
            list.Add(processRecord);
        }

        switch (_arg)
        {
            case "1":
                {
                    foreach (var processRecord in list)
                    {
                        string fallback = (
                      ($"Process:", processRecord.ProcessName),
                      ($"Number of Handles:", processRecord.HandleCount),
                       ($"Process Id in Hex:", processRecord.Id)).ToString();
                        Console.WriteLine(fallback);
                    }
                    Console.ReadKey();
                    return;
                }

            case "2":
                {
                    foreach (var processRecord in list)
                    {
                        if (processRecord.Responding == false)
                        {
                            string output = (
                          ($"Process:", processRecord.ProcessName),
                          ($"Number of Handles:", processRecord.HandleCount),
                          ($"Process Id in Hex:", processRecord.Id)).ToString();

                            Console.WriteLine(output);
                        }
                    }
                    return;
                }
            //loop forever, wait for 10 seconds and then run it again.
            case "3":
                {
                    TimerCallback callback = new TimerCallback(Tick);
                    foreach (var processRecord in list)
                    {
                        if (processRecord.Responding == false)
                        {
                            string output = (
                                 ($"Process:", processRecord.ProcessName),
                                 ($"Number of Handles:", processRecord.HandleCount),
                                 ($"Process Id in Hex:", processRecord.Id)).ToString();
                            var _timer = new Timer(callback, output, 0, 5000);
                            for (; ; )
                            {
                                Thread.Sleep(5000);
                                Console.WriteLine(DateTime.Now);
                                Console.WriteLine(output);
                            }
                        }
                    }
                    return;
                }

            default:
                return;
        }
    }

    static public void Tick(Object output)
    {
     // this is a placeholder for the timer...   
    }
}


