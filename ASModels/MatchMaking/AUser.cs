using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.MatchMaking
{
    [Table("a_users")]
    public partial class AUser
    {
        [Key]
        [Column("sno")]
        public long Sno { get; set; }
        [Column("username")]
        [StringLength(150)]
        [Unicode(false)]
        public string? Username { get; set; }
        [Column("password")]
        [StringLength(150)]
        [Unicode(false)]
        public string? Password { get; set; }
        [Column("active")]
        public bool? Active { get; set; }
    }
}
