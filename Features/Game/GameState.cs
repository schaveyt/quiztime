using BlazorState;
using System.Collections.Generic;
using QuizTime.Shared.Data;
using System.Text;
using System;

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
        private readonly List<Player> _players;
        public GameMode Mode { get; private set; }

        public List<Player> Players => _players;

        public GameState()
            : base ()
        {
            _players = new List<Player>();
        }

        public override void Initialize()
        {
            Mode = GameMode.Start;
        }

        public int PlayerIndex(Player p)
        {
            for (var i = 0; i < Players.Count; i++)
            {
                if (Players[i].Name == p.Name)
                {
                    return i;
                }
            }
            return -1;
        }

        public bool PlayerExists(Player p)
        {
            return PlayerIndex(p) != -1;
        }

        public void PlayerRemove (Player p)
        {
            var i = PlayerIndex(p);
            if (i != -1)
            {
                Players.RemoveAt(i);
            }
        }

        public void PlayerAdd (Player p)
        {
            Players.Add(p);
        }

        public override string ToString()
        {
            var s = new StringBuilder();
            s.AppendLine($"mode: {Mode.ToString().ToLower()}");
            s.AppendLine("players:");
            foreach (var p in Players)
            {
                s.AppendLine($"  {p.Name}");
            }
            return s.ToString();
        }
    }
}
