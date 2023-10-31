﻿namespace AstroOfficeWeb.Client.Models
{
    public class TokenRechargeTableTRModel : TableAttributeConfiguration
    {
        public int SrNo { get; set; }
        public int ID { get; set; }
        public string? UserSNO { get; set; }
        public decimal? PaymentAmount { get; set; }
        public int TransactionStatusID { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string? Status { get; set; }
        public DateTime? TimestampCreated { get; set; }
    }
}
