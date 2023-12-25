using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AstroOfficeWeb.Shared.VOs;
//using AstroShared.Models;
using Kunda;
namespace ASDLL.DataAccess.Core
{
    public class KPPredBLL
    {
        private List<long> all_upayindex_sno = new List<long>();

        private long prev_umra = (long)0;

        private List<string> jad_method_planet_used = new List<string>();

        private List<string> umra_method_planet_used = new List<string>();

        public static List<KPRemediesVO> Remedy_List_VFAL;

        static KPPredBLL()
        {
            KPPredBLL.Remedy_List_VFAL = new List<KPRemediesVO>();
            KPPredBLL.Remedy_List_VFAL = (new KPDAO()).Get_Remedies("vfal");
        }

        public KPPredBLL()
        {
        }

        public string Get_DashaWise_Talak_ShadiYog(List<KPPlanetMappingVO> kp_chart, List<KPHouseMappingVO> cusp_house, KundliVO persKV, bool include, ProductSettingsVO prod)
        {
            string str;
            string str1 = "";
            List<string> strs = new List<string>();
            PredictionBLL predictionBLL = new PredictionBLL();
            List<KPDashaVO> kPDashaVOs = new List<KPDashaVO>();
            List<KPDashaVO> antarDasha = new List<KPDashaVO>();
            List<KPDashaVO> kPDashaVOs1 = new List<KPDashaVO>();
            DateTime dateTime = new DateTime();
            KPBLL kPBLL = new KPBLL();
            List<KPDashafalChainVO> kPDashafalChainVOs = new List<KPDashafalChainVO>();
            KPDAO kPDAO = new KPDAO();
            kPDashaVOs = kPBLL.Get_Dasha(cusp_house, kp_chart, persKV, include);
            persKV.Dob.AddYears(20);
            foreach (KPDashaVO kPDashaVO in kPDashaVOs)
            {
                antarDasha = kPBLL.Get_Antar_Dasha(kPDashaVO.StartDate, kPDashaVO.EndDate, kPDashaVO.Planet, kp_chart, include);
                antarDasha = (
                    from Map in antarDasha
                    where Map.EndDate >= persKV.Dob.AddYears(18)
                    select Map).ToList<KPDashaVO>();
                short house = (
                    from Map in kp_chart
                    where Map.Planet == kPDashaVO.Planet
                    select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                foreach (KPDashaVO kPDashaVO1 in antarDasha)
                {
                    short num = Convert.ToInt16(predictionBLL.CalculateAgeCorrect(persKV.Dob, dateTime));
                    short bhavChalitHouse = (
                        from Map in kp_chart
                        where Map.Planet == kPDashaVO1.Planet
                        select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
                    DateTime startDate = kPDashaVO1.StartDate;
                    DateTime endDate = kPDashaVO1.EndDate;
                    if (num < 60)
                    {
                        dateTime = endDate;
                        string[] strArrays = new string[] { startDate.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", startDate.ToString("%M")), persKV.Language, persKV.Paid, true), " ", startDate.ToString("yyyy") };
                        string str2 = string.Concat(strArrays);
                        strArrays = new string[] { endDate.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", endDate.ToString("%M")), persKV.Language, persKV.Paid, true), " ", endDate.ToString("yyyy") };
                        string str3 = string.Concat(strArrays);
                        List<KPMixDashaVO> kPMixDashaVOs = new List<KPMixDashaVO>();
                        kPMixDashaVOs = (
                            from Map in kPDAO.Get_Mix_Dasha(kPDashaVO1.Planet, bhavChalitHouse, 1, prod.Product, "fullyog").ToList<KPMixDashaVO>()
                            where Map.married_life
                            select Map).ToList<KPMixDashaVO>();
                        kPMixDashaVOs.AddRange((
                            from Map in kPDAO.Get_Mix_Dasha(kPDashaVO1.Planet, bhavChalitHouse, 1, prod.Product, "fullyuti").ToList<KPMixDashaVO>()
                            where Map.married_life
                            select Map).ToList<KPMixDashaVO>());
                        kPMixDashaVOs.AddRange((
                            from Map in kPDAO.Get_Mix_Dasha(kPDashaVO1.Planet, bhavChalitHouse, 1, prod.Product, "fulltriangle")
                            where Map.married_life
                            select Map).ToList<KPMixDashaVO>());
                        kPMixDashaVOs.AddRange(kPDAO.Get_Mix_Dasha(kPDashaVO1.Planet, bhavChalitHouse, 1, "married_life", "dasha").ToList<KPMixDashaVO>());
                        kPMixDashaVOs.AddRange((
                            from Map in kPDAO.Get_Mix_Dasha(kPDashaVO1.Planet, bhavChalitHouse, 1, "all", "yuti").ToList<KPMixDashaVO>()
                            where Map.married_life
                            select Map).ToList<KPMixDashaVO>());
                        foreach (KPMixDashaVO kPMixDashaVO in kPMixDashaVOs)
                        {
                            short house1 = 0;
                            house1 = (
                                from Map in kp_chart
                                where Map.Planet == kPMixDashaVO.Planet1
                                select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                            KPRemediesVO kPRemediesVO = new KPRemediesVO();
                            if (kPBLL.isAllConditionMet(kPMixDashaVO, kp_chart, bhavChalitHouse.ToString(), kPMixDashaVO.ptype.ToLower()))
                            {
                                if (!strs.Contains(string.Concat(str2, str3)))
                                {
                                    str1 = string.Concat(str1, kPBLL.ScoreTY(kPDashaVO1.Planet, kPMixDashaVO.ShadiYog, kPMixDashaVO.Talak, kPMixDashaVO.verybad, "Y", startDate, endDate, prod, persKV, kp_chart, cusp_house, kPDashaVO1.Signi_String, kPDashaVO1.Nak_Signi_String, num));
                                }
                                strs.Add(string.Concat(str2, str3));
                            }
                        }
                    }
                    else
                    {
                        str = str1;
                        return str;
                    }
                }
            }
            str = str1;
            return str;
        }

        public string Get_mfal_marking(List<KPPlanetMappingVO> lkmv, short year, List<short> months, KundliVO persKV, ProductSettingsVO prod)
        {
            //KPPredBLL.<>c__DisplayClass9 variable;
            //KPPredBLL.<>c__DisplayClass7 variable1;
            string str = "";
            //long num = (long)0;
            DateTime dateTime = new DateTime();
            DateTime dateTime1 = new DateTime();
            List<KPPlanetMappingVO> kPPlanetMappingVOs = new List<KPPlanetMappingVO>();
            PredictionBLL predictionBLL = new PredictionBLL();
            GetPlanetVO getPlanetVO = new GetPlanetVO();
            KundliBLL kundliBLL = new KundliBLL();
            RuleBLL ruleBLL = new RuleBLL();
            string str1 = "";
            foreach (short month in months)
            {
                kPPlanetMappingVOs = kundliBLL.NEW_GetMonthlyKundli(year, month, persKV, lkmv);
                DateTime dob = persKV.Dob;
                dob = dob.AddYears(year - 1);
                dateTime = dob.AddMonths(month - 1);
                dob = persKV.Dob;
                dob = dob.AddYears(year - 1);
                dob = dob.AddMonths(month);
                dateTime1 = dob.AddDays(-1);
                Years35BLL years35BLL = new Years35BLL();
                PlanetBLL planetBLL = new PlanetBLL();
                List<Years35VO> years35VOs = years35BLL.Get35Years(persKV.JanamSamay);
                KPBLL kPBLL = new KPBLL();
                List<KPPlanetsVO> kPPlanetsVOs = kPBLL.Fill_Planets();
                string str2 = (
                    from map in years35VOs
                    where map.Years == (long)year
                    select map).FirstOrDefault<Years35VO>().Planet.ToString();
                List<short> nums = new List<short>();
                short planet = (
                    from Map in kPPlanetsVOs
                    where Map.Roman == str2
                    select Map).FirstOrDefault<KPPlanetsVO>().Planet;
                short house = (
                    from lk in kPPlanetMappingVOs
                    where lk.Planet == planet
                    select lk).FirstOrDefault<KPPlanetMappingVO>().House;
                nums = this.Pakka_House_Wala_Planet(house);
                long num1 = (long)0;
                if ((house == 1 || house == 7 || house == 4 ? true : house == 10))
                {
                    num1 = (long)((house + 6) % 12);
                }
                short num2 = 0;
                List<KPMixDashaVO> kPMixDashaVOs = new List<KPMixDashaVO>();
                KPDAO kPDAO = new KPDAO();
                kPMixDashaVOs = kPDAO.Get_Mix_Dasha(1, 1, 0, "", "all_monthfal");
                bool result = false;
                foreach (KPPlanetMappingVO kPPlanetMappingVO in kPPlanetMappingVOs)
                {
                    //num = (long)0;
                    List<KPMixDashaVO> list = new List<KPMixDashaVO>();
                    list = (
                        from Map in kPMixDashaVOs
                        where (Map.Planet1 != kPPlanetMappingVO.Planet || Map.House1 != kPPlanetMappingVO.House ? false : Map.Isbad == kPPlanetMappingVO.isbad)
                        select Map).ToList<KPMixDashaVO>();


                    //result = (years35VOs.Where(years35VO => 
                    //    years35VO.Years == year
                    //    && years35VO.Period.Contains(kPPlanetsVOs[kPPlanetMappingVO.Planet - 1].Roman)
                    //    && kPPlanetsVOs.Any(kPPlanetsVO => 
                    //        kPPlanetsVO.Roman == years35VO.Planet 
                    //        && kPPlanetsVO.Planet == kPPlanetMappingVO.Planet)).Count() >= 1)
                    //|| (nums.Contains(kPPlanetMappingVO.Planet))
                    //|| (kPPlanetMappingVO.House == num1);


                    result = (Convert.ToInt64(years35VOs.Where<Years35VO>(Map =>
                            Map.Years == year
                            && Map.Period.Contains(kPPlanetsVOs[kPPlanetMappingVO.Planet - 1].Roman)
                            && (from Map1 in kPPlanetsVOs where Map1.Roman == Map.Planet select Map1).FirstOrDefault<KPPlanetsVO>().Planet == kPPlanetMappingVO.Planet).Count<Years35VO>()) >= 1
                        || nums.Contains(kPPlanetMappingVO.Planet)
                        || (long)kPPlanetMappingVO.House == num1);

                    if (result)
                    //if ((Convert.ToInt64(years35VOs.Where<Years35VO>((Years35VO Map) => return (Map.Years != (long)year ? false : (Map.Period.Contains(kPPlanetsVOs[kPPlanetMappingVO.Planet - 1].Roman) ? true : (
                    //from Map1 in kPPlanetsVOs
                    //where Map1.Roman == Map.Planet
                    //select Map1).FirstOrDefault<KPPlanetsVO>().Planet == kPPlanetMappingVO.Planet))).Count<Years35VO>()) >= (long)1 || nums.Contains(kPPlanetMappingVO.Planet) ? true : (long)kPPlanetMappingVO.House == num1))
                    {
                        if (num2 != year)
                        {
                            str1 = string.Concat(str1, "\r\n\r\n");
                            string str3 = str1;
                            string[] strArrays = new string[] { str3, "<B>", dateTime.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", dateTime.ToString("%M")), persKV.Language, persKV.Paid, true), " ", dateTime.ToString("yyyy"), predictionBLL.GetCodeLang("to", persKV.Language, true, true), dateTime1.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", dateTime1.ToString("%M")), persKV.Language, persKV.Paid, true), " ", dateTime1.ToString("yyyy"), " ", predictionBLL.GetCodeLang("monthend", persKV.Language, true, true), "</B>" };
                            str1 = string.Concat(strArrays);
                        }
                        num2 = year;
                        foreach (KPMixDashaVO kPMixDashaVO in list)
                        {
                            str = "";
                            if (persKV.ShowRef)
                            {
                                short sno = kPMixDashaVO.Sno;
                                str = string.Concat("-", sno.ToString(), "-");
                            }
                            str = (year < 18 ? string.Concat(str, kPBLL.Get_KP_Lang(kPMixDashaVO.Sno, persKV.Language, false, false, false)) : string.Concat(str, kPBLL.Get_KP_Lang(kPMixDashaVO.Sno, persKV.Language, false, false, false)));
                            str1 = string.Concat(str1, str);
                        }
                        str1 = string.Concat(str1, "\r\n\r\n");
                    }
                }
            }
            return str1;
        }

        public string Get_Red_Signi(List<KPPlanetMappingVO> kp_chart, List<KPHouseMappingVO> cusp_house, ProductSettingsVO prod, KundliVO persKV)
        {
            string str = "";
            KPDAO kPDAO = new KPDAO();
            string signiString = "";
            KPBLL kPBLL = new KPBLL();
            List<KPMixDashaVO> kPMixDashaVOs = new List<KPMixDashaVO>();
            kPMixDashaVOs = kPDAO.Get_Mix_Dasha(1, 1, 1, "", "redsigni");
            foreach (KPPlanetMappingVO kpChart in kp_chart)
            {
                signiString = kPBLL.Get_Signi_String(kpChart.Nak_Lord, kp_chart, false);
                char[] chrArray = new char[] { ' ' };
                string[] strArrays = signiString.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                foreach (KPMixDashaVO list in (
                    from Map in kPMixDashaVOs
                    where Map.Planet1 == kpChart.Planet
                    select Map).ToList<KPMixDashaVO>())
                {
                    bool flag = true;
                    string signi = list.Signi;
                    chrArray = new char[] { ',' };
                    string[] strArrays1 = signi.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                    int num = 0;
                    while (num < (int)strArrays1.Length)
                    {
                        if (strArrays.Contains<string>(strArrays1[num].Trim()))
                        {
                            num++;
                        }
                        else
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        if (persKV.ShowRef)
                        {
                            object obj = str;
                            object[] nakLord = new object[] { obj, null, null, null, null, null, null, null, null, null, null };
                            short planet = kpChart.Planet;
                            nakLord[1] = planet.ToString();
                            nakLord[2] = ":";
                            nakLord[3] = kpChart.Nak_Lord;
                            nakLord[4] = " ( Pred Signi:";
                            nakLord[5] = list.Signi;
                            nakLord[6] = ", Planet Signi:";
                            nakLord[7] = signiString;
                            nakLord[8] = ") [Red Signi : ";
                            planet = list.Sno;
                            nakLord[9] = planet.ToString();
                            nakLord[10] = " ] ";
                            str = string.Concat(nakLord);
                        }
                        str = string.Concat(str, kPBLL.Get_KP_Lang(list.Sno, persKV.Language, false, false, prod.Mini), "\r\n\r\n");
                    }
                }
            }
            return str;
        }

        public string Get_Red_Signi_PlanetWise(List<KPPlanetMappingVO> kp_chart, List<KPHouseMappingVO> cusp_house, ProductSettingsVO prod, KundliVO persKV, short planet)
        {
            string str = "";
            KPDAO kPDAO = new KPDAO();
            List<short> nums = new List<short>();
            List<short> nums1 = new List<short>();
            string signiString = "";
            KPBLL kPBLL = new KPBLL();
            List<KPMixDashaVO> kPMixDashaVOs = new List<KPMixDashaVO>();
            List<KPMixDashaVO> mixDasha = new List<KPMixDashaVO>();
            kPMixDashaVOs = kPDAO.Get_Mix_Dasha(1, 1, 1, "", "redsigni");
            mixDasha = kPDAO.Get_Mix_Dasha(1, 1, 1, "", "restredsigni");
            foreach (KPPlanetMappingVO list in (
                from Map in kp_chart
                where Map.Planet == planet
                select Map).ToList<KPPlanetMappingVO>())
            {
                nums1 = new List<short>();
                signiString = kPBLL.Get_Signi_String(list.Nak_Lord, kp_chart, false);
                char[] chrArray = new char[] { ' ' };
                string[] strArrays = signiString.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                bool flag = true;
                foreach (KPMixDashaVO kPMixDashaVO in (
                    from Map in kPMixDashaVOs
                    where Map.Planet1 == list.Planet
                    select Map).ToList<KPMixDashaVO>())
                {
                    flag = true;
                    string signi = kPMixDashaVO.Signi;
                    chrArray = new char[] { ',' };
                    string[] strArrays1 = signi.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                    int num = 0;
                    while (num < (int)strArrays1.Length)
                    {
                        if (strArrays.Contains<string>(strArrays1[num].Trim()))
                        {
                            num++;
                        }
                        else
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        if (!nums.Exists((short Map) => Map == kPMixDashaVO.Sno))
                        {
                            if (persKV.ShowRef)
                            {
                                object obj = str;
                                object[] nakLord = new object[] { obj, null, null, null, null, null, null, null, null, null, null };
                                short sno = list.Planet;
                                nakLord[1] = sno.ToString();
                                nakLord[2] = ":";
                                nakLord[3] = list.Nak_Lord;
                                nakLord[4] = " ( Pred Signi:";
                                nakLord[5] = kPMixDashaVO.Signi;
                                nakLord[6] = ", Planet Signi:";
                                nakLord[7] = signiString;
                                nakLord[8] = ") [Red Signi : ";
                                sno = kPMixDashaVO.Sno;
                                nakLord[9] = sno.ToString();
                                nakLord[10] = " ] ";
                                str = string.Concat(nakLord);
                            }
                            str = string.Concat(str, kPBLL.Get_KP_Lang(kPMixDashaVO.Sno, persKV.Language, false, false, prod.Mini), "\r\n\r\n");
                        }
                        nums.Add(kPMixDashaVO.Sno);
                    }
                }
            }
            return str;
        }

        public string Get_Talak_ShadiYog(List<KPPlanetMappingVO> kp_chart, List<KPHouseMappingVO> cusp_house, ProductSettingsVO prod, KundliVO persKV)
        {
            return "";
        }

        public string Get_VarshFal_Predictions(KundliVO persKV, List<short> Varshfal_years, List<KundliMappingVO> lkmv, List<short> months, ProductSettingsVO prod)
        {
            int house;
            string str;
            bool male = prod.Male;
            bool flag = true;
            string lang = prod.Lang;
            bool paid = persKV.Paid;
            string dD = persKV.DD;
            string mM = persKV.MM;
            string yY = persKV.YY;
            string hH = persKV.HH;
            string mIN = persKV.MIN;
            bool showRef = prod.ShowRef;
            bool flag1 = true;
            if (prod.NoCategory)
            {
                paid = false;
            }
            PredictionBLL predictionBLL = new PredictionBLL();
            List<KundliMappingVO> kundliMappingVOs = new List<KundliMappingVO>();
            KundliBLL kundliBLL = new KundliBLL();
            string str1 = "";
            List<RulesVO> rulesVOs = new List<RulesVO>();
            rulesVOs = predictionBLL.generate_final_lrvgen(persKV, lkmv, true, Varshfal_years, lang, "", false, false);
            DateTime dateTime = new DateTime();
            DateTime dateTime1 = new DateTime();
            foreach (short varshfalYear in Varshfal_years)
            {
                kundliMappingVOs = kundliBLL.GetVarshaphalKundliMapping(varshfalYear, persKV, lkmv);
                if (persKV.Paid)
                {
                    str1 = string.Concat(str1, "\r\n");
                    DateTime dob = persKV.Dob;
                    dateTime = dob.AddYears(varshfalYear - 1);
                    dob = persKV.Dob;
                    dob = dob.AddYears(varshfalYear);
                    dateTime1 = dob.AddDays(-1);
                    string str2 = str1;
                    string[] strArrays = new string[] { str2, "<B>", dateTime.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", dateTime.ToString("%M")), persKV.Language, persKV.Paid, true), " ", dateTime.ToString("yyyy"), predictionBLL.GetCodeLang("to", persKV.Language, true, true), dateTime1.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", dateTime1.ToString("%M")), persKV.Language, persKV.Paid, true), " ", dateTime1.ToString("yyyy"), " ", predictionBLL.GetCodeLang("yearend", persKV.Language, true, true), "</B>" };
                    str1 = string.Concat(strArrays);
                    str1 = string.Concat(str1, "\r\n\r\n");
                    foreach (KundliMappingVO kundliMappingVO in kundliMappingVOs)
                    {
                        string str3 = str1;
                        if (kundliMappingVO.VIsBad)
                        {
                            strArrays = new string[] { predictionBLL.GetCodeLang(kundliMappingVO.PlanetNameEnglish, lang, paid, flag1).ToString(), " ", null, null, null, null };
                            house = kundliMappingVO.House;
                            strArrays[2] = house.ToString();
                            strArrays[3] = " ";
                            strArrays[4] = predictionBLL.GetCodeLang("Bad", lang, paid, flag1).ToString();
                            strArrays[5] = "\r\n";
                            str = string.Concat(strArrays);
                        }
                        else
                        {
                            strArrays = new string[] { predictionBLL.GetCodeLang(kundliMappingVO.PlanetNameEnglish, lang, paid, flag1).ToString(), " ", null, null, null, null };
                            house = kundliMappingVO.House;
                            strArrays[2] = house.ToString();
                            strArrays[3] = " ";
                            strArrays[4] = predictionBLL.GetCodeLang("Good", lang, paid, flag1).ToString();
                            strArrays[5] = "\r\n";
                            str = string.Concat(strArrays);
                        }
                        str1 = string.Concat(str3, str);
                    }
                }
                str1 = string.Concat(str1, "\r\n");
                str1 = string.Concat(str1, this.GetVarshFal(persKV, lkmv, kundliMappingVOs, varshfalYear, showRef, flag, male, persKV.JanamSamay, lang, paid));
                foreach (RulesVO list in (
                    from Map in rulesVOs
                    where Map.VfalYears.Split(new char[] { ',' }).ToArray<string>().Contains<string>(varshfalYear.ToString())
                    select Map).ToList<RulesVO>())
                {
                    str1 = string.Concat(str1, predictionBLL.Get_Pred_Text(list.Sno, lang, male, true, showRef, false, paid, true, flag1, persKV));
                    RulesVO rulesVO = new RulesVO();
                    RuleDAO ruleDAO = new RuleDAO();
                    RuleBLL ruleBLL = new RuleBLL();
                    if (!prod.NoCategory)
                    {
                        rulesVO = ruleBLL.GetAdvanceRuleById(list.Sno);
                        UpayIndex upayIndex = new UpayIndex();
                        upayIndex = ruleDAO.Get_UpayIndex(Convert.ToInt32(rulesVO.Upay));
                        if (upayIndex != null)
                        {
                            if (rulesVO.Upay > 0)
                            {
                                if (!this.all_upayindex_sno.Contains((long)upayIndex.Sno))
                                {
                                    this.all_upayindex_sno.Add((long)upayIndex.Sno);
                                }
                            }
                        }
                    }
                }
                if ((!paid ? false : persKV.Product.ToLower() != "free"))
                {
                    str1 = string.Concat(str1, this.GetVarshFal_35years(lkmv, varshfalYear, showRef, flag, male, persKV.JanamSamay, lang, persKV, prod));
                }
                if (persKV.Mfal)
                {
                    str1 = string.Concat(str1, "\r\n", this.GetMonthFal(persKV, lkmv, varshfalYear, months, persKV.ShowRef, true, persKV.Male, persKV.JanamSamay, persKV.Language, paid, prod));
                }
            }
            return str1;
        }

        public string GetMonthFal(KundliVO perskv, List<KundliMappingVO> lkmv, short year, List<short> months, bool showref, bool marking, bool male, string janamsamay, string lang, bool paid, ProductSettingsVO prod)
        {
            //RulesVO rulesVO = null;
            bool house;
            string str = "";
            long num = (long)0;
            bool isBad = false;
            //bool flag = true;
            DateTime dateTime = new DateTime();
            DateTime dateTime1 = new DateTime();
            List<KundliMappingVO> kundliMappingVOs = new List<KundliMappingVO>();
            PredictionBLL predictionBLL = new PredictionBLL();
            GetPlanetVO getPlanetVO = new GetPlanetVO();
            KundliBLL kundliBLL = new KundliBLL();
            RuleBLL ruleBLL = new RuleBLL();
            string str1 = "";
            bool flag1 = true;
            if (prod.NoCategory)
            {
                //flag = false;
                paid = false;
            }
            foreach (short month in months)
            {
                kundliMappingVOs = kundliBLL.GetMonthlyKundli(year, month, perskv, lkmv);
                DateTime dob = perskv.Dob;
                dob = dob.AddYears(year - 1);
                dateTime = dob.AddMonths(month - 1);
                dob = perskv.Dob;
                dob = dob.AddYears(year - 1);
                dob = dob.AddMonths(month);
                dateTime1 = dob.AddDays(-1);
                ruleBLL.CalcKundliPlanets(kundliMappingVOs);
                int num1 = 2;
                Years35BLL years35BLL = new Years35BLL();
                PlanetBLL planetBLL = new PlanetBLL();
                List<Years35VO> years35VOs = years35BLL.Get35Years(janamsamay);
                string str2 = (
                    from map in years35VOs
                    where map.Years == (long)year
                    select map).FirstOrDefault<Years35VO>().Planet.ToString();
                List<PlanetHouseMappingVO> planetHouseMappingVOs = new List<PlanetHouseMappingVO>();
                long house1 = (long)(
                    from lk in kundliMappingVOs
                    where lk.PlanetName.Equals(str2)
                    select lk).FirstOrDefault<KundliMappingVO>().House;
                planetHouseMappingVOs = (
                    from pk in planetBLL.GetPakkeGhar()
                    where (long)pk.House == house1
                    select pk).ToList<PlanetHouseMappingVO>();
                long num2 = (long)0;
                if ((house1 == (long)1 || house1 == (long)7 || house1 == (long)4 ? true : house1 == (long)10))
                {
                    num2 = (house1 + (long)6) % (long)12;
                }
                short num3 = 0;
                foreach (KundliMappingVO kundliMappingVO in kundliMappingVOs)
                {
                    num = (long)0;
                    List<RulesVO> list = (
                        from Rules in kundliBLL.GetAdvancePredictions(kundliMappingVOs, kundliMappingVO.Planet, num1)
                        where (Rules.Isbad != kundliMappingVO.VIsBad ? false : Rules.RuleType == "mfal")
                        select Rules).ToList<RulesVO>();
                    num = Convert.ToInt64((
                        from Map in years35VOs
                        where (Map.Years != (long)year ? false : (Map.Period.Contains(kundliMappingVO.PlanetName) ? true : Map.Planet == kundliMappingVO.PlanetName))
                        select Map).Count<Years35VO>());
                    if (num > (long)0)
                    {
                        isBad = (
                            from Map in lkmv
                            where Map.PlanetName == kundliMappingVO.PlanetName
                            select Map).SingleOrDefault<KundliMappingVO>().IsBad;
                    }
                    if (num < (long)1)
                    {
                        if ((
                            from pp in planetHouseMappingVOs
                            where pp.Planet == kundliMappingVO.Planet
                            select pp).Count<PlanetHouseMappingVO>() > 0)
                        {
                            goto Label1;
                        }
                        house = (long)kundliMappingVO.House != num2;
                        goto Label0;
                    }
                    Label1:
                    house = false;
                    Label0:
                    if (!house)
                    {
                        if (num3 != year)
                        {
                            str1 = string.Concat(str1, "\r\n\r\n");
                            string str3 = str1;
                            string[] strArrays = new string[] { str3, "<B>", dateTime.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", dateTime.ToString("%M")), perskv.Language, perskv.Paid, true), " ", dateTime.ToString("yyyy"), predictionBLL.GetCodeLang("to", perskv.Language, true, true), dateTime1.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", dateTime1.ToString("%M")), perskv.Language, perskv.Paid, true), " ", dateTime1.ToString("yyyy"), " ", predictionBLL.GetCodeLang("monthend", perskv.Language, true, true), "</B>" };
                            str1 = string.Concat(strArrays);
                        }
                        num3 = year;
                        if (marking)
                        {
                            foreach (RulesVO rulesVO in list)
                            {
                                str = (year < 18 ? predictionBLL.Get_Pred_Text(rulesVO.Sno, lang, male, false, showref, true, paid, true, flag1, perskv) : predictionBLL.Get_Pred_Text(rulesVO.Sno, lang, male, true, showref, true, paid, true, flag1, perskv));
                                str = string.Concat(str, "\r\n");
                                if (!showref)
                                {
                                    str1 = string.Concat(str1, str);
                                }
                                else
                                {
                                    object obj = str1;
                                    object[] sno = new object[] { obj, str, "   ", rulesVO.Sno, "  ", ruleBLL.GetPlanetByRuleNo(rulesVO.Sno).Planet, " ", ruleBLL.GetPlanetByRuleNo(rulesVO.Sno).House, " ", rulesVO.Reference };
                                    str1 = string.Concat(sno);
                                }
                            }
                        }
                    }
                    if (!marking)
                    {
                        foreach (RulesVO rulesVO1 in list)
                        {
                            str = (year < 18 ? predictionBLL.Get_Pred_Text(rulesVO1.Sno, lang, male, false, showref, true, paid, true, flag1, perskv) : predictionBLL.Get_Pred_Text(rulesVO1.Sno, lang, male, true, showref, true, paid, true, flag1, perskv));
                            str = string.Concat(str, "\r\n");
                            str1 = string.Concat(str1, str);
                            str1 = string.Concat(str1, "\r\n");
                        }
                    }
                }
            }
            return str1;
        }

