using POFF.Kicker.View.Model;
using System.IO;
using System.Xml.Serialization;

namespace POFF.Kicker.Infrastructure;

public class FileTournamentStorage : ITournamentStorage
{
    private readonly string _filename;

    public FileTournamentStorage(string filename = "Tournament.xml")
    {
        _filename = filename;
    }

    public Tournament Load()
    {
        if (File.Exists(_filename))
        {
            using var reader = new StreamReader(_filename);
            var serializer = new XmlSerializer(typeof(TournamentFile));
            var file = (TournamentFile)serializer.Deserialize(reader);
            reader.Close();
            return new Tournament(file.Teams, file.Matches);
        }
        return new Tournament();
    }

    public void Save(Tournament tournament)
    {
        var tournamentFile = new TournamentFile 
        { 
            Teams = tournament.GetTeams, 
            Matches = tournament.MatchManager.GetMatches()
        };
        var writer = new StreamWriter(_filename, false);
        var serializer = new XmlSerializer(typeof(TournamentFile));
        serializer.Serialize(writer, tournamentFile);
        writer.Close();
    }
}