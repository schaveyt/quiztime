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
        private readonly SortedList<string, Player> _players = new SortedList<string, Player>
        {
            { "Mia", new Player (){ Id = 1, Name = "Mia", MinLevel = 0, MaxLevel = 2, Color = ThemeColor.Blue } },
            { "Izzy", new Player (){ Id = 2, Name = "Izzy", MinLevel = 0, MaxLevel = 2, Color = ThemeColor.Pink } },
            { "Jack", new Player (){ Id = 3, Name = "Jack", MinLevel = 5, MaxLevel = 8, Color = ThemeColor.Blue } },
            { "Mom", new Player (){ Id = 4, Name = "Mom", MinLevel = 11, MaxLevel = 16, Color = ThemeColor.Yellow } },
            { "Dad", new Player (){ Id = 5, Name = "Dad", MinLevel = 11, MaxLevel = 16, Color = ThemeColor.Purple } },
        };

        public IEnumerable<Player> GetPlayers()
        {
            return _players.Values;
        }

        private readonly List<string> _successImages = new List<string>()
        {
            "https://media.giphy.com/media/BSx6mzbW1ew7K/giphy.gif", // nyan cat animated
            "https://media.giphy.com/media/mtaWx98w7mX7y/giphy.gif", // nyan cat pikachu
            "https://media.giphy.com/media/l41lZxzroU33typuU/giphy.gif", // full house you got it dude
            "https://media.giphy.com/media/bTzFnjHPuVvva/giphy.gif", // carlton
            "https://media.giphy.com/media/j3gsT2RsH9K0w/giphy.gif", // nepoleaon dynamite dance
            "https://media.giphy.com/media/SKGo6OYe24EBG/giphy.gif", // spongebob rainbow
            "https://media.giphy.com/media/o75ajIFH0QnQC3nCeD/giphy.gif", // the office fist pump
            "https://media.giphy.com/media/111ebonMs90YLu/giphy.gif", // kid thumbs up
            "https://media.giphy.com/media/Swx36wwSsU49HAnIhC/giphy.gif", // dumbledore applause
            "https://media.giphy.com/media/26gN16cJ6gy4LzZSw/giphy.gif", // harry potter applause
            "https://media.giphy.com/media/3otPoS81loriI9sO8o/giphy.gif", // elf you did it
            "https://media.giphy.com/media/3o7abKhOpu0NwenH3O/giphy.gif", // spungebob thumbs up
            "https://media.giphy.com/media/oobNzX5ICcRZC/giphy.gif", //minion thumbs up
            "https://media.giphy.com/media/1gqDQUaLe3mCc/giphy.gif", // awesome
            "https://media.giphy.com/media/3o7abGQa0aRJUurpII/giphy.gif", // spongebob many thumbup
            "https://media.giphy.com/media/5xtDarziy6FezwXWCbu/giphy.gif", // uncle grandpa pizza
            "https://media.giphy.com/media/kMxknXFU9P8d2/giphy.gif", // my little pony 
        };

        public List<string> SuccessImages => _successImages;

        private readonly List<string> _failImages = new List<string>()
        {
            "https://media.giphy.com/media/vPN3zK9dNL236/giphy.gif", // grumpy cat
            "https://media.giphy.com/media/gnE4FFhtFoLKM/giphy.gif", // minion - eh nope
            "https://media.giphy.com/media/d2ZcfODrNWlA5Gg0/giphy.gif", // scooby no
            "https://media.giphy.com/media/26tPbBRTZ8CQvyxeU/giphy.gif", // pichachu no
            "https://media.giphy.com/media/wofftnAdDtx4s/giphy.gif", // spongebob sand nope
            "https://media.giphy.com/media/ji6zzUZwNIuLS/giphy.gif", // little girl face
            "https://media.giphy.com/media/ToMjGpx9F5ktZw8qPUQ/giphy.gif", // office god no
            "https://media.giphy.com/media/26tPtM8Arb1nyc1i0/giphy.gif", // home alone
            "https://media.giphy.com/media/Sr9NHwRKlsD3unMK43/giphy.gif", // shrek donkey
            "https://media.giphy.com/media/9Vb9gWFgb9a4zUXDSW/giphy.gif", // how about no
            "https://media.giphy.com/media/15aGGXfSlat2dP6ohs/giphy.gif", // fish lips
            "https://media.giphy.com/media/3o7TKpjt7qIbmRp2XC/giphy.gif", // californians
            "https://media.giphy.com/media/OUwzqE4ZOk5Bm/giphy.gif", // hermonie
            "https://media.giphy.com/media/i8tL4unehxmvu/giphy.gif", // malfoy
            "https://media.giphy.com/media/l0HUeiukiyc3GOTuM/giphy.gif", //ginny
            "https://media.giphy.com/media/Uw5esGjfVEDpC/giphy.gif", //hermonie 2
            "https://media.giphy.com/media/12nfFCZA0vyrSw/giphy.gif", // ron

        };

        public List<string> FailImages => _failImages;

        public async Task<IQuizItem> GetQuizItemById(HttpClient httpClient, int itemId)
        {
            QuizItemDto item = null;

            try
            {
                item = await httpClient.GetFromJsonAsync<QuizItemDto>($"api/items/{itemId}");
            }
            catch(Exception e)
            {
                Console.WriteLine($"ERROR: 84340 - Exception when getting next quiz item.\nException Msg: {e.Message}");
            }

            if (item == null)
            {
                return new MultipleChoiceQuizItem("Error", new string[]{"error"}, 0, 0);
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

        public async Task<List<IQuizItem>> GetQuizItems(HttpClient httpClient, uint minSkillLevel,
            uint maxSkillLevel, bool local = false)
        {
            List<QuizItemDto> items = null;
            
            try
            {
                items = await httpClient.GetFromJsonAsync<List<QuizItemDto>>("api/items");
            }
            catch(Exception e)
            {
                Console.WriteLine($"ERROR: 84341 - Exception when getting next quiz item.\nException Msg: {e.Message}");
            }

            if (items == null)
            {
                return new List<IQuizItem>();
            }
            
            var results = new List<IQuizItem>();

            foreach (var item in items)
            {
                switch (item.QuestionType)
                {
                    case QuestionTypeEnum.MultipleChoice:
                        results.Add( (MultipleChoiceQuizItem)item );
                        break;

                    case QuestionTypeEnum.Boolean:
                        results.Add( (BooleanQuizItem)item );
                        break;
                    
                    default:
                        Console.WriteLine ($"warning: encountered unsupported QuestionType enum '{item.QuestionType}'");
                        break;
                }
            }

            return results;
            
         }

        public async Task<List<int>> GetQuizItemsIds(HttpClient httpClient, uint minSkillLevel,
            uint maxSkillLevel, bool local = false)
        {
            List<int> items = null;
            
            try
            {
                items = await httpClient.GetFromJsonAsync<List<int>>("api/itemids");
            }
            catch(Exception e)
            {
                Console.WriteLine($"ERROR: 84342 - Exception when getting next quiz item.\nException Msg: {e.Message}");
            }

            if (items == null)
            {
                return new List<int>();
            }
            
            return items;
         }
    }

}

