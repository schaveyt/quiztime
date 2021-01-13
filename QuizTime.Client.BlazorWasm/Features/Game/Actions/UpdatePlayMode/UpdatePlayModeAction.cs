
using BlazorState;

namespace QuizTime.Client.BlazorWasm.Features.Game
{
    public partial class GameState
    {
        public class UpdatePlayModeAction : IAction
        {
            public PlayMode Value { get; set; }
            public bool GotoNextPlayerDisabled {get; set;}
        }
    }
}