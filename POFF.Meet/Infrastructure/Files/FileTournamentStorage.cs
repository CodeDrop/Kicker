using POFF.Meet.View.Model;
using System;
using System.Collections.Generic;
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

        var meetFile = Deserialize([typeof(MeetFile2), typeof(MeetFile1)]);
        var tournament = meetFile.ToTournament();

        if (string.IsNullOrWhiteSpace(tournament.Name))
        {
            tournament.Name = Path.GetFileNameWithoutExtension(_filename);
        }

        return tournament;
    }

    private MeetFileBase Deserialize(IEnumerable<Type> meetFileTypes)
    {
        using var stream = File.OpenRead(_filename);
        foreach (var type in meetFileTypes)
        {
            var serializer = new XmlSerializer(type);
            try
            {
                return (MeetFileBase)serializer.Deserialize(stream);
            }
            catch (InvalidOperationException)
            {
                // Ignore and try next type
            }
            finally
            {
                stream.Seek(0, SeekOrigin.Begin); // Reset stream position for next attempt
            }
        }
        return null;
    }
}