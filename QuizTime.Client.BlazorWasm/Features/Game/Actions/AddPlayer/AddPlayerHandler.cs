using System;
using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using MediatR;

namespace QuizTime.Client.BlazorWasm.Features.Game
{
    public partial class GameState
    {
        public class AddPlayerHandler : ActionHandler<AddPlayerAction>
        {
            public AddPlayerHandler(IStore aStore): base(aStore)
            {

            }

            GameState State => Store.GetState<GameState>();

            public override Task<Unit> Handle(AddPlayerAction aAction, CancellationToken aCancellationToken)
            {
                State.PlayerAdd(aAction.Value);
                return Unit.Task;
            }
        }
    }
}