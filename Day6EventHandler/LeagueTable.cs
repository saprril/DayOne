namespace Day6EventHandler
{
    using System.Collections.Generic;

public class LeagueTable
{
    private readonly Dictionary<string, TeamStats> _teamStats = new Dictionary<string, TeamStats>();

    public void AddTeam(Team team)
    {
        if (!_teamStats.ContainsKey(team.Name))
        {
            _teamStats.Add(team.Name, new TeamStats { Team = team });
        }
    }

    // Event handler method to be called when a game state changes
    public void OnGameStateChange(object sender, GameEventArgs e)
    {
        if (e.State == GameState.FullTime)
        {
            // Update points and goal difference based on final scores
            var game = sender as Game;
            if (game == null) return;

            var homeStats = _teamStats[game.Home.Name];
            var awayStats = _teamStats[game.Away.Name];

            homeStats.GamesPlayed++;
            awayStats.GamesPlayed++;
            homeStats.GoalsFor += game.HomeScore;
            awayStats.GoalsFor += game.AwayScore;
            homeStats.GoalsAgainst += game.AwayScore;
            awayStats.GoalsAgainst += game.HomeScore;
            homeStats.GoalDifference = homeStats.GoalsFor - homeStats.GoalsAgainst;
            awayStats.GoalDifference = awayStats.GoalsFor - awayStats.GoalsAgainst;

            if (game.HomeScore > game.AwayScore)
            {
                homeStats.Points += 3; // Win
                homeStats.Wins++;
                awayStats.Losses++;
            }
            else if (game.AwayScore > game.HomeScore)
            {
                awayStats.Points += 3; // Win
                awayStats.Wins++;
                homeStats.Losses++;
            }
            else
            {
                homeStats.Points += 1; // Draw
                awayStats.Points += 1; // Draw
                homeStats.Draws++;
                awayStats.Draws++;
            }
        }
        // You can add more logic here for other states
    }

    public void PrintStandings()
    {
        Console.WriteLine("\n--- League Standings ---");
        Console.WriteLine("{0,-15} {1,-5} {2,-5} {3,-5} {4,-5} {5,-5} {6,-5}", "Team", "GP", "W", "D", "L", "GD", "Pts");
        foreach (var stats in _teamStats.Values)
        {
            Console.WriteLine("{0,-15} {1,-5} {2,-5} {3,-5} {4,-5} {5,-5} {6,-5}",
                stats.Team.Name, stats.GamesPlayed, stats.Wins, stats.Draws, stats.Losses, stats.GoalDifference, stats.Points);
        }
    }
}

public class TeamStats
{
    public Team Team { get; set; }
    public int GamesPlayed { get; set; }
    public int Wins { get; set; }
    public int Draws { get; set; }
    public int Losses { get; set; }
    public int GoalsFor { get; set; }
    public int GoalsAgainst { get; set; }
    public int GoalDifference { get; set; }
    public int Points { get; set; }
}
}