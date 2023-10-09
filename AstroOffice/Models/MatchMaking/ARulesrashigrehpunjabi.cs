using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.MatchMaking
{
    [Keyless]
    [Table("A_rulesrashigrehpunjabi")]
    public partial class ARulesrashigrehpunjabi
    {
        [Column("sno")]
        public long Sno { get; set; }
        [Column("male", TypeName = "text")]
        public string? Male { get; set; }
        [Column("female", TypeName = "text")]
        public string? Female { get; set; }
        [Column("pred", TypeName = "text")]
        public string? Pred { get; set; }
    }
}
