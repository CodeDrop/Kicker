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
        content = Inject(content, "POFF\\.Meet#Ranking", ranking);

        var games = GetGamesHtml(tournament);
        content = Inject(content, "POFF\\.Meet#Games", games);

        File.WriteAllText(_targetFilename, content);
    }

    private static string Inject(string content, string tag, string value)
    {
        return Regex.Replace(content,
            // capture start tag, inner content (non-greedy, singleline), and end tag
            $"(<-- {tag}-Start -->)(.*?)(<-- {tag}-End -->)",
            m => m.Groups[1].Value + value + m.Groups[3].Value,
            RegexOptions.Singleline, Regex.InfiniteMatchTimeout);
    }

    private string GetGamesHtml(Tournament tournament)
    {
        var gamesBuilder = new StringBuilder();

        foreach (Domain.Match match in tournament.Matches)
        {
            // <tr><td>1</td><td>Spieler 1</td><td>Spieler 2</td><td>3:1</td></tr>
            gamesBuilder.Append("<tr>");
            gamesBuilder.Append($"<td>{match.Number}</td>");
            gamesBuilder.Append($"<td>{match.Team1.Name}</td>");
            gamesBuilder.Append($"<td>{match.Team2.Name}</td>");
            gamesBuilder.Append($"<td>{match.Result}</td>");
            gamesBuilder.Append("</tr>");
            gamesBuilder.Append(Environment.NewLine);
        }

       return gamesBuilder.ToString();
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
