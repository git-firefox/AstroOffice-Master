﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Keyless]
    [Table("A_hindi")]
    public partial class AHindi
    {
        [Column("sno")]
        public long Sno { get; set; }
        [Column("ruleno")]
        public long? Ruleno { get; set; }
        [Column("common_pred", TypeName = "text")]
        public string? CommonPred { get; set; }
        [Column("male_pred", TypeName = "text")]
        public string? MalePred { get; set; }
        [Column("female_pred", TypeName = "text")]
        public string? FemalePred { get; set; }
        [Column("child_pred", TypeName = "text")]
        public string? ChildPred { get; set; }
    }
}
