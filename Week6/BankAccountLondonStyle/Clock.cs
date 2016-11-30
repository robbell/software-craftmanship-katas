using System;

namespace BankAccountLondonStyle.UnitTests
{
    public class Clock
    {
        public virtual DateTime Now()
        {
            return DateTime.Now;
        }
    }
}