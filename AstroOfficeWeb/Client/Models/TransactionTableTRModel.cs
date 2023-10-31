namespace AstroOfficeWeb.Client.Models
{
    public class TransactionTableTRModel : TableAttributeConfiguration
    {
        public int ID { get; set; }
        public int SrNo { get; set; }
        public string? UserSNO { get; set; }
        public string? TransactionType { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
        public int TransactionStatusID { get; set; }
        public DateTime? TimestampCreated { get; set; }
    }
}
