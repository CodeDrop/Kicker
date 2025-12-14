using System.Text.RegularExpressions;
using NUnit.Framework;
using POFF.Kicker.Domain;
using POFF.Kicker.Infrastructure;
using POFF.Kicker.View.Model;

namespace POFF.Kicker.Tests;

[TestFixture]
class HtmlExportTests
{
    private static string _result;

    [OneTimeSetUp]
    public static void SetUp()
    {
        // Arrange
        var tournament = new Tournament();
        var team1 = new Team(1);
        var team2 = new Team(2);
        var team3 = new Team(3) { Withdrawn = true };
        tournament.AddTeam(team1);
        tournament.AddTeam(team2);
        tournament.AddTeam(team3);
        tournament.Start(TournamentType.Standard);
        var matchResult = new Result();
        matchResult.AddSetResult(new SetResult() { Home = 5, Guest = 3 });
        tournament.MatchManager.SetStatus(2, matchResult);
        var testClass = new HtmlExport(tournament, ExportType.Games | ExportType.Standings);

        // Act
        _result = testClass.ToString();
    }

    [Test]
    public void StandingTest()
    {
        Assert.That(_result, Does.Contain("<td>Team N°1</td>"));
    }

    [Test]
    public void GamesOfWithdrawnTeam()
    {
        var pattern = new Regex("<td>Team N°3</td>");
        Assert.That(_result, Does.Not.Match(pattern.ToString()));
    }
}