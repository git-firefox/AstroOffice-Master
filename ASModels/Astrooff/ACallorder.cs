using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Table("a_callorder")]
    public partial class ACallorder
    {
        [Key]
        [Column("sno")]
        public long Sno { get; set; }
        [Column("name")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Name { get; set; }
        [Column("dob", TypeName = "datetime")]
        public DateTime? Dob { get; set; }
        [Column("tob")]
        [StringLength(10)]
        [Unicode(false)]
        public string? Tob { get; set; }
        [Column("pob")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Pob { get; set; }
        [Column("product")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Product { get; set; }
        [Column("remarks")]
        [StringLength(500)]
        [Unicode(false)]
        public string? Remarks { get; set; }
        [Column("orderdate", TypeName = "datetime")]
        public DateTime? Orderdate { get; set; }
        [Column("phone")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Phone { get; set; }
        [Column("state")]
        [StringLength(50)]
        [Unicode(false)]
        public string? State { get; set; }
        [Column("city")]
        [StringLength(50)]
        [Unicode(false)]
        public string? City { get; set; }
        [Column("country")]
        public long? Country { get; set; }
        [Column("refnumber")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Refnumber { get; set; }
        [Column("gender")]
        [StringLength(10)]
        [Unicode(false)]
        public string? Gender { get; set; }
        [Column("maritalStatus")]
        [StringLength(10)]
        [Unicode(false)]
        public string? MaritalStatus { get; set; }
    }
}
