using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Table("A_hindi_mobile_Translate")]
    public partial class AHindiMobileTranslate
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        public int? Sno { get; set; }
        public string? PredHindi { get; set; }
        public string? CommonPred { get; set; }
        public string? Paraphrase { get; set; }
    }
}
