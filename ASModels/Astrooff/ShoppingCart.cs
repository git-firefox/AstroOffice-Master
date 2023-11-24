using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    public partial class ShoppingCart
    {
        public ShoppingCart()
        {
            CartItems = new HashSet<CartItem>();
        }

        [Key]
        public long Sno { get; set; }
        [Column("A_Users_Sno")]
        public long? AUsersSno { get; set; }

        [ForeignKey("AUsersSno")]
        [InverseProperty("ShoppingCarts")]
        public virtual AUser? AUsersSnoNavigation { get; set; }
        [InverseProperty("ShoppingCartsSnoNavigation")]
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
