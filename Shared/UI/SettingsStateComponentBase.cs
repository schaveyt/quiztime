
using BlazorState;
using QuizTime.Features.Settings;

namespace QuizTime.Shared.UI
{
    public class SettingsStateComponentBase : BlazorStateComponent
    {

        protected SettingsState SettingsState => GetState<SettingsState>();
    }

}