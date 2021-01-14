
using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using MediatR;

namespace QuizTime.Client.BlazorWasm.Features.Game
{
    public partial class GameState
    {
        public class UpdateThemeColorHandler : ActionHandler<UpdateThemeColorAction>
        {
            public UpdateThemeColorHandler(IStore aStore): base(aStore)
            {

            }

            GameState State => Store.GetState<GameState>();

            public override Task<Unit> Handle(UpdateThemeColorAction aAction, CancellationToken aCancellationToken)
            {
                State.ThemeColor = aAction.Value;
                return Unit.Task;
            }
        }
    }
}