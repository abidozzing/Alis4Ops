using Alis4Ops2024.Web;
using Alis4Ops2024.Web.Core;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<IQuestionGeneratorService, QuestionGeneratorService>();
builder.Services.AddSingleton<IAddQuestionGeneratorService, AddQuestionGeneratorService>();
builder.Services.AddSingleton<ISubtractQuestionGeneratorService, SubtractQuestionGeneratorService>();
builder.Services.AddSingleton<IMultiplyQuestionGeneratorService, MultiplyQuestionGeneratorService>();
builder.Services.AddSingleton<IDivideQuestionGeneratorService, DivideQuestionGeneratorService>();
await builder.Build().RunAsync();
