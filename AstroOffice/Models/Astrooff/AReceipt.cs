using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.Astrooff
{
    [Table("a_receipt")]
    public partial class AReceipt
    {
        public AReceipt()
        {
            ADddetails = new HashSet<ADddetail>();
        }

        [Key]
        [Column("sno")]
        public long Sno { get; set; }
        [Column("date", TypeName = "datetime")]
        public DateTime? Date { get; set; }
        [Column("rupees")]
        public long? Rupees { get; set; }
        [Column("name")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Name { get; set; }
        [Column("address")]
        [StringLength(100)]
        [Unicode(false)]
        public string? Address { get; set; }
        [Column("contact")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Contact { get; set; }
        [Column("transactiontype")]
        [StringLength(10)]
        [Unicode(false)]
        public string? Transactiontype { get; set; }
        [Column("receiptSno")]
        public long? ReceiptSno { get; set; }
        [Column("transactionfor")]
        public bool? Transactionfor { get; set; }
        [Column("referenceno")]
        public long? Referenceno { get; set; }

        [InverseProperty("Receipt")]
        public virtual ICollection<ADddetail> ADddetails { get; set; }
    }
}
