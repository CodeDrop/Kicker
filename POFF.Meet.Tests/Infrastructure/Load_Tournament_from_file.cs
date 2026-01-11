using NUnit.Framework;
using POFF.Meet.Infrastructure.Files;
using POFF.Meet.View.Model;
using System;

namespace POFF.Meet.Tests.Infrastructure;

[TestFixture]
public class Load_Tournament_from_file
{
    private Tournament _sut;

    [OneTimeSetUp]
    public void Setup()
    {
        var storage = new FileTournamentStorage(@"Infrastructure\MeetFileV1.xml");
        _sut = storage.Load();
    }

    [Test]
    public void File_contains_id()
    {
        Assert.That(_sut.Id, Is.Not.EqualTo(Guid.Empty));
    }

    [Test]
    public void File_contains_teams()
    {
        Assert.That(_sut.Teams, Is.Not.Empty);
    }

    [Test]
    public void File_contains_matches()
    {
        Assert.That(_sut.Matches, Is.Not.Empty);
    }

    [Test]
    [TestCase(@"Infrastructure\MeetFileV1.xml")]
    public void File_from_older_version_can_be_loaded(string filename)
    {
        // arrange
        var storage = new FileTournamentStorage(filename);
        // act
        var tournament = storage.Load();
        // assert
        Assert.That(tournament.Id, Is.Not.EqualTo(Guid.Empty));
        Assert.That(tournament.Name, Is.Not.Empty);
        Assert.That(tournament.Teams, Is.Not.Empty);
        Assert.That(tournament.Matches, Is.Not.Empty);
    }
}
