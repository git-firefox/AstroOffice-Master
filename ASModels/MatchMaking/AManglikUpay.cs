using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.MatchMaking
{
    [Keyless]
    [Table("A_manglik_upay")]
    public partial class AManglikUpay
    {
        [Column("sno")]
        public long? Sno { get; set; }
        [Column("lagnarashi")]
        public int? Lagnarashi { get; set; }
        [Column("mangaliktype")]
        public int? Mangaliktype { get; set; }
        [Column("upayhindi", TypeName = "text")]
        public string? Upayhindi { get; set; }
        [Column("upayenglish", TypeName = "text")]
        public string? Upayenglish { get; set; }
        [Column("upaybangla", TypeName = "text")]
        public string? Upaybangla { get; set; }
        [Column("upaykannada", TypeName = "text")]
        public string? Upaykannada { get; set; }
        [Column("upaytamil", TypeName = "text")]
        public string? Upaytamil { get; set; }
        [Column("upaytelugu", TypeName = "text")]
        public string? Upaytelugu { get; set; }
    }
}
