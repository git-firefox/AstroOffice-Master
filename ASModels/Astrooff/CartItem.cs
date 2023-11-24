using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    public partial class CartItem
    {
        [Key]
        public int Sno { get; set; }
        public int? Quantity { get; set; }
        [Column("ShoppingCarts_Sno")]
        public long? ShoppingCartsSno { get; set; }
        [Column("A_Products_Sno")]
        public long? AProductsSno { get; set; }

        [ForeignKey("AProductsSno")]
        [InverseProperty("CartItems")]
        public virtual AProduct? AProductsSnoNavigation { get; set; }
        [ForeignKey("ShoppingCartsSno")]
        [InverseProperty("CartItems")]
        public virtual ShoppingCart? ShoppingCartsSnoNavigation { get; set; }
    }
}
