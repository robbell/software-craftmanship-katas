namespace BankAccountLondonStyle.UnitTests
{
    public class Account
    {
        public virtual void Deposit(int amount)
        {
        }

        public virtual void Withdraw(int amount)
        {
        }

        public virtual AccountStatement CreateStatement()
        {
            return null;
        }
    }
}