using System.Collections.Generic;
using NUnit.Framework;

namespace GameOfLife.Test
{
    [TestFixture]
    public class UniverseShould
    {
        [Test]
        public void AllowCellsToBeAdded()
        {
            var cell = new Cell(State.Dead);
            var universe = new Universe();

            universe.SetCell(cell, 2, 3);

            Assert.That(universe.GetCell(2, 3), Is.EqualTo(cell));
        }

        [Test]
        public void KillCellWhenItHasNoNeighbours()
        {
            var universe = new Universe();

            universe.SetCell(new Cell(State.Alive), 1, 3);

            universe.Tick();

            Assert.That(universe.GetCell(1, 3).GetState(), Is.EqualTo(State.Dead));
        }

        [Test]
        public void KeepCellAliveWhenItHasTwoNeighbours()
        {
            var universe = new Universe();

            universe.SetCell(new Cell(State.Alive), 1, 3);
            universe.SetCell(new Cell(State.Alive), 2, 3);
            universe.SetCell(new Cell(State.Alive), 3, 3);

            universe.Tick();

            Assert.That(universe.GetCell(2, 3).GetState(), Is.EqualTo(State.Alive));
        }
    }

    public class Universe
    {
        private Cell[] cells = new Cell[9];

        public void SetCell(Cell cell, int x, int y)
        {
            cells[x] = cell;
        }

        public Cell GetCell(int x, int y)
        {
            return cells[x];
        }

        public void Tick()
        {
            cells[1].Tick(cells.Length);
        }
    }
}
