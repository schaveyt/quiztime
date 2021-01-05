using BlazorState;

namespace QuizTime.Features.Game
{
    public enum GameMode
    {
        Start,
        Play
    }

    public partial class GameState : State<GameState>
    {
        public GameMode Mode { get; private set; }

        public override void Initialize()
        {
            Mode = GameMode.Start;
        }
    }
}
