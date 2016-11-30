using System;

namespace BankAccountLondonStyle.UnitTests
{
    public class Printer
    {
        public virtual void PrintStatement(string statement)
        {
            Console.Write(statement);
        }
    }
}