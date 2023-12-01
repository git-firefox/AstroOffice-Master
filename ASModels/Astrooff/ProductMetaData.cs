using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    public partial class ProductMetaData
    {
        [Key]
        public long Sno { get; set; }
        [StringLength(255)]
        public string? MetaKeyword { get; set; }
        [StringLength(255)]
        public string? MetaValue { get; set; }
        [Column("A_Products_Sno")]
        public long? AProductsSno { get; set; }

        [ForeignKey("AProductsSno")]
        [InverseProperty("ProductMetaData")]
        public virtual AProduct? AProductsSnoNavigation { get; set; }
    }
}
