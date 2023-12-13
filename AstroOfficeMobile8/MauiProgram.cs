using AstroOfficeMobile8.Services.IServices;
using AstroOfficeMobile8.Services;
using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;

namespace AstroOfficeMobile8
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()


                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://10.0.2.2:5004") });
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://ec2-15-207-51-190.ap-south-1.compute.amazonaws.com") });
#else
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://ec2-15-207-51-190.ap-south-1.compute.amazonaws.com") });
#endif
            builder.Services.AddScoped<ISwaggerApiService, SwaggerApiService>();
            builder.Services.AddScoped<IAccountService, AccountService>();

            return builder.Build();
        }
    }
}
