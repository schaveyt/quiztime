
using System.Collections.Generic;
using BlazorState;
using QuizTime.Shared.Data;

namespace QuizTime.Client.BlazorWasm.Features.Game
{
    public partial class GameState
    {
        public class UpdateQuizQuestionSetAction : IAction
        {
            public List<int> Value { get; set; }
        }
    }
}