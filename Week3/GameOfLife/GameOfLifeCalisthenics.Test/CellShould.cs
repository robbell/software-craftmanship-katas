using GameOfLifeCalisthenics.Src;
using NUnit.Framework;

namespace GameOfLifeCalisthenics.Test
{
    [TestFixture]
    public class CellShould
    {
        private Neighbours neighbours;

        [SetUp]
        public void SetUp()
        {
            neighbours = new Neighbours();

        }

        [Test]
        public void DieWhenItIsAliveAndHasFewerThanTwoNeighbours()
        {
            var cell = new Cell(State.Alive);

            neighbours.Add(new Cell(State.Alive));

            cell.Tick(neighbours);

            Assert.That(cell.GetState(), Is.EqualTo(State.Dead));
        }

        [Test]
        public void LiveWhenItIsAliveAndHasTwoNeighbours()
        {
            var cell = new Cell(State.Alive);

            neighbours.Add(new Cell(State.Alive));
            neighbours.Add(new Cell(State.Alive));

            cell.Tick(neighbours);

            Assert.That(cell.GetState(), Is.EqualTo(State.Alive));
        }

        [Test]
        public void LiveWhenItIsAliveAndHasThreeNeighbours()
        {
            var cell = new Cell(State.Alive);

            neighbours.Add(new Cell(State.Alive));
            neighbours.Add(new Cell(State.Alive));
            neighbours.Add(new Cell(State.Alive));

            cell.Tick(neighbours);

            Assert.That(cell.GetState(), Is.EqualTo(State.Alive));
        }

        [Test]
        public void DieWhenItIsAliveAndHasMoreThanThreeNeighbours()
        {
            var cell = new Cell(State.Alive);

            neighbours.Add(new Cell(State.Alive));
            neighbours.Add(new Cell(State.Alive));
            neighbours.Add(new Cell(State.Alive));
            neighbours.Add(new Cell(State.Alive));

            cell.Tick(neighbours);

            Assert.That(cell.GetState(), Is.EqualTo(State.Dead));
        }

        [Test]
        public void BecomeAliveWhenItIsDeadAndHasThreeNeighbours()
        {
            var cell = new Cell(State.Dead);

            neighbours.Add(new Cell(State.Alive));
            neighbours.Add(new Cell(State.Alive));
            neighbours.Add(new Cell(State.Alive));

            cell.Tick(neighbours);

            Assert.That(cell.GetState(), Is.EqualTo(State.Alive));
        }
    }
}
