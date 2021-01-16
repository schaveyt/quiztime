using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using QuizTime.Shared.Data;

namespace QuizTime.Client.BlazorWasm.Shared.Data
{
    public partial class QuizDataService
    {
        public List<QuizItemDto> QuizItemsLocal {get; private set;} = new List<QuizItemDto>()
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

        private QuizItemDto GetLocalRandomQuizItem()
        {
            var randomId = new Random().Next(0, QuizItemsLocal.Count);
            return QuizItemsLocal[randomId];
        }
    }

}

