using NUnit.Framework;
using POFF.Meet.View;

namespace POFF.Meet.Tests;

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