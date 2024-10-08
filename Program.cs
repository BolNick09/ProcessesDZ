using System.Diagnostics;

namespace ProcessesDZ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Process[] processes = Process.GetProcesses().OrderBy(p => p.ProcessName).ToArray();
            foreach (Process process in processes)
                Console.WriteLine($"Id: {process.Id} Name: {process.ProcessName}");

            Console.WriteLine("Введите Id процесса для прерывания оного");
            int killId;
            Int32.TryParse(Console.ReadLine(), out killId);

            Process processToKill = processes.First(p => p.Id == killId);

            if (processToKill != null)
            {
                Console.WriteLine($"Вы уверены, что хотите остановить процесс {processToKill.ProcessName}? (y/n)");
                string key = Console.ReadLine();
                if (key.ToLower() == "y")
                {
                    processToKill.Kill();
                    Console.WriteLine($"Процесс {processToKill.ProcessName} остановлен.");
                }
                else                
                    Console.WriteLine("Остановка процесса отменена.");                
            }
            else            
                Console.WriteLine("Процесс с указанным Id не найден.");
            
        }

        
    }
}
