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
        private async Task<QuizItemDto> GetLocalRandomQuizItem()
        {
            var items = await GetQuizItemsLocal(0, 0);
            var randomId = new Random().Next(0, items.Count);
            await Task.Delay(3000); // simulate delay
            return items[randomId];
        }

        private async Task<List<QuizItemDto>> GetQuizItemsLocal(uint minSkillLevel, uint maxSkillLevel)
        {
            await Task.Delay(3000); // simulate delay

            var items = new List<QuizItemDto>()
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
                    answerIndex: 2,
                    id: 1
                ),

                new MultipleChoiceQuizItem
                (
                    question: "What is the captial of France?",
                    choices: new string[]
                    {
                        "Paris",
                        "Berlin"
                    },
                    answerIndex: 0,
                    id: 2
                ),

                new BooleanQuizItem
                (
                    question: "The largest U.S. state is Michigan.",
                    answer: false,
                    id: 3
                ),

                new BooleanQuizItem
                (
                    question: "The largest U.S. state is Alaska.",
                    answer: true,
                    id: 4
                ),

                new BooleanQuizItem
                (
                    question: "The Michigan state bird is the robin.",
                    answer: true,
                    id: 5
                ),

                new BooleanQuizItem
                (
                    question: "Florida is full of crazy people.",
                    answer: true,
                    id: 6
                ),
            };

            await Task.Delay(1); // simulate delay
            return items;
        }
    }

}

