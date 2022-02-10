using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone
{
    public class VendingMachineItem
    {

        //CONSTANTS
        public const int Fully_Stocked = 5;
        
        //Fields
        public static Dictionary<string, int> itemQuantityPair = new Dictionary<string, int>();
        public static List<VendingMachineItem> vendingMachineItemsProprerties = new List<VendingMachineItem>();

        //PROPERTIES
        public string SlotId { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public string ItemType { get; private set; }
        public int Quantity { get; internal set; }

        public VendingMachineItem() { }

        public int TotalSoldPerStock
        {
            get
            {
                return Fully_Stocked - Quantity;
            }
        }
        
        public decimal TotalSalesPerStock
        {
            get
            {
                return Price * TotalSoldPerStock;
            }
        }

        //METHODS
        public void RefillVendingMachine(string x, VendingMachineItem vendingMachineItem)
        {

            string[] itemProperties = x.Split("|");
            this.SlotId = itemProperties[0];
            this.Name = itemProperties[1];
            this.Price = decimal.Parse(itemProperties[2]);
            this.ItemType = itemProperties[3].ToLower();
            this.Quantity = Fully_Stocked;
            
            //ship to Display List
            itemQuantityPair.Add(this.Name, this.Quantity);

            //ship to Select - Item List
            vendingMachineItemsProprerties.Add(vendingMachineItem);

        }        
    }
}
