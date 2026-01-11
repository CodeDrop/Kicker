using POFF.Meet.View.Model;
using System;
using System.IO;
using System.Xml.Serialization;

namespace POFF.Meet.Infrastructure.Files;

public class FileTournamentStorage(in string filename) : ITournamentStorage
{
    private readonly string _filename = filename;

    public void Save(Tournament tournament)
    {
        var file = new MeetFile1
        {
            Id = tournament.Id,
            Teams = [.. tournament.Teams],
            Matches = [.. tournament.Matches],
            PlayMode = tournament.PlayMode.GetType().Name,
        };
        var writer = new StreamWriter(_filename, false);
        var serializer = new XmlSerializer(typeof(MeetFile1));
        serializer.Serialize(writer, file);
        writer.Close();
        tournament.Name = Path.GetFileNameWithoutExtension(_filename);
    }

    public Tournament Load()
    {
        if (!File.Exists(_filename)) return Tournament.Empty;

        Type type = typeof(MeetFile1);
        using var stream = File.OpenRead(_filename);
        var serializer = new XmlSerializer(type);
        var meetFile = (MeetFile1)serializer.Deserialize(stream);
        var tournament = meetFile.ToTournament();

        if (string.IsNullOrWhiteSpace(tournament.Name))
        {
            tournament.Name = Path.GetFileNameWithoutExtension(_filename);
        }

        return tournament;
    }
}