using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.MatchMaking
{
    [Keyless]
    [Table("A_rulesnakenglish")]
    public partial class ARulesnakenglish
    {
        [Column("sno")]
        public long Sno { get; set; }
        [Column("charan1", TypeName = "text")]
        public string? Charan1 { get; set; }
        [Column("charan2", TypeName = "text")]
        public string? Charan2 { get; set; }
        [Column("charan3", TypeName = "text")]
        public string? Charan3 { get; set; }
        [Column("charan4", TypeName = "text")]
        public string? Charan4 { get; set; }
        [Column("male", TypeName = "text")]
        public string? Male { get; set; }
        [Column("female", TypeName = "text")]
        public string? Female { get; set; }
        [Column("pred", TypeName = "text")]
        public string? Pred { get; set; }
    }
}
