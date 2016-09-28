using System.Runtime.InteropServices;
using NUnit.Framework;
namespace GameOfLife.Test
{
    [TestFixture]
    public class CellShould
    {
        [Test]
        public void DieIfItHasLessThanTwoNeighbours()
        {
            var cell = new Cell(State.Alive);

            cell.Tick(1);

            Assert.That(cell.GetState(), Is.EqualTo(State.Dead));
        }

        [Test]
        public void LiveIfItHasTwoOrMoreNeighbours()
        {
            var cell = new Cell(State.Dead);

            cell.Tick(2);

            Assert.That(cell.GetState(), Is.EqualTo(State.Alive));
        }

        [Test]
        public void DieIfItHasMoreThanThreeNeighbours()
        {
            var cell = new Cell(State.Alive);

            cell.Tick(4);

            Assert.That(cell.GetState(), Is.EqualTo(State.Dead));   
        }

        [Test]
        public void BecomeLiveWhenItIsDeadAndHasThreeNeighbours()
        {
            var cell = new Cell(State.Dead);

            cell.Tick(3);

            Assert.That(cell.GetState(), Is.EqualTo(State.Alive));
        }

        [Test]
        public void AllowStateToBeSetOnCreation()
        {
            var cell = new Cell(State.Alive);

            Assert.That(cell.GetState(), Is.EqualTo(State.Alive));
        }
    }

    public enum State   
    {
        Dead,
        Alive
    }

    public class Cell
    {
        private State currentState;

        public Cell(State initialState)
        {
            currentState = initialState;
        }

        public State GetState()
        {
            return currentState;
        }

        public void Tick(int numberOfNeighbours)
        {
            if(numberOfNeighbours < 2) currentState = State.Dead;

            if(numberOfNeighbours >= 2) currentState = State.Alive;

            if(numberOfNeighbours >= 4) currentState = State.Dead;
        }
    }
}
