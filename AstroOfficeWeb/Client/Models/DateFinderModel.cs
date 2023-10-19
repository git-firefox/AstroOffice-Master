using AstroOfficeWeb.Client.Helper;
using AstroOfficeWeb.Shared.Models;

namespace AstroOfficeWeb.Client.Models
{
    public class DateFinderModel
    {
        public string Occassion { get; set; } = "Child Birth - 2,5,11 - 18~55";
        public bool Sahasane { get; set; }
        public bool FullMatch { get; set; }
        public Period Period { get; set; } = Period.Pryan;
        public Dasha Dasha { get; set; }
        public string DateList { get; set; } = "";
        public IList<SelectListItem> OccassionList { get; set; } = new List<SelectListItem>
        {
            new SelectListItem("Child Birth - 2,5,11 - 18~55", "0"),
            new SelectListItem("Marriage - 2,7,11 - 18~55", "1"),
            new SelectListItem("Business - 2,7,10,11 - 21~80", "2"),
            new SelectListItem("Profession - 2,10,11 - 21~80", "3"),
            new SelectListItem("Job - 2,6,10,11 - 21~80", "4"),
            new SelectListItem("Worst Days - 2,6,8,12 - 1~70", "5"),
            new SelectListItem("Finance Worst Days - 5,8,12 - 21~80", "6"),
            new SelectListItem("Loss - 8,1,12 - 21~80", "7"),
            new SelectListItem("Health Worst Days - 2,7,6,8,12 - 1~70", "8"),
            new SelectListItem("Cash Worst Days - 5,8,9,12 - 16~80", "9"),
            new SelectListItem("Education Worst Days - 3,5,8,12 - 11~35", "10"),
            new SelectListItem("Child Worst Days - 1,4,6,8,12 - 18~80", "11"),
            new SelectListItem("Married Worst Days - 1,6,8,10,12 - 18~60", "12"),
            new SelectListItem("Confirm Divorce Days - 1,3,6,8,10 - 21~80", "13"),
            new SelectListItem("Job Worst Days - 1,5,8,9,12 - 21~80", "14"),
            new SelectListItem("Biz Worst Days - 1,6,8,9,12 - 21~80", "15"),
            new SelectListItem("Jail/Hosp Worst Days - 1,3,6,8,12 - 21~80", "16")
        };
    }
}
