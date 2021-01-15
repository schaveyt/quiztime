using BlazorState;
using QuizTime.Shared.Data;

namespace QuizTime.Client.BlazorWasm.Features.Game
{
    public partial class GameState
    {
        public ThemeColor SystemDefaultThemeColor { get; private set; } = ThemeColor.Blue;
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
                    case ThemeColor.Purple:
                        return ThemeColor.Pink;
                    case ThemeColor.Yellow:
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
                    case ThemeColor.Purple:
                        return ThemeColor.Blue;
                    case ThemeColor.Yellow:
                        return ThemeColor.Blue;
                    default:
                        return ThemeColor.Undefined;
                }
            }
        }

        public string ThemeColorString => ThemeColor.ToString().ToLower();
        public string SecondaryColorString => SecondaryColor.ToString().ToLower();
        public string TrinaryColorString => TrinaryColor.ToString().ToLower();

    }
}
