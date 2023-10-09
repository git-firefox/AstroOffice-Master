using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Table("a_user_log")]
    public partial class AUserLog
    {
        [Key]
        [Column("sno")]
        public long Sno { get; set; }
        [Column("username")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Username { get; set; }
        [Column("logintime", TypeName = "datetime")]
        public DateTime? Logintime { get; set; }
        [Column("systemname")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Systemname { get; set; }
        [Column("loginsuccess")]
        public bool? Loginsuccess { get; set; }
    }
}
