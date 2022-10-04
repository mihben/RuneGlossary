using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RuneGlossary.Client.WASM;
using RuneGlossary.Client.WASM.Repositories;
using STrain;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.UseLightinject();
builder.UseRequestRouter(request => "bff")
    .AddGenericHttpSender("bff", (options, _) =>
    {
        options.BaseAddress = new Uri("http://localhost:5100");
        options.Path = "api";
    });

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddTransient<ICharacterRepository, LocalStorageCharacterRepository>();

await builder.Build().RunAsync();
