﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.MatchMaking
{
    [Keyless]
    [Table("tel_RulesHouseDrishti_male")]
    public partial class TelRulesHouseDrishtiMale
    {
        [Column("sno", TypeName = "decimal(19, 0)")]
        public decimal Sno { get; set; }
        [Column("male")]
        public string? Male { get; set; }
        [Column("other")]
        public string? Other { get; set; }
    }
}
