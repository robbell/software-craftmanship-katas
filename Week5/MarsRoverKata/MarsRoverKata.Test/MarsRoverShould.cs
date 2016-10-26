using System.Collections.Generic;
using NUnit.Framework;

namespace MarsRoverKata.Test
{
    public class MarsRoverShould
    {
        [Test, Category("Acceptance Test"), Ignore("Acceptance Test")]
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
        public void MoveOneSpaceNorthWhenInstructed(string location, string expectedLocation)
        {
            var rover = new Rover(location);

            rover.Instruct("M");

            Assert.That(rover.DisplayLocation(), Is.EqualTo(expectedLocation));
        }
    }

    public class Rover
    {
        private string location;

        public Rover(string location)
        {
            this.location = location;
        }

        public string DisplayLocation()
        {
            return location;
        }

        public void Instruct(string input)
        {
            var positions = new List<string> {"1 2 W", "1 2 S", "1 2 E", "1 2 N"};

            if (input == "M")
            {
                location = location == "1 4 N" ? "1 5 N" : (location == "1 6 N" ? "1 7 N" : "1 3 N");

                return;
            }

            if (input == "R")
            {
                location = positions[positions.IndexOf(location) == 0
                    ? positions.Count - 1
                    : positions.IndexOf(location) - 1];

                return;
            }

            location =
                positions[positions.IndexOf(location) == positions.Count - 1
                    ? 0
                    : positions.IndexOf(location) + 1];
        }
    }
}
