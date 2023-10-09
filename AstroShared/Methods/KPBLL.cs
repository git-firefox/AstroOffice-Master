using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroShared.Models;

namespace AstroShared.Methods
{
    public class KPBLL
    {
        public static List<KPPlanetsVO> planet_list;

        public static List<KPHousesVO> house_list;

        public static List<KPNAKVO> nak_list;

        public static List<KPRashiVO> rashi_list;

        public static List<KP249VO> kp249;

        public static List<KPRemediesVO> Remedy_List_VFAL;

        public static List<KPRemediesVO> Remedy_List_IA;

        public static List<KPRemediesVO> Remedy_List_General;

        public static List<KPRemediesVO> Remedy_List_Bupay;

        public static List<KPRemediesVO> Remedy_List_Logical;

        public static List<KPGoodBadVO> Good_Bad;

        public List<KPHousesVO> Fill_Houses()
        {
            List<KPHousesVO> kPHousesVOs = new List<KPHousesVO>();
            KPHousesVO kPHousesVO = new KPHousesVO()
            {
                House = 1,
                Swami = 3
            };
            kPHousesVOs.Add(kPHousesVO);
            kPHousesVO = new KPHousesVO()
            {
                House = 2,
                Swami = 6
            };
            kPHousesVOs.Add(kPHousesVO);
            kPHousesVO = new KPHousesVO()
            {
                House = 3,
                Swami = 4
            };
            kPHousesVOs.Add(kPHousesVO);
            kPHousesVO = new KPHousesVO()
            {
                House = 4,
                Swami = 2
            };
            kPHousesVOs.Add(kPHousesVO);
            kPHousesVO = new KPHousesVO()
            {
                House = 5,
                Swami = 1
            };
            kPHousesVOs.Add(kPHousesVO);
            kPHousesVO = new KPHousesVO()
            {
                House = 6,
                Swami = 4
            };
            kPHousesVOs.Add(kPHousesVO);
            kPHousesVO = new KPHousesVO()
            {
                House = 7,
                Swami = 6
            };
            kPHousesVOs.Add(kPHousesVO);
            kPHousesVO = new KPHousesVO()
            {
                House = 8,
                Swami = 3
            };
            kPHousesVOs.Add(kPHousesVO);
            kPHousesVO = new KPHousesVO()
            {
                House = 9,
                Swami = 5
            };
            kPHousesVOs.Add(kPHousesVO);
            kPHousesVO = new KPHousesVO()
            {
                House = 10,
                Swami = 7
            };
            kPHousesVOs.Add(kPHousesVO);
            kPHousesVO = new KPHousesVO()
            {
                House = 11,
                Swami = 7
            };
            kPHousesVOs.Add(kPHousesVO);
            kPHousesVO = new KPHousesVO()
            {
                House = 12,
                Swami = 5
            };
            kPHousesVOs.Add(kPHousesVO);
            return kPHousesVOs;
        }
        
        public List<KPPlanetsVO> Fill_Planets()
        {
            List<KPPlanetsVO> kPPlanetsVOs = new List<KPPlanetsVO>();
            KPPlanetsVO kPPlanetsVO = new KPPlanetsVO()
            {
                Planet = 1,
                English = "Sun",
                Roman = "Surya",
                Hindi = "सूर्य",
                Marathi = "सूर्य",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Drishti = "7",
                Day = "Sunday",
                Ratna = "माणिक्य",
                Upratna = "लाल हकीक",
                RatnaCode = "ruby",
                Pakke_Ghar = "1",
                Shreshth = "1,2,3,4,5,8,9,11,12",
                Mande_Ghar = "6,7,10",
                Shatru = "6,7,8",
                Mitra = "2,3,5",
                Sam = "4",
                Uch_Rashi = "1",
                Neech_Rashi = "7",
                Lal_Pakke_Ghar = "1"
            };
            kPPlanetsVOs.Add(kPPlanetsVO);
            kPPlanetsVO = new KPPlanetsVO()
            {
                Planet = 2,
                English = "Moon",
                Hindi = "चंद्र",
                Roman = "Chandra",
                Marathi = "चंद्र",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Drishti = "7",
                Day = "Monday",
                Ratna = "मोती",
                Upratna = "चंद्रकांता मणि, सफ़ेद हकीक",
                RatnaCode = "pearl",
                Pakke_Ghar = "4",
                Shreshth = "1,2,3,4,5,7,9",
                Mande_Ghar = "6,8,10,11,12",
                Shatru = "8,9",
                Mitra = "1,4",
                Sam = "3,5,6,7",
                Uch_Rashi = "2",
                Neech_Rashi = "8",
                Lal_Pakke_Ghar = "4"
            };
            kPPlanetsVOs.Add(kPPlanetsVO);
            kPPlanetsVO = new KPPlanetsVO()
            {
                Planet = 3,
                English = "Mars",
                Hindi = "मंगल",
                Roman = "Mangal",
                Marathi = "मंगळ",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Drishti = "7,4,8",
                Day = "Tuesday",
                Ratna = "मूंगा",
                Upratna = "लाल हकीक, लाल ओनिक्स",
                RatnaCode = "redcoral",
                Pakke_Ghar = "3",
                Shreshth = "1,2,3,5,6,7,9,10,11,12",
                Mande_Ghar = "4,8",
                Shatru = "4,9",
                Mitra = "1,2,5",
                Sam = "6,7",
                Uch_Rashi = "10",
                Neech_Rashi = "4",
                Lal_Pakke_Ghar = "1,8,3"
            };
            kPPlanetsVOs.Add(kPPlanetsVO);
            kPPlanetsVO = new KPPlanetsVO()
            {
                Planet = 4,
                English = "Mercury",
                Hindi = "बुध",
                Roman = "Budh",
                Marathi = "बुध",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Drishti = "7",
                Day = "Wednesday",
                Ratna = "पन्ना",
                Upratna = "हरा हकीक, ओनिक्स",
                RatnaCode = "emerald",
                Pakke_Ghar = "7",
                Shreshth = "1,2,4,5,6,7",
                Mande_Ghar = "3,8,9,10,11,12",
                Shatru = "2",
                Mitra = "1,6,8",
                Sam = "3,5,7,9",
                Uch_Rashi = "6",
                Neech_Rashi = "12",
                Lal_Pakke_Ghar = "6,7"
            };
            kPPlanetsVOs.Add(kPPlanetsVO);
            kPPlanetsVO = new KPPlanetsVO()
            {
                Planet = 5,
                English = "Jupiter",
                Hindi = "गुरू",
                Roman = "Guru",
                Marathi = "गुरू",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Drishti = "7,5,9",
                Day = "Thursday",
                Ratna = "पुखराज",
                Upratna = "सुनहला, पीला हकीक",
                RatnaCode = "yellowsaphire",
                Pakke_Ghar = "9",
                Shreshth = "1,2,3,4,5,8,9,12",
                Mande_Ghar = "6,7,10",
                Shatru = "4,6",
                Mitra = "1,2,3",
                Sam = "7,8,9",
                Uch_Rashi = "4",
                Neech_Rashi = "10",
                Lal_Pakke_Ghar = "2,5,9,11"
            };
            kPPlanetsVOs.Add(kPPlanetsVO);
            kPPlanetsVO = new KPPlanetsVO()
            {
                Planet = 6,
                English = "Venus",
                Hindi = "शुक्र",
                Roman = "Shukra",
                Marathi = "शुक्र",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Drishti = "7",
                Day = "Friday",
                Ratna = "हीरा",
                Upratna = "ओपल, जिरकॉन, अमेरिकन डायमंड",
                RatnaCode = "diamond",
                Pakke_Ghar = "7",
                Shreshth = "2,3,4,7,12",
                Mande_Ghar = "6,1,9",
                Shatru = "1,2,8",
                Mitra = "4,7,9",
                Sam = "0",
                Uch_Rashi = "12",
                Neech_Rashi = "6",
                Lal_Pakke_Ghar = "7"
            };
            kPPlanetsVOs.Add(kPPlanetsVO);
            kPPlanetsVO = new KPPlanetsVO()
            {
                Planet = 7,
                English = "Saturn",
                Hindi = "शनि",
                Roman = "Shani",
                Marathi = "शनि",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Drishti = "7,3,10",
                Day = "Saturday",
                Ratna = "नीलम",
                Upratna = "कटहला, काला गोमेद",
                RatnaCode = "bluesaphire",
                Pakke_Ghar = "10",
                Shreshth = "2,3,7,8,9,10,11,12",
                Mande_Ghar = "1,4,5,6",
                Shatru = "1,2,3",
                Mitra = "4,6,8",
                Sam = "5,9",
                Uch_Rashi = "7",
                Neech_Rashi = "1",
                Lal_Pakke_Ghar = "8,10"
            };
            kPPlanetsVOs.Add(kPPlanetsVO);
            kPPlanetsVO = new KPPlanetsVO()
            {
                Planet = 8,
                English = "Rahu",
                Hindi = "राहु",
                Roman = "Rahu",
                Marathi = "राहु",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Drishti = "",
                Day = "",
                Ratna = "गोमेद",
                Upratna = "गोमेद",
                RatnaCode = "hessonite",
                Pakke_Ghar = "12",
                Shreshth = "3,4,6",
                Mande_Ghar = "1,2,5,7,8,9,10,11,12",
                Shatru = "1,6,3",
                Mitra = "4,7,9",
                Sam = "5,2",
                Uch_Rashi = "3,6",
                Neech_Rashi = "8,9,11",
                Lal_Pakke_Ghar = "12"
            };
            kPPlanetsVOs.Add(kPPlanetsVO);
            kPPlanetsVO = new KPPlanetsVO()
            {
                Planet = 9,
                English = "Ketu",
                Hindi = "केतु",
                Roman = "Ketu",
                Marathi = "केतु",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Drishti = "",
                Day = "",
                Ratna = "लहसुनिया",
                Upratna = "लहसुनिया",
                RatnaCode = "catseye",
                Pakke_Ghar = "6",
                Shreshth = "3,9,10,12",
                Mande_Ghar = "6,7,11",
                Shatru = "2,3",
                Mitra = "6,8",
                Sam = "1,4,5,7",
                Uch_Rashi = "5,9,12",
                Neech_Rashi = "6,8",
                Lal_Pakke_Ghar = "6"
            };
            kPPlanetsVOs.Add(kPPlanetsVO);
            kPPlanetsVO = new KPPlanetsVO()
            {
                Planet = 10,
                English = "Harshal",
                Roman = "Harshal",
                Hindi = "हर्षल",
                Marathi = "हर्षल",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Drishti = "",
                Day = ""
            };
            kPPlanetsVOs.Add(kPPlanetsVO);
            kPPlanetsVO = new KPPlanetsVO()
            {
                Planet = 11,
                English = "Neptune",
                Roman = "Neptune",
                Hindi = "नेपच्यून",
                Marathi = "नेपच्यून",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Drishti = "",
                Day = ""
            };
            kPPlanetsVOs.Add(kPPlanetsVO);
            kPPlanetsVO = new KPPlanetsVO()
            {
                Planet = 12,
                English = "Pluto",
                Hindi = "प्लुटो",
                Roman = "Pluto",
                Marathi = "प्लुटो",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Drishti = "",
                Day = ""
            };
            kPPlanetsVOs.Add(kPPlanetsVO);
            return kPPlanetsVOs;
        }
        
