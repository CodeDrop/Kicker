using NUnit.Framework;
using POFF.Kicker.View;

namespace POFF.Kicker.Tests;

[TestFixture]
class AppWindowViewModelTests
{
    private AppWindowViewModel _sut;

    [OneTimeSetUp]
    public void SetUp()
    {
        _sut = AppWindowViewModel.Instance;
    }

    [Test]
    public void Teams_is_not_null()
    {
        Assert.That(_sut.Teams, Is.Not.Null);
    }

    [Test]
    public void Matches_is_not_null()
    {
        Assert.That(_sut.Teams, Is.Not.Null);
    }
}