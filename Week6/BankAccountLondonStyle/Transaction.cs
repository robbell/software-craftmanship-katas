using System;

namespace BankAccountLondonStyle.UnitTests
{
    public class Transaction
    {
        public virtual int Amount { get; set; }
        public DateTime Date { get; set; }

        public virtual int AdjustBalance(int balance)
        {
            return balance + Amount;
        }
    }
}