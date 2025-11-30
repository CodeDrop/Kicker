using NUnit.Framework;
using POFF.Kicker.Domain;
using POFF.Kicker.Infrastructure;
using POFF.Kicker.View.Model;
using System.IO;

namespace POFF.Kicker.Tests.Infrastructure
{
    [TestFixture]
    class Save_Tournament_File
    {
        private const string FILENAME = "unittest.xml";
        private FileTournamentStorage _sut;

        [OneTimeSetUp]
        public void Setup()
        {
            Team[] teams =
                [
                    new Team { Name = "Team A" },
                    new Team { Name = "Team B" }
                ];

            Match[] matches = [new Match(1, teams[0], teams[1])];

            var tournament = new Tournament(teams, matches);

            _sut = new FileTournamentStorage(FILENAME);
            _sut.Save(tournament);
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
