using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public class Transactions
    {

        //CONSTANTS
        public const decimal Quarter = 0.25M;
        public const decimal Dime = 0.10M;
        public const decimal Nickel = 0.05M;

        //METHODS
        public static string GiveChange()
        {

            int quartersGiven = 0;
            int dimesGiven = 0;
            int nickelsGiven = 0;
            decimal balanceBefore = VendingMachine.balance;

            string message = "";

            if (balanceBefore == 0)
            {
                message = "No change";
            }
            else
            {
                while (VendingMachine.balance > 0)
                {
                    if (VendingMachine.balance >= Quarter)
                    {
                        quartersGiven++;
                        VendingMachine.balance -= Quarter;
                    }
                    else if (VendingMachine.balance >= Dime)
                    {
                        dimesGiven++;
                        VendingMachine.balance -= Dime;
                    }
                    else
                    {
                        nickelsGiven++;
                        VendingMachine.balance -= Nickel;
                    }
                }

                Log.LogEvent("GIVE CHANGE:", balanceBefore);
                message = $"Your change is {quartersGiven} quarters, {dimesGiven} dimes, and {nickelsGiven} nickels for a total of {Quarter * quartersGiven + Dime * dimesGiven + Nickel * nickelsGiven:C2}";
            }

            return message;

        }

        public static void FeedMoney(string userChoice)
        {

            while (userChoice != "5")
            {
               
                AddAcceptableBillsOnly(userChoice);
                userChoice = Console.ReadLine();
                if (userChoice == "5")
                {
                    VendingMachine.DisplayPurchaseMenu();
                }
            }
        }

        public static void PurchaseItem(string userChoice)
        {

            int numberOfItemsChecked = 0;

            foreach (VendingMachineItem item in VendingMachineItem.vendingMachineItemsProprerties)
            {
                if (userChoice.Equals(item.SlotId))
                {
                    if (VendingMachine.balance >= item.Price && item.Quantity != 0)
                    {

                        VendingMachine.balance -= item.Price;
                        item.Quantity--;
                        VendingMachineItem.itemQuantityPair[item.Name] = item.Quantity;
                        Log.LogEvent($"{item.SlotId} {item.Name}:", VendingMachine.balance + item.Price);

                        Console.WriteLine($"Dispensing {item.Name}. Cost: {item.Price:C2}. Remaining balance: {VendingMachine.balance:C2}");

                        Console.WriteLine(Transactions.GetMessege(item.ItemType));

                        Console.WriteLine("Press ENTER to return back to Purchase Menu.");
                        Console.ReadLine();
                        VendingMachine.DisplayPurchaseMenu();

                    }
                    else
                    {

                        Console.WriteLine("Insufficient funds or item is sold out. Please deposit more funds or choose another item.");
                        Console.WriteLine("(1) Deposit More Funds");
                        Console.WriteLine("(2) Choose Another Item");

                        string inputChoice = Console.ReadLine();

                        if (inputChoice == "1")
                        {
                            VendingMachine.DisplayFeedMoneyMenu();
                            return;
                        }
                        else
                        {
                            VendingMachine.DisplayPurchaseItemMenu();
                            return;
                        }

                    }
                }
                else
                {

                    numberOfItemsChecked++;
                    if (numberOfItemsChecked == VendingMachineItem.vendingMachineItemsProprerties.Count)
                    {
                        Console.WriteLine("Invalid item selected. Please choose valid slot ID.");
                        VendingMachine.DisplayPurchaseItemMenu();
                        return;
                    }

                }
            }
        }

        public static string GetMessege(string itemTypeChosen)
        {

            switch (itemTypeChosen)
            {
                case "chip":
                    {
                        return ChipItem.GetMessege();
                    }
                case "candy":
                    {
                        return CandyItem.GetMessege();
                    }
                case "drink":
                    {
                        return DrinkItem.GetMessege();
                    }
                case "gum":
                    {
                        return GumItem.GetMessege();
                    }
            }

            return "Please choose another item.";

        }

        public static int CanPurchaseItem(string userChoice)
        {

            int caseNumber = 0;

            foreach (VendingMachineItem item in VendingMachineItem.vendingMachineItemsProprerties)
            {
                if (userChoice.Equals(item.SlotId))
                {

                    if (VendingMachine.balance >= item.Price && item.Quantity != 0)
                    {
                        caseNumber = 0; // 0 = Yes, Can Purchase
                    }
                    else if (VendingMachine.balance < item.Price)
                    {
                        caseNumber = 1; // 1 : No, Insufficient Balance
                    }
                    else if (item.Quantity == 0)
                    {
                        caseNumber = 3; // 3 : No, Sold Out
                    }

                }
                else
                {
                    caseNumber = 2; // 2 : No, Invalid ID
                }

            }

            return caseNumber;
        }

        public static string AddAcceptableBillsOnly(string userChoice)
        {
            switch (userChoice)
            {
                case "1":
                    VendingMachine.balance++;
                    Log.LogEvent("FEED MONEY:", 1, VendingMachine.balance);
                    Console.WriteLine($"Current balance is {VendingMachine.balance:C2}.");
                    break;

                case "2":
                    VendingMachine.balance += 2;
                    Log.LogEvent("FEED MONEY:", 2, VendingMachine.balance);
                    Console.WriteLine($"Current balance is {VendingMachine.balance:C2}.");
                    break;

                case "3":
                    VendingMachine.balance += 5;
                    Log.LogEvent("FEED MONEY:", 5, VendingMachine.balance);
                    Console.WriteLine($"Current balance is {VendingMachine.balance:C2}.");
                    break;

                case "4":
                    VendingMachine.balance += 10;
                    Log.LogEvent("FEED MONEY:", 10, VendingMachine.balance);
                    Console.WriteLine($"Current balance is {VendingMachine.balance:C2}.");
                    break;

                default:
                    Console.WriteLine("Invalid bill selection. Please insert $1, $2, $5, or $10 bills only.");
                    break;
            }

            return Convert.ToString(VendingMachine.balance);
        }

    }
}
