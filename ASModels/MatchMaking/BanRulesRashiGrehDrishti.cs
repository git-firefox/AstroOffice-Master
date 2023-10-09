using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.MatchMaking
{
    [Keyless]
    [Table("ban_RulesRashiGrehDrishti")]
    public partial class BanRulesRashiGrehDrishti
    {
        [Column("sno", TypeName = "decimal(19, 0)")]
        public decimal Sno { get; set; }
        [Column("pred")]
        public string? Pred { get; set; }
        [Column("other")]
        public string? Other { get; set; }
    }
}
