using System;
using System.IO;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //string refillFile = @"C:\Users\Student\workspace\orange-mod1-capstone-team1\dotnet\vendingmachine.csv";
            string refillFile = @"C:\Users\Student\Desktop\vendingmachine.csv";

            try
            {
                using (StreamReader sr = new StreamReader(refillFile))
                {
                    while (!sr.EndOfStream)
                    {

                        VendingMachineItem vendingMachineItem = new VendingMachineItem();
                        vendingMachineItem.RefillVendingMachine(sr.ReadLine(), vendingMachineItem);

                    }
                }
            }
            catch (IOException ex)
            {

                Console.WriteLine(ex.Message); ;
            }

            VendingMachine.DisplayMainMenu();            

        }
    }
}
