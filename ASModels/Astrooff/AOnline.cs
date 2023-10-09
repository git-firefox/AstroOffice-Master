using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Keyless]
    [Table("A_online")]
    public partial class AOnline
    {
        [Column("sno", TypeName = "decimal(19, 0)")]
        public decimal Sno { get; set; }
        [Column("ruleformula")]
        public string? Ruleformula { get; set; }
        [Column("isbad")]
        public short? Isbad { get; set; }
        [Column("title")]
        public string? Title { get; set; }
        [Column("actualformula")]
        public string? Actualformula { get; set; }
        [Column("reference")]
        public string? Reference { get; set; }
        [Column("newlang")]
        public string? Newlang { get; set; }
        [Column("ruletype")]
        public string? Ruletype { get; set; }
        [Column("female_newlang")]
        public string? FemaleNewlang { get; set; }
        [Column("child_male")]
        public string? ChildMale { get; set; }
        [Column("child_female")]
        public string? ChildFemale { get; set; }
        [Column("eng_male")]
        public string? EngMale { get; set; }
        [Column("eng_female")]
        public string? EngFemale { get; set; }
        [Column("eng_child_male")]
        public string? EngChildMale { get; set; }
        [Column("eng_child_female")]
        public string? EngChildFemale { get; set; }
    }
}
