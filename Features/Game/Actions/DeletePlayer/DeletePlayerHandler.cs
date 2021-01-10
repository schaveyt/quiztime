using System;
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
                Console.WriteLine("DeletePlayerHandler()...");
                //State.Players.Remove(aAction.Value.Name);
                return Unit.Task;
            }
        }
    }
}