using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Keyless]
    [Table("Query_eng")]
    public partial class QueryEng
    {
        [Column("ruleno", TypeName = "decimal(19, 0)")]
        public decimal? Ruleno { get; set; }
        [Column("hindi_common")]
        public string? HindiCommon { get; set; }
        [Column("eng_common")]
        public string? EngCommon { get; set; }
        [Column("ruletype")]
        public string? Ruletype { get; set; }
    }
}
