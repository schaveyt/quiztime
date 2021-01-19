using System;
using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using MediatR;

namespace QuizTime.Client.BlazorWasm.Features.Game
{
    public partial class GameState
    {
        public class UpdatePlayerHandler : ActionHandler<UpdatePlayerAction>
        {
            public UpdatePlayerHandler(IStore aStore): base(aStore)
            {

            }

            GameState State => Store.GetState<GameState>();

            public override Task<Unit> Handle(UpdatePlayerAction aAction, CancellationToken aCancellationToken)
            {
                State.PlayerUpdate(aAction.Value);
                return Unit.Task;
            }
        }
    }
}