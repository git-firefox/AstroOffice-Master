using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    public partial class ProductMedia
    {
        [Key]
        public long Sno { get; set; }
        [Column("A_Products_Sno")]
        public long? AProductsSno { get; set; }
        public string? MediaUrl { get; set; }
        [StringLength(255)]
        public string? MediaName { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? MediaType { get; set; }
        public int? MediaOrder { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsSecondary { get; set; }

        [ForeignKey("AProductsSno")]
        [InverseProperty("ProductMedia")]
        public virtual AProduct? AProductsSnoNavigation { get; set; }
    }
}
