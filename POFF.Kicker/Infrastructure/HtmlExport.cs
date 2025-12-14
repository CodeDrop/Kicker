using POFF.Kicker.Domain;
using POFF.Kicker.Properties;
using POFF.Kicker.View.Model;
using System;
using System.Linq;
using System.Text;

namespace POFF.Kicker.Infrastructure;

public class HtmlExport(Tournament tournament, ExportType exportType)
{
    public override string ToString()
    {
        var builder = new StringBuilder(Resources.HtmlExportStandingOnlyTemplate);

        if ((exportType & ExportType.Games) == ExportType.Games)
            SetGames(builder);
        if ((exportType & ExportType.Standings) == ExportType.Standings)
            SetStandings(builder);

        return builder.ToString();
    }

    private void SetStandings(StringBuilder builder)
    {
        var standingsBuilder = new StringBuilder();

        foreach (Standing standing in tournament.GetStandings())
        {
            // <tr><td>1.</td><td>Spieler 1</td><td>3</td><td class="font-weight-bold">7</td></td><td>10:2</td></tr>
            standingsBuilder.Append("<tr>");
            standingsBuilder.Append($"<td>{standing.Place}</td>");
            standingsBuilder.Append($"<td>{standing.Team.Name}</td>");
            standingsBuilder.Append($"<td>{standing.MatchCount}</td>");
            standingsBuilder.Append($"<td class=\"font-weight-bold\">{standing.Points}</td>");
            standingsBuilder.Append($"<td>{standing.Goals}:{standing.GoalsAgainst}</td>");
            standingsBuilder.Append("</tr>");
            standingsBuilder.Append(Environment.NewLine);
        }

        builder.Replace("<!-- Tabelle -->", standingsBuilder.ToString());
    }

    private void SetGames(StringBuilder builder)
    {
        var gamesBuilder = new StringBuilder();

        foreach (Match match in tournament.MatchManager.GetMatches())
        {
            if (ContainsWithdrawnTeam(match))
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
        var team1 = tournament.Teams.Single(t => t.Equals(match.Team1));
        var team2 = tournament.Teams.Single(t => t.Equals(match.Team2));
        return team1.Withdrawn | team2.Withdrawn;
    }

}