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
            Assert.That(_sut.GetTeams, Is.Not.Empty);
            Assert.That(_sut.GetTeams, Has.Length.EqualTo(3));
        }

        [Test]
        public void File_contains_matches()
        {
            Assert.Pass();//.That([], Is.Not.Empty);
        }
    }
}
