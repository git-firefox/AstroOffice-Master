using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.MatchMaking
{
    [Keyless]
    [Table("A_KP_House_NakLord")]
    public partial class AKpHouseNakLord
    {
        [Column("sno")]
        public long Sno { get; set; }
        [Column("house")]
        public int? House { get; set; }
        [Column("naklord")]
        public int? Naklord { get; set; }
        [Column("title", TypeName = "text")]
        public string? Title { get; set; }
        [Column("pred", TypeName = "text")]
        public string? Pred { get; set; }
    }
}
