using System;
using System.Linq;
using Moq;
using NUnit.Framework;

namespace BankAccountLondonStyle.UnitTests
{
    [TestFixture]
    public class AccountShould
    {
        [Test]
        public void DepositAmount()
        {
            var expectedDate = new DateTime(2012, 1, 2);
            var clock = Mock.Of<Clock>(x => x.Now() == expectedDate);
            var account = new Account(clock);

            account.Deposit(10);

            var transaction = account.ListTransactions().First();
            Assert.That(transaction.Amount, Is.EqualTo(10));
            Assert.That(transaction, Is.TypeOf<Credit>());
            Assert.That(transaction.Date, Is.EqualTo(expectedDate));
        }

        [Test]
        public void CreditAmount()
        {
            var expectedDate = new DateTime(2012, 1, 2);
            var clock = Mock.Of<Clock>(x => x.Now() == expectedDate);
            var account = new Account(clock);

            account.Withdraw(20);

            var transaction = account.ListTransactions().First();
            Assert.That(transaction.Amount, Is.EqualTo(20));
            Assert.That(transaction, Is.TypeOf<Debit>());
            Assert.That(transaction.Date, Is.EqualTo(expectedDate));
        }
    }
}