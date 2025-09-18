namespace Day6EventHandler
{
    public class Game
    {
        public Team Home { get; }
        public Team Away { get; }

        public int HomeScore { get; private set; }
        public int AwayScore { get; private set; }
        public GameState CurrentState { get; private set; }

        public event EventHandler<GameEventArgs>? GameStateHandler;

        public Game(Team home, Team away)
        {
            Home = home;
            Away = away;
        }

        public void ScoreGoal(Team scoringTeam)
        {
            if (scoringTeam == Home)
            {
                HomeScore++;
            }
            if (scoringTeam == Away)
            {
                AwayScore++;
            }

            OnStateGameChange(new GameEventArgs { Scorer = scoringTeam, State = GameState.GoalScored });
        }
        public void EndGame()
        {
            CurrentState = GameState.FullTime;
            // Raise the event
            OnStateGameChange(new GameEventArgs
            {
                State = GameState.FullTime,
            });
        }
        protected virtual void OnStateGameChange(GameEventArgs e)
        {
            GameStateHandler?.Invoke(this, e);
        }
    }
}