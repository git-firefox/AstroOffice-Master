using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.MatchMaking
{
    [Keyless]
    [Table("kan_rulesnak_female")]
    public partial class KanRulesnakFemale
    {
        [Column("sno", TypeName = "decimal(19, 0)")]
        public decimal Sno { get; set; }
        [Column("female")]
        public string? Female { get; set; }
        [Column("other")]
        public string? Other { get; set; }
    }
}
