using System.Text.RegularExpressions;
using NUnit.Framework;
using POFF.Kicker.Domain;
using POFF.Kicker.Infrastructure;
using POFF.Kicker.View.Model;

namespace POFF.Kicker.Tests;


[TestFixture]
class HtmlExportTests
{

    private static string Result;

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
        tournament.MatchManager.Generate([team1, team2, team3]);
        var matchResult = new Result();
        matchResult.AddSetResult(new SetResult() { Home = 5, Guest = 3 });
        tournament.MatchManager.SetStatus(2, matchResult);
        var testClass = new HtmlExport(tournament, ExportType.Games | ExportType.Standings);

        // Act
        Result = testClass.ToString();
    }

    [Test]
    public void StandingTest()
    {
        StringAssert.Contains("<td>Team N°1</td>", Result);
    }

    [Test]
    public void GamesOfWithdrawnTeam()
    {
        var pattern = new Regex("<td>Team N°3</td>");
        StringAssert.DoesNotMatch(pattern.ToString(), Result);
    }


}