using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone;

namespace CapstoneTests
{
    [TestClass]
    public class TransactionsTests
    {
        [TestMethod]
        public void LeastChangeGiven()
        {
           
            VendingMachine.balance = 10M;
            string testMessage = Transactions.GiveChange();
            Assert.AreEqual("Your change is 40 quarters, 0 dimes, and 0 nickels for a total of $10.00", testMessage);

            VendingMachine.balance = 0.35M;
            string testMessage1 = Transactions.GiveChange();
            Assert.AreEqual("Your change is 1 quarters, 1 dimes, and 0 nickels for a total of $0.35", testMessage1);

            VendingMachine.balance = 0.05M;
            string testMessage2 = Transactions.GiveChange();
            Assert.AreEqual("Your change is 0 quarters, 0 dimes, and 1 nickels for a total of $0.05", testMessage2);

            VendingMachine.balance = 0.00M;
            string testMessage3 = Transactions.GiveChange();
            Assert.AreEqual("No change", testMessage3);

        }

        [TestMethod]
        public void OutputCorrectMessegeForItemType()
        {

            string messege = Transactions.GetMessege("chip");
            Assert.AreEqual("Crunch, Crunch, YUM!", messege);

            string messege2 = Transactions.GetMessege("candy");
            Assert.AreEqual("Munch, Munch, YUM!", messege2);

            string messege3 = Transactions.GetMessege("drink");
            Assert.AreEqual("Glug, Glug, YUM!", messege3);

            string messege4 = Transactions.GetMessege("gum");
            Assert.AreEqual("Chew, Chew, YUM!", messege4);

        }

        [TestMethod]
        public void AttemptToPurchaseItemReturnsCorrectOutput()
        {

            string @string = "A1|b|0.10|Chip";
            VendingMachineItem vendingMachineItem = new VendingMachineItem();
            vendingMachineItem.RefillVendingMachine(@string, vendingMachineItem);

            VendingMachine.balance = .05M;
            int result = Transactions.CanPurchaseItem("A1");
            Assert.AreEqual(1, result);

            VendingMachine.balance = .20M;
            int result1 = Transactions.CanPurchaseItem("asjdhnaisdhaisdh");
            Assert.AreEqual(2, result1);

        }

        [TestMethod]
        public void FeedMoneyOnlyAcceptsCertainBills()
        {
            VendingMachine.balance = .00M;
            Transactions.AddAcceptableBillsOnly("1");
            Assert.AreEqual(decimal.Parse("1.00"), VendingMachine.balance);

            VendingMachine.balance = 100M;
            Transactions.AddAcceptableBillsOnly("4");
            Assert.AreEqual(decimal.Parse("110.00"), VendingMachine.balance);

            VendingMachine.balance = 100M;
            Transactions.AddAcceptableBillsOnly("sdfjsdiofjsdifj");
            Assert.AreEqual(decimal.Parse("100.00"), VendingMachine.balance);

        }
        

    }
}
