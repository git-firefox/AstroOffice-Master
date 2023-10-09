using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.MatchMaking
{
    [Keyless]
    [Table("a_kundlis")]
    public partial class AKundli
    {
        [Column("sno")]
        public long Sno { get; set; }
        [Column("name")]
        [StringLength(250)]
        [Unicode(false)]
        public string? Name { get; set; }
        [Column("dob", TypeName = "datetime")]
        public DateTime? Dob { get; set; }
        [Column("tob", TypeName = "datetime")]
        public DateTime? Tob { get; set; }
        [Column("placeofbirth")]
        [StringLength(100)]
        [Unicode(false)]
        public string? Placeofbirth { get; set; }
        [Column("lagna")]
        public int? Lagna { get; set; }
        [Column("lon")]
        public double? Lon { get; set; }
        [Column("lat")]
        public double? Lat { get; set; }
        [Column("timezone")]
        public double? Timezone { get; set; }
        [Column("remarks")]
        [StringLength(500)]
        [Unicode(false)]
        public string? Remarks { get; set; }
    }
}
