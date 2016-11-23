namespace BankAccountLondonStyle.UnitTests
{
    public class Atm
    {
        private readonly Printer printer;
        private readonly Account account;

        public Atm(Printer printer, Account account)
        {
            this.printer = printer;
            this.account = account;
        }

        public void PrintStatement()
        {
            printer.PrintStatement(account.CreateStatement());
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