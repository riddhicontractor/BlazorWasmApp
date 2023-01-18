using BlazorWasmApp;
using I18NPortable;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton((_) =>
        I18N.Current
    .AddLocaleReader(new I18NPortable.JsonReader.JsonKvpReader(), ".json") // ILocaleReader, file extension
    .Init(typeof(Program).Assembly));

builder.Services.AddSingleton(new Events());

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();