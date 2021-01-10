

using BlazorState;

namespace QuizTime.Features.Settings
{
    public partial class SettingsState
    {
        public class UpdateThemeColorAction : IAction
        {
            public ThemeColor Value { get; set; }
        }
    }
}