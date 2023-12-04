using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroShared.DTOs
{
    public abstract class BaseAddressDTO
    {

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50, ErrorMessage = "First Name cannot exceed 50 characters")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50, ErrorMessage = "Last Name cannot exceed 50 characters")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Address Line 1 is required")]
        [MaxLength(255, ErrorMessage = "Address Line 1 cannot exceed 255 characters")]
        public string? AddressLine1 { get; set; }

        [MaxLength(255, ErrorMessage = "Address Line 2 cannot exceed 255 characters")]
        public string? AddressLine2 { get; set; }

        [Required(ErrorMessage = "City is required")]
        [MaxLength(50, ErrorMessage = "City cannot exceed 50 characters")]
        public string? City { get; set; }

        [Required(ErrorMessage = "State is required")]
        [MaxLength(50, ErrorMessage = "State cannot exceed 50 characters")]
        public string? State { get; set; }

        [Required(ErrorMessage = "Zip Code is required")]
        [MaxLength(20, ErrorMessage = "Zip Code cannot exceed 20 characters")]
        public string? ZipCode { get; set; }

        [MaxLength(255, ErrorMessage = "Landmark cannot exceed 255 characters")]
        public string? Landmark { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [MaxLength(255, ErrorMessage = "Email cannot exceed 255 characters")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format")]
        public string? Email { get; set; }

        [MaxLength(255, ErrorMessage = "Country cannot exceed 255 characters")]
        public string? Country { get; set; }

        [Required]
        [MaxLength(12, ErrorMessage = "Phone Number cannot exceed 12 characters")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone Number must contain exactly 10 digits")]
        public string? PhoneNumber { get; set; }
    }


    public class AddressDTO : BaseAddressDTO
    {
        public long Sno { get; set; }

        [Required]
        [Display(Name = "Country")]
        [Range(1, 100000, ErrorMessage = "{0} is required.")]
        public long ACountrySno { get; set; }

        [Required]
        public string? AddressType { get; set; }
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }
    }
}

