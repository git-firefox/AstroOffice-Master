using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.MatchMaking
{
    [Keyless]
    [Table("tel_manglikupay")]
    public partial class TelManglikupay
    {
        [Column("sno", TypeName = "decimal(19, 0)")]
        public decimal? Sno { get; set; }
        [Column("hindi")]
        public string? Hindi { get; set; }
        [Column("eng")]
        public string? Eng { get; set; }
        [Column("other")]
        public string? Other { get; set; }
    }
}
