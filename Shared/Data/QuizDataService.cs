using System;
using System.Collections.Generic;

namespace QuizTime.Shared.Data
{
    public class QuizDataService
    {
        private static readonly List<IQuizItem> _testdata = new List<IQuizItem>
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
        };

        public IQuizItem GetNextQuizItem(int minSkillLevel, int maxSkillLevel)
        {
            var index = new Random().Next(0, _testdata.Count);
            return _testdata[index];
        }

        public IEnumerable<Player> GetPlayers()
        {
            return _testplayers.Values;
        }
    }
}

