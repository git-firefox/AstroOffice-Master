using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.Astrooff
{
    [Keyless]
    [Table("Female")]
    public partial class Female
    {
        [Column("ruleno", TypeName = "decimal(19, 0)")]
        public decimal? Ruleno { get; set; }
        [Column("hindi_female")]
        public string? HindiFemale { get; set; }
        [Column("eng_female")]
        public string? EngFemale { get; set; }
        [Column("bang_female")]
        public string? BangFemale { get; set; }
        [Column("ruletype")]
        public string? Ruletype { get; set; }
    }
}
