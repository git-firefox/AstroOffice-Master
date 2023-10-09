using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.MatchMaking
{
    [Keyless]
    [Table("A_KP_Planet_Rashi")]
    public partial class AKpPlanetRashi
    {
        [Column("sno")]
        public long Sno { get; set; }
        [Column("planet")]
        public int? Planet { get; set; }
        [Column("rashi")]
        public int? Rashi { get; set; }
        [Column("pred", TypeName = "text")]
        public string? Pred { get; set; }
    }
}
