using System.Linq;
using NUnit.Framework;
using POFF.Meet.Domain.PlayModes;

namespace POFF.Meet.Tests;

[TestFixture]
public class RoundRobinPlayModeTests
{
    private RoundRobinPlayMode _sut;

    [OneTimeSetUp]
    public void SetUp()
    {
        _sut = new RoundRobinPlayMode();
    }

    [Test]
    [TestCase(2, 1)]
    [TestCase(3, 3)]
    [TestCase(5, 10)]
    public void Generate_returns_expected_number_of_fixtures(int teamCount, int expectedFixtureCount)
    {
        var result = _sut.Generate(teamCount);
        Assert.That(result.Count(), Is.EqualTo(expectedFixtureCount));
    }

    [Test]
    public void Name_is_not_empty()
    {
        Assert.That(_sut.Name, Is.Not.Empty);
    }
}