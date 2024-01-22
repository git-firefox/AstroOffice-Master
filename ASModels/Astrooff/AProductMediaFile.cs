using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Table("A_ProductMediaFiles")]
    public partial class AProductMediaFile
    {
        [Key]
        public long Sno { get; set; }
        [Column("A_Products_Sno")]
        public long? AProductsSno { get; set; }
        public string? MediaUrl { get; set; }
        [StringLength(510)]
        public string? MediaName { get; set; }
        [StringLength(50)]
        public string? MediaType { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UploadDate { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsSecondary { get; set; }

        [ForeignKey("AProductsSno")]
        [InverseProperty("AProductMediaFiles")]
        public virtual AProduct? AProductsSnoNavigation { get; set; }
    }
}
