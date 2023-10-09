using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.MatchMaking
{
    [Keyless]
    [Table("A_KP_Shashtam_Naklord_Disease")]
    public partial class AKpShashtamNaklordDisease
    {
        [Column("sno")]
        public long Sno { get; set; }
        [Column("naklord")]
        public int? Naklord { get; set; }
        [Column("pred", TypeName = "text")]
        public string? Pred { get; set; }
    }
}
