using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using QuizTime.Shared.Data;
using System.IO;

namespace QuizTime.Api.Rest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // handle cors
            //
            builder.Services.AddCors(options => 
                options.AddDefaultPolicy(
                builder =>
                {
                    builder.WithOrigins(
                        "https://0.0.0.0:5001", 
                        "https://0.0.0.0:3000");
                })
            );

            var app = builder.Build();
            app.UseCors();
            app.Listen("https://0.0.0.0:3000");
            app.MapGet("/api/items", GetQuizItems);
            app.MapGet("/api/random/{id}", GetRandomQuizItem);
            
            await InitializeSeedData();

            //await StoreQuizItems(null);           

            await app.RunAsync();
        }

        static async Task InitializeSeedData()
        {
            var db = new QuizTimeDbContext();
            using (FileStream fs = new FileStream("data-import.csv", FileMode.Open, FileAccess.Read))
            {
                using (var reader = new StreamReader(fs))
                {
                    string line;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        var cols = line.Split(',');
                        var answerIndex = 0;
                        Int32.TryParse(cols[3], out answerIndex);

                        await db.QuizItems.AddAsync(
                            new QuizItemDto()
                            {
                                Question = cols[2],
                                QuestionType =  cols[0][0] == 'M' ? QuestionTypeEnum.MultipleChoice : QuestionTypeEnum.Boolean,
                                AnswerIndex = answerIndex
                            }
                        );
                    }
                }
            }

            await db.SaveChangesAsync();
        }


        static async Task GetQuizItems(HttpContext http)
        {
            using var db = new QuizTimeDbContext();
            var results = await db.QuizItems.ToListAsync();
            await http.Response.WriteJsonAsync(results);
        }

        // "/random/{id}
        static async Task GetRandomQuizItem(HttpContext http)
        {
            if (!http.Request.RouteValues.TryGet("id", out int id))
            {
                http.Response.StatusCode = 400;
                return;
            }

            using var db = new QuizTimeDbContext();
            var itemCount = await db.QuizItems.CountAsync();
            var randomId = new Random().Next(0, itemCount);

            var quizItem = db.QuizItems.FindAsync(randomId);
            await http.Response.WriteJsonAsync(quizItem.Result);
        }

        static async Task StoreQuizItems(HttpContext http)
        {
            using var db = new QuizTimeDbContext();
            var results = await db.QuizItems.ToListAsync();

            // Write the specified text asynchronously to a new file named "WriteTextAsync.txt".
            using (StreamWriter outputFile = new StreamWriter("data-export.csv"))
            {
                foreach (var item in results)
                {
                    await outputFile.WriteLineAsync($"{item.QuestionType},{0},{item.Question},{item.AnswerIndex}");
                }
            }
            
        }

        
    }

}