        public List<KPNAKVO> Fill_Nak()
        {
            List<KPNAKVO> kPNAKVOs = new List<KPNAKVO>();
            KundliBLL kundliBLL = new KundliBLL();
            KPNAKVO kPNAKVO = new KPNAKVO()
            {
                NakNumber = 1,
                Hindi = "अश्विनि",
                English = "Ashvani",
                Marathi = "अश्विनि",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Swami = 9
            };
            KPDashaRashiVO kPDashaRashiVO = new KPDashaRashiVO()
            {
                Rashi = 1,
                DM = "00:00-13:20"
            };
            string dM = kPDashaRashiVO.DM;
            char[] chrArray = new char[] { '-' };
            string str = dM.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            double num = Convert.ToDouble(str.Split(chrArray)[0]);
            string dM1 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str1 = dM1.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_From = kundliBLL.DMStoDecimal(num, Convert.ToDouble(str1.Split(chrArray)[1]), 0);
            string dM2 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str2 = dM2.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            double num1 = Convert.ToDouble(str2.Split(chrArray)[0]);
            string dM3 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str3 = dM3.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_To = kundliBLL.DMStoDecimal(num1, Convert.ToDouble(str3.Split(chrArray)[1]), 0);
            kPNAKVO.DashaRashi.Add(kPDashaRashiVO);
            kPNAKVOs.Add(kPNAKVO);
            kPNAKVO = new KPNAKVO()
            {
                NakNumber = 2,
                Hindi = "भरणी",
                English = "Bharani",
                Marathi = "भरणी",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Swami = 6
            };
            kPDashaRashiVO = new KPDashaRashiVO()
            {
                Rashi = 1,
                DM = "13:20-26:40"
            };
            string dM4 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str4 = dM4.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            double num2 = Convert.ToDouble(str4.Split(chrArray)[0]);
            string dM5 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str5 = dM5.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_From = kundliBLL.DMStoDecimal(num2, Convert.ToDouble(str5.Split(chrArray)[1]), 0);
            string dM6 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str6 = dM6.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            double num3 = Convert.ToDouble(str6.Split(chrArray)[0]);
            string dM7 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str7 = dM7.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_To = kundliBLL.DMStoDecimal(num3, Convert.ToDouble(str7.Split(chrArray)[1]), 0);
            kPNAKVO.DashaRashi.Add(kPDashaRashiVO);
            kPNAKVOs.Add(kPNAKVO);
            kPNAKVO = new KPNAKVO()
            {
                NakNumber = 3,
                Hindi = "कृत्तिका",
                English = "Kritika",
                Marathi = "कृत्तिका",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Swami = 1
            };
            kPDashaRashiVO = new KPDashaRashiVO()
            {
                Rashi = 1,
                DM = "26:40-30:00"
            };
            string dM8 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str8 = dM8.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            double num4 = Convert.ToDouble(str8.Split(chrArray)[0]);
            string dM9 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str9 = dM9.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_From = kundliBLL.DMStoDecimal(num4, Convert.ToDouble(str9.Split(chrArray)[1]), 0);
            string dM10 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str10 = dM10.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            double num5 = Convert.ToDouble(str10.Split(chrArray)[0]);
            string dM11 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str11 = dM11.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_To = kundliBLL.DMStoDecimal(num5, Convert.ToDouble(str11.Split(chrArray)[1]), 0);
            kPNAKVO.DashaRashi.Add(kPDashaRashiVO);
            kPDashaRashiVO = new KPDashaRashiVO()
            {
                Rashi = 2,
                DM = "00:00-10:00"
            };
            string dM12 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str12 = dM12.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            double num6 = Convert.ToDouble(str12.Split(chrArray)[0]);
            string dM13 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str13 = dM13.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_From = kundliBLL.DMStoDecimal(num6, Convert.ToDouble(str13.Split(chrArray)[1]), 0);
            string dM14 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str14 = dM14.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            double num7 = Convert.ToDouble(str14.Split(chrArray)[0]);
            string dM15 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str15 = dM15.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_To = kundliBLL.DMStoDecimal(num7, Convert.ToDouble(str15.Split(chrArray)[1]), 0);
            kPNAKVO.DashaRashi.Add(kPDashaRashiVO);
            kPNAKVOs.Add(kPNAKVO);
            kPNAKVO = new KPNAKVO()
            {
                NakNumber = 4,
                Hindi = "रोहिणी",
                English = "Rohini",
                Marathi = "रोहिणी",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Swami = 2
            };
            kPDashaRashiVO = new KPDashaRashiVO()
            {
                Rashi = 2,
                DM = "10:00-23:20"
            };
            string dM16 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str16 = dM16.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            double num8 = Convert.ToDouble(str16.Split(chrArray)[0]);
            string dM17 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str17 = dM17.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_From = kundliBLL.DMStoDecimal(num8, Convert.ToDouble(str17.Split(chrArray)[1]), 0);
            string dM18 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str18 = dM18.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            double num9 = Convert.ToDouble(str18.Split(chrArray)[0]);
            string dM19 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str19 = dM19.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_To = kundliBLL.DMStoDecimal(num9, Convert.ToDouble(str19.Split(chrArray)[1]), 0);
            kPNAKVO.DashaRashi.Add(kPDashaRashiVO);
            kPNAKVOs.Add(kPNAKVO);
            kPNAKVO = new KPNAKVO()
            {
                NakNumber = 5,
                Hindi = "म्रृगशीर्षा",
                English = "Mrigshira",
                Marathi = "म्रृगशीर्षा",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Swami = 3
            };
            kPDashaRashiVO = new KPDashaRashiVO()
            {
                Rashi = 2,
                DM = "23:20-30:00"
            };
            string dM20 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str20 = dM20.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            double num10 = Convert.ToDouble(str20.Split(chrArray)[0]);
            string dM21 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str21 = dM21.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_From = kundliBLL.DMStoDecimal(num10, Convert.ToDouble(str21.Split(chrArray)[1]), 0);
            string dM22 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str22 = dM22.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            double num11 = Convert.ToDouble(str22.Split(chrArray)[0]);
            string dM23 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str23 = dM23.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_To = kundliBLL.DMStoDecimal(num11, Convert.ToDouble(str23.Split(chrArray)[1]), 0);
            kPNAKVO.DashaRashi.Add(kPDashaRashiVO);
            kPDashaRashiVO = new KPDashaRashiVO()
            {
                Rashi = 3,
                DM = "00:00-06:40"
            };
            string dM24 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str24 = dM24.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            double num12 = Convert.ToDouble(str24.Split(chrArray)[0]);
            string dM25 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str25 = dM25.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_From = kundliBLL.DMStoDecimal(num12, Convert.ToDouble(str25.Split(chrArray)[1]), 0);
            string dM26 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str26 = dM26.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            double num13 = Convert.ToDouble(str26.Split(chrArray)[0]);
            string dM27 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str27 = dM27.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_To = kundliBLL.DMStoDecimal(num13, Convert.ToDouble(str27.Split(chrArray)[1]), 0);
            kPNAKVO.DashaRashi.Add(kPDashaRashiVO);
            kPNAKVOs.Add(kPNAKVO);
            kPNAKVO = new KPNAKVO()
            {
                NakNumber = 6,
                Hindi = "आर्द्रा",
                English = "Adra",
                Marathi = "आर्द्रा",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Swami = 8
            };
            kPDashaRashiVO = new KPDashaRashiVO()
            {
                Rashi = 3,
                DM = "06:40-20:00"
            };
            string dM28 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str28 = dM28.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            double num14 = Convert.ToDouble(str28.Split(chrArray)[0]);
            string dM29 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str29 = dM29.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_From = kundliBLL.DMStoDecimal(num14, Convert.ToDouble(str29.Split(chrArray)[1]), 0);
            string dM30 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str30 = dM30.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            double num15 = Convert.ToDouble(str30.Split(chrArray)[0]);
            string dM31 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str31 = dM31.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_To = kundliBLL.DMStoDecimal(num15, Convert.ToDouble(str31.Split(chrArray)[1]), 0);
            kPNAKVO.DashaRashi.Add(kPDashaRashiVO);
            kPNAKVOs.Add(kPNAKVO);
            kPNAKVO = new KPNAKVO()
            {
                NakNumber = 7,
                Hindi = "पुनर्वसु",
                English = "Punarvasu",
                Marathi = "पुनर्वसु",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Swami = 5
            };
            kPDashaRashiVO = new KPDashaRashiVO()
            {
                Rashi = 3,
                DM = "20:00-30:00"
            };
            string dM32 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str32 = dM32.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            double num16 = Convert.ToDouble(str32.Split(chrArray)[0]);
            string dM33 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str33 = dM33.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_From = kundliBLL.DMStoDecimal(num16, Convert.ToDouble(str33.Split(chrArray)[1]), 0);
            string dM34 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str34 = dM34.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            double num17 = Convert.ToDouble(str34.Split(chrArray)[0]);
            string dM35 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str35 = dM35.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_To = kundliBLL.DMStoDecimal(num17, Convert.ToDouble(str35.Split(chrArray)[1]), 0);
            kPNAKVO.DashaRashi.Add(kPDashaRashiVO);
            kPDashaRashiVO = new KPDashaRashiVO()
            {
                Rashi = 4,
                DM = "00:00-03:20"
            };
            string dM36 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str36 = dM36.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            double num18 = Convert.ToDouble(str36.Split(chrArray)[0]);
            string dM37 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str37 = dM37.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_From = kundliBLL.DMStoDecimal(num18, Convert.ToDouble(str37.Split(chrArray)[1]), 0);
            string dM38 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str38 = dM38.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            double num19 = Convert.ToDouble(str38.Split(chrArray)[0]);
            string dM39 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str39 = dM39.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_To = kundliBLL.DMStoDecimal(num19, Convert.ToDouble(str39.Split(chrArray)[1]), 0);
            kPNAKVO.DashaRashi.Add(kPDashaRashiVO);
            kPNAKVOs.Add(kPNAKVO);
            kPNAKVO = new KPNAKVO()
            {
                NakNumber = 8,
                Hindi = "पुष्य",
                English = "Pushya",
                Marathi = "पुष्य",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Swami = 7
            };
            kPDashaRashiVO = new KPDashaRashiVO()
            {
                Rashi = 4,
                DM = "03:20-16:40"
            };
            string dM40 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str40 = dM40.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            double num20 = Convert.ToDouble(str40.Split(chrArray)[0]);
            string dM41 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str41 = dM41.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_From = kundliBLL.DMStoDecimal(num20, Convert.ToDouble(str41.Split(chrArray)[1]), 0);
            string dM42 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str42 = dM42.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            double num21 = Convert.ToDouble(str42.Split(chrArray)[0]);
            string dM43 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str43 = dM43.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_To = kundliBLL.DMStoDecimal(num21, Convert.ToDouble(str43.Split(chrArray)[1]), 0);
            kPNAKVO.DashaRashi.Add(kPDashaRashiVO);
            kPNAKVOs.Add(kPNAKVO);
            kPNAKVO = new KPNAKVO()
            {
                NakNumber = 9,
                Hindi = "आश्लेषा",
                English = "Ashlesha",
                Marathi = "आश्लेषा",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Swami = 4
            };
            kPDashaRashiVO = new KPDashaRashiVO()
            {
                Rashi = 4,
                DM = "16:40-30:00"
            };
            string dM44 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str44 = dM44.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            double num22 = Convert.ToDouble(str44.Split(chrArray)[0]);
            string dM45 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str45 = dM45.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_From = kundliBLL.DMStoDecimal(num22, Convert.ToDouble(str45.Split(chrArray)[1]), 0);
            string dM46 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str46 = dM46.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            double num23 = Convert.ToDouble(str46.Split(chrArray)[0]);
            string dM47 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str47 = dM47.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_To = kundliBLL.DMStoDecimal(num23, Convert.ToDouble(str47.Split(chrArray)[1]), 0);
            kPNAKVO.DashaRashi.Add(kPDashaRashiVO);
            kPNAKVOs.Add(kPNAKVO);
            kPNAKVO = new KPNAKVO()
            {
                NakNumber = 10,
                Hindi = "मघा",
                English = "Magha",
                Marathi = "मघा",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Swami = 9
            };
            kPDashaRashiVO = new KPDashaRashiVO()
            {
                Rashi = 5,
                DM = "00:00-13:20"
            };
            string dM48 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str48 = dM48.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            double num24 = Convert.ToDouble(str48.Split(chrArray)[0]);
            string dM49 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str49 = dM49.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_From = kundliBLL.DMStoDecimal(num24, Convert.ToDouble(str49.Split(chrArray)[1]), 0);
            string dM50 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str50 = dM50.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            double num25 = Convert.ToDouble(str50.Split(chrArray)[0]);
            string dM51 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str51 = dM51.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_To = kundliBLL.DMStoDecimal(num25, Convert.ToDouble(str51.Split(chrArray)[1]), 0);
            kPNAKVO.DashaRashi.Add(kPDashaRashiVO);
            kPNAKVOs.Add(kPNAKVO);
            kPNAKVO = new KPNAKVO()
            {
                NakNumber = 11,
                Hindi = "पूर्व फाल्गुनी",
                English = "Purva Falguni",
                Marathi = "पूर्व फाल्गुनी",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Swami = 6
            };
            kPDashaRashiVO = new KPDashaRashiVO()
            {
                Rashi = 5,
                DM = "13:20-26:40"
            };
            string dM52 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str52 = dM52.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            double num26 = Convert.ToDouble(str52.Split(chrArray)[0]);
            string dM53 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str53 = dM53.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_From = kundliBLL.DMStoDecimal(num26, Convert.ToDouble(str53.Split(chrArray)[1]), 0);
            string dM54 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str54 = dM54.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            double num27 = Convert.ToDouble(str54.Split(chrArray)[0]);
            string dM55 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str55 = dM55.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_To = kundliBLL.DMStoDecimal(num27, Convert.ToDouble(str55.Split(chrArray)[1]), 0);
            kPNAKVO.DashaRashi.Add(kPDashaRashiVO);
            kPNAKVOs.Add(kPNAKVO);
            kPNAKVO = new KPNAKVO()
            {
                NakNumber = 12,
                Hindi = "उत्तर फाल्गुनी",
                English = "Uttra Falguni",
                Marathi = "उत्तर फाल्गुनी",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Swami = 1
            };
            kPDashaRashiVO = new KPDashaRashiVO()
            {
                Rashi = 5,
                DM = "26:40-30:00"
            };
            string dM56 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str56 = dM56.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            double num28 = Convert.ToDouble(str56.Split(chrArray)[0]);
            string dM57 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str57 = dM57.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_From = kundliBLL.DMStoDecimal(num28, Convert.ToDouble(str57.Split(chrArray)[1]), 0);
            string dM58 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str58 = dM58.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            double num29 = Convert.ToDouble(str58.Split(chrArray)[0]);
            string dM59 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str59 = dM59.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_To = kundliBLL.DMStoDecimal(num29, Convert.ToDouble(str59.Split(chrArray)[1]), 0);
            kPNAKVO.DashaRashi.Add(kPDashaRashiVO);
            kPDashaRashiVO = new KPDashaRashiVO()
            {
                Rashi = 6,
                DM = "00:00-10:00"
            };
            string dM60 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str60 = dM60.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            double num30 = Convert.ToDouble(str60.Split(chrArray)[0]);
            string dM61 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str61 = dM61.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_From = kundliBLL.DMStoDecimal(num30, Convert.ToDouble(str61.Split(chrArray)[1]), 0);
            string dM62 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str62 = dM62.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            double num31 = Convert.ToDouble(str62.Split(chrArray)[0]);
            string dM63 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str63 = dM63.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_To = kundliBLL.DMStoDecimal(num31, Convert.ToDouble(str63.Split(chrArray)[1]), 0);
            kPNAKVO.DashaRashi.Add(kPDashaRashiVO);
            kPNAKVOs.Add(kPNAKVO);
            kPNAKVO = new KPNAKVO()
            {
                NakNumber = 13,
                Hindi = "हस्त",
                English = "Hast",
                Marathi = "हस्त",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Swami = 2
            };
            kPDashaRashiVO = new KPDashaRashiVO()
            {
                Rashi = 6,
                DM = "10:00-23:20"
            };
            string dM64 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str64 = dM64.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            double num32 = Convert.ToDouble(str64.Split(chrArray)[0]);
            string dM65 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str65 = dM65.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_From = kundliBLL.DMStoDecimal(num32, Convert.ToDouble(str65.Split(chrArray)[1]), 0);
            string dM66 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str66 = dM66.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            double num33 = Convert.ToDouble(str66.Split(chrArray)[0]);
            string dM67 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str67 = dM67.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_To = kundliBLL.DMStoDecimal(num33, Convert.ToDouble(str67.Split(chrArray)[1]), 0);
            kPNAKVO.DashaRashi.Add(kPDashaRashiVO);
            kPNAKVOs.Add(kPNAKVO);
            kPNAKVO = new KPNAKVO()
            {
                NakNumber = 14,
                Hindi = "चित्रा",
                English = "Chitra",
                Marathi = "चित्रा",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Swami = 3
            };
            kPDashaRashiVO = new KPDashaRashiVO()
            {
                Rashi = 6,
                DM = "23:20-30:00"
            };
            string dM68 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str68 = dM68.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            double num34 = Convert.ToDouble(str68.Split(chrArray)[0]);
            string dM69 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str69 = dM69.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_From = kundliBLL.DMStoDecimal(num34, Convert.ToDouble(str69.Split(chrArray)[1]), 0);
            string dM70 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str70 = dM70.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            double num35 = Convert.ToDouble(str70.Split(chrArray)[0]);
            string dM71 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str71 = dM71.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_To = kundliBLL.DMStoDecimal(num35, Convert.ToDouble(str71.Split(chrArray)[1]), 0);
            kPNAKVO.DashaRashi.Add(kPDashaRashiVO);
            kPDashaRashiVO = new KPDashaRashiVO()
            {
                Rashi = 7,
                DM = "00:00-06:40"
            };
            string dM72 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str72 = dM72.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            double num36 = Convert.ToDouble(str72.Split(chrArray)[0]);
            string dM73 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str73 = dM73.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_From = kundliBLL.DMStoDecimal(num36, Convert.ToDouble(str73.Split(chrArray)[1]), 0);
            string dM74 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str74 = dM74.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            double num37 = Convert.ToDouble(str74.Split(chrArray)[0]);
            string dM75 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str75 = dM75.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_To = kundliBLL.DMStoDecimal(num37, Convert.ToDouble(str75.Split(chrArray)[1]), 0);
            kPNAKVO.DashaRashi.Add(kPDashaRashiVO);
            kPNAKVOs.Add(kPNAKVO);
            kPNAKVO = new KPNAKVO()
            {
                NakNumber = 15,
                Hindi = "स्वाति",
                English = "Swati",
                Marathi = "स्वाति",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Swami = 8
            };
            kPDashaRashiVO = new KPDashaRashiVO()
            {
                Rashi = 7,
                DM = "06:40-20:00"
            };
            string dM76 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str76 = dM76.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            double num38 = Convert.ToDouble(str76.Split(chrArray)[0]);
            string dM77 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str77 = dM77.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_From = kundliBLL.DMStoDecimal(num38, Convert.ToDouble(str77.Split(chrArray)[1]), 0);
            string dM78 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str78 = dM78.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            double num39 = Convert.ToDouble(str78.Split(chrArray)[0]);
            string dM79 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str79 = dM79.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_To = kundliBLL.DMStoDecimal(num39, Convert.ToDouble(str79.Split(chrArray)[1]), 0);
            kPNAKVO.DashaRashi.Add(kPDashaRashiVO);
            kPNAKVOs.Add(kPNAKVO);
            kPNAKVO = new KPNAKVO()
            {
                NakNumber = 16,
                Hindi = "विशाखा",
                English = "Vishakha",
                Marathi = "विशाखा",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Swami = 5
            };
            kPDashaRashiVO = new KPDashaRashiVO()
            {
                Rashi = 7,
                DM = "20:00-30:00"
            };
            string dM80 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str80 = dM80.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            double num40 = Convert.ToDouble(str80.Split(chrArray)[0]);
            string dM81 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str81 = dM81.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_From = kundliBLL.DMStoDecimal(num40, Convert.ToDouble(str81.Split(chrArray)[1]), 0);
            string dM82 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str82 = dM82.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            double num41 = Convert.ToDouble(str82.Split(chrArray)[0]);
            string dM83 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str83 = dM83.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_To = kundliBLL.DMStoDecimal(num41, Convert.ToDouble(str83.Split(chrArray)[1]), 0);
            kPNAKVO.DashaRashi.Add(kPDashaRashiVO);
            kPDashaRashiVO = new KPDashaRashiVO()
            {
                Rashi = 8,
                DM = "00:00-03:20"
            };
            string dM84 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str84 = dM84.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            double num42 = Convert.ToDouble(str84.Split(chrArray)[0]);
            string dM85 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str85 = dM85.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_From = kundliBLL.DMStoDecimal(num42, Convert.ToDouble(str85.Split(chrArray)[1]), 0);
            string dM86 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str86 = dM86.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            double num43 = Convert.ToDouble(str86.Split(chrArray)[0]);
            string dM87 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str87 = dM87.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_To = kundliBLL.DMStoDecimal(num43, Convert.ToDouble(str87.Split(chrArray)[1]), 0);
            kPNAKVO.DashaRashi.Add(kPDashaRashiVO);
            kPNAKVOs.Add(kPNAKVO);
            kPNAKVO = new KPNAKVO()
            {
                NakNumber = 17,
                Hindi = "अनुराधा",
                English = "Anuradha",
                Marathi = "अनुराधा",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Swami = 7
            };
            kPDashaRashiVO = new KPDashaRashiVO()
            {
                Rashi = 8,
                DM = "03:20-16:40"
            };
            string dM88 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str88 = dM88.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            double num44 = Convert.ToDouble(str88.Split(chrArray)[0]);
            string dM89 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str89 = dM89.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_From = kundliBLL.DMStoDecimal(num44, Convert.ToDouble(str89.Split(chrArray)[1]), 0);
            string dM90 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str90 = dM90.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            double num45 = Convert.ToDouble(str90.Split(chrArray)[0]);
            string dM91 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str91 = dM91.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_To = kundliBLL.DMStoDecimal(num45, Convert.ToDouble(str91.Split(chrArray)[1]), 0);
            kPNAKVO.DashaRashi.Add(kPDashaRashiVO);
            kPNAKVOs.Add(kPNAKVO);
            kPNAKVO = new KPNAKVO()
            {
                NakNumber = 18,
                Hindi = "ज्येष्ठा",
                English = "Jyeshtha",
                Marathi = "ज्येष्ठा",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Swami = 4
            };
            kPDashaRashiVO = new KPDashaRashiVO()
            {
                Rashi = 8,
                DM = "16:40-30:00"
            };
            string dM92 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str92 = dM92.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            double num46 = Convert.ToDouble(str92.Split(chrArray)[0]);
            string dM93 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str93 = dM93.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_From = kundliBLL.DMStoDecimal(num46, Convert.ToDouble(str93.Split(chrArray)[1]), 0);
            string dM94 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str94 = dM94.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            double num47 = Convert.ToDouble(str94.Split(chrArray)[0]);
            string dM95 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str95 = dM95.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_To = kundliBLL.DMStoDecimal(num47, Convert.ToDouble(str95.Split(chrArray)[1]), 0);
            kPNAKVO.DashaRashi.Add(kPDashaRashiVO);
            kPNAKVOs.Add(kPNAKVO);
            kPNAKVO = new KPNAKVO()
            {
                NakNumber = 19,
                Hindi = "मूल",
                English = "Mula",
                Swami = 9
            };
            kPDashaRashiVO = new KPDashaRashiVO()
            {
                Rashi = 9,
                DM = "00:00-13:20"
            };
            string dM96 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str96 = dM96.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            double num48 = Convert.ToDouble(str96.Split(chrArray)[0]);
            string dM97 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str97 = dM97.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_From = kundliBLL.DMStoDecimal(num48, Convert.ToDouble(str97.Split(chrArray)[1]), 0);
            string dM98 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str98 = dM98.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            double num49 = Convert.ToDouble(str98.Split(chrArray)[0]);
            string dM99 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str99 = dM99.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_To = kundliBLL.DMStoDecimal(num49, Convert.ToDouble(str99.Split(chrArray)[1]), 0);
            kPNAKVO.DashaRashi.Add(kPDashaRashiVO);
            kPNAKVOs.Add(kPNAKVO);
            kPNAKVO = new KPNAKVO()
            {
                NakNumber = 20,
                Hindi = "पूर्वाषाढ़ा",
                English = "Purva Shada",
                Marathi = "पूर्वाषाढ़ा",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Swami = 6
            };
            kPDashaRashiVO = new KPDashaRashiVO()
            {
                Rashi = 9,
                DM = "13:20-26:40"
            };
            string dM100 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str100 = dM100.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            double num50 = Convert.ToDouble(str100.Split(chrArray)[0]);
            string dM101 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str101 = dM101.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_From = kundliBLL.DMStoDecimal(num50, Convert.ToDouble(str101.Split(chrArray)[1]), 0);
            string dM102 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str102 = dM102.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            double num51 = Convert.ToDouble(str102.Split(chrArray)[0]);
            string dM103 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str103 = dM103.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_To = kundliBLL.DMStoDecimal(num51, Convert.ToDouble(str103.Split(chrArray)[1]), 0);
            kPNAKVO.DashaRashi.Add(kPDashaRashiVO);
            kPNAKVOs.Add(kPNAKVO);
            kPNAKVO = new KPNAKVO()
            {
                NakNumber = 21,
                Hindi = "उत्तराषाढ़ा",
                English = "Uttra Shada",
                Marathi = "उत्तराषाढ़ा",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Swami = 1
            };
            kPDashaRashiVO = new KPDashaRashiVO()
            {
                Rashi = 9,
                DM = "26:40-30:00"
            };
            string dM104 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str104 = dM104.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            double num52 = Convert.ToDouble(str104.Split(chrArray)[0]);
            string dM105 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str105 = dM105.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_From = kundliBLL.DMStoDecimal(num52, Convert.ToDouble(str105.Split(chrArray)[1]), 0);
            string dM106 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str106 = dM106.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            double num53 = Convert.ToDouble(str106.Split(chrArray)[0]);
            string dM107 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str107 = dM107.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_To = kundliBLL.DMStoDecimal(num53, Convert.ToDouble(str107.Split(chrArray)[1]), 0);
            kPNAKVO.DashaRashi.Add(kPDashaRashiVO);
            kPDashaRashiVO = new KPDashaRashiVO()
            {
                Rashi = 10,
                DM = "00:00-10:00"
            };
            string dM108 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str108 = dM108.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            double num54 = Convert.ToDouble(str108.Split(chrArray)[0]);
            string dM109 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str109 = dM109.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_From = kundliBLL.DMStoDecimal(num54, Convert.ToDouble(str109.Split(chrArray)[1]), 0);
            string dM110 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str110 = dM110.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            double num55 = Convert.ToDouble(str110.Split(chrArray)[0]);
            string dM111 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str111 = dM111.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_To = kundliBLL.DMStoDecimal(num55, Convert.ToDouble(str111.Split(chrArray)[1]), 0);
            kPNAKVO.DashaRashi.Add(kPDashaRashiVO);
            kPNAKVOs.Add(kPNAKVO);
            kPNAKVO = new KPNAKVO()
            {
                NakNumber = 22,
                Hindi = "श्रवण",
                English = "Shravan",
                Marathi = "श्रवण",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Swami = 2
            };
            kPDashaRashiVO = new KPDashaRashiVO()
            {
                Rashi = 10,
                DM = "10:00-23:20"
            };
            string dM112 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str112 = dM112.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            double num56 = Convert.ToDouble(str112.Split(chrArray)[0]);
            string dM113 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str113 = dM113.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_From = kundliBLL.DMStoDecimal(num56, Convert.ToDouble(str113.Split(chrArray)[1]), 0);
            string dM114 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str114 = dM114.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            double num57 = Convert.ToDouble(str114.Split(chrArray)[0]);
            string dM115 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str115 = dM115.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_To = kundliBLL.DMStoDecimal(num57, Convert.ToDouble(str115.Split(chrArray)[1]), 0);
            kPNAKVO.DashaRashi.Add(kPDashaRashiVO);
            kPNAKVOs.Add(kPNAKVO);
            kPNAKVO = new KPNAKVO()
            {
                NakNumber = 23,
                Hindi = "धनिष्ठा",
                English = "Dhanishtha",
                Marathi = "धनिष्ठा",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Swami = 3
            };
            kPDashaRashiVO = new KPDashaRashiVO()
            {
                Rashi = 10,
                DM = "23:20-30:00"
            };
            string dM116 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str116 = dM116.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            double num58 = Convert.ToDouble(str116.Split(chrArray)[0]);
            string dM117 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str117 = dM117.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_From = kundliBLL.DMStoDecimal(num58, Convert.ToDouble(str117.Split(chrArray)[1]), 0);
            string dM118 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str118 = dM118.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            double num59 = Convert.ToDouble(str118.Split(chrArray)[0]);
            string dM119 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str119 = dM119.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_To = kundliBLL.DMStoDecimal(num59, Convert.ToDouble(str119.Split(chrArray)[1]), 0);
            kPNAKVO.DashaRashi.Add(kPDashaRashiVO);
            kPDashaRashiVO = new KPDashaRashiVO()
            {
                Rashi = 11,
                DM = "00:00-06:40"
            };
            string dM120 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str120 = dM120.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            double num60 = Convert.ToDouble(str120.Split(chrArray)[0]);
            string dM121 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str121 = dM121.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_From = kundliBLL.DMStoDecimal(num60, Convert.ToDouble(str121.Split(chrArray)[1]), 0);
            string dM122 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str122 = dM122.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            double num61 = Convert.ToDouble(str122.Split(chrArray)[0]);
            string dM123 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str123 = dM123.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_To = kundliBLL.DMStoDecimal(num61, Convert.ToDouble(str123.Split(chrArray)[1]), 0);
            kPNAKVO.DashaRashi.Add(kPDashaRashiVO);
            kPNAKVOs.Add(kPNAKVO);
            kPNAKVO = new KPNAKVO()
            {
                NakNumber = 24,
                Hindi = "शतभिषा",
                English = "Shatbhisha",
                Marathi = "शतभिषा",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Swami = 8
            };
            kPDashaRashiVO = new KPDashaRashiVO()
            {
                Rashi = 11,
                DM = "06:40-20:00"
            };
            string dM124 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str124 = dM124.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            double num62 = Convert.ToDouble(str124.Split(chrArray)[0]);
            string dM125 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str125 = dM125.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_From = kundliBLL.DMStoDecimal(num62, Convert.ToDouble(str125.Split(chrArray)[1]), 0);
            string dM126 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str126 = dM126.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            double num63 = Convert.ToDouble(str126.Split(chrArray)[0]);
            string dM127 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str127 = dM127.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_To = kundliBLL.DMStoDecimal(num63, Convert.ToDouble(str127.Split(chrArray)[1]), 0);
            kPNAKVO.DashaRashi.Add(kPDashaRashiVO);
            kPNAKVOs.Add(kPNAKVO);
            kPNAKVO = new KPNAKVO()
            {
                NakNumber = 25,
                Hindi = "पूर्वभाद्रपद",
                English = "Purva Bhadrapada",
                Marathi = "पूर्वभाद्रपद",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Swami = 5
            };
            kPDashaRashiVO = new KPDashaRashiVO()
            {
                Rashi = 11,
                DM = "20:00-30:00"
            };
            string dM128 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str128 = dM128.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            double num64 = Convert.ToDouble(str128.Split(chrArray)[0]);
            string dM129 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str129 = dM129.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_From = kundliBLL.DMStoDecimal(num64, Convert.ToDouble(str129.Split(chrArray)[1]), 0);
            string dM130 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str130 = dM130.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            double num65 = Convert.ToDouble(str130.Split(chrArray)[0]);
            string dM131 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str131 = dM131.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_To = kundliBLL.DMStoDecimal(num65, Convert.ToDouble(str131.Split(chrArray)[1]), 0);
            kPNAKVO.DashaRashi.Add(kPDashaRashiVO);
            kPDashaRashiVO = new KPDashaRashiVO()
            {
                Rashi = 12,
                DM = "00:00-03:20"
            };
            string dM132 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str132 = dM132.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            double num66 = Convert.ToDouble(str132.Split(chrArray)[0]);
            string dM133 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str133 = dM133.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_From = kundliBLL.DMStoDecimal(num66, Convert.ToDouble(str133.Split(chrArray)[1]), 0);
            string dM134 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str134 = dM134.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            double num67 = Convert.ToDouble(str134.Split(chrArray)[0]);
            string dM135 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str135 = dM135.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_To = kundliBLL.DMStoDecimal(num67, Convert.ToDouble(str135.Split(chrArray)[1]), 0);
            kPNAKVO.DashaRashi.Add(kPDashaRashiVO);
            kPNAKVOs.Add(kPNAKVO);
            kPNAKVO = new KPNAKVO()
            {
                NakNumber = 26,
                Hindi = "उत्तरभाद्रपद",
                English = "Uttra Bhadrapada",
                Marathi = "उत्तरभाद्रपद",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Swami = 7
            };
            kPDashaRashiVO = new KPDashaRashiVO()
            {
                Rashi = 12,
                DM = "03:20-16:40"
            };
            string dM136 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str136 = dM136.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            double num68 = Convert.ToDouble(str136.Split(chrArray)[0]);
            string dM137 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str137 = dM137.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_From = kundliBLL.DMStoDecimal(num68, Convert.ToDouble(str137.Split(chrArray)[1]), 0);
            string dM138 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str138 = dM138.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            double num69 = Convert.ToDouble(str138.Split(chrArray)[0]);
            string dM139 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str139 = dM139.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_To = kundliBLL.DMStoDecimal(num69, Convert.ToDouble(str139.Split(chrArray)[1]), 0);
            kPNAKVO.DashaRashi.Add(kPDashaRashiVO);
            kPNAKVOs.Add(kPNAKVO);
            kPNAKVO = new KPNAKVO()
            {
                NakNumber = 27,
                Hindi = "रेवती",
                English = "Revati",
                Marathi = "रेवती",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Swami = 4
            };
            kPDashaRashiVO = new KPDashaRashiVO()
            {
                Rashi = 12,
                DM = "16:40-30:00"
            };
            string dM140 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str140 = dM140.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            double num70 = Convert.ToDouble(str140.Split(chrArray)[0]);
            string dM141 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str141 = dM141.Split(chrArray)[0];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_From = kundliBLL.DMStoDecimal(num70, Convert.ToDouble(str141.Split(chrArray)[1]), 0);
            string dM142 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str142 = dM142.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            double num71 = Convert.ToDouble(str142.Split(chrArray)[0]);
            string dM143 = kPDashaRashiVO.DM;
            chrArray = new char[] { '-' };
            string str143 = dM143.Split(chrArray)[1];
            chrArray = new char[] { ':' };
            kPDashaRashiVO.Decimal_To = kundliBLL.DMStoDecimal(num71, Convert.ToDouble(str143.Split(chrArray)[1]), 0);
            kPNAKVO.DashaRashi.Add(kPDashaRashiVO);
            kPNAKVOs.Add(kPNAKVO);
            return kPNAKVOs;
        }
        
