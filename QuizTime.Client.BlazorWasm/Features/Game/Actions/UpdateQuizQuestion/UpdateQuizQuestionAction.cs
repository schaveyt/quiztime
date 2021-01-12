
using BlazorState;
using QuizTime.Shared.Data;

namespace QuizTime.Features.Game
{
    public partial class GameState
    {
        public class UpdateQuizQuestionAction : IAction
        {
            public IQuizItem Value { get; set; }
        }
    }
}