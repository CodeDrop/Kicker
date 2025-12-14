using NUnit.Framework;
using POFF.Kicker.Infrastructure;
using POFF.Kicker.View.Model;

namespace POFF.Kicker.Tests.Infrastructure
{
    [TestFixture]
    class Load_Tournament_from_file
    {
        private Tournament _sut;

        [OneTimeSetUp]
        public void Setup()
        {
            var storage = new FileTournamentStorage(@"Infrastructure\TournamentFile.xml");
            _sut = storage.Load();
        }

        [Test]
        public void File_contains_teams()
        {
            Assert.That(_sut.Teams, Is.Not.Empty);
        }

        [Test]
        public void File_contains_matches()
        {
            Assert.That(_sut.MatchManager.GetMatches(), Is.Not.Empty);
            Assert.That(_sut.MatchManager.GetMatches(), Has.Length.EqualTo(3));
        }
    }
}