        public List<KPRashiVO> Fill_Rashi()
        {
            List<KPRashiVO> kPRashiVOs = new List<KPRashiVO>();
            KPRashiVO kPRashiVO = new KPRashiVO()
            {
                Rashi = 1,
                Hindi = "मेष",
                English = "Aries",
                Marathi = "मेष",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Swami = 3,
                Ratna = "मूंगा",
                Upratna = "लाल हकीक, लाल ओनिक्स"
            };
            kPRashiVOs.Add(kPRashiVO);
            kPRashiVO = new KPRashiVO()
            {
                Rashi = 2,
                Hindi = "वृष",
                English = "Taurus",
                Marathi = "वृषभ",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Swami = 6,
                Ratna = "हीरा",
                Upratna = "ओपल, जिरकॉन, अमेरिकन डायमंड"
            };
            kPRashiVOs.Add(kPRashiVO);
            kPRashiVO = new KPRashiVO()
            {
                Rashi = 3,
                Hindi = "मिथुन",
                English = "Gemini",
                Marathi = "मिथुन",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Swami = 4,
                Ratna = "पन्ना",
                Upratna = "हरा हकीक , ओनिक्स"
            };
            kPRashiVOs.Add(kPRashiVO);
            kPRashiVO = new KPRashiVO()
            {
                Rashi = 4,
                Hindi = "कर्क",
                English = "Cancer",
                Marathi = "कर्क",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Swami = 2,
                Ratna = "मोती",
                Upratna = "चंद्रकांता मणि , सफ़ेद हकीक"
            };
            kPRashiVOs.Add(kPRashiVO);
            kPRashiVO = new KPRashiVO()
            {
                Rashi = 5,
                Hindi = "सिंह",
                English = "Leo",
                Marathi = "सिंह",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Swami = 1,
                Ratna = "माणिक्य",
                Upratna = "लाल हकीक"
            };
            kPRashiVOs.Add(kPRashiVO);
            kPRashiVO = new KPRashiVO()
            {
                Rashi = 6,
                Hindi = "कन्या",
                English = "Virgo",
                Marathi = "कन्या",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Swami = 4,
                Ratna = "पन्ना",
                Upratna = "हरा हकीक , ओनिक्स"
            };
            kPRashiVOs.Add(kPRashiVO);
            kPRashiVO = new KPRashiVO()
            {
                Rashi = 7,
                Hindi = "तुला",
                English = "Libra",
                Marathi = "तूळ",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Swami = 6,
                Ratna = "हीरा",
                Upratna = "ओपल , जिरकॉन , अमेरिकन डायमंड"
            };
            kPRashiVOs.Add(kPRashiVO);
            kPRashiVO = new KPRashiVO()
            {
                Rashi = 8,
                Hindi = "वृश्चिक",
                English = "Scorpio",
                Marathi = "वृश्चिक",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Swami = 3,
                Ratna = "मूंगा",
                Upratna = "लाल हकीक , लाल ओनिक्स"
            };
            kPRashiVOs.Add(kPRashiVO);
            kPRashiVO = new KPRashiVO()
            {
                Rashi = 9,
                Hindi = "धनु",
                English = "Sagittarius",
                Marathi = "धनु",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Swami = 5,
                Ratna = "पुखराज",
                Upratna = "सुनहला , पीला हकीक"
            };
            kPRashiVOs.Add(kPRashiVO);
            kPRashiVO = new KPRashiVO()
            {
                Rashi = 10,
                Hindi = "मकर",
                English = "Capricorn",
                Marathi = "मकर",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Swami = 7,
                Ratna = "नीलम",
                Upratna = "कटहला , काला गोमेद"
            };
            kPRashiVOs.Add(kPRashiVO);
            kPRashiVO = new KPRashiVO()
            {
                Rashi = 11,
                Hindi = "कुंभ",
                English = "Aquarius",
                Marathi = "कुंभ",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Swami = 7,
                Ratna = "नीलम",
                Upratna = "कटहला, काला गोमेद"
            };
            kPRashiVOs.Add(kPRashiVO);
            kPRashiVO = new KPRashiVO()
            {
                Rashi = 12,
                Hindi = "मीन",
                English = "Pisces",
                Marathi = "मीन",
                Telugu = " - ",
                Tamil = " - ",
                Punjabi = " - ",
                Oriya = " - ",
                Bangla = " - ",
                Assamese = " - ",
                Gujarati = " - ",
                Kannada = " - ",
                Malayalam = " - ",
                Swami = 5,
                Ratna = "पुखराज",
                Upratna = "सुनहला, पीला हकीक"
            };
            kPRashiVOs.Add(kPRashiVO);
            return kPRashiVOs;
        }

