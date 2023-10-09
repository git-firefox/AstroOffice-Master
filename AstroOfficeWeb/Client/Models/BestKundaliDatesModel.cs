using AstroOfficeWeb.Client.Helper;

namespace AstroOfficeWeb.Client.Models
{
    public class BestKundaliDatesModel
    {

        public DateTime? Pick_start_date { get; set; } = DateTime.Now.Date;
        public string? StartingTime { get; set; } = DateTime.Now.ToString("HH:mm");
        public DateTime? Pick_end_date { get; set; } = DateTime.Now.Date.AddDays(1);
        public string? EndingTime { get; set; }
        public string? Comborating { get; set; } = "Good";

        public string? BestDate { get; set; }
        public KundaliDatesRadio KundaliDatesRadio { get; set; }

        public List<string> ComboratingSelect { get; set; } = new List<string>
        {
            "Good",
            "Best",
            "Excellent"
        };
    }
}
