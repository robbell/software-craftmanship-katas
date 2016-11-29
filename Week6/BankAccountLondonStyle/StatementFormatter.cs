using System.Collections.Generic;
using System.Text;

namespace BankAccountLondonStyle.UnitTests
{
    public class StatementFormatter
    {
        public virtual string CreateStatement(IList<Transaction> transactions)
        {
            var transactionText = new StringBuilder();
            transactionText.AppendLine("date || credit || debit || balance");

            foreach (var transaction in transactions)
            {
                if (transaction is Credit)
                {
                    transactionText.AppendLine(
                        $"{transaction.Date.ToString("dd / MM / yyyy")} || {transaction.Amount}.00 || || {transaction.Amount}.00");
                }
                else
                {
                    transactionText.AppendLine(
                        $"{transaction.Date.ToString("dd / MM / yyyy")} || || {transaction.Amount}.00 || {transaction.Amount}.00");
                }
            }

            return transactionText.ToString().TrimEnd();
        }
    }
}