using System;
using System.Collections.Generic;

namespace MarsRoverKata.Test
{
    public class Rover
    {
        private Position position;
        private static Dictionary<string, Func<int, int, Position>> _dictionary;

        public Rover(string location)
        {
            InitialisePosition(location);
        }

        public string DisplayLocation()
        {
            return $"{position.X} {position.Y} {position.Direction}";
        }

        public void Instruct(string input)
        {
            foreach (var instruction in input)
            {
                SingleInstruction(instruction.ToString());
            }
        }

        private void SingleInstruction(string input)
        {
            var directions = new List<string> { "W", "S", "E", "N" };

            _dictionary = new Dictionary<string, Func<int, int, Position>>
            {
                {"N", (x, y) => new Position(x, y + 1, "N")},
                {"E", (x, y) => new Position(x + 1, y, "E")},
                {"S", (x, y) => new Position(x, y - 1, "S")},
                {"W", (x, y) => new Position(x - 1, y, "W")},
            };

            if (input == "M")
            {
                position = Move(position);
            }

            if (input == "R")
            {
                position.Direction = directions[directions.IndexOf(position.Direction) == 0
                    ? directions.Count - 1
                    : directions.IndexOf(position.Direction) - 1];
            }

            if (input == "L")
            {
                position.Direction = directions[directions.IndexOf(position.Direction) == directions.Count - 1
                    ? 0
                    : directions.IndexOf(position.Direction) + 1];
            }
        }

        private static Position Move(Position position2)
        {
            return _dictionary[position2.Direction](position2.X, position2.Y);
        }

        private void InitialisePosition(string location)
        {
            var data = location.Split(' ');
            var xCoordinate = Convert.ToInt32(data[0]);
            var yCoordinate = Convert.ToInt32(data[1]);
            var direction = data[2];

            position = new Position(xCoordinate, yCoordinate, direction);
        }
    }

    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Direction { get; set; }

        public Position(int x, int y, string direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }
    }
}