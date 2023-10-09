using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Table("A_kundlis")]
    public partial class AKundli
    {
        [Key]
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
        [Column("entrytime", TypeName = "datetime")]
        public DateTime? Entrytime { get; set; }
        [Column("username")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Username { get; set; }
        [Column("gender")]
        public bool? Gender { get; set; }
        [Column("varshfalyears")]
        [StringLength(500)]
        [Unicode(false)]
        public string? Varshfalyears { get; set; }
        [Column("orderno")]
        public long? Orderno { get; set; }
        [Column("product")]
        [StringLength(100)]
        [Unicode(false)]
        public string? Product { get; set; }
        [Column("paid")]
        public bool? Paid { get; set; }
        [Column("lonstr")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Lonstr { get; set; }
        [Column("latstr")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Latstr { get; set; }
        [Column("timezonestr")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Timezonestr { get; set; }
        [Column("language")]
        [StringLength(20)]
        [Unicode(false)]
        public string? Language { get; set; }
        [Column("manual")]
        public bool? Manual { get; set; }
        [Column("source")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Source { get; set; }
        [Column("dd")]
        [StringLength(5)]
        [Unicode(false)]
        public string? Dd { get; set; }
        [Column("mm")]
        [StringLength(5)]
        [Unicode(false)]
        public string? Mm { get; set; }
        [Column("yy")]
        [StringLength(5)]
        [Unicode(false)]
        public string? Yy { get; set; }
        [Column("hh")]
        [StringLength(5)]
        [Unicode(false)]
        public string? Hh { get; set; }
        [Column("min")]
        [StringLength(5)]
        [Unicode(false)]
        public string? Min { get; set; }
        [Column("ss")]
        [StringLength(5)]
        [Unicode(false)]
        public string? Ss { get; set; }
        [Column("machine")]
        [StringLength(200)]
        [Unicode(false)]
        public string? Machine { get; set; }
    }
}
