
using System;
using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using MediatR;

namespace QuizTime.Client.BlazorWasm.Features.Game
{
    public partial class GameState
    {
        public class UpdateSystemThemeColorHandler : ActionHandler<UpdateSystemThemeColorAction>
        {
            public UpdateSystemThemeColorHandler(IStore aStore): base(aStore)
            {

            }

            GameState State => Store.GetState<GameState>();

            public override Task<Unit> Handle(UpdateSystemThemeColorAction aAction, CancellationToken aCancellationToken)
            {
                State.SystemDefaultThemeColor = aAction.Value;
                State.ThemeColor = State.SystemDefaultThemeColor;
                return Unit.Task;
            }
        }
    }
}