namespace AstroShared.ViewModels
{
    public class PersonKundaliTableTRModel
    {
        public int SrNo { get; set; }
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? ProductName { get; set; }
        public string? Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public TimeSpan TimeOfBirth { get; set; }
        public int PlaceOfBirthID { get; set; }
        public string? PlaceOfBirth { get; set; }
        public string? Language { get; set; }
        public bool IsPaid { get; set; }
        public bool IsSaved { get; set; }
        public DateTime? ViewDate { get; set; }
        public string? A_User_SNO { get; set; }
    }
}
