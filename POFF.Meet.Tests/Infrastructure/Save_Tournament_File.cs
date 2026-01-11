using NUnit.Framework;
using POFF.Meet.Domain;
using POFF.Meet.Domain.PlayModes;
using POFF.Meet.Infrastructure.Files;
using POFF.Meet.View.Model;
using System;
using System.IO;

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
                new Team { Name = "Team A" },
                new Team { Name = "Team B" }
            ];

        Match[] matches = [new Match(1, teams[0], teams[1])];

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
    public void Saved_file_contains_id()
    {
        var reloadedTournament = _sut.Load(); 
        Assert.That(reloadedTournament.Id, Is.EqualTo(_tournament.Id));
    }
}