        public List<KPSigniGoodBad> Fill_Signi_GoodBad()
        {
            List<KPSigniGoodBad> kPSigniGoodBads = new List<KPSigniGoodBad>();
            KPSigniGoodBad kPSigniGoodBad = new KPSigniGoodBad()
            {
                House = 1,
                Good_House = "1,2,4,9,10",
                Bad_House = "6,8,12"
            };
            kPSigniGoodBads.Add(kPSigniGoodBad);
            kPSigniGoodBad = new KPSigniGoodBad()
            {
                House = 2,
                Good_House = "2,7,8,10",
                Bad_House = "1,12"
            };
            kPSigniGoodBads.Add(kPSigniGoodBad);
            kPSigniGoodBad = new KPSigniGoodBad()
            {
                House = 3,
                Good_House = "3,6,9,10,11",
                Bad_House = "2,8,12"
            };
            kPSigniGoodBads.Add(kPSigniGoodBad);
            kPSigniGoodBad = new KPSigniGoodBad()
            {
                House = 4,
                Good_House = "4,9,11",
                Bad_House = "3,5,8,12"
            };
            kPSigniGoodBads.Add(kPSigniGoodBad);
            kPSigniGoodBad = new KPSigniGoodBad()
            {
                House = 5,
                Good_House = "2,5,7,10,11",
                Bad_House = "4,8,12"
            };
            kPSigniGoodBads.Add(kPSigniGoodBad);
            kPSigniGoodBad = new KPSigniGoodBad()
            {
                House = 6,
                Good_House = "2,5,10,11",
                Bad_House = "6,7,8,12"
            };
            kPSigniGoodBads.Add(kPSigniGoodBad);
            kPSigniGoodBad = new KPSigniGoodBad()
            {
                House = 7,
                Good_House = "2,7,10,11",
                Bad_House = "6,8,12"
            };
            kPSigniGoodBads.Add(kPSigniGoodBad);
            kPSigniGoodBad = new KPSigniGoodBad()
            {
                House = 8,
                Good_House = "8,11",
                Bad_House = "2,4,10,12"
            };
            kPSigniGoodBads.Add(kPSigniGoodBad);
            kPSigniGoodBad = new KPSigniGoodBad()
            {
                House = 9,
                Good_House = "3,9,10,11",
                Bad_House = "8,12"
            };
            kPSigniGoodBads.Add(kPSigniGoodBad);
            kPSigniGoodBad = new KPSigniGoodBad()
            {
                House = 10,
                Good_House = "2,3,6,10,11",
                Bad_House = "4,5,8,9,12"
            };
            kPSigniGoodBads.Add(kPSigniGoodBad);
            kPSigniGoodBad = new KPSigniGoodBad()
            {
                House = 11,
                Good_House = "2,3,4,5,6,7,9",
                Bad_House = "8,10,12"
            };
            kPSigniGoodBads.Add(kPSigniGoodBad);
            kPSigniGoodBad = new KPSigniGoodBad()
            {
                House = 12,
                Good_House = "3,9",
                Bad_House = "2,4,6,8,11,12"
            };
            kPSigniGoodBads.Add(kPSigniGoodBad);
            return kPSigniGoodBads;
        }

