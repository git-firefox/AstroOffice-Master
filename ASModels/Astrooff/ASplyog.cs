using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Keyless]
    [Table("A_splyog")]
    public partial class ASplyog
    {
        [Column("sno")]
        public long Sno { get; set; }
        [Column("ruleno")]
        public long? Ruleno { get; set; }
        [Column("pred", TypeName = "text")]
        public string? Pred { get; set; }
    }
}
