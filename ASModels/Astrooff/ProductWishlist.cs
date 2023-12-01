using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Table("ProductWishlist")]
    public partial class ProductWishlist
    {
        [Key]
        public long Sno { get; set; }
        [Column("A_Products_Sno")]
        public long? AProductsSno { get; set; }
        [Column("A_Users_Sno")]
        public long? AUsersSno { get; set; }

        [ForeignKey("AProductsSno")]
        [InverseProperty("ProductWishlists")]
        public virtual AProduct? AProductsSnoNavigation { get; set; }
        [ForeignKey("AUsersSno")]
        [InverseProperty("ProductWishlists")]
        public virtual AUser? AUsersSnoNavigation { get; set; }
    }
}
