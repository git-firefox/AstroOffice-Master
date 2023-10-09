using AstroOfficeWeb.Client;
using AstroOfficeWeb.Client.Services;
using AstroOfficeWeb.Client.Services.IService;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//other services
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AuthenticationStateService>();
builder.Services.AddScoped<IAuthenticationStateService, AuthenticationStateService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<ISwaggerApiService, SwaggerApiService>();
builder.Services.AddScoped<KaranService>();

await builder.Build().RunAsync();
