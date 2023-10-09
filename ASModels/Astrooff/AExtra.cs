using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Keyless]
    [Table("A_extra")]
    public partial class AExtra
    {
        [Column("sno")]
        public long Sno { get; set; }
        [Column("ruleformula")]
        [StringLength(1000)]
        [Unicode(false)]
        public string? Ruleformula { get; set; }
        [Column("isbad")]
        public bool? Isbad { get; set; }
        [Column("title")]
        [StringLength(2000)]
        [Unicode(false)]
        public string? Title { get; set; }
        [Column("actualformula", TypeName = "text")]
        public string? Actualformula { get; set; }
        [Column("reference")]
        [StringLength(500)]
        [Unicode(false)]
        public string? Reference { get; set; }
        [Column("newlang", TypeName = "text")]
        public string? Newlang { get; set; }
        [Column("ruletype")]
        [StringLength(20)]
        [Unicode(false)]
        public string? Ruletype { get; set; }
        [Column("female_newlang", TypeName = "text")]
        public string? FemaleNewlang { get; set; }
        [Column("child_male", TypeName = "text")]
        public string? ChildMale { get; set; }
        [Column("child_female", TypeName = "text")]
        public string? ChildFemale { get; set; }
        [Column("eng_male", TypeName = "text")]
        public string? EngMale { get; set; }
        [Column("eng_female", TypeName = "text")]
        public string? EngFemale { get; set; }
        [Column("eng_child_male", TypeName = "text")]
        public string? EngChildMale { get; set; }
        [Column("eng_child_female", TypeName = "text")]
        public string? EngChildFemale { get; set; }
    }
}
