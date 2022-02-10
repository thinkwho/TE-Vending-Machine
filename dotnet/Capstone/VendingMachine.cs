using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{

    public class VendingMachine
    {
        
        //FIELDS
        public static decimal balance { get; set; } = 0;
        
        //CONSTRUCTOR
        public VendingMachine()
        {
            
        }

        //METHODS
        public static void DisplayMainMenu()
        {

            Console.WriteLine();
            Console.WriteLine("Main Menu");
            Console.WriteLine();

            Console.WriteLine("(1) Display Vending Machine Items");
            Console.WriteLine("(2) Purchase");
            Console.WriteLine("(3) Exit");

            int userChoice = 0;

            try
            {
                userChoice = int.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                DisplayMainMenu();
                return;
            }
            catch(OverflowException ex)
            {
                Console.WriteLine(ex.Message);
                DisplayMainMenu();
                return;
            }

            switch (userChoice)
            {
                
                case 1:
                    VendingMachine.DisplayVendingMachineItems();
                    break;

                case 2:
                    VendingMachine.DisplayPurchaseMenu();
                    break;

                case 3:
                    Console.WriteLine("Thank you for using our vending machine. Come again!");
                    break;

                case 4:                    
                    Console.WriteLine("Generating Sales Report...");
                    SalesReport.ExportSalesReportCreate();
                    Console.WriteLine();
                    Console.WriteLine("Sales Report Has Been Generated, Thank You!");
                    return;

                default:
                    Console.WriteLine("Invalid option selected. Please enter a valid choice.");
                    DisplayMainMenu();
                    break;

            }

        }

        public static void DisplayPurchaseMenu()
        {

            Console.WriteLine();
            Console.WriteLine("Purchase Menu");
            Console.WriteLine();

            Console.WriteLine("(1) Feed Money");
            Console.WriteLine("(2) Select Item");
            Console.WriteLine("(3) Finish Transaction");
            Console.WriteLine();

            Console.WriteLine($"Current Balance: {balance:C2}");

            int userChoice = 0;

            try
            {
                userChoice = int.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Please select a valid option.");
                Console.WriteLine();
                DisplayPurchaseMenu();
                return;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Please select a valid option.");
                Console.WriteLine();
                DisplayPurchaseMenu();
                return;
            }
            

            switch (userChoice)
            {

                case 1:
                    DisplayFeedMoneyMenu();
                    break;

                case 2:
                    VendingMachine.DisplayPurchaseItemMenu();
                    break;

                case 3:
                    Console.WriteLine(Transactions.GiveChange());
                    VendingMachine.DisplayMainMenu();
                    break;
                    
                default:
                    Console.WriteLine("Invalid option selected. Please enter a valid choice.");
                    VendingMachine.DisplayPurchaseMenu();
                    break;
 
            }

        }


        public static void DisplayFeedMoneyMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Please Insert Money");
            Console.WriteLine();

            Console.WriteLine("(1) $1.00");
            Console.WriteLine("(2) $2.00");
            Console.WriteLine("(3) $5.00");
            Console.WriteLine("(4) $10.00");
            Console.WriteLine("(5) Exit");

            string userChoice = Console.ReadLine();

            if(userChoice != "5")
            {
                Transactions.FeedMoney(userChoice);
            }
            else
            {
                DisplayPurchaseMenu();
                return;
            }

        }

        public static void DisplayPurchaseItemMenu()
        {
            foreach (VendingMachineItem item in VendingMachineItem.vendingMachineItemsProprerties)
            {
                Console.WriteLine($"{item.SlotId} {item.Name} {item.Price:C2} {item.Quantity}");
            }

            Console.WriteLine();
            Console.WriteLine("Please Select Slot ID of what you would like :) ");

            Console.WriteLine();
            Console.WriteLine("Enter \"Exit\" to go back to the Purchase Menu.");
            string userChoice = Console.ReadLine();

            try
            {
                if (userChoice.ToLower() == "exit")
                {
                    DisplayPurchaseMenu();
                }
                else
                {
                    Transactions.PurchaseItem(userChoice);
                }
            }
            catch (FormatException ex)
            {

                Console.WriteLine(ex.Message);
                DisplayPurchaseItemMenu();
                return;
            }

            
        }

        public static void DisplayVendingMachineItems()
        {

            foreach (KeyValuePair<string, int> item in VendingMachineItem.itemQuantityPair)
            {

                if (item.Value == 0)
                {
                    Console.WriteLine($"{item.Key}: Sold Out");
                }
                else
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Hit ENTER to go back to the main menu");
            Console.ReadLine();
            DisplayMainMenu();

        }

    }
}
