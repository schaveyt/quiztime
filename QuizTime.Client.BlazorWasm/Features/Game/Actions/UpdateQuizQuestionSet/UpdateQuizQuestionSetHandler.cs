using System;
using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using MediatR;

namespace QuizTime.Client.BlazorWasm.Features.Game
{
    public partial class GameState
    {
        public class UpdateQuizQuestionSetHandler : ActionHandler<UpdateQuizQuestionSetAction>
        {
            public UpdateQuizQuestionSetHandler(IStore aStore): base(aStore)
            {

            }

            GameState State => Store.GetState<GameState>();

            public override Task<Unit> Handle(UpdateQuizQuestionSetAction aAction, CancellationToken aCancellationToken)
            {
                State.QuestionSetIds = aAction.Value;
                return Unit.Task;
            }
        }
    }
}