        public string Get_Signi_String(short planet, List<KPPlanetMappingVO> kp_chart, bool include)
        {
            string str = "";
            List<KPSigniVO> signi = (
                from Map in kp_chart
                where Map.Planet == planet
                select Map).SingleOrDefault<KPPlanetMappingVO>().Signi;
            short rule = 0;
            foreach (KPSigniVO kPSigniVO in
                from Map in signi
                orderby Map.Rule
                select Map)
            {
                if (include)
                {
                    if (rule != kPSigniVO.Rule)
                    {
                        str = string.Concat(str, " ");
                        rule = kPSigniVO.Rule;
                    }
                    str = string.Concat(str, kPSigniVO.Signi, " ");
                }
                else if ((kPSigniVO.Rule == 1 || kPSigniVO.Rule == 2 || kPSigniVO.Rule == 8 ? true : kPSigniVO.Rule == 9))
                {
                    if (rule != kPSigniVO.Rule)
                    {
                        str = string.Concat(str, " ");
                        rule = kPSigniVO.Rule;
                    }
                    str = string.Concat(str, kPSigniVO.Signi, " ");
                }
            }
            str = str.Trim();
            char[] chrArray = new char[] { ',' };
            str = str.TrimEnd(chrArray);
            chrArray = new char[] { ',' };
            str = str.TrimStart(chrArray);
            str = str.Replace("  ", " ");
            return str;
        }

