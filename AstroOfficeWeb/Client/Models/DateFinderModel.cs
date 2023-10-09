using AstroOfficeWeb.Client.Helper;

namespace AstroOfficeWeb.Client.Models
{
    public class DateFinderModel
    {
        public string Occassion { get; set; } = "Child Birth - 2,5,11 - 18~55";
        public bool Sahasane { get; set; }
        public bool FullMatch { get; set; }
        public Period Period { get; set; }
        public Dasha Dasha { get; set; }
        public string DateList { get; set; } = "";
        public List<String> OccassionList { get; set; } = new List<string>
        {
            "Child Birth - 2,5,11 - 18~55",
            "Marriage - 2,7,11 - 18~55",
            "Business - 2,7,10,11 - 21~80",
            "Profession - 2,10,11 - 21~80",
            "Job - 2,6,10,11 - 21~80",
            "Worst Days - 2,6,8,12 - 1~70",
            "Finance Worst Days - 5,8,12 - 21~80",
            "Loss - 8,1,12 - 21~80",
            "Health Worst Days - 2,7,6,8,12 - 1~70",
            "Cash Worst Days - 5,8,9,12 - 16~80",
            "Education Worst Days - 3,5,8,12 - 11~35",
            "Child Worst Days - 1,4,6,8,12 - 18~80",
            "Married Worst Days - 1,6,8,10,12 - 18~60",
            "Confirm Divorce Days - 1,3,6,8,10 - 21~80",
            "Job Worst Days - 1,5,8,9,12 - 21~80",
            "Biz Worst Days - 1,6,8,9,12 - 21~80",
            "Jail/Hosp Worst Days - 1,3,6,8,12 - 21~80"
        };
    }
}
