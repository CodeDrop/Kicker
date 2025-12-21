using NUnit.Framework;
using POFF.Meet.View;
using System.IO;

namespace POFF.Meet.Tests;

[TestFixture]
class AppWindowViewModelTests
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
    public void New_Tournament_Creates_File()
    {
        // arrange
        _filename = Path.GetTempFileName();
        // act
        _sut.NewTournament(_filename);
        // assert
        Assert.That(_filename, Does.Exist);
        Assert.That(new FileInfo(_filename).Length, Is.GreaterThan(0));
        Assert.That(_sut.Title, Does.Contain(Path.GetFileNameWithoutExtension(_filename)));
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