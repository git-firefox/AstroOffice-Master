using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Keyless]
    [Table("Query")]
    public partial class Query
    {
        [Column("ruleno", TypeName = "decimal(19, 0)")]
        public decimal? Ruleno { get; set; }
        [Column("common_pred")]
        public string? CommonPred { get; set; }
        [Column("male_pred")]
        public string? MalePred { get; set; }
        [Column("female_pred")]
        public string? FemalePred { get; set; }
        [Column("ruletype")]
        public string? Ruletype { get; set; }
    }
}
