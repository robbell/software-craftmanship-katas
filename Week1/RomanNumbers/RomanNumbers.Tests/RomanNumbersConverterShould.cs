using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace RomanNumbers.Tests
{
    [TestFixture]
    public class RomanNumbersConverterShould
    {
        [TestCase(1, ExpectedResult = "I")]
        [TestCase(2, ExpectedResult = "II")]
        [TestCase(4, ExpectedResult = "IV")]
        [TestCase(5, ExpectedResult = "V")]
        [TestCase(6, ExpectedResult = "VI")]
        [TestCase(7, ExpectedResult = "VII")]
        [TestCase(8, ExpectedResult = "VIII")]
        [TestCase(9, ExpectedResult = "IX")]
        [TestCase(10, ExpectedResult = "X")]
        [TestCase(11, ExpectedResult = "XI")]
        [TestCase(40, ExpectedResult = "XL")]
        [TestCase(41, ExpectedResult = "XLI")]
        [TestCase(50, ExpectedResult = "L")]
        [TestCase(51, ExpectedResult = "LI")]
        [TestCase(90, ExpectedResult = "XC")]
        [TestCase(91, ExpectedResult = "XCI")]
        [TestCase(100, ExpectedResult = "C")]
        [TestCase(400, ExpectedResult = "CD")]
        [TestCase(500, ExpectedResult = "D")]
        [TestCase(900, ExpectedResult = "CM")]
        [TestCase(1000, ExpectedResult = "M")]
        [TestCase(1999, ExpectedResult = "MCMXCIX")]
        public string ConvertNumberToRoman(int number)
        {
            var converter = new RomanNumbersConverter();
            return converter.Convert(number);
        }
    }

    public class RomanNumbersConverter
    {
        public string Convert(int number)
        {
            var conversions = new Dictionary<int, string>
            {
                {4, "IV"},
                {5, "V"},
                {9, "IX"},
                {10, "X"},
                {40, "XL"},
                {50, "L"},
                {90, "XC"},
                {100, "C"},
                {400, "CD"},
                {500, "D"},
                {900, "CM"},
                {1000, "M"}
            };

            if (conversions.ContainsKey(number)) return conversions[number];

            foreach (var conversion in conversions.Reverse())
            {
                if (number > conversion.Key) return conversion.Value + Convert(number - conversion.Key);
            }

            return new string('I', number);
        }
    }
}
