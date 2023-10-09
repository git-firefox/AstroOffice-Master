using System.Configuration;
using ASBAL;
using ASDAL;
using ASModels;
using AstroOffice.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AstroOffice
{
    internal static class Program
    {
        public static ServiceProvider ServiceProvider { get; private set; }

        private static void BuildServiceProvider(IServiceCollection services)
        {
            services.AddTransient<BALUser>();
            services.AddTransient<DALUser>();
            services.AddTransient<DALCountry>();
            services.AddTransient<BALCountry>();
            services.AddDbContext<AstrooffContext>(options =>
            {
                options.UseSqlServer(ConfigurationManager.ConnectionStrings["AstroOfficeConnectionString"].ConnectionString.ToString());
            });
            ServiceProvider = services.BuildServiceProvider();
        }

        public static void DisposeServiceProvider()
        {
            ServiceProvider?.Dispose();
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            BuildServiceProvider(new ServiceCollection());

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            //Application.Run(new FrmNewKP());
            Application.Run(new FrmLogin());
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            ExceptionHandler.HandleException(e.Exception);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            if (ex != null)
            {
                ExceptionHandler.HandleException(ex);
            }
        }
    }
}