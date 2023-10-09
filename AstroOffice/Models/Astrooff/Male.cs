using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.Astrooff
{
    [Keyless]
    [Table("Male")]
    public partial class Male
    {
        [Column("ruleno", TypeName = "decimal(19, 0)")]
        public decimal? Ruleno { get; set; }
        [Column("hindi_male")]
        public string? HindiMale { get; set; }
        [Column("eng_male")]
        public string? EngMale { get; set; }
        [Column("bang_male")]
        public string? BangMale { get; set; }
        [Column("ruletype")]
        public string? Ruletype { get; set; }
    }
}
