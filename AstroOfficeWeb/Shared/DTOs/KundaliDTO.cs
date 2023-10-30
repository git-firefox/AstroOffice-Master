using AstroOfficeWeb.Shared.Models;

namespace AstroOfficeWeb.Shared.DTOs
{
    public class KundaliDTO
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? ProductName { get; set; }
        public string? Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime ViewDate { get; set; }
        public TimeSpan TimeOfBirth { get; set; }
        public long? PlaceOfBirthID { get; set; }
        public string? PlaceOfBirth { get; set; }
        public string? Language { get; set; }
        public bool IsPaid { get; set; }
        public bool IsSaved { get; set; }
        public string? CountryCode { get; set; }
        public string? Category { get; set; }
        public string? Ayanansh { get; set; }
        public short Rotate { get; set; }
        public bool CheckSahasaneLogic { get; set; }
        public bool CheckSalaChakkar { get; set; }
        public bool CheckMFal { get; set; }
        public bool CheckShowRef { get; set; }
        public int KundaliUdvYear { get; set; }
        public string? TimeType { get; set; }
        public string? SkipBadType { get; set; }
    }
}
