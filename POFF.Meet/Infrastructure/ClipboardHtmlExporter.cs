using POFF.Meet.Domain;
using POFF.Meet.Domain.ScoreModes;
using POFF.Meet.Properties;
using POFF.Meet.View.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POFF.Meet.Infrastructure;

public class ClipboardHtmlExporter(ExportType exportType) : IExporter
{
    private Tournament _tournament;

    public void Export(Tournament tournament)
    {
        Export(tournament, tournament.Matches.Select(m => m.Number));
    }

    public void Export(Tournament tournament, IEnumerable<int> matchNumbers)
    {
        _tournament = tournament;
        var builder = new StringBuilder(Resources.HtmlExportStandingOnlyTemplate);

        if ((exportType & ExportType.Games) == ExportType.Games)
            SetGames(builder, matchNumbers);
        if ((exportType & ExportType.Standings) == ExportType.Standings)
            SetStandings(builder);

        Clipboard.SetText(builder.ToString());
    }

    public override string ToString()
    {
        return Clipboard.GetText(TextDataFormat.Text);
    }

    private void SetStandings(StringBuilder builder)
    {
        var standingsBuilder = new StringBuilder();

        foreach (Standing standing in _tournament.GetStandings())
        {
            // <tr><td>1.</td><td>Spieler 1</td><td>3</td><td class="font-weight-bold">7</td></td><td>10:2</td></tr>
            standingsBuilder.Append("<tr>");
            standingsBuilder.Append($"<td>{standing.Place}</td>");
            standingsBuilder.Append($"<td>{standing.Team.Name}</td>");
            standingsBuilder.Append($"<td>{standing.MatchCount}</td>");
            standingsBuilder.Append($"<td class=\"font-weight-bold\">{standing.Points}</td>");
            standingsBuilder.Append($"<td>{standing.Goals.Scored}:{standing.Goals.Conceded}</td>");
            standingsBuilder.Append("</tr>");
            standingsBuilder.Append(Environment.NewLine);
        }

        builder.Replace("<!-- Tabelle -->", standingsBuilder.ToString());
    }

    private void SetGames(StringBuilder builder, IEnumerable<int> matchNumbers)
    {
        var gamesBuilder = new StringBuilder();

        foreach (Match match in _tournament.Matches)
        {
            if (ContainsWithdrawnTeam(match) || !matchNumbers.Contains(match.Number))
                continue;
            // <tr><td>1</td><td>Spieler 1</td><td>Spieler 2</td><td>3:1</td></tr>
            gamesBuilder.Append("<tr>");
            gamesBuilder.Append($"<td>{match.Number}</td>");
            gamesBuilder.Append($"<td>{match.Team1.Name}</td>");
            gamesBuilder.Append($"<td>{match.Team2.Name}</td>");
            gamesBuilder.Append($"<td>{match.Result}</td>");
            gamesBuilder.Append("</tr>");
            gamesBuilder.Append(Environment.NewLine);
        }

        builder.Replace("<!-- Spiele -->", gamesBuilder.ToString());
    }

    private bool ContainsWithdrawnTeam(Match match)
    {
        var team1 = _tournament.Teams.Single(t => t.Equals(match.Team1));
        var team2 = _tournament.Teams.Single(t => t.Equals(match.Team2));
        return team1.Withdrawn | team2.Withdrawn;
    }
}