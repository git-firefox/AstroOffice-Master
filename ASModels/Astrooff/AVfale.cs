using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Keyless]
    [Table("A_vfale")]
    public partial class AVfale
    {
        [Column("ruleno")]
        public long? Ruleno { get; set; }
        [Column("eng")]
        [StringLength(8000)]
        [Unicode(false)]
        public string? Eng { get; set; }
    }
}
