
using BlazorState;
using QuizTime.Features.Settings;

namespace QuizTime.Shared
{
    public class SettingsStateComponentBase : BlazorStateComponent
    {

        protected SettingsState SettingsState => GetState<SettingsState>();
    }

}