using NUnit.Framework;

namespace MarsRoverKata.Test
{
    public class MarsRoverShould
    {
        [TestCase("LMLMLMLMM", "1 2 N", "1 3 N"), Category("Acceptance Test")]
        public void DisplayLocationOfRoverAfterInstructions(string input, string startLocation, string expectedLocation)
        {
            var rover = new Rover(startLocation);

            rover.Instruct(input);

            Assert.That(rover.DisplayLocation(), Is.EqualTo(expectedLocation));
        }

        [TestCase("1 2 N")]
        [TestCase("5 3 N")]
        public void DisplayInitialLocation(string location)
        {
            var rover = new Rover(location);

            Assert.That(rover.DisplayLocation(), Is.EqualTo(location));
        }

        [TestCase("1 2 N", "1 2 W")]
        [TestCase("1 2 W", "1 2 S")]
        [TestCase("1 2 S", "1 2 E")]
        public void ChangeDirectionWhenToldToTurnLeft(string location, string expectedLocation)
        {
            var rover = new Rover(location);

            rover.Instruct("L");

            Assert.That(rover.DisplayLocation(), Is.EqualTo(expectedLocation));
        }

        [TestCase("1 2 S", "1 2 W")]
        [TestCase("1 2 W", "1 2 N")]
        public void ChangeDirectionWhenToldToTurnRight(string location, string expectedLocation)
        {
            var rover = new Rover(location);

            rover.Instruct("R");

            Assert.That(rover.DisplayLocation(), Is.EqualTo(expectedLocation));
        }

        [TestCase("1 2 N", "1 3 N")]
        [TestCase("1 4 N", "1 5 N")]
        [TestCase("1 6 N", "1 7 N")]
        [TestCase("1 6 E", "2 6 E")]
        [TestCase("1 6 S", "1 5 S")]
        public void MoveOneSpaceWhenInstructed(string location, string expectedLocation)
        {
            var rover = new Rover(location);

            rover.Instruct("M");

            Assert.That(rover.DisplayLocation(), Is.EqualTo(expectedLocation));
        }
    }
}
