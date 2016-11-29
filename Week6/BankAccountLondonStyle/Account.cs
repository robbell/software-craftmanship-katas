using System;
using System.Collections.Generic;

namespace BankAccountLondonStyle.UnitTests
{
    public class Account
    {
        private readonly IList<Transaction> transactions = new List<Transaction>();

        public virtual void Deposit(int amount)
        {
            transactions.Add(new Transaction { Amount = amount });
        }

        public virtual void Withdraw(int amount)
        {
            transactions.Add(new Transaction { Amount = amount });
        }

        public IEnumerable<Transaction> ListTransactions()
        {
            return transactions;
        }
    }

    public class Transaction
    {
        public int Amount { get; set; }
        public DateTime Date { get; set; }
    }
}