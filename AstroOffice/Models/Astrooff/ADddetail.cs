using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.Astrooff
{
    [Table("a_DDdetail")]
    public partial class ADddetail
    {
        [Column("bankname")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Bankname { get; set; }
        [Column("state")]
        [StringLength(50)]
        [Unicode(false)]
        public string? State { get; set; }
        [Column("branchaddress")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Branchaddress { get; set; }
        [Column("paybleat")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Paybleat { get; set; }
        [Column("ddnumber")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Ddnumber { get; set; }
        [Column("receiptno")]
        public long? Receiptno { get; set; }
        [Key]
        [Column("sno")]
        public long Sno { get; set; }
        [Column("date", TypeName = "datetime")]
        public DateTime? Date { get; set; }
        [Column("receiptid")]
        public long? Receiptid { get; set; }

        [ForeignKey("Receiptid")]
        [InverseProperty("ADddetails")]
        public virtual AReceipt? Receipt { get; set; }
    }
}
