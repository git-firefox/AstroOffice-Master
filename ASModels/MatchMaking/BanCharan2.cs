using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.MatchMaking
{
    [Keyless]
    [Table("ban_charan2")]
    public partial class BanCharan2
    {
        [Column("sno", TypeName = "decimal(19, 0)")]
        public decimal Sno { get; set; }
        [Column("charan2")]
        public string? Charan2 { get; set; }
        [Column("other")]
        public string? Other { get; set; }
    }
}
