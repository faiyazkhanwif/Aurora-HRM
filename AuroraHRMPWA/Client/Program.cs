global using AuroraHRMPWA.Client.Services.AuthService;
global using AuroraHRMPWA.Shared;
global using System.Net.Http.Json;
using AuroraHRMPWA.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IAuthServiceClient, AuthServiceClient>();

await builder.Build().RunAsync();
