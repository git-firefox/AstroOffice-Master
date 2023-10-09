using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Keyless]
    [Table("vfal_bangla")]
    public partial class VfalBangla
    {
        [Column("ruleno1")]
        public int Ruleno1 { get; set; }
        [Column("eng", TypeName = "text")]
        public string? Eng { get; set; }
        [Column("bangla", TypeName = "text")]
        public string? Bangla { get; set; }
    }
}
