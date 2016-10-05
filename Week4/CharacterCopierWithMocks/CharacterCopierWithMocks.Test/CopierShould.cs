using Moq;
using NUnit.Framework;

namespace CharacterCopierWithMocks.Test
{
    [TestFixture]
    public class CopierShould
    {
        [Test]
        public void ReadCharacterFromSource()
        {
            var source = new Mock<ISource>();

            source.Setup(s => s.GetChar())
                .Returns('\n');

            var copier = new Copier(source.Object, new Mock<IDestination>().Object);

            copier.Copy();

            source.Verify(m => m.GetChar());
        }

        [Test]
        public void WriteCharacterToDestination()
        {
            var destination = new Mock<IDestination>();

            var source = new Mock<ISource>();

            source.SetupSequence(s => s.GetChar())
                .Returns('b')
                .Returns('\n');

            var copier = new Copier(source.Object, destination.Object);

            copier.Copy();

            destination.Verify(m => m.SetChar(It.IsAny<char>()));
        }

        [Test]
        public void CopyCharacterFromSourceToDestination()
        {
            var destination = new Mock<IDestination>();
            var source = new Mock<ISource>();

            source.SetupSequence(s => s.GetChar())
                .Returns('b')
                .Returns('\n');

            var copier = new Copier(source.Object, destination.Object);

            copier.Copy();

            destination.Verify(m => m.SetChar('b'));
        }

        [Test]
        public void CopyFromSourceUntilItReadsANewLine()
        {
            var destination = new Mock<IDestination>();
            var source = new Mock<ISource>();

            source.SetupSequence(s => s.GetChar())
                .Returns('b')
                .Returns('\n');

            var copier = new Copier(source.Object, destination.Object);

            copier.Copy();

            destination.Verify(m => m.SetChar('b'));
            destination.Verify(m => m.SetChar('\n'), Times.Never);
        }
    }

    public interface IDestination
    {
        void SetChar(char c);
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
            char character;

            while ((character = source.GetChar()) != '\n')
            {
                destination.SetChar(character);
            }
        }
    }

    public interface ISource
    {
        char GetChar();
    }
}
