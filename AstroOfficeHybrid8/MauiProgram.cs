//using AstroOfficeHybrid8.Client.Services;
using AstroOfficeHybrid8.Services;
using AstroOfficeHybrid8.Services.IServices;
using AstroOfficeWeb.Services;
using AstroOfficeWeb.Services.IServices;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using MudExtensions.Services;
namespace AstroOfficeHybrid8
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });
            builder.Services.AddMudServices();
            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddMudExtensions();
            builder.Services.AddAuthorizationCore();
            

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://ec2-15-207-51-190.ap-south-1.compute.amazonaws.com") });
#else
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://ec2-15-207-51-190.ap-south-1.compute.amazonaws.com") });
#endif

            builder.Services.AddScoped<AuthenticationStateProvider, AuthenticationStateService>();
            builder.Services.AddScoped<IAuthenticationStateService, AuthenticationStateService>();
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
            builder.Services.AddScoped<ISwaggerApiService, SwaggerApiService>();
            builder.Services.AddScoped<ISnackbarService,CustomSnackbar>();
            builder.Services.AddScoped<IPrintService,PrintService>();
            builder.Services.AddScoped<DocumentService>();
            builder.Services.AddScoped<ProductService>();
            builder.Services.AddScoped<KundaliHistroyService>();
            builder.Services.AddScoped<CountryService>();
            builder.Services.AddScoped<StripePayment>();
            builder.Services.AddScoped<StateContainerService>();
            builder.Services.AddScoped<TokenWalletService>();
            builder.Services.AddScoped<BestBLLService>();
            builder.Services.AddScoped<KPBLLService>();
            builder.Services.AddScoped<PredictionBLLService>();
            builder.Services.AddScoped<KundliBLLService>();
            builder.Services.AddScoped<KPDAOService>();
            builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
            return builder.Build();
        }
    }
}
