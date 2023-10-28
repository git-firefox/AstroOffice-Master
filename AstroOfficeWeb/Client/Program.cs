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

//if (builder.HostEnvironment.IsDevelopment())
//{
//    builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
//}
//else
//{
//    builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://3.110.160.108/") });
//}

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AuthenticationStateService>();
builder.Services.AddScoped<IAuthenticationStateService, AuthenticationStateService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<ISwaggerApiService, SwaggerApiService>();
builder.Services.AddScoped<KaranService>();
builder.Services.AddScoped<BestBLLService>();
builder.Services.AddScoped<KPBLLService>();
builder.Services.AddScoped<KPDAOService>();
builder.Services.AddScoped<KundliBLLService>();
builder.Services.AddScoped<PredictionBLLService>();
builder.Services.AddScoped<KundaliHistroyService>();

await builder.Build().RunAsync();
