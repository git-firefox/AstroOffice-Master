using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.Astrooff
{
    [Keyless]
    [Table("vfal_telugu")]
    public partial class VfalTelugu
    {
        [Column("ruleno1")]
        public int Ruleno1 { get; set; }
        [Column("eng", TypeName = "text")]
        public string? Eng { get; set; }
        [Column("telugu", TypeName = "text")]
        public string? Telugu { get; set; }
    }
}
