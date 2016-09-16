using NUnit.Framework;

namespace LeapYear.Tests
{
    [TestFixture]
    public class LeapYearTest
    {
        [TestCase(4)]
        [TestCase(8)]
        [TestCase(12)]
        [TestCase(400)]
        [TestCase(800)]
        public void IdentifiesValidLeapYear(int year)
        {
            var leapYearValidator = new LeapYearValidator();

            Assert.That(leapYearValidator.Validate(year), Is.True);
        }

        [TestCase(5)]
        [TestCase(100)]
        [TestCase(200)]
        [TestCase(300)]
        public void IdentifiesNonValidLeapYear(int year)
        {
            var leapYearValidator = new LeapYearValidator();

            Assert.That(leapYearValidator.Validate(year), Is.False);
        }
    }

    public class LeapYearValidator
    {
        public bool Validate(int year)
        {
            if (year % 400 == 0) return true;

            if (year % 100 == 0) return false;

            return year % 4 == 0;
        }
    }
}
