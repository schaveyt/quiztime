using BlazorState;

namespace QuizTime.Client.BlazorWasm.Features.Settings
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

        public ThemeColor TrinaryColor
        {
            get
            {               
                switch (this.ThemeColor)
                {
                    case ThemeColor.Green:
                        return ThemeColor.Pink;
                    case ThemeColor.Blue:
                        return ThemeColor.Green;
                    case ThemeColor.Pink:
                        return ThemeColor.Blue;
                    default:
                        return ThemeColor.Undefined;
                }
            }
        }

        public string ThemeColorString => ThemeColor.ToString().ToLower();
        public string SecondaryColorString => SecondaryColor.ToString().ToLower();
        public string TrinaryColorString => TrinaryColor.ToString().ToLower();

        public override void Initialize()
        {
            ThemeColor = ThemeColor.Blue;
        }
    }
}
