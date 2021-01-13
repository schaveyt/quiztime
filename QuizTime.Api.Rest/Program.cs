using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using QuizTime.Shared.Data;

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

            await app.RunAsync();
        }

        static async Task InitializeSeedData()
        {
            var db = new QuizTimeDbContext();

            await db.QuizItems.AddAsync(
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
                )
            );

            await db.QuizItems.AddAsync(
                new MultipleChoiceQuizItem
                (
                    question: "What is the captial of France?",
                    choices: new string[]
                    {
                        "Paris",
                        "Berlin"
                    },
                    answerIndex: 0
                )
            );

            await db.QuizItems.AddAsync(
                new BooleanQuizItem
                (
                    question: "The largest U.S. state is Michigan.",
                    answer: false
                )
            );

            await db.QuizItems.AddAsync(
                new BooleanQuizItem
                (
                    question: "The largest U.S. state is Alaska.",
                    answer: true
                )
            );

            await db.QuizItems.AddAsync(
                new BooleanQuizItem
                (
                    question: "The Michigan state bird is the robin.",
                    answer: true
                )
            );

            await db.QuizItems.AddAsync(
                new BooleanQuizItem
                (
                    question: "Florida is full of crazy people.",
                    answer: true
                )
            );

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

        
    }

}

