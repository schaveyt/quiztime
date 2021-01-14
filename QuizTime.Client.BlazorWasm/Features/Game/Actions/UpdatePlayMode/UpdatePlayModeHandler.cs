using System;
using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using MediatR;

namespace QuizTime.Client.BlazorWasm.Features.Game
{
    public partial class GameState
    {
        public class UpdatePlayModeHandler : ActionHandler<UpdatePlayModeAction>
        {
            public UpdatePlayModeHandler(IStore aStore): base(aStore)
            {
            }

            GameState State => Store.GetState<GameState>();

            public override Task<Unit> Handle(UpdatePlayModeAction aAction, CancellationToken aCancellationToken)
            {
                State.GotoNextPlayerDisabled = aAction.GotoNextPlayerDisabled;
                State.PlayMode = aAction.Value;
                return Unit.Task;
            }
        }
    }
}