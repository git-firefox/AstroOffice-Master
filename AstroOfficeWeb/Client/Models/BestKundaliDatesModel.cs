using AstroOfficeWeb.Client.Helper;

namespace AstroOfficeWeb.Client.Models
{
    public class BestKundaliDatesModel
    {

        public DateTime Pick_start_date { get; set; } = DateTime.Now.Date;
        public DateTime StartingTime { get; set; }
        public DateTime Pick_end_date { get; set; } = DateTime.Now.Date.AddDays(1);
        public DateTime EndingTime { get; set; }
        public string? Comborating { get; set; } = "Good";

        public string? BestDate { get; set; }
        public KundaliDatesRadio KundaliDatesRadio { get; set; }

        public string countProcess { get; set; } = string.Empty;

        public List<string> ComboratingSelect { get; set; } = new List<string>
        {
            "Good",
            "Best",
            "Excellent"
        };
    }
}
