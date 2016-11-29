using System.Linq;
using NUnit.Framework;

namespace BankAccountLondonStyle.UnitTests
{
    [TestFixture]
    public class AccountShould
    {
        [Test]
        public void DepositAmount()
        {
            var account = new Account();

            account.Deposit(10);

            Assert.That(account.ListTransactions().First().Amount, Is.EqualTo(10));
        }

        [Test]
        public void CreditAmount()
        {
            var account = new Account();

            account.Withdraw(20);

            Assert.That(account.ListTransactions().First().Amount, Is.EqualTo(20));
        }
    }
}