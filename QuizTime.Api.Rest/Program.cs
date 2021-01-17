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
                        builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .SetIsOriginAllowed(origin => true);
                    }
                )
            );

            builder.Services.AddSingleton<IApiDataService, ApiDataServiceFileStore>();
            builder.Services.AddControllers();

            var app = builder.Build();
            app.UseCors();
            app.MapControllers();
            app.Listen("http://0.0.0.0:3000");
            

            if (await app.Services.GetRequiredService<IApiDataService>().Load() != 0)
            {
                return;
            }

            await app.RunAsync();
        }

    }

}

