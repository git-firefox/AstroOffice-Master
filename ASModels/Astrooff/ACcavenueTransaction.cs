using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Table("A_CCAvenueTransactions")]
    public partial class ACcavenueTransaction
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("A_UserSNO")]
        public long? AUserSno { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal PaymentAmount { get; set; }
        [Column("A_Transaction_Statuses_ID")]
        public int? ATransactionStatusesId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PaymentDate { get; set; }
        [Column("CCAvenueResponse", TypeName = "text")]
        public string? CcavenueResponse { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? TimestampCreated { get; set; }

        [ForeignKey("ATransactionStatusesId")]
        [InverseProperty("ACcavenueTransactions")]
        public virtual ATransactionStatus? ATransactionStatuses { get; set; }
        [ForeignKey("AUserSno")]
        [InverseProperty("ACcavenueTransactions")]
        public virtual AUser? AUserSnoNavigation { get; set; }
    }
}
