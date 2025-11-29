using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using POFF.Kicker.Data;
using POFF.Kicker.View.Model;

namespace POFF.Kicker.Tests;


[TestClass()]
public class HtmlExportTests
{

    private static string Result;

    [ClassInitialize]
    public static void SetUp(TestContext testContext)
    {
        // Arrange
        var tournament = new Tournament();
        var team1 = new Team(1);
        var team2 = new Team(2);
        var team3 = new Team(3) { Withdrawn = true };
        tournament.AddTeam(team1);
        tournament.AddTeam(team2);
        tournament.AddTeam(team3);
        tournament.MatchManager.Generate(new[] { team1, team2, team3 });
        var matchResult = new Result();
        matchResult.AddSetResult(new SetResult() { Home = 5, Guest = 3 });
        tournament.MatchManager.SetStatus(2, matchResult);
        var testClass = new HtmlExport(tournament);

        // Act
        Result = testClass.ToString();
    }

    [TestMethod]
    public void HeaderTest()
    {
        StringAssert.StartsWith(Result, "<p>Stand ");
    }

    [TestMethod]
    public void SubtitleTest()
    {
        StringAssert.Contains(Result, " nach 1 von ");
    }

    [TestMethod]
    public void StandingTest()
    {
        StringAssert.Contains(Result, "<td>Team N°1</td>");
    }

    [TestMethod]
    public void GamesOfWithdrawnTeam()
    {
        var pattern = new Regex("<td>Team N°3</td>");
        StringAssert.DoesNotMatch(Result, pattern);
    }

    [TestMethod]
    public void FooterTest()
    {
        StringAssert.Contains(Result, "</table>");
    }

}