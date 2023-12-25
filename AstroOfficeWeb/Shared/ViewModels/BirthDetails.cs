using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroOfficeWeb.Shared.Utilities;


namespace AstroOfficeWeb.Shared.ViewModels
{
    public class BirthDetails
    {
        public string CmbCountry { get; set; } = "Ind.";
        public string TxtName { get; set; } = "SHIVA";
        public string? CmbSkipBad { get; set; }
        public string? CmbTime { get; set; }
        public int TimeValue { get; set; } = 2;
        public int Dobdd { get; set; } = 12;
        public int Dobmm { get; set; } = 06;
        public int Dobyy { get; set; } = 2006;
        public int Tobhh { get; set; } = 13;
        public int Tobmm { get; set; } = 25;
        public int Tobss { get; set; } = 00;

        public DateTime DateOfBirth { get; set; }

        public string TxtBirthPlace { get; set; } = "Delhi";
        public string? BirthPlace { get; set; } = "Delhi";
        public string BirthCity { get; set; } = string.Empty;
        public bool IsMale { get; set; }
        public bool IsFemale { get; set; }
        public string CmbCategory { get; set; } = "Kamkaj";
        public string CmbAyanansh { get; set; } = "KP";
        public string Brief { get; set; } = string.Empty;
        public short CmbRotate { get; set; } = 1;
        public bool ChkSahasaneLogic { get; set; }
        public bool SalaChakkar { get; set; } = true;
        public bool ChkMfal { get; set; } = false;
        public string Longtitude { get; set; } = string.Empty;
        public string Latitude { get; set; } = string.Empty;
        public string CmbLanguage { get; set; } = "Hindi";
        public string TxtTimezone { get; set; } = string.Empty;
        public bool ChkShowRef { get; set; }
        public Gender Gender { get; set; }
        public int KundaliUdvYear { get; set; }
        public long? PlaceOfBirthID { get; set; }

        public BirthDetails()
        {
            DateOfBirth = new DateTime(Dobyy, Dobmm, Dobdd, Tobhh, Tobmm, Tobss);
        }
    }
}
