using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone;

namespace CapstoneTests
{

    [TestClass]
    public class VendingMachineTests
    {

        [TestMethod]
        public void VendingMachineRefills5_OfEachItemAndPropertiesAssigned()
        {

            string @string = "A1|a|0.10|Chip";

            VendingMachineItem vendingMachineItem = new VendingMachineItem();
            vendingMachineItem.RefillVendingMachine(@string, vendingMachineItem);

            Assert.AreEqual(VendingMachineItem.itemQuantityPair["a"], vendingMachineItem.Quantity, 5);
            Assert.AreEqual(vendingMachineItem.ItemType, "chip");
            Assert.AreEqual(vendingMachineItem.Price, 0.10M);
            Assert.AreEqual(vendingMachineItem.SlotId, "A1");
            
        }

    }
    
}
