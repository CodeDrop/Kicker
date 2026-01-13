using NUnit.Framework;
using POFF.Meet.Domain;
using System.Linq;

namespace POFF.Meet.Tests.PlayModes;

[TestFixture]
public class SwissSystemPlayModeTests
{
    private SwissSystemPlayMode _sut;

    [SetUp]
    public void SetUp()
    {
        _sut = new SwissSystemPlayMode();
    }

    [Test]
    [TestCase(0, 0)]
    [TestCase(1, 0)]
    [TestCase(2, 1)]
    [TestCase(3, 0)]
    [TestCase(4, 2)]
    public void Round1_has_expected_number_of_fixtures(int teamCount, int expectedFixtureCount)
    {
        var result = _sut.Generate(teamCount);
        Assert.That(result.Count(), Is.EqualTo(expectedFixtureCount));
    }

    [Test]
    [TestCase(0)]
    [TestCase(2)]
    [TestCase(4)]
    public void Round2_has_zero_fixtures_when_no_games_played(int teamCount)
    {
        var round1 = _sut.Generate(teamCount);
        Match[] matches = [];
        var round2 = _sut.Generate(teamCount, matches);
        Assert.That(round2.Count(), Is.Zero);
    }

    [Test]
    public void Swiss_System_generates_round_1()
    {
        Assert.That(_sut.Generate(4).All(f => f.Round == 1), Is.True);
    }
}
