using BlazorState;
using QuizTime.Shared.Data;

namespace QuizTime.Features.Game
{
    public partial class GameState
    {
        public class AddPlayerAction : IAction
        {
            public Player Value { get; set; }
        }
    }
}