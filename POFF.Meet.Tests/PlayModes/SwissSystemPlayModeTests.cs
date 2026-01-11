using NUnit.Framework;
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
    public void Generate_returns_expected_number_of_fixtures(int teamCount, int expectedFixtureCount)
    {
        var result = _sut.Generate(teamCount);
        Assert.That(result.Count(), Is.EqualTo(expectedFixtureCount));
    }

    [Test]
    public void Swiss_System_generates_round_1()
    {
        Assert.That(_sut.Generate(4).All(f => f.Section == 1), Is.True);
    }
}
