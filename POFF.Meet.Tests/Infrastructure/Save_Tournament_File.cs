using NUnit.Framework;
using POFF.Meet.Domain;
using POFF.Meet.Domain.PlayModes;
using POFF.Meet.Infrastructure.Files;
using POFF.Meet.View.Model;
using System;
using System.IO;
using System.Linq;

namespace POFF.Meet.Tests.Infrastructure;

[TestFixture]
public class Save_Tournament_File
{
    private FileTournamentStorage _sut;
    private Tournament _tournament;
    private const string FILENAME = "unittest.xml";

    [OneTimeSetUp]
    public void Setup()
    {
        Team[] teams =
            [
                new Team { Number = 1, Name = "Team A" },
                new Team { Number = 2, Name = "Team B" }
            ];

        Match[] matches = [new Match(1, teams[0], teams[1]) { Status = MatchStatus.Finished }];

        _tournament = new Tournament(Guid.NewGuid(), teams, matches, PlayMode.Empty);

        _sut = new FileTournamentStorage(FILENAME);
        _sut.Save(_tournament);
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

    [Test]
    public void Saved_file_can_be_reloaded()
    {
        var reloadedTournament = _sut.Load();
        Assert.That(reloadedTournament.Id, Is.EqualTo(_tournament.Id));
        Assert.That(reloadedTournament.PlayMode, Is.InstanceOf<PlayModeEmpty>());
        Assert.That(reloadedTournament.Name, Is.Not.Empty);
        Assert.That(reloadedTournament.Teams, Is.Not.Empty);
        Assert.That(reloadedTournament.Matches, Is.Not.Empty);
        Assert.That(reloadedTournament.Matches.ElementAt(0).Status, Is.EqualTo(MatchStatus.Finished));
    }
}
