using NUnit.Framework;
using POFF.Meet.Domain;
using POFF.Meet.Infrastructure;
using POFF.Meet.View.Model;
using System.IO;

namespace POFF.Meet.Tests.Infrastructure;

[TestFixture]
class Export_into_twig_file
{
    private Tournament _tournament;
    private TwigFileInjectionExporter _sut;
    private string _targetFile;
    private string _content;

    [OneTimeSetUp]
    public void SetUp()
    {
        _targetFile = Path.GetTempFileName();
        File.Copy(@"Infrastructure\TournamentPage.html.twig", _targetFile, overwrite: true);
        var storage = new FileTournamentStorage(@"Infrastructure\TournamentFile.xml");
        _tournament = storage.Load();
        _sut = new TwigFileInjectionExporter(_targetFile);
        _sut.Export(_tournament);
        _content = File.ReadAllText(_targetFile);
    }

    [OneTimeTearDown]
    public void TearDown()
    {
        if (File.Exists(_targetFile))
        {
            File.Delete(_targetFile);
        }
    }

    [Test]
    [TestCase("<-- POFF.Meet#Ranking-Start -->")]
    [TestCase("<-- POFF.Meet#Ranking-End -->")]
    public void File_contains_ranking_tag(string tag)
    {
        Assert.That(_content, Does.Contain(tag));
    }

    [Test]
    [TestCase("<tr><td>1</td><td>Team A</td><td>0</td><td class=\"font-weight-bold\">0</td>")]
    public void File_contains_ranking(string ranking)
    {
        Assert.That(_content, Does.Contain(ranking));
    }

    [Test]
    public void File_contains_all_team_names()
    {
        foreach (Team team in _tournament.Teams)
        {
            Assert.That(_content, Does.Contain(team.Name));
        }
    }
}
