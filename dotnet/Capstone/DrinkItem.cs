using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class DrinkItem
    {

        public string Messege { get; } = "Glug, Glug, YUM!";

        public DrinkItem()
        {

        }

        public static string GetMessege()
        {
            DrinkItem drink = new DrinkItem();
            return drink.Messege;
        }

    }
}
