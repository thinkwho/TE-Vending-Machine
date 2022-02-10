using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class GumItem
    {

        public string Messege { get; } = "Chew, Chew, YUM!";

        public GumItem()
        {

        }

        public static string GetMessege()
        {
            GumItem gum = new GumItem();
            return gum.Messege;
        }

    }
}
