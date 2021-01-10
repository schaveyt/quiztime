using BlazorState;
using System.Collections.Generic;
using QuizTime.Shared.Data;
using System.Text;

namespace QuizTime.Features.Game
{
    public enum GameMode
    {
        Start,
        Play,
        NewGame,
        AddPlayers,
        SelectPlayers
    }

    public partial class GameState : State<GameState>
    {
        public readonly SortedList<string, Player> _players;
        public GameMode Mode { get; private set; }

        //public SortedList<string, Player> Players => _players;

        // public GameState()
        // {
        //     _players = new SortedList<string, Player>();
        // }

        public override void Initialize()
        {
            Mode = GameMode.Start;
            //Players.Add("Junk", new Player(){Name = "Junk"});
        }

        // public override string ToString()
        // {
        //     var s = new StringBuilder();
        //     s.AppendLine($"mode: {Mode.ToString().ToLower()}");
        //     s.AppendLine("players:");
        //     foreach (var p in Players.Keys)
        //     {
        //         s.AppendLine($"  {p}");
        //     }
        //     return s.ToString();
        // }
    }
}
