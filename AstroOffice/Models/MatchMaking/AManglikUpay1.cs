using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.MatchMaking
{
    [Keyless]
    [Table("A_manglik_upay1")]
    public partial class AManglikUpay1
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
    }
}
