using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class CandyItem : VendingMachineItem, IPurchasable
    {

        public string Messege { get; } = "Munch, Munch, YUM!";

        public CandyItem()
        {

        }

        public static string GetMessege()
        {
            CandyItem candy = new CandyItem();
            return candy.Messege;
        }

    }
}
