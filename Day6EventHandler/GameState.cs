namespace Day6EventHandler
{
    public class GameEventArgs : EventArgs
    {
        public Team Scorer { get; set; }
        public GameState State { get; set; }
    }

    public enum GameState
    {
        InProgress,
        GoalScored,
        FullTime
    }
}