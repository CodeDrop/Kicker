using POFF.Meet.Domain.ScoreModes;
using POFF.Meet.View.Model;
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace POFF.Meet.Infrastructure;

public class TwigFileInjectionExporter
{
    private readonly string _targetFilename;

    public TwigFileInjectionExporter(string targetFilename)
    {
        _targetFilename = targetFilename;
    }

    public void Export(Tournament tournament)
    {
        var content = File.ReadAllText(_targetFilename);
        var ranking = GetRankingHtml(tournament);
        content = Regex.Replace(content,
            // capture start tag, inner content (non-greedy, singleline), and end tag
            "(<-- POFF\\.Meet#Ranking-Start -->)(.*?)(<-- POFF\\.Meet#Ranking-End -->)",
            m => m.Groups[1].Value + ranking + m.Groups[3].Value,
            RegexOptions.Singleline, Regex.InfiniteMatchTimeout);
        File.WriteAllText(_targetFilename, content);
    }

    private string GetRankingHtml(Tournament tournament)
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

        return standingsBuilder.ToString();
    }
}
