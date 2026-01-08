using System.Linq;
using NUnit.Framework;
using POFF.Meet.Domain.PlayModes;

namespace POFF.Meet.Tests;

[TestFixture]
public class MatchdaysPlayModeTests
{
    private MatchdaysPlayMode _sut;

    [OneTimeSetUp]
    public void SetUp()
    {
        _sut = new MatchdaysPlayMode();
    }

    [Test]
    [TestCase(0, 0)]
    [TestCase(1, 0)]
    [TestCase(2, 1)]
    [TestCase(3, 0)]
    [TestCase(4, 6)]
    [TestCase(5, 0)]
    [TestCase(6, 0)]
    [TestCase(8, 28)]
    [TestCase(10, 45)]
    [TestCase(12, 66)]
    [TestCase(14, 91)]
    [Timeout(250)]
    public void Generate_returns_expected_number_of_fixtures(int teamCount, int expectedFixtureCount)
    {
        var result = _sut.Generate(teamCount);
        Assert.That(result.Count(), Is.EqualTo(expectedFixtureCount));
    }
}