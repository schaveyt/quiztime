
using BlazorState;
using QuizTime.Client.BlazorWasm.Features.Settings;

namespace QuizTime.Client.BlazorWasm.Shared.UI
{
    public class SettingsStateComponentBase : BlazorStateComponent
    {
        protected SettingsState SettingsState => GetState<SettingsState>();
    }

}