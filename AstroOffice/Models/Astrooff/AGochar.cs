using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.Astrooff
{
    [Keyless]
    [Table("A_gochar")]
    public partial class AGochar
    {
        [Column("sno")]
        public int Sno { get; set; }
        [Column("planet")]
        public int? Planet { get; set; }
        [Column("rashi")]
        public int? Rashi { get; set; }
        [Column("entrydate", TypeName = "datetime")]
        public DateTime? Entrydate { get; set; }
        [Column("exitdate", TypeName = "datetime")]
        public DateTime? Exitdate { get; set; }
        [Column("rflag")]
        public bool? Rflag { get; set; }
    }
}
