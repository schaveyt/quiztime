using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BlazorState;
using Blazored.Modal;
using System.Reflection;
using QuizTime.Client.BlazorWasm.Shared.Data;

namespace QuizTime.Client.BlazorWasm
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            var apiUrl = builder.Configuration["ApiUrl"];
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiUrl) });
            builder.Services.AddSingleton<QuizDataService, QuizDataService>();

            ConfigureServices(builder.Services);
            
            await builder.Build().RunAsync();
        }

        public static void ConfigureServices(IServiceCollection aServiceCollection)
        {
            aServiceCollection.AddBlazorState((aOptions) =>
                aOptions.Assemblies =
                new Assembly[]
                {
                    typeof(Program).GetTypeInfo().Assembly,
                }
            );

            aServiceCollection.AddBlazoredModal();
        }
    }
}
