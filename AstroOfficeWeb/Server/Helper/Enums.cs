namespace AstroOfficeWeb.Server.Helper
{
    public enum TransactionStatus
    {
        Success = 1,
        Failed = 2,
        Pending = 3,
        Refunded = 4,
        Canceled = 5,
        Chargeback = 6,
        Error = 7
    }
}
