// Ignore Spelling: Astro Sno Username Adminuser Astrooff

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Table("a_users")]
    public partial class AUser
    {
        [Key]
        [Column("sno")]
        public long Sno { get; set; }
        [Column("username")]
        [StringLength(250)]
        [Unicode(false)]
        public string? Username { get; set; }
        [Column("password")]
        [StringLength(250)]
        [Unicode(false)]
        public string? Password { get; set; }
        [Column("adminuser")]
        public bool? Adminuser { get; set; }
        public bool? CanAdd { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanReport { get; set; }
        [Column("active")]
        public bool? Active { get; set; }
        public string? MobileNumber { get; set; }
        public string? MobileOtp { get; set; }
    }
}
