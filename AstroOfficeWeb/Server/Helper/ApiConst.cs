namespace AstroOfficeWeb.Server.Helper
{
    public static class BalanceApiConst
    {
        public static string Balance = "Balance?ApiKey={0}&ClientId={1}";
    }
    public static class SMSApiConst
    {
        public static string POST_SendSMS = "SendSMS";
    }

    public class UserSaveRequest
    {
        public long Sno { get; set; }
        public string Name { get; set; } = null!;
        public string Prop1 { get; set; } = null!;
        public string Prop2 { get; set; } = null!;
        public DateTime Prop3 { get; set; } = DateTime.Now;
        public IFormFileCollection File { get; set; }
    }

}
