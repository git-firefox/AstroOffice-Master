using System.Configuration;

namespace ASDLL
{
    public static class ApplicationConfiguration
    {
        private static readonly string _dbConnectionString;

        private static readonly string _dbProviderName;

        public static string DbConnectionString
        {
            get
            {
                return _dbConnectionString;
            }
        }

        public static string DbProviderName
        {
            get
            {
                return _dbProviderName;
            }
        }

        public static bool EnableErrorLogEmail
        {
            get
            {
                return true;
            }
        }

        public static string ErrorLogEmail
        {
            get
            {
                return "errorlogmailing";
            }
        }

        public static string MailServer
        {
            get
            {
                return "mailserver";
            }
        }

        public static string NumPerPage
        {
            get
            {
                return "10";
            }
        }

        static ApplicationConfiguration()
        {
            if (!AstroGlobal.Online)
            {
                _dbConnectionString = ConfigurationManager.ConnectionStrings["AstroOfficeConnectionString"].ConnectionString.ToString();
                _dbProviderName = ConfigurationManager.ConnectionStrings["AstroOfficeConnectionString"].ProviderName.ToString();
            }
            else
            {
                _dbConnectionString = AstroGlobal.AstroConnectionString;
                _dbProviderName = "Microsoft.Data.SqlClient";
            }
        }
    }
}