using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Moq;
using NUnit.Framework;

namespace BankAccountLondonStyle.UnitTests
{
    [TestFixture]
    public class AtmShould
    {
        [Test]
        public void ListAllTransactions()
        {
            var expectedTransactions =
@"date || credit || debit || balance
14 / 01 / 2012 || || 500.00 || 2500.00
13 / 01 / 2012 || 2000.00 || || 3000.00
10 / 01 / 2012 || 1000.00 || || 1000.00";

            var output = new StringBuilder();
            var stream = new StringWriter(output);
            Console.SetOut(stream);

            var atm = new Atm(new Printer(), new Account(), new StatementFormatter());

            atm.Deposit(1000);
            atm.Deposit(2000);
            atm.Withdraw(500);
            atm.PrintStatement();

            Assert.That(output.ToString(), Is.EqualTo(expectedTransactions));
        }

        [Test]
        public void DepositMoneyToAccount()
        {
            var account = new Mock<Account>();

            var atm = new Atm(null, account.Object, new StatementFormatter());

            atm.Deposit(200);

            account.Verify(a => a.Deposit(200));
        }

        [Test]
        public void WithdrawMoneyFromAccount()
        {
            var account = new Mock<Account>();

            var atm = new Atm(null, account.Object, new StatementFormatter());

            atm.Withdraw(200);

            account.Verify(a => a.Withdraw(200));
        }

        [Test]
        public void GetStatementFromAccount()
        {
            var expectedStatement = "My statement headings";
            var statementFormatter = Mock.Of<StatementFormatter>(a => a.CreateStatement(It.IsAny<IList<Transaction>>()) == expectedStatement);
            var printer = Mock.Of<Printer>();

            var atm = new Atm(printer, new Account(), statementFormatter);

            atm.PrintStatement();

            Mock.Get(printer).Verify(p => p.PrintStatement(expectedStatement));
        }
    }
}
