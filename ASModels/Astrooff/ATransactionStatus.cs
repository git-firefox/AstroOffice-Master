using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Table("A_Transaction_Statuses")]
    public partial class ATransactionStatus
    {
        public ATransactionStatus()
        {
            ACcavenueTransactions = new HashSet<ACcavenueTransaction>();
            ATokenTransactions = new HashSet<ATokenTransaction>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string StatusName { get; set; } = null!;
        [Column(TypeName = "text")]
        public string? Description { get; set; }

        [InverseProperty("ATransactionStatuses")]
        public virtual ICollection<ACcavenueTransaction> ACcavenueTransactions { get; set; }
        [InverseProperty("ATransactionStatuses")]
        public virtual ICollection<ATokenTransaction> ATokenTransactions { get; set; }
    }
}
