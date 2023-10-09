using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.MatchMaking
{
    [Keyless]
    [Table("ban_Charan1")]
    public partial class BanCharan1
    {
        [Column("sno", TypeName = "decimal(19, 0)")]
        public decimal Sno { get; set; }
        [Column("charan1")]
        public string? Charan1 { get; set; }
        [Column("other")]
        public string? Other { get; set; }
    }
}
