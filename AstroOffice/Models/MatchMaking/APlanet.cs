﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AstroOffice.Models.MatchMaking
{
    [Keyless]
    [Table("A_planet")]
    public partial class APlanet
    {
        [Column("sno")]
        public long Sno { get; set; }
        [Column("name")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Name { get; set; }
        [Column("hindi")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Hindi { get; set; }
        [Column("english")]
        [StringLength(50)]
        [Unicode(false)]
        public string? English { get; set; }
    }
}
