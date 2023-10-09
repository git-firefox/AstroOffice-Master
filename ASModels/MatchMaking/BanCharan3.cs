using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.MatchMaking
{
    [Keyless]
    [Table("ban_Charan3")]
    public partial class BanCharan3
    {
        [Column("sno", TypeName = "decimal(19, 0)")]
        public decimal Sno { get; set; }
        [Column("charan3")]
        public string? Charan3 { get; set; }
        [Column("other")]
        public string? Other { get; set; }
    }
}
