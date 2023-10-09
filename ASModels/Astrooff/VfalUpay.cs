using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Keyless]
    [Table("vfal_upay")]
    public partial class VfalUpay
    {
        [Column("ruleno1")]
        public int Ruleno1 { get; set; }
        [Column("hindi")]
        public string? Hindi { get; set; }
        [Column("eng")]
        public string? Eng { get; set; }
    }
}
