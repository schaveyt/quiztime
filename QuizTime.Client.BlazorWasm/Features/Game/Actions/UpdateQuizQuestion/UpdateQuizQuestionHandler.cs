using System;
using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using MediatR;

namespace QuizTime.Client.BlazorWasm.Features.Game
{
    public partial class GameState
    {
        public class UpdateQuizQuestionHandler : ActionHandler<UpdateQuizQuestionAction>
        {
            public UpdateQuizQuestionHandler(IStore aStore): base(aStore)
            {

            }

            GameState State => Store.GetState<GameState>();

            public override Task<Unit> Handle(UpdateQuizQuestionAction aAction, CancellationToken aCancellationToken)
            {
                State.CurrentQuizItem = aAction.Value;
                return Unit.Task;
            }
        }
    }
}