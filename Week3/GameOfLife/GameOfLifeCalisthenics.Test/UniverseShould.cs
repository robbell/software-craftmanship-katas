using GameOfLifeCalisthenics.Src;
using NUnit.Framework;

namespace GameOfLifeCalisthenics.Test
{
    [TestFixture]
    public class UniverseShould
    {
        [Test]
        public void BeEqualToEmptyUniverseWhenEmpty()
        {
            var emptyUniverse = new Universe();
            var anotherEmptyUniverse = new Universe();

            Assert.That(anotherEmptyUniverse, Is.EqualTo(emptyUniverse));
        }

        [Test]
        public void NotBeEmptyAfterCellIsAdded()
        {
            var emptyUniverse = new Universe();
            var populatedUniverse = new Universe();

            populatedUniverse.Add(new Cell(State.Alive));

            Assert.That(populatedUniverse, Is.Not.EqualTo(emptyUniverse));
        }
    }
}