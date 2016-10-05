using NUnit.Framework;

namespace CharacterCopierWithSpies.Test
{
    [TestFixture]
    public class CopierShould
    {
        [Test]
        public void ReadFromSource()
        {
            var source = new Source();

            var copier = new Copier(source, new Destination());

            copier.Copy();

            Assert.That(source.GetCharWasCalled(), Is.True);
        }

        [Test]
        public void WriteCharacterToDestination()
        {
            var destination = new Destination();

            var copier = new Copier(new Source(), destination);

            copier.Copy();

            Assert.That(destination.SetCharWasCalled(), Is.True);
        }
    }

    public interface IDestination
    {
        void SetChar();
    }

    public class Destination : IDestination
    {
        private bool setCharWasCalled;

        public bool SetCharWasCalled()
        {
            return setCharWasCalled;
        }

        public void SetChar()
        {
            setCharWasCalled = true;
        }
    }

    public class Copier
    {
        private readonly ISource source;
        private readonly IDestination destination;

        public Copier(ISource source, IDestination destination)
        {
            this.source = source;
            this.destination = destination;
        }

        public void Copy()
        {
            source.GetChar();
            destination.SetChar();
        }
    }

    public interface ISource
    {
        void GetChar();
    }

    public class Source : ISource
    {
        private bool getCharWasCalled;

        public bool GetCharWasCalled()
        {
            return getCharWasCalled;
        }

        public void GetChar()
        {
            getCharWasCalled = true;
        }
    }
}
