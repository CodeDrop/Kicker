using NUnit.Framework;
using POFF.Meet.View;
using System.IO;

namespace POFF.Meet.Tests;

[TestFixture]
public class AppWindowViewModelTests
{
    private AppWindowViewModel _sut;
    private string _filename;

    [OneTimeSetUp]
    public void SetUp()
    {
        _sut = new AppWindowViewModel();
    }

    [TearDown]
    public void TearDown()
    {
        if (File.Exists(_filename))
        {
            File.Delete(_filename);
        }
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
}