        public List<KPDashaVO> Get_Dasha(List<KPHouseMappingVO> cusp_house, List<KPPlanetMappingVO> kp_chart, KundliVO persKV, bool include)
        {
            List<KPDashaVO> kPDashaVOs = new List<KPDashaVO>();
            KPDashaVO kPDashaVO = new KPDashaVO();
            KundliBLL kundliBLL = new KundliBLL();
            List<KPMahadashaVO> kPMahadashaVOs = new List<KPMahadashaVO>();
            kPMahadashaVOs = this.Fill_Mahadasha();
            short nakNumber = 0;
            KPBLL.nak_list = this.Fill_Nak();
            short nakLord = (
                from Map in kp_chart
                where Map.Planet == 2
                select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
            double degreePlanetDecimal = (
                from Map in kp_chart
                where Map.Planet == 2
                select Map).SingleOrDefault<KPPlanetMappingVO>().DegreePlanet_Decimal;
            double rashi = (double)(
                from Map in kp_chart
                where Map.Planet == 2
                select Map).SingleOrDefault<KPPlanetMappingVO>().Rashi;
            KPDashaRashiVO kPDashaRashiVO = new KPDashaRashiVO();
            foreach (KPNAKVO nakList in KPBLL.nak_list)
            {
                List<KPDashaRashiVO> kPDashaRashiVOs = new List<KPDashaRashiVO>();
                kPDashaRashiVOs = nakList.DashaRashi;
                nakNumber = nakList.NakNumber;
                kPDashaRashiVO = (
                    from Map in kPDashaRashiVOs
                    where (degreePlanetDecimal <= Map.Decimal_From || degreePlanetDecimal > Map.Decimal_To ? false : (double)Map.Rashi == rashi)
                    select Map).SingleOrDefault<KPDashaRashiVO>();
                if (kPDashaRashiVO != null)
                {
                    break;
                }
            }
            double decimalTo = kPDashaRashiVO.Decimal_To - degreePlanetDecimal;
            if ((nakNumber != 3 ? false : rashi != 2))
            {
                decimalTo += kundliBLL.DMStoDecimal(10, 0, 0);
            }
            if ((nakNumber != 5 ? false : rashi != 3))
            {
                decimalTo += kundliBLL.DMStoDecimal(6, 40, 0);
            }
            if ((nakNumber != 7 ? false : rashi != 4))
            {
                decimalTo += kundliBLL.DMStoDecimal(3, 20, 0);
            }
            if ((nakNumber != 12 ? false : rashi != 6))
            {
                decimalTo += kundliBLL.DMStoDecimal(10, 0, 0);
            }
            if ((nakNumber != 14 ? false : rashi != 7))
            {
                decimalTo += kundliBLL.DMStoDecimal(6, 40, 0);
            }
            if ((nakNumber != 16 ? false : rashi != 8))
            {
                decimalTo += kundliBLL.DMStoDecimal(3, 20, 0);
            }
            if ((nakNumber != 21 ? false : rashi != 10))
            {
                decimalTo += kundliBLL.DMStoDecimal(10, 0, 0);
            }
            if ((nakNumber != 23 ? false : rashi != 11))
            {
                decimalTo += kundliBLL.DMStoDecimal(6, 40, 0);
            }
            if ((nakNumber != 25 ? false : rashi != 12))
            {
                decimalTo += kundliBLL.DMStoDecimal(3, 20, 0);
            }
            string dMS = kundliBLL.Dasha_DecimalToDMS(decimalTo);
            char[] chrArray = new char[] { ':' };
            string str = dMS.Split(chrArray)[0];
            string dMS1 = kundliBLL.Dasha_DecimalToDMS(decimalTo);
            chrArray = new char[] { ':' };
            string str1 = dMS1.Split(chrArray)[1];
            string dMS2 = kundliBLL.Dasha_DecimalToDMS(decimalTo);
            chrArray = new char[] { ':' };
            if (Convert.ToInt16(dMS2.Split(chrArray)[2]) >= 30)
            {
                str1 = Convert.ToString(Convert.ToInt16(str1) + 1);
            }
            double num = Convert.ToDouble((double)((
                from Map in kPMahadashaVOs
                where Map.Planet == nakLord
                select Map).SingleOrDefault<KPMahadashaVO>().Years * 12) * 30.41);
            short num1 = Convert.ToInt16((
                from Map in kPMahadashaVOs
                where Map.Planet == nakLord
                select Map).SingleOrDefault<KPMahadashaVO>().Years);
            short num2 = Convert.ToInt16(Convert.ToInt16(str) * 60 + Convert.ToInt16(str1));
            double num3 = Convert.ToDouble(num / 800);
            short num4 = Convert.ToInt16((double)num2 * num3);
            DateTime dateTime = persKV.Dob.AddDays((double)num4);
            DateTime dateTime1 = dateTime.AddYears(-num1);
            dateTime1 = dateTime1.AddDays(1);
            short sno = (
                from Map in kPMahadashaVOs
                where Map.Planet == nakLord
                select Map).SingleOrDefault<KPMahadashaVO>().Sno;
            short num5 = 1;
            for (short i = 1; i <= 9; i = (short)(i + 1))
            {
                kPDashaVO = new KPDashaVO()
                {
                    SNo = num5,
                    Planet = (
                        from Map in kPMahadashaVOs
                        where Map.Sno == sno
                        select Map).SingleOrDefault<KPMahadashaVO>().Planet,
                    StartDate = dateTime1,
                    EndDate = dateTime
                };
                TimeSpan endDate = kPDashaVO.EndDate - kPDashaVO.StartDate;
                kPDashaVO.Days = (long)Convert.ToInt16(endDate.Days);
                KPDashaVO kPDashaVO1 = kPDashaVO;
                short years = (
                    from Map in kPMahadashaVOs
                    where Map.Sno == sno
                    select Map).SingleOrDefault<KPMahadashaVO>().Years;
                kPDashaVO1.Duration = string.Concat("Y ", years.ToString());
                kPDashaVO.Signi = this.Get_Planet_Signis(kp_chart, kPDashaVO.Planet, include);
                kPDashaVO.NakSigni = this.Get_Planet_Signis(kp_chart, (
                    from Map in kp_chart
                    where Map.Planet == kPDashaVO.Planet
                    select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord, include);
                kPDashaVO.Signi_String = this.Get_Signi_String(kPDashaVO.Planet, kp_chart, include);
                kPDashaVO.Nak_Signi_String = this.Get_Signi_String((
                    from Map in kp_chart
                    where Map.Planet == kPDashaVO.Planet
                    select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord, kp_chart, include);
                kPDashaVOs.Add(kPDashaVO);
                if (sno == 9)
                {
                    sno = 0;
                }
                sno = Convert.ToInt16(sno + 1);
                dateTime1 = dateTime.AddDays(1);
                dateTime = dateTime.AddYears((
                    from Map in kPMahadashaVOs
                    where Map.Sno == sno
                    select Map).SingleOrDefault<KPMahadashaVO>().Years);
                num5 = (short)(num5 + 1);
            }
            return kPDashaVOs;
        }

        public List<KPMahadashaVO> Fill_Mahadasha()
        {
            List<KPMahadashaVO> kPMahadashaVOs = new List<KPMahadashaVO>();
            KPMahadashaVO kPMahadashaVO = new KPMahadashaVO()
            {
                Sno = 1,
                Planet = 9,
                Years = 7
            };
            kPMahadashaVOs.Add(kPMahadashaVO);
            kPMahadashaVO = new KPMahadashaVO()
            {
                Sno = 2,
                Planet = 6,
                Years = 20
            };
            kPMahadashaVOs.Add(kPMahadashaVO);
            kPMahadashaVO = new KPMahadashaVO()
            {
                Sno = 3,
                Planet = 1,
                Years = 6
            };
            kPMahadashaVOs.Add(kPMahadashaVO);
            kPMahadashaVO = new KPMahadashaVO()
            {
                Sno = 4,
                Planet = 2,
                Years = 10
            };
            kPMahadashaVOs.Add(kPMahadashaVO);
            kPMahadashaVO = new KPMahadashaVO()
            {
                Sno = 5,
                Planet = 3,
                Years = 7
            };
            kPMahadashaVOs.Add(kPMahadashaVO);
            kPMahadashaVO = new KPMahadashaVO()
            {
                Sno = 6,
                Planet = 8,
                Years = 18
            };
            kPMahadashaVOs.Add(kPMahadashaVO);
            kPMahadashaVO = new KPMahadashaVO()
            {
                Sno = 7,
                Planet = 5,
                Years = 16
            };
            kPMahadashaVOs.Add(kPMahadashaVO);
            kPMahadashaVO = new KPMahadashaVO()
            {
                Sno = 8,
                Planet = 7,
                Years = 19
            };
            kPMahadashaVOs.Add(kPMahadashaVO);
            kPMahadashaVO = new KPMahadashaVO()
            {
                Sno = 9,
                Planet = 4,
                Years = 17
            };
            kPMahadashaVOs.Add(kPMahadashaVO);
            return kPMahadashaVOs;
        }

        public List<KPSigniVO> Get_Planet_Signis(List<KPPlanetMappingVO> kp_chart, short planetno, bool include)
        {
            List<KPSigniVO> kPSigniVOs = new List<KPSigniVO>();
            if (planetno > 0)
            {
                kp_chart = (
                    from Map in kp_chart
                    where Map.Planet == planetno
                    select Map).ToList<KPPlanetMappingVO>();
            }
            foreach (KPPlanetMappingVO kpChart in kp_chart)
            {
                if (!include)
                {
                    foreach (KPSigniVO kPSigniVO in
                        from sk in kpChart.Signi
                        where (sk.Rule == 1 || sk.Rule == 2 || sk.Rule == 8 ? true : sk.Rule == 9)
                        select sk)
                    {
                        if (!kPSigniVOs.Exists((KPSigniVO Map) => Map.Signi == kPSigniVO.Signi))
                        {
                            kPSigniVOs.Add(kPSigniVO);
                        }
                    }
                }
                if (include)
                {
                    foreach (KPSigniVO signi in kpChart.Signi)
                    {
                        if (!kPSigniVOs.Exists((KPSigniVO Map) => Map.Signi == signi.Signi))
                        {
                            kPSigniVOs.Add(signi);
                        }
                    }
                }
            }
            return kPSigniVOs;
        }

        public List<KPSigniVO> Get_Planet_Signis(List<KPPlanetMappingVO> kp_chart, short planetno)
        {
            List<KPSigniVO> kPSigniVOs = new List<KPSigniVO>();
            if (planetno > 0)
            {
                kp_chart = (
                    from Map in kp_chart
                    where Map.Planet == planetno
                    select Map).ToList<KPPlanetMappingVO>();
            }
            foreach (KPPlanetMappingVO kpChart in kp_chart)
            {
                foreach (KPSigniVO signi in kpChart.Signi)
                {
                    if (!kPSigniVOs.Exists((KPSigniVO Map) => Map.Signi == signi.Signi))
                    {
                        kPSigniVOs.Add(signi);
                    }
                }
            }
            return kPSigniVOs;
        }

        public List<KPDashaVO> Get_Antar_Dasha(DateTime dasha_starts, DateTime main_dasha_ends, short main_planet, List<KPPlanetMappingVO> kp_chart, bool include)
        {
            List<KPDashaVO> kPDashaVOs = new List<KPDashaVO>();
            KPDashaVO kPDashaVO = new KPDashaVO();
            KundliBLL kundliBLL = new KundliBLL();
            List<KPMahadashaVO> kPMahadashaVOs = new List<KPMahadashaVO>();
            kPMahadashaVOs = this.Fill_Mahadasha();
            KPDashaRashiVO kPDashaRashiVO = new KPDashaRashiVO();
            Convert.ToDouble((double)((
                from Map in kPMahadashaVOs
                where Map.Planet == main_planet
                select Map).SingleOrDefault<KPMahadashaVO>().Years * 12) * 30.41);
            short num = Convert.ToInt16((
                from Map in kPMahadashaVOs
                where Map.Planet == main_planet
                select Map).SingleOrDefault<KPMahadashaVO>().Years);
            DateTime dashaStarts = dasha_starts;
            short sno = (
                from Map in kPMahadashaVOs
                where Map.Planet == main_planet
                select Map).SingleOrDefault<KPMahadashaVO>().Sno;
            for (short i = 1; i <= 9; i = (short)(i + 1))
            {
                short num1 = Convert.ToInt16((
                    from Map in kPMahadashaVOs
                    where Map.Sno == sno
                    select Map).SingleOrDefault<KPMahadashaVO>().Years);
                short num2 = Convert.ToInt16(Math.Floor(Convert.ToDouble(num) * Convert.ToDouble(num1) / 10 * 30.41));
                kPDashaVO = new KPDashaVO()
                {
                    Planet = (
                        from Map in kPMahadashaVOs
                        where Map.Sno == sno
                        select Map).SingleOrDefault<KPMahadashaVO>().Planet,
                    StartDate = dasha_starts
                };
                dashaStarts = dasha_starts.AddDays((double)num2);
                kPDashaVO.EndDate = dashaStarts;
                kPDashaVO.Signi = this.Get_Planet_Signis(kp_chart, kPDashaVO.Planet, include);
                kPDashaVO.NakSigni = this.Get_Planet_Signis(kp_chart, (
                    from Map in kp_chart
                    where Map.Planet == kPDashaVO.Planet
                    select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord, include);
                kPDashaVO.Signi_String = this.Get_Signi_String(kPDashaVO.Planet, kp_chart, include);
                kPDashaVO.Nak_Signi_String = this.Get_Signi_String((
                    from Map in kp_chart
                    where Map.Planet == kPDashaVO.Planet
                    select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord, kp_chart, include);
                if (i == 9)
                {
                    kPDashaVO.EndDate = main_dasha_ends;
                }
                TimeSpan endDate = kPDashaVO.EndDate - kPDashaVO.StartDate;
                kPDashaVO.Days = Convert.ToInt64(endDate.Days);
                kPDashaVO.Duration = this.Get_Duration_String(Convert.ToInt64(endDate.Days));
                kPDashaVOs.Add(kPDashaVO);
                if (sno == 9)
                {
                    sno = 0;
                }
                sno = Convert.ToInt16(sno + 1);
                dasha_starts = dashaStarts.AddDays(1);
            }
            return kPDashaVOs;
        }

        private string Get_Duration_String(long days)
        {
            string str = "";
            long num = (long)0;
            long num1 = (long)0;
            long num2 = (long)0;
            num = Convert.ToInt64(Convert.ToInt64(Math.Floor((double)days / 30.41)) / (long)12);
            num1 = Convert.ToInt64(Convert.ToInt64(Math.Floor((double)days / 30.41)) - num * (long)12);
            num2 = Convert.ToInt64(days - num * (long)365);
            num2 = Convert.ToInt64((double)num2 - (double)num1 * 30.41);
            if ((num2 == (long)30 ? true : num2 == (long)31))
            {
                num1 = Convert.ToInt64(num1 + (long)1);
                num2 = (long)0;
            }
            if (num > (long)0)
            {
                str = string.Concat(str, "Y", num.ToString());
            }
            if (num1 > (long)0)
            {
                str = string.Concat(str, " M", num1.ToString());
            }
            str = string.Concat(str, " D", num2.ToString());
            str = str.TrimStart(new char[] { ' ' });
            return str;
        }

        public List<KPDashaVO> Get_Prayatntar_Dasha(List<KPDashaVO> antardasha, DateTime dasha_starts, DateTime main_dasha_ends, short main_planet, short antar_planet, List<KPPlanetMappingVO> kp_chart, bool include)
        {
            List<KPDashaVO> kPDashaVOs = new List<KPDashaVO>();
            KPDashaVO kPDashaVO = new KPDashaVO();
            KundliBLL kundliBLL = new KundliBLL();
            List<KPMahadashaVO> kPMahadashaVOs = new List<KPMahadashaVO>();
            kPMahadashaVOs = this.Fill_Mahadasha();
            KPDashaRashiVO kPDashaRashiVO = new KPDashaRashiVO();
            double num = Convert.ToDouble((
                from Map in kPMahadashaVOs
                where Map.Planet == main_planet
                select Map).SingleOrDefault<KPMahadashaVO>().Years);
            DateTime dashaStarts = dasha_starts;
            short sno = (
                from Map in kPMahadashaVOs
                where Map.Planet == antar_planet
                select Map).SingleOrDefault<KPMahadashaVO>().Sno;
            double num1 = Convert.ToDouble((
                from Map in kPMahadashaVOs
                where Map.Planet == antar_planet
                select Map).SingleOrDefault<KPMahadashaVO>().Years);
            for (short i = 1; i <= 9; i = (short)(i + 1))
            {
                double num2 = Convert.ToDouble((
                    from Map in kPMahadashaVOs
                    where Map.Sno == sno
                    select Map).SingleOrDefault<KPMahadashaVO>().Years);
                double num3 = Convert.ToDouble(Math.Floor(Convert.ToDouble(num) * Convert.ToDouble(num1) / 10 * 30.41));
                num3 = (double)Convert.ToInt16(Convert.ToDouble(num3 * (num2 * 100 / 120) / 100));
                kPDashaVO = new KPDashaVO()
                {
                    Planet = (
                        from Map in kPMahadashaVOs
                        where Map.Sno == sno
                        select Map).SingleOrDefault<KPMahadashaVO>().Planet,
                    StartDate = dasha_starts
                };
                dashaStarts = dasha_starts.AddDays(num3);
                kPDashaVO.EndDate = dashaStarts;
                if (i == 9)
                {
                    kPDashaVO.EndDate = main_dasha_ends;
                }
                kPDashaVO.Signi = this.Get_Planet_Signis(kp_chart, kPDashaVO.Planet, include);
                kPDashaVO.NakSigni = this.Get_Planet_Signis(kp_chart, (
                    from Map in kp_chart
                    where Map.Planet == kPDashaVO.Planet
                    select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord, include);
                kPDashaVO.Signi_String = this.Get_Signi_String(kPDashaVO.Planet, kp_chart, include);
                kPDashaVO.Nak_Signi_String = this.Get_Signi_String((
                    from Map in kp_chart
                    where Map.Planet == kPDashaVO.Planet
                    select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord, kp_chart, include);
                TimeSpan endDate = kPDashaVO.EndDate - kPDashaVO.StartDate;
                kPDashaVO.Days = (long)Convert.ToInt16(endDate.Days);
                kPDashaVO.Duration = this.Get_Duration_String((long)Convert.ToInt16(endDate.Days));
                kPDashaVOs.Add(kPDashaVO);
                if (sno == 9)
                {
                    sno = 0;
                }
                sno = Convert.ToInt16(sno + 1);
                dasha_starts = dashaStarts.AddDays(1);
            }
            return kPDashaVOs;
        }

        public List<KPDashaVO> Get_Sukhsma_Dasha(List<KPDashaVO> antardasha, DateTime dasha_starts, DateTime main_dasha_ends, short main_planet, short antra_planet, short pryantar_planet, List<KPPlanetMappingVO> kp_chart, bool include)
        {
            List<KPDashaVO> kPDashaVOs = new List<KPDashaVO>();
            KPDashaVO kPDashaVO = new KPDashaVO();
            KundliBLL kundliBLL = new KundliBLL();
            List<KPMahadashaVO> kPMahadashaVOs = new List<KPMahadashaVO>();
            kPMahadashaVOs = this.Fill_Mahadasha();
            KPDashaRashiVO kPDashaRashiVO = new KPDashaRashiVO();
            double num = (double)Convert.ToInt16(kPMahadashaVOs.Where(Map => Map.Planet == antra_planet).SingleOrDefault<KPMahadashaVO>().Years);
            DateTime dashaStarts = dasha_starts;
            short sno = kPMahadashaVOs.Where(Map => Map.Planet == pryantar_planet).SingleOrDefault<KPMahadashaVO>().Sno;
            double num1 = Convert.ToDouble((from Map in kPMahadashaVOs where Map.Planet == antra_planet select Map).SingleOrDefault<KPMahadashaVO>().Years);
            double num2 = 0;
            for (short i = 1; i <= 9; i = (short)(i + 1))
            {
                num2 = Convert.ToDouble(kPMahadashaVOs.Where(Map => Map.Sno == sno).SingleOrDefault<KPMahadashaVO>().Years);
                double num3 = Convert.ToDouble(Math.Floor(Convert.ToDouble(num) * Convert.ToDouble(num1) / 10 * 30.41));
                num3 = (double)Convert.ToInt16(Convert.ToDouble(num3 * (num1 * 100 / 120) / 100));
                num3 = (double)Convert.ToInt16(Convert.ToDouble(num3 * (num2 * 100 / 120) / 100));

                kPDashaVO = new KPDashaVO();

                var planet = kPMahadashaVOs.Where(Map => Map.Sno == sno).SingleOrDefault<KPMahadashaVO>().Planet;
                var nakLord = kp_chart.Where(Map => Map.Planet == planet).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;

                kPDashaVO.Planet = planet;
                kPDashaVO.StartDate = dasha_starts;
                kPDashaVO.Signi = this.Get_Planet_Signis(kp_chart, planet, include);
                kPDashaVO.NakSigni = this.Get_Planet_Signis(kp_chart, nakLord, include);
                kPDashaVO.Signi_String = this.Get_Signi_String(planet, kp_chart, include);
                kPDashaVO.Nak_Signi_String = this.Get_Signi_String(nakLord, kp_chart, include);
                dashaStarts = dasha_starts.AddDays(num3);

                kPDashaVO.EndDate = dashaStarts;
                if (i == 9)
                {
                    kPDashaVO.EndDate = main_dasha_ends;
                }
                TimeSpan endDate = kPDashaVO.EndDate - kPDashaVO.StartDate;
                kPDashaVO.Days = (long)Convert.ToInt16(endDate.Days);
                kPDashaVO.Duration = this.Get_Duration_String((long)Convert.ToInt16(endDate.Days));
                kPDashaVOs.Add(kPDashaVO);
                if (sno == 9)
                {
                    sno = 0;
                }
                sno = Convert.ToInt16(sno + 1);
                if (num3 < 1)
                {
                    dasha_starts = dashaStarts;
                }
                else
                {
                    dasha_starts = dashaStarts.AddDays(1);
                }
                dashaStarts = dashaStarts.AddYears(kPMahadashaVOs.Where(Map => Map.Sno == sno).SingleOrDefault<KPMahadashaVO>().Years);
            }
            return kPDashaVOs;
        }

    }
}
