using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Keyless]
    [Table("vfal_tamil")]
    public partial class VfalTamil
    {
        [Column("ruleno1")]
        public int Ruleno1 { get; set; }
        [Column("eng", TypeName = "text")]
        public string? Eng { get; set; }
        [Column("tamil", TypeName = "text")]
        public string? Tamil { get; set; }
    }
}
