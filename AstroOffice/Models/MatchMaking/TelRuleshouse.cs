using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.MatchMaking
{
    [Keyless]
    [Table("tel_Ruleshouse")]
    public partial class TelRuleshouse
    {
        [Column("sno", TypeName = "decimal(19, 0)")]
        public decimal Sno { get; set; }
        [Column("hindi")]
        public string? Hindi { get; set; }
        [Column("eng")]
        public string? Eng { get; set; }
        [Column("other")]
        public string? Other { get; set; }
    }
}
