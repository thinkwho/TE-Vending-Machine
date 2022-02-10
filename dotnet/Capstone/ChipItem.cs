using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class ChipItem : VendingMachineItem, IPurchasable
    {

        public string Messege { get; } = "Crunch, Crunch, YUM!";

        public ChipItem()
        {

        }

        public static string GetMessege()
        {
            ChipItem chip = new ChipItem();
            return chip.Messege;
        }

    }
}
