using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.Astrooff
{
    [Table("a_changelog")]
    public partial class AChangelog
    {
        [Key]
        [Column("sno")]
        public long Sno { get; set; }
        [Column("tablename")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Tablename { get; set; }
        [Column("columname")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Columname { get; set; }
        [Column("oldaval")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Oldaval { get; set; }
        [Column("newval")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Newval { get; set; }
        [Column("modifiedOn", TypeName = "datetime")]
        public DateTime? ModifiedOn { get; set; }
        [Column("modifiedby")]
        public long? Modifiedby { get; set; }
    }
}
