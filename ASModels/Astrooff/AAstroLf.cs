﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Keyless]
    [Table("A_Astro_LF")]
    public partial class AAstroLf
    {
        [Column("sno")]
        public long Sno { get; set; }
        [Column("lagna")]
        public long Lagna { get; set; }
        [Column("pred", TypeName = "text")]
        public string? Pred { get; set; }
        [Column("marathi", TypeName = "text")]
        public string? Marathi { get; set; }
        [Column("punjabi", TypeName = "text")]
        public string? Punjabi { get; set; }
        [Column("english", TypeName = "text")]
        public string? English { get; set; }
    }
}
