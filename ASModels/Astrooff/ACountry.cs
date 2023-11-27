using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    [Table("a_country")]
    public partial class ACountry
    {
        public ACountry()
        {
            Addresses = new HashSet<Address>();
        }

        [Key]
        [Column("sno")]
        public long Sno { get; set; }
        [Column("country")]
        [StringLength(250)]
        [Unicode(false)]
        public string? Country { get; set; }

        [InverseProperty("ACountrySnoNavigation")]
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
