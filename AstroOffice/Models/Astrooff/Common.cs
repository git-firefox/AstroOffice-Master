using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.Astrooff
{
    [Keyless]
    [Table("Common")]
    public partial class Common
    {
        [Column("ruleno", TypeName = "decimal(19, 0)")]
        public decimal? Ruleno { get; set; }
        [Column("hindi_common")]
        public string? HindiCommon { get; set; }
        [Column("eng_common")]
        public string? EngCommon { get; set; }
        [Column("bang_common")]
        public string? BangCommon { get; set; }
        [Column("ruletype")]
        public string? Ruletype { get; set; }
    }
}
