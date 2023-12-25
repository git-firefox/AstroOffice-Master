using ASDLL;
using AstroOfficeWeb.Shared.VOs;
using Kunda;


//using MatchDL;
//using MatchDL.ValueObjects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
//using AstroShared.Models;
namespace ASDLL.DataAccess.Core
{
    public class PredictionBLL
    {
        private LangResource lrs = new LangResource();

        private long prev_umra = (long)0;

        private List<string> jad_method_planet_used = new List<string>();

        private List<string> umra_method_planet_used = new List<string>();

        private List<long> all_upayindex_sno = new List<long>();

        private List<long> all_Special_sno = new List<long>();

        private string All_Special_List = "";

        private PlanetBLL pbl = new PlanetBLL();

        private bool paidpred;

        private List<PlanetMAPVO> planetmap = new List<PlanetMAPVO>();

        public PredictionBLL()
        {
            AstroGlobal.ValidKey = true;
            this.planetmap = this.pbl.FillAllPlanets();
        }

        public int CalculateAgeCorrect(DateTime birthDate, DateTime now)
        {
            bool flag;
            int year = now.Year - birthDate.Year;
            if (now.Month < birthDate.Month)
            {
                flag = false;
            }
            else
            {
                flag = (now.Month != birthDate.Month ? true : now.Day >= birthDate.Day);
            }
            if (!flag)
            {
                year--;
            }
            return year;
        }

        //public string Chart_35(KundliVO persKV, List<KundliMappingVO> lkmv)
        //{
        //    long lagna = persKV.Lagna;
        //    string str = "";
        //    List<Life35VO> life35VOs = new List<Life35VO>();
        //    life35VOs = (new KundliBLL()).GetLife35(persKV.JanamSamay);
        //    bool flag = false;
        //    foreach (Life35VO life35VO in life35VOs)
        //    {
        //        List<long> nums = new List<long>();
        //        flag = true;
        //        string str1 = "";
        //        KundliMappingVO kundliMappingVO = new KundliMappingVO();
        //        kundliMappingVO = (
        //            from Map in lkmv
        //            where Map.PlanetName == life35VO.Planet
        //            select Map).SingleOrDefault<KundliMappingVO>();
        //        Years35BLL years35BLL = new Years35BLL();
        //        List<Years35VO> years35VOs = years35BLL.Get35Years(persKV.JanamSamay);
        //        long umra = years35BLL.GetUmra(kundliMappingVO.PlanetName) - (long)1;
        //        long num = Convert.ToInt64((
        //            from Map in years35VOs
        //            where Map.Planet == kundliMappingVO.PlanetName
        //            select Map).Min<Years35VO>((Years35VO Map) => Map.Years));
        //        str1 = string.Concat(str1, this.lrs.getPrabhav(num, umra, persKV.Language).ToString());
        //        string str2 = str;
        //        string[] planetnameHindi = new string[] { str2, this.findplanet_by_name(life35VO.Planet.ToString()).PlanetnameHindi, "  ", str1, "\r\n\r\n" };
        //        str = string.Concat(planetnameHindi);
        //    }
        //    return str;
        //}

        public PlanetVO findplanet(int pid)
        {
            List<PlanetVO> allPlanets = (new PlanetBLL()).GetAllPlanets();
            PlanetVO planetVO = allPlanets.Find((PlanetVO p) => p.Sno == pid);
            return planetVO;
        }

        //public PlanetVO findplanet_by_name(string planet)
        //{
        //    List<PlanetVO> allPlanets = (new PlanetBLL()).GetAllPlanets();
        //    PlanetVO planetVO = allPlanets.Find((PlanetVO p) => p.Planetname == planet);
        //    return planetVO;
        //}

        public List<RulesVO> generate_final_lrvgen(KundliVO persKV, List<KundliMappingVO> lkmv, bool vfal, List<short> year, string lang, string planet, bool singleplanet, bool mainplanet)
        {
            char[] chrArray;
            string[] strArrays;
            int num;
            List<RulesVO> rulesVOs = new List<RulesVO>();
            List<RulesVO> rulesVOs1 = new List<RulesVO>();
            List<Life35VO> life35VOs = new List<Life35VO>();
            KundliBLL kundliBLL = new KundliBLL();
            if (planet.Trim().Length <= 0)
            {
                life35VOs = kundliBLL.GetLife35(persKV.JanamSamay);
            }
            else
            {
                life35VOs.Add(new Life35VO()
                {
                    Planet = planet
                });
            }
            foreach (Life35VO life35VO in life35VOs)
            {
                KundliMappingVO kundliMappingVO = new KundliMappingVO();
                kundliMappingVO = (
                    from Map in lkmv
                    where Map.PlanetName == life35VO.Planet
                    select Map).SingleOrDefault<KundliMappingVO>();
                List<RulesVO> list = new List<RulesVO>();
                if (vfal)
                {
                    foreach (short num1 in year)
                    {
                        list.AddRange((
                            from Map in kundliBLL.GetAdvancePredictions(lkmv, kundliMappingVO.Planet, 0)
                            where ((Map.RuleType == "any" || Map.RuleType == "general" || Map.RuleType == "triangle" || Map.RuleType == "gatha") && Map.Isbad == kundliMappingVO.IsBad ? Map.VfalYears.Split(new char[] { ',' }).ToArray<string>().Contains<string>(num1.ToString()) : false)
                            select Map).ToList<RulesVO>());
                        list.AddRange((
                            from Map in kundliBLL.GetAdvancePredictions(lkmv, kundliMappingVO.Planet, 0)
                            where (Map.RuleType == "triangle" || Map.RuleType == "gany" || Map.RuleType == "any" ? Map.VfalYears.Split(new char[] { ',' }).ToArray<string>().Contains<string>(num1.ToString()) : false)
                            select Map).ToList<RulesVO>());
                    }
                }
                else if (!(lang.ToLower() == "gujarati" ? false : !(lang.ToLower() == "punjabi")))
                {
                    list = (
                        from Map in kundliBLL.GetAdvancePredictions(lkmv, kundliMappingVO.Planet, 0)
                        where (Map.Isbad != kundliMappingVO.IsBad ? false : (Map.RuleType == "langsplupay2" || Map.RuleType == "general" || Map.RuleType == "langgeneral" || Map.RuleType == "triangle" || Map.RuleType == "gatha" || Map.RuleType == "langgatha" || Map.RuleType == "langsunheri" ? true : (Map.Reference != "Indian Astrology" ? false : Map.Ruleformula.Contains("&"))))
                        select Map).ToList<RulesVO>();
                    list.AddRange((
                        from Map in kundliBLL.GetAdvancePredictions(lkmv, kundliMappingVO.Planet, 0)
                        where (Map.RuleType == "gany" || Map.RuleType == "shadi" || Map.RuleType == "triangle" || Map.RuleType == "any" ? true : Map.RuleType == "gochar")
                        select Map).ToList<RulesVO>());
                }
                else if (!mainplanet)
                {
                    list = (
                        from Map in kundliBLL.GetAdvancePredictions(lkmv, kundliMappingVO.Planet, 0)
                        where (Map.Isbad != kundliMappingVO.IsBad ? false : (Map.RuleType == "any" || Map.RuleType == "general" || Map.RuleType == "triangle" || Map.RuleType == "gatha" ? true : (Map.Reference != "Indian Astrology" ? false : Map.Ruleformula.Contains("&"))))
                        select Map).ToList<RulesVO>();
                    list.AddRange((
                        from Map in kundliBLL.GetAdvancePredictions(lkmv, kundliMappingVO.Planet, 0)
                        where (Map.RuleType == "gany" || Map.RuleType == "shadi" || Map.RuleType == "gochar" || Map.RuleType == "triangle" ? true : Map.RuleType == "any")
                        select Map).ToList<RulesVO>());
                }
                else
                {
                    list = (
                        from Map in kundliBLL.GetAdvancePredictions(lkmv, kundliMappingVO.Planet, 0)
                        where (Map.Isbad != kundliMappingVO.IsBad || Map.Mainplanet != kundliMappingVO.Planet ? false : (Map.RuleType == "any" || Map.RuleType == "general" || Map.RuleType == "triangle" || Map.RuleType == "gatha" ? true : (Map.Reference != "Indian Astrology" ? false : Map.Ruleformula.Contains("&"))))
                        select Map).ToList<RulesVO>();
                    list.AddRange((
                        from Map in kundliBLL.GetAdvancePredictions(lkmv, kundliMappingVO.Planet, 0)
                        where (Map.Mainplanet != kundliMappingVO.Planet ? false : (Map.RuleType == "mlife" || Map.RuleType == "gany" || Map.RuleType == "shadi" || Map.RuleType == "gochar" || Map.RuleType == "triangle" ? true : Map.RuleType == "any"))
                        select Map).ToList<RulesVO>());
                }
                rulesVOs1 = list;
                List<RulesVO> rulesVOs2 = new List<RulesVO>();
                rulesVOs2 = (!singleplanet ? rulesVOs1 : (
                    from Rules in rulesVOs1
                    where Rules.Rule_Nature == 1
                    select Rules).ToList<RulesVO>());
                rulesVOs1 = rulesVOs2;
                foreach (RulesVO rulesVO in rulesVOs1)
                {
                    //bool flag = false;
                    //flag = false;
                    if ((rulesVO.Good.Trim().Length > 0 ? false : rulesVO.Bad.Trim().Length <= 0))
                    {
                        rulesVOs.Add(rulesVO);
                    }
                    else
                    {
                        string good = rulesVO.Good;
                        string bad = rulesVO.Bad;
                        if (good.Length > 0)
                        {
                            chrArray = new char[] { ',' };
                            strArrays = good.Split(chrArray);
                            num = 0;
                            while (num < (int)strArrays.Length)
                            {
                                string str = strArrays[num];
                                if ((
                                    from Map in lkmv
                                    where Map.Planet == Convert.ToInt16(str)
                                    select Map).SingleOrDefault<KundliMappingVO>().IsBad)
                                {
                                    num++;
                                }
                                else
                                {
                                    rulesVOs.Add(rulesVO);
                                    break;
                                }
                            }
                        }
                        if (bad.Length > 0)
                        {
                            chrArray = new char[] { ',' };
                            strArrays = bad.Split(chrArray);
                            num = 0;
                            while (num < (int)strArrays.Length)
                            {
                                string str1 = strArrays[num];
                                if (!(
                                    from Map in lkmv
                                    where Map.Planet == Convert.ToInt16(str1)
                                    select Map).SingleOrDefault<KundliMappingVO>().IsBad)
                                {
                                    num++;
                                }
                                else
                                {
                                    rulesVOs.Add(rulesVO);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            rulesVOs = (
                from i in rulesVOs
                group i by i.Sno into g
                select g.First<RulesVO>()).ToList<RulesVO>();
            if (persKV.Male)
            {
                rulesVOs = (
                    from Map in rulesVOs
                    where (Map.Common ? true : Map.Male)
                    select Map).ToList<RulesVO>();
            }
            if (!persKV.Male)
            {
                rulesVOs = (
                    from Map in rulesVOs
                    where (Map.Common ? true : Map.Female)
                    select Map).ToList<RulesVO>();
            }
            return rulesVOs;
        }

        //public string Get_Antardasha_HTML(string Online_Result, KundliVO persKV, DateTime dasha_starts, DateTime dasha_ends)
        //{
        //    List<KPDashaVO> kPDashaVOs = new List<KPDashaVO>();
        //    KPBLL kPBLL = new KPBLL();
        //    kPDashaVOs = this.Get_List_35_Sala(Online_Result, persKV, dasha_starts, dasha_ends);
        //    return kPBLL.Get_Antar_HTML(kPDashaVOs, persKV.Language);
        //}

        public string Get_Current_35_Sala_Fal(KundliVO persKV, string Online_Result, ProductSettingsVO tmpprod)
        {
            string str = "";
            KPBLL kPBLL = new KPBLL();
            List<KPDashaVO> kPDashaVOs = new List<KPDashaVO>();
            List<KPPlanetsVO> kPPlanetsVOs = new List<KPPlanetsVO>();
            kPPlanetsVOs = kPBLL.Fill_Planets();
            List<KPPlanetMappingVO> kPPlanetMappingVOs = new List<KPPlanetMappingVO>();
            List<KPHouseMappingVO> kPHouseMappingVOs = new List<KPHouseMappingVO>();
            kPBLL.Process_Planet_Lagan(Online_Result, ref kPPlanetMappingVOs, ref kPHouseMappingVOs, persKV.Rotate, true);
            List<short> nums = new List<short>();
            if (tmpprod.Dasha_Years <= 0)
            {
                tmpprod.Dasha_Years = 2;
            }
            PredictionBLL predictionBLL = new PredictionBLL();
            List<KPDashaVO> dasha = new List<KPDashaVO>();
            List<KPMahadashaVO> kPMahadashaVOs = new List<KPMahadashaVO>();
            kPMahadashaVOs = kPBLL.Fill_Mahadasha();
            List<string> strs = new List<string>();
            dasha = kPBLL.Get_Dasha(kPHouseMappingVOs, kPPlanetMappingVOs, persKV, false);
            DateTime date = DateTime.Now.Date;
            DateTime dateTime = date.AddYears(-1);
            date = DateTime.Now.Date;
            DateTime dateTime1 = date.AddYears(tmpprod.Dasha_Years);
            string falDoubleAntarHyphenWala = "";
            kPDashaVOs = this.Get_List_35_Sala_For_CurrentAntar(Online_Result, persKV, dateTime, dateTime1, tmpprod);
            short currentAge = persKV.Current_Age;
            foreach (KPDashaVO kPDashaVO in kPDashaVOs)
            {
                string[] codeLang = new string[5];
                date = kPDashaVO.StartDate;
                codeLang[0] = date.ToString("dd");
                codeLang[1] = " ";
                date = kPDashaVO.StartDate;
                codeLang[2] = predictionBLL.GetCodeLang(string.Concat("M", date.ToString("%M")), persKV.Language, persKV.Paid, true);
                codeLang[3] = " ";
                date = kPDashaVO.StartDate;
                codeLang[4] = date.ToString("yyyy");
                string str1 = string.Concat(codeLang);
                if (kPDashaVO.StartDate < persKV.Dob)
                {
                    codeLang = new string[5];
                    date = persKV.Dob;
                    codeLang[0] = date.ToString("dd");
                    codeLang[1] = " ";
                    date = persKV.Dob;
                    codeLang[2] = predictionBLL.GetCodeLang(string.Concat("M", date.ToString("%M")), persKV.Language, persKV.Paid, true);
                    codeLang[3] = " ";
                    date = persKV.Dob;
                    codeLang[4] = date.ToString("yyyy");
                    str1 = string.Concat(codeLang);
                }
                codeLang = new string[5];
                date = kPDashaVO.EndDate;
                codeLang[0] = date.ToString("dd");
                codeLang[1] = " ";
                date = kPDashaVO.EndDate;
                codeLang[2] = predictionBLL.GetCodeLang(string.Concat("M", date.ToString("%M")), persKV.Language, persKV.Paid, true);
                codeLang[3] = " ";
                date = kPDashaVO.EndDate;
                codeLang[4] = date.ToString("yyyy");
                string str2 = string.Concat(codeLang);
                short planet = (
                    from Map in dasha
                    where (kPDashaVO.StartDate < Map.StartDate ? false : kPDashaVO.StartDate <= Map.EndDate)
                    select Map).FirstOrDefault<KPDashaVO>().Planet;
                falDoubleAntarHyphenWala = this.Get_Fal_Double_Antar_Hyphen_Wala(kPDashaVO.Duration, kPDashaVO.Nak_Signi_String, kPDashaVO.Planet, planet, tmpprod, persKV);
                if (falDoubleAntarHyphenWala.Length >= 60)
                {
                    string str3 = "";
                    if (!strs.Exists((string Map) => Map == string.Concat(str1, str2)))
                    {
                        if (!(kPDashaVO.Duration == "-"))
                        {
                            codeLang = new string[] { "\r\n<B>", predictionBLL.GetCodeLang("updasha", persKV.Language, persKV.Paid, true), " ", str1, predictionBLL.GetCodeLang("to", persKV.Language, persKV.Paid, true), str2, "</B>\r\n\r\n" };
                            str3 = string.Concat(codeLang);
                        }
                        else
                        {
                            codeLang = new string[] { "\r\n<B>", predictionBLL.GetCodeLang("mukhya", persKV.Language, persKV.Paid, true), " ", str1, predictionBLL.GetCodeLang("to", persKV.Language, persKV.Paid, true), str2, "</B>\r\n\r\n" };
                            str3 = string.Concat(codeLang);
                        }
                    }
                    strs.Add(string.Concat(str1, str2));
                    str = string.Concat(str, str3, "\r\n\r\n", falDoubleAntarHyphenWala);
                }
                currentAge = (short)(currentAge + 1);
            }
            return str;
        }

        public string Get_Current_MahadashaFal(KundliVO persKV, string Online_Result, ProductSettingsVO tmpprod)
        {
            string str = "";
            KPBLL kPBLL = new KPBLL();
            List<short> nums = new List<short>();
            List<KPDashaVO> kPDashaVOs = new List<KPDashaVO>();
            List<KPPlanetsVO> kPPlanetsVOs = new List<KPPlanetsVO>();
            kPPlanetsVOs = kPBLL.Fill_Planets();
            List<KPMahadashaVO> kPMahadashaVOs = new List<KPMahadashaVO>();
            kPMahadashaVOs = kPBLL.Fill_Mahadasha();
            List<KPPlanetMappingVO> kPPlanetMappingVOs = new List<KPPlanetMappingVO>();
            List<KPHouseMappingVO> kPHouseMappingVOs = new List<KPHouseMappingVO>();
            kPBLL.Process_Planet_Lagan(Online_Result, ref kPPlanetMappingVOs, ref kPHouseMappingVOs, persKV.Rotate, true);
            kPDashaVOs = kPBLL.Get_Dasha(kPHouseMappingVOs, kPPlanetMappingVOs, persKV, false);
            short planet = (
                from Map in kPPlanetsVOs
                where Map.English == persKV.Dasha_Visho
                select Map).FirstOrDefault<KPPlanetsVO>().Planet;
            short sNo = (
                from Map in kPDashaVOs
                where Map.Planet == planet
                select Map).FirstOrDefault<KPDashaVO>().SNo;
            nums.Add(planet);
            PredictionBLL predictionBLL = new PredictionBLL();
            foreach (short num in nums)
            {
                DateTime startDate = (
                    from Map in kPDashaVOs
                    where Map.Planet == num
                    select Map).SingleOrDefault<KPDashaVO>().StartDate;
                DateTime endDate = (
                    from Map in kPDashaVOs
                    where Map.Planet == num
                    select Map).SingleOrDefault<KPDashaVO>().EndDate;
                string str1 = string.Concat("\r\n<B>", predictionBLL.GetCodeLang("mahadashanote", persKV.Language, true, true), "</B>\r\n\r\n");
                string str2 = str1;
                short years = (
                    from Map in kPMahadashaVOs
                    where Map.Planet == num
                    select Map).SingleOrDefault<KPMahadashaVO>().Years;
                str1 = str2.Replace("[#years#]", years.ToString());
                string[] codeLang = new string[] { startDate.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", startDate.ToString("%M")), persKV.Language, persKV.Paid, true), " ", startDate.ToString("yyyy") };
                string str3 = string.Concat(codeLang);
                if (startDate < persKV.Dob)
                {
                    codeLang = new string[5];
                    DateTime dob = persKV.Dob;
                    codeLang[0] = dob.ToString("dd");
                    codeLang[1] = " ";
                    dob = persKV.Dob;
                    codeLang[2] = predictionBLL.GetCodeLang(string.Concat("M", dob.ToString("%M")), persKV.Language, persKV.Paid, true);
                    codeLang[3] = " ";
                    dob = persKV.Dob;
                    codeLang[4] = dob.ToString("yyyy");
                    str3 = string.Concat(codeLang);
                }
                codeLang = new string[] { endDate.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", endDate.ToString("%M")), persKV.Language, persKV.Paid, true), " ", endDate.ToString("yyyy") };
                string str4 = string.Concat(codeLang);
                str = string.Concat(str, str1);
                string str5 = str;
                codeLang = new string[] { str5, "<B>", predictionBLL.GetCodeLang("mahadasha", persKV.Language, persKV.Paid, true), " ", str3, predictionBLL.GetCodeLang("to", persKV.Language, persKV.Paid, true), str4, "</B>\r\n\r\n" };
                str = string.Concat(codeLang);
                str = string.Concat(str, kPBLL.Get_Fal_Double_Mahadasha(num, persKV, Online_Result, tmpprod));
            }
            return str;
        }

        public string Get_Fal_Antar(string Online_Result, short planet_no, string antar_string, string age_string, KundliVO persKV, ProductSettingsVO tmpprod, bool mfal)
        {
            PredictionBLL predictionBLL;
            short planetNo = planet_no;
            string str = "";
            List<KPPlanetsVO> kPPlanetsVOs = new List<KPPlanetsVO>();
            short num = 0;
            short num1 = 0;
            KPBLL kPBLL = new KPBLL();
            char[] chrArray = new char[] { '-' };
            string[] strArrays = age_string.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
            List<KPDashaVO> kPDashaVOs = new List<KPDashaVO>();
            List<KPDashaVO> antarDasha = new List<KPDashaVO>();
            List<KundliMappingVO> kundliMappingVOs = new List<KundliMappingVO>();
            PredictionBLL predictionBLL1 = new PredictionBLL();
            kPPlanetsVOs = kPBLL.Fill_Planets();
            kundliMappingVOs = predictionBLL1.map_kundali(Online_Result, true);
            List<KPPlanetMappingVO> kPPlanetMappingVOs = new List<KPPlanetMappingVO>();
            List<KPHouseMappingVO> kPHouseMappingVOs = new List<KPHouseMappingVO>();
            kPBLL.Process_Planet_Lagan(Online_Result, ref kPPlanetMappingVOs, ref kPHouseMappingVOs, persKV.Rotate, true);
            kPDashaVOs = kPBLL.Get_Dasha(kPHouseMappingVOs, kPPlanetMappingVOs, persKV, false);
            DateTime startDate = (
                from Map in kPDashaVOs
                where Map.Planet == planetNo
                select Map).SingleOrDefault<KPDashaVO>().StartDate;
            DateTime endDate = (
                from Map in kPDashaVOs
                where Map.Planet == planetNo
                select Map).SingleOrDefault<KPDashaVO>().EndDate;
            antarDasha = kPBLL.Get_Antar_Dasha(startDate, endDate, planetNo, kPPlanetMappingVOs, false);
            if (!(antar_string == "-"))
            {
                string str1 = "";
                short planet = (
                    from Map in kPPlanetsVOs
                    where Map.Hindi == antar_string
                    select Map).SingleOrDefault<KPPlanetsVO>().Planet;
                short num2 = planetNo;
                planetNo = planet;
                short num3 = planetNo;
                short bhavChalitHouse = (
                    from Map in kPPlanetMappingVOs
                    where Map.Planet == num3
                    select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
                predictionBLL = new PredictionBLL();
                short num4 = Convert.ToInt16(predictionBLL.CalculateAgeCorrect(persKV.Dob, startDate));
                planetNo = (
                    from Map in kPPlanetMappingVOs
                    where Map.Planet == planetNo
                    select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
                short bhavChalitHouse1 = 0;
                string str2 = "";
                short num5 = planetNo;
                short nakLord = (
                    from Map in kPPlanetMappingVOs
                    where Map.Planet == num2
                    select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
                bhavChalitHouse1 = (
                    from Map in kPPlanetMappingVOs
                    where Map.Planet == num5
                    select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
                str2 = string.Concat((
                    from Map in kPDashaVOs
                    where Map.Planet == num2
                    select Map).SingleOrDefault<KPDashaVO>().Signi_String, " ", (
                    from Map in antarDasha
                    where Map.Planet == num3
                    select Map).SingleOrDefault<KPDashaVO>().Signi_String);
                string signiStringWithoutNakRashi = kPBLL.Get_Signi_String_Without_NakRashi(planetNo, kPPlanetMappingVOs, false);
                chrArray = new char[] { ' ' };
                signiStringWithoutNakRashi.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                string signiStringWithoutNakRashi1 = kPBLL.Get_Signi_String_Without_NakRashi(num2, kPPlanetMappingVOs, false);
                chrArray = new char[] { ' ' };
                signiStringWithoutNakRashi1.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                str1 = string.Concat(str1, kPBLL.Get_Planet_Chain_Pred(str2, startDate, endDate, persKV, "multi", num3, tmpprod, num4));
                if (tmpprod.Vfal)
                {
                    List<short> nums = new List<short>();
                    List<short> nums1 = new List<short>();
                    nums.Clear();
                    nums1.Clear();
                    for (short i = 0; i < 12; i = (short)(i + 1))
                    {
                        nums.Add(Convert.ToInt16(i + 1));
                    }
                    string[] strArrays1 = strArrays;
                    for (int j = 0; j < (int)strArrays1.Length; j++)
                    {
                        nums1.Add(Convert.ToInt16(strArrays1[j]));
                    }
                    KPPredBLL kPPredBLL = new KPPredBLL();
                    persKV.Mfal = mfal;
                    str1 = string.Concat(str1, "\r\n", kPPredBLL.NEW_Get_VarshFal_Predictions(persKV, nums1, kPPlanetMappingVOs, nums, tmpprod));
                }
                str = str1;
            }
            else
            {
                num = Convert.ToInt16(strArrays[0]);
                num1 = (strArrays.ToList<string>().Count <= 1 ? num : Convert.ToInt16(strArrays[1]));
                predictionBLL = new PredictionBLL();
                string str3 = "";
                str3 = kPBLL.LalKitabAmrit_35Years(persKV, kundliMappingVOs, kundliMappingVOs, "", persKV.ShowRef, persKV.Male, persKV.Language, num, num1, tmpprod);
                str = string.Concat(str, "\r\n", str3);
                str = string.Concat(str, "\r\n", kPBLL.Get_Fal_Mahadasha(planetNo, persKV, Online_Result, tmpprod));
            }
            return str;
        }

        public string Get_Fal_Double_Antar_Hyphen_Wala(string antar_string, string age_string, short planet_no, short maha_planet_no, ProductSettingsVO prod, KundliVO persKV)
        {
            short planetNo = planet_no;
            string str = "";
            List<KPDashaVO> kPDashaVOs = new List<KPDashaVO>();
            List<KPDashaVO> antarDasha = new List<KPDashaVO>();
            List<KPPlanetsVO> kPPlanetsVOs = new List<KPPlanetsVO>();
            KPBLL kPBLL = new KPBLL();
            string onlineResult = persKV.Online_Result;
            List<KundliMappingVO> kundliMappingVOs = new List<KundliMappingVO>();
            PredictionBLL predictionBLL = new PredictionBLL();
            kPPlanetsVOs = kPBLL.Fill_Planets();
            kundliMappingVOs = predictionBLL.map_kundali(onlineResult, true);
            char[] chrArray = new char[] { '-' };
            age_string.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
            List<KPPlanetMappingVO> kPPlanetMappingVOs = new List<KPPlanetMappingVO>();
            List<KPHouseMappingVO> kPHouseMappingVOs = new List<KPHouseMappingVO>();
            kPBLL.Process_Planet_Lagan(onlineResult, ref kPPlanetMappingVOs, ref kPHouseMappingVOs, persKV.Rotate, true);
            kPDashaVOs = kPBLL.Get_Dasha(kPHouseMappingVOs, kPPlanetMappingVOs, persKV, false);
            DateTime startDate = (
                from Map in kPDashaVOs
                where Map.Planet == maha_planet_no
                select Map).SingleOrDefault<KPDashaVO>().StartDate;
            DateTime endDate = (
                from Map in kPDashaVOs
                where Map.Planet == maha_planet_no
                select Map).SingleOrDefault<KPDashaVO>().EndDate;
            antarDasha = kPBLL.Get_Antar_Dasha(startDate, endDate, maha_planet_no, kPPlanetMappingVOs, false);
            DateTime dateTime = (
                from Map in antarDasha
                where Map.Planet == planetNo
                select Map).SingleOrDefault<KPDashaVO>().StartDate;
            DateTime endDate1 = (
                from Map in antarDasha
                where Map.Planet == planetNo
                select Map).SingleOrDefault<KPDashaVO>().EndDate;
            short num = planetNo;
            short bhavChalitHouse = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == num
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            PredictionBLL predictionBLL1 = new PredictionBLL();
            short num1 = Convert.ToInt16(predictionBLL1.CalculateAgeCorrect(persKV.Dob, dateTime));
            planetNo = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == planetNo
                select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
            short bhavChalitHouse1 = 0;
            string str1 = "";
            short num2 = planetNo;
            short nakLord = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == maha_planet_no
                select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
            bhavChalitHouse1 = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == num2
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            str1 = string.Concat((
                from Map in kPDashaVOs
                where Map.Planet == maha_planet_no
                select Map).SingleOrDefault<KPDashaVO>().Signi_String, " ", (
                from Map in antarDasha
                where Map.Planet == num
                select Map).SingleOrDefault<KPDashaVO>().Signi_String);
            string str2 = "";
            string signiStringWithoutNakRashi = kPBLL.Get_Signi_String_Without_NakRashi(planetNo, kPPlanetMappingVOs, prod.Include);
            chrArray = new char[] { ' ' };
            signiStringWithoutNakRashi.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
            string signiStringWithoutNakRashi1 = kPBLL.Get_Signi_String_Without_NakRashi(maha_planet_no, kPPlanetMappingVOs, prod.Include);
            chrArray = new char[] { ' ' };
            signiStringWithoutNakRashi1.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
            if (antar_string == "-")
            {
                str = string.Concat(str, kPBLL.Get_Planet_Chain_Pred(str1, dateTime, endDate1, persKV, "multi", num, prod, num1));
                str = string.Concat(str, "\r\n");
            }
            str = string.Concat(str, this.Get_Fal_Antar(onlineResult, num, antar_string, age_string, persKV, prod, persKV.Mfal));
            if (antar_string == "-")
            {
                short nakLord1 = (
                    from Map in kPPlanetMappingVOs
                    where Map.Planet == num2
                    select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
                short bhavChalitHouse2 = (
                    from Map in kPPlanetMappingVOs
                    where Map.Planet == num2
                    select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
                short bhavChalitHouse3 = (
                    from Map in kPPlanetMappingVOs
                    where Map.Planet == nakLord1
                    select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
                str2 = (nakLord1 == num2 ? bhavChalitHouse2.ToString() : string.Concat(bhavChalitHouse2.ToString(), " ", bhavChalitHouse3.ToString()));
                if (nakLord1 == num2)
                {
                    str2 = string.Concat(str2, " ", kPBLL.Get_Signi_String_Only_Rashi(num2, kPPlanetMappingVOs, false));
                }
                KPBLL kPBLL1 = new KPBLL();
                str = string.Concat(str, "\r\n");
                string str3 = string.Concat(bhavChalitHouse, " ", kPBLL.Get_Signi_String_Only_Rashi(num, kPPlanetMappingVOs, prod.Include));
                str = string.Concat(str, kPBLL.Get_Dasha_Pred(num, str3, dateTime, endDate1, persKV, "fulllife", prod, kPPlanetMappingVOs), "\r\n\r\n");
                str = string.Concat(str, kPBLL.Get_Dasha_Pred(num2, bhavChalitHouse2.ToString(), dateTime, endDate1, persKV, "fulllife", prod, kPPlanetMappingVOs), "\r\n\r\n");
            }
            return str;
        }

        //public string Get_Gochar_New(KundliVO persKV, List<KundliMappingVO> lkmv_gochar)
        //{
        //    string str = "";
        //    PredictionBLL predictionBLL = new PredictionBLL();
        //    List<RulesVO> rulesVOs = new List<RulesVO>();
        //    rulesVOs = predictionBLL.generate_final_lrvgen(persKV, lkmv_gochar, false, new List<short>(), persKV.Language, "", false, false);
        //    RuleDAO ruleDAO = new RuleDAO();
        //    RuleBLL ruleBLL = new RuleBLL();
        //    short num = 0;
        //    int num1 = this.CalculateAgeCorrect(persKV.Dob, DateTime.Now);
        //    if ((num1 < 1 ? false : num1 <= 12))
        //    {
        //        rulesVOs = (
        //            from Map in rulesVOs
        //            where (Map.Shishu ? true : Map.Bachpan)
        //            select Map).ToList<RulesVO>();
        //    }
        //    if ((num1 < 13 ? false : num1 <= 20))
        //    {
        //        rulesVOs = (
        //            from Map in rulesVOs
        //            where Map.Kishor
        //            select Map).ToList<RulesVO>();
        //    }
        //    if ((num1 < 21 ? false : num1 <= 35))
        //    {
        //        rulesVOs = (
        //            from Map in rulesVOs
        //            where Map.Yuva
        //            select Map).ToList<RulesVO>();
        //    }
        //    if (num1 >= 36)
        //    {
        //        rulesVOs = (
        //            from Map in rulesVOs
        //            where (Map.Madhya ? true : Map.Budhapa)
        //            select Map).ToList<RulesVO>();
        //    }
        //    foreach (RulesVO list in (
        //        from Map in rulesVOs
        //        where Map.RuleType == "gochar"
        //        select Map).ToList<RulesVO>())
        //    {
        //        GocharVO gocharVO = new GocharVO();
        //        num = Convert.ToInt16(ruleBLL.GetPlanetByFormula(Convert.ToInt64(list.Ruleformula)).Sno);
        //        gocharVO = ruleDAO.Get_Gochar_By_Planet(Convert.ToInt16(num)).SingleOrDefault<GocharVO>();
        //        if (gocharVO != null)
        //        {
        //            string str1 = str;
        //            string[] codeLang = new string[] { str1, "\r\n\r\n", null, null, null, null, null };
        //            DateTime entrydate = gocharVO.Entrydate;
        //            codeLang[2] = entrydate.ToString("dd-MM-yyyy");
        //            codeLang[3] = " ";
        //            codeLang[4] = predictionBLL.GetCodeLang("to", persKV.Language, persKV.Paid);
        //            codeLang[5] = " ";
        //            entrydate = gocharVO.Exitdate;
        //            codeLang[6] = entrydate.ToString("dd-MM-yyyy");
        //            str = string.Concat(codeLang);
        //            str = string.Concat(str, "\r\n\r\n");
        //        }
        //        str = string.Concat(str, predictionBLL.Get_Pred_Text(list.Sno, persKV.Language, persKV.Male, true, persKV.ShowRef, false, persKV.Paid, false, false, persKV), "\r\n");
        //    }
        //    return str;
        //}

        //public string Get_Gochar_Pred(KundliVO persKV)
        //{
        //    long lagna = persKV.Lagna;
        //    long _sno = (long)0;
        //    string str = "";
        //    RuleDAO ruleDAO = new RuleDAO();
        //    AstroDAL astroDAL = new AstroDAL();
        //    List<long> nums = new List<long>();
        //    List<GocharVO> gocharVOs = new List<GocharVO>();
        //    gocharVOs = ruleDAO.Get_Gochar(Convert.ToInt16(lagna));
        //    foreach (GocharVO gocharVO in gocharVOs)
        //    {
        //        KundliMappingVO kundliMappingVO = new KundliMappingVO()
        //        {
        //            House = gocharVO.House,
        //            Planet = gocharVO.Planet,
        //            Rashi = gocharVO.Rashi,
        //            PlanetName = this.findplanet(gocharVO.Planet).Planetname
        //        };
        //        _sno = astroDAL.GetPlanetByName(kundliMappingVO.PlanetName.ToString()).get_sno();
        //        LagnaVO lagnaVO = (
        //            from al in ruleDAO.Get_Laganfal(Convert.ToInt16(lagna))
        //            where ((long)al.rashi != lagna || al.house != kundliMappingVO.House || (long)al.planet1 != _sno ? false : al.planet2 == 0)
        //            select al).FirstOrDefault<LagnaVO>();
        //        if (lagnaVO != null)
        //        {
        //            string str1 = str;
        //            string[] codeLang = new string[] { str1, "\r\n\r\n", null, null, null, null, null };
        //            DateTime entrydate = gocharVO.Entrydate;
        //            codeLang[2] = entrydate.ToString("dd-MM-yyyy");
        //            codeLang[3] = " ";
        //            codeLang[4] = this.GetCodeLang("to", persKV.Language, persKV.Paid);
        //            codeLang[5] = " ";
        //            entrydate = gocharVO.Exitdate;
        //            codeLang[6] = entrydate.ToString("dd-MM-yyyy");
        //            str = string.Concat(codeLang);
        //            str = string.Concat(str, "\r\n\r\n", lagnaVO.pred);
        //            if (persKV.ShowRef)
        //            {
        //                int num = lagnaVO.sno;
        //                str = string.Concat(str, num.ToString());
        //            }
        //        }
        //    }
        //    return str;
        //}

        //public string Get_Jeevan_Sandesh_Upay(long fakeupaycode, long upayno, long ruleno, KundliVO persKV, bool unicode)
        //{
        //    object obj;
        //    object[] codeLang;
        //    string str = "";
        //    unicode = false;
        //    UpayIndex upayIndex = new UpayIndex();
        //    RuleDAO ruleDAO = new RuleDAO();
        //    persKV.Product = "free jeevan sandesh";
        //    persKV.UpayCode = fakeupaycode.ToString();
        //    str = string.Concat(this.Get_Pred_Text(ruleno, persKV.Language, persKV.Male, true, false, false, true, true, false, persKV), "\r\n\r\n");
        //    upayIndex = ruleDAO.Get_UpayIndex(Convert.ToInt32(upayno));
        //    if (persKV.Language.ToLower() == "hindi")
        //    {
        //        obj = str;
        //        codeLang = new object[] { obj, this.GetCodeLang("aa", persKV.Language, persKV.Paid, unicode), " ", this.GetCodeLang("upay", persKV.Language, persKV.Paid, unicode), " ", fakeupaycode, " ", this.GetCodeLang("aa", persKV.Language, persKV.Paid, unicode), "\r\n", upayIndex.Hindi.Trim(), "\r\n\r\n" };
        //        str = string.Concat(codeLang);
        //    }
        //    if (persKV.Language.ToLower() == "marathi")
        //    {
        //        obj = str;
        //        codeLang = new object[] { obj, this.GetCodeLang("aa", persKV.Language, persKV.Paid, unicode), " ", this.GetCodeLang("upay", persKV.Language, persKV.Paid, unicode), " ", fakeupaycode, " ", this.GetCodeLang("aa", persKV.Language, persKV.Paid, unicode), "\r\n", upayIndex.Marathi.Trim(), "\r\n\r\n" };
        //        str = string.Concat(codeLang);
        //    }
        //    if (persKV.Language.ToLower() == "english")
        //    {
        //        obj = str;
        //        codeLang = new object[] { obj, this.GetCodeLang("aa", persKV.Language, persKV.Paid, unicode), " ", this.GetCodeLang("upay", persKV.Language, persKV.Paid, unicode), " ", fakeupaycode, " ", this.GetCodeLang("aa", persKV.Language, persKV.Paid, unicode), "\r\n", upayIndex.Eng.Trim(), "\r\n\r\n" };
        //        str = string.Concat(codeLang);
        //    }
        //    str = string.Concat(str, "\r\n\r\n", this.GetCodeLang("upayhelpbottom", persKV.Language, persKV.Paid, unicode), "\r\n");
        //    return str;
        //}

        public List<KPDashaVO> Get_List_35_Sala(string Online_Result, KundliVO persKV, DateTime dasha_starts, DateTime dasha_ends)
        {
            DateTime dob;
            KPBLL kPBLL = new KPBLL();
            List<KPDashaVO> kPDashaVOs = new List<KPDashaVO>();
            List<KPPlanetsVO> kPPlanetsVOs = kPBLL.Fill_Planets();
            List<KPPlanetMappingVO> kPPlanetMappingVOs = new List<KPPlanetMappingVO>();
            List<KPHouseMappingVO> kPHouseMappingVOs = new List<KPHouseMappingVO>();
            List<KPDashaVO> kPDashaVOs1 = new List<KPDashaVO>();
            KPDashaVO kPDashaVO = new KPDashaVO();
            kPBLL.Process_Planet_Lagan(Online_Result, ref kPPlanetMappingVOs, ref kPHouseMappingVOs, persKV.Rotate, true);
            DateTime dateTime = new DateTime();
            DateTime dateTime1 = new DateTime();
            Years35BLL years35BLL = new Years35BLL();
            short num = 0;
            List<Years35VO> years35VOs = years35BLL.Get35Years(persKV.JanamSamay);
            List<KP35SalaVO> kP35SalaVOs = new List<KP35SalaVO>();
            foreach (Years35VO years35VO in years35VOs)
            {
                dob = persKV.Dob;
                dateTime = dob.AddYears(Convert.ToInt16(num));
                dob = persKV.Dob;
                dob = dob.AddYears(Convert.ToInt16(years35VO.Years));
                dateTime1 = dob.AddDays(-1);
                num = Convert.ToInt16(years35VO.Years);
                string[] str = new string[] { dateTime.ToString("dd"), " ", this.GetCodeLang(string.Concat("M", dateTime.ToString("%M")), persKV.Language, persKV.Paid, true), " ", dateTime.ToString("yyyy") };
                string.Concat(str);
                str = new string[] { dateTime1.ToString("dd"), " ", this.GetCodeLang(string.Concat("M", dateTime1.ToString("%M")), persKV.Language, persKV.Paid, true), " ", dateTime1.ToString("yyyy") };
                string.Concat(str);
                if ((dateTime < dasha_starts ? false : dateTime <= dasha_ends))
                {
                    string[] strArrays = years35VO.Period.Split(new char[] { '/' });
                    for (int i = 0; i < (int)strArrays.Length; i++)
                    {
                        string str1 = strArrays[i];
                        KP35SalaVO kP35SalaVO = new KP35SalaVO()
                        {
                            Planet = (
                                from Map in kPPlanetsVOs
                                where Map.Roman == years35VO.Planet
                                select Map).FirstOrDefault<KPPlanetsVO>().Hindi,
                            Start_Date = dateTime,
                            End_Date = dateTime1,
                            Antar = (
                                from Map in kPPlanetsVOs
                                where Map.Roman == str1
                                select Map).FirstOrDefault<KPPlanetsVO>().Hindi,
                            Age = years35VO.Years.ToString()
                        };
                        kP35SalaVOs.Add(kP35SalaVO);
                    }
                }
            }
            string planet = "";
            string antar = "";
            foreach (KP35SalaVO kP35SalaVO1 in kP35SalaVOs)
            {
                if (planet != kP35SalaVO1.Planet)
                {
                    kPDashaVO = new KPDashaVO()
                    {
                        Planet = (
                            from Map in kPPlanetsVOs
                            where Map.Hindi == kP35SalaVO1.Planet
                            select Map).FirstOrDefault<KPPlanetsVO>().Planet,
                        Duration = "-",
                        Signi_String = kP35SalaVO1.Period
                    };
                    if (!(kP35SalaVO1.Age == (
                        from Map in kP35SalaVOs
                        where Map.Planet == kP35SalaVO1.Planet
                        select Map).LastOrDefault<KP35SalaVO>().Age))
                    {
                        kPDashaVO.Nak_Signi_String = string.Concat(kP35SalaVO1.Age, " - ", (
                            from Map in kP35SalaVOs
                            where Map.Planet == kP35SalaVO1.Planet
                            select Map).LastOrDefault<KP35SalaVO>().Age);
                        kPDashaVO.StartDate = kP35SalaVO1.Start_Date;
                        KPDashaVO kPDashaVO1 = kPDashaVO;
                        dob = persKV.Dob;
                        dob = dob.AddYears(Convert.ToInt16((
                            from Map in kP35SalaVOs
                            where Map.Planet == kP35SalaVO1.Planet
                            select Map).LastOrDefault<KP35SalaVO>().Age));
                        kPDashaVO1.EndDate = dob.AddDays(-1);
                    }
                    else
                    {
                        kPDashaVO.StartDate = kP35SalaVO1.Start_Date;
                        dob = persKV.Dob;
                        dob = dob.AddYears(Convert.ToInt16(kP35SalaVO1.Age));
                        kPDashaVO.EndDate = dob.AddDays(-1);
                        kPDashaVO.Nak_Signi_String = kP35SalaVO1.Age;
                    }
                    kPDashaVOs1.Add(kPDashaVO);
                    kPDashaVO = new KPDashaVO()
                    {
                        Planet = (
                            from Map in kPPlanetsVOs
                            where Map.Hindi == kP35SalaVO1.Planet
                            select Map).FirstOrDefault<KPPlanetsVO>().Planet,
                        Duration = kP35SalaVO1.Antar,
                        Signi_String = kP35SalaVO1.Period
                    };
                    if (!(kP35SalaVO1.Age == (
                        from Map in kP35SalaVOs
                        where (Map.Planet != kP35SalaVO1.Planet ? false : Map.Antar == kP35SalaVO1.Antar)
                        select Map).LastOrDefault<KP35SalaVO>().Age))
                    {
                        kPDashaVO.Nak_Signi_String = string.Concat(kP35SalaVO1.Age, " - ", (
                            from Map in kP35SalaVOs
                            where (Map.Planet != kP35SalaVO1.Planet ? false : Map.Antar == kP35SalaVO1.Antar)
                            select Map).LastOrDefault<KP35SalaVO>().Age);
                        kPDashaVO.StartDate = kP35SalaVO1.Start_Date;
                        KPDashaVO kPDashaVO2 = kPDashaVO;
                        dob = persKV.Dob;
                        dob = dob.AddYears(Convert.ToInt16((
                            from Map in kP35SalaVOs
                            where (Map.Planet != kP35SalaVO1.Planet ? false : Map.Antar == kP35SalaVO1.Antar)
                            select Map).LastOrDefault<KP35SalaVO>().Age));
                        kPDashaVO2.EndDate = dob.AddDays(-1);
                    }
                    else
                    {
                        kPDashaVO.Nak_Signi_String = kP35SalaVO1.Age;
                        kPDashaVO.StartDate = kP35SalaVO1.Start_Date;
                        dob = persKV.Dob;
                        dob = dob.AddYears(Convert.ToInt16(kP35SalaVO1.Age));
                        kPDashaVO.EndDate = dob.AddDays(-1);
                    }
                    kPDashaVOs1.Add(kPDashaVO);
                    antar = kP35SalaVO1.Antar;
                    planet = kP35SalaVO1.Planet;
                }
                else if (antar != kP35SalaVO1.Antar)
                {
                    kPDashaVO = new KPDashaVO()
                    {
                        Planet = (
                            from Map in kPPlanetsVOs
                            where Map.Hindi == kP35SalaVO1.Planet
                            select Map).FirstOrDefault<KPPlanetsVO>().Planet,
                        Duration = kP35SalaVO1.Antar,
                        Signi_String = kP35SalaVO1.Period
                    };
                    if (!(kP35SalaVO1.Age == (
                        from Map in kP35SalaVOs
                        where (Map.Planet != kP35SalaVO1.Planet ? false : Map.Antar == kP35SalaVO1.Antar)
                        select Map).LastOrDefault<KP35SalaVO>().Age))
                    {
                        kPDashaVO.Nak_Signi_String = string.Concat(kP35SalaVO1.Age, " - ", (
                            from Map in kP35SalaVOs
                            where (Map.Planet != kP35SalaVO1.Planet ? false : Map.Antar == kP35SalaVO1.Antar)
                            select Map).LastOrDefault<KP35SalaVO>().Age);
                        kPDashaVO.StartDate = kP35SalaVO1.Start_Date;
                        KPDashaVO kPDashaVO3 = kPDashaVO;
                        dob = persKV.Dob;
                        dob = dob.AddYears(Convert.ToInt16((
                            from Map in kP35SalaVOs
                            where (Map.Planet != kP35SalaVO1.Planet ? false : Map.Antar == kP35SalaVO1.Antar)
                            select Map).LastOrDefault<KP35SalaVO>().Age));
                        kPDashaVO3.EndDate = dob.AddDays(-1);
                    }
                    else
                    {
                        kPDashaVO.Nak_Signi_String = kP35SalaVO1.Age;
                        kPDashaVO.StartDate = kP35SalaVO1.Start_Date;
                        dob = persKV.Dob;
                        dob = dob.AddYears(Convert.ToInt16(kP35SalaVO1.Age));
                        kPDashaVO.EndDate = dob.AddDays(-1);
                    }
                    kPDashaVOs1.Add(kPDashaVO);
                    antar = kP35SalaVO1.Antar;
                }
            }
            return kPDashaVOs1;
        }

        public List<KPDashaVO> Get_List_35_Sala_For_CurrentAntar(string Online_Result, KundliVO persKV, DateTime dasha_starts, DateTime dasha_ends, ProductSettingsVO prod)
        {
            DateTime dob;
            KPBLL kPBLL = new KPBLL();
            List<KPDashaVO> kPDashaVOs = new List<KPDashaVO>();
            List<KPPlanetsVO> kPPlanetsVOs = kPBLL.Fill_Planets();
            List<KPPlanetMappingVO> kPPlanetMappingVOs = new List<KPPlanetMappingVO>();
            List<KPHouseMappingVO> kPHouseMappingVOs = new List<KPHouseMappingVO>();
            List<KPDashaVO> kPDashaVOs1 = new List<KPDashaVO>();
            KPDashaVO kPDashaVO = new KPDashaVO();
            kPBLL.Process_Planet_Lagan(Online_Result, ref kPPlanetMappingVOs, ref kPHouseMappingVOs, persKV.Rotate, true);
            DateTime dateTime = new DateTime();
            DateTime dateTime1 = new DateTime();
            Years35BLL years35BLL = new Years35BLL();
            short num = 0;
            List<Years35VO> years35VOs = years35BLL.Get35Years(persKV.JanamSamay);
            List<Years35VO> list = years35BLL.Get35Years(persKV.JanamSamay);
            List<KP35SalaVO> kP35SalaVOs = new List<KP35SalaVO>();
            short num1 = 0;
            list = (
                from Map in years35VOs
                where Map.Years >= (long)(persKV.Current_Age + 1)
                select Map).ToList<Years35VO>();
            num1 = Convert.ToInt16(list.FirstOrDefault<Years35VO>().Sno - (long)1);
            list = (
                from Map in years35VOs
                where Map.Sno >= (long)num1
                select Map).ToList<Years35VO>();
            years35VOs = list;
            num = Convert.ToInt16(years35VOs.FirstOrDefault<Years35VO>().Years - (long)1);
            foreach (Years35VO years35VO in years35VOs)
            {
                dob = persKV.Dob;
                dateTime = dob.AddYears(Convert.ToInt16(num));
                dob = persKV.Dob;
                dob = dob.AddYears(Convert.ToInt16(years35VO.Years));
                dateTime1 = dob.AddDays(-1);
                num = Convert.ToInt16(years35VO.Years);
                string[] str = new string[] { dateTime.ToString("dd"), " ", this.GetCodeLang(string.Concat("M", dateTime.ToString("%M")), persKV.Language, persKV.Paid, true), " ", dateTime.ToString("yyyy") };
                string.Concat(str);
                str = new string[] { dateTime1.ToString("dd"), " ", this.GetCodeLang(string.Concat("M", dateTime1.ToString("%M")), persKV.Language, persKV.Paid, true), " ", dateTime1.ToString("yyyy") };
                string.Concat(str);
                if (dateTime <= dasha_ends)
                {
                    string[] strArrays = years35VO.Period.Split(new char[] { '/' });
                    for (int i = 0; i < (int)strArrays.Length; i++)
                    {
                        string str1 = strArrays[i];
                        KP35SalaVO kP35SalaVO = new KP35SalaVO()
                        {
                            Planet = (
                                from Map in kPPlanetsVOs
                                where Map.Roman == years35VO.Planet
                                select Map).FirstOrDefault<KPPlanetsVO>().Hindi,
                            Start_Date = dateTime,
                            End_Date = dateTime1,
                            Antar = (
                                from Map in kPPlanetsVOs
                                where Map.Roman == str1
                                select Map).FirstOrDefault<KPPlanetsVO>().Hindi,
                            Age = years35VO.Years.ToString()
                        };
                        kP35SalaVOs.Add(kP35SalaVO);
                    }
                }
            }
            string planet = "";
            string antar = "";
            foreach (KP35SalaVO kP35SalaVO1 in kP35SalaVOs)
            {
                if (planet != kP35SalaVO1.Planet)
                {
                    kPDashaVO = new KPDashaVO()
                    {
                        Planet = (
                            from Map in kPPlanetsVOs
                            where Map.Hindi == kP35SalaVO1.Planet
                            select Map).FirstOrDefault<KPPlanetsVO>().Planet,
                        Duration = "-",
                        Signi_String = kP35SalaVO1.Period
                    };
                    if (!(kP35SalaVO1.Age == (
                        from Map in kP35SalaVOs
                        where Map.Planet == kP35SalaVO1.Planet
                        select Map).LastOrDefault<KP35SalaVO>().Age))
                    {
                        kPDashaVO.Nak_Signi_String = string.Concat(kP35SalaVO1.Age, " - ", (
                            from Map in kP35SalaVOs
                            where Map.Planet == kP35SalaVO1.Planet
                            select Map).LastOrDefault<KP35SalaVO>().Age);
                        kPDashaVO.StartDate = kP35SalaVO1.Start_Date;
                        KPDashaVO kPDashaVO1 = kPDashaVO;
                        dob = persKV.Dob;
                        dob = dob.AddYears(Convert.ToInt16((
                            from Map in kP35SalaVOs
                            where Map.Planet == kP35SalaVO1.Planet
                            select Map).LastOrDefault<KP35SalaVO>().Age));
                        kPDashaVO1.EndDate = dob.AddDays(-1);
                    }
                    else
                    {
                        kPDashaVO.StartDate = kP35SalaVO1.Start_Date;
                        dob = persKV.Dob;
                        dob = dob.AddYears(Convert.ToInt16(kP35SalaVO1.Age));
                        kPDashaVO.EndDate = dob.AddDays(-1);
                        kPDashaVO.Nak_Signi_String = kP35SalaVO1.Age;
                    }
                    kPDashaVOs1.Add(kPDashaVO);
                    kPDashaVO = new KPDashaVO()
                    {
                        Planet = (
                            from Map in kPPlanetsVOs
                            where Map.Hindi == kP35SalaVO1.Planet
                            select Map).FirstOrDefault<KPPlanetsVO>().Planet,
                        Duration = kP35SalaVO1.Antar,
                        Signi_String = kP35SalaVO1.Period
                    };
                    if (!(kP35SalaVO1.Age == (
                        from Map in kP35SalaVOs
                        where (Map.Planet != kP35SalaVO1.Planet ? false : Map.Antar == kP35SalaVO1.Antar)
                        select Map).LastOrDefault<KP35SalaVO>().Age))
                    {
                        kPDashaVO.Nak_Signi_String = string.Concat(kP35SalaVO1.Age, " - ", (
                            from Map in kP35SalaVOs
                            where (Map.Planet != kP35SalaVO1.Planet ? false : Map.Antar == kP35SalaVO1.Antar)
                            select Map).LastOrDefault<KP35SalaVO>().Age);
                        kPDashaVO.StartDate = kP35SalaVO1.Start_Date;
                        KPDashaVO kPDashaVO2 = kPDashaVO;
                        dob = persKV.Dob;
                        dob = dob.AddYears(Convert.ToInt16((
                            from Map in kP35SalaVOs
                            where (Map.Planet != kP35SalaVO1.Planet ? false : Map.Antar == kP35SalaVO1.Antar)
                            select Map).LastOrDefault<KP35SalaVO>().Age));
                        kPDashaVO2.EndDate = dob.AddDays(-1);
                    }
                    else
                    {
                        kPDashaVO.Nak_Signi_String = kP35SalaVO1.Age;
                        kPDashaVO.StartDate = kP35SalaVO1.Start_Date;
                        dob = persKV.Dob;
                        dob = dob.AddYears(Convert.ToInt16(kP35SalaVO1.Age));
                        kPDashaVO.EndDate = dob.AddDays(-1);
                    }
                    kPDashaVOs1.Add(kPDashaVO);
                    antar = kP35SalaVO1.Antar;
                    planet = kP35SalaVO1.Planet;
                }
                else if (antar != kP35SalaVO1.Antar)
                {
                    kPDashaVO = new KPDashaVO()
                    {
                        Planet = (
                            from Map in kPPlanetsVOs
                            where Map.Hindi == kP35SalaVO1.Planet
                            select Map).FirstOrDefault<KPPlanetsVO>().Planet,
                        Duration = kP35SalaVO1.Antar,
                        Signi_String = kP35SalaVO1.Period
                    };
                    if (!(kP35SalaVO1.Age == (
                        from Map in kP35SalaVOs
                        where (Map.Planet != kP35SalaVO1.Planet ? false : Map.Antar == kP35SalaVO1.Antar)
                        select Map).LastOrDefault<KP35SalaVO>().Age))
                    {
                        kPDashaVO.Nak_Signi_String = string.Concat(kP35SalaVO1.Age, " - ", (
                            from Map in kP35SalaVOs
                            where (Map.Planet != kP35SalaVO1.Planet ? false : Map.Antar == kP35SalaVO1.Antar)
                            select Map).LastOrDefault<KP35SalaVO>().Age);
                        kPDashaVO.StartDate = kP35SalaVO1.Start_Date;
                        KPDashaVO kPDashaVO3 = kPDashaVO;
                        dob = persKV.Dob;
                        dob = dob.AddYears(Convert.ToInt16((
                            from Map in kP35SalaVOs
                            where (Map.Planet != kP35SalaVO1.Planet ? false : Map.Antar == kP35SalaVO1.Antar)
                            select Map).LastOrDefault<KP35SalaVO>().Age));
                        kPDashaVO3.EndDate = dob.AddDays(-1);
                    }
                    else
                    {
                        kPDashaVO.Nak_Signi_String = kP35SalaVO1.Age;
                        kPDashaVO.StartDate = kP35SalaVO1.Start_Date;
                        dob = persKV.Dob;
                        dob = dob.AddYears(Convert.ToInt16(kP35SalaVO1.Age));
                        kPDashaVO.EndDate = dob.AddDays(-1);
                    }
                    kPDashaVOs1.Add(kPDashaVO);
                    antar = kP35SalaVO1.Antar;
                }
            }
            return kPDashaVOs1;
        }

        //public string Get_Mahadasha_HTML(string Online_Result, KundliVO persKV)
        //{
        //    List<KPDashaVO> kPDashaVOs = new List<KPDashaVO>();
        //    List<KPPlanetMappingVO> kPPlanetMappingVOs = new List<KPPlanetMappingVO>();
        //    List<KPHouseMappingVO> kPHouseMappingVOs = new List<KPHouseMappingVO>();
        //    List<KPDashaVO> dasha = new List<KPDashaVO>();
        //    KPBLL kPBLL = new KPBLL();
        //    kPBLL.Process_Planet_Lagan(Online_Result, ref kPPlanetMappingVOs, ref kPHouseMappingVOs, persKV.Rotate, true);
        //    dasha = kPBLL.Get_Dasha(kPHouseMappingVOs, kPPlanetMappingVOs, persKV, false);
        //    return kPBLL.Get_Dasha_HTML(dasha, persKV.Language);
        //}

        //public string get_mlife(KundliVO persKV, List<KundliMappingVO> lkmv)
        //{
        //    string str = "";
        //    KundliBLL kundliBLL = new KundliBLL();
        //    List<RulesVO> rulesVOs = new List<RulesVO>();
        //    List<RulesVO> list = new List<RulesVO>();
        //    bool flag = false;
        //    if (persKV.Sub_prodtype == "mobile")
        //    {
        //        flag = true;
        //    }
        //    for (short i = 1; i <= 9; i = (short)(i + 1))
        //    {
        //        KundliMappingVO kundliMappingVO = new KundliMappingVO();
        //        kundliMappingVO = (
        //            from Map in lkmv
        //            where Map.Planet == i
        //            select Map).SingleOrDefault<KundliMappingVO>();
        //        rulesVOs.AddRange((
        //            from Map in kundliBLL.GetAdvancePredictions(lkmv, kundliMappingVO.Planet, 0)
        //            where (Map.Isbad != kundliMappingVO.IsBad ? false : Map.RuleType == "mlife")
        //            select Map).ToList<RulesVO>());
        //    }
        //    list = rulesVOs;
        //    if (persKV.Male)
        //    {
        //        list = (
        //            from Map in list
        //            where (Map.Common ? true : Map.Male)
        //            select Map).ToList<RulesVO>();
        //    }
        //    if (!persKV.Male)
        //    {
        //        list = (
        //            from Map in list
        //            where (Map.Common ? true : Map.Female)
        //            select Map).ToList<RulesVO>();
        //    }
        //    str = string.Concat(str, this.GetCodeLang("headjeevan", persKV.Language, persKV.Paid, flag), "\r\n");
        //    foreach (RulesVO rulesVO in list)
        //    {
        //        str = string.Concat(str, this.Get_Pred_Text(rulesVO.Sno, persKV.Language, persKV.Male, true, persKV.ShowRef, false, true, false, flag, persKV), "\r\n");
        //    }
        //    str = string.Concat(str, "\r\n");
        //    return str;
        //}

        public string Get_Pred_Text(long sno, string lang, bool male, bool adult, bool showref, bool vfal, bool paid, bool add_upayno, bool unicode, KundliVO persKV)
        {
            string str;
            bool flag;
            string str1 = "\r\n";
            RuleDAO ruleDAO = new RuleDAO();
            LangVO langVO = new LangVO();
            RuleBLL ruleBLL = new RuleBLL();
            this.paidpred = paid;
            langVO = ruleDAO.Get_Lang(sno, lang, paid, unicode);
            try
            {
                str1 = (!adult ? string.Concat(str1, langVO.Child_Pred) : string.Concat(str1, langVO.Common_Pred));
                if (str1.Trim().Length > 0)
                {
                    if (showref)
                    {
                        str1 = string.Concat(str1, "   ", langVO.Rule_Number);
                    }
                }
            }
            catch (Exception exception)
            {
                _ = exception;
            }
            if ((this.paidpred ? true : paid))
            {
                RuleDAO ruleDAO1 = new RuleDAO();
                VfalUpayVO vfalUpayVO = new VfalUpayVO();
                VfalUpayVO vfalUpayVO1 = (
                    from Map in ruleDAO1.Get_VfalUpay()
                    where (long)Map.Ruleno1 == sno
                    select Map).FirstOrDefault<VfalUpayVO>();
                VfalUpayVO vfalUpayVO2 = (
                    from Map in ruleDAO1.Get_VfalUpay()
                    where (long)Map.Ruleno2 == sno
                    select Map).FirstOrDefault<VfalUpayVO>();
                lang = lang.ToLower();
                if (vfalUpayVO1 != null)
                {
                    str = lang;
                    if (str != null)
                    {
                        switch (str)
                        {
                            case "hindi":
                                {
                                    if (vfalUpayVO1.Hindi.Length >= 5)
                                    {
                                        str1 = string.Concat(str1, "\r\n\r\n", this.GetCodeLang("increase", lang, paid, unicode).ToString(), "\r\n\r\n");
                                        if (!adult)
                                        {
                                            str1 = (unicode ? string.Concat(str1, vfalUpayVO1.Child_Hindi_Unicode) : string.Concat(str1, vfalUpayVO1.Child_Hindi));
                                        }
                                        else
                                        {
                                            str1 = (unicode ? string.Concat(str1, vfalUpayVO1.Hindi_Unicode) : string.Concat(str1, vfalUpayVO1.Hindi));
                                        }
                                    }
                                    break;
                                }
                            case "english":
                                {
                                    if (vfalUpayVO1.Eng.Length >= 5)
                                    {
                                        str1 = string.Concat(str1, "\r\n\r\n", this.GetCodeLang("increase", lang, paid, unicode).ToString(), "\r\n\r\n");
                                        str1 = (!adult ? string.Concat(str1, vfalUpayVO1.Child_Eng) : string.Concat(str1, vfalUpayVO1.Eng));
                                    }
                                    break;
                                }
                            case "tamil":
                                {
                                    if (vfalUpayVO1.Tamil.Length >= 5)
                                    {
                                        str1 = string.Concat(str1, "\r\n\r\n", this.GetCodeLang("increase", lang, paid, unicode).ToString(), "\r\n\r\n");
                                        str1 = (!adult ? string.Concat(str1, vfalUpayVO1.Child_Tamil) : string.Concat(str1, vfalUpayVO1.Tamil));
                                    }
                                    break;
                                }
                            case "bangla":
                                {
                                    if (vfalUpayVO1.Bangla.Length >= 5)
                                    {
                                        str1 = string.Concat(str1, "\r\n\r\n", this.GetCodeLang("increase", lang, paid, unicode).ToString(), "\r\n\r\n");
                                        str1 = (!adult ? string.Concat(str1, vfalUpayVO1.Child_Bangla) : string.Concat(str1, vfalUpayVO1.Bangla));
                                    }
                                    break;
                                }
                            case "telugu":
                                {
                                    if (vfalUpayVO1.Telugu.Length >= 5)
                                    {
                                        str1 = string.Concat(str1, "\r\n\r\n", this.GetCodeLang("increase", lang, paid, unicode).ToString(), "\r\n\r\n");
                                        str1 = (!adult ? string.Concat(str1, vfalUpayVO1.Child_Telugu) : string.Concat(str1, vfalUpayVO1.Telugu));
                                    }
                                    break;
                                }
                            case "kannada":
                                {
                                    if (vfalUpayVO1.Kannada.Length >= 5)
                                    {
                                        str1 = string.Concat(str1, "\r\n\r\n", this.GetCodeLang("increase", lang, paid, unicode).ToString(), "\r\n\r\n");
                                        str1 = (!adult ? string.Concat(str1, vfalUpayVO1.Child_Kannada) : string.Concat(str1, vfalUpayVO1.Kannada));
                                    }
                                    break;
                                }
                            case "marathi":
                                {
                                    if (vfalUpayVO1.Marathi.Length >= 5)
                                    {
                                        str1 = string.Concat(str1, "\r\n\r\n", this.GetCodeLang("increase", lang, paid, unicode).ToString(), "\r\n\r\n");
                                        str1 = (!adult ? string.Concat(str1, vfalUpayVO1.Child_Marathi) : string.Concat(str1, vfalUpayVO1.Marathi));
                                    }
                                    break;
                                }
                            case "gujarati":
                                {
                                    if (vfalUpayVO1.Gujarati.Length >= 5)
                                    {
                                        str1 = string.Concat(str1, "\r\n\r\n", this.GetCodeLang("increase", lang, paid, unicode).ToString(), "\r\n\r\n");
                                        str1 = (!adult ? string.Concat(str1, vfalUpayVO1.Child_Gujarati) : string.Concat(str1, vfalUpayVO1.Gujarati));
                                    }
                                    break;
                                }
                            case "punjabi":
                                {
                                    if (vfalUpayVO1.Punjabi.Length >= 5)
                                    {
                                        str1 = string.Concat(str1, "\r\n\r\n", this.GetCodeLang("increase", lang, paid, unicode).ToString(), "\r\n\r\n");
                                        str1 = (!adult ? string.Concat(str1, vfalUpayVO1.Child_Punjabi) : string.Concat(str1, vfalUpayVO1.Punjabi));
                                    }
                                    break;
                                }
                        }
                    }
                }
                if (vfalUpayVO2 != null)
                {
                    str = lang;
                    if (str != null)
                    {
                        switch (str)
                        {
                            case "hindi":
                                {
                                    if (vfalUpayVO2.Hindi.Length >= 5)
                                    {
                                        str1 = string.Concat(str1, "\r\n\r\n", this.GetCodeLang("decrease", lang, paid, unicode).ToString(), "\r\n\r\n");
                                        if (!adult)
                                        {
                                            str1 = (unicode ? string.Concat(str1, vfalUpayVO2.Child_Hindi_Unicode) : string.Concat(str1, vfalUpayVO2.Child_Hindi));
                                        }
                                        else
                                        {
                                            str1 = (unicode ? string.Concat(str1, vfalUpayVO2.Hindi_Unicode) : string.Concat(str1, vfalUpayVO2.Hindi));
                                        }
                                    }
                                    break;
                                }
                            case "english":
                                {
                                    if (vfalUpayVO2.Eng.Length >= 5)
                                    {
                                        str1 = string.Concat(str1, "\r\n\r\n", this.GetCodeLang("decrease", lang, paid, unicode).ToString(), "\r\n\r\n");
                                        str1 = (!adult ? string.Concat(str1, vfalUpayVO2.Child_Eng) : string.Concat(str1, vfalUpayVO2.Eng));
                                    }
                                    break;
                                }
                            case "tamil":
                                {
                                    if (vfalUpayVO2.Tamil.Length >= 5)
                                    {
                                        str1 = string.Concat(str1, "\r\n\r\n", this.GetCodeLang("decrease", lang, paid, unicode).ToString(), "\r\n\r\n");
                                        str1 = string.Concat(str1, vfalUpayVO2.Tamil);
                                    }
                                    break;
                                }
                            case "bangla":
                                {
                                    if (vfalUpayVO2.Bangla.Length >= 5)
                                    {
                                        str1 = string.Concat(str1, "\r\n\r\n", this.GetCodeLang("decrease", lang, paid, unicode).ToString(), "\r\n\r\n");
                                        str1 = string.Concat(str1, vfalUpayVO2.Bangla);
                                    }
                                    break;
                                }
                            case "telugu":
                                {
                                    if (vfalUpayVO2.Telugu.Length >= 5)
                                    {
                                        str1 = string.Concat(str1, "\r\n\r\n", this.GetCodeLang("decrease", lang, paid, unicode).ToString(), "\r\n\r\n");
                                        str1 = string.Concat(str1, vfalUpayVO2.Telugu);
                                    }
                                    break;
                                }
                            case "kannada":
                                {
                                    if (vfalUpayVO2.Kannada.Length >= 5)
                                    {
                                        str1 = string.Concat(str1, "\r\n\r\n", this.GetCodeLang("decrease", lang, paid, unicode).ToString(), "\r\n\r\n");
                                        str1 = string.Concat(str1, vfalUpayVO2.Kannada);
                                    }
                                    break;
                                }
                            case "marathi":
                                {
                                    if (vfalUpayVO2.Marathi.Length >= 5)
                                    {
                                        str1 = string.Concat(str1, "\r\n\r\n", this.GetCodeLang("decrease", lang, paid, unicode).ToString(), "\r\n\r\n");
                                        str1 = string.Concat(str1, vfalUpayVO2.Marathi);
                                    }
                                    break;
                                }
                            case "gujarati":
                                {
                                    if (vfalUpayVO2.Gujarati.Length >= 5)
                                    {
                                        str1 = string.Concat(str1, "\r\n\r\n", this.GetCodeLang("decrease", lang, paid, unicode).ToString(), "\r\n\r\n");
                                        str1 = string.Concat(str1, vfalUpayVO2.Gujarati);
                                    }
                                    break;
                                }
                            case "punjabi":
                                {
                                    if (vfalUpayVO2.Punjabi.Length >= 5)
                                    {
                                        str1 = string.Concat(str1, "\r\n\r\n", this.GetCodeLang("decrease", lang, paid, unicode).ToString(), "\r\n\r\n");
                                        str1 = string.Concat(str1, vfalUpayVO2.Punjabi);
                                    }
                                    break;
                                }
                        }
                    }
                }
            }
            str1 = str1.TrimEnd(new char[0]);
            if (ruleBLL.GetAdvanceRuleById((long)langVO.Rule_Number).Memory)
            {
                string title = ruleBLL.GetAdvanceRuleById((long)langVO.Rule_Number).Title;
                if (title.Length >= 3)
                {
                    if (!this.all_Special_sno.Contains((long)langVO.Rule_Number))
                    {
                        this.all_Special_sno.Add((long)langVO.Rule_Number);
                        PredictionBLL predictionBLL = this;
                        predictionBLL.All_Special_List = string.Concat(predictionBLL.All_Special_List, title, "\r\n");
                    }
                }
            }
            if ((vfal || !paid ? false : add_upayno))
            {
                RulesVO rulesVO = new RulesVO();
                RuleDAO ruleDAO2 = new RuleDAO();
                rulesVO = ruleBLL.GetAdvanceRuleById(sno);
                if (rulesVO.Upay <= 0 || str1.Trim().Length <= 10)
                {
                    flag = true;
                }
                else
                {
                    flag = (lang.ToLower() == "bangla" || lang.ToLower() == "hindi" || lang.ToLower() == "marathi" ? false : !(lang.ToLower() == "english"));
                }
                if (!flag)
                {
                    if ((persKV.Product.ToLower() == "free jeevan sandesh" ? false : !(persKV.Product.ToLower() == "free jeevan sandesh full")))
                    {
                        UpayIndex upayIndex = new UpayIndex();
                        upayIndex = ruleDAO2.Get_UpayIndex(Convert.ToInt32(rulesVO.Upay));
                        if (upayIndex != null)
                        {
                            str1 = str1.TrimEnd(new char[0]);
                            object obj = str1;
                            object[] codeLang = new object[] { obj, " ", this.GetCodeLang("aa", lang.ToLower(), paid, unicode), " ", this.GetCodeLang("upay", lang, paid, unicode), " ", upayIndex.Sno, " ", this.GetCodeLang("aa", lang, paid, false), "\r\n" };
                            str1 = string.Concat(codeLang);
                            if (!this.all_upayindex_sno.Contains((long)upayIndex.Sno))
                            {
                                this.all_upayindex_sno.Add((long)upayIndex.Sno);
                            }
                        }
                    }
                    else
                    {
                        str1 = str1.TrimEnd(new char[0]);
                        string str2 = str1;
                        string[] strArrays = new string[] { str2, " ", this.GetCodeLang("aa", lang.ToLower(), paid, unicode), " ", this.GetCodeLang("upay", lang, paid, unicode), " ", persKV.UpayCode, " ", this.GetCodeLang("aa", lang, paid, false), "\r\n" };
                        str1 = string.Concat(strArrays);
                        this.all_upayindex_sno.Add(Convert.ToInt64(persKV.UpayCode));
                    }
                }
            }
            return str1;
        }

        //public string get_product(KundliVO persKV, List<KundliMappingVO> lkmv, List<short> years, bool normaltext, bool onlyvfal, string prodtype, bool showUpay)
        //{
        //    KPBLL kPBLL;
        //    List<KPPlanetMappingVO> kPPlanetMappingVOs;
        //    List<KPHouseMappingVO> kPHouseMappingVOs;
        //    PredictionBLL predictionBLL;
        //    //RulesVO rulesVO = null;
        //    List<short> nums;
        //    List<short> nums1;
        //    DateTime dateTime;
        //    DateTime today;
        //    short num;
        //    short num1;
        //    DateTime dateTime1;
        //    DateTime today1;
        //    short num2;
        //    short num3;
        //    short num4;
        //    short num5;
        //    DateTime dateTime2;
        //    int num6;
        //    int num7;
        //    string str;
        //    string str1;
        //    TimeSpan timeSpan;
        //    short num8;
        //    short num9;
        //    short i;
        //    Exception exception;
        //    string str2;
        //    string str3;
        //    string[] codeLang;
        //    DateTime startDate;
        //    char[] chrArray;
        //    int year;
        //    object obj;
        //    object[] fileCode;
        //    string str4 = "";
        //    string str5 = "";
        //    string str6 = "";
        //    string str7 = "";
        //    short num10 = 11;
        //    bool flag = false;
        //    string str8 = "";
        //    if (persKV.Sub_prodtype == "mobile")
        //    {
        //        flag = true;
        //    }
        //    if (prodtype == "Only Life")
        //    {
        //        if (persKV.Language.ToLower() == "hindi")
        //        {
        //            kPBLL = new KPBLL();
        //            kPPlanetMappingVOs = new List<KPPlanetMappingVO>();
        //            kPHouseMappingVOs = new List<KPHouseMappingVO>();
        //            ProductSettingsVO productSettingsVO = new ProductSettingsVO();
        //            kPBLL.Process_Planet_Lagan(persKV.Online_Result, ref kPPlanetMappingVOs, ref kPHouseMappingVOs, persKV.Rotate, false);
        //            kPPlanetMappingVOs = kPBLL.Process_KPChart_GoodBad(kPPlanetMappingVOs, persKV, productSettingsVO);
        //            str7 = string.Concat(str7, kPBLL.Get_Cusp_Pred(kPHouseMappingVOs, kPPlanetMappingVOs, persKV, false, persKV.ShowRef, false));
        //        }
        //        str7 = string.Concat(str7, "\r\n\r\n", this.GetCodeLang("lifehead", persKV.Language, persKV.Paid, flag), "\r\n");
        //        str7 = string.Concat(str7, this.OldLifePrediction(persKV, lkmv, lkmv, "", persKV.ShowRef, persKV.Male, persKV.Language));
        //    }
        //    if (prodtype.StartsWith("Mahadasha Fal"))
        //    {
        //        BasicruleBLL basicruleBLL = new BasicruleBLL();
        //        List<RulesVO> rulesVOs = new List<RulesVO>();
        //        string str9 = "";
        //        KundliBLL kundliBLL = new KundliBLL();
        //        List<KPDashaVO> kPDashaVOs = new List<KPDashaVO>();
        //        kPBLL = new KPBLL();
        //        PlanetBLL planetBLL = new PlanetBLL();
        //        kPPlanetMappingVOs = new List<KPPlanetMappingVO>();
        //        kPHouseMappingVOs = new List<KPHouseMappingVO>();
        //        predictionBLL = new PredictionBLL();
        //        ProductSettingsVO productSettingsVO1 = new ProductSettingsVO();
        //        kPBLL.Process_Planet_Lagan(persKV.Online_Result, ref kPPlanetMappingVOs, ref kPHouseMappingVOs, persKV.Rotate, false);
        //        kPPlanetMappingVOs = kPBLL.Process_KPChart_GoodBad(kPPlanetMappingVOs, persKV, productSettingsVO1);
        //        kPDashaVOs = kPBLL.Get_Dasha(kPHouseMappingVOs, kPPlanetMappingVOs, persKV, false);
        //        kPDashaVOs[0].StartDate = persKV.Dob;
        //        List<PlanetMAPVO> planetMAPVOs = planetBLL.FillAllPlanets();
        //        rulesVOs = this.generate_final_lrvgen(persKV, lkmv, false, new List<short>(), persKV.Language, "", false, false).ToList<RulesVO>();
        //        foreach (KPDashaVO kPDashaVO in kPDashaVOs)
        //        {
        //            short num11 = Convert.ToInt16((
        //                from Map in planetMAPVOs
        //                where Map.Mangal == (long)kPDashaVO.Planet
        //                select Map).SingleOrDefault<PlanetMAPVO>().NewAstro);
        //            short num12 = Convert.ToInt16((
        //                from Map in lkmv
        //                where Map.Planet == num11
        //                select Map).SingleOrDefault<KundliMappingVO>().House);
        //            short num13 = Convert.ToInt16(basicruleBLL.GetBasicRuleByHousePlanet(num12, num11).Sno);
        //            List<RulesVO> list = (
        //                from Map in rulesVOs
        //                where (Map.Mainplanet != num11 ? false : Map.Ruleformula.Contains(num13.ToString()))
        //                select Map).ToList<RulesVO>();
        //            str3 = str9;
        //            codeLang = new string[] { str3, this.GetCodeLang("day", persKV.Language, persKV.Paid, flag), " ", null, null, null, null, null };
        //            startDate = kPDashaVO.StartDate;
        //            codeLang[3] = startDate.ToString("dd");
        //            codeLang[4] = " ";
        //            startDate = kPDashaVO.StartDate;
        //            codeLang[5] = this.GetCodeLang(string.Concat("M", startDate.ToString("%M")), persKV.Language, persKV.Paid, flag);
        //            codeLang[6] = " ";
        //            startDate = kPDashaVO.StartDate;
        //            codeLang[7] = startDate.ToString("yyyy");
        //            str9 = string.Concat(codeLang);
        //            str9 = string.Concat(str9, " ", this.GetCodeLang("to", persKV.Language, persKV.Paid, flag), " ");
        //            str3 = str9;
        //            codeLang = new string[] { str3, null, null, null, null, null };
        //            startDate = kPDashaVO.EndDate;
        //            codeLang[1] = startDate.ToString("dd");
        //            codeLang[2] = " ";
        //            startDate = kPDashaVO.EndDate;
        //            codeLang[3] = this.GetCodeLang(string.Concat("M", startDate.ToString("%M")), persKV.Language, persKV.Paid, flag);
        //            codeLang[4] = " ";
        //            startDate = kPDashaVO.EndDate;
        //            codeLang[5] = startDate.ToString("yyyy");
        //            str9 = string.Concat(codeLang);
        //            str3 = str9;
        //            codeLang = new string[] { str3, " ", this.GetCodeLang("aa", persKV.Language, persKV.Paid, flag), " ", this.findplanet(num11).PlanetnameHindi, this.GetCodeLang("aa", persKV.Language, persKV.Paid, flag) };
        //            str9 = string.Concat(codeLang);
        //            str9 = string.Concat(str9, "\r\n----------------------------------------------------------------\r\n\r\n");
        //            foreach (RulesVO rulesVO1 in list)
        //            {
        //                str9 = string.Concat(str9, this.Get_Pred_Text(rulesVO1.Sno, persKV.Language, persKV.Male, true, persKV.ShowRef, false, true, true, flag, persKV), "\r\n\r\n");
        //            }
        //        }
        //        str9 = str9.Replace("\r\n\r\n\r\n", "\r\n\r\n");
        //        str9 = str9.Replace("\r\n\r\n\r\n\r\n", "\r\n\r\n");
        //        str2 = str9;
        //    }
        //    else if (prodtype.StartsWith("Tool"))
        //    {
        //        List<RulesVO> rulesVOs1 = new List<RulesVO>();
        //        KundliVO kundliVO = persKV;
        //        chrArray = new char[] { '#' };
        //        str7 = this.Lagnaengine_House(kundliVO, lkmv, Convert.ToInt16(prodtype.Split(chrArray)[1]));
        //        rulesVOs1 = this.generate_final_lrvgen(persKV, lkmv, false, new List<short>(), persKV.Language, "", false, false).ToList<RulesVO>();
        //        str7 = string.Concat(str7, "\r\n\r\n----------------------------------------------------------------\r\n\r\n");
        //        foreach (RulesVO rulesVO2 in
        //            from Map in rulesVOs1
        //            where Map.RuleType == "triangle"
        //            select Map)
        //        {
        //            str7 = string.Concat(str7, this.Get_Pred_Text(rulesVO2.Sno, persKV.Language, persKV.Male, true, persKV.ShowRef, false, true, true, flag, persKV), "\r\n\r\n");
        //        }
        //        str2 = str7;
        //    }
        //    else if (!(persKV.Language.ToLower() == "hindi" || persKV.Language.ToLower() == "english" ? !(prodtype.ToLower() == "free") : true))
        //    {
        //        persKV.Paid = false;
        //        nums = new List<short>();
        //        nums1 = new List<short>();
        //        dateTime = new DateTime(Convert.ToInt16(persKV.YY), Convert.ToInt16(persKV.MM), Convert.ToInt16(persKV.DD));
        //        today = DateTime.Today;
        //        num = 0;
        //        num1 = 0;
        //        num = Convert.ToInt16(this.CalculateAgeCorrect(dateTime, today));
        //        num1 = Convert.ToInt16(this.GetMonthsBetween(dateTime.AddYears(num), today));
        //        num1 = Convert.ToInt16(num1 + 1);
        //        num = Convert.ToInt16(num + 1);
        //        str7 = string.Concat(str7, this.get_mlife(persKV, lkmv));
        //        if (num1 <= 2)
        //        {
        //            nums1.Clear();
        //            nums1.Add(Convert.ToInt16(num - 1));
        //            str7 = string.Concat(str7, this.Get_varshfal(persKV, nums1, lkmv, new List<short>()));
        //            if (num1 == 2)
        //            {
        //                nums.Clear();
        //                nums.Add(12);
        //                num = Convert.ToInt16(num - 1);
        //                str7 = string.Concat(str7, "\r\n", this.GetMonthFal(persKV, lkmv, num, nums, persKV.ShowRef, true, persKV.Male, persKV.JanamSamay, persKV.Language, false));
        //                nums.Clear();
        //                nums.Add(1);
        //                nums.Add(2);
        //                nums.Add(3);
        //                num = Convert.ToInt16(num + 1);
        //                str7 = string.Concat(str7, "\r\n", this.GetMonthFal(persKV, lkmv, num, nums, persKV.ShowRef, true, persKV.Male, persKV.JanamSamay, persKV.Language, false));
        //            }
        //            if (num1 == 1)
        //            {
        //                nums.Clear();
        //                nums.Add(11);
        //                nums.Add(12);
        //                num = Convert.ToInt16(num - 1);
        //                str7 = string.Concat(str7, "\r\n", this.GetMonthFal(persKV, lkmv, num, nums, persKV.ShowRef, true, persKV.Male, persKV.JanamSamay, persKV.Language, false));
        //                nums.Clear();
        //                nums.Add(1);
        //                nums.Add(2);
        //                num = Convert.ToInt16(num + 1);
        //                str7 = string.Concat(str7, "\r\n", this.GetMonthFal(persKV, lkmv, num, nums, persKV.ShowRef, true, persKV.Male, persKV.JanamSamay, persKV.Language, false));
        //            }
        //        }
        //        else if (num1 == 12)
        //        {
        //            nums.Clear();
        //            nums.Add(Convert.ToInt16(num1 - 2));
        //            nums.Add(Convert.ToInt16(num1 - 1));
        //            nums.Add(Convert.ToInt16(num1));
        //            nums1.Clear();
        //            nums1.Add(Convert.ToInt16(num));
        //            str7 = string.Concat(str7, this.Get_varshfal(persKV, nums1, lkmv, new List<short>()));
        //            str7 = string.Concat(str7, "\r\n", this.GetMonthFal(persKV, lkmv, num, nums, persKV.ShowRef, true, persKV.Male, persKV.JanamSamay, persKV.Language, false));
        //            nums.Clear();
        //            nums.Add(Convert.ToInt16(1));
        //            num = Convert.ToInt16(num + 1);
        //            str7 = string.Concat(str7, "\r\n", this.GetMonthFal(persKV, lkmv, num, nums, persKV.ShowRef, true, persKV.Male, persKV.JanamSamay, persKV.Language, false));
        //        }
        //        else
        //        {
        //            nums.Clear();
        //            nums.Add(Convert.ToInt16(num1 - 2));
        //            nums.Add(Convert.ToInt16(num1 - 1));
        //            nums.Add(Convert.ToInt16(num1));
        //            nums.Add(Convert.ToInt16(num1 + 1));
        //            nums1.Clear();
        //            nums1.Add(Convert.ToInt16(num));
        //            str7 = string.Concat(str7, this.Get_varshfal(persKV, nums1, lkmv, new List<short>()));
        //            str7 = string.Concat(str7, "\r\n", this.GetMonthFal(persKV, lkmv, num, nums, persKV.ShowRef, true, persKV.Male, persKV.JanamSamay, persKV.Language, false));
        //        }
        //        str2 = str7;
        //    }
        //    else if (prodtype == "This Year")
        //    {
        //        str7 = "";
        //        predictionBLL = new PredictionBLL();
        //        startDate = DateTime.Now;
        //        short num14 = Convert.ToInt16(startDate.ToString("yyyy"));
        //        startDate = DateTime.Now;
        //        short num15 = Convert.ToInt16(startDate.ToString("MM"));
        //        startDate = DateTime.Now;
        //        dateTime1 = new DateTime(num14, num15, Convert.ToInt16(startDate.ToString("dd")));
        //        startDate = DateTime.Now;
        //        short num16 = Convert.ToInt16(startDate.ToString("yyyy"));
        //        startDate = DateTime.Now;
        //        short num17 = Convert.ToInt16(startDate.ToString("MM"));
        //        startDate = DateTime.Now;
        //        today1 = new DateTime(num16, num17, Convert.ToInt16(startDate.ToString("dd")));
        //        num2 = 0;
        //        dateTime = new DateTime(Convert.ToInt16(persKV.YY), Convert.ToInt16(persKV.MM), Convert.ToInt16(persKV.DD));
        //        num2 = Convert.ToInt16(this.CalculateAgeCorrect(dateTime, today1) + 1);
        //        nums1 = new List<short>();
        //        num = num2;
        //        nums1.Add(num2);
        //        str7 = string.Concat(str7, this.Get_varshfal(persKV, nums1, lkmv, new List<short>()));
        //        str2 = str7;
        //    }
        //    else if (prodtype == "This Month")
        //    {
        //        str7 = "";
        //        predictionBLL = new PredictionBLL();
        //        startDate = DateTime.Now;
        //        short num18 = Convert.ToInt16(startDate.ToString("yyyy"));
        //        startDate = DateTime.Now;
        //        short num19 = Convert.ToInt16(startDate.ToString("MM"));
        //        startDate = DateTime.Now;
        //        dateTime1 = new DateTime(num18, num19, Convert.ToInt16(startDate.ToString("dd")));
        //        startDate = DateTime.Now;
        //        short num20 = Convert.ToInt16(startDate.ToString("yyyy"));
        //        startDate = DateTime.Now;
        //        short num21 = Convert.ToInt16(startDate.ToString("MM"));
        //        startDate = DateTime.Now;
        //        today1 = new DateTime(num20, num21, Convert.ToInt16(startDate.ToString("dd")));
        //        num2 = 0;
        //        num3 = 0;
        //        dateTime = new DateTime(Convert.ToInt16(persKV.YY), Convert.ToInt16(persKV.MM), Convert.ToInt16(persKV.DD));
        //        num2 = Convert.ToInt16(this.CalculateAgeCorrect(dateTime, today1) + 1);
        //        num3 = Convert.ToInt16(this.GetMonthsBetween(dateTime.AddYears(num2 - 1), today1));
        //        num3 = Convert.ToInt16(num3 + 1);
        //        nums = new List<short>();
        //        num = num2;
        //        nums.Add(num3);
        //        str7 = string.Concat(str7, this.GetMonthFal(persKV, lkmv, num, nums, persKV.ShowRef, true, persKV.Male, persKV.JanamSamay, persKV.Language, persKV.Paid));
        //        str2 = str7;
        //    }
        //    else if (prodtype == "This Week")
        //    {
        //        str7 = "";
        //        predictionBLL = new PredictionBLL();
        //        dateTime1 = new DateTime(Convert.ToInt16(persKV.WYY), Convert.ToInt16(Convert.ToInt16(persKV.WMM)), Convert.ToInt16(Convert.ToInt16(persKV.WDD)));
        //        today1 = new DateTime(Convert.ToInt16(persKV.WYY), Convert.ToInt16(Convert.ToInt16(persKV.WMM)), Convert.ToInt16(Convert.ToInt16(persKV.WDD)));
        //        DateTime dateTime3 = new DateTime(Convert.ToInt16(persKV.WYY), Convert.ToInt16(Convert.ToInt16(persKV.WMM)), Convert.ToInt16(Convert.ToInt16(persKV.WDD)));
        //        num2 = 0;
        //        num3 = 0;
        //        num4 = 0;
        //        num5 = 0;
        //        dateTime = new DateTime(Convert.ToInt16(persKV.YY), Convert.ToInt16(persKV.MM), Convert.ToInt16(persKV.DD));
        //        str3 = str7;
        //        codeLang = new string[] { str3, "\r\n\r\n", predictionBLL.GetCodeLang("aa", persKV.Language, persKV.Paid, flag), " ", predictionBLL.GetCodeLang("saptahik", persKV.Language, persKV.Paid, flag), " ", predictionBLL.GetCodeLang("aa", persKV.Language, persKV.Paid, flag) };
        //        str7 = string.Concat(codeLang);
        //        num2 = Convert.ToInt16(this.CalculateAgeCorrect(dateTime, today1) + 1);
        //        num3 = Convert.ToInt16(this.GetMonthsBetween(dateTime.AddYears(num2 - 1), today1));
        //        num3 = Convert.ToInt16(num3 + 1);
        //        dateTime2 = new DateTime();
        //        num6 = DateTime.DaysInMonth(today1.Year, today1.Month);
        //        startDate = today1.AddMonths(-1);
        //        int year1 = startDate.Year;
        //        startDate = today1.AddMonths(-1);
        //        num7 = DateTime.DaysInMonth(year1, startDate.Month);
        //        str = "";
        //        str1 = "";
        //        if (num6 < Convert.ToInt32(dateTime.ToString("dd")))
        //        {
        //            year = today1.Year;
        //            str = string.Concat(year.ToString(), "-", today1.ToString("MM"), "-01");
        //        }
        //        else
        //        {
        //            codeLang = new string[5];
        //            year = today1.Year;
        //            codeLang[0] = year.ToString();
        //            codeLang[1] = "-";
        //            codeLang[2] = today1.ToString("MM");
        //            codeLang[3] = "-";
        //            codeLang[4] = dateTime.ToString("dd");
        //            str = string.Concat(codeLang);
        //        }
        //        if (num7 < Convert.ToInt32(dateTime.ToString("dd")))
        //        {
        //            year = today1.Year;
        //            str1 = string.Concat(year.ToString(), "-", today1.ToString("MM"), "-01");
        //        }
        //        else
        //        {
        //            codeLang = new string[5];
        //            year = today1.Year;
        //            codeLang[0] = year.ToString();
        //            codeLang[1] = "-";
        //            startDate = today1.AddMonths(-1);
        //            codeLang[2] = startDate.ToString("MM");
        //            codeLang[3] = "-";
        //            codeLang[4] = dateTime.ToString("dd");
        //            str1 = string.Concat(codeLang);
        //        }
        //        dateTime2 = (today1.Day >= Convert.ToInt16(persKV.DD) ? DateTime.ParseExact(str, "yyyy-MM-dd", null) : DateTime.ParseExact(str1, "yyyy-MM-dd", null));
        //        timeSpan = today1 - dateTime2;
        //        if (timeSpan.Days <= 0)
        //        {
        //            num5 = 1;
        //        }
        //        else
        //        {
        //            num5 = Convert.ToInt16(timeSpan.Days + 1);
        //        }
        //        //num8 = Convert.ToInt16(Math.Floor(Convert.ToDecimal(num5 / 7))++);
        //        num8 = Convert.ToInt16(Math.Floor(Convert.ToDecimal(num5 / 7)) + 1);
        //        if ((num8 <= 0 ? true : num5 <= 7))
        //        {
        //            num8 = 1;
        //        }
        //        if (num5 % 7 == 0)
        //        {
        //            num8 = (short)(num8 - 1);
        //        }
        //        num4 = num8;
        //        today1 = dateTime2.AddDays((double)((num8 - 1) * 7));
        //        str7 = string.Concat(str7, predictionBLL.GetWeekFal(persKV, lkmv, num2, num3, num4, persKV.ShowRef, true, persKV.Male, persKV.JanamSamay, persKV.Language, persKV.Paid, dateTime3));
        //        str2 = str7;
        //    }
        //    else if (prodtype.StartsWith("Daily"))
        //    {
        //        str7 = "";
        //        predictionBLL = new PredictionBLL();
        //        num9 = 0;
        //        dateTime1 = new DateTime(Convert.ToInt16(persKV.WYY), Convert.ToInt16(Convert.ToInt16(persKV.WMM)), Convert.ToInt16(Convert.ToInt16(persKV.WDD)));
        //        today1 = new DateTime(Convert.ToInt16(persKV.WYY), Convert.ToInt16(Convert.ToInt16(persKV.WMM)), Convert.ToInt16(Convert.ToInt16(persKV.WDD)));
        //        dateTime1 = dateTime1.AddDays((double)num9);
        //        today1 = today1.AddDays((double)num9);
        //        num2 = 0;
        //        num3 = 0;
        //        num4 = 0;
        //        num5 = 0;
        //        dateTime = new DateTime(Convert.ToInt16(persKV.YY), Convert.ToInt16(persKV.MM), Convert.ToInt16(persKV.DD));
        //        str3 = str7;
        //        codeLang = new string[] { str3, "\r\n\r\n", predictionBLL.GetCodeLang("aa", persKV.Language, persKV.Paid, flag), " ", predictionBLL.GetCodeLang("dainik", persKV.Language, persKV.Paid, flag), " ", predictionBLL.GetCodeLang("aa", persKV.Language, persKV.Paid, flag) };
        //        str7 = string.Concat(codeLang);
        //        num2 = Convert.ToInt16(this.CalculateAgeCorrect(dateTime, today1) + 1);
        //        num3 = Convert.ToInt16(this.GetMonthsBetween(dateTime.AddYears(num2 - 1), today1));
        //        num3 = Convert.ToInt16(num3 + 1);
        //        dateTime2 = new DateTime();
        //        num6 = DateTime.DaysInMonth(today1.Year, today1.Month);
        //        startDate = today1.AddMonths(-1);
        //        int year2 = startDate.Year;
        //        startDate = today1.AddMonths(-1);
        //        num7 = DateTime.DaysInMonth(year2, startDate.Month);
        //        str = "";
        //        str1 = "";
        //        if (num6 < Convert.ToInt32(dateTime.ToString("dd")))
        //        {
        //            year = today1.Year;
        //            str = string.Concat(year.ToString(), "-", today1.ToString("MM"), "-01");
        //        }
        //        else
        //        {
        //            codeLang = new string[5];
        //            year = today1.Year;
        //            codeLang[0] = year.ToString();
        //            codeLang[1] = "-";
        //            codeLang[2] = today1.ToString("MM");
        //            codeLang[3] = "-";
        //            codeLang[4] = dateTime.ToString("dd");
        //            str = string.Concat(codeLang);
        //        }
        //        if (num7 < Convert.ToInt32(dateTime.ToString("dd")))
        //        {
        //            year = today1.Year;
        //            str1 = string.Concat(year.ToString(), "-", today1.ToString("MM"), "-01");
        //        }
        //        else
        //        {
        //            codeLang = new string[5];
        //            year = today1.Year;
        //            codeLang[0] = year.ToString();
        //            codeLang[1] = "-";
        //            startDate = today1.AddMonths(-1);
        //            codeLang[2] = startDate.ToString("MM");
        //            codeLang[3] = "-";
        //            codeLang[4] = dateTime.ToString("dd");
        //            str1 = string.Concat(codeLang);
        //        }
        //        dateTime2 = (today1.Day >= Convert.ToInt16(persKV.DD) ? DateTime.ParseExact(str, "yyyy-MM-dd", null) : DateTime.ParseExact(str1, "yyyy-MM-dd", null));
        //        timeSpan = today1 - dateTime2;
        //        if (timeSpan.Days <= 0)
        //        {
        //            num5 = 1;
        //        }
        //        else
        //        {
        //            num5 = Convert.ToInt16(timeSpan.Days + 1);
        //        }
        //        //num8 = Convert.ToInt16(Math.Floor(Convert.ToDecimal(num5 / 7))++);
        //        num8 = Convert.ToInt16(Math.Floor(Convert.ToDecimal(num5 / 7)) + 1);
        //        if ((num8 <= 0 ? true : num5 <= 7))
        //        {
        //            num8 = 1;
        //        }
        //        if (num5 % 7 == 0)
        //        {
        //            num8 = (short)(num8 - 1);
        //        }
        //        num4 = num8;
        //        today1 = dateTime2.AddDays((double)((num8 - 1) * 7));
        //        KundliBLL kundliBLL1 = new KundliBLL();
        //        str7 = string.Concat(str7, "\r\n\r\n", predictionBLL.GetCodeLang("Aries", persKV.Language, true, true));
        //        str7 = string.Concat(str7, predictionBLL.GetDayFal(persKV, lkmv, num2, num3, num5, persKV.ShowRef, true, persKV.Male, persKV.JanamSamay, persKV.Language, false, dateTime1));
        //        lkmv = kundliBLL1.RotateKundliMappings(lkmv, 1, persKV);
        //        str7 = string.Concat(str7, "\r\n\r\n", predictionBLL.GetCodeLang("Taurus", persKV.Language, true, true));
        //        str7 = string.Concat(str7, predictionBLL.GetDayFal(persKV, lkmv, num2, num3, num5, persKV.ShowRef, true, persKV.Male, persKV.JanamSamay, persKV.Language, false, dateTime1));
        //        lkmv = kundliBLL1.RotateKundliMappings(lkmv, 1, persKV);
        //        str7 = string.Concat(str7, "\r\n\r\n", predictionBLL.GetCodeLang("Gemini", persKV.Language, true, true));
        //        str7 = string.Concat(str7, predictionBLL.GetDayFal(persKV, lkmv, num2, num3, num5, persKV.ShowRef, true, persKV.Male, persKV.JanamSamay, persKV.Language, false, dateTime1));
        //        lkmv = kundliBLL1.RotateKundliMappings(lkmv, 1, persKV);
        //        str7 = string.Concat(str7, "\r\n\r\n", predictionBLL.GetCodeLang("Cancer", persKV.Language, true, true));
        //        str7 = string.Concat(str7, predictionBLL.GetDayFal(persKV, lkmv, num2, num3, num5, persKV.ShowRef, true, persKV.Male, persKV.JanamSamay, persKV.Language, false, dateTime1));
        //        lkmv = kundliBLL1.RotateKundliMappings(lkmv, 1, persKV);
        //        str7 = string.Concat(str7, "\r\n\r\n", predictionBLL.GetCodeLang("Leo", persKV.Language, true, true));
        //        str7 = string.Concat(str7, predictionBLL.GetDayFal(persKV, lkmv, num2, num3, num5, persKV.ShowRef, true, persKV.Male, persKV.JanamSamay, persKV.Language, false, dateTime1));
        //        lkmv = kundliBLL1.RotateKundliMappings(lkmv, 1, persKV);
        //        str7 = string.Concat(str7, "\r\n\r\n", predictionBLL.GetCodeLang("Virgo", persKV.Language, true, true));
        //        str7 = string.Concat(str7, predictionBLL.GetDayFal(persKV, lkmv, num2, num3, num5, persKV.ShowRef, true, persKV.Male, persKV.JanamSamay, persKV.Language, false, dateTime1));
        //        lkmv = kundliBLL1.RotateKundliMappings(lkmv, 1, persKV);
        //        str7 = string.Concat(str7, "\r\n\r\n", predictionBLL.GetCodeLang("Libra", persKV.Language, true, true));
        //        str7 = string.Concat(str7, predictionBLL.GetDayFal(persKV, lkmv, num2, num3, num5, persKV.ShowRef, true, persKV.Male, persKV.JanamSamay, persKV.Language, false, dateTime1));
        //        lkmv = kundliBLL1.RotateKundliMappings(lkmv, 1, persKV);
        //        str7 = string.Concat(str7, "\r\n\r\n", predictionBLL.GetCodeLang("Scorpio", persKV.Language, true, true));
        //        str7 = string.Concat(str7, predictionBLL.GetDayFal(persKV, lkmv, num2, num3, num5, persKV.ShowRef, true, persKV.Male, persKV.JanamSamay, persKV.Language, false, dateTime1));
        //        lkmv = kundliBLL1.RotateKundliMappings(lkmv, 1, persKV);
        //        str7 = string.Concat(str7, "\r\n\r\n", predictionBLL.GetCodeLang("Sagittarius", persKV.Language, true, true));
        //        str7 = string.Concat(str7, predictionBLL.GetDayFal(persKV, lkmv, num2, num3, num5, persKV.ShowRef, true, persKV.Male, persKV.JanamSamay, persKV.Language, false, dateTime1));
        //        lkmv = kundliBLL1.RotateKundliMappings(lkmv, 1, persKV);
        //        str7 = string.Concat(str7, "\r\n\r\n", predictionBLL.GetCodeLang("Capricorn", persKV.Language, true, true));
        //        str7 = string.Concat(str7, predictionBLL.GetDayFal(persKV, lkmv, num2, num3, num5, persKV.ShowRef, true, persKV.Male, persKV.JanamSamay, persKV.Language, false, dateTime1));
        //        lkmv = kundliBLL1.RotateKundliMappings(lkmv, 1, persKV);
        //        str7 = string.Concat(str7, "\r\n\r\n", predictionBLL.GetCodeLang("Aquarius", persKV.Language, true, true));
        //        str7 = string.Concat(str7, predictionBLL.GetDayFal(persKV, lkmv, num2, num3, num5, persKV.ShowRef, true, persKV.Male, persKV.JanamSamay, persKV.Language, false, dateTime1));
        //        lkmv = kundliBLL1.RotateKundliMappings(lkmv, 1, persKV);
        //        str7 = string.Concat(str7, "\r\n\r\n", predictionBLL.GetCodeLang("Pisces", persKV.Language, true, true));
        //        str7 = string.Concat(str7, predictionBLL.GetDayFal(persKV, lkmv, num2, num3, num5, persKV.ShowRef, true, persKV.Male, persKV.JanamSamay, persKV.Language, false, dateTime1));
        //        str2 = str7;
        //    }
        //    else if (prodtype.StartsWith("Today"))
        //    {
        //        str7 = "";
        //        predictionBLL = new PredictionBLL();
        //        num9 = 0;
        //        num9 = (!prodtype.StartsWith("Today-1") ? Convert.ToInt16(prodtype.Substring(5, 1)) : Convert.ToInt16(prodtype.Substring(5, 2)));
        //        dateTime1 = new DateTime(Convert.ToInt16(persKV.WYY), Convert.ToInt16(Convert.ToInt16(persKV.WMM)), Convert.ToInt16(Convert.ToInt16(persKV.WDD)));
        //        today1 = new DateTime(Convert.ToInt16(persKV.WYY), Convert.ToInt16(Convert.ToInt16(persKV.WMM)), Convert.ToInt16(Convert.ToInt16(persKV.WDD)));
        //        dateTime1 = dateTime1.AddDays((double)num9);
        //        today1 = today1.AddDays((double)num9);
        //        num2 = 0;
        //        num3 = 0;
        //        num4 = 0;
        //        num5 = 0;
        //        dateTime = new DateTime(Convert.ToInt16(persKV.YY), Convert.ToInt16(persKV.MM), Convert.ToInt16(persKV.DD));
        //        str3 = str7;
        //        codeLang = new string[] { str3, "\r\n\r\n", predictionBLL.GetCodeLang("aa", persKV.Language, persKV.Paid, flag), " ", predictionBLL.GetCodeLang("dainik", persKV.Language, persKV.Paid, flag), " ", predictionBLL.GetCodeLang("aa", persKV.Language, persKV.Paid, flag) };
        //        str7 = string.Concat(codeLang);
        //        num2 = Convert.ToInt16(this.CalculateAgeCorrect(dateTime, today1) + 1);
        //        num3 = Convert.ToInt16(this.GetMonthsBetween(dateTime.AddYears(num2 - 1), today1));
        //        num3 = Convert.ToInt16(num3 + 1);
        //        dateTime2 = new DateTime();
        //        num6 = DateTime.DaysInMonth(today1.Year, today1.Month);
        //        startDate = today1.AddMonths(-1);
        //        int year3 = startDate.Year;
        //        startDate = today1.AddMonths(-1);
        //        num7 = DateTime.DaysInMonth(year3, startDate.Month);
        //        str = "";
        //        str1 = "";
        //        if (num6 < Convert.ToInt32(dateTime.ToString("dd")))
        //        {
        //            year = today1.Year;
        //            str = string.Concat(year.ToString(), "-", today1.ToString("MM"), "-01");
        //        }
        //        else
        //        {
        //            codeLang = new string[5];
        //            year = today1.Year;
        //            codeLang[0] = year.ToString();
        //            codeLang[1] = "-";
        //            codeLang[2] = today1.ToString("MM");
        //            codeLang[3] = "-";
        //            codeLang[4] = dateTime.ToString("dd");
        //            str = string.Concat(codeLang);
        //        }
        //        if (num7 < Convert.ToInt32(dateTime.ToString("dd")))
        //        {
        //            year = today1.Year;
        //            str1 = string.Concat(year.ToString(), "-", today1.ToString("MM"), "-01");
        //        }
        //        else
        //        {
        //            codeLang = new string[5];
        //            year = today1.Year;
        //            codeLang[0] = year.ToString();
        //            codeLang[1] = "-";
        //            startDate = today1.AddMonths(-1);
        //            codeLang[2] = startDate.ToString("MM");
        //            codeLang[3] = "-";
        //            codeLang[4] = dateTime.ToString("dd");
        //            str1 = string.Concat(codeLang);
        //        }
        //        dateTime2 = (today1.Day >= Convert.ToInt16(persKV.DD) ? DateTime.ParseExact(str, "yyyy-MM-dd", null) : DateTime.ParseExact(str1, "yyyy-MM-dd", null));
        //        timeSpan = today1 - dateTime2;
        //        if (timeSpan.Days <= 0)
        //        {
        //            num5 = 1;
        //        }
        //        else
        //        {
        //            num5 = Convert.ToInt16(timeSpan.Days + 1);
        //        }
        //        num8 = Convert.ToInt16(Math.Floor(Convert.ToDecimal(num5 / 7)) + 1);
        //        //num8 = Convert.ToInt16(Math.Floor(Convert.ToDecimal(num5 / 7))++);
        //        if ((num8 <= 0 ? true : num5 <= 7))
        //        {
        //            num8 = 1;
        //        }
        //        if (num5 % 7 == 0)
        //        {
        //            num8 = (short)(num8 - 1);
        //        }
        //        num4 = num8;
        //        today1 = dateTime2.AddDays((double)((num8 - 1) * 7));
        //        str7 = string.Concat(str7, predictionBLL.GetDayFal(persKV, lkmv, num2, num3, num5, persKV.ShowRef, true, persKV.Male, persKV.JanamSamay, persKV.Language, false, dateTime1));
        //        str2 = str7;
        //    }
        //    else if (prodtype == "1 Year (Daily/Weekly)")
        //    {
        //        str7 = "";
        //        predictionBLL = new PredictionBLL();
        //        dateTime1 = DateTime.Today;
        //        today1 = DateTime.Today;
        //        num2 = 0;
        //        num3 = 0;
        //        num4 = 0;
        //        num5 = 0;
        //        dateTime = new DateTime(Convert.ToInt16(persKV.YY), Convert.ToInt16(persKV.MM), Convert.ToInt16(persKV.DD));
        //        str3 = str7;
        //        codeLang = new string[] { str3, "\r\n", predictionBLL.GetCodeLang("aa", persKV.Language, persKV.Paid), " ", predictionBLL.GetCodeLang("dainik", persKV.Language, persKV.Paid), " ", predictionBLL.GetCodeLang("aa", persKV.Language, persKV.Paid) };
        //        str7 = string.Concat(codeLang);
        //        for (i = 1; i <= 365; i = (short)(i + 1))
        //        {
        //            num2 = Convert.ToInt16(this.CalculateAgeCorrect(dateTime, dateTime1) + 1);
        //            num3 = Convert.ToInt16(this.GetMonthsBetween(dateTime.AddYears(num2 - 1), dateTime1));
        //            num3 = Convert.ToInt16(num3 + 1);
        //            dateTime2 = new DateTime();
        //            num6 = DateTime.DaysInMonth(dateTime1.Year, dateTime1.Month);
        //            startDate = dateTime1.AddMonths(-1);
        //            int year4 = startDate.Year;
        //            startDate = dateTime1.AddMonths(-1);
        //            num7 = DateTime.DaysInMonth(year4, startDate.Month);
        //            str = "";
        //            str1 = "";
        //            if (num6 < Convert.ToInt32(dateTime.ToString("dd")))
        //            {
        //                year = dateTime1.Year;
        //                str = string.Concat(year.ToString(), "-", dateTime1.ToString("MM"), "-01");
        //            }
        //            else
        //            {
        //                codeLang = new string[5];
        //                year = dateTime1.Year;
        //                codeLang[0] = year.ToString();
        //                codeLang[1] = "-";
        //                codeLang[2] = dateTime1.ToString("MM");
        //                codeLang[3] = "-";
        //                codeLang[4] = dateTime.ToString("dd");
        //                str = string.Concat(codeLang);
        //            }
        //            if (num7 < Convert.ToInt32(dateTime.ToString("dd")))
        //            {
        //                year = dateTime1.Year;
        //                str1 = string.Concat(year.ToString(), "-", dateTime1.ToString("MM"), "-01");
        //            }
        //            else
        //            {
        //                codeLang = new string[5];
        //                year = dateTime1.Year;
        //                codeLang[0] = year.ToString();
        //                codeLang[1] = "-";
        //                startDate = dateTime1.AddMonths(-1);
        //                codeLang[2] = startDate.ToString("MM");
        //                codeLang[3] = "-";
        //                codeLang[4] = dateTime.ToString("dd");
        //                str1 = string.Concat(codeLang);
        //            }
        //            dateTime2 = (dateTime1.Day >= Convert.ToInt16(persKV.DD) ? DateTime.ParseExact(str, "yyyy-MM-dd", null) : DateTime.ParseExact(str1, "yyyy-MM-dd", null));
        //            timeSpan = dateTime1 - dateTime2;
        //            if (timeSpan.Days <= 0)
        //            {
        //                num5 = 1;
        //            }
        //            else
        //            {
        //                num5 = Convert.ToInt16(timeSpan.Days + 1);
        //            }
        //            str7 = string.Concat(str7, predictionBLL.GetDayFal(persKV, lkmv, num2, num3, num5, persKV.ShowRef, true, persKV.Male, persKV.JanamSamay, persKV.Language, persKV.Paid, dateTime1));
        //            dateTime1 = dateTime1.AddDays(1);
        //        }
        //        str3 = str7;
        //        codeLang = new string[] { str3, "\r\n\r\n", predictionBLL.GetCodeLang("aa", persKV.Language, persKV.Paid), " ", predictionBLL.GetCodeLang("saptahik", persKV.Language, persKV.Paid), " ", predictionBLL.GetCodeLang("aa", persKV.Language, persKV.Paid) };
        //        str7 = string.Concat(codeLang);
        //        for (i = 1; i <= 52; i = (short)(i + 1))
        //        {
        //            num2 = Convert.ToInt16(this.CalculateAgeCorrect(dateTime, today1) + 1);
        //            num3 = Convert.ToInt16(this.GetMonthsBetween(dateTime.AddYears(num2 - 1), today1));
        //            num3 = Convert.ToInt16(num3 + 1);
        //            dateTime2 = new DateTime();
        //            num6 = DateTime.DaysInMonth(today1.Year, today1.Month);
        //            startDate = today1.AddMonths(-1);
        //            int year5 = startDate.Year;
        //            startDate = today1.AddMonths(-1);
        //            num7 = DateTime.DaysInMonth(year5, startDate.Month);
        //            str = "";
        //            str1 = "";
        //            if (num6 < Convert.ToInt32(dateTime.ToString("dd")))
        //            {
        //                year = today1.Year;
        //                str = string.Concat(year.ToString(), "-", today1.ToString("MM"), "-01");
        //            }
        //            else
        //            {
        //                codeLang = new string[5];
        //                year = today1.Year;
        //                codeLang[0] = year.ToString();
        //                codeLang[1] = "-";
        //                codeLang[2] = today1.ToString("MM");
        //                codeLang[3] = "-";
        //                codeLang[4] = dateTime.ToString("dd");
        //                str = string.Concat(codeLang);
        //            }
        //            if (num7 < Convert.ToInt32(dateTime.ToString("dd")))
        //            {
        //                year = today1.Year;
        //                str1 = string.Concat(year.ToString(), "-", today1.ToString("MM"), "-01");
        //            }
        //            else
        //            {
        //                codeLang = new string[5];
        //                year = today1.Year;
        //                codeLang[0] = year.ToString();
        //                codeLang[1] = "-";
        //                startDate = today1.AddMonths(-1);
        //                codeLang[2] = startDate.ToString("MM");
        //                codeLang[3] = "-";
        //                codeLang[4] = dateTime.ToString("dd");
        //                str1 = string.Concat(codeLang);
        //            }
        //            dateTime2 = (today1.Day >= Convert.ToInt16(persKV.DD) ? DateTime.ParseExact(str, "yyyy-MM-dd", null) : DateTime.ParseExact(str1, "yyyy-MM-dd", null));
        //            timeSpan = today1 - dateTime2;
        //            if (timeSpan.Days <= 0)
        //            {
        //                num5 = 1;
        //            }
        //            else
        //            {
        //                num5 = Convert.ToInt16(timeSpan.Days + 1);
        //            }
        //            num8 = Convert.ToInt16(Math.Floor(Convert.ToDecimal(num5 / 7)) + 1);
        //            //num8 = Convert.ToInt16(Math.Floor(Convert.ToDecimal(num5 / 7))++);
        //            if ((num8 <= 0 ? true : num5 <= 7))
        //            {
        //                num8 = 1;
        //            }
        //            if (num5 % 7 == 0)
        //            {
        //                num8 = (short)(num8 - 1);
        //            }
        //            num4 = num8;
        //            str7 = string.Concat(str7, predictionBLL.GetWeekFal(persKV, lkmv, num2, num3, num4, persKV.ShowRef, true, persKV.Male, persKV.JanamSamay, persKV.Language, persKV.Paid, today1));
        //            today1 = today1.AddDays(7);
        //        }
        //        str2 = str7;
        //    }
        //    else if ((prodtype == "12 Months" ? false : !(prodtype == "24 Months")))
        //    {
        //        List<long> nums2 = new List<long>();
        //        List<RulesVO> list1 = new List<RulesVO>();
        //        list1 = this.generate_final_lrvgen(persKV, lkmv, false, new List<short>(), persKV.Language, "", false, false).ToList<RulesVO>();
        //        string str10 = "";
        //        string str11 = "";
        //        string str12 = string.Concat("\r\n", this.GetCodeLang("upayhelp", persKV.Language, persKV.Paid, flag));
        //        string str13 = "";
        //        string str14 = "";
        //        string str15 = "";
        //        string str16 = "";
        //        string str17 = "";
        //        string str18 = "";
        //        string str19 = "";
        //        string str20 = "";
        //        str3 = str13;
        //        codeLang = new string[] { str3, "\r\n", this.GetCodeLang("headmatapita", persKV.Language, persKV.Paid, flag), " ", this.GetCodeLang("headgood", persKV.Language, persKV.Paid, flag), "\r\n" };
        //        str13 = string.Concat(codeLang);
        //        str3 = str14;
        //        codeLang = new string[] { str3, "\r\n", this.GetCodeLang("headsantan", persKV.Language, persKV.Paid, flag), " ", this.GetCodeLang("headgood", persKV.Language, persKV.Paid, flag), "\r\n" };
        //        str14 = string.Concat(codeLang);
        //        str3 = str15;
        //        codeLang = new string[] { str3, "\r\n", this.GetCodeLang("headbhai", persKV.Language, persKV.Paid, flag), " ", this.GetCodeLang("headgood", persKV.Language, persKV.Paid, flag), "\r\n" };
        //        str15 = string.Concat(codeLang);
        //        str3 = str16;
        //        codeLang = new string[] { str3, "\r\n", this.GetCodeLang("headprem", persKV.Language, persKV.Paid, flag), " ", this.GetCodeLang("headgood", persKV.Language, persKV.Paid, flag), "\r\n" };
        //        str16 = string.Concat(codeLang);
        //        str3 = str17;
        //        codeLang = new string[] { str3, "\r\n", this.GetCodeLang("headbimari", persKV.Language, persKV.Paid, flag), " ", this.GetCodeLang("headgood", persKV.Language, persKV.Paid, flag), "\r\n" };
        //        str17 = string.Concat(codeLang);
        //        str3 = str18;
        //        codeLang = new string[] { str3, "\r\n", this.GetCodeLang("headshadi", persKV.Language, persKV.Paid, flag), " ", this.GetCodeLang("headgood", persKV.Language, persKV.Paid, flag), "\r\n" };
        //        str18 = string.Concat(codeLang);
        //        str3 = str20;
        //        codeLang = new string[] { str3, "\r\n", this.GetCodeLang("headyog", persKV.Language, persKV.Paid, flag), " ", this.GetCodeLang("headgood", persKV.Language, persKV.Paid, flag), "\r\n" };
        //        str20 = string.Concat(codeLang);
        //        string str21 = "";
        //        string str22 = "";
        //        string str23 = "";
        //        string str24 = "";
        //        string str25 = "";
        //        string str26 = "";
        //        string str27 = "";
        //        string str28 = "";
        //        str3 = str21;
        //        codeLang = new string[] { str3, "\r\n", this.GetCodeLang("headmatapita", persKV.Language, persKV.Paid, flag), " ", this.GetCodeLang("headbad", persKV.Language, persKV.Paid, flag), "\r\n" };
        //        str21 = string.Concat(codeLang);
        //        str3 = str22;
        //        codeLang = new string[] { str3, "\r\n", this.GetCodeLang("headsantan", persKV.Language, persKV.Paid, flag), " ", this.GetCodeLang("headbad", persKV.Language, persKV.Paid, flag), "\r\n" };
        //        str22 = string.Concat(codeLang);
        //        str3 = str23;
        //        codeLang = new string[] { str3, "\r\n", this.GetCodeLang("headbhai", persKV.Language, persKV.Paid, flag), " ", this.GetCodeLang("headbad", persKV.Language, persKV.Paid, flag), "\r\n" };
        //        str23 = string.Concat(codeLang);
        //        str3 = str24;
        //        codeLang = new string[] { str3, "\r\n", this.GetCodeLang("headprem", persKV.Language, persKV.Paid, flag), " ", this.GetCodeLang("headbad", persKV.Language, persKV.Paid, flag), "\r\n" };
        //        str24 = string.Concat(codeLang);
        //        str3 = str25;
        //        codeLang = new string[] { str3, "\r\n", this.GetCodeLang("headbimari", persKV.Language, persKV.Paid, flag), " ", this.GetCodeLang("headbad", persKV.Language, persKV.Paid, flag), "\r\n" };
        //        str25 = string.Concat(codeLang);
        //        str3 = str26;
        //        codeLang = new string[] { str3, "\r\n", this.GetCodeLang("headshadi", persKV.Language, persKV.Paid, flag), " ", this.GetCodeLang("headbad", persKV.Language, persKV.Paid, flag), "\r\n" };
        //        str26 = string.Concat(codeLang);
        //        str3 = str27;
        //        codeLang = new string[] { str3, "\r\n", this.GetCodeLang("headnaukri", persKV.Language, persKV.Paid, flag), " ", this.GetCodeLang("headbad", persKV.Language, persKV.Paid, flag), "\r\n" };
        //        str27 = string.Concat(codeLang);
        //        str3 = str28;
        //        codeLang = new string[] { str3, "\r\n", this.GetCodeLang("headyog", persKV.Language, persKV.Paid, flag), " ", this.GetCodeLang("headbad", persKV.Language, persKV.Paid, flag), "\r\n" };
        //        str28 = string.Concat(codeLang);
        //        int length = str13.Length + 1;
        //        int length1 = str14.Length + 1;
        //        int length2 = str15.Length + 1;
        //        int length3 = str16.Length + 1;
        //        int length4 = str17.Length + 1;
        //        int length5 = str18.Length + 1;
        //        int length6 = str19.Length + 1;
        //        int length7 = str20.Length + 1;
        //        int length8 = str21.Length + 1;
        //        int length9 = str22.Length + 1;
        //        int length10 = str23.Length + 1;
        //        int length11 = str24.Length + 1;
        //        int length12 = str25.Length + 1;
        //        int length13 = str26.Length + 1;
        //        int length14 = str27.Length + 1;
        //        int length15 = str28.Length + 1;
        //        if (prodtype == "Match Making")
        //        {
        //            short num22 = 0;
        //            short num23 = 0;
        //            if (persKV.Male)
        //            {
        //                try
        //                {
        //                    AstroGlobal.MM_married = Convert.ToInt16((
        //                        from Map in list1
        //                        where (!Map.Marriedlife ? false : Map.Isbad)
        //                        select Map).Count<RulesVO>() * Convert.ToInt16(100) / Convert.ToInt16((
        //                        from Map in list1
        //                        where Map.Marriedlife
        //                        select Map).Count<RulesVO>()));
        //                    AstroGlobal.MM_profession = Convert.ToInt16((
        //                        from Map in list1
        //                        where (Map.Occupation || Map.Profit ? Map.Isbad : false)
        //                        select Map).Count<RulesVO>() * Convert.ToInt16(100) / Convert.ToInt16((
        //                        from Map in list1
        //                        where Map.Occupation
        //                        select Map).Count<RulesVO>()));
        //                    AstroGlobal.MM_child = Convert.ToInt16((
        //                        from Map in list1
        //                        where (!Map.Santan ? false : Map.Isbad)
        //                        select Map).Count<RulesVO>() * Convert.ToInt16(100) / Convert.ToInt16((
        //                        from Map in list1
        //                        where Map.Santan
        //                        select Map).Count<RulesVO>()));
        //                    AstroGlobal.MM_health = Convert.ToInt16((
        //                        from Map in list1
        //                        where (!Map.Disease ? false : Map.Isbad)
        //                        select Map).Count<RulesVO>() * Convert.ToInt16(100) / Convert.ToInt16((
        //                        from Map in list1
        //                        where Map.Disease
        //                        select Map).Count<RulesVO>()));
        //                    AstroGlobal.MM_love = Convert.ToInt16((
        //                        from Map in list1
        //                        where (!Map.Love_affair ? false : Map.Isbad)
        //                        select Map).Count<RulesVO>() * Convert.ToInt16(100) / Convert.ToInt16((
        //                        from Map in list1
        //                        where Map.Love_affair
        //                        select Map).Count<RulesVO>()));
        //                    AstroGlobal.MM_married = Convert.ToInt16((double)AstroGlobal.MM_married * 1.3);
        //                    AstroGlobal.MM_child = Convert.ToInt16((double)AstroGlobal.MM_child * 1.1);
        //                    AstroGlobal.MM_health = Convert.ToInt16((double)AstroGlobal.MM_health * 1.1);
        //                }
        //                catch (Exception exception1)
        //                {
        //                    exception = exception1;
        //                }
        //            }
        //            if (!persKV.Male)
        //            {
        //                try
        //                {
        //                    AstroGlobal.MF_married = Convert.ToInt16((
        //                        from Map in list1
        //                        where (!Map.Marriedlife ? false : Map.Isbad)
        //                        select Map).Count<RulesVO>() * Convert.ToInt16(100) / Convert.ToInt16((
        //                        from Map in list1
        //                        where Map.Marriedlife
        //                        select Map).Count<RulesVO>()));
        //                    AstroGlobal.MF_profession = Convert.ToInt16((
        //                        from Map in list1
        //                        where (Map.Occupation || Map.Profit ? Map.Isbad : false)
        //                        select Map).Count<RulesVO>() * Convert.ToInt16(100) / Convert.ToInt16((
        //                        from Map in list1
        //                        where Map.Occupation
        //                        select Map).Count<RulesVO>()));
        //                    AstroGlobal.MF_child = Convert.ToInt16((
        //                        from Map in list1
        //                        where (!Map.Santan ? false : Map.Isbad)
        //                        select Map).Count<RulesVO>() * Convert.ToInt16(100) / Convert.ToInt16((
        //                        from Map in list1
        //                        where Map.Santan
        //                        select Map).Count<RulesVO>()));
        //                    AstroGlobal.MF_health = Convert.ToInt16((
        //                        from Map in list1
        //                        where (!Map.Disease ? false : Map.Isbad)
        //                        select Map).Count<RulesVO>() * Convert.ToInt16(100) / Convert.ToInt16((
        //                        from Map in list1
        //                        where Map.Disease
        //                        select Map).Count<RulesVO>()));
        //                    AstroGlobal.MF_love = Convert.ToInt16((
        //                        from Map in list1
        //                        where (!Map.Love_affair ? false : Map.Isbad)
        //                        select Map).Count<RulesVO>() * Convert.ToInt16(100) / Convert.ToInt16((
        //                        from Map in list1
        //                        where Map.Love_affair
        //                        select Map).Count<RulesVO>()));
        //                    AstroGlobal.MF_married = Convert.ToInt16((double)AstroGlobal.MF_married * 0.25);
        //                    AstroGlobal.MF_profession = Convert.ToInt16((double)AstroGlobal.MF_profession * 0.25);
        //                    AstroGlobal.MM_child = Convert.ToInt16((double)AstroGlobal.MM_child * 1.25);
        //                    AstroGlobal.MF_health = Convert.ToInt16((double)AstroGlobal.MF_health * 0.5);
        //                    AstroGlobal.MF_love = Convert.ToInt16((double)AstroGlobal.MF_love * 1.25);
        //                }
        //                catch (Exception exception2)
        //                {
        //                    exception = exception2;
        //                }
        //            }
        //            if (!persKV.Male)
        //            {
        //                short num24 = 0;
        //                num22 = Convert.ToInt16((int)(AstroGlobal.MM_married + AstroGlobal.MM_profession + AstroGlobal.MM_child + AstroGlobal.MM_health + AstroGlobal.MM_love));
        //                num23 = Convert.ToInt16((int)(AstroGlobal.MF_married + AstroGlobal.MF_profession + AstroGlobal.MF_child + AstroGlobal.MF_health + AstroGlobal.MF_love));
        //                num24 = Convert.ToInt16((num22 + num23) / 12);
        //                if (Convert.ToInt16(num24) >= 85)
        //                {
        //                    if (persKV.Language.ToLower() == "hindi")
        //                    {
        //                        str5 = "fu\"d\"kZ %\r\n\r\nvkids dq.Myh feyku esa nks”k gSa ftlds dkj.k ;g fookg lQy ugha jgsxk vkSj oSokfgd thou esa vR;Ur leL;k,¡ gksaxhA";
        //                    }
        //                    if (persKV.Language.ToLower() == "english")
        //                    {
        //                        str5 = "Conclusion : \r\n\r\nThis match is not suitable so don't fix marriage. If marriage takes place then this couple will face difficulties in life and marital life will become miserable.";
        //                    }
        //                }
        //                else if (!(Convert.ToInt16(num24) < 50 ? true : Convert.ToInt16(num24) >= 85))
        //                {
        //                    if (persKV.Language.ToLower() == "hindi")
        //                    {
        //                        str5 = "fu\"d\"kZ %\r\n\r\nvkids dq.Myh feyku esa dqN nks”k gSa ftUgsa dqN dfBu mik;ksa }kjk Bhd djuk laHko gS vr% nks”kksa dk fuokj.k djds gh fookg djsaA";
        //                    }
        //                    if (persKV.Language.ToLower() == "english")
        //                    {
        //                        str5 = "Conclusion : \r\n\r\nThis matchmaking has some flaws which can be cured by some difficult remedies which is already mentioned here. Please do all the remedies before marriage.";
        //                    }
        //                }
        //                else if (!(Convert.ToInt16(num24) < 35 ? true : Convert.ToInt16(num24) >= 50))
        //                {
        //                    if (persKV.Language.ToLower() == "hindi")
        //                    {
        //                        str5 = "fu\"d\"kZ %\r\n\r\nvkidk dq.Myh feyku vkSlr gS vr% vkidk oSokfgd thou feyk&tqyk jgsxk vkSj mrkj p<+ko vk,axsA  dqN ljy mik; djus ds i'pkr~ gh fookg djsaA  ";
        //                    }
        //                    if (persKV.Language.ToLower() == "english")
        //                    {
        //                        str5 = "Conclusion : \r\n\r\nThis matchmaking is average which means couple may face ups and downs in their marital life. Do simple remedies before you get married.";
        //                    }
        //                }
        //                else if (!(Convert.ToInt16(num24) < 20 ? true : Convert.ToInt16(num24) >= 35))
        //                {
        //                    if (persKV.Language.ToLower() == "hindi")
        //                    {
        //                        str5 = "fu\"d\"kZ %\r\n\r\n\r\n vkidk dq.Myh feyku mÙke gS vr% vkidk oSokfgd thou vPNk jgsxkA";
        //                    }
        //                    if (persKV.Language.ToLower() == "english")
        //                    {
        //                        str5 = "Conclusion : \r\n\r\nThis match is suitable and couple will enjoy happy married life. ";
        //                    }
        //                }
        //                else if (Convert.ToInt16(num24) < 20)
        //                {
        //                    if (persKV.Language.ToLower() == "hindi")
        //                    {
        //                        str5 = "fu\"d\"kZ %\r\n\r\nvkidk dq.Myh feyku loksZÙe gS vr% vkidk oSokfgd thou vR;Ur lq[ke; jgsxkA";
        //                    }
        //                    if (persKV.Language.ToLower() == "english")
        //                    {
        //                        str5 = "Conclusion : \r\n\r\nThis match is suitable and couple will enjoy happy married life.";
        //                    }
        //                }
        //            }
        //        }
        //        if (prodtype == "Married Life")
        //        {
        //            list1 = (
        //                from Map in list1
        //                where (Map.Marriedlife ? true : Map.Memory)
        //                select Map).ToList<RulesVO>();
        //        }
        //        if (prodtype == "Profession")
        //        {
        //            list1 = (
        //                from Map in list1
        //                where (Map.Occupation || Map.Profit ? true : Map.Memory)
        //                select Map).ToList<RulesVO>();
        //        }
        //        if (prodtype == "ProfessionYICC")
        //        {
        //            list1 = (
        //                from Map in list1
        //                where (Map.Occupation ? true : Map.Profit)
        //                select Map).ToList<RulesVO>();
        //        }
        //        if (prodtype == "Parents")
        //        {
        //            list1 = (
        //                from Map in list1
        //                where (Map.Mother_father ? true : Map.Memory)
        //                select Map).ToList<RulesVO>();
        //        }
        //        if (prodtype == "Siblings")
        //        {
        //            list1 = (
        //                from Map in list1
        //                where (Map.Brother ? true : Map.Memory)
        //                select Map).ToList<RulesVO>();
        //        }
        //        if (prodtype == "Children")
        //        {
        //            list1 = (
        //                from Map in list1
        //                where (Map.Santan ? true : Map.Memory)
        //                select Map).ToList<RulesVO>();
        //        }
        //        if (prodtype == "Health")
        //        {
        //            list1 = (
        //                from Map in list1
        //                where (Map.Disease ? true : Map.Memory)
        //                select Map).ToList<RulesVO>();
        //        }
        //        if (prodtype == "Love Relationship")
        //        {
        //            list1 = (
        //                from Map in list1
        //                where (Map.Love_affair ? true : Map.Memory)
        //                select Map).ToList<RulesVO>();
        //        }
        //        if (prodtype == "Match Making")
        //        {
        //            list1 = (
        //                from Map in list1
        //                where (Map.Occupation || Map.Marriedlife ? true : Map.Memory)
        //                select Map).ToList<RulesVO>();
        //        }
        //        if (prodtype == "Shadi ke Yog")
        //        {
        //            list1 = (
        //                from Map in list1
        //                where (Map.Love_affair || Map.Marriedlife ? (Map.Rule_Nature > 1 ? true : Map.Rule_Nature == 0) : false)
        //                select Map).ToList<RulesVO>();
        //        }
        //        List<short> nums3 = new List<short>();
        //        List<short> nums4 = new List<short>();
        //        PlanetBLL planetBLL1 = new PlanetBLL();
        //        BasicruleBLL basicruleBLL1 = new BasicruleBLL();
        //        List<RulesVO> rulesVOs2 = new List<RulesVO>();
        //        short num25 = Convert.ToInt16((
        //            from Map in planetBLL1.GetAllPlanets()
        //            where Map.PlanetnameEnglish == persKV.JanamDin
        //            select Map).FirstOrDefault<PlanetVO>().Sno);
        //        short num26 = Convert.ToInt16((
        //            from Map in lkmv
        //            where Map.Planet == num25
        //            select Map).SingleOrDefault<KundliMappingVO>().House);
        //        short num27 = Convert.ToInt16(basicruleBLL1.GetBasicRuleByHousePlanet(num26, num25).Sno);
        //        if ((prodtype.ToLower() == "jeevan sandesh" ? true : prodtype.ToLower() == "free jeevan sandesh"))
        //        {
        //            rulesVOs2 = (
        //                from Map in list1
        //                where (Map.Sno < (long)34938 || Map.Mainplanet != num25 ? false : Map.Ruleformula.Contains(num27.ToString()))
        //                select Map).ToList<RulesVO>();
        //            rulesVOs2.AddRange((
        //                from Map in list1
        //                where (Map.Sno < (long)34938 ? false : (Map.Ruleformula.Contains("61") || Map.Ruleformula.Contains("62") || Map.Ruleformula.Contains("63") || Map.Ruleformula.Contains("64") || Map.Ruleformula.Contains("65") || Map.Ruleformula.Contains("66") || Map.Ruleformula.Contains("67") || Map.Ruleformula.Contains("68") || Map.Ruleformula.Contains("69") || Map.Ruleformula.Contains("70") || Map.Ruleformula.Contains("71") ? true : Map.Ruleformula.Contains("72")))
        //                select Map).ToList<RulesVO>());
        //        }
        //        if ((prodtype.ToLower() == "jeevan sandesh full" ? true : prodtype.ToLower() == "free jeevan sandesh full"))
        //        {
        //            rulesVOs2 = (
        //                from Map in list1
        //                where (Map.Mainplanet != num25 ? false : Map.Ruleformula.Contains(num27.ToString()))
        //                select Map).ToList<RulesVO>();
        //            rulesVOs2.AddRange((
        //                from Map in list1
        //                where (Map.Ruleformula.Contains("&") || Map.Ruleformula.Contains("|") || Map.Mainplanet != 8 ? false : (Map.Ruleformula.Contains("61") || Map.Ruleformula.Contains("62") || Map.Ruleformula.Contains("63") || Map.Ruleformula.Contains("64") || Map.Ruleformula.Contains("65") || Map.Ruleformula.Contains("66") || Map.Ruleformula.Contains("67") || Map.Ruleformula.Contains("68") || Map.Ruleformula.Contains("69") || Map.Ruleformula.Contains("70") || Map.Ruleformula.Contains("71") ? true : Map.Ruleformula.Contains("72")))
        //                select Map).ToList<RulesVO>());
        //            rulesVOs2.AddRange((
        //                from Map in list1
        //                where (!Map.Ruleformula.Contains("&") || !Map.Ruleformula.Contains("|") || Map.Mainplanet != 8 ? false : (Map.Ruleformula.Contains("61") || Map.Ruleformula.Contains("62") || Map.Ruleformula.Contains("63") || Map.Ruleformula.Contains("64") || Map.Ruleformula.Contains("65") || Map.Ruleformula.Contains("66") || Map.Ruleformula.Contains("67") || Map.Ruleformula.Contains("68") || Map.Ruleformula.Contains("69") || Map.Ruleformula.Contains("70") || Map.Ruleformula.Contains("71") ? true : Map.Ruleformula.Contains("72")))
        //                select Map).ToList<RulesVO>());
        //            rulesVOs2.AddRange((
        //                from Map in list1
        //                where (Map.Ruleformula.Contains("&") || Map.Ruleformula.Contains("|") || Map.Mainplanet == 8 ? false : (Map.Ruleformula.Contains("61") || Map.Ruleformula.Contains("62") || Map.Ruleformula.Contains("63") || Map.Ruleformula.Contains("64") || Map.Ruleformula.Contains("65") || Map.Ruleformula.Contains("66") || Map.Ruleformula.Contains("67") || Map.Ruleformula.Contains("68") || Map.Ruleformula.Contains("69") || Map.Ruleformula.Contains("70") || Map.Ruleformula.Contains("71") ? true : Map.Ruleformula.Contains("72")))
        //                select Map).ToList<RulesVO>());
        //            rulesVOs2.AddRange((
        //                from Map in list1
        //                where (!Map.Ruleformula.Contains("&") || !Map.Ruleformula.Contains("|") || Map.Mainplanet == 8 ? false : (Map.Ruleformula.Contains("61") || Map.Ruleformula.Contains("62") || Map.Ruleformula.Contains("63") || Map.Ruleformula.Contains("64") || Map.Ruleformula.Contains("65") || Map.Ruleformula.Contains("66") || Map.Ruleformula.Contains("67") || Map.Ruleformula.Contains("68") || Map.Ruleformula.Contains("69") || Map.Ruleformula.Contains("70") || Map.Ruleformula.Contains("71") ? true : Map.Ruleformula.Contains("72")))
        //                select Map).ToList<RulesVO>());
        //        }
        //        if ((prodtype.ToLower() == "jeevan sandesh" || prodtype.ToLower() == "free jeevan sandesh" || prodtype.ToLower() == "jeevan sandesh full" ? true : prodtype.ToLower() == "free jeevan sandesh full"))
        //        {
        //            list1 = rulesVOs2;
        //        }
        //        RuleDAO ruleDAO = new RuleDAO();
        //        string str29 = "";
        //        str29 = string.Concat(str29, "\r\n\r\n", this.GetCodeLang("headjeevan", persKV.Language, persKV.Paid, flag), "\r\n\r\n");
        //        if (list1 != null)
        //        {
        //            foreach (RulesVO rulesVO in list1)
        //            {
        //                UpayIndex upayIndex = new UpayIndex();
        //                upayIndex = ruleDAO.Get_UpayIndex(Convert.ToInt32(rulesVO.Upay));
        //                if ((upayIndex == null ? false : upayIndex.Sno > 0))
        //                {
        //                    if (!nums2.Contains((long)upayIndex.Sno))
        //                    {
        //                        if ((prodtype.ToLower() == "free jeevan sandesh" ? false : !(prodtype.ToLower() == "free jeevan sandesh full")))
        //                        {
        //                            persKV.UpayCode = upayIndex.Sno.ToString();
        //                            nums2.Add((long)upayIndex.Sno);
        //                        }
        //                        else
        //                        {
        //                            nums2.Add(Convert.ToInt64(string.Concat(persKV.FileCode, num10.ToString())));
        //                            persKV.UpayCode = string.Concat(persKV.FileCode, num10.ToString());
        //                            obj = str4;
        //                            fileCode = new object[] { obj, persKV.FileCode, num10.ToString(), ",", upayIndex.Sno, ",", rulesVO.Sno, "#" };
        //                            str4 = string.Concat(fileCode);
        //                            num10 = (short)(num10 + 1);
        //                        }
        //                    }
        //                }
        //                str10 = (!persKV.Paid ? string.Concat(this.Get_Pred_Text(rulesVO.Sno, persKV.Language, persKV.Male, true, persKV.ShowRef, false, persKV.Paid, false, false, persKV), "\r\n") : this.Get_Pred_Text(rulesVO.Sno, persKV.Language, persKV.Male, true, persKV.ShowRef, false, persKV.Paid, true, false, persKV));
        //                str29 = string.Concat(str29, str10, "\r\n\r\n");
        //                if ((!rulesVO.Mother_father ? false : !rulesVO.Isbad))
        //                {
        //                    str13 = string.Concat(str13, str10);
        //                }
        //                if ((!rulesVO.Mother_father ? false : rulesVO.Isbad))
        //                {
        //                    str21 = string.Concat(str21, str10);
        //                }
        //                if ((!rulesVO.Santan ? false : !rulesVO.Isbad))
        //                {
        //                    str14 = string.Concat(str14, str10);
        //                }
        //                if ((!rulesVO.Santan ? false : rulesVO.Isbad))
        //                {
        //                    str22 = string.Concat(str22, str10);
        //                }
        //                if ((!rulesVO.Brother ? false : !rulesVO.Isbad))
        //                {
        //                    str15 = string.Concat(str15, str10);
        //                }
        //                if ((!rulesVO.Brother ? false : rulesVO.Isbad))
        //                {
        //                    str23 = string.Concat(str23, str10);
        //                }
        //                if ((!rulesVO.Love_affair ? false : !rulesVO.Isbad))
        //                {
        //                    str16 = string.Concat(str16, str10);
        //                }
        //                if ((!rulesVO.Love_affair ? false : rulesVO.Isbad))
        //                {
        //                    str24 = string.Concat(str24, str10);
        //                }
        //                if ((!rulesVO.Disease ? false : !rulesVO.Isbad))
        //                {
        //                    str17 = string.Concat(str17, str10);
        //                }
        //                if ((!rulesVO.Disease ? false : rulesVO.Isbad))
        //                {
        //                    str25 = string.Concat(str25, str10);
        //                }
        //                if ((!rulesVO.Marriedlife ? false : !rulesVO.Isbad))
        //                {
        //                    str18 = string.Concat(str18, str10);
        //                }
        //                if ((!rulesVO.Marriedlife ? false : rulesVO.Isbad))
        //                {
        //                    str26 = string.Concat(str26, str10);
        //                }
        //                if ((rulesVO.Occupation || rulesVO.Profit ? !rulesVO.Isbad : false))
        //                {
        //                    str19 = string.Concat(str19, str10);
        //                }
        //                if ((rulesVO.Occupation || rulesVO.Profit ? rulesVO.Isbad : false))
        //                {
        //                    str27 = string.Concat(str27, str10);
        //                }
        //                if ((!rulesVO.Memory ? false : !rulesVO.Isbad))
        //                {
        //                    str20 = string.Concat(str20, str10);
        //                }
        //                if ((!rulesVO.Memory ? false : rulesVO.Isbad))
        //                {
        //                    str28 = string.Concat(str28, str10);
        //                }
        //            }
        //        }
        //        if ((!(prodtype.ToLower() != "jeevan sandesh") || !(prodtype.ToLower() != "free jeevan sandesh") || !(prodtype.ToLower() != "jeevan sandesh full") ? true : !(prodtype.ToLower() != "free jeevan sandesh full")))
        //        {
        //            str7 = string.Concat(str7, str29);
        //        }
        //        else
        //        {
        //            if (prodtype != "ProfessionYICC")
        //            {
        //                if (str20.Trim().Length > length7)
        //                {
        //                    str11 = string.Concat(str11, "\r\n", str20);
        //                }
        //                if (str28.Trim().Length > length15)
        //                {
        //                    str11 = string.Concat(str11, "\r\n", str28, "\r\n");
        //                }
        //            }
        //            if (str13.Trim().Length > length)
        //            {
        //                str11 = string.Concat(str11, "\r\n", str13);
        //            }
        //            if (str21.Trim().Length > length8)
        //            {
        //                str11 = string.Concat(str11, "\r\n", str21, "\r\n");
        //            }
        //            if (str14.Trim().Length > length1)
        //            {
        //                str11 = string.Concat(str11, "\r\n", str14);
        //            }
        //            if (str22.Trim().Length > length9)
        //            {
        //                str11 = string.Concat(str11, "\r\n", str22, "\r\n");
        //            }
        //            if (str15.Trim().Length > length2)
        //            {
        //                str11 = string.Concat(str11, "\r\n", str15);
        //            }
        //            if (str23.Trim().Length > length10)
        //            {
        //                str11 = string.Concat(str11, "\r\n", str23, "\r\n");
        //            }
        //            if (str16.Trim().Length > length3)
        //            {
        //                str11 = string.Concat(str11, "\r\n", str16);
        //            }
        //            if (str24.Trim().Length > length11)
        //            {
        //                str11 = string.Concat(str11, "\r\n", str24, "\r\n");
        //            }
        //            if (str17.Trim().Length > length4)
        //            {
        //                str11 = string.Concat(str11, "\r\n", str17);
        //            }
        //            if (str25.Trim().Length > length12)
        //            {
        //                str11 = string.Concat(str11, "\r\n", str25, "\r\n");
        //            }
        //            if (str18.Trim().Length > length5)
        //            {
        //                str11 = string.Concat(str11, "\r\n\r\n", str18);
        //            }
        //            if (str26.Trim().Length > length13)
        //            {
        //                str11 = string.Concat(str11, "\r\n", str26, "\r\n");
        //            }
        //            RuleDAO ruleDAO1 = new RuleDAO();
        //            List<RulesVO> list2 = (
        //                from Map in (new KundliBLL()).GetAdvancePredictions(lkmv, 0, 0)
        //                where Map.RuleType == "LagnaShikshaYog"
        //                select Map).ToList<RulesVO>();
        //            RuleDAO ruleDAO2 = new RuleDAO();
        //            List<RulesVO> rulesVOs3 = new List<RulesVO>();
        //            rulesVOs3.AddRange((
        //                from map in list2
        //                where map.RuleType == "LagnaShikshaYog"
        //                select map).ToList<RulesVO>());
        //            List<long> nums5 = new List<long>();
        //            bool flag1 = false;
        //            foreach (RulesVO rulesVO3 in rulesVOs3)
        //            {
        //                List<AdditionalRulesVO> additionalRulesVOs = (
        //                    from aar in ruleDAO2.Get_AdditionalRules()
        //                    where aar.RuleNo == rulesVO3.Sno
        //                    select aar).ToList<AdditionalRulesVO>();
        //                if (additionalRulesVOs.Count > 0)
        //                {
        //                    foreach (AdditionalRulesVO additionalRulesVO in additionalRulesVOs)
        //                    {
        //                        string str30 = additionalRulesVO.Lagan.ToString();
        //                        chrArray = new char[] { ',' };
        //                        string[] array = str30.Split(chrArray).ToArray<string>();
        //                        for (int j = 0; j < array.Count<string>(); j++)
        //                        {
        //                            if ((long)Convert.ToInt32(array[j].ToString()) == persKV.Lagna)
        //                            {
        //                                if ((nums5.Contains(rulesVO3.RefNo) ? false : !flag1))
        //                                {
        //                                    str8 = string.Concat(str8, this.Get_Pred_Text(rulesVO3.RefNo, persKV.Language, persKV.Male, true, persKV.ShowRef, false, persKV.Paid, false, false, persKV), "\r\n\r\n");
        //                                    flag1 = true;
        //                                    nums5.Add(rulesVO3.RefNo);
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //            if (str8.Trim().Length > 5)
        //            {
        //                string str31 = "";
        //                str31 = string.Concat("\r\n", str8, "\r\n", str19);
        //                str19 = string.Concat("\r\n", str31);
        //            }
        //            if (str19.Trim().Length > length6)
        //            {
        //                str3 = str11;
        //                codeLang = new string[] { str3, "\r\n", this.GetCodeLang("headnaukri", persKV.Language, persKV.Paid, flag), " ", this.GetCodeLang("headgood", persKV.Language, persKV.Paid, flag), str19 };
        //                str11 = string.Concat(codeLang);
        //            }
        //            if (str27.Trim().Length > length14)
        //            {
        //                str11 = string.Concat(str11, "\r\n", str27, "\r\n");
        //            }
        //            str7 = string.Concat(str7, str11);
        //        }
        //        if (prodtype == "Shadi ke Yog")
        //        {
        //            str7 = string.Concat(this.GetShadi(persKV, lkmv), "\r\n", str7);
        //        }
        //        if (showUpay)
        //        {
        //            str6 = string.Concat("\r\n\r\n", this.GetCodeLang("upayhelpbottom", persKV.Language, persKV.Paid, flag), "\r\n");
        //            if ((persKV.Language.ToLower() == "hindi" || persKV.Language.ToLower() == "marathi" ? true : persKV.Language.ToLower() == "english"))
        //            {
        //                str6 = string.Concat(str6, "\r\n\r\n", this.GetCodeLang("upaybelow", persKV.Language, persKV.Paid, flag), "\r\n");
        //            }
        //            if (prodtype != "Pitri Rin")
        //            {
        //                nums2.Sort();
        //                foreach (short num28 in nums2)
        //                {
        //                    UpayIndex upayIndex1 = new UpayIndex();
        //                    upayIndex1 = (new RuleDAO()).Get_UpayIndex(Convert.ToInt32(num28));
        //                    if ((prodtype.ToLower() == "free jeevan sandesh" ? false : prodtype.ToLower() != "free jeevan sandesh full"))
        //                    {
        //                        if (persKV.Language.ToLower() == "hindi")
        //                        {
        //                            obj = str6;
        //                            fileCode = new object[] { obj, this.GetCodeLang("aa", persKV.Language, persKV.Paid, flag), " ", this.GetCodeLang("upay", persKV.Language, persKV.Paid, flag), " ", upayIndex1.Sno, " ", this.GetCodeLang("aa", persKV.Language, persKV.Paid, flag), "\r\n", upayIndex1.Hindi.Trim(), "\r\n\r\n" };
        //                            str6 = string.Concat(fileCode);
        //                        }
        //                        if (persKV.Language.ToLower() == "marathi")
        //                        {
        //                            obj = str6;
        //                            fileCode = new object[] { obj, this.GetCodeLang("aa", persKV.Language, persKV.Paid, flag), " ", this.GetCodeLang("upay", persKV.Language, persKV.Paid, flag), " ", upayIndex1.Sno, " ", this.GetCodeLang("aa", persKV.Language, persKV.Paid, flag), "\r\n", upayIndex1.Marathi.Trim(), "\r\n\r\n" };
        //                            str6 = string.Concat(fileCode);
        //                        }
        //                        if (persKV.Language.ToLower() == "english")
        //                        {
        //                            obj = str6;
        //                            fileCode = new object[] { obj, this.GetCodeLang("aa", persKV.Language, persKV.Paid, flag), " ", this.GetCodeLang("upay", persKV.Language, persKV.Paid, flag), " ", upayIndex1.Sno, " ", this.GetCodeLang("aa", persKV.Language, persKV.Paid, flag), "\r\n", upayIndex1.Eng.Trim(), "\r\n\r\n" };
        //                            str6 = string.Concat(fileCode);
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        if (prodtype == "Pitri Rin")
        //        {
        //            str7 = this.rin_pitri(persKV, lkmv);
        //            str6 = "";
        //        }
        //        if ((prodtype.ToLower() == "free jeevan sandesh" ? true : prodtype.ToLower() == "free jeevan sandesh full"))
        //        {
        //            str6 = "";
        //        }
        //        str7 = string.Concat(str7, "\r\n\r\n", str6);
        //        if ((prodtype != "Match Making" ? false : !persKV.Male))
        //        {
        //            str7 = string.Concat(str7, "\r\n\r\n", str5);
        //        }
        //        if ((prodtype.ToLower() == "free jeevan sandesh" ? true : prodtype.ToLower() == "free jeevan sandesh full"))
        //        {
        //            str7 = string.Concat(str7, "#####", str4);
        //        }
        //        str2 = str7;
        //    }
        //    else
        //    {
        //        dateTime = new DateTime(Convert.ToInt16(persKV.YY), Convert.ToInt16(persKV.MM), Convert.ToInt16(persKV.DD));
        //        today = DateTime.Today;
        //        nums = new List<short>();
        //        nums1 = new List<short>();
        //        num = 0;
        //        num1 = 0;
        //        short num29 = 12;
        //        str7 = string.Concat(str7, this.get_mlife(persKV, lkmv));
        //        num = Convert.ToInt16(this.CalculateAgeCorrect(dateTime, today));
        //        num1 = Convert.ToInt16(this.GetMonthsBetween(dateTime.AddYears(num), today));
        //        num1 = Convert.ToInt16(num1 + 1);
        //        num = Convert.ToInt16(num + 1);
        //        nums1.Add(num);
        //        nums1.Add(Convert.ToInt16(num + 1));
        //        if (prodtype == "24 Months")
        //        {
        //            nums1.Add(Convert.ToInt16(num + 2));
        //            num29 = 24;
        //        }
        //        str7 = string.Concat(str7, this.Get_varshfal(persKV, nums1, lkmv, new List<short>()));
        //        nums.Clear();
        //        nums.Add(num1);
        //        for (i = 0; i < num29; i = (short)(i + 1))
        //        {
        //            str7 = string.Concat(str7, "\r\n", this.GetMonthFal(persKV, lkmv, num, nums, persKV.ShowRef, true, persKV.Male, persKV.JanamSamay, persKV.Language, persKV.Paid));
        //            nums.Clear();
        //            num1 = Convert.ToInt16(num1 + 1);
        //            nums.Add(num1);
        //            if (num1 > 12)
        //            {
        //                num = Convert.ToInt16(num + 1);
        //                num1 = 1;
        //                nums.Clear();
        //                nums.Add(num1);
        //            }
        //        }
        //        str2 = str7;
        //    }
        //    return str2;
        //}

        //public string Get_varshfal(KundliVO persKV, List<short> Varshfal_years, List<KundliMappingVO> lkmv, List<short> months)
        //{
        //    int house;
        //    bool flag;
        //    string str;
        //    bool male = persKV.Male;
        //    bool flag1 = true;
        //    string language = persKV.Language;
        //    bool paid = persKV.Paid;
        //    string dD = persKV.DD;
        //    string mM = persKV.MM;
        //    string yY = persKV.YY;
        //    string hH = persKV.HH;
        //    string mIN = persKV.MIN;
        //    bool showRef = persKV.ShowRef;
        //    bool flag2 = false;
        //    if (persKV.Sub_prodtype == "mobile")
        //    {
        //        flag2 = true;
        //    }
        //    this.paidpred = true;
        //    PredictionBLL predictionBLL = new PredictionBLL();
        //    List<KundliMappingVO> kundliMappingVOs = new List<KundliMappingVO>();
        //    KundliBLL kundliBLL = new KundliBLL();
        //    string str1 = "";
        //    DateTime dateTime = new DateTime();
        //    DateTime dateTime1 = new DateTime();
        //    List<RulesVO> rulesVOs = new List<RulesVO>();
        //    rulesVOs = this.generate_final_lrvgen(persKV, lkmv, true, Varshfal_years, language, "", false, false);
        //    foreach (short varshfalYear in Varshfal_years)
        //    {
        //        kundliMappingVOs = kundliBLL.GetVarshaphalKundliMapping(varshfalYear, persKV, lkmv);
        //        DateTime dob = persKV.Dob;
        //        dateTime = dob.AddYears(varshfalYear - 1);
        //        dob = persKV.Dob;
        //        dob = dob.AddYears(varshfalYear);
        //        dateTime1 = dob.AddDays(-1);
        //        if (persKV.Paid)
        //        {
        //            str1 = string.Concat(str1, "\r\n");
        //            string str2 = str1;
        //            string[] strArrays = new string[] { str2, dateTime.ToString("dd"), " ", this.GetCodeLang(string.Concat("M", dateTime.ToString("%M")), persKV.Language, persKV.Paid), " ", dateTime.ToString("yyyy"), " ", this.GetCodeLang("to", persKV.Language, true), " ", dateTime1.ToString("dd"), " ", this.GetCodeLang(string.Concat("M", dateTime1.ToString("%M")), persKV.Language, persKV.Paid), " ", dateTime1.ToString("yyyy"), " ", this.GetCodeLang("yearend", persKV.Language, true) };
        //            str1 = string.Concat(strArrays);
        //            str1 = string.Concat(str1, "\r\n\r\n");
        //            foreach (KundliMappingVO kundliMappingVO in kundliMappingVOs)
        //            {
        //                string str3 = str1;
        //                if (kundliMappingVO.VIsBad)
        //                {
        //                    strArrays = new string[] { this.GetCodeLang(kundliMappingVO.PlanetNameEnglish, language, paid, flag2).ToString(), " ", null, null, null, null };
        //                    house = kundliMappingVO.House;
        //                    strArrays[2] = house.ToString();
        //                    strArrays[3] = " ";
        //                    strArrays[4] = this.GetCodeLang("Bad", language, paid, flag2).ToString();
        //                    strArrays[5] = "\r\n";
        //                    str = string.Concat(strArrays);
        //                }
        //                else
        //                {
        //                    strArrays = new string[] { this.GetCodeLang(kundliMappingVO.PlanetNameEnglish, language, paid, flag2).ToString(), " ", null, null, null, null };
        //                    house = kundliMappingVO.House;
        //                    strArrays[2] = house.ToString();
        //                    strArrays[3] = " ";
        //                    strArrays[4] = this.GetCodeLang("Good", language, paid, flag2).ToString();
        //                    strArrays[5] = "\r\n";
        //                    str = string.Concat(strArrays);
        //                }
        //                str1 = string.Concat(str3, str);
        //            }
        //        }
        //        str1 = string.Concat(str1, "\r\n");
        //        str1 = string.Concat(str1, predictionBLL.GetVarshFal(persKV, lkmv, kundliMappingVOs, varshfalYear, showRef, flag1, male, persKV.JanamSamay, language, paid));
        //        foreach (RulesVO list in (
        //            from Map in rulesVOs
        //            where Map.VfalYears.Split(new char[] { ',' }).ToArray<string>().Contains<string>(varshfalYear.ToString())
        //            select Map).ToList<RulesVO>())
        //        {
        //            str1 = string.Concat(str1, this.Get_Pred_Text(list.Sno, language, male, true, showRef, false, paid, true, flag2, persKV));
        //            if (persKV.Paid)
        //            {
        //                RulesVO rulesVO = new RulesVO();
        //                RuleDAO ruleDAO = new RuleDAO();
        //                rulesVO = (new RuleBLL()).GetAdvanceRuleById(list.Sno);
        //                UpayIndex upayIndex = new UpayIndex();
        //                upayIndex = ruleDAO.Get_UpayIndex(Convert.ToInt32(rulesVO.Upay));
        //                if (upayIndex != null)
        //                {
        //                    if (rulesVO.Upay <= 0)
        //                    {
        //                        flag = true;
        //                    }
        //                    else
        //                    {
        //                        flag = (persKV.Language.ToLower() == "hindi" || persKV.Language.ToLower() == "marathi" ? false : !(persKV.Language.ToLower() == "english"));
        //                    }
        //                    if (!flag)
        //                    {
        //                        if (!this.all_upayindex_sno.Contains((long)upayIndex.Sno))
        //                        {
        //                            this.all_upayindex_sno.Add((long)upayIndex.Sno);
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        if ((!paid ? false : persKV.Product.ToLower() != "free"))
        //        {
        //            str1 = string.Concat(str1, predictionBLL.GetVarshFal_35years(lkmv, varshfalYear, showRef, flag1, male, persKV.JanamSamay, language, persKV));
        //        }
        //        if (persKV.Mfal)
        //        {
        //            str1 = string.Concat(str1, "\r\n", this.GetMonthFal(persKV, lkmv, varshfalYear, months, persKV.ShowRef, true, persKV.Male, persKV.JanamSamay, persKV.Language, persKV.Paid));
        //        }
        //    }
        //    return str1;
        //}

        //public string get_videsh(KundliVO persKV, List<KundliMappingVO> lkmv_lagna)
        //{
        //    KundliBLL kundliBLL = new KundliBLL();
        //    string str = "";
        //    RuleDAO ruleDAO = new RuleDAO();
        //    List<RulesVO> list = (
        //        from Map in kundliBLL.GetAdvancePredictions(lkmv_lagna, 0, 0)
        //        where Map.RuleType == "LagnaVideshYog"
        //        select Map).ToList<RulesVO>();
        //    RuleDAO ruleDAO1 = new RuleDAO();
        //    string codeLang = this.GetCodeLang("videshyog", persKV.Language, persKV.Paid, false);
        //    List<RulesVO> rulesVOs = new List<RulesVO>();
        //    rulesVOs.AddRange((
        //        from map in list
        //        where map.RuleType == "LagnaVideshYog"
        //        select map).ToList<RulesVO>());
        //    List<AdditionalRulesVO> additionalRulesVOs = new List<AdditionalRulesVO>();
        //    List<RulesVO> rulesVOs1 = new List<RulesVO>();
        //    long priority = (long)0;
        //    string str1 = "";
        //    List<long> nums = new List<long>();
        //    foreach (RulesVO rulesVO in rulesVOs)
        //    {
        //        RulesVO rulesVO1 = (
        //            from map in rulesVOs
        //            where map.Sno == rulesVO.Sno
        //            select map into mp
        //            orderby mp.Priority
        //            select mp).FirstOrDefault<RulesVO>();
        //        List<AdditionalRulesVO> list1 = (
        //            from aar in ruleDAO1.Get_AdditionalRules()
        //            where aar.RuleNo == rulesVO1.Sno
        //            select aar).ToList<AdditionalRulesVO>();
        //        if (list1.Count > 0)
        //        {
        //            foreach (AdditionalRulesVO additionalRulesVO in list1)
        //            {
        //                string lagan = additionalRulesVO.Lagan;
        //                char[] chrArray = new char[] { ',' };
        //                string[] array = lagan.Split(chrArray).ToArray<string>();
        //                for (int i = 0; i < array.Count<string>(); i++)
        //                {
        //                    if ((long)Convert.ToInt32(array[i].ToString()) == persKV.Lagna)
        //                    {
        //                        additionalRulesVOs.Add(additionalRulesVO);
        //                        rulesVOs1.Add(rulesVO);
        //                    }
        //                }
        //            }
        //            RulesVO rulesVO2 = (
        //                from map in rulesVOs1
        //                orderby map.Priority
        //                select map).FirstOrDefault<RulesVO>();
        //            if (rulesVO2 != null)
        //            {
        //                if (rulesVO2.Priority != 0)
        //                {
        //                    (
        //                        from aar in ruleDAO1.Get_AdditionalRules()
        //                        where aar.RuleNo == rulesVO2.Sno
        //                        select aar).FirstOrDefault<AdditionalRulesVO>();
        //                    if ((priority == (long)0 ? true : priority > (long)rulesVO2.Priority))
        //                    {
        //                        if (!nums.Contains(rulesVO2.Sno))
        //                        {
        //                            str1 = string.Concat("\r\n", ruleDAO.Get_Lang(rulesVO2.RefNo, persKV.Language, persKV.Paid, false).Common_Pred);
        //                            priority = (long)rulesVO2.Priority;
        //                            nums.Add(rulesVO2.Sno);
        //                            if (persKV.ShowRef)
        //                            {
        //                                str1 = string.Concat(str1, "\r\n", rulesVO2.Sno);
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    str = string.Concat("\r\n", str1);
        //    if (str.Trim().Length > 5)
        //    {
        //        str = string.Concat("\r\n\r\n", codeLang, "\r\n", str);
        //    }
        //    return str;
        //}

        //public string GetAntar(string planet)
        //{
        //    string str = "";
        //    DbCommand dbCommand = MatchDL.GenericDataAccess.CreateCommand();
        //    dbCommand.CommandType = CommandType.Text;
        //    dbCommand.CommandText = string.Concat("select * from A_35years (nolock)  where planet='", planet, "'");
        //    foreach (DataRow row in MatchDL.GenericDataAccess.ExecuteSelectCommand(dbCommand).Rows)
        //    {
        //        string[] strArrays = new string[] { row["mid1"].ToString(), "/", row["mid2"].ToString(), "/", row["mid3"].ToString() };
        //        str = string.Concat(strArrays);
        //    }
        //    return str;
        //}

        public string GetCodeLang(string rulecode, string lang, bool paid, bool unicode)
        {
            #region Old Code

            //string str = "";
            //lang = lang.ToLower();
            //try
            //{
            //    RuleDAO ruleDAO = new RuleDAO();
            //    var codeLangVOs = ruleDAO.Get_Code_Lang(paid, unicode);

            //    CodeLangVO codeLangVO = (
            //        from aa in ruleDAO.Get_Code_Lang(paid, unicode)
            //        where aa.rulecode.Trim().ToLower() == rulecode.Trim().ToLower()
            //        select aa).FirstOrDefault<CodeLangVO>();

            //    string str1 = lang;
            //    if (str1 != null)
            //    {
            //        switch (str1)
            //        {
            //            case "hindi":
            //                {
            //                    str = codeLangVO.hindi;
            //                    break;
            //                }
            //            case "english":
            //                {
            //                    str = codeLangVO.english;
            //                    break;
            //                }
            //            case "tamil":
            //                {
            //                    str = codeLangVO.tamil;
            //                    break;
            //                }
            //            case "bangla":
            //                {
            //                    str = codeLangVO.bangla;
            //                    break;
            //                }
            //            case "telugu":
            //                {
            //                    str = codeLangVO.telugu;
            //                    break;
            //                }
            //            case "kannada":
            //                {
            //                    str = codeLangVO.kannada;
            //                    break;
            //                }
            //            case "marathi":
            //                {
            //                    str = codeLangVO.marathi;
            //                    break;
            //                }
            //            case "gujarati":
            //                {
            //                    str = codeLangVO.gujrati;
            //                    break;
            //                }
            //            case "punjabi":
            //                {
            //                    str = codeLangVO.punjabi;
            //                    break;
            //                }
            //            case "oriya":
            //                {
            //                    str = codeLangVO.oriya;
            //                    break;
            //                }
            //            case "malayalam":
            //                {
            //                    str = codeLangVO.malayalam;
            //                    break;
            //                }
            //            case "assamese":
            //                {
            //                    str = codeLangVO.assamese;
            //                    break;
            //                }
            //        }
            //    }
            //}
            //catch (Exception exception)
            //{
            //    _ = exception;
            //}
            //return str;
            #endregion

            string str = "";
            try
            {
                RuleDAO ruleDAO = new RuleDAO();
                var codeLangVOs = ruleDAO.Get_Code_Lang(paid, unicode);

                CodeLangVO codeLangVO = codeLangVOs.Where(aa => aa.rulecode.Trim().ToLower() == rulecode.Trim().ToLower()).FirstOrDefault<CodeLangVO>();

                if (codeLangVO == null) return "";

                if (lang != null)
                {
                    switch (lang.ToLower())
                    {
                        case "hindi":
                            {
                                str = codeLangVO.hindi;
                                break;
                            }
                        case "english":
                            {
                                str = codeLangVO.english;
                                break;
                            }
                        case "tamil":
                            {
                                str = codeLangVO.tamil;
                                break;
                            }
                        case "bangla":
                            {
                                str = codeLangVO.bangla;
                                break;
                            }
                        case "telugu":
                            {
                                str = codeLangVO.telugu;
                                break;
                            }
                        case "kannada":
                            {
                                str = codeLangVO.kannada;
                                break;
                            }
                        case "marathi":
                            {
                                str = codeLangVO.marathi;
                                break;
                            }
                        case "gujarati":
                            {
                                str = codeLangVO.gujrati;
                                break;
                            }
                        case "punjabi":
                            {
                                str = codeLangVO.punjabi;
                                break;
                            }
                        case "oriya":
                            {
                                str = codeLangVO.oriya;
                                break;
                            }
                        case "malayalam":
                            {
                                str = codeLangVO.malayalam;
                                break;
                            }
                        case "assamese":
                            {
                                str = codeLangVO.assamese;
                                break;
                            }
                    }
                }
            }
            catch (Exception exception)
            {
                _ = exception;
            }
            return str;
        }

        public string GetCodeLang(string rulecode, string lang, bool paid)
        {
            bool flag = false;
            RuleDAO ruleDAO = new RuleDAO();
            lang = lang.ToLower();
            CodeLangVO codeLangVO = (
                from aa in ruleDAO.Get_Code_Lang(paid, flag)
                where aa.rulecode.Trim().ToLower() == rulecode.Trim().ToLower()
                select aa).FirstOrDefault<CodeLangVO>();
            string str = "";
            try
            {
                string str1 = lang;
                if (str1 != null)
                {
                    switch (str1)
                    {
                        case "hindi":
                            {
                                str = codeLangVO.hindi;
                                break;
                            }
                        case "english":
                            {
                                str = codeLangVO.english;
                                break;
                            }
                        case "tamil":
                            {
                                str = codeLangVO.tamil;
                                break;
                            }
                        case "bangla":
                            {
                                str = codeLangVO.bangla;
                                break;
                            }
                        case "telugu":
                            {
                                str = codeLangVO.telugu;
                                break;
                            }
                        case "kannada":
                            {
                                str = codeLangVO.kannada;
                                break;
                            }
                        case "marathi":
                            {
                                str = codeLangVO.marathi;
                                break;
                            }
                        case "gujarati":
                            {
                                str = codeLangVO.gujrati;
                                break;
                            }
                        case "punjabi":
                            {
                                str = codeLangVO.punjabi;
                                break;
                            }
                    }
                }
            }
            catch (Exception exception)
            {
                _ = exception;
            }
            return str;
        }

        //public string GetDayFal(KundliVO perskv, List<KundliMappingVO> lkmv, short year, short smonth, short day, bool showref, bool marking, bool male, string janamsamay, string lang, bool paid, DateTime wdate)
        //{
        //    RulesVO rulesVO = null;
        //    bool house;
        //    string str = "";
        //    long num = (long)0;
        //    bool isBad = false;
        //    this.paidpred = paid;
        //    PredictionBLL predictionBLL = new PredictionBLL();
        //    List<KundliMappingVO> kundliMappingVOs = new List<KundliMappingVO>();
        //    List<KundliMappingVO> monthlyKundli = new List<KundliMappingVO>();
        //    GetPlanetVO getPlanetVO = new GetPlanetVO();
        //    KundliBLL kundliBLL = new KundliBLL();
        //    RuleBLL ruleBLL = new RuleBLL();
        //    string str1 = "";
        //    bool flag = false;
        //    if (perskv.Sub_prodtype == "mobile")
        //    {
        //        flag = true;
        //    }
        //    foreach (short num1 in new List<short>()
        //    {
        //        smonth
        //    })
        //    {
        //        monthlyKundli = kundliBLL.GetMonthlyKundli(year, num1, perskv, lkmv);
        //        kundliMappingVOs = kundliBLL.GetDayKundli(year, num1, day - 1, perskv, monthlyKundli);
        //        ruleBLL.CalcKundliPlanets(kundliMappingVOs);
        //        int num2 = 2;
        //        Years35BLL years35BLL = new Years35BLL();
        //        PlanetBLL planetBLL = new PlanetBLL();
        //        List<Years35VO> years35VOs = years35BLL.Get35Years(janamsamay);
        //        AstroDAL astroDAL = new AstroDAL();
        //        string str2 = (
        //            from map in years35VOs
        //            where map.Years == (long)year
        //            select map).FirstOrDefault<Years35VO>().Planet.ToString();
        //        List<PlanetHouseMappingVO> planetHouseMappingVOs = new List<PlanetHouseMappingVO>();
        //        long house1 = (long)(
        //            from lk in kundliMappingVOs
        //            where lk.PlanetName.Equals(str2)
        //            select lk).FirstOrDefault<KundliMappingVO>().House;
        //        planetHouseMappingVOs = (
        //            from pk in planetBLL.GetPakkeGhar()
        //            where (long)pk.House == house1
        //            select pk).ToList<PlanetHouseMappingVO>();
        //        long num3 = (long)0;
        //        if ((house1 == (long)1 || house1 == (long)7 || house1 == (long)4 ? true : house1 == (long)10))
        //        {
        //            num3 = (house1 + (long)6) % (long)12;
        //        }
        //        short num4 = 0;
        //        foreach (KundliMappingVO kundliMappingVO in kundliMappingVOs)
        //        {
        //            num = (long)0;
        //            List<RulesVO> list = (
        //                from Rules in kundliBLL.GetAdvancePredictions(kundliMappingVOs, kundliMappingVO.Planet, num2)
        //                where (Rules.Isbad != kundliMappingVO.VIsBad ? false : Rules.RuleType == "dfal")
        //                select Rules).ToList<RulesVO>();
        //            num = Convert.ToInt64((
        //                from Map in years35VOs
        //                where (Map.Years != (long)year ? false : (Map.Period.Contains(kundliMappingVO.PlanetName) ? true : Map.Planet == kundliMappingVO.PlanetName))
        //                select Map).Count<Years35VO>());
        //            if (num > (long)0)
        //            {
        //                isBad = (
        //                    from Map in lkmv
        //                    where Map.PlanetName == kundliMappingVO.PlanetName
        //                    select Map).SingleOrDefault<KundliMappingVO>().IsBad;
        //            }
        //            if (num < (long)1)
        //            {
        //                if ((
        //                    from pp in planetHouseMappingVOs
        //                    where pp.Planet == kundliMappingVO.Planet
        //                    select pp).Count<PlanetHouseMappingVO>() > 0)
        //                {
        //                    goto Label1;
        //                }
        //                house = (long)kundliMappingVO.House != num3;
        //                goto Label0;
        //            }
        //        Label1:
        //            house = false;
        //        Label0:
        //            if (!house)
        //            {
        //                if (num4 != day)
        //                {
        //                    str1 = string.Concat(str1, "\r\n\r\n");
        //                    string str3 = str1;
        //                    string[] codeLang = new string[] { str3, predictionBLL.GetCodeLang("day", perskv.Language, perskv.Paid, flag), " ", wdate.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", wdate.ToString("%M")), perskv.Language, perskv.Paid, flag), " ", wdate.ToString("yyyy") };
        //                    str1 = string.Concat(codeLang);
        //                    str1 = string.Concat(str1, "\r\n");
        //                }
        //                num4 = day;
        //                if (marking)
        //                {
        //                    foreach (RulesVO rulesVO in list)
        //                    {
        //                        str = (year < 18 ? this.Get_Pred_Text(rulesVO.Sno, lang, male, false, showref, true, paid, true, flag, perskv) : this.Get_Pred_Text(rulesVO.Sno, lang, male, true, showref, true, paid, true, flag, perskv));
        //                        str = string.Concat(str, "\r\n");
        //                        if (!showref)
        //                        {
        //                            str1 = string.Concat(str1, str);
        //                        }
        //                        else
        //                        {
        //                            object obj = str1;
        //                            object[] sno = new object[] { obj, str, "   ", rulesVO.Sno, "  ", ruleBLL.GetPlanetByRuleNo(rulesVO.Sno).Planet, " ", ruleBLL.GetPlanetByRuleNo(rulesVO.Sno).House, " ", rulesVO.Reference };
        //                            str1 = string.Concat(sno);
        //                        }
        //                    }
        //                }
        //            }
        //            if (!marking)
        //            {
        //                foreach (RulesVO rulesVO1 in list)
        //                {
        //                    str = (year < 18 ? this.Get_Pred_Text(rulesVO1.Sno, lang, male, false, showref, true, paid, true, flag, perskv) : this.Get_Pred_Text(rulesVO1.Sno, lang, male, true, showref, true, paid, true, flag, perskv));
        //                    str = string.Concat(str, "\r\n");
        //                    long length = (long)str.Length;
        //                    if (!paid)
        //                    {
        //                        length = (!kundliMappingVO.VIsBad ? (long)str.IndexOf("vr% 'kqHk Qyksa") : (long)str.IndexOf("vr% v'kqHk Qyksa"));
        //                    }
        //                    if (lang == "english")
        //                    {
        //                        length = (long)str.ToLower().IndexOf("do the following remedies");
        //                    }
        //                    str1 = string.Concat(str1, str.Substring(0, Convert.ToInt16(length)));
        //                    str1 = string.Concat(str1, "\r\n");
        //                }
        //            }
        //        }
        //    }
        //    return str1;
        //}

        //public string GetFutureVFAL(KundliVO persKV)
        //{
        //    int num;
        //    bool flag;
        //    bool flag1;
        //    bool flag2;
        //    bool flag3;
        //    bool flag4;
        //    bool flag5;
        //    List<KundliMappingVO> kundliMappingVOs = this.map_kundali(persKV.Online_Result, true);
        //    KundliBLL kundliBLL = new KundliBLL();
        //    List<KundliMappingVO> kundliMappingVOs1 = kundliBLL.RotateKundliMappings(kundliMappingVOs, persKV.Rotate, persKV);
        //    bool male = persKV.Male;
        //    string language = persKV.Language;
        //    bool paid = persKV.Paid;
        //    string dD = persKV.DD;
        //    string mM = persKV.MM;
        //    string yY = persKV.YY;
        //    string hH = persKV.HH;
        //    string mIN = persKV.MIN;
        //    bool showRef = persKV.ShowRef;
        //    List<long> nums = new List<long>();
        //    PlanetBLL planetBLL = new PlanetBLL();
        //    RuleBLL ruleBLL = new RuleBLL();
        //    List<Life35VO> life35VOs = new List<Life35VO>();
        //    string str = "";
        //    List<RulesVO> rulesVOs = new List<RulesVO>();
        //    KundliBLL kundliBLL1 = new KundliBLL();
        //    PredictionBLL predictionBLL = new PredictionBLL();
        //    List<PlanetMAPVO> planetMAPVOs = new List<PlanetMAPVO>();
        //    planetMAPVOs = planetBLL.FillAllPlanets();
        //    BasicruleBLL basicruleBLL = new BasicruleBLL();
        //    RuleBLL ruleBLL1 = new RuleBLL();
        //    RuleDAO ruleDAO = new RuleDAO();
        //    life35VOs = kundliBLL1.GetLife35(persKV.JanamSamay);
        //    string str1 = "";
        //    foreach (Life35VO life35VO in life35VOs)
        //    {
        //        List<long> nums1 = new List<long>();
        //        string str2 = "";
        //        KundliMappingVO kundliMappingVO = new KundliMappingVO();
        //        kundliMappingVO = (
        //            from Map in kundliMappingVOs1
        //            where Map.PlanetName == life35VO.Planet
        //            select Map).SingleOrDefault<KundliMappingVO>();
        //        List<RulesVO> list = new List<RulesVO>();
        //        Years35BLL years35BLL = new Years35BLL();
        //        List<Years35VO> years35VOs = years35BLL.Get35Years(persKV.JanamSamay);
        //        long umra = years35BLL.GetUmra(kundliMappingVO.PlanetName) - (long)1;
        //        long num1 = Convert.ToInt64((
        //            from Map in years35VOs
        //            where Map.Planet == kundliMappingVO.PlanetName
        //            select Map).Min<Years35VO>((Years35VO Map) => Map.Years));
        //        str2 = string.Concat(str2, this.lrs.getPrabhav(num1, umra, language).ToString());
        //        list = kundliBLL1.GetAdvancePredictions(kundliMappingVOs1, kundliMappingVO.Planet, 0).ToList<RulesVO>();
        //        if (persKV.Male)
        //        {
        //            list = (
        //                from Map in list
        //                where (Map.Common ? true : Map.Male)
        //                select Map).ToList<RulesVO>();
        //        }
        //        if (!persKV.Male)
        //        {
        //            list = (
        //                from Map in list
        //                where (Map.Common ? true : Map.Female)
        //                select Map).ToList<RulesVO>();
        //        }
        //        List<DataAccess.Core.iAstroUpayVO> iAstroUpayVOs = new List<DataAccess.Core.iAstroUpayVO>();
        //        rulesVOs = (
        //            from Rules in list
        //            where (Rules.RuleType == "general" || Rules.RuleType == "triangle" || Rules.RuleType == "any" ? true : (!Rules.Reference.Contains("Indian Astrology") ? false : Rules.Ruleformula.Contains("&")))
        //            select Rules into Map
        //            orderby Map.RuleType
        //            select Map).ToList<RulesVO>();
        //        List<RulesVO> rulesVOs1 = new List<RulesVO>();
        //        RuleDAO ruleDAO1 = new RuleDAO();
        //        foreach (RulesVO rulesVO in rulesVOs)
        //        {
        //            iAstroUpayVOs = (
        //                from rr in ruleDAO1.Get_iAstroUpay()
        //                where (long)rr.ruleno == rulesVO.Sno
        //                select rr).ToList<DataAccess.Core.iAstroUpayVO>();
        //            foreach (DataAccess.Core.iAstroUpayVO iAstroUpayVO in iAstroUpayVOs)
        //            {
        //                if ((iAstroUpayVO.pred == null ? false : iAstroUpayVO.pred.Trim().Length > 0))
        //                {
        //                    if (iAstroUpayVO.vfal.Trim().Length > 0)
        //                    {
        //                        if ((iAstroUpayVO.vfal.Contains<char>('|') ? false : !iAstroUpayVO.vfal.Contains<char>('&')))
        //                        {
        //                            string str3 = "";
        //                            long num2 = Convert.ToInt64(iAstroUpayVO.vfal.ToString());
        //                            BasicruleBLL basicruleBLL1 = new BasicruleBLL();
        //                            (
        //                                from aa in ruleBLL.GetAllAdvanceRules()
        //                                where aa.Sno == (long)iAstroUpayVO.ruleno
        //                                select aa).FirstOrDefault<RulesVO>();
        //                            BasicruleVO basicruleVO = (
        //                                from ab in basicruleBLL1.GetAllBasicRule()
        //                                where (long)ab.Sno == num2
        //                                select ab).FirstOrDefault<BasicruleVO>();
        //                            (
        //                                from ab in basicruleBLL1.GetAllBasicRule()
        //                                where (long)ab.Sno == num2
        //                                select ab).FirstOrDefault<BasicruleVO>();
        //                            RuleBLL ruleBLL2 = new RuleBLL();
        //                            List<VarshPhalVO> vfalYearList = ruleBLL2.GetVfalYearList(Convert.ToInt32((
        //                                from Map in kundliMappingVOs1
        //                                where Map.Planet == basicruleVO.Planet
        //                                select Map).FirstOrDefault<KundliMappingVO>().House), basicruleVO.House);
        //                            foreach (VarshPhalVO varshPhalVO in vfalYearList)
        //                            {
        //                                num = varshPhalVO.age;
        //                                str3 = string.Concat(str3, num.ToString(), "]");
        //                            }
        //                            str3 = str3.Remove(str3.Length - 1);
        //                            string str4 = str1;
        //                            string[] codeLang = new string[] { str4, "\r\n", str3, " ", this.GetCodeLang("vfallist", language, paid, false), " " };
        //                            str1 = string.Concat(codeLang);
        //                            str1 = string.Concat(str1, this.getiastroupaybylang(iAstroUpayVO, language), "\r\n");
        //                        }
        //                        else
        //                        {
        //                            int num3 = iAstroUpayVO.sno;
        //                            switch (num3)
        //                            {
        //                                case 114:
        //                                    {
        //                                        if (((
        //                                            from li in kundliMappingVOs1
        //                                            where (li.House != 2 ? false : li.PlanetNameEnglish.Equals("ketu"))
        //                                            select li).Count<KundliMappingVO>() <= 0 ? false : (
        //                                            from li in kundliMappingVOs1
        //                                            where (li.House != 2 ? false : li.PlanetNameEnglish.Equals("chandra"))
        //                                            select li).Count<KundliMappingVO>() > 0))
        //                                        {
        //                                            str1 = string.Concat(str1, this.getiastroupaybylang(iAstroUpayVO, language));
        //                                            if (showRef)
        //                                            {
        //                                                num = iAstroUpayVO.sno;
        //                                                str1 = string.Concat(str1, "\r\n vfalastro ", num.ToString());
        //                                            }
        //                                        }
        //                                        break;
        //                                    }
        //                                case 115:
        //                                    {
        //                                        if ((
        //                                            from li in kundliMappingVOs1
        //                                            where li.House == 2
        //                                            select li).Count<KundliMappingVO>() == 0)
        //                                        {
        //                                            str1 = string.Concat(str1, this.getiastroupaybylang(iAstroUpayVO, language));
        //                                            if (showRef)
        //                                            {
        //                                                num = iAstroUpayVO.sno;
        //                                                str1 = string.Concat(str1, "\r\n vfalastro ", num.ToString());
        //                                            }
        //                                        }
        //                                        break;
        //                                    }
        //                                default:
        //                                    {
        //                                        if (num3 == 256)
        //                                        {
        //                                            if ((
        //                                                from li in kundliMappingVOs1
        //                                                where (li.House != 2 ? false : li.PlanetNameEnglish.Equals("rahu"))
        //                                                select li).Count<KundliMappingVO>() <= 0)
        //                                            {
        //                                                flag = true;
        //                                            }
        //                                            else
        //                                            {
        //                                                flag = ((
        //                                                    from li in kundliMappingVOs1
        //                                                    where (li.House != 1 ? false : li.PlanetNameEnglish.Equals("sun"))
        //                                                    select li).Count<KundliMappingVO>() > 0 ? false : (
        //                                                    from li in kundliMappingVOs1
        //                                                    where (li.House != 1 ? false : li.PlanetNameEnglish.Equals("moon"))
        //                                                    select li).Count<KundliMappingVO>() <= 0);
        //                                            }
        //                                            if (!flag)
        //                                            {
        //                                                str1 = string.Concat(str1, this.getiastroupaybylang(iAstroUpayVO, language));
        //                                                if (showRef)
        //                                                {
        //                                                    num = iAstroUpayVO.sno;
        //                                                    str1 = string.Concat(str1, "\r\n vfalastro ", num.ToString());
        //                                                }
        //                                            }
        //                                            break;
        //                                        }
        //                                        else
        //                                        {
        //                                            switch (num3)
        //                                            {
        //                                                case 312:
        //                                                    {
        //                                                        if (((
        //                                                            from li in kundliMappingVOs1
        //                                                            where (li.House != 2 ? false : li.PlanetNameEnglish.Equals("ketu"))
        //                                                            select li).Count<KundliMappingVO>() <= 0 ? false : (
        //                                                            from li in kundliMappingVOs1
        //                                                            where (li.House != 2 ? false : li.PlanetNameEnglish.Equals("moon"))
        //                                                            select li).Count<KundliMappingVO>() > 0))
        //                                                        {
        //                                                            str1 = string.Concat(str1, this.getiastroupaybylang(iAstroUpayVO, language));
        //                                                            if (showRef)
        //                                                            {
        //                                                                num = iAstroUpayVO.sno;
        //                                                                str1 = string.Concat(str1, "\r\n vfalastro ", num.ToString());
        //                                                            }
        //                                                        }
        //                                                        break;
        //                                                    }
        //                                                case 315:
        //                                                    {
        //                                                        if (((
        //                                                            from li in kundliMappingVOs1
        //                                                            where (li.House != 4 ? false : li.PlanetNameEnglish.Equals("jupiter"))
        //                                                            select li).Count<KundliMappingVO>() <= 0 ? false : (
        //                                                            from li in kundliMappingVOs1
        //                                                            where (li.House != 4 ? false : li.PlanetNameEnglish.Equals("moon"))
        //                                                            select li).Count<KundliMappingVO>() > 0))
        //                                                        {
        //                                                            str1 = string.Concat(str1, this.getiastroupaybylang(iAstroUpayVO, language));
        //                                                            if (showRef)
        //                                                            {
        //                                                                num = iAstroUpayVO.sno;
        //                                                                str1 = string.Concat(str1, "\r\n vfalastro ", num.ToString());
        //                                                            }
        //                                                        }
        //                                                        break;
        //                                                    }
        //                                                case 317:
        //                                                    {
        //                                                        if ((
        //                                                            from li in kundliMappingVOs1
        //                                                            where (!li.PlanetNameEnglish.Equals("saturn") ? false : (li.House == 2 || li.House == 7 || li.House == 9 ? true : li.House == 12))
        //                                                            select li).Count<KundliMappingVO>() > 0)
        //                                                        {
        //                                                            str1 = string.Concat(str1, this.getiastroupaybylang(iAstroUpayVO, language));
        //                                                            if (showRef)
        //                                                            {
        //                                                                num = iAstroUpayVO.sno;
        //                                                                str1 = string.Concat(str1, "\r\n vfalastro ", num.ToString());
        //                                                            }
        //                                                        }
        //                                                        break;
        //                                                    }
        //                                                case 320:
        //                                                    {
        //                                                        if ((
        //                                                            from li in kundliMappingVOs1
        //                                                            where (!li.PlanetNameEnglish.Equals("saturn") ? false : (li.House == 5 ? true : li.House == 7))
        //                                                            select li).Count<KundliMappingVO>() <= 0)
        //                                                        {
        //                                                            if ((
        //                                                                from li in kundliMappingVOs1
        //                                                                where (!li.PlanetNameEnglish.Equals("sun") ? false : (li.House == 5 ? true : li.House == 7))
        //                                                                select li).Count<KundliMappingVO>() > 0)
        //                                                            {
        //                                                                goto Label1;
        //                                                            }
        //                                                            flag1 = (
        //                                                                from li in kundliMappingVOs1
        //                                                                where (!li.PlanetNameEnglish.Equals("mangal") ? false : (li.House == 5 ? true : li.House == 7))
        //                                                                select li).Count<KundliMappingVO>() <= 0;
        //                                                            goto Label0;
        //                                                        }
        //                                                    Label1:
        //                                                        flag1 = false;
        //                                                    Label0:
        //                                                        if (!flag1)
        //                                                        {
        //                                                            str1 = string.Concat(str1, this.getiastroupaybylang(iAstroUpayVO, language));
        //                                                            if (showRef)
        //                                                            {
        //                                                                num = iAstroUpayVO.sno;
        //                                                                str1 = string.Concat(str1, "\r\n vfalastro ", num.ToString());
        //                                                            }
        //                                                        }
        //                                                        break;
        //                                                    }
        //                                                case 324:
        //                                                    {
        //                                                        if ((
        //                                                            from li in kundliMappingVOs1
        //                                                            where (li.House != 1 ? false : (!li.PlanetNameEnglish.Equals("jupiter") ? false : li.PlanetNameEnglish.Equals("mercury")))
        //                                                            select li).Count<KundliMappingVO>() > 0)
        //                                                        {
        //                                                            str1 = string.Concat(str1, this.getiastroupaybylang(iAstroUpayVO, language));
        //                                                            if (showRef)
        //                                                            {
        //                                                                num = iAstroUpayVO.sno;
        //                                                                str1 = string.Concat(str1, "\r\n vfalastro ", num.ToString());
        //                                                            }
        //                                                        }
        //                                                        break;
        //                                                    }
        //                                                case 325:
        //                                                    {
        //                                                        if ((
        //                                                            from li in kundliMappingVOs1
        //                                                            where (li.House != 2 ? false : (!li.PlanetNameEnglish.Equals("jupiter") ? false : li.PlanetNameEnglish.Equals("saturn")))
        //                                                            select li).Count<KundliMappingVO>() > 0)
        //                                                        {
        //                                                            str1 = string.Concat(str1, this.getiastroupaybylang(iAstroUpayVO, language));
        //                                                            if (showRef)
        //                                                            {
        //                                                                num = iAstroUpayVO.sno;
        //                                                                str1 = string.Concat(str1, "\r\n vfalastro ", num.ToString());
        //                                                            }
        //                                                        }
        //                                                        break;
        //                                                    }
        //                                                case 326:
        //                                                    {
        //                                                        if ((
        //                                                            from li in kundliMappingVOs1
        //                                                            where (li.House != 1 ? false : (li.PlanetNameEnglish.Equals("moon") || li.PlanetNameEnglish.Equals("venus") ? true : li.PlanetNameEnglish.Equals("mars")))
        //                                                            select li).Count<KundliMappingVO>() > 0)
        //                                                        {
        //                                                            str1 = string.Concat(str1, this.getiastroupaybylang(iAstroUpayVO, language));
        //                                                            if (showRef)
        //                                                            {
        //                                                                num = iAstroUpayVO.sno;
        //                                                                str1 = string.Concat(str1, "\r\n vfalastro ", num.ToString());
        //                                                            }
        //                                                        }
        //                                                        break;
        //                                                    }
        //                                                case 328:
        //                                                    {
        //                                                        if (((
        //                                                            from li in kundliMappingVOs1
        //                                                            where (li.House != 8 ? false : li.PlanetNameEnglish.Equals("mercury"))
        //                                                            select li).Count<KundliMappingVO>() <= 0 ? false : (
        //                                                            from li in kundliMappingVOs1
        //                                                            where (li.House != 2 ? false : li.PlanetNameEnglish.Equals("jupiter"))
        //                                                            select li).Count<KundliMappingVO>() > 0))
        //                                                        {
        //                                                            str1 = string.Concat(str1, this.getiastroupaybylang(iAstroUpayVO, language));
        //                                                            if (showRef)
        //                                                            {
        //                                                                num = iAstroUpayVO.sno;
        //                                                                str1 = string.Concat(str1, "\r\n vfalastro ", num.ToString());
        //                                                            }
        //                                                        }
        //                                                        break;
        //                                                    }
        //                                                case 329:
        //                                                    {
        //                                                        if (((
        //                                                            from li in kundliMappingVOs1
        //                                                            where (li.House != 3 ? false : li.PlanetNameEnglish.Equals("moon"))
        //                                                            select li).Count<KundliMappingVO>() <= 0 ? false : (
        //                                                            from li in kundliMappingVOs1
        //                                                            where (li.House != 11 ? false : li.PlanetNameEnglish.Equals("mercury"))
        //                                                            select li).Count<KundliMappingVO>() > 0))
        //                                                        {
        //                                                            str1 = string.Concat(str1, this.getiastroupaybylang(iAstroUpayVO, language));
        //                                                            if (showRef)
        //                                                            {
        //                                                                num = iAstroUpayVO.sno;
        //                                                                str1 = string.Concat(str1, "\r\n vfalastro ", num.ToString());
        //                                                            }
        //                                                        }
        //                                                        break;
        //                                                    }
        //                                                case 332:
        //                                                    {
        //                                                        if ((
        //                                                            from li in kundliMappingVOs1
        //                                                            where (li.House != 9 ? false : (!li.PlanetNameEnglish.Equals("jupiter") ? false : li.PlanetNameEnglish.Equals("moon")))
        //                                                            select li).Count<KundliMappingVO>() > 0)
        //                                                        {
        //                                                            str1 = string.Concat(str1, this.getiastroupaybylang(iAstroUpayVO, language));
        //                                                            if (showRef)
        //                                                            {
        //                                                                num = iAstroUpayVO.sno;
        //                                                                str1 = string.Concat(str1, "\r\n vfalastro ", num.ToString());
        //                                                            }
        //                                                        }
        //                                                        break;
        //                                                    }
        //                                                case 333:
        //                                                    {
        //                                                        if ((
        //                                                            from li in kundliMappingVOs1
        //                                                            where (li.House != 10 ? false : (!li.PlanetNameEnglish.Equals("jupiter") ? false : li.PlanetNameEnglish.Equals("moon")))
        //                                                            select li).Count<KundliMappingVO>() > 0)
        //                                                        {
        //                                                            str1 = string.Concat(str1, this.getiastroupaybylang(iAstroUpayVO, language));
        //                                                            if (showRef)
        //                                                            {
        //                                                                num = iAstroUpayVO.sno;
        //                                                                str1 = string.Concat(str1, "\r\n vfalastro ", num.ToString());
        //                                                            }
        //                                                        }
        //                                                        break;
        //                                                    }
        //                                                case 336:
        //                                                    {
        //                                                        if ((
        //                                                            from li in kundliMappingVOs1
        //                                                            where (!li.PlanetNameEnglish.Equals("saturn") ? false : (li.House == 7 ? true : li.House == 9))
        //                                                            select li).Count<KundliMappingVO>() > 0)
        //                                                        {
        //                                                            if ((
        //                                                                from li in kundliMappingVOs1
        //                                                                where (li.House != 7 ? false : li.PlanetNameEnglish.Equals("mars"))
        //                                                                select li).Count<KundliMappingVO>() <= 0)
        //                                                            {
        //                                                                goto Label3;
        //                                                            }
        //                                                            flag2 = (
        //                                                                from li in kundliMappingVOs1
        //                                                                where (li.House != 7 ? false : (li.PlanetNameEnglish.Equals("sun") ? true : li.PlanetNameEnglish.Equals("moon")))
        //                                                                select li).Count<KundliMappingVO>() <= 0;
        //                                                            goto Label2;
        //                                                        }
        //                                                    Label3:
        //                                                        flag2 = true;
        //                                                    Label2:
        //                                                        if (!flag2)
        //                                                        {
        //                                                            str1 = string.Concat(str1, this.getiastroupaybylang(iAstroUpayVO, language));
        //                                                            if (showRef)
        //                                                            {
        //                                                                num = iAstroUpayVO.sno;
        //                                                                str1 = string.Concat(str1, "\r\n vfalastro ", num.ToString());
        //                                                            }
        //                                                        }
        //                                                        break;
        //                                                    }
        //                                                case 337:
        //                                                    {
        //                                                        if ((
        //                                                            from li in kundliMappingVOs1
        //                                                            where (li.House == 1 || li.House == 3 ? (li.PlanetNameEnglish.Equals("ketu") || li.PlanetNameEnglish.Equals("saturn") ? true : li.PlanetNameEnglish.Equals("rahu")) : false)
        //                                                            select li).Count<KundliMappingVO>() > 0)
        //                                                        {
        //                                                            str1 = string.Concat(str1, this.getiastroupaybylang(iAstroUpayVO, language));
        //                                                            if (showRef)
        //                                                            {
        //                                                                num = iAstroUpayVO.sno;
        //                                                                str1 = string.Concat(str1, "\r\n vfalastro ", num.ToString());
        //                                                            }
        //                                                        }
        //                                                        break;
        //                                                    }
        //                                                case 338:
        //                                                    {
        //                                                        if ((
        //                                                            from li in kundliMappingVOs1
        //                                                            where (li.House != 7 ? false : (!li.PlanetNameEnglish.Equals("sun") ? false : li.PlanetNameEnglish.Equals("saturn")))
        //                                                            select li).Count<KundliMappingVO>() > 0)
        //                                                        {
        //                                                            str1 = string.Concat(str1, this.getiastroupaybylang(iAstroUpayVO, language));
        //                                                            if (showRef)
        //                                                            {
        //                                                                num = iAstroUpayVO.sno;
        //                                                                str1 = string.Concat(str1, "\r\n vfalastro ", num.ToString());
        //                                                            }
        //                                                        }
        //                                                        break;
        //                                                    }
        //                                                case 339:
        //                                                    {
        //                                                        if ((
        //                                                            from li in kundliMappingVOs1
        //                                                            where (li.House != 2 ? false : (!li.PlanetNameEnglish.Equals("jupiter") || !li.PlanetNameEnglish.Equals("moon") ? false : li.PlanetNameEnglish.Equals("venus")))
        //                                                            select li).Count<KundliMappingVO>() > 0)
        //                                                        {
        //                                                            str1 = string.Concat(str1, this.getiastroupaybylang(iAstroUpayVO, language));
        //                                                            if (showRef)
        //                                                            {
        //                                                                num = iAstroUpayVO.sno;
        //                                                                str1 = string.Concat(str1, "\r\n vfalastro ", num.ToString());
        //                                                            }
        //                                                        }
        //                                                        break;
        //                                                    }
        //                                                case 340:
        //                                                    {
        //                                                        if (((
        //                                                            from li in kundliMappingVOs1
        //                                                            where (li.House != 2 ? false : li.PlanetNameEnglish.Equals("moon"))
        //                                                            select li).Count<KundliMappingVO>() <= 0 ? false : (
        //                                                            from li in kundliMappingVOs1
        //                                                            where (li.House != 8 ? false : li.PlanetNameEnglish.Equals("mercury"))
        //                                                            select li).Count<KundliMappingVO>() > 0))
        //                                                        {
        //                                                            str1 = string.Concat(str1, this.getiastroupaybylang(iAstroUpayVO, language));
        //                                                            if (showRef)
        //                                                            {
        //                                                                num = iAstroUpayVO.sno;
        //                                                                str1 = string.Concat(str1, "\r\n vfalastro ", num.ToString());
        //                                                            }
        //                                                        }
        //                                                        break;
        //                                                    }
        //                                                case 341:
        //                                                    {
        //                                                        if (((
        //                                                            from li in kundliMappingVOs1
        //                                                            where (li.House != 2 ? false : li.PlanetNameEnglish.Equals("ketu"))
        //                                                            select li).Count<KundliMappingVO>() <= 0 ? false : (
        //                                                            from li in kundliMappingVOs1
        //                                                            where (li.House != 8 ? false : li.PlanetNameEnglish.Equals("mercury"))
        //                                                            select li).Count<KundliMappingVO>() > 0))
        //                                                        {
        //                                                            str1 = string.Concat(str1, this.getiastroupaybylang(iAstroUpayVO, language));
        //                                                            if (showRef)
        //                                                            {
        //                                                                num = iAstroUpayVO.sno;
        //                                                                str1 = string.Concat(str1, "\r\n vfalastro ", num.ToString());
        //                                                            }
        //                                                        }
        //                                                        break;
        //                                                    }
        //                                                case 344:
        //                                                    {
        //                                                        if (((
        //                                                            from li in kundliMappingVOs1
        //                                                            where (li.House != 12 ? false : li.PlanetNameEnglish.Equals("mercury"))
        //                                                            select li).Count<KundliMappingVO>() <= 0 ? false : (
        //                                                            from li in kundliMappingVOs1
        //                                                            where (li.House != 6 ? false : li.PlanetNameEnglish.Equals("sun"))
        //                                                            select li).Count<KundliMappingVO>() > 0))
        //                                                        {
        //                                                            str1 = string.Concat(str1, this.getiastroupaybylang(iAstroUpayVO, language));
        //                                                            if (showRef)
        //                                                            {
        //                                                                num = iAstroUpayVO.sno;
        //                                                                str1 = string.Concat(str1, "\r\n vfalastro ", num.ToString());
        //                                                            }
        //                                                        }
        //                                                        break;
        //                                                    }
        //                                                case 345:
        //                                                    {
        //                                                        if ((
        //                                                            from li in kundliMappingVOs1
        //                                                            where (li.House != 1 ? false : li.PlanetNameEnglish.Equals("mercury"))
        //                                                            select li).Count<KundliMappingVO>() > 0)
        //                                                        {
        //                                                            if ((
        //                                                                from li in kundliMappingVOs1
        //                                                                where (li.House != 1 ? false : li.PlanetNameEnglish.Equals("ketu"))
        //                                                                select li).Count<KundliMappingVO>() <= 0)
        //                                                            {
        //                                                                goto Label5;
        //                                                            }
        //                                                            flag3 = (
        //                                                                from li in kundliMappingVOs1
        //                                                                where (li.House != 8 ? false : li.PlanetNameEnglish.Equals("saturn"))
        //                                                                select li).Count<KundliMappingVO>() <= 0;
        //                                                            goto Label4;
        //                                                        }
        //                                                    Label5:
        //                                                        flag3 = true;
        //                                                    Label4:
        //                                                        if (!flag3)
        //                                                        {
        //                                                            str1 = string.Concat(str1, this.getiastroupaybylang(iAstroUpayVO, language));
        //                                                            if (showRef)
        //                                                            {
        //                                                                num = iAstroUpayVO.sno;
        //                                                                str1 = string.Concat(str1, "\r\n vfalastro ", num.ToString());
        //                                                            }
        //                                                        }
        //                                                        break;
        //                                                    }
        //                                                case 346:
        //                                                    {
        //                                                        if ((
        //                                                            from li in kundliMappingVOs1
        //                                                            where (li.House != 7 ? false : li.PlanetNameEnglish.Equals("sun"))
        //                                                            select li).Count<KundliMappingVO>() <= 0)
        //                                                        {
        //                                                            if ((
        //                                                                from li in kundliMappingVOs1
        //                                                                where (li.House != 7 ? false : li.PlanetNameEnglish.Equals("moon"))
        //                                                                select li).Count<KundliMappingVO>() > 0)
        //                                                            {
        //                                                                goto Label7;
        //                                                            }
        //                                                            flag4 = (
        //                                                                from li in kundliMappingVOs1
        //                                                                where (li.House != 7 ? false : li.PlanetNameEnglish.Equals("mars"))
        //                                                                select li).Count<KundliMappingVO>() <= 0;
        //                                                            goto Label6;
        //                                                        }
        //                                                    Label7:
        //                                                        flag4 = false;
        //                                                    Label6:
        //                                                        if (!flag4)
        //                                                        {
        //                                                            str1 = string.Concat(str1, this.getiastroupaybylang(iAstroUpayVO, language));
        //                                                            if (showRef)
        //                                                            {
        //                                                                num = iAstroUpayVO.sno;
        //                                                                str1 = string.Concat(str1, "\r\n vfalastro ", num.ToString());
        //                                                            }
        //                                                        }
        //                                                        break;
        //                                                    }
        //                                                case 347:
        //                                                    {
        //                                                        if (((
        //                                                            from li in kundliMappingVOs1
        //                                                            where (li.House != 3 ? false : li.PlanetNameEnglish.Equals("rahu"))
        //                                                            select li).Count<KundliMappingVO>() > 0 ? true : (
        //                                                            from li in kundliMappingVOs1
        //                                                            where (li.House != 6 ? false : li.PlanetNameEnglish.Equals("rahu"))
        //                                                            select li).Count<KundliMappingVO>() > 0))
        //                                                        {
        //                                                            str1 = string.Concat(str1, this.getiastroupaybylang(iAstroUpayVO, language));
        //                                                            if (showRef)
        //                                                            {
        //                                                                num = iAstroUpayVO.sno;
        //                                                                str1 = string.Concat(str1, "\r\n vfalastro ", num.ToString());
        //                                                            }
        //                                                        }
        //                                                        break;
        //                                                    }
        //                                                case 351:
        //                                                    {
        //                                                        if ((
        //                                                            from li in kundliMappingVOs1
        //                                                            where (li.House != 1 ? false : li.PlanetNameEnglish.Equals("mars"))
        //                                                            select li).Count<KundliMappingVO>() <= 0)
        //                                                        {
        //                                                            if ((
        //                                                                from li in kundliMappingVOs1
        //                                                                where (li.House != 8 ? false : li.PlanetNameEnglish.Equals("mars"))
        //                                                                select li).Count<KundliMappingVO>() > 0)
        //                                                            {
        //                                                                goto Label9;
        //                                                            }
        //                                                            flag5 = (
        //                                                                from li in kundliMappingVOs1
        //                                                                where (li.House != 8 ? false : li.PlanetNameEnglish.Equals("saturn"))
        //                                                                select li).Count<KundliMappingVO>() <= 0;
        //                                                            goto Label8;
        //                                                        }
        //                                                    Label9:
        //                                                        flag5 = false;
        //                                                    Label8:
        //                                                        if (!flag5)
        //                                                        {
        //                                                            str1 = string.Concat(str1, this.getiastroupaybylang(iAstroUpayVO, language));
        //                                                            if (showRef)
        //                                                            {
        //                                                                num = iAstroUpayVO.sno;
        //                                                                str1 = string.Concat(str1, "\r\n vfalastro ", num.ToString());
        //                                                            }
        //                                                        }
        //                                                        break;
        //                                                    }
        //                                                case 353:
        //                                                    {
        //                                                        if (((
        //                                                            from li in kundliMappingVOs1
        //                                                            where (li.House != 11 ? false : li.PlanetNameEnglish.Equals("ketu"))
        //                                                            select li).Count<KundliMappingVO>() <= 0 ? false : (
        //                                                            from li in kundliMappingVOs1
        //                                                            where (li.House != 3 ? false : li.PlanetNameEnglish.Equals("mercury"))
        //                                                            select li).Count<KundliMappingVO>() > 0))
        //                                                        {
        //                                                            str1 = string.Concat(str1, this.getiastroupaybylang(iAstroUpayVO, language));
        //                                                            if (showRef)
        //                                                            {
        //                                                                num = iAstroUpayVO.sno;
        //                                                                str1 = string.Concat(str1, "\r\n vfalastro ", num.ToString());
        //                                                            }
        //                                                        }
        //                                                        break;
        //                                                    }
        //                                                case 356:
        //                                                    {
        //                                                        if (((
        //                                                            from li in kundliMappingVOs1
        //                                                            where (li.House != 2 ? false : li.PlanetNameEnglish.Equals("jupiter"))
        //                                                            select li).Count<KundliMappingVO>() <= 0 ? false : (
        //                                                            from li in kundliMappingVOs1
        //                                                            where (li.House != 2 ? false : li.PlanetNameEnglish.Equals("saturn"))
        //                                                            select li).Count<KundliMappingVO>() > 0))
        //                                                        {
        //                                                            str1 = string.Concat(str1, this.getiastroupaybylang(iAstroUpayVO, language));
        //                                                            if (showRef)
        //                                                            {
        //                                                                num = iAstroUpayVO.sno;
        //                                                                str1 = string.Concat(str1, "\r\n vfalastro ", num.ToString());
        //                                                            }
        //                                                        }
        //                                                        break;
        //                                                    }
        //                                            }
        //                                        }
        //                                        break;
        //                                    }
        //                            }
        //                        }
        //                    }
        //                    if (showRef)
        //                    {
        //                        num = iAstroUpayVO.sno;
        //                        str1 = string.Concat(str1, "\r\n", num.ToString());
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    str = string.Concat(str, "\r\n", str1);
        //    return str;
        //}

        //public string getiastroupaybylang(iAstroUpayVO avu, string lang)
        //{
        //    lang = lang.ToLower();
        //    string str = "";
        //    string str1 = lang;
        //    if (str1 != null)
        //    {
        //        switch (str1)
        //        {
        //            case "hindi":
        //                {
        //                    str = string.Concat(str, avu.pred);
        //                    break;
        //                }
        //            case "english":
        //                {
        //                    str = string.Concat(str, avu.pred_english);
        //                    break;
        //                }
        //            case "tamil":
        //                {
        //                    str = string.Concat(str, avu.pred_tamil);
        //                    break;
        //                }
        //            case "bangla":
        //                {
        //                    str = string.Concat(str, avu.pred_bangla);
        //                    break;
        //                }
        //            case "telugu":
        //                {
        //                    str = string.Concat(str, avu.pred_telugu);
        //                    break;
        //                }
        //            case "kannada":
        //                {
        //                    str = string.Concat(str, avu.pred_kannada);
        //                    break;
        //                }
        //            case "marathi":
        //                {
        //                    str = string.Concat(str, avu.pred_marathi);
        //                    break;
        //                }
        //            case "gujarati":
        //                {
        //                    str = string.Concat(str, avu.pred_gujarati);
        //                    break;
        //                }
        //            case "punjabi":
        //                {
        //                    str = string.Concat(str, avu.pred_punjabi);
        //                    break;
        //                }
        //        }
        //    }
        //    return str;
        //}

        //public string GetLifePrediction(KundliVO persKV, List<short> years, List<short> months, bool normaltext, bool onlyvfal, string prodtype)
        //{
        //    string str;
        //    int house;
        //    object obj;
        //    object[] codeLang;
        //    string str1;
        //    List<KundliMappingVO> kundliMappingVOs = this.map_kundali(persKV.Online_Result, true);
        //    kundliMappingVOs = (new KundliBLL()).RotateKundliMappings(kundliMappingVOs, 0, persKV);
        //    List<KundliMappingVO> kundliMappingVOs1 = kundliMappingVOs;
        //    string language = persKV.Language;
        //    bool showRef = persKV.ShowRef;
        //    bool male = persKV.Male;
        //    bool paid = persKV.Paid;
        //    bool flag = false;
        //    if (persKV.Sub_prodtype == "mobile")
        //    {
        //        flag = true;
        //    }
        //    string str2 = "";
        //    RuleBLL ruleBLL = new RuleBLL();
        //    RuleDAO ruleDAO = new RuleDAO();
        //    PlanetBLL planetBLL = new PlanetBLL();
        //    RuleBLL ruleBLL1 = new RuleBLL();
        //    List<Life35VO> life35VOs = new List<Life35VO>();
        //    List<RulesVO> rulesVOs = new List<RulesVO>();
        //    List<RulesVO> rulesVOs1 = new List<RulesVO>();
        //    life35VOs = (new KundliBLL()).GetLife35(persKV.JanamSamay);
        //    string[] dD = new string[] { persKV.DD, "/", persKV.MM, "/", persKV.YY };
        //    string str3 = string.Concat(dD);
        //    dD = new string[] { str3.ToString(), " ", persKV.HH, ":", persKV.MIN, ":00" };
        //    string.Concat(dD);
        //    if (persKV.Paid)
        //    {
        //        if (normaltext)
        //        {
        //            DateTime dateTime = new DateTime(Convert.ToInt16(persKV.YY), Convert.ToInt16(persKV.MM), Convert.ToInt16(persKV.DD));
        //            AstroDAL astroDAL = new AstroDAL();
        //            string lower = astroDAL.GetRashiById(persKV.Lagna).get_english().ToLower();
        //            str = str2;
        //            dD = new string[] { str, "\r\n\r\n", this.GetCodeLang("BirthDayPlanet", persKV.Language, persKV.Paid, flag).ToString(), " ", this.GetCodeLang(persKV.JanamDin, persKV.Language, persKV.Paid, flag).ToString(), "\r\n" };
        //            str2 = string.Concat(dD);
        //            str2 = string.Concat(str2, this.GetCodeLang("BirthTimePlanet", persKV.Language, persKV.Paid, flag).ToString(), " ", this.GetCodeLang(persKV.JanamSamay, persKV.Language, persKV.Paid, flag).ToString());
        //            str = str2;
        //            dD = new string[] { str, "\r\n", this.GetCodeLang("janamlagna", persKV.Language, persKV.Paid, flag).ToString(), "  ", this.GetCodeLang(lower, persKV.Language, persKV.Paid, flag).ToString(), "\r\n", this.GetCodeLang("janamrashi", persKV.Language, persKV.Paid, flag).ToString(), " ", this.GetCodeLang(persKV.Janam_rashi, persKV.Language, persKV.Paid, flag).ToString() };
        //            str2 = string.Concat(dD);
        //            str = str2;
        //            dD = new string[] { str, "\r\n", this.GetCodeLang("luckynumber", persKV.Language, persKV.Paid, flag).ToString(), " ", persKV.Lucky_number, "\r\n", this.GetCodeLang("luckyday", persKV.Language, persKV.Paid, flag).ToString(), " ", this.GetCodeLang(persKV.Lucky_day1, persKV.Language, persKV.Paid, flag).ToString(), " ", this.GetCodeLang(persKV.Lucky_day2, persKV.Language, persKV.Paid, flag).ToString() };
        //            str2 = string.Concat(dD);
        //            str = str2;
        //            dD = new string[] { str, "\r\n", this.GetCodeLang("dashavisho", persKV.Language, persKV.Paid, flag).ToString(), " ", this.GetCodeLang(persKV.Dasha_Visho, persKV.Language, persKV.Paid, flag).ToString(), "\r\n" };
        //            str2 = string.Concat(dD);
        //            str = str2;
        //            dD = new string[] { str, this.GetCodeLang("antarvisho", persKV.Language, persKV.Paid, flag).ToString(), " ", this.GetCodeLang(persKV.Antar_Visho, persKV.Language, persKV.Paid, flag).ToString(), "\r\n" };
        //            str2 = string.Concat(dD);
        //            str2 = string.Concat(str2, "\r\n\r\n");
        //            foreach (KundliMappingVO kundliMappingVO in kundliMappingVOs1)
        //            {
        //                string str4 = str2;
        //                if ((
        //                    from Map in kundliMappingVOs1
        //                    where Map.PlanetName == kundliMappingVO.PlanetName
        //                    select Map).SingleOrDefault<KundliMappingVO>().IsBad)
        //                {
        //                    dD = new string[] { this.GetCodeLang(kundliMappingVO.PlanetNameEnglish, persKV.Language, persKV.Paid, flag).ToString(), " ", null, null, null, null };
        //                    house = kundliMappingVO.House;
        //                    dD[2] = house.ToString();
        //                    dD[3] = " ";
        //                    dD[4] = this.GetCodeLang("Bad", persKV.Language, persKV.Paid, flag).ToString();
        //                    dD[5] = "\r\n";
        //                    str1 = string.Concat(dD);
        //                }
        //                else
        //                {
        //                    dD = new string[] { this.GetCodeLang(kundliMappingVO.PlanetNameEnglish, persKV.Language, persKV.Paid, flag).ToString(), " ", null, null, null, null };
        //                    house = kundliMappingVO.House;
        //                    dD[2] = house.ToString();
        //                    dD[3] = " ";
        //                    dD[4] = this.GetCodeLang("Good", persKV.Language, persKV.Paid, flag).ToString();
        //                    dD[5] = "\r\n";
        //                    str1 = string.Concat(dD);
        //                }
        //                str2 = string.Concat(str4, str1);
        //            }
        //        }
        //        string str5 = "";
        //        string str6 = "";
        //        string str7 = "";
        //        foreach (KundliMappingVO kundliMappingVO1 in kundliMappingVOs1)
        //        {
        //            if (!kundliMappingVO1.IsBad)
        //            {
        //                string planetNameEnglish = kundliMappingVO1.PlanetNameEnglish;
        //                string language1 = persKV.Language;
        //                house = kundliMappingVO1.House;
        //                str5 = string.Concat(str5, this.getvargitdaan(planetNameEnglish, language1, house.ToString(), kundliMappingVO1.IsBad));
        //            }
        //            else
        //            {
        //                string planetNameEnglish1 = kundliMappingVO1.PlanetNameEnglish;
        //                string language2 = persKV.Language;
        //                house = kundliMappingVO1.House;
        //                str7 = string.Concat(str7, this.getvargitdaan(planetNameEnglish1, language2, house.ToString(), kundliMappingVO1.IsBad));
        //                str6 = string.Concat(str6, this.getvargitcolor(kundliMappingVO1.PlanetNameEnglish, persKV.Language));
        //            }
        //        }
        //        if ((str5.Trim().Length > 0 ? false : str7.Trim().Length <= 0))
        //        {
        //            str2 = string.Concat(str2, this.GetCodeLang("generaldaan", language, true, flag));
        //        }
        //        if (str5.Trim().Length > 0)
        //        {
        //            str = str2;
        //            dD = new string[] { str, "\r\n\r\n", this.GetCodeLang("vdaan", persKV.Language, persKV.Paid, flag), "\r\n", str5, "\r\n\r\n" };
        //            str2 = string.Concat(dD);
        //        }
        //        if (str7.Trim().Length > 0)
        //        {
        //            str = str2;
        //            dD = new string[] { str, "\r\n\r\n", this.GetCodeLang("daan", persKV.Language, persKV.Paid, flag), " \r\n", str7, "\r\n\r\n" };
        //            str2 = string.Concat(dD);
        //        }
        //        if (str6.Trim().Length > 0)
        //        {
        //            str = str2;
        //            dD = new string[] { str, "\r\n\r\n", this.GetCodeLang("vcolor", persKV.Language, persKV.Paid, flag), "\r\n", str6, "\r\n" };
        //            str2 = string.Concat(dD);
        //        }
        //        str2 = string.Concat(str2, "\r\n", this.GetPlanetLord(kundliMappingVOs1, persKV));
        //    }
        //    if ((persKV.Language.ToLower() != "hindi" ? false : prodtype != "Match Making"))
        //    {
        //        str2 = string.Concat(str2, "\r\n", this.All_Special_List, "\r\n");
        //    }
        //    if ((prodtype.ToLower().Contains("jeevan sandesh") ? true : prodtype.ToLower().Contains("mahadasha fal")))
        //    {
        //        str2 = "";
        //    }
        //    if (!onlyvfal)
        //    {
        //        if (prodtype.Trim().Length <= 0)
        //        {
        //            if (years.ToList<short>().Count > 0)
        //            {
        //                str2 = string.Concat(str2, "\r\n\r\n");
        //                str2 = string.Concat(str2, "\r\n", this.GetCodeLang("vfalhead", persKV.Language, persKV.Paid, flag), "\r\n");
        //                if (years.ToList<short>().Count > 0)
        //                {
        //                    str2 = string.Concat(str2, this.Get_varshfal(persKV, years, kundliMappingVOs, months));
        //                }
        //            }
        //            str2 = string.Concat(str2, "\r\n\r\n", this.GetCodeLang("lifehead", persKV.Language, persKV.Paid, flag), "\r\n");
        //            str2 = string.Concat(str2, this.OldLifePrediction(persKV, kundliMappingVOs1, kundliMappingVOs, "", persKV.ShowRef, persKV.Male, persKV.Language));
        //            if (persKV.Language.ToLower() == "hindi")
        //            {
        //                str2 = string.Concat(str2, this.get_videsh(persKV, kundliMappingVOs1));
        //                str2 = string.Concat(str2, "\r\n", this.get_product(persKV, kundliMappingVOs1, years, normaltext, false, "ProfessionYICC", false));
        //            }
        //            str2 = string.Concat(str2, "\r\n\r\n", this.rin_pitri(persKV, kundliMappingVOs1));
        //            str2 = string.Concat(str2, "\r\n\r\n", this.GetMiscUpay(persKV, kundliMappingVOs1, persKV.ShowRef, persKV.Male, persKV.Language));
        //            string str8 = "";
        //            this.all_upayindex_sno.Sort();
        //            str8 = string.Concat(this.GetCodeLang("upayhelpbottom", persKV.Language, persKV.Paid, flag), "\r\n");
        //            if ((persKV.Language.ToLower() == "hindi" || persKV.Language.ToLower() == "marathi" ? true : persKV.Language.ToLower() == "english"))
        //            {
        //                str8 = string.Concat(str8, "\r\n", this.GetCodeLang("upaybelow", persKV.Language, persKV.Paid, flag), "\r\n");
        //            }
        //            foreach (short allUpayindexSno in this.all_upayindex_sno)
        //            {
        //                UpayIndex upayIndex = new UpayIndex();
        //                upayIndex = (new RuleDAO()).Get_UpayIndex(Convert.ToInt32(allUpayindexSno));
        //                if ((upayIndex == null ? false : upayIndex.Sno > 0))
        //                {
        //                    if (persKV.Language.ToLower() == "hindi")
        //                    {
        //                        obj = str8;
        //                        codeLang = new object[] { obj, this.GetCodeLang("aa", persKV.Language, persKV.Paid, flag), " ", this.GetCodeLang("upay", persKV.Language, persKV.Paid, flag), " ", upayIndex.Sno, " ", this.GetCodeLang("aa", persKV.Language, persKV.Paid, flag), "\r\n", upayIndex.Hindi.Trim(), "\r\n\r\n" };
        //                        str8 = string.Concat(codeLang);
        //                    }
        //                    if (persKV.Language.ToLower() == "marathi")
        //                    {
        //                        obj = str8;
        //                        codeLang = new object[] { obj, this.GetCodeLang("aa", persKV.Language, persKV.Paid, flag), " ", this.GetCodeLang("upay", persKV.Language, persKV.Paid, flag), " ", upayIndex.Sno, " ", this.GetCodeLang("aa", persKV.Language, persKV.Paid, flag), "\r\n", upayIndex.Marathi.Trim(), "\r\n\r\n" };
        //                        str8 = string.Concat(codeLang);
        //                    }
        //                    if (persKV.Language.ToLower() == "english")
        //                    {
        //                        obj = str8;
        //                        codeLang = new object[] { obj, this.GetCodeLang("aa", persKV.Language, persKV.Paid, flag), " ", this.GetCodeLang("upay", persKV.Language, persKV.Paid, flag), " ", upayIndex.Sno, " ", this.GetCodeLang("aa", persKV.Language, persKV.Paid, flag), "\r\n", upayIndex.Eng.Trim(), "\r\n\r\n" };
        //                        str8 = string.Concat(codeLang);
        //                    }
        //                    if (persKV.Language.ToLower() == "bangla")
        //                    {
        //                        obj = str8;
        //                        codeLang = new object[] { obj, this.GetCodeLang("aa", persKV.Language, persKV.Paid, flag), " ", this.GetCodeLang("upay", persKV.Language, persKV.Paid, flag), " ", upayIndex.Sno, " ", this.GetCodeLang("aa", persKV.Language, persKV.Paid, flag), "\r\n", upayIndex.Bangla.Trim(), "\r\n\r\n" };
        //                        str8 = string.Concat(codeLang);
        //                    }
        //                }
        //            }
        //            string str9 = "";
        //            List<RulesVO> list = new List<RulesVO>();
        //            list = (
        //                from Map in this.generate_final_lrvgen(persKV, kundliMappingVOs1, false, new List<short>(), persKV.Language, "", false, false)
        //                where Map.RuleType == "khabar"
        //                select Map).ToList<RulesVO>();
        //            if (list != null)
        //            {
        //                foreach (RulesVO rulesVO in list)
        //                {
        //                    str9 = string.Concat(str9, this.Get_Pred_Text(rulesVO.Sno, persKV.Language, true, true, persKV.ShowRef, false, persKV.Paid, false, flag, persKV), "\r\n");
        //                }
        //                if (str9.Trim().Length > 0)
        //                {
        //                    str8 = string.Concat(str8, this.GetCodeLang("Precautions", persKV.Language, persKV.Paid, flag), "\r\n\r\n", str9);
        //                }
        //            }
        //            if ((!paid ? false : prodtype != "Pitri Rin"))
        //            {
        //                str2 = string.Concat(str2, "\r\n\r\n", str8);
        //            }
        //        }
        //    }
        //    if ((years.ToList<short>().Count <= 0 ? false : onlyvfal))
        //    {
        //        str2 = string.Concat(str2, "\r\n\r\n", this.Get_varshfal(persKV, years, kundliMappingVOs1, months));
        //    }
        //    if (prodtype.Length > 0)
        //    {
        //        if ((prodtype.StartsWith("Today") || prodtype == "This Week" || prodtype == "This Month" || prodtype == "This Year" || prodtype.StartsWith("Tool") || prodtype == "14 March" || prodtype == "Weekly" || prodtype == "Daily" ? true : prodtype == "1 Year (Daily/Weekly)"))
        //        {
        //            str2 = "";
        //        }
        //        str2 = string.Concat(str2, this.get_product(persKV, kundliMappingVOs1, years, normaltext, onlyvfal, prodtype, true));
        //        if ((prodtype.StartsWith("Today") || prodtype == "This Week" || prodtype == "This Month" || prodtype == "This Year" ? true : prodtype.StartsWith("Tool")))
        //        {
        //            dD = new string[] { this.GetCodeLang("GoodBadDisclaimer", language.ToLower(), paid, flag), "\r\n\r\n", str2, "\r\n\r\n", this.GetCodeLang("upaybottom", language.ToLower(), paid, flag) };
        //            str2 = string.Concat(dD);
        //        }
        //    }
        //    return str2;
        //}

        //public string GetMiscUpay(KundliVO persKV, List<KundliMappingVO> lkmv, bool showref, bool male, string lang)
        //{
        //    string str = "";
        //    RuleBLL ruleBLL = new RuleBLL();
        //    bool flag = true;
        //    List<SoyeGrehUpayeVO> allSoyeGrehUpaye = (new PlanetBLL()).GetAllSoyeGrehUpaye();
        //    lkmv = ruleBLL.CalcSoyeGreh(lkmv);
        //    IEnumerable<KundliMappingVO> kundliMappingVOs =
        //        from L in lkmv
        //        where L.Soya
        //        select L;
        //    if (kundliMappingVOs.Count<KundliMappingVO>() > 0)
        //    {
        //        str = string.Concat(str, this.GetCodeLang("Sleeping", lang, flag, false).ToString(), "\r\n");
        //        foreach (KundliMappingVO kundliMappingVO in kundliMappingVOs)
        //        {
        //            if (lang == "hindi")
        //            {
        //                str = string.Concat(str, (
        //                    from upaye in allSoyeGrehUpaye
        //                    where upaye.Planet == kundliMappingVO.Planet
        //                    select upaye.Details).SingleOrDefault<string>(), "\r\n");
        //            }
        //            else if (lang == "english")
        //            {
        //                str = string.Concat(str, (
        //                    from upaye in allSoyeGrehUpaye
        //                    where upaye.Planet == kundliMappingVO.Planet
        //                    select upaye.Eng_Details).SingleOrDefault<string>(), "\r\n");
        //            }
        //            else if (lang == "tamil")
        //            {
        //                str = string.Concat(str, (
        //                    from upaye in allSoyeGrehUpaye
        //                    where upaye.Planet == kundliMappingVO.Planet
        //                    select upaye.Tamil_Details).SingleOrDefault<string>(), "\r\n");
        //            }
        //            else if (lang == "telugu")
        //            {
        //                str = string.Concat(str, (
        //                    from upaye in allSoyeGrehUpaye
        //                    where upaye.Planet == kundliMappingVO.Planet
        //                    select upaye.Telugu_Details).SingleOrDefault<string>(), "\r\n");
        //            }
        //            else if (lang == "bangla")
        //            {
        //                str = string.Concat(str, (
        //                    from upaye in allSoyeGrehUpaye
        //                    where upaye.Planet == kundliMappingVO.Planet
        //                    select upaye.Bangla_Details).SingleOrDefault<string>(), "\r\n");
        //            }
        //            else if (lang == "kannada")
        //            {
        //                str = string.Concat(str, (
        //                    from upaye in allSoyeGrehUpaye
        //                    where upaye.Planet == kundliMappingVO.Planet
        //                    select upaye.Kannada_Details).SingleOrDefault<string>(), "\r\n");
        //            }
        //            else if (lang == "marathi")
        //            {
        //                str = string.Concat(str, (
        //                    from upaye in allSoyeGrehUpaye
        //                    where upaye.Planet == kundliMappingVO.Planet
        //                    select upaye.Marathi_Details).SingleOrDefault<string>(), "\r\n");
        //            }
        //            else if (lang == "punjabi")
        //            {
        //                str = string.Concat(str, (
        //                    from upaye in allSoyeGrehUpaye
        //                    where upaye.Planet == kundliMappingVO.Planet
        //                    select upaye.Punjabi_Details).SingleOrDefault<string>(), "\r\n");
        //            }
        //            else if (lang == "gujarati")
        //            {
        //                str = string.Concat(str, (
        //                    from upaye in allSoyeGrehUpaye
        //                    where upaye.Planet == kundliMappingVO.Planet
        //                    select upaye.Gujarati_Details).SingleOrDefault<string>(), "\r\n");
        //            }
        //        }
        //    }
        //    List<string> strs = new List<string>()
        //    {
        //        this.GetCodeLang("soyeupay1", lang, flag, false).ToString(),
        //        this.GetCodeLang("soyeupay2", lang, flag, false).ToString(),
        //        this.GetCodeLang("soyeupay3", lang, flag, false).ToString(),
        //        this.GetCodeLang("soyeupay4", lang, flag, false).ToString(),
        //        this.GetCodeLang("soyeupay5", lang, flag, false).ToString(),
        //        this.GetCodeLang("soyeupay6", lang, flag, false).ToString(),
        //        this.GetCodeLang("soyeupay7", lang, flag, false).ToString(),
        //        this.GetCodeLang("soyeupay8", lang, flag, false).ToString(),
        //        this.GetCodeLang("soyeupay9", lang, flag, false).ToString(),
        //        this.GetCodeLang("soyeupay10", lang, flag, false).ToString(),
        //        this.GetCodeLang("soyeupay11", lang, flag, false).ToString(),
        //        this.GetCodeLang("soyeupay12", lang, flag, false).ToString()
        //    };
        //    List<long> nums = new List<long>();
        //    bool[] soyeBhav = ruleBLL.GetSoyeBhav(lkmv);
        //    string str1 = "";
        //    if (soyeBhav.Count<bool>() > 0)
        //    {
        //        for (int i = 1; i <= 12; i++)
        //        {
        //            if ((!soyeBhav[i - 1] ? false : (
        //                from Map in lkmv
        //                where Map.House == i
        //                select Map).Count<KundliMappingVO>() == 0))
        //            {
        //                str1 = string.Concat(str1, strs[i - 1], "\r\n");
        //            }
        //        }
        //    }
        //    if (str1.Length > 5)
        //    {
        //        str = string.Concat(str, "\r\n", this.GetCodeLang("sleeping_and_empty", lang, flag, false), "\r\n");
        //        str = string.Concat(str, str1);
        //    }
        //    return str;
        //}

        //public string GetMonthFal(KundliVO perskv, List<KundliMappingVO> lkmv, short year, List<short> months, bool showref, bool marking, bool male, string janamsamay, string lang, bool paid)
        //{
        //    RulesVO rulesVO = null;
        //    bool house;
        //    string str = "";
        //    long num = (long)0;
        //    bool isBad = false;
        //    this.paidpred = paid;
        //    List<KundliMappingVO> kundliMappingVOs = new List<KundliMappingVO>();
        //    DateTime dateTime = new DateTime();
        //    DateTime dateTime1 = new DateTime();
        //    GetPlanetVO getPlanetVO = new GetPlanetVO();
        //    KundliBLL kundliBLL = new KundliBLL();
        //    RuleBLL ruleBLL = new RuleBLL();
        //    string str1 = "";
        //    bool flag = false;
        //    if (perskv.Sub_prodtype == "mobile")
        //    {
        //        flag = true;
        //    }
        //    foreach (short month in months)
        //    {
        //        kundliMappingVOs = kundliBLL.GetMonthlyKundli(year, month, perskv, lkmv);
        //        ruleBLL.CalcKundliPlanets(kundliMappingVOs);
        //        int num1 = 2;
        //        Years35BLL years35BLL = new Years35BLL();
        //        PlanetBLL planetBLL = new PlanetBLL();
        //        List<Years35VO> years35VOs = years35BLL.Get35Years(janamsamay);
        //        AstroDAL astroDAL = new AstroDAL();
        //        string str2 = (
        //            from map in years35VOs
        //            where map.Years == (long)year
        //            select map).FirstOrDefault<Years35VO>().Planet.ToString();
        //        List<PlanetHouseMappingVO> planetHouseMappingVOs = new List<PlanetHouseMappingVO>();
        //        long house1 = (long)(
        //            from lk in kundliMappingVOs
        //            where lk.PlanetName.Equals(str2)
        //            select lk).FirstOrDefault<KundliMappingVO>().House;
        //        planetHouseMappingVOs = (
        //            from pk in planetBLL.GetPakkeGhar()
        //            where (long)pk.House == house1
        //            select pk).ToList<PlanetHouseMappingVO>();
        //        long num2 = (long)0;
        //        if ((house1 == (long)1 || house1 == (long)7 || house1 == (long)4 ? true : house1 == (long)10))
        //        {
        //            num2 = (house1 + (long)6) % (long)12;
        //        }
        //        short num3 = 0;
        //        foreach (KundliMappingVO kundliMappingVO in kundliMappingVOs)
        //        {
        //            num = (long)0;
        //            List<RulesVO> list = (
        //                from Rules in kundliBLL.GetAdvancePredictions(kundliMappingVOs, kundliMappingVO.Planet, num1)
        //                where (Rules.Isbad != kundliMappingVO.VIsBad ? false : Rules.RuleType == "mfal")
        //                select Rules).ToList<RulesVO>();
        //            num = Convert.ToInt64((
        //                from Map in years35VOs
        //                where (Map.Years != (long)year ? false : (Map.Period.Contains(kundliMappingVO.PlanetName) ? true : Map.Planet == kundliMappingVO.PlanetName))
        //                select Map).Count<Years35VO>());
        //            if (num > (long)0)
        //            {
        //                isBad = (
        //                    from Map in lkmv
        //                    where Map.PlanetName == kundliMappingVO.PlanetName
        //                    select Map).SingleOrDefault<KundliMappingVO>().IsBad;
        //            }
        //            if (num < (long)1)
        //            {
        //                if ((
        //                    from pp in planetHouseMappingVOs
        //                    where pp.Planet == kundliMappingVO.Planet
        //                    select pp).Count<PlanetHouseMappingVO>() > 0)
        //                {
        //                    goto Label1;
        //                }
        //                house = (long)kundliMappingVO.House != num2;
        //                goto Label0;
        //            }
        //        Label1:
        //            house = false;
        //        Label0:
        //            if (!house)
        //            {
        //                if (num3 != year)
        //                {
        //                    str1 = string.Concat(str1, "\r\n\r\n");
        //                    DateTime dob = perskv.Dob;
        //                    dob = dob.AddYears(year - 1);
        //                    dateTime = dob.AddMonths(month - 1);
        //                    dob = perskv.Dob;
        //                    dob = dob.AddYears(year - 1);
        //                    dob = dob.AddMonths(month);
        //                    dateTime1 = dob.AddDays(-1);
        //                    string str3 = str1;
        //                    string[] strArrays = new string[] { str3, dateTime.ToString("dd"), " ", this.GetCodeLang(string.Concat("M", dateTime.ToString("%M")), perskv.Language, perskv.Paid), " ", dateTime.ToString("yyyy"), " ", this.GetCodeLang("to", perskv.Language, true), " ", dateTime1.ToString("dd"), " ", this.GetCodeLang(string.Concat("M", dateTime1.ToString("%M")), perskv.Language, perskv.Paid), " ", dateTime1.ToString("yyyy"), " ", this.GetCodeLang("monthend", perskv.Language, true) };
        //                    str1 = string.Concat(strArrays);
        //                }
        //                num3 = year;
        //                if (marking)
        //                {
        //                    foreach (RulesVO rulesVO in list)
        //                    {
        //                        str = (year < 18 ? this.Get_Pred_Text(rulesVO.Sno, lang, male, false, showref, true, paid, true, flag, perskv) : this.Get_Pred_Text(rulesVO.Sno, lang, male, true, showref, true, paid, true, flag, perskv));
        //                        str = string.Concat(str, "\r\n");
        //                        if (!showref)
        //                        {
        //                            str1 = string.Concat(str1, str);
        //                        }
        //                        else
        //                        {
        //                            object obj = str1;
        //                            object[] sno = new object[] { obj, str, "   ", rulesVO.Sno, "  ", ruleBLL.GetPlanetByRuleNo(rulesVO.Sno).Planet, " ", ruleBLL.GetPlanetByRuleNo(rulesVO.Sno).House, " ", rulesVO.Reference };
        //                            str1 = string.Concat(sno);
        //                        }
        //                    }
        //                }
        //            }
        //            if (!marking)
        //            {
        //                foreach (RulesVO rulesVO1 in list)
        //                {
        //                    str = (year < 18 ? this.Get_Pred_Text(rulesVO1.Sno, lang, male, false, showref, true, paid, true, flag, perskv) : this.Get_Pred_Text(rulesVO1.Sno, lang, male, true, showref, true, paid, true, flag, perskv));
        //                    str = string.Concat(str, "\r\n");
        //                    long length = (long)str.Length;
        //                    if (!paid)
        //                    {
        //                        length = (!kundliMappingVO.VIsBad ? (long)str.IndexOf("vr% 'kqHk Qyksa") : (long)str.IndexOf("vr% v'kqHk Qyksa"));
        //                    }
        //                    if (lang == "english")
        //                    {
        //                        length = (long)str.ToLower().IndexOf("do the following remedies");
        //                    }
        //                    str1 = string.Concat(str1, str.Substring(0, Convert.ToInt16(length)));
        //                    str1 = string.Concat(str1, "\r\n");
        //                }
        //            }
        //        }
        //    }
        //    return str1;
        //}

        //public int GetMonthsBetween(DateTime from, DateTime to)
        //{
        //    if (from > to)
        //    {
        //        DateTime dateTime = from;
        //        from = to;
        //        to = dateTime;
        //    }
        //    int num = Math.Abs(to.Year * 12 + (to.Month - 1) - (from.Year * 12 + (from.Month - 1)));
        //    return ((from.AddMonths(num) > to ? false : to.Day >= from.Day) ? num : num - 1);
        //}

        //public string GetPlanetLord(List<KundliMappingVO> lkmv, KundliVO persKV)
        //{
        //    KundliMappingVO kundliMappingVO = null;
        //    string str;
        //    string[] strArrays;
        //    Func<KundliMappingVO, bool> func = null;
        //    Func<KundliMappingVO, bool> func1 = null;
        //    Func<KundliMappingVO, bool> func2 = null;
        //    Func<KundliMappingVO, bool> func3 = null;
        //    string str1 = "";
        //    string str2 = "";
        //    int num1 = 0;
        //    PredictionBLL predictionBLL = new PredictionBLL();
        //    List<KundliMappingVO> list = (
        //        from kk in lkmv
        //        where kk.House == 9
        //        select kk).ToList<KundliMappingVO>();
        //    List<KundliMappingVO> list1 = (
        //        from kk in lkmv
        //        where kk.House == 5
        //        select kk).ToList<KundliMappingVO>();
        //    List<KundliMappingVO> kundliMappingVOs1 = (
        //        from kk in lkmv
        //        where kk.House == 2
        //        select kk).ToList<KundliMappingVO>();
        //    List<int> nums = new List<int>();
        //    if (list.Count > 0)
        //    {
        //        foreach (KundliMappingVO kundliMappingVO1 in list)
        //        {
        //            if (!kundliMappingVO1.IsBad)
        //            {
        //                num1 = kundliMappingVO1.Planet;
        //            }
        //        }
        //    }
        //    else if (list1.Count > 0)
        //    {
        //        foreach (KundliMappingVO kundliMappingVO2 in list1)
        //        {
        //            if (!kundliMappingVO2.IsBad)
        //            {
        //                num1 = kundliMappingVO2.Planet;
        //            }
        //        }
        //    }
        //    else if (kundliMappingVOs1.Count > 0)
        //    {
        //        foreach (KundliMappingVO kundliMappingVO in kundliMappingVOs1)
        //        {
        //            if (!kundliMappingVO.IsBad)
        //            {
        //                num1 = kundliMappingVO.Planet;
        //            }
        //        }
        //    }
        //    if (nums.Count == 0)
        //    {
        //        if (!(
        //            from kk in lkmv
        //            where kk.Planet == 6
        //            select kk).FirstOrDefault<KundliMappingVO>().IsBad)
        //        {
        //            num1 = 6;
        //        }
        //        else if (!(
        //            from kk in lkmv
        //            where kk.Planet == 5
        //            select kk).FirstOrDefault<KundliMappingVO>().IsBad)
        //        {
        //            num1 = 5;
        //        }
        //        else if (!(
        //            from kk in lkmv
        //            where kk.Planet == 4
        //            select kk).FirstOrDefault<KundliMappingVO>().IsBad)
        //        {
        //            num1 = 4;
        //        }
        //        else if (!(
        //            from kk in lkmv
        //            where kk.Planet == 7
        //            select kk).FirstOrDefault<KundliMappingVO>().IsBad)
        //        {
        //            num1 = 7;
        //        }
        //        else if (!(
        //            from kk in lkmv
        //            where kk.Planet == 9
        //            select kk).FirstOrDefault<KundliMappingVO>().IsBad)
        //        {
        //            num1 = 9;
        //        }
        //        else if (!(
        //            from kk in lkmv
        //            where kk.Planet == 8
        //            select kk).FirstOrDefault<KundliMappingVO>().IsBad)
        //        {
        //            num1 = 8;
        //        }
        //        else if (!(
        //            from kk in lkmv
        //            where kk.Planet == 3
        //            select kk).FirstOrDefault<KundliMappingVO>().IsBad)
        //        {
        //            num1 = 3;
        //        }
        //        else if (!(
        //            from kk in lkmv
        //            where kk.Planet == 1
        //            select kk).FirstOrDefault<KundliMappingVO>().IsBad)
        //        {
        //            num1 = 1;
        //        }
        //        else if (!(
        //            from kk in lkmv
        //            where kk.Planet == 2
        //            select kk).FirstOrDefault<KundliMappingVO>().IsBad)
        //        {
        //            num1 = 2;
        //        }
        //    }
        //    if ((persKV.Male ? false : num1 == 9))
        //    {
        //        num1 = 2;
        //    }
        //    str1 = (num1 <= 0 ? string.Concat(str1, "\r\n", predictionBLL.GetCodeLang("anypuja", persKV.Language, persKV.Paid, false).ToString()) : string.Concat(str1, "\r\n", predictionBLL.GetCodeLang(string.Concat(this.findplanet(num1).Planetname.ToLower(), "puja"), persKV.Language, persKV.Paid, false).ToString()));
        //    long num2 = Convert.ToInt64((
        //        from Map in lkmv
        //        where Map.PlanetName.Contains("Surya")
        //        select Map.House).SingleOrDefault<int>());
        //    long num3 = Convert.ToInt64((
        //        from Map in lkmv
        //        where Map.PlanetName.Contains("Rahu")
        //        select Map.House).SingleOrDefault<int>());
        //    long num4 = Convert.ToInt64((
        //        from Map in lkmv
        //        where Map.PlanetName.Contains("Ketu")
        //        select Map.House).SingleOrDefault<int>());
        //    long num5 = Convert.ToInt64((
        //        from Map in lkmv
        //        where Map.PlanetName.Contains("Shani")
        //        select Map.House).SingleOrDefault<int>());
        //    Convert.ToInt64((
        //        from Map in lkmv
        //        where Map.PlanetName.Contains("Budh")
        //        select Map.House).SingleOrDefault<int>());
        //    Convert.ToInt64((
        //        from Map in lkmv
        //        where Map.PlanetName.Contains("Shukra")
        //        select Map.House).SingleOrDefault<int>());
        //    Convert.ToInt64((
        //        from Map in lkmv
        //        where Map.PlanetName.Contains("Mangal")
        //        select Map.House).SingleOrDefault<int>());
        //    long num6 = Convert.ToInt64((
        //        from Map in lkmv
        //        where Map.PlanetName.Contains("Chandra")
        //        select Map.House).SingleOrDefault<int>());
        //    long num7 = Convert.ToInt64((
        //        from Map in lkmv
        //        where Map.PlanetName.Contains("Guru")
        //        select Map.House).SingleOrDefault<int>());
        //    bool flag = false;
        //    bool flag1 = false;
        //    PlanetBLL planetBLL = new PlanetBLL();
        //    if ((num7 == (long)10 || num7 == (long)7 ? true : num5 == (long)10))
        //    {
        //        flag = true;
        //    }
        //    if (num2 == num3)
        //    {
        //        flag = true;
        //    }
        //    if (num6 == num4)
        //    {
        //        flag = true;
        //    }
        //    if (flag)
        //    {
        //        str2 = string.Concat(str2, "\r\n", predictionBLL.GetCodeLang("nopuja", persKV.Language, persKV.Paid, false).ToString(), "\r\n");
        //    }
        //    else if (str1.Trim().Length > 0)
        //    {
        //        str = str2;
        //        strArrays = new string[] { str, "\r\n", predictionBLL.GetCodeLang("grehpuja", persKV.Language, persKV.Paid, false).ToString(), "\r\n", str1 };
        //        str2 = string.Concat(strArrays);
        //    }
        //    int num8 = 0;
        //    if ((
        //        from Map in lkmv
        //        where Map.House == 8
        //        select Map).Count<KundliMappingVO>() >= 2)
        //    {
        //        num8 = lkmv.Where<KundliMappingVO>((KundliMappingVO Map) =>
        //        {
        //            bool planet;
        //            if (Map.House != 8)
        //            {
        //                planet = false;
        //            }
        //            else
        //            {
        //                int num = Map.Planet;
        //                List<KundliMappingVO> kundliMappingVOs = lkmv;
        //                if (func == null)
        //                {
        //                    func = (KundliMappingVO Map1) => Map1.House == 8;
        //                }
        //                planet = num != kundliMappingVOs.Where<KundliMappingVO>(func).FirstOrDefault<KundliMappingVO>().Planet;
        //            }
        //            return planet;
        //        }).FirstOrDefault<KundliMappingVO>().Planet;
        //        if ((planetBLL.GetAllPlanetRelations().Where<PlanetRelationsVO>((PlanetRelationsVO Map) =>
        //        {
        //            int planet1 = Map.Planet1;
        //            List<KundliMappingVO> kundliMappingVOs = lkmv;
        //            if (func1 == null)
        //            {
        //                func1 = (KundliMappingVO Map1) => Map1.House == 8;
        //            }
        //            return (planet1 != kundliMappingVOs.Where<KundliMappingVO>(func1).FirstOrDefault<KundliMappingVO>().Planet ? false : Map.Planet2 == num8);
        //        }).OrderByDescending<PlanetRelationsVO, int>((PlanetRelationsVO Map) => Map.Sno).FirstOrDefault<PlanetRelationsVO>().Relation != 2 ? false : (
        //            from Map in lkmv
        //            where Map.House == 2
        //            select Map).Count<KundliMappingVO>() == 0))
        //        {
        //            flag1 = true;
        //        }
        //    }
        //    if ((
        //        from Map in lkmv
        //        where Map.House == 10
        //        select Map).Count<KundliMappingVO>() >= 2)
        //    {
        //        num8 = lkmv.Where<KundliMappingVO>((KundliMappingVO Map) =>
        //        {
        //            bool planet;
        //            if (Map.House != 10)
        //            {
        //                planet = false;
        //            }
        //            else
        //            {
        //                int num = Map.Planet;
        //                List<KundliMappingVO> kundliMappingVOs = lkmv;
        //                if (func2 == null)
        //                {
        //                    func2 = (KundliMappingVO Map1) => Map1.House == 10;
        //                }
        //                planet = num != kundliMappingVOs.Where<KundliMappingVO>(func2).FirstOrDefault<KundliMappingVO>().Planet;
        //            }
        //            return planet;
        //        }).FirstOrDefault<KundliMappingVO>().Planet;
        //        if ((planetBLL.GetAllPlanetRelations().Where<PlanetRelationsVO>((PlanetRelationsVO Map) =>
        //        {
        //            int planet1 = Map.Planet1;
        //            List<KundliMappingVO> kundliMappingVOs = lkmv;
        //            if (func3 == null)
        //            {
        //                func3 = (KundliMappingVO Map1) => Map1.House == 10;
        //            }
        //            return (planet1 != kundliMappingVOs.Where<KundliMappingVO>(func3).FirstOrDefault<KundliMappingVO>().Planet ? false : Map.Planet2 == num8);
        //        }).OrderByDescending<PlanetRelationsVO, int>((PlanetRelationsVO Map) => Map.Sno).FirstOrDefault<PlanetRelationsVO>().Relation != 2 ? false : (
        //            from Map in lkmv
        //            where Map.House == 2
        //            select Map).Count<KundliMappingVO>() == 0))
        //        {
        //            flag1 = true;
        //        }
        //    }
        //    if ((!flag1 ? false : flag))
        //    {
        //        str2 = string.Concat("\r\n", predictionBLL.GetCodeLang("nomandir", persKV.Language, persKV.Paid, false).ToString(), "\r\n");
        //    }
        //    if ((!flag1 ? false : !flag))
        //    {
        //        str = str2;
        //        strArrays = new string[] { str, "\r\n", predictionBLL.GetCodeLang("nomandir", persKV.Language, persKV.Paid, false).ToString(), " ", predictionBLL.GetCodeLang("pujanomandir", persKV.Language, persKV.Paid, false).ToString(), "\r\n" };
        //        str2 = string.Concat(strArrays);
        //    }
        //    return str2;
        //}

        public string GetPlanetLord_Unicode(List<KundliMappingVO> lkmv, KundliVO persKV)
        {
            //KundliMappingVO kundliMappingVO = null;
            string str;
            string[] strArrays;
            Func<KundliMappingVO, bool> func = null;
            Func<KundliMappingVO, bool> func1 = null;
            Func<KundliMappingVO, bool> func2 = null;
            Func<KundliMappingVO, bool> func3 = null;
            string str1 = "";
            string str2 = "";
            int num1 = 0;
            PredictionBLL predictionBLL = new PredictionBLL();
            List<KundliMappingVO> list = (
                from kk in lkmv
                where kk.House == 9
                select kk).ToList<KundliMappingVO>();
            List<KundliMappingVO> list1 = (
                from kk in lkmv
                where kk.House == 5
                select kk).ToList<KundliMappingVO>();
            List<KundliMappingVO> kundliMappingVOs1 = (
                from kk in lkmv
                where kk.House == 2
                select kk).ToList<KundliMappingVO>();
            List<int> nums = new List<int>();
            if (list.Count > 0)
            {
                foreach (KundliMappingVO kundliMappingVO1 in list)
                {
                    if (!kundliMappingVO1.IsBad)
                    {
                        num1 = kundliMappingVO1.Planet;
                    }
                }
            }
            else if (list1.Count > 0)
            {
                foreach (KundliMappingVO kundliMappingVO2 in list1)
                {
                    if (!kundliMappingVO2.IsBad)
                    {
                        num1 = kundliMappingVO2.Planet;
                    }
                }
            }
            else if (kundliMappingVOs1.Count > 0)
            {
                foreach (KundliMappingVO kundliMappingVO in kundliMappingVOs1)
                {
                    if (!kundliMappingVO.IsBad)
                    {
                        num1 = kundliMappingVO.Planet;
                    }
                }
            }
            if (nums.Count == 0)
            {
                if (!(
                    from kk in lkmv
                    where kk.Planet == 6
                    select kk).FirstOrDefault<KundliMappingVO>().IsBad)
                {
                    num1 = 6;
                }
                else if (!(
                    from kk in lkmv
                    where kk.Planet == 5
                    select kk).FirstOrDefault<KundliMappingVO>().IsBad)
                {
                    num1 = 5;
                }
                else if (!(
                    from kk in lkmv
                    where kk.Planet == 4
                    select kk).FirstOrDefault<KundliMappingVO>().IsBad)
                {
                    num1 = 4;
                }
                else if (!(
                    from kk in lkmv
                    where kk.Planet == 7
                    select kk).FirstOrDefault<KundliMappingVO>().IsBad)
                {
                    num1 = 7;
                }
                else if (!(
                    from kk in lkmv
                    where kk.Planet == 9
                    select kk).FirstOrDefault<KundliMappingVO>().IsBad)
                {
                    num1 = 9;
                }
                else if (!(
                    from kk in lkmv
                    where kk.Planet == 8
                    select kk).FirstOrDefault<KundliMappingVO>().IsBad)
                {
                    num1 = 8;
                }
                else if (!(
                    from kk in lkmv
                    where kk.Planet == 3
                    select kk).FirstOrDefault<KundliMappingVO>().IsBad)
                {
                    num1 = 3;
                }
                else if (!(
                    from kk in lkmv
                    where kk.Planet == 1
                    select kk).FirstOrDefault<KundliMappingVO>().IsBad)
                {
                    num1 = 1;
                }
                else if (!(
                    from kk in lkmv
                    where kk.Planet == 2
                    select kk).FirstOrDefault<KundliMappingVO>().IsBad)
                {
                    num1 = 2;
                }
            }
            if ((persKV.Male ? false : num1 == 9))
            {
                num1 = 2;
            }
            str1 = (num1 <= 0 ? string.Concat(str1, "\r\n", predictionBLL.GetCodeLang("anypuja", persKV.Language, persKV.Paid, true).ToString()) : string.Concat(str1, "\r\n", predictionBLL.GetCodeLang(string.Concat(this.findplanet(num1).Planetname.ToLower(), "puja"), persKV.Language, persKV.Paid, true).ToString()));
            long num2 = Convert.ToInt64((
                from Map in lkmv
                where Map.PlanetName.Contains("Surya")
                select Map.House).SingleOrDefault<int>());
            long num3 = Convert.ToInt64((
                from Map in lkmv
                where Map.PlanetName.Contains("Rahu")
                select Map.House).SingleOrDefault<int>());
            long num4 = Convert.ToInt64((
                from Map in lkmv
                where Map.PlanetName.Contains("Ketu")
                select Map.House).SingleOrDefault<int>());
            long num5 = Convert.ToInt64((
                from Map in lkmv
                where Map.PlanetName.Contains("Shani")
                select Map.House).SingleOrDefault<int>());
            Convert.ToInt64((
                from Map in lkmv
                where Map.PlanetName.Contains("Budh")
                select Map.House).SingleOrDefault<int>());
            Convert.ToInt64((
                from Map in lkmv
                where Map.PlanetName.Contains("Shukra")
                select Map.House).SingleOrDefault<int>());
            Convert.ToInt64((
                from Map in lkmv
                where Map.PlanetName.Contains("Mangal")
                select Map.House).SingleOrDefault<int>());
            long num6 = Convert.ToInt64((
                from Map in lkmv
                where Map.PlanetName.Contains("Chandra")
                select Map.House).SingleOrDefault<int>());
            long num7 = Convert.ToInt64((
                from Map in lkmv
                where Map.PlanetName.Contains("Guru")
                select Map.House).SingleOrDefault<int>());
            bool flag = false;
            bool flag1 = false;
            PlanetBLL planetBLL = new PlanetBLL();
            if ((num7 == (long)10 || num7 == (long)7 ? true : num5 == (long)10))
            {
                flag = true;
            }
            if (num2 == num3)
            {
                flag = true;
            }
            if (num6 == num4)
            {
                flag = true;
            }
            if (flag)
            {
                str2 = string.Concat(str2, "\r\n", predictionBLL.GetCodeLang("nopuja", persKV.Language, persKV.Paid, true).ToString(), "\r\n");
            }
            else if (str1.Trim().Length > 0)
            {
                str = str2;
                strArrays = new string[] { str, "\r\n", predictionBLL.GetCodeLang("grehpuja", persKV.Language, persKV.Paid, true).ToString(), "\r\n", str1 };
                str2 = string.Concat(strArrays);
            }
            int num8 = 0;
            if ((
                from Map in lkmv
                where Map.House == 8
                select Map).Count<KundliMappingVO>() >= 2)
            {
                num8 = lkmv.Where<KundliMappingVO>((KundliMappingVO Map) =>
                {
                    bool planet;
                    if (Map.House != 8)
                    {
                        planet = false;
                    }
                    else
                    {
                        int num = Map.Planet;
                        List<KundliMappingVO> kundliMappingVOs = lkmv;
                        if (func == null)
                        {
                            func = (KundliMappingVO Map1) => Map1.House == 8;
                        }
                        planet = num != kundliMappingVOs.Where<KundliMappingVO>(func).FirstOrDefault<KundliMappingVO>().Planet;
                    }
                    return planet;
                }).FirstOrDefault<KundliMappingVO>().Planet;
                if ((planetBLL.GetAllPlanetRelations().Where<PlanetRelationsVO>((PlanetRelationsVO Map) =>
                {
                    int planet1 = Map.Planet1;
                    List<KundliMappingVO> kundliMappingVOs = lkmv;
                    if (func1 == null)
                    {
                        func1 = (KundliMappingVO Map1) => Map1.House == 8;
                    }
                    return (planet1 != kundliMappingVOs.Where<KundliMappingVO>(func1).FirstOrDefault<KundliMappingVO>().Planet ? false : Map.Planet2 == num8);
                }).OrderByDescending<PlanetRelationsVO, int>((PlanetRelationsVO Map) => Map.Sno).FirstOrDefault<PlanetRelationsVO>().Relation != 2 ? false : (
                    from Map in lkmv
                    where Map.House == 2
                    select Map).Count<KundliMappingVO>() == 0))
                {
                    flag1 = true;
                }
            }
            if ((
                from Map in lkmv
                where Map.House == 10
                select Map).Count<KundliMappingVO>() >= 2)
            {
                num8 = lkmv.Where<KundliMappingVO>((KundliMappingVO Map) =>
                {
                    bool planet;
                    if (Map.House != 10)
                    {
                        planet = false;
                    }
                    else
                    {
                        int num = Map.Planet;
                        List<KundliMappingVO> kundliMappingVOs = lkmv;
                        if (func2 == null)
                        {
                            func2 = (KundliMappingVO Map1) => Map1.House == 10;
                        }
                        planet = num != kundliMappingVOs.Where<KundliMappingVO>(func2).FirstOrDefault<KundliMappingVO>().Planet;
                    }
                    return planet;
                }).FirstOrDefault<KundliMappingVO>().Planet;
                if ((planetBLL.GetAllPlanetRelations().Where<PlanetRelationsVO>((PlanetRelationsVO Map) =>
                {
                    int planet1 = Map.Planet1;
                    List<KundliMappingVO> kundliMappingVOs = lkmv;
                    if (func3 == null)
                    {
                        func3 = (KundliMappingVO Map1) => Map1.House == 10;
                    }
                    return (planet1 != kundliMappingVOs.Where<KundliMappingVO>(func3).FirstOrDefault<KundliMappingVO>().Planet ? false : Map.Planet2 == num8);
                }).OrderByDescending<PlanetRelationsVO, int>((PlanetRelationsVO Map) => Map.Sno).FirstOrDefault<PlanetRelationsVO>().Relation != 2 ? false : (
                    from Map in lkmv
                    where Map.House == 2
                    select Map).Count<KundliMappingVO>() == 0))
                {
                    flag1 = true;
                }
            }
            if ((!flag1 ? false : flag))
            {
                str2 = string.Concat("\r\n", predictionBLL.GetCodeLang("nomandir", persKV.Language, persKV.Paid, true).ToString(), "\r\n");
            }
            if ((!flag1 ? false : !flag))
            {
                str = str2;
                strArrays = new string[] { str, "\r\n", predictionBLL.GetCodeLang("nomandir", persKV.Language, persKV.Paid, true).ToString(), " ", predictionBLL.GetCodeLang("pujanomandir", persKV.Language, persKV.Paid, true).ToString(), "\r\n" };
                str2 = string.Concat(strArrays);
            }
            return str2;
        }

        //public string GetShadi(KundliVO persKV, List<KundliMappingVO> lkmv)
        //{
        //    int num = 0;
        //    List<long> nums = new List<long>();
        //    RuleBLL ruleBLL = new RuleBLL();
        //    string str = "";
        //    List<RulesVO> rulesVOs = new List<RulesVO>();
        //    KundliBLL kundliBLL = new KundliBLL();
        //    kundliBLL.GetAdvancePredictions(lkmv, num, 0).ToList<RulesVO>();
        //    str = string.Concat(str, this.GetCodeLang("Remedies_marriage", persKV.Language, persKV.Paid, false).ToString());
        //    str = string.Concat(str, "\r\n");
        //    for (int i1 = 1; i1 < 9; i1++)
        //    {
        //        KundliMappingVO kundliMappingVO = new KundliMappingVO();
        //        kundliMappingVO = (
        //            from Map in lkmv
        //            where Map.Planet == i1
        //            select Map).SingleOrDefault<KundliMappingVO>();
        //        List<RulesVO> list = kundliBLL.GetAdvancePredictions(lkmv, i1, 0).ToList<RulesVO>();
        //        rulesVOs = (
        //            from Rules in list
        //            where Rules.RuleType == "shadi"
        //            select Rules).ToList<RulesVO>();
        //        foreach (RulesVO rulesVO in rulesVOs)
        //        {
        //            if (!nums.Exists((long i) => i == rulesVO.Sno))
        //            {
        //                str = string.Concat(str, this.Get_Pred_Text(rulesVO.Sno, persKV.Language, persKV.Male, true, persKV.ShowRef, false, persKV.Paid, true, false, persKV));
        //                nums.Add(rulesVO.Sno);
        //            }
        //        }
        //    }
        //    str = string.Concat(str, "\r\n", this.Get_Pred_Text((long)4600, persKV.Language, persKV.Male, true, persKV.ShowRef, false, persKV.Paid, true, false, persKV));
        //    return str;
        //}

        //public string getvargitcolor(string planetname, string lang)
        //{
        //    string str = "";
        //    RuleDAO ruleDAO = new RuleDAO();
        //    string str1 = lang;
        //    if (str1 != null)
        //    {
        //        switch (str1)
        //        {
        //            case "hindi":
        //                {
        //                    str = string.Concat(str, (
        //                        from aa in ruleDAO.Get_VDAAN()
        //                        where aa.planet.Equals(planetname.ToLower())
        //                        select aa).FirstOrDefault<VDaanVO>().color);
        //                    break;
        //                }
        //            case "english":
        //                {
        //                    str = string.Concat(str, (
        //                        from aa in ruleDAO.Get_VDAAN()
        //                        where aa.planet.Equals(planetname.ToLower())
        //                        select aa).FirstOrDefault<VDaanVO>().english_color.ToString());
        //                    break;
        //                }
        //            case "tamil":
        //                {
        //                    str = string.Concat(str, (
        //                        from aa in ruleDAO.Get_VDAAN()
        //                        where aa.planet.Equals(planetname.ToLower())
        //                        select aa).FirstOrDefault<VDaanVO>().tamil_color.ToString());
        //                    break;
        //                }
        //            case "bangla":
        //                {
        //                    str = string.Concat(str, (
        //                        from aa in ruleDAO.Get_VDAAN()
        //                        where aa.planet.Equals(planetname.ToLower())
        //                        select aa).FirstOrDefault<VDaanVO>().bangla_color.ToString());
        //                    break;
        //                }
        //            case "telugu":
        //                {
        //                    str = string.Concat(str, (
        //                        from aa in ruleDAO.Get_VDAAN()
        //                        where aa.planet.Equals(planetname.ToLower())
        //                        select aa).FirstOrDefault<VDaanVO>().telugu_color.ToString());
        //                    break;
        //                }
        //            case "kannada":
        //                {
        //                    str = string.Concat(str, (
        //                        from aa in ruleDAO.Get_VDAAN()
        //                        where aa.planet.Equals(planetname.ToLower())
        //                        select aa).FirstOrDefault<VDaanVO>().kannada_color.ToString());
        //                    break;
        //                }
        //            case "marathi":
        //                {
        //                    str = string.Concat(str, (
        //                        from aa in ruleDAO.Get_VDAAN()
        //                        where aa.planet.Equals(planetname.ToLower())
        //                        select aa).FirstOrDefault<VDaanVO>().marathi_color.ToString());
        //                    break;
        //                }
        //            case "gujarati":
        //                {
        //                    str = string.Concat(str, (
        //                        from aa in ruleDAO.Get_VDAAN()
        //                        where aa.planet.Equals(planetname.ToLower())
        //                        select aa).FirstOrDefault<VDaanVO>().gujarati_color.ToString());
        //                    break;
        //                }
        //            case "punjabi":
        //                {
        //                    str = string.Concat(str, (
        //                        from aa in ruleDAO.Get_VDAAN()
        //                        where aa.planet.Equals(planetname.ToLower())
        //                        select aa).FirstOrDefault<VDaanVO>().punjabi_color.ToString());
        //                    break;
        //                }
        //        }
        //    }
        //    return str;
        //}

        //public string getvargitdaan(string planetname, string lang, string house, bool bad)
        //{
        //    int i;
        //    char[] chrArray;
        //    string str = "";
        //    RuleDAO ruleDAO = new RuleDAO();
        //    List<VDaanVO> list = (
        //        from av in ruleDAO.Get_VDAAN()
        //        where av.planet.Equals(planetname.ToLower())
        //        select av).ToList<VDaanVO>();
        //    List<long> nums = new List<long>();
        //    foreach (VDaanVO vDaanVO in list)
        //    {
        //        string[] array = null;
        //        if (!bad)
        //        {
        //            string str1 = vDaanVO.inhouse;
        //            chrArray = new char[] { ',' };
        //            array = str1.Split(chrArray).ToArray<string>();
        //        }
        //        else
        //        {
        //            string str2 = vDaanVO.outhouse;
        //            chrArray = new char[] { ',' };
        //            array = str2.Split(chrArray).ToArray<string>();
        //        }
        //        for (i = 0; i < array.Count<string>(); i++)
        //        {
        //            if (array[i] == house)
        //            {
        //                nums.Add((long)vDaanVO.sno);
        //            }
        //        }
        //    }
        //    for (i = 0; i < nums.Count; i++)
        //    {
        //        long item = nums[i];
        //        string str3 = lang;
        //        if (str3 != null)
        //        {
        //            switch (str3)
        //            {
        //                case "hindi":
        //                    {
        //                        str = string.Concat(str, (
        //                            from aa in ruleDAO.Get_VDAAN()
        //                            where (long)aa.sno == item
        //                            select aa).FirstOrDefault<VDaanVO>().vdaan.ToString());
        //                        break;
        //                    }
        //                case "english":
        //                    {
        //                        str = string.Concat(str, (
        //                            from aa in ruleDAO.Get_VDAAN()
        //                            where (long)aa.sno == item
        //                            select aa).FirstOrDefault<VDaanVO>().english_vdaan.ToString());
        //                        break;
        //                    }
        //                case "tamil":
        //                    {
        //                        str = string.Concat(str, (
        //                            from aa in ruleDAO.Get_VDAAN()
        //                            where (long)aa.sno == item
        //                            select aa).FirstOrDefault<VDaanVO>().tamil_vdaan.ToString());
        //                        break;
        //                    }
        //                case "bangla":
        //                    {
        //                        str = string.Concat(str, (
        //                            from aa in ruleDAO.Get_VDAAN()
        //                            where (long)aa.sno == item
        //                            select aa).FirstOrDefault<VDaanVO>().bangla_vdaan.ToString());
        //                        break;
        //                    }
        //                case "telugu":
        //                    {
        //                        str = string.Concat(str, (
        //                            from aa in ruleDAO.Get_VDAAN()
        //                            where (long)aa.sno == item
        //                            select aa).FirstOrDefault<VDaanVO>().telugu_vdaan.ToString());
        //                        break;
        //                    }
        //                case "kannada":
        //                    {
        //                        str = string.Concat(str, (
        //                            from aa in ruleDAO.Get_VDAAN()
        //                            where (long)aa.sno == item
        //                            select aa).FirstOrDefault<VDaanVO>().kannada_vdaan.ToString());
        //                        break;
        //                    }
        //                case "marathi":
        //                    {
        //                        str = string.Concat(str, (
        //                            from aa in ruleDAO.Get_VDAAN()
        //                            where (long)aa.sno == item
        //                            select aa).FirstOrDefault<VDaanVO>().marathi_vdaan.ToString());
        //                        break;
        //                    }
        //                case "gujarati":
        //                    {
        //                        str = string.Concat(str, (
        //                            from aa in ruleDAO.Get_VDAAN()
        //                            where (long)aa.sno == item
        //                            select aa).FirstOrDefault<VDaanVO>().gujarati_vdaan.ToString());
        //                        break;
        //                    }
        //                case "punjabi":
        //                    {
        //                        str = string.Concat(str, (
        //                            from aa in ruleDAO.Get_VDAAN()
        //                            where (long)aa.sno == item
        //                            select aa).FirstOrDefault<VDaanVO>().punjabi_vdaan.ToString());
        //                        break;
        //                    }
        //            }
        //        }
        //    }
        //    return str;
        //}

        //private string GetVarshFal(KundliVO perskv, List<KundliMappingVO> lkmv, List<KundliMappingVO> VVlkmv, short year, bool showref, bool marking, bool male, string janamsamay, string lang, bool paid)
        //{
        //    RulesVO rulesVO = null;
        //    bool house;
        //    string str = "";
        //    long num = (long)0;
        //    bool isBad = false;
        //    this.paidpred = paid;
        //    short num1 = 0;
        //    GetPlanetVO getPlanetVO = new GetPlanetVO();
        //    KundliBLL kundliBLL = new KundliBLL();
        //    RuleBLL ruleBLL = new RuleBLL();
        //    string str1 = "";
        //    ruleBLL.CalcKundliPlanets(VVlkmv);
        //    bool flag = false;
        //    if (perskv.Sub_prodtype == "mobile")
        //    {
        //        flag = true;
        //    }
        //    int num2 = 2;
        //    Years35BLL years35BLL = new Years35BLL();
        //    PlanetBLL planetBLL = new PlanetBLL();
        //    List<Years35VO> years35VOs = years35BLL.Get35Years(janamsamay);
        //    AstroDAL astroDAL = new AstroDAL();
        //    string str2 = (
        //        from map in years35VOs
        //        where map.Years == (long)year
        //        select map).FirstOrDefault<Years35VO>().Planet.ToString();
        //    List<PlanetHouseMappingVO> planetHouseMappingVOs = new List<PlanetHouseMappingVO>();
        //    long house1 = (long)(
        //        from lk in VVlkmv
        //        where lk.PlanetName.Equals(str2)
        //        select lk).FirstOrDefault<KundliMappingVO>().House;
        //    planetHouseMappingVOs = (
        //        from pk in planetBLL.GetPakkeGhar()
        //        where (long)pk.House == house1
        //        select pk).ToList<PlanetHouseMappingVO>();
        //    long num3 = (long)0;
        //    if ((house1 == (long)1 || house1 == (long)7 || house1 == (long)4 ? true : house1 == (long)10))
        //    {
        //        num3 = (house1 + (long)6) % (long)12;
        //    }
        //    string str3 = "";
        //    ProductSettingsVO productSettingsVO = new ProductSettingsVO();
        //    List<KPPlanetMappingVO> kPPlanetMappingVOs = new List<KPPlanetMappingVO>();
        //    List<KPHouseMappingVO> kPHouseMappingVOs = new List<KPHouseMappingVO>();
        //    KPBLL kPBLL = new KPBLL();
        //    productSettingsVO.Online_Result = perskv.Online_Result;
        //    productSettingsVO.Include = false;
        //    productSettingsVO.Lang = perskv.Language;
        //    productSettingsVO.Male = male;
        //    productSettingsVO.PredFor = 0;
        //    productSettingsVO.ShowRef = perskv.ShowRef;
        //    productSettingsVO.ShowUpay = false;
        //    productSettingsVO.ShowUpayCode = false;
        //    productSettingsVO.Sno = (long)555;
        //    productSettingsVO.Category = "all";
        //    productSettingsVO.Product = "";
        //    kPBLL.Process_Planet_Lagan(perskv.Online_Result, ref kPPlanetMappingVOs, ref kPHouseMappingVOs, perskv.Rotate, false);
        //    kPPlanetMappingVOs = kPBLL.Process_KPChart_GoodBad(kPPlanetMappingVOs, perskv, productSettingsVO);
        //    foreach (KundliMappingVO vVlkmv in VVlkmv)
        //    {
        //        num = (long)0;
        //        short planet = 0;
        //        string signiStringWithoutNakRashi = "";
        //        List<RulesVO> list = (
        //            from Rules in kundliBLL.GetAdvancePredictions(VVlkmv, vVlkmv.Planet, num2)
        //            where (Rules.Isbad != vVlkmv.VIsBad ? false : Rules.RuleType == "vfal")
        //            select Rules).ToList<RulesVO>();
        //        planet = (
        //            from Map in kPBLL.Fill_Planets()
        //            where Map.English == vVlkmv.PlanetNameEnglish
        //            select Map).SingleOrDefault<KPPlanetsVO>().Planet;
        //        signiStringWithoutNakRashi = kPBLL.Get_Signi_String_Without_NakRashi(planet, kPPlanetMappingVOs, false);
        //        num = Convert.ToInt64((
        //            from Map in years35VOs
        //            where (Map.Years != (long)year ? false : (Map.Period.Contains(vVlkmv.PlanetName) ? true : Map.Planet == vVlkmv.PlanetName))
        //            select Map).Count<Years35VO>());
        //        if (num > (long)0)
        //        {
        //            isBad = (
        //                from Map in lkmv
        //                where Map.PlanetName == vVlkmv.PlanetName
        //                select Map).SingleOrDefault<KundliMappingVO>().IsBad;
        //        }
        //        if (num < (long)1)
        //        {
        //            if ((
        //                from pp in planetHouseMappingVOs
        //                where pp.Planet == vVlkmv.Planet
        //                select pp).Count<PlanetHouseMappingVO>() > 0)
        //            {
        //                goto Label1;
        //            }
        //            house = (long)vVlkmv.House != num3;
        //            goto Label0;
        //        }
        //    Label1:
        //        house = false;
        //    Label0:
        //        if (!house)
        //        {
        //            str1 = string.Concat(str1, "\r\n");
        //            if (num1 != year)
        //            {
        //                str1 = string.Concat(str1, "\r\n");
        //            }
        //            num1 = year;
        //            if (marking)
        //            {
        //                foreach (RulesVO rulesVO in list)
        //                {
        //                    str = (year < 18 ? this.Get_Pred_Text(rulesVO.Sno, lang, male, false, showref, true, paid, true, flag, perskv) : this.Get_Pred_Text(rulesVO.Sno, lang, male, true, showref, true, paid, true, flag, perskv));
        //                    if (!showref)
        //                    {
        //                        str1 = string.Concat(str1, str);
        //                    }
        //                    else
        //                    {
        //                        object obj = str1;
        //                        object[] sno = new object[] { obj, str, "   ", rulesVO.Sno, "  ", ruleBLL.GetPlanetByRuleNo(rulesVO.Sno).Planet, " ", ruleBLL.GetPlanetByRuleNo(rulesVO.Sno).House, " ", rulesVO.Reference };
        //                        str1 = string.Concat(sno);
        //                    }
        //                }
        //                str1 = string.Concat(str1, "\r\n\r\n", str3);
        //            }
        //        }
        //        if (!marking)
        //        {
        //            foreach (RulesVO rulesVO1 in list)
        //            {
        //                str = (year < 18 ? this.Get_Pred_Text(rulesVO1.Sno, lang, male, false, showref, true, paid, true, flag, perskv) : this.Get_Pred_Text(rulesVO1.Sno, lang, male, true, showref, true, paid, true, flag, perskv));
        //                long length = (long)str.Length;
        //                if (!paid)
        //                {
        //                    length = (!vVlkmv.VIsBad ? (long)str.IndexOf("vr% 'kqHk Qyksa") : (long)str.IndexOf("vr% v'kqHk Qyksa"));
        //                }
        //                if (lang == "english")
        //                {
        //                    length = (long)str.ToLower().IndexOf("do the following remedies");
        //                }
        //                str1 = string.Concat(str1, str.Substring(0, Convert.ToInt16(length)));
        //                str1 = string.Concat(str1, "\r\n");
        //            }
        //        }
        //    }
        //    return str1;
        //}

        //private string GetVarshFal_35years(List<KundliMappingVO> lkmv, short year, bool showref, bool marking, bool male, string janamsamay, string lang, KundliVO persKV)
        //{
        //    long? nullable;
        //    bool flag;
        //    PlanetBLL planetBLL = new PlanetBLL();
        //    long num = (long)0;
        //    string str = "";
        //    long num1 = (long)0;
        //    List<PlanetHouseMappingVO> planetHouseMappingVOs = new List<PlanetHouseMappingVO>();
        //    RulesVO rulesVO = new RulesVO();
        //    List<string> strs = new List<string>();
        //    GetPlanetVO getPlanetVO = new GetPlanetVO();
        //    KundliBLL kundliBLL = new KundliBLL();
        //    RuleBLL ruleBLL = new RuleBLL();
        //    AstroDAL astroDAL = new AstroDAL();
        //    int num2 = 2;
        //    Years35BLL years35BLL = new Years35BLL();
        //    List<Years35VO> years35VOs = years35BLL.Get35Years(janamsamay);
        //    Years35VO years35VO = (
        //        from Map in years35VOs
        //        where Map.Years == (long)year
        //        select Map).SingleOrDefault<Years35VO>();
        //    int? _swami = astroDAL.GetRashiById((long)(
        //        from pp in lkmv
        //        where pp.PlanetName.Equals(years35VO.Planet)
        //        select pp).FirstOrDefault<KundliMappingVO>().Rashi).get_swami();
        //    if (_swami.HasValue)
        //    {
        //        nullable = new long?((long)_swami.GetValueOrDefault());
        //    }
        //    else
        //    {
        //        nullable = null;
        //    }
        //    long? nullable1 = nullable;
        //    string str1 = astroDAL.GetPlanetById(Convert.ToInt64(nullable1)).get_name().ToString();
        //    PlanetBLL planetBLL1 = new PlanetBLL();
        //    long umra = years35BLL.GetUmra(years35VO.Planet) - (long)1;
        //    long num3 = Convert.ToInt64((
        //        from Map in years35VOs
        //        where Map.Years >= (long)year
        //        select Map).TakeWhile<Years35VO>((Years35VO Map) => Map.Planet == years35VO.Planet).Max<Years35VO>((Years35VO Map) => Map.Years));
        //    long num4 = num3 - umra;
        //    if (this.prev_umra == (long)0)
        //    {
        //        this.prev_umra = num4;
        //    }
        //    if (num4 >= this.prev_umra + (long)35)
        //    {
        //        this.umra_method_planet_used = new List<string>();
        //        this.prev_umra = num4;
        //    }
        //    strs = strs.Distinct<string>().Except<string>(this.umra_method_planet_used).ToList<string>();
        //    strs.Add(years35VO.Planet);
        //    if (!strs.Contains(str1))
        //    {
        //    }
        //    string period = years35VO.Period;
        //    char[] chrArray = new char[] { '/' };
        //    strs.AddRange(period.Split(chrArray).ToList<string>());
        //    strs = strs.Distinct<string>().Except<string>(this.umra_method_planet_used).ToList<string>();
        //    this.umra_method_planet_used.AddRange(strs.Distinct<string>().ToList<string>());
        //    foreach (string str2 in strs)
        //    {
        //        KundliMappingVO kundliMappingVO = new KundliMappingVO();
        //        kundliMappingVO = (
        //            from Map in lkmv
        //            where Map.PlanetName == str2
        //            select Map).SingleOrDefault<KundliMappingVO>();
        //        if (male)
        //        {
        //            rulesVO = (
        //                from Rules in kundliBLL.GetAdvancePredictions(lkmv, kundliMappingVO.Planet, num2)
        //                where (Rules.Isbad != kundliMappingVO.IsBad ? false : Rules.RuleType == "general")
        //                select Rules).FirstOrDefault<RulesVO>();
        //        }
        //        if (rulesVO != null)
        //        {
        //            if (year >= 18)
        //            {
        //                str = string.Concat(str, this.Get_Pred_Text(rulesVO.Sno, lang, male, true, showref, true, true, true, false, persKV));
        //                RulesVO advanceRuleById = new RulesVO();
        //                RuleDAO ruleDAO = new RuleDAO();
        //                advanceRuleById = ruleBLL.GetAdvanceRuleById(rulesVO.Sno);
        //                UpayIndex upayIndex = new UpayIndex();
        //                upayIndex = ruleDAO.Get_UpayIndex(Convert.ToInt32(advanceRuleById.Upay));
        //                if (upayIndex != null)
        //                {
        //                    if (advanceRuleById.Upay <= 0)
        //                    {
        //                        flag = true;
        //                    }
        //                    else
        //                    {
        //                        flag = (lang.ToLower() == "hindi" || lang.ToLower() == "marathi" ? false : !(lang.ToLower() == "english"));
        //                    }
        //                    if (!flag)
        //                    {
        //                        if (!this.all_upayindex_sno.Contains((long)upayIndex.Sno))
        //                        {
        //                            this.all_upayindex_sno.Add((long)upayIndex.Sno);
        //                        }
        //                    }
        //                }
        //                str = string.Concat(str, "\r\n");
        //            }
        //            if (showref)
        //            {
        //                long sno = rulesVO.Sno;
        //                str = string.Concat(str, sno.ToString());
        //                str = string.Concat(str, "\r\n");
        //            }
        //        }
        //        num += (long)1;
        //    }
        //    return str;
        //}

        //private string GetVarshFal_Same(List<KundliMappingVO> lkmv, List<KundliMappingVO> VVlkmv, short year, bool showref, bool marking, bool male, string janamsamay, string lang, bool paid, string vfaltype, KundliVO persKV)
        //{
        //    bool house;
        //    string str = "";
        //    List<RulesVO> rulesVOs = new List<RulesVO>();
        //    long num = (long)0;
        //    bool isBad = false;
        //    this.paidpred = paid;
        //    List<long> nums = new List<long>();
        //    GetPlanetVO getPlanetVO = new GetPlanetVO();
        //    KundliBLL kundliBLL = new KundliBLL();
        //    RuleBLL ruleBLL = new RuleBLL();
        //    string str1 = "";
        //    ruleBLL.CalcKundliPlanets(VVlkmv);
        //    int num1 = 2;
        //    Years35BLL years35BLL = new Years35BLL();
        //    PlanetBLL planetBLL = new PlanetBLL();
        //    List<Years35VO> years35VOs = years35BLL.Get35Years(janamsamay);
        //    AstroDAL astroDAL = new AstroDAL();
        //    string str2 = (
        //        from map in years35VOs
        //        where map.Years == (long)year
        //        select map).FirstOrDefault<Years35VO>().Planet.ToString();
        //    List<PlanetHouseMappingVO> planetHouseMappingVOs = new List<PlanetHouseMappingVO>();
        //    long house1 = (long)(
        //        from lk in VVlkmv
        //        where lk.PlanetName.Equals(str2)
        //        select lk).FirstOrDefault<KundliMappingVO>().House;
        //    planetHouseMappingVOs = (
        //        from pk in planetBLL.GetPakkeGhar()
        //        where (long)pk.House == house1
        //        select pk).ToList<PlanetHouseMappingVO>();
        //    long num2 = (long)0;
        //    if ((house1 == (long)1 || house1 == (long)7 || house1 == (long)4 ? true : house1 == (long)10))
        //    {
        //        num2 = (house1 + (long)6) % (long)12;
        //    }
        //    foreach (KundliMappingVO vVlkmv in VVlkmv)
        //    {
        //        num = (long)0;
        //        List<string> strs = new List<string>();
        //        Years35BLL years35BLL1 = new Years35BLL();
        //        string antar = this.GetAntar(vVlkmv.PlanetName.ToString());
        //        char[] chrArray = new char[] { '/' };
        //        strs.AddRange(antar.Split(chrArray).ToList<string>());
        //        num = Convert.ToInt64((
        //            from Map in years35VOs
        //            where (Map.Years != (long)year ? false : (Map.Period.Contains(vVlkmv.PlanetName) ? true : Map.Planet == vVlkmv.PlanetName))
        //            select Map).Count<Years35VO>());
        //        if (num > (long)0)
        //        {
        //            isBad = (
        //                from Map in lkmv
        //                where Map.PlanetName == vVlkmv.PlanetName
        //                select Map).SingleOrDefault<KundliMappingVO>().IsBad;
        //        }
        //        if (num < (long)1)
        //        {
        //            if ((
        //                from pp in planetHouseMappingVOs
        //                where pp.Planet == vVlkmv.Planet
        //                select pp).Count<PlanetHouseMappingVO>() > 0)
        //            {
        //                goto Label1;
        //            }
        //            house = (long)vVlkmv.House != num2;
        //            goto Label0;
        //        }
        //    Label1:
        //        house = false;
        //    Label0:
        //        if (!house)
        //        {
        //            str1 = string.Concat(str1, "\r\n");
        //            str1 = string.Concat(str1, this.lrs.major(lang, year.ToString(), false).ToString());
        //            str1 = string.Concat(str1, "\r\n");
        //        }
        //        foreach (string str3 in strs)
        //        {
        //            List<KundliMappingVO> kundliMappingVOs = new List<KundliMappingVO>();
        //            KundliMappingVO kundliMappingVO = new KundliMappingVO();
        //            kundliMappingVO = (
        //                from Map in VVlkmv
        //                where Map.PlanetName == str3
        //                select Map).SingleOrDefault<KundliMappingVO>();
        //            kundliMappingVOs = VVlkmv;
        //            if (vfaltype == "Same")
        //            {
        //                kundliMappingVOs[Convert.ToInt16((
        //                    from Map in kundliMappingVOs
        //                    where (Map.House != vVlkmv.House ? false : Map.PlanetName == str3)
        //                    select Map.Sno).SingleOrDefault<long>())].House = vVlkmv.House;
        //            }
        //            List<RulesVO> list = kundliBLL.GetAdvancePredictions(kundliMappingVOs, this.findplanet_by_name(str3).Sno, num1).ToList<RulesVO>();
        //            rulesVOs = (
        //                from Rules in list
        //                where (Rules.Isbad != (
        //                    from Map in kundliMappingVOs
        //                    where Map.PlanetName.Contains(str3)
        //                    select Map).SingleOrDefault<KundliMappingVO>().VIsBad ? false : Rules.RuleType == "splvfal")
        //                select Rules).ToList<RulesVO>();
        //            foreach (RulesVO rulesVO in rulesVOs)
        //            {
        //                if (!nums.Exists((long Map) => Map == rulesVO.Sno))
        //                {
        //                    str = (year < 18 ? this.Get_Pred_Text(rulesVO.Sno, lang, male, false, showref, true, paid, true, false, persKV) : this.Get_Pred_Text(rulesVO.Sno, lang, male, true, showref, true, paid, true, false, persKV));
        //                    nums.Add(rulesVO.Sno);
        //                    long length = (long)str.Length;
        //                    if (!paid)
        //                    {
        //                        length = (!vVlkmv.VIsBad ? (long)str.IndexOf("vr% 'kqHk Qyksa") : (long)str.IndexOf("vr% v'kqHk Qyksa"));
        //                    }
        //                    if (lang == "english")
        //                    {
        //                        length = (long)str.ToLower().IndexOf("do the following remedies");
        //                    }
        //                    str1 = string.Concat(str1, str.Substring(0, Convert.ToInt16(length)));
        //                    str1 = string.Concat(str1, "\r\n");
        //                }
        //            }
        //        }
        //    }
        //    return str1;
        //}

        //public string GetWeekFal(KundliVO perskv, List<KundliMappingVO> lkmv, short year, short smonth, short week, bool showref, bool marking, bool male, string janamsamay, string lang, bool paid, DateTime wdate)
        //{
        //    RulesVO rulesVO = null;
        //    bool house;
        //    string str = "";
        //    long num = (long)0;
        //    bool isBad = false;
        //    this.paidpred = paid;
        //    PredictionBLL predictionBLL = new PredictionBLL();
        //    List<KundliMappingVO> kundliMappingVOs = new List<KundliMappingVO>();
        //    List<KundliMappingVO> monthlyKundli = new List<KundliMappingVO>();
        //    GetPlanetVO getPlanetVO = new GetPlanetVO();
        //    KundliBLL kundliBLL = new KundliBLL();
        //    RuleBLL ruleBLL = new RuleBLL();
        //    string str1 = "";
        //    bool flag = false;
        //    if (perskv.Sub_prodtype == "mobile")
        //    {
        //        flag = true;
        //    }
        //    foreach (short num1 in new List<short>()
        //    {
        //        smonth
        //    })
        //    {
        //        monthlyKundli = kundliBLL.GetMonthlyKundli(year, num1, perskv, lkmv);
        //        kundliMappingVOs = kundliBLL.GetWeekKundli(year, num1, week, perskv, monthlyKundli);
        //        ruleBLL.CalcKundliPlanets(kundliMappingVOs);
        //        int num2 = 2;
        //        Years35BLL years35BLL = new Years35BLL();
        //        PlanetBLL planetBLL = new PlanetBLL();
        //        List<Years35VO> years35VOs = years35BLL.Get35Years(janamsamay);
        //        AstroDAL astroDAL = new AstroDAL();
        //        string str2 = (
        //            from map in years35VOs
        //            where map.Years == (long)year
        //            select map).FirstOrDefault<Years35VO>().Planet.ToString();
        //        List<PlanetHouseMappingVO> planetHouseMappingVOs = new List<PlanetHouseMappingVO>();
        //        long house1 = (long)(
        //            from lk in kundliMappingVOs
        //            where lk.PlanetName.Equals(str2)
        //            select lk).FirstOrDefault<KundliMappingVO>().House;
        //        planetHouseMappingVOs = (
        //            from pk in planetBLL.GetPakkeGhar()
        //            where (long)pk.House == house1
        //            select pk).ToList<PlanetHouseMappingVO>();
        //        long num3 = (long)0;
        //        if ((house1 == (long)1 || house1 == (long)7 || house1 == (long)4 ? true : house1 == (long)10))
        //        {
        //            num3 = (house1 + (long)6) % (long)12;
        //        }
        //        short num4 = 0;
        //        foreach (KundliMappingVO kundliMappingVO in kundliMappingVOs)
        //        {
        //            num = (long)0;
        //            List<RulesVO> list = (
        //                from Rules in kundliBLL.GetAdvancePredictions(kundliMappingVOs, kundliMappingVO.Planet, num2)
        //                where (Rules.Isbad != kundliMappingVO.VIsBad ? false : Rules.RuleType == "wfal")
        //                select Rules).ToList<RulesVO>();
        //            num = Convert.ToInt64((
        //                from Map in years35VOs
        //                where (Map.Years != (long)year ? false : (Map.Period.Contains(kundliMappingVO.PlanetName) ? true : Map.Planet == kundliMappingVO.PlanetName))
        //                select Map).Count<Years35VO>());
        //            if (num > (long)0)
        //            {
        //                isBad = (
        //                    from Map in lkmv
        //                    where Map.PlanetName == kundliMappingVO.PlanetName
        //                    select Map).SingleOrDefault<KundliMappingVO>().IsBad;
        //            }
        //            if (num < (long)1)
        //            {
        //                if ((
        //                    from pp in planetHouseMappingVOs
        //                    where pp.Planet == kundliMappingVO.Planet
        //                    select pp).Count<PlanetHouseMappingVO>() > 0)
        //                {
        //                    goto Label1;
        //                }
        //                house = (long)kundliMappingVO.House != num3;
        //                goto Label0;
        //            }
        //        Label1:
        //            house = false;
        //        Label0:
        //            if (!house)
        //            {
        //                if (num4 != year)
        //                {
        //                    str1 = string.Concat(str1, "\r\n\r\n");
        //                    string str3 = str1;
        //                    string[] codeLang = new string[] { str3, predictionBLL.GetCodeLang("day", perskv.Language, perskv.Paid, flag), " ", wdate.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", wdate.ToString("%M")), perskv.Language, perskv.Paid, flag), " ", wdate.ToString("yyyy"), " ", predictionBLL.GetCodeLang("to", perskv.Language, perskv.Paid, flag), " ", null, null, null, null, null };
        //                    DateTime dateTime = wdate.AddDays(6);
        //                    codeLang[11] = dateTime.ToString("dd");
        //                    codeLang[12] = " ";
        //                    dateTime = wdate.AddDays(6);
        //                    codeLang[13] = predictionBLL.GetCodeLang(string.Concat("M", dateTime.ToString("%M")), perskv.Language, perskv.Paid, flag);
        //                    codeLang[14] = " ";
        //                    dateTime = wdate.AddDays(6);
        //                    codeLang[15] = dateTime.ToString("yyyy");
        //                    str1 = string.Concat(codeLang);
        //                    str1 = string.Concat(str1, "\r\n");
        //                }
        //                num4 = year;
        //                if (marking)
        //                {
        //                    foreach (RulesVO rulesVO in list)
        //                    {
        //                        str = (year < 18 ? this.Get_Pred_Text(rulesVO.Sno, lang, male, false, showref, true, paid, true, flag, perskv) : this.Get_Pred_Text(rulesVO.Sno, lang, male, true, showref, true, paid, true, flag, perskv));
        //                        str = string.Concat(str, "\r\n");
        //                        if (!showref)
        //                        {
        //                            str1 = string.Concat(str1, str);
        //                        }
        //                        else
        //                        {
        //                            object obj = str1;
        //                            object[] sno = new object[] { obj, str, "   ", rulesVO.Sno, "  ", ruleBLL.GetPlanetByRuleNo(rulesVO.Sno).Planet, " ", ruleBLL.GetPlanetByRuleNo(rulesVO.Sno).House, " ", rulesVO.Reference };
        //                            str1 = string.Concat(sno);
        //                        }
        //                    }
        //                }
        //            }
        //            if (!marking)
        //            {
        //                foreach (RulesVO rulesVO1 in list)
        //                {
        //                    str = (year < 18 ? this.Get_Pred_Text(rulesVO1.Sno, lang, male, false, showref, true, paid, true, flag, perskv) : this.Get_Pred_Text(rulesVO1.Sno, lang, male, true, showref, true, paid, true, flag, perskv));
        //                    str = string.Concat(str, "\r\n");
        //                    long length = (long)str.Length;
        //                    if (!paid)
        //                    {
        //                        length = (!kundliMappingVO.VIsBad ? (long)str.IndexOf("vr% 'kqHk Qyksa") : (long)str.IndexOf("vr% v'kqHk Qyksa"));
        //                    }
        //                    if (lang == "english")
        //                    {
        //                        length = (long)str.ToLower().IndexOf("do the following remedies");
        //                    }
        //                    str1 = string.Concat(str1, str.Substring(0, Convert.ToInt16(length)));
        //                    str1 = string.Concat(str1, "\r\n");
        //                }
        //            }
        //        }
        //    }
        //    return str1;
        //}

        //public string kp_rin_pitri(KundliVO persKV, List<KundliMappingVO> lkmv)
        //{
        //    string str = "";
        //    List<RulesVO> list = (
        //        from Rules in (new KundliBLL()).GetAdvancePredictions(lkmv, 0, 0)
        //        where Rules.RuleType == "rinpitri"
        //        select Rules).ToList<RulesVO>();
        //    if (list.Count > 0)
        //    {
        //        str = string.Concat(str, "\r\n", this.GetCodeLang("pitrrinn", persKV.Language, persKV.Paid, true), "\r\n\r\n");
        //        foreach (RulesVO rulesVO in list)
        //        {
        //            str = string.Concat(str, "\r\n\r\n", this.Get_Pred_Text(rulesVO.Sno, persKV.Language, persKV.Male, true, persKV.ShowRef, false, persKV.Paid, false, true, persKV));
        //        }
        //    }
        //    return str;
        //}

        public string KPgetvargitcolor(string planetname, string lang)
        {
            string str = "";
            RuleDAO ruleDAO = new RuleDAO();
            string str1 = lang;
            if (str1 != null)
            {
                switch (str1)
                {
                    case "hindi":
                        {
                            str = string.Concat(str, (
                                from aa in ruleDAO.Get_VDAAN()
                                where aa.planet.Equals(planetname.ToLower())
                                select aa).FirstOrDefault<VDaanVO>().color_unicode);
                            break;
                        }
                    case "english":
                        {
                            str = string.Concat(str, (
                                from aa in ruleDAO.Get_VDAAN()
                                where aa.planet.Equals(planetname.ToLower())
                                select aa).FirstOrDefault<VDaanVO>().english_color.ToString());
                            break;
                        }
                    case "tamil":
                        {
                            str = string.Concat(str, (
                                from aa in ruleDAO.Get_VDAAN()
                                where aa.planet.Equals(planetname.ToLower())
                                select aa).FirstOrDefault<VDaanVO>().tamil_color_unicode.ToString());
                            break;
                        }
                    case "bangla":
                        {
                            str = string.Concat(str, (
                                from aa in ruleDAO.Get_VDAAN()
                                where aa.planet.Equals(planetname.ToLower())
                                select aa).FirstOrDefault<VDaanVO>().bangla_color_unicode.ToString());
                            break;
                        }
                    case "telugu":
                        {
                            str = string.Concat(str, (
                                from aa in ruleDAO.Get_VDAAN()
                                where aa.planet.Equals(planetname.ToLower())
                                select aa).FirstOrDefault<VDaanVO>().telugu_color_unicode.ToString());
                            break;
                        }
                    case "kannada":
                        {
                            str = string.Concat(str, (
                                from aa in ruleDAO.Get_VDAAN()
                                where aa.planet.Equals(planetname.ToLower())
                                select aa).FirstOrDefault<VDaanVO>().kannada_color_unicode.ToString());
                            break;
                        }
                    case "marathi":
                        {
                            str = string.Concat(str, (
                                from aa in ruleDAO.Get_VDAAN()
                                where aa.planet.Equals(planetname.ToLower())
                                select aa).FirstOrDefault<VDaanVO>().marathi_color_unicode.ToString());
                            break;
                        }
                    case "gujarati":
                        {
                            str = string.Concat(str, (
                                from aa in ruleDAO.Get_VDAAN()
                                where aa.planet.Equals(planetname.ToLower())
                                select aa).FirstOrDefault<VDaanVO>().gujarati_color_unicode.ToString());
                            break;
                        }
                    case "punjabi":
                        {
                            str = string.Concat(str, (
                                from aa in ruleDAO.Get_VDAAN()
                                where aa.planet.Equals(planetname.ToLower())
                                select aa).FirstOrDefault<VDaanVO>().punjabi_color_unicode.ToString());
                            break;
                        }
                    case "oriya":
                        {
                            str = string.Concat(str, (
                                from aa in ruleDAO.Get_VDAAN()
                                where aa.planet.Equals(planetname.ToLower())
                                select aa).FirstOrDefault<VDaanVO>().oriya_color_unicode.ToString());
                            break;
                        }
                    case "malayalam":
                        {
                            str = string.Concat(str, (
                                from aa in ruleDAO.Get_VDAAN()
                                where aa.planet.Equals(planetname.ToLower())
                                select aa).FirstOrDefault<VDaanVO>().malayalam_color_unicode.ToString());
                            break;
                        }
                    case "assamese":
                        {
                            str = string.Concat(str, (
                                from aa in ruleDAO.Get_VDAAN()
                                where aa.planet.Equals(planetname.ToLower())
                                select aa).FirstOrDefault<VDaanVO>().assamese_color_unicode.ToString());
                            break;
                        }
                }
            }
            return str;
        }

        public string KPgetvargitdaan(string planetname, string lang, string house, bool bad)
        {
            int i;
            char[] chrArray;
            string str = "";
            RuleDAO ruleDAO = new RuleDAO();
            List<VDaanVO> list = (
                from av in ruleDAO.Get_VDAAN()
                where av.planet.Equals(planetname.ToLower())
                select av).ToList<VDaanVO>();
            List<long> nums = new List<long>();
            foreach (VDaanVO vDaanVO in list)
            {
                string[] array = null;
                if (!bad)
                {
                    string str1 = vDaanVO.inhouse;
                    chrArray = new char[] { ',' };
                    array = str1.Split(chrArray).ToArray<string>();
                }
                else
                {
                    string str2 = vDaanVO.outhouse;
                    chrArray = new char[] { ',' };
                    array = str2.Split(chrArray).ToArray<string>();
                }
                for (i = 0; i < array.Count<string>(); i++)
                {
                    if (array[i] == house)
                    {
                        nums.Add((long)vDaanVO.sno);
                    }
                }
            }
            for (i = 0; i < nums.Count; i++)
            {
                long item = nums[i];
                string str3 = lang;
                if (str3 != null)
                {
                    switch (str3)
                    {
                        case "hindi":
                            {
                                str = string.Concat(str, (
                                    from aa in ruleDAO.Get_VDAAN()
                                    where (long)aa.sno == item
                                    select aa).FirstOrDefault<VDaanVO>().vdaan_unicode.ToString());
                                break;
                            }
                        case "english":
                            {
                                str = string.Concat(str, (
                                    from aa in ruleDAO.Get_VDAAN()
                                    where (long)aa.sno == item
                                    select aa).FirstOrDefault<VDaanVO>().english_vdaan.ToString());
                                break;
                            }
                        case "tamil":
                            {
                                str = string.Concat(str, (
                                    from aa in ruleDAO.Get_VDAAN()
                                    where (long)aa.sno == item
                                    select aa).FirstOrDefault<VDaanVO>().tamil_vdaan_unicode.ToString());
                                break;
                            }
                        case "bangla":
                            {
                                str = string.Concat(str, (
                                    from aa in ruleDAO.Get_VDAAN()
                                    where (long)aa.sno == item
                                    select aa).FirstOrDefault<VDaanVO>().bangla_vdaan_unicode.ToString());
                                break;
                            }
                        case "telugu":
                            {
                                str = string.Concat(str, (
                                    from aa in ruleDAO.Get_VDAAN()
                                    where (long)aa.sno == item
                                    select aa).FirstOrDefault<VDaanVO>().telugu_vdaan_unicode.ToString());
                                break;
                            }
                        case "kannada":
                            {
                                str = string.Concat(str, (
                                    from aa in ruleDAO.Get_VDAAN()
                                    where (long)aa.sno == item
                                    select aa).FirstOrDefault<VDaanVO>().kannada_vdaan_unicode.ToString());
                                break;
                            }
                        case "marathi":
                            {
                                str = string.Concat(str, (
                                    from aa in ruleDAO.Get_VDAAN()
                                    where (long)aa.sno == item
                                    select aa).FirstOrDefault<VDaanVO>().marathi_vdaan_unicode.ToString());
                                break;
                            }
                        case "gujarati":
                            {
                                str = string.Concat(str, (
                                    from aa in ruleDAO.Get_VDAAN()
                                    where (long)aa.sno == item
                                    select aa).FirstOrDefault<VDaanVO>().gujarati_vdaan_unicode.ToString());
                                break;
                            }
                        case "punjabi":
                            {
                                str = string.Concat(str, (
                                    from aa in ruleDAO.Get_VDAAN()
                                    where (long)aa.sno == item
                                    select aa).FirstOrDefault<VDaanVO>().punjabi_vdaan_unicode.ToString());
                                break;
                            }
                        case "oriya":
                            {
                                str = string.Concat(str, (
                                    from aa in ruleDAO.Get_VDAAN()
                                    where (long)aa.sno == item
                                    select aa).FirstOrDefault<VDaanVO>().oriya_vdaan_unicode.ToString());
                                break;
                            }
                        case "malayalam":
                            {
                                str = string.Concat(str, (
                                    from aa in ruleDAO.Get_VDAAN()
                                    where (long)aa.sno == item
                                    select aa).FirstOrDefault<VDaanVO>().malayalam_vdaan_unicode.ToString());
                                break;
                            }
                        case "assamese":
                            {
                                str = string.Concat(str, (
                                    from aa in ruleDAO.Get_VDAAN()
                                    where (long)aa.sno == item
                                    select aa).FirstOrDefault<VDaanVO>().assamese_vdaan_unicode.ToString());
                                break;
                            }
                    }
                }
            }
            return str;
        }

        //public string Lagnaengine(KundliVO persKV, List<KundliMappingVO> lkmv)
        //{
        //    int num;
        //    long lagna = persKV.Lagna;
        //    long _sno = (long)0;
        //    string str = "";
        //    RuleDAO ruleDAO = new RuleDAO();
        //    AstroDAL astroDAL = new AstroDAL();
        //    List<long> nums = new List<long>();
        //    foreach (KundliMappingVO kundliMappingVO in lkmv)
        //    {
        //        _sno = astroDAL.GetPlanetByName(kundliMappingVO.PlanetName.ToString()).get_sno();
        //        LagnaVO lagnaVO = (
        //            from al in ruleDAO.Get_Laganfal(Convert.ToInt16(lagna))
        //            where ((long)al.rashi != lagna || al.house != kundliMappingVO.House || (long)al.planet1 != _sno ? false : al.planet2 == 0)
        //            select al).FirstOrDefault<LagnaVO>();
        //        if (lagnaVO != null)
        //        {
        //            str = string.Concat(str, "\r\n\r\n", lagnaVO.pred);
        //            if (persKV.ShowRef)
        //            {
        //                num = lagnaVO.sno;
        //                str = string.Concat(str, num.ToString(), " ", this.findplanet(kundliMappingVO.Planet).PlanetnameHindi);
        //            }
        //        }
        //        List<KundliMappingVO> list = (
        //            from lk in lkmv
        //            where (lk.House != kundliMappingVO.House ? false : lk.Planet != kundliMappingVO.Planet)
        //            select lk).ToList<KundliMappingVO>();
        //        foreach (KundliMappingVO kundliMappingVO1 in list)
        //        {
        //            long _sno1 = astroDAL.GetPlanetByName(kundliMappingVO1.PlanetName.ToString()).get_sno();
        //            if (!nums.Contains(_sno))
        //            {
        //                nums.Add(_sno1);
        //                LagnaVO lagnaVO1 = (
        //                    from al in ruleDAO.Get_Laganfal(Convert.ToInt16(lagna))
        //                    where ((long)al.rashi != lagna || al.house != kundliMappingVO.House || (long)al.planet1 != _sno ? false : (long)al.planet2 == _sno1)
        //                    select al).FirstOrDefault<LagnaVO>();
        //                if (lagnaVO1 != null)
        //                {
        //                    str = string.Concat(str, "\r\n\r\n", lagnaVO1.pred);
        //                    if (persKV.ShowRef)
        //                    {
        //                        num = lagnaVO1.sno;
        //                        str = string.Concat(str, num.ToString(), " ", this.findplanet(kundliMappingVO.Planet).PlanetnameHindi);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    return str;
        //}

        //public string Lagnaengine_House(KundliVO persKV, List<KundliMappingVO> lkmv, short house)
        //{
        //    long lagna = persKV.Lagna;
        //    long _sno = (long)0;
        //    string str = "";
        //    RuleDAO ruleDAO = new RuleDAO();
        //    List<KundliMappingVO> kundliMappingVOs = new List<KundliMappingVO>();
        //    AstroDAL astroDAL = new AstroDAL();
        //    List<long> nums = new List<long>();
        //    List<short> nums1 = new List<short>();
        //    if ((
        //        from Map in lkmv
        //        where Map.House == house
        //        select Map).Count<KundliMappingVO>() > 0)
        //    {
        //        kundliMappingVOs = (
        //            from Map in lkmv
        //            where Map.House == house
        //            select Map).ToList<KundliMappingVO>();
        //    }
        //    int planet = (
        //        from Map in this.pbl.GetPakkeGhar()
        //        where Map.House == house
        //        select Map).FirstOrDefault<PlanetHouseMappingVO>().Planet;
        //    kundliMappingVOs.AddRange((
        //        from Map in lkmv
        //        where Map.Planet == this.findplanet(planet).Sno
        //        select Map).ToList<KundliMappingVO>());
        //    string[] strArrays = this.pbl.GetFixHouse(house).Split(new char[] { ',' });
        //    for (int i = 0; i < (int)strArrays.Length; i++)
        //    {
        //        string str1 = strArrays[i];
        //        kundliMappingVOs.AddRange((
        //            from Map in lkmv
        //            where Map.Planet == this.findplanet_by_name(str1).Sno
        //            select Map).ToList<KundliMappingVO>());
        //    }
        //    foreach (KundliMappingVO kundliMappingVO in kundliMappingVOs)
        //    {
        //        _sno = astroDAL.GetPlanetByName(kundliMappingVO.PlanetName.ToString()).get_sno();
        //        LagnaVO lagnaVO = (
        //            from al in ruleDAO.Get_Laganfal(Convert.ToInt16(lagna))
        //            where ((long)al.rashi != lagna || al.house != kundliMappingVO.House || (long)al.planet1 != _sno ? false : al.planet2 == 0)
        //            select al).FirstOrDefault<LagnaVO>();
        //        if (lagnaVO != null)
        //        {
        //            if (!nums1.Exists((short Map) => Map == lagnaVO.sno))
        //            {
        //                str = string.Concat(str, "\r\n\r\n", lagnaVO.pred);
        //                nums1.Add(Convert.ToInt16(lagnaVO.sno));
        //            }
        //            if (persKV.ShowRef)
        //            {
        //                int num = lagnaVO.sno;
        //                str = string.Concat(str, num.ToString(), " ", this.findplanet(kundliMappingVO.Planet).PlanetnameHindi);
        //            }
        //        }
        //    }
        //    return str;
        //}

        //public string Lagnaengine_Samay(KundliVO persKV, List<KundliMappingVO> lkmv)
        //{
        //    int num;
        //    long lagna = persKV.Lagna;
        //    long _sno = (long)0;
        //    PlanetBLL planetBLL = new PlanetBLL();
        //    string str = "";
        //    List<Life35VO> life35VOs = new List<Life35VO>();
        //    life35VOs = (new KundliBLL()).GetLife35(persKV.JanamSamay);
        //    bool flag = false;
        //    long[] numArray = new long[12];
        //    string onlineResult = persKV.Online_Result;
        //    char[] chrArray = new char[] { '-' };
        //    string str1 = onlineResult.Split(chrArray)[1];
        //    chrArray = new char[] { '#' };
        //    str1.Split(chrArray);
        //    long lagna1 = persKV.Lagna;
        //    for (int i = 0; i < 12; i++)
        //    {
        //        if (lagna1 > (long)12)
        //        {
        //            lagna1 -= (long)12;
        //        }
        //        numArray[i] = lagna1;
        //        lagna1 += (long)1;
        //    }
        //    List<PlanetMAPVO> planetMAPVOs = new List<PlanetMAPVO>();
        //    planetMAPVOs = planetBLL.FillAllPlanets();
        //    foreach (Life35VO life35VO in life35VOs)
        //    {
        //        List<string> strs = new List<string>();
        //        List<long> nums = new List<long>();
        //        List<PlanetHouseMappingVO> planetHouseMappingVOs = new List<PlanetHouseMappingVO>();
        //        flag = true;
        //        string str2 = "";
        //        KundliMappingVO kundliMappingVO = new KundliMappingVO();
        //        kundliMappingVO = (
        //            from Map in lkmv
        //            where Map.PlanetName == life35VO.Planet
        //            select Map).SingleOrDefault<KundliMappingVO>();
        //        Years35BLL years35BLL = new Years35BLL();
        //        List<Years35VO> years35VOs = years35BLL.Get35Years(persKV.JanamSamay);
        //        AstroDAL astroDAL = new AstroDAL();
        //        long umra = years35BLL.GetUmra(kundliMappingVO.PlanetName) - (long)1;
        //        long num1 = Convert.ToInt64((
        //            from Map in years35VOs
        //            where Map.Planet == kundliMappingVO.PlanetName
        //            select Map).Min<Years35VO>((Years35VO Map) => Map.Years));
        //        str2 = string.Concat(str2, this.lrs.getPrabhav(num1, umra, persKV.Language).ToString());
        //        string str3 = str;
        //        string[] planetnameHindi = new string[] { str3, "\r\n\r\n", this.findplanet_by_name(life35VO.Planet.ToString()).PlanetnameHindi, "  ", str2 };
        //        str = string.Concat(planetnameHindi);
        //        planetHouseMappingVOs = (
        //            from Map in planetBLL.GetPakkeGhar()
        //            where Map.Planet == this.findplanet_by_name(life35VO.Planet.ToString()).Sno
        //            select Map).ToList<PlanetHouseMappingVO>();
        //        strs.Add(life35VO.Planet);
        //        int planet = (
        //            from Map in planetBLL.GetPakkeGhar()
        //            where Map.House == kundliMappingVO.House
        //            select Map).FirstOrDefault<PlanetHouseMappingVO>().Planet;
        //        if (!strs.Contains(this.findplanet(planet).Planetname))
        //        {
        //            strs.Add(this.findplanet(planet).Planetname);
        //        }
        //        RuleDAO ruleDAO = new RuleDAO();
        //        AstroDAL astroDAL1 = new AstroDAL();
        //        List<long> nums1 = new List<long>();
        //        List<long> nums2 = new List<long>();
        //        List<long> nums3 = new List<long>();
        //        foreach (string str4 in strs)
        //        {
        //            KundliMappingVO kundliMappingVO1 = new KundliMappingVO();
        //            kundliMappingVO1 = (
        //                from Map in lkmv
        //                where Map.PlanetName == str4
        //                select Map).FirstOrDefault<KundliMappingVO>();
        //            _sno = astroDAL1.GetPlanetByName(kundliMappingVO1.PlanetName.ToString()).get_sno();
        //            LagnaVO lagnaVO = (
        //                from al in ruleDAO.Get_Laganfal(Convert.ToInt16(lagna))
        //                where ((long)al.rashi != lagna || al.house != kundliMappingVO1.House || (long)al.planet1 != _sno ? false : al.planet2 == 0)
        //                select al).FirstOrDefault<LagnaVO>();
        //            if (lagnaVO != null)
        //            {
        //                if (!nums3.Contains((long)lagnaVO.sno))
        //                {
        //                    str = string.Concat(str, "\r\n\r\n", lagnaVO.pred);
        //                    nums3.Add((long)lagnaVO.sno);
        //                    if (persKV.ShowRef)
        //                    {
        //                        num = lagnaVO.sno;
        //                        str = string.Concat(str, num.ToString());
        //                    }
        //                }
        //            }
        //            List<KundliMappingVO> list = (
        //                from lk in lkmv
        //                where (lk.House != kundliMappingVO1.House ? false : lk.Planet != kundliMappingVO1.Planet)
        //                select lk).ToList<KundliMappingVO>();
        //            foreach (KundliMappingVO kundliMappingVO2 in list)
        //            {
        //                long _sno1 = astroDAL1.GetPlanetByName(kundliMappingVO2.PlanetName.ToString()).get_sno();
        //                if (!nums1.Contains(_sno))
        //                {
        //                    nums1.Add(_sno1);
        //                    LagnaVO lagnaVO1 = (
        //                        from al in ruleDAO.Get_Laganfal(Convert.ToInt16(lagna))
        //                        where ((long)al.rashi != lagna || al.house != kundliMappingVO1.House || (long)al.planet1 != _sno ? false : (long)al.planet2 == _sno1)
        //                        select al).FirstOrDefault<LagnaVO>();
        //                    if (lagnaVO1 != null)
        //                    {
        //                        if (!nums3.Contains((long)lagnaVO.sno))
        //                        {
        //                            str = string.Concat(str, "\r\n\r\n", lagnaVO1.pred);
        //                            nums3.Add((long)lagnaVO.sno);
        //                            if (persKV.ShowRef)
        //                            {
        //                                num = lagnaVO1.sno;
        //                                str = string.Concat(str, num.ToString());
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //            List<RulesVO> rulesVOs = new List<RulesVO>();
        //            rulesVOs = this.generate_final_lrvgen(persKV, lkmv, false, new List<short>(), persKV.Language, str4, false, false);
        //            foreach (RulesVO rulesVO in (
        //                from Map in rulesVOs
        //                where Map.Rule_Nature == 1
        //                select Map).ToList<RulesVO>())
        //            {
        //                if (!nums2.Contains(rulesVO.Sno))
        //                {
        //                    nums2.Add(rulesVO.Sno);
        //                    str = string.Concat(str, this.Get_Pred_Text(rulesVO.Sno, persKV.Language, true, true, persKV.ShowRef, false, true, true, false, persKV), "\r\n");
        //                }
        //            }
        //        }
        //    }
        //    return str;
        //}

        //public string mangal_pred(List<KundliMappingVO> janam_kund, string lang, bool paid, KundliVO persKV)
        //{
        //    string str = "";
        //    if ((new KundliBLL()).Is_Mangal_Bad(janam_kund) == 2)
        //    {
        //        str = string.Concat(str, this.GetCodeLang("Is_Mangal_Bad2", lang, paid, false).ToString(), "\r\n");
        //        str = string.Concat(str, this.Get_Pred_Text((long)5483, lang, true, true, false, false, true, true, false, persKV));
        //    }
        //    return str;
        //}

        public List<KundliMappingVO> map_kundali(string Online_Result, bool cusp)
        {
            int i;
            KundliBLL kundliBLL = new KundliBLL();
            List<KundliMappingVO> kundliMappingVOs = new List<KundliMappingVO>();
            long num = (long)0;
            int[] numArray = new int[13];
            int[] num1 = new int[13];
            int[] numArray1 = new int[12];
            int[] numArray2 = new int[12];
            char[] chrArray = new char[] { '-' };
            string[] strArrays = Online_Result.Split(chrArray);
            PredictionBLL predictionBLL = new PredictionBLL();
            string str = strArrays[0];
            chrArray = new char[] { '#' };
            string[] strArrays1 = str.Split(chrArray);
            string str1 = strArrays[1];
            chrArray = new char[] { '#' };
            string[] strArrays2 = str1.Split(chrArray);
            string str2 = strArrays[2];
            chrArray = new char[] { '#' };
            string[] strArrays3 = str2.Split(chrArray);
            string str3 = strArrays[4];
            chrArray = new char[] { '#' };
            string[] strArrays4 = str3.Split(chrArray);
            string str4 = strArrays[5];
            chrArray = new char[] { '#' };
            str4.Split(chrArray);
            string str5 = strArrays[3];
            chrArray = new char[] { '#' };
            Convert.ToInt64(str5.Split(chrArray)[0]);
            string str6 = strArrays[3];
            chrArray = new char[] { '#' };
            Convert.ToInt64(str6.Split(chrArray)[1]);
            string str7 = strArrays[3];
            chrArray = new char[] { '#' };
            Convert.ToInt64(str7.Split(chrArray)[2]);
            for (i = 0; i <= 12; i++)
            {
                numArray[i] = Convert.ToInt16(strArrays1[i]);
                num1[i] = Convert.ToInt16(strArrays2[i]);
            }
            int num2 = numArray[0];
            for (i = 0; i <= 11; i++)
            {
                numArray1[i] = Convert.ToInt16(strArrays3[i]);
            }
            for (int j = 1; j <= 9; j++)
            {
                num += (long)1;
                long num3 = (long)0;
                if (j == 1)
                {
                    num3 = (long)5;
                }
                if (j == 2)
                {
                    num3 = (long)4;
                }
                if (j == 3)
                {
                    num3 = (long)9;
                }
                if (j == 4)
                {
                    num3 = (long)8;
                }
                if (j == 5)
                {
                    num3 = (long)6;
                }
                if (j == 6)
                {
                    num3 = (long)7;
                }
                if (j == 7)
                {
                    num3 = (long)3;
                }
                if (j == 8)
                {
                    num3 = (long)1;
                }
                if (j == 9)
                {
                    num3 = (long)2;
                }
                KundliMappingVO kundliMappingVO = new KundliMappingVO()
                {
                    Kundliid = AstroGlobal.ActiveID
                };
                if (!cusp)
                {
                    kundliMappingVO.House = Convert.ToInt32(numArray[j]);
                }
                else
                {
                    kundliMappingVO.House = Convert.ToInt32(num1[j]);
                }
                kundliMappingVO.Sno = (long)(j - 1);
                if (numArray[j] + (num2 - 1) <= 12)
                {
                    kundliMappingVO.Rashi = Convert.ToInt32(numArray[j] + (num2 - 1));
                }
                else
                {
                    kundliMappingVO.Rashi = Convert.ToInt32(numArray[j] + (num2 - 1) - 12);
                }
                kundliMappingVO.Planet = Convert.ToInt32(num3);
                kundliMappingVO.PlanetName = kundliBLL.findplanet(kundliMappingVO.Planet).Planetname;
                kundliMappingVO.PlanetNameEnglish = kundliBLL.findplanet(kundliMappingVO.Planet).PlanetnameEnglish;
                kundliMappingVO.PlanetNameHindi = kundliBLL.findplanet(kundliMappingVO.Planet).PlanetnameHindi;
                kundliMappingVO.Degree = strArrays4[j];
                kundliMappingVOs.Add(kundliMappingVO);
            }
            kundliBLL.Process_Kundali_Planet_GoodBad(ref kundliMappingVOs);
            return kundliMappingVOs;
        }

        //public List<KundliMappingVO> map_kundali_chalit(string Online_Result)
        //{
        //    int i;
        //    KundliBLL kundliBLL = new KundliBLL();
        //    List<KundliMappingVO> kundliMappingVOs = new List<KundliMappingVO>();
        //    long num = (long)0;
        //    int[] numArray = new int[13];
        //    int[] num1 = new int[13];
        //    int[] numArray1 = new int[13];
        //    double[] num2 = new double[13];
        //    string[] strArrays = null;
        //    char[] chrArray = new char[] { '-' };
        //    string[] strArrays1 = Online_Result.Split(chrArray);
        //    PredictionBLL predictionBLL = new PredictionBLL();
        //    string str = strArrays1[0];
        //    chrArray = new char[] { '#' };
        //    string[] strArrays2 = str.Split(chrArray);
        //    string str1 = strArrays1[1];
        //    chrArray = new char[] { '#' };
        //    string[] strArrays3 = str1.Split(chrArray);
        //    string str2 = strArrays1[2];
        //    chrArray = new char[] { '#' };
        //    strArrays = str2.Split(chrArray);
        //    string str3 = strArrays1[3];
        //    chrArray = new char[] { '#' };
        //    string[] strArrays4 = str3.Split(chrArray);
        //    string str4 = strArrays1[4];
        //    chrArray = new char[] { '#' };
        //    Convert.ToInt64(str4.Split(chrArray)[0]);
        //    string str5 = strArrays1[4];
        //    chrArray = new char[] { '#' };
        //    Convert.ToInt64(str5.Split(chrArray)[1]);
        //    for (i = 0; i <= 12; i++)
        //    {
        //        numArray[i] = Convert.ToInt16(strArrays2[i]);
        //    }
        //    for (i = 0; i <= 12; i++)
        //    {
        //        num1[i] = Convert.ToInt16(strArrays3[i]);
        //    }
        //    for (i = 0; i <= 12; i++)
        //    {
        //        num2[i] = Convert.ToDouble(strArrays[i]);
        //    }
        //    long num3 = (long)numArray[0];
        //    for (i = 0; i < 12; i++)
        //    {
        //        int num4 = Convert.ToInt16(strArrays4[i]) - Convert.ToInt16(num3 - (long)1);
        //        if (num4 <= 0)
        //        {
        //            num4 += 12;
        //        }
        //        numArray1[i] = num4;
        //    }
        //    for (int j = 1; j <= 9; j++)
        //    {
        //        num += (long)1;
        //        long num5 = (long)0;
        //        if (j == 1)
        //        {
        //            num5 = (long)5;
        //        }
        //        if (j == 2)
        //        {
        //            num5 = (long)4;
        //        }
        //        if (j == 3)
        //        {
        //            num5 = (long)9;
        //        }
        //        if (j == 4)
        //        {
        //            num5 = (long)8;
        //        }
        //        if (j == 5)
        //        {
        //            num5 = (long)6;
        //        }
        //        if (j == 6)
        //        {
        //            num5 = (long)7;
        //        }
        //        if (j == 7)
        //        {
        //            num5 = (long)3;
        //        }
        //        if (j == 8)
        //        {
        //            num5 = (long)1;
        //        }
        //        if (j == 9)
        //        {
        //            num5 = (long)2;
        //        }
        //        KundliMappingVO kundliMappingVO = new KundliMappingVO()
        //        {
        //            Kundliid = AstroGlobal.ActiveID,
        //            Sno = (long)(j - 1),
        //            Planet = Convert.ToInt32(num5),
        //            House = Convert.ToInt32(numArray1[j]),
        //            PlanetName = kundliBLL.findplanet(kundliMappingVO.Planet).Planetname,
        //            PlanetNameEnglish = kundliBLL.findplanet(kundliMappingVO.Planet).PlanetnameEnglish,
        //            PlanetNameHindi = kundliBLL.findplanet(kundliMappingVO.Planet).PlanetnameHindi,
        //            Rashi = Convert.ToInt32(numArray[j])
        //        };
        //        kundliMappingVOs.Add(kundliMappingVO);
        //    }
        //    kundliBLL.Process_Kundali_Planet_GoodBad(ref kundliMappingVOs);
        //    return kundliMappingVOs;
        //}

        public KundliVO map_persKV(string Online_Result, string name, string city, string dd, string mm, string yy, string hh, string min, string ss, string username, string lon, string lat, string tz, bool paid, string lang, bool showref, bool male, string domain, string file_prefix, string vcn_prefix, string source, string headertitle, string product, string wdd, string wmm, string wyy, short rotate)
        {
            char chr;
            int num;
            KundliVO kundliVO = new KundliVO();
            string str = "";
            string str1 = "";
            kundliVO.Online_Result = Online_Result;
            List<KPRashiVO> kPRashiVOs = new List<KPRashiVO>();
            kundliVO.Rotate = rotate;
            string[] strArrays = new string[] { dd, "/", mm, "/", yy };
            string str2 = string.Concat(strArrays);
            strArrays = new string[] { str2.ToString(), " ", hh, ":", min, ":", ss };
            string.Concat(strArrays);
            strArrays = new string[] { hh, ":", min, ":", ss };
            string str3 = string.Concat(strArrays);
            strArrays = new string[] { "Aries", "Taurus", "Gemini", "Cancer", "Leo", "Virgo", "Libra", "Scorpio", "Sagittarius", "Capricorn", "Aquarius", "Pisces" };
            string[] strArrays1 = strArrays;
            KundliBLL kundliBLL = new KundliBLL();
            kundliVO.DD = dd;
            kundliVO.MM = mm;
            kundliVO.YY = yy;
            kundliVO.WDD = wdd;
            kundliVO.WMM = wmm;
            kundliVO.WYY = wyy;
            kundliVO.HH = hh;
            kundliVO.MIN = min;
            kundliVO.SS = "0";
            kundliBLL.janam_greh(str2, str3, ref str, ref str1);
            kundliVO.JanamDin = (
                from Map in this.pbl.GetAllPlanets()
                where Map.Planetname == str
                select Map).FirstOrDefault<PlanetVO>().PlanetnameEnglish;
            kundliVO.JanamSamay = (
                from Map in this.pbl.GetAllPlanets()
                where Map.Planetname == str1
                select Map).FirstOrDefault<PlanetVO>().PlanetnameEnglish;
            kundliVO.Machine = "";
            char[] chrArray = new char[] { '/' };
            short num1 = Convert.ToInt16(str2.Split(chrArray)[2]);
            chrArray = new char[] { '/' };
            short num2 = Convert.ToInt16(str2.Split(chrArray)[1]);
            chrArray = new char[] { '/' };
            DateTime dateTime = new DateTime(num1, num2, Convert.ToInt16(str2.Split(chrArray)[0]));
            chrArray = new char[] { '/' };
            short num3 = Convert.ToInt16(str2.Split(chrArray)[2]);
            chrArray = new char[] { '/' };
            short num4 = Convert.ToInt16(str2.Split(chrArray)[1]);
            chrArray = new char[] { '/' };
            short num5 = Convert.ToInt16(str2.Split(chrArray)[0]);
            chrArray = new char[] { ':' };
            short num6 = Convert.ToInt16(str3.Split(chrArray)[0]);
            chrArray = new char[] { ':' };
            DateTime dateTime1 = new DateTime(num3, num4, num5, num6, Convert.ToInt16(str3.Split(chrArray)[1]), 0);
            lat = lat.Replace(':', '.');
            lon = lon.Replace(':', '.');
            kundliVO.ShowRef = showref;
            kundliVO.Dob = dateTime;
            kundliVO.Name = name;
            kundliVO.Placeofbirth = city;
            kundliVO.Username = username;
            kundliVO.Tob = dateTime1;
            kundliVO.Lat = Convert.ToDouble(lat);
            kundliVO.Lon = Convert.ToDouble(lon);
            kundliVO.Language = lang.ToLower();
            kundliVO.Paid = paid;
            kundliVO.Male = male;
            kundliVO.TimeZone = Convert.ToDouble(tz);
            kundliVO.Remarks = "";
            kundliVO.EntryTime = DateTime.Now;
            kundliVO.Source = source;
            kundliVO.VCN_Prefix = vcn_prefix;
            kundliVO.File_Prefix = file_prefix;
            kundliVO.Domain = domain;
            kundliVO.HeaderTitle = headertitle;
            kundliVO.Product = product;
            DateTime dob = kundliVO.Dob;
            DateTime now = DateTime.Now;
            kundliVO.Current_Age = Convert.ToInt16(this.CalculateAgeCorrect(dob, now.Date));
            chrArray = new char[] { '-' };
            string[] strArrays2 = Online_Result.Split(chrArray);
            kPRashiVOs = (new KPBLL()).Fill_Rashi();
            string str4 = strArrays2[3];
            chrArray = new char[] { '#' };
            kundliVO.Nak = Convert.ToInt64(str4.Split(chrArray)[1]);
            string str5 = strArrays2[3];
            chrArray = new char[] { '#' };
            kundliVO.Charan = Convert.ToInt64(str5.Split(chrArray)[2]);
            chrArray = new char[] { '-' };
            string str6 = Online_Result.Split(chrArray)[0];
            chrArray = new char[] { '#' };
            kundliVO.Lagna = (long)Convert.ToInt32(str6.Split(chrArray)[0].ToString());
            string str7 = strArrays2[3];
            chrArray = new char[] { '#' };
            kundliVO.Janam_rashi = strArrays1[Convert.ToInt32(str7.Split(chrArray)[0]) - 1];
            chrArray = new char[] { '-' };
            string str8 = Online_Result.Split(chrArray)[0];
            chrArray = new char[] { '#' };
            kundliVO.Janam_Lagna = str8.Split(chrArray)[0].ToString();
            kundliVO.Ratna = (
                from Map in kPRashiVOs
                where Map.Rashi == Convert.ToInt16(strArrays2[3].Split(new char[] { '#' })[0])
                select Map).SingleOrDefault<KPRashiVO>().Ratna;
            kundliVO.Upratna = (
                from Map in kPRashiVOs
                where Map.Rashi == Convert.ToInt16(strArrays2[3].Split(new char[] { '#' })[0])
                select Map).SingleOrDefault<KPRashiVO>().Upratna;
            string str9 = "";
            string str10 = "";
            string str11 = "";
            string str12 = "";
            string str13 = string.Concat(kundliVO.DD, kundliVO.MM, kundliVO.YY);
            string str14 = "0";
            for (int i = 0; i < str13.Trim().Length; i++)
            {
                if (i == 2)
                {
                    str9 = str14;
                    if (Convert.ToInt32(str14) >= 10)
                    {
                        chr = str14[0];
                        int num7 = Convert.ToInt32(chr.ToString());
                        chr = str14[1];
                        num = num7 + Convert.ToInt32(chr.ToString());
                        str9 = num.ToString();
                    }
                }
                int num8 = Convert.ToInt32(str14);
                chr = str13[i];
                num = num8 + Convert.ToInt32(chr.ToString());
                str14 = num.ToString();
            }
            int num9 = 0;
            while (Convert.ToInt32(str14) > 10)
            {
                for (int j = 0; j < str14.Trim().Length; j++)
                {
                    chr = str14[j];
                    num9 += Convert.ToInt32(chr.ToString());
                }
                str14 = num9.ToString();
                num9 = 0;
            }
            if (str14 == "10")
            {
                str14 = "1";
            }
            str10 = str14;
            string str15 = str14;
            if (str15 != null)
            {
                switch (str15)
                {
                    case "1":
                        {
                            str12 = "Sunday";
                            break;
                        }
                    case "2":
                        {
                            str12 = "Monday";
                            break;
                        }
                    case "3":
                        {
                            str12 = "Thursday";
                            break;
                        }
                    case "4":
                        {
                            str12 = "Sunday";
                            break;
                        }
                    case "5":
                        {
                            str12 = "Wednesday";
                            break;
                        }
                    case "6":
                        {
                            str12 = "Friday";
                            break;
                        }
                    case "7":
                        {
                            str12 = "Monday";
                            break;
                        }
                    case "8":
                        {
                            str12 = "Saturday";
                            break;
                        }
                    case "9":
                        {
                            str12 = "Tuesday";
                            break;
                        }
                }
            }
            if (Convert.ToInt32(str10) != Convert.ToInt32(str9))
            {
                str10 = string.Concat(str10, "   ", str9);
                str15 = str9;
                if (str15 != null)
                {
                    switch (str15)
                    {
                        case "1":
                            {
                                str11 = string.Concat(str11, "Sunday");
                                break;
                            }
                        case "2":
                            {
                                str11 = string.Concat(str11, "Monday");
                                break;
                            }
                        case "3":
                            {
                                str11 = string.Concat(str11, "Thursday");
                                break;
                            }
                        case "4":
                            {
                                str11 = string.Concat(str11, "Sunday");
                                break;
                            }
                        case "5":
                            {
                                str11 = string.Concat(str11, "Wednesday");
                                break;
                            }
                        case "6":
                            {
                                str11 = string.Concat(str11, "Friday");
                                break;
                            }
                        case "7":
                            {
                                str11 = string.Concat(str11, "Monday");
                                break;
                            }
                        case "8":
                            {
                                str11 = string.Concat(str11, "Saturday");
                                break;
                            }
                        case "9":
                            {
                                str11 = string.Concat(str11, "Tuesday");
                                break;
                            }
                    }
                }
            }
            kundliVO.Lucky_number = str10;
            kundliVO.Lucky_day1 = str12;
            kundliVO.Lucky_day2 = "";
            if (str11 != str12)
            {
                kundliVO.Lucky_day2 = str11;
            }
            List<KPDashaVO> kPDashaVOs = new List<KPDashaVO>();
            List<KPDashaVO> antarDasha = new List<KPDashaVO>();
            List<KPDashaVO> prayatntarDasha = new List<KPDashaVO>();
            KPBLL kPBLL = new KPBLL();
            List<KPPlanetsVO> kPPlanetsVOs = kPBLL.Fill_Planets();
            List<KPPlanetMappingVO> kPPlanetMappingVOs = new List<KPPlanetMappingVO>();
            List<KPHouseMappingVO> kPHouseMappingVOs = new List<KPHouseMappingVO>();
            ProductSettingsVO productSettingsVO = new ProductSettingsVO();
            kPBLL.Process_Planet_Lagan(Online_Result, ref kPPlanetMappingVOs, ref kPHouseMappingVOs, kundliVO.Rotate, false);
            kPPlanetMappingVOs = kPBLL.Process_KPChart_GoodBad(kPPlanetMappingVOs, kundliVO, productSettingsVO);
            kPDashaVOs = kPBLL.Get_Dasha(kPHouseMappingVOs, kPPlanetMappingVOs, kundliVO, false);
            DateTime date = new DateTime();
            date = DateTime.Now.Date;
            if (DateTime.Now.Date < kundliVO.Dob)
            {
                date = kundliVO.Dob;
            }
            short planet = (
                from Map in kPDashaVOs
                where (date < Map.StartDate ? false : date <= Map.EndDate)
                select Map).SingleOrDefault<KPDashaVO>().Planet;
            DateTime startDate = (
                from Map in kPDashaVOs
                where Map.Planet == planet
                select Map).SingleOrDefault<KPDashaVO>().StartDate;
            DateTime endDate = (
                from Map in kPDashaVOs
                where Map.Planet == planet
                select Map).SingleOrDefault<KPDashaVO>().EndDate;
            antarDasha = kPBLL.Get_Antar_Dasha(startDate, endDate, planet, kPPlanetMappingVOs, false);
            short planet1 = (
                from Map in antarDasha
                where (date < Map.StartDate ? false : date <= Map.EndDate)
                select Map).SingleOrDefault<KPDashaVO>().Planet;
            DateTime startDate1 = (
                from Map in antarDasha
                where Map.Planet == planet1
                select Map).SingleOrDefault<KPDashaVO>().StartDate;
            DateTime endDate1 = (
                from Map in antarDasha
                where Map.Planet == planet1
                select Map).SingleOrDefault<KPDashaVO>().EndDate;
            prayatntarDasha = kPBLL.Get_Prayatntar_Dasha(antarDasha, startDate1, endDate1, planet, planet1, kPPlanetMappingVOs, false);
            short planet2 = (
                from Map in prayatntarDasha
                where (date < Map.StartDate ? false : date <= Map.EndDate)
                select Map).SingleOrDefault<KPDashaVO>().Planet;
            DateTime startDate2 = (
                from Map in prayatntarDasha
                where Map.Planet == planet2
                select Map).SingleOrDefault<KPDashaVO>().StartDate;
            DateTime endDate2 = (
                from Map in prayatntarDasha
                where Map.Planet == planet2
                select Map).SingleOrDefault<KPDashaVO>().EndDate;
            kundliVO.Dasha_Visho = kPPlanetsVOs[planet - 1].English;
            kundliVO.Antar_Visho = kPPlanetsVOs[planet1 - 1].English;
            kundliVO.Pryantar_Visho = kPPlanetsVOs[planet2 - 1].English;
            List<Years35VO> years35VOs = (new Years35BLL()).Get35Years(kundliVO.JanamSamay);
            short num10 = 0;
            DateTime dateTime2 = new DateTime(Convert.ToInt16(kundliVO.YY), Convert.ToInt16(kundliVO.MM), Convert.ToInt16(kundliVO.DD));
            now = DateTime.Now;
            short num11 = Convert.ToInt16(now.ToString("yyyy"));
            now = DateTime.Now;
            short num12 = Convert.ToInt16(now.ToString("MM"));
            now = DateTime.Now;
            DateTime dateTime3 = new DateTime(num11, num12, Convert.ToInt16(now.ToString("dd")));
            num10 = Convert.ToInt16(this.CalculateAgeCorrect(dateTime2, dateTime3) + 1);
            if (num10 <= 0)
            {
                num10 = 1;
            }
            if (num10 > 0)
            {
                kundliVO.Dasha35 = (
                    from Map in years35VOs
                    where Map.Years == (long)num10
                    select Map).FirstOrDefault<Years35VO>().Planet;
                kundliVO.Antar35 = (
                    from Map1 in years35VOs
                    where Map1.Years == (long)num10
                    select Map1).FirstOrDefault<Years35VO>().Period;
            }
            List<short> nums = new List<short>();
            //string str16 = "";
            kundliVO.Ratna = "";
            kundliVO.Upratna = "";
            foreach (KPPlanetMappingVO kPPlanetMappingVO in kPPlanetMappingVOs)
            {
                if (!kPPlanetMappingVO.isbad)
                {
                    string signiString = kPBLL.Get_Signi_String(kPPlanetMappingVO.Planet, kPPlanetMappingVOs, false);
                    chrArray = new char[] { ' ' };
                    string[] strArrays3 = signiString.Split(chrArray);
                    if ((strArrays3.Contains<string>("6") || strArrays3.Contains<string>("8") ? false : !strArrays3.Contains<string>("12")))
                    {
                        nums.Add(kPPlanetMappingVO.Planet);
                    }
                    //else
                    //{
                    //    str16 = "";
                    //}
                }
            }
            kundliVO.Ratna = "";
            kundliVO.Upratna = "";
            kundliVO.RatnaCode = "";
            if (nums.Count >= 1)
            {
                foreach (short num13 in nums)
                {
                    KPPlanetsVO kPPlanetsVO = (
                        from Map in kPPlanetsVOs
                        where Map.Planet == num13
                        select Map).SingleOrDefault<KPPlanetsVO>();
                    KundliVO kundliVO1 = kundliVO;
                    kundliVO1.Ratna = string.Concat(kundliVO1.Ratna, kPPlanetsVO.Ratna, ",");
                    KundliVO kundliVO2 = kundliVO;
                    kundliVO2.Upratna = string.Concat(kundliVO2.Upratna, kPPlanetsVO.Upratna, ",");
                    KundliVO kundliVO3 = kundliVO;
                    string ratnaCode = kundliVO3.RatnaCode;
                    short num14 = num13;
                    kundliVO3.RatnaCode = string.Concat(ratnaCode, num14.ToString(), ",");
                }
                string ratna = kundliVO.Ratna;
                chrArray = new char[] { ',' };
                kundliVO.Ratna = ratna.TrimEnd(chrArray);
                string upratna = kundliVO.Upratna;
                chrArray = new char[] { ',' };
                kundliVO.Upratna = upratna.TrimEnd(chrArray);
                string ratnaCode1 = kundliVO.RatnaCode;
                chrArray = new char[] { ',' };
                kundliVO.RatnaCode = ratnaCode1.TrimEnd(chrArray);
            }
            kundliVO.Base_Lagna = kundliVO.Lagna;
            return kundliVO;
        }

        //public string MatchMaking(KundliVO persKVMale, KundliVO persKVFemale)
        //{
        //    string str = "";
        //    str = string.Concat(str, "\r\n\r\n", this.GetLifePrediction(persKVMale, new List<short>(), new List<short>(), true, false, "Match Making"));
        //    str = string.Concat(str, "\r\n\r\n", this.GetLifePrediction(persKVFemale, new List<short>(), new List<short>(), true, false, "Match Making"));
        //    str = string.Concat(str, "\r\n\r\n", this.GetCodeLang("upaymatchmaking", "Hindi", true, false).ToString());
        //    return str;
        //}

        //public string matchmaking_score(KundliVO BoypersKV, KundliVO GirlpersKV, List<KundliMappingVO> lkmv, List<KundliMappingVO> lkmv_girl)
        //{
        //    Exception exception;
        //    string str = "";
        //    List<RulesVO> rulesVOs = new List<RulesVO>();
        //    List<RulesVO> list = new List<RulesVO>();
        //    rulesVOs = this.generate_final_lrvgen(BoypersKV, lkmv, false, new List<short>(), BoypersKV.Language, "", false, false).ToList<RulesVO>();
        //    list = this.generate_final_lrvgen(GirlpersKV, lkmv_girl, false, new List<short>(), GirlpersKV.Language, "", false, false).ToList<RulesVO>();
        //    short num = 0;
        //    short num1 = 0;
        //    try
        //    {
        //        AstroGlobal.MM_married = Convert.ToInt16((
        //            from Map in rulesVOs
        //            where (!Map.Marriedlife ? false : Map.Isbad)
        //            select Map).Count<RulesVO>() * Convert.ToInt16(100) / Convert.ToInt16((
        //            from Map in rulesVOs
        //            where Map.Marriedlife
        //            select Map).Count<RulesVO>()));
        //        AstroGlobal.MM_profession = Convert.ToInt16((
        //            from Map in rulesVOs
        //            where (Map.Occupation || Map.Profit ? Map.Isbad : false)
        //            select Map).Count<RulesVO>() * Convert.ToInt16(100) / Convert.ToInt16((
        //            from Map in rulesVOs
        //            where Map.Occupation
        //            select Map).Count<RulesVO>()));
        //        AstroGlobal.MM_child = Convert.ToInt16((
        //            from Map in rulesVOs
        //            where (!Map.Santan ? false : Map.Isbad)
        //            select Map).Count<RulesVO>() * Convert.ToInt16(100) / Convert.ToInt16((
        //            from Map in rulesVOs
        //            where Map.Santan
        //            select Map).Count<RulesVO>()));
        //        AstroGlobal.MM_health = Convert.ToInt16((
        //            from Map in rulesVOs
        //            where (!Map.Disease ? false : Map.Isbad)
        //            select Map).Count<RulesVO>() * Convert.ToInt16(100) / Convert.ToInt16((
        //            from Map in rulesVOs
        //            where Map.Disease
        //            select Map).Count<RulesVO>()));
        //        AstroGlobal.MM_love = Convert.ToInt16((
        //            from Map in rulesVOs
        //            where (!Map.Love_affair ? false : Map.Isbad)
        //            select Map).Count<RulesVO>() * Convert.ToInt16(100) / Convert.ToInt16((
        //            from Map in rulesVOs
        //            where Map.Love_affair
        //            select Map).Count<RulesVO>()));
        //        AstroGlobal.MM_married = Convert.ToInt16((double)AstroGlobal.MM_married * 1.3);
        //        AstroGlobal.MM_child = Convert.ToInt16((double)AstroGlobal.MM_child * 1.1);
        //        AstroGlobal.MM_health = Convert.ToInt16((double)AstroGlobal.MM_health * 1.1);
        //    }
        //    catch (Exception exception1)
        //    {
        //        exception = exception1;
        //    }
        //    try
        //    {
        //        AstroGlobal.MF_married = Convert.ToInt16((
        //            from Map in rulesVOs
        //            where (!Map.Marriedlife ? false : Map.Isbad)
        //            select Map).Count<RulesVO>() * Convert.ToInt16(100) / Convert.ToInt16((
        //            from Map in rulesVOs
        //            where Map.Marriedlife
        //            select Map).Count<RulesVO>()));
        //        AstroGlobal.MF_profession = Convert.ToInt16((
        //            from Map in rulesVOs
        //            where (Map.Occupation || Map.Profit ? Map.Isbad : false)
        //            select Map).Count<RulesVO>() * Convert.ToInt16(100) / Convert.ToInt16((
        //            from Map in rulesVOs
        //            where Map.Occupation
        //            select Map).Count<RulesVO>()));
        //        AstroGlobal.MF_child = Convert.ToInt16((
        //            from Map in rulesVOs
        //            where (!Map.Santan ? false : Map.Isbad)
        //            select Map).Count<RulesVO>() * Convert.ToInt16(100) / Convert.ToInt16((
        //            from Map in rulesVOs
        //            where Map.Santan
        //            select Map).Count<RulesVO>()));
        //        AstroGlobal.MF_health = Convert.ToInt16((
        //            from Map in rulesVOs
        //            where (!Map.Disease ? false : Map.Isbad)
        //            select Map).Count<RulesVO>() * Convert.ToInt16(100) / Convert.ToInt16((
        //            from Map in rulesVOs
        //            where Map.Disease
        //            select Map).Count<RulesVO>()));
        //        AstroGlobal.MF_love = Convert.ToInt16((
        //            from Map in rulesVOs
        //            where (!Map.Love_affair ? false : Map.Isbad)
        //            select Map).Count<RulesVO>() * Convert.ToInt16(100) / Convert.ToInt16((
        //            from Map in rulesVOs
        //            where Map.Love_affair
        //            select Map).Count<RulesVO>()));
        //        AstroGlobal.MF_married = Convert.ToInt16((double)AstroGlobal.MF_married * 0.25);
        //        AstroGlobal.MF_profession = Convert.ToInt16((double)AstroGlobal.MF_profession * 0.25);
        //        AstroGlobal.MM_child = Convert.ToInt16((double)AstroGlobal.MM_child * 1.25);
        //        AstroGlobal.MF_health = Convert.ToInt16((double)AstroGlobal.MF_health * 0.5);
        //        AstroGlobal.MF_love = Convert.ToInt16((double)AstroGlobal.MF_love * 1.25);
        //    }
        //    catch (Exception exception2)
        //    {
        //        exception = exception2;
        //    }
        //    short num2 = 0;
        //    num = Convert.ToInt16((int)(AstroGlobal.MM_married + AstroGlobal.MM_profession + AstroGlobal.MM_child + AstroGlobal.MM_health + AstroGlobal.MM_love));
        //    num1 = Convert.ToInt16((int)(AstroGlobal.MF_married + AstroGlobal.MF_profession + AstroGlobal.MF_child + AstroGlobal.MF_health + AstroGlobal.MF_love));
        //    num2 = Convert.ToInt16((num + num1) / 12);
        //    if (Convert.ToInt16(num2) >= 85)
        //    {
        //        str = "1";
        //    }
        //    else if (!(Convert.ToInt16(num2) < 50 ? true : Convert.ToInt16(num2) >= 85))
        //    {
        //        str = "2";
        //    }
        //    else if (!(Convert.ToInt16(num2) < 35 ? true : Convert.ToInt16(num2) >= 50))
        //    {
        //        str = "3";
        //    }
        //    else if (!(Convert.ToInt16(num2) < 20 ? true : Convert.ToInt16(num2) >= 35))
        //    {
        //        str = "4";
        //    }
        //    else if (Convert.ToInt16(num2) < 20)
        //    {
        //        str = "5";
        //    }
        //    return str;
        //}

        //public string OldLifePrediction(KundliVO persKV, List<KundliMappingVO> lkmv, List<KundliMappingVO> lkmv_lagna, string ruletype, bool showref, bool male, string lang)
        //{
        //    bool flag = false;
        //    List<long> nums = new List<long>();
        //    PlanetBLL planetBLL = new PlanetBLL();
        //    RuleBLL ruleBLL = new RuleBLL();
        //    List<Life35VO> life35VOs = new List<Life35VO>();
        //    string str = "";
        //    List<RulesVO> rulesVOs = new List<RulesVO>();
        //    KundliBLL kundliBLL = new KundliBLL();
        //    life35VOs = kundliBLL.GetLife35(persKV.JanamSamay);
        //    string predText = "";
        //    List<long> nums1 = new List<long>();
        //    foreach (Life35VO life35VO in life35VOs)
        //    {
        //        flag = true;
        //        List<long> nums2 = new List<long>();
        //        string str1 = "";
        //        KundliMappingVO kundliMappingVO = new KundliMappingVO();
        //        kundliMappingVO = (
        //            from Map in lkmv
        //            where Map.PlanetName == life35VO.Planet
        //            select Map).SingleOrDefault<KundliMappingVO>();
        //        List<RulesVO> list = new List<RulesVO>();
        //        list = (
        //            from Map in kundliBLL.GetAdvancePredictions(lkmv, kundliMappingVO.Planet, 0)
        //            where Map.Isbad == kundliMappingVO.IsBad
        //            select Map).ToList<RulesVO>();
        //        if (kundliMappingVO.Planet == 8)
        //        {
        //            if (Convert.ToInt16((
        //                from Map in lkmv
        //                where Map.House == kundliMappingVO.House
        //                select Map).Count<KundliMappingVO>()) == 1)
        //            {
        //                short num = 0;
        //                if (kundliMappingVO.House == 1)
        //                {
        //                    num = 5;
        //                }
        //                if (kundliMappingVO.House == 2)
        //                {
        //                    num = 6;
        //                }
        //                if (kundliMappingVO.House == 3)
        //                {
        //                    num = 9;
        //                }
        //                if (kundliMappingVO.House == 4)
        //                {
        //                    num = 4;
        //                }
        //                if (kundliMappingVO.House == 5)
        //                {
        //                    num = 6;
        //                }
        //                if (kundliMappingVO.House == 6)
        //                {
        //                    num = 2;
        //                }
        //                if (kundliMappingVO.House == 7)
        //                {
        //                    num = 7;
        //                }
        //                if (kundliMappingVO.House == 8)
        //                {
        //                    num = 3;
        //                }
        //                if (kundliMappingVO.House == 9)
        //                {
        //                    num = 6;
        //                }
        //                if (kundliMappingVO.House == 10)
        //                {
        //                    num = 3;
        //                }
        //                if (kundliMappingVO.House == 11)
        //                {
        //                    num = 6;
        //                }
        //                if (kundliMappingVO.House == 12)
        //                {
        //                    num = 1;
        //                }
        //                bool isBad = (
        //                    from Map in lkmv
        //                    where Map.Planet == num
        //                    select Map).SingleOrDefault<KundliMappingVO>().IsBad;
        //                list.AddRange((
        //                    from Map in kundliBLL.GetAdvancePredictions(lkmv, num, 0)
        //                    where Map.Isbad == isBad
        //                    select Map).ToList<RulesVO>());
        //            }
        //        }
        //        Years35BLL years35BLL = new Years35BLL();
        //        List<Years35VO> years35VOs = years35BLL.Get35Years(persKV.JanamSamay);
        //        long umra = years35BLL.GetUmra(kundliMappingVO.PlanetName) - (long)1;
        //        long num1 = Convert.ToInt64((
        //            from Map in years35VOs
        //            where Map.Planet == kundliMappingVO.PlanetName
        //            select Map).Min<Years35VO>((Years35VO Map) => Map.Years));
        //        str1 = string.Concat(str1, this.lrs.getPrabhav(num1, umra, lang).ToString());
        //        if (!(lang.ToLower() == "gujarati" ? false : !(lang.ToLower() == "punjabi")))
        //        {
        //            list = (
        //                from Map in kundliBLL.GetAdvancePredictions(lkmv, kundliMappingVO.Planet, 0)
        //                where (Map.Isbad != kundliMappingVO.IsBad ? false : (Map.RuleType == "langsplupay2" || Map.RuleType == "pmegeneral" || Map.RuleType == "general" || Map.RuleType == "langgeneral" || Map.RuleType == "triangle" || Map.RuleType == "gatha" || Map.RuleType == "langgatha" || Map.RuleType == "langsunheri" ? true : (Map.Reference != "Indian Astrology" ? false : Map.Ruleformula.Contains("&"))))
        //                select Map).ToList<RulesVO>();
        //            list.AddRange((
        //                from Map in kundliBLL.GetAdvancePredictions(lkmv, kundliMappingVO.Planet, 0)
        //                where (Map.RuleType == "shadi" || Map.RuleType == "triangle" ? true : Map.RuleType == "any")
        //                select Map).ToList<RulesVO>());
        //        }
        //        else if (!(lang.ToLower() == "hindi"))
        //        {
        //            list = (
        //                from Map in kundliBLL.GetAdvancePredictions(lkmv, kundliMappingVO.Planet, 0)
        //                where (Map.Isbad != kundliMappingVO.IsBad || Map.Mainplanet != kundliMappingVO.Planet ? false : (Map.RuleType == "pmegeneral" || Map.RuleType == "any" || Map.RuleType == "general" || Map.RuleType == "triangle" || Map.RuleType == "gatha" ? true : (Map.Reference != "Indian Astrology" ? false : Map.Ruleformula.Contains("&"))))
        //                select Map).ToList<RulesVO>();
        //            list.AddRange((
        //                from Map in kundliBLL.GetAdvancePredictions(lkmv, kundliMappingVO.Planet, 0)
        //                where (Map.Mainplanet != kundliMappingVO.Planet ? false : (Map.RuleType == "gany" || Map.RuleType == "shadi" || Map.RuleType == "triangle" ? true : Map.RuleType == "any"))
        //                select Map).ToList<RulesVO>());
        //        }
        //        else
        //        {
        //            list = (
        //                from Map in kundliBLL.GetAdvancePredictions(lkmv, kundliMappingVO.Planet, 0)
        //                where (Map.Isbad != kundliMappingVO.IsBad || Map.Mainplanet != kundliMappingVO.Planet ? false : (Map.RuleType == "any" || Map.RuleType == "general" || Map.RuleType == "triangle" || Map.RuleType == "gatha" ? true : (Map.Reference != "Indian Astrology" ? false : Map.Ruleformula.Contains("&"))))
        //                select Map).ToList<RulesVO>();
        //            list.AddRange((
        //                from Map in kundliBLL.GetAdvancePredictions(lkmv, kundliMappingVO.Planet, 0)
        //                where (Map.Mainplanet != kundliMappingVO.Planet ? false : (Map.RuleType == "gany" || Map.RuleType == "shadi" || Map.RuleType == "triangle" ? true : Map.RuleType == "any"))
        //                select Map).ToList<RulesVO>());
        //        }
        //        rulesVOs = list;
        //        RuleDAO ruleDAO = new RuleDAO();
        //        string ruleformula = "";
        //        if (persKV.Male)
        //        {
        //            rulesVOs = (
        //                from Map in rulesVOs
        //                where (Map.Common ? true : Map.Male)
        //                select Map).ToList<RulesVO>();
        //        }
        //        if (!persKV.Male)
        //        {
        //            rulesVOs = (
        //                from Map in rulesVOs
        //                where (Map.Common ? true : Map.Female)
        //                select Map).ToList<RulesVO>();
        //        }
        //        foreach (RulesVO rulesVO in
        //            from Map in rulesVOs
        //            orderby Map.Ruleformula
        //            orderby Map.Upay
        //            select Map)
        //        {
        //            if (flag)
        //            {
        //                str = string.Concat(str, "\r\n", this.lrs.result(lang, str1), "\r\n");
        //            }
        //            flag = false;
        //            if (!nums1.Exists((long Map) => Map == rulesVO.Sno))
        //            {
        //                predText = this.Get_Pred_Text(rulesVO.Sno, persKV.Language, male, true, showref, false, true, true, false, persKV);
        //                if (ruleformula == rulesVO.Ruleformula)
        //                {
        //                    predText = string.Concat(predText, "\r\n");
        //                }
        //                str = string.Concat(str, predText);
        //                ruleformula = rulesVO.Ruleformula;
        //                nums1.Add(rulesVO.Sno);
        //            }
        //        }
        //    }
        //    return str;
        //}

        //public string rin_pitri(KundliVO persKV, List<KundliMappingVO> lkmv)
        //{
        //    string str = "";
        //    List<RulesVO> list = (
        //        from Rules in (new KundliBLL()).GetAdvancePredictions(lkmv, 0, 0)
        //        where Rules.RuleType == "rinpitri"
        //        select Rules).ToList<RulesVO>();
        //    if (list.Count > 0)
        //    {
        //        str = string.Concat(str, "\r\n", this.GetCodeLang("pitrrinn", persKV.Language, persKV.Paid, false), "\r\n\r\n");
        //        foreach (RulesVO rulesVO in list)
        //        {
        //            str = string.Concat(str, "\r\n\r\n", this.Get_Pred_Text(rulesVO.Sno, persKV.Language, persKV.Male, true, persKV.ShowRef, false, persKV.Paid, false, false, persKV));
        //        }
        //    }
        //    return str;
        //}

        //public string SoyeGrehUpay(List<KundliMappingVO> lkmv, string lang)
        //{
        //    string str = "";
        //    RuleBLL ruleBLL = new RuleBLL();
        //    bool flag = true;
        //    PredictionBLL predictionBLL = new PredictionBLL();
        //    List<SoyeGrehUpayeVO> allSoyeGrehUpaye = (new PlanetBLL()).GetAllSoyeGrehUpaye();
        //    lkmv = ruleBLL.CalcSoyeGreh(lkmv);
        //    IEnumerable<KundliMappingVO> kundliMappingVOs =
        //        from L in lkmv
        //        where L.Soya
        //        select L;
        //    if (kundliMappingVOs.Count<KundliMappingVO>() > 0)
        //    {
        //        str = string.Concat(str, predictionBLL.GetCodeLang("Sleeping", lang, flag, false).ToString(), "\r\n");
        //        foreach (KundliMappingVO kundliMappingVO in kundliMappingVOs)
        //        {
        //            if (lang == "hindi")
        //            {
        //                str = string.Concat(str, (
        //                    from upaye in allSoyeGrehUpaye
        //                    where upaye.Planet == kundliMappingVO.Planet
        //                    select upaye.Details).SingleOrDefault<string>(), "\r\n");
        //            }
        //            else if (lang == "english")
        //            {
        //                str = string.Concat(str, (
        //                    from upaye in allSoyeGrehUpaye
        //                    where upaye.Planet == kundliMappingVO.Planet
        //                    select upaye.Eng_Details).SingleOrDefault<string>(), "\r\n");
        //            }
        //            else if (lang == "tamil")
        //            {
        //                str = string.Concat(str, (
        //                    from upaye in allSoyeGrehUpaye
        //                    where upaye.Planet == kundliMappingVO.Planet
        //                    select upaye.Tamil_Details).SingleOrDefault<string>(), "\r\n");
        //            }
        //            else if (lang == "telugu")
        //            {
        //                str = string.Concat(str, (
        //                    from upaye in allSoyeGrehUpaye
        //                    where upaye.Planet == kundliMappingVO.Planet
        //                    select upaye.Telugu_Details).SingleOrDefault<string>(), "\r\n");
        //            }
        //            else if (lang == "bangla")
        //            {
        //                str = string.Concat(str, (
        //                    from upaye in allSoyeGrehUpaye
        //                    where upaye.Planet == kundliMappingVO.Planet
        //                    select upaye.Bangla_Details).SingleOrDefault<string>(), "\r\n");
        //            }
        //            else if (lang == "kannada")
        //            {
        //                str = string.Concat(str, (
        //                    from upaye in allSoyeGrehUpaye
        //                    where upaye.Planet == kundliMappingVO.Planet
        //                    select upaye.Kannada_Details).SingleOrDefault<string>(), "\r\n");
        //            }
        //            else if (lang == "marathi")
        //            {
        //                str = string.Concat(str, (
        //                    from upaye in allSoyeGrehUpaye
        //                    where upaye.Planet == kundliMappingVO.Planet
        //                    select upaye.Marathi_Details).SingleOrDefault<string>(), "\r\n");
        //            }
        //            else if (lang == "punjabi")
        //            {
        //                str = string.Concat(str, (
        //                    from upaye in allSoyeGrehUpaye
        //                    where upaye.Planet == kundliMappingVO.Planet
        //                    select upaye.Punjabi_Details).SingleOrDefault<string>(), "\r\n");
        //            }
        //            else if (lang == "gujarati")
        //            {
        //                str = string.Concat(str, (
        //                    from upaye in allSoyeGrehUpaye
        //                    where upaye.Planet == kundliMappingVO.Planet
        //                    select upaye.Gujarati_Details).SingleOrDefault<string>(), "\r\n");
        //            }
        //        }
        //    }
        //    List<string> strs = new List<string>()
        //    {
        //        predictionBLL.GetCodeLang("soyeupay1", lang, flag, false).ToString(),
        //        predictionBLL.GetCodeLang("soyeupay2", lang, flag, false).ToString(),
        //        predictionBLL.GetCodeLang("soyeupay3", lang, flag, false).ToString(),
        //        predictionBLL.GetCodeLang("soyeupay4", lang, flag, false).ToString(),
        //        predictionBLL.GetCodeLang("soyeupay5", lang, flag, false).ToString(),
        //        predictionBLL.GetCodeLang("soyeupay6", lang, flag, false).ToString(),
        //        predictionBLL.GetCodeLang("soyeupay7", lang, flag, false).ToString(),
        //        predictionBLL.GetCodeLang("soyeupay8", lang, flag, false).ToString(),
        //        predictionBLL.GetCodeLang("soyeupay9", lang, flag, false).ToString(),
        //        predictionBLL.GetCodeLang("soyeupay10", lang, flag, false).ToString(),
        //        predictionBLL.GetCodeLang("soyeupay11", lang, flag, false).ToString(),
        //        predictionBLL.GetCodeLang("soyeupay12", lang, flag, false).ToString()
        //    };
        //    List<long> nums = new List<long>();
        //    bool[] soyeBhav = ruleBLL.GetSoyeBhav(lkmv);
        //    if (soyeBhav.Count<bool>() > 0)
        //    {
        //        str = string.Concat(str, predictionBLL.GetCodeLang("sleeping_and_empty", lang, flag, false), "\r\n");
        //        for (int i = 1; i <= 12; i++)
        //        {
        //            if ((!soyeBhav[i - 1] ? false : (
        //                from Map in lkmv
        //                where Map.House == i
        //                select Map).Count<KundliMappingVO>() == 0))
        //            {
        //                str = string.Concat(str, strs[i - 1], "\r\n");
        //            }
        //        }
        //    }
        //    return str;
        //}

        //public string Time_Machine(KundliVO persKV, List<KundliMappingVO> lkmv, List<short> vyears)
        //{
        //    RuleDAO ruleDAO;
        //    string str = null;
        //    List<RulesVO> rulesVOs;
        //    RulesVO rulesVO = null;
        //    YearsVO yearsVO;
        //    RulesVO advanceRuleById = null;
        //    short year2From;
        //    short year2To;
        //    UpayIndex upayIndex;
        //    object obj;
        //    object[] year1From;
        //    bool flag;
        //    bool flag1;
        //    bool flag2;
        //    bool flag3;
        //    bool flag4;
        //    bool flag5;
        //    bool flag6;
        //    bool flag7;
        //    bool flag8;
        //    bool flag9;
        //    bool flag10;
        //    bool flag11;
        //    bool flag12;
        //    bool flag13;
        //    bool flag14;
        //    bool flag15;
        //    bool flag16;
        //    bool flag17;
        //    bool flag18;
        //    bool flag19;
        //    bool flag20;
        //    bool flag21;
        //    bool flag22;
        //    bool flag23;
        //    bool flag24;
        //    bool flag25;
        //    bool flag26;
        //    bool flag27;
        //    bool flag28;
        //    bool flag29;
        //    bool flag30;
        //    bool flag31;
        //    bool flag32;
        //    bool flag33 = false;
        //    long lagna = persKV.Lagna;
        //    long num = (long)0;
        //    PlanetBLL planetBLL = new PlanetBLL();
        //    string str1 = "";
        //    if (persKV.Sub_prodtype == "mobile")
        //    {
        //        flag33 = true;
        //    }
        //    List<short> nums = new List<short>();
        //    List<Life35VO> life35VOs = new List<Life35VO>();
        //    KundliBLL kundliBLL = new KundliBLL();
        //    life35VOs = kundliBLL.GetLife35(persKV.JanamSamay);
        //    bool flag34 = false;
        //    long[] numArray = new long[12];
        //    string onlineResult = persKV.Online_Result;
        //    char[] chrArray = new char[] { '-' };
        //    string str2 = onlineResult.Split(chrArray)[1];
        //    chrArray = new char[] { '#' };
        //    str2.Split(chrArray);
        //    long lagna1 = persKV.Lagna;
        //    for (int i = 0; i < 12; i++)
        //    {
        //        if (lagna1 > (long)12)
        //        {
        //            lagna1 -= (long)12;
        //        }
        //        numArray[i] = lagna1;
        //        lagna1 += (long)1;
        //    }
        //    List<PlanetMAPVO> planetMAPVOs = new List<PlanetMAPVO>();
        //    planetMAPVOs = planetBLL.FillAllPlanets();
        //    List<YearsVO> yearsVOs = new List<YearsVO>();
        //    short num1 = 0;
        //    foreach (Life35VO life35VO in life35VOs)
        //    {
        //        List<string> strs = new List<string>();
        //        List<string> strs1 = new List<string>();
        //        List<long> nums1 = new List<long>();
        //        List<PlanetHouseMappingVO> planetHouseMappingVOs = new List<PlanetHouseMappingVO>();
        //        flag34 = true;
        //        string str3 = "";
        //        KundliMappingVO kundliMappingVO = new KundliMappingVO();
        //        kundliMappingVO = (
        //            from Map in lkmv
        //            where Map.PlanetName == life35VO.Planet
        //            select Map).SingleOrDefault<KundliMappingVO>();
        //        Years35BLL years35BLL = new Years35BLL();
        //        List<Years35VO> years35VOs = years35BLL.Get35Years(persKV.JanamSamay);
        //        AstroDAL astroDAL = new AstroDAL();
        //        long umra = years35BLL.GetUmra(kundliMappingVO.PlanetName) - (long)1;
        //        long num2 = Convert.ToInt64((
        //            from Map in years35VOs
        //            where Map.Planet == kundliMappingVO.PlanetName
        //            select Map).Min<Years35VO>((Years35VO Map) => Map.Years));
        //        str3 = string.Concat(str3, this.lrs.getPrabhav(num2, umra, persKV.Language).ToString());
        //        short num3 = Convert.ToInt16(num2);
        //        short num4 = Convert.ToInt16(num2 + umra);
        //        short num5 = Convert.ToInt16(num2 + (long)35);
        //        short num6 = Convert.ToInt16(num2 + umra + (long)35);
        //        short num7 = Convert.ToInt16(num2 + (long)70);
        //        short num8 = Convert.ToInt16(num2 + umra + (long)70);
        //        planetHouseMappingVOs = (
        //            from Map in planetBLL.GetPakkeGhar()
        //            where Map.Planet == this.findplanet_by_name(life35VO.Planet.ToString()).Sno
        //            select Map).ToList<PlanetHouseMappingVO>();
        //        strs.Add(life35VO.Planet);
        //        foreach (PlanetHouseMappingVO planetHouseMappingVO in planetHouseMappingVOs)
        //        {
        //            if ((
        //                from Map in lkmv
        //                where Map.House == planetHouseMappingVO.House
        //                select Map).FirstOrDefault<KundliMappingVO>() != null)
        //            {
        //                strs1.Add((
        //                    from Map in lkmv
        //                    where Map.House == planetHouseMappingVO.House
        //                    select Map).FirstOrDefault<KundliMappingVO>().PlanetName);
        //            }
        //        }
        //        ruleDAO = new RuleDAO();
        //        AstroDAL astroDAL1 = new AstroDAL();
        //        List<long> nums2 = new List<long>();
        //        List<long> nums3 = new List<long>();
        //        foreach (string str in strs)
        //        {
        //            rulesVOs = new List<RulesVO>();
        //            rulesVOs = this.generate_final_lrvgen(persKV, lkmv, false, new List<short>(), persKV.Language, str, true, true).ToList<RulesVO>();
        //            foreach (RulesVO rulesVO in rulesVOs)
        //            {
        //                yearsVO = new YearsVO()
        //                {
        //                    Sno = num1,
        //                    RuleNo = Convert.ToInt16(rulesVO.Sno),
        //                    Year1_From = num3,
        //                    Year2_From = num5,
        //                    Year3_From = num7,
        //                    Year1_To = num4,
        //                    Year2_To = num6,
        //                    Year3_To = num8,
        //                    VFalYears = rulesVO.VfalYears
        //                };
        //                if (rulesVO.Shishu)
        //                {
        //                    yearsVO.Age = "shishu";
        //                }
        //                if (rulesVO.Bachpan)
        //                {
        //                    yearsVO.Age = "bachpan";
        //                }
        //                if (rulesVO.Kishor)
        //                {
        //                    YearsVO yearsVO1 = yearsVO;
        //                    yearsVO1.Age = string.Concat(yearsVO1.Age, "kishor");
        //                }
        //                if (rulesVO.Yuva)
        //                {
        //                    YearsVO yearsVO2 = yearsVO;
        //                    yearsVO2.Age = string.Concat(yearsVO2.Age, "yuva");
        //                }
        //                if (rulesVO.Madhya)
        //                {
        //                    YearsVO yearsVO3 = yearsVO;
        //                    yearsVO3.Age = string.Concat(yearsVO3.Age, "madhya");
        //                }
        //                if (rulesVO.Budhapa)
        //                {
        //                    YearsVO yearsVO4 = yearsVO;
        //                    yearsVO4.Age = string.Concat(yearsVO4.Age, "budhapa");
        //                }
        //                yearsVO.Shishu = rulesVO.Shishu;
        //                yearsVO.Bachpan = rulesVO.Bachpan;
        //                yearsVO.Kishor = rulesVO.Kishor;
        //                yearsVO.Yuva = rulesVO.Yuva;
        //                yearsVO.Madhya = rulesVO.Madhya;
        //                yearsVO.Budhapa = rulesVO.Budhapa;
        //                num1 = (short)(num1 + 1);
        //                yearsVOs.Add(yearsVO);
        //            }
        //        }
        //        foreach (string str4 in strs1)
        //        {
        //            rulesVOs = new List<RulesVO>();
        //            rulesVOs = this.generate_final_lrvgen(persKV, lkmv, false, new List<short>(), persKV.Language, str4, false, false).ToList<RulesVO>();
        //            foreach (RulesVO rulesVO1 in rulesVOs)
        //            {
        //                yearsVO = new YearsVO()
        //                {
        //                    Sno = num1,
        //                    RuleNo = Convert.ToInt16(rulesVO1.Sno),
        //                    Year1_From = num3,
        //                    Year2_From = num5,
        //                    Year3_From = num7,
        //                    Year1_To = num4,
        //                    Year2_To = num6,
        //                    Year3_To = num8,
        //                    VFalYears = rulesVO1.VfalYears
        //                };
        //                if (rulesVO1.Shishu)
        //                {
        //                    yearsVO.Age = "shishu";
        //                }
        //                if (rulesVO1.Bachpan)
        //                {
        //                    yearsVO.Age = "bachpan";
        //                }
        //                if (rulesVO1.Kishor)
        //                {
        //                    YearsVO yearsVO5 = yearsVO;
        //                    yearsVO5.Age = string.Concat(yearsVO5.Age, "kishor");
        //                }
        //                if (rulesVO1.Yuva)
        //                {
        //                    YearsVO yearsVO6 = yearsVO;
        //                    yearsVO6.Age = string.Concat(yearsVO6.Age, "yuva");
        //                }
        //                if (rulesVO1.Madhya)
        //                {
        //                    YearsVO yearsVO7 = yearsVO;
        //                    yearsVO7.Age = string.Concat(yearsVO7.Age, "madhya");
        //                }
        //                if (rulesVO1.Budhapa)
        //                {
        //                    YearsVO yearsVO8 = yearsVO;
        //                    yearsVO8.Age = string.Concat(yearsVO8.Age, "budhapa");
        //                }
        //                yearsVO.Shishu = rulesVO1.Shishu;
        //                yearsVO.Bachpan = rulesVO1.Bachpan;
        //                yearsVO.Kishor = rulesVO1.Kishor;
        //                yearsVO.Yuva = rulesVO1.Yuva;
        //                yearsVO.Madhya = rulesVO1.Madhya;
        //                yearsVO.Budhapa = rulesVO1.Budhapa;
        //                num1 = (short)(num1 + 1);
        //                yearsVOs.Add(yearsVO);
        //            }
        //        }
        //    }
        //    RuleDAO ruleDAO1 = new RuleDAO();
        //    bool flag35 = false;
        //    List<RulesVO> list = (
        //        from Map in kundliBLL.GetAdvancePredictions(lkmv, 0, 0)
        //        where Map.RuleType == "LagnaShikshaYog"
        //        select Map).ToList<RulesVO>();
        //    RuleDAO ruleDAO2 = new RuleDAO();
        //    List<RulesVO> rulesVOs1 = new List<RulesVO>();
        //    rulesVOs1.AddRange((
        //        from map in list
        //        where map.RuleType == "LagnaShikshaYog"
        //        select map).ToList<RulesVO>());
        //    List<long> nums4 = new List<long>();
        //    if (!flag35)
        //    {
        //        foreach (RulesVO rulesVO2 in rulesVOs1)
        //        {
        //            List<AdditionalRulesVO> additionalRulesVOs = (
        //                from aar in ruleDAO2.Get_AdditionalRules()
        //                where aar.RuleNo == rulesVO2.Sno
        //                select aar).ToList<AdditionalRulesVO>();
        //            if (additionalRulesVOs.Count > 0)
        //            {
        //                foreach (AdditionalRulesVO additionalRulesVO in additionalRulesVOs)
        //                {
        //                    string str5 = additionalRulesVO.Lagan.ToString();
        //                    chrArray = new char[] { ',' };
        //                    string[] array = str5.Split(chrArray).ToArray<string>();
        //                    for (int j = 0; j < array.Count<string>(); j++)
        //                    {
        //                        if (((long)Convert.ToInt32(array[j].ToString()) != persKV.Lagna ? false : !flag35))
        //                        {
        //                            if (!nums4.Contains(rulesVO2.Sno))
        //                            {
        //                                yearsVO = new YearsVO()
        //                                {
        //                                    Sno = num1,
        //                                    RuleNo = Convert.ToInt16(rulesVO2.RefNo),
        //                                    VFalYears = "17",
        //                                    Kishor = true,
        //                                    Age = "kishor"
        //                                };
        //                                num1 = (short)(num1 + 1);
        //                                yearsVOs.Add(yearsVO);
        //                                flag35 = true;
        //                                nums4.Add(rulesVO2.Sno);
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    foreach (Life35VO life35VO1 in life35VOs)
        //    {
        //        List<RulesVO> list1 = new List<RulesVO>();
        //        KundliMappingVO kundliMappingVO1 = new KundliMappingVO();
        //        kundliMappingVO1 = (
        //            from Map in lkmv
        //            where Map.PlanetName == life35VO1.Planet
        //            select Map).SingleOrDefault<KundliMappingVO>();
        //        str = kundliMappingVO1.PlanetName;
        //        list1 = (
        //            from Map in kundliBLL.GetAdvancePredictions(lkmv, this.findplanet_by_name(life35VO1.Planet).Sno, 0)
        //            where (Map.VfalYears.Trim().Length > 0 || Map.Isbad != kundliMappingVO1.IsBad ? false : (Map.RuleType == "general" ? true : (Map.Reference != "Indian Astrology" ? false : Map.Ruleformula.Contains("&"))))
        //            select Map).ToList<RulesVO>();
        //        list1.AddRange((
        //            from Map in kundliBLL.GetAdvancePredictions(lkmv, this.findplanet_by_name(life35VO1.Planet).Sno, 0)
        //            where (Map.VfalYears.Trim().Length > 0 ? false : (Map.RuleType == "any" ? true : Map.RuleType == "triangle"))
        //            select Map).ToList<RulesVO>());
        //        if (persKV.Male)
        //        {
        //            list1 = (
        //                from Map in list1
        //                where (Map.Common ? true : Map.Male)
        //                select Map).ToList<RulesVO>();
        //        }
        //        if (!persKV.Male)
        //        {
        //            list1 = (
        //                from Map in list1
        //                where (Map.Common ? true : Map.Female)
        //                select Map).ToList<RulesVO>();
        //        }
        //        foreach (RulesVO advanceRuleById in list1)
        //        {
        //            yearsVO = new YearsVO()
        //            {
        //                Sno = num1,
        //                RuleNo = Convert.ToInt16(advanceRuleById.Sno)
        //            };
        //            if (!(life35VO1.Planet == "Guru") || !advanceRuleById.Bachpan)
        //            {
        //                flag = true;
        //            }
        //            else
        //            {
        //                flag = (advanceRuleById.Memory || advanceRuleById.Confidence || advanceRuleById.Mother_father || advanceRuleById.Brother ? false : !advanceRuleById.Disease);
        //            }
        //            if (!flag)
        //            {
        //                yearsVO.VFalYears = "10";
        //                yearsVO.Bachpan = true;
        //                num1 = (short)(num1 + 1);
        //                yearsVOs.Add(yearsVO);
        //            }
        //            if (!(life35VO1.Planet == "Guru") || !advanceRuleById.Kishor)
        //            {
        //                flag1 = true;
        //            }
        //            else
        //            {
        //                flag1 = (advanceRuleById.Memory || advanceRuleById.Confidence || advanceRuleById.Mother_father || advanceRuleById.Brother || advanceRuleById.Disease ? false : !advanceRuleById.Love_affair);
        //            }
        //            if (!flag1)
        //            {
        //                yearsVO.VFalYears = "16";
        //                yearsVO.Kishor = true;
        //                num1 = (short)(num1 + 1);
        //                yearsVOs.Add(yearsVO);
        //            }
        //            if (!(life35VO1.Planet == "Guru") || !advanceRuleById.Madhya)
        //            {
        //                flag2 = true;
        //            }
        //            else
        //            {
        //                flag2 = (advanceRuleById.Memory || advanceRuleById.Confidence || advanceRuleById.Marriedlife || advanceRuleById.Occupation || advanceRuleById.Profit || advanceRuleById.Santan || advanceRuleById.Disease ? false : !advanceRuleById.Love_affair);
        //            }
        //            if (!flag2)
        //            {
        //                yearsVO.VFalYears = "51";
        //                yearsVO.Madhya = true;
        //                num1 = (short)(num1 + 1);
        //                yearsVOs.Add(yearsVO);
        //            }
        //            if (!(life35VO1.Planet == "Surya") || !advanceRuleById.Bachpan)
        //            {
        //                flag3 = true;
        //            }
        //            else
        //            {
        //                flag3 = (advanceRuleById.Memory || advanceRuleById.Confidence || advanceRuleById.Mother_father || advanceRuleById.Brother ? false : !advanceRuleById.Disease);
        //            }
        //            if (!flag3)
        //            {
        //                yearsVO.VFalYears = "6,11";
        //                yearsVO.Bachpan = true;
        //                num1 = (short)(num1 + 1);
        //                yearsVOs.Add(yearsVO);
        //            }
        //            if (!(life35VO1.Planet == "Surya") || !advanceRuleById.Yuva)
        //            {
        //                flag4 = true;
        //            }
        //            else
        //            {
        //                flag4 = (advanceRuleById.Memory || advanceRuleById.Confidence || advanceRuleById.Marriedlife || advanceRuleById.Occupation || advanceRuleById.Mother_father || advanceRuleById.Brother || advanceRuleById.Profit || advanceRuleById.Santan || advanceRuleById.Disease ? false : !advanceRuleById.Love_affair);
        //            }
        //            if (!flag4)
        //            {
        //                yearsVO.VFalYears = "22";
        //                yearsVO.Yuva = true;
        //                num1 = (short)(num1 + 1);
        //                yearsVOs.Add(yearsVO);
        //            }
        //            if (!(life35VO1.Planet == "Chandra") || !advanceRuleById.Bachpan)
        //            {
        //                flag5 = true;
        //            }
        //            else
        //            {
        //                flag5 = (advanceRuleById.Memory || advanceRuleById.Confidence || advanceRuleById.Mother_father || advanceRuleById.Brother ? false : !advanceRuleById.Disease);
        //            }
        //            if (!flag5)
        //            {
        //                yearsVO.VFalYears = "6,12";
        //                yearsVO.Bachpan = true;
        //                num1 = (short)(num1 + 1);
        //                yearsVOs.Add(yearsVO);
        //            }
        //            if (!(life35VO1.Planet == "Chandra") || !advanceRuleById.Yuva)
        //            {
        //                flag6 = true;
        //            }
        //            else
        //            {
        //                flag6 = (advanceRuleById.Memory || advanceRuleById.Confidence || advanceRuleById.Marriedlife || advanceRuleById.Occupation || advanceRuleById.Mother_father || advanceRuleById.Brother || advanceRuleById.Profit || advanceRuleById.Santan || advanceRuleById.Disease ? false : !advanceRuleById.Love_affair);
        //            }
        //            if (!flag6)
        //            {
        //                yearsVO.VFalYears = "24";
        //                num1 = (short)(num1 + 1);
        //                yearsVOs.Add(yearsVO);
        //            }
        //            if (!(life35VO1.Planet == "Mangal") || !advanceRuleById.Kishor)
        //            {
        //                flag7 = true;
        //            }
        //            else
        //            {
        //                flag7 = (advanceRuleById.Memory || advanceRuleById.Confidence || advanceRuleById.Mother_father || advanceRuleById.Brother || advanceRuleById.Disease ? false : !advanceRuleById.Love_affair);
        //            }
        //            if (!flag7)
        //            {
        //                yearsVO.VFalYears = "15";
        //                yearsVO.Kishor = true;
        //                num1 = (short)(num1 + 1);
        //                yearsVOs.Add(yearsVO);
        //            }
        //            if (!(life35VO1.Planet == "Mangal") || !advanceRuleById.Yuva)
        //            {
        //                flag8 = true;
        //            }
        //            else
        //            {
        //                flag8 = (advanceRuleById.Memory || advanceRuleById.Confidence || advanceRuleById.Marriedlife || advanceRuleById.Occupation || advanceRuleById.Mother_father || advanceRuleById.Brother || advanceRuleById.Profit || advanceRuleById.Santan || advanceRuleById.Disease ? false : !advanceRuleById.Love_affair);
        //            }
        //            if (!flag8)
        //            {
        //                yearsVO.VFalYears = "26,28";
        //                yearsVO.Yuva = true;
        //                num1 = (short)(num1 + 1);
        //                yearsVOs.Add(yearsVO);
        //            }
        //            if (!(life35VO1.Planet == "Budh") || !advanceRuleById.Bachpan)
        //            {
        //                flag9 = true;
        //            }
        //            else
        //            {
        //                flag9 = (advanceRuleById.Memory || advanceRuleById.Confidence || advanceRuleById.Mother_father || advanceRuleById.Brother ? false : !advanceRuleById.Disease);
        //            }
        //            if (!flag9)
        //            {
        //                yearsVO.VFalYears = "9";
        //                yearsVO.Bachpan = true;
        //                num1 = (short)(num1 + 1);
        //                yearsVOs.Add(yearsVO);
        //            }
        //            if (!(life35VO1.Planet == "Budh") || !advanceRuleById.Kishor)
        //            {
        //                flag10 = true;
        //            }
        //            else
        //            {
        //                flag10 = (advanceRuleById.Memory || advanceRuleById.Confidence || advanceRuleById.Mother_father || advanceRuleById.Brother || advanceRuleById.Disease ? false : !advanceRuleById.Love_affair);
        //            }
        //            if (!flag10)
        //            {
        //                yearsVO.VFalYears = "17";
        //                yearsVO.Kishor = true;
        //                num1 = (short)(num1 + 1);
        //                yearsVOs.Add(yearsVO);
        //            }
        //            if (!(life35VO1.Planet == "Budh") || !advanceRuleById.Yuva)
        //            {
        //                flag11 = true;
        //            }
        //            else
        //            {
        //                flag11 = (advanceRuleById.Memory || advanceRuleById.Confidence || advanceRuleById.Marriedlife || advanceRuleById.Occupation || advanceRuleById.Mother_father || advanceRuleById.Brother || advanceRuleById.Profit || advanceRuleById.Santan || advanceRuleById.Disease ? false : !advanceRuleById.Love_affair);
        //            }
        //            if (!flag11)
        //            {
        //                yearsVO.VFalYears = "34";
        //                yearsVO.Yuva = true;
        //                num1 = (short)(num1 + 1);
        //                yearsVOs.Add(yearsVO);
        //            }
        //            if (!(life35VO1.Planet == "Shukra") || !advanceRuleById.Yuva)
        //            {
        //                flag12 = true;
        //            }
        //            else
        //            {
        //                flag12 = (advanceRuleById.Memory || advanceRuleById.Confidence || advanceRuleById.Marriedlife || advanceRuleById.Occupation || advanceRuleById.Mother_father || advanceRuleById.Brother || advanceRuleById.Profit || advanceRuleById.Santan || advanceRuleById.Disease ? false : !advanceRuleById.Love_affair);
        //            }
        //            if (!flag12)
        //            {
        //                yearsVO.VFalYears = "25";
        //                yearsVO.Yuva = true;
        //                num1 = (short)(num1 + 1);
        //                yearsVOs.Add(yearsVO);
        //            }
        //            if (!(life35VO1.Planet == "Shani") || !advanceRuleById.Bachpan)
        //            {
        //                flag13 = true;
        //            }
        //            else
        //            {
        //                flag13 = (advanceRuleById.Memory || advanceRuleById.Confidence || advanceRuleById.Mother_father || advanceRuleById.Brother ? false : !advanceRuleById.Disease);
        //            }
        //            if (!flag13)
        //            {
        //                yearsVO.VFalYears = "9";
        //                yearsVO.Bachpan = true;
        //                num1 = (short)(num1 + 1);
        //                yearsVOs.Add(yearsVO);
        //            }
        //            if (!(life35VO1.Planet == "Shani") || !advanceRuleById.Kishor)
        //            {
        //                flag14 = true;
        //            }
        //            else
        //            {
        //                flag14 = (advanceRuleById.Memory || advanceRuleById.Confidence || advanceRuleById.Mother_father || advanceRuleById.Brother || advanceRuleById.Disease ? false : !advanceRuleById.Love_affair);
        //            }
        //            if (!flag14)
        //            {
        //                yearsVO.VFalYears = "18";
        //                yearsVO.Kishor = true;
        //                num1 = (short)(num1 + 1);
        //                yearsVOs.Add(yearsVO);
        //            }
        //            if (!(life35VO1.Planet == "Shani") || !advanceRuleById.Madhya)
        //            {
        //                flag15 = true;
        //            }
        //            else
        //            {
        //                flag15 = (advanceRuleById.Memory || advanceRuleById.Confidence || advanceRuleById.Marriedlife || advanceRuleById.Occupation || advanceRuleById.Mother_father || advanceRuleById.Brother || advanceRuleById.Profit || advanceRuleById.Santan || advanceRuleById.Disease ? false : !advanceRuleById.Love_affair);
        //            }
        //            if (!flag15)
        //            {
        //                yearsVO.VFalYears = "36";
        //                yearsVO.Madhya = true;
        //                num1 = (short)(num1 + 1);
        //                yearsVOs.Add(yearsVO);
        //            }
        //            if (!(life35VO1.Planet == "Rahu") || !advanceRuleById.Bachpan)
        //            {
        //                flag16 = true;
        //            }
        //            else
        //            {
        //                flag16 = (advanceRuleById.Memory || advanceRuleById.Confidence || advanceRuleById.Mother_father || advanceRuleById.Brother ? false : !advanceRuleById.Disease);
        //            }
        //            if (!flag16)
        //            {
        //                yearsVO.VFalYears = "11";
        //                yearsVO.Bachpan = true;
        //                num1 = (short)(num1 + 1);
        //                yearsVOs.Add(yearsVO);
        //            }
        //            if (!(life35VO1.Planet == "Rahu") || !advanceRuleById.Yuva)
        //            {
        //                flag17 = true;
        //            }
        //            else
        //            {
        //                flag17 = (advanceRuleById.Memory || advanceRuleById.Confidence || advanceRuleById.Marriedlife || advanceRuleById.Occupation || advanceRuleById.Mother_father || advanceRuleById.Brother || advanceRuleById.Profit || advanceRuleById.Santan || advanceRuleById.Disease ? false : !advanceRuleById.Love_affair);
        //            }
        //            if (!flag17)
        //            {
        //                yearsVO.VFalYears = "21";
        //                yearsVO.Yuva = true;
        //                num1 = (short)(num1 + 1);
        //                yearsVOs.Add(yearsVO);
        //            }
        //            if (!(life35VO1.Planet == "Rahu") || !advanceRuleById.Madhya)
        //            {
        //                flag18 = true;
        //            }
        //            else
        //            {
        //                flag18 = (advanceRuleById.Memory || advanceRuleById.Confidence || advanceRuleById.Marriedlife || advanceRuleById.Occupation || advanceRuleById.Profit || advanceRuleById.Santan || advanceRuleById.Disease ? false : !advanceRuleById.Love_affair);
        //            }
        //            if (!flag18)
        //            {
        //                yearsVO.VFalYears = "40,42";
        //                yearsVO.Madhya = true;
        //                num1 = (short)(num1 + 1);
        //                yearsVOs.Add(yearsVO);
        //            }
        //            if (!(life35VO1.Planet == "Ketu") || !advanceRuleById.Madhya)
        //            {
        //                flag19 = true;
        //            }
        //            else
        //            {
        //                flag19 = (advanceRuleById.Memory || advanceRuleById.Confidence || advanceRuleById.Marriedlife || advanceRuleById.Occupation || advanceRuleById.Profit || advanceRuleById.Santan || advanceRuleById.Disease ? false : !advanceRuleById.Love_affair);
        //            }
        //            if (!flag19)
        //            {
        //                yearsVO.VFalYears = "40";
        //                yearsVO.Madhya = true;
        //                num1 = (short)(num1 + 1);
        //                yearsVOs.Add(yearsVO);
        //            }
        //        }
        //    }
        //    foreach (YearsVO yearsVO in yearsVOs.ToList<YearsVO>())
        //    {
        //        yearsVOs[yearsVO.Sno].Age = " ";
        //    }
        //    RuleBLL ruleBLL = new RuleBLL();
        //    foreach (YearsVO list2 in (
        //        from Map in yearsVOs
        //        where Map.VFalYears.ToString().Length <= 0
        //        select Map).ToList<YearsVO>())
        //    {
        //        advanceRuleById = new RulesVO();
        //        advanceRuleById = ruleBLL.GetAdvanceRuleById((long)list2.RuleNo);
        //        if (!advanceRuleById.Shishu)
        //        {
        //            flag20 = true;
        //        }
        //        else if ((advanceRuleById.Memory || advanceRuleById.Confidence || advanceRuleById.Mother_father || advanceRuleById.Brother || advanceRuleById.Disease) && list2.Year1_From >= 1 && list2.Year1_From <= 3)
        //        {
        //            flag20 = false;
        //        }
        //        else if (list2.Year2_From < 1 || list2.Year2_From > 3)
        //        {
        //            flag20 = (list2.Year3_From < 1 ? true : list2.Year3_From > 3);
        //        }
        //        else
        //        {
        //            flag20 = false;
        //        }
        //        if (!flag20)
        //        {
        //            YearsVO item = yearsVOs[list2.Sno];
        //            item.Age = string.Concat(item.Age, "shishu");
        //        }
        //        if (!advanceRuleById.Bachpan)
        //        {
        //            flag21 = true;
        //        }
        //        else if ((advanceRuleById.Memory || advanceRuleById.Confidence || advanceRuleById.Mother_father || advanceRuleById.Brother || advanceRuleById.Disease) && list2.Year1_From >= 4 && list2.Year1_From <= 12)
        //        {
        //            flag21 = false;
        //        }
        //        else if (list2.Year2_From < 4 || list2.Year2_From > 12)
        //        {
        //            flag21 = (list2.Year3_From < 4 ? true : list2.Year3_From > 12);
        //        }
        //        else
        //        {
        //            flag21 = false;
        //        }
        //        if (!flag21)
        //        {
        //            YearsVO item1 = yearsVOs[list2.Sno];
        //            item1.Age = string.Concat(item1.Age, "bachpan");
        //        }
        //        if (!advanceRuleById.Kishor)
        //        {
        //            flag22 = true;
        //        }
        //        else if (!advanceRuleById.Memory && !advanceRuleById.Confidence && !advanceRuleById.Mother_father && !advanceRuleById.Brother && !advanceRuleById.Disease && !advanceRuleById.Love_affair)
        //        {
        //            flag22 = true;
        //        }
        //        else if ((list2.Year1_From < 13 || list2.Year1_From > 20) && (list2.Year2_From < 13 || list2.Year2_From > 20))
        //        {
        //            flag22 = (list2.Year3_From < 13 ? true : list2.Year3_From > 20);
        //        }
        //        else
        //        {
        //            flag22 = false;
        //        }
        //        if (!flag22)
        //        {
        //            YearsVO item2 = yearsVOs[list2.Sno];
        //            item2.Age = string.Concat(item2.Age, "kishor");
        //        }
        //        if (!advanceRuleById.Yuva)
        //        {
        //            flag23 = true;
        //        }
        //        else if (!advanceRuleById.Memory && !advanceRuleById.Confidence && !advanceRuleById.Marriedlife && !advanceRuleById.Occupation && !advanceRuleById.Mother_father && !advanceRuleById.Brother && !advanceRuleById.Profit && !advanceRuleById.Santan && !advanceRuleById.Disease && !advanceRuleById.Love_affair)
        //        {
        //            flag23 = true;
        //        }
        //        else if ((list2.Year1_From < 21 || list2.Year1_From > 35) && (list2.Year2_From < 21 || list2.Year2_From > 35))
        //        {
        //            flag23 = (list2.Year3_From < 21 ? true : list2.Year3_From > 35);
        //        }
        //        else
        //        {
        //            flag23 = false;
        //        }
        //        if (!flag23)
        //        {
        //            YearsVO item3 = yearsVOs[list2.Sno];
        //            item3.Age = string.Concat(item3.Age, "yuva");
        //        }
        //        if (!advanceRuleById.Madhya)
        //        {
        //            flag24 = true;
        //        }
        //        else if (!advanceRuleById.Memory && !advanceRuleById.Confidence && !advanceRuleById.Marriedlife && !advanceRuleById.Occupation && !advanceRuleById.Profit && !advanceRuleById.Santan && !advanceRuleById.Disease && !advanceRuleById.Love_affair)
        //        {
        //            flag24 = true;
        //        }
        //        else if ((list2.Year1_From < 36 || list2.Year1_From > 51) && (list2.Year2_From < 36 || list2.Year2_From > 51))
        //        {
        //            flag24 = (list2.Year3_From < 36 ? true : list2.Year3_From > 51);
        //        }
        //        else
        //        {
        //            flag24 = false;
        //        }
        //        if (!flag24)
        //        {
        //            YearsVO item4 = yearsVOs[list2.Sno];
        //            item4.Age = string.Concat(item4.Age, "madhya");
        //        }
        //        if (!advanceRuleById.Budhapa)
        //        {
        //            flag25 = true;
        //        }
        //        else if (!advanceRuleById.Memory && !advanceRuleById.Brother && !advanceRuleById.Santan && !advanceRuleById.Marriedlife && !advanceRuleById.Confidence && !advanceRuleById.Profit && !advanceRuleById.Disease)
        //        {
        //            flag25 = true;
        //        }
        //        else if ((list2.Year1_From < 52 || list2.Year1_From > 120) && (list2.Year2_From < 52 || list2.Year2_From > 120))
        //        {
        //            flag25 = (list2.Year3_From < 52 ? true : list2.Year3_From > 120);
        //        }
        //        else
        //        {
        //            flag25 = false;
        //        }
        //        if (!flag25)
        //        {
        //            YearsVO item5 = yearsVOs[list2.Sno];
        //            item5.Age = string.Concat(item5.Age, "budhapa");
        //        }
        //    }
        //    foreach (YearsVO list3 in (
        //        from Map in yearsVOs
        //        where Map.VFalYears.ToString().Length > 0
        //        select Map).ToList<YearsVO>())
        //    {
        //        advanceRuleById = new RulesVO();
        //        advanceRuleById = ruleBLL.GetAdvanceRuleById((long)list3.RuleNo);
        //        string vFalYears = list3.VFalYears;
        //        chrArray = new char[] { ',' };
        //        string[] strArrays = vFalYears.Split(chrArray).ToArray<string>();
        //        for (int k = 0; k < (int)strArrays.Length; k++)
        //        {
        //            string str6 = strArrays[k];
        //            if (!advanceRuleById.Shishu)
        //            {
        //                flag26 = true;
        //            }
        //            else if (advanceRuleById.Memory || advanceRuleById.Confidence || advanceRuleById.Mother_father || advanceRuleById.Brother || advanceRuleById.Disease)
        //            {
        //                flag26 = (Convert.ToInt16(str6) < 1 ? true : Convert.ToInt16(str6) > 3);
        //            }
        //            else
        //            {
        //                flag26 = true;
        //            }
        //            if (!flag26)
        //            {
        //                YearsVO item6 = yearsVOs[list3.Sno];
        //                item6.Age = string.Concat(item6.Age, "shishu");
        //                yearsVOs[list3.Sno].Year1_From = (
        //                    from Map in yearsVOs
        //                    where (Convert.ToInt16(str6) < Map.Year1_From ? false : Convert.ToInt16(str6) <= Map.Year1_To)
        //                    select Map).FirstOrDefault<YearsVO>().Year1_From;
        //                yearsVOs[list3.Sno].Year1_To = (
        //                    from Map in yearsVOs
        //                    where (Convert.ToInt16(str6) < Map.Year1_From ? false : Convert.ToInt16(str6) <= Map.Year1_To)
        //                    select Map).FirstOrDefault<YearsVO>().Year1_To;
        //            }
        //            if (!advanceRuleById.Bachpan)
        //            {
        //                flag27 = true;
        //            }
        //            else if (advanceRuleById.Memory || advanceRuleById.Confidence || advanceRuleById.Mother_father || advanceRuleById.Brother || advanceRuleById.Disease)
        //            {
        //                flag27 = (Convert.ToInt16(str6) < 4 ? true : Convert.ToInt16(str6) > 12);
        //            }
        //            else
        //            {
        //                flag27 = true;
        //            }
        //            if (!flag27)
        //            {
        //                YearsVO item7 = yearsVOs[list3.Sno];
        //                item7.Age = string.Concat(item7.Age, "bachpan");
        //                yearsVOs[list3.Sno].Year1_From = (
        //                    from Map in yearsVOs
        //                    where (Convert.ToInt16(str6) < Map.Year1_From ? false : Convert.ToInt16(str6) <= Map.Year1_To)
        //                    select Map).FirstOrDefault<YearsVO>().Year1_From;
        //                yearsVOs[list3.Sno].Year1_To = (
        //                    from Map in yearsVOs
        //                    where (Convert.ToInt16(str6) < Map.Year1_From ? false : Convert.ToInt16(str6) <= Map.Year1_To)
        //                    select Map).FirstOrDefault<YearsVO>().Year1_To;
        //            }
        //            if (!advanceRuleById.Kishor)
        //            {
        //                flag28 = true;
        //            }
        //            else if (advanceRuleById.Memory || advanceRuleById.Confidence || advanceRuleById.Mother_father || advanceRuleById.Brother || advanceRuleById.Disease || advanceRuleById.Love_affair)
        //            {
        //                flag28 = (Convert.ToInt16(str6) < 13 ? true : Convert.ToInt16(str6) > 20);
        //            }
        //            else
        //            {
        //                flag28 = true;
        //            }
        //            if (!flag28)
        //            {
        //                YearsVO item8 = yearsVOs[list3.Sno];
        //                item8.Age = string.Concat(item8.Age, "kishor");
        //                yearsVOs[list3.Sno].Year1_From = (
        //                    from Map in yearsVOs
        //                    where (Convert.ToInt16(str6) < Map.Year1_From ? false : Convert.ToInt16(str6) <= Map.Year1_To)
        //                    select Map).FirstOrDefault<YearsVO>().Year1_From;
        //                yearsVOs[list3.Sno].Year1_To = (
        //                    from Map in yearsVOs
        //                    where (Convert.ToInt16(str6) < Map.Year1_From ? false : Convert.ToInt16(str6) <= Map.Year1_To)
        //                    select Map).FirstOrDefault<YearsVO>().Year1_To;
        //            }
        //            if (!advanceRuleById.Yuva)
        //            {
        //                flag29 = true;
        //            }
        //            else if (advanceRuleById.Memory || advanceRuleById.Confidence || advanceRuleById.Marriedlife || advanceRuleById.Occupation || advanceRuleById.Mother_father || advanceRuleById.Brother || advanceRuleById.Profit || advanceRuleById.Santan || advanceRuleById.Disease || advanceRuleById.Love_affair)
        //            {
        //                flag29 = (Convert.ToInt16(str6) < 21 ? true : Convert.ToInt16(str6) > 35);
        //            }
        //            else
        //            {
        //                flag29 = true;
        //            }
        //            if (!flag29)
        //            {
        //                YearsVO item9 = yearsVOs[list3.Sno];
        //                item9.Age = string.Concat(item9.Age, "yuva");
        //                yearsVOs[list3.Sno].Year1_From = (
        //                    from Map in yearsVOs
        //                    where (Convert.ToInt16(str6) < Map.Year1_From ? false : Convert.ToInt16(str6) <= Map.Year1_To)
        //                    select Map).FirstOrDefault<YearsVO>().Year1_From;
        //                yearsVOs[list3.Sno].Year1_To = (
        //                    from Map in yearsVOs
        //                    where (Convert.ToInt16(str6) < Map.Year1_From ? false : Convert.ToInt16(str6) <= Map.Year1_To)
        //                    select Map).FirstOrDefault<YearsVO>().Year1_To;
        //            }
        //            if (!advanceRuleById.Madhya)
        //            {
        //                flag30 = true;
        //            }
        //            else if (advanceRuleById.Memory || advanceRuleById.Confidence || advanceRuleById.Marriedlife || advanceRuleById.Occupation || advanceRuleById.Profit || advanceRuleById.Santan || advanceRuleById.Disease || advanceRuleById.Love_affair)
        //            {
        //                flag30 = (Convert.ToInt16(str6) < 36 ? true : Convert.ToInt16(str6) > 51);
        //            }
        //            else
        //            {
        //                flag30 = true;
        //            }
        //            if (!flag30)
        //            {
        //                YearsVO yearsVO9 = yearsVOs[list3.Sno];
        //                yearsVO9.Age = string.Concat(yearsVO9.Age, "madhya");
        //                yearsVOs[list3.Sno].Year2_From = (
        //                    from Map in yearsVOs
        //                    where (Convert.ToInt16(str6) < Map.Year2_From ? false : Convert.ToInt16(str6) <= Map.Year2_To)
        //                    select Map).FirstOrDefault<YearsVO>().Year2_From;
        //                yearsVOs[list3.Sno].Year2_To = (
        //                    from Map in yearsVOs
        //                    where (Convert.ToInt16(str6) < Map.Year2_From ? false : Convert.ToInt16(str6) <= Map.Year2_To)
        //                    select Map).FirstOrDefault<YearsVO>().Year2_To;
        //            }
        //            if (!advanceRuleById.Budhapa)
        //            {
        //                flag31 = true;
        //            }
        //            else if (advanceRuleById.Memory || advanceRuleById.Brother || advanceRuleById.Santan || advanceRuleById.Marriedlife || advanceRuleById.Confidence || advanceRuleById.Profit || advanceRuleById.Disease)
        //            {
        //                flag31 = (Convert.ToInt16(str6) < 52 ? true : Convert.ToInt16(str6) > 120);
        //            }
        //            else
        //            {
        //                flag31 = true;
        //            }
        //            if (!flag31)
        //            {
        //                YearsVO item10 = yearsVOs[list3.Sno];
        //                item10.Age = string.Concat(item10.Age, "budhapa");
        //                if ((Convert.ToInt16(str6) < 52 ? false : Convert.ToInt16(str6) <= 70))
        //                {
        //                    yearsVOs[list3.Sno].Year2_From = (
        //                        from Map in yearsVOs
        //                        where (Convert.ToInt16(str6) < Map.Year2_From ? false : Convert.ToInt16(str6) <= Map.Year2_To)
        //                        select Map).FirstOrDefault<YearsVO>().Year2_From;
        //                    yearsVOs[list3.Sno].Year2_To = (
        //                        from Map in yearsVOs
        //                        where (Convert.ToInt16(str6) < Map.Year2_From ? false : Convert.ToInt16(str6) <= Map.Year2_To)
        //                        select Map).FirstOrDefault<YearsVO>().Year2_To;
        //                }
        //                if ((Convert.ToInt16(str6) < 71 ? false : Convert.ToInt16(str6) <= 120))
        //                {
        //                    yearsVOs[list3.Sno].Year3_From = (
        //                        from Map in yearsVOs
        //                        where (Convert.ToInt16(str6) < Map.Year3_From ? false : Convert.ToInt16(str6) <= Map.Year3_To)
        //                        select Map).FirstOrDefault<YearsVO>().Year3_From;
        //                    yearsVOs[list3.Sno].Year3_To = (
        //                        from Map in yearsVOs
        //                        where (Convert.ToInt16(str6) < Map.Year3_From ? false : Convert.ToInt16(str6) <= Map.Year3_To)
        //                        select Map).FirstOrDefault<YearsVO>().Year3_To;
        //                }
        //            }
        //        }
        //    }
        //    string str7 = "";
        //    string str8 = "";
        //    string str9 = "";
        //    string str10 = "";
        //    string str11 = "";
        //    string str12 = "";
        //    List<long> nums5 = new List<long>();
        //    List<long> nums6 = new List<long>();
        //    List<long> nums7 = new List<long>();
        //    List<long> nums8 = new List<long>();
        //    List<long> nums9 = new List<long>();
        //    List<long> nums10 = new List<long>();
        //    List<long> nums11 = new List<long>();
        //    short year1From1 = 0;
        //    short year1From2 = 0;
        //    short year1From3 = 0;
        //    short year1From4 = 0;
        //    short year2From1 = 0;
        //    short num9 = 0;
        //    short num10 = 0;
        //    string str13 = "";
        //    foreach (YearsVO yearsVO10 in
        //        from Map in yearsVOs
        //        orderby Map.Year3_From
        //        orderby Map.Year2_From
        //        orderby Map.Year1_From
        //        select Map)
        //    {
        //        if (yearsVO10.Age.Contains("shishu"))
        //        {
        //            if (!nums5.Contains((long)yearsVO10.RuleNo))
        //            {
        //                if (year1From1 != yearsVO10.Year1_From)
        //                {
        //                    obj = str7;
        //                    year1From = new object[] { obj, "\r\n", yearsVO10.Year1_From, " ", this.GetCodeLang("toyear", persKV.Language, persKV.Paid, flag33) };
        //                    str7 = string.Concat(year1From);
        //                }
        //                year1From1 = yearsVO10.Year1_From;
        //                str7 = string.Concat(str7, str13, this.Get_Pred_Text((long)yearsVO10.RuleNo, persKV.Language, true, true, persKV.ShowRef, false, persKV.Paid, true, flag33, persKV), "\r\n");
        //                nums5.Add((long)yearsVO10.RuleNo);
        //            }
        //        }
        //        if (yearsVO10.Age.Contains("bachpan"))
        //        {
        //            if (!nums6.Contains((long)yearsVO10.RuleNo))
        //            {
        //                if (year1From2 != yearsVO10.Year1_From)
        //                {
        //                    obj = str8;
        //                    year1From = new object[] { obj, "\r\n", yearsVO10.Year1_From, " ", this.GetCodeLang("toyear", persKV.Language, persKV.Paid, flag33) };
        //                    str8 = string.Concat(year1From);
        //                }
        //                year1From2 = yearsVO10.Year1_From;
        //                str8 = string.Concat(str8, str13, this.Get_Pred_Text((long)yearsVO10.RuleNo, persKV.Language, true, true, persKV.ShowRef, false, persKV.Paid, true, flag33, persKV), "\r\n");
        //                nums6.Add((long)yearsVO10.RuleNo);
        //            }
        //        }
        //        if (yearsVO10.Age.Contains("kishor"))
        //        {
        //            if (!nums7.Contains((long)yearsVO10.RuleNo))
        //            {
        //                if (year1From3 != yearsVO10.Year1_From)
        //                {
        //                    obj = str9;
        //                    year1From = new object[] { obj, "\r\n", yearsVO10.Year1_From, " ", this.GetCodeLang("toyear", persKV.Language, persKV.Paid, flag33) };
        //                    str9 = string.Concat(year1From);
        //                }
        //                year1From3 = yearsVO10.Year1_From;
        //                str9 = string.Concat(str9, str13, this.Get_Pred_Text((long)yearsVO10.RuleNo, persKV.Language, true, true, persKV.ShowRef, false, persKV.Paid, true, flag33, persKV), "\r\n");
        //                nums7.Add((long)yearsVO10.RuleNo);
        //            }
        //        }
        //        if (yearsVO10.Age.Contains("yuva"))
        //        {
        //            if (!nums8.Contains((long)yearsVO10.RuleNo))
        //            {
        //                if (year1From4 != yearsVO10.Year1_From)
        //                {
        //                    obj = str11;
        //                    year1From = new object[] { obj, "\r\n", yearsVO10.Year1_From, " ", this.GetCodeLang("toyear", persKV.Language, persKV.Paid, flag33) };
        //                    str11 = string.Concat(year1From);
        //                }
        //                year1From4 = yearsVO10.Year1_From;
        //                str11 = string.Concat(str11, str13, this.Get_Pred_Text((long)yearsVO10.RuleNo, persKV.Language, true, true, persKV.ShowRef, false, persKV.Paid, true, flag33, persKV), "\r\n");
        //                nums8.Add((long)yearsVO10.RuleNo);
        //            }
        //        }
        //    }
        //    foreach (YearsVO list4 in (
        //        from Map in yearsVOs
        //        orderby Map.Year2_From
        //        where (!Map.Age.Contains("madhya") ? false : Map.Year2_From >= 36)
        //        select Map).ToList<YearsVO>())
        //    {
        //        if (!nums9.Contains((long)list4.RuleNo))
        //        {
        //            if (year2From1 != list4.Year2_From)
        //            {
        //                obj = str10;
        //                year1From = new object[] { obj, "\r\n", list4.Year2_From, " ", this.GetCodeLang("toyear", persKV.Language, persKV.Paid, flag33) };
        //                str10 = string.Concat(year1From);
        //            }
        //            year2From1 = list4.Year2_From;
        //            str10 = string.Concat(str10, str13, this.Get_Pred_Text((long)list4.RuleNo, persKV.Language, true, true, persKV.ShowRef, false, persKV.Paid, true, flag33, persKV), "\r\n");
        //            nums9.Add((long)list4.RuleNo);
        //        }
        //    }
        //    foreach (YearsVO list5 in (
        //        from Map in yearsVOs
        //        orderby Map.Year2_From
        //        where (!Map.Age.Contains("budhapa") ? false : Map.Year2_From >= 52)
        //        select Map).ToList<YearsVO>())
        //    {
        //        if (!nums10.Contains((long)list5.RuleNo))
        //        {
        //            year2From = 0;
        //            year2To = 0;
        //            if ((Convert.ToInt16(list5.Year2_From) < 52 ? false : Convert.ToInt16(list5.Year2_From) <= 70))
        //            {
        //                year2From = list5.Year2_From;
        //                year2To = list5.Year2_To;
        //                if (num9 != year2From)
        //                {
        //                    obj = str12;
        //                    year1From = new object[] { obj, "\r\n", year2From, " ", this.GetCodeLang("toyear", persKV.Language, persKV.Paid, flag33) };
        //                    str12 = string.Concat(year1From);
        //                }
        //                num9 = year2From;
        //                str12 = string.Concat(str12, str13, this.Get_Pred_Text((long)list5.RuleNo, persKV.Language, true, true, persKV.ShowRef, false, persKV.Paid, true, flag33, persKV), "\r\n");
        //                nums10.Add((long)list5.RuleNo);
        //            }
        //        }
        //    }
        //    foreach (YearsVO list6 in (
        //        from Map in yearsVOs
        //        orderby Map.Year3_From
        //        where (!Map.Age.Contains("budhapa") || Map.Year3_From < 71 ? false : Map.Year3_From <= 72)
        //        select Map).ToList<YearsVO>())
        //    {
        //        if (!nums11.Contains((long)list6.RuleNo))
        //        {
        //            year2From = 0;
        //            year2To = 0;
        //            if (Convert.ToInt16(list6.Year3_From) >= 71)
        //            {
        //                year2From = list6.Year3_From;
        //                year2To = list6.Year3_To;
        //                if (num10 != year2From)
        //                {
        //                    obj = str12;
        //                    year1From = new object[] { obj, "\r\n", year2From, " ", this.GetCodeLang("toyear", persKV.Language, persKV.Paid, flag33) };
        //                    str12 = string.Concat(year1From);
        //                }
        //                num10 = year2From;
        //                str12 = string.Concat(str12, str13, this.Get_Pred_Text((long)list6.RuleNo, persKV.Language, true, true, persKV.ShowRef, false, persKV.Paid, true, flag33, persKV), "\r\n");
        //                nums11.Add((long)list6.RuleNo);
        //            }
        //        }
        //    }
        //    string str14 = "";
        //    if (vyears.ToList<short>().Count > 0)
        //    {
        //    }
        //    string str15 = "";
        //    if (persKV.Paid)
        //    {
        //        foreach (YearsVO list7 in (
        //            from Map in yearsVOs
        //            where Map.Age.Trim().Length > 2
        //            select Map).ToList<YearsVO>())
        //        {
        //            advanceRuleById = new RulesVO();
        //            ruleDAO = new RuleDAO();
        //            advanceRuleById = ruleBLL.GetAdvanceRuleById((long)list7.RuleNo);
        //            upayIndex = new UpayIndex();
        //            upayIndex = ruleDAO.Get_UpayIndex(Convert.ToInt32(advanceRuleById.Upay));
        //            if (upayIndex != null)
        //            {
        //                if (advanceRuleById.Upay <= 0)
        //                {
        //                    flag32 = true;
        //                }
        //                else
        //                {
        //                    flag32 = (persKV.Language.ToLower() == "hindi" || persKV.Language.ToLower() == "marathi" ? false : !(persKV.Language.ToLower() == "english"));
        //                }
        //                if (!flag32)
        //                {
        //                    if (!this.all_upayindex_sno.Contains((long)upayIndex.Sno))
        //                    {
        //                        this.all_upayindex_sno.Add((long)upayIndex.Sno);
        //                    }
        //                }
        //            }
        //        }
        //        this.all_upayindex_sno.Sort();
        //        str15 = string.Concat("\r\n\r\n", this.GetCodeLang("upayhelpbottom", persKV.Language, persKV.Paid, flag33), "\r\n");
        //        if ((persKV.Language.ToLower() == "hindi" || persKV.Language.ToLower() == "marathi" ? true : persKV.Language.ToLower() == "english"))
        //        {
        //            str15 = string.Concat(str15, "\r\n\r\n", this.GetCodeLang("upaybelow", persKV.Language, persKV.Paid, flag33), "\r\n");
        //        }
        //        foreach (short allUpayindexSno in this.all_upayindex_sno)
        //        {
        //            upayIndex = new UpayIndex();
        //            upayIndex = (new RuleDAO()).Get_UpayIndex(Convert.ToInt32(allUpayindexSno));
        //            if (persKV.Language.ToLower() == "hindi")
        //            {
        //                obj = str15;
        //                year1From = new object[] { obj, this.GetCodeLang("aa", persKV.Language, persKV.Paid, flag33), " ", this.GetCodeLang("upay", persKV.Language, persKV.Paid, flag33), " ", upayIndex.Sno, " ", this.GetCodeLang("aa", persKV.Language, persKV.Paid, flag33), "\r\n", upayIndex.Hindi.Trim(), "\r\n\r\n" };
        //                str15 = string.Concat(year1From);
        //            }
        //            if (persKV.Language.ToLower() == "marathi")
        //            {
        //                obj = str15;
        //                year1From = new object[] { obj, this.GetCodeLang("aa", persKV.Language, persKV.Paid, flag33), " ", this.GetCodeLang("upay", persKV.Language, persKV.Paid, flag33), " ", upayIndex.Sno, " ", this.GetCodeLang("aa", persKV.Language, persKV.Paid, flag33), "\r\n", upayIndex.Marathi.Trim(), "\r\n\r\n" };
        //                str15 = string.Concat(year1From);
        //            }
        //            if (persKV.Language.ToLower() == "english")
        //            {
        //                obj = str15;
        //                year1From = new object[] { obj, this.GetCodeLang("aa", persKV.Language, persKV.Paid, flag33), " ", this.GetCodeLang("upay", persKV.Language, persKV.Paid, flag33), " ", upayIndex.Sno, " ", this.GetCodeLang("aa", persKV.Language, persKV.Paid, flag33), "\r\n", upayIndex.Eng.Trim(), "\r\n\r\n" };
        //                str15 = string.Concat(year1From);
        //            }
        //        }
        //        string str16 = "";
        //        List<RulesVO> rulesVOs2 = new List<RulesVO>();
        //        rulesVOs2 = (
        //            from Map in this.generate_final_lrvgen(persKV, lkmv, false, new List<short>(), persKV.Language, "", false, false)
        //            where Map.RuleType == "khabar"
        //            select Map).ToList<RulesVO>();
        //        if (rulesVOs2 != null)
        //        {
        //            foreach (RulesVO rulesVO3 in rulesVOs2)
        //            {
        //                str16 = string.Concat(str16, this.Get_Pred_Text(rulesVO3.Sno, persKV.Language, true, true, persKV.ShowRef, false, persKV.Paid, false, flag33, persKV), "\r\n");
        //            }
        //            if (str16.Trim().Length > 0)
        //            {
        //                str15 = string.Concat(str15, this.GetCodeLang("Precautions", persKV.Language, persKV.Paid, flag33), "\r\n\r\n", str16);
        //            }
        //        }
        //    }
        //    if (persKV.Paid)
        //    {
        //        str1 = string.Concat("\r\n\r\n\r\n", this.GetCodeLang("upayhelp", persKV.Language, persKV.Paid, flag33));
        //    }
        //    string str17 = str1;
        //    string[] codeLang = new string[] { str17, this.GetCodeLang("shishu", persKV.Language, persKV.Paid, flag33), "\r\n", str7, "\r\n", this.GetCodeLang("bachpan", persKV.Language, persKV.Paid, flag33), "\r\n", str8, "\r\n", this.GetCodeLang("kishor", persKV.Language, persKV.Paid, flag33), "\r\n", str9, "\r\n", this.GetCodeLang("yuva", persKV.Language, persKV.Paid, flag33), "\r\n", str11, "\r\n", this.GetCodeLang("madhya", persKV.Language, persKV.Paid, flag33), "\r\n", str10, "\r\n", this.GetCodeLang("budhapa", persKV.Language, persKV.Paid, flag33), "\r\n", str12 };
        //    str1 = string.Concat(codeLang);
        //    str1 = string.Concat(str1, "\r\n\r\n", this.YICC_Category_Pred(persKV), "\r\n");
        //    if (persKV.Paid)
        //    {
        //        str1 = string.Concat(str1, "\r\n");
        //        str1 = string.Concat(str1, this.rin_pitri(persKV, lkmv));
        //        str1 = string.Concat(str1, "\r\n\r\n", this.GetMiscUpay(persKV, lkmv, persKV.ShowRef, persKV.Male, persKV.Language));
        //        str17 = str1;
        //        codeLang = new string[] { str17, "\r\n", str14, "\r\n", this.Get_Pred_Text((long)4371, persKV.Language, persKV.Male, true, persKV.ShowRef, false, persKV.Paid, true, flag33, persKV) };
        //        str1 = string.Concat(codeLang);
        //        str1 = string.Concat(str1, "\r\n\r\n", str15);
        //    }
        //    return str1;
        //}

        //public int yearsdiff(DateTime fromDate, DateTime toDate)
        //{
        //    int month;
        //    int year;
        //    int[] numArray = new int[] { 31, -1, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        //    if (!(toDate < fromDate))
        //    {
        //        int num = 0;
        //        if (fromDate.Day > toDate.Day)
        //        {
        //            num = numArray[fromDate.Month - 1];
        //        }
        //        if (fromDate.Month + num <= toDate.Month)
        //        {
        //            month = toDate.Month - (fromDate.Month + num);
        //            num = 0;
        //        }
        //        else
        //        {
        //            month = toDate.Month + 12 - (fromDate.Month + num);
        //            num = 1;
        //        }
        //        year = toDate.Year - (fromDate.Year + num);
        //    }
        //    else
        //    {
        //        year = -1;
        //    }
        //    return year;
        //}

        //public string YICC_Category_Pred(KundliVO persKV)
        //{
        //    List<KundliMappingVO> kundliMappingVOs = this.map_kundali(persKV.Online_Result, true);
        //    KundliBLL kundliBLL = new KundliBLL();
        //    kundliMappingVOs = kundliBLL.RotateKundliMappings(kundliMappingVOs, persKV.Rotate, persKV);
        //    List<KundliMappingVO> kundliMappingVOs1 = kundliMappingVOs;
        //    string str = "";
        //    string str1 = "";
        //    string language = persKV.Language;
        //    bool showRef = persKV.ShowRef;
        //    bool male = persKV.Male;
        //    bool paid = persKV.Paid;
        //    string str2 = "";
        //    RuleBLL ruleBLL = new RuleBLL();
        //    RuleDAO ruleDAO = new RuleDAO();
        //    int num = 0;
        //    PlanetBLL planetBLL = new PlanetBLL();
        //    RuleBLL ruleBLL1 = new RuleBLL();
        //    List<Life35VO> life35VOs = new List<Life35VO>();
        //    List<RulesVO> rulesVOs = new List<RulesVO>();
        //    List<RulesVO> list = new List<RulesVO>();
        //    KundliBLL kundliBLL1 = new KundliBLL();
        //    (
        //        from Rules in kundliBLL1.GetAdvancePredictions(kundliMappingVOs1, num, 0)
        //        where Rules.RuleType == "rinpitri"
        //        select Rules).ToList<RulesVO>();
        //    life35VOs = kundliBLL1.GetLife35(persKV.JanamSamay);
        //    IFormatProvider cultureInfo = new CultureInfo("en-CA", true);
        //    string[] dD = new string[] { persKV.DD, "/", persKV.MM, "/", persKV.YY };
        //    string str3 = string.Concat(dD);
        //    dD = new string[] { str3.ToString(), " ", persKV.HH, ":", persKV.MIN, ":00" };
        //    string.Concat(dD);
        //    if (persKV.Paid)
        //    {
        //        long lagna = persKV.Lagna;
        //        str2 = string.Concat(str2, "\r\n");
        //    }
        //    list = this.generate_final_lrvgen(persKV, kundliMappingVOs1, false, new List<short>(), language, "", false, false).ToList<RulesVO>();
        //    string predText = "";
        //    string str4 = "";
        //    string str5 = "";
        //    string str6 = "";
        //    string str7 = "";
        //    string str8 = "";
        //    string str9 = "";
        //    string str10 = "";
        //    string str11 = str5;
        //    dD = new string[] { str11, "\r\n", this.GetCodeLang("headmatapita", persKV.Language, persKV.Paid), " ", this.GetCodeLang("headgood", persKV.Language, persKV.Paid), "\r\n" };
        //    str5 = string.Concat(dD);
        //    str11 = str6;
        //    dD = new string[] { str11, "\r\n", this.GetCodeLang("headsantan", persKV.Language, persKV.Paid), " ", this.GetCodeLang("headgood", persKV.Language, persKV.Paid), "\r\n" };
        //    str6 = string.Concat(dD);
        //    str11 = str7;
        //    dD = new string[] { str11, "\r\n", this.GetCodeLang("headbhai", persKV.Language, persKV.Paid), " ", this.GetCodeLang("headgood", persKV.Language, persKV.Paid), "\r\n" };
        //    str7 = string.Concat(dD);
        //    str11 = str8;
        //    dD = new string[] { str11, "\r\n", this.GetCodeLang("headbimari", persKV.Language, persKV.Paid), " ", this.GetCodeLang("headgood", persKV.Language, persKV.Paid), "\r\n" };
        //    str8 = string.Concat(dD);
        //    str11 = str9;
        //    dD = new string[] { str11, "\r\n", this.GetCodeLang("headshadi", persKV.Language, persKV.Paid), " ", this.GetCodeLang("headgood", persKV.Language, persKV.Paid), "\r\n" };
        //    str9 = string.Concat(dD);
        //    str11 = str10;
        //    dD = new string[] { str11, "\r\n", this.GetCodeLang("headnaukri", persKV.Language, persKV.Paid), " ", this.GetCodeLang("headgood", persKV.Language, persKV.Paid), "\r\n" };
        //    str10 = string.Concat(dD);
        //    string str12 = "";
        //    string str13 = "";
        //    string str14 = "";
        //    string str15 = "";
        //    string str16 = "";
        //    string str17 = "";
        //    str11 = str12;
        //    dD = new string[] { str11, "\r\n", this.GetCodeLang("headmatapita", persKV.Language, persKV.Paid), " ", this.GetCodeLang("headbad", persKV.Language, persKV.Paid), "\r\n" };
        //    str12 = string.Concat(dD);
        //    str11 = str13;
        //    dD = new string[] { str11, "\r\n", this.GetCodeLang("headsantan", persKV.Language, persKV.Paid), " ", this.GetCodeLang("headbad", persKV.Language, persKV.Paid), "\r\n" };
        //    str13 = string.Concat(dD);
        //    str11 = str14;
        //    dD = new string[] { str11, "\r\n", this.GetCodeLang("headbhai", persKV.Language, persKV.Paid), " ", this.GetCodeLang("headbad", persKV.Language, persKV.Paid), "\r\n" };
        //    str14 = string.Concat(dD);
        //    str11 = str15;
        //    dD = new string[] { str11, "\r\n", this.GetCodeLang("headbimari", persKV.Language, persKV.Paid), " ", this.GetCodeLang("headbad", persKV.Language, persKV.Paid), "\r\n" };
        //    str15 = string.Concat(dD);
        //    str11 = str16;
        //    dD = new string[] { str11, "\r\n", this.GetCodeLang("headshadi", persKV.Language, persKV.Paid), " ", this.GetCodeLang("headbad", persKV.Language, persKV.Paid), "\r\n" };
        //    str16 = string.Concat(dD);
        //    str11 = str17;
        //    dD = new string[] { str11, "\r\n", this.GetCodeLang("headnaukri", persKV.Language, persKV.Paid), " ", this.GetCodeLang("headbad", persKV.Language, persKV.Paid), "\r\n" };
        //    str17 = string.Concat(dD);
        //    int length = str5.Length + 1;
        //    int length1 = str6.Length + 1;
        //    int num1 = str7.Length + 1;
        //    int length2 = str8.Length + 1;
        //    int num2 = str9.Length + 1;
        //    int length3 = str10.Length + 1;
        //    int num3 = str12.Length + 1;
        //    int length4 = str13.Length + 1;
        //    int num4 = str14.Length + 1;
        //    int length5 = str15.Length + 1;
        //    int num5 = str16.Length + 1;
        //    int length6 = str17.Length + 1;
        //    RuleDAO ruleDAO1 = new RuleDAO();
        //    if (list != null)
        //    {
        //        foreach (RulesVO rulesVO in list)
        //        {
        //            if (paid)
        //            {
        //                predText = this.Get_Pred_Text(rulesVO.Sno, language, male, true, showRef, false, paid, true, false, persKV);
        //            }
        //            if ((!rulesVO.Mother_father ? false : !rulesVO.Isbad))
        //            {
        //                str5 = string.Concat(str5, predText);
        //            }
        //            if ((!rulesVO.Mother_father ? false : rulesVO.Isbad))
        //            {
        //                str12 = string.Concat(str12, predText);
        //            }
        //            if ((!rulesVO.Santan ? false : !rulesVO.Isbad))
        //            {
        //                str6 = string.Concat(str6, predText);
        //            }
        //            if ((!rulesVO.Santan ? false : rulesVO.Isbad))
        //            {
        //                str13 = string.Concat(str13, predText);
        //            }
        //            if ((!rulesVO.Brother ? false : !rulesVO.Isbad))
        //            {
        //                str7 = string.Concat(str7, predText);
        //            }
        //            if ((!rulesVO.Brother ? false : rulesVO.Isbad))
        //            {
        //                str14 = string.Concat(str14, predText);
        //            }
        //            if ((!rulesVO.Disease ? false : !rulesVO.Isbad))
        //            {
        //                str8 = string.Concat(str8, predText);
        //            }
        //            if ((!rulesVO.Disease ? false : rulesVO.Isbad))
        //            {
        //                str15 = string.Concat(str15, predText);
        //            }
        //            if ((!rulesVO.Marriedlife ? false : !rulesVO.Isbad))
        //            {
        //                str9 = string.Concat(str9, predText);
        //            }
        //            if ((!rulesVO.Marriedlife ? false : rulesVO.Isbad))
        //            {
        //                str16 = string.Concat(str16, predText);
        //            }
        //            if ((!rulesVO.Occupation ? false : !rulesVO.Isbad))
        //            {
        //                str10 = string.Concat(str10, predText);
        //            }
        //            if ((!rulesVO.Occupation ? false : rulesVO.Isbad))
        //            {
        //                str17 = string.Concat(str17, predText);
        //            }
        //        }
        //    }
        //    if (str5.Trim().Length > length)
        //    {
        //        str4 = string.Concat(str4, "\r\n", str5);
        //    }
        //    if (str12.Trim().Length > num3)
        //    {
        //        str4 = string.Concat(str4, "\r\n", str12, "\r\n");
        //    }
        //    if (str6.Trim().Length > length1)
        //    {
        //        str4 = string.Concat(str4, "\r\n", str6);
        //    }
        //    if (str13.Trim().Length > length4)
        //    {
        //        str4 = string.Concat(str4, "\r\n", str13, "\r\n");
        //    }
        //    if (str7.Trim().Length > num1)
        //    {
        //        str4 = string.Concat(str4, "\r\n", str7);
        //    }
        //    if (str14.Trim().Length > num4)
        //    {
        //        str4 = string.Concat(str4, "\r\n", str14, "\r\n");
        //    }
        //    if (str8.Trim().Length > length2)
        //    {
        //        str4 = string.Concat(str4, "\r\n", str8);
        //    }
        //    if (str15.Trim().Length > length5)
        //    {
        //        str4 = string.Concat(str4, "\r\n", str15, "\r\n");
        //    }
        //    if (str9.Trim().Length > num2)
        //    {
        //        str4 = string.Concat(str4, "\r\n\r\n", str9);
        //    }
        //    if (str16.Trim().Length > num5)
        //    {
        //        str4 = string.Concat(str4, "\r\n", str16, "\r\n");
        //    }
        //    if (str10.Trim().Length > length3)
        //    {
        //        str4 = string.Concat(str4, "\r\n", str10);
        //    }
        //    if (str17.Trim().Length > length6)
        //    {
        //        str4 = string.Concat(str4, "\r\n", str17, "\r\n");
        //    }
        //    if (!(persKV.Language.ToLower() == "hindi"))
        //    {
        //        str2 = string.Concat(str2, str4);
        //    }
        //    else
        //    {
        //        str2 = (str.Trim().Length > 0 ? string.Concat(str2, str4) : string.Concat(str2, str4, str1));
        //    }
        //    string _videsh = "";
        //    _videsh = this.get_videsh(persKV, kundliMappingVOs);
        //    if (_videsh.Trim().Length >= 5)
        //    {
        //        str2 = string.Concat(str2, _videsh);
        //    }
        //    return str2;
        //}
    }
}