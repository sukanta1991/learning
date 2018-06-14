using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace virusDetect
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter the file path:");
                string abc = Console.ReadLine();
               // Console.WriteLine(abc);
                //string filePath = @"<dir>\TestCase.txt";
                string filePath = abc;
                Console.WriteLine("processing file" + abc);
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "C:\\Program Files\\Windows Defender\\MpCmdRun.exe";
                startInfo.Arguments = "-Scan -ScanType 3 -File " + filePath;
                process.StartInfo = startInfo;
                var result = process.Start();
                Console.WriteLine("Scanned with result: " + result.ToString());
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}
