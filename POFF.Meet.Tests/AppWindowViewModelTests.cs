using NUnit.Framework;
using POFF.Meet.Domain.PlayModes;
using POFF.Meet.View;
using System.Collections.Generic;

namespace POFF.Meet.Tests;

[TestFixture]
public class AppWindowViewModelTests
{
    private AppWindowViewModel _sut;

    [OneTimeSetUp]
    public void SetUp()
    {
        _sut = new AppWindowViewModel();
    }

    [Test]
    public void New_Tournament_Sets_IsNew()
    {
        _sut.NewTournament();
        Assert.That(_sut.IsNew, Is.True);
    }

    [Test]
    public void New_Tournament_Sets_Title()
    {
        _sut.NewTournament();
        Assert.That(_sut.Title, Does.Contain("New Tournament"));
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

    [Test]
    public void PlayModes_are_available()
    {
        IList<IPlayMode> playModes = _sut.PlayModes;
        Assert.That(playModes, Has.Count.EqualTo(2));
    }
}