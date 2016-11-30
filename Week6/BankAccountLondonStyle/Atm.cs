using System.Linq;

namespace BankAccountLondonStyle.UnitTests
{
    public class Atm
    {
        private readonly Printer printer;
        private readonly Account account;
        private readonly StatementFormatter statementFormatter;

        public Atm(Printer printer, Account account, StatementFormatter statementFormatter)
        {
            this.printer = printer;
            this.account = account;
            this.statementFormatter = statementFormatter;
        }

        public void PrintStatement()
        {
            printer.PrintStatement(statementFormatter.CreateStatement(account.ListTransactions()));
        }

        public void Deposit(int amount)
        {
            account.Deposit(amount);
        }

        public void Withdraw(int amount)
        {
            account.Withdraw(amount);
        }
    }
}