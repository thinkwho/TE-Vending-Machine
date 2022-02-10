using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public static class Log
    {

        //PROPERTIES
        public static string LogFilePath { get; set; } = @"C:\Users\Student\Desktop\Log.txt";

        //METHODS
        public static void LogEvent(string actionTook, decimal balanceBefore)
        {
            
            try
            {
                using (StreamWriter sw = new StreamWriter(LogFilePath, true))
                {
                    sw.WriteLine($"{DateTime.Now} {actionTook} {balanceBefore:C2} {VendingMachine.balance:C2}");
                }
            }
            catch(IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        public static void LogEvent(string actionTook, decimal moneyFedIn, decimal balanceAfter)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(LogFilePath, true))
                {
                    sw.WriteLine($"{DateTime.Now} {actionTook} {moneyFedIn:C2} {balanceAfter:C2}");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}
