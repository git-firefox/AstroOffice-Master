using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Table("a_varshphal")]
    public partial class AVarshphal
    {
        [Key]
        [Column("sno")]
        public int Sno { get; set; }
        [Column("age")]
        public int? Age { get; set; }
        [Column("house1")]
        public int? House1 { get; set; }
        [Column("house2")]
        public int? House2 { get; set; }
        [Column("house3")]
        public int? House3 { get; set; }
        [Column("house4")]
        public int? House4 { get; set; }
        [Column("house5")]
        public int? House5 { get; set; }
        [Column("house6")]
        public int? House6 { get; set; }
        [Column("house7")]
        public int? House7 { get; set; }
        [Column("house8")]
        public int? House8 { get; set; }
        [Column("house9")]
        public int? House9 { get; set; }
        [Column("house10")]
        public int? House10 { get; set; }
        [Column("house11")]
        public int? House11 { get; set; }
        [Column("house12")]
        public int? House12 { get; set; }
    }
}
