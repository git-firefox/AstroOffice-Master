using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.MatchMaking
{
    [Keyless]
    [Table("tam_ruleshouse_female")]
    public partial class TamRuleshouseFemale
    {
        [Column("sno", TypeName = "decimal(19, 0)")]
        public decimal Sno { get; set; }
        [Column("female")]
        public string? Female { get; set; }
        [Column("other")]
        public string? Other { get; set; }
    }
}
