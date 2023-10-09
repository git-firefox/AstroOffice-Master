using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Table("a_appointment")]
    public partial class AAppointment
    {
        [Key]
        [Column("sno")]
        public long Sno { get; set; }
        [Column("appDate", TypeName = "datetime")]
        public DateTime? AppDate { get; set; }
        [Column("apptime")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Apptime { get; set; }
        [Column("persName")]
        [StringLength(50)]
        [Unicode(false)]
        public string? PersName { get; set; }
        [Column("DOB")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Dob { get; set; }
        [Column("POB")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Pob { get; set; }
        [Column("TOB")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Tob { get; set; }
        [Column("mobile")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Mobile { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? State { get; set; }
        [Column("city")]
        [StringLength(50)]
        [Unicode(false)]
        public string? City { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Country { get; set; }
        [Column("booked")]
        public bool? Booked { get; set; }
        [Column("confirmed")]
        public bool? Confirmed { get; set; }
        [Column("cancelled")]
        public bool? Cancelled { get; set; }
        [Column("referenceno")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Referenceno { get; set; }
        [Column("appType")]
        [StringLength(50)]
        [Unicode(false)]
        public string? AppType { get; set; }
        [Column("gender")]
        [StringLength(10)]
        [Unicode(false)]
        public string? Gender { get; set; }
        [Column("maritalStatus")]
        [StringLength(10)]
        [Unicode(false)]
        public string? MaritalStatus { get; set; }
        [Column("kundliid")]
        public long? Kundliid { get; set; }
    }
}
