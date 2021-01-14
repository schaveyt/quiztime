
using BlazorState;
using QuizTime.Client.BlazorWasm.Features.Game;

namespace QuizTime.Client.BlazorWasm.Shared.UI
{
    public class SettingsStateComponentBase : BlazorStateComponent
    {
        protected GameState SettingsState => GetState<GameState>();
    }

}