        private string GetVarshFal(KundliVO perskv, List<KundliMappingVO> lkmv, List<KundliMappingVO> VVlkmv, short year, bool showref, bool marking, bool male, string janamsamay, string lang, bool paid)
        {
            //RulesVO rulesVO = null;
            bool house;
            PredictionBLL predictionBLL = new PredictionBLL();
            string str = "";
            long num = (long)0;
            bool isBad = false;
            short num1 = 0;
            GetPlanetVO getPlanetVO = new GetPlanetVO();
            KundliBLL kundliBLL = new KundliBLL();
            RuleBLL ruleBLL = new RuleBLL();
            string str1 = "";
            ruleBLL.CalcKundliPlanets(VVlkmv);
            bool flag = true;
            int num2 = 2;
            Years35BLL years35BLL = new Years35BLL();
            PlanetBLL planetBLL = new PlanetBLL();
            List<Years35VO> years35VOs = years35BLL.Get35Years(janamsamay);
            string str2 = (
                from map in years35VOs
                where map.Years == (long)year
                select map).FirstOrDefault<Years35VO>().Planet.ToString();
            List<PlanetHouseMappingVO> planetHouseMappingVOs = new List<PlanetHouseMappingVO>();
            long house1 = (long)(
                from lk in VVlkmv
                where lk.PlanetName.Equals(str2)
                select lk).FirstOrDefault<KundliMappingVO>().House;
            planetHouseMappingVOs = (
                from pk in planetBLL.GetPakkeGhar()
                where (long)pk.House == house1
                select pk).ToList<PlanetHouseMappingVO>();
            long num3 = (long)0;
            if ((house1 == (long)1 || house1 == (long)7 || house1 == (long)4 ? true : house1 == (long)10))
            {
                num3 = (house1 + (long)6) % (long)12;
            }
            string str3 = "";
            ProductSettingsVO productSettingsVO = new ProductSettingsVO();
            List<KPPlanetMappingVO> kPPlanetMappingVOs = new List<KPPlanetMappingVO>();
            List<KPHouseMappingVO> kPHouseMappingVOs = new List<KPHouseMappingVO>();
            KPBLL kPBLL = new KPBLL();
            productSettingsVO.Online_Result = perskv.Online_Result;
            productSettingsVO.Include = false;
            productSettingsVO.Lang = perskv.Language;
            productSettingsVO.Male = male;
            productSettingsVO.PredFor = 0;
            productSettingsVO.ShowRef = perskv.ShowRef;
            productSettingsVO.ShowUpay = true;
            productSettingsVO.ShowUpayCode = true;
            productSettingsVO.Sno = (long)555;
            productSettingsVO.Category = "all";
            productSettingsVO.Product = "";
            kPBLL.Process_Planet_Lagan(perskv.Online_Result, ref kPPlanetMappingVOs, ref kPHouseMappingVOs, perskv.Rotate, false);
            kPPlanetMappingVOs = kPBLL.Process_KPChart_GoodBad(kPPlanetMappingVOs, perskv, productSettingsVO);
            foreach (KundliMappingVO vVlkmv in VVlkmv)
            {
                num = (long)0;
                short planet = 0;
                string signiStringWithoutNakRashi = "";
                List<RulesVO> list = (
                    from Rules in kundliBLL.GetAdvancePredictions(VVlkmv, vVlkmv.Planet, num2)
                    where (Rules.Isbad != vVlkmv.VIsBad ? false : Rules.RuleType == "vfal")
                    select Rules).ToList<RulesVO>();
                planet = (
                    from Map in kPBLL.Fill_Planets()
                    where Map.English == vVlkmv.PlanetNameEnglish
                    select Map).SingleOrDefault<KPPlanetsVO>().Planet;
                signiStringWithoutNakRashi = kPBLL.Get_Signi_String_Without_NakRashi(planet, kPPlanetMappingVOs, false);
                num = Convert.ToInt64((
                    from Map in years35VOs
                    where (Map.Years != (long)year ? false : (Map.Period.Contains(vVlkmv.PlanetName) ? true : Map.Planet == vVlkmv.PlanetName))
                    select Map).Count<Years35VO>());
                if (num > (long)0)
                {
                    isBad = (
                        from Map in lkmv
                        where Map.PlanetName == vVlkmv.PlanetName
                        select Map).SingleOrDefault<KundliMappingVO>().IsBad;
                }
                if (num < (long)1)
                {
                    if ((
                        from pp in planetHouseMappingVOs
                        where pp.Planet == vVlkmv.Planet
                        select pp).Count<PlanetHouseMappingVO>() > 0)
                    {
                        goto Label1;
                    }
                    house = (long)vVlkmv.House != num3;
                    goto Label0;
                }
                Label1:
                house = false;
                Label0:
                if (!house)
                {
                    str1 = string.Concat(str1, "\r\n");
                    if (num1 != year)
                    {
                        str1 = string.Concat(str1, "\r\n");
                    }
                    num1 = year;
                    if (marking)
                    {
                        foreach (RulesVO rulesVO in list)
                        {
                            str = (year < 18 ? predictionBLL.Get_Pred_Text(rulesVO.Sno, lang, male, false, showref, true, paid, true, flag, perskv) : predictionBLL.Get_Pred_Text(rulesVO.Sno, lang, male, true, showref, true, paid, true, flag, perskv));
                            if (!showref)
                            {
                                str1 = string.Concat(str1, str);
                            }
                            else
                            {
                                object obj = str1;
                                object[] sno = new object[] { obj, str, "   ", rulesVO.Sno, "  ", ruleBLL.GetPlanetByRuleNo(rulesVO.Sno).Planet, " ", ruleBLL.GetPlanetByRuleNo(rulesVO.Sno).House, " ", rulesVO.Reference };
                                str1 = string.Concat(sno);
                            }
                        }
                        str1 = string.Concat(str1, "\r\n\r\n", str3);
                    }
                }
                if (!marking)
                {
                    foreach (RulesVO rulesVO1 in list)
                    {
                        str = (year < 18 ? predictionBLL.Get_Pred_Text(rulesVO1.Sno, lang, male, false, showref, true, paid, true, flag, perskv) : predictionBLL.Get_Pred_Text(rulesVO1.Sno, lang, male, true, showref, true, paid, true, flag, perskv));
                        str1 = string.Concat(str1, str);
                        str1 = string.Concat(str1, "\r\n");
                    }
                }
            }
            return str1;
        }

