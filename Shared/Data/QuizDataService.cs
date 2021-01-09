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
        };

        public IQuizItem GetNextQuizItem(int minSkillLevel, int maxSkillLevel)
        {
            var index = new Random().Next(0, _testdata.Count);
            return _testdata[index];
        }
    }
}

