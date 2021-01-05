using BlazorState;

namespace QuizTime.Features.Settings
{
    public enum ThemeColor
    {
        Green,
        Pink,
        Blue,
    }
    
    
    public partial class SettingsState : State<SettingsState>
    {
        public ThemeColor ThemeColor { get; private set; }

        public string ThemeColorString => ThemeColor.ToString().ToLower();

        public override void Initialize()
        {
            ThemeColor = ThemeColor.Blue;
        }
    }
}
