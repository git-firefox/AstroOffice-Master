﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Keyless]
    [Table("A_rules_upay")]
    public partial class ARulesUpay
    {
        [Column("sno")]
        public long Sno { get; set; }
        [Column("ruleno")]
        public int? Ruleno { get; set; }
        [Column("upayno")]
        public int? Upayno { get; set; }
    }
}
