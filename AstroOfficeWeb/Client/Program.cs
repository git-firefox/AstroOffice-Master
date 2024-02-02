using AstroOfficeWeb.Client;
using AstroOfficeWeb.Client.Services;
using AstroOfficeWeb.Client.Services.IService;
using AstroOfficeWeb.Components.HomeComponents;
using AstroOfficeWeb.Components.MyComponents;
using AstroOfficeWeb.Services;
using AstroOfficeWeb.Services.IServices;

using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
//builder.RootComponents.Add<NavMenu>("#header-container");
//builder.RootComponents.Add<NavMenuMobile>("#footer-container");
builder.Services.AddMudServices();
builder.Services.AddMudBlazorDialog();
builder.Services.AddScoped<ISnackbarService, CustomSnackbar>();
builder.Services.AddScoped(sp => new HttpClient { 
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
    Timeout = TimeSpan.FromMinutes(10)
});
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://ec2-15-207-51-190.ap-south-1.compute.amazonaws.com") });
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, AuthenticationStateService>();
builder.Services.AddScoped<IAuthenticationStateService, AuthenticationStateService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<ISwaggerApiService, SwaggerApiService>();
builder.Services.AddScoped<IPrintService, PrintService>();
builder.Services.AddScoped<DocumentService>();
builder.Services.AddScoped<AccountService>();
builder.Services.AddScoped<BestBLLService>();
builder.Services.AddScoped<KPBLLService>();
builder.Services.AddScoped<KPDAOService>();
builder.Services.AddScoped<KundliBLLService>();
builder.Services.AddScoped<PredictionBLLService>();
builder.Services.AddScoped<KundaliHistroyService>();
builder.Services.AddScoped<TokenWalletService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<StateContainerService>();
builder.Services.AddScoped<StripePayment>();
builder.Services.AddScoped<LookupService>();

await builder.Build().RunAsync();
