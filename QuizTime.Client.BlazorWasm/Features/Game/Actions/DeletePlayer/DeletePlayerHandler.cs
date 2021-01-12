using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using MediatR;

namespace QuizTime.Features.Game
{
    public partial class GameState
    {
        public class DeletePlayerHandler : ActionHandler<DeletePlayerAction>
        {
            public DeletePlayerHandler(IStore aStore): base(aStore)
            {

            }

            GameState State => Store.GetState<GameState>();

            public override Task<Unit> Handle(DeletePlayerAction aAction, CancellationToken aCancellationToken)
            {
                State.PlayerRemove(aAction.Value);                
                return Unit.Task;
            }
        }
    }
}