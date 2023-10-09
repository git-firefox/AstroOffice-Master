using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Keyless]
    [Table("A_data")]
    public partial class ADatum
    {
        [Column("sno")]
        public long Sno { get; set; }
        [Column("hindi", TypeName = "text")]
        public string? Hindi { get; set; }
        [Column("english", TypeName = "text")]
        public string? English { get; set; }
        [Column("ruletype")]
        [StringLength(20)]
        [Unicode(false)]
        public string? Ruletype { get; set; }
    }
}
