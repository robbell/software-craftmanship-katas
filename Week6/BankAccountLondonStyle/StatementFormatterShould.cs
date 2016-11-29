using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace BankAccountLondonStyle.UnitTests
{
    [TestFixture]
    public class StatementFormatterShould
    {
        [Test]
        public void CreateStatementWithNoTransactions()
        {
            var statementFormatter = new StatementFormatter();
            var expectedStatement = "date || credit || debit || balance";

            var statement = statementFormatter.CreateStatement(new List<Transaction>());

            Assert.That(statement, Is.EqualTo(expectedStatement));
        }

        [Test]
        public void CreateStatementWithOneDeposit()
        {
            var statementFormatter = new StatementFormatter();
            var transactions = new List<Transaction> { new Credit { Amount = 1000, Date = new DateTime(2012, 1, 10) } };

            var expectedStatement = 
@"date || credit || debit || balance
10 / 01 / 2012 || 1000.00 || || 1000.00";

            var statement = statementFormatter.CreateStatement(transactions);

            Assert.That(statement, Is.EqualTo(expectedStatement));
        }

        [Test]
        public void CreateStatementWithOneWithdrawal()
        {
            var statementFormatter = new StatementFormatter();
            var transactions = new List<Transaction> { new Debit { Amount = 500, Date = new DateTime(2012, 1, 14) } };

            var expectedStatement =
@"date || credit || debit || balance
14 / 01 / 2012 || || 500.00 || 500.00";

            var statement = statementFormatter.CreateStatement(transactions);

            Assert.That(statement, Is.EqualTo(expectedStatement));
        }

        [Test, Ignore("Not yet implemented")]
        public void CreateStatementWithTwoDeposits()
        {
            var statementFormatter = new StatementFormatter();
            var transactions = new List<Transaction> { new Debit { Amount = 500, Date = new DateTime(2012, 1, 14) } };

            var expectedStatement =
@"date || credit || debit || balance
14 / 01 / 2012 || || 500.00 || 500.00";

            var statement = statementFormatter.CreateStatement(transactions);

            Assert.That(statement, Is.EqualTo(expectedStatement));
        }
    }
}