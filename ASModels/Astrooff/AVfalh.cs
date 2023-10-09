using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Keyless]
    [Table("A_vfalh")]
    public partial class AVfalh
    {
        [Column("ruleno")]
        public long? Ruleno { get; set; }
        [Column("hindi")]
        [StringLength(8000)]
        [Unicode(false)]
        public string? Hindi { get; set; }
    }
}