        private string GetVarshFal_35years(List<KundliMappingVO> lkmv, short year, bool showref, bool marking, bool male, string janamsamay, string lang, KundliVO persKV, ProductSettingsVO prod)
        {
            PredictionBLL predictionBLL = new PredictionBLL();
            bool flag = true;
            PlanetBLL planetBLL = new PlanetBLL();
            long num = (long)0;
            string str = "";
            if (prod.NoCategory)
            {
                flag = false;
            }
            //long num1 = (long)0;
            List<PlanetHouseMappingVO> planetHouseMappingVOs = new List<PlanetHouseMappingVO>();
            RulesVO rulesVO = new RulesVO();
            List<string> strs = new List<string>();
            GetPlanetVO getPlanetVO = new GetPlanetVO();
            KundliBLL kundliBLL = new KundliBLL();
            RuleBLL ruleBLL = new RuleBLL();
            int num2 = 2;
            Years35BLL years35BLL = new Years35BLL();
            List<Years35VO> years35VOs = years35BLL.Get35Years(janamsamay);
            KPBLL kPBLL = new KPBLL();
            Years35VO years35VO = (
                from Map in years35VOs
                where Map.Years == (long)year
                select Map).SingleOrDefault<Years35VO>();
            long rashi = (long)(
                from pp in lkmv
                where pp.PlanetName.Equals(years35VO.Planet)
                select pp).FirstOrDefault<KundliMappingVO>().Rashi;
            long? nullable1 = new long?((long)(
                from Map in kPBLL.Fill_Rashi()
                where Map.Rashi == Convert.ToInt16(rashi)
                select Map).FirstOrDefault<KPRashiVO>().Swami);
            string roman = kPBLL.Fill_Planets().Where<KPPlanetsVO>((KPPlanetsVO Map) =>
            {
                long planet = (long)Map.Planet;
                long? nullable = nullable1;
                return (planet != nullable.GetValueOrDefault() ? false : nullable.HasValue);
            }).FirstOrDefault<KPPlanetsVO>().Roman;
            PlanetBLL planetBLL1 = new PlanetBLL();
            long umra = years35BLL.GetUmra(years35VO.Planet) - (long)1;
            long num3 = Convert.ToInt64((
                from Map in years35VOs
                where Map.Years >= (long)year
                select Map).TakeWhile<Years35VO>((Years35VO Map) => Map.Planet == years35VO.Planet).Max<Years35VO>((Years35VO Map) => Map.Years));
            long num4 = num3 - umra;
            if (this.prev_umra == (long)0)
            {
                this.prev_umra = num4;
            }
            if (num4 >= this.prev_umra + (long)35)
            {
                this.umra_method_planet_used = new List<string>();
                this.prev_umra = num4;
            }
            strs = strs.Distinct<string>().Except<string>(this.umra_method_planet_used).ToList<string>();
            strs.Add(years35VO.Planet);
            if (!strs.Contains(roman))
            {
            }
            string period = years35VO.Period;
            char[] chrArray = new char[] { '/' };
            strs.AddRange(period.Split(chrArray).ToList<string>());
            strs = strs.Distinct<string>().Except<string>(this.umra_method_planet_used).ToList<string>();
            this.umra_method_planet_used.AddRange(strs.Distinct<string>().ToList<string>());
            foreach (string str1 in strs)
            {
                KundliMappingVO kundliMappingVO = new KundliMappingVO();
                kundliMappingVO = (
                    from Map in lkmv
                    where Map.PlanetName == str1
                    select Map).SingleOrDefault<KundliMappingVO>();
                if (male)
                {
                    rulesVO = (
                        from Rules in kundliBLL.GetAdvancePredictions(lkmv, kundliMappingVO.Planet, num2)
                        where (Rules.Isbad != kundliMappingVO.IsBad ? false : Rules.RuleType == "general")
                        select Rules).FirstOrDefault<RulesVO>();
                }
                if (rulesVO != null)
                {
                    if (year >= 18)
                    {
                        str = string.Concat(str, predictionBLL.Get_Pred_Text(rulesVO.Sno, lang, male, true, showref, true, flag, true, true, persKV));
                        RulesVO advanceRuleById = new RulesVO();
                        RuleDAO ruleDAO = new RuleDAO();
                        advanceRuleById = ruleBLL.GetAdvanceRuleById(rulesVO.Sno);
                        UpayIndex upayIndex = new UpayIndex();
                        upayIndex = ruleDAO.Get_UpayIndex(Convert.ToInt32(advanceRuleById.Upay));
                        if (upayIndex != null)
                        {
                            if (advanceRuleById.Upay > 0)
                            {
                                if (!this.all_upayindex_sno.Contains((long)upayIndex.Sno))
                                {
                                    this.all_upayindex_sno.Add((long)upayIndex.Sno);
                                }
                            }
                        }
                        str = string.Concat(str, "\r\n");
                    }
                    if (showref)
                    {
                        long sno = rulesVO.Sno;
                        str = string.Concat(str, sno.ToString());
                        str = string.Concat(str, "\r\n");
                    }
                }
                num += (long)1;
            }
            return str;
        }

