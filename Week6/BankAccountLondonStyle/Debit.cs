namespace BankAccountLondonStyle.UnitTests
{
    public class Debit : Transaction
    {
        public override int AdjustBalance(int balance)
        {
            return balance - Amount;
        }
    }
}