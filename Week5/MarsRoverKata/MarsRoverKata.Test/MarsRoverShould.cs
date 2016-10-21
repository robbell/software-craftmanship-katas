using NUnit.Framework;

namespace MarsRoverKata.Test
{
    public class MarsRoverShould
    {
        [Test, Category("Acceptance Test")]
        public void DisplayLocationOfRoverAfterInstructions()
        {
            var input = "LMLMLMLMM";

            var rover = new Rover("1 2 N");

            rover.Instruct(input);

            Assert.That(rover.DisplayLocation(), Is.EqualTo("1 3 N"));
        }

        [TestCase("1 2 N")]
        [TestCase("5 3 N")]
        public void DisplayInitialLocation(string location)
        {
            var rover = new Rover(location);

            Assert.That(rover.DisplayLocation(), Is.EqualTo(location));
        }
    }

    public class Rover
    {
        private string v;

        public Rover(string v)
        {
            this.v = v;
        }

        public string DisplayLocation()
        {
            return "1 2 N";
        }

        public void Instruct(string input)
        {
        }
    }
}
