
using BlazorState;

namespace QuizTime.Features.Game
{
    public partial class GameState
    {
        public class UpdateGameModeAction : IAction
        {
            public GameMode Value { get; set; }
        }
    }
}