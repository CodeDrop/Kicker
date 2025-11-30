using NUnit.Framework;
using POFF.Kicker.Infrastructure;
using System.IO;
using System.Xml.Serialization;

namespace POFF.Kicker.Tests.Infrastructure
{
    [TestFixture]
    class Open_Tournament_File
    {
        private TournamentFile _sut;

        [OneTimeSetUp]
        public void Setup()
        {
            using var reader = new StreamReader(@"Infrastructure\TournamentFile.xml");
            var objectGenerator = new XmlSerializer(typeof(TournamentFile));
            _sut = (TournamentFile)objectGenerator.Deserialize(reader);
            reader.Close();
        }

        [Test]
        public void File_contains_teams()
        {
            Assert.That(_sut.Teams, Is.Not.Empty);
            Assert.That(_sut.Teams, Has.Length.EqualTo(3));
        }

        [Test]
        public void File_contains_matches()
        {
            Assert.That(_sut.Matches, Is.Not.Empty);
        }
    }
}
