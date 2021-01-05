
using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using MediatR;

namespace QuizTime.Features.Settings
{
    public partial class SettingsState
    {
        public class UpdateThemeColorHandler : ActionHandler<UpdateThemColorAction>
        {
            public UpdateThemeColorHandler(IStore aStore): base(aStore)
            {

            }

            SettingsState State => Store.GetState<SettingsState>();

            public override Task<Unit> Handle(UpdateThemColorAction aAction, CancellationToken aCancellationToken)
            {
                State.ThemeColor = aAction.Value;
                return Unit.Task;
            }
        }
    }
}