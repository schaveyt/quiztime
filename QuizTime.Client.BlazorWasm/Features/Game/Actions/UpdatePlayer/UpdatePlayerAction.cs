using BlazorState;
using QuizTime.Shared.Data;

namespace QuizTime.Client.BlazorWasm.Features.Game
{
    public partial class GameState
    {
        public class UpdatePlayerAction : IAction
        {
            public Player Value { get; set; }
        }
    }
}