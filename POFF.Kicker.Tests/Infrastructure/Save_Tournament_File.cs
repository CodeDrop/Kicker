using NUnit.Framework;
using POFF.Kicker.Domain;
using POFF.Kicker.Infrastructure;
using System.IO;
using System.Xml.Serialization;

namespace POFF.Kicker.Tests.Infrastructure
{
    [TestFixture]
    class Save_Tournament_File
    {
        private const string FILENAME = "unittest.xml";
        private TournamentFile _sut;

        [OneTimeSetUp]
        public void Setup()
        {
            Team[] teams =
                [
                    new Team { Name = "Team A" },
                    new Team { Name = "Team B" }
                ];

            _sut = new TournamentFile
            {
                Teams = teams,
                Matches = [new Match(1, teams[0], teams[1])]
            };

            var writer = new StreamWriter(FILENAME, false);

            var serializer = new XmlSerializer(typeof(TournamentFile));
            serializer.Serialize(writer, _sut);
            writer.Close();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            if (File.Exists(FILENAME))
            {
                File.Delete(FILENAME);
            }
        }

        [Test]
        public void Saved_file_exists()
        {
            Assert.That(FILENAME, Does.Exist);
        }
    }
}
