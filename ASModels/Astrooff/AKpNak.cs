using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Keyless]
    [Table("A_Kp_Nak")]
    public partial class AKpNak
    {
        [Column("sno")]
        public int? Sno { get; set; }
        [Column("rashi")]
        public int? Rashi { get; set; }
        [Column("from_degree")]
        [StringLength(50)]
        [Unicode(false)]
        public string? FromDegree { get; set; }
        [Column("to_degree")]
        [StringLength(50)]
        [Unicode(false)]
        public string? ToDegree { get; set; }
        [Column("rashi_lord")]
        public int? RashiLord { get; set; }
        [Column("nak_lord")]
        public int? NakLord { get; set; }
        [Column("sub_lord")]
        public int? SubLord { get; set; }
        [Column("greh1")]
        public int? Greh1 { get; set; }
        [Column("time1_from")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Time1From { get; set; }
        [Column("time1_to")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Time1To { get; set; }
        [Column("greh2")]
        public int? Greh2 { get; set; }
        [Column("time2_from")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Time2From { get; set; }
        [Column("time2_to")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Time2To { get; set; }
        [Column("greh3")]
        public int? Greh3 { get; set; }
        [Column("time3_from")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Time3From { get; set; }
        [Column("time3_to")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Time3To { get; set; }
        [Column("greh4")]
        public int? Greh4 { get; set; }
        [Column("time4_from")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Time4From { get; set; }
        [Column("time4_to")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Time4To { get; set; }
        [Column("greh5")]
        public int? Greh5 { get; set; }
        [Column("time5_from")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Time5From { get; set; }
        [Column("time5_to")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Time5To { get; set; }
        [Column("greh6")]
        public int? Greh6 { get; set; }
        [Column("time6_from")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Time6From { get; set; }
        [Column("time6_to")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Time6To { get; set; }
        [Column("greh7")]
        public int? Greh7 { get; set; }
        [Column("time7_from")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Time7From { get; set; }
        [Column("time7_to")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Time7To { get; set; }
        [Column("greh8")]
        public int? Greh8 { get; set; }
        [Column("time8_from")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Time8From { get; set; }
        [Column("time8_to")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Time8To { get; set; }
        [Column("greh9")]
        public int? Greh9 { get; set; }
        [Column("time9_from")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Time9From { get; set; }
        [Column("time9_to")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Time9To { get; set; }
    }
}
