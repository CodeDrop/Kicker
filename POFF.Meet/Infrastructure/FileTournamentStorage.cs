using POFF.Meet.Domain;
using POFF.Meet.View.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace POFF.Meet.Infrastructure;

public class FileTournamentStorage : ITournamentStorage
{
    private readonly string _filename;

    public FileTournamentStorage(string filename = "Tournament.xml")
    {
        _filename = filename;
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

    public Tournament Load()
    {
        if (File.Exists(_filename))
        {
            using var reader = new StreamReader(_filename);
            var serializer = new XmlSerializer(typeof(TournamentFile));
            var file = (TournamentFile)serializer.Deserialize(reader);
            reader.Close();

            var id = (file.Id != Guid.Empty) ? file.Id : Guid.NewGuid();
            var teams = file.Teams.ToList();
            var matches = file.Matches.ToList();
            if (teams.Any(t => t.Number == 0))
            {
                FixTeamNumbers(teams, matches);
            }
            foreach (var match in matches)
            {
                match.Team1 = teams.Single(t => t.Number == match.Team1.Number);
                match.Team2 = teams.Single(t => t.Number == match.Team2.Number);
            }

            Tournament tournament = new(id, teams, matches) { Name = Path.GetFileNameWithoutExtension(_filename) };

            return tournament;
        }
        return Tournament.Empty;
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