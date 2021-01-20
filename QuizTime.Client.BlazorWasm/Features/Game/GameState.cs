using BlazorState;
using System.Collections.Generic;
using QuizTime.Shared.Data;
using System.Text;
using System;
using System.Linq;

namespace QuizTime.Client.BlazorWasm.Features.Game
{
    public enum GameMode
    {
        Start,
        Play,
        NewGame,
        AddPlayers,
        SelectPlayers
    }

    public enum PlayMode
    {
        None,
        OnDeck,
        Question,
        GameOver,
        Scoreboard
    }

    public partial class GameState : State<GameState>
    {
        private GameMode _gameMode;
        public PlayMode _playMode;
        private readonly List<Player> _players;
        private int _currentPlayerIndex;

        public GameState()
            : base ()
        {
            _currentPlayerIndex = 0;
            _players = new List<Player>();
        }

        public GameMode Mode 
        { 
            get
            {
                return _gameMode;
            } 
            private set
            {
                //Console.WriteLine($"GameState.Mode being set to {value}");
                switch(value)
                {
                    case GameMode.Start:
                    case GameMode.NewGame:
                        PlayMode = PlayMode.None;
                        ThemeColor = SystemDefaultThemeColor;
                        break;
                    
                    case GameMode.Play:
                        PlayMode = PlayMode.OnDeck;
                        break;
                }

                _gameMode = value;
            } 
        }

        public PlayMode PlayMode 
        { 
            get
            {
                return _playMode;
            } 
            private set
            {
                //Console.WriteLine($"GameState.PlayMode being set to {value}");
                switch(value)
                {
                    case PlayMode.OnDeck:
                        DetermineNextPlayer();
                        break;
                }

                _playMode = value;
            } 
        }

        public Player CurrentPlayer {get; private set;}

        protected bool GotoNextPlayerDisabled {get; set;}

        public List<Player> Players => _players;

        public List<int> QuestionSetIds {get; private set;}

        public IQuizItem CurrentQuizItem {get; private set;}

        public override void Initialize()
        {
            Mode = GameMode.Start;
            ThemeColor = SystemDefaultThemeColor;
        }

        public int PlayerIndex(Player p)
        {
            for (var i = 0; i < Players.Count; i++)
            {
                if (Players[i].Id == p.Id)
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

        public void PlayerUpdate (Player p)
        {
            var idx = PlayerIndex(p);
            if (idx == -1)
            {
                return;
            }

            var player = Players[idx];
            player.Name = p.Name;
            player.Color = p.Color;
            player.MinLevel = p.MinLevel;
            player.MaxLevel = p.MaxLevel;
        }

        private void DetermineNextPlayer()
        {
            if (GotoNextPlayerDisabled)
            {
                return;
            }

            if (Players == null || Players.Count == 0)
            {
                _currentPlayerIndex = 0;
                CurrentPlayer = null;
                return;
            }

            if (Players.Count == 1)
            {
                _currentPlayerIndex = 0;
            }
            else
            {
                _currentPlayerIndex++;
                if (_currentPlayerIndex >= Players.Count)
                {
                    _currentPlayerIndex = 0;
                }
            }

            CurrentPlayer = Players[_currentPlayerIndex];
            ThemeColor = CurrentPlayer.Color;
        }


        public override string ToString()
        {
            var s = new StringBuilder();
            s.AppendLine($"gm: {Mode.ToString().ToLower()}");
            s.AppendLine($"pm: {PlayMode.ToString().ToLower()}");
            s.AppendLine($"cpi: {_currentPlayerIndex}");
            s.AppendLine("players:");
            foreach (var p in Players)
            {
                s.AppendLine($"  {p.Name}");
            }
            return s.ToString();
        }
    }
}
