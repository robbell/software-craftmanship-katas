using System.Collections.Generic;

namespace BankAccountLondonStyle.UnitTests
{
    public class Account
    {
        private readonly IList<Transaction> transactions = new List<Transaction>();
        private Clock clock;

        public Account()
        {
            clock = new Clock();
        }

        public Account(Clock clock)
        {
            this.clock = clock;
        }

        public virtual void Deposit(int amount)
        {
            transactions.Add(new Credit { Amount = amount, Date = clock.Now() });
        }

        public virtual void Withdraw(int amount)
        {
            transactions.Add(new Debit { Amount = amount, Date = clock.Now() });
        }

        public IEnumerable<Transaction> ListTransactions()
        {
            return transactions;
        }
    }
}