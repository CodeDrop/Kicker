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
    public void Generate_returns_expected_number_of_fixtures(int teamCount, int expectedFixtureCount)
    {
        var result = _sut.Generate(teamCount);
        Assert.That(result.Count(), Is.EqualTo(expectedFixtureCount));
    }
}
