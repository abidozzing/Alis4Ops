using Alis4Ops2024.Web;
using Alis4Ops2024.Web.Core;
using Alis4Ops2024.Web.Pages;
using Blazor.Extensions.Storage;
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

// Program.cs
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSingleton<IQuestionGeneratorService, QuestionGeneratorService>();
builder.Services.AddSingleton<IAddQuestionGeneratorService, AddQuestionGeneratorService>();
builder.Services.AddSingleton<ISubtractQuestionGeneratorService, SubtractQuestionGeneratorService>();
builder.Services.AddSingleton<IMultiplyQuestionGeneratorService, MultiplyQuestionGeneratorService>();
builder.Services.AddSingleton<IDivideQuestionGeneratorService, DivideQuestionGeneratorService>();
builder.Services.AddSingleton<IArithmeticService, ArithmeticService>();
builder.Services.AddSingleton<RefreshService>();
// Register Blazor.Extensions.Storage
builder.Services.AddStorage();
builder.Services.AddBlazoredSessionStorageAsSingleton();
// Register services
builder.Services.AddSingleton<IScreenSizeService, ScreenSizeService>();
builder.Services.AddSingleton<DateTimeCounterStopWatch>();
await builder.Build().RunAsync();

