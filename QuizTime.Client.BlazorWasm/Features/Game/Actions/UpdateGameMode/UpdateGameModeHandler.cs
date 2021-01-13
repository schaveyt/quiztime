using System;
using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using MediatR;

namespace QuizTime.Client.BlazorWasm.Features.Game
{
    public partial class GameState
    {
        public class UpdateGameModeHandler : ActionHandler<UpdateGameModeAction>
        {
            public UpdateGameModeHandler(IStore aStore): base(aStore)
            {

            }

            GameState State => Store.GetState<GameState>();

            public override Task<Unit> Handle(UpdateGameModeAction aAction, CancellationToken aCancellationToken)
            {
                Console.WriteLine("UpdateGameModeHandler()...");
                State.Mode = aAction.Value;
                return Unit.Task;
            }
        }
    }
}