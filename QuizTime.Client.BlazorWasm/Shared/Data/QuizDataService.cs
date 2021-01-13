using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QuizTime.Shared.Data;

namespace QuizTime.Client.BlazorWasm.Shared.Data
{
    public class QuizDataService
    {
        private static readonly List<QuizItem> _testdata = new List<QuizItem>
        {
            new MultipleChoiceQuizItem
            (
                question: "Which of these is not an ocean?",
                choices: new string[]
                {
                    "Pacific",
                    "Atlantic",
                    "Oceanitic",
                    "Indian"
                },
                answerIndex: 2
            ),
            new MultipleChoiceQuizItem
            (
                question: "What is the captial of France?",
                choices: new string[]
                {
                    "Paris", 
                    "Berlin"
                },
                answerIndex: 0
            ),
            new BooleanQuizItem
            (
                question: "The largest U.S. state is Michigan.",
                answer: false
            ),
            new BooleanQuizItem
            (
                question: "The largest U.S. state is Alaska.",
                answer: true
            ),
            new BooleanQuizItem
            (
                question: "The Michigan state bird is the robin.",
                answer: true
            ),
            new BooleanQuizItem
            (
                question: "Florida is full of crazy people.",
                answer: true
            ),
        };

        private static readonly SortedList<string, Player> _testplayers = new SortedList<string, Player>
        {
            { "Mia", new Player (){ Name = "Mia", MinLevel = 0, MaxLevel = 2 } },
            { "Izzy", new Player (){ Name = "Izzy", MinLevel = 0, MaxLevel = 2 } },
            { "Jack", new Player (){ Name = "Jack", MinLevel = 5, MaxLevel = 8 } },
            { "Mom", new Player (){ Name = "Mom", MinLevel = 11, MaxLevel = 16 } },
            { "Dad", new Player (){ Name = "Dad", MinLevel = 11, MaxLevel = 16 } },
        };

        public async Task<QuizItem> GetNextQuizItem(uint minSkillLevel, uint maxSkillLevel)
        {
            await Task.Delay(2000);
            var index = new Random().Next(0, _testdata.Count);
            return _testdata[index];
        }

        public IEnumerable<Player> GetPlayers()
        {
            return _testplayers.Values;
        }
    }
}

