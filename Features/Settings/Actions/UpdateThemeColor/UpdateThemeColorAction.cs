

using BlazorState;

namespace QuizTime.Features.Settings
{
    public partial class SettingsState
    {
        public class UpdateThemColorAction : IAction
        {
            public ThemeColor Value { get; set; }
        }
    }
}