using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.Astrooff
{
    [Keyless]
    [Table("A_telugu")]
    [Index("Ruleno", Name = "IX_A_telugu_1")]
    public partial class ATelugu
    {
        [Column("sno")]
        public long Sno { get; set; }
        [Column("ruleno")]
        public long? Ruleno { get; set; }
        [Column("male_pred", TypeName = "ntext")]
        public string? MalePred { get; set; }
        [Column("female_pred", TypeName = "ntext")]
        public string? FemalePred { get; set; }
        [Column("common_pred", TypeName = "ntext")]
        public string? CommonPred { get; set; }
        [Column("child_pred", TypeName = "ntext")]
        public string? ChildPred { get; set; }
    }
}
