using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.MatchMaking
{
    [Keyless]
    [Table("A_KP_Pancham_Rashi_House")]
    public partial class AKpPanchamRashiHouse
    {
        [Column("sno")]
        public long Sno { get; set; }
        [Column("naklord")]
        public int? Naklord { get; set; }
        [Column("house")]
        public int? House { get; set; }
        [Column("pred", TypeName = "text")]
        public string? Pred { get; set; }
    }
}
