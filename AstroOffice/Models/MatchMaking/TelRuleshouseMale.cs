using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.MatchMaking
{
    [Keyless]
    [Table("tel_ruleshouse_male")]
    public partial class TelRuleshouseMale
    {
        [Column("sno", TypeName = "decimal(19, 0)")]
        public decimal Sno { get; set; }
        [Column("male")]
        public string? Male { get; set; }
        [Column("other")]
        public string? Other { get; set; }
    }
}
