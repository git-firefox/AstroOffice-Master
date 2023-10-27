using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Shared.Models
{
    public class SaveKundaliRequest
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? ProductName { get; set; }
        public string? Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public TimeSpan TimeOfBirth { get; set; }
        public int PlaceOfBirthID { get; set; }
        public string? Language { get; set; }
        public bool IsPaid { get; set; }
        public bool IsSaved { get; set; }
        public DateTime? ViewDate { get; set; }
        public string? A_User_SNO { get; set; }
        public string? CountryCode { get; set; }
        public string? Category { get; set; }
        public string? Ayanansh { get; set; }
        public bool Rotate { get; set; }
        public bool CheckSahasaneLogic { get; set; }
        public bool CheckSalaChakkar { get; set; }
        public bool CheckMFal { get; set; }
        public bool CheckShowRef { get; set; }
        public string? KundaliUdvYear { get; set; }
        public string? TimeType { get; set; }
        public string? SkipBadType { get; set; }
    }
}
