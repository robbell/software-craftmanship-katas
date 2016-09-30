using GameOfLifeCalisthenics.Src;
using NUnit.Framework;

namespace GameOfLifeCalisthenics.Test
{
    [TestFixture]
    public class NeighboursShould
    {
        private Neighbours neighbours;

        [SetUp]
        public void SetUp()
        {
            neighbours = new Neighbours();
        }

        [Test]
        public void DefinesOneNeighboursAsUnderpopulation()
        {
            neighbours.Add(new Cell(State.Alive));

            Assert.That(neighbours.GetPopulationStatus(), Is.EqualTo(PopulationStatus.Underpopulated));
        }

        [Test]
        public void DefinesTwoNeighboursAsHealthyPopulation()
        {
            neighbours.Add(new Cell(State.Alive));
            neighbours.Add(new Cell(State.Alive));

            Assert.That(neighbours.GetPopulationStatus(), Is.EqualTo(PopulationStatus.HealthyPopulation));
        }

        [Test]
        public void DefinesThreeNeighboursAsHealthyPopulation()
        {
            neighbours.Add(new Cell(State.Alive));
            neighbours.Add(new Cell(State.Alive));
            neighbours.Add(new Cell(State.Alive));

            Assert.That(neighbours.GetPopulationStatus(), Is.EqualTo(PopulationStatus.HealthyPopulation));
        }

        [Test]
        public void DefinesMoreThanFourNeighboursAsOverpopulation()
        {
            neighbours.Add(new Cell(State.Alive));
            neighbours.Add(new Cell(State.Alive));
            neighbours.Add(new Cell(State.Alive));
            neighbours.Add(new Cell(State.Alive));

            Assert.That(neighbours.GetPopulationStatus(), Is.EqualTo(PopulationStatus.Overpopulation));
        }
    }
}