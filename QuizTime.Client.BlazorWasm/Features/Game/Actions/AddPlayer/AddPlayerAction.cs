using BlazorState;
using QuizTime.Shared.Data;

namespace QuizTime.Client.BlazorWasm.Features.Game
{
    public partial class GameState
    {
        public class AddPlayerAction : IAction
        {
            public Player Value { get; set; }
        }
    }
}