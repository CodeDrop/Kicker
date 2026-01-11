using POFF.Meet.Domain;
using POFF.Meet.Domain.PlayModes;
using POFF.Meet.View.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

namespace POFF.Meet.Infrastructure.Files;

public class FileTournamentStorage : ITournamentStorage
{
    private readonly string _filename;

    public FileTournamentStorage(string filename = "Tournament.xml")
    {
        _filename = filename;
    }

    public void Save(Tournament tournament)
    {
        var tournamentFile = new XmlMeetFile
        {
            Id = tournament.Id,
            Teams = [.. tournament.Teams],
            Matches = [.. tournament.Matches],
            PlayMode = tournament.PlayMode.GetType().Name,
        };
        var writer = new StreamWriter(_filename, false);
        var serializer = new XmlSerializer(typeof(XmlMeetFile));
        serializer.Serialize(writer, tournamentFile);
        writer.Close();
        tournament.Name = Path.GetFileNameWithoutExtension(_filename);
    }

    public Tournament Load()
    {
        if (File.Exists(_filename))
        {
            using var reader = new StreamReader(_filename);
            var serializer = new XmlSerializer(typeof(XmlMeetFile));
            var file = (XmlMeetFile)serializer.Deserialize(reader);
            reader.Close();

            var id = (file.Id != Guid.Empty) ? file.Id : Guid.NewGuid();
            var teams = file.Teams.ToList();
            var matches = file.Matches.ToList();
            PlayMode playMode = GetPlayMode(file.PlayMode);

            if (teams.Any(t => t.Number == 0))
            {
                FixTeamNumbers(teams, matches);
            }
            foreach (var match in matches)
            {
                match.Team1 = teams.Single(t => t.Number == match.Team1.Number);
                match.Team2 = teams.Single(t => t.Number == match.Team2.Number);
            }

            Tournament tournament = new(id, teams, matches, playMode) { Name = Path.GetFileNameWithoutExtension(_filename) };

            return tournament;
        }
        return Tournament.Empty;
    }

    private PlayMode GetPlayMode(string playModeTypeName)
    {
        var playModeType = Assembly.GetExecutingAssembly().GetTypes()
              .FirstOrDefault(t => t.Name == playModeTypeName
                  && typeof(PlayMode).IsAssignableFrom(t)
                  && !t.IsAbstract
                  && !t.IsInterface
                  && t.GetConstructor(Type.EmptyTypes) != null
              );
        
        if (playModeType == null) return PlayMode.Empty;

        return Activator.CreateInstance(playModeType) as PlayMode;
    }

    private void FixTeamNumbers(List<Team> teams, List<Match> matches)
    {
        for (int i = 0; i < teams.Count; i++)
        {
            teams[i].Number = i + 1;
        }
        foreach (var match in matches)
        {
            match.Team1 = teams.Single(t => t.Name == match.Team1.Name);
            match.Team2 = teams.Single(t => t.Name == match.Team2.Name);
        }
    }
}