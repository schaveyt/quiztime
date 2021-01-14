using BlazorState;
using QuizTime.Shared.Data;

namespace QuizTime.Client.BlazorWasm.Features.Game
{
    public partial class GameState
    {
        public class UpdateThemeColorAction : IAction
        {
            public ThemeColor Value { get; set; }
        }
    }
}