using System;
using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using MediatR;

namespace QuizTime.Features.Game
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
                Console.WriteLine("AddPlayerHandler()...");
                //State._players.Add(aAction.Value.Name, aAction.Value);
                return Unit.Task;
            }
        }
    }
}