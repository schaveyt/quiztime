
using BlazorState;
using QuizTime.Shared.Data;

namespace QuizTime.Client.BlazorWasm.Features.Game
{
    public partial class GameState
    {
        public class UpdateQuizQuestionAction : IAction
        {
            public QuizItem Value { get; set; }
        }
    }
}