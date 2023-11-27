using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ASModels.Astrooff
{
    public partial class Address
    {
        [Key]
        public long Sno { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string? AddressType { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? AddressLine1 { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? AddressLine2 { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? City { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? State { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string? ZipCode { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? Landmark { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? Email { get; set; }
        [StringLength(255)]
        [Unicode(false)]
        public string? Country { get; set; }
        [StringLength(12)]
        [Unicode(false)]
        public string? PhoneNumber { get; set; }
        [Column("A_Users_Sno")]
        public long? AUsersSno { get; set; }
        [Column("A_country_Sno")]
        public long? ACountrySno { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? FirstName { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? LastName { get; set; }
        [Required]
        public bool? IsActive { get; set; }

        [ForeignKey("ACountrySno")]
        [InverseProperty("Addresses")]
        public virtual ACountry? ACountrySnoNavigation { get; set; }
        [ForeignKey("AUsersSno")]
        [InverseProperty("Addresses")]
        public virtual AUser? AUsersSnoNavigation { get; set; }
    }
}
