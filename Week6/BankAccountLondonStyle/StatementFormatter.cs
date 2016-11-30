using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankAccountLondonStyle.UnitTests
{
    public class StatementFormatter
    {
        public virtual string CreateStatement(IEnumerable<Transaction> transactions)
        {
            var transactionText = new StringBuilder();
            
            var balance = 0;

            foreach (var transaction in transactions)
            {
                balance = transaction.AdjustBalance(balance);

                if (transaction is Credit)
                {
                    transactionText.Insert(0,
                        $"{transaction.Date.ToString("dd / MM / yyyy")} || {transaction.Amount}.00 || || {balance}.00"  + Environment.NewLine);
                }
                else
                {
                    transactionText.Insert(0,
                        $"{transaction.Date.ToString("dd / MM / yyyy")} || || {transaction.Amount}.00 || {balance}.00" + Environment.NewLine);
                }
            }

            transactionText.Insert(0, "date || credit || debit || balance" + Environment.NewLine);

            return transactionText.ToString().TrimEnd();
        }
    }
}