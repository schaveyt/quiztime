using BlazorState;

namespace QuizTime.Features.Settings
{
    public enum ThemeColor
    {
        Green,
        Pink,
        Blue,
        Undefined
    }
    
    
    public partial class SettingsState : State<SettingsState>
    {
        public ThemeColor ThemeColor { get; private set; }

        public ThemeColor SecondaryColor
        {
            get
            {               
                switch (this.ThemeColor)
                {
                    case ThemeColor.Green:
                        return ThemeColor.Blue;
                    case ThemeColor.Blue:
                        return ThemeColor.Pink;
                    case ThemeColor.Pink:
                        return ThemeColor.Green;
                    default:
                        return ThemeColor.Undefined;
                }
            }
        }

        public string ThemeColorString => ThemeColor.ToString().ToLower();
        public string SecondaryColorString => SecondaryColor.ToString().ToLower();

        public override void Initialize()
        {
            ThemeColor = ThemeColor.Blue;
        }
    }
}
