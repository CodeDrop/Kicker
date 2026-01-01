using POFF.Meet.View.Model;
using System;
using System.IO;
using System.Xml.Serialization;

namespace POFF.Meet.Infrastructure;

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

            if (file.Id == Guid.Empty) file.Id = Guid.NewGuid();
            Tournament tournament = new(file.Id, file.Teams, file.Matches) { Name = Path.GetFileNameWithoutExtension(_filename) };

            return tournament;
        }
        return new Tournament();
    }

    public void Save(Tournament tournament)
    {
        var tournamentFile = new TournamentFile
        {
            Id = tournament.Id,
            Teams = [.. tournament.Teams],
            Matches = [.. tournament.Matches]
        };
        var writer = new StreamWriter(_filename, false);
        var serializer = new XmlSerializer(typeof(TournamentFile));
        serializer.Serialize(writer, tournamentFile);
        writer.Close();
        tournament.Name = Path.GetFileNameWithoutExtension(_filename);
    }
}