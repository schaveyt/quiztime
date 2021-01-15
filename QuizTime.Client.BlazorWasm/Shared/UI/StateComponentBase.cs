
using BlazorState;
using QuizTime.Client.BlazorWasm.Features.Game;

namespace QuizTime.Client.BlazorWasm.Shared.UI
{
    public class StateComponentBase : BlazorStateComponent
    {
        protected GameState State => GetState<GameState>();
    }

}