using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeWeb.Shared.DTOs
{
    public class KundliVO
    {
        public long Sno { get; set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public DateTime Tob { get; set; }
        public DateTime Gochar_Date_1 { get; set; }
        public DateTime Gochar_Date_2 { get; set; }
        public string Placeofbirth { get; set; }
        public long Lagna { get; set; }
        public long Base_Lagna { get; set; }
        public long Nak { get; set; }
        public short Current_Age { get; set; }
        public long Charan { get; set; }
        public string Online_Result { get; set; }
        public string? Online_Result_Gochar { get; set; }
        public double Lon { get; set; }
        public double Lat { get; set; }
        public double TimeZone { get; set; }
        public string Janamsamay { get; set; }
        public string Janamdin { get; set; }
        public string Remarks { get; set; }
        public string Username { get; set; }
        public DateTime EntryTime { get; set; }
        public bool Paid { get; set; }
        public bool ShowRef { get; set; }
        public string? Sub_prodtype { get; set; }
        public bool Mfal { get; set; }
        public short Rotate { get; set; }
        public string Dasha35 { get; set; }
        public string Antar35 { get; set; }
        public string Dasha_Visho { get; set; }
        public string Antar_Visho { get; set; }
        public string Pryantar_Visho { get; set; }
        public string Ratna { get; set; }
        public string Upratna { get; set; }
        public string RatnaCode { get; set; }
        public string DD { get; set; }
        public string MM { get; set; }
        public string YY { get; set; }
        public string Wdd { get; set; }
        public string Wmm { get; set; }
        public string Wyy { get; set; }
        public string Hh { get; set; }
        public string Min { get; set; }
        public string Ss { get; set; }
        public bool Male { get; set; }
        public string Language { get; set; }
        public string Lucky_day1 { get; set; }
        public string Lucky_day2 { get; set; }
        public string Lucky_number { get; set; }
        public string Janam_lagna { get; set; }
        public string Janam_rashi { get; set; }
        public string Domain { get; set; }
        public string Vcn_prefix { get; set; }
        public string File_prefix { get; set; }
        public string Source { get; set; }
        public string Headertitle { get; set; }
        public string Product { get; set; }
        public long Orderno { get; set; }
        public string? Lonstr { get; set; }
        public string? Latstr { get; set; }
        public string? Timezonestr { get; set; }
        public bool Manual { get; set; }
        public string Machine { get; set; }
        public string? Filecode { get; set; }
        public string? Upaycode { get; set; }
    }
}
