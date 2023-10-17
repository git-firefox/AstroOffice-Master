namespace AstroOfficeWeb.Server.Helper
{
    public static class BaseApiConst
    {
        public static string Base = "http://api.ssexpertsystem.com/api/v2/";
    }
    public static class BalanceApiConst
    {
        public static string Balance = BaseApiConst.Base + "Balance?ApiKey={0}&ClientId={1}";
    }
}
