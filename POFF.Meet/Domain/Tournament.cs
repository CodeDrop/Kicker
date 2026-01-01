using POFF.Meet.Domain;
using POFF.Meet.Domain.PlayModes;
using POFF.Meet.Domain.ScoreModes;
using POFF.Meet.Infrastructure;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace POFF.Meet.View.Model;

public class Tournament
{
    private readonly List<Team> _teams = [];
    private readonly List<Match> _matches = [];
    private IPlayMode _playMode = new RoundRobinPlayMode();
    private IScoreMode _scoreMode = new Win3Equal1Loss0ScoreMode();

    public static readonly Tournament Empty = new(Guid.Empty, [], []);

    public Tournament() : this(Guid.NewGuid(), [], [])
    { }

    public Tournament(Guid id, IEnumerable<Team> teams, IEnumerable<Match> matches)
    {
        Id = id;
        _teams.AddRange(teams);
        _matches.AddRange(matches);
        _playMode = new RoundRobinPlayMode();
        _scoreMode = new Win3Equal1Loss0ScoreMode();
    }

    public Guid Id { get; }

    public IEnumerable<Team> Teams => _teams;

    public IEnumerable<Match> Matches => _matches;

    public IPlayMode PlayMode
    {
        set
        {
            _playMode = value ?? throw new ArgumentNullException(nameof(PlayMode));
            GenerateMatches();
        }
    }

    public IScoreMode ScoreMode
    {
        set { _scoreMode = value ?? throw new ArgumentNullException(nameof(ScoreMode)); }
    }

    public void AddTeam(Team team)
    {
        _teams.Add(team ?? throw new ArgumentNullException(nameof(team)));
        GenerateMatches();
    }

    public void RemoveTeam(Team team)
    {
        _teams.Remove(team ?? throw new ArgumentNullException(nameof(team)));
        GenerateMatches();
    }

    private void GenerateMatches()
    {
        _matches.Clear();

        foreach (var fixture in _playMode.Generate(_teams.Count))
        {
            _matches.Add(new Match(_matches.Count + 1, _teams[fixture.Item1], _teams[fixture.Item2]));
        }
    }

    public void SetResult(int matchNo, Result result)
    {
        if (matchNo < 1 | matchNo > _matches.Count)
            throw new IndexOutOfRangeException("matchNo may only have values between 1 and number of matches");

        _matches[matchNo - 1].Result = result;
        _matches[matchNo - 1].Status = MatchStatus.Finished;
    }

    public IEnumerable<Standing> GetStandings()
    {
        return _scoreMode.Evaluate([.. Matches]);
    }

    public void CopyToClipboard(ExportType exportType)
    {
        var export = new HtmlExport(this, exportType);
        Clipboard.SetText(export.ToString());
    }
}