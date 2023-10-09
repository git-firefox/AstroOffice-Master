using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.MatchMaking
{
    [Keyless]
    [Table("a_temp_mappings")]
    public partial class ATempMapping
    {
        [Column("map_no")]
        public long? MapNo { get; set; }
        [Column("house")]
        public int? House { get; set; }
        [Column("planet")]
        public int? Planet { get; set; }

        [ForeignKey("MapNo")]
        public virtual ATempMap? MapNoNavigation { get; set; }
    }
}
