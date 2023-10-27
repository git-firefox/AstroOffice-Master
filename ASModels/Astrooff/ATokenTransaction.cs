using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Table("A_TokenTransactions")]
    public partial class ATokenTransaction
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("A_User_SNO")]
        public long? AUserSno { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string TransactionType { get; set; } = null!;
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Amount { get; set; }
        [Column(TypeName = "text")]
        public string? Description { get; set; }
        [Column("A_Transaction_Statuses_ID")]
        public int? ATransactionStatusesId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? TimestampCreated { get; set; }

        [ForeignKey("ATransactionStatusesId")]
        [InverseProperty("ATokenTransactions")]
        public virtual ATransactionStatus? ATransactionStatuses { get; set; }
        [ForeignKey("AUserSno")]
        [InverseProperty("ATokenTransactions")]
        public virtual AUser? AUserSnoNavigation { get; set; }
    }
}