        public string NEW_Get_VarshFal_Predictions(KundliVO persKV, List<short> Varshfal_years, List<KPPlanetMappingVO> kp_chart, List<short> months, ProductSettingsVO prod)
        {
            short house;
            string str;
            bool male = prod.Male;
            string lang = prod.Lang;
            bool paid = persKV.Paid;
            string dD = persKV.DD;
            string mM = persKV.MM;
            string yY = persKV.YY;
            string hH = persKV.HH;
            string mIN = persKV.MIN;
            List<KPPlanetsVO> kPPlanetsVOs = (new KPBLL()).Fill_Planets();
            bool showRef = prod.ShowRef;
            bool flag = true;
            if (prod.NoCategory)
            {
                paid = false;
            }
            PredictionBLL predictionBLL = new PredictionBLL();
            List<KPPlanetMappingVO> kPPlanetMappingVOs = new List<KPPlanetMappingVO>();
            KundliBLL kundliBLL = new KundliBLL();
            string str1 = "";
            DateTime dateTime = new DateTime();
            DateTime dateTime1 = new DateTime();
            foreach (short varshfalYear in Varshfal_years)
            {
                kPPlanetMappingVOs = kundliBLL.NEW_GetVarshaphalKundliMapping(varshfalYear, persKV, kp_chart);
                str1 = string.Concat(str1, "\r\n");
                DateTime dob = persKV.Dob;
                dateTime = dob.AddYears(varshfalYear - 1);
                dob = persKV.Dob.AddYears(varshfalYear);
                dateTime1 = dob.AddDays(-1);
                string str2 = str1;
                string[] strArrays = new string[] { str2, "<B>", dateTime.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", dateTime.ToString("%M")), persKV.Language, persKV.Paid, true), " ", dateTime.ToString("yyyy"), predictionBLL.GetCodeLang("to", persKV.Language, true, true), dateTime1.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", dateTime1.ToString("%M")), persKV.Language, persKV.Paid, true), " ", dateTime1.ToString("yyyy"), " ", predictionBLL.GetCodeLang("yearend", persKV.Language, true, true), "</B>" };
                str1 = string.Concat(strArrays);
                str1 = string.Concat(str1, "\r\n\r\n");
                foreach (KPPlanetMappingVO kPPlanetMappingVO in kPPlanetMappingVOs)
                {
                    string str3 = str1;
                    if (kPPlanetMappingVO.isbad)
                    {
                        strArrays = new string[] { predictionBLL.GetCodeLang(kPPlanetsVOs[kPPlanetMappingVO.Planet - 1].English, lang, paid, flag).ToString(), " ", null, null, null, null };
                        house = kPPlanetMappingVO.House;
                        strArrays[2] = house.ToString();
                        strArrays[3] = " ";
                        strArrays[4] = predictionBLL.GetCodeLang("Bad", lang, paid, flag).ToString();
                        strArrays[5] = "\r\n";
                        str = string.Concat(strArrays);
                    }
                    else
                    {
                        strArrays = new string[] { predictionBLL.GetCodeLang(kPPlanetsVOs[kPPlanetMappingVO.Planet - 1].English, lang, paid, flag).ToString(), " ", null, null, null, null };
                        house = kPPlanetMappingVO.House;
                        strArrays[2] = house.ToString();
                        strArrays[3] = " ";
                        strArrays[4] = predictionBLL.GetCodeLang("Good", lang, paid, flag).ToString();
                        strArrays[5] = "\r\n";
                        str = string.Concat(strArrays);
                    }
                    str1 = string.Concat(str3, str);
                }
                str1 = string.Concat(str1, "\r\n");
                str1 = string.Concat(str1, this.VFAL_MARKING(persKV, kp_chart, kPPlanetMappingVOs, varshfalYear, prod));
                if (persKV.Paid)
                {
                    str1 = string.Concat(str1, this.VFAL_JAD(kp_chart, varshfalYear, persKV, kPPlanetMappingVOs));
                }
                if (persKV.Mfal)
                {
                    str1 = string.Concat(str1, "\r\n", this.Get_mfal_marking(kp_chart, varshfalYear, months, persKV, prod));
                }
            }
            return str1;
        }

        public List<short> Pakka_House_Wala_Planet(short house)
        {
            List<short> nums = new List<short>();
            KPBLL kPBLL = new KPBLL();
            List<KPPlanetsVO> kPPlanetsVOs = new List<KPPlanetsVO>();
            foreach (KPPlanetsVO kPPlanetsVO in
                from Map in kPBLL.Fill_Planets()
                where Map.Planet <= 9
                select Map)
            {
                string lalPakkeGhar = kPPlanetsVO.Lal_Pakke_Ghar;
                char[] chrArray = new char[] { ',' };
                if (lalPakkeGhar.Split(chrArray, StringSplitOptions.RemoveEmptyEntries).Contains<string>(house.ToString()))
                {
                    nums.Add(kPPlanetsVO.Planet);
                }
            }
            return nums;
        }

        private string VFAL_JAD(List<KPPlanetMappingVO> lkmv, short year, KundliVO persKV, List<KPPlanetMappingVO> VVlkmv)
        {
            PredictionBLL predictionBLL = new PredictionBLL();
            PlanetBLL planetBLL = new PlanetBLL();
            long num = (long)0;
            string str = "";
            List<PlanetHouseMappingVO> planetHouseMappingVOs = new List<PlanetHouseMappingVO>();
            List<string> strs = new List<string>();
            KPBLL kPBLL = new KPBLL();
            List<KPPlanetsVO> kPPlanetsVOs = kPBLL.Fill_Planets();
            GetPlanetVO getPlanetVO = new GetPlanetVO();
            KundliBLL kundliBLL = new KundliBLL();
            RuleBLL ruleBLL = new RuleBLL();
            Years35BLL years35BLL = new Years35BLL();
            List<Years35VO> years35VOs = years35BLL.Get35Years(persKV.JanamSamay);
            Years35VO years35VO = (
                from Map in years35VOs
                where Map.Years == (long)year
                select Map).SingleOrDefault<Years35VO>();
            long rashi = (long)(
                from pp in lkmv
                where pp.Planet == (
                    from Map in kPPlanetsVOs
                    where Map.Roman == years35VO.Planet
                    select Map).FirstOrDefault<KPPlanetsVO>().Planet
                select pp).FirstOrDefault<KPPlanetMappingVO>().Rashi;
            long? nullable1 = new long?((long)(
                from Map in kPBLL.Fill_Rashi()
                where Map.Rashi == Convert.ToInt16(rashi)
                select Map).FirstOrDefault<KPRashiVO>().Swami);
            string roman = kPBLL.Fill_Planets().Where<KPPlanetsVO>((KPPlanetsVO Map) =>
            {
                long planet = (long)Map.Planet;
                long? nullable = nullable1;
                return (planet != nullable.GetValueOrDefault() ? false : nullable.HasValue);
            }).FirstOrDefault<KPPlanetsVO>().Roman;
            PlanetBLL planetBLL1 = new PlanetBLL();
            long umra = years35BLL.GetUmra(years35VO.Planet) - (long)1;
            long num1 = Convert.ToInt64((
                from Map in years35VOs
                where Map.Years >= (long)year
                select Map).TakeWhile<Years35VO>((Years35VO Map) => Map.Planet == years35VO.Planet).Max<Years35VO>((Years35VO Map) => Map.Years));
            long num2 = num1 - umra;
            if (this.prev_umra == (long)0)
            {
                this.prev_umra = num2;
            }
            if (num2 >= this.prev_umra + (long)35)
            {
                this.umra_method_planet_used = new List<string>();
                this.prev_umra = num2;
            }
            strs = strs.Distinct<string>().Except<string>(this.umra_method_planet_used).ToList<string>();
            strs.Add(years35VO.Planet);
            string period = years35VO.Period;
            char[] chrArray = new char[] { '/' };
            strs.AddRange(period.Split(chrArray).ToList<string>());
            strs = strs.Distinct<string>().Except<string>(this.umra_method_planet_used).ToList<string>();
            this.umra_method_planet_used.AddRange(strs.Distinct<string>().ToList<string>());
            List<KPMixDashaVO> kPMixDashaVOs = new List<KPMixDashaVO>();
            KPDAO kPDAO = new KPDAO();
            foreach (string str1 in strs)
            {
                KPMixDashaVO kPMixDashaVO = new KPMixDashaVO();
                KPPlanetMappingVO kPPlanetMappingVO = new KPPlanetMappingVO();
                kPPlanetMappingVO = (
                    from Map in lkmv
                    where Map.Planet == (
                        from Map1 in kPPlanetsVOs
                        where Map1.Roman == str1
                        select Map1).FirstOrDefault<KPPlanetsVO>().Planet
                    select Map).FirstOrDefault<KPPlanetMappingVO>();
                kPMixDashaVO = (
                    from Map in kPDAO.Get_Mix_Dasha(kPPlanetMappingVO.Planet, kPPlanetMappingVO.House, 0, "", "general_varshfal")
                    where Map.Isbad == kPPlanetMappingVO.isbad
                    select Map).FirstOrDefault<KPMixDashaVO>();
                if (kPMixDashaVO != null)
                {
                    if (year >= 18)
                    {
                        if (persKV.ShowRef)
                        {
                            short sno = kPMixDashaVO.Sno;
                            str = string.Concat(str, "-", sno.ToString(), "-");
                        }
                        str = string.Concat(str, kPBLL.Get_KP_Lang(kPMixDashaVO.Sno, persKV.Language, false, false, false));
                        str = string.Concat(str, "\r\n");
                    }
                }
                num += (long)1;
            }
            return str;
        }

        private string VFAL_MARKING(KundliVO perskv, List<KPPlanetMappingVO> lkmv, List<KPPlanetMappingVO> VVlkmv, short year, ProductSettingsVO prod)
        {
            //KPPredBLL.<>c__DisplayClass2b variable;
            PredictionBLL predictionBLL = new PredictionBLL();
            string str = "";
            long num = (long)0;
            KPBLL kPBLL = new KPBLL();
            List<KPPlanetsVO> kPPlanetsVOs = kPBLL.Fill_Planets();
            short num1 = 0;
            GetPlanetVO getPlanetVO = new GetPlanetVO();
            KundliBLL kundliBLL = new KundliBLL();
            RuleBLL ruleBLL = new RuleBLL();
            string str1 = "";
            Years35BLL years35BLL = new Years35BLL();
            PlanetBLL planetBLL = new PlanetBLL();
            List<Years35VO> years35VOs = years35BLL.Get35Years(perskv.JanamSamay);
            List<short> nums = new List<short>();
            string str2 = (
                from map in years35VOs
                where map.Years == (long)year
                select map).FirstOrDefault<Years35VO>().Planet.ToString();
            short planet = (
                from Map in kPPlanetsVOs
                where Map.Roman == str2
                select Map).FirstOrDefault<KPPlanetsVO>().Planet;
            short house = (
                from lk in VVlkmv
                where lk.Planet == planet
                select lk).FirstOrDefault<KPPlanetMappingVO>().House;
            nums = this.Pakka_House_Wala_Planet(house);
            long num2 = (long)0;
            if ((house == 1 || house == 7 || house == 4 ? true : house == 10))
            {
                num2 = (long)((house + 6) % 12);
            }
            List<KPMixDashaVO> kPMixDashaVOs = new List<KPMixDashaVO>();
            KPDAO kPDAO = new KPDAO();
            kPMixDashaVOs = kPDAO.Get_Mix_Dasha(1, 1, 0, "", "all_varshfal");
            foreach (KPPlanetMappingVO vVlkmv in VVlkmv)
            {
                num = (long)0;
                List<KPMixDashaVO> list = new List<KPMixDashaVO>();
                list = (
                    from Map in kPMixDashaVOs
                    where (Map.Planet1 != vVlkmv.Planet || Map.House1 != vVlkmv.House ? false : Map.Isbad == vVlkmv.isbad)
                    select Map).ToList<KPMixDashaVO>();
                //num = Convert.ToInt64(years35VOs.Where<Years35VO>((Years35VO Map) => return (Map.Years != (long)year ? false : (Map.Period.Contains(kPPlanetsVOs[vVlkmv.Planet - 1].Roman) ? true : (
                //    from Map1 in kPPlanetsVOs
                //    where Map1.Roman == Map.Planet
                //    select Map1).FirstOrDefault<KPPlanetsVO>().Planet == vVlkmv.Planet))).Count<Years35VO>());
                num = Convert.ToInt64(years35VOs.Where<Years35VO>(Map =>
                    Map.Years == year
                    && (Map.Period.Contains(kPPlanetsVOs[vVlkmv.Planet - 1].Roman)
                        || (from Map1 in kPPlanetsVOs where Map1.Roman == Map.Planet select Map1).FirstOrDefault<KPPlanetsVO>().Planet == vVlkmv.Planet)).Count<Years35VO>());
                if (vVlkmv.Planet == 3)
                {
                    vVlkmv.Planet = 3;
                }
                if ((num >= (long)1 || nums.Contains(vVlkmv.Planet) ? true : (long)vVlkmv.House == num2))
                {
                    str1 = string.Concat(str1, "\r\n");
                    if (num1 != year)
                    {
                        str1 = string.Concat(str1, "\r\n");
                    }
                    num1 = year;
                    foreach (KPMixDashaVO kPMixDashaVO in list)
                    {
                        str = "";
                        if (perskv.ShowRef)
                        {
                            short sno = kPMixDashaVO.Sno;
                            str = string.Concat("-", sno.ToString(), "-");
                        }
                        str = (year < 18 ? string.Concat(str, kPBLL.Get_KP_Lang(kPMixDashaVO.Sno, perskv.Language, false, false, false)) : string.Concat(str, kPBLL.Get_KP_Lang(kPMixDashaVO.Sno, perskv.Language, false, false, false)));
                        if (kPMixDashaVO.Isbad)
                        {
                            KPRemediesVO kPRemediesVO = (
                                from Map in KPPredBLL.Remedy_List_VFAL
                                where (Map.Planet != kPMixDashaVO.Planet1 ? false : Map.House == kPMixDashaVO.House1)
                                select Map).FirstOrDefault<KPRemediesVO>();
                            if (kPRemediesVO != null)
                            {
                                if (perskv.Paid)
                                {
                                    str = string.Concat(str, "\r\n\r\n<B>", predictionBLL.GetCodeLang("decrease", perskv.Language, true, true), "</B>\r\n\r\n");
                                    if (perskv.Language.ToLower() == "hindi")
                                    {
                                        str = string.Concat(str, kPRemediesVO.Pred_Hindi);
                                    }
                                    if (perskv.Language.ToLower() == "english")
                                    {
                                        str = string.Concat(str, kPRemediesVO.Pred_English);
                                    }
                                    if (perskv.Language.ToLower() == "marathi")
                                    {
                                        str = string.Concat(str, kPRemediesVO.Pred_Marathi);
                                    }
                                }
                                if (prod.Gen_Link)
                                {
                                    str = string.Concat(str, kPBLL.Gen_Link((long)kPRemediesVO.Sno, prod.Gen_Link, (long)kPMixDashaVO.Sno, false, (long)kPMixDashaVO.Sno, "R"), "\r\n\r\n");
                                }
                            }
                        }
                        str1 = string.Concat(str1, str);
                    }
                    str1 = string.Concat(str1, "\r\n\r\n");
                }
            }
            return str1;
        }
    }
}