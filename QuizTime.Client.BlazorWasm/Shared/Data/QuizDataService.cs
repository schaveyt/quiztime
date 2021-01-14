using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using QuizTime.Shared.Data;

namespace QuizTime.Client.BlazorWasm.Shared.Data
{
    public class QuizDataService
    {
        [Inject]
        public HttpClient Http { get; set; }

        private static readonly SortedList<string, Player> _testplayers = new SortedList<string, Player>
        {
            { "Mia", new Player (){ Name = "Alexander Hamilton", MinLevel = 0, MaxLevel = 2, Color = ThemeColor.Blue } },
            { "Izzy", new Player (){ Name = "Izzy", MinLevel = 0, MaxLevel = 2, Color = ThemeColor.Pink } },
            { "Jack", new Player (){ Name = "Jack", MinLevel = 5, MaxLevel = 8, Color = ThemeColor.Blue } },
            { "Mom", new Player (){ Name = "Mom", MinLevel = 11, MaxLevel = 16, Color = ThemeColor.Yellow } },
            { "Dad", new Player (){ Name = "Dad", MinLevel = 11, MaxLevel = 16, Color = ThemeColor.Purple } },
        };

        public async Task<IQuizItem> GetNextQuizItem(uint minSkillLevel, uint maxSkillLevel)
        {
            var item = await Http.GetFromJsonAsync<QuizItemDto>("api/random/0");

            if (item == null)
            {
                return new MultipleChoiceQuizItem("Error", new string[]{"error"}, 0);
            }
            
            if (item.QuestionType == QuestionTypeEnum.MultipleChoice)
            {
                return (MultipleChoiceQuizItem)item;
            }

            if (item.QuestionType == QuestionTypeEnum.Boolean)
            {
                return (BooleanQuizItem)item;
            }

            throw new Exception("Unsupported QuestionType encountered");
         }

        public IEnumerable<Player> GetPlayers()
        {
            return _testplayers.Values;
        }
    }
}

