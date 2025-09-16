namespace Day6EventHandler
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Starts of program");
            // 1. Setup
            var manCity = new Team { Name = "Man City" };
            var liverpool = new Team { Name = "Liverpool" };
            var chelsea = new Team { Name = "Chelsea" };

            var league = new LeagueTable();
            league.AddTeam(manCity);
            league.AddTeam(liverpool);
            league.AddTeam(chelsea);

            // 2. Create Games
            var game1 = new Game(manCity, liverpool);
            var game2 = new Game(chelsea, manCity);

            // 3. Subscribe the LeagueTable to the events
            game1.GameStateHandler += league.OnGameStateChange;
            game2.GameStateHandler += league.OnGameStateChange;

            // 4. Simulate a game (Publisher raises events)
            Console.WriteLine("--- Simulating Game 1: Man City vs Liverpool ---");
            game1.ScoreGoal(manCity); // Event raised -> league table updates goals
            game1.ScoreGoal(liverpool);
            game1.ScoreGoal(manCity);
            game1.EndGame();         // Event raised -> league table updates points, GD, etc.

            league.PrintStandings();

            // 5. Simulate another game
            Console.WriteLine("\n--- Simulating Game 2: Chelsea vs Man City ---");
            game2.ScoreGoal(chelsea);
            game2.ScoreGoal(manCity);
            game2.ScoreGoal(manCity);
            game2.EndGame();

            league.PrintStandings();
        }
    }
}