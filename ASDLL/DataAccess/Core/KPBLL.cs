using ASDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using AstroShared.Models;

namespace ASDLL.DataAccess.Core
{
    public class KPBLL
    {
        public static List<KPPlanetsVO> planet_list;

        public static List<KPHousesVO> house_list;

        public static List<KPNAKVO> nak_list;

        public static List<KPRashiVO> rashi_list;

        public static List<KP249VO> kp249;

        private LangResource lrs = new LangResource();

        private List<KPUpayList> upay_list = new List<KPUpayList>();

        private List<string> date_list = new List<string>();

        private List<short> prev_mix_all_fal = new List<short>();

        private DateTime last_antar_date;

        private DateTime last_pryaantar_date;

        public static List<KPRemediesVO> Remedy_List_VFAL;

        public static List<KPRemediesVO> Remedy_List_IA;

        public static List<KPRemediesVO> Remedy_List_General;

        public static List<KPRemediesVO> Remedy_List_Bupay;

        public static List<KPRemediesVO> Remedy_List_Logical;

        public static List<KPGoodBadVO> Good_Bad;

        private List<short> all_fal_dasha = new List<short>();

        private List<short> all_fal_dasha_chain = new List<short>();

        private List<short> all_fal_planet_chain = new List<short>();

        private List<short> chain_all_fal = new List<short>();

        private List<short> fullyog_all_fal = new List<short>();

        private List<short> fullyuti_all_fal = new List<short>();

        private List<short> fulltriangle_all_fal = new List<short>();

        private List<short> fullyuti_house = new List<short>();

        private List<short> mvfal_all_fal = new List<short>();

        static KPBLL()
        {
            KPBLL.planet_list = new List<KPPlanetsVO>();
            KPBLL.house_list = new List<KPHousesVO>();
            KPBLL.nak_list = new List<KPNAKVO>();
            KPBLL.rashi_list = new List<KPRashiVO>();
            KPBLL.kp249 = new List<KP249VO>();
            KPBLL.Remedy_List_VFAL = new List<KPRemediesVO>();
            KPBLL.Remedy_List_IA = new List<KPRemediesVO>();
            KPBLL.Remedy_List_General = new List<KPRemediesVO>();
            KPBLL.Remedy_List_Bupay = new List<KPRemediesVO>();
            KPBLL.Remedy_List_Logical = new List<KPRemediesVO>();
            KPBLL.Good_Bad = new List<KPGoodBadVO>();
            KPDAO kPDAO = new KPDAO();
            KPBLL.Remedy_List_IA = kPDAO.Get_Remedies("upay_ia");
            KPBLL.Remedy_List_VFAL = kPDAO.Get_Remedies("vfal");
            KPBLL.Remedy_List_General = kPDAO.Get_Remedies("general");
            KPBLL.Remedy_List_Bupay = kPDAO.Get_Remedies("upay_b");
            KPBLL.Remedy_List_Logical = kPDAO.Get_Remedies("logical");
            KPBLL.Good_Bad = kPDAO.Get_GoodBad();
        }

        public KPBLL() { }

        public List<KPPlanetMappingVO> Bad_Kardo(List<KPPlanetMappingVO> kp_chart, KundliVO persKV, ProductSettingsVO prod)
        {
            string[] strArrays;
            //string list = null;
            string[] strArrays1;
            bool flag;
            bool flag1;
            bool flag2;
            bool flag3;
            bool flag4;
            bool flag5;
            List<KPPlanetMappingVO> kPPlanetMappingVOs = new List<KPPlanetMappingVO>();
            kPPlanetMappingVOs = kp_chart;
            short bhavChalitHouseNew = (
                from Map in kp_chart
                where Map.Planet == 1
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House_New;
            short num = (
                from Map in kp_chart
                where Map.Planet == 2
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House_New;
            short bhavChalitHouseNew1 = (
                from Map in kp_chart
                where Map.Planet == 3
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House_New;
            short num1 = (
                from Map in kp_chart
                where Map.Planet == 4
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House_New;
            short bhavChalitHouseNew2 = (
                from Map in kp_chart
                where Map.Planet == 5
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House_New;
            short num2 = (
                from Map in kp_chart
                where Map.Planet == 6
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House_New;
            short bhavChalitHouseNew3 = (
                from Map in kp_chart
                where Map.Planet == 7
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House_New;
            short num3 = (
                from Map in kp_chart
                where Map.Planet == 8
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House_New;
            short bhavChalitHouseNew4 = (
                from Map in kp_chart
                where Map.Planet == 9
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House_New;
            Convert.ToInt16(kp_chart.Count<KPPlanetMappingVO>((KPPlanetMappingVO Map) => Map.Bhav_Chalit_House == 1));
            Convert.ToInt16(kp_chart.Count<KPPlanetMappingVO>((KPPlanetMappingVO Map) => Map.Bhav_Chalit_House == 2));
            Convert.ToInt16(kp_chart.Count<KPPlanetMappingVO>((KPPlanetMappingVO Map) => Map.Bhav_Chalit_House == 3));
            Convert.ToInt16(kp_chart.Count<KPPlanetMappingVO>((KPPlanetMappingVO Map) => Map.Bhav_Chalit_House == 4));
            Convert.ToInt16(kp_chart.Count<KPPlanetMappingVO>((KPPlanetMappingVO Map) => Map.Bhav_Chalit_House == 5));
            Convert.ToInt16(kp_chart.Count<KPPlanetMappingVO>((KPPlanetMappingVO Map) => Map.Bhav_Chalit_House == 6));
            Convert.ToInt16(kp_chart.Count<KPPlanetMappingVO>((KPPlanetMappingVO Map) => Map.Bhav_Chalit_House == 7));
            Convert.ToInt16(kp_chart.Count<KPPlanetMappingVO>((KPPlanetMappingVO Map) => Map.Bhav_Chalit_House == 8));
            Convert.ToInt16(kp_chart.Count<KPPlanetMappingVO>((KPPlanetMappingVO Map) => Map.Bhav_Chalit_House == 9));
            Convert.ToInt16(kp_chart.Count<KPPlanetMappingVO>((KPPlanetMappingVO Map) => Map.Bhav_Chalit_House == 10));
            Convert.ToInt16(kp_chart.Count<KPPlanetMappingVO>((KPPlanetMappingVO Map) => Map.Bhav_Chalit_House == 11));
            Convert.ToInt16(kp_chart.Count<KPPlanetMappingVO>((KPPlanetMappingVO Map) => Map.Bhav_Chalit_House == 12));
            foreach (KPPlanetMappingVO kpChart in kp_chart)
            {
                if (kpChart.Planet == 1)
                {
                    if (this.isOccupied_by_Shatru(kpChart.Planet, "1,5", kp_chart))
                    {
                        kPPlanetMappingVOs[0].isbad = true;
                    }
                    if (this.isDrishti(8, kpChart.Planet, kp_chart))
                    {
                        flag4 = false;
                    }
                    else if (num3 != bhavChalitHouseNew)
                    {
                        flag4 = true;
                    }
                    else
                    {
                        flag4 = (num3 == 9 ? false : num3 != 12);
                    }
                    if (!flag4)
                    {
                        kPPlanetMappingVOs[0].isbad = true;
                    }
                    if (!this.isDrishti(6, kpChart.Planet, kp_chart) || !kp_chart[5].isbad)
                    {
                        flag5 = (!this.isDrishti(7, kpChart.Planet, kp_chart) ? true : !kp_chart[6].isbad);
                    }
                    else
                    {
                        flag5 = false;
                    }
                    if (!flag5)
                    {
                        kPPlanetMappingVOs[0].isbad = true;
                    }
                    if (this.isDrishti(1, 7, kp_chart))
                    {
                        kPPlanetMappingVOs[5].isbad = true;
                    }
                }
                if (kpChart.Planet == 2)
                {
                    if (this.Pehele_Baad(5, 9, kp_chart))
                    {
                        kPPlanetMappingVOs[1].isbad = true;
                    }
                    if (this.isDrishti(7, 2, kp_chart))
                    {
                        kPPlanetMappingVOs[1].isbad = true;
                    }
                    if ((num3 == num || bhavChalitHouseNew4 == num ? true : bhavChalitHouseNew == bhavChalitHouseNew1))
                    {
                        kPPlanetMappingVOs[1].isbad = true;
                    }
                    strArrays1 = new string[] { "1", "3", "4", "5", "6" };
                    strArrays = strArrays1;
                    if (this.Dristi_Khane_Wale_Planet(2, kp_chart, true).Intersect<string>(strArrays).ToList<string>().Count > 0)
                    {
                        kPPlanetMappingVOs[1].isbad = true;
                    }
                    if (kp_chart[1].isJadKharab)
                    {
                        kPPlanetMappingVOs[1].isbad = true;
                    }
                }
                if (kpChart.Planet == 3)
                {
                    if (this.isDrishti(3, 7, kp_chart))
                    {
                        kPPlanetMappingVOs[2].isbad = true;
                    }
                    if ((num2 != num1 ? false : num2 == 8))
                    {
                        kPPlanetMappingVOs[2].isbad = true;
                    }
                    if ((bhavChalitHouseNew4 == 3 ? true : bhavChalitHouseNew4 == 8))
                    {
                        kPPlanetMappingVOs[2].isbad = true;
                    }
                    if (this.IsMilan(3, 9, kp_chart))
                    {
                        kPPlanetMappingVOs[2].isbad = true;
                        kPPlanetMappingVOs[8].isbad = true;
                    }
                }
                if (kpChart.Planet == 4)
                {
                    if (this.Pehele_Baad(6, 4, kp_chart))
                    {
                        kPPlanetMappingVOs[3].isbad = true;
                    }
                    if ((num == 6 ? true : bhavChalitHouseNew1 == 6))
                    {
                        kPPlanetMappingVOs[3].isbad = true;
                        kPPlanetMappingVOs[8].isbad = true;
                    }
                    if (num3 != 7 || !kp_chart[7].isbad)
                    {
                        flag3 = (bhavChalitHouseNew1 != 6 ? true : !kp_chart[2].isbad);
                    }
                    else
                    {
                        flag3 = false;
                    }
                    if (!flag3)
                    {
                        kPPlanetMappingVOs[3].isbad = true;
                    }
                    if ((num != num3 ? false : num3 != 11))
                    {
                        kPPlanetMappingVOs[3].isbad = true;
                    }
                }
                if (kpChart.Planet == 5)
                {
                    if ((num1 == 2 || num1 == 5 || num1 == 9 ? true : num1 == 12))
                    {
                        kPPlanetMappingVOs[4].isbad = true;
                    }
                    if ((num2 == 2 || num2 == 5 || num2 == 9 ? true : num2 == 12))
                    {
                        kPPlanetMappingVOs[4].isbad = true;
                    }
                    if ((bhavChalitHouseNew3 == 2 || bhavChalitHouseNew3 == 5 || bhavChalitHouseNew3 == 9 || bhavChalitHouseNew3 == 12 ? kp_chart[6].isbad : false))
                    {
                        kPPlanetMappingVOs[4].isbad = true;
                    }
                    if ((num3 == 2 || num3 == 5 || num3 == 9 ? true : num3 == 12))
                    {
                        kPPlanetMappingVOs[4].isbad = true;
                    }
                    if ((bhavChalitHouseNew == num3 ? true : num == bhavChalitHouseNew4))
                    {
                        kPPlanetMappingVOs[4].isbad = true;
                    }
                    strArrays1 = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" };
                    strArrays = strArrays1;
                    if ((bhavChalitHouseNew == num3 ? true : num == bhavChalitHouseNew4))
                    {
                        foreach (string list in this.Dristi_Khane_Wale_Planet(5, kp_chart, false).Intersect<string>(strArrays).ToList<string>())
                        {
                            kPPlanetMappingVOs[Convert.ToInt16(list) - 1].isbad = true;
                        }
                        if (this.Pehele_Baad(6, 4, kp_chart))
                        {
                            kPPlanetMappingVOs[4].isbad = true;
                            kPPlanetMappingVOs[7].isbad = true;
                        }
                    }
                }
                if (kpChart.Planet == 6)
                {
                    if ((bhavChalitHouseNew == 7 || num == 7 || num3 == 7 || bhavChalitHouseNew2 == 7 ? persKV.Male : false))
                    {
                        kPPlanetMappingVOs[5].isbad = true;
                    }
                    if ((bhavChalitHouseNew == 7 || num == 7 || num3 == 7 ? !persKV.Male : false))
                    {
                        kPPlanetMappingVOs[4].isbad = true;
                    }
                    if ((num2 != 2 || num1 != 8) && (num2 != 3 || num1 != 9) && (num2 != 6 || num1 != 12))
                    {
                        flag2 = (num2 != 8 ? true : num1 != 2);
                    }
                    else
                    {
                        flag2 = false;
                    }
                    if (!flag2)
                    {
                        kPPlanetMappingVOs[5].isbad = true;
                        kPPlanetMappingVOs[3].isbad = true;
                    }
                    if (this.isDrishti(7, 6, kp_chart))
                    {
                        strArrays1 = new string[] { "1", "2", "8" };
                        strArrays = strArrays1;
                        foreach (string str in this.Dristi_Marne_Wale_Planet(6, kp_chart).Intersect<string>(strArrays).ToList<string>())
                        {
                            kPPlanetMappingVOs[Convert.ToInt16(str) - 1].isbad = true;
                        }
                        foreach (string list1 in this.Ham_Saath_Planet(6, kp_chart).Intersect<string>(strArrays).ToList<string>())
                        {
                            kPPlanetMappingVOs[Convert.ToInt16(list1) - 1].isbad = true;
                        }
                    }
                    if ((!this.Sitting_in_Shatru_House(6, kp_chart) ? false : this.Saath_Lagte_Ghar(6, 8, kp_chart)))
                    {
                        kPPlanetMappingVOs[5].isbad = true;
                    }
                }
                if (kpChart.Planet == 7)
                {
                    if (this.Pehele_Baad(8, 9, kp_chart))
                    {
                        kPPlanetMappingVOs[6].isbad = true;
                    }
                    if (bhavChalitHouseNew3 != num3 || bhavChalitHouseNew3 != 12)
                    {
                        flag1 = (bhavChalitHouseNew3 != num ? true : bhavChalitHouseNew3 != 12);
                    }
                    else
                    {
                        flag1 = false;
                    }
                    if (!flag1)
                    {
                        kPPlanetMappingVOs[6].isbad = true;
                    }
                    if ((bhavChalitHouseNew == 10 ? true : num == 10))
                    {
                        kPPlanetMappingVOs[6].isbad = true;
                    }
                }
                if (kpChart.Planet == 8)
                {
                    short num4 = Convert.ToInt16((int)(bhavChalitHouseNew3 - num3));
                    if ((num4 == -2 || num4 == 10 || num4 == -9 || num4 == 3 || num4 == -7 || num4 == 5 ? true : Math.Abs(num4) == 6))
                    {
                        kPPlanetMappingVOs[7].isbad = true;
                    }
                }
                if (kpChart.Planet == 9)
                {
                    if ((bhavChalitHouseNew1 == num1 ? true : bhavChalitHouseNew1 == bhavChalitHouseNew2))
                    {
                        kPPlanetMappingVOs[8].isbad = true;
                    }
                    if ((bhavChalitHouseNew1 == 12 || bhavChalitHouseNew2 == 12 ? true : num1 == 12))
                    {
                        kPPlanetMappingVOs[8].isbad = true;
                    }
                    if ((num == 11 ? true : num == 12))
                    {
                        kPPlanetMappingVOs[8].isbad = true;
                    }
                    if (bhavChalitHouseNew4 == num1)
                    {
                        kPPlanetMappingVOs[8].isbad = true;
                    }
                    if (this.Sitting_with_Shatru(1, kp_chart))
                    {
                        kPPlanetMappingVOs[8].isbad = true;
                    }
                    if (num2 == num)
                    {
                        kPPlanetMappingVOs[8].isbad = true;
                    }
                    if (bhavChalitHouseNew4 == 9 || bhavChalitHouseNew4 == 12)
                    {
                        flag = (num == 2 ? false : bhavChalitHouseNew1 != 2);
                    }
                    else
                    {
                        flag = true;
                    }
                    if (!flag)
                    {
                        kPPlanetMappingVOs[8].isbad = true;
                    }
                }
            }
            return kPPlanetMappingVOs;
        }

        public string Change_to_Hora_Kundali_Result(string Online_Result, short kpno)
        {
            string str;
            int i;
            KPBLL.kp249 = this.Fill_249();
            string str1 = "";
            string str2 = "";
            string str3 = "";
            char[] chrArray = new char[] { '-' };
            string[] strArrays = Online_Result.Split(chrArray);
            string str4 = strArrays[0];
            chrArray = new char[] { '#' };
            string[] strArrays1 = str4.Split(chrArray);
            string str5 = strArrays[1];
            chrArray = new char[] { '#' };
            string[] strArrays2 = str5.Split(chrArray);
            string str6 = strArrays[2];
            chrArray = new char[] { '#' };
            string[] strArrays3 = str6.Split(chrArray);
            string str7 = strArrays[4];
            chrArray = new char[] { '#' };
            str7.Split(chrArray);
            string str8 = strArrays[5];
            chrArray = new char[] { '#' };
            str8.Split(chrArray);
            short rashi = (
                from Map in KPBLL.kp249
                where Map.Sno == kpno
                select Map).SingleOrDefault<KP249VO>().Rashi;
            strArrays1[0] = rashi.ToString();
            strArrays2[0] = rashi.ToString();
            string[] strArrays4 = strArrays1;
            for (i = 0; i < (int)strArrays4.Length; i++)
            {
                str = strArrays4[i];
                str1 = string.Concat(str1, str, "#");
            }
            strArrays4 = strArrays2;
            for (i = 0; i < (int)strArrays4.Length; i++)
            {
                str = strArrays4[i];
                str2 = string.Concat(str2, str, "#");
            }
            strArrays4 = strArrays3;
            for (i = 0; i < (int)strArrays4.Length; i++)
            {
                str = strArrays4[i];
                short num = 0;
                num = (Convert.ToInt16(str) + (rashi - 1) <= 12 ? Convert.ToInt16(Convert.ToInt16(str) + (rashi - 1)) : Convert.ToInt16(Convert.ToInt16(str) + (rashi - 1) - 12));
                str3 = string.Concat(str3, num.ToString(), "#");
            }
            chrArray = new char[] { '#' };
            str1 = str2.TrimEnd(chrArray);
            chrArray = new char[] { '#' };
            str2 = str2.TrimEnd(chrArray);
            chrArray = new char[] { '#' };
            str3 = str3.TrimEnd(chrArray);
            string[] strArrays5 = new string[] { str1, "-", str2, "-", str3, "-", strArrays[3], "-", strArrays[4], "-", strArrays[5] };
            return string.Concat(strArrays5);
        }

        public bool Check_Gandmool(List<KPPlanetMappingVO> kp_chart)
        {
            bool flag = false;
            short nakLord = (
                from Map in kp_chart
                where Map.Planet == 2
                select Map).FirstOrDefault<KPPlanetMappingVO>().Nak_Lord;
            if ((nakLord == 4 ? true : nakLord == 9))
            {
                flag = true;
            }
            return flag;
        }

        public bool Check_Kal_Sarp(List<KPPlanetMappingVO> kp_chart)
        {
            bool flag = false;
            short bhavChalitHouse = (
                from Map in kp_chart
                where Map.Planet == 8
                select Map).FirstOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            short num = (
                from Map in kp_chart
                where Map.Planet == 9
                select Map).FirstOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            bool flag1 = false;
            bool flag2 = false;
            short num1 = Convert.ToInt16(bhavChalitHouse + 1);
            short num2 = Convert.ToInt16(num + 1);
            short num3 = 0;
            while (num3 < 5)
            {
                if ((
                    from Map in kp_chart
                    where Map.Bhav_Chalit_House == num1
                    select Map).ToList<KPPlanetMappingVO>().Count <= 0)
                {
                    num1 = (short)(num1 + 1);
                    if (num1 > 12)
                    {
                        num1 = 1;
                    }
                    num3 = (short)(num3 + 1);
                }
                else
                {
                    flag1 = true;
                    break;
                }
            }
            num3 = 0;
            while (num3 < 5)
            {
                if ((
                    from Map in kp_chart
                    where Map.Bhav_Chalit_House == num2
                    select Map).ToList<KPPlanetMappingVO>().Count <= 0)
                {
                    num2 = (short)(num2 + 1);
                    if (num2 > 12)
                    {
                        num2 = 1;
                    }
                    num3 = (short)(num3 + 1);
                }
                else
                {
                    flag2 = true;
                    break;
                }
            }
            if ((!flag1 ? true : !flag2))
            {
                flag = true;
            }
            return flag;
        }

        public List<string> Dristi_Khane_Wale_Planet(short planet, List<KPPlanetMappingVO> kp_chart, bool jad_kharab)
        {
            List<string> strs = new List<string>();
            foreach (KPPlanetMappingVO kpChart in kp_chart)
            {
                if ((!this.isDrishti(planet, kpChart.Planet, kp_chart) ? false : kp_chart[kpChart.Planet - 1].isJadKharab == jad_kharab))
                {
                    strs.Add(kpChart.Planet.ToString());
                }
            }
            return strs;
        }

        public List<string> Dristi_Marne_Wale_Planet(short planet, List<KPPlanetMappingVO> kp_chart)
        {
            List<string> strs = new List<string>();
            foreach (KPPlanetMappingVO kpChart in kp_chart)
            {
                if (this.isDrishti(kpChart.Planet, planet, kp_chart))
                {
                    strs.Add(kpChart.Planet.ToString());
                }
            }
            return strs;
        }

        public List<KP249VO> Fill_249()
        {
            List<KP249VO> kP249VOs = new List<KP249VO>();
            return (new KPDAO()).Get249();
        }

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

        public List<KPKaryeshVO> Fill_Karyesh_List()
        {
            List<KPKaryeshVO> kPKaryeshVOs = new List<KPKaryeshVO>();
            return (new KPDAO()).Get_Karyesh_List();
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

        public string Gen_Link(long upaycode, bool genlink, long fakecode, bool mahadasha, long sno, string SS)
        {
            string str;
            if (!genlink)
            {
                str = "";
            }
            else
            {
                object[] objArray = new object[] { " <upay>", fakecode, ",'", SS, upaycode.ToString(), "',", sno.ToString(), "</upay>" };
                str = string.Concat(objArray);
            }
            return str;
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

        public string Get_Antar_HTML(List<KPDashaVO> dasha, string lang)
        {
            string str = "";
            str = "[";
            foreach (KPDashaVO kPDashaVO in dasha)
            {
                str = string.Concat(str, "{");
                if (lang == "hindi")
                {
                    str = string.Concat(str, "\"Planet\": \"", KPBLL.planet_list[kPDashaVO.Planet - 1].Hindi, "\",");
                }
                if (lang == "english")
                {
                    str = string.Concat(str, "\"Planet\": \"", KPBLL.planet_list[kPDashaVO.Planet - 1].English, "\",");
                }
                str = string.Concat(str, "\"Antar\": \"", kPDashaVO.Duration, "\",");
                string str1 = str;
                string[] strArrays = new string[] { str1, "\"Period\": \"", null, null, null, null };
                DateTime startDate = kPDashaVO.StartDate;
                strArrays[2] = startDate.ToString("dd MMM yyyy");
                strArrays[3] = " - ";
                startDate = kPDashaVO.EndDate;
                strArrays[4] = startDate.ToString("dd MMM yyyy");
                strArrays[5] = "\",";
                str = string.Concat(strArrays);
                str = string.Concat(str, "\"Age\": \"", kPDashaVO.Nak_Signi_String, "\"");
                str = string.Concat(str, "},");
            }
            str = str.TrimEnd(new char[] { ',' });
            str = string.Concat(str, "]");
            return str;
        }

        public string Get_Budh_Shukra(List<KPPlanetMappingVO> kp_chart, List<KPHouseMappingVO> cusp_house, ProductSettingsVO prod, KundliVO persKV)
        {
            PredictionBLL predictionBLL = new PredictionBLL();
            string str = "";
            short bhavChalitHouse = (
                from Map in kp_chart
                where Map.Planet == 6
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            short num = (
                from Map in kp_chart
                where Map.Planet == 4
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            short bhavChalitHouse1 = (
                from Map in kp_chart
                where Map.Planet == 4
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            if (bhavChalitHouse < num)
            {
                str = string.Concat(predictionBLL.GetCodeLang("budhshukranote", persKV.Language, true, true), "\r\n\r\n");
                if (!prod.Tool507)
                {
                    KPRemediesVO kPRemediesVO = new KPRemediesVO();
                    kPRemediesVO = (
                        from Map in KPBLL.Remedy_List_Bupay
                        where (Map.Planet != 4 ? false : Map.House == num)
                        select Map).FirstOrDefault<KPRemediesVO>();
                    str = string.Concat(str, this.Get_KP_Lang(Convert.ToInt16(kPRemediesVO.Sno), persKV.Language, false, true, prod.Mini), "\r\n\r\n");
                    kPRemediesVO = (
                        from Map in KPBLL.Remedy_List_Bupay
                        where (Map.Planet != 8 ? false : Map.House == bhavChalitHouse1)
                        select Map).FirstOrDefault<KPRemediesVO>();
                    str = string.Concat(str, this.Get_KP_Lang(Convert.ToInt16(kPRemediesVO.Sno), persKV.Language, false, true, prod.Mini), "\r\n\r\n");
                }
            }
            return str;
        }

        public string Get_Cat(ProductSettingsVO prod, List<KPPlanetMappingVO> kp_chart, List<KPHouseMappingVO> cusp_house, KundliVO persKV)
        {
            string str = "";
            short currentAge = 0;
            currentAge = persKV.Current_Age;
            currentAge = Convert.ToInt16(currentAge - 1);
            short num = 0;
            while (num <= 27)
            {
                currentAge = Convert.ToInt16(currentAge + 1);
                str = string.Concat(str, this.Get_Cat_Fal(kp_chart, cusp_house, persKV, prod.Include, currentAge, prod, true));
                if (!(this.last_antar_date > DateTime.Now.Date.AddYears(prod.Dasha_Years)))
                {
                    num = (short)(num + 1);
                }
                else
                {
                    break;
                }
            }
            return str;
        }

        public List<KPDashafalVO> Get_Cat_Dasha_Pred(short planet, string houses, DateTime startdate, DateTime enddate, KundliVO persKV, string ptype)
        {
            long num;
            KPUpayList kPUpayList;
            short house;
            string predHindi;
            List<KPDashafalVO> kPDashafalVOs = new List<KPDashafalVO>();
            PredictionBLL predictionBLL = new PredictionBLL();
            KPDashafalVO kPDashafalVO = new KPDashafalVO();
            List<short> nums = new List<short>();
            KPDAO kPDAO = new KPDAO();
            short num1 = Convert.ToInt16(predictionBLL.CalculateAgeCorrect(persKV.Dob, startdate));
            Convert.ToInt16(predictionBLL.CalculateAgeCorrect(persKV.Dob, enddate));
            if (startdate < persKV.Dob)
            {
                num1 = 1;
            }
            string[] str = new string[] { startdate.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", startdate.ToString("%M")), persKV.Language, persKV.Paid, true), " ", startdate.ToString("yyyy") };
            string.Concat(str);
            str = new string[] { enddate.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", enddate.ToString("%M")), persKV.Language, persKV.Paid, true), " ", enddate.ToString("yyyy") };
            string.Concat(str);
            houses = houses.Trim();
            char[] chrArray = new char[] { ' ' };
            string[] strArrays = houses.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string str1 = strArrays[i];
                kPDashafalVO = new KPDashafalVO();
                List<KPDashafalVO> list = (
                    from Map in kPDAO.Get_Dashafal(planet, Convert.ToInt16(str1))
                    where Map.Ptype == ptype
                    orderby Map.Ptype
                    select Map).ToList<KPDashafalVO>();
                if ((num1 < 0 ? false : num1 <= 12))
                {
                    list = (
                        from Map in list
                        where (Map.shishu ? true : Map.bachpan)
                        select Map).ToList<KPDashafalVO>();
                }
                if ((num1 < 13 ? false : num1 <= 20))
                {
                    list = (
                        from Map in list
                        where Map.kishor
                        select Map).ToList<KPDashafalVO>();
                }
                if ((num1 < 21 ? false : num1 <= 35))
                {
                    list = (
                        from Map in list
                        where Map.yuva
                        select Map).ToList<KPDashafalVO>();
                }
                if (num1 >= 36)
                {
                    list = (
                        from Map in list
                        where (Map.madhya ? true : Map.budhapa)
                        select Map).ToList<KPDashafalVO>();
                }
                List<KPDashafalVO> kPDashafalVOs1 = new List<KPDashafalVO>();
                kPDashafalVOs1 = list;
                if (persKV.Male)
                {
                    list = (
                        from Map in kPDashafalVOs1
                        where (!Map.common ? false : !Map.female)
                        select Map).ToList<KPDashafalVO>();
                    list.AddRange((
                        from Map in kPDashafalVOs1
                        where Map.male
                        select Map).ToList<KPDashafalVO>());
                }
                if (!persKV.Male)
                {
                    list = (
                        from Map in kPDashafalVOs1
                        where (!Map.common ? false : !Map.male)
                        select Map).ToList<KPDashafalVO>();
                    list.AddRange((
                        from Map in kPDashafalVOs1
                        where Map.female
                        select Map).ToList<KPDashafalVO>());
                }
                foreach (KPDashafalVO kPDashafalVO1 in
                    from Map in list
                    where Map.Ptype == ptype
                    select Map)
                {
                    if (!nums.Exists((short Map) => Map == kPDashafalVO1.Sno))
                    {
                        if (persKV.ShowRef)
                        {
                            str = new string[] { KPBLL.planet_list[kPDashafalVO1.Planet - 1].Hindi, " ", null, null, null, null };
                            house = kPDashafalVO1.House;
                            str[2] = house.ToString();
                            str[3] = " [A_dashafal : ";
                            house = kPDashafalVO1.Sno;
                            str[4] = house.ToString();
                            str[5] = "]  ";
                            kPDashafalVO.Pred_Hindi = string.Concat(str);
                        }
                        KPDashafalVO kPDashafalVO2 = kPDashafalVO;
                        kPDashafalVO2.Pred_Hindi = string.Concat(kPDashafalVO2.Pred_Hindi, kPDashafalVO1.Pred_Hindi);
                        kPDashafalVO.bachpan = kPDashafalVO1.bachpan;
                        kPDashafalVO.brother = kPDashafalVO1.brother;
                        kPDashafalVO.budhapa = kPDashafalVO1.budhapa;
                        kPDashafalVO.children = kPDashafalVO1.children;
                        kPDashafalVO.common = kPDashafalVO1.common;
                        kPDashafalVO.disease = kPDashafalVO1.disease;
                        kPDashafalVO.female = kPDashafalVO1.female;
                        kPDashafalVO.general = kPDashafalVO1.general;
                        kPDashafalVO.House = kPDashafalVO1.House;
                        kPDashafalVO.Isbad = kPDashafalVO1.Isbad;
                        kPDashafalVO.kishor = kPDashafalVO1.kishor;
                        kPDashafalVO.love_affair = kPDashafalVO1.love_affair;
                        kPDashafalVO.madhya = kPDashafalVO1.madhya;
                        kPDashafalVO.male = kPDashafalVO1.male;
                        kPDashafalVO.married = kPDashafalVO1.married;
                        kPDashafalVO.mother_father = kPDashafalVO1.mother_father;
                        kPDashafalVO.occupation = kPDashafalVO1.occupation;
                        kPDashafalVO.Planet = kPDashafalVO1.Planet;
                        kPDashafalVO.Pred_English = kPDashafalVO1.Pred_English;
                        kPDashafalVO.Pred_Hindi = kPDashafalVO1.Pred_Hindi;
                        kPDashafalVO.Ptype = kPDashafalVO1.Ptype;
                        kPDashafalVO.shishu = kPDashafalVO1.shishu;
                        kPDashafalVO.Sno = kPDashafalVO1.Sno;
                        kPDashafalVO.Upay = kPDashafalVO1.Upay;
                        kPDashafalVO.VeryBad = kPDashafalVO1.VeryBad;
                        kPDashafalVO.wealth = kPDashafalVO1.wealth;
                        kPDashafalVO.yuva = kPDashafalVO1.yuva;
                        if (!kPDashafalVO1.Isbad)
                        {
                            KPDashafalVO kPDashafalVO3 = kPDashafalVO;
                            kPDashafalVO3.Pred_Hindi = string.Concat(kPDashafalVO3.Pred_Hindi, "\r\n\r\n");
                        }
                        if ((ptype != "vfal" ? false : kPDashafalVO1.Isbad))
                        {
                            KPRemediesVO kPRemediesVO = (
                                from Map in KPBLL.Remedy_List_IA
                                where (Map.Planet != kPDashafalVO1.Planet ? false : Map.House == kPDashafalVO1.House)
                                select Map).FirstOrDefault<KPRemediesVO>();
                            if (kPRemediesVO != null)
                            {
                                kPUpayList = new KPUpayList();
                                num = (long)(this.upay_list.Count<KPUpayList>() + 1);
                                house = kPRemediesVO.Sno;
                                kPUpayList.Sno = (long)Convert.ToInt16(house.ToString());
                                house = kPRemediesVO.Sno;
                                kPUpayList.Code = (long)Convert.ToInt16(house.ToString());
                                kPUpayList.FakeCode = num;
                                kPUpayList.Upay = kPRemediesVO.Pred_Hindi;
                                if (!this.upay_list.Exists((KPUpayList Map) => Map.Sno == (long)kPRemediesVO.Sno))
                                {
                                    this.upay_list.Add(kPUpayList);
                                }
                                KPDashafalVO kPDashafalVO4 = kPDashafalVO;
                                predHindi = kPDashafalVO4.Pred_Hindi;
                                str = new string[] { predHindi, "  ", predictionBLL.GetCodeLang("upay", persKV.Language, true, true), " ", num.ToString(), "\r\n\r\n" };
                                kPDashafalVO4.Pred_Hindi = string.Concat(str);
                            }
                        }
                        if ((ptype != "mfal" ? false : kPDashafalVO1.Isbad))
                        {
                            KPRemediesVO kPRemediesVO1 = (
                                from Map in KPBLL.Remedy_List_VFAL
                                where (Map.Planet != kPDashafalVO1.Planet ? false : Map.House == kPDashafalVO1.House)
                                select Map).FirstOrDefault<KPRemediesVO>();
                            if (kPRemediesVO1 != null)
                            {
                                kPUpayList = new KPUpayList();
                                num = (long)(this.upay_list.Count<KPUpayList>() + 1);
                                house = kPRemediesVO1.Sno;
                                kPUpayList.Sno = (long)Convert.ToInt16(house.ToString());
                                house = kPRemediesVO1.Sno;
                                kPUpayList.Code = (long)Convert.ToInt16(house.ToString());
                                kPUpayList.FakeCode = num;
                                kPUpayList.Upay = kPRemediesVO1.Pred_Hindi;
                                if (!this.upay_list.Exists((KPUpayList Map) => Map.Sno == (long)kPRemediesVO1.Sno))
                                {
                                    this.upay_list.Add(kPUpayList);
                                }
                                KPDashafalVO kPDashafalVO5 = kPDashafalVO;
                                predHindi = kPDashafalVO5.Pred_Hindi;
                                str = new string[] { predHindi, "  ", predictionBLL.GetCodeLang("upay", persKV.Language, true, true), " ", num.ToString(), "\r\n\r\n" };
                                kPDashafalVO5.Pred_Hindi = string.Concat(str);
                            }
                        }
                    }
                    nums.Add(kPDashafalVO1.Sno);
                }
                kPDashafalVOs.Add(kPDashafalVO);
            }
            return kPDashafalVOs;
        }

        public string Get_Cat_Fal(List<KPPlanetMappingVO> kp_chart, List<KPHouseMappingVO> cusp_house, KundliVO persKV, bool include, short age, ProductSettingsVO prod, bool first_block_only)
        {
            string str;
            string str1 = "";
            PredictionBLL predictionBLL = new PredictionBLL();
            List<KPDashaVO> kPDashaVOs = new List<KPDashaVO>();
            List<KPDashaVO> antarDasha = new List<KPDashaVO>();
            List<KPDashaVO> kPDashaVOs1 = new List<KPDashaVO>();
            KPDAO kPDAO = new KPDAO();
            kPDashaVOs = this.Get_Dasha(cusp_house, kp_chart, persKV, include);
            string str2 = "";
            string str3 = "";
            DateTime dob = persKV.Dob;
            DateTime dateTime = dob.AddYears(age);
            KPDashaVO kPDashaVO = new KPDashaVO();
            kPDashaVO = (
                from Map in kPDashaVOs
                where Map.EndDate >= dateTime
                select Map).FirstOrDefault<KPDashaVO>();
            antarDasha = this.Get_Antar_Dasha(kPDashaVO.StartDate, kPDashaVO.EndDate, kPDashaVO.Planet, kp_chart, include);
            antarDasha = (
                from Map in antarDasha
                where Map.EndDate >= persKV.Dob
                select Map).ToList<KPDashaVO>();
            short house = (
                from Map in kp_chart
                where Map.Planet == kPDashaVO.Planet
                select Map).SingleOrDefault<KPPlanetMappingVO>().House;
            this.Get_Signi_String(kPDashaVO.Planet, kp_chart, include);
            if ((
                from Map in antarDasha
                where Map.EndDate >= dateTime
                select Map).FirstOrDefault<KPDashaVO>().EndDate <= DateTime.Now)
            {
                dob = persKV.Dob;
                dateTime = dob.AddYears(age);
            }
            if (Convert.ToInt16(predictionBLL.CalculateAgeCorrect(persKV.Dob, this.last_antar_date)) < 100)
            {
                KPDashaVO kPDashaVO1 = (
                    from Map in antarDasha
                    where Map.EndDate >= dateTime
                    select Map).FirstOrDefault<KPDashaVO>();
                if (this.last_antar_date.Year > 1500)
                {
                    kPDashaVO = (
                        from Map in kPDashaVOs
                        where (this.last_antar_date.AddDays(1) < Map.StartDate ? false : this.last_antar_date.AddDays(1) <= Map.EndDate)
                        select Map).FirstOrDefault<KPDashaVO>();
                    antarDasha = this.Get_Antar_Dasha(kPDashaVO.StartDate, kPDashaVO.EndDate, kPDashaVO.Planet, kp_chart, include);
                    antarDasha = (
                        from Map in antarDasha
                        where Map.EndDate >= persKV.Dob
                        select Map).ToList<KPDashaVO>();
                    kPDashaVO1 = (
                        from Map in antarDasha
                        where Map.StartDate >= this.last_antar_date
                        select Map).FirstOrDefault<KPDashaVO>();
                }
                else
                {
                    kPDashaVO = (
                        from Map in kPDashaVOs
                        where Map.EndDate >= dateTime
                        select Map).FirstOrDefault<KPDashaVO>();
                    antarDasha = this.Get_Antar_Dasha(kPDashaVO.StartDate, kPDashaVO.EndDate, kPDashaVO.Planet, kp_chart, include);
                    antarDasha = (
                        from Map in antarDasha
                        where Map.EndDate >= persKV.Dob
                        select Map).ToList<KPDashaVO>();
                    kPDashaVO1 = (
                        from Map in antarDasha
                        where Map.EndDate >= dateTime
                        select Map).FirstOrDefault<KPDashaVO>();
                }
                DateTime startDate = kPDashaVO1.StartDate;
                DateTime endDate = kPDashaVO1.EndDate;
                this.last_antar_date = kPDashaVO1.EndDate;
                string[] codeLang = new string[] { startDate.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", startDate.ToString("%M")), persKV.Language, persKV.Paid, true), " ", startDate.ToString("yyyy") };
                string str4 = string.Concat(codeLang);
                if (startDate < persKV.Dob)
                {
                    codeLang = new string[5];
                    dob = persKV.Dob;
                    codeLang[0] = dob.ToString("dd");
                    codeLang[1] = " ";
                    dob = persKV.Dob;
                    codeLang[2] = predictionBLL.GetCodeLang(string.Concat("M", dob.ToString("%M")), persKV.Language, persKV.Paid, true);
                    codeLang[3] = " ";
                    dob = persKV.Dob;
                    codeLang[4] = dob.ToString("yyyy");
                    str4 = string.Concat(codeLang);
                }
                codeLang = new string[] { endDate.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", endDate.ToString("%M")), persKV.Language, persKV.Paid, true), " ", endDate.ToString("yyyy") };
                string str5 = string.Concat(codeLang);
                string str6 = "\r\n";
                KPDAO kPDAO1 = new KPDAO();
                short num = Convert.ToInt16(predictionBLL.CalculateAgeCorrect(persKV.Dob, startDate));
                Convert.ToInt16(predictionBLL.CalculateAgeCorrect(persKV.Dob, endDate));
                if (num < 0)
                {
                    num = 0;
                }
                codeLang = new string[] { "<B>", predictionBLL.GetCodeLang("mukhya", persKV.Language, persKV.Paid, true), " ", str4, predictionBLL.GetCodeLang("to", persKV.Language, persKV.Paid, true), str5, "</B>  ", str3, "\r\n" };
                str2 = string.Concat(codeLang);
                short nakLord = (
                    from Map in kp_chart
                    where Map.Planet == kPDashaVO1.Planet
                    select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
                short house1 = (
                    from Map in kp_chart
                    where Map.Planet == nakLord
                    select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                short nakLord1 = (
                    from Map in kp_chart
                    where Map.Planet == kPDashaVO1.Planet
                    select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
                if (first_block_only)
                {
                    short num1 = (
                        from Map in kp_chart
                        where Map.Planet == kPDashaVO.Planet
                        select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
                    short nakLord2 = (
                        from Map in kp_chart
                        where Map.Planet == kPDashaVO1.Planet
                        select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
                    string signiStringWithoutNakRashi = this.Get_Signi_String_Without_NakRashi(num1, kp_chart, include);
                    string signiStringWithoutNakRashi1 = this.Get_Signi_String_Without_NakRashi(nakLord2, kp_chart, include);
                    short house2 = (
                        from Map in kp_chart
                        where Map.Planet == kPDashaVO1.Planet
                        select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                    this.Get_Signi_String_Without_NakRashi(nakLord2, kp_chart, include);
                    char[] chrArray = new char[] { ' ' };
                    signiStringWithoutNakRashi1.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                    string.Concat(signiStringWithoutNakRashi, " ", signiStringWithoutNakRashi1);
                    this.prev_mix_all_fal = new List<short>();
                    str6 = string.Concat(str6, this.Get_Mix_Fal(kPDashaVO1.Planet, kp_chart, cusp_house, persKV, prod, age, false, false, "dasha", startDate, endDate));
                    if (!prod.Tool)
                    {
                        str6 = string.Concat(str6, this.Get_Mix_Fal_PlanetWise(kPDashaVO1.Planet, kp_chart, cusp_house, persKV, prod, age, false, false, startDate, endDate));
                    }
                    if ((!prod.Karyesh || str6.Length > 300 ? false : prod.Product != "disease"))
                    {
                        str6 = string.Concat(str6, this.Get_Mix_Fal_PlanetWise(kPDashaVO1.Planet, kp_chart, cusp_house, persKV, prod, age, false, true, startDate, endDate));
                    }
                    if (!this.date_list.Contains(string.Concat(str4, str5)))
                    {
                        if (str6.Length > 50)
                        {
                            str1 = string.Concat(str1, str2, "\r\n", str6);
                        }
                    }
                    this.date_list.Add(string.Concat(str4, str5));
                    str6 = "";
                }
                if (str6.Trim().Length > 50)
                {
                    str1 = string.Concat(str6, "\r\n\r\n", str1);
                }
                if (str1.Trim().Length <= 50)
                {
                    str1 = "";
                }
                str = str1;
            }
            else
            {
                str = "";
            }
            return str;
        }

        public string Get_Cat_Products_Mobile(ProductSettingsVO prod)
        {
            PredictionBLL predictionBLL = new PredictionBLL();
            string str = "";
            string str1 = "";
            KundliBLL kundliBLL = new KundliBLL();
            str1 = kundliBLL.Gen_Kunda(prod.Online_Result, 500f, Convert.ToInt16(prod.Rotate));
            KundliVO kundliVO = new KundliVO();
            PredictionBLL predictionBLL1 = new PredictionBLL();
            PredictionBLL predictionBLL2 = new PredictionBLL();
            this.upay_list = new List<KPUpayList>();
            this.date_list = new List<string>();
            string onlineResult = prod.Online_Result;
            char[] chrArray = new char[] { ',' };
            string[] strArrays = onlineResult.Split(chrArray);
            List<KundliMappingVO> kundliMappingVOs = new List<KundliMappingVO>();
            string str2 = strArrays[2];
            string str3 = strArrays[3];
            chrArray = new char[] { 'E' };
            str2 = str2.TrimEnd(chrArray);
            chrArray = new char[] { 'N' };
            str2 = str2.TrimEnd(chrArray);
            chrArray = new char[] { 'S' };
            str2 = str2.TrimEnd(chrArray);
            chrArray = new char[] { 'W' };
            str2 = str2.TrimEnd(chrArray);
            chrArray = new char[] { 'E' };
            str3 = str3.TrimEnd(chrArray);
            chrArray = new char[] { 'N' };
            str3 = str3.TrimEnd(chrArray);
            chrArray = new char[] { 'S' };
            str3 = str3.TrimEnd(chrArray);
            chrArray = new char[] { 'W' };
            str3 = str3.TrimEnd(chrArray);
            string str4 = strArrays[0];
            chrArray = new char[] { '/' };
            string str5 = str4.Split(chrArray)[0];
            string str6 = strArrays[0];
            chrArray = new char[] { '/' };
            string str7 = str6.Split(chrArray)[1];
            string str8 = strArrays[0];
            chrArray = new char[] { '/' };
            string str9 = str8.Split(chrArray)[2];
            string str10 = strArrays[1];
            chrArray = new char[] { ':' };
            string str11 = str10.Split(chrArray)[0];
            string str12 = strArrays[1];
            chrArray = new char[] { ':' };
            kundliVO = predictionBLL1.map_persKV(str1, "", "", str5, str7, str9, str11, str12.Split(chrArray)[1], "00", "admin", str2, str3, strArrays[4], true, prod.Lang, prod.ShowRef, prod.Male, "YICC", "YICC", "YICC", "YICC", "YICC", prod.Product, "01", "01", "2000", prod.Rotate);
            kundliVO.FileCode = prod.Sno.ToString();
            kundliMappingVOs = predictionBLL2.map_kundali(str1, true);
            List<KPPlanetMappingVO> kPPlanetMappingVOs = new List<KPPlanetMappingVO>();
            List<KPHouseMappingVO> kPHouseMappingVOs = new List<KPHouseMappingVO>();
            this.Process_Planet_Lagan(str1, ref kPPlanetMappingVOs, ref kPHouseMappingVOs, kundliVO.Rotate, false);
            kPPlanetMappingVOs = this.Process_KPChart_GoodBad(kPPlanetMappingVOs, kundliVO, prod);
            if (prod.Category == "education")
            {
                str = string.Concat(str, this.Get_School_Kids(str1, kundliVO, false, prod), "\r\n\r\n");
            }
            if (prod.Category == "disease")
            {
                str = string.Concat(str, "<B>", predictionBLL.GetCodeLang("kphealth", kundliVO.Language, true, true), "</B>");
            }
            if (prod.Category == "married")
            {
                str = string.Concat(str, "<B>", predictionBLL.GetCodeLang("kpmarriage", kundliVO.Language, true, true), "</B>");
            }
            if (prod.Category == "occupation")
            {
                str = string.Concat(str, "<B>", predictionBLL.GetCodeLang("kpoccupation", kundliVO.Language, true, true), "</B>");
            }
            this.last_antar_date = new DateTime();
            this.last_pryaantar_date = new DateTime();
            string str13 = "";
            str13 = string.Concat(this.Get_Only_Mahadasha(kPHouseMappingVOs, kPPlanetMappingVOs, kundliVO, prod.Include, prod.ShowUpay, prod.ShowUpayCode, prod, false), "\r\n\r\n");
            if (str13.Trim().Length > 100)
            {
                str = string.Concat(str, str13);
            }
            short currentAge = kundliVO.Current_Age;
            currentAge = Convert.ToInt16(currentAge - 2);
            for (short i = 0; i < prod.Dasha_Years; i = (short)(i + 1))
            {
                currentAge = Convert.ToInt16(currentAge + 1);
                str = string.Concat(str, this.Get_Dashafal_Age_Wise(kPPlanetMappingVOs, kPHouseMappingVOs, kundliVO, prod.Include, currentAge, prod, true));
            }
            str = str.Replace("\r\n\r\n\r\n\r\n", "\r\n\r\n");
            str = str.Replace("\r\n\r\n\r\n", "\r\n\r\n");
            return str;
        }

        public string Get_Chain_Free(string houses, DateTime startdate, DateTime enddate, KundliVO persKV)
        {
            string str = "";
            PredictionBLL predictionBLL = new PredictionBLL();
            KPDAO kPDAO = new KPDAO();
            houses = houses.Trim();
            List<KPDashafalChainVO> list = (
                from Map in kPDAO.Get_Dashafal_Chain()
                where Map.Ptype == "multi"
                select Map).ToList<KPDashafalChainVO>();
            foreach (KPDashafalChainVO kPDashafalChainVO in
                from Map in list
                where Map.Ptype == "multi"
                select Map)
            {
                short num = 0;
                char[] chrArray = new char[] { ' ' };
                string[] strArrays = houses.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                string signi = kPDashafalChainVO.Signi;
                chrArray = new char[] { ',' };
                string[] strArrays1 = signi.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < (int)strArrays1.Length; i++)
                {
                    if (strArrays.Contains<string>(strArrays1[i].Trim()))
                    {
                        num = (short)(num + 1);
                    }
                }
                string signi1 = kPDashafalChainVO.Signi;
                chrArray = new char[] { ',' };
                if (num == (int)signi1.Split(chrArray, StringSplitOptions.RemoveEmptyEntries).Length)
                {
                    if (!this.all_fal_dasha_chain.Exists((short Map) => Map == kPDashafalChainVO.Sno))
                    {
                        if (persKV.ShowRef)
                        {
                            string str1 = str;
                            string[] signi2 = new string[] { str1, kPDashafalChainVO.Signi, " [A_kp_dasha_chain : ", null, null };
                            signi2[3] = kPDashafalChainVO.Sno.ToString();
                            signi2[4] = "]  ";
                            str = string.Concat(signi2);
                            str = string.Concat(str, kPDashafalChainVO.Pred_Hindi, "\r\n\r\n");
                        }
                        this.all_fal_dasha_chain.Add(kPDashafalChainVO.Sno);
                    }
                }
            }
            return str;
        }

        public string Get_Cusp_Pred(List<KPHouseMappingVO> cusp_house, List<KPPlanetMappingVO> kp_chart, KundliVO persKV, bool include_yuti_drishti, bool showref, bool brief)
        {
            string str = "";
            PredictionBLL predictionBLL = new PredictionBLL();
            List<KP_Sublord_Pred> kPSublordPreds = new List<KP_Sublord_Pred>();
            KPDAO kPDAO = new KPDAO();
            List<long> nums = new List<long>();
            if (brief)
            {
                cusp_house = (
                    from Map in cusp_house
                    where (Map.House == 1 || Map.House == 3 || Map.House == 6 || Map.House == 7 || Map.House == 8 || Map.House == 9 ? true : Map.House == 12)
                    select Map).ToList<KPHouseMappingVO>();
            }
            foreach (KPHouseMappingVO cuspHouse in cusp_house)
            {
                short subLord = (
                    from Map in cusp_house
                    where Map.House == cuspHouse.House
                    select Map).SingleOrDefault<KPHouseMappingVO>().Sub_Lord;
                short nakLord = (
                    from Map in kp_chart
                    where Map.Planet == subLord
                    select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
                List<KPSigniVO> kPSigniVOs = new List<KPSigniVO>();
                kPSigniVOs = (
                    from Map in kp_chart
                    where Map.Planet == nakLord
                    select Map).SingleOrDefault<KPPlanetMappingVO>().Signi;
                if (!include_yuti_drishti)
                {
                    kPSigniVOs = (
                        from Map in kPSigniVOs
                        where (Map.Rule == 1 ? true : Map.Rule == 2)
                        select Map).ToList<KPSigniVO>();
                }
                foreach (KPSigniVO kPSigniVO in kPSigniVOs)
                {
                    kPSublordPreds.AddRange((
                        from Map in kPDAO.Get_KP_Cusp_Pred(showref, kPSigniVO.WhichPlanet)
                        where (Map.Sublord != kPSigniVO.Signi ? false : Map.House == cuspHouse.House)
                        select Map).ToList<KP_Sublord_Pred>());
                }
            }
            string str1 = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            string str6 = "";
            string str7 = "";
            string str8 = "";
            string str9 = "";
            string str10 = "";
            string str11 = "";
            string str12 = "";
            string str13 = "";
            string str14 = "";
            string str15 = "";
            string str16 = "";
            if (brief)
            {
                kPSublordPreds = (
                    from Map in kPSublordPreds
                    where (Map.PType == "health" || Map.PType == "nature" ? true : Map.PType == "marriage")
                    select Map).ToList<KP_Sublord_Pred>();
            }
            foreach (KP_Sublord_Pred kPSublordPred in kPSublordPreds)
            {
                str15 = "";
                if (!nums.Contains(kPSublordPred.Sno))
                {
                    if (persKV.Language.ToLower() == "hindi")
                    {
                        str16 = string.Concat(str16, kPSublordPred.Pred_Hindi, "\r\n\r\n");
                    }
                    if (persKV.Language.ToLower() == "english")
                    {
                        str16 = string.Concat(str16, kPSublordPred.Pred_English, "\r\n\r\n");
                    }
                }
                if (!brief)
                {
                    if (!nums.Contains(kPSublordPred.Sno))
                    {
                        if (persKV.Language.ToLower() == "hindi")
                        {
                            str15 = string.Concat(kPSublordPred.Pred_Hindi, "\r\n\r\n");
                        }
                        if (persKV.Language.ToLower() == "english")
                        {
                            str15 = string.Concat(kPSublordPred.Pred_English, "\r\n\r\n");
                        }
                    }
                    if ((!(kPSublordPred.PType == "general") || str15.Trim().Length <= 0 ? false : !kPSublordPred.Isbad))
                    {
                        str1 = string.Concat(str1, str15);
                    }
                    if ((!(kPSublordPred.PType == "nature") || str15.Trim().Length <= 0 ? false : !kPSublordPred.Isbad))
                    {
                        str2 = string.Concat(str2, str15);
                    }
                    if ((!(kPSublordPred.PType == "education") || str15.Trim().Length <= 0 ? false : !kPSublordPred.Isbad))
                    {
                        str3 = string.Concat(str3, str15);
                    }
                    if ((!(kPSublordPred.PType == "occupation") || str15.Trim().Length <= 0 ? false : !kPSublordPred.Isbad))
                    {
                        str4 = string.Concat(str4, str15);
                    }
                    if ((!(kPSublordPred.PType == "marriage") || str15.Trim().Length <= 0 ? false : !kPSublordPred.Isbad))
                    {
                        str5 = string.Concat(str5, str15);
                    }
                    if ((!(kPSublordPred.PType == "health") || str15.Trim().Length <= 0 ? false : !kPSublordPred.Isbad))
                    {
                        str6 = string.Concat(str6, str15);
                    }
                    if ((!(kPSublordPred.PType == "children") || str15.Trim().Length <= 0 ? false : !kPSublordPred.Isbad))
                    {
                        str7 = string.Concat(str7, str15);
                    }
                    if ((!(kPSublordPred.PType == "general") || str15.Trim().Length <= 0 ? false : kPSublordPred.Isbad))
                    {
                        str8 = string.Concat(str8, str15);
                    }
                    if ((!(kPSublordPred.PType == "nature") || str15.Trim().Length <= 0 ? false : kPSublordPred.Isbad))
                    {
                        str9 = string.Concat(str9, str15);
                    }
                    if ((!(kPSublordPred.PType == "education") || str15.Trim().Length <= 0 ? false : kPSublordPred.Isbad))
                    {
                        str10 = string.Concat(str10, str15);
                    }
                    if ((!(kPSublordPred.PType == "occupation") || str15.Trim().Length <= 0 ? false : kPSublordPred.Isbad))
                    {
                        str11 = string.Concat(str11, str15);
                    }
                    if ((!(kPSublordPred.PType == "marriage") || str15.Trim().Length <= 0 ? false : kPSublordPred.Isbad))
                    {
                        str12 = string.Concat(str12, str15);
                    }
                    if ((!(kPSublordPred.PType == "health") || str15.Trim().Length <= 0 ? false : kPSublordPred.Isbad))
                    {
                        str13 = string.Concat(str13, str15);
                    }
                    if ((!(kPSublordPred.PType == "children") || str15.Trim().Length <= 0 ? false : kPSublordPred.Isbad))
                    {
                        str14 = string.Concat(str14, str15);
                    }
                }
                nums.Add(kPSublordPred.Sno);
            }
            if (!brief)
            {
                str = string.Concat(str, predictionBLL.GetCodeLang("kpheading", persKV.Language, true, true), "\r\n\r\n");
                str = string.Concat(str, predictionBLL.GetCodeLang("kpnote", persKV.Language, true, true), "\r\n\r\n");
                if ((str1.Trim().Length > 0 ? true : str8.Trim().Length > 0))
                {
                    str = string.Concat(str, predictionBLL.GetCodeLang("kpgeneral", persKV.Language, true, true), "\r\n\r\n");
                    if (str1.Trim().Length > 0)
                    {
                        str = string.Concat(str, predictionBLL.GetCodeLang("kpgeneralgood", persKV.Language, true, true), "\r\n");
                        str = string.Concat(str, str1);
                    }
                    if (str8.Trim().Length > 0)
                    {
                        str = string.Concat(str, predictionBLL.GetCodeLang("kpgeneralbad", persKV.Language, true, true), "\r\n");
                        str = string.Concat(str, str8);
                    }
                }
                if ((str2.Trim().Length > 0 ? true : str9.Trim().Length > 0))
                {
                    str = string.Concat(str, predictionBLL.GetCodeLang("kpnature", persKV.Language, true, true), "\r\n\r\n");
                    if (str2.Trim().Length > 0)
                    {
                        str = string.Concat(str, predictionBLL.GetCodeLang("kpnaturegood", persKV.Language, true, true), "\r\n");
                        str = string.Concat(str, str2);
                    }
                    if (str9.Trim().Length > 0)
                    {
                        str = string.Concat(str, predictionBLL.GetCodeLang("kpnaturebad", persKV.Language, true, true), "\r\n");
                        str = string.Concat(str, str9);
                    }
                }
                if ((str3.Trim().Length > 0 ? true : str10.Trim().Length > 0))
                {
                    str = string.Concat(str, predictionBLL.GetCodeLang("kpeducation", persKV.Language, true, true), "\r\n\r\n");
                    if (str3.Trim().Length > 0)
                    {
                        str = string.Concat(str, predictionBLL.GetCodeLang("kpeducationgood", persKV.Language, true, true), "\r\n");
                        str = string.Concat(str, str3);
                    }
                    if (str10.Trim().Length > 0)
                    {
                        str = string.Concat(str, predictionBLL.GetCodeLang("kpeducationbad", persKV.Language, true, true), "\r\n");
                        str = string.Concat(str, str10);
                    }
                }
                if ((str4.Trim().Length > 0 ? true : str11.Trim().Length > 0))
                {
                    str = string.Concat(str, predictionBLL.GetCodeLang("kpoccupation", persKV.Language, true, true), "\r\n\r\n");
                    if (str4.Trim().Length > 0)
                    {
                        str = string.Concat(str, predictionBLL.GetCodeLang("kpoccupationgood", persKV.Language, true, true), "\r\n");
                        str = string.Concat(str, str4);
                    }
                    if (str11.Trim().Length > 0)
                    {
                        str = string.Concat(str, predictionBLL.GetCodeLang("kpoccupationbad", persKV.Language, true, true), "\r\n");
                        str = string.Concat(str, str11);
                    }
                }
                if ((str5.Trim().Length > 0 ? true : str12.Trim().Length > 0))
                {
                    str = string.Concat(str, predictionBLL.GetCodeLang("kpmarriage", persKV.Language, true, true), "\r\n\r\n");
                    if (str5.Trim().Length > 0)
                    {
                        str = string.Concat(str, predictionBLL.GetCodeLang("kpmarriagegood", persKV.Language, true, true), "\r\n");
                        str = string.Concat(str, str5);
                    }
                    if (str12.Trim().Length > 0)
                    {
                        str = string.Concat(str, predictionBLL.GetCodeLang("kpmarriagebad", persKV.Language, true, true), "\r\n");
                        str = string.Concat(str, str12);
                    }
                }
                if ((str6.Trim().Length > 0 ? true : str13.Trim().Length > 0))
                {
                    str = string.Concat(str, predictionBLL.GetCodeLang("kphealth", persKV.Language, true, true), "\r\n\r\n");
                    if (str6.Trim().Length > 0)
                    {
                        str = string.Concat(str, predictionBLL.GetCodeLang("kphealthgood", persKV.Language, true, true), "\r\n");
                        str = string.Concat(str, str6);
                    }
                    if (str13.Trim().Length > 0)
                    {
                        str = string.Concat(str, predictionBLL.GetCodeLang("kphealthbad", persKV.Language, true, true), "\r\n");
                        str = string.Concat(str, str13);
                    }
                }
                if ((str7.Trim().Length > 0 ? true : str14.Trim().Length > 0))
                {
                    str = string.Concat(str, predictionBLL.GetCodeLang("kpchildren", persKV.Language, true, true), "\r\n\r\n");
                    if (str7.Trim().Length > 0)
                    {
                        str = string.Concat(str, predictionBLL.GetCodeLang("kpchildrengood", persKV.Language, true, true), "\r\n");
                        str = string.Concat(str, str7);
                    }
                    if (str14.Trim().Length > 0)
                    {
                        str = string.Concat(str, predictionBLL.GetCodeLang("kpchildrenbad", persKV.Language, true, true), "\r\n");
                        str = string.Concat(str, str14);
                    }
                }
            }
            if (brief)
            {
                str = str16;
            }
            return str;
        }

        public List<KPSigniVO> Get_Cusp_Signis(List<KPHouseMappingVO> cusp_house, short houseno, bool include)
        {
            List<KPSigniVO> kPSigniVOs = new List<KPSigniVO>();
            if (houseno > 0)
            {
                cusp_house = (
                    from Map in cusp_house
                    where Map.House == houseno
                    select Map).ToList<KPHouseMappingVO>();
            }
            foreach (KPHouseMappingVO cuspHouse in cusp_house)
            {
                if (!include)
                {
                    foreach (KPSigniVO kPSigniVO in
                        from sk in cuspHouse.Signi
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
                    foreach (KPSigniVO signi in cuspHouse.Signi)
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

        public List<KPSigniVO> Get_Cusp_Signis(List<KPHouseMappingVO> cusp_house, short houseno)
        {
            List<KPSigniVO> kPSigniVOs = new List<KPSigniVO>();
            if (houseno > 0)
            {
                cusp_house = (
                    from Map in cusp_house
                    where Map.House == houseno
                    select Map).ToList<KPHouseMappingVO>();
            }
            foreach (KPHouseMappingVO cuspHouse in cusp_house)
            {
                foreach (KPSigniVO signi in cuspHouse.Signi)
                {
                    if (!kPSigniVOs.Exists((KPSigniVO Map) => Map.Signi == signi.Signi))
                    {
                        kPSigniVOs.Add(signi);
                    }
                }
            }
            return kPSigniVOs;
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

        public string Get_Dasha_Chain_Pred(string houses, DateTime startdate, DateTime enddate, KundliVO persKV, string ptype, short pryaantar_nak_swami, short pryaantar_nak_swami_house, ProductSettingsVO prod)
        {
            List<KPDashafalChainVO> kPDashafalChainVOs;
            List<KPDashafalChainVO> kPDashafalChainVOs1;
            long num;
            KPUpayList kPUpayList;
            string str;
            char[] chrArray;
            string[] strArrays;
            int i;
            string str1;
            short sno;
            long fakeCode;
            string str2 = "";
            List<short> nums = new List<short>();
            PredictionBLL predictionBLL = new PredictionBLL();
            string[] signi = new string[] { startdate.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", startdate.ToString("%M")), persKV.Language, persKV.Paid, true), " ", startdate.ToString("yyyy") };
            string.Concat(signi);
            signi = new string[] { enddate.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", enddate.ToString("%M")), persKV.Language, persKV.Paid, true), " ", enddate.ToString("yyyy") };
            string.Concat(signi);
            KPDAO kPDAO = new KPDAO();
            short num1 = Convert.ToInt16(predictionBLL.CalculateAgeCorrect(persKV.Dob, startdate));
            Convert.ToInt16(predictionBLL.CalculateAgeCorrect(persKV.Dob, enddate));
            if (startdate < persKV.Dob)
            {
                num1 = 1;
            }
            houses = houses.Trim();
            if (ptype == "single")
            {
                chrArray = new char[] { ' ' };
                strArrays = houses.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                for (i = 0; i < (int)strArrays.Length; i++)
                {
                    string str3 = strArrays[i];
                    kPDashafalChainVOs = new List<KPDashafalChainVO>();
                    if ((prod.Category == "all" ? true : prod.Category.Length <= 0))
                    {
                        kPDashafalChainVOs = (
                            from Map in kPDAO.Get_Dashafal_Chain()
                            where Map.Ptype == ptype
                            select Map).ToList<KPDashafalChainVO>();
                    }
                    if (prod.Category == "married")
                    {
                        kPDashafalChainVOs = (
                            from Map in kPDAO.Get_Dashafal_Chain()
                            where (Map.Ptype != ptype ? false : Map.married)
                            select Map).ToList<KPDashafalChainVO>();
                    }
                    if (prod.Category == "children")
                    {
                        kPDashafalChainVOs = (
                            from Map in kPDAO.Get_Dashafal_Chain()
                            where (Map.Ptype != ptype ? false : Map.children)
                            select Map).ToList<KPDashafalChainVO>();
                    }
                    if (prod.Category == "occupation")
                    {
                        kPDashafalChainVOs = (
                            from Map in kPDAO.Get_Dashafal_Chain()
                            where (Map.Ptype != ptype ? false : Map.occupation)
                            select Map).ToList<KPDashafalChainVO>();
                    }
                    if (prod.Category == "disease")
                    {
                        kPDashafalChainVOs = (
                            from Map in kPDAO.Get_Dashafal_Chain()
                            where (Map.Ptype != ptype ? false : Map.disease)
                            select Map).ToList<KPDashafalChainVO>();
                    }
                    if (prod.Category == "mother_father")
                    {
                        kPDashafalChainVOs = (
                            from Map in kPDAO.Get_Dashafal_Chain()
                            where (Map.Ptype != ptype ? false : Map.mother_father)
                            select Map).ToList<KPDashafalChainVO>();
                    }
                    if (prod.Category == "general")
                    {
                        kPDashafalChainVOs = (
                            from Map in kPDAO.Get_Dashafal_Chain()
                            where (Map.Ptype != ptype ? false : Map.general)
                            select Map).ToList<KPDashafalChainVO>();
                    }
                    kPDashafalChainVOs = (
                        from Map in kPDashafalChainVOs
                        where Map.Signi == str3
                        select Map).ToList<KPDashafalChainVO>();
                    if ((prod.Category == "all" ? true : prod.Category.Length <= 0))
                    {
                        if ((num1 < 0 ? false : num1 <= 12))
                        {
                            kPDashafalChainVOs = (
                                from Map in kPDashafalChainVOs
                                where (Map.shishu ? true : Map.bachpan)
                                select Map).ToList<KPDashafalChainVO>();
                        }
                        if ((num1 < 13 ? false : num1 <= 20))
                        {
                            kPDashafalChainVOs = (
                                from Map in kPDashafalChainVOs
                                where Map.kishor
                                select Map).ToList<KPDashafalChainVO>();
                        }
                        if ((num1 < 21 ? false : num1 <= 35))
                        {
                            kPDashafalChainVOs = (
                                from Map in kPDashafalChainVOs
                                where Map.yuva
                                select Map).ToList<KPDashafalChainVO>();
                        }
                        if (num1 >= 36)
                        {
                            kPDashafalChainVOs = (
                                from Map in kPDashafalChainVOs
                                where (Map.madhya ? true : Map.budhapa)
                                select Map).ToList<KPDashafalChainVO>();
                        }
                        kPDashafalChainVOs1 = new List<KPDashafalChainVO>();
                        kPDashafalChainVOs1 = kPDashafalChainVOs;
                        if (persKV.Male)
                        {
                            kPDashafalChainVOs = (
                                from Map in kPDashafalChainVOs1
                                where (!Map.common ? false : !Map.female)
                                select Map).ToList<KPDashafalChainVO>();
                            kPDashafalChainVOs.AddRange((
                                from Map in kPDashafalChainVOs1
                                where Map.male
                                select Map).ToList<KPDashafalChainVO>());
                        }
                        if (!persKV.Male)
                        {
                            kPDashafalChainVOs = (
                                from Map in kPDashafalChainVOs1
                                where (!Map.common ? false : !Map.male)
                                select Map).ToList<KPDashafalChainVO>();
                            kPDashafalChainVOs.AddRange((
                                from Map in kPDashafalChainVOs1
                                where Map.female
                                select Map).ToList<KPDashafalChainVO>());
                        }
                    }
                    foreach (KPDashafalChainVO kPDashafalChainVO in
                        from Map in kPDashafalChainVOs
                        where Map.Ptype == ptype
                        select Map)
                    {
                        if (!nums.Exists((short Map) => Map == kPDashafalChainVO.Sno))
                        {
                            if (persKV.ShowRef)
                            {
                                str1 = str2;
                                signi = new string[] { str1, "( ", kPDashafalChainVO.Signi, ") [A_kp_dasha_chain : ", null, null };
                                sno = kPDashafalChainVO.Sno;
                                signi[4] = sno.ToString();
                                signi[5] = "]  ";
                                str2 = string.Concat(signi);
                            }
                            if (persKV.Language.ToLower() == "hindi")
                            {
                                str2 = string.Concat(str2, kPDashafalChainVO.Pred_Hindi);
                            }
                            if (persKV.Language.ToLower() == "english")
                            {
                                str2 = string.Concat(str2, kPDashafalChainVO.Pred_English);
                            }
                            KPRemediesVO kPRemediesVO = new KPRemediesVO();
                            if (prod.ShowUpayCode)
                            {
                                kPRemediesVO = (
                                    from Map in KPBLL.Remedy_List_IA
                                    where (Map.Planet != pryaantar_nak_swami ? false : Map.House == pryaantar_nak_swami_house)
                                    select Map).FirstOrDefault<KPRemediesVO>();
                                if (kPDashafalChainVO.Isbad)
                                {
                                    if (kPRemediesVO != null)
                                    {
                                        kPUpayList = new KPUpayList();
                                        if (this.upay_list.Exists((KPUpayList Map) => Map.Sno == (long)kPRemediesVO.Sno))
                                        {
                                            fakeCode = (
                                                from Map in this.upay_list
                                                where Map.Sno.ToString() == kPRemediesVO.Sno.ToString()
                                                select Map).SingleOrDefault<KPUpayList>().FakeCode;
                                            str = fakeCode.ToString();
                                            if (!persKV.ShowRef)
                                            {
                                                str1 = str2;
                                                signi = new string[] { str1, "  <I>", predictionBLL.GetCodeLang("upay", persKV.Language, true, true), "</I> ", str.ToString(), this.Gen_Link((long)kPRemediesVO.Sno, prod.Gen_Link, Convert.ToInt64(str), false, (long)kPDashafalChainVO.Sno, "R") };
                                                str2 = string.Concat(signi);
                                            }
                                            else
                                            {
                                                str1 = str2;
                                                signi = new string[] { str1, "  [ A_kp_remedy Chain : ", null, null, null, null, null };
                                                sno = kPRemediesVO.Sno;
                                                signi[2] = sno.ToString();
                                                signi[3] = " ] ";
                                                signi[4] = predictionBLL.GetCodeLang("upay", persKV.Language, true, true);
                                                signi[5] = " ";
                                                signi[6] = str.ToString();
                                                str2 = string.Concat(signi);
                                            }
                                        }
                                        else
                                        {
                                            num = (long)(this.upay_list.Count<KPUpayList>() + 1);
                                            sno = kPRemediesVO.Sno;
                                            kPUpayList.Sno = (long)Convert.ToInt16(sno.ToString());
                                            sno = kPRemediesVO.Sno;
                                            kPUpayList.Code = (long)Convert.ToInt16(sno.ToString());
                                            kPUpayList.FakeCode = num;
                                            if (persKV.Language.ToLower() == "hindi")
                                            {
                                                kPUpayList.Upay = kPRemediesVO.Pred_Hindi;
                                            }
                                            if (persKV.Language.ToLower() == "english")
                                            {
                                                kPUpayList.Upay = kPRemediesVO.Pred_English;
                                            }
                                            this.upay_list.Add(kPUpayList);
                                            if (!persKV.ShowRef)
                                            {
                                                str1 = str2;
                                                signi = new string[] { str1, " <I>", predictionBLL.GetCodeLang("upay", persKV.Language, true, true), "</I>", num.ToString(), this.Gen_Link((long)kPRemediesVO.Sno, prod.Gen_Link, num, false, (long)kPDashafalChainVO.Sno, "R"), "\r\n\r\n" };
                                                str2 = string.Concat(signi);
                                            }
                                            else
                                            {
                                                str1 = str2;
                                                signi = new string[] { str1, "  [ A_kp_remedy Chain : ", null, null, null, null, null };
                                                sno = kPRemediesVO.Sno;
                                                signi[2] = sno.ToString();
                                                signi[3] = " ] ";
                                                signi[4] = predictionBLL.GetCodeLang("upay", persKV.Language, true, true);
                                                signi[5] = " ";
                                                signi[6] = num.ToString();
                                                str2 = string.Concat(signi);
                                            }
                                        }
                                    }
                                }
                            }
                            if ((!kPDashafalChainVO.Isbad || kPRemediesVO == null ? true : !prod.ShowUpayCode))
                            {
                                str2 = string.Concat(str2, "\r\n\r\n");
                            }
                        }
                        nums.Add(kPDashafalChainVO.Sno);
                    }
                }
            }
            if (ptype == "multi")
            {
                kPDashafalChainVOs = new List<KPDashafalChainVO>();
                if ((prod.Category == "all" ? true : prod.Category.Length <= 0))
                {
                    kPDashafalChainVOs = (
                        from Map in kPDAO.Get_Dashafal_Chain()
                        where Map.Ptype == ptype
                        select Map).ToList<KPDashafalChainVO>();
                }
                if (prod.Category == "married")
                {
                    kPDashafalChainVOs = (
                        from Map in kPDAO.Get_Dashafal_Chain()
                        where (Map.Ptype != ptype ? false : Map.married)
                        select Map).ToList<KPDashafalChainVO>();
                }
                if (prod.Category == "children")
                {
                    kPDashafalChainVOs = (
                        from Map in kPDAO.Get_Dashafal_Chain()
                        where (Map.Ptype != ptype ? false : Map.children)
                        select Map).ToList<KPDashafalChainVO>();
                }
                if (prod.Category == "occupation")
                {
                    kPDashafalChainVOs = (
                        from Map in kPDAO.Get_Dashafal_Chain()
                        where (Map.Ptype != ptype ? false : Map.occupation)
                        select Map).ToList<KPDashafalChainVO>();
                }
                if (prod.Category == "disease")
                {
                    kPDashafalChainVOs = (
                        from Map in kPDAO.Get_Dashafal_Chain()
                        where (Map.Ptype != ptype ? false : Map.disease)
                        select Map).ToList<KPDashafalChainVO>();
                }
                if (prod.Category == "mother_father")
                {
                    kPDashafalChainVOs = (
                        from Map in kPDAO.Get_Dashafal_Chain()
                        where (Map.Ptype != ptype ? false : Map.mother_father)
                        select Map).ToList<KPDashafalChainVO>();
                }
                if (prod.Category == "general")
                {
                    kPDashafalChainVOs = (
                        from Map in kPDAO.Get_Dashafal_Chain()
                        where (Map.Ptype != ptype ? false : Map.general)
                        select Map).ToList<KPDashafalChainVO>();
                }
                if ((prod.Category == "all" ? true : prod.Category.Length <= 0))
                {
                    if ((num1 < 0 ? false : num1 <= 12))
                    {
                        kPDashafalChainVOs = (
                            from Map in kPDashafalChainVOs
                            where (Map.shishu ? true : Map.bachpan)
                            select Map).ToList<KPDashafalChainVO>();
                    }
                    if ((num1 < 13 ? false : num1 <= 20))
                    {
                        kPDashafalChainVOs = (
                            from Map in kPDashafalChainVOs
                            where Map.kishor
                            select Map).ToList<KPDashafalChainVO>();
                    }
                    if ((num1 < 21 ? false : num1 <= 35))
                    {
                        kPDashafalChainVOs = (
                            from Map in kPDashafalChainVOs
                            where Map.yuva
                            select Map).ToList<KPDashafalChainVO>();
                    }
                    if (num1 >= 36)
                    {
                        kPDashafalChainVOs = (
                            from Map in kPDashafalChainVOs
                            where (Map.madhya ? true : Map.budhapa)
                            select Map).ToList<KPDashafalChainVO>();
                    }
                    kPDashafalChainVOs1 = new List<KPDashafalChainVO>();
                    kPDashafalChainVOs1 = kPDashafalChainVOs;
                    if (persKV.Male)
                    {
                        kPDashafalChainVOs = (
                            from Map in kPDashafalChainVOs1
                            where (!Map.common ? false : !Map.female)
                            select Map).ToList<KPDashafalChainVO>();
                        kPDashafalChainVOs.AddRange((
                            from Map in kPDashafalChainVOs1
                            where Map.male
                            select Map).ToList<KPDashafalChainVO>());
                    }
                    if (!persKV.Male)
                    {
                        kPDashafalChainVOs = (
                            from Map in kPDashafalChainVOs1
                            where (!Map.common ? false : !Map.male)
                            select Map).ToList<KPDashafalChainVO>();
                        kPDashafalChainVOs.AddRange((
                            from Map in kPDashafalChainVOs1
                            where Map.female
                            select Map).ToList<KPDashafalChainVO>());
                    }
                }
                foreach (KPDashafalChainVO kPDashafalChainVO1 in
                    from Map in kPDashafalChainVOs
                    where Map.Ptype == ptype
                    select Map)
                {
                    short num2 = 0;
                    chrArray = new char[] { ' ' };
                    string[] strArrays1 = houses.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                    string signi1 = kPDashafalChainVO1.Signi;
                    chrArray = new char[] { ',' };
                    strArrays = signi1.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                    for (i = 0; i < (int)strArrays.Length; i++)
                    {
                        if (strArrays1.Contains<string>(strArrays[i].Trim()))
                        {
                            num2 = (short)(num2 + 1);
                        }
                    }
                    string signi2 = kPDashafalChainVO1.Signi;
                    chrArray = new char[] { ',' };
                    if (num2 == (int)signi2.Split(chrArray, StringSplitOptions.RemoveEmptyEntries).Length)
                    {
                        if (!nums.Exists((short Map) => Map == kPDashafalChainVO1.Sno))
                        {
                            if (persKV.ShowRef)
                            {
                                str1 = str2;
                                signi = new string[] { str1, "( ", kPDashafalChainVO1.Signi, ") [A_kp_dasha_chain : ", null, null };
                                sno = kPDashafalChainVO1.Sno;
                                signi[4] = sno.ToString();
                                signi[5] = "]  ";
                                str2 = string.Concat(signi);
                            }
                            if (persKV.Language.ToLower() == "hindi")
                            {
                                str2 = string.Concat(str2, kPDashafalChainVO1.Pred_Hindi);
                            }
                            if (persKV.Language.ToLower() == "english")
                            {
                                str2 = string.Concat(str2, kPDashafalChainVO1.Pred_English);
                            }
                            KPRemediesVO kPRemediesVO1 = new KPRemediesVO();
                            if (prod.ShowUpayCode)
                            {
                                kPRemediesVO1 = (
                                    from Map in KPBLL.Remedy_List_IA
                                    where (Map.Planet != pryaantar_nak_swami ? false : Map.House == pryaantar_nak_swami_house)
                                    select Map).FirstOrDefault<KPRemediesVO>();
                                if (kPDashafalChainVO1.Isbad)
                                {
                                    if (kPRemediesVO1 != null)
                                    {
                                        kPUpayList = new KPUpayList();
                                        if (this.upay_list.Exists((KPUpayList Map) => Map.Sno == (long)kPRemediesVO1.Sno))
                                        {
                                            fakeCode = (
                                                from Map in this.upay_list
                                                where Map.Sno.ToString() == kPRemediesVO1.Sno.ToString()
                                                select Map).SingleOrDefault<KPUpayList>().FakeCode;
                                            str = fakeCode.ToString();
                                            if (!persKV.ShowRef)
                                            {
                                                str1 = str2;
                                                signi = new string[] { str1, "  <I>", predictionBLL.GetCodeLang("upay", persKV.Language, true, true), "</I> ", str.ToString(), this.Gen_Link((long)kPRemediesVO1.Sno, prod.Gen_Link, Convert.ToInt64(str), false, (long)kPDashafalChainVO1.Sno, "R") };
                                                str2 = string.Concat(signi);
                                            }
                                            else
                                            {
                                                str1 = str2;
                                                signi = new string[] { str1, "  [ A_kp_remedy : ", null, null, null, null, null };
                                                sno = kPRemediesVO1.Sno;
                                                signi[2] = sno.ToString();
                                                signi[3] = " ] ";
                                                signi[4] = predictionBLL.GetCodeLang("upay", persKV.Language, true, true);
                                                signi[5] = " ";
                                                signi[6] = str.ToString();
                                                str2 = string.Concat(signi);
                                            }
                                        }
                                        else
                                        {
                                            num = (long)(this.upay_list.Count<KPUpayList>() + 1);
                                            sno = kPRemediesVO1.Sno;
                                            kPUpayList.Sno = (long)Convert.ToInt16(sno.ToString());
                                            sno = kPRemediesVO1.Sno;
                                            kPUpayList.Code = (long)Convert.ToInt16(sno.ToString());
                                            kPUpayList.FakeCode = num;
                                            if (persKV.Language.ToLower() == "hindi")
                                            {
                                                kPUpayList.Upay = kPRemediesVO1.Pred_Hindi;
                                            }
                                            if (persKV.Language.ToLower() == "english")
                                            {
                                                kPUpayList.Upay = kPRemediesVO1.Pred_English;
                                            }
                                            this.upay_list.Add(kPUpayList);
                                            if (!persKV.ShowRef)
                                            {
                                                str1 = str2;
                                                signi = new string[] { str1, " <I>", predictionBLL.GetCodeLang("upay", persKV.Language, true, true), "</I> ", num.ToString(), this.Gen_Link((long)kPRemediesVO1.Sno, prod.Gen_Link, num, false, (long)kPDashafalChainVO1.Sno, "R"), "\r\n\r\n" };
                                                str2 = string.Concat(signi);
                                            }
                                            else
                                            {
                                                str1 = str2;
                                                signi = new string[] { str1, "  [ A_kp_remedy : ", null, null, null, null, null };
                                                sno = kPRemediesVO1.Sno;
                                                signi[2] = sno.ToString();
                                                signi[3] = " ] ";
                                                signi[4] = predictionBLL.GetCodeLang("upay", persKV.Language, true, true);
                                                signi[5] = " ";
                                                signi[6] = num.ToString();
                                                str2 = string.Concat(signi);
                                            }
                                        }
                                    }
                                }
                            }
                            if ((!kPDashafalChainVO1.Isbad || kPRemediesVO1 == null ? true : !prod.ShowUpayCode))
                            {
                                str2 = string.Concat(str2, "\r\n\r\n");
                            }
                        }
                        nums.Add(kPDashafalChainVO1.Sno);
                    }
                }
            }
            return str2;
        }

        public string Get_Dasha_HTML(List<KPDashaVO> dasha, string lang)
        {
            string str = "";
            str = "[";
            foreach (KPDashaVO kPDashaVO in dasha)
            {
                str = string.Concat(str, "{");
                if (lang == "hindi")
                {
                    str = string.Concat(str, "\"Planet\": \"", KPBLL.planet_list[kPDashaVO.Planet - 1].Hindi, "\",");
                }
                if (lang == "english")
                {
                    str = string.Concat(str, "\"Planet\": \"", KPBLL.planet_list[kPDashaVO.Planet - 1].English, "\",");
                }
                if (lang == "marathi")
                {
                    str = string.Concat(str, "\"Planet\": \"", KPBLL.planet_list[kPDashaVO.Planet - 1].Marathi, "\",");
                }
                string str1 = str;
                string[] strArrays = new string[] { str1, "\"Period\": \"", null, null, null, null };
                DateTime startDate = kPDashaVO.StartDate;
                strArrays[2] = startDate.ToString("dd MMM yyyy");
                strArrays[3] = " - ";
                startDate = kPDashaVO.EndDate;
                strArrays[4] = startDate.ToString("dd MMM yyyy");
                strArrays[5] = "\"";
                str = string.Concat(strArrays);
                str = string.Concat(str, "},");
            }
            str = str.TrimEnd(new char[] { ',' });
            str = string.Concat(str, "]");
            return str;
        }

        public string Get_Dasha_Pred(short planet, string houses, DateTime startdate, DateTime enddate, KundliVO persKV, string ptype, ProductSettingsVO prod, List<KPPlanetMappingVO> kp_chart)
        {
            bool flag;
            short sno;
            string str;
            bool flag1;
            string str1 = "";
            PredictionBLL predictionBLL = new PredictionBLL();
            List<short> nums = new List<short>();
            KPDAO kPDAO = new KPDAO();
            short num = Convert.ToInt16(predictionBLL.CalculateAgeCorrect(persKV.Dob, startdate));
            Convert.ToInt16(predictionBLL.CalculateAgeCorrect(persKV.Dob, enddate));
            if (startdate < persKV.Dob)
            {
                num = 1;
            }
            short num1 = planet;
            short house = (
                from Map in kp_chart
                where Map.Planet == num1
                select Map).SingleOrDefault<KPPlanetMappingVO>().House;
            string[] codeLang = new string[] { startdate.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", startdate.ToString("%M")), persKV.Language, persKV.Paid, true), " ", startdate.ToString("yyyy") };
            string.Concat(codeLang);
            codeLang = new string[] { enddate.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", enddate.ToString("%M")), persKV.Language, persKV.Paid, true), " ", enddate.ToString("yyyy") };
            string.Concat(codeLang);
            houses = houses.Trim();
            char[] chrArray = new char[] { ' ' };
            string[] strArrays = houses.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string str2 = strArrays[i];
                List<KPDashafalVO> kPDashafalVOs = new List<KPDashafalVO>();
                if (prod.Product.ToLower() != "mobile")
                {
                    flag1 = true;
                }
                else
                {
                    flag1 = (prod.Category == "disease" || prod.Category == "married_life" || prod.Category == "married" || prod.Category == "occupation" ? false : !(prod.Category == "education"));
                }
                if (flag1)
                {
                    if ((prod.Category == "all" ? true : prod.Category.Length <= 0))
                    {
                        kPDashafalVOs = (
                            from Map in kPDAO.Get_Dashafal(planet, Convert.ToInt16(str2))
                            where Map.Ptype == ptype
                            orderby Map.Ptype
                            select Map).ToList<KPDashafalVO>();
                    }
                    if ((prod.Category == "married" ? true : prod.Category == "married_life"))
                    {
                        kPDashafalVOs = (
                            from Map in kPDAO.Get_Dashafal(planet, Convert.ToInt16(str2))
                            where (Map.Ptype != ptype ? false : Map.married)
                            orderby Map.Ptype
                            select Map).ToList<KPDashafalVO>();
                    }
                    if (prod.Category == "children")
                    {
                        kPDashafalVOs = (
                            from Map in kPDAO.Get_Dashafal(planet, Convert.ToInt16(str2))
                            where (Map.Ptype != ptype ? false : Map.children)
                            orderby Map.Ptype
                            select Map).ToList<KPDashafalVO>();
                    }
                    if (prod.Category == "occupation")
                    {
                        kPDashafalVOs = (
                            from Map in kPDAO.Get_Dashafal(planet, Convert.ToInt16(str2))
                            where (Map.Ptype != ptype ? false : Map.occupation)
                            orderby Map.Ptype
                            select Map).ToList<KPDashafalVO>();
                    }
                    if (prod.Category == "disease")
                    {
                        kPDashafalVOs = (
                            from Map in kPDAO.Get_Dashafal(planet, Convert.ToInt16(str2))
                            where (Map.Ptype != ptype ? false : Map.disease)
                            orderby Map.Ptype
                            select Map).ToList<KPDashafalVO>();
                    }
                    if (prod.Category == "mother_father")
                    {
                        kPDashafalVOs = (
                            from Map in kPDAO.Get_Dashafal(planet, Convert.ToInt16(str2))
                            where (Map.Ptype != ptype ? false : Map.mother_father)
                            orderby Map.Ptype
                            select Map).ToList<KPDashafalVO>();
                    }
                    if (prod.Category == "general")
                    {
                        kPDashafalVOs = (
                            from Map in kPDAO.Get_Dashafal(planet, Convert.ToInt16(str2))
                            where (Map.Ptype != ptype ? false : Map.general)
                            orderby Map.Ptype
                            select Map).ToList<KPDashafalVO>();
                    }
                }
                else
                {
                    kPDashafalVOs = (
                        from Map in kPDAO.Get_Dashafal(planet, Convert.ToInt16(str2))
                        where Map.Ptype == ptype
                        orderby Map.Ptype
                        select Map).ToList<KPDashafalVO>();
                }
                if ((prod.Category == "all" ? true : prod.Category.Length <= 0))
                {
                    if ((!(ptype != "fulllife") || !(ptype != "oldvfal") || !(ptype != "newvfal") || !(ptype != "oldcfal") || !(ptype != "oldmfal") || !(ptype != "oldcmfal") ? false : ptype != "oldcvfal"))
                    {
                        if ((num < 0 ? false : num <= 12))
                        {
                            kPDashafalVOs = (
                                from Map in kPDashafalVOs
                                where (Map.shishu ? true : Map.bachpan)
                                select Map).ToList<KPDashafalVO>();
                        }
                        if ((num < 13 ? false : num <= 20))
                        {
                            kPDashafalVOs = (
                                from Map in kPDashafalVOs
                                where Map.kishor
                                select Map).ToList<KPDashafalVO>();
                        }
                        if ((num < 21 ? false : num <= 35))
                        {
                            kPDashafalVOs = (
                                from Map in kPDashafalVOs
                                where Map.yuva
                                select Map).ToList<KPDashafalVO>();
                        }
                        if (num >= 36)
                        {
                            kPDashafalVOs = (
                                from Map in kPDashafalVOs
                                where (Map.madhya ? true : Map.budhapa)
                                select Map).ToList<KPDashafalVO>();
                        }
                    }
                }
                List<KPDashafalVO> kPDashafalVOs1 = new List<KPDashafalVO>();
                kPDashafalVOs1 = kPDashafalVOs;
                if (persKV.Male)
                {
                    kPDashafalVOs = (
                        from Map in kPDashafalVOs1
                        where (!Map.common ? false : !Map.female)
                        select Map).ToList<KPDashafalVO>();
                    kPDashafalVOs.AddRange((
                        from Map in kPDashafalVOs1
                        where Map.male
                        select Map).ToList<KPDashafalVO>());
                }
                if (!persKV.Male)
                {
                    kPDashafalVOs = (
                        from Map in kPDashafalVOs1
                        where (!Map.common ? false : !Map.male)
                        select Map).ToList<KPDashafalVO>();
                    kPDashafalVOs.AddRange((
                        from Map in kPDashafalVOs1
                        where Map.female
                        select Map).ToList<KPDashafalVO>());
                }
                if (ptype == "fulllife")
                {
                    List<KPDashafalVO> kPDashafalVOs2 = new List<KPDashafalVO>();
                    bool flag2 = false;
                    flag2 = (
                        from Map in kp_chart
                        where Map.Planet == planet
                        select Map).SingleOrDefault<KPPlanetMappingVO>().isbad;
                    kPDashafalVOs2 = kPDashafalVOs;
                    kPDashafalVOs = (
                        from Map in kPDashafalVOs
                        where Map.Isbad == flag2
                        select Map).ToList<KPDashafalVO>();
                    if (kPDashafalVOs.Count <= 0)
                    {
                        kPDashafalVOs = kPDashafalVOs2;
                    }
                }
                foreach (KPDashafalVO kPDashafalVO in
                    from Map in kPDashafalVOs
                    where Map.Ptype == ptype
                    select Map)
                {
                    flag = ((ptype == "oldmfal" ? false : !(ptype == "oldcmfal")) ? nums.Exists((short Map) => Map == kPDashafalVO.Sno) : this.mvfal_all_fal.Exists((short Map) => Map == kPDashafalVO.Sno));
                    KPRemediesVO kPRemediesVO = new KPRemediesVO();
                    if (!flag)
                    {
                        if (persKV.ShowRef)
                        {
                            object obj = str1;
                            object[] hindi = new object[] { obj, KPBLL.planet_list[kPDashafalVO.Planet - 1].Hindi, " ", kPDashafalVO.House, " [A_mix_dasha : ", kPDashafalVO.LawType, " ", null, null };
                            sno = kPDashafalVO.Sno;
                            hindi[7] = sno.ToString();
                            hindi[8] = "] \r\n\r\n ";
                            str1 = string.Concat(hindi);
                        }
                        str1 = string.Concat(str1, this.Get_KP_Lang(kPDashafalVO.Sno, persKV.Language, true, false, prod.Mini));
                        this.ScoreMM(kPDashafalVO.Isbad, kPDashafalVO.VeryBad, kPDashafalVO.married, kPDashafalVO.occupation, kPDashafalVO.children, kPDashafalVO.disease, persKV.Male, "maha");
                        if ((!kPDashafalVO.Isbad || kPDashafalVO.Pred_Hindi.Trim().Length < 20 ? false : prod.ShowUpayCode))
                        {
                            kPRemediesVO = ((ptype == "vfal" || ptype == "mfal" || ptype == "oldvfal" || ptype == "oldmfal" || ptype == "oldcvfal" ? false : !(ptype == "oldcmfal")) ? (
                                from Map in KPBLL.Remedy_List_General
                                where (long)Map.RuleCode == kPDashafalVO.Upay
                                select Map).FirstOrDefault<KPRemediesVO>() : (
                                from Map in KPBLL.Remedy_List_VFAL
                                where (Map.Planet != kPDashafalVO.Planet ? false : Map.House == kPDashafalVO.House)
                                select Map).FirstOrDefault<KPRemediesVO>());
                            if (kPRemediesVO == null)
                            {
                                kPRemediesVO = (
                                    from Map in KPBLL.Remedy_List_IA
                                    where (Map.Planet != kPDashafalVO.Planet ? false : Map.House == kPDashafalVO.House)
                                    select Map).FirstOrDefault<KPRemediesVO>();
                            }
                            if (kPRemediesVO != null)
                            {
                                KPUpayList kPUpayList = new KPUpayList();
                                if (this.upay_list.Exists((KPUpayList Map) => Map.Sno == (long)kPRemediesVO.Sno))
                                {
                                    long fakeCode = (
                                        from Map in this.upay_list
                                        where Map.Sno.ToString() == kPRemediesVO.Sno.ToString()
                                        select Map).SingleOrDefault<KPUpayList>().FakeCode;
                                    string str3 = fakeCode.ToString();
                                    if (!prod.ShowUpayBelow)
                                    {
                                        if (!prod.FreeUpay)
                                        {
                                            this.upay_list.Add(kPUpayList);
                                            if (!persKV.ShowRef)
                                            {
                                                str = str1;
                                                codeLang = new string[] { str, "  <I>", predictionBLL.GetCodeLang("upay", persKV.Language, true, true), "</I> ", str3.ToString(), "\r\n\r\n" };
                                                str1 = string.Concat(codeLang);
                                            }
                                            else
                                            {
                                                str = str1;
                                                codeLang = new string[] { str, "  [ A_kp_remedy : ", kPRemediesVO.Ptype, "  ", null, null, null, null, null, null };
                                                sno = kPRemediesVO.Sno;
                                                codeLang[4] = sno.ToString();
                                                codeLang[5] = " ] ";
                                                codeLang[6] = predictionBLL.GetCodeLang("upay", persKV.Language, true, true);
                                                codeLang[7] = " ";
                                                codeLang[8] = str3.ToString();
                                                codeLang[9] = "\r\n\r\n";
                                                str1 = string.Concat(codeLang);
                                            }
                                        }
                                        else if ((ptype == "oldvfal" || ptype == "olcvfal" ? true : ptype == "fulllife"))
                                        {
                                            this.upay_list.Add(kPUpayList);
                                            if (!persKV.ShowRef)
                                            {
                                                str = str1;
                                                codeLang = new string[] { str, "  <I>", predictionBLL.GetCodeLang("upay", persKV.Language, true, true), "</I> ", str3.ToString(), "\r\n\r\n" };
                                                str1 = string.Concat(codeLang);
                                            }
                                            else
                                            {
                                                str = str1;
                                                codeLang = new string[] { str, "  [ A_kp_remedy : ", kPRemediesVO.Ptype, "  ", null, null, null, null, null, null };
                                                sno = kPRemediesVO.Sno;
                                                codeLang[4] = sno.ToString();
                                                codeLang[5] = " ] ";
                                                codeLang[6] = predictionBLL.GetCodeLang("upay", persKV.Language, true, true);
                                                codeLang[7] = " ";
                                                codeLang[8] = str3.ToString();
                                                codeLang[9] = "\r\n\r\n";
                                                str1 = string.Concat(codeLang);
                                            }
                                        }
                                    }
                                    if (prod.ShowUpayBelow)
                                    {
                                        str = str1;
                                        codeLang = new string[] { str, "\r\n", predictionBLL.GetCodeLang("upaytext", persKV.Language, true, true), "\r\n", kPUpayList.Upay };
                                        str1 = string.Concat(codeLang);
                                    }
                                }
                                else
                                {
                                    long num2 = (long)(this.upay_list.Count<KPUpayList>() + 1);
                                    sno = kPRemediesVO.Sno;
                                    kPUpayList.Sno = (long)Convert.ToInt16(sno.ToString());
                                    sno = kPRemediesVO.Sno;
                                    kPUpayList.Code = (long)Convert.ToInt16(sno.ToString());
                                    kPUpayList.FakeCode = num2;
                                    kPUpayList.Upay = this.Get_KP_Lang(Convert.ToInt16(kPUpayList.Sno), persKV.Language, false, true, prod.Mini);
                                    if (!prod.ShowUpayBelow)
                                    {
                                        if (!prod.FreeUpay)
                                        {
                                            this.upay_list.Add(kPUpayList);
                                            if (!persKV.ShowRef)
                                            {
                                                str = str1;
                                                codeLang = new string[] { str, "  <I>", predictionBLL.GetCodeLang("upay", persKV.Language, true, true), "</I> ", num2.ToString(), "\r\n\r\n" };
                                                str1 = string.Concat(codeLang);
                                            }
                                            else
                                            {
                                                str = str1;
                                                codeLang = new string[] { str, "  [ A_kp_remedy : ", kPRemediesVO.Ptype, "  ", null, null, null, null, null, null };
                                                sno = kPRemediesVO.Sno;
                                                codeLang[4] = sno.ToString();
                                                codeLang[5] = " ] ";
                                                codeLang[6] = predictionBLL.GetCodeLang("upay", persKV.Language, true, true);
                                                codeLang[7] = " ";
                                                codeLang[8] = num2.ToString();
                                                codeLang[9] = "\r\n\r\n";
                                                str1 = string.Concat(codeLang);
                                            }
                                        }
                                        else if ((ptype == "oldvfal" || ptype == "olcvfal" ? true : ptype == "fulllife"))
                                        {
                                            this.upay_list.Add(kPUpayList);
                                            if (!persKV.ShowRef)
                                            {
                                                str = str1;
                                                codeLang = new string[] { str, "  <I>", predictionBLL.GetCodeLang("upay", persKV.Language, true, true), "</I> ", num2.ToString(), "\r\n\r\n" };
                                                str1 = string.Concat(codeLang);
                                            }
                                            else
                                            {
                                                str = str1;
                                                codeLang = new string[] { str, "  [ A_kp_remedy : ", kPRemediesVO.Ptype, "  ", null, null, null, null, null, null };
                                                sno = kPRemediesVO.Sno;
                                                codeLang[4] = sno.ToString();
                                                codeLang[5] = " ] ";
                                                codeLang[6] = predictionBLL.GetCodeLang("upay", persKV.Language, true, true);
                                                codeLang[7] = " ";
                                                codeLang[8] = num2.ToString();
                                                codeLang[9] = "\r\n\r\n";
                                                str1 = string.Concat(codeLang);
                                            }
                                        }
                                    }
                                    if (prod.ShowUpayBelow)
                                    {
                                        str = str1;
                                        codeLang = new string[] { str, "\r\n", predictionBLL.GetCodeLang("upaytext", persKV.Language, true, true), "\r\n", kPUpayList.Upay };
                                        str1 = string.Concat(codeLang);
                                    }
                                }
                            }
                        }
                        if ((!kPDashafalVO.Isbad || kPRemediesVO == null || !prod.ShowUpayCode ? str1.Length >= 50 : false))
                        {
                            str1 = string.Concat(str1, "\r\n\r\n");
                        }
                    }
                    if ((ptype == "oldmfal" ? false : !(ptype == "oldcmfal")))
                    {
                        nums.Add(kPDashafalVO.Sno);
                    }
                    else
                    {
                        this.mvfal_all_fal.Add(kPDashafalVO.Sno);
                    }
                }
            }
            if (str1.Trim().Length <= 50)
            {
                str1 = "";
            }
            return str1;
        }

        public string Get_Dasha_Pred_Free(KundliVO persKV, List<KPDashaVO> mahadasha, List<KPPlanetMappingVO> kp_chart)
        {
            string str = "";
            PredictionBLL predictionBLL = new PredictionBLL();
            List<long> nums = new List<long>();
            foreach (KPDashaVO kPDashaVO in mahadasha)
            {
                DateTime startDate = kPDashaVO.StartDate;
                DateTime endDate = kPDashaVO.EndDate;
                Convert.ToInt16(predictionBLL.CalculateAgeCorrect(persKV.Dob, startDate));
                Convert.ToInt16(predictionBLL.CalculateAgeCorrect(persKV.Dob, endDate));
                short house = (
                    from Map in kp_chart
                    where Map.Planet == kPDashaVO.Planet
                    select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                string signiString = this.Get_Signi_String(kPDashaVO.Planet, kp_chart, false);
                string[] strArrays = new string[] { startDate.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", startDate.ToString("%M")), persKV.Language, persKV.Paid, true), " ", startDate.ToString("yyyy") };
                string.Concat(strArrays);
                strArrays = new string[] { endDate.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", endDate.ToString("%M")), persKV.Language, persKV.Paid, true), " ", endDate.ToString("yyyy") };
                string.Concat(strArrays);
                KPDAO kPDAO = new KPDAO();
                short num = Convert.ToInt16(predictionBLL.CalculateAgeCorrect(persKV.Dob, startDate));
                Convert.ToInt16(predictionBLL.CalculateAgeCorrect(persKV.Dob, endDate));
                if (startDate < persKV.Dob)
                {
                    num = 1;
                }
                signiString = signiString.Trim();
                char[] chrArray = new char[] { ' ' };
                string[] strArrays1 = signiString.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < (int)strArrays1.Length; i++)
                {
                    string str1 = strArrays1[i];
                    List<KPDashafalVO> list = (
                        from Map in kPDAO.Get_Dashafal(kPDashaVO.Planet, Convert.ToInt16(str1))
                        where Map.Ptype == "fulllife"
                        orderby Map.Ptype
                        select Map).ToList<KPDashafalVO>();
                    List<KPDashafalVO> kPDashafalVOs = new List<KPDashafalVO>();
                    kPDashafalVOs = list;
                    if (persKV.Male)
                    {
                        list = (
                            from Map in kPDashafalVOs
                            where (!Map.common ? false : !Map.female)
                            select Map).ToList<KPDashafalVO>();
                        list.AddRange((
                            from Map in kPDashafalVOs
                            where Map.male
                            select Map).ToList<KPDashafalVO>());
                    }
                    if (!persKV.Male)
                    {
                        list = (
                            from Map in kPDashafalVOs
                            where (!Map.common ? false : !Map.male)
                            select Map).ToList<KPDashafalVO>();
                        list.AddRange((
                            from Map in kPDashafalVOs
                            where Map.female
                            select Map).ToList<KPDashafalVO>());
                    }
                    foreach (KPDashafalVO kPDashafalVO in
                        from Map in list
                        where Map.Ptype == "fulllife"
                        select Map)
                    {
                        if (!nums.Exists((long Map) => Map == (long)kPDashafalVO.Sno))
                        {
                            str = string.Concat(str, kPDashafalVO.Pred_Hindi, "\r\n\r\n");
                        }
                        nums.Add((long)kPDashafalVO.Sno);
                    }
                }
            }
            return str;
        }

        public string Get_Dasha_Pred_Intelli(short planet, string houses, DateTime startdate, DateTime enddate, KundliVO persKV, string ptype, ProductSettingsVO prod, List<KPPlanetMappingVO> kp_chart, short actual_planet, short actual_planet_house, short nak_swami_house)
        {
            bool flag;
            string str = "";
            List<KPDashafalVO> kPDashafalVOs = new List<KPDashafalVO>();
            string str1 = "";
            kPDashafalVOs.AddRange(this.Get_Dasha_Pred_SNO(planet, houses, startdate, enddate, persKV, ptype, prod, kp_chart));
            if (actual_planet_house != nak_swami_house)
            {
                kPDashafalVOs.AddRange(this.Get_Dasha_Pred_SNO(actual_planet, actual_planet_house.ToString(), startdate, enddate, persKV, ptype, prod, kp_chart));
            }
            kPDashafalVOs = (
                from Map in kPDashafalVOs
                orderby Map.Isbad
                select Map).ToList<KPDashafalVO>();
            short num = 0;
            short num1 = 0;
            bool isbad = false;
            string str2 = "";
            short num2 = Convert.ToInt16(kPDashafalVOs.Count<KPDashafalVO>((KPDashafalVO Map) => Map.Isbad));
            short num3 = Convert.ToInt16(kPDashafalVOs.Count<KPDashafalVO>((KPDashafalVO Map) => Map.Isbad));
            if (num3 != 2)
            {
                flag = true;
            }
            else
            {
                flag = (num2 == 1 ? false : num2 != 2);
            }
            if (!flag)
            {
                kPDashafalVOs = (
                    from Map in kPDashafalVOs
                    where Map.Isbad
                    select Map).ToList<KPDashafalVO>();
                str1 = "यह सारे बुरे फल इस समय में घटित होने के बावजूद भी कुदरत कुछ आपकी रक्षा करेगी जिसके कारन बहुत बड़ी खराबियों से कुछ बचाव रहेगा |";
            }
            foreach (KPDashafalVO kPDashafalVO in kPDashafalVOs)
            {
                str2 = "";
                if ((!kPDashafalVO.Isbad || isbad || num != 0 ? false : num3 == 1))
                {
                    str2 = "लेकिन थोड़े समय के लिए ";
                }
                if ((!kPDashafalVO.Isbad || isbad || num != 0 ? false : num3 >= 2))
                {
                    str2 = "लेकिन लम्बे समय के लिए ";
                }
                if ((!kPDashafalVO.Isbad || !isbad || num != 1 ? false : num3 == 1))
                {
                    str2 = "इन सब दुखों के अलावा और भी कष्ट होंगे जैसे ";
                }
                if ((!kPDashafalVO.Isbad || !isbad || num != 1 ? false : num3 >= 2))
                {
                    str2 = "इन सब दुखों के अलावा लम्बे समय के लिए और भी कष्ट होंगे जैसे ";
                }
                if ((!kPDashafalVO.Isbad || !isbad ? false : num > 1))
                {
                    str2 = "और ";
                }
                if ((kPDashafalVO.Isbad || isbad || num1 != 1 ? false : num2 == 1))
                {
                    str2 = "इसके अलावा थोड़े समय  के लिए ";
                }
                if ((kPDashafalVO.Isbad || isbad || num1 != 1 ? false : num2 > 1))
                {
                    str2 = "इसके अलावा लम्बे समय  के लिए ";
                }
                if ((kPDashafalVO.Isbad || isbad ? false : num1 > 1))
                {
                    str2 = "और ";
                }
                if (prod.ShowRef)
                {
                    object obj = str;
                    object[] objArray = new object[] { obj, " ", kPDashafalVO.Planet, ":", kPDashafalVO.House, " - Sno:", kPDashafalVO.Sno };
                    str = string.Concat(objArray);
                }
                str = string.Concat(str, str2, this.Get_KP_Lang(kPDashafalVO.Sno, persKV.Language, true, false, prod.Mini), " ");
                if (kPDashafalVO.Isbad)
                {
                    num = (short)(num + 1);
                }
                if (!kPDashafalVO.Isbad)
                {
                    num1 = (short)(num1 + 1);
                }
                isbad = kPDashafalVO.Isbad;
            }
            str = string.Concat(str, str1);
            return str;
        }

        public List<KPDashafalVO> Get_Dasha_Pred_SNO(short planet, string houses, DateTime startdate, DateTime enddate, KundliVO persKV, string ptype, ProductSettingsVO prod, List<KPPlanetMappingVO> kp_chart)
        {
            bool flag;
            bool flag1;
            List<KPDashafalVO> kPDashafalVOs = new List<KPDashafalVO>();
            PredictionBLL predictionBLL = new PredictionBLL();
            List<short> nums = new List<short>();
            KPDAO kPDAO = new KPDAO();
            short num = Convert.ToInt16(predictionBLL.CalculateAgeCorrect(persKV.Dob, startdate));
            Convert.ToInt16(predictionBLL.CalculateAgeCorrect(persKV.Dob, enddate));
            if (startdate < persKV.Dob)
            {
                num = 1;
            }
            short num1 = planet;
            short house = (
                from Map in kp_chart
                where Map.Planet == num1
                select Map).SingleOrDefault<KPPlanetMappingVO>().House;
            string[] str = new string[] { startdate.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", startdate.ToString("%M")), persKV.Language, persKV.Paid, true), " ", startdate.ToString("yyyy") };
            string.Concat(str);
            str = new string[] { enddate.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", enddate.ToString("%M")), persKV.Language, persKV.Paid, true), " ", enddate.ToString("yyyy") };
            string.Concat(str);
            houses = houses.Trim();
            char[] chrArray = new char[] { ' ' };
            string[] strArrays = houses.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string str1 = strArrays[i];
                List<KPDashafalVO> list = new List<KPDashafalVO>();
                if (prod.Product.ToLower() != "mobile")
                {
                    flag1 = true;
                }
                else
                {
                    flag1 = (prod.Category == "disease" || prod.Category == "married_life" || prod.Category == "married" || prod.Category == "occupation" ? false : !(prod.Category == "education"));
                }
                if (flag1)
                {
                    if ((prod.Category == "all" ? true : prod.Category.Length <= 0))
                    {
                        list = (
                            from Map in kPDAO.Get_Dashafal(planet, Convert.ToInt16(str1))
                            where Map.Ptype == ptype
                            orderby Map.Ptype
                            select Map).ToList<KPDashafalVO>();
                    }
                    if ((prod.Category == "married" ? true : prod.Category == "married_life"))
                    {
                        list = (
                            from Map in kPDAO.Get_Dashafal(planet, Convert.ToInt16(str1))
                            where (Map.Ptype != ptype ? false : Map.married)
                            orderby Map.Ptype
                            select Map).ToList<KPDashafalVO>();
                    }
                    if (prod.Category == "children")
                    {
                        list = (
                            from Map in kPDAO.Get_Dashafal(planet, Convert.ToInt16(str1))
                            where (Map.Ptype != ptype ? false : Map.children)
                            orderby Map.Ptype
                            select Map).ToList<KPDashafalVO>();
                    }
                    if (prod.Category == "occupation")
                    {
                        list = (
                            from Map in kPDAO.Get_Dashafal(planet, Convert.ToInt16(str1))
                            where (Map.Ptype != ptype ? false : Map.occupation)
                            orderby Map.Ptype
                            select Map).ToList<KPDashafalVO>();
                    }
                    if (prod.Category == "disease")
                    {
                        list = (
                            from Map in kPDAO.Get_Dashafal(planet, Convert.ToInt16(str1))
                            where (Map.Ptype != ptype ? false : Map.disease)
                            orderby Map.Ptype
                            select Map).ToList<KPDashafalVO>();
                    }
                    if (prod.Category == "mother_father")
                    {
                        list = (
                            from Map in kPDAO.Get_Dashafal(planet, Convert.ToInt16(str1))
                            where (Map.Ptype != ptype ? false : Map.mother_father)
                            orderby Map.Ptype
                            select Map).ToList<KPDashafalVO>();
                    }
                    if (prod.Category == "general")
                    {
                        list = (
                            from Map in kPDAO.Get_Dashafal(planet, Convert.ToInt16(str1))
                            where (Map.Ptype != ptype ? false : Map.general)
                            orderby Map.Ptype
                            select Map).ToList<KPDashafalVO>();
                    }
                }
                else
                {
                    list = (
                        from Map in kPDAO.Get_Dashafal(planet, Convert.ToInt16(str1))
                        where Map.Ptype == ptype
                        orderby Map.Ptype
                        select Map).ToList<KPDashafalVO>();
                }
                if ((prod.Category == "all" ? true : prod.Category.Length <= 0))
                {
                    if ((!(ptype != "fulllife") || !(ptype != "oldvfal") || !(ptype != "newvfal") || !(ptype != "oldcfal") || !(ptype != "oldmfal") || !(ptype != "oldcmfal") ? false : ptype != "oldcvfal"))
                    {
                        if ((num < 0 ? false : num <= 12))
                        {
                            list = (
                                from Map in list
                                where (Map.shishu ? true : Map.bachpan)
                                select Map).ToList<KPDashafalVO>();
                        }
                        if ((num < 13 ? false : num <= 20))
                        {
                            list = (
                                from Map in list
                                where Map.kishor
                                select Map).ToList<KPDashafalVO>();
                        }
                        if ((num < 21 ? false : num <= 35))
                        {
                            list = (
                                from Map in list
                                where Map.yuva
                                select Map).ToList<KPDashafalVO>();
                        }
                        if (num >= 36)
                        {
                            list = (
                                from Map in list
                                where (Map.madhya ? true : Map.budhapa)
                                select Map).ToList<KPDashafalVO>();
                        }
                    }
                }
                List<KPDashafalVO> kPDashafalVOs1 = new List<KPDashafalVO>();
                kPDashafalVOs1 = list;
                if (persKV.Male)
                {
                    list = (
                        from Map in kPDashafalVOs1
                        where (!Map.common ? false : !Map.female)
                        select Map).ToList<KPDashafalVO>();
                    list.AddRange((
                        from Map in kPDashafalVOs1
                        where Map.male
                        select Map).ToList<KPDashafalVO>());
                }
                if (!persKV.Male)
                {
                    list = (
                        from Map in kPDashafalVOs1
                        where (!Map.common ? false : !Map.male)
                        select Map).ToList<KPDashafalVO>();
                    list.AddRange((
                        from Map in kPDashafalVOs1
                        where Map.female
                        select Map).ToList<KPDashafalVO>());
                }
                if (ptype == "fulllife")
                {
                    List<KPDashafalVO> kPDashafalVOs2 = new List<KPDashafalVO>();
                    bool flag2 = false;
                    flag2 = (
                        from Map in kp_chart
                        where Map.Planet == planet
                        select Map).SingleOrDefault<KPPlanetMappingVO>().isbad;
                    kPDashafalVOs2 = list;
                    list = (
                        from Map in list
                        where Map.Isbad == flag2
                        select Map).ToList<KPDashafalVO>();
                    if (list.Count <= 0)
                    {
                        list = kPDashafalVOs2;
                    }
                }
                foreach (KPDashafalVO kPDashafalVO in
                    from Map in list
                    where Map.Ptype == ptype
                    select Map)
                {
                    flag = ((ptype == "oldmfal" ? false : !(ptype == "oldcmfal")) ? nums.Exists((short Map) => Map == kPDashafalVO.Sno) : this.mvfal_all_fal.Exists((short Map) => Map == kPDashafalVO.Sno));
                    KPRemediesVO kPRemediesVO = new KPRemediesVO();
                    if (!flag)
                    {
                        kPDashafalVOs.Add(kPDashafalVO);
                    }
                    else if ((ptype == "oldcmfal" ? true : ptype == "oldmfal"))
                    {
                    }
                    if ((ptype == "oldmfal" ? false : !(ptype == "oldcmfal")))
                    {
                        nums.Add(kPDashafalVO.Sno);
                    }
                    else
                    {
                        this.mvfal_all_fal.Add(kPDashafalVO.Sno);
                    }
                }
            }
            return kPDashafalVOs;
        }

        public string Get_Dashafal_Age_Wise(List<KPPlanetMappingVO> kp_chart, List<KPHouseMappingVO> cusp_house, KundliVO persKV, bool include, short age, ProductSettingsVO prod, bool first_block_only)
        {
            string str;
            char[] chrArray;
            string str1;
            string str2 = "";
            PredictionBLL predictionBLL = new PredictionBLL();
            List<KPDashaVO> kPDashaVOs = new List<KPDashaVO>();
            List<KPDashaVO> antarDasha = new List<KPDashaVO>();
            List<KPDashaVO> prayatntarDasha = new List<KPDashaVO>();
            string str3 = "";
            string str4 = "";
            str3 = string.Concat("\r\n\r\n<B>", predictionBLL.GetCodeLang("mukhyadashanote", persKV.Language, true, true), "</B>\r\n");
            List<KPDashafalChainVO> kPDashafalChainVOs = new List<KPDashafalChainVO>();
            KPDAO kPDAO = new KPDAO();
            kPDashaVOs = this.Get_Dasha(cusp_house, kp_chart, persKV, include);
            string str5 = "";
            string str6 = "";
            kPDashafalChainVOs = kPDAO.Get_Dashafal_Chain();
            DateTime dob = persKV.Dob;
            DateTime dateTime = dob.AddYears(age);
            KPDashaVO kPDashaVO = new KPDashaVO();
            kPDashaVO = (
                from Map in kPDashaVOs
                where Map.EndDate >= dateTime
                select Map).FirstOrDefault<KPDashaVO>();
            if (age < 100)
            {
                antarDasha = this.Get_Antar_Dasha(kPDashaVO.StartDate, kPDashaVO.EndDate, kPDashaVO.Planet, kp_chart, include);
                antarDasha = (
                    from Map in antarDasha
                    where Map.EndDate >= persKV.Dob
                    select Map).ToList<KPDashaVO>();
                short house = (
                    from Map in kp_chart
                    where Map.Planet == kPDashaVO.Planet
                    select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                this.Get_Signi_String(kPDashaVO.Planet, kp_chart, include);
                if ((
                    from Map in antarDasha
                    where Map.EndDate >= dateTime
                    select Map).FirstOrDefault<KPDashaVO>().EndDate <= DateTime.Now)
                {
                    dob = persKV.Dob;
                    dateTime = dob.AddYears(age);
                }
                if (Convert.ToInt16(predictionBLL.CalculateAgeCorrect(persKV.Dob, this.last_antar_date)) < 100)
                {
                    KPDashaVO kPDashaVO1 = (
                        from Map in antarDasha
                        where Map.EndDate >= dateTime
                        select Map).FirstOrDefault<KPDashaVO>();
                    if (this.last_antar_date.Year > 1500)
                    {
                        kPDashaVO = (
                            from Map in kPDashaVOs
                            where (this.last_antar_date.AddDays(1) < Map.StartDate ? false : this.last_antar_date.AddDays(1) <= Map.EndDate)
                            select Map).FirstOrDefault<KPDashaVO>();
                        antarDasha = this.Get_Antar_Dasha(kPDashaVO.StartDate, kPDashaVO.EndDate, kPDashaVO.Planet, kp_chart, include);
                        antarDasha = (
                            from Map in antarDasha
                            where Map.EndDate >= persKV.Dob
                            select Map).ToList<KPDashaVO>();
                        kPDashaVO1 = (
                            from Map in antarDasha
                            where Map.StartDate >= this.last_antar_date
                            select Map).FirstOrDefault<KPDashaVO>();
                    }
                    else
                    {
                        kPDashaVO = (
                            from Map in kPDashaVOs
                            where Map.EndDate >= dateTime
                            select Map).FirstOrDefault<KPDashaVO>();
                        antarDasha = this.Get_Antar_Dasha(kPDashaVO.StartDate, kPDashaVO.EndDate, kPDashaVO.Planet, kp_chart, include);
                        antarDasha = (
                            from Map in antarDasha
                            where Map.EndDate >= persKV.Dob
                            select Map).ToList<KPDashaVO>();
                        kPDashaVO1 = (
                            from Map in antarDasha
                            where Map.EndDate >= dateTime
                            select Map).FirstOrDefault<KPDashaVO>();
                    }
                    DateTime startDate = kPDashaVO1.StartDate;
                    DateTime endDate = kPDashaVO1.EndDate;
                    this.last_antar_date = kPDashaVO1.EndDate;
                    string[] codeLang = new string[] { startDate.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", startDate.ToString("%M")), persKV.Language, persKV.Paid, true), " ", startDate.ToString("yyyy") };
                    string str7 = string.Concat(codeLang);
                    if (startDate < persKV.Dob)
                    {
                        codeLang = new string[5];
                        dob = persKV.Dob;
                        codeLang[0] = dob.ToString("dd");
                        codeLang[1] = " ";
                        dob = persKV.Dob;
                        codeLang[2] = predictionBLL.GetCodeLang(string.Concat("M", dob.ToString("%M")), persKV.Language, persKV.Paid, true);
                        codeLang[3] = " ";
                        dob = persKV.Dob;
                        codeLang[4] = dob.ToString("yyyy");
                        str7 = string.Concat(codeLang);
                    }
                    codeLang = new string[] { endDate.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", endDate.ToString("%M")), persKV.Language, persKV.Paid, true), " ", endDate.ToString("yyyy") };
                    string str8 = string.Concat(codeLang);
                    string str9 = "\r\n";
                    KPDAO kPDAO1 = new KPDAO();
                    short num = Convert.ToInt16(predictionBLL.CalculateAgeCorrect(persKV.Dob, startDate));
                    Convert.ToInt16(predictionBLL.CalculateAgeCorrect(persKV.Dob, endDate));
                    if (num < 0)
                    {
                        num = 0;
                    }
                    dob = kPDashaVO1.StartDate;
                    str4 = str3.Replace("[#fromdate#]", dob.ToString("dd/MM/yyyy"));
                    dob = kPDashaVO1.EndDate;
                    str4 = str4.Replace("[#todate#]", dob.ToString("dd/MM/yyyy"));
                    codeLang = new string[] { "<B>", predictionBLL.GetCodeLang("mukhya", persKV.Language, persKV.Paid, true), " ", str7, predictionBLL.GetCodeLang("to", persKV.Language, persKV.Paid, true), str8, "</B>  ", str6, "\r\n" };
                    str5 = string.Concat(codeLang);
                    str5 = string.Concat(str5, str4);
                    List<KPRashiVO> kPRashiVOs = new List<KPRashiVO>();
                    List<short> nums = new List<short>();
                    short nakLord = (
                        from Map in kp_chart
                        where Map.Planet == kPDashaVO1.Planet
                        select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
                    kPRashiVOs = (
                        from Map in KPBLL.rashi_list
                        where Map.Swami == kPDashaVO1.Planet
                        select Map).ToList<KPRashiVO>();
                    foreach (KPRashiVO kPRashiVO in kPRashiVOs)
                    {
                        nums.Add((
                            from Map in cusp_house
                            where Map.LaganRashi == kPRashiVO.Rashi
                            select Map).SingleOrDefault<KPHouseMappingVO>().House);
                    }
                    if (first_block_only)
                    {
                        short nakLord1 = (
                            from Map in kp_chart
                            where Map.Planet == kPDashaVO.Planet
                            select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
                        short num1 = (
                            from Map in kp_chart
                            where Map.Planet == kPDashaVO1.Planet
                            select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
                        short house1 = (
                            from Map in kp_chart
                            where Map.Planet == num1
                            select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                        string signiString = this.Get_Signi_String(nakLord1, kp_chart, include);
                        string signiStringWithoutNakRashi = this.Get_Signi_String_Without_NakRashi(num1, kp_chart, include);
                        short house2 = (
                            from Map in kp_chart
                            where Map.Planet == kPDashaVO1.Planet
                            select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                        this.Get_Signi_String(num1, kp_chart, include);
                        chrArray = new char[] { ' ' };
                        signiStringWithoutNakRashi.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                        string.Concat(signiString, " ", signiStringWithoutNakRashi);
                        if (prod.Product == "mobile")
                        {
                            prod.Product = "all";
                            if (prod.Category == "disease")
                            {
                                prod.Product = "disease";
                            }
                            if (prod.Category == "married")
                            {
                                prod.Product = "married_life";
                            }
                            if (prod.Category == "occupation")
                            {
                                prod.Product = "occupation";
                            }
                            if (prod.Category == "education")
                            {
                                prod.Product = "education";
                            }
                            str9 = string.Concat(str9, this.Get_Mix_Fal(kPDashaVO1.Planet, kp_chart, cusp_house, persKV, prod, num, false, false, "dasha", startDate, endDate), "\r\n");
                        }
                        string dashaPred = "";
                        if (num <= 16)
                        {
                            dashaPred = this.Get_Dasha_Pred(num1, signiStringWithoutNakRashi, startDate, endDate, persKV, "oldcvfal", prod, kp_chart);
                            str9 = string.Concat(str9, dashaPred, "\r\n\r\n");
                        }
                        if (num > 16)
                        {
                            dashaPred = this.Get_Dasha_Pred(num1, signiStringWithoutNakRashi, startDate, endDate, persKV, "oldvfal", prod, kp_chart);
                            str9 = string.Concat(str9, dashaPred, "\r\n\r\n");
                            prod.fulltype = 1;
                            prod.fulltype_planet = kPDashaVO1.Planet;
                            if (persKV.ShowRef)
                            {
                                str9 = string.Concat(str9, "Full Triangle ");
                            }
                            str9 = string.Concat(str9, this.Get_Full_Triangle(kp_chart, cusp_house, persKV, prod, age, startDate, endDate));
                            prod.fulltype = 2;
                            prod.fulltype_planet = kPDashaVO1.Planet;
                            if (persKV.ShowRef)
                            {
                                str9 = string.Concat(str9, "Full Yog ");
                            }
                            str9 = string.Concat(str9, this.Get_Full_Yog(kp_chart, cusp_house, persKV, prod, age, startDate, endDate));
                            prod.fulltype = 0;
                            prod.fulltype_planet = 0;
                        }
                        if (!this.date_list.Contains(string.Concat(str7, str8)))
                        {
                            if (str9.Length > 50)
                            {
                                str1 = str2;
                                codeLang = new string[] { str1, "\r\n", str5, "\r\n", str9 };
                                str2 = string.Concat(codeLang);
                            }
                        }
                        this.date_list.Add(string.Concat(str7, str8));
                        str9 = "";
                    }
                    if (!first_block_only)
                    {
                        if (prod.Lang.ToLower() != "hindi")
                        {
                            str2 = "";
                            prayatntarDasha = this.Get_Prayatntar_Dasha(antarDasha, startDate, endDate, kPDashaVO.Planet, kPDashaVO1.Planet, kp_chart, include);
                            prayatntarDasha = (
                                from Map in prayatntarDasha
                                where Map.EndDate >= persKV.Dob
                                select Map).ToList<KPDashaVO>();
                            string str10 = "";
                            string str11 = "";
                            foreach (KPDashaVO kPDashaVO2 in prayatntarDasha)
                            {
                                DateTime startDate1 = kPDashaVO2.StartDate;
                                DateTime endDate1 = kPDashaVO2.EndDate;
                                codeLang = new string[] { startDate1.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", startDate1.ToString("%M")), persKV.Language, persKV.Paid, true), " ", startDate1.ToString("yyyy") };
                                str7 = string.Concat(codeLang);
                                if (startDate1 < persKV.Dob)
                                {
                                    codeLang = new string[5];
                                    dob = persKV.Dob;
                                    codeLang[0] = dob.ToString("dd");
                                    codeLang[1] = " ";
                                    dob = persKV.Dob;
                                    codeLang[2] = predictionBLL.GetCodeLang(string.Concat("M", dob.ToString("%M")), persKV.Language, persKV.Paid, true);
                                    codeLang[3] = " ";
                                    dob = persKV.Dob;
                                    codeLang[4] = dob.ToString("yyyy");
                                    str7 = string.Concat(codeLang);
                                }
                                codeLang = new string[] { endDate1.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", endDate1.ToString("%M")), persKV.Language, persKV.Paid, true), " ", endDate1.ToString("yyyy") };
                                str8 = string.Concat(codeLang);
                                short num2 = Convert.ToInt16(predictionBLL.CalculateAgeCorrect(persKV.Dob, startDate1));
                                Convert.ToInt16(predictionBLL.CalculateAgeCorrect(persKV.Dob, endDate1));
                                if (num2 < 0)
                                {
                                    num2 = 0;
                                }
                                this.last_pryaantar_date = endDate1;
                                codeLang = new string[] { "<B>", predictionBLL.GetCodeLang("updasha", persKV.Language, persKV.Paid, true), "  ", str7, predictionBLL.GetCodeLang("to", persKV.Language, persKV.Paid, true), str8, "</B> ", str6, "\r\n" };
                                str5 = string.Concat(codeLang);
                                short nakLord2 = (
                                    from Map in kp_chart
                                    where Map.Planet == kPDashaVO2.Planet
                                    select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
                                short house3 = (
                                    from Map in kp_chart
                                    where Map.Planet == kPDashaVO2.Planet
                                    select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                                short num3 = (
                                    from Map in kp_chart
                                    where Map.Planet == nakLord2
                                    select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                                string signiString1 = this.Get_Signi_String(nakLord2, kp_chart, include);
                                string signiString2 = this.Get_Signi_String(kPDashaVO2.Planet, kp_chart, include);
                                string signiString3 = this.Get_Signi_String(kPDashaVO1.Planet, kp_chart, include);
                                chrArray = new char[] { ' ' };
                                string[] strArrays = signiString2.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                                chrArray = new char[] { ' ' };
                                string[] strArrays1 = signiString3.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                                if ((int)strArrays.Length >= 2)
                                {
                                    signiString2 = string.Concat(strArrays[0], " ", strArrays[1]);
                                }
                                if ((int)strArrays1.Length >= 2)
                                {
                                    signiString3 = string.Concat(strArrays1[0], " ", strArrays1[1]);
                                }
                                chrArray = new char[] { ' ' };
                                signiString1.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                                chrArray = new char[] { ' ' };
                                signiString1.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                                this.Get_Signi_String_Without_NakRashi(nakLord2, kp_chart, include);
                                string dashaPred1 = "";
                                if (num2 <= 16)
                                {
                                    dashaPred1 = this.Get_Dasha_Pred(nakLord2, signiString2, startDate1, endDate1, persKV, "oldcmfal", prod, kp_chart);
                                    str10 = string.Concat(str10, dashaPred1, "\r\n\r\n");
                                }
                                if (num2 > 16)
                                {
                                    dashaPred1 = this.Get_Dasha_Pred(nakLord2, signiString2, startDate1, endDate1, persKV, "oldmfal", prod, kp_chart);
                                    str10 = string.Concat(str10, dashaPred1, "\r\n\r\n");
                                    prod.fulltype = 1;
                                    prod.fulltype_planet = kPDashaVO2.Planet;
                                    if (persKV.ShowRef)
                                    {
                                        str10 = string.Concat(str10, "Full Triangle ");
                                    }
                                    str10 = string.Concat(str10, this.Get_Full_Triangle(kp_chart, cusp_house, persKV, prod, age, startDate1, endDate1));
                                    prod.fulltype = 2;
                                    prod.fulltype_planet = kPDashaVO2.Planet;
                                    if (persKV.ShowRef)
                                    {
                                        str10 = string.Concat(str10, "Full Yog ");
                                    }
                                    str10 = string.Concat(str10, this.Get_Full_Yog(kp_chart, cusp_house, persKV, prod, age, startDate1, endDate1));
                                    prod.fulltype = 0;
                                    prod.fulltype_planet = 0;
                                }
                                if (!this.date_list.Contains(string.Concat(str7, str8)))
                                {
                                    if (str10.Length > 50)
                                    {
                                        str1 = str2;
                                        codeLang = new string[] { str1, "\r\n", str5, str10, "\r\n" };
                                        str2 = string.Concat(codeLang);
                                    }
                                }
                                this.date_list.Add(string.Concat(str7, str8));
                                str10 = "";
                                str11 = "";
                            }
                        }
                    }
                    str = str2;
                }
                else
                {
                    str = "";
                }
            }
            else
            {
                str = "";
            }
            return str;
        }

        public string Get_Dashafal_Cat_Age_Wise(List<KPPlanetMappingVO> kp_chart, List<KPHouseMappingVO> cusp_house, KundliVO persKV, bool include, short age, ProductSettingsVO prod)
        {
            string str = "";
            PredictionBLL predictionBLL = new PredictionBLL();
            List<KPDashaVO> kPDashaVOs = new List<KPDashaVO>();
            List<KPDashaVO> antarDasha = new List<KPDashaVO>();
            List<KPDashaVO> kPDashaVOs1 = new List<KPDashaVO>();
            List<long> nums = new List<long>();
            string str1 = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            string str6 = "";
            string str7 = "";
            string str8 = "";
            string str9 = "";
            string str10 = "";
            string str11 = "";
            string str12 = "";
            string str13 = "";
            string str14 = "";
            List<KPDashafalChainVO> kPDashafalChainVOs = new List<KPDashafalChainVO>();
            KPDAO kPDAO = new KPDAO();
            kPDashaVOs = this.Get_Dasha(cusp_house, kp_chart, persKV, include);
            string str15 = "";
            string str16 = "";
            kPDashafalChainVOs = kPDAO.Get_Dashafal_Chain();
            DateTime dob = persKV.Dob;
            DateTime dateTime = dob.AddYears(age);
            KPDashaVO kPDashaVO = new KPDashaVO();
            kPDashaVO = (
                from Map in kPDashaVOs
                where Map.EndDate >= dateTime
                select Map).FirstOrDefault<KPDashaVO>();
            antarDasha = this.Get_Antar_Dasha(kPDashaVO.StartDate, kPDashaVO.EndDate, kPDashaVO.Planet, kp_chart, include);
            antarDasha = (
                from Map in antarDasha
                where Map.EndDate >= persKV.Dob
                select Map).ToList<KPDashaVO>();
            short house = (
                from Map in kp_chart
                where Map.Planet == kPDashaVO.Planet
                select Map).SingleOrDefault<KPPlanetMappingVO>().House;
            this.Get_Signi_String(kPDashaVO.Planet, kp_chart, include);
            if ((
                from Map in antarDasha
                where Map.EndDate >= dateTime
                select Map).FirstOrDefault<KPDashaVO>().EndDate <= DateTime.Now)
            {
                age = (short)(age + 1);
                dob = persKV.Dob;
                dateTime = dob.AddYears(age);
            }
            KPDashaVO kPDashaVO1 = (
                from Map in antarDasha
                where Map.EndDate >= dateTime
                select Map).FirstOrDefault<KPDashaVO>();
            kPDashaVO = (
                from Map in kPDashaVOs
                where Map.StartDate >= this.last_antar_date
                select Map).FirstOrDefault<KPDashaVO>();
            antarDasha = this.Get_Antar_Dasha(kPDashaVO.StartDate, kPDashaVO.EndDate, kPDashaVO.Planet, kp_chart, include);
            antarDasha = (
                from Map in antarDasha
                where Map.EndDate >= persKV.Dob
                select Map).ToList<KPDashaVO>();
            kPDashaVO1 = (
                from Map in antarDasha
                where Map.StartDate >= this.last_antar_date
                select Map).FirstOrDefault<KPDashaVO>();
            this.last_antar_date = kPDashaVO1.EndDate;
            DateTime startDate = kPDashaVO1.StartDate;
            DateTime endDate = kPDashaVO1.EndDate;
            string[] codeLang = new string[] { startDate.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", startDate.ToString("%M")), persKV.Language, persKV.Paid, true), " ", startDate.ToString("yyyy") };
            string str17 = string.Concat(codeLang);
            codeLang = new string[] { endDate.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", endDate.ToString("%M")), persKV.Language, persKV.Paid, true), " ", endDate.ToString("yyyy") };
            string str18 = string.Concat(codeLang);
            string str19 = "\r\n";
            KPDAO kPDAO1 = new KPDAO();
            Convert.ToInt16(predictionBLL.CalculateAgeCorrect(persKV.Dob, startDate));
            Convert.ToInt16(predictionBLL.CalculateAgeCorrect(persKV.Dob, endDate));
            codeLang = new string[] { str17, predictionBLL.GetCodeLang("to", persKV.Language, persKV.Paid, true), str18, "  ", str16, "\r\n" };
            str15 = string.Concat(codeLang);
            short nakLord = (
                from Map in kp_chart
                where Map.Planet == kPDashaVO.Planet
                select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
            short num = (
                from Map in kp_chart
                where Map.Planet == kPDashaVO1.Planet
                select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
            string signiString = this.Get_Signi_String(nakLord, kp_chart, include);
            string signiString1 = this.Get_Signi_String(num, kp_chart, include);
            string.Concat(signiString, " ", signiString1);
            List<KPDashafalVO> kPDashafalVOs = new List<KPDashafalVO>();
            string str20 = "";
            kPDashafalVOs = this.Get_Cat_Dasha_Pred(kPDashaVO1.Planet, signiString1.ToString(), startDate, endDate, persKV, "vfal");
            foreach (KPDashafalVO kPDashafalVO in kPDashafalVOs)
            {
                str20 = "";
                if (!nums.Contains((long)kPDashafalVO.Sno))
                {
                    if (persKV.Language.ToLower() == "hindi")
                    {
                        str20 = string.Concat(kPDashafalVO.Pred_Hindi, "\r\n\r\n");
                    }
                    if (persKV.Language.ToLower() == "english")
                    {
                        str20 = string.Concat(kPDashafalVO.Pred_English, "\r\n\r\n");
                    }
                }
                if ((!(kPDashafalVO.Ptype == "general") || str20.Trim().Length <= 0 ? false : !kPDashafalVO.Isbad))
                {
                    str1 = string.Concat(str1, str20);
                }
                if ((!(kPDashafalVO.Ptype == "nature") || str20.Trim().Length <= 0 ? false : !kPDashafalVO.Isbad))
                {
                    str2 = string.Concat(str2, str20);
                }
                if ((!(kPDashafalVO.Ptype == "education") || str20.Trim().Length <= 0 ? false : !kPDashafalVO.Isbad))
                {
                    str3 = string.Concat(str3, str20);
                }
                if ((!(kPDashafalVO.Ptype == "occupation") || str20.Trim().Length <= 0 ? false : !kPDashafalVO.Isbad))
                {
                    str4 = string.Concat(str4, str20);
                }
                if ((!(kPDashafalVO.Ptype == "marriage") || str20.Trim().Length <= 0 ? false : !kPDashafalVO.Isbad))
                {
                    str5 = string.Concat(str5, str20);
                }
                if ((!(kPDashafalVO.Ptype == "health") || str20.Trim().Length <= 0 ? false : !kPDashafalVO.Isbad))
                {
                    str6 = string.Concat(str6, str20);
                }
                if ((!(kPDashafalVO.Ptype == "children") || str20.Trim().Length <= 0 ? false : !kPDashafalVO.Isbad))
                {
                    str7 = string.Concat(str7, str20);
                }
                if ((!(kPDashafalVO.Ptype == "general") || str20.Trim().Length <= 0 ? false : kPDashafalVO.Isbad))
                {
                    str8 = string.Concat(str8, str20);
                }
                if ((!(kPDashafalVO.Ptype == "nature") || str20.Trim().Length <= 0 ? false : kPDashafalVO.Isbad))
                {
                    str9 = string.Concat(str9, str20);
                }
                if ((!(kPDashafalVO.Ptype == "education") || str20.Trim().Length <= 0 ? false : kPDashafalVO.Isbad))
                {
                    str10 = string.Concat(str10, str20);
                }
                if ((!(kPDashafalVO.Ptype == "occupation") || str20.Trim().Length <= 0 ? false : kPDashafalVO.Isbad))
                {
                    str11 = string.Concat(str11, str20);
                }
                if ((!(kPDashafalVO.Ptype == "marriage") || str20.Trim().Length <= 0 ? false : kPDashafalVO.Isbad))
                {
                    str12 = string.Concat(str12, str20);
                }
                if ((!(kPDashafalVO.Ptype == "health") || str20.Trim().Length <= 0 ? false : kPDashafalVO.Isbad))
                {
                    str13 = string.Concat(str13, str20);
                }
                if ((!(kPDashafalVO.Ptype == "children") || str20.Trim().Length <= 0 ? false : kPDashafalVO.Isbad))
                {
                    str14 = string.Concat(str14, str20);
                }
                nums.Add((long)kPDashafalVO.Sno);
            }
            if ((str1.Trim().Length > 0 ? true : str8.Trim().Length > 0))
            {
                str19 = string.Concat(str19, predictionBLL.GetCodeLang("kpgeneral", persKV.Language, true, true), "\r\n\r\n");
                if (str1.Trim().Length > 0)
                {
                    str19 = string.Concat(str19, predictionBLL.GetCodeLang("kpgeneralgood", persKV.Language, true, true), "\r\n");
                    str19 = string.Concat(str19, str1);
                }
                if (str8.Trim().Length > 0)
                {
                    str19 = string.Concat(str19, predictionBLL.GetCodeLang("kpgeneralbad", persKV.Language, true, true), "\r\n");
                    str19 = string.Concat(str19, str8);
                }
            }
            if ((str2.Trim().Length > 0 ? true : str9.Trim().Length > 0))
            {
                str19 = string.Concat(str19, predictionBLL.GetCodeLang("kpnature", persKV.Language, true, true), "\r\n\r\n");
                if (str2.Trim().Length > 0)
                {
                    str19 = string.Concat(str19, predictionBLL.GetCodeLang("kpnaturegood", persKV.Language, true, true), "\r\n");
                    str19 = string.Concat(str19, str2);
                }
                if (str9.Trim().Length > 0)
                {
                    str19 = string.Concat(str19, predictionBLL.GetCodeLang("kpnaturebad", persKV.Language, true, true), "\r\n");
                    str19 = string.Concat(str19, str9);
                }
            }
            if ((str3.Trim().Length > 0 ? true : str10.Trim().Length > 0))
            {
                str19 = string.Concat(str19, predictionBLL.GetCodeLang("kpeducation", persKV.Language, true, true), "\r\n\r\n");
                if (str3.Trim().Length > 0)
                {
                    str19 = string.Concat(str19, predictionBLL.GetCodeLang("kpeducationgood", persKV.Language, true, true), "\r\n");
                    str19 = string.Concat(str19, str3);
                }
                if (str10.Trim().Length > 0)
                {
                    str19 = string.Concat(str19, predictionBLL.GetCodeLang("kpeducationbad", persKV.Language, true, true), "\r\n");
                    str19 = string.Concat(str19, str10);
                }
            }
            if ((str4.Trim().Length > 0 ? true : str11.Trim().Length > 0))
            {
                str19 = string.Concat(str19, predictionBLL.GetCodeLang("kpoccupation", persKV.Language, true, true), "\r\n\r\n");
                if (str4.Trim().Length > 0)
                {
                    str19 = string.Concat(str19, predictionBLL.GetCodeLang("kpoccupationgood", persKV.Language, true, true), "\r\n");
                    str19 = string.Concat(str19, str4);
                }
                if (str11.Trim().Length > 0)
                {
                    str19 = string.Concat(str19, predictionBLL.GetCodeLang("kpoccupationbad", persKV.Language, true, true), "\r\n");
                    str19 = string.Concat(str19, str11);
                }
            }
            if ((str5.Trim().Length > 0 ? true : str12.Trim().Length > 0))
            {
                str19 = string.Concat(str19, predictionBLL.GetCodeLang("kpmarriage", persKV.Language, true, true), "\r\n\r\n");
                if (str5.Trim().Length > 0)
                {
                    str19 = string.Concat(str19, predictionBLL.GetCodeLang("kpmarriagegood", persKV.Language, true, true), "\r\n");
                    str19 = string.Concat(str19, str5);
                }
                if (str12.Trim().Length > 0)
                {
                    str19 = string.Concat(str19, predictionBLL.GetCodeLang("kpmarriagebad", persKV.Language, true, true), "\r\n");
                    str19 = string.Concat(str19, str12);
                }
            }
            if ((str6.Trim().Length > 0 ? true : str13.Trim().Length > 0))
            {
                str19 = string.Concat(str19, predictionBLL.GetCodeLang("kphealth", persKV.Language, true, true), "\r\n\r\n");
                if (str6.Trim().Length > 0)
                {
                    str19 = string.Concat(str19, predictionBLL.GetCodeLang("kphealthgood", persKV.Language, true, true), "\r\n");
                    str19 = string.Concat(str19, str6);
                }
                if (str13.Trim().Length > 0)
                {
                    str19 = string.Concat(str19, predictionBLL.GetCodeLang("kphealthbad", persKV.Language, true, true), "\r\n");
                    str19 = string.Concat(str19, str13);
                }
            }
            if ((str7.Trim().Length > 0 ? true : str14.Trim().Length > 0))
            {
                str19 = string.Concat(str19, predictionBLL.GetCodeLang("kpchildren", persKV.Language, true, true), "\r\n\r\n");
                if (str7.Trim().Length > 0)
                {
                    str19 = string.Concat(str19, predictionBLL.GetCodeLang("kpchildrengood", persKV.Language, true, true), "\r\n");
                    str19 = string.Concat(str19, str7);
                }
                if (str14.Trim().Length > 0)
                {
                    str19 = string.Concat(str19, predictionBLL.GetCodeLang("kpchildrenbad", persKV.Language, true, true), "\r\n");
                    str19 = string.Concat(str19, str14);
                }
            }
            if (str19.Length > 50)
            {
                str = string.Concat(str, str15, str19);
            }
            str19 = "";
            return str;
        }

        public string Get_Dates_Chain(List<KPPlanetMappingVO> kp_chart, List<KPHouseMappingVO> cusp_house, KundliVO persKV, string chain, ProductSettingsVO prod, bool nakswami, bool both, bool include, short fromyear, short toyear, bool fullmatch, short dasha_type)
        {
            string[] strArrays;
            DateTime startDate;
            string[] signiString;
            string[] strArrays1;
            int num;
            string str;
            bool flag;
            string str1 = "";
            bool flag1 = false;
            bool flag2 = false;
            List<KPDashaVO> kPDashaVOs = new List<KPDashaVO>();
            List<KPDashaVO> antarDasha = new List<KPDashaVO>();
            List<KPDashaVO> prayatntarDasha = new List<KPDashaVO>();
            List<KPDashaVO> kPDashaVOs1 = new List<KPDashaVO>();
            string str2 = chain.Trim();
            char[] chrArray = new char[] { '@' };
            chain = str2.TrimStart(chrArray);
            chrArray = new char[] { ',' };
            string[] strArrays2 = chain.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
            kPDashaVOs = this.Get_Dasha(cusp_house, kp_chart, persKV, include);
            DateTime dateTime = persKV.Dob.AddYears(fromyear);
            DateTime dateTime1 = persKV.Dob.AddYears(toyear);
            foreach (KPDashaVO kPDashaVO in kPDashaVOs)
            {
                antarDasha = this.Get_Antar_Dasha(kPDashaVO.StartDate, kPDashaVO.EndDate, kPDashaVO.Planet, kp_chart, include);
                if (dasha_type == 2)
                {
                    kPDashaVO.Signi_String = kPDashaVO.Signi_String;
                    kPDashaVO.Nak_Signi_String = kPDashaVO.Nak_Signi_String;
                    if ((kPDashaVO.StartDate < dateTime ? false : kPDashaVO.StartDate <= dateTime1))
                    {
                        kPDashaVOs1.Add(kPDashaVO);
                    }
                }
                foreach (KPDashaVO kPDashaVO1 in antarDasha)
                {
                    prayatntarDasha = this.Get_Prayatntar_Dasha(antarDasha, kPDashaVO1.StartDate, kPDashaVO1.EndDate, kPDashaVO.Planet, kPDashaVO1.Planet, kp_chart, include);
                    if (dasha_type == 2)
                    {
                        kPDashaVO1.Signi_String = string.Concat(kPDashaVO.Signi_String, " ", kPDashaVO1.Signi_String);
                        kPDashaVO1.Nak_Signi_String = string.Concat(kPDashaVO.Nak_Signi_String, " ", kPDashaVO1.Nak_Signi_String);
                        if ((kPDashaVO1.StartDate < dateTime ? false : kPDashaVO1.StartDate <= dateTime1))
                        {
                            kPDashaVOs1.Add(kPDashaVO1);
                        }
                    }
                    foreach (KPDashaVO kPDashaVO2 in prayatntarDasha)
                    {
                        if (dasha_type == 3)
                        {
                            signiString = new string[] { kPDashaVO.Signi_String, " ", kPDashaVO1.Signi_String, " ", kPDashaVO2.Signi_String };
                            kPDashaVO2.Signi_String = string.Concat(signiString);
                            signiString = new string[] { kPDashaVO.Nak_Signi_String, " ", kPDashaVO1.Nak_Signi_String, " ", kPDashaVO2.Nak_Signi_String };
                            kPDashaVO2.Nak_Signi_String = string.Concat(signiString);
                            if ((kPDashaVO2.StartDate < dateTime ? false : kPDashaVO2.StartDate <= dateTime1))
                            {
                                kPDashaVOs1.Add(kPDashaVO2);
                            }
                        }
                    }
                }
            }
            foreach (KPDashaVO kPDashaVO3 in kPDashaVOs1)
            {
                string nakSigniString = "";
                string nakSigniString1 = "";
                if (!both)
                {
                    if (!nakswami)
                    {
                        nakSigniString = kPDashaVO3.Signi_String;
                    }
                    if (nakswami)
                    {
                        nakSigniString = kPDashaVO3.Nak_Signi_String;
                    }
                    chrArray = new char[] { ' ' };
                    strArrays = nakSigniString.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                    if (!fullmatch)
                    {
                        flag1 = true;
                        strArrays1 = strArrays2;
                        num = 0;
                        while (num < (int)strArrays1.Length)
                        {
                            if (!strArrays.Contains<string>(strArrays1[num].Trim()))
                            {
                                num++;
                            }
                            else
                            {
                                flag1 = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        flag1 = false;
                        strArrays1 = strArrays2;
                        num = 0;
                        while (num < (int)strArrays1.Length)
                        {
                            if (strArrays.Contains<string>(strArrays1[num].Trim()))
                            {
                                num++;
                            }
                            else
                            {
                                flag1 = true;
                                break;
                            }
                        }
                    }
                    if ((flag1 ? false : fullmatch))
                    {
                        if (!nakswami)
                        {
                            str = str1;
                            signiString = new string[] { str, null, null, null, null, null, null };
                            startDate = kPDashaVO3.StartDate;
                            signiString[1] = startDate.ToString("dd MMM yyyy");
                            signiString[2] = " - ";
                            startDate = kPDashaVO3.EndDate;
                            signiString[3] = startDate.ToString("dd MMM yyyy");
                            signiString[4] = " [";
                            signiString[5] = kPDashaVO3.Signi_String;
                            signiString[6] = "] \r\n\r\n";
                            str1 = string.Concat(signiString);
                        }
                        else
                        {
                            str = str1;
                            signiString = new string[] { str, null, null, null, null, null, null };
                            startDate = kPDashaVO3.StartDate;
                            signiString[1] = startDate.ToString("dd MMM yyyy");
                            signiString[2] = " - ";
                            startDate = kPDashaVO3.EndDate;
                            signiString[3] = startDate.ToString("dd MMM yyyy");
                            signiString[4] = " [";
                            signiString[5] = kPDashaVO3.Nak_Signi_String;
                            signiString[6] = "] \r\n\r\n";
                            str1 = string.Concat(signiString);
                        }
                    }
                    if ((fullmatch ? false : !flag1))
                    {
                        if (!nakswami)
                        {
                            str = str1;
                            signiString = new string[] { str, null, null, null, null, null, null };
                            startDate = kPDashaVO3.StartDate;
                            signiString[1] = startDate.ToString("dd MMM yyyy");
                            signiString[2] = " - ";
                            startDate = kPDashaVO3.EndDate;
                            signiString[3] = startDate.ToString("dd MMM yyyy");
                            signiString[4] = " [";
                            signiString[5] = kPDashaVO3.Signi_String;
                            signiString[6] = "] \r\n\r\n";
                            str1 = string.Concat(signiString);
                        }
                        else
                        {
                            str = str1;
                            signiString = new string[] { str, null, null, null, null, null, null };
                            startDate = kPDashaVO3.StartDate;
                            signiString[1] = startDate.ToString("dd MMM yyyy");
                            signiString[2] = " - ";
                            startDate = kPDashaVO3.EndDate;
                            signiString[3] = startDate.ToString("dd MMM yyyy");
                            signiString[4] = " [";
                            signiString[5] = kPDashaVO3.Nak_Signi_String;
                            signiString[6] = "] \r\n\r\n";
                            str1 = string.Concat(signiString);
                        }
                    }
                }
                if (both)
                {
                    nakSigniString = kPDashaVO3.Signi_String;
                    nakSigniString1 = kPDashaVO3.Nak_Signi_String;
                    chrArray = new char[] { ' ' };
                    strArrays = nakSigniString.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                    chrArray = new char[] { ' ' };
                    string[] strArrays3 = nakSigniString1.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                    if (!fullmatch)
                    {
                        flag1 = true;
                        flag2 = true;
                        strArrays1 = strArrays2;
                        num = 0;
                        while (num < (int)strArrays1.Length)
                        {
                            if (!strArrays.Contains<string>(strArrays1[num].Trim()))
                            {
                                num++;
                            }
                            else
                            {
                                flag1 = false;
                                break;
                            }
                        }
                        strArrays1 = strArrays2;
                        num = 0;
                        while (num < (int)strArrays1.Length)
                        {
                            if (!strArrays3.Contains<string>(strArrays1[num].Trim()))
                            {
                                num++;
                            }
                            else
                            {
                                flag2 = false;
                                break;
                            }
                        }
                    }
                    else
                    {
                        flag1 = false;
                        flag2 = false;
                        strArrays1 = strArrays2;
                        num = 0;
                        while (num < (int)strArrays1.Length)
                        {
                            if (strArrays.Contains<string>(strArrays1[num].Trim()))
                            {
                                num++;
                            }
                            else
                            {
                                flag1 = true;
                                break;
                            }
                        }
                        strArrays1 = strArrays2;
                        num = 0;
                        while (num < (int)strArrays1.Length)
                        {
                            if (strArrays3.Contains<string>(strArrays1[num].Trim()))
                            {
                                num++;
                            }
                            else
                            {
                                flag2 = true;
                                break;
                            }
                        }
                    }
                    if ((flag1 || flag2 ? false : fullmatch))
                    {
                        str = str1;
                        signiString = new string[] { str, null, null, null, null, null, null, null, null };
                        startDate = kPDashaVO3.StartDate;
                        signiString[1] = startDate.ToString("dd MMM yyyy");
                        signiString[2] = " - ";
                        startDate = kPDashaVO3.EndDate;
                        signiString[3] = startDate.ToString("dd MMM yyyy");
                        signiString[4] = " [";
                        signiString[5] = kPDashaVO3.Signi_String;
                        signiString[6] = " / ";
                        signiString[7] = kPDashaVO3.Nak_Signi_String;
                        signiString[8] = "] \r\n\r\n";
                        str1 = string.Concat(signiString);
                    }
                    if (fullmatch)
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = (!flag1 ? false : flag2);
                    }
                    if (!flag)
                    {
                        str = str1;
                        signiString = new string[] { str, null, null, null, null, null, null, null, null };
                        startDate = kPDashaVO3.StartDate;
                        signiString[1] = startDate.ToString("dd MMM yyyy");
                        signiString[2] = " - ";
                        startDate = kPDashaVO3.EndDate;
                        signiString[3] = startDate.ToString("dd MMM yyyy");
                        signiString[4] = " [";
                        signiString[5] = kPDashaVO3.Signi_String;
                        signiString[6] = " / ";
                        signiString[7] = kPDashaVO3.Nak_Signi_String;
                        signiString[8] = "] \r\n\r\n";
                        str1 = string.Concat(signiString);
                    }
                }
            }
            return str1;
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

        public string Get_Fal_Double_Mahadasha(short planet_no, KundliVO persKV, string Online_Result, ProductSettingsVO tmpprod)
        {
            string str = "";
            List<KPDashaVO> kPDashaVOs = new List<KPDashaVO>();
            List<KPPlanetMappingVO> kPPlanetMappingVOs = new List<KPPlanetMappingVO>();
            List<KPHouseMappingVO> kPHouseMappingVOs = new List<KPHouseMappingVO>();
            this.Process_Planet_Lagan(Online_Result, ref kPPlanetMappingVOs, ref kPHouseMappingVOs, persKV.Rotate, true);
            kPPlanetMappingVOs = this.Process_KPChart_GoodBad(kPPlanetMappingVOs, persKV, tmpprod);
            kPDashaVOs = this.Get_Dasha(kPHouseMappingVOs, kPPlanetMappingVOs, persKV, false);
            PredictionBLL predictionBLL = new PredictionBLL();
            DateTime startDate = (
                from Map in kPDashaVOs
                where Map.Planet == planet_no
                select Map).SingleOrDefault<KPDashaVO>().StartDate;
            DateTime endDate = (
                from Map in kPDashaVOs
                where Map.Planet == planet_no
                select Map).SingleOrDefault<KPDashaVO>().EndDate;
            short num = Convert.ToInt16(predictionBLL.CalculateAgeCorrect(persKV.Dob, startDate));
            short bhavChalitHouse = 0;
            string signiString = "";
            string signiString1 = "";
            bhavChalitHouse = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == planet_no
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            signiString = (
                from Map in kPDashaVOs
                where Map.Planet == planet_no
                select Map).SingleOrDefault<KPDashaVO>().Signi_String;
            short nakLord = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == planet_no
                select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
            signiString1 = (
                from Map in kPDashaVOs
                where Map.Planet == nakLord
                select Map).SingleOrDefault<KPDashaVO>().Signi_String;
            short bhavChalitHouse1 = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == nakLord
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            short num1 = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == planet_no
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            if (persKV.Paid)
            {
                string mixFal = "";
                mixFal = this.Get_Mix_Fal(planet_no, kPPlanetMappingVOs, kPHouseMappingVOs, persKV, tmpprod, Convert.ToInt16(persKV.Current_Age), false, true, "khabar", startDate, endDate);
                if (mixFal.Length > 30)
                {
                    mixFal = string.Concat(predictionBLL.GetCodeLang("Precautions", persKV.Language, true, true), "\r\n\r\n", mixFal);
                    str = string.Concat(str, mixFal);
                }
            }
            tmpprod.fulltype = 1;
            tmpprod.fulltype_planet = planet_no;
            if (persKV.ShowRef)
            {
                str = string.Concat(str, "Full Triangle ");
            }
            str = string.Concat(str, this.Get_Full_Triangle(kPPlanetMappingVOs, kPHouseMappingVOs, persKV, tmpprod, num, startDate, endDate), "\r\n");
            tmpprod.fulltype = 2;
            tmpprod.fulltype_planet = planet_no;
            if (persKV.ShowRef)
            {
                str = string.Concat(str, "Full Yog ");
            }
            str = string.Concat(str, "\r\n");
            str = string.Concat(str, this.Get_Full_Yog(kPPlanetMappingVOs, kPHouseMappingVOs, persKV, tmpprod, num, startDate, endDate), "\r\n");
            tmpprod.fulltype = 0;
            tmpprod.fulltype_planet = 0;
            str = string.Concat(str, this.Get_Planet_Chain_Pred(signiString, startDate, endDate, persKV, "multi", planet_no, tmpprod, num));
            str = string.Concat(str, this.Get_Dasha_Pred(planet_no, bhavChalitHouse.ToString(), startDate, endDate, persKV, "fulllife", tmpprod, kPPlanetMappingVOs), "\r\n\r\n");
            List<short> nums = new List<short>();
            if (bhavChalitHouse1 != bhavChalitHouse)
            {
                str = string.Concat(str, "\r\n", this.Get_Dasha_Pred(planet_no, bhavChalitHouse1.ToString(), startDate, endDate, persKV, "fulllife", tmpprod, kPPlanetMappingVOs), "\r\n\r\n");
            }
            if ((num1 == bhavChalitHouse ? false : num1 != bhavChalitHouse1))
            {
                str = string.Concat(str, "\r\n", this.Get_Dasha_Pred(planet_no, num1.ToString(), startDate, endDate, persKV, "fulllife", tmpprod, kPPlanetMappingVOs), "\r\n\r\n");
            }
            nums.Add(nakLord);
            nums.Add(bhavChalitHouse1);
            nums.Add(bhavChalitHouse);
            nums.Add(num1);
            string signiStringOnlyRashi = this.Get_Signi_String_Only_Rashi(planet_no, kPPlanetMappingVOs, false);
            char[] chrArray = new char[] { ' ' };
            string[] strArrays = signiStringOnlyRashi.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
            if (strArrays.Count<string>() == 1)
            {
                if (!nums.Contains(Convert.ToInt16(strArrays[0])))
                {
                    str = string.Concat(str, "\r\n", this.Get_Dasha_Pred(planet_no, strArrays[0].ToString(), startDate, endDate, persKV, "fulllife", tmpprod, kPPlanetMappingVOs), "\r\n\r\n");
                }
                nums.Add(Convert.ToInt16(strArrays[0]));
            }
            if (strArrays.Count<string>() == 2)
            {
                if (!nums.Contains(Convert.ToInt16(strArrays[0])))
                {
                    str = string.Concat(str, "\r\n", this.Get_Dasha_Pred(planet_no, strArrays[0].ToString(), startDate, endDate, persKV, "fulllife", tmpprod, kPPlanetMappingVOs), "\r\n\r\n");
                }
                if (!nums.Contains(Convert.ToInt16(strArrays[1])))
                {
                    str = string.Concat(str, "\r\n", this.Get_Dasha_Pred(planet_no, strArrays[1].ToString(), startDate, endDate, persKV, "fulllife", tmpprod, kPPlanetMappingVOs), "\r\n\r\n");
                }
                nums.Add(Convert.ToInt16(strArrays[0]));
                nums.Add(Convert.ToInt16(strArrays[1]));
            }
            return str;
        }

        public string Get_Fal_Mahadasha(short planet_no, KundliVO persKV, string Online_Result, ProductSettingsVO tmpprod)
        {
            string str = "";
            List<KPDashaVO> kPDashaVOs = new List<KPDashaVO>();
            List<KPPlanetMappingVO> kPPlanetMappingVOs = new List<KPPlanetMappingVO>();
            List<KPHouseMappingVO> kPHouseMappingVOs = new List<KPHouseMappingVO>();
            this.Process_Planet_Lagan(Online_Result, ref kPPlanetMappingVOs, ref kPHouseMappingVOs, persKV.Rotate, true);
            kPPlanetMappingVOs = this.Process_KPChart_GoodBad(kPPlanetMappingVOs, persKV, tmpprod);
            kPDashaVOs = this.Get_Dasha(kPHouseMappingVOs, kPPlanetMappingVOs, persKV, false);
            PredictionBLL predictionBLL = new PredictionBLL();
            DateTime startDate = (
                from Map in kPDashaVOs
                where Map.Planet == planet_no
                select Map).SingleOrDefault<KPDashaVO>().StartDate;
            DateTime endDate = (
                from Map in kPDashaVOs
                where Map.Planet == planet_no
                select Map).SingleOrDefault<KPDashaVO>().EndDate;
            short num = Convert.ToInt16(predictionBLL.CalculateAgeCorrect(persKV.Dob, startDate));
            short bhavChalitHouse = 0;
            string signiString = "";
            string signiString1 = "";
            bhavChalitHouse = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == planet_no
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            signiString = (
                from Map in kPDashaVOs
                where Map.Planet == planet_no
                select Map).SingleOrDefault<KPDashaVO>().Signi_String;
            short nakLord = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == planet_no
                select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
            signiString1 = (
                from Map in kPDashaVOs
                where Map.Planet == nakLord
                select Map).SingleOrDefault<KPDashaVO>().Signi_String;
            short bhavChalitHouse1 = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == nakLord
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            short num1 = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == planet_no
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            if (persKV.Paid)
            {
                string mixFal = "";
                mixFal = this.Get_Mix_Fal(planet_no, kPPlanetMappingVOs, kPHouseMappingVOs, persKV, tmpprod, Convert.ToInt16(persKV.Current_Age), false, true, "khabar", startDate, endDate);
                if (mixFal.Length > 30)
                {
                    mixFal = string.Concat(predictionBLL.GetCodeLang("Precautions", persKV.Language, true, true), "\r\n\r\n", mixFal);
                    str = string.Concat(str, mixFal);
                }
            }
            tmpprod.fulltype = 1;
            tmpprod.fulltype_planet = planet_no;
            if (persKV.ShowRef)
            {
                str = string.Concat(str, "Full Triangle ");
            }
            str = string.Concat(str, this.Get_Full_Triangle(kPPlanetMappingVOs, kPHouseMappingVOs, persKV, tmpprod, num, startDate, endDate), "\r\n");
            tmpprod.fulltype = 2;
            tmpprod.fulltype_planet = planet_no;
            if (persKV.ShowRef)
            {
                str = string.Concat(str, "Full Yog ");
            }
            str = string.Concat(str, "\r\n");
            str = string.Concat(str, this.Get_Full_Yog(kPPlanetMappingVOs, kPHouseMappingVOs, persKV, tmpprod, num, startDate, endDate), "\r\n");
            tmpprod.fulltype = 0;
            tmpprod.fulltype_planet = 0;
            return str;
        }

        public string Get_Fortuna(List<KPPlanetMappingVO> kp_chart, List<KPHouseMappingVO> cusp_house)
        {
            double num;
            KundliBLL kundliBLL = new KundliBLL();
            double degreeHouseDecimal = (
                from Map in cusp_house
                where Map.House == 1
                select Map).SingleOrDefault<KPHouseMappingVO>().DegreeHouse_Decimal + (double)(((
                from Map in cusp_house
                where Map.House == 1
                select Map).SingleOrDefault<KPHouseMappingVO>().Rashi - 1) * 30);
            double degreePlanetDecimal = (
                from Map in kp_chart
                where Map.Planet == 2
                select Map).SingleOrDefault<KPPlanetMappingVO>().DegreePlanet_Decimal + (double)(((
                from Map in kp_chart
                where Map.Planet == 2
                select Map).SingleOrDefault<KPPlanetMappingVO>().Rashi - 1) * 30);
            double degreePlanetDecimal1 = (
                from Map in kp_chart
                where Map.Planet == 1
                select Map).SingleOrDefault<KPPlanetMappingVO>().DegreePlanet_Decimal + (double)(((
                from Map in kp_chart
                where Map.Planet == 1
                select Map).SingleOrDefault<KPPlanetMappingVO>().Rashi - 1) * 30);
            double num1 = degreeHouseDecimal + degreePlanetDecimal;
            num = (num1 >= degreePlanetDecimal1 ? num1 - degreePlanetDecimal1 : num1 + 360 - degreePlanetDecimal1);
            if (num > 360)
            {
                num -= 360;
            }
            return kundliBLL.DecimalToDMS(num);
        }

        public string Get_Full_Triangle(List<KPPlanetMappingVO> kp_chart, List<KPHouseMappingVO> cusp_house, KundliVO persKV, ProductSettingsVO prod, short age, DateTime StartDate, DateTime EndDate)
        {
            string str = "";
            PredictionBLL predictionBLL = new PredictionBLL();
            string str1 = string.Concat(predictionBLL.GetCodeLang("getfulltri", persKV.Language, true, true), "\r\n\r\n");
            this.fulltriangle_all_fal = new List<short>();
            if (prod.fulltype > 0)
            {
                str1 = "";
            }
            List<KPPlanetMappingVO> kPPlanetMappingVOs = new List<KPPlanetMappingVO>();
            kPPlanetMappingVOs = kp_chart;
            if (prod.fulltype_planet > 0)
            {
                kPPlanetMappingVOs = (
                    from Map in kPPlanetMappingVOs
                    where Map.Planet == prod.fulltype_planet
                    select Map).ToList<KPPlanetMappingVO>();
            }
            foreach (KPPlanetMappingVO kPPlanetMappingVO in kPPlanetMappingVOs)
            {
                str = string.Concat(str, this.Get_Mix_Fal(kPPlanetMappingVO.Planet, kp_chart, cusp_house, persKV, prod, age, false, true, "fulltriangle", StartDate, EndDate));
            }
            this.fulltriangle_all_fal = new List<short>();
            if (str.Length > 50)
            {
                str = string.Concat(str1, str);
            }
            return str;
        }

        public string Get_Full_Yog(List<KPPlanetMappingVO> kp_chart, List<KPHouseMappingVO> cusp_house, KundliVO persKV, ProductSettingsVO prod, short age, DateTime StartDate, DateTime EndDate)
        {
            string str = "";
            PredictionBLL predictionBLL = new PredictionBLL();
            string str1 = string.Concat(predictionBLL.GetCodeLang("getfullyog", persKV.Language, true, true), "\r\n\r\n");
            if (prod.fulltype > 0)
            {
                str1 = "";
            }
            this.fullyog_all_fal = new List<short>();
            List<KPPlanetMappingVO> kPPlanetMappingVOs = new List<KPPlanetMappingVO>();
            kPPlanetMappingVOs = kp_chart;
            if (prod.fulltype_planet > 0)
            {
                kPPlanetMappingVOs = (
                    from Map in kPPlanetMappingVOs
                    where Map.Planet == prod.fulltype_planet
                    select Map).ToList<KPPlanetMappingVO>();
            }
            foreach (KPPlanetMappingVO kPPlanetMappingVO in kPPlanetMappingVOs)
            {
                str = string.Concat(str, this.Get_Mix_Fal(kPPlanetMappingVO.Planet, kp_chart, cusp_house, persKV, prod, age, false, true, "fullyog", StartDate, EndDate));
            }
            this.fullyog_all_fal = new List<short>();
            if (str.Length > 50)
            {
                str = string.Concat(str1, str);
            }
            return str;
        }

        public string Get_Full_Yuti(List<KPPlanetMappingVO> kp_chart, List<KPHouseMappingVO> cusp_house, KundliVO persKV, ProductSettingsVO prod, short age, DateTime StartDate, DateTime EndDate)
        {
            string str = "";
            PredictionBLL predictionBLL = new PredictionBLL();
            string str1 = string.Concat(predictionBLL.GetCodeLang("getfullyuti", persKV.Language, true, true), "\r\n\r\n");
            if (prod.fulltype > 0)
            {
                str1 = "";
            }
            this.fullyuti_all_fal = new List<short>();
            this.fullyuti_house = new List<short>();
            foreach (KPPlanetMappingVO kpChart in kp_chart)
            {
                str = string.Concat(str, this.Get_Mix_Fal(kpChart.Planet, kp_chart, cusp_house, persKV, prod, age, false, true, "fullyuti", StartDate, EndDate));
            }
            this.fullyuti_all_fal = new List<short>();
            this.fullyuti_house = new List<short>();
            if (str.Length > 50)
            {
                str = string.Concat(str1, str);
            }
            return str;
        }

        public string Get_GDG_Logic(short dasha, short subdasha, ProductSettingsVO prod, DateTime startdate, DateTime enddate, List<KPPlanetMappingVO> kp_chart, List<KPHouseMappingVO> cusp_house, KundliVO persKV, string ptype)
        {
            string str;
            string str1 = "";
            List<KPRashiVO> kPRashiVOs = new List<KPRashiVO>();
            short house = (
                from Map in kp_chart
                where Map.Planet == subdasha
                select Map).SingleOrDefault<KPPlanetMappingVO>().House;
            short rashi = (
                from Map in kp_chart
                where Map.Planet == subdasha
                select Map).SingleOrDefault<KPPlanetMappingVO>().Rashi;
            List<short> nums = new List<short>();
            if ((subdasha == 8 ? false : subdasha != 9))
            {
                kPRashiVOs = (
                    from Map in KPBLL.rashi_list
                    where Map.Swami == subdasha
                    select Map).ToList<KPRashiVO>();
                foreach (KPRashiVO kPRashiVO in kPRashiVOs)
                {
                    nums.Add((
                        from Map in cusp_house
                        where Map.LaganRashi == kPRashiVO.Rashi
                        select Map).SingleOrDefault<KPHouseMappingVO>().House);
                }
                short nakLord = (
                    from Map in kp_chart
                    where Map.Planet == dasha
                    select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
                string signiString = this.Get_Signi_String(nakLord, kp_chart, prod.Include);
                char[] chrArray = new char[] { ' ' };
                string[] strArrays = signiString.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                foreach (short num in nums)
                {
                    if (strArrays.Contains<string>(num.ToString()))
                    {
                        str1 = string.Concat(str1, this.Get_Dasha_Pred(nakLord, num.ToString(), startdate, enddate, persKV, ptype, prod, kp_chart), "\r\n");
                    }
                }
                str = str1;
            }
            else
            {
                str = "";
            }
            return str;
        }

        public string Get_Karyesh_Pred(List<KPHouseMappingVO> cusp_house, List<KPPlanetMappingVO> kp_chart)
        {
            string str = "";
            List<KP_Karyesh_Pred> kPKaryeshPreds = new List<KP_Karyesh_Pred>();
            KPDAO kPDAO = new KPDAO();
            foreach (KPHouseMappingVO cuspHouse in cusp_house)
            {
                List<KPSigniVO> list = (
                    from Map in (
                        from Map in kp_chart
                        where Map.Planet == cuspHouse.Sub_Lord
                        select Map).SingleOrDefault<KPPlanetMappingVO>().Signi
                    orderby Map.Rule
                    select Map).ToList<KPSigniVO>();
                foreach (KP_Karyesh_Pred kPKaryeshPred in (
                    from Map in kPDAO.Get_KP_Karyesh_Pred()
                    where Map.House == cuspHouse.House
                    select Map).ToList<KP_Karyesh_Pred>())
                {
                    string karyesh = kPKaryeshPred.Karyesh;
                    char[] chrArray = new char[] { ',' };
                    string[] array = karyesh.Split(chrArray).ToArray<string>();
                    bool flag = false;
                    string[] strArrays = array;
                    int num = 0;
                    while (num < (int)strArrays.Length)
                    {
                        string str1 = strArrays[num];
                        if (!list.Exists((KPSigniVO Map) => Map.Signi == Convert.ToInt16(str1)))
                        {
                            flag = false;
                            break;
                        }
                        else
                        {
                            flag = true;
                            num++;
                        }
                    }
                    if ((kPKaryeshPreds.Exists((KP_Karyesh_Pred Map) => Map.Sno == kPKaryeshPred.Sno) ? false : flag))
                    {
                        kPKaryeshPreds.Add(kPKaryeshPred);
                    }
                }
            }
            foreach (KP_Karyesh_Pred kPKaryeshPred1 in kPKaryeshPreds)
            {
                str = string.Concat(str, kPKaryeshPred1.Pred_Hindi, "\r\n\r\n");
            }
            return str;
        }

        public string Get_KP_Lang(short mixsno, string language, bool dashafal, bool upay, bool mini)
        {
            string predHindi = "";
            KPDAO kPDAO = new KPDAO();
            KPLangVO kPLangVO = new KPLangVO();
            kPLangVO = kPDAO.Get_KP_Lang(mixsno, dashafal, upay, language, mini);
            if (language.Trim().ToLower() == "hindi")
            {
                predHindi = kPLangVO.pred_hindi;
            }
            if (language.Trim().ToLower() == "punjabi")
            {
                predHindi = kPLangVO.pred_punjabi;
            }
            if (language.Trim().ToLower() == "tamil")
            {
                predHindi = kPLangVO.pred_tamil;
            }
            if (language.Trim().ToLower() == "telugu")
            {
                predHindi = kPLangVO.pred_telugu;
            }
            if (language.Trim().ToLower() == "oriya")
            {
                predHindi = kPLangVO.pred_oriya;
            }
            if (language.Trim().ToLower() == "english")
            {
                predHindi = kPLangVO.pred_english;
            }
            if ((language.Trim().ToLower() == "bengali" ? true : language.Trim().ToLower() == "bangla"))
            {
                predHindi = kPLangVO.pred_bengali;
            }
            if (language.Trim().ToLower() == "malayalam")
            {
                predHindi = kPLangVO.pred_malayalam;
            }
            if (language.Trim().ToLower() == "marathi")
            {
                predHindi = kPLangVO.pred_marathi;
            }
            if (language.Trim().ToLower() == "assamese")
            {
                predHindi = kPLangVO.pred_assamese;
            }
            if (language.Trim().ToLower() == "gujarati")
            {
                predHindi = kPLangVO.pred_gujarati;
            }
            if (language.Trim().ToLower() == "kannada")
            {
                predHindi = kPLangVO.pred_kannada;
            }
            return predHindi;
        }

        public short Get_Logical_Number(string hashvalue, List<KPRemediesVO> logicalupay)
        {
            short sno;
            short num = 0;
            if ((hashvalue.Trim().Length <= 0 ? false : !(hashvalue.Trim() == "0")))
            {
                bool flag = false;
                char[] chrArray = new char[] { ',' };
                string[] strArrays = hashvalue.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                foreach (KPRemediesVO kPRemediesVO in
                    from Map in logicalupay
                    where Map.Planethouse != "0"
                    select Map)
                {
                    flag = false;
                    string planethouse = kPRemediesVO.Planethouse;
                    chrArray = new char[] { ',' };
                    string[] strArrays1 = planethouse.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                    int num1 = 0;
                    while (num1 < (int)strArrays1.Length)
                    {
                        string str = strArrays1[num1];
                        chrArray = new char[] { '#' };
                        string[] strArrays2 = str.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                        if (strArrays.Contains<string>(string.Concat(strArrays2[0], "#", strArrays2[1])))
                        {
                            num1++;
                        }
                        else
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                    {
                        sno = kPRemediesVO.Sno;
                        return sno;
                    }
                }
                sno = num;
            }
            else
            {
                sno = 0;
            }
            return sno;
        }

        public string Get_Mahadasha_Fal(List<KPPlanetMappingVO> kp_chart, List<KPHouseMappingVO> cusp_house, KundliVO persKV, bool include, ProductSettingsVO prod)
        {
            string str;
            string str1 = "";
            PredictionBLL predictionBLL = new PredictionBLL();
            List<KPDashaVO> kPDashaVOs = new List<KPDashaVO>();
            List<KPDashaVO> antarDasha = new List<KPDashaVO>();
            List<KPDashaVO> prayatntarDasha = new List<KPDashaVO>();
            List<KPDashafalChainVO> kPDashafalChainVOs = new List<KPDashafalChainVO>();
            KPDAO kPDAO = new KPDAO();
            string str2 = "";
            kPDashaVOs = this.Get_Dasha(cusp_house, kp_chart, persKV, include);
            bool flag = true;
            string str3 = "";
            string str4 = "";
            kPDashafalChainVOs = kPDAO.Get_Dashafal_Chain();
            str1 = string.Concat(str1, this.Get_Only_Mahadasha(cusp_house, kp_chart, persKV, include, true, true, prod, false));
            str2 = str1;
            str1 = "";
            persKV.Dob.AddYears(72);
            kPDashaVOs = (
                from Map in kPDashaVOs
                where (DateTime.Now.Date < Map.StartDate ? false : DateTime.Now.Date <= Map.EndDate)
                select Map).ToList<KPDashaVO>();
            foreach (KPDashaVO kPDashaVO in kPDashaVOs)
            {
                antarDasha = this.Get_Antar_Dasha(kPDashaVO.StartDate, kPDashaVO.EndDate, kPDashaVO.Planet, kp_chart, include);
                DateTime startDate = kPDashaVO.StartDate;
                DateTime endDate = kPDashaVO.EndDate;
                Convert.ToInt16(predictionBLL.CalculateAgeCorrect(persKV.Dob, startDate));
                Convert.ToInt16(predictionBLL.CalculateAgeCorrect(persKV.Dob, endDate));
                short house = (
                    from Map in kp_chart
                    where Map.Planet == kPDashaVO.Planet
                    select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                this.Get_Signi_String(kPDashaVO.Planet, kp_chart, include);
                antarDasha = (
                    from Map in antarDasha
                    where DateTime.Now.Date >= Map.StartDate
                    select Map).ToList<KPDashaVO>();
                foreach (KPDashaVO kPDashaVO1 in antarDasha)
                {
                    DateTime dateTime = kPDashaVO1.StartDate;
                    DateTime endDate1 = kPDashaVO1.EndDate;
                    string[] codeLang = new string[] { dateTime.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", dateTime.ToString("%M")), persKV.Language, persKV.Paid, true), " ", dateTime.ToString("yyyy") };
                    string str5 = string.Concat(codeLang);
                    codeLang = new string[] { endDate1.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", endDate1.ToString("%M")), persKV.Language, persKV.Paid, true), " ", endDate1.ToString("yyyy") };
                    string str6 = string.Concat(codeLang);
                    KPDAO kPDAO1 = new KPDAO();
                    short num = Convert.ToInt16(predictionBLL.CalculateAgeCorrect(persKV.Dob, dateTime));
                    Convert.ToInt16(predictionBLL.CalculateAgeCorrect(persKV.Dob, endDate1));
                    if (num < persKV.Current_Age + 3)
                    {
                        if (persKV.ShowRef)
                        {
                            str4 = string.Concat(KPBLL.planet_list[kPDashaVO.Planet - 1].Hindi, " ", KPBLL.planet_list[kPDashaVO1.Planet - 1].Hindi, " ");
                        }
                        codeLang = new string[] { str5, predictionBLL.GetCodeLang("to", persKV.Language, persKV.Paid, true), str6, "  ", str4, "\r\n" };
                        str3 = string.Concat(codeLang);
                        string str7 = "";
                        short nakLord = (
                            from Map in kp_chart
                            where Map.Planet == kPDashaVO.Planet
                            select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
                        short nakLord1 = (
                            from Map in kp_chart
                            where Map.Planet == kPDashaVO1.Planet
                            select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
                        short house1 = (
                            from Map in kp_chart
                            where Map.Planet == nakLord1
                            select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                        string signiString = this.Get_Signi_String(nakLord, kp_chart, include);
                        string signiString1 = this.Get_Signi_String(nakLord1, kp_chart, include);
                        this.Get_Signi_String(nakLord1, kp_chart, include);
                        char[] chrArray = new char[] { ' ' };
                        string[] strArrays = signiString.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                        chrArray = new char[] { ' ' };
                        string[] strArrays1 = signiString1.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                        signiString = strArrays[0];
                        if ((int)strArrays.Length > 1)
                        {
                            signiString = string.Concat(signiString, " ", strArrays[1]);
                        }
                        signiString1 = strArrays1[0];
                        if ((int)strArrays1.Length > 1)
                        {
                            signiString1 = string.Concat(signiString1, " ", strArrays1[1]);
                        }
                        string.Concat(signiString, " ", signiString1);
                        if (persKV.ShowRef)
                        {
                            str = str7;
                            codeLang = new string[] { str, KPBLL.planet_list[nakLord1 - 1].Hindi.ToString(), "  ", signiString1.ToString(), "  " };
                            str7 = string.Concat(codeLang);
                        }
                        str7 = string.Concat(str7, this.Get_Mix_Fal(nakLord1, kp_chart, cusp_house, persKV, prod, num, true, false, "dasha", dateTime, endDate1), "\r\n\r\n");
                        if (str7.Length > 50)
                        {
                            str1 = string.Concat(str1, str3, "\r\n", str7);
                        }
                        str7 = "";
                        prayatntarDasha = this.Get_Prayatntar_Dasha(antarDasha, dateTime, endDate1, kPDashaVO.Planet, kPDashaVO1.Planet, kp_chart, include);
                        string str8 = "";
                        foreach (KPDashaVO kPDashaVO2 in prayatntarDasha)
                        {
                            DateTime startDate1 = kPDashaVO2.StartDate;
                            DateTime dateTime1 = kPDashaVO2.EndDate;
                            codeLang = new string[] { startDate1.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", startDate1.ToString("%M")), persKV.Language, persKV.Paid, true), " ", startDate1.ToString("yyyy") };
                            str5 = string.Concat(codeLang);
                            codeLang = new string[] { dateTime1.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", dateTime1.ToString("%M")), persKV.Language, persKV.Paid, true), " ", dateTime1.ToString("yyyy") };
                            str6 = string.Concat(codeLang);
                            short num1 = Convert.ToInt16(predictionBLL.CalculateAgeCorrect(persKV.Dob, startDate1));
                            Convert.ToInt16(predictionBLL.CalculateAgeCorrect(persKV.Dob, dateTime1));
                            if (num1 < persKV.Current_Age + 3)
                            {
                                flag = true;
                                if (persKV.ShowRef)
                                {
                                    codeLang = new string[] { KPBLL.planet_list[kPDashaVO.Planet - 1].Hindi, " ", KPBLL.planet_list[kPDashaVO1.Planet - 1].Hindi, " ", KPBLL.planet_list[kPDashaVO2.Planet - 1].Hindi };
                                    str4 = string.Concat(codeLang);
                                }
                                codeLang = new string[] { str5, predictionBLL.GetCodeLang("to", persKV.Language, persKV.Paid, true), str6, "  ", str4, "\r\n\r\n" };
                                str3 = string.Concat(codeLang);
                                short nakLord2 = (
                                    from Map in kp_chart
                                    where Map.Planet == kPDashaVO2.Planet
                                    select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
                                short house2 = (
                                    from Map in kp_chart
                                    where Map.Planet == nakLord2
                                    select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                                string signiString2 = this.Get_Signi_String(kPDashaVO2.Planet, kp_chart, include);
                                chrArray = new char[] { ' ' };
                                string[] strArrays2 = signiString1.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                                signiString2 = strArrays2[0];
                                chrArray = new char[] { ' ' };
                                string[] strArrays3 = signiString2.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                                string signiString3 = this.Get_Signi_String(nakLord2, kp_chart, include);
                                signiString3 = strArrays3[0];
                                this.Get_Signi_String(kPDashaVO2.Planet, kp_chart, include);
                                this.Get_Signi_String(kPDashaVO1.Planet, kp_chart, include);
                                if ((int)strArrays3.Length > 1)
                                {
                                    signiString3 = string.Concat(signiString3, " ", strArrays3[1]);
                                }
                                if ((int)strArrays2.Length > 1)
                                {
                                    signiString2 = string.Concat(signiString2, " ", strArrays2[1]);
                                }
                                if (persKV.ShowRef)
                                {
                                    str = str8;
                                    codeLang = new string[] { str, KPBLL.planet_list[nakLord2 - 1].Hindi.ToString(), "  ", signiString3.ToString(), "  " };
                                    str8 = string.Concat(codeLang);
                                }
                                str8 = string.Concat(str8, this.Get_Dasha_Pred(nakLord2, signiString3, startDate1, dateTime1, persKV, "mfal", prod, kp_chart), "\r\n\r\n");
                                if (str8.Length > 50)
                                {
                                    str1 = string.Concat(str1, str3, "\r\n\r\n", str8);
                                }
                                str8 = "";
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return string.Concat(str2, "\r\n\r\n", str1);
        }

        public string Get_Matchmaking(ProductSettingsVO boyprod, ProductSettingsVO girlprod, string language)
        {
            PredictionBLL predictionBLL = new PredictionBLL();
            string str = string.Concat("<B>", predictionBLL.GetCodeLang("upaymatchmaking", language, true, true), "</B>\r\n\r\n");
            str = string.Concat("<h2>", predictionBLL.GetCodeLang("ladka", language, true, true), "</h2>\r\n\r\n");
            str = string.Concat(str, this.Get_New_Products(boyprod));
            str = string.Concat(str, "\r\n\r\n");
            str = string.Concat(str, "<h2>", predictionBLL.GetCodeLang("ladki", language, true, true), "</h2>");
            str = string.Concat(str, this.Get_New_Products(girlprod));
            if (boyprod.Paid)
            {
                short num = 0;
                short num1 = 0;
                num = Convert.ToInt16((int)(AstroGlobal.MM_child + AstroGlobal.MM_married + AstroGlobal.MM_profession + AstroGlobal.MM_health));
                num1 = Convert.ToInt16((int)(AstroGlobal.MF_child + AstroGlobal.MF_married + AstroGlobal.MF_profession + AstroGlobal.MF_health));
                short num2 = Convert.ToInt16((this.perc(AstroGlobal.MM_child, AstroGlobal.MM_total) + this.perc(AstroGlobal.MM_married, AstroGlobal.MM_total) + this.perc(AstroGlobal.MM_health, AstroGlobal.MM_total) + this.perc(AstroGlobal.MM_profession, AstroGlobal.MM_total)) / 4);
                short num3 = Convert.ToInt16((this.perc(AstroGlobal.MF_child, AstroGlobal.MF_total) + this.perc(AstroGlobal.MF_married, AstroGlobal.MF_total) + this.perc(AstroGlobal.MF_health, AstroGlobal.MF_total) + this.perc(AstroGlobal.MF_profession, AstroGlobal.MF_total)) / 4);
                short num4 = 0;
                num4 = this.perc_score(num2, num3);
                str = string.Concat(str, "<br><br><h2>", predictionBLL.GetCodeLang(string.Concat("nishkarsh", num4.ToString()), language, true, true), "</h2>");
                string str1 = "";
                string codeLang = predictionBLL.GetCodeLang("boychild", language, true, true);
                short num5 = this.perc(AstroGlobal.MM_child, AstroGlobal.MM_total);
                str1 = string.Concat(str1, codeLang, num5.ToString(), "%");
                string str2 = str1;
                string[] strArrays = new string[] { str2, "\r\n\r\n", predictionBLL.GetCodeLang("boymarriage", language, true, true), null, null };
                num5 = this.perc(AstroGlobal.MM_married, AstroGlobal.MM_total);
                strArrays[3] = num5.ToString();
                strArrays[4] = "%";
                str2 = string.Concat(strArrays);
                strArrays = new string[] { str2, "\r\n\r\n", predictionBLL.GetCodeLang("boyhealth", language, true, true), null, null };
                num5 = this.perc(AstroGlobal.MM_health, AstroGlobal.MM_total);
                strArrays[3] = num5.ToString();
                strArrays[4] = "%";
                str2 = string.Concat(strArrays);
                strArrays = new string[] { str2, "\r\n\r\n", predictionBLL.GetCodeLang("boywork", language, true, true), null, null };
                num5 = this.perc(AstroGlobal.MM_profession, AstroGlobal.MM_total);
                strArrays[3] = num5.ToString();
                strArrays[4] = "%";
                str2 = string.Concat(strArrays);
                strArrays = new string[] { str2, "\r\n\r\n", predictionBLL.GetCodeLang("boymarks", language, true, true), num2.ToString(), "% </b>" };
                str2 = string.Concat(strArrays);
                strArrays = new string[] { str2, "\r\n\r\n", predictionBLL.GetCodeLang("girlchild", language, true, true), null, null };
                num5 = this.perc(AstroGlobal.MF_child, AstroGlobal.MF_total);
                strArrays[3] = num5.ToString();
                strArrays[4] = "%";
                str2 = string.Concat(strArrays);
                strArrays = new string[] { str2, "\r\n\r\n", predictionBLL.GetCodeLang("girlmarriage", language, true, true), null, null };
                num5 = this.perc(AstroGlobal.MF_married, AstroGlobal.MF_total);
                strArrays[3] = num5.ToString();
                strArrays[4] = "%";
                str2 = string.Concat(strArrays);
                strArrays = new string[] { str2, "\r\n\r\n", predictionBLL.GetCodeLang("girlhealth", language, true, true), null, null };
                num5 = this.perc(AstroGlobal.MF_health, AstroGlobal.MF_total);
                strArrays[3] = num5.ToString();
                strArrays[4] = "%";
                str2 = string.Concat(strArrays);
                strArrays = new string[] { str2, "\r\n\r\n", predictionBLL.GetCodeLang("girlwork", language, true, true), null, null };
                num5 = this.perc(AstroGlobal.MF_profession, AstroGlobal.MF_total);
                strArrays[3] = num5.ToString();
                strArrays[4] = "%";
                str2 = string.Concat(strArrays);
                strArrays = new string[] { str2, "\r\n\r\n", predictionBLL.GetCodeLang("girlmarks", language, true, true), num3.ToString(), "% </b>" };
                str1 = string.Concat(strArrays);
                str = string.Concat(str, "\r\n", str1, "\r\n");
                str = string.Concat(str, "\r\n\r\n<b>", predictionBLL.GetCodeLang("upaymatchmaking", language, true, true), "</b>");
            }
            return str;
        }

        public string Get_Mix_Fal(short planet1, List<KPPlanetMappingVO> kp_chart, List<KPHouseMappingVO> cusp_house, KundliVO persKV, ProductSettingsVO prod, short age, bool mahadasha, bool no_nak, string ptype, DateTime StartDate, DateTime EndDate)
        {
            short house;
            short num;
            short house1;
            short sno;
            string str;
            string[] codeLang;
            bool flag;
            bool flag1;
            bool flag2;
            short nakLord = planet1;
            string str1 = "";
            PredictionBLL predictionBLL = new PredictionBLL();
            List<short> nums = new List<short>();
            short bhavChalitHouse = 0;
            short num1 = nakLord;
            bhavChalitHouse = (
                from Map in kp_chart
                where Map.Planet == nakLord
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            KPDAO kPDAO = new KPDAO();
            List<KPMixDashaVO> kPMixDashaVOs = new List<KPMixDashaVO>();
            string signiStringWithoutNakRashi = "";
            if (!mahadasha)
            {
                if (!no_nak)
                {
                    nakLord = (
                        from Map in kp_chart
                        where Map.Planet == nakLord
                        select Map).FirstOrDefault<KPPlanetMappingVO>().Nak_Lord;
                }
                signiStringWithoutNakRashi = this.Get_Signi_String_Without_NakRashi(nakLord, kp_chart, false);
            }
            else
            {
                signiStringWithoutNakRashi = this.Get_Signi_String_Without_NakRashi(nakLord, kp_chart, false);
                if (age <= 16)
                {
                    ptype = "fulllifechild";
                }
                if (age > 16)
                {
                    ptype = "fulllifeadult";
                }
                kPMixDashaVOs = (
                    from Map in kPDAO.Get_Mix_Dasha(nakLord, bhavChalitHouse, 1, prod.Product, ptype)
                    where (Map.ptype == "fulllifeadult" ? true : Map.ptype == "fulllifechild")
                    select Map).ToList<KPMixDashaVO>();
            }
            string[] strArrays = signiStringWithoutNakRashi.Split(new char[] { ' ' });
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string str2 = strArrays[i];
                short num2 = Convert.ToInt16(str2);
                if ((!(ptype != "fulllifeadult") || !(ptype != "fulllifechild") ? false : ptype != "khabar"))
                {
                    if ((age < 0 ? false : age <= 5))
                    {
                        kPMixDashaVOs = (
                            from Map in kPDAO.Get_Mix_Dasha(nakLord, num2, 1, prod.Product, ptype)
                            where (Map.education || Map.disease || Map.sibling ? true : Map.parents)
                            select Map).ToList<KPMixDashaVO>();
                    }
                    if ((age <= 5 ? false : age <= 16))
                    {
                        kPMixDashaVOs = (
                            from Map in kPDAO.Get_Mix_Dasha(nakLord, num2, 1, prod.Product, ptype)
                            where (Map.education || Map.disease || Map.family || Map.sibling || Map.parents ? true : Map.uncle)
                            select Map).ToList<KPMixDashaVO>();
                    }
                    if ((age <= 16 ? false : age <= 20))
                    {
                        kPMixDashaVOs = (
                            from Map in kPDAO.Get_Mix_Dasha(nakLord, num2, 1, prod.Product, ptype)
                            where (Map.married_life || Map.occupation || Map.love_affair || Map.education || Map.disease || Map.family || Map.parents || Map.sibling ? true : Map.uncle)
                            select Map).ToList<KPMixDashaVO>();
                    }
                    if ((age <= 20 ? false : age <= 27))
                    {
                        kPMixDashaVOs = (
                            from Map in kPDAO.Get_Mix_Dasha(nakLord, num2, 1, prod.Product, ptype)
                            where (Map.precaution || Map.wealth || Map.occupation || Map.married_life || Map.love_affair || Map.education || Map.nature || Map.disease || Map.family || Map.parents || Map.sibling ? true : Map.uncle)
                            select Map).ToList<KPMixDashaVO>();
                    }
                    if ((age <= 27 ? false : age <= 35))
                    {
                        kPMixDashaVOs = (
                            from Map in kPDAO.Get_Mix_Dasha(nakLord, num2, 1, prod.Product, ptype)
                            where (Map.general || Map.nature || Map.precaution || Map.wealth || Map.occupation || Map.santan || Map.married_life || Map.love_affair || Map.disease || Map.family || Map.parents || Map.sibling ? true : Map.uncle)
                            select Map).ToList<KPMixDashaVO>();
                    }
                    if ((age <= 35 ? false : age <= 50))
                    {
                        kPMixDashaVOs = (
                            from Map in kPDAO.Get_Mix_Dasha(nakLord, num2, 1, prod.Product, ptype)
                            where (Map.married_life || Map.nature || Map.precaution || Map.wealth || Map.general || Map.occupation || Map.santan || Map.love_affair || Map.disease || Map.family || Map.parents ? true : Map.sibling)
                            select Map).ToList<KPMixDashaVO>();
                    }
                    if ((age <= 50 ? false : age <= 70))
                    {
                        kPMixDashaVOs = (
                            from Map in kPDAO.Get_Mix_Dasha(nakLord, num2, 1, prod.Product, ptype)
                            where (Map.married_life || Map.wealth || Map.occupation || Map.santan || Map.disease || Map.family || Map.sibling ? true : Map.general)
                            select Map).ToList<KPMixDashaVO>();
                    }
                    if (age > 70)
                    {
                        kPMixDashaVOs = (
                            from Map in kPDAO.Get_Mix_Dasha(nakLord, num2, 1, prod.Product, ptype)
                            where (Map.married_life || Map.wealth || Map.santan || Map.disease ? true : Map.family)
                            select Map).ToList<KPMixDashaVO>();
                    }
                }
                if (!(!(prod.Product.ToLower() == "work_pred") || age < 10 || age > 60 ? true : !mahadasha))
                {
                    kPMixDashaVOs = (
                        from Map in kPDAO.Get_Mix_Dasha(nakLord, Convert.ToInt16(str2), 1, prod.Product, "work_pred")
                        where Map.work_pred
                        select Map).ToList<KPMixDashaVO>();
                    short house2 = (
                        from Map in kp_chart
                        where Map.Planet == nakLord
                        select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                    short nakLord1 = (
                        from Map in kp_chart
                        where Map.Planet == nakLord
                        select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
                    short bhavChalitHouse1 = (
                        from Map in kp_chart
                        where Map.Planet == nakLord1
                        select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
                    short bhavChalitHouse2 = (
                        from Map in kp_chart
                        where Map.Planet == nakLord
                        select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
                    if (bhavChalitHouse1 != house2)
                    {
                        kPMixDashaVOs.AddRange((
                            from Map in kPDAO.Get_Mix_Dasha(nakLord, Convert.ToInt16(bhavChalitHouse1), 1, prod.Product, "work_pred")
                            where Map.work_pred
                            select Map).ToList<KPMixDashaVO>());
                    }
                    if ((bhavChalitHouse2 == house2 ? false : bhavChalitHouse2 != bhavChalitHouse1))
                    {
                        kPMixDashaVOs.AddRange((
                            from Map in kPDAO.Get_Mix_Dasha(nakLord, Convert.ToInt16(bhavChalitHouse2), 1, prod.Product, "work_pred")
                            where Map.work_pred
                            select Map).ToList<KPMixDashaVO>());
                    }
                }
                else if (!mahadasha)
                {
                    kPMixDashaVOs.AddRange(kPDAO.Get_Mix_Dasha(nakLord, 0, 1, prod.Product, "yuti"));
                }
                if (ptype == "fullyog")
                {
                    kPMixDashaVOs = kPDAO.Get_Mix_Dasha(num1, bhavChalitHouse, 1, prod.Product, "fullyog").ToList<KPMixDashaVO>();
                    if ((prod.fulltype != 2 ? false : prod.fulltype_planet > 0))
                    {
                        kPMixDashaVOs = (
                            from Map in kPMixDashaVOs
                            where Map.Planet1 == prod.fulltype_planet
                            select Map).ToList<KPMixDashaVO>();
                    }
                }
                if (ptype == "fullyuti")
                {
                    kPMixDashaVOs = kPDAO.Get_Mix_Dasha(num1, bhavChalitHouse, 1, prod.Product, "fullyuti").ToList<KPMixDashaVO>();
                }
                if (ptype == "fulltriangle")
                {
                    kPMixDashaVOs = kPDAO.Get_Mix_Dasha(num1, bhavChalitHouse, 1, prod.Product, "fulltriangle").ToList<KPMixDashaVO>();
                    if ((prod.fulltype != 1 ? false : prod.fulltype_planet > 0))
                    {
                        kPMixDashaVOs = (
                            from Map in kPMixDashaVOs
                            where Map.Planet2 == prod.fulltype_planet
                            select Map).ToList<KPMixDashaVO>();
                    }
                }
                if ((ptype == "fulltriangle" || ptype == "fullyuti" ? true : ptype == "fullyog"))
                {
                    if (prod.Product == "disease")
                    {
                        kPMixDashaVOs = (
                            from Map in kPMixDashaVOs
                            where Map.disease
                            select Map).ToList<KPMixDashaVO>();
                    }
                    if (prod.Product == "occupation")
                    {
                        kPMixDashaVOs = (
                            from Map in kPMixDashaVOs
                            where (Map.occupation || Map.education ? true : Map.wealth)
                            select Map).ToList<KPMixDashaVO>();
                    }
                    if (prod.Product == "married_life")
                    {
                        kPMixDashaVOs = (
                            from Map in kPMixDashaVOs
                            where (Map.married_life ? true : Map.love_affair)
                            select Map).ToList<KPMixDashaVO>();
                    }
                    if (prod.Product == "santan")
                    {
                        kPMixDashaVOs = (
                            from Map in kPMixDashaVOs
                            where Map.santan
                            select Map).ToList<KPMixDashaVO>();
                    }
                    if (prod.Product == "parents")
                    {
                        kPMixDashaVOs = (
                            from Map in kPMixDashaVOs
                            where (Map.parents ? true : Map.family)
                            select Map).ToList<KPMixDashaVO>();
                    }
                }
                if (ptype == "khabar")
                {
                    kPMixDashaVOs = kPDAO.Get_Mix_Dasha(num1, bhavChalitHouse, 1, prod.Product, "khabar").ToList<KPMixDashaVO>();
                }
                if (prod.fulltype > 0)
                {
                    if ((age < 0 ? false : age <= 5))
                    {
                        kPMixDashaVOs = (
                            from Map in kPMixDashaVOs
                            where (Map.education || Map.disease || Map.sibling ? true : Map.parents)
                            select Map).ToList<KPMixDashaVO>();
                    }
                    if ((age <= 5 ? false : age <= 16))
                    {
                        kPMixDashaVOs = (
                            from Map in kPMixDashaVOs
                            where (Map.education || Map.disease || Map.family || Map.sibling || Map.parents ? true : Map.uncle)
                            select Map).ToList<KPMixDashaVO>();
                    }
                    if ((age <= 16 ? false : age <= 20))
                    {
                        kPMixDashaVOs = (
                            from Map in kPMixDashaVOs
                            where (Map.married_life || Map.occupation || Map.love_affair || Map.education || Map.disease || Map.family || Map.parents || Map.sibling ? true : Map.uncle)
                            select Map).ToList<KPMixDashaVO>();
                    }
                    if ((age <= 20 ? false : age <= 27))
                    {
                        kPMixDashaVOs = (
                            from Map in kPMixDashaVOs
                            where (Map.precaution || Map.wealth || Map.occupation || Map.married_life || Map.love_affair || Map.education || Map.nature || Map.disease || Map.family || Map.parents || Map.sibling ? true : Map.uncle)
                            select Map).ToList<KPMixDashaVO>();
                    }
                    if ((age <= 27 ? false : age <= 35))
                    {
                        kPMixDashaVOs = (
                            from Map in kPMixDashaVOs
                            where (Map.general || Map.nature || Map.precaution || Map.wealth || Map.occupation || Map.santan || Map.married_life || Map.love_affair || Map.disease || Map.family || Map.parents || Map.sibling ? true : Map.uncle)
                            select Map).ToList<KPMixDashaVO>();
                    }
                    if ((age <= 35 ? false : age <= 45))
                    {
                        kPMixDashaVOs = (
                            from Map in kPMixDashaVOs
                            where (Map.married_life || Map.nature || Map.precaution || Map.wealth || Map.general || Map.occupation || Map.santan || Map.love_affair || Map.disease || Map.family || Map.parents ? true : Map.sibling)
                            select Map).ToList<KPMixDashaVO>();
                    }
                    if ((age <= 45 ? false : age <= 60))
                    {
                        kPMixDashaVOs = (
                            from Map in kPMixDashaVOs
                            where (Map.wealth || Map.occupation || Map.santan || Map.disease || Map.family || Map.sibling ? true : Map.general)
                            select Map).ToList<KPMixDashaVO>();
                    }
                    if (age > 60)
                    {
                        kPMixDashaVOs = (
                            from Map in kPMixDashaVOs
                            where (Map.wealth || Map.santan || Map.disease ? true : Map.family)
                            select Map).ToList<KPMixDashaVO>();
                    }
                }
                short num3 = nakLord;
                short house3 = (
                    from Map in kp_chart
                    where Map.Planet == nakLord
                    select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                List<KPMixDashaVO> kPMixDashaVOs1 = new List<KPMixDashaVO>();
                kPMixDashaVOs1 = kPMixDashaVOs;
                if (persKV.Male)
                {
                    kPMixDashaVOs = (
                        from Map in kPMixDashaVOs1
                        where (!Map.common ? false : !Map.female)
                        select Map).ToList<KPMixDashaVO>();
                    kPMixDashaVOs.AddRange((
                        from Map in kPMixDashaVOs1
                        where Map.male
                        select Map).ToList<KPMixDashaVO>());
                }
                if (!persKV.Male)
                {
                    kPMixDashaVOs = (
                        from Map in kPMixDashaVOs1
                        where (!Map.common ? false : !Map.male)
                        select Map).ToList<KPMixDashaVO>();
                    kPMixDashaVOs.AddRange((
                        from Map in kPMixDashaVOs1
                        where Map.female
                        select Map).ToList<KPMixDashaVO>());
                }
                foreach (KPMixDashaVO kPMixDashaVO in kPMixDashaVOs)
                {
                    short house4 = 0;
                    house4 = (
                        from Map in kp_chart
                        where Map.Planet == kPMixDashaVO.Planet1
                        select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                    KPRemediesVO kPRemediesVO = new KPRemediesVO();
                    if (!nums.Exists((short Map) => Map == kPMixDashaVO.Sno))
                    {
                        if (!this.fullyog_all_fal.Exists((short Map) => Map == kPMixDashaVO.Sno))
                        {
                            if (!this.fullyuti_all_fal.Exists((short Map) => Map == kPMixDashaVO.Sno))
                            {
                                if (this.fulltriangle_all_fal.Exists((short Map) => Map == kPMixDashaVO.Sno))
                                {
                                    goto Label1;
                                }
                                flag = this.fullyuti_house.Exists((short Map) => Map == house4);
                                goto Label0;
                            }
                        }
                    }
                    Label1:
                    flag = true;
                    Label0:
                    if (!flag)
                    {
                        if (this.isAllConditionMet(kPMixDashaVO, kp_chart, str2, prod.Product.ToLower()))
                        {
                            if (persKV.ShowRef)
                            {
                                if ((!(ptype != "fullyog") || !(ptype != "fullyuti") ? true : !(ptype != "fulltriangle")))
                                {
                                    str = str1;
                                    codeLang = new string[] { str, "[A_mix_dasha  : ", kPMixDashaVO.lawtype, " ", null, null, null, null };
                                    sno = kPMixDashaVO.Sno;
                                    codeLang[4] = sno.ToString();
                                    codeLang[5] = " ] ";
                                    codeLang[6] = kPMixDashaVO.rules;
                                    codeLang[7] = " - ";
                                    str1 = string.Concat(codeLang);
                                }
                                else
                                {
                                    object obj = str1;
                                    object[] hindi = new object[] { obj, "[A_mix_dasha  : ", kPMixDashaVO.lawtype, " ", null, null, null, null, null, null };
                                    sno = kPMixDashaVO.Sno;
                                    hindi[4] = sno.ToString();
                                    hindi[5] = " ] ";
                                    hindi[6] = KPBLL.planet_list[kPMixDashaVO.Planet1 - 1].Hindi;
                                    hindi[7] = "-";
                                    hindi[8] = kPMixDashaVO.House1;
                                    hindi[9] = "  ";
                                    str1 = string.Concat(hindi);
                                    if (kPMixDashaVO.Planet2 != 0)
                                    {
                                        obj = str1;
                                        hindi = new object[] { obj, "  ", KPBLL.planet_list[kPMixDashaVO.Planet2 - 1].Hindi, "-", kPMixDashaVO.House2, "  " };
                                        str1 = string.Concat(hindi);
                                    }
                                    if (kPMixDashaVO.Planet3 != 0)
                                    {
                                        obj = str1;
                                        hindi = new object[] { obj, "  ", KPBLL.planet_list[kPMixDashaVO.Planet3 - 1].Hindi, "-", kPMixDashaVO.House3, "  " };
                                        str1 = string.Concat(hindi);
                                    }
                                    if (kPMixDashaVO.Planet4 != 0)
                                    {
                                        obj = str1;
                                        hindi = new object[] { obj, "  ", KPBLL.planet_list[kPMixDashaVO.Planet4 - 1].Hindi, "-", kPMixDashaVO.House4, "  " };
                                        str1 = string.Concat(hindi);
                                    }
                                }
                            }
                            str1 = string.Concat(str1, this.Get_KP_Lang(kPMixDashaVO.Sno, persKV.Language, false, false, prod.Mini));
                            this.ScoreMM(kPMixDashaVO.Isbad, kPMixDashaVO.verybad, kPMixDashaVO.married_life, kPMixDashaVO.occupation, kPMixDashaVO.santan, kPMixDashaVO.disease, prod.Male, "");
                            this.prev_mix_all_fal.Add(kPMixDashaVO.Sno);
                            nums.Add(kPMixDashaVO.Sno);
                            if (ptype == "fullyog")
                            {
                                this.fullyog_all_fal.Add(kPMixDashaVO.Sno);
                            }
                            if (ptype == "fullyuti")
                            {
                                this.fullyuti_all_fal.Add(kPMixDashaVO.Sno);
                                this.fullyuti_house.Add(house4);
                            }
                            if (ptype == "fulltriangle")
                            {
                                this.fulltriangle_all_fal.Add(kPMixDashaVO.Sno);
                            }
                            if ((!kPMixDashaVO.Isbad || kPMixDashaVO.Pred_Hindi.Trim().Length < 20 ? false : prod.ShowUpayCode))
                            {
                                kPRemediesVO = (!(kPMixDashaVO.reff == "vfal") ? (
                                    from Map in KPBLL.Remedy_List_General
                                    where (long)Map.RuleCode == kPMixDashaVO.Upay
                                    select Map).FirstOrDefault<KPRemediesVO>() : (
                                    from Map in KPBLL.Remedy_List_VFAL
                                    where (Map.Planet != num3 ? false : Map.House == house3)
                                    select Map).FirstOrDefault<KPRemediesVO>());
                                if ((ptype != "fullyuti" ? false : kPMixDashaVO.Upay <= (long)0))
                                {
                                    string str3 = "";
                                    if (kPMixDashaVO.lawtype == "Yuti 2")
                                    {
                                        house = (
                                            from Map in kp_chart
                                            where Map.Planet == kPMixDashaVO.Planet1
                                            select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                                        num = (
                                            from Map in kp_chart
                                            where Map.Planet == kPMixDashaVO.Planet2
                                            select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                                        codeLang = new string[7];
                                        sno = kPMixDashaVO.Planet1;
                                        codeLang[0] = sno.ToString();
                                        codeLang[1] = "#";
                                        codeLang[2] = house.ToString();
                                        codeLang[3] = ",";
                                        sno = kPMixDashaVO.Planet2;
                                        codeLang[4] = sno.ToString();
                                        codeLang[5] = "#";
                                        codeLang[6] = num.ToString();
                                        str3 = string.Concat(codeLang);
                                    }
                                    if (kPMixDashaVO.lawtype == "Yuti 3")
                                    {
                                        house = (
                                            from Map in kp_chart
                                            where Map.Planet == kPMixDashaVO.Planet1
                                            select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                                        num = (
                                            from Map in kp_chart
                                            where Map.Planet == kPMixDashaVO.Planet2
                                            select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                                        house1 = (
                                            from Map in kp_chart
                                            where Map.Planet == kPMixDashaVO.Planet3
                                            select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                                        codeLang = new string[11];
                                        sno = kPMixDashaVO.Planet1;
                                        codeLang[0] = sno.ToString();
                                        codeLang[1] = "#";
                                        codeLang[2] = house.ToString();
                                        codeLang[3] = ",";
                                        sno = kPMixDashaVO.Planet2;
                                        codeLang[4] = sno.ToString();
                                        codeLang[5] = "#";
                                        codeLang[6] = num.ToString();
                                        codeLang[7] = ",";
                                        sno = kPMixDashaVO.Planet3;
                                        codeLang[8] = sno.ToString();
                                        codeLang[9] = "#";
                                        codeLang[10] = house1.ToString();
                                        str3 = string.Concat(codeLang);
                                    }
                                    if (kPMixDashaVO.lawtype == "Yuti 4")
                                    {
                                        house = (
                                            from Map in kp_chart
                                            where Map.Planet == kPMixDashaVO.Planet1
                                            select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                                        num = (
                                            from Map in kp_chart
                                            where Map.Planet == kPMixDashaVO.Planet2
                                            select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                                        house1 = (
                                            from Map in kp_chart
                                            where Map.Planet == kPMixDashaVO.Planet3
                                            select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                                        short num4 = (
                                            from Map in kp_chart
                                            where Map.Planet == kPMixDashaVO.Planet4
                                            select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                                        codeLang = new string[15];
                                        sno = kPMixDashaVO.Planet1;
                                        codeLang[0] = sno.ToString();
                                        codeLang[1] = "#";
                                        codeLang[2] = house.ToString();
                                        codeLang[3] = ",";
                                        sno = kPMixDashaVO.Planet2;
                                        codeLang[4] = sno.ToString();
                                        codeLang[5] = "#";
                                        codeLang[6] = num.ToString();
                                        codeLang[7] = ",";
                                        sno = kPMixDashaVO.Planet3;
                                        codeLang[8] = sno.ToString();
                                        codeLang[9] = "#";
                                        codeLang[10] = house1.ToString();
                                        codeLang[11] = ",";
                                        sno = kPMixDashaVO.Planet4;
                                        codeLang[12] = sno.ToString();
                                        codeLang[13] = "#";
                                        codeLang[14] = num4.ToString();
                                        str3 = string.Concat(codeLang);
                                    }
                                    short logicalNumber = 0;
                                    if (str3.Length > 1)
                                    {
                                        logicalNumber = this.Get_Logical_Number(str3, KPBLL.Remedy_List_Logical);
                                    }
                                    if (logicalNumber > 0)
                                    {
                                        kPRemediesVO = (
                                            from Map in KPBLL.Remedy_List_Logical
                                            where Map.Sno == logicalNumber
                                            select Map).FirstOrDefault<KPRemediesVO>();
                                    }
                                }
                                if (ptype != "fulltriangle")
                                {
                                    flag1 = true;
                                }
                                else
                                {
                                    flag1 = (kPMixDashaVO.Upay < (long)0 ? true : kPMixDashaVO.Upay > (long)9);
                                }
                                if (!flag1)
                                {
                                    if (kPMixDashaVO.lawtype == "takrao")
                                    {
                                        flag2 = true;
                                    }
                                    else
                                    {
                                        flag2 = (kPMixDashaVO.Upay < (long)1 ? true : kPMixDashaVO.Upay > (long)9);
                                    }
                                    if (!flag2)
                                    {
                                        short house5 = (
                                            from Map in kp_chart
                                            where (long)Map.Planet == kPMixDashaVO.Upay
                                            select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                                        kPRemediesVO = (
                                            from Map in KPBLL.Remedy_List_Bupay
                                            where ((long)Map.Planet != kPMixDashaVO.Upay ? false : Map.House == house5)
                                            select Map).FirstOrDefault<KPRemediesVO>();
                                    }
                                    if (kPMixDashaVO.lawtype == "takrao")
                                    {
                                        short num5 = 0;
                                        short num6 = kPMixDashaVO.Planet1;
                                        short planet2 = kPMixDashaVO.Planet2;
                                        house = (
                                            from Map in kp_chart
                                            where Map.Planet == num6
                                            select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                                        num = (
                                            from Map in kp_chart
                                            where Map.Planet == planet2
                                            select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                                        short num7 = Convert.ToInt16((int)(house - num));
                                        if (num7 == 7)
                                        {
                                            num5 = planet2;
                                        }
                                        if (num7 == -7)
                                        {
                                            num5 = num6;
                                        }
                                        short house6 = (
                                            from Map in kp_chart
                                            where Map.Planet == num5
                                            select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                                        kPRemediesVO = (
                                            from Map in KPBLL.Remedy_List_Bupay
                                            where (Map.Planet != num5 ? false : Map.House == house6)
                                            select Map).FirstOrDefault<KPRemediesVO>();
                                    }
                                }
                                if ((kPRemediesVO != null || !(ptype != "fullyuti") || !(ptype != "fullyog") ? false : ptype != "fulltriangle"))
                                {
                                    kPRemediesVO = (
                                        from Map in KPBLL.Remedy_List_IA
                                        where (Map.Planet != num3 ? false : Map.House == house3)
                                        select Map).FirstOrDefault<KPRemediesVO>();
                                }
                                if ((ptype == "fulllifeadult" || ptype == "fulllifechild" ? mahadasha : false))
                                {
                                    kPRemediesVO = (
                                        from Map in KPBLL.Remedy_List_VFAL
                                        where (Map.Planet != num3 ? false : Map.House == house3)
                                        select Map).FirstOrDefault<KPRemediesVO>();
                                }
                                if (kPRemediesVO != null)
                                {
                                    KPUpayList kPUpayList = new KPUpayList();
                                    if (this.upay_list.Exists((KPUpayList Map) => Map.Sno == (long)kPRemediesVO.Sno))
                                    {
                                        long fakeCode = (
                                            from Map in this.upay_list
                                            where Map.Sno.ToString() == kPRemediesVO.Sno.ToString()
                                            select Map).SingleOrDefault<KPUpayList>().FakeCode;
                                        string str4 = fakeCode.ToString();
                                        if (!prod.ShowUpayBelow)
                                        {
                                            if (!prod.FreeUpay)
                                            {
                                                if (!persKV.ShowRef)
                                                {
                                                    str = str1;
                                                    codeLang = new string[] { str, "  <I>", predictionBLL.GetCodeLang("upay", persKV.Language, true, true), "</I> ", str4.ToString(), this.Gen_Link((long)kPRemediesVO.Sno, prod.Gen_Link, Convert.ToInt64(str4), mahadasha, (long)kPMixDashaVO.Sno, "R"), "\r\n\r\n" };
                                                    str1 = string.Concat(codeLang);
                                                }
                                                else
                                                {
                                                    str = str1;
                                                    codeLang = new string[] { str, "  [ A_kp_remedy : ", kPRemediesVO.Ptype, "  ", null, null, null, null, null, null };
                                                    sno = kPRemediesVO.Sno;
                                                    codeLang[4] = sno.ToString();
                                                    codeLang[5] = " ] ";
                                                    codeLang[6] = predictionBLL.GetCodeLang("upay", persKV.Language, true, true);
                                                    codeLang[7] = " ";
                                                    codeLang[8] = str4.ToString();
                                                    codeLang[9] = "\r\n\r\n";
                                                    str1 = string.Concat(codeLang);
                                                }
                                            }
                                            else if ((!(ptype != "fullyog") || !(ptype != "fullyuti") ? false : ptype != "fulltriangle"))
                                            {
                                                if (!persKV.ShowRef)
                                                {
                                                    str = str1;
                                                    codeLang = new string[] { str, "  <I>", predictionBLL.GetCodeLang("upay", persKV.Language, true, true), "</I> ", str4.ToString(), this.Gen_Link((long)kPRemediesVO.Sno, prod.Gen_Link, Convert.ToInt64(str4), mahadasha, (long)kPMixDashaVO.Sno, "R"), "\r\n\r\n" };
                                                    str1 = string.Concat(codeLang);
                                                }
                                                else
                                                {
                                                    str = str1;
                                                    codeLang = new string[] { str, "  [ A_kp_remedy : ", kPRemediesVO.Ptype, "  ", null, null, null, null, null, null };
                                                    sno = kPRemediesVO.Sno;
                                                    codeLang[4] = sno.ToString();
                                                    codeLang[5] = " ] ";
                                                    codeLang[6] = predictionBLL.GetCodeLang("upay", persKV.Language, true, true);
                                                    codeLang[7] = " ";
                                                    codeLang[8] = str4.ToString();
                                                    codeLang[9] = "\r\n\r\n";
                                                    str1 = string.Concat(codeLang);
                                                }
                                            }
                                        }
                                        if (prod.ShowUpayBelow)
                                        {
                                            str = str1;
                                            codeLang = new string[] { str, "\r\n", predictionBLL.GetCodeLang("upaytext", persKV.Language, true, true), "\r\n", kPUpayList.Upay };
                                            str1 = string.Concat(codeLang);
                                        }
                                    }
                                    else
                                    {
                                        long num8 = (long)(this.upay_list.Count<KPUpayList>() + 1);
                                        sno = kPRemediesVO.Sno;
                                        kPUpayList.Sno = (long)Convert.ToInt16(sno.ToString());
                                        sno = kPRemediesVO.Sno;
                                        kPUpayList.Code = (long)Convert.ToInt16(sno.ToString());
                                        kPUpayList.FakeCode = num8;
                                        kPUpayList.Upay = this.Get_KP_Lang(Convert.ToInt16(kPUpayList.Sno), persKV.Language, false, true, prod.Mini);
                                        if (!prod.ShowUpayBelow)
                                        {
                                            if (!prod.FreeUpay)
                                            {
                                                this.upay_list.Add(kPUpayList);
                                                if (!persKV.ShowRef)
                                                {
                                                    str = str1;
                                                    codeLang = new string[] { str, "  <I>", predictionBLL.GetCodeLang("upay", persKV.Language, true, true), "</I> ", num8.ToString(), this.Gen_Link((long)kPRemediesVO.Sno, prod.Gen_Link, num8, mahadasha, (long)kPMixDashaVO.Sno, "R"), "\r\n\r\n" };
                                                    str1 = string.Concat(codeLang);
                                                }
                                                else
                                                {
                                                    str = str1;
                                                    codeLang = new string[] { str, "  [ A_kp_remedy : ", kPRemediesVO.Ptype, "  ", null, null, null, null, null, null };
                                                    sno = kPRemediesVO.Sno;
                                                    codeLang[4] = sno.ToString();
                                                    codeLang[5] = " ] ";
                                                    codeLang[6] = predictionBLL.GetCodeLang("upay", persKV.Language, true, true);
                                                    codeLang[7] = " ";
                                                    codeLang[8] = num8.ToString();
                                                    codeLang[9] = "\r\n\r\n";
                                                    str1 = string.Concat(codeLang);
                                                }
                                            }
                                            else if ((!(ptype != "fullyog") || !(ptype != "fullyuti") ? false : ptype != "fulltriangle"))
                                            {
                                                this.upay_list.Add(kPUpayList);
                                                if (!persKV.ShowRef)
                                                {
                                                    str = str1;
                                                    codeLang = new string[] { str, "  <I>", predictionBLL.GetCodeLang("upay", persKV.Language, true, true), "</I> ", num8.ToString(), this.Gen_Link((long)kPRemediesVO.Sno, prod.Gen_Link, num8, mahadasha, (long)kPMixDashaVO.Sno, "R"), "\r\n\r\n" };
                                                    str1 = string.Concat(codeLang);
                                                }
                                                else
                                                {
                                                    str = str1;
                                                    codeLang = new string[] { str, "  [ A_kp_remedy : ", kPRemediesVO.Ptype, "  ", null, null, null, null, null, null };
                                                    sno = kPRemediesVO.Sno;
                                                    codeLang[4] = sno.ToString();
                                                    codeLang[5] = " ] ";
                                                    codeLang[6] = predictionBLL.GetCodeLang("upay", persKV.Language, true, true);
                                                    codeLang[7] = " ";
                                                    codeLang[8] = num8.ToString();
                                                    codeLang[9] = "\r\n\r\n";
                                                    str1 = string.Concat(codeLang);
                                                }
                                            }
                                        }
                                        if (prod.ShowUpayBelow)
                                        {
                                            str = str1;
                                            codeLang = new string[] { str, "\r\n", predictionBLL.GetCodeLang("upaytext", persKV.Language, true, true), "\r\n", kPUpayList.Upay };
                                            str1 = string.Concat(codeLang);
                                        }
                                    }
                                }
                            }
                            if ((!kPMixDashaVO.Isbad || kPRemediesVO == null || !prod.ShowUpayCode ? str1.Length >= 50 : false))
                            {
                                str1 = string.Concat(str1, "\r\n\r\n");
                            }
                        }
                    }
                }
            }
            if (str1.Length <= 50)
            {
                str1 = "";
            }
            return str1;
        }

        public string Get_Mix_Fal_PlanetWise(short planet1, List<KPPlanetMappingVO> kp_chart, List<KPHouseMappingVO> cusp_house, KundliVO persKV, ProductSettingsVO prod, short age, bool mahadasha, bool no_nak, DateTime StartDate, DateTime EndDate)
        {
            short sno;
            string str;
            string[] codeLang;
            short nakLord = planet1;
            string str1 = "";
            PredictionBLL predictionBLL = new PredictionBLL();
            List<short> nums = new List<short>();
            KPDAO kPDAO = new KPDAO();
            List<KPMixDashaVO> kPMixDashaVOs = new List<KPMixDashaVO>();
            string str2 = "dasha";
            string signiStringWithoutNakRashi = "";
            if (mahadasha)
            {
                signiStringWithoutNakRashi = this.Get_Signi_String_Without_NakRashi(nakLord, kp_chart, false);
                if (age <= 16)
                {
                    str2 = "fulllifechild";
                }
                if (age > 16)
                {
                    str2 = "fulllifeadult";
                }
            }
            else if (no_nak)
            {
                signiStringWithoutNakRashi = this.Get_Signi_String_Without_NakRashi(nakLord, kp_chart, false);
            }
            else
            {
                nakLord = (
                    from Map in kp_chart
                    where Map.Planet == nakLord
                    select Map).FirstOrDefault<KPPlanetMappingVO>().Nak_Lord;
                signiStringWithoutNakRashi = this.Get_Signi_String_Without_NakRashi(nakLord, kp_chart, false);
            }
            string[] strArrays = signiStringWithoutNakRashi.Split(new char[] { ' ' });
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string str3 = strArrays[i];
                short num = Convert.ToInt16(str3);
                if ((age < 0 ? false : age <= 5))
                {
                    kPMixDashaVOs = (
                        from Map in kPDAO.Get_Mix_Dasha_Planet_Wise(nakLord, num, 1, prod.Product, str2)
                        where (Map.education || Map.disease || Map.sibling ? true : Map.parents)
                        select Map).ToList<KPMixDashaVO>();
                }
                if ((age <= 5 ? false : age <= 16))
                {
                    kPMixDashaVOs = (
                        from Map in kPDAO.Get_Mix_Dasha_Planet_Wise(nakLord, num, 1, prod.Product, str2)
                        where (Map.education || Map.disease || Map.family || Map.sibling || Map.parents ? true : Map.uncle)
                        select Map).ToList<KPMixDashaVO>();
                }
                if ((age <= 16 ? false : age <= 20))
                {
                    kPMixDashaVOs = (
                        from Map in kPDAO.Get_Mix_Dasha_Planet_Wise(nakLord, num, 1, prod.Product, str2)
                        where (Map.married_life || Map.occupation || Map.love_affair || Map.education || Map.disease || Map.family || Map.parents || Map.sibling ? true : Map.uncle)
                        select Map).ToList<KPMixDashaVO>();
                }
                if ((age <= 20 ? false : age <= 25))
                {
                    kPMixDashaVOs = (
                        from Map in kPDAO.Get_Mix_Dasha_Planet_Wise(nakLord, num, 1, prod.Product, str2)
                        where (Map.precaution || Map.wealth || Map.occupation || Map.married_life || Map.love_affair || Map.education || Map.nature || Map.disease || Map.family || Map.parents || Map.sibling ? true : Map.uncle)
                        select Map).ToList<KPMixDashaVO>();
                }
                if ((age <= 25 ? false : age <= 35))
                {
                    kPMixDashaVOs = (
                        from Map in kPDAO.Get_Mix_Dasha_Planet_Wise(nakLord, num, 1, prod.Product, str2)
                        where (Map.general || Map.nature || Map.precaution || Map.wealth || Map.occupation || Map.santan || Map.married_life || Map.love_affair || Map.disease || Map.family || Map.parents || Map.sibling ? true : Map.uncle)
                        select Map).ToList<KPMixDashaVO>();
                }
                if ((age <= 35 ? false : age <= 50))
                {
                    kPMixDashaVOs = (
                        from Map in kPDAO.Get_Mix_Dasha_Planet_Wise(nakLord, num, 1, prod.Product, str2)
                        where (Map.married_life || Map.nature || Map.precaution || Map.wealth || Map.general || Map.occupation || Map.santan || Map.disease || Map.family || Map.parents ? true : Map.sibling)
                        select Map).ToList<KPMixDashaVO>();
                }
                if ((age <= 50 ? false : age <= 70))
                {
                    kPMixDashaVOs = (
                        from Map in kPDAO.Get_Mix_Dasha_Planet_Wise(nakLord, num, 1, prod.Product, str2)
                        where (Map.married_life || Map.wealth || Map.occupation || Map.santan || Map.disease || Map.family || Map.sibling ? true : Map.general)
                        select Map).ToList<KPMixDashaVO>();
                }
                if (age > 70)
                {
                    kPMixDashaVOs = (
                        from Map in kPDAO.Get_Mix_Dasha_Planet_Wise(nakLord, num, 1, prod.Product, str2)
                        where (Map.married_life || Map.wealth || Map.santan || Map.disease ? true : Map.family)
                        select Map).ToList<KPMixDashaVO>();
                }
                List<KPMixDashaVO> kPMixDashaVOs1 = new List<KPMixDashaVO>();
                kPMixDashaVOs1 = kPMixDashaVOs;
                if (persKV.Male)
                {
                    kPMixDashaVOs = (
                        from Map in kPMixDashaVOs1
                        where (!Map.common ? false : !Map.female)
                        select Map).ToList<KPMixDashaVO>();
                    kPMixDashaVOs.AddRange((
                        from Map in kPMixDashaVOs1
                        where Map.male
                        select Map).ToList<KPMixDashaVO>());
                }
                if (!persKV.Male)
                {
                    kPMixDashaVOs = (
                        from Map in kPMixDashaVOs1
                        where (!Map.common ? false : !Map.male)
                        select Map).ToList<KPMixDashaVO>();
                    kPMixDashaVOs.AddRange((
                        from Map in kPMixDashaVOs1
                        where Map.female
                        select Map).ToList<KPMixDashaVO>());
                }
                foreach (KPMixDashaVO kPMixDashaVO in kPMixDashaVOs)
                {
                    KPRemediesVO kPRemediesVO = new KPRemediesVO();
                    short num1 = kPMixDashaVO.Planet1;
                    short house = (
                        from Map in kp_chart
                        where Map.Planet == kPMixDashaVO.Planet1
                        select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                    if ((nums.Exists((short Map) => Map == kPMixDashaVO.Sno) ? false : !this.prev_mix_all_fal.Exists((short Map) => Map == kPMixDashaVO.Sno)))
                    {
                        if (this.isFewConditionMet(kPMixDashaVO, kp_chart, str3))
                        {
                            if (persKV.ShowRef)
                            {
                                object obj = str1;
                                object[] hindi = new object[] { obj, "[A_mix_dasha SIGNI : ", kPMixDashaVO.lawtype, " ", null, null, null, null, null, null };
                                sno = kPMixDashaVO.Sno;
                                hindi[4] = sno.ToString();
                                hindi[5] = " ] ";
                                hindi[6] = KPBLL.planet_list[kPMixDashaVO.Planet1 - 1].Hindi;
                                hindi[7] = "-";
                                hindi[8] = kPMixDashaVO.House1;
                                hindi[9] = "  ";
                                str1 = string.Concat(hindi);
                                if (kPMixDashaVO.Planet2 != 0)
                                {
                                    obj = str1;
                                    hindi = new object[] { obj, "  ", KPBLL.planet_list[kPMixDashaVO.Planet2 - 1].Hindi, "-", num, "  " };
                                    str1 = string.Concat(hindi);
                                }
                                if (kPMixDashaVO.Planet3 != 0)
                                {
                                    obj = str1;
                                    hindi = new object[] { obj, "  ", KPBLL.planet_list[kPMixDashaVO.Planet3 - 1].Hindi, "-", num, "  " };
                                    str1 = string.Concat(hindi);
                                }
                                if (kPMixDashaVO.Planet4 != 0)
                                {
                                    obj = str1;
                                    hindi = new object[] { obj, "  ", KPBLL.planet_list[kPMixDashaVO.Planet4 - 1].Hindi, "-", num, "  " };
                                    str1 = string.Concat(hindi);
                                }
                            }
                            str1 = string.Concat(str1, this.Get_KP_Lang(kPMixDashaVO.Sno, persKV.Language, false, false, prod.Mini));
                            this.ScoreMM(kPMixDashaVO.Isbad, kPMixDashaVO.verybad, kPMixDashaVO.married_life, kPMixDashaVO.occupation, kPMixDashaVO.santan, kPMixDashaVO.disease, prod.Male, "");
                            nums.Add(kPMixDashaVO.Sno);
                            this.prev_mix_all_fal.Add(kPMixDashaVO.Sno);
                            if ((!kPMixDashaVO.Isbad || kPMixDashaVO.Pred_Hindi.Trim().Length < 20 ? false : prod.ShowUpayCode))
                            {
                                kPRemediesVO = (!(kPMixDashaVO.reff == "vfal") ? (
                                    from Map in KPBLL.Remedy_List_General
                                    where (long)Map.RuleCode == kPMixDashaVO.Upay
                                    select Map).FirstOrDefault<KPRemediesVO>() : (
                                    from Map in KPBLL.Remedy_List_VFAL
                                    where (Map.Planet != num1 ? false : Map.House == house)
                                    select Map).FirstOrDefault<KPRemediesVO>());
                                if (kPRemediesVO == null)
                                {
                                    kPRemediesVO = (
                                        from Map in KPBLL.Remedy_List_IA
                                        where (Map.Planet != num1 ? false : Map.House == house)
                                        select Map).FirstOrDefault<KPRemediesVO>();
                                }
                                if (kPRemediesVO != null)
                                {
                                    KPUpayList kPUpayList = new KPUpayList();
                                    if (this.upay_list.Exists((KPUpayList Map) => Map.Sno == (long)kPRemediesVO.Sno))
                                    {
                                        long fakeCode = (
                                            from Map in this.upay_list
                                            where Map.Sno.ToString() == kPRemediesVO.Sno.ToString()
                                            select Map).SingleOrDefault<KPUpayList>().FakeCode;
                                        string str4 = fakeCode.ToString();
                                        if (!prod.FreeUpay)
                                        {
                                            if (!persKV.ShowRef)
                                            {
                                                str = str1;
                                                codeLang = new string[] { str, "  <I>", predictionBLL.GetCodeLang("upay", persKV.Language, true, true), "</I> ", str4.ToString(), this.Gen_Link((long)kPRemediesVO.Sno, prod.Gen_Link, Convert.ToInt64(str4), mahadasha, (long)kPMixDashaVO.Sno, "R"), "\r\n\r\n" };
                                                str1 = string.Concat(codeLang);
                                            }
                                            else
                                            {
                                                str = str1;
                                                codeLang = new string[] { str, "  [ A_kp_remedy : ", kPRemediesVO.Ptype, "  ", null, null, null, null, null, null };
                                                sno = kPRemediesVO.Sno;
                                                codeLang[4] = sno.ToString();
                                                codeLang[5] = " ] ";
                                                codeLang[6] = predictionBLL.GetCodeLang("upay", persKV.Language, true, true);
                                                codeLang[7] = " ";
                                                codeLang[8] = str4.ToString();
                                                codeLang[9] = "\r\n\r\n";
                                                str1 = string.Concat(codeLang);
                                            }
                                        }
                                        else if ((!(str2 != "fullyog") || !(str2 != "fullyuti") ? false : str2 != "fulltriangle"))
                                        {
                                            if (!persKV.ShowRef)
                                            {
                                                str = str1;
                                                codeLang = new string[] { str, "  <I>", predictionBLL.GetCodeLang("upay", persKV.Language, true, true), "</I> ", str4.ToString(), this.Gen_Link((long)kPRemediesVO.Sno, prod.Gen_Link, Convert.ToInt64(str4), mahadasha, (long)kPMixDashaVO.Sno, "R"), "\r\n\r\n" };
                                                str1 = string.Concat(codeLang);
                                            }
                                            else
                                            {
                                                str = str1;
                                                codeLang = new string[] { str, "  [ A_kp_remedy : ", kPRemediesVO.Ptype, "  ", null, null, null, null, null, null };
                                                sno = kPRemediesVO.Sno;
                                                codeLang[4] = sno.ToString();
                                                codeLang[5] = " ] ";
                                                codeLang[6] = predictionBLL.GetCodeLang("upay", persKV.Language, true, true);
                                                codeLang[7] = " ";
                                                codeLang[8] = str4.ToString();
                                                codeLang[9] = "\r\n\r\n";
                                                str1 = string.Concat(codeLang);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        long num2 = (long)(this.upay_list.Count<KPUpayList>() + 1);
                                        sno = kPRemediesVO.Sno;
                                        kPUpayList.Sno = (long)Convert.ToInt16(sno.ToString());
                                        sno = kPRemediesVO.Sno;
                                        kPUpayList.Code = (long)Convert.ToInt16(sno.ToString());
                                        kPUpayList.FakeCode = num2;
                                        kPUpayList.Upay = this.Get_KP_Lang(Convert.ToInt16(kPUpayList.Sno), persKV.Language, false, true, prod.Mini);
                                        if (!prod.FreeUpay)
                                        {
                                            this.upay_list.Add(kPUpayList);
                                            if (!persKV.ShowRef)
                                            {
                                                str = str1;
                                                codeLang = new string[] { str, "  <I>", predictionBLL.GetCodeLang("upay", persKV.Language, true, true), "</I> ", num2.ToString(), this.Gen_Link((long)kPRemediesVO.Sno, prod.Gen_Link, num2, mahadasha, (long)kPMixDashaVO.Sno, "R"), "\r\n\r\n" };
                                                str1 = string.Concat(codeLang);
                                            }
                                            else
                                            {
                                                str = str1;
                                                codeLang = new string[] { str, "  [ A_kp_remedy : ", kPRemediesVO.Ptype, "  ", null, null, null, null, null, null };
                                                sno = kPRemediesVO.Sno;
                                                codeLang[4] = sno.ToString();
                                                codeLang[5] = " ] ";
                                                codeLang[6] = predictionBLL.GetCodeLang("upay", persKV.Language, true, true);
                                                codeLang[7] = " ";
                                                codeLang[8] = num2.ToString();
                                                codeLang[9] = "\r\n\r\n";
                                                str1 = string.Concat(codeLang);
                                            }
                                        }
                                        else if ((!(str2 != "fullyog") || !(str2 != "fullyuti") ? false : str2 != "fulltriangle"))
                                        {
                                            this.upay_list.Add(kPUpayList);
                                            if (!persKV.ShowRef)
                                            {
                                                str = str1;
                                                codeLang = new string[] { str, "  <I>", predictionBLL.GetCodeLang("upay", persKV.Language, true, true), "</I> ", num2.ToString(), this.Gen_Link((long)kPRemediesVO.Sno, prod.Gen_Link, num2, mahadasha, (long)kPMixDashaVO.Sno, "R"), "\r\n\r\n" };
                                                str1 = string.Concat(codeLang);
                                            }
                                            else
                                            {
                                                str = str1;
                                                codeLang = new string[] { str, "  [ A_kp_remedy : ", kPRemediesVO.Ptype, "  ", null, null, null, null, null, null };
                                                sno = kPRemediesVO.Sno;
                                                codeLang[4] = sno.ToString();
                                                codeLang[5] = " ] ";
                                                codeLang[6] = predictionBLL.GetCodeLang("upay", persKV.Language, true, true);
                                                codeLang[7] = " ";
                                                codeLang[8] = num2.ToString();
                                                codeLang[9] = "\r\n\r\n";
                                                str1 = string.Concat(codeLang);
                                            }
                                        }
                                    }
                                }
                            }
                            if ((!kPMixDashaVO.Isbad || kPRemediesVO == null || !prod.ShowUpayCode ? str1.Length >= 50 : false))
                            {
                                str1 = string.Concat(str1, "\r\n\r\n");
                            }
                        }
                    }
                }
            }
            if (str1.Length <= 50)
            {
                str1 = "";
            }
            return str1;
        }

        public string Get_Mix_Mahadasha(List<KPHouseMappingVO> cusp_house, List<KPPlanetMappingVO> kp_chart, KundliVO persKV, bool include, bool showupay, bool upay, ProductSettingsVO prod, bool current_mahadasha)
        {
            string str = "";
            string str1 = "";
            PredictionBLL predictionBLL = new PredictionBLL();
            List<KPDashaVO> kPDashaVOs = new List<KPDashaVO>();
            List<KPDashafalChainVO> kPDashafalChainVOs = new List<KPDashafalChainVO>();
            KPDAO kPDAO = new KPDAO();
            kPDashaVOs = this.Get_Dasha(cusp_house, kp_chart, persKV, include);
            kPDashaVOs = (
                from Map in kPDashaVOs
                where Map.EndDate >= persKV.Dob
                select Map).ToList<KPDashaVO>();
            DateTime date = DateTime.Now.Date;
            short house = 0;
            string signiStringWithoutNakRashi = "";
            foreach (KPDashaVO kPDashaVO in kPDashaVOs)
            {
                DateTime startDate = kPDashaVO.StartDate;
                DateTime endDate = kPDashaVO.EndDate;
                short num = Convert.ToInt16(predictionBLL.CalculateAgeCorrect(persKV.Dob, startDate));
                Convert.ToInt16(predictionBLL.CalculateAgeCorrect(persKV.Dob, endDate));
                short house1 = (
                    from Map in kp_chart
                    where Map.Planet == kPDashaVO.Planet
                    select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                this.Get_Signi_String_Without_NakRashi(kPDashaVO.Planet, kp_chart, include);
                if (num <= 0)
                {
                    num = 1;
                }
                string[] codeLang = new string[] { startDate.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", startDate.ToString("%M")), persKV.Language, persKV.Paid, true), " ", startDate.ToString("yyyy") };
                string str2 = string.Concat(codeLang);
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
                    str2 = string.Concat(codeLang);
                }
                codeLang = new string[] { endDate.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", endDate.ToString("%M")), persKV.Language, persKV.Paid, true), " ", endDate.ToString("yyyy") };
                string str3 = string.Concat(codeLang);
                codeLang = new string[] { "\r\n\r\n <B>", predictionBLL.GetCodeLang("mahadasha", persKV.Language, persKV.Paid, true), " ", str2, predictionBLL.GetCodeLang("to", persKV.Language, persKV.Paid, true), str3, "</B>\r\n" };
                string str4 = string.Concat(codeLang);
                house = (
                    from Map in kp_chart
                    where Map.Planet == kPDashaVO.Planet
                    select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                signiStringWithoutNakRashi = this.Get_Signi_String_Without_NakRashi(kPDashaVO.Planet, kp_chart, false);
                this.prev_mix_all_fal = new List<short>();
                str1 = string.Concat(str1, this.Get_Mix_Fal(kPDashaVO.Planet, kp_chart, cusp_house, persKV, prod, num, true, false, "dasha", startDate, endDate));
                if (!prod.Tool)
                {
                    str1 = string.Concat(str1, this.Get_Mix_Fal_PlanetWise(kPDashaVO.Planet, kp_chart, cusp_house, persKV, prod, num, true, false, startDate, endDate));
                }
                if (num <= 72)
                {
                    if (str1.Trim().Length > 50)
                    {
                        str = string.Concat(str, str4, str1);
                    }
                    str1 = "";
                }
                else
                {
                    break;
                }
            }
            return str;
        }

        public string Get_New_Products(ProductSettingsVO prod)
        {
            KPPredBLL kPPredBLL;
            List<short> nums;
            string[] strArrays;
            string[] strArrays1;
            string str;
            //KPPlanetMappingVO kPPlanetMappingVO = null;
            KPPlanetsVO kPPlanetsVO;
            bool flag;
            string str1;
            Exception exception;
            string str2;
            List<KundliMappingVO> kundliMappingVOs;
            string str3;
            string str4;
            string str5;
            //KundliMappingVO kundliMappingVO = null;
            string str6;
            //KPUpayList upayList = null;
            string str7;
            short k;
            string str8;
            string redSigni;
            char[] chrArray;
            long fakeCode;
            string str9;
            string[] codeLang;
            DateTime now;
            string[] strArrays2;
            int j;
            int house;
            object obj;
            object[] code;
            string budhShukra = "";
            PredictionBLL predictionBLL = new PredictionBLL();
            string dashaWiseTalakShadiYog = "";
            string str10 = "";
            KundliBLL kundliBLL = new KundliBLL();
            if (prod.Rotate <= 1)
            {
                str10 = kundliBLL.Gen_Kunda(prod.Online_Result, 500f, prod.Rotate);
            }
            else
            {
                KundliBLL kundliBLL1 = new KundliBLL();
                string str11 = "";
                str10 = kundliBLL.Gen_Kunda(prod.Online_Result, 500f);
                chrArray = new char[] { '-' };
                string str12 = str10.Split(chrArray)[0];
                chrArray = new char[] { '#' };
                string[] strArrays3 = str12.Split(chrArray);
                short num = Convert.ToInt16(Convert.ToInt16(strArrays3[0]) + Convert.ToInt16(prod.Rotate) - 1);
                if (num > 12)
                {
                    num = Convert.ToInt16(num - 12);
                }
                short num1 = Convert.ToInt16(prod.Rotate);
                str11 = kundliBLL.Gen_Kunda(prod.Online_Result, (float)num, Convert.ToInt16(num1));
                str10 = str11;
            }
            KundliVO kundliVO = new KundliVO();
            PredictionBLL predictionBLL1 = new PredictionBLL();
            PredictionBLL predictionBLL2 = new PredictionBLL();
            string str13 = "";
            string product = prod.Product;
            this.upay_list = new List<KPUpayList>();
            this.date_list = new List<string>();
            string onlineResult = prod.Online_Result;
            chrArray = new char[] { ',' };
            string[] strArrays4 = onlineResult.Split(chrArray);
            short currentAge = 0;
            List<KundliMappingVO> kundliMappingVOs1 = new List<KundliMappingVO>();
            string str14 = strArrays4[2];
            string str15 = strArrays4[3];
            chrArray = new char[] { 'E' };
            str14 = str14.TrimEnd(chrArray);
            chrArray = new char[] { 'N' };
            str14 = str14.TrimEnd(chrArray);
            chrArray = new char[] { 'S' };
            str14 = str14.TrimEnd(chrArray);
            chrArray = new char[] { 'W' };
            str14 = str14.TrimEnd(chrArray);
            chrArray = new char[] { 'E' };
            str15 = str15.TrimEnd(chrArray);
            chrArray = new char[] { 'N' };
            str15 = str15.TrimEnd(chrArray);
            chrArray = new char[] { 'S' };
            str15 = str15.TrimEnd(chrArray);
            chrArray = new char[] { 'W' };
            str15 = str15.TrimEnd(chrArray);
            string str16 = strArrays4[0];
            chrArray = new char[] { '/' };
            string str17 = str16.Split(chrArray)[0];
            string str18 = strArrays4[0];
            chrArray = new char[] { '/' };
            string str19 = str18.Split(chrArray)[1];
            string str20 = strArrays4[0];
            chrArray = new char[] { '/' };
            string str21 = str20.Split(chrArray)[2];
            string str22 = strArrays4[1];
            chrArray = new char[] { ':' };
            string str23 = str22.Split(chrArray)[0];
            string str24 = strArrays4[1];
            chrArray = new char[] { ':' };
            kundliVO = predictionBLL1.map_persKV(str10, "", "", str17, str19, str21, str23, str24.Split(chrArray)[1], "00", "admin", str14, str15, strArrays4[4], prod.Paid, prod.Lang, prod.ShowRef, prod.Male, "YICC", "YICC", "YICC", "YICC", "YICC", prod.Product, "01", "01", "2000", prod.Rotate);
            kundliVO.FileCode = prod.Sno.ToString();
            kundliMappingVOs1 = predictionBLL2.map_kundali(str10, true);
            List<KPPlanetMappingVO> kPPlanetMappingVOs = new List<KPPlanetMappingVO>();
            List<KPPlanetMappingVO> kPPlanetMappingVOs1 = new List<KPPlanetMappingVO>();
            List<KPHouseMappingVO> kPHouseMappingVOs = new List<KPHouseMappingVO>();
            List<KPHouseMappingVO> kPHouseMappingVOs1 = new List<KPHouseMappingVO>();
            this.Process_Planet_Lagan(str10, ref kPPlanetMappingVOs, ref kPHouseMappingVOs, kundliVO.Rotate, false);
            kPPlanetMappingVOs = this.Process_KPChart_GoodBad(kPPlanetMappingVOs, kundliVO, prod);
            this.Process_Planet_Lagan(str10, ref kPPlanetMappingVOs1, ref kPHouseMappingVOs1, kundliVO.Rotate, true);
            kPPlanetMappingVOs1 = this.Process_KPChart_GoodBad(kPPlanetMappingVOs1, kundliVO, prod);
            if (prod.Product.ToLower() == "sankdinewlogic")
            {
                string str25 = "";
                str25 = string.Concat(this.Get_Sankdi_Mahadasha_New_Logic(kundliVO, str10, prod), "\r\n");
                str25 = string.Concat(str25, this.Get_Sankdi_Antardasha_New_Logic(kundliVO, str10, prod), "\r\n");
                str25 = string.Concat(str25, this.Get_Sankdi_Pryantardasha_New_Logic(kundliVO, str10, prod), "\r\n");
                redSigni = str25;
            }
            else if (prod.Product.ToLower() == "redsigni")
            {
                kPPredBLL = new KPPredBLL();
                redSigni = kPPredBLL.Get_Red_Signi(kPPlanetMappingVOs1, kPHouseMappingVOs1, prod, kundliVO);
            }
            else if (prod.Product == "ratnaonly")
            {
                nums = new List<short>();
                str = "";
                foreach (KPPlanetMappingVO kPPlanetMappingVO1 in kPPlanetMappingVOs)
                {
                    if (!kPPlanetMappingVO1.isbad)
                    {
                        string signiString = this.Get_Signi_String(kPPlanetMappingVO1.Planet, kPPlanetMappingVOs, false);
                        chrArray = new char[] { ' ' };
                        strArrays = signiString.Split(chrArray);
                        if ((strArrays.Contains<string>("6") || strArrays.Contains<string>("8") ? false : !strArrays.Contains<string>("12")))
                        {
                            nums.Add(kPPlanetMappingVO1.Planet);
                        }
                        else
                        {
                            str = "";
                        }
                    }
                }
                foreach (short num2 in nums)
                {
                    kPPlanetsVO = (
                        from Map in KPBLL.planet_list
                        where Map.Planet == num2
                        select Map).SingleOrDefault<KPPlanetsVO>();
                    if ((num2 == 8 ? true : num2 == 9))
                    {
                        string signiStringWithoutNakRashi = this.Get_Signi_String_Without_NakRashi(num2, kPPlanetMappingVOs, false);
                        chrArray = new char[] { ' ' };
                        strArrays1 = signiStringWithoutNakRashi.Split(chrArray);
                    }
                    else
                    {
                        string signiStringOnlyRashi = this.Get_Signi_String_Only_Rashi(num2, kPPlanetMappingVOs, false);
                        chrArray = new char[] { ' ' };
                        strArrays1 = signiStringOnlyRashi.Split(chrArray);
                    }
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, kPPlanetsVO.RatnaCode, ",");
                }
                redSigni = dashaWiseTalakShadiYog;
            }
            else if (prod.Product == "work_pred")
            {
                redSigni = this.Tenth_Kamkaj_Pred(kPHouseMappingVOs, kPPlanetMappingVOs, kundliVO);
            }
            else if (prod.Product == "ratna")
            {
                nums = new List<short>();
                str = "";
                foreach (KPPlanetMappingVO kPPlanetMappingVO2 in kPPlanetMappingVOs)
                {
                    if (!kPPlanetMappingVO2.isbad)
                    {
                        string signiString1 = this.Get_Signi_String(kPPlanetMappingVO2.Planet, kPPlanetMappingVOs, false);
                        chrArray = new char[] { ' ' };
                        strArrays = signiString1.Split(chrArray);
                        if ((strArrays.Contains<string>("6") || strArrays.Contains<string>("8") ? false : !strArrays.Contains<string>("12")))
                        {
                            nums.Add(kPPlanetMappingVO2.Planet);
                        }
                        else
                        {
                            str = "";
                        }
                    }
                }
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<table style='border-collapse: collapse;' width=60% align=center border=1 cellspacing=3  cellpadding=3>");
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<tr><td colspan=2><h3 class='text-center'>", predictionBLL.GetCodeLang("shubhratan", kundliVO.Language, true, true), "</h3></td> </tr>");
                foreach (short num3 in nums)
                {
                    kPPlanetsVO = (
                        from Map in KPBLL.planet_list
                        where Map.Planet == num3
                        select Map).SingleOrDefault<KPPlanetsVO>();
                    if ((num3 == 8 ? true : num3 == 9))
                    {
                        string signiStringWithoutNakRashi1 = this.Get_Signi_String_Without_NakRashi(num3, kPPlanetMappingVOs, false);
                        chrArray = new char[] { ' ' };
                        strArrays1 = signiStringWithoutNakRashi1.Split(chrArray);
                    }
                    else
                    {
                        string signiStringOnlyRashi1 = this.Get_Signi_String_Only_Rashi(num3, kPPlanetMappingVOs, false);
                        chrArray = new char[] { ' ' };
                        strArrays1 = signiStringOnlyRashi1.Split(chrArray);
                    }
                    str9 = dashaWiseTalakShadiYog;
                    codeLang = new string[] { str9, "<tr><td> ", predictionBLL.GetCodeLang("ratan", kundliVO.Language, true, true), "   </td> <td>", kPPlanetsVO.Ratna, "</td></tr>" };
                    dashaWiseTalakShadiYog = string.Concat(codeLang);
                    str9 = dashaWiseTalakShadiYog;
                    codeLang = new string[] { str9, "<tr><td> ", predictionBLL.GetCodeLang("upratan", kundliVO.Language, true, true), "  </td> <td>", kPPlanetsVO.Upratna, "</td></tr>" };
                    dashaWiseTalakShadiYog = string.Concat(codeLang);
                    foreach (string str26 in strArrays1.Distinct<string>())
                    {
                        str9 = dashaWiseTalakShadiYog;
                        codeLang = new string[] { str9, "<tr><td> ", predictionBLL.GetCodeLang("fal", kundliVO.Language, true, true), "   </td> <td>", this.Get_Dasha_Pred(num3, str26, DateTime.Now, DateTime.Now, kundliVO, "fulllife", prod, kPPlanetMappingVOs), "</td></tr>" };
                        dashaWiseTalakShadiYog = string.Concat(codeLang);
                        dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<tr><td colspan=2>---------------------------------------</td> </tr>");
                    }
                }
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "</table>");
                redSigni = dashaWiseTalakShadiYog;
            }
            else if (prod.Product.StartsWith("kpcusp"))
            {
                List<KP_Sublord_Pred> kPSublordPreds = new List<KP_Sublord_Pred>();
                List<KP_Sublord_Pred> kPSublordPreds1 = new List<KP_Sublord_Pred>();
                KPDAO kPDAO = new KPDAO();
                if (!(prod.Product == "kpcusp"))
                {
                    string product1 = prod.Product;
                    chrArray = new char[] { '-' };
                    string[] strArrays5 = product1.Split(chrArray);
                    if (strArrays5[1] == "married")
                    {
                        kPSublordPreds = (
                            from Map in kPDAO.Get_KP_Cusp_Pred(kundliVO.ShowRef, 0)
                            where (Map.married ? true : Map.love_affair)
                            select Map).ToList<KP_Sublord_Pred>();
                    }
                    if (strArrays5[1] == "parents")
                    {
                        kPSublordPreds = (
                            from Map in kPDAO.Get_KP_Cusp_Pred(kundliVO.ShowRef, 0)
                            where Map.mother_father
                            select Map).ToList<KP_Sublord_Pred>();
                    }
                    if (strArrays5[1] == "brother")
                    {
                        kPSublordPreds = (
                            from Map in kPDAO.Get_KP_Cusp_Pred(kundliVO.ShowRef, 0)
                            where Map.brother
                            select Map).ToList<KP_Sublord_Pred>();
                    }
                    if (strArrays5[1] == "occupation")
                    {
                        kPSublordPreds = (
                            from Map in kPDAO.Get_KP_Cusp_Pred(kundliVO.ShowRef, 0)
                            where (Map.occupation ? true : Map.wealth)
                            select Map).ToList<KP_Sublord_Pred>();
                    }
                    if (strArrays5[1] == "health")
                    {
                        kPSublordPreds = (
                            from Map in kPDAO.Get_KP_Cusp_Pred(kundliVO.ShowRef, 0)
                            where Map.disease
                            select Map).ToList<KP_Sublord_Pred>();
                    }
                    if (strArrays5[1] == "general")
                    {
                        kPSublordPreds = (
                            from Map in kPDAO.Get_KP_Cusp_Pred(kundliVO.ShowRef, 0)
                            where Map.general
                            select Map).ToList<KP_Sublord_Pred>();
                    }
                }
                else
                {
                    kPSublordPreds = kPDAO.Get_KP_Cusp_Pred(kundliVO.ShowRef, 0);
                }
                List<KPSigniVO> kPSigniVOs = new List<KPSigniVO>();
                List<short> nums1 = new List<short>();
                short planet = (
                    from Map in KPBLL.planet_list
                    where Map.English == kundliVO.Pryantar_Visho
                    select Map).SingleOrDefault<KPPlanetsVO>().Planet;
                short planet1 = (
                    from Map in KPBLL.planet_list
                    where Map.English == kundliVO.Antar_Visho
                    select Map).SingleOrDefault<KPPlanetsVO>().Planet;
                short planet2 = (
                    from Map in KPBLL.planet_list
                    where Map.English == kundliVO.Dasha_Visho
                    select Map).SingleOrDefault<KPPlanetsVO>().Planet;
                short nakLord = (
                    from Map in kPPlanetMappingVOs
                    where Map.Planet == planet
                    select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
                short nakLord1 = (
                    from Map in kPPlanetMappingVOs
                    where Map.Planet == planet1
                    select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
                short nakLord2 = (
                    from Map in kPPlanetMappingVOs
                    where Map.Planet == planet2
                    select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
                string str27 = string.Concat(this.Get_Signi_String(nakLord1, kPPlanetMappingVOs, prod.Include), " ", this.Get_Signi_String(nakLord, kPPlanetMappingVOs, prod.Include));
                short house1 = (
                    from Map in kPPlanetMappingVOs
                    where Map.Planet == nakLord
                    select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                ProductSettingsVO productSettingsVO = new ProductSettingsVO()
                {
                    Online_Result = str10,
                    Include = prod.Include,
                    Lang = prod.Lang,
                    Male = prod.Male,
                    PredFor = 0,
                    ShowRef = prod.ShowRef,
                    ShowUpay = false,
                    ShowUpayCode = false,
                    Sno = (long)555,
                    Category = "",
                    Product = "all",
                    Karyesh = true,
                    Rotate = prod.Rotate
                };
                currentAge = kundliVO.Current_Age;
                if (prod.Product == "kpcusp")
                {
                    DateTime date = DateTime.Now.Date;
                    now = DateTime.Now;
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, this.Get_Planet_Chain_Pred(str27, date, now.Date, kundliVO, "multi", nakLord, productSettingsVO, currentAge), "\r\n\r\n");
                }
                short num4 = 100;
                for (short i = 0; i < 12; i = (short)(i + 1))
                {
                    kPSublordPreds1 = new List<KP_Sublord_Pred>();
                    short subLord = (
                        from Map in kPHouseMappingVOs
                        where Map.House == i + 1
                        select Map).SingleOrDefault<KPHouseMappingVO>().Sub_Lord;
                    short nakLord3 = (
                        from Map in kPPlanetMappingVOs
                        where Map.Planet == subLord
                        select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
                    kPSigniVOs = (
                        from Map in kPPlanetMappingVOs
                        where Map.Planet == nakLord3
                        select Map).SingleOrDefault<KPPlanetMappingVO>().Signi;
                    string str28 = "";
                    str28 = string.Concat("<B>", predictionBLL.GetCodeLang("month", kundliVO.Language, true, true), " घर के कार्येश का फल : </B>\r\n");
                    foreach (KPSigniVO kPSigniVO in kPSigniVOs)
                    {
                        if ((kPSigniVO.Rule == 1 || kPSigniVO.Rule == 2 || kPSigniVO.Rule == 8 ? true : kPSigniVO.Rule == 9))
                        {
                            kPSublordPreds1.AddRange((
                                from Map in kPSublordPreds
                                where (Map.House != i + 1 ? false : Map.Sublord == kPSigniVO.Signi)
                                select Map).ToList<KP_Sublord_Pred>());
                            foreach (KP_Sublord_Pred kPSublordPred in kPSublordPreds1)
                            {
                                if (!nums1.Exists((short Map) => (long)Map == kPSublordPred.Sno))
                                {
                                    if ((kPSublordPred.Pred_Hindi.Length <= 10 ? false : num4 != i))
                                    {
                                        dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, str28, "\r\n\r\n");
                                    }
                                    str9 = dashaWiseTalakShadiYog;
                                    codeLang = new string[] { str9, "[ ", KPBLL.planet_list[kPSigniVO.WhichPlanet - 1].Hindi, " ] ", kPSublordPred.Pred_Hindi, "\r\n\r\n" };
                                    dashaWiseTalakShadiYog = string.Concat(codeLang);
                                    num4 = i;
                                }
                                nums1.Add(Convert.ToInt16(kPSublordPred.Sno));
                            }
                            kPSublordPreds1 = new List<KP_Sublord_Pred>();
                        }
                    }
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "\r\n");
                }
                redSigni = dashaWiseTalakShadiYog;
            }
            else if (!(prod.Product_Name != "toolonlyyogyuti" ? true : !kundliVO.Paid))
            {
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<table style='border-collapse: collapse;' width=60% align=center border=2 cellspacing=6  cellpadding=6>");
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<tr><td colspan=2><h3 class='text-center'>", predictionBLL.GetCodeLang("aboutkundli", kundliVO.Language, true, true), "  </h3></td> </tr>");
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<tr><td>");
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, predictionBLL.GetCodeLang("janamrashi", kundliVO.Language, true, true), "   </td> <td>", predictionBLL.GetCodeLang((
                    from Map in KPBLL.rashi_list
                    where Map.English == kundliVO.Janam_rashi
                    select Map).SingleOrDefault<KPRashiVO>().English, kundliVO.Language, true, true));
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "</td></tr>");
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<tr><td>");
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, predictionBLL.GetCodeLang("janamlagna", kundliVO.Language, true, true), "  </td> <td>", predictionBLL.GetCodeLang(KPBLL.rashi_list[Convert.ToInt16(kundliVO.Janam_Lagna) - 1].English, kundliVO.Language, true, true));
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "</td></tr>");
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<tr><td>");
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, predictionBLL.GetCodeLang("BirthDayPlanet", kundliVO.Language, true, true), " </td> <td>", predictionBLL.GetCodeLang((
                    from Map in KPBLL.planet_list
                    where Map.English == kundliVO.JanamDin
                    select Map).SingleOrDefault<KPPlanetsVO>().English, kundliVO.Language, true, true));
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "</td></tr>");
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<tr><td>");
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, predictionBLL.GetCodeLang("BirthTimePlanet", kundliVO.Language, true, true), " </td> <td>", predictionBLL.GetCodeLang((
                    from Map in KPBLL.planet_list
                    where Map.English == kundliVO.JanamSamay
                    select Map).SingleOrDefault<KPPlanetsVO>().English, kundliVO.Language, true, true));
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "</td></tr>");
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<tr><td>");
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, predictionBLL.GetCodeLang("currentmahadasha", kundliVO.Language, true, true), "   </td> <td>", predictionBLL.GetCodeLang((
                    from Map in KPBLL.planet_list
                    where Map.English == kundliVO.Dasha_Visho
                    select Map).SingleOrDefault<KPPlanetsVO>().English, kundliVO.Language, true, true));
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "</td></tr>");
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<tr><td>");
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, predictionBLL.GetCodeLang("currentantardasha", kundliVO.Language, true, true), "   </td> <td>", predictionBLL.GetCodeLang((
                    from Map in KPBLL.planet_list
                    where Map.English == kundliVO.Antar_Visho
                    select Map).SingleOrDefault<KPPlanetsVO>().English, kundliVO.Language, true, true));
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "</td></tr>");
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<tr><td>");
                flag = kundliBLL.Is_Manglik(kPPlanetMappingVOs);
                str1 = "";
                if (flag)
                {
                    str1 = "yesmanglik";
                }
                if (!flag)
                {
                    str1 = "nomanglik";
                }
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, predictionBLL.GetCodeLang("manglik", kundliVO.Language, true, true), "   </td> <td>", predictionBLL.GetCodeLang(str1, kundliVO.Language, true, true));
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "</td></tr>");
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<tr><td>");
                if (kundliVO.Lucky_day1.Trim().Length <= 2)
                {
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, predictionBLL.GetCodeLang("luckyday", kundliVO.Language, true, true), "  </td> <td>", predictionBLL.GetCodeLang(kundliVO.Lucky_day1, kundliVO.Language, true, true));
                }
                else
                {
                    str9 = dashaWiseTalakShadiYog;
                    codeLang = new string[] { str9, predictionBLL.GetCodeLang("luckyday", kundliVO.Language, true, true), "   </td> <td>", predictionBLL.GetCodeLang(kundliVO.Lucky_day1, kundliVO.Language, true, true), " ", predictionBLL.GetCodeLang(kundliVO.Lucky_day2, kundliVO.Language, true, true) };
                    dashaWiseTalakShadiYog = string.Concat(codeLang);
                }
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "</td></tr>");
                try
                {
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<tr><td>");
                    str9 = dashaWiseTalakShadiYog;
                    codeLang = new string[] { str9, predictionBLL.GetCodeLang("luckynumber", kundliVO.Language, true, true), "   </td> <td>", null, null, null };
                    string luckyNumber = kundliVO.Lucky_number;
                    chrArray = new char[] { ' ' };
                    codeLang[3] = luckyNumber.Split(chrArray, StringSplitOptions.RemoveEmptyEntries)[0];
                    codeLang[4] = ",";
                    string luckyNumber1 = kundliVO.Lucky_number;
                    chrArray = new char[] { ' ' };
                    codeLang[5] = luckyNumber1.Split(chrArray, StringSplitOptions.RemoveEmptyEntries)[1];
                    dashaWiseTalakShadiYog = string.Concat(codeLang);
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "</td></tr>");
                }
                catch (Exception exception1)
                {
                    exception = exception1;
                }
                if (kundliVO.Ratna.Trim().Length > 2)
                {
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<tr><td colspan=2><h3 class='text-center'> ", predictionBLL.GetCodeLang("ratan4you", kundliVO.Language, true, true), "</h3> </td> </tr>");
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<tr><td>");
                    str2 = "";
                    string ratnaCode = kundliVO.RatnaCode;
                    chrArray = new char[] { ',' };
                    strArrays2 = ratnaCode.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                    for (j = 0; j < (int)strArrays2.Length; j++)
                    {
                        string str29 = strArrays2[j];
                        str2 = string.Concat(str2, predictionBLL.GetCodeLang((
                            from Map in KPBLL.planet_list
                            where Map.Planet == Convert.ToInt16(str29)
                            select Map).SingleOrDefault<KPPlanetsVO>().RatnaCode, kundliVO.Language, true, true), ", ");
                    }
                    str2 = str2.Trim();
                    chrArray = new char[] { ',' };
                    str2 = str2.TrimEnd(chrArray);
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, predictionBLL.GetCodeLang("ratan", kundliVO.Language, true, true), "   </td> <td> ", str2);
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "</td></tr>");
                }
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "</table>");
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "\r\n\r\n");
                kundliMappingVOs = predictionBLL.map_kundali(kundliVO.Online_Result, true);
                str3 = "";
                str4 = "";
                str5 = "";
                if (!prod.Mobile)
                {
                    foreach (KundliMappingVO kundliMappingVO1 in kundliMappingVOs)
                    {
                        if (!kundliMappingVO1.IsBad)
                        {
                            string planetNameEnglish = kundliMappingVO1.PlanetNameEnglish;
                            string language = kundliVO.Language;
                            house = kundliMappingVO1.House;
                            str3 = string.Concat(str3, predictionBLL.KPgetvargitdaan(planetNameEnglish, language, house.ToString(), kundliMappingVO1.IsBad));
                        }
                        else
                        {
                            string planetNameEnglish1 = kundliMappingVO1.PlanetNameEnglish;
                            string language1 = kundliVO.Language;
                            house = kundliMappingVO1.House;
                            str5 = string.Concat(str5, predictionBLL.KPgetvargitdaan(planetNameEnglish1, language1, house.ToString(), kundliMappingVO1.IsBad));
                            str4 = string.Concat(str4, predictionBLL.KPgetvargitcolor(kundliMappingVO1.PlanetNameEnglish, kundliVO.Language));
                        }
                    }
                }
                if (str3.Trim().Length > 0)
                {
                    str9 = dashaWiseTalakShadiYog;
                    codeLang = new string[] { str9, "\r\n<B><U>", predictionBLL.GetCodeLang("vdaan", kundliVO.Language, kundliVO.Paid, true), "</U></B>\r\n", str3, "\r\n" };
                    dashaWiseTalakShadiYog = string.Concat(codeLang);
                }
                if (str5.Trim().Length > 0)
                {
                    str9 = dashaWiseTalakShadiYog;
                    codeLang = new string[] { str9, "\r\n<B><U>", predictionBLL.GetCodeLang("daan", kundliVO.Language, kundliVO.Paid, true), "</U></B>\r\n", str5, "\r\n" };
                    dashaWiseTalakShadiYog = string.Concat(codeLang);
                }
                if (str4.Trim().Length > 0)
                {
                    str9 = dashaWiseTalakShadiYog;
                    codeLang = new string[] { str9, "\r\n<B><U>", predictionBLL.GetCodeLang("vcolor", kundliVO.Language, kundliVO.Paid, true), "</U></B>\r\n", str4, "\r\n\r\n\r\n" };
                    dashaWiseTalakShadiYog = string.Concat(codeLang);
                }
                prod.Product = "all";
                if ((prod.Lang.ToLower() == "hindi" || prod.Lang.ToLower() == "marathi" ? true : prod.Lang.ToLower() == "english"))
                {
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, this.Get_Budh_Shukra(kPPlanetMappingVOs1, kPHouseMappingVOs1, prod, kundliVO));
                }
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, this.Get_Full_Yog(kPPlanetMappingVOs1, kPHouseMappingVOs1, kundliVO, prod, 1, kundliVO.Dob, kundliVO.Dob), "\r\n\r\n");
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, this.Get_Full_Yuti(kPPlanetMappingVOs1, kPHouseMappingVOs1, kundliVO, prod, 1, kundliVO.Dob, kundliVO.Dob), "\r\n\r\n");
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, this.Get_Full_Triangle(kPPlanetMappingVOs1, kPHouseMappingVOs1, kundliVO, prod, 1, kundliVO.Dob, kundliVO.Dob));
                redSigni = dashaWiseTalakShadiYog;
            }
            else if (prod.Product_Name == "firstpage")
            {
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<table style='border-collapse: collapse;' width=100% align=center border=2 cellspacing=6  cellpadding=6>");
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<tr><td colspan=2><h3 class='text-center'>", predictionBLL.GetCodeLang("aboutkundli", kundliVO.Language, true, true), "  </h3> </td> </tr>");
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<tr><td>");
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, predictionBLL.GetCodeLang("janamrashi", kundliVO.Language, true, true), "   </td> <td>", predictionBLL.GetCodeLang((
                    from Map in KPBLL.rashi_list
                    where Map.English == kundliVO.Janam_rashi
                    select Map).SingleOrDefault<KPRashiVO>().English, kundliVO.Language, true, true));
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "</td></tr>");
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<tr><td>");
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, predictionBLL.GetCodeLang("janamlagna", kundliVO.Language, true, true), "  </td> <td>", predictionBLL.GetCodeLang(KPBLL.rashi_list[Convert.ToInt16(kundliVO.Janam_Lagna) - 1].English, kundliVO.Language, true, true));
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "</td></tr>");
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<tr><td>");
                if (kundliVO.Language.ToLower() == "hindi")
                {
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, predictionBLL.GetCodeLang("nak", kundliVO.Language, true, true), "  </td> <td>", KPBLL.nak_list[Convert.ToInt16(kundliVO.Nak - (long)1)].Hindi);
                }
                if (kundliVO.Language.ToLower() == "english")
                {
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, predictionBLL.GetCodeLang("nak", kundliVO.Language, true, true), "  </td> <td>", KPBLL.nak_list[Convert.ToInt16(kundliVO.Nak - (long)1)].English);
                }
                if (kundliVO.Language.ToLower() == "marathi")
                {
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, predictionBLL.GetCodeLang("nak", kundliVO.Language, true, true), "  </td> <td>", KPBLL.nak_list[Convert.ToInt16(kundliVO.Nak - (long)1)].Marathi);
                }
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "</td></tr>");
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<tr><td>");
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, predictionBLL.GetCodeLang("BirthDayPlanet", kundliVO.Language, true, true), " </td> <td>", predictionBLL.GetCodeLang((
                    from Map in KPBLL.planet_list
                    where Map.English == kundliVO.JanamDin
                    select Map).SingleOrDefault<KPPlanetsVO>().English, kundliVO.Language, true, true));
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "</td></tr>");
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<tr><td>");
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, predictionBLL.GetCodeLang("BirthTimePlanet", kundliVO.Language, true, true), " </td> <td>", predictionBLL.GetCodeLang((
                    from Map in KPBLL.planet_list
                    where Map.English == kundliVO.JanamSamay
                    select Map).SingleOrDefault<KPPlanetsVO>().English, kundliVO.Language, true, true));
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "</td></tr>");
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<tr><td>");
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, predictionBLL.GetCodeLang("currentmahadasha", kundliVO.Language, true, true), "   </td> <td>", predictionBLL.GetCodeLang((
                    from Map in KPBLL.planet_list
                    where Map.English == kundliVO.Dasha_Visho
                    select Map).SingleOrDefault<KPPlanetsVO>().English, kundliVO.Language, true, true));
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "</td></tr>");
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<tr><td>");
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, predictionBLL.GetCodeLang("currentantardasha", kundliVO.Language, true, true), "   </td> <td>", predictionBLL.GetCodeLang((
                    from Map in KPBLL.planet_list
                    where Map.English == kundliVO.Antar_Visho
                    select Map).SingleOrDefault<KPPlanetsVO>().English, kundliVO.Language, true, true));
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "</td></tr>");
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<tr><td>");
                flag = kundliBLL.Is_Manglik(kPPlanetMappingVOs);
                str1 = "";
                if (flag)
                {
                    str1 = "yesmanglik";
                }
                if (!flag)
                {
                    str1 = "nomanglik";
                }
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, predictionBLL.GetCodeLang("manglik", kundliVO.Language, true, true), "   </td> <td>", predictionBLL.GetCodeLang(str1, kundliVO.Language, true, true));
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "</td></tr>");
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<tr><td>");
                bool flag1 = this.Check_Kal_Sarp(kPPlanetMappingVOs);
                string str30 = "";
                if (flag1)
                {
                    str30 = "kalsarpyes";
                }
                if (!flag1)
                {
                    str30 = "kalsarpno";
                }
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, predictionBLL.GetCodeLang("kalsarp", kundliVO.Language, true, true), "   </td> <td>", predictionBLL.GetCodeLang(str30, kundliVO.Language, true, true));
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "</td></tr>");
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<tr><td>");
                bool flag2 = this.Check_Gandmool(kPPlanetMappingVOs);
                string str31 = "";
                if (flag2)
                {
                    str31 = "gandmoolyes";
                }
                if (!flag2)
                {
                    str31 = "gandmoolno";
                }
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, predictionBLL.GetCodeLang("gandmool", kundliVO.Language, true, true), "   </td> <td>", predictionBLL.GetCodeLang(str31, kundliVO.Language, true, true));
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "</td></tr>");
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<tr><td>");
                if (kundliVO.Lucky_day1.Trim().Length <= 2)
                {
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, predictionBLL.GetCodeLang("luckyday", kundliVO.Language, true, true), "  </td> <td>", predictionBLL.GetCodeLang(kundliVO.Lucky_day1, kundliVO.Language, true, true));
                }
                else
                {
                    str9 = dashaWiseTalakShadiYog;
                    codeLang = new string[] { str9, predictionBLL.GetCodeLang("luckyday", kundliVO.Language, true, true), "   </td> <td>", predictionBLL.GetCodeLang(kundliVO.Lucky_day1, kundliVO.Language, true, true), " ", predictionBLL.GetCodeLang(kundliVO.Lucky_day2, kundliVO.Language, true, true) };
                    dashaWiseTalakShadiYog = string.Concat(codeLang);
                }
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "</td></tr>");
                try
                {
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<tr><td>");
                    if (kundliVO.Lucky_number.Trim().Length <= 1)
                    {
                        string codeLang1 = predictionBLL.GetCodeLang("luckynumber", kundliVO.Language, true, true);
                        string luckyNumber2 = kundliVO.Lucky_number;
                        chrArray = new char[] { ' ' };
                        dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, codeLang1, "   </td> <td>", luckyNumber2.Split(chrArray, StringSplitOptions.RemoveEmptyEntries)[0]);
                    }
                    else
                    {
                        str9 = dashaWiseTalakShadiYog;
                        codeLang = new string[] { str9, predictionBLL.GetCodeLang("luckynumber", kundliVO.Language, true, true), "   </td> <td>", null, null, null };
                        string luckyNumber3 = kundliVO.Lucky_number;
                        chrArray = new char[] { ' ' };
                        codeLang[3] = luckyNumber3.Split(chrArray, StringSplitOptions.RemoveEmptyEntries)[0];
                        codeLang[4] = ",";
                        string luckyNumber4 = kundliVO.Lucky_number;
                        chrArray = new char[] { ' ' };
                        codeLang[5] = luckyNumber4.Split(chrArray, StringSplitOptions.RemoveEmptyEntries)[1];
                        dashaWiseTalakShadiYog = string.Concat(codeLang);
                    }
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "</td></tr>");
                }
                catch (Exception exception2)
                {
                    exception = exception2;
                }
                if (kundliVO.Ratna.Trim().Length > 2)
                {
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<tr><td>");
                    str2 = "";
                    string ratnaCode1 = kundliVO.RatnaCode;
                    chrArray = new char[] { ',' };
                    strArrays2 = ratnaCode1.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                    for (j = 0; j < (int)strArrays2.Length; j++)
                    {
                        string str32 = strArrays2[j];
                        str2 = string.Concat(str2, predictionBLL.GetCodeLang((
                            from Map in KPBLL.planet_list
                            where Map.Planet == Convert.ToInt16(str32)
                            select Map).SingleOrDefault<KPPlanetsVO>().RatnaCode, kundliVO.Language, true, true), ", ");
                    }
                    str2 = str2.Trim();
                    chrArray = new char[] { ',' };
                    str2 = str2.TrimEnd(chrArray);
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, predictionBLL.GetCodeLang("ratan", kundliVO.Language, true, true), "   </td> <td> ", str2);
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "</td></tr>");
                }
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<tr><td colspan=2><h3 class='text-center'>", predictionBLL.GetCodeLang("grehpos", kundliVO.Language, true, true), "</h3></td> </tr>");
                str6 = "";
                foreach (KPPlanetMappingVO kPPlanetMappingVO3 in kPPlanetMappingVOs)
                {
                    str6 = (!kPPlanetMappingVO3.isbad ? predictionBLL.GetCodeLang("good", kundliVO.Language, true, true) : predictionBLL.GetCodeLang("bad", kundliVO.Language, true, true));
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<tr><td>");
                    str9 = dashaWiseTalakShadiYog;
                    codeLang = new string[] { str9, predictionBLL.GetCodeLang(KPBLL.planet_list[kPPlanetMappingVO3.Planet - 1].English, kundliVO.Language, true, true), "</td><td>", str6, "\r\n" };
                    dashaWiseTalakShadiYog = string.Concat(codeLang);
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "</td></tr>");
                }
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "</table>");
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "\r\n\r\n");
                kundliMappingVOs = predictionBLL.map_kundali(kundliVO.Online_Result, true);
                str3 = "";
                str4 = "";
                str5 = "";
                if (!prod.Mobile)
                {
                    foreach (KundliMappingVO kundliMappingVO2 in kundliMappingVOs)
                    {
                        if (!kundliMappingVO2.IsBad)
                        {
                            string planetNameEnglish2 = kundliMappingVO2.PlanetNameEnglish;
                            string language2 = kundliVO.Language;
                            house = kundliMappingVO2.House;
                            str3 = string.Concat(str3, predictionBLL.KPgetvargitdaan(planetNameEnglish2, language2, house.ToString(), kundliMappingVO2.IsBad));
                        }
                        else
                        {
                            string planetNameEnglish3 = kundliMappingVO2.PlanetNameEnglish;
                            string language3 = kundliVO.Language;
                            house = kundliMappingVO2.House;
                            str5 = string.Concat(str5, predictionBLL.KPgetvargitdaan(planetNameEnglish3, language3, house.ToString(), kundliMappingVO2.IsBad));
                            str4 = string.Concat(str4, predictionBLL.KPgetvargitcolor(kundliMappingVO2.PlanetNameEnglish, kundliVO.Language));
                        }
                    }
                }
                if (str3.Trim().Length > 0)
                {
                    str9 = dashaWiseTalakShadiYog;
                    codeLang = new string[] { str9, "\r\n<B><U>", predictionBLL.GetCodeLang("vdaan", kundliVO.Language, kundliVO.Paid, true), "</U></B>\r\n", str3, "\r\n" };
                    dashaWiseTalakShadiYog = string.Concat(codeLang);
                }
                if (str5.Trim().Length > 0)
                {
                    str9 = dashaWiseTalakShadiYog;
                    codeLang = new string[] { str9, "\r\n<B><U>", predictionBLL.GetCodeLang("daan", kundliVO.Language, kundliVO.Paid, true), "</U></B>\r\n", str5, "\r\n" };
                    dashaWiseTalakShadiYog = string.Concat(codeLang);
                }
                if (str4.Trim().Length > 0)
                {
                    str9 = dashaWiseTalakShadiYog;
                    codeLang = new string[] { str9, "\r\n<B><U>", predictionBLL.GetCodeLang("vcolor", kundliVO.Language, kundliVO.Paid, true), "</U></B>\r\n", str4, "\r\n\r\n\r\n" };
                    dashaWiseTalakShadiYog = string.Concat(codeLang);
                }
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "\r\n<I>", predictionBLL.GetPlanetLord_Unicode(kundliMappingVOs, kundliVO), "</I>\r\n\r\n");
                redSigni = dashaWiseTalakShadiYog;
            }
            else if (prod.Product_Name == "manglik")
            {
                flag = kundliBLL.Is_Manglik(kPPlanetMappingVOs);
                str1 = "";
                if (flag)
                {
                    str1 = "yesmanglik";
                }
                if (!flag)
                {
                    str1 = "nomanglik";
                }
                redSigni = str1;
            }
            else if (prod.Product_Name == "onlyyogyuti")
            {
                dashaWiseTalakShadiYog = "";
                prod.Product = "all";
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, this.Get_Full_Yog(kPPlanetMappingVOs1, kPHouseMappingVOs1, kundliVO, prod, 1, kundliVO.Dob, kundliVO.Dob), "\r\n\r\n");
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, this.Get_Full_Yuti(kPPlanetMappingVOs1, kPHouseMappingVOs1, kundliVO, prod, 1, kundliVO.Dob, kundliVO.Dob), "\r\n\r\n");
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, this.Get_Full_Triangle(kPPlanetMappingVOs1, kPHouseMappingVOs1, kundliVO, prod, 1, kundliVO.Dob, kundliVO.Dob));
                if (kundliVO.Paid)
                {
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "\r\n\r\n<B>", predictionBLL.GetCodeLang("upaybelow", kundliVO.Language, true, true), "</B>\r\n");
                    foreach (KPUpayList kPUpayList in this.upay_list)
                    {
                        if (kPUpayList.Upay != null)
                        {
                            if (!prod.ShowRef)
                            {
                                str9 = dashaWiseTalakShadiYog;
                                codeLang = new string[] { str9, "<I>", predictionBLL.GetCodeLang("upay", kundliVO.Language, true, true), "</I> ", null, null, null, null };
                                fakeCode = kPUpayList.FakeCode;
                                codeLang[4] = fakeCode.ToString();
                                codeLang[5] = "\r\n";
                                codeLang[6] = kPUpayList.Upay.ToString();
                                codeLang[7] = "\r\n";
                                dashaWiseTalakShadiYog = string.Concat(codeLang);
                            }
                            else
                            {
                                str9 = dashaWiseTalakShadiYog;
                                codeLang = new string[] { str9, "[ A_kp_remedy : ", null, null, null, null, null, null, null, null };
                                fakeCode = kPUpayList.Sno;
                                codeLang[2] = fakeCode.ToString();
                                codeLang[3] = " ]";
                                codeLang[4] = predictionBLL.GetCodeLang("upay", kundliVO.Language, true, true);
                                codeLang[5] = " ";
                                fakeCode = kPUpayList.FakeCode;
                                codeLang[6] = fakeCode.ToString();
                                codeLang[7] = "\r\n";
                                codeLang[8] = kPUpayList.Upay.ToString();
                                codeLang[9] = "\r\n";
                                dashaWiseTalakShadiYog = string.Concat(codeLang);
                            }
                            dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "\r\n");
                        }
                    }
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, predictionBLL.GetCodeLang("upayhelpbottom", kundliVO.Language, true, true), "\r\n");
                }
                redSigni = dashaWiseTalakShadiYog;
            }
            else if (!(prod.Product.ToLower() == "scorety"))
            {
                currentAge = Convert.ToInt16(predictionBLL.CalculateAgeCorrect(kundliVO.Dob, DateTime.Now));
                currentAge = (short)(currentAge - 1);
                currentAge = (short)(currentAge - 1);
                List<KundliMappingVO> kundliMappingVOs2 = predictionBLL.map_kundali(kundliVO.Online_Result, true);
                string str33 = "";
                string str34 = "";
                string str35 = "";
                if (!prod.Mobile)
                {
                    foreach (KundliMappingVO kundliMappingVO in kundliMappingVOs2)
                    {
                        if (!kundliMappingVO.IsBad)
                        {
                            string planetNameEnglish4 = kundliMappingVO.PlanetNameEnglish;
                            string language4 = kundliVO.Language;
                            house = kundliMappingVO.House;
                            str33 = string.Concat(str33, predictionBLL.KPgetvargitdaan(planetNameEnglish4, language4, house.ToString(), kundliMappingVO.IsBad));
                        }
                        else
                        {
                            string planetNameEnglish5 = kundliMappingVO.PlanetNameEnglish;
                            string language5 = kundliVO.Language;
                            house = kundliMappingVO.House;
                            str35 = string.Concat(str35, predictionBLL.KPgetvargitdaan(planetNameEnglish5, language5, house.ToString(), kundliMappingVO.IsBad));
                            str34 = string.Concat(str34, predictionBLL.KPgetvargitcolor(kundliMappingVO.PlanetNameEnglish, kundliVO.Language));
                        }
                    }
                }
                if (kundliVO.Paid)
                {
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<table style='border-collapse: collapse;' width=100% align=center border=2 cellspacing=6  cellpadding=6>");
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<tr><td colspan=2><h3 class='text-center'>", predictionBLL.GetCodeLang("aboutkundli", kundliVO.Language, true, true), "  </h3>  </td> </tr>");
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<tr><td>");
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, predictionBLL.GetCodeLang("janamrashi", kundliVO.Language, true, true), "   </td> <td>", predictionBLL.GetCodeLang((
                        from Map in KPBLL.rashi_list
                        where Map.English == kundliVO.Janam_rashi
                        select Map).SingleOrDefault<KPRashiVO>().English, kundliVO.Language, true, true));
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "</td></tr>");
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<tr><td>");
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, predictionBLL.GetCodeLang("janamlagna", kundliVO.Language, true, true), "  </td> <td>", predictionBLL.GetCodeLang(KPBLL.rashi_list[Convert.ToInt16(kundliVO.Janam_Lagna) - 1].English, kundliVO.Language, true, true));
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "</td></tr>");
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<tr><td>");
                    if (kundliVO.Language.ToLower() == "hindi")
                    {
                        dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, predictionBLL.GetCodeLang("nak", kundliVO.Language, true, true), "  </td> <td>", KPBLL.nak_list[Convert.ToInt16(kundliVO.Nak - (long)1)].Hindi);
                    }
                    if (kundliVO.Language.ToLower() == "english")
                    {
                        dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, predictionBLL.GetCodeLang("nak", kundliVO.Language, true, true), "  </td> <td>", KPBLL.nak_list[Convert.ToInt16(kundliVO.Nak - (long)1)].English);
                    }
                    if (kundliVO.Language.ToLower() == "marathi")
                    {
                        dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, predictionBLL.GetCodeLang("nak", kundliVO.Language, true, true), "  </td> <td>", KPBLL.nak_list[Convert.ToInt16(kundliVO.Nak - (long)1)].Marathi);
                    }
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "</td></tr>");
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<tr><td>");
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, predictionBLL.GetCodeLang("BirthDayPlanet", kundliVO.Language, true, true), " </td> <td>", predictionBLL.GetCodeLang((
                        from Map in KPBLL.planet_list
                        where Map.English == kundliVO.JanamDin
                        select Map).SingleOrDefault<KPPlanetsVO>().English, kundliVO.Language, true, true));
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "</td></tr>");
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<tr><td>");
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, predictionBLL.GetCodeLang("BirthTimePlanet", kundliVO.Language, true, true), " </td> <td>", predictionBLL.GetCodeLang((
                        from Map in KPBLL.planet_list
                        where Map.English == kundliVO.JanamSamay
                        select Map).SingleOrDefault<KPPlanetsVO>().English, kundliVO.Language, true, true));
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "</td></tr>");
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<tr><td>");
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, predictionBLL.GetCodeLang("currentmahadasha", kundliVO.Language, true, true), "   </td> <td>", predictionBLL.GetCodeLang((
                        from Map in KPBLL.planet_list
                        where Map.English == kundliVO.Dasha_Visho
                        select Map).SingleOrDefault<KPPlanetsVO>().English, kundliVO.Language, true, true));
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "</td></tr>");
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<tr><td>");
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, predictionBLL.GetCodeLang("currentantardasha", kundliVO.Language, true, true), "   </td> <td>", predictionBLL.GetCodeLang((
                        from Map in KPBLL.planet_list
                        where Map.English == kundliVO.Antar_Visho
                        select Map).SingleOrDefault<KPPlanetsVO>().English, kundliVO.Language, true, true));
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "</td></tr>");
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<tr><td>");
                    bool flag3 = kundliBLL.Is_Manglik(kPPlanetMappingVOs);
                    string str36 = "";
                    if (flag3)
                    {
                        str36 = "yesmanglik";
                    }
                    if (!flag3)
                    {
                        str36 = "nomanglik";
                    }
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, predictionBLL.GetCodeLang("manglik", kundliVO.Language, true, true), "   </td> <td>", predictionBLL.GetCodeLang(str36, kundliVO.Language, true, true));
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "</td></tr>");
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<tr><td>");
                    bool flag4 = this.Check_Kal_Sarp(kPPlanetMappingVOs);
                    string str37 = "";
                    if (flag4)
                    {
                        str37 = "kalsarpyes";
                    }
                    if (!flag4)
                    {
                        str37 = "kalsarpno";
                    }
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, predictionBLL.GetCodeLang("kalsarp", kundliVO.Language, true, true), "   </td> <td>", predictionBLL.GetCodeLang(str37, kundliVO.Language, true, true));
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "</td></tr>");
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<tr><td>");
                    bool flag5 = this.Check_Gandmool(kPPlanetMappingVOs);
                    string str38 = "";
                    if (flag5)
                    {
                        str38 = "gandmoolyes";
                    }
                    if (!flag5)
                    {
                        str38 = "gandmoolno";
                    }
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, predictionBLL.GetCodeLang("gandmool", kundliVO.Language, true, true), "   </td> <td>", predictionBLL.GetCodeLang(str38, kundliVO.Language, true, true));
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "</td></tr>");
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<tr><td>");
                    if (kundliVO.Lucky_day1.Trim().Length <= 2)
                    {
                        dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, predictionBLL.GetCodeLang("luckyday", kundliVO.Language, true, true), "  </td> <td>", predictionBLL.GetCodeLang(kundliVO.Lucky_day1, kundliVO.Language, true, true));
                        str9 = str13;
                        codeLang = new string[] { str9, "{\"key\": \"", predictionBLL.GetCodeLang("luckyday", kundliVO.Language, true, true), "\",\"value\": \"", predictionBLL.GetCodeLang(kundliVO.Lucky_day1, kundliVO.Language, true, true), "\" }," };
                        str13 = string.Concat(codeLang);
                    }
                    else
                    {
                        str9 = dashaWiseTalakShadiYog;
                        codeLang = new string[] { str9, predictionBLL.GetCodeLang("luckyday", kundliVO.Language, true, true), "   </td> <td>", predictionBLL.GetCodeLang(kundliVO.Lucky_day1, kundliVO.Language, true, true), " ", predictionBLL.GetCodeLang(kundliVO.Lucky_day2, kundliVO.Language, true, true) };
                        dashaWiseTalakShadiYog = string.Concat(codeLang);
                        str9 = str13;
                        codeLang = new string[] { str9, "{\"key\": \"", predictionBLL.GetCodeLang("luckyday", kundliVO.Language, true, true), "\",\"value\": \"", predictionBLL.GetCodeLang(kundliVO.Lucky_day1, kundliVO.Language, true, true), " ", predictionBLL.GetCodeLang(kundliVO.Lucky_day2, kundliVO.Language, true, true), "\" }," };
                        str13 = string.Concat(codeLang);
                    }
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "</td></tr>");
                    try
                    {
                        dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<tr><td>");
                        if (kundliVO.Lucky_number.Trim().Length <= 1)
                        {
                            string codeLang2 = predictionBLL.GetCodeLang("luckynumber", kundliVO.Language, true, true);
                            string luckyNumber5 = kundliVO.Lucky_number;
                            chrArray = new char[] { ' ' };
                            dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, codeLang2, "   </td> <td>", luckyNumber5.Split(chrArray, StringSplitOptions.RemoveEmptyEntries)[0]);
                        }
                        else
                        {
                            str9 = dashaWiseTalakShadiYog;
                            codeLang = new string[] { str9, predictionBLL.GetCodeLang("luckynumber", kundliVO.Language, true, true), "   </td> <td>", null, null, null };
                            string luckyNumber6 = kundliVO.Lucky_number;
                            chrArray = new char[] { ' ' };
                            codeLang[3] = luckyNumber6.Split(chrArray, StringSplitOptions.RemoveEmptyEntries)[0];
                            codeLang[4] = ",";
                            string luckyNumber7 = kundliVO.Lucky_number;
                            chrArray = new char[] { ' ' };
                            codeLang[5] = luckyNumber7.Split(chrArray, StringSplitOptions.RemoveEmptyEntries)[1];
                            dashaWiseTalakShadiYog = string.Concat(codeLang);
                        }
                        dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "</td></tr>");
                    }
                    catch (Exception exception3)
                    {
                        exception = exception3;
                    }
                    if (kundliVO.Ratna.Trim().Length > 2)
                    {
                        dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<tr><td>");
                        str2 = "";
                        string ratnaCode2 = kundliVO.RatnaCode;
                        chrArray = new char[] { ',' };
                        strArrays2 = ratnaCode2.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                        for (j = 0; j < (int)strArrays2.Length; j++)
                        {
                            string str39 = strArrays2[j];
                            str2 = string.Concat(str2, predictionBLL.GetCodeLang((
                                from Map in KPBLL.planet_list
                                where Map.Planet == Convert.ToInt16(str39)
                                select Map).SingleOrDefault<KPPlanetsVO>().RatnaCode, kundliVO.Language, true, true), ", ");
                        }
                        str2 = str2.Trim();
                        chrArray = new char[] { ',' };
                        str2 = str2.TrimEnd(chrArray);
                        dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, predictionBLL.GetCodeLang("ratan", kundliVO.Language, true, true), "   </td> <td> ", str2);
                        dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "</td></tr>");
                    }
                    str13 = string.Concat(str13, "]},");
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "</table>");
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "\r\n\r\n");
                    str6 = "";
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<table style='border-collapse: collapse;' width=50% align=center border=2 cellspacing=6  cellpadding=6>");
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<tr><td colspan=2><h3 class='text-center'>", predictionBLL.GetCodeLang("grehpos", kundliVO.Language, true, true), "</h3></td> </tr>");
                    str13 = string.Concat(str13, "\"grehonkehalat\": {\"heading\": \"", predictionBLL.GetCodeLang("grehpos", kundliVO.Language, true, true), "\",\"data\": [");
                    foreach (KPPlanetMappingVO kPPlanetMappingVO in kPPlanetMappingVOs)
                    {
                        str6 = (!kPPlanetMappingVO.isbad ? predictionBLL.GetCodeLang("good", kundliVO.Language, true, true) : predictionBLL.GetCodeLang("bad", kundliVO.Language, true, true));
                        dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<tr><td>");
                        str9 = dashaWiseTalakShadiYog;
                        codeLang = new string[] { str9, predictionBLL.GetCodeLang(KPBLL.planet_list[kPPlanetMappingVO.Planet - 1].English, kundliVO.Language, true, true), "</td><td>", str6, "\r\n" };
                        dashaWiseTalakShadiYog = string.Concat(codeLang);
                        dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "</td></tr>");
                        str9 = str13;
                        codeLang = new string[] { str9, "{\"planet\": \"", predictionBLL.GetCodeLang(KPBLL.planet_list[kPPlanetMappingVO.Planet - 1].English, kundliVO.Language, true, true), "\",\"status\": \"", str6, "\",\"isBad\": ", null, null };
                        bool flag6 = kPPlanetMappingVO.isbad;
                        codeLang[6] = flag6.ToString().ToLower();
                        codeLang[7] = "},";
                        str13 = string.Concat(codeLang);
                    }
                    chrArray = new char[] { ',' };
                    str13 = str13.TrimEnd(chrArray);
                    str13 = string.Concat(str13, "]},");
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "</table>");
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "\r\n\r\n");
                    if (!prod.Tool)
                    {
                        if (prod.Mobile)
                        {
                            dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "<B>", predictionBLL.GetCodeLang("lifeheadmobile", kundliVO.Language, true, true), "</B>\r\n\r\n");
                        }
                        else if (prod.ShowManyavar)
                        {
                            budhShukra = "";
                            budhShukra = string.Concat("<B>", predictionBLL.GetCodeLang("lifehead", kundliVO.Language, true, true), "</B>\r\n\r\n");
                            dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                            str13 = string.Concat(str13, "\"manyavar\": {\"data\": [{");
                            str13 = string.Concat(str13, "\"value\": \"", budhShukra, "\"");
                            str13 = string.Concat(str13, "}]},");
                        }
                        if (!prod.Mobile)
                        {
                            if ((prod.Mobile || !prod.ShowUpay ? prod.Tool507 : true))
                            {
                                if ((!prod.Tool ? true : prod.Tool507))
                                {
                                    if (str33.Trim().Length > 0)
                                    {
                                        str9 = dashaWiseTalakShadiYog;
                                        codeLang = new string[] { str9, "\r\n<B><U>", predictionBLL.GetCodeLang("vdaan", kundliVO.Language, kundliVO.Paid, true), "</U></B>\r\n", str33, "\r\n" };
                                        dashaWiseTalakShadiYog = string.Concat(codeLang);
                                        str13 = string.Concat(str13, "\"vdaan\": {\"data\": [{");
                                        str9 = str13;
                                        codeLang = new string[] { str9, "\"heading\": \"", predictionBLL.GetCodeLang("vdaan", kundliVO.Language, kundliVO.Paid, true), "\",\"value\": \"", str33, "\"" };
                                        str13 = string.Concat(codeLang);
                                        str13 = string.Concat(str13, "}]},");
                                    }
                                    if (str35.Trim().Length > 0)
                                    {
                                        str9 = dashaWiseTalakShadiYog;
                                        codeLang = new string[] { str9, "\r\n<B><U>", predictionBLL.GetCodeLang("daan", kundliVO.Language, kundliVO.Paid, true), "</U></B>\r\n", str35, "\r\n" };
                                        dashaWiseTalakShadiYog = string.Concat(codeLang);
                                        str13 = string.Concat(str13, "\"daan\": {\"data\": [{");
                                        str9 = str13;
                                        codeLang = new string[] { str9, "\"heading\": \"", predictionBLL.GetCodeLang("daan", kundliVO.Language, kundliVO.Paid, true), "\",\"value\": \"", str35, "\"" };
                                        str13 = string.Concat(codeLang);
                                        str13 = string.Concat(str13, "}]},");
                                    }
                                    if (str34.Trim().Length > 0)
                                    {
                                        str9 = dashaWiseTalakShadiYog;
                                        codeLang = new string[] { str9, "\r\n<B><U>", predictionBLL.GetCodeLang("vcolor", kundliVO.Language, kundliVO.Paid, true), "</U></B>\r\n", str34, "\r\n" };
                                        dashaWiseTalakShadiYog = string.Concat(codeLang);
                                        str13 = string.Concat(str13, "\"vcolor\": {\"data\": [{");
                                        str9 = str13;
                                        codeLang = new string[] { str9, "\"heading\": \"", predictionBLL.GetCodeLang("vcolor", kundliVO.Language, kundliVO.Paid, true), "\",\"value\": \"", str34, "\"" };
                                        str13 = string.Concat(codeLang);
                                        str13 = string.Concat(str13, "}]},");
                                    }
                                }
                            }
                        }
                        this.upay_list = new List<KPUpayList>();
                        if (!prod.Mobile)
                        {
                            if ((prod.Mobile || !prod.ShowUpay ? false : !prod.Matchmaking))
                            {
                                budhShukra = "";
                                budhShukra = string.Concat("\r\n<I>", predictionBLL.GetPlanetLord_Unicode(kundliMappingVOs2, kundliVO), "</I>\r\n\r\n");
                                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                                str13 = string.Concat(str13, "\"ishtdev\": {\"data\": [{");
                                str13 = string.Concat(str13, "\"value\": \"", budhShukra, "\"");
                                str13 = string.Concat(str13, "}]},");
                                if ((prod.Lang.ToLower() == "hindi" || prod.Lang.ToLower() == "marathi" ? true : prod.Lang.ToLower() == "english"))
                                {
                                    budhShukra = "";
                                    budhShukra = this.Get_Budh_Shukra(kPPlanetMappingVOs1, kPHouseMappingVOs1, prod, kundliVO);
                                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                                    str13 = string.Concat(str13, "\"budhshukra\": {\"data\": [{");
                                    str13 = string.Concat(str13, "\"value\": \"", budhShukra, "\"");
                                    str13 = string.Concat(str13, "}]},");
                                }
                                if ((product == "occupation" || product == "YICCCOMBO7" || product == "YICCCOMBO4" || product == "YICCCOMBO1" || product == "YICCCOMBO2" || product == "YICCCOMBO5" || product == "YICCCOMBO10" ? true : product == "YICCCOMBO25"))
                                {
                                    budhShukra = "";
                                }
                                budhShukra = string.Concat(this.Get_School_Kids(str10, kundliVO, false, prod), "\r\n\r\n");
                                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                                str13 = string.Concat(str13, "\"sikshakamkaj\": {\"data\": [{");
                                str13 = string.Concat(str13, "\"value\": \"", budhShukra, "\"");
                                str13 = string.Concat(str13, "}]},");
                                str13 = string.Concat(str13, "\"kaamkaajdasha\": {\"data\": [{");
                                str9 = str13;
                                codeLang = new string[] { str9, "\"heading\": \"", predictionBLL.GetCodeLang("headnaukri", kundliVO.Language, kundliVO.Paid, true).ToString(), "\",\"value\": \"", budhShukra, "\"" };
                                str13 = string.Concat(codeLang);
                                str13 = string.Concat(str13, "}]},");
                            }
                        }
                    }
                }
                currentAge = Convert.ToInt16(predictionBLL.CalculateAgeCorrect(kundliVO.Dob, DateTime.Now));
                str7 = "";
                currentAge = (short)(currentAge - 1);
                string cat = "";
                string cat1 = "";
                string cat2 = "";
                string cat3 = "";
                string cat4 = "";
                string cat5 = "";
                string str40 = "";
                string str41 = "";
                string str42 = "";
                string str43 = "";
                string str44 = "";
                string str45 = "";
                prod.Dasha_Years = 2;
                if ((prod.Product == "YICCCOMBO7" || prod.Product == "YICCCOMBO4" || prod.Product == "YICCCOMBO1" || prod.Product == "YICCCOMBO2" || prod.Product == "YICCCOMBO5" || prod.Product == "YICCCOMBO10" ? false : !(prod.Product == "YICCCOMBO25")))
                {
                    prod.Dasha_Years = 2;
                    string product2 = prod.Product;
                    chrArray = new char[] { ',' };
                    string[] strArrays6 = product2.Split(chrArray);
                    budhShukra = "";
                    budhShukra = "\r\n";
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                    str7 = string.Concat(str7, budhShukra);
                    if (prod.OnlyMahadasha)
                    {
                        dashaWiseTalakShadiYog = "";
                        str7 = "";
                        budhShukra = "";
                        budhShukra = this.Get_Only_Mahadasha(kPHouseMappingVOs, kPPlanetMappingVOs, kundliVO, prod.Include, true, true, prod, true);
                        dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                        str7 = string.Concat(str7, budhShukra);
                        redSigni = dashaWiseTalakShadiYog;
                        return redSigni;
                    }
                    strArrays2 = strArrays6;
                    for (j = 0; j < (int)strArrays2.Length; j++)
                    {
                        string str46 = strArrays2[j];
                        prod.Product = str46;
                        if (str46 == "disease")
                        {
                            budhShukra = "";
                            budhShukra = string.Concat("\r\n\r\n", predictionBLL.GetCodeLang("disease_head", kundliVO.Language, true, true), "\r\n\r\n");
                            dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                            str7 = string.Concat(str7, budhShukra);
                            this.last_antar_date = new DateTime();
                            this.last_pryaantar_date = new DateTime();
                            this.date_list = new List<string>();
                        }
                        if (str46 == "occupation")
                        {
                            dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, this.Get_School_Kids(str10, kundliVO, false, prod), "\r\n\r\n");
                            dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "\r\n\r\n<B>", predictionBLL.GetCodeLang("headnaukri", kundliVO.Language, kundliVO.Paid, true).ToString(), "</B>");
                            dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "\r\n", this.Get_Work_Pred_Mahadasha(kPHouseMappingVOs, kPPlanetMappingVOs, kundliVO, prod.Include, prod.ShowUpay, prod.ShowUpayCode, prod, false));
                            budhShukra = "";
                            budhShukra = string.Concat("\r\n\r\n", predictionBLL.GetCodeLang("occupation_head", kundliVO.Language, true, true), "\r\n\r\n");
                            dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                            str7 = string.Concat(str7, budhShukra);
                            this.last_antar_date = new DateTime();
                            this.last_pryaantar_date = new DateTime();
                            this.date_list = new List<string>();
                        }
                        if (str46 == "married_life")
                        {
                            budhShukra = "";
                            budhShukra = string.Concat("\r\n\r\n", predictionBLL.GetCodeLang("married_life_head", kundliVO.Language, true, true), "\r\n\r\n");
                            dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                            str7 = string.Concat(str7, budhShukra);
                            this.last_antar_date = new DateTime();
                            this.last_pryaantar_date = new DateTime();
                            this.date_list = new List<string>();
                        }
                        if (str46 == "santan")
                        {
                            budhShukra = "";
                            budhShukra = string.Concat("\r\n\r\n", predictionBLL.GetCodeLang("santan_head", kundliVO.Language, true, true), "\r\n\r\n");
                            dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                            str7 = string.Concat(str7, budhShukra);
                            this.last_antar_date = new DateTime();
                            this.last_pryaantar_date = new DateTime();
                            this.date_list = new List<string>();
                        }
                        if (str46 == "parents")
                        {
                            budhShukra = "";
                            budhShukra = string.Concat("\r\n\r\n", predictionBLL.GetCodeLang("parents_head", kundliVO.Language, true, true), "\r\n\r\n");
                            dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                            str7 = string.Concat(str7, budhShukra);
                            this.last_antar_date = new DateTime();
                            this.last_pryaantar_date = new DateTime();
                            this.date_list = new List<string>();
                        }
                        if ((prod.Tool ? false : !prod.Tool507))
                        {
                            if (prod.Paid)
                            {
                                budhShukra = "";
                                budhShukra = this.Get_Only_Mahadasha(kPHouseMappingVOs, kPPlanetMappingVOs, kundliVO, prod.Include, true, true, prod, true);
                                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                                str7 = string.Concat(str7, budhShukra);
                            }
                        }
                        budhShukra = "";
                        budhShukra = string.Concat(this.Get_Cat(prod, kPPlanetMappingVOs1, kPHouseMappingVOs, kundliVO), "\r\n\r\n");
                        dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                        str7 = string.Concat(str7, budhShukra);
                        if ((prod.Tool507 ? false : !prod.AstroArmy))
                        {
                            budhShukra = "";
                            budhShukra = string.Concat(predictionBLL.GetCodeLang("yyyhead", kundliVO.Language, true, true), "\r\n\r\n");
                            dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                            str7 = string.Concat(str7, budhShukra);
                            budhShukra = "";
                            budhShukra = string.Concat(this.Get_Full_Yog(kPPlanetMappingVOs1, kPHouseMappingVOs1, kundliVO, prod, 1, kundliVO.Dob, kundliVO.Dob), "\r\n\r\n");
                            dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                            str7 = string.Concat(str7, budhShukra);
                            budhShukra = "";
                            budhShukra = string.Concat(this.Get_Full_Yuti(kPPlanetMappingVOs1, kPHouseMappingVOs1, kundliVO, prod, 1, kundliVO.Dob, kundliVO.Dob), "\r\n\r\n");
                            dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                            str7 = string.Concat(str7, budhShukra);
                            budhShukra = "";
                            budhShukra = this.Get_Full_Triangle(kPPlanetMappingVOs1, kPHouseMappingVOs1, kundliVO, prod, 1, kundliVO.Dob, kundliVO.Dob);
                            dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                            str7 = string.Concat(str7, budhShukra);
                        }
                    }
                }
                else
                {
                    currentAge = 1;
                    currentAge = Convert.ToInt16(currentAge - 1);
                    string product3 = prod.Product;
                    now = kundliVO.Dob;
                    DateTime dateTime = now.AddYears(kundliVO.Current_Age);
                    now = DateTime.Now;
                    TimeSpan timeSpan = now.Date - dateTime;
                    short num5 = Convert.ToInt16(timeSpan.Days / 30);
                    if (prod.Product == "YICCCOMBO1")
                    {
                        prod.Dasha_Years = 1;
                    }
                    if (prod.Product == "YICCCOMBO2")
                    {
                        prod.Dasha_Years = 2;
                    }
                    if (prod.Product == "YICCCOMBO4")
                    {
                        prod.Dasha_Years = 4;
                    }
                    if (prod.Product == "YICCCOMBO5")
                    {
                        prod.Dasha_Years = 5;
                    }
                    if (prod.Product == "YICCCOMBO7")
                    {
                        prod.Dasha_Years = 7;
                    }
                    if (prod.Product == "YICCCOMBO10")
                    {
                        prod.Dasha_Years = 10;
                    }
                    if (prod.Product == "YICCCOMBO25")
                    {
                        prod.Dasha_Years = 25;
                    }
                    prod.Product = "all";
                    if (prod.Matchmaking)
                    {
                        budhShukra = "";
                        budhShukra = "\r\n\r\n";
                        dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                        str7 = string.Concat(str7, budhShukra);
                    }
                    currentAge = Convert.ToInt16(predictionBLL.CalculateAgeCorrect(kundliVO.Dob, DateTime.Now));
                    currentAge = (short)(currentAge - 1);
                    if (!prod.Matchmaking)
                    {
                        if (!prod.Tool507)
                        {
                            kundliVO.Mfal = true;
                            dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, predictionBLL1.Get_Current_MahadashaFal(kundliVO, str10, prod));
                            dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, predictionBLL1.Get_Current_35_Sala_Fal(kundliVO, str10, prod));
                            kPPredBLL = new KPPredBLL();
                            if (num5 > 7)
                            {
                                prod.Dasha_Years = Convert.ToInt16(prod.Dasha_Years + 1);
                            }
                            KPPredBLL kPPredBLL1 = new KPPredBLL();
                            List<short> nums2 = new List<short>();
                            List<short> nums3 = new List<short>();
                            short dashaYears = prod.Dasha_Years;
                            short num6 = Convert.ToInt16(kundliVO.Current_Age + 1);
                            for (k = 0; k < dashaYears; k = (short)(k + 1))
                            {
                                nums2.Add(Convert.ToInt16((int)(num6 + k)));
                            }
                            for (k = 0; k < 12; k = (short)(k + 1))
                            {
                                nums3.Add(Convert.ToInt16(k + 1));
                            }
                            dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, "\r\n", kPPredBLL.NEW_Get_VarshFal_Predictions(kundliVO, nums2, kPPlanetMappingVOs, nums3, prod));
                            if (num5 > 7)
                            {
                                prod.Dasha_Years = Convert.ToInt16(prod.Dasha_Years - 1);
                            }
                        }
                    }
                    if (prod.OnlyUpay)
                    {
                        budhShukra = "";
                        budhShukra = "";
                        dashaWiseTalakShadiYog = budhShukra;
                        str7 = budhShukra;
                    }
                    if (!prod.NoCategory)
                    {
                        this.last_antar_date = new DateTime();
                        this.last_pryaantar_date = new DateTime();
                        this.date_list = new List<string>();
                        currentAge = Convert.ToInt16(predictionBLL.CalculateAgeCorrect(kundliVO.Dob, DateTime.Now));
                        currentAge = (short)(currentAge - 1);
                        this.mvfal_all_fal = new List<short>();
                        if ((!prod.Mini ? false : !prod.Matchmaking))
                        {
                            goto Label2;
                        }
                        prod.Product = product3;
                        string product4 = prod.Product;
                        if (prod.Product == "YICCCOMBO1")
                        {
                            prod.Dasha_Years = 1;
                        }
                        if (prod.Product == "YICCCOMBO2")
                        {
                            prod.Dasha_Years = 2;
                        }
                        if (prod.Product == "YICCCOMBO4")
                        {
                            prod.Dasha_Years = 4;
                        }
                        if (prod.Product == "YICCCOMBO5")
                        {
                            prod.Dasha_Years = 5;
                        }
                        if (prod.Product == "YICCCOMBO7")
                        {
                            prod.Dasha_Years = 7;
                        }
                        if (prod.Product == "YICCCOMBO10")
                        {
                            prod.Dasha_Years = 10;
                        }
                        if (prod.Product == "YICCCOMBO25")
                        {
                            prod.Dasha_Years = 25;
                        }
                        if (prod.Include_Category)
                        {
                            if (prod.Matchmaking)
                            {
                                if (prod.Male)
                                {
                                    str40 = string.Concat("\r\n\r\n", predictionBLL.GetCodeLang("headbimariboy", kundliVO.Language, true, true));
                                }
                                if (!prod.Male)
                                {
                                    str40 = string.Concat("\r\n\r\n", predictionBLL.GetCodeLang("headbimarigirl", kundliVO.Language, true, true));
                                }
                            }
                            else
                            {
                                str40 = string.Concat("\r\n\r\n", predictionBLL.GetCodeLang("disease_head", kundliVO.Language, true, true));
                            }
                            if (prod.Matchmaking)
                            {
                                if (prod.Male)
                                {
                                    str42 = string.Concat("\r\n\r\n", predictionBLL.GetCodeLang("headnaukriboy", kundliVO.Language, true, true));
                                }
                                if (!prod.Male)
                                {
                                    str42 = string.Concat("\r\n\r\n", predictionBLL.GetCodeLang("headnaukrigirl", kundliVO.Language, true, true));
                                }
                            }
                            else
                            {
                                str42 = string.Concat("\r\n\r\n", predictionBLL.GetCodeLang("occupation_head", kundliVO.Language, true, true));
                            }
                            if (prod.Matchmaking)
                            {
                                if (prod.Male)
                                {
                                    str41 = string.Concat("\r\n\r\n", predictionBLL.GetCodeLang("headshadiboy", kundliVO.Language, true, true));
                                }
                                if (!prod.Male)
                                {
                                    str41 = string.Concat("\r\n\r\n", predictionBLL.GetCodeLang("headshadigirl", kundliVO.Language, true, true));
                                }
                            }
                            else
                            {
                                str41 = string.Concat("\r\n\r\n", predictionBLL.GetCodeLang("married_life_head", kundliVO.Language, true, true));
                            }
                            if (prod.Matchmaking)
                            {
                                if (prod.Male)
                                {
                                    str44 = string.Concat("\r\n\r\n", predictionBLL.GetCodeLang("headsantanboy", kundliVO.Language, true, true));
                                }
                                if (!prod.Male)
                                {
                                    str44 = string.Concat("\r\n\r\n", predictionBLL.GetCodeLang("headsantangirl", kundliVO.Language, true, true));
                                }
                            }
                            else
                            {
                                str44 = string.Concat("\r\n\r\n", predictionBLL.GetCodeLang("santan_head", kundliVO.Language, true, true));
                            }
                            str43 = string.Concat("\r\n\r\n", predictionBLL.GetCodeLang("parents_head", kundliVO.Language, true, true));
                            str45 = string.Concat("\r\n\r\n", predictionBLL.GetCodeLang("nature_head", kundliVO.Language, true, true));
                            this.last_antar_date = new DateTime();
                            this.last_pryaantar_date = new DateTime();
                            this.date_list = new List<string>();
                            prod.Product = "disease";
                            cat = this.Get_Cat(prod, kPPlanetMappingVOs, kPHouseMappingVOs, kundliVO);
                            this.last_antar_date = new DateTime();
                            this.last_pryaantar_date = new DateTime();
                            this.date_list = new List<string>();
                            prod.Product = "occupation";
                            cat2 = this.Get_Cat(prod, kPPlanetMappingVOs1, kPHouseMappingVOs, kundliVO);
                            this.last_antar_date = new DateTime();
                            this.last_pryaantar_date = new DateTime();
                            this.date_list = new List<string>();
                            prod.Product = "married_life";
                            cat1 = this.Get_Cat(prod, kPPlanetMappingVOs1, kPHouseMappingVOs, kundliVO);
                            this.last_antar_date = new DateTime();
                            this.last_pryaantar_date = new DateTime();
                            this.date_list = new List<string>();
                            prod.Product = "santan";
                            cat4 = this.Get_Cat(prod, kPPlanetMappingVOs1, kPHouseMappingVOs, kundliVO);
                            if (!prod.Matchmaking)
                            {
                                this.last_antar_date = new DateTime();
                                this.last_pryaantar_date = new DateTime();
                                this.date_list = new List<string>();
                                prod.Product = "parents";
                                cat3 = this.Get_Cat(prod, kPPlanetMappingVOs1, kPHouseMappingVOs, kundliVO);
                                this.last_antar_date = new DateTime();
                                this.last_pryaantar_date = new DateTime();
                                this.date_list = new List<string>();
                                prod.Product = "nature";
                                cat5 = this.Get_Cat(prod, kPPlanetMappingVOs1, kPHouseMappingVOs, kundliVO);
                            }
                            if (cat.Trim().Length > 50)
                            {
                                budhShukra = "";
                                budhShukra = string.Concat(str40, "\r\n\r\n", cat);
                                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                                str7 = string.Concat(str7, budhShukra);
                            }
                            if (cat2.Trim().Length > 50)
                            {
                                budhShukra = "";
                                budhShukra = string.Concat(str42, "\r\n\r\n", cat2);
                                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                                str7 = string.Concat(str7, budhShukra);
                            }
                            if (cat1.Trim().Length > 50)
                            {
                                budhShukra = "";
                                budhShukra = string.Concat(str41, "\r\n\r\n", cat1);
                                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                                str7 = string.Concat(str7, budhShukra);
                            }
                            if (cat4.Trim().Length > 50)
                            {
                                budhShukra = "";
                                budhShukra = string.Concat(str44, "\r\n\r\n", cat4);
                                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                                str7 = string.Concat(str7, budhShukra);
                            }
                            if (cat3.Trim().Length > 50)
                            {
                                budhShukra = "";
                                budhShukra = string.Concat(str43, "\r\n\r\n", cat3);
                                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                                str7 = string.Concat(str7, budhShukra);
                            }
                            if (cat5.Trim().Length > 50)
                            {
                                budhShukra = "";
                                budhShukra = string.Concat(str45, "\r\n\r\n", cat5);
                                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                                str7 = string.Concat(str7, budhShukra);
                            }
                        }
                        prod.Product = "all";
                        if ((prod.Matchmaking ? false : product4 != "YICCCOMBO1"))
                        {
                            budhShukra = "";
                            budhShukra = string.Concat("\r\n\r\n", this.Get_Only_Mahadasha(kPHouseMappingVOs, kPPlanetMappingVOs, kundliVO, prod.Include, true, true, prod, false), "\r\n\r\n");
                            dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                            str7 = string.Concat(str7, budhShukra);
                        }
                        if (!prod.Matchmaking)
                        {
                            budhShukra = "";
                            budhShukra = string.Concat("\r\n\r\n<B>", predictionBLL.GetCodeLang("yognote", kundliVO.Language, true, true), "</B>\r\n\r\n");
                            dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                            str7 = string.Concat(str7, budhShukra);
                            if ((prod.Lang.ToLower() == "hindi" || prod.Lang.ToLower() == "marathi" ? true : prod.Lang.ToLower() == "english"))
                            {
                                budhShukra = "";
                                budhShukra = this.Get_Budh_Shukra(kPPlanetMappingVOs1, kPHouseMappingVOs1, prod, kundliVO);
                                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                                str7 = string.Concat(str7, budhShukra);
                            }
                            budhShukra = "";
                            budhShukra = string.Concat(this.Get_Full_Yog(kPPlanetMappingVOs1, kPHouseMappingVOs1, kundliVO, prod, 1, kundliVO.Dob, kundliVO.Dob), "\r\n\r\n");
                            dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                            str7 = string.Concat(str7, budhShukra);
                            budhShukra = "";
                            budhShukra = string.Concat(this.Get_Full_Yuti(kPPlanetMappingVOs1, kPHouseMappingVOs1, kundliVO, prod, 1, kundliVO.Dob, kundliVO.Dob), "\r\n\r\n");
                            dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                            str7 = string.Concat(str7, budhShukra);
                            budhShukra = "";
                            budhShukra = this.Get_Full_Triangle(kPPlanetMappingVOs1, kPHouseMappingVOs1, kundliVO, prod, 1, kundliVO.Dob, kundliVO.Dob);
                            dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                            str7 = string.Concat(str7, budhShukra);
                        }
                    }
                    else if (!prod.Tool507)
                    {
                        if (prod.OnlyUpay)
                        {
                            budhShukra = "";
                            budhShukra = string.Concat("\r\n\r\n<B>", predictionBLL.GetCodeLang("upaybelow", kundliVO.Language, true, true), "</B>\r\n");
                            dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                            str7 = string.Concat(str7, budhShukra);
                            foreach (KPUpayList upayList in this.upay_list)
                            {
                                if (upayList.Upay != null)
                                {
                                    if (!prod.ShowRef)
                                    {
                                        budhShukra = "";
                                        codeLang = new string[] { "<I>", predictionBLL.GetCodeLang("upay", kundliVO.Language, true, true), "</I> ", null, null, null, null };
                                        fakeCode = upayList.FakeCode;
                                        codeLang[3] = fakeCode.ToString();
                                        codeLang[4] = "\r\n";
                                        codeLang[5] = upayList.Upay.ToString();
                                        codeLang[6] = "\r\n\r\n";
                                        budhShukra = string.Concat(codeLang);
                                        dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                                        str7 = string.Concat(str7, budhShukra);
                                    }
                                    else
                                    {
                                        budhShukra = "";
                                        codeLang = new string[] { "[ A_kp_remedy : ", null, null, null, null, null, null, null, null };
                                        fakeCode = upayList.Sno;
                                        codeLang[1] = fakeCode.ToString();
                                        codeLang[2] = " ]";
                                        codeLang[3] = predictionBLL.GetCodeLang("upay", kundliVO.Language, true, true);
                                        codeLang[4] = " ";
                                        fakeCode = upayList.FakeCode;
                                        codeLang[5] = fakeCode.ToString();
                                        codeLang[6] = "\r\n";
                                        codeLang[7] = upayList.Upay.ToString();
                                        codeLang[8] = "\r\n\r\n";
                                        budhShukra = string.Concat(codeLang);
                                        dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                                        str7 = string.Concat(str7, budhShukra);
                                    }
                                }
                            }
                            budhShukra = "";
                            budhShukra = string.Concat(predictionBLL.GetCodeLang("upayhelpbottom", kundliVO.Language, true, true), "\r\n");
                            dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                            str7 = string.Concat(str7, budhShukra);
                        }
                        redSigni = dashaWiseTalakShadiYog;
                        return redSigni;
                    }
                    else
                    {
                        budhShukra = "";
                        budhShukra = string.Concat(this.Get_Full_Yog(kPPlanetMappingVOs1, kPHouseMappingVOs1, kundliVO, prod, 1, kundliVO.Dob, kundliVO.Dob), "\r\n\r\n");
                        dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                        str7 = string.Concat(str7, budhShukra);
                        budhShukra = "";
                        budhShukra = string.Concat(this.Get_Full_Yuti(kPPlanetMappingVOs1, kPHouseMappingVOs1, kundliVO, prod, 1, kundliVO.Dob, kundliVO.Dob), "\r\n\r\n");
                        dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                        str7 = string.Concat(str7, budhShukra);
                        budhShukra = "";
                        budhShukra = this.Get_Full_Triangle(kPPlanetMappingVOs1, kPHouseMappingVOs1, kundliVO, prod, 1, kundliVO.Dob, kundliVO.Dob);
                        dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                        str7 = string.Concat(str7, budhShukra);
                        redSigni = dashaWiseTalakShadiYog;
                        return redSigni;
                    }
                }
                if ((prod.Tool ? false : prod.ShowUpay))
                {
                    if ((product == "YICCCOMBO7" || product == "YICCCOMBO4" || product == "YICCCOMBO1" || product == "YICCCOMBO2" || product == "YICCCOMBO5" || product == "YICCCOMBO10" || product == "YICCCOMBO25" || prod.Category.Length <= 0 ? !prod.Mobile : false))
                    {
                        if (!prod.Matchmaking)
                        {
                            budhShukra = "";
                            budhShukra = string.Concat("\r\n\r\n", this.Get_Rinn_Pitri(prod, kundliVO, kPPlanetMappingVOs), "\r\n\r\n");
                            dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                            str7 = string.Concat(str7, budhShukra);
                        }
                    }
                    str8 = "";
                    if ((!prod.ShowUpay ? false : !prod.Mobile))
                    {
                        budhShukra = "";
                        budhShukra = string.Concat("\r\n\r\n<B>", predictionBLL.GetCodeLang("upaybelow", kundliVO.Language, true, true), "</B>\r\n");
                        dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                        str7 = string.Concat(str7, budhShukra);
                        str8 = "##########";
                        foreach (KPUpayList upayList1 in this.upay_list)
                        {
                            if (upayList1.Upay != null)
                            {
                                if (!prod.ShowRef)
                                {
                                    budhShukra = "";
                                    codeLang = new string[] { "<I>", predictionBLL.GetCodeLang("upay", kundliVO.Language, true, true), "</I> ", null, null, null, null };
                                    fakeCode = upayList1.FakeCode;
                                    codeLang[3] = fakeCode.ToString();
                                    codeLang[4] = "\r\n";
                                    codeLang[5] = upayList1.Upay.ToString();
                                    codeLang[6] = "\r\n";
                                    budhShukra = string.Concat(codeLang);
                                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                                    str7 = string.Concat(str7, budhShukra);
                                }
                                else
                                {
                                    budhShukra = "";
                                    codeLang = new string[] { "[ A_kp_remedy : ", null, null, null, null, null, null, null, null };
                                    fakeCode = upayList1.Sno;
                                    codeLang[1] = fakeCode.ToString();
                                    codeLang[2] = " ]";
                                    codeLang[3] = predictionBLL.GetCodeLang("upay", kundliVO.Language, true, true);
                                    codeLang[4] = " ";
                                    fakeCode = upayList1.FakeCode;
                                    codeLang[5] = fakeCode.ToString();
                                    codeLang[6] = "\r\n";
                                    codeLang[7] = upayList1.Upay.ToString();
                                    codeLang[8] = "\r\n";
                                    budhShukra = string.Concat(codeLang);
                                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                                    str7 = string.Concat(str7, budhShukra);
                                }
                                obj = str8;
                                code = new object[] { obj, upayList1.Code, "-", upayList1.FakeCode, "#" };
                                str8 = string.Concat(code);
                                budhShukra = "";
                                budhShukra = "\r\n";
                                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                                str7 = string.Concat(str7, budhShukra);
                            }
                        }
                        if (prod.Matchmaking)
                        {
                            str8 = string.Concat(str8, "$$$$$$");
                        }
                        budhShukra = "";
                        budhShukra = string.Concat(predictionBLL.GetCodeLang("upayhelpbottom", kundliVO.Language, true, true), "\r\n");
                        dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                        str7 = string.Concat(str7, budhShukra);
                    }
                    budhShukra = "";
                    budhShukra = str8;
                    dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                    str7 = string.Concat(str7, budhShukra);
                }
                if (prod.Json)
                {
                    str13 = string.Concat(str13, "\"completeprediction\": {\"data\": [{");
                    str9 = str13;
                    codeLang = new string[] { str9, "\"heading\": \"", predictionBLL.GetCodeLang("headnaukri", kundliVO.Language, kundliVO.Paid, true).ToString(), "\",\"value\": \"", str7, "\"" };
                    str13 = string.Concat(codeLang);
                    str13 = string.Concat(str13, "}]},");
                    dashaWiseTalakShadiYog = str13;
                }
                redSigni = dashaWiseTalakShadiYog;
            }
            else
            {
                KPPredBLL kPPredBLL2 = new KPPredBLL();
                dashaWiseTalakShadiYog = "";
                dashaWiseTalakShadiYog = kPPredBLL2.Get_DashaWise_Talak_ShadiYog(kPPlanetMappingVOs, kPHouseMappingVOs, kundliVO, prod.Include, prod);
                redSigni = dashaWiseTalakShadiYog;
            }
            return redSigni;
            Label2:
            budhShukra = "";
            budhShukra = string.Concat(this.Get_Full_Yog(kPPlanetMappingVOs1, kPHouseMappingVOs1, kundliVO, prod, 1, kundliVO.Dob, kundliVO.Dob), "\r\n\r\n");
            dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
            str7 = string.Concat(str7, budhShukra);
            budhShukra = "";
            budhShukra = string.Concat(this.Get_Full_Yuti(kPPlanetMappingVOs1, kPHouseMappingVOs1, kundliVO, prod, 1, kundliVO.Dob, kundliVO.Dob), "\r\n\r\n");
            dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
            str7 = string.Concat(str7, budhShukra);
            budhShukra = "";
            budhShukra = this.Get_Full_Triangle(kPPlanetMappingVOs1, kPHouseMappingVOs1, kundliVO, prod, 1, kundliVO.Dob, kundliVO.Dob);
            dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
            str7 = string.Concat(str7, budhShukra);
            if ((!prod.ShowUpay ? false : !prod.Mobile))
            {
                str8 = "";
                budhShukra = "";
                budhShukra = string.Concat("\r\n\r\n<B>", predictionBLL.GetCodeLang("upaybelow", kundliVO.Language, true, true), "</B>\r\n");
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                str7 = string.Concat(str7, budhShukra);
                str8 = "##########";
                foreach (KPUpayList kPUpayList1 in this.upay_list)
                {
                    if (kPUpayList1.Upay != null)
                    {
                        if (!prod.ShowRef)
                        {
                            budhShukra = "";
                            codeLang = new string[] { "<I>", predictionBLL.GetCodeLang("upay", kundliVO.Language, true, true), "</I> ", null, null, null, null };
                            fakeCode = kPUpayList1.FakeCode;
                            codeLang[3] = fakeCode.ToString();
                            codeLang[4] = "\r\n";
                            codeLang[5] = kPUpayList1.Upay.ToString();
                            codeLang[6] = "\r\n\r\n";
                            budhShukra = string.Concat(codeLang);
                            dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                            str7 = string.Concat(str7, budhShukra);
                        }
                        else
                        {
                            budhShukra = "";
                            codeLang = new string[] { "[ A_kp_remedy : ", null, null, null, null, null, null, null, null };
                            fakeCode = kPUpayList1.Sno;
                            codeLang[1] = fakeCode.ToString();
                            codeLang[2] = " ]";
                            codeLang[3] = predictionBLL.GetCodeLang("upay", kundliVO.Language, true, true);
                            codeLang[4] = " ";
                            fakeCode = kPUpayList1.FakeCode;
                            codeLang[5] = fakeCode.ToString();
                            codeLang[6] = "\r\n";
                            codeLang[7] = kPUpayList1.Upay.ToString();
                            codeLang[8] = "\r\n\r\n";
                            budhShukra = string.Concat(codeLang);
                            dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                            str7 = string.Concat(str7, budhShukra);
                        }
                        obj = str8;
                        code = new object[] { obj, kPUpayList1.Code, "-", kPUpayList1.FakeCode, "#" };
                        str8 = string.Concat(code);
                    }
                }
                if (prod.Matchmaking)
                {
                    str8 = string.Concat(str8, "$$$$$$");
                }
                budhShukra = "";
                budhShukra = string.Concat(predictionBLL.GetCodeLang("upayhelpbottom", kundliVO.Language, true, true), "\r\n");
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                str7 = string.Concat(str7, budhShukra);
                budhShukra = "";
                budhShukra = str8;
                dashaWiseTalakShadiYog = string.Concat(dashaWiseTalakShadiYog, budhShukra);
                str7 = string.Concat(str7, budhShukra);
            }
            redSigni = dashaWiseTalakShadiYog;
            return redSigni;
        }

        //public string Get_Nishkarsh(ProductSettingsVO boyprod, ProductSettingsVO girlprod, string language)
        //{
        //    PredictionBLL predictionBLL = new PredictionBLL();
        //    this.Get_New_Products(boyprod);
        //    this.Get_New_Products(girlprod);
        //    short num = 0;
        //    short num1 = 0;
        //    num = Convert.ToInt16((int)(AstroGlobal.MM_child + AstroGlobal.MM_married + AstroGlobal.MM_profession + AstroGlobal.MM_health));
        //    num1 = Convert.ToInt16((int)(AstroGlobal.MF_child + AstroGlobal.MF_married + AstroGlobal.MF_profession + AstroGlobal.MF_health));
        //    short num2 = Convert.ToInt16((this.perc(AstroGlobal.MM_child, AstroGlobal.MM_total) + this.perc(AstroGlobal.MM_married, AstroGlobal.MM_total) + this.perc(AstroGlobal.MM_health, AstroGlobal.MM_total) + this.perc(AstroGlobal.MM_profession, AstroGlobal.MM_total)) / 4);
        //    short num3 = Convert.ToInt16((this.perc(AstroGlobal.MF_child, AstroGlobal.MF_total) + this.perc(AstroGlobal.MF_married, AstroGlobal.MF_total) + this.perc(AstroGlobal.MF_health, AstroGlobal.MF_total) + this.perc(AstroGlobal.MF_profession, AstroGlobal.MF_total)) / 4);
        //    short num4 = 0;
        //    num4 = this.perc_score(Convert.ToInt16((int)(num + num1)), Convert.ToInt16((int)(AstroGlobal.MM_total + AstroGlobal.MF_total)));
        //    num4 = this.perc_score(num2, num3);
        //    string str = "";
        //    short num5 = this.perc(AstroGlobal.MM_child, AstroGlobal.MM_total);
        //    str = string.Concat(str, "\r\n\r\n\r\n Boy Child : ", num5.ToString(), "%");
        //    num5 = this.perc(AstroGlobal.MM_married, AstroGlobal.MM_total);
        //    str = string.Concat(str, "\r\n\r\n Boy Married Life : ", num5.ToString(), "%");
        //    num5 = this.perc(AstroGlobal.MM_health, AstroGlobal.MM_total);
        //    str = string.Concat(str, "\r\n\r\n Boy Health : ", num5.ToString(), "%");
        //    num5 = this.perc(AstroGlobal.MM_profession, AstroGlobal.MM_total);
        //    str = string.Concat(str, "\r\n\r\n Boy Occupation : ", num5.ToString(), "%");
        //    str = string.Concat(str, "\r\n\r\n Boy Total : ", num2.ToString(), "%");
        //    num5 = this.perc(AstroGlobal.MF_child, AstroGlobal.MF_total);
        //    str = string.Concat(str, "\r\n\r\n Girl Child : ", num5.ToString(), "%");
        //    num5 = this.perc(AstroGlobal.MF_married, AstroGlobal.MF_total);
        //    str = string.Concat(str, "\r\n\r\n Gill Married Life : ", num5.ToString(), "%");
        //    num5 = this.perc(AstroGlobal.MF_health, AstroGlobal.MF_total);
        //    str = string.Concat(str, "\r\n\r\n Girl Health : ", num5.ToString(), "%");
        //    num5 = this.perc(AstroGlobal.MF_profession, AstroGlobal.MF_total);
        //    str = string.Concat(str, "\r\n\r\n Girl Occupation : ", num5.ToString(), "%");
        //    str = string.Concat(str, "\r\n\r\n Girl Total : ", num3.ToString(), "%");
        //    str = string.Concat(str, "\r\n\r\n\r\n", predictionBLL.GetCodeLang(string.Concat("nishkarsh", num4.ToString()), language, true, true));
        //    str = string.Concat(str, "\r\n\r\n", predictionBLL.GetCodeLang("upaymatchmaking", language, true, true));
        //    return str;
        //}

        public string Get_Only_Mahadasha(List<KPHouseMappingVO> cusp_house, List<KPPlanetMappingVO> kp_chart, KundliVO persKV, bool include, bool showupay, bool upay, ProductSettingsVO prod, bool current_mahadasha)
        {
            bool flag;
            string str = "";
            PredictionBLL predictionBLL = new PredictionBLL();
            List<KPDashaVO> kPDashaVOs = new List<KPDashaVO>();
            List<KPDashaVO> list = new List<KPDashaVO>();
            KPDashaVO kPDashaVO = new KPDashaVO();
            KPDashaVO kPDashaVO1 = new KPDashaVO();
            List<KPDashafalChainVO> kPDashafalChainVOs = new List<KPDashafalChainVO>();
            string[] codeLang = new string[] { " " };
            string[] strArrays = codeLang;
            if (persKV.RatnaCode.Length >= 1)
            {
                strArrays = persKV.RatnaCode.Split(new char[] { ',' });
            }
            KPDAO kPDAO = new KPDAO();
            kPDashaVOs = this.Get_Dasha(cusp_house, kp_chart, persKV, include);
            List<KPMahadashaVO> kPMahadashaVOs = new List<KPMahadashaVO>();
            kPMahadashaVOs = this.Fill_Mahadasha();
            if (!current_mahadasha)
            {
                str = string.Concat(str, "\r\n\r\n<B>", predictionBLL.GetCodeLang("kpgeneral", persKV.Language, true, true), "</B>\r\n\r\n");
            }
            kPDashaVOs = (
                from Map in kPDashaVOs
                where Map.EndDate >= persKV.Dob
                select Map).ToList<KPDashaVO>();
            list = (
                from Map in kPDashaVOs
                where Map.EndDate >= persKV.Dob
                select Map).ToList<KPDashaVO>();
            string str1 = "";
            string str2 = "";
            DateTime date = DateTime.Now.Date;
            str1 = string.Concat("\r\n<B>", predictionBLL.GetCodeLang("mahadashanote", persKV.Language, true, true), "</B>\r\n\r\n");
            if (prod.Product.ToLower() == "mobile" || prod.CurrentMahadasha || current_mahadasha)
            {
                flag = false;
            }
            else
            {
                flag = (prod.ShowUpay ? true : prod.ShowUpayCode);
            }
            if (!flag)
            {
                kPDashaVOs = (
                    from Map in kPDashaVOs
                    where (date < Map.StartDate ? false : date <= Map.EndDate)
                    select Map).ToList<KPDashaVO>();
            }
            foreach (KPDashaVO kPDashaVO2 in
                from Map in kPDashaVOs
                orderby Map.StartDate
                select Map)
            {
                DateTime startDate = kPDashaVO2.StartDate;
                DateTime endDate = kPDashaVO2.EndDate;
                short num = Convert.ToInt16(predictionBLL.CalculateAgeCorrect(persKV.Dob, startDate));
                Convert.ToInt16(predictionBLL.CalculateAgeCorrect(persKV.Dob, endDate));
                short house = (
                    from Map in kp_chart
                    where Map.Planet == kPDashaVO2.Planet
                    select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                this.Get_Signi_String_Without_NakRashi(kPDashaVO2.Planet, kp_chart, include);
                string str3 = str1;
                short years = (
                    from Map in kPMahadashaVOs
                    where Map.Planet == kPDashaVO2.Planet
                    select Map).SingleOrDefault<KPMahadashaVO>().Years;
                str2 = str3.Replace("[#years#]", years.ToString());
                codeLang = new string[] { startDate.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", startDate.ToString("%M")), persKV.Language, persKV.Paid, true), " ", startDate.ToString("yyyy") };
                string str4 = string.Concat(codeLang);
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
                    str4 = string.Concat(codeLang);
                }
                codeLang = new string[] { endDate.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", endDate.ToString("%M")), persKV.Language, persKV.Paid, true), " ", endDate.ToString("yyyy") };
                string str5 = string.Concat(codeLang);
                codeLang = new string[] { "<B>", predictionBLL.GetCodeLang("mahadasha", persKV.Language, persKV.Paid, true), " ", str4, predictionBLL.GetCodeLang("to", persKV.Language, persKV.Paid, true), str5, "</B>\r\n" };
                string str6 = string.Concat(codeLang);
                if (!(num <= 72 ? true : persKV.Current_Age > 60))
                {
                    break;
                }
                else if ((num <= 100 ? true : persKV.Current_Age <= 60))
                {
                    short house1 = (
                        from Map in kp_chart
                        where Map.Planet == kPDashaVO2.Planet
                        select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                    string str7 = str;
                    codeLang = new string[] { str7, str6, str2, this.Get_Dasha_Pred(kPDashaVO2.Planet, house1.ToString(), startDate, endDate, persKV, "fulllife", prod, kp_chart), "\r\n\r\n" };
                    str = string.Concat(codeLang);
                    short nakLord = (
                        from Map in kp_chart
                        where Map.Planet == kPDashaVO2.Planet
                        select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
                    short bhavChalitHouse = (
                        from Map in kp_chart
                        where Map.Planet == nakLord
                        select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
                    short bhavChalitHouse1 = (
                        from Map in kp_chart
                        where Map.Planet == kPDashaVO2.Planet
                        select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
                    if (bhavChalitHouse != house1)
                    {
                        str = string.Concat(str, "\r\n", this.Get_Dasha_Pred(kPDashaVO2.Planet, bhavChalitHouse.ToString(), startDate, endDate, persKV, "fulllife", prod, kp_chart), "\r\n\r\n");
                    }
                    if ((bhavChalitHouse1 == house1 ? false : bhavChalitHouse1 != bhavChalitHouse))
                    {
                        str = string.Concat(str, "\r\n", this.Get_Dasha_Pred(kPDashaVO2.Planet, bhavChalitHouse1.ToString(), startDate, endDate, persKV, "fulllife", prod, kp_chart), "\r\n\r\n");
                    }
                    if (persKV.RatnaCode.Length >= 1)
                    {
                        if (strArrays.Contains<string>(kPDashaVO2.Planet.ToString()))
                        {
                            KPMixDashaVO kPMixDashaVO = new KPMixDashaVO();
                            KPPlanetsVO kPPlanetsVO = (
                                from Map in KPBLL.planet_list
                                where Map.Planet == kPDashaVO2.Planet
                                select Map).SingleOrDefault<KPPlanetsVO>();
                            kPMixDashaVO = (
                                from Map in kPDAO.Get_Mix_Dasha(kPDashaVO2.Planet, house1, 1, "all", "fulllife_gems")
                                where !Map.Isbad
                                select Map).FirstOrDefault<KPMixDashaVO>();
                            if (kPMixDashaVO != null)
                            {
                                str7 = str;
                                codeLang = new string[] { str7, "<b>", predictionBLL.GetCodeLang(kPPlanetsVO.RatnaCode, persKV.Language, true, true), "</b> ", this.Get_KP_Lang(kPMixDashaVO.Sno, persKV.Language, false, false, prod.Mini), "\r\n\r\n\r\n" };
                                str = string.Concat(codeLang);
                            }
                        }
                    }
                    string mixFal = "";
                    mixFal = this.Get_Mix_Fal(kPDashaVO2.Planet, kp_chart, cusp_house, persKV, prod, Convert.ToInt16(persKV.Current_Age), false, true, "khabar", startDate, endDate);
                    if (bhavChalitHouse != house1)
                    {
                        mixFal = string.Concat(mixFal, this.Get_Dasha_Pred(kPDashaVO2.Planet, bhavChalitHouse.ToString(), startDate, endDate, persKV, "khabar", prod, kp_chart), "\r\n");
                    }
                    if ((bhavChalitHouse1 == house1 ? false : bhavChalitHouse1 != bhavChalitHouse))
                    {
                        mixFal = string.Concat(mixFal, this.Get_Dasha_Pred(kPDashaVO2.Planet, bhavChalitHouse1.ToString(), startDate, endDate, persKV, "khabar", prod, kp_chart), "\r\n");
                    }
                    if (mixFal.Length > 30)
                    {
                        mixFal = string.Concat(predictionBLL.GetCodeLang("Precautions", persKV.Language, true, true), "\r\n\r\n", mixFal);
                        str = string.Concat(str, mixFal);
                    }
                }
                else
                {
                    break;
                }
            }
            return str;
        }

        public string Get_Planet_Chain_Pred(string houses, DateTime startdate, DateTime enddate, KundliVO persKV, string ptype, short nak_swami, ProductSettingsVO prod, short age)
        {
            string[] signi;
            string str = "";
            PredictionBLL predictionBLL = new PredictionBLL();
            KPDAO kPDAO = new KPDAO();
            short num = Convert.ToInt16(predictionBLL.CalculateAgeCorrect(persKV.Dob, startdate));
            Convert.ToInt16(predictionBLL.CalculateAgeCorrect(persKV.Dob, enddate));
            if (startdate < persKV.Dob)
            {
                num = 1;
            }
            houses = houses.Trim();
            if (ptype == "multi")
            {
                List<KPMixDashaVO> kPMixDashaVOs = new List<KPMixDashaVO>();
                kPMixDashaVOs = kPDAO.Get_Mix_Dasha(nak_swami, 1, 1, prod.Product, "multi");
                List<KPMixDashaVO> kPMixDashaVOs1 = new List<KPMixDashaVO>();
                kPMixDashaVOs1 = kPMixDashaVOs;
                if (persKV.Male)
                {
                    kPMixDashaVOs = (
                        from Map in kPMixDashaVOs1
                        where (!Map.common ? false : !Map.female)
                        select Map).ToList<KPMixDashaVO>();
                    kPMixDashaVOs.AddRange((
                        from Map in kPMixDashaVOs1
                        where Map.male
                        select Map).ToList<KPMixDashaVO>());
                }
                if (!persKV.Male)
                {
                    kPMixDashaVOs = (
                        from Map in kPMixDashaVOs1
                        where (!Map.common ? false : !Map.male)
                        select Map).ToList<KPMixDashaVO>();
                    kPMixDashaVOs.AddRange((
                        from Map in kPMixDashaVOs1
                        where Map.female
                        select Map).ToList<KPMixDashaVO>());
                }
                foreach (KPMixDashaVO kPMixDashaVO in kPMixDashaVOs)
                {
                    short num1 = 0;
                    char[] chrArray = new char[] { ' ' };
                    string[] strArrays = houses.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                    string signi1 = kPMixDashaVO.Signi;
                    chrArray = new char[] { ',' };
                    string[] strArrays1 = signi1.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < (int)strArrays1.Length; i++)
                    {
                        if (strArrays.Contains<string>(strArrays1[i].Trim()))
                        {
                            num1 = (short)(num1 + 1);
                        }
                    }
                    string str1 = kPMixDashaVO.Signi;
                    chrArray = new char[] { ',' };
                    if (num1 == (int)str1.Split(chrArray, StringSplitOptions.RemoveEmptyEntries).Length)
                    {
                        if (!this.chain_all_fal.Exists((short Map) => Map == kPMixDashaVO.Sno))
                        {
                            if (persKV.ShowRef)
                            {
                                string str2 = str;
                                signi = new string[] { str2, "( ", kPMixDashaVO.Signi, ") [Mix Dasha Chain : ", null, null, null, null, null, null };
                                signi[4] = kPMixDashaVO.Sno.ToString();
                                signi[5] = " ] ";
                                signi[6] = kPMixDashaVO.planethouse;
                                signi[7] = "  ";
                                signi[8] = kPMixDashaVO.Signi;
                                signi[9] = " ";
                                str = string.Concat(signi);
                            }
                            str = string.Concat(str, this.Get_KP_Lang(kPMixDashaVO.Sno, persKV.Language, false, false, prod.Mini));
                        }
                        this.chain_all_fal.Add(kPMixDashaVO.Sno);
                    }
                }
            }
            if (str.Length > 60)
            {
                signi = new string[] { "<B>", predictionBLL.GetCodeLang("sankdi", prod.Lang, prod.Paid, true), "</B>\r\n\r\n", str, "\r\n_______________\r\n\r\n" };
                str = string.Concat(signi);
            }
            else
            {
                str = "";
            }
            return str;
        }

        public string Get_Planet_Nak_Planet_Sublord_Fal(KundliVO persKV, short house, string houses)
        {
            KPDAO kPDAO = new KPDAO();
            string str = "";
            List<short> nums = new List<short>();
            List<KP_Sublord_Pred> kPSublordPreds = new List<KP_Sublord_Pred>();
            kPSublordPreds = kPDAO.Get_KP_Cusp_Pred(persKV.ShowRef, house);
            char[] chrArray = new char[] { ' ' };
            string[] strArrays = houses.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string str1 = strArrays[i];
                foreach (KP_Sublord_Pred kPSublordPred in
                    from Map in kPSublordPreds
                    where Map.Sublord == Convert.ToInt16(str1)
                    select Map)
                {
                    if (!nums.Exists((short Map) => (long)Map == kPSublordPred.Sno))
                    {
                        str = string.Concat(str, kPSublordPred.Pred_Hindi, "\r\n\r\n");
                    }
                    nums.Add(Convert.ToInt16(kPSublordPred.Sno));
                }
            }
            return str;
        }

        public string Get_Planet_Pred(List<KPPlanetMappingVO> kp_chart)
        {
            string str = "";
            List<KP_Planet_Pred> kPPlanetPreds = new List<KP_Planet_Pred>();
            KPDAO kPDAO = new KPDAO();
            foreach (KPPlanetMappingVO kpChart in kp_chart)
            {
                if (kp_chart.Exists((KPPlanetMappingVO Map) => Map.Nak_Lord == kpChart.Planet))
                {
                    kPPlanetPreds.AddRange((
                        from Map in kPDAO.Get_KP_Planet_Pred()
                        where (Map.Planet != kpChart.Planet ? false : Map.House == kpChart.Bhav_Chalit_House)
                        select Map).ToList<KP_Planet_Pred>());
                }
            }
            foreach (KP_Planet_Pred kPPlanetPred in kPPlanetPreds)
            {
                str = string.Concat(str, kPPlanetPred.Pred_Hindi, "\r\n\r\n");
            }
            return str;
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

        public string Get_Pred_Text(long sno, string lang, bool male, bool adult, bool showref, bool vfal, bool paid, bool add_upayno, bool unicode, KundliVO persKV, ProductSettingsVO prod)
        {
            string str;
            string[] codeLang;
            PredictionBLL predictionBLL = new PredictionBLL();
            string str1 = "\r\n";
            RuleDAO ruleDAO = new RuleDAO();
            LangVO langVO = new LangVO();
            RuleBLL ruleBLL = new RuleBLL();
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
            if (prod.ShowUpayCode)
            {
                RulesVO rulesVO = new RulesVO();
                RuleDAO ruleDAO1 = new RuleDAO();
                rulesVO = ruleBLL.GetAdvanceRuleById(sno);
                UpayIndex upayIndex = new UpayIndex();
                upayIndex = ruleDAO1.Get_UpayIndex(Convert.ToInt32(rulesVO.Upay), true);
                if ((upayIndex == null ? false : upayIndex.Sno != 0))
                {
                    str1 = str1.TrimEnd(new char[0]);
                    if (prod.ShowUpay)
                    {
                        if (persKV.Language.ToLower() == "hindi")
                        {
                            str = str1;
                            codeLang = new string[] { str, "\r\n<B>", predictionBLL.GetCodeLang("upaytext", lang, paid, unicode), " </B> \r\n", upayIndex.Hindi, "\r\n" };
                            str1 = string.Concat(codeLang);
                        }
                        if (persKV.Language.ToLower() == "english")
                        {
                            str = str1;
                            codeLang = new string[] { str, "\r\n<B>", predictionBLL.GetCodeLang("upaytext", lang, paid, unicode), " </B> \r\n", upayIndex.Eng, "\r\n" };
                            str1 = string.Concat(codeLang);
                        }
                        if (persKV.Language.ToLower() == "marathi")
                        {
                            str = str1;
                            codeLang = new string[] { str, "\r\n<B>", predictionBLL.GetCodeLang("upaytext", lang, paid, unicode), " </B> \r\n", upayIndex.Marathi, "\r\n" };
                            str1 = string.Concat(codeLang);
                        }
                    }
                    if (prod.Gen_Link)
                    {
                        str1 = string.Concat(str1, this.Gen_Link((long)upayIndex.Sno, prod.Gen_Link, (long)upayIndex.Sno, false, sno, "U"), "\r\n\r\n");
                    }
                }
            }
            return str1;
        }

        public string Get_Products(ProductSettingsVO prod)
        {
            string str;
            long fakeCode;
            int house;
            string str1;
            string[] codeLang;
            PredictionBLL predictionBLL = new PredictionBLL();
            string str2 = "";
            string str3 = "";
            KundliBLL kundliBLL = new KundliBLL();
            str3 = kundliBLL.Gen_Kunda(prod.Online_Result, 500f, prod.Rotate);
            KundliVO kundliVO = new KundliVO();
            PredictionBLL predictionBLL1 = new PredictionBLL();
            PredictionBLL predictionBLL2 = new PredictionBLL();
            this.upay_list = new List<KPUpayList>();
            this.date_list = new List<string>();
            string onlineResult = prod.Online_Result;
            char[] chrArray = new char[] { ',' };
            string[] strArrays = onlineResult.Split(chrArray);
            short num = 0;
            List<KundliMappingVO> kundliMappingVOs = new List<KundliMappingVO>();
            string str4 = strArrays[2];
            string str5 = strArrays[3];
            chrArray = new char[] { 'E' };
            str4 = str4.TrimEnd(chrArray);
            chrArray = new char[] { 'N' };
            str4 = str4.TrimEnd(chrArray);
            chrArray = new char[] { 'S' };
            str4 = str4.TrimEnd(chrArray);
            chrArray = new char[] { 'W' };
            str4 = str4.TrimEnd(chrArray);
            chrArray = new char[] { 'E' };
            str5 = str5.TrimEnd(chrArray);
            chrArray = new char[] { 'N' };
            str5 = str5.TrimEnd(chrArray);
            chrArray = new char[] { 'S' };
            str5 = str5.TrimEnd(chrArray);
            chrArray = new char[] { 'W' };
            str5 = str5.TrimEnd(chrArray);
            string str6 = strArrays[0];
            chrArray = new char[] { '/' };
            string str7 = str6.Split(chrArray)[0];
            string str8 = strArrays[0];
            chrArray = new char[] { '/' };
            string str9 = str8.Split(chrArray)[1];
            string str10 = strArrays[0];
            chrArray = new char[] { '/' };
            string str11 = str10.Split(chrArray)[2];
            string str12 = strArrays[1];
            chrArray = new char[] { ':' };
            string str13 = str12.Split(chrArray)[0];
            string str14 = strArrays[1];
            chrArray = new char[] { ':' };
            kundliVO = predictionBLL1.map_persKV(str3, "", "", str7, str9, str11, str13, str14.Split(chrArray)[1], "00", "admin", str4, str5, strArrays[4], true, prod.Lang, prod.ShowRef, prod.Male, "YICC", "YICC", "YICC", "YICC", "YICC", prod.Product, "01", "01", "2000", prod.Rotate);
            kundliVO.FileCode = prod.Sno.ToString();
            kundliMappingVOs = predictionBLL2.map_kundali(str3, true);
            List<KPPlanetMappingVO> kPPlanetMappingVOs = new List<KPPlanetMappingVO>();
            List<KPHouseMappingVO> kPHouseMappingVOs = new List<KPHouseMappingVO>();
            this.Process_Planet_Lagan(str3, ref kPPlanetMappingVOs, ref kPHouseMappingVOs, kundliVO.Rotate, false);
            kPPlanetMappingVOs = this.Process_KPChart_GoodBad(kPPlanetMappingVOs, kundliVO, prod);
            List<KundliMappingVO> kundliMappingVOs1 = predictionBLL.map_kundali(kundliVO.Online_Result, true);
            num = Convert.ToInt16(predictionBLL.CalculateAgeCorrect(kundliVO.Dob, DateTime.Now));
            num = (short)(num - 1);
            num = (short)(num - 1);
            string str15 = "";
            string str16 = "";
            string str17 = "";
            if (!prod.Mobile)
            {
                foreach (KundliMappingVO kundliMappingVO in kundliMappingVOs1)
                {
                    if (!kundliMappingVO.IsBad)
                    {
                        string planetNameEnglish = kundliMappingVO.PlanetNameEnglish;
                        string language = kundliVO.Language;
                        house = kundliMappingVO.House;
                        str15 = string.Concat(str15, predictionBLL.KPgetvargitdaan(planetNameEnglish, language, house.ToString(), kundliMappingVO.IsBad));
                    }
                    else
                    {
                        string planetNameEnglish1 = kundliMappingVO.PlanetNameEnglish;
                        string language1 = kundliVO.Language;
                        house = kundliMappingVO.House;
                        str17 = string.Concat(str17, predictionBLL.KPgetvargitdaan(planetNameEnglish1, language1, house.ToString(), kundliMappingVO.IsBad));
                        str16 = string.Concat(str16, predictionBLL.KPgetvargitcolor(kundliMappingVO.PlanetNameEnglish, kundliVO.Language));
                    }
                }
            }
            str2 = ((!prod.Mobile ? false : prod.ShowManyavar) ? string.Concat(str2, "<B>", predictionBLL.GetCodeLang("lifeheadmobile", kundliVO.Language, true, true), "</B>\r\n\r\n") : string.Concat(str2, "<B>", predictionBLL.GetCodeLang("lifehead", kundliVO.Language, true, true), "</B>\r\n\r\n"));
            if (!prod.Mobile)
            {
                if (str15.Trim().Length > 0)
                {
                    str1 = str2;
                    codeLang = new string[] { str1, "\r\n\r\n<B><U>", predictionBLL.GetCodeLang("vdaan", kundliVO.Language, kundliVO.Paid, true), "</U></B>\r\n", str15, "\r\n\r\n" };
                    str2 = string.Concat(codeLang);
                }
                if (str17.Trim().Length > 0)
                {
                    str1 = str2;
                    codeLang = new string[] { str1, "\r\n\r\n<B><U>", predictionBLL.GetCodeLang("daan", kundliVO.Language, kundliVO.Paid, true), "</U></B>\r\n", str17, "\r\n\r\n" };
                    str2 = string.Concat(codeLang);
                }
                if (str16.Trim().Length > 0)
                {
                    str1 = str2;
                    codeLang = new string[] { str1, "\r\n\r\n<B><U>", predictionBLL.GetCodeLang("vcolor", kundliVO.Language, kundliVO.Paid, true), "</U></B>\r\n", str16, "\r\n" };
                    str2 = string.Concat(codeLang);
                }
            }
            if (!prod.Mobile)
            {
                str2 = string.Concat(str2, "\r\n<I>", predictionBLL.GetPlanetLord_Unicode(kundliMappingVOs1, kundliVO), "</I>\r\n\r\n");
                if ((prod.Category == "all" || prod.Category.Length <= 0 ? true : prod.Category == "occupation"))
                {
                    str2 = string.Concat(str2, this.Get_School_Kids(str3, kundliVO, false, prod), "\r\n\r\n");
                }
            }
            num = Convert.ToInt16(predictionBLL.CalculateAgeCorrect(kundliVO.Dob, DateTime.Now));
            num = (short)(num - 1);
            short num1 = 0;
            while (num1 <= 20)
            {
                num = Convert.ToInt16(num + 1);
                str2 = string.Concat(str2, this.Get_Dashafal_Age_Wise(kPPlanetMappingVOs, kPHouseMappingVOs, kundliVO, prod.Include, num, prod, true));
                if (!(this.last_antar_date > DateTime.Now.Date.AddYears(prod.Dasha_Years - 2)))
                {
                    num1 = (short)(num1 + 1);
                }
                else
                {
                    break;
                }
            }
            this.last_antar_date = new DateTime();
            this.last_pryaantar_date = new DateTime();
            num = Convert.ToInt16(predictionBLL.CalculateAgeCorrect(kundliVO.Dob, DateTime.Now));
            num = (short)(num - 1);
            num1 = 0;
            while (num1 <= 20)
            {
                num = Convert.ToInt16(num + 1);
                str2 = string.Concat(str2, this.Get_Dashafal_Age_Wise(kPPlanetMappingVOs, kPHouseMappingVOs, kundliVO, prod.Include, num, prod, false));
                if (!(this.last_pryaantar_date > DateTime.Now.Date.AddYears(prod.Dasha_Years - 2)))
                {
                    num1 = (short)(num1 + 1);
                }
                else
                {
                    break;
                }
            }
            if ((prod.Category == "all" ? true : prod.Category.Length <= 0))
            {
                str2 = string.Concat(str2, this.Get_Only_Mahadasha(kPHouseMappingVOs, kPPlanetMappingVOs, kundliVO, prod.Include, prod.ShowUpay, prod.ShowUpayCode, prod, false), "\r\n\r\n");
            }
            if (!prod.Only_Chain)
            {
                if ((prod.Category == "all" || prod.Category.Length <= 0 ? !prod.Mobile : false))
                {
                    str2 = string.Concat(str2, "\r\n\r\n", this.Get_Rinn_Pitri(prod, kundliVO, kPPlanetMappingVOs), "\r\n\r\n");
                }
                string str18 = "";
                if ((!prod.ShowUpay ? false : !prod.Mobile))
                {
                    str2 = string.Concat(str2, "\r\n\r\n<B>", predictionBLL.GetCodeLang("upaybelow", kundliVO.Language, true, true), "</B>\r\n");
                    str18 = "##########";
                    foreach (KPUpayList upayList in this.upay_list)
                    {
                        if (!prod.ShowRef)
                        {
                            str1 = str2;
                            codeLang = new string[] { str1, "<I>", predictionBLL.GetCodeLang("upay", kundliVO.Language, true, true), "</I> ", null, null, null };
                            fakeCode = upayList.FakeCode;
                            codeLang[4] = fakeCode.ToString();
                            codeLang[5] = "\r\n";
                            codeLang[6] = upayList.Upay.ToString();
                            str2 = string.Concat(codeLang);
                        }
                        else
                        {
                            str1 = str2;
                            codeLang = new string[] { str1, "[ A_kp_remedy : ", null, null, null, null, null, null, null };
                            fakeCode = upayList.Sno;
                            codeLang[2] = fakeCode.ToString();
                            codeLang[3] = " ]";
                            codeLang[4] = predictionBLL.GetCodeLang("upay", kundliVO.Language, true, true);
                            codeLang[5] = " ";
                            fakeCode = upayList.FakeCode;
                            codeLang[6] = fakeCode.ToString();
                            codeLang[7] = "\r\n";
                            codeLang[8] = upayList.Upay.ToString();
                            str2 = string.Concat(codeLang);
                        }
                        object obj = str18;
                        object[] code = new object[] { obj, upayList.Code, "-", upayList.FakeCode, "#" };
                        str18 = string.Concat(code);
                        str2 = string.Concat(str2, "\r\n");
                    }
                    str2 = string.Concat(str2, predictionBLL.GetCodeLang("upayhelpbottom", kundliVO.Language, true, true), "\r\n");
                }
                str2 = str2.Replace("\r\n\r\n\r\n\r\n", "\r\n\r\n");
                str2 = str2.Replace("\r\n\r\n\r\n", "\r\n\r\n");
                str2 = string.Concat(str2, str18);
                str = str2;
            }
            else
            {
                str = str2;
            }
            return str;
        }

        public string Get_Rinn_Pitri(ProductSettingsVO prod, KundliVO persKV, List<KPPlanetMappingVO> kp_chart)
        {
            double num;
            short num1;
            short num2;
            string str = "";
            PredictionBLL predictionBLL = new PredictionBLL();
            KPDAO kPDAO = new KPDAO();
            List<KPRinnPitriVO> kPRinnPitriVOs = new List<KPRinnPitriVO>();
            kPRinnPitriVOs = kPDAO.Get_Rinn_Pitri();
            bool flag = false;
            bool flag1 = false;
            short num3 = 1;
            foreach (KPRinnPitriVO kPRinnPitriVO in kPRinnPitriVOs)
            {
                string inHouse = kPRinnPitriVO.InHouse;
                char[] chrArray = new char[] { '#' };
                string[] strArrays = inHouse.Split(chrArray);
                string outHouse = kPRinnPitriVO.OutHouse;
                chrArray = new char[] { '#' };
                string[] strArrays1 = outHouse.Split(chrArray);
                string[] strArrays2 = strArrays;
                int num4 = 0;
                while (num4 < (int)strArrays2.Length)
                {
                    string str1 = strArrays2[num4];
                    num2 = Convert.ToInt16(Convert.ToInt16(str1) % 12);
                    if (num2 == 0)
                    {
                        num2 = 12;
                    }
                    num = Convert.ToDouble(Convert.ToInt16(str1) / 12);
                    num1 = Convert.ToInt16(Math.Ceiling(num));
                    if ((
                        from Map in kp_chart
                        where (Map.House != num2 ? false : Map.Planet == num1)
                        select Map).Count<KPPlanetMappingVO>() <= 0)
                    {
                        num4++;
                    }
                    else
                    {
                        flag = true;
                        break;
                    }
                }
                strArrays2 = strArrays1;
                num4 = 0;
                while (num4 < (int)strArrays2.Length)
                {
                    string str2 = strArrays2[num4];
                    num2 = Convert.ToInt16(Convert.ToInt16(str2) % 12);
                    if (num2 == 0)
                    {
                        num2 = 12;
                    }
                    num = Convert.ToDouble(Convert.ToInt16(str2) / 12);
                    num1 = Convert.ToInt16(Math.Ceiling(num));
                    if ((
                        from Map in kp_chart
                        where (Map.House != num2 ? false : Map.Planet == num1)
                        select Map).Count<KPPlanetMappingVO>() <= 0)
                    {
                        num4++;
                    }
                    else
                    {
                        flag1 = true;
                        break;
                    }
                }
                if ((!flag ? false : flag1))
                {
                    if (persKV.Language.ToLower() == "hindi")
                    {
                        str = string.Concat(str, kPRinnPitriVO.pred_hindi, "\r\n\r\n");
                    }
                    if (persKV.Language.Trim().ToLower() == "punjabi")
                    {
                        str = string.Concat(kPRinnPitriVO.pred_punjabi, "\r\n\r\n");
                    }
                    if (persKV.Language.Trim().ToLower() == "tamil")
                    {
                        str = string.Concat(kPRinnPitriVO.pred_tamil, "\r\n\r\n");
                    }
                    if (persKV.Language.Trim().ToLower() == "telugu")
                    {
                        str = string.Concat(kPRinnPitriVO.pred_telugu, "\r\n\r\n");
                    }
                    if (persKV.Language.Trim().ToLower() == "oriya")
                    {
                        str = string.Concat(kPRinnPitriVO.pred_oriya, "\r\n\r\n");
                    }
                    if (persKV.Language.Trim().ToLower() == "english")
                    {
                        str = string.Concat(kPRinnPitriVO.pred_english, "\r\n\r\n");
                    }
                    if ((persKV.Language.Trim().ToLower() == "bengali" ? true : persKV.Language.Trim().ToLower() == "bangla"))
                    {
                        str = string.Concat(kPRinnPitriVO.pred_bengali, "\r\n\r\n");
                    }
                    if (persKV.Language.Trim().ToLower() == "malayalam")
                    {
                        str = string.Concat(kPRinnPitriVO.pred_malayalam, "\r\n\r\n");
                    }
                    if (persKV.Language.Trim().ToLower() == "marathi")
                    {
                        str = string.Concat(kPRinnPitriVO.pred_marathi, "\r\n\r\n");
                    }
                    if (persKV.Language.Trim().ToLower() == "assamese")
                    {
                        str = string.Concat(kPRinnPitriVO.pred_assamese, "\r\n\r\n");
                    }
                    if (persKV.Language.Trim().ToLower() == "gujarati")
                    {
                        str = string.Concat(kPRinnPitriVO.pred_gujarati, "\r\n\r\n");
                    }
                    if (persKV.Language.Trim().ToLower() == "kannada")
                    {
                        str = string.Concat(kPRinnPitriVO.pred_kannada, "\r\n\r\n");
                    }
                    num3 = (short)(num3 + 1);
                }
                if (num3 >= 3)
                {
                    break;
                }
            }
            str = (str.Length < 50 ? "" : string.Concat("\r\n", predictionBLL.GetCodeLang("pitrrinn", persKV.Language, persKV.Paid, true), "\r\n\r\n", str));
            return str;
        }

        public string Get_Sankdi_AllDasha(KundliVO persKV, string Online_Result, ProductSettingsVO prod)
        {
            return "";
        }

        public string Get_Sankdi_Antardasha_New_Logic(KundliVO persKV, string Online_Result, ProductSettingsVO prod)
        {
            string str = "";
            str = "";
            ProductSettingsVO productSettingsVO = new ProductSettingsVO()
            {
                Online_Result = Online_Result,
                Include = prod.Include,
                Lang = persKV.Language,
                Male = persKV.Male,
                PredFor = 0,
                ShowRef = prod.ShowRef,
                ShowUpay = false,
                ShowUpayCode = false,
                Sno = (long)555,
                Category = "",
                Product = "all",
                Rotate = 1
            };
            List<KPPlanetMappingVO> kPPlanetMappingVOs = new List<KPPlanetMappingVO>();
            List<KPHouseMappingVO> kPHouseMappingVOs = new List<KPHouseMappingVO>();
            List<KPDashaVO> kPDashaVOs = new List<KPDashaVO>();
            List<KPDashaVO> antarDasha = new List<KPDashaVO>();
            this.Process_Planet_Lagan(Online_Result, ref kPPlanetMappingVOs, ref kPHouseMappingVOs, persKV.Rotate, false);
            kPPlanetMappingVOs = this.Process_KPChart_GoodBad(kPPlanetMappingVOs, persKV, productSettingsVO);
            kPDashaVOs = this.Get_Dasha(kPHouseMappingVOs, kPPlanetMappingVOs, persKV, false);
            DateTime date = new DateTime();
            date = DateTime.Now.Date;
            if (DateTime.Now.Date < persKV.Dob)
            {
                date = persKV.Dob;
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
            short num = planet;
            antarDasha = this.Get_Antar_Dasha(startDate, endDate, planet, kPPlanetMappingVOs, false);
            short planet1 = (
                from Map in antarDasha
                where (date < Map.StartDate ? false : date <= Map.EndDate)
                select Map).SingleOrDefault<KPDashaVO>().Planet;
            DateTime dateTime = (
                from Map in antarDasha
                where Map.Planet == planet1
                select Map).SingleOrDefault<KPDashaVO>().StartDate;
            DateTime endDate1 = (
                from Map in antarDasha
                where Map.Planet == planet1
                select Map).SingleOrDefault<KPDashaVO>().EndDate;
            short nakLord = planet1;
            PredictionBLL predictionBLL = new PredictionBLL();
            DateTime startDate1 = (
                from Map in antarDasha
                where Map.Planet == nakLord
                select Map).SingleOrDefault<KPDashaVO>().StartDate;
            DateTime dateTime1 = (
                from Map in antarDasha
                where Map.Planet == nakLord
                select Map).SingleOrDefault<KPDashaVO>().EndDate;
            string[] codeLang = new string[] { startDate1.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", startDate1.ToString("%M")), persKV.Language, persKV.Paid, true), " ", startDate1.ToString("yyyy") };
            string str1 = string.Concat(codeLang);
            if (startDate1 < persKV.Dob)
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
                str1 = string.Concat(codeLang);
            }
            codeLang = new string[] { dateTime1.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", dateTime1.ToString("%M")), persKV.Language, persKV.Paid, true), " ", dateTime1.ToString("yyyy") };
            string str2 = string.Concat(codeLang);
            codeLang = new string[] { "<B>", predictionBLL.GetCodeLang("mukhya", persKV.Language, persKV.Paid, true), " ", str1, predictionBLL.GetCodeLang("to", persKV.Language, persKV.Paid, true), str2, "</B>\r\n" };
            string str3 = string.Concat(codeLang);
            short num1 = nakLord;
            short bhavChalitHouse = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == num1
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            Convert.ToInt16(predictionBLL.CalculateAgeCorrect(persKV.Dob, startDate1));
            nakLord = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == nakLord
                select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
            short bhavChalitHouse1 = 0;
            string str4 = "";
            short num2 = nakLord;
            short nakLord1 = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == num
                select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
            bhavChalitHouse1 = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == num2
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            str4 = string.Concat((
                from Map in kPDashaVOs
                where Map.Planet == num
                select Map).SingleOrDefault<KPDashaVO>().Signi_String, " ", (
                from Map in antarDasha
                where Map.Planet == num1
                select Map).SingleOrDefault<KPDashaVO>().Signi_String);
            str = string.Concat(str3, "\r\n");
            str = string.Concat(str, this.Get_Planet_Nak_Planet_Sublord_Fal(persKV, bhavChalitHouse1, (
                from Map in antarDasha
                where Map.Planet == num2
                select Map).SingleOrDefault<KPDashaVO>().Signi_String));
            return str;
        }

        public string Get_Sankdi_Mahadasha_New_Logic(KundliVO persKV, string Online_Result, ProductSettingsVO prod)
        {
            string str = "";
            str = "";
            ProductSettingsVO productSettingsVO = new ProductSettingsVO()
            {
                Online_Result = Online_Result,
                Include = prod.Include,
                Lang = persKV.Language,
                Male = persKV.Male,
                PredFor = 0,
                ShowRef = prod.ShowRef,
                ShowUpay = false,
                ShowUpayCode = false,
                Sno = (long)555,
                Category = "",
                Product = "all",
                Rotate = 1
            };
            List<KPPlanetMappingVO> kPPlanetMappingVOs = new List<KPPlanetMappingVO>();
            List<KPHouseMappingVO> kPHouseMappingVOs = new List<KPHouseMappingVO>();
            List<KPDashaVO> kPDashaVOs = new List<KPDashaVO>();
            this.Process_Planet_Lagan(Online_Result, ref kPPlanetMappingVOs, ref kPHouseMappingVOs, persKV.Rotate, false);
            kPPlanetMappingVOs = this.Process_KPChart_GoodBad(kPPlanetMappingVOs, persKV, productSettingsVO);
            kPDashaVOs = this.Get_Dasha(kPHouseMappingVOs, kPPlanetMappingVOs, persKV, false);
            DateTime date = new DateTime();
            date = DateTime.Now.Date;
            if (DateTime.Now.Date < persKV.Dob)
            {
                date = persKV.Dob;
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
            PredictionBLL predictionBLL = new PredictionBLL();
            Convert.ToInt16(predictionBLL.CalculateAgeCorrect(persKV.Dob, startDate));
            short num = planet;
            short bhavChalitHouse = 0;
            string signiString = "";
            string signiString1 = "";
            string[] codeLang = new string[] { startDate.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", startDate.ToString("%M")), persKV.Language, persKV.Paid, true), " ", startDate.ToString("yyyy") };
            string str1 = string.Concat(codeLang);
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
                str1 = string.Concat(codeLang);
            }
            codeLang = new string[] { endDate.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", endDate.ToString("%M")), persKV.Language, persKV.Paid, true), " ", endDate.ToString("yyyy") };
            string str2 = string.Concat(codeLang);
            codeLang = new string[] { "<B>", predictionBLL.GetCodeLang("mahadasha", persKV.Language, persKV.Paid, true), " ", str1, predictionBLL.GetCodeLang("to", persKV.Language, persKV.Paid, true), str2, "</B>\r\n" };
            string str3 = string.Concat(codeLang);
            bhavChalitHouse = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == num
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            signiString = (
                from Map in kPDashaVOs
                where Map.Planet == num
                select Map).SingleOrDefault<KPDashaVO>().Signi_String;
            short nakLord = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == num
                select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
            signiString1 = (
                from Map in kPDashaVOs
                where Map.Planet == nakLord
                select Map).SingleOrDefault<KPDashaVO>().Signi_String;
            short bhavChalitHouse1 = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == nakLord
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            short num1 = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == num
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            KPBLL kPBLL = new KPBLL();
            str = string.Concat(str3, "\r\n");
            str = string.Concat(str, kPBLL.Get_Planet_Nak_Planet_Sublord_Fal(persKV, bhavChalitHouse1, signiString));
            return str;
        }

        public string Get_Sankdi_Pryantardasha_New_Logic(KundliVO persKV, string Online_Result, ProductSettingsVO prod)
        {
            string str = "";
            str = "";
            ProductSettingsVO productSettingsVO = new ProductSettingsVO()
            {
                Online_Result = Online_Result,
                Include = prod.Include,
                Lang = persKV.Language,
                Male = persKV.Male,
                PredFor = 0,
                ShowRef = prod.ShowRef,
                ShowUpay = false,
                ShowUpayCode = false,
                Sno = (long)555,
                Category = "",
                Product = "all",
                Rotate = 1
            };
            List<KPPlanetMappingVO> kPPlanetMappingVOs = new List<KPPlanetMappingVO>();
            List<KPHouseMappingVO> kPHouseMappingVOs = new List<KPHouseMappingVO>();
            List<KPDashaVO> kPDashaVOs = new List<KPDashaVO>();
            List<KPDashaVO> antarDasha = new List<KPDashaVO>();
            List<KPDashaVO> prayatntarDasha = new List<KPDashaVO>();
            this.Process_Planet_Lagan(Online_Result, ref kPPlanetMappingVOs, ref kPHouseMappingVOs, persKV.Rotate, false);
            kPPlanetMappingVOs = this.Process_KPChart_GoodBad(kPPlanetMappingVOs, persKV, productSettingsVO);
            kPDashaVOs = this.Get_Dasha(kPHouseMappingVOs, kPPlanetMappingVOs, persKV, false);
            DateTime date = new DateTime();
            date = DateTime.Now.Date;
            if (DateTime.Now.Date < persKV.Dob)
            {
                date = persKV.Dob;
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
            short num = planet;
            antarDasha = this.Get_Antar_Dasha(startDate, endDate, planet, kPPlanetMappingVOs, false);
            short planet1 = (
                from Map in antarDasha
                where (date < Map.StartDate ? false : date <= Map.EndDate)
                select Map).SingleOrDefault<KPDashaVO>().Planet;
            DateTime dateTime = (
                from Map in antarDasha
                where Map.Planet == planet1
                select Map).SingleOrDefault<KPDashaVO>().StartDate;
            DateTime endDate1 = (
                from Map in antarDasha
                where Map.Planet == planet1
                select Map).SingleOrDefault<KPDashaVO>().EndDate;
            prayatntarDasha = this.Get_Prayatntar_Dasha(antarDasha, dateTime, endDate1, planet, planet1, kPPlanetMappingVOs, false);
            short num1 = (
                from Map in prayatntarDasha
                where (date < Map.StartDate ? false : date <= Map.EndDate)
                select Map).SingleOrDefault<KPDashaVO>().Planet;
            DateTime startDate1 = (
                from Map in prayatntarDasha
                where Map.Planet == num1
                select Map).SingleOrDefault<KPDashaVO>().StartDate;
            DateTime dateTime1 = (
                from Map in prayatntarDasha
                where Map.Planet == num1
                select Map).SingleOrDefault<KPDashaVO>().EndDate;
            PredictionBLL predictionBLL = new PredictionBLL();
            string[] codeLang = new string[] { startDate1.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", startDate1.ToString("%M")), persKV.Language, persKV.Paid, true), " ", startDate1.ToString("yyyy") };
            string str1 = string.Concat(codeLang);
            if (startDate1 < persKV.Dob)
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
                str1 = string.Concat(codeLang);
            }
            codeLang = new string[] { dateTime1.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", dateTime1.ToString("%M")), persKV.Language, persKV.Paid, true), " ", dateTime1.ToString("yyyy") };
            string str2 = string.Concat(codeLang);
            codeLang = new string[] { "<B>", predictionBLL.GetCodeLang("updasha", persKV.Language, persKV.Paid, true), " ", str1, predictionBLL.GetCodeLang("to", persKV.Language, persKV.Paid, true), str2, "</B>\r\n" };
            string str3 = string.Concat(codeLang);
            short nakLord = num1;
            short num2 = planet1;
            short nakLord1 = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == num2
                select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
            short nakLord2 = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == num
                select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
            DateTime startDate2 = (
                from Map in prayatntarDasha
                where Map.Planet == nakLord
                select Map).SingleOrDefault<KPDashaVO>().StartDate;
            DateTime endDate2 = (
                from Map in prayatntarDasha
                where Map.Planet == nakLord
                select Map).SingleOrDefault<KPDashaVO>().EndDate;
            Convert.ToInt16(predictionBLL.CalculateAgeCorrect(persKV.Dob, startDate2));
            KPBLL kPBLL = new KPBLL();
            short bhavChalitHouse = 0;
            string str4 = "";
            short num3 = nakLord;
            short bhavChalitHouse1 = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == num3
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            nakLord = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == nakLord
                select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
            bhavChalitHouse = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == nakLord
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            codeLang = new string[] { (
                from Map in kPDashaVOs
                where Map.Planet == num
                select Map).SingleOrDefault<KPDashaVO>().Signi_String, " ", (
                from Map in antarDasha
                where Map.Planet == num2
                select Map).SingleOrDefault<KPDashaVO>().Signi_String, " ", (
                from Map in prayatntarDasha
                where Map.Planet == num3
                select Map).SingleOrDefault<KPDashaVO>().Signi_String };
            str4 = string.Concat(codeLang);
            short nakLord3 = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == nakLord
                select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
            short bhavChalitHouse2 = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == nakLord
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            short bhavChalitHouse3 = (
                from Map in kPPlanetMappingVOs
                where Map.Planet == nakLord3
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            str = string.Concat(str3, "\r\n");
            str = string.Concat(str, this.Get_Planet_Nak_Planet_Sublord_Fal(persKV, bhavChalitHouse, (
                from Map in prayatntarDasha
                where Map.Planet == nakLord
                select Map).SingleOrDefault<KPDashaVO>().Signi_String));
            return str;
        }

        public string Get_School_Kids(string Online_Result, KundliVO persKV, bool no_occupation, ProductSettingsVO prod)
        {
            string str = "";
            List<KPPlanetMappingVO> kPPlanetMappingVOs = new List<KPPlanetMappingVO>();
            List<KPHouseMappingVO> kPHouseMappingVOs = new List<KPHouseMappingVO>();
            PredictionBLL predictionBLL = new PredictionBLL();
            this.Process_Planet_Lagan(Online_Result, ref kPPlanetMappingVOs, ref kPHouseMappingVOs, persKV.Rotate, true);
            kPPlanetMappingVOs = this.Process_KPChart_GoodBad(kPPlanetMappingVOs, persKV, prod);
            str = string.Concat(str, "<B>", predictionBLL.GetCodeLang("kpeducation", persKV.Language, persKV.Paid, true).ToString(), "</B>\r\n");
            str = string.Concat(str, "<I>", predictionBLL.GetCodeLang("school1", persKV.Language, persKV.Paid, true).ToString(), "</I>\r\n");
            str = string.Concat(str, this.Get_Sublord_Education_Pred(kPHouseMappingVOs, kPPlanetMappingVOs, persKV));
            if (!no_occupation)
            {
                str = string.Concat(str, "<B>", predictionBLL.GetCodeLang("school2", persKV.Language, persKV.Paid, true).ToString(), "</B>");
                str = string.Concat(str, "\r\n", this.Tenth_Kamkaj_Pred(kPHouseMappingVOs, kPPlanetMappingVOs, persKV));
            }
            return str;
        }

        public string Get_Signi_House_String(short house, List<KPHouseMappingVO> cusp_house, bool include)
        {
            string str = "";
            List<KPSigniVO> signi = (
                from Map in cusp_house
                where Map.House == house
                select Map).SingleOrDefault<KPHouseMappingVO>().Signi;
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
            return str;
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

        public string Get_Signi_String_Only_Rashi(short planet, List<KPPlanetMappingVO> kp_chart, bool include)
        {
            string str = "";
            KPSigniVO kPSigniVO = new KPSigniVO();
            List<KPSigniVO> kPSigniVOs = new List<KPSigniVO>();
            kPSigniVOs.AddRange((
                from Map in kp_chart
                where Map.Planet == planet
                select Map).SingleOrDefault<KPPlanetMappingVO>().Signi);
            short rule = 0;
            foreach (KPSigniVO kPSigniVO1 in
                from Map in kPSigniVOs
                orderby Map.Rule
                select Map)
            {
                if (include)
                {
                    if (rule != kPSigniVO1.Rule)
                    {
                        str = string.Concat(str, " ");
                        rule = kPSigniVO1.Rule;
                    }
                    str = string.Concat(str, kPSigniVO1.Signi, " ");
                }
                else if (kPSigniVO1.Rule == 9)
                {
                    if (rule != kPSigniVO1.Rule)
                    {
                        str = string.Concat(str, " ");
                        rule = kPSigniVO1.Rule;
                    }
                    str = string.Concat(str, kPSigniVO1.Signi, " ");
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

        public string Get_Signi_String_Without_NakRashi(short planet, List<KPPlanetMappingVO> kp_chart, bool include)
        {
            string str = "";
            KPSigniVO kPSigniVO = new KPSigniVO();
            List<KPSigniVO> kPSigniVOs = new List<KPSigniVO>();
            kPSigniVO.Rule = 1;
            kPSigniVO.WhichPlanet = 0;
            kPSigniVO.Signi = (
                from Map in kp_chart
                where Map.Planet == planet
                select Map).SingleOrDefault<KPPlanetMappingVO>().House;
            kPSigniVOs.Add(kPSigniVO);
            kPSigniVOs.AddRange((
                from Map in kp_chart
                where Map.Planet == planet
                select Map).SingleOrDefault<KPPlanetMappingVO>().Signi);
            short rule = 0;
            foreach (KPSigniVO kPSigniVO1 in
                from Map in kPSigniVOs
                orderby Map.Rule
                select Map)
            {
                if (include)
                {
                    if (rule != kPSigniVO1.Rule)
                    {
                        str = string.Concat(str, " ");
                        rule = kPSigniVO1.Rule;
                    }
                    str = string.Concat(str, kPSigniVO1.Signi, " ");
                }
                else if ((kPSigniVO1.Rule == 1 || kPSigniVO1.Rule == 8 ? true : kPSigniVO1.Rule == 9))
                {
                    if (rule != kPSigniVO1.Rule)
                    {
                        str = string.Concat(str, " ");
                        rule = kPSigniVO1.Rule;
                    }
                    str = string.Concat(str, kPSigniVO1.Signi, " ");
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

        public string Get_Sublord_Education_Pred(List<KPHouseMappingVO> cusp_house, List<KPPlanetMappingVO> kp_chart, KundliVO persKV)
        {
            string str = "";
            List<KP_Sublord_Pred> kPSublordPreds = new List<KP_Sublord_Pred>();
            KPDAO kPDAO = new KPDAO();
            short subLord = 0;
            PredictionBLL predictionBLL = new PredictionBLL();
            subLord = (
                from Map in cusp_house
                where Map.House == 10
                select Map).SingleOrDefault<KPHouseMappingVO>().Sub_Lord;
            if ((subLord == 8 ? true : subLord == 9))
            {
                subLord = (
                    from Map in kp_chart
                    where Map.Planet == subLord
                    select Map).SingleOrDefault<KPPlanetMappingVO>().Rashi_Lord;
            }
            if (persKV.Language.ToLower() == "hindi")
            {
                str = string.Concat(str, (
                    from Map in kPDAO.Get_KP_Sublord_Pred()
                    where (Map.Sublord != subLord ? false : Map.House == 10)
                    select Map).FirstOrDefault<KP_Sublord_Pred>().Pred_Hindi, "\r\n\r\n");
            }
            if (persKV.Language.ToLower() == "english")
            {
                str = string.Concat(str, (
                    from Map in kPDAO.Get_KP_Sublord_Pred()
                    where (Map.Sublord != subLord ? false : Map.House == 10)
                    select Map).FirstOrDefault<KP_Sublord_Pred>().Pred_English, "\r\n\r\n");
            }
            if (persKV.Language.ToLower() == "tamil")
            {
                str = string.Concat(str, (
                    from Map in kPDAO.Get_KP_Sublord_Pred()
                    where (Map.Sublord != subLord ? false : Map.House == 10)
                    select Map).FirstOrDefault<KP_Sublord_Pred>().pred_tamil, "\r\n\r\n");
            }
            if ((persKV.Language.ToLower() == "bangla" ? true : persKV.Language.Trim().ToLower() == "bengali"))
            {
                str = string.Concat(str, (
                    from Map in kPDAO.Get_KP_Sublord_Pred()
                    where (Map.Sublord != subLord ? false : Map.House == 10)
                    select Map).FirstOrDefault<KP_Sublord_Pred>().pred_bengali, "\r\n\r\n");
            }
            if (persKV.Language.ToLower() == "telugu")
            {
                str = string.Concat(str, (
                    from Map in kPDAO.Get_KP_Sublord_Pred()
                    where (Map.Sublord != subLord ? false : Map.House == 10)
                    select Map).FirstOrDefault<KP_Sublord_Pred>().pred_telugu, "\r\n\r\n");
            }
            if (persKV.Language.ToLower() == "kannada")
            {
                str = string.Concat(str, (
                    from Map in kPDAO.Get_KP_Sublord_Pred()
                    where (Map.Sublord != subLord ? false : Map.House == 10)
                    select Map).FirstOrDefault<KP_Sublord_Pred>().pred_kannada, "\r\n\r\n");
            }
            if (persKV.Language.ToLower() == "marathi")
            {
                str = string.Concat(str, (
                    from Map in kPDAO.Get_KP_Sublord_Pred()
                    where (Map.Sublord != subLord ? false : Map.House == 10)
                    select Map).FirstOrDefault<KP_Sublord_Pred>().pred_marathi, "\r\n\r\n");
            }
            if (persKV.Language.ToLower() == "gujarati")
            {
                str = string.Concat(str, (
                    from Map in kPDAO.Get_KP_Sublord_Pred()
                    where (Map.Sublord != subLord ? false : Map.House == 10)
                    select Map).FirstOrDefault<KP_Sublord_Pred>().pred_gujarati, "\r\n\r\n");
            }
            if (persKV.Language.ToLower() == "punjabi")
            {
                str = string.Concat(str, (
                    from Map in kPDAO.Get_KP_Sublord_Pred()
                    where (Map.Sublord != subLord ? false : Map.House == 10)
                    select Map).FirstOrDefault<KP_Sublord_Pred>().pred_punjabi, "\r\n\r\n");
            }
            if (persKV.Language.ToLower() == "oriya")
            {
                str = string.Concat(str, (
                    from Map in kPDAO.Get_KP_Sublord_Pred()
                    where (Map.Sublord != subLord ? false : Map.House == 10)
                    select Map).FirstOrDefault<KP_Sublord_Pred>().pred_oriya, "\r\n\r\n");
            }
            if (persKV.Language.ToLower() == "malayalam")
            {
                str = string.Concat(str, (
                    from Map in kPDAO.Get_KP_Sublord_Pred()
                    where (Map.Sublord != subLord ? false : Map.House == 10)
                    select Map).FirstOrDefault<KP_Sublord_Pred>().pred_malayalam, "\r\n\r\n");
            }
            if (persKV.Language.ToLower() == "assamese")
            {
                str = string.Concat(str, (
                    from Map in kPDAO.Get_KP_Sublord_Pred()
                    where (Map.Sublord != subLord ? false : Map.House == 10)
                    select Map).FirstOrDefault<KP_Sublord_Pred>().pred_assamese, "\r\n\r\n");
            }
            return str;
        }

        public string Get_Sublord_Pred(List<KPHouseMappingVO> cusp_house, KundliVO persKV)
        {
            string str = "";
            List<KP_Sublord_Pred> kPSublordPreds = new List<KP_Sublord_Pred>();
            KPDAO kPDAO = new KPDAO();
            foreach (KPHouseMappingVO cuspHouse in cusp_house)
            {
                kPSublordPreds.AddRange((
                    from Map in kPDAO.Get_KP_Sublord_Pred()
                    where (Map.Sublord != cuspHouse.Sub_Lord ? false : Map.House == cuspHouse.House)
                    select Map).ToList<KP_Sublord_Pred>());
            }
            foreach (KP_Sublord_Pred kPSublordPred in kPSublordPreds)
            {
                if (persKV.Language.ToLower() == "hindi")
                {
                    str = string.Concat(str, kPSublordPred.Pred_Hindi, "\r\n\r\n");
                }
                if (persKV.Language.ToLower() == "english")
                {
                    str = string.Concat(str, kPSublordPred.Pred_English, "\r\n\r\n");
                }
            }
            return str;
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

        public string Get_Work_Pred_Mahadasha(List<KPHouseMappingVO> cusp_house, List<KPPlanetMappingVO> kp_chart, KundliVO persKV, bool include, bool showupay, bool upay, ProductSettingsVO prod, bool current_mahadasha)
        {
            string str = "";
            string str1 = "";
            PredictionBLL predictionBLL = new PredictionBLL();
            List<KPDashaVO> kPDashaVOs = new List<KPDashaVO>();
            List<KPDashafalChainVO> kPDashafalChainVOs = new List<KPDashafalChainVO>();
            KPDAO kPDAO = new KPDAO();
            kPDashaVOs = this.Get_Dasha(cusp_house, kp_chart, persKV, include);
            DateTime date = DateTime.Now.Date;
            short house = 0;
            string signiStringWithoutNakRashi = "";
            foreach (KPDashaVO kPDashaVO in kPDashaVOs)
            {
                DateTime startDate = kPDashaVO.StartDate;
                DateTime endDate = kPDashaVO.EndDate;
                short num = Convert.ToInt16(predictionBLL.CalculateAgeCorrect(persKV.Dob, startDate));
                Convert.ToInt16(predictionBLL.CalculateAgeCorrect(persKV.Dob, endDate));
                short house1 = kp_chart.Where(Map => Map.Planet == kPDashaVO.Planet).SingleOrDefault<KPPlanetMappingVO>().House;
                this.Get_Signi_String_Without_NakRashi(kPDashaVO.Planet, kp_chart, include);
                if (num <= 0)
                {
                    num = 1;
                }
                string[] codeLang = new string[] { startDate.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", startDate.ToString("%M")), persKV.Language, persKV.Paid, true), " ", startDate.ToString("yyyy") };
                string str2 = string.Concat(codeLang);
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
                    str2 = string.Concat(codeLang);
                }
                codeLang = new string[] { endDate.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", endDate.ToString("%M")), persKV.Language, persKV.Paid, true), " ", endDate.ToString("yyyy") };
                string str3 = string.Concat(codeLang);
                codeLang = new string[] { "\r\n\r\n <B>", str2, predictionBLL.GetCodeLang("to", persKV.Language, persKV.Paid, true), str3, "</B>\r\n" };
                string str4 = string.Concat(codeLang);
                house = kp_chart.Where(Map => Map.Planet == kPDashaVO.Planet).SingleOrDefault<KPPlanetMappingVO>().House;
                signiStringWithoutNakRashi = this.Get_Signi_String_Without_NakRashi(kPDashaVO.Planet, kp_chart, false);
                this.prev_mix_all_fal = new List<short>();
                if (num <= 72)
                {
                    if ((prod.Product == "YICCCOMBO4" || prod.Product == "YICCCOMBO7" || prod.Product == "YICCCOMBO1" || prod.Product == "YICCCOMBO2" || prod.Product == "YICCCOMBO5" || prod.Product == "YICCCOMBO10" || prod.Product == "YICCCOMBO25" ? true : prod.Product == "occupation"))
                    {
                        if ((num < 10 ? false : num <= 60))
                        {
                            string product = prod.Product;
                            prod.Product = "work_pred";
                            str1 = string.Concat(str1, this.Get_Mix_Fal(kPDashaVO.Planet, kp_chart, cusp_house, persKV, prod, num, true, false, "dasha", startDate, endDate));
                            prod.Product = product;
                        }
                    }
                    if (str1.Trim().Length > 50)
                    {
                        str = string.Concat(str, str4, str1);
                    }
                    str1 = "";
                }
                else
                {
                    break;
                }
            }
            return str;
        }

        public string GetFree(string stt, short predfor, string lang, bool male, short sno, bool brief, short age, bool include, bool onlymahadasha, bool showref, ProductSettingsVO prod)
        {
            short nakLord;
            DateTime now;
            PredictionBLL predictionBLL = new PredictionBLL();
            string str = "";
            string str1 = "";
            KundliBLL kundliBLL = new KundliBLL();
            str1 = kundliBLL.Gen_Kunda(stt, 500f, prod.Rotate);
            KundliVO kundliVO = new KundliVO();
            PredictionBLL predictionBLL1 = new PredictionBLL();
            PredictionBLL predictionBLL2 = new PredictionBLL();
            kundliVO.FileCode = sno.ToString();
            char[] chrArray = new char[] { ',' };
            string[] strArrays = stt.Split(chrArray);
            List<KundliMappingVO> kundliMappingVOs = new List<KundliMappingVO>();
            string str2 = strArrays[2];
            string str3 = strArrays[3];
            chrArray = new char[] { 'E' };
            str2 = str2.TrimEnd(chrArray);
            chrArray = new char[] { 'N' };
            str2 = str2.TrimEnd(chrArray);
            chrArray = new char[] { 'S' };
            str2 = str2.TrimEnd(chrArray);
            chrArray = new char[] { 'W' };
            str2 = str2.TrimEnd(chrArray);
            chrArray = new char[] { 'E' };
            str3 = str3.TrimEnd(chrArray);
            chrArray = new char[] { 'N' };
            str3 = str3.TrimEnd(chrArray);
            chrArray = new char[] { 'S' };
            str3 = str3.TrimEnd(chrArray);
            chrArray = new char[] { 'W' };
            str3 = str3.TrimEnd(chrArray);
            string str4 = strArrays[0];
            chrArray = new char[] { '/' };
            string str5 = str4.Split(chrArray)[0];
            string str6 = strArrays[0];
            chrArray = new char[] { '/' };
            string str7 = str6.Split(chrArray)[1];
            string str8 = strArrays[0];
            chrArray = new char[] { '/' };
            string str9 = str8.Split(chrArray)[2];
            string str10 = strArrays[1];
            chrArray = new char[] { ':' };
            string str11 = str10.Split(chrArray)[0];
            string str12 = strArrays[1];
            chrArray = new char[] { ':' };
            kundliVO = predictionBLL1.map_persKV(str1, "", "", str5, str7, str9, str11, str12.Split(chrArray)[1], "00", "admin", str2, str3, strArrays[4], true, lang, showref, male, "YYYY", "YYYY", "YYYY", "YYYY", "YYYY", "Free", "01", "01", "2000", 1);
            kundliVO.FileCode = sno.ToString();
            kundliMappingVOs = predictionBLL2.map_kundali(str1, true);
            List<KPPlanetMappingVO> kPPlanetMappingVOs = new List<KPPlanetMappingVO>();
            List<KPHouseMappingVO> kPHouseMappingVOs = new List<KPHouseMappingVO>();
            this.Process_Planet_Lagan(str1, ref kPPlanetMappingVOs, ref kPHouseMappingVOs, kundliVO.Rotate, false);
            kPPlanetMappingVOs = this.Process_KPChart_GoodBad(kPPlanetMappingVOs, kundliVO, prod);
            if (!onlymahadasha)
            {
                if (brief)
                {
                    str = string.Concat(str, predictionBLL.GetCodeLang("kpheading", kundliVO.Language, true, true), "\r\n\r\n");
                    foreach (KPHouseMappingVO list in kPHouseMappingVOs.Where(Map => Map.House == 1 || Map.House == 3 || Map.House == 6 || Map.House == 7 || Map.House == 8 || Map.House == 9 ? true : Map.House == 12).ToList<KPHouseMappingVO>())
                    {
                        nakLord = kPPlanetMappingVOs.Where(Map => Map.Planet == list.Sub_Lord).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
                        string signiString = this.Get_Signi_String(nakLord, kPPlanetMappingVOs, false);
                        DateTime dob = kundliVO.Dob;
                        now = DateTime.Now;
                        str = string.Concat(str, this.Get_Chain_Free(signiString, dob, now.Date, kundliVO));
                    }
                    str = string.Concat(str, this.Get_Cusp_Pred(kPHouseMappingVOs, kPPlanetMappingVOs, kundliVO, false, showref, true));
                }
                if (!brief)
                {
                    str = string.Concat(this.Get_School_Kids(str1, kundliVO, true, prod), "\r\n\r\n");
                    str = string.Concat(str, predictionBLL.GetCodeLang("kpgeneral", kundliVO.Language, true, true), "\r\n\r\n");
                    str = string.Concat(str, this.Get_Dashafal_Age_Wise(kPPlanetMappingVOs, kPHouseMappingVOs, kundliVO, include, age, prod, true));
                    str = string.Concat(str, predictionBLL.GetCodeLang("kpheading", kundliVO.Language, true, true), "\r\n\r\n");
                    foreach (KPHouseMappingVO kPHouseMappingVO in kPHouseMappingVOs.Where(Map => Map.House == 1 || Map.House == 3 || Map.House == 6 || Map.House == 7 || Map.House == 8 || Map.House == 9 ? true : Map.House == 12).ToList<KPHouseMappingVO>())
                    {
                        nakLord = kPPlanetMappingVOs.Where(Map => Map.Planet == kPHouseMappingVO.Sub_Lord).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
                        string signiString1 = this.Get_Signi_String(nakLord, kPPlanetMappingVOs, false);
                        DateTime dateTime = kundliVO.Dob;
                        now = DateTime.Now;
                        str = string.Concat(str, this.Get_Chain_Free(signiString1, dateTime, now.Date, kundliVO));
                    }
                    str = string.Concat(str, "\r\n");
                    str = string.Concat(str, this.Get_Cusp_Pred(kPHouseMappingVOs, kPPlanetMappingVOs, kundliVO, false, showref, true));
                }
            }
            if (onlymahadasha)
            {
                str = string.Concat(str, this.Get_Only_Mahadasha(kPHouseMappingVOs, kPPlanetMappingVOs, kundliVO, include, true, true, prod, true));
            }
            return str;
        }

        public List<string> Ham_Saath_Planet(short planet, List<KPPlanetMappingVO> kp_chart)
        {
            List<string> strs = new List<string>();
            short bhavChalitHouse = (
                from Map in kp_chart
                where Map.Planet == planet
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            foreach (KPPlanetMappingVO kPPlanetMappingVO in
                from Map in kp_chart
                where Map.Bhav_Chalit_House == bhavChalitHouse
                select Map)
            {
                strs.Add(kPPlanetMappingVO.Planet.ToString());
            }
            return strs;
        }

        public short Is_Mangal_Bad(List<KPPlanetMappingVO> lkmv)
        {
            bool flag;
            bool flag1;
            Func<KPPlanetMappingVO, bool> func = null;
            Func<KPPlanetMappingVO, bool> planet = null;
            Func<KPPlanetMappingVO, bool> planet1 = null;
            Func<KPPlanetMappingVO, bool> func1 = null;
            Func<KPPlanetMappingVO, bool> planet2 = null;
            Func<KPPlanetMappingVO, bool> func2 = null;
            Func<KPPlanetMappingVO, bool> planet3 = null;
            Func<KPPlanetMappingVO, bool> func3 = null;
            Func<KPPlanetMappingVO, bool> planet4 = null;
            Convert.ToInt16(lkmv.Count<KPPlanetMappingVO>((KPPlanetMappingVO Map) => Map.Bhav_Chalit_House == 1));
            Convert.ToInt16(lkmv.Count<KPPlanetMappingVO>((KPPlanetMappingVO Map) => Map.Bhav_Chalit_House == 2));
            Convert.ToInt16(lkmv.Count<KPPlanetMappingVO>((KPPlanetMappingVO Map) => Map.Bhav_Chalit_House == 3));
            Convert.ToInt16(lkmv.Count<KPPlanetMappingVO>((KPPlanetMappingVO Map) => Map.Bhav_Chalit_House == 4));
            Convert.ToInt16(lkmv.Count<KPPlanetMappingVO>((KPPlanetMappingVO Map) => Map.Bhav_Chalit_House == 5));
            Convert.ToInt16(lkmv.Count<KPPlanetMappingVO>((KPPlanetMappingVO Map) => Map.Bhav_Chalit_House == 6));
            Convert.ToInt16(lkmv.Count<KPPlanetMappingVO>((KPPlanetMappingVO Map) => Map.Bhav_Chalit_House == 7));
            Convert.ToInt16(lkmv.Count<KPPlanetMappingVO>((KPPlanetMappingVO Map) => Map.Bhav_Chalit_House == 8));
            Convert.ToInt16(lkmv.Count<KPPlanetMappingVO>((KPPlanetMappingVO Map) => Map.Bhav_Chalit_House == 9));
            Convert.ToInt16(lkmv.Count<KPPlanetMappingVO>((KPPlanetMappingVO Map) => Map.Bhav_Chalit_House == 10));
            Convert.ToInt16(lkmv.Count<KPPlanetMappingVO>((KPPlanetMappingVO Map) => Map.Bhav_Chalit_House == 11));
            Convert.ToInt16(lkmv.Count<KPPlanetMappingVO>((KPPlanetMappingVO Map) => Map.Bhav_Chalit_House == 12));
            short num = Convert.ToInt16(lkmv.Count<KPPlanetMappingVO>((KPPlanetMappingVO Map) =>
            {
                short bhavChalitHouse = Map.Bhav_Chalit_House;
                List<KPPlanetMappingVO> kPPlanetMappingVOs = lkmv;
                if (func == null)
                {
                    func = (KPPlanetMappingVO Map1) => Map1.Planet == 1;
                }
                return bhavChalitHouse == kPPlanetMappingVOs.Where<KPPlanetMappingVO>(func).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            }));
            Convert.ToInt16(lkmv.Count<KPPlanetMappingVO>((KPPlanetMappingVO Map) =>
            {
                short bhavChalitHouse = Map.Bhav_Chalit_House;
                List<KPPlanetMappingVO> kPPlanetMappingVOs = lkmv;
                if (planet == null)
                {
                    planet = (KPPlanetMappingVO Map1) => Map1.Planet == 2;
                }
                return bhavChalitHouse == kPPlanetMappingVOs.Where<KPPlanetMappingVO>(planet).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            }));
            Convert.ToInt16(lkmv.Count<KPPlanetMappingVO>((KPPlanetMappingVO Map) =>
            {
                short bhavChalitHouse = Map.Bhav_Chalit_House;
                List<KPPlanetMappingVO> kPPlanetMappingVOs = lkmv;
                if (planet1 == null)
                {
                    planet1 = (KPPlanetMappingVO Map1) => Map1.Planet == 3;
                }
                return bhavChalitHouse == kPPlanetMappingVOs.Where<KPPlanetMappingVO>(planet1).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            }));
            short num1 = Convert.ToInt16(lkmv.Count<KPPlanetMappingVO>((KPPlanetMappingVO Map) =>
            {
                short bhavChalitHouse = Map.Bhav_Chalit_House;
                List<KPPlanetMappingVO> kPPlanetMappingVOs = lkmv;
                if (func1 == null)
                {
                    func1 = (KPPlanetMappingVO Map1) => Map1.Planet == 4;
                }
                return bhavChalitHouse == kPPlanetMappingVOs.Where<KPPlanetMappingVO>(func1).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            }));
            Convert.ToInt16(lkmv.Count<KPPlanetMappingVO>((KPPlanetMappingVO Map) =>
            {
                short bhavChalitHouse = Map.Bhav_Chalit_House;
                List<KPPlanetMappingVO> kPPlanetMappingVOs = lkmv;
                if (planet2 == null)
                {
                    planet2 = (KPPlanetMappingVO Map1) => Map1.Planet == 5;
                }
                return bhavChalitHouse == kPPlanetMappingVOs.Where<KPPlanetMappingVO>(planet2).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            }));
            short num2 = Convert.ToInt16(lkmv.Count<KPPlanetMappingVO>((KPPlanetMappingVO Map) =>
            {
                short bhavChalitHouse = Map.Bhav_Chalit_House;
                List<KPPlanetMappingVO> kPPlanetMappingVOs = lkmv;
                if (func2 == null)
                {
                    func2 = (KPPlanetMappingVO Map1) => Map1.Planet == 6;
                }
                return bhavChalitHouse == kPPlanetMappingVOs.Where<KPPlanetMappingVO>(func2).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            }));
            Convert.ToInt16(lkmv.Count<KPPlanetMappingVO>((KPPlanetMappingVO Map) =>
            {
                short bhavChalitHouse = Map.Bhav_Chalit_House;
                List<KPPlanetMappingVO> kPPlanetMappingVOs = lkmv;
                if (planet3 == null)
                {
                    planet3 = (KPPlanetMappingVO Map1) => Map1.Planet == 7;
                }
                return bhavChalitHouse == kPPlanetMappingVOs.Where<KPPlanetMappingVO>(planet3).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            }));
            Convert.ToInt16(lkmv.Count<KPPlanetMappingVO>((KPPlanetMappingVO Map) =>
            {
                short bhavChalitHouse = Map.Bhav_Chalit_House;
                List<KPPlanetMappingVO> kPPlanetMappingVOs = lkmv;
                if (func3 == null)
                {
                    func3 = (KPPlanetMappingVO Map1) => Map1.Planet == 8;
                }
                return bhavChalitHouse == kPPlanetMappingVOs.Where<KPPlanetMappingVO>(func3).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            }));
            Convert.ToInt16(lkmv.Count<KPPlanetMappingVO>((KPPlanetMappingVO Map) =>
            {
                short bhavChalitHouse = Map.Bhav_Chalit_House;
                List<KPPlanetMappingVO> kPPlanetMappingVOs = lkmv;
                if (planet4 == null)
                {
                    planet4 = (KPPlanetMappingVO Map1) => Map1.Planet == 9;
                }
                return bhavChalitHouse == kPPlanetMappingVOs.Where<KPPlanetMappingVO>(planet4).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            }));
            short num3 = 0;
            short num4 = Convert.ToInt16((
                from Map in lkmv
                where Map.Planet == 3
                select Map.House).SingleOrDefault<short>());
            short num5 = Convert.ToInt16((
                from Map in lkmv
                where Map.Planet == 1
                select Map.House).SingleOrDefault<short>());
            short num6 = Convert.ToInt16((
                from Map in lkmv
                where Map.Planet == 7
                select Map.House).SingleOrDefault<short>());
            short num7 = Convert.ToInt16((
                from Map in lkmv
                where Map.Planet == 2
                select Map.House).SingleOrDefault<short>());
            short num8 = Convert.ToInt16((
                from Map in lkmv
                where Map.Planet == 6
                select Map.House).SingleOrDefault<short>());
            short num9 = Convert.ToInt16((
                from Map in lkmv
                where Map.Planet == 4
                select Map.House).SingleOrDefault<short>());
            Convert.ToInt16((
                from Map in lkmv
                where Map.Planet == 8
                select Map.House).SingleOrDefault<short>());
            Convert.ToInt16((
                from Map in lkmv
                where Map.Planet == 9
                select Map.House).SingleOrDefault<short>());
            Convert.ToInt16((
                from Map in lkmv
                where Map.Planet == 5
                select Map.House).SingleOrDefault<short>());
            bool flag2 = (
                from Map in lkmv
                where Map.Planet == 7
                select Map).SingleOrDefault<KPPlanetMappingVO>().isbad;
            if ((num5 != num6 ? false : num == 2))
            {
                num3 = 2;
            }
            if (num4 != 8)
            {
                flag = true;
            }
            else
            {
                flag = (num6 == 1 || num6 == 2 ? !flag2 : true);
            }
            if (!flag)
            {
                num3 = 2;
            }
            if ((num8 != num9 ? false : num1 == 2))
            {
                num3 = 2;
            }
            if ((num8 != 9 ? false : num2 == 1))
            {
                num3 = 2;
            }
            if (Convert.ToInt16((
                from Map in lkmv
                where Map.House == num5
                select Map).Count<KPPlanetMappingVO>()) != 1)
            {
                flag1 = true;
            }
            else
            {
                flag1 = (num5 == 6 || num5 == 7 || num5 == 10 ? false : num5 != 12);
            }
            if (!flag1)
            {
                num3 = 2;
            }
            if ((num9 != num4 ? false : num9 != 8))
            {
                num3 = 2;
            }
            if ((num7 == 1 || num7 == 3 || num7 == 4 || num7 == 8 ? true : num7 == 9))
            {
                num3 = Convert.ToInt16(num3 != 2 ? 1 : 3);
            }
            if (num5 == num9)
            {
                num3 = 1;
            }
            if ((Convert.ToInt16((
                from Map in lkmv
                where Map.House == num5
                select Map).Count<KPPlanetMappingVO>()) != 1 ? false : num5 == 3))
            {
                num3 = 1;
            }
            return num3;
        }

        public bool Is_Mangal_Badh_New(List<KPPlanetMappingVO> kp_chart)
        {
            bool flag = false;
            short bhavChalitHouseNew = (
                from Map in kp_chart
                where Map.Planet == 1
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House_New;
            short num = (
                from Map in kp_chart
                where Map.Planet == 2
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House_New;
            short bhavChalitHouseNew1 = (
                from Map in kp_chart
                where Map.Planet == 3
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House_New;
            short num1 = (
                from Map in kp_chart
                where Map.Planet == 4
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House_New;
            short bhavChalitHouseNew2 = (
                from Map in kp_chart
                where Map.Planet == 5
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House_New;
            short num2 = (
                from Map in kp_chart
                where Map.Planet == 6
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House_New;
            short bhavChalitHouseNew3 = (
                from Map in kp_chart
                where Map.Planet == 7
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House_New;
            short num3 = (
                from Map in kp_chart
                where Map.Planet == 8
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House_New;
            short bhavChalitHouseNew4 = (
                from Map in kp_chart
                where Map.Planet == 9
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House_New;
            Convert.ToInt16(kp_chart.Count<KPPlanetMappingVO>((KPPlanetMappingVO Map) => Map.Bhav_Chalit_House == 1));
            Convert.ToInt16(kp_chart.Count<KPPlanetMappingVO>((KPPlanetMappingVO Map) => Map.Bhav_Chalit_House == 2));
            Convert.ToInt16(kp_chart.Count<KPPlanetMappingVO>((KPPlanetMappingVO Map) => Map.Bhav_Chalit_House == 3));
            Convert.ToInt16(kp_chart.Count<KPPlanetMappingVO>((KPPlanetMappingVO Map) => Map.Bhav_Chalit_House == 4));
            Convert.ToInt16(kp_chart.Count<KPPlanetMappingVO>((KPPlanetMappingVO Map) => Map.Bhav_Chalit_House == 5));
            Convert.ToInt16(kp_chart.Count<KPPlanetMappingVO>((KPPlanetMappingVO Map) => Map.Bhav_Chalit_House == 6));
            Convert.ToInt16(kp_chart.Count<KPPlanetMappingVO>((KPPlanetMappingVO Map) => Map.Bhav_Chalit_House == 7));
            Convert.ToInt16(kp_chart.Count<KPPlanetMappingVO>((KPPlanetMappingVO Map) => Map.Bhav_Chalit_House == 8));
            Convert.ToInt16(kp_chart.Count<KPPlanetMappingVO>((KPPlanetMappingVO Map) => Map.Bhav_Chalit_House == 9));
            Convert.ToInt16(kp_chart.Count<KPPlanetMappingVO>((KPPlanetMappingVO Map) => Map.Bhav_Chalit_House == 10));
            Convert.ToInt16(kp_chart.Count<KPPlanetMappingVO>((KPPlanetMappingVO Map) => Map.Bhav_Chalit_House == 11));
            Convert.ToInt16(kp_chart.Count<KPPlanetMappingVO>((KPPlanetMappingVO Map) => Map.Bhav_Chalit_House == 12));
            if (bhavChalitHouseNew == bhavChalitHouseNew3)
            {
                flag = true;
            }
            if ((num2 != num1 ? false : Convert.ToInt16((
                from Map in kp_chart
                where Map.House == num2
                select Map).Count<KPPlanetMappingVO>()) == 2))
            {
                flag = true;
            }
            if ((num2 != num1 || num2 != bhavChalitHouseNew1 ? false : Convert.ToInt16((
                from Map in kp_chart
                where Map.House == num2
                select Map).Count<KPPlanetMappingVO>()) == 3))
            {
                flag = true;
            }
            if ((num2 != 9 ? false : Convert.ToInt16((
                from Map in kp_chart
                where Map.House == num2
                select Map).Count<KPPlanetMappingVO>()) == 1))
            {
                flag = true;
            }
            if ((bhavChalitHouseNew == 6 || bhavChalitHouseNew == 7 || bhavChalitHouseNew == 10 || bhavChalitHouseNew == 12 ? Convert.ToInt16((
                from Map in kp_chart
                where Map.House == bhavChalitHouseNew
                select Map).Count<KPPlanetMappingVO>()) == 1 : false))
            {
                flag = true;
            }
            if ((num3 == 5 || num3 == 9 ? kp_chart[7].isbad : false))
            {
                flag = true;
            }
            if ((bhavChalitHouseNew4 == 5 || bhavChalitHouseNew4 == 9 ? kp_chart[7].isbad : false))
            {
                flag = true;
            }
            if ((num2 != bhavChalitHouseNew1 || num2 != num1 ? false : Convert.ToInt16((
                from Map in kp_chart
                where Map.House == num2
                select Map).Count<KPPlanetMappingVO>()) == 3))
            {
                flag = true;
            }
            if ((bhavChalitHouseNew1 == 4 || bhavChalitHouseNew1 == 8 ? bhavChalitHouseNew3 == 9 : false))
            {
                flag = true;
            }
            return flag;
        }

        public bool isAllConditionMet(KPMixDashaVO mix, List<KPPlanetMappingVO> kp_chart, string houses, string ptype)
        {
            bool flag;
            bool flag1 = false;
            if (!(mix.ptype == "khabar"))
            {
                if (ptype == "work_pred")
                {
                    List<KPPlanetMappingVO> kPPlanetMappingVOs = new List<KPPlanetMappingVO>();
                    foreach (KPPlanetMappingVO kpChart in kp_chart)
                    {
                        kpChart.House = kpChart.Bhav_Chalit_House;
                        kPPlanetMappingVOs.Add(kpChart);
                    }
                    kp_chart = kPPlanetMappingVOs;
                }
                if ((!(mix.ptype != "fulltriangle") || !(mix.ptype != "yuti") || !(mix.ptype != "multi") || !(mix.ptype != "fullyuti") || !(mix.lawtype != "triangle") || !(mix.lawtype != "ulta") || !(mix.lawtype != "chokor") || !(mix.lawtype != "drishti") ? false : mix.lawtype != "takrao"))
                {
                    if (this.isPlanetHousePass(mix, kp_chart))
                    {
                        if (!(!this.isEmptyPass(mix.empty, kp_chart) || !this.isNotEmptyPass(mix.not_empty, kp_chart) || !this.isShubhPass(mix.shubh, kp_chart) ? false : this.isAshubhPass(mix.ashubh, kp_chart)))
                        {
                            flag = false;
                            return flag;
                        }
                        else if (!(!this.isAndPlanetPass(mix.andplanet, kp_chart) || !this.isNotAndPlanetPass(mix.not_andplanet, kp_chart) || !this.isOrPlanetPass(mix.orplanet, kp_chart) ? false : this.isNotOrPlanetPass(mix.not_orplanet, kp_chart)))
                        {
                            flag = false;
                            return flag;
                        }
                        else if (!(!this.isConjPass(mix.conj, mix.Planet1, kp_chart) ? false : this.isNotConjPass(mix.not_conj, mix.Planet1, kp_chart)))
                        {
                            flag = false;
                            return flag;
                        }
                        else if ((!this.isDrishtiPass(mix.drishti, mix.Planet1, kp_chart) ? false : this.isNotDrishtiPass(mix.not_drishti, mix.Planet1, kp_chart)))
                        {
                            if (mix.lawtype == "mangalbad")
                            {
                                if (!this.Is_Mangal_Badh_New(kp_chart))
                                {
                                    flag = false;
                                    return flag;
                                }
                            }
                            flag1 = true;
                        }
                        else
                        {
                            flag = false;
                            return flag;
                        }
                    }
                }
                if ((mix.lawtype == "yuti" ? true : mix.ptype == "yuti"))
                {
                    if (!(!this.isEmptyPass(mix.empty, kp_chart) || !this.isShubhPass(mix.shubh, kp_chart) ? false : this.isAshubhPass(mix.ashubh, kp_chart)))
                    {
                        flag = false;
                        return flag;
                    }
                    else if (!(!this.isAndPlanetPass(mix.andplanet, kp_chart) || !this.isNotAndPlanetPass(mix.not_andplanet, kp_chart) || !this.isOrPlanetPass(mix.orplanet, kp_chart) ? false : this.isNotOrPlanetPass(mix.not_orplanet, kp_chart)))
                    {
                        flag = false;
                        return flag;
                    }
                    else if (!(!this.isConjPass(mix.conj, mix.Planet1, kp_chart) ? false : this.isNotConjPass(mix.not_conj, mix.Planet1, kp_chart)))
                    {
                        flag = false;
                        return flag;
                    }
                    else if ((!this.isDrishtiPass(mix.drishti, mix.Planet1, kp_chart) ? false : this.isNotDrishtiPass(mix.not_drishti, mix.Planet1, kp_chart)))
                    {
                        if (!this.isYutiPass(mix, kp_chart))
                        {
                            flag = false;
                            return flag;
                        }
                        flag1 = true;
                    }
                    else
                    {
                        flag = false;
                        return flag;
                    }
                }
                if ((mix.lawtype == "triangle" || mix.lawtype == "ulta" || mix.lawtype == "chokor" || mix.lawtype == "drishti" ? true : mix.lawtype == "takrao"))
                {
                    if (!(!this.isEmptyPass(mix.empty, kp_chart) || !this.isShubhPass(mix.shubh, kp_chart) ? false : this.isAshubhPass(mix.ashubh, kp_chart)))
                    {
                        flag = false;
                        return flag;
                    }
                    else if (!(!this.isAndPlanetPass(mix.andplanet, kp_chart) || !this.isNotAndPlanetPass(mix.not_andplanet, kp_chart) || !this.isOrPlanetPass(mix.orplanet, kp_chart) ? false : this.isNotOrPlanetPass(mix.not_orplanet, kp_chart)))
                    {
                        flag = false;
                        return flag;
                    }
                    else if (!(!this.isConjPass(mix.conj, mix.Planet1, kp_chart) ? false : this.isNotConjPass(mix.not_conj, mix.Planet1, kp_chart)))
                    {
                        flag = false;
                        return flag;
                    }
                    else if ((!this.isDrishtiPass(mix.drishti, mix.Planet1, kp_chart) ? false : this.isNotDrishtiPass(mix.not_drishti, mix.Planet1, kp_chart)))
                    {
                        if (!this.isTrianglePass(mix, kp_chart))
                        {
                            flag = false;
                            return flag;
                        }
                        flag1 = true;
                    }
                    else
                    {
                        flag = false;
                        return flag;
                    }
                }
                if (mix.ptype == "fulltriangle")
                {
                    if (!(!this.isEmptyPass(mix.empty, kp_chart) || !this.isShubhPass(mix.shubh, kp_chart) ? false : this.isAshubhPass(mix.ashubh, kp_chart)))
                    {
                        flag = false;
                        return flag;
                    }
                    else if (!(!this.isAndPlanetPass(mix.andplanet, kp_chart) || !this.isNotAndPlanetPass(mix.not_andplanet, kp_chart) || !this.isOrPlanetPass(mix.orplanet, kp_chart) ? false : this.isNotOrPlanetPass(mix.not_orplanet, kp_chart)))
                    {
                        flag = false;
                        return flag;
                    }
                    else if (!(!this.isConjPass(mix.conj, mix.Planet1, kp_chart) ? false : this.isNotConjPass(mix.not_conj, mix.Planet1, kp_chart)))
                    {
                        flag = false;
                        return flag;
                    }
                    else if ((!this.isDrishtiPass(mix.drishti, mix.Planet1, kp_chart) ? false : this.isNotDrishtiPass(mix.not_drishti, mix.Planet1, kp_chart)))
                    {
                        if (!this.isTrianglePass(mix, kp_chart))
                        {
                            flag = false;
                            return flag;
                        }
                        flag1 = true;
                    }
                    else
                    {
                        flag = false;
                        return flag;
                    }
                }
                if (mix.ptype == "fullyuti")
                {
                    if (!this.isPlanetHousePass(mix, kp_chart))
                    {
                        flag = false;
                        return flag;
                    }
                    else if (!(!this.isEmptyPass(mix.empty, kp_chart) || !this.isShubhPass(mix.shubh, kp_chart) ? false : this.isAshubhPass(mix.ashubh, kp_chart)))
                    {
                        flag = false;
                        return flag;
                    }
                    else if (!(!this.isAndPlanetPass(mix.andplanet, kp_chart) || !this.isNotAndPlanetPass(mix.not_andplanet, kp_chart) || !this.isOrPlanetPass(mix.orplanet, kp_chart) ? false : this.isNotOrPlanetPass(mix.not_orplanet, kp_chart)))
                    {
                        flag = false;
                        return flag;
                    }
                    else if (!(!this.isConjPass(mix.conj, mix.Planet1, kp_chart) ? false : this.isNotConjPass(mix.not_conj, mix.Planet1, kp_chart)))
                    {
                        flag = false;
                        return flag;
                    }
                    else if ((!this.isDrishtiPass(mix.drishti, mix.Planet1, kp_chart) ? false : this.isNotDrishtiPass(mix.not_drishti, mix.Planet1, kp_chart)))
                    {
                        if (!this.isFullYutiPass(mix, kp_chart))
                        {
                            flag = false;
                            return flag;
                        }
                        flag1 = true;
                    }
                    else
                    {
                        flag = false;
                        return flag;
                    }
                }
                flag = flag1;
            }
            else
            {
                flag = true;
            }
            return flag;
        }

        public bool isAndPlanetPass(string hashvalue, List<KPPlanetMappingVO> kp_chart)
        {
            bool flag;
            bool flag1 = true;
            if ((hashvalue.Trim().Length <= 0 ? false : !(hashvalue.Trim() == "0")))
            {
                char[] chrArray = new char[] { ',' };
                string[] strArrays = hashvalue.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                int num = 0;
                while (num < (int)strArrays.Length)
                {
                    string str = strArrays[num];
                    chrArray = new char[] { '#' };
                    string[] strArrays1 = str.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                    if ((
                        from Map in kp_chart
                        where (Map.Planet != Convert.ToInt16(strArrays1[0]) ? false : Map.House == Convert.ToInt16(strArrays1[1]))
                        select Map).ToList<KPPlanetMappingVO>().Count != 0)
                    {
                        num++;
                    }
                    else
                    {
                        flag = false;
                        return flag;
                    }
                }
                flag = flag1;
            }
            else
            {
                flag = true;
            }
            return flag;
        }

        public bool isAshubhPass(string ashubh, List<KPPlanetMappingVO> kp_chart)
        {
            bool flag;
            bool flag1 = true;
            if ((ashubh.Trim().Length <= 0 ? false : !(ashubh.Trim() == "0")))
            {
                char[] chrArray = new char[] { ',' };
                string[] strArrays = ashubh.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                int num = 0;
                while (num < (int)strArrays.Length)
                {
                    string str = strArrays[num];
                    if ((
                        from Map in kp_chart
                        where Map.Planet == Convert.ToInt16(str)
                        select Map).ToList<KPPlanetMappingVO>().SingleOrDefault<KPPlanetMappingVO>().isbad)
                    {
                        num++;
                    }
                    else
                    {
                        flag = false;
                        return flag;
                    }
                }
                flag = flag1;
            }
            else
            {
                flag = true;
            }
            return flag;
        }

        public bool isConjPass(string conj, short planet, List<KPPlanetMappingVO> kp_chart)
        {
            bool flag;
            bool flag1 = true;
            bool flag2 = false;
            if ((conj.Trim().Length <= 0 ? false : !(conj.Trim() == "0")))
            {
                char[] chrArray = new char[] { ',' };
                string[] strArrays = conj.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < (int)strArrays.Length; i++)
                {
                    string str = strArrays[i];
                    short house = (
                        from Map in kp_chart
                        where Map.Planet == Convert.ToInt16(str)
                        select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                    short num = (
                        from Map in kp_chart
                        where Map.Planet == planet
                        select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                    if ((!this.isDrishti(Convert.ToInt16(str), planet, kp_chart) ? false : this.isDrishti(planet, Convert.ToInt16(str), kp_chart)))
                    {
                        flag1 = false;
                    }
                    if (house == num)
                    {
                        flag2 = true;
                    }
                }
                if (flag2)
                {
                    flag1 = true;
                }
                flag = flag1;
            }
            else
            {
                flag = true;
            }
            return flag;
        }

        public bool isDrishti(short planet1, short planet2, List<KPPlanetMappingVO> kp_chart)
        {
            bool flag;
            bool flag1 = false;
            if ((
                from Map in kp_chart
                where Map.Planet == planet2
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House != 8)
            {
                short bhavChalitHouse = (
                    from Map in kp_chart
                    where Map.Planet == 1
                    select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
                short num = (
                    from Map in kp_chart
                    where Map.Planet == 2
                    select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
                short bhavChalitHouse1 = (
                    from Map in kp_chart
                    where Map.Planet == 3
                    select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
                short num1 = (
                    from Map in kp_chart
                    where Map.Planet == 4
                    select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
                short bhavChalitHouse2 = (
                    from Map in kp_chart
                    where Map.Planet == 5
                    select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
                short num2 = (
                    from Map in kp_chart
                    where Map.Planet == 6
                    select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
                short bhavChalitHouse3 = (
                    from Map in kp_chart
                    where Map.Planet == 7
                    select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
                short num3 = (
                    from Map in kp_chart
                    where Map.Planet == 8
                    select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
                short bhavChalitHouse4 = (
                    from Map in kp_chart
                    where Map.Planet == 9
                    select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
                short num4 = (
                    from Map in kp_chart
                    where Map.Planet == planet1
                    select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
                short bhavChalitHouse5 = (
                    from Map in kp_chart
                    where Map.Planet == planet2
                    select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
                short num5 = 0;
                if ((planet1 == 1 || planet1 == 2 || planet1 == 4 || planet1 == 6 ? true : planet1 == 9))
                {
                    num5 = Convert.ToInt16((int)(num4 - bhavChalitHouse5));
                    if (Math.Abs(num5) == 6)
                    {
                        flag = true;
                        return flag;
                    }
                }
                if (planet1 == 3)
                {
                    num5 = Convert.ToInt16((int)(num4 - bhavChalitHouse5));
                    if ((num5 == -3 || num5 == 9 || num5 == -7 || num5 == 5 ? true : Math.Abs(num5) == 6))
                    {
                        flag = true;
                        return flag;
                    }
                }
                if (planet1 == 5)
                {
                    num5 = Convert.ToInt16((int)(num4 - bhavChalitHouse5));
                    if ((num5 == -4 || num5 == 8 || num5 == -8 || num5 == 4 ? true : Math.Abs(num5) == 6))
                    {
                        flag = true;
                        return flag;
                    }
                }
                if (planet1 == 7)
                {
                    num5 = Convert.ToInt16((int)(num4 - bhavChalitHouse5));
                    if ((num5 == -2 || num5 == 10 || num5 == -9 || num5 == 3 ? true : Math.Abs(num5) == 6))
                    {
                        flag = true;
                        return flag;
                    }
                }
                if (planet1 == 8)
                {
                    num5 = Convert.ToInt16((int)(num4 - bhavChalitHouse5));
                    if ((num5 == -8 || num5 == 4 ? true : Math.Abs(num5) == 6))
                    {
                        flag = true;
                        return flag;
                    }
                }
                flag = flag1;
            }
            else
            {
                flag = false;
            }
            return flag;
        }

        public bool isDrishtiPass(string from_drishti, short to_drishti, List<KPPlanetMappingVO> kp_chart)
        {
            bool flag;
            bool flag1 = false;
            if ((from_drishti.Trim().Length <= 0 ? false : !(from_drishti.Trim() == "0")))
            {
                char[] chrArray = new char[] { ',' };
                string[] strArrays = from_drishti.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                int num = 0;
                while (num < (int)strArrays.Length)
                {
                    if (!this.isDrishti(Convert.ToInt16(strArrays[num]), to_drishti, kp_chart))
                    {
                        num++;
                    }
                    else
                    {
                        flag = true;
                        return flag;
                    }
                }
                flag = flag1;
            }
            else
            {
                flag = true;
            }
            return flag;
        }

        public bool isEmptyPass(string empty, List<KPPlanetMappingVO> kp_chart)
        {
            bool flag;
            bool flag1 = true;
            if ((empty.Trim().Length <= 0 ? false : !(empty.Trim() == "0")))
            {
                char[] chrArray = new char[] { ',' };
                string[] strArrays = empty.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                int num = 0;
                while (num < (int)strArrays.Length)
                {
                    string str = strArrays[num];
                    if ((
                        from Map in kp_chart
                        where Map.House == Convert.ToInt16(str)
                        select Map).ToList<KPPlanetMappingVO>().Count <= 0)
                    {
                        num++;
                    }
                    else
                    {
                        flag = false;
                        return flag;
                    }
                }
                flag = flag1;
            }
            else
            {
                flag = true;
            }
            return flag;
        }

        public bool isFewConditionMet(KPMixDashaVO mix, List<KPPlanetMappingVO> kp_chart, string houses)
        {
            bool flag;
            bool flag1 = false;
            if ((mix.ptype == "yuti" ? true : mix.ptype == "multi"))
            {
                if (mix.lawtype == "yuti")
                {
                    if (this.isYutiPass(mix, kp_chart))
                    {
                        flag1 = true;
                    }
                }
                flag = flag1;
                return flag;
            }
            else if (mix.Planet2 > 0)
            {
                flag = false;
            }
            else if (!(!this.isEmptyPass(mix.empty, kp_chart) || !this.isNotEmptyPass(mix.not_empty, kp_chart) || !this.isShubhPass(mix.shubh, kp_chart) ? false : this.isAshubhPass(mix.ashubh, kp_chart)))
            {
                flag = false;
            }
            else if (!(!this.isAndPlanetPass(mix.andplanet, kp_chart) || !this.isNotAndPlanetPass(mix.not_andplanet, kp_chart) || !this.isOrPlanetPass(mix.orplanet, kp_chart) ? false : this.isNotOrPlanetPass(mix.not_orplanet, kp_chart)))
            {
                flag = false;
            }
            else if ((!this.isConjPass(mix.conj, mix.Planet1, kp_chart) ? false : this.isNotConjPass(mix.not_conj, mix.Planet1, kp_chart)))
            {
                if ((!this.isDrishtiPass(mix.drishti, mix.Planet1, kp_chart) ? true : !this.isNotDrishtiPass(mix.not_drishti, mix.Planet1, kp_chart)))
                {
                    flag = false;
                    return flag;
                }
                flag1 = true;
                if (mix.lawtype == "yuti")
                {
                    if (this.isYutiPass(mix, kp_chart))
                    {
                        flag1 = true;
                    }
                }
                flag = flag1;
                return flag;
            }
            else
            {
                flag = false;
            }
            return flag;
        }

        public bool isFullYutiPass(KPMixDashaVO mix, List<KPPlanetMappingVO> kp_chart)
        {
            bool flag;
            bool flag1 = false;
            if (!(mix.yuticombi.Trim().Length <= 0 ? false : !(mix.yuticombi.Trim() == "0")))
            {
                flag = false;
            }
            else if (!(mix.ptype != "fullyuti"))
            {
                string str = mix.yutihouse;
                char[] chrArray = new char[] { ',' };
                string[] strArrays = str.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                string str1 = mix.yuticombi;
                chrArray = new char[] { ',' };
                string[] strArrays1 = str1.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                short house = 0;
                short num = 0;
                short house1 = 0;
                short num1 = 0;
                short house2 = 0;
                short num2 = 1;
                string[] strArrays2 = strArrays1;
                for (int i = 0; i < (int)strArrays2.Length; i++)
                {
                    string str2 = strArrays2[i];
                    if (num2 == 1)
                    {
                        house = (
                            from Map in kp_chart
                            where Map.Planet == Convert.ToInt16(str2)
                            select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                    }
                    if (num2 == 2)
                    {
                        num = (
                            from Map in kp_chart
                            where Map.Planet == Convert.ToInt16(str2)
                            select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                    }
                    if (num2 == 3)
                    {
                        house1 = (
                            from Map in kp_chart
                            where Map.Planet == Convert.ToInt16(str2)
                            select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                    }
                    if (num2 == 4)
                    {
                        num1 = (
                            from Map in kp_chart
                            where Map.Planet == Convert.ToInt16(str2)
                            select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                    }
                    if (num2 == 5)
                    {
                        house2 = (
                            from Map in kp_chart
                            where Map.Planet == Convert.ToInt16(str2)
                            select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                    }
                    num2 = (short)(num2 + 1);
                }
                if (mix.lawtype == "Yuti 2")
                {
                    if (house == num)
                    {
                        flag1 = true;
                    }
                }
                if (mix.lawtype == "Yuti 3")
                {
                    if ((house != num ? false : house == house1))
                    {
                        flag1 = true;
                    }
                }
                if (mix.lawtype == "Yuti 4")
                {
                    if ((house != num || house != house1 ? false : house == num1))
                    {
                        flag1 = true;
                    }
                }
                if ((strArrays.Count<string>() <= 0 ? false : mix.yutihouse != "0"))
                {
                    if (!strArrays.Contains<string>(house.ToString()))
                    {
                        flag = false;
                        return flag;
                    }
                }
                flag = flag1;
            }
            else
            {
                flag = false;
            }
            return flag;
        }

        public bool IsMilan(short planet1, short planet2, List<KPPlanetMappingVO> kp_chart)
        {
            bool flag = false;
            short bhavChalitHouse = (
                from Map in kp_chart
                where Map.Planet == planet1
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            short num = (
                from Map in kp_chart
                where Map.Planet == planet2
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            string pakkeGhar = KPBLL.planet_list[planet1 - 1].Pakke_Ghar;
            char[] chrArray = new char[] { ',' };
            List<string> list = pakkeGhar.Split(chrArray, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            string str = KPBLL.planet_list[planet2 - 1].Pakke_Ghar;
            chrArray = new char[] { ',' };
            List<string> strs = str.Split(chrArray, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            flag = (this.isDrishti(planet1, planet2, kp_chart) ? true : this.isDrishti(planet2, planet1, kp_chart));
            if (bhavChalitHouse == num)
            {
                flag = true;
            }
            if ((list.Contains(num.ToString()) ? true : strs.Contains(bhavChalitHouse.ToString())))
            {
                flag = true;
            }
            return flag;
        }

        public bool isNotAndPlanetPass(string hashvalue, List<KPPlanetMappingVO> kp_chart)
        {
            bool flag;
            bool flag1 = true;
            if ((hashvalue.Trim().Length <= 0 ? false : !(hashvalue.Trim() == "0")))
            {
                char[] chrArray = new char[] { ',' };
                string[] strArrays = hashvalue.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                int num = 0;
                while (num < (int)strArrays.Length)
                {
                    string str = strArrays[num];
                    chrArray = new char[] { '#' };
                    string[] strArrays1 = str.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                    if ((
                        from Map in kp_chart
                        where (Map.Planet != Convert.ToInt16(strArrays1[0]) ? false : Map.House == Convert.ToInt16(strArrays1[1]))
                        select Map).ToList<KPPlanetMappingVO>().Count <= 0)
                    {
                        num++;
                    }
                    else
                    {
                        flag = false;
                        return flag;
                    }
                }
                flag = flag1;
            }
            else
            {
                flag = true;
            }
            return flag;
        }

        public bool isNotConjPass(string conj, short planet, List<KPPlanetMappingVO> kp_chart)
        {
            bool flag;
            bool flag1 = true;
            bool flag2 = false;
            if ((conj.Trim().Length <= 0 ? false : !(conj.Trim() == "0")))
            {
                char[] chrArray = new char[] { ',' };
                string[] strArrays = conj.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                int num = 0;
                while (num < (int)strArrays.Length)
                {
                    string str = strArrays[num];
                    short house = (
                        from Map in kp_chart
                        where Map.Planet == Convert.ToInt16(str)
                        select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                    short house1 = (
                        from Map in kp_chart
                        where Map.Planet == planet
                        select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                    if ((this.isDrishti(Convert.ToInt16(str), planet, kp_chart) ? false : !this.isDrishti(planet, Convert.ToInt16(str), kp_chart)))
                    {
                        if (house == house1)
                        {
                            flag2 = true;
                        }
                        num++;
                    }
                    else
                    {
                        flag = false;
                        return flag;
                    }
                }
                if (flag2)
                {
                    flag1 = false;
                }
                flag = flag1;
            }
            else
            {
                flag = true;
            }
            return flag;
        }

        public bool isNotDrishtiPass(string from_drishti, short to_drishti, List<KPPlanetMappingVO> kp_chart)
        {
            bool flag;
            bool flag1 = true;
            if ((from_drishti.Trim().Length <= 0 ? false : !(from_drishti.Trim() == "0")))
            {
                char[] chrArray = new char[] { ',' };
                string[] strArrays = from_drishti.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                int num = 0;
                while (num < (int)strArrays.Length)
                {
                    if (!this.isDrishti(Convert.ToInt16(strArrays[num]), to_drishti, kp_chart))
                    {
                        num++;
                    }
                    else
                    {
                        flag = false;
                        return flag;
                    }
                }
                flag = flag1;
            }
            else
            {
                flag = true;
            }
            return flag;
        }

        public bool isNotEmptyPass(string not_empty, List<KPPlanetMappingVO> kp_chart)
        {
            bool flag;
            bool flag1 = true;
            if ((not_empty.Trim().Length <= 0 ? false : !(not_empty.Trim() == "0")))
            {
                char[] chrArray = new char[] { ',' };
                string[] strArrays = not_empty.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                int num = 0;
                while (num < (int)strArrays.Length)
                {
                    string str = strArrays[num];
                    if ((
                        from Map in kp_chart
                        where Map.House == Convert.ToInt16(str)
                        select Map).ToList<KPPlanetMappingVO>().Count > 0)
                    {
                        num++;
                    }
                    else
                    {
                        flag = false;
                        return flag;
                    }
                }
                flag = flag1;
            }
            else
            {
                flag = true;
            }
            return flag;
        }

        public bool isNotOrPlanetPass(string hashvalue, List<KPPlanetMappingVO> kp_chart)
        {
            bool flag;
            bool flag1 = true;
            if ((hashvalue.Trim().Length <= 0 ? false : !(hashvalue.Trim() == "0")))
            {
                char[] chrArray = new char[] { ',' };
                string[] strArrays = hashvalue.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                int num = 0;
                while (num < (int)strArrays.Length)
                {
                    string str = strArrays[num];
                    chrArray = new char[] { '#' };
                    string[] strArrays1 = str.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                    if ((
                        from Map in kp_chart
                        where (Map.Planet != Convert.ToInt16(strArrays1[0]) ? false : Map.House == Convert.ToInt16(strArrays1[1]))
                        select Map).ToList<KPPlanetMappingVO>().Count <= 0)
                    {
                        num++;
                    }
                    else
                    {
                        flag = false;
                        return flag;
                    }
                }
                flag = flag1;
            }
            else
            {
                flag = true;
            }
            return flag;
        }

        public bool isOccupied_by_Mitra(short planet, string houses, List<KPPlanetMappingVO> kp_chart)
        {
            bool flag = false;
            char[] chrArray = new char[] { ',' };
            List<string> list = houses.Split(chrArray, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            string mitra = KPBLL.planet_list[planet - 1].Mitra;
            chrArray = new char[] { ',' };
            List<string> strs = mitra.Split(chrArray, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            List<string> strs1 = new List<string>();
            foreach (KPPlanetMappingVO kpChart in kp_chart)
            {
                if (list.Contains(Convert.ToString(kpChart.Bhav_Chalit_House)))
                {
                    strs1.Add(Convert.ToString(kpChart.Planet));
                }
            }
            if (strs.Intersect<string>(strs1).ToList<string>().Count > 0)
            {
                flag = true;
            }
            return flag;
        }

        public bool isOccupied_by_Shatru(short planet, string houses, List<KPPlanetMappingVO> kp_chart)
        {
            bool flag = false;
            char[] chrArray = new char[] { ',' };
            List<string> list = houses.Split(chrArray, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            string shatru = KPBLL.planet_list[planet - 1].Shatru;
            chrArray = new char[] { ',' };
            List<string> strs = shatru.Split(chrArray, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            List<string> strs1 = new List<string>();
            foreach (KPPlanetMappingVO kpChart in kp_chart)
            {
                if (list.Contains(Convert.ToString(kpChart.Bhav_Chalit_House)))
                {
                    strs1.Add(Convert.ToString(kpChart.Planet));
                }
            }
            if (strs.Intersect<string>(strs1).ToList<string>().Count > 0)
            {
                flag = true;
            }
            return flag;
        }

        public bool isOrPlanetPass(string hashvalue, List<KPPlanetMappingVO> kp_chart)
        {
            bool flag;
            bool flag1 = false;
            if ((hashvalue.Trim().Length <= 0 ? false : !(hashvalue.Trim() == "0")))
            {
                char[] chrArray = new char[] { ',' };
                string[] strArrays = hashvalue.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                int num = 0;
                while (num < (int)strArrays.Length)
                {
                    string str = strArrays[num];
                    chrArray = new char[] { '#' };
                    string[] strArrays1 = str.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                    if ((
                        from Map in kp_chart
                        where (Map.Planet != Convert.ToInt16(strArrays1[0]) ? false : Map.House == Convert.ToInt16(strArrays1[1]))
                        select Map).ToList<KPPlanetMappingVO>().Count <= 0)
                    {
                        num++;
                    }
                    else
                    {
                        flag1 = true;
                        break;
                    }
                }
                flag = flag1;
            }
            else
            {
                flag = true;
            }
            return flag;
        }

        public bool isPlanetHousePass(KPMixDashaVO mix, List<KPPlanetMappingVO> kp_chart)
        {
            bool flag;
            bool flag1 = true;
            if ((mix.planethouse.Trim().Length <= 0 ? false : !(mix.planethouse.Trim() == "0")))
            {
                string str = mix.planethouse;
                char[] chrArray = new char[] { ',' };
                string[] strArrays = str.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                if (mix.planethouse.Contains<char>('#'))
                {
                    string[] strArrays1 = strArrays;
                    int num = 0;
                    while (num < (int)strArrays1.Length)
                    {
                        string str1 = strArrays1[num];
                        chrArray = new char[] { '#' };
                        string[] strArrays2 = str1.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                        if ((
                            from Map in kp_chart
                            where (Map.Planet != Convert.ToInt16(strArrays2[0]) ? false : Map.House == Convert.ToInt16(strArrays2[1]))
                            select Map).ToList<KPPlanetMappingVO>().Count != 0)
                        {
                            num++;
                        }
                        else
                        {
                            flag = false;
                            return flag;
                        }
                    }
                    flag = flag1;
                }
                else
                {
                    flag = true;
                }
            }
            else
            {
                flag = true;
            }
            return flag;
        }

        public bool isShubhPass(string shubh, List<KPPlanetMappingVO> kp_chart)
        {
            bool flag;
            bool flag1 = true;
            if ((shubh.Trim().Length <= 0 ? false : !(shubh.Trim() == "0")))
            {
                char[] chrArray = new char[] { ',' };
                string[] strArrays = shubh.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                int num = 0;
                while (num < (int)strArrays.Length)
                {
                    string str = strArrays[num];
                    if (!(
                        from Map in kp_chart
                        where Map.Planet == Convert.ToInt16(str)
                        select Map).ToList<KPPlanetMappingVO>().SingleOrDefault<KPPlanetMappingVO>().isbad)
                    {
                        num++;
                    }
                    else
                    {
                        flag = false;
                        return flag;
                    }
                }
                flag = flag1;
            }
            else
            {
                flag = true;
            }
            return flag;
        }

        public bool isTrianglePass(KPMixDashaVO mix, List<KPPlanetMappingVO> kp_chart)
        {
            bool flag;
            bool flag1 = false;
            if ((!(mix.lawtype != "triangle") || !(mix.lawtype != "chokor") || !(mix.lawtype != "drishti") || !(mix.lawtype != "ulta") ? true : !(mix.lawtype != "takrao")))
            {
                short house = 0;
                short num = 0;
                short num1 = 0;
                short planet1 = mix.Planet1;
                short planet2 = mix.Planet2;
                house = (
                    from Map in kp_chart
                    where Map.Planet == mix.Planet1
                    select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                num = (
                    from Map in kp_chart
                    where Map.Planet == mix.Planet2
                    select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                if ((house <= 0 ? false : num > 0))
                {
                    num1 = Math.Abs(Convert.ToInt16((int)(house - num)));
                    if ((mix.lawtype != "chokor" ? false : num1 == 3))
                    {
                        flag1 = true;
                    }
                    if ((mix.lawtype != "drishti" ? false : this.isDrishti(planet1, planet2, kp_chart)))
                    {
                        flag1 = true;
                    }
                    if ((mix.lawtype != "takrao" ? false : num1 == 7))
                    {
                        if ((house == 2 || house == 8 ? false : house != 9))
                        {
                            flag1 = true;
                        }
                    }
                    if ((mix.lawtype != "triangle" ? false : num1 == 4))
                    {
                        flag1 = true;
                    }
                    if ((mix.lawtype != "ulta" ? false : this.isDrishti(planet2, planet1, kp_chart)))
                    {
                        flag1 = true;
                    }
                }
                if (flag1)
                {
                    flag1 = true;
                }
                flag = flag1;
            }
            else
            {
                flag = false;
            }
            return flag;
        }

        public bool isYutiPass(KPMixDashaVO mix, List<KPPlanetMappingVO> kp_chart)
        {
            bool flag;
            bool flag1 = false;
            if ((mix.yuticombi.Trim().Length <= 0 ? false : !(mix.yuticombi.Trim() == "0")))
            {
                string str = mix.yutihouse;
                char[] chrArray = new char[] { ',' };
                string[] strArrays = str.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                string str1 = mix.yuticombi;
                chrArray = new char[] { ',' };
                string[] strArrays1 = str1.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                short house = 0;
                short num = 0;
                short house1 = 0;
                short num1 = 0;
                short house2 = 0;
                short num2 = 1;
                string[] strArrays2 = strArrays1;
                for (int i = 0; i < (int)strArrays2.Length; i++)
                {
                    string str2 = strArrays2[i];
                    if (num2 == 1)
                    {
                        house = (
                            from Map in kp_chart
                            where Map.Planet == Convert.ToInt16(str2)
                            select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                    }
                    if (num2 == 2)
                    {
                        num = (
                            from Map in kp_chart
                            where Map.Planet == Convert.ToInt16(str2)
                            select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                    }
                    if (num2 == 3)
                    {
                        house1 = (
                            from Map in kp_chart
                            where Map.Planet == Convert.ToInt16(str2)
                            select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                    }
                    if (num2 == 4)
                    {
                        num1 = (
                            from Map in kp_chart
                            where Map.Planet == Convert.ToInt16(str2)
                            select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                    }
                    if (num2 == 5)
                    {
                        house2 = (
                            from Map in kp_chart
                            where Map.Planet == Convert.ToInt16(str2)
                            select Map).SingleOrDefault<KPPlanetMappingVO>().House;
                    }
                    num2 = (short)(num2 + 1);
                }
                if ((house <= 0 || num <= 0 || house1 != 0 || num1 != 0 ? false : house2 == 0))
                {
                    if (house == num)
                    {
                        flag1 = true;
                    }
                }
                if ((house <= 0 || num <= 0 || house1 <= 0 || num1 != 0 ? false : house2 == 0))
                {
                    if ((house != num ? false : house == house1))
                    {
                        flag1 = true;
                    }
                }
                if ((house <= 0 || num <= 0 || house1 <= 0 || num1 <= 0 ? false : house2 == 0))
                {
                    if ((house != num || house != house1 ? false : house == num1))
                    {
                        flag1 = true;
                    }
                }
                if ((house <= 0 || num <= 0 || house1 <= 0 || num1 <= 0 ? false : house2 > 0))
                {
                    if ((house != num || house != house1 || house != num1 ? false : house == house2))
                    {
                        flag1 = true;
                    }
                }
                if ((strArrays.Count<string>() <= 0 ? false : mix.yutihouse != "0"))
                {
                    if (!strArrays.Contains<string>(house.ToString()))
                    {
                        flag = false;
                        return flag;
                    }
                }
                flag = flag1;
            }
            else
            {
                flag = false;
            }
            return flag;
        }

        public string LalKitabAmrit_35Years(KundliVO persKV, List<KundliMappingVO> lkmv, List<KundliMappingVO> lkmv_lagna, string ruletype, bool showref, bool male, string lang, short agefrom, short ageto, ProductSettingsVO prod)
        {
            string str;
            bool flag;
            bool flag1 = false;
            List<long> nums = new List<long>();
            bool flag2 = false;
            PlanetBLL planetBLL = new PlanetBLL();
            RuleBLL ruleBLL = new RuleBLL();
            List<Life35VO> life35VOs = new List<Life35VO>();
            string str1 = "";
            List<RulesVO> rulesVOs = new List<RulesVO>();
            KundliBLL kundliBLL = new KundliBLL();
            life35VOs = kundliBLL.GetLife35(persKV.JanamSamay);
            string predText = "";
            List<long> nums1 = new List<long>();
            foreach (Life35VO life35VO in life35VOs)
            {
                flag1 = true;
                List<long> nums2 = new List<long>();
                string str2 = "";
                KundliMappingVO kundliMappingVO = new KundliMappingVO();
                kundliMappingVO = (
                    from Map in lkmv
                    where Map.PlanetName == life35VO.Planet
                    select Map).SingleOrDefault<KundliMappingVO>();
                Years35BLL years35BLL = new Years35BLL();
                List<Years35VO> years35VOs = years35BLL.Get35Years(persKV.JanamSamay);
                long umra = years35BLL.GetUmra(kundliMappingVO.PlanetName) - (long)1;
                long num = Convert.ToInt64((
                    from Map in years35VOs
                    where Map.Planet == kundliMappingVO.PlanetName
                    select Map).Min<Years35VO>((Years35VO Map) => Map.Years));
                str2 = string.Concat(str2, this.lrs.getPrabhav(num, umra, lang).ToString());
                short num1 = Convert.ToInt16(35);
                if (((long)agefrom < num || (long)agefrom > num + umra) && ((long)agefrom < num + (long)num1 || (long)agefrom > num + (long)num1 + umra))
                {
                    flag = ((long)agefrom < num + (long)num1 ? true : (long)agefrom > num + (long)num1 + umra);
                }
                else
                {
                    flag = false;
                }
                if (!flag)
                {
                    flag2 = true;
                }
                if (flag2)
                {
                    List<RulesVO> list = new List<RulesVO>();
                    list = (
                        from Map in kundliBLL.GetAdvancePredictions(lkmv, kundliMappingVO.Planet, 0)
                        where Map.Isbad == kundliMappingVO.IsBad
                        select Map).ToList<RulesVO>();
                    if (kundliMappingVO.Planet == 8)
                    {
                        if (Convert.ToInt16((
                            from Map in lkmv
                            where Map.House == kundliMappingVO.House
                            select Map).Count<KundliMappingVO>()) == 1)
                        {
                            short num2 = 0;
                            if (kundliMappingVO.House == 1)
                            {
                                num2 = 5;
                            }
                            if (kundliMappingVO.House == 2)
                            {
                                num2 = 6;
                            }
                            if (kundliMappingVO.House == 3)
                            {
                                num2 = 9;
                            }
                            if (kundliMappingVO.House == 4)
                            {
                                num2 = 4;
                            }
                            if (kundliMappingVO.House == 5)
                            {
                                num2 = 6;
                            }
                            if (kundliMappingVO.House == 6)
                            {
                                num2 = 2;
                            }
                            if (kundliMappingVO.House == 7)
                            {
                                num2 = 7;
                            }
                            if (kundliMappingVO.House == 8)
                            {
                                num2 = 3;
                            }
                            if (kundliMappingVO.House == 9)
                            {
                                num2 = 6;
                            }
                            if (kundliMappingVO.House == 10)
                            {
                                num2 = 3;
                            }
                            if (kundliMappingVO.House == 11)
                            {
                                num2 = 6;
                            }
                            if (kundliMappingVO.House == 12)
                            {
                                num2 = 1;
                            }
                            bool isBad = (
                                from Map in lkmv
                                where Map.Planet == num2
                                select Map).SingleOrDefault<KundliMappingVO>().IsBad;
                            list.AddRange((
                                from Map in kundliBLL.GetAdvancePredictions(lkmv, num2, 0)
                                where Map.Isbad == isBad
                                select Map).ToList<RulesVO>());
                        }
                    }
                    if (!(lang.ToLower() == "gujarati" ? false : !(lang.ToLower() == "punjabi")))
                    {
                        list = (
                            from Map in kundliBLL.GetAdvancePredictions(lkmv, kundliMappingVO.Planet, 0)
                            where (Map.Isbad != kundliMappingVO.IsBad ? false : (Map.RuleType == "langsplupay2" || Map.RuleType == "pmegeneral" || Map.RuleType == "general" || Map.RuleType == "langgeneral" || Map.RuleType == "triangle" || Map.RuleType == "gatha" || Map.RuleType == "langgatha" || Map.RuleType == "langsunheri" ? true : (Map.Reference != "Indian Astrology" ? false : Map.Ruleformula.Contains("&"))))
                            select Map).ToList<RulesVO>();
                        list.AddRange((
                            from Map in kundliBLL.GetAdvancePredictions(lkmv, kundliMappingVO.Planet, 0)
                            where (Map.RuleType == "shadi" || Map.RuleType == "triangle" ? true : Map.RuleType == "any")
                            select Map).ToList<RulesVO>());
                    }
                    else if ((lang.ToLower() == "hindi" ? true : lang.ToLower() == "marathi"))
                    {
                        list = (
                            from Map in kundliBLL.GetAdvancePredictions(lkmv, kundliMappingVO.Planet, 0)
                            where (Map.Isbad != kundliMappingVO.IsBad || Map.Mainplanet != kundliMappingVO.Planet ? false : (Map.RuleType == "any" || Map.RuleType == "general" || Map.RuleType == "triangle" || Map.RuleType == "gatha" ? true : (Map.Reference != "Indian Astrology" ? false : Map.Ruleformula.Contains("&"))))
                            select Map).ToList<RulesVO>();
                        list.AddRange((
                            from Map in kundliBLL.GetAdvancePredictions(lkmv, kundliMappingVO.Planet, 0)
                            where (Map.Mainplanet != kundliMappingVO.Planet ? false : (Map.RuleType == "gany" || Map.RuleType == "shadi" || Map.RuleType == "triangle" ? true : Map.RuleType == "any"))
                            select Map).ToList<RulesVO>());
                    }
                    rulesVOs = list;
                    RuleDAO ruleDAO = new RuleDAO();
                    string ruleformula = "";
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
                    if (flag2)
                    {
                        str1 = "";
                    }
                    foreach (RulesVO rulesVO in
                        from Map in rulesVOs
                        orderby Map.Ruleformula
                        orderby Map.Upay
                        select Map)
                    {
                        flag1 = false;
                        if (!nums1.Exists((long Map) => Map == rulesVO.Sno))
                        {
                            predText = this.Get_Pred_Text(rulesVO.Sno, persKV.Language, male, true, showref, false, prod.ShowUpay, prod.ShowUpay, true, persKV, prod);
                            if (ruleformula == rulesVO.Ruleformula)
                            {
                                predText = string.Concat(predText, "\r\n");
                            }
                            str1 = string.Concat(str1, predText);
                            ruleformula = rulesVO.Ruleformula;
                            nums1.Add(rulesVO.Sno);
                        }
                    }
                    if (flag2)
                    {
                        str = str1;
                        return str;
                    }
                }
            }
            str = str1;
            return str;
        }

        public short Number_of_Mitra(short planet, string houses, List<KPPlanetMappingVO> kp_chart)
        {
            char[] chrArray = new char[] { ',' };
            List<string> list = houses.Split(chrArray, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            string mitra = KPBLL.planet_list[planet - 1].Mitra;
            chrArray = new char[] { ',' };
            List<string> strs = mitra.Split(chrArray, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            List<string> strs1 = new List<string>();
            foreach (KPPlanetMappingVO kpChart in kp_chart)
            {
                if (list.Contains(Convert.ToString(kpChart.Bhav_Chalit_House)))
                {
                    strs1.Add(Convert.ToString(kpChart.Planet));
                }
            }
            List<string> list1 = strs.Intersect<string>(strs1).ToList<string>();
            return Convert.ToInt16(list1.Count);
        }

        public short Number_of_Shatru(short planet, string houses, List<KPPlanetMappingVO> kp_chart)
        {
            char[] chrArray = new char[] { ',' };
            List<string> list = houses.Split(chrArray, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            string shatru = KPBLL.planet_list[planet - 1].Shatru;
            chrArray = new char[] { ',' };
            List<string> strs = shatru.Split(chrArray, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            List<string> strs1 = new List<string>();
            foreach (KPPlanetMappingVO kpChart in kp_chart)
            {
                if (list.Contains(Convert.ToString(kpChart.Bhav_Chalit_House)))
                {
                    strs1.Add(Convert.ToString(kpChart.Planet));
                }
            }
            List<string> list1 = strs.Intersect<string>(strs1).ToList<string>();
            return Convert.ToInt16(list1.Count);
        }

        public bool Pehele_Baad(short first_planet, short second_planet, List<KPPlanetMappingVO> kp_chart)
        {
            bool flag = false;
            bool flag1 = false;
            short bhavChalitHouse = (
                from Map in kp_chart
                where Map.Planet == first_planet
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            short num = (
                from Map in kp_chart
                where Map.Planet == second_planet
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            flag = (bhavChalitHouse < 1 ? false : bhavChalitHouse <= 6);
            flag1 = (num < 7 ? false : num <= 12);
            return (!flag ? false : flag1);
        }

        private short perc(short val, short total)
        {
            short num = Convert.ToInt16(100 - Convert.ToInt16(val * 100 / total));
            return num;
        }

        private short perc_score(short bper, short gper)
        {
            short num = 0;
            short num1 = Convert.ToInt16((bper + gper) / 2);
            if (num1 < 50)
            {
                num = 1;
            }
            if ((num1 < 50 ? false : num1 < 65))
            {
                num = 2;
            }
            if ((num1 < 65 ? false : num1 < 75))
            {
                num = 3;
            }
            if ((num1 < 75 ? false : num1 < 80))
            {
                num = 4;
            }
            if (num1 >= 80)
            {
                num = 5;
            }
            return num;
        }

        public List<KPPlanetMappingVO> Process_KPChart_GoodBad(List<KPPlanetMappingVO> kp_chart, KundliVO persKV, ProductSettingsVO prod)
        {
            List<KPPlanetMappingVO> kPPlanetMappingVOs = new List<KPPlanetMappingVO>();
            kPPlanetMappingVOs = this.Bad_Kardo(kp_chart, persKV, prod);
            return this.Bad_Kardo(kPPlanetMappingVOs, persKV, prod);
        }

        public void Process_Planet_Lagan(string Online_Result, ref List<KPPlanetMappingVO> kp_chart, ref List<KPHouseMappingVO> cusp_house, short rotate, bool bhav_chalit)
        {
            string str;
            //KPHouseMappingVO list = null;
            List<KPSigniVO> kPSigniVOs;
            //short num = 0;
            string[] strArrays;
            int k;
            short num1;
            KundliBLL kundliBLL = new KundliBLL();
            List<KundliMappingVO> kundliMappingVOs = new List<KundliMappingVO>();
            KPBLL.planet_list = this.Fill_Planets();
            KPBLL.house_list = this.Fill_Houses();
            KPBLL.nak_list = this.Fill_Nak();
            KPBLL.rashi_list = this.Fill_Rashi();
            KPBLL.kp249 = this.Fill_249();//---------------------
            char[] chrArray = new char[] { '-' };
            string[] strArrays1 = Online_Result.Split(chrArray);
            PredictionBLL predictionBLL = new PredictionBLL();
            string str1 = strArrays1[0];
            chrArray = new char[] { '#' };
            string[] strArrays2 = str1.Split(chrArray);
            string str2 = strArrays1[1];
            chrArray = new char[] { '#' };
            string[] strArrays3 = str2.Split(chrArray);
            string str3 = strArrays1[2];
            chrArray = new char[] { '#' };
            string[] strArrays4 = str3.Split(chrArray);
            string str4 = strArrays1[4];
            chrArray = new char[] { '#' };
            string[] strArrays5 = str4.Split(chrArray);
            string str5 = strArrays1[5];
            chrArray = new char[] { '#' };
            string[] strArrays6 = str5.Split(chrArray);
            string str6 = strArrays1[0];
            chrArray = new char[] { '#' };
            short num2 = Convert.ToInt16(str6.Split(chrArray)[0]);
            for (int i = 1; i <= 12; i++)
            {
                KPPlanetMappingVO kPPlanetMappingVO = new KPPlanetMappingVO();
                KPHouseMappingVO kPHouseMappingVO = new KPHouseMappingVO();
                kPPlanetMappingVO.Planet = Convert.ToInt16(i);
                short num3 = Convert.ToInt16(strArrays3[i]);
                if (Convert.ToInt16(strArrays2[i]) + (num2 - 1) <= 12)
                {
                    kPPlanetMappingVO.Rashi = Convert.ToInt16(Convert.ToInt16(strArrays2[i]) + (num2 - 1));
                }
                else
                {
                    kPPlanetMappingVO.Rashi = Convert.ToInt16(Convert.ToInt16(strArrays2[i]) + (num2 - 1) - 12);
                }
                kPPlanetMappingVO.Bhav_Chalit_Rashi = Convert.ToInt16(strArrays4[num3 - 1]);
                kPPlanetMappingVO.DegreePlanet = strArrays5[i];
                if (kPPlanetMappingVO.DegreePlanet == "00:00:00")
                {
                    kPPlanetMappingVO.DegreePlanet = "00:00:01";
                }
                KPPlanetMappingVO kPPlanetMappingVO1 = kPPlanetMappingVO;
                string degreePlanet = kPPlanetMappingVO.DegreePlanet;
                chrArray = new char[] { ':' };
                double num4 = Convert.ToDouble(degreePlanet.Split(chrArray)[0]);
                string degreePlanet1 = kPPlanetMappingVO.DegreePlanet;
                chrArray = new char[] { ':' };
                double num5 = Convert.ToDouble(degreePlanet1.Split(chrArray)[1]);
                string degreePlanet2 = kPPlanetMappingVO.DegreePlanet;
                chrArray = new char[] { ':' };
                kPPlanetMappingVO1.DegreePlanet_Decimal = kundliBLL.DMStoDecimal(num4, num5, Convert.ToDouble(degreePlanet2.Split(chrArray)[2]));
                if (kPPlanetMappingVO.DegreePlanet_Decimal > 30)
                {
                    kPPlanetMappingVO.DegreePlanet_Decimal = 30;
                }
                if (bhav_chalit)
                {
                    kPPlanetMappingVO.House = Convert.ToInt16(strArrays3[i]);
                }
                else
                {
                    kPPlanetMappingVO.House = Convert.ToInt16(strArrays2[i]);
                }
                kPPlanetMappingVO.Bhav_Chalit_House = Convert.ToInt16(strArrays3[i]);
                kPPlanetMappingVO.Bhav_Chalit_House_New = Convert.ToInt16(strArrays3[i]);
                kPPlanetMappingVO.Rashi_Lord = (
                    from Map in KPBLL.rashi_list
                    where Map.Rashi == kPPlanetMappingVO.Rashi
                    select Map).SingleOrDefault<KPRashiVO>().Swami;
                kPPlanetMappingVO.Nak_Lord = (
                    from Map in KPBLL.kp249
                    where (kPPlanetMappingVO.DegreePlanet_Decimal < Map.From_Degree_Decimal || kPPlanetMappingVO.DegreePlanet_Decimal > Map.To_Degree_Decimal ? false : Map.Rashi == kPPlanetMappingVO.Rashi)
                    select Map).FirstOrDefault<KP249VO>().Nak_Lord;
                kPPlanetMappingVO.Sub_Lord = (
                    from Map in KPBLL.kp249
                    where (kPPlanetMappingVO.DegreePlanet_Decimal < Map.From_Degree_Decimal || kPPlanetMappingVO.DegreePlanet_Decimal > Map.To_Degree_Decimal ? false : Map.Rashi == kPPlanetMappingVO.Rashi)
                    select Map).FirstOrDefault<KP249VO>().Sub_Lord;
                short sno = (
                    from Map in KPBLL.kp249
                    where (kPPlanetMappingVO.DegreePlanet_Decimal < Map.From_Degree_Decimal || kPPlanetMappingVO.DegreePlanet_Decimal > Map.To_Degree_Decimal ? false : Map.Rashi == kPPlanetMappingVO.Rashi)
                    select Map).FirstOrDefault<KP249VO>().Sno;
                List<KP249SubSubLordVO> kP249SubSubLordVOs = new List<KP249SubSubLordVO>();
                kP249SubSubLordVOs = (
                    from Map in KPBLL.kp249
                    where Map.Sno == sno
                    select Map).SingleOrDefault<KP249VO>().Sub_Sub_Lord.ToList<KP249SubSubLordVO>();
                kPPlanetMappingVO.Sub_Sub_Lord = (
                    from Map in kP249SubSubLordVOs
                    where (kPPlanetMappingVO.DegreePlanet_Decimal < Map.From_Degree_Decimal ? false : kPPlanetMappingVO.DegreePlanet_Decimal <= Map.To_Degree_Decimal)
                    select Map).FirstOrDefault<KP249SubSubLordVO>().Planet;
                KPDAO kPDAO = new KPDAO();
                kPPlanetMappingVO.isJadKharab = false;
                kPPlanetMappingVO.isManda = false;
                kPPlanetMappingVO.IsPakka = false;
                kPPlanetMappingVO.isbad = false;
                if (kPPlanetMappingVO.Planet <= 9)
                {
                    KPPlanetMappingVO kPPlanetMappingVO2 = kPPlanetMappingVO;
                    string mandeGhar = KPBLL.planet_list[kPPlanetMappingVO.Planet - 1].Mande_Ghar;
                    chrArray = new char[] { ',' };
                    string[] strArrays7 = mandeGhar.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                    short bhavChalitHouse = kPPlanetMappingVO.Bhav_Chalit_House;
                    kPPlanetMappingVO2.isManda = strArrays7.Contains<string>(bhavChalitHouse.ToString());
                    KPPlanetMappingVO kPPlanetMappingVO3 = kPPlanetMappingVO;
                    string pakkeGhar = KPBLL.planet_list[kPPlanetMappingVO.Planet - 1].Pakke_Ghar;
                    chrArray = new char[] { ',' };
                    string[] strArrays8 = pakkeGhar.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                    bhavChalitHouse = kPPlanetMappingVO.Bhav_Chalit_House;
                    kPPlanetMappingVO3.IsPakka = strArrays8.Contains<string>(bhavChalitHouse.ToString());
                    string shatru = KPBLL.planet_list[kPPlanetMappingVO.Planet - 1].Shatru;
                    chrArray = new char[] { ',' };
                    strArrays = shatru.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                    k = 0;
                    while (k < (int)strArrays.Length)
                    {
                        str = strArrays[k];
                        string str7 = strArrays3[Convert.ToInt16(str) - 1];
                        string pakkeGhar1 = KPBLL.planet_list[kPPlanetMappingVO.Planet - 1].Pakke_Ghar;
                        chrArray = new char[] { ',' };
                        if (!pakkeGhar1.Split(chrArray, StringSplitOptions.RemoveEmptyEntries).Contains<string>(str7))
                        {
                            k++;
                        }
                        else
                        {
                            kPPlanetMappingVO.isJadKharab = true;
                            break;
                        }
                    }
                }
                short num6 = 0;
                num6 = Convert.ToInt16(i + num2 - 1);
                if (num6 > 12)
                {
                    num6 = Convert.ToInt16(num6 - 12);
                }
                kPHouseMappingVO.House = Convert.ToInt16(i);
                kPHouseMappingVO.Rashi = Convert.ToInt16(strArrays4[i - 1]);
                kPHouseMappingVO.LaganRashi = num6;
                kPHouseMappingVO.DegreeHouse = strArrays6[i - 1];
                KPHouseMappingVO kPHouseMappingVO1 = kPHouseMappingVO;
                string degreeHouse = kPHouseMappingVO.DegreeHouse;
                chrArray = new char[] { ':' };
                double num7 = Convert.ToDouble(degreeHouse.Split(chrArray)[0]);
                string degreeHouse1 = kPHouseMappingVO.DegreeHouse;
                chrArray = new char[] { ':' };
                double num8 = Convert.ToDouble(degreeHouse1.Split(chrArray)[1]);
                string degreeHouse2 = kPHouseMappingVO.DegreeHouse;
                chrArray = new char[] { ':' };
                kPHouseMappingVO1.DegreeHouse_Decimal = kundliBLL.DMStoDecimal(num7, num8, Convert.ToDouble(degreeHouse2.Split(chrArray)[2]));
                if (kPHouseMappingVO.DegreeHouse_Decimal > 30)
                {
                    kPHouseMappingVO.DegreeHouse_Decimal = 30;
                }
                kPHouseMappingVO.Rashi_Lord = (
                    from Map in KPBLL.rashi_list
                    where Map.Rashi == kPHouseMappingVO.Rashi
                    select Map).SingleOrDefault<KPRashiVO>().Swami;
                kPHouseMappingVO.Nak_Lord = (
                    from Map in KPBLL.kp249
                    where (kPHouseMappingVO.DegreeHouse_Decimal < Map.From_Degree_Decimal || kPHouseMappingVO.DegreeHouse_Decimal > Map.To_Degree_Decimal ? false : Map.Rashi == kPHouseMappingVO.Rashi)
                    select Map).FirstOrDefault<KP249VO>().Nak_Lord;
                kPHouseMappingVO.Sub_Lord = (
                    from Map in KPBLL.kp249
                    where (kPHouseMappingVO.DegreeHouse_Decimal < Map.From_Degree_Decimal || kPHouseMappingVO.DegreeHouse_Decimal > Map.To_Degree_Decimal ? false : Map.Rashi == kPHouseMappingVO.Rashi)
                    select Map).FirstOrDefault<KP249VO>().Sub_Lord;
                short sno1 = (
                    from Map in KPBLL.kp249
                    where (kPHouseMappingVO.DegreeHouse_Decimal < Map.From_Degree_Decimal || kPHouseMappingVO.DegreeHouse_Decimal > Map.To_Degree_Decimal ? false : Map.Rashi == kPHouseMappingVO.Rashi)
                    select Map).FirstOrDefault<KP249VO>().Sno;
                List<KP249SubSubLordVO> kP249SubSubLordVOs1 = new List<KP249SubSubLordVO>();
                kP249SubSubLordVOs1 = (
                    from Map in KPBLL.kp249
                    where Map.Sno == sno1
                    select Map).SingleOrDefault<KP249VO>().Sub_Sub_Lord.ToList<KP249SubSubLordVO>();
                kPHouseMappingVO.Sub_Sub_Lord = (
                    from Map in kP249SubSubLordVOs1
                    where (kPHouseMappingVO.DegreeHouse_Decimal < Map.From_Degree_Decimal ? false : kPHouseMappingVO.DegreeHouse_Decimal <= Map.To_Degree_Decimal)
                    select Map).FirstOrDefault<KP249SubSubLordVO>().Planet;
                kPHouseMappingVO.Is_Manda = false;
                foreach (KPPlanetMappingVO list1 in (
                    from Map in kp_chart
                    where Map.Bhav_Chalit_House == kPHouseMappingVO.House
                    select Map).ToList<KPPlanetMappingVO>())
                {
                    if (list1.isManda)
                    {
                        kPHouseMappingVO.Is_Manda = true;
                    }
                }
                kp_chart.Add(kPPlanetMappingVO);
                cusp_house.Add(kPHouseMappingVO);
            }
            kp_chart = (
                from Map in kp_chart
                where Map.Planet <= 9
                select Map).ToList<KPPlanetMappingVO>();
            List<short> nums = new List<short>();
            List<short> nums1 = new List<short>();
            for (int j = 1; j <= 9; j++)
            {
                KPSigniVO kPSigniVO = new KPSigniVO();
                short nakLord = (
                    from Map in kp_chart
                    where Map.Planet == j
                    select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
                short bhavChalitHouse1 = (
                    from Map in kp_chart
                    where Map.Planet == nakLord
                    select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
                kPSigniVO = new KPSigniVO()
                {
                    Signi = bhavChalitHouse1,
                    Rule = 1,
                    WhichPlanet = nakLord
                };
                kp_chart[j - 1].Signi.Add(kPSigniVO);
                foreach (KPRashiVO kPRashiVO in (
                    from Map in KPBLL.rashi_list
                    where Map.Swami == nakLord
                    select Map).ToList<KPRashiVO>())
                {
                    foreach (KPHouseMappingVO list in (
                        from Map in cusp_house
                        where Map.Rashi == kPRashiVO.Rashi
                        select Map).ToList<KPHouseMappingVO>())
                    {
                        kPSigniVO = new KPSigniVO()
                        {
                            Signi = list.House,
                            Rule = 2,
                            WhichPlanet = nakLord
                        };
                        kp_chart[j - 1].Signi.Add(kPSigniVO);
                    }
                }
                kPSigniVO = new KPSigniVO()
                {
                    Signi = (
                        from Map in kp_chart
                        where Map.Planet == j
                        select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House,
                    Rule = 8,
                    WhichPlanet = Convert.ToInt16(j)
                };
                kp_chart[j - 1].Signi.Add(kPSigniVO);
                foreach (KPRashiVO kPRashiVO1 in (
                    from Map in KPBLL.rashi_list
                    where Map.Swami == j
                    select Map).ToList<KPRashiVO>())
                {
                    foreach (KPHouseMappingVO list2 in (
                        from Map in cusp_house
                        where Map.Rashi == kPRashiVO1.Rashi
                        select Map).ToList<KPHouseMappingVO>())
                    {
                        kPSigniVO = new KPSigniVO()
                        {
                            Signi = list2.House,
                            Rule = 9,
                            WhichPlanet = Convert.ToInt16(j)
                        };
                        kp_chart[j - 1].Signi.Add(kPSigniVO);
                    }
                }
            }
            foreach (KPPlanetsVO kPPlanetsVO in (
                from Map in KPBLL.planet_list
                where Map.Drishti.Length > 0
                orderby Map.Planet
                select Map).ToList<KPPlanetsVO>())
            {
                string drishti = kPPlanetsVO.Drishti;
                chrArray = new char[] { ',' };
                strArrays = drishti.Split(chrArray);
                for (k = 0; k < (int)strArrays.Length; k++)
                {
                    str = strArrays[k];
                    num1 = Convert.ToInt16((int)((
                        from Map in kp_chart
                        where Map.Planet == kPPlanetsVO.Planet
                        select Map).Single<KPPlanetMappingVO>().House + Convert.ToInt16(str)));
                    num1 = (short)(num1 - 1);
                    if (num1 > 12)
                    {
                        num1 = Convert.ToInt16(num1 - 12);
                    }
                    kPSigniVOs = new List<KPSigniVO>();
                    KPSigniVO kPSigniVO1 = new KPSigniVO()
                    {
                        Signi = num1,
                        Rule = 10,
                        WhichPlanet = Convert.ToInt16(kPPlanetsVO.Planet)
                    };
                    if (!(
                        from Map in kp_chart
                        where Map.Planet == kPPlanetsVO.Planet
                        select Map).SingleOrDefault<KPPlanetMappingVO>().Signi.Exists((KPSigniVO Map) => (Map.Signi != num1 ? false : Map.Rule == kPSigniVO1.Rule)))
                    {
                        kp_chart[kPPlanetsVO.Planet - 1].Signi.Add(kPSigniVO1);
                    }
                }
            }
            short rashi = (
                from Map in kp_chart
                where Map.Planet == 8
                select Map).SingleOrDefault<KPPlanetMappingVO>().Rashi;
            short rashi1 = (
                from Map in kp_chart
                where Map.Planet == 9
                select Map).SingleOrDefault<KPPlanetMappingVO>().Rashi;
            short swami = (
                from Map in KPBLL.rashi_list
                where Map.Rashi == rashi
                select Map).SingleOrDefault<KPRashiVO>().Swami;
            short swami1 = (
                from Map in KPBLL.rashi_list
                where Map.Rashi == rashi1
                select Map).SingleOrDefault<KPRashiVO>().Swami;
            foreach (KPSigniVO planetSigni in this.Get_Planet_Signis(kp_chart, swami))
            {
                KPSigniVO signi = new KPSigniVO();
                kPSigniVOs = new List<KPSigniVO>();
                signi.Signi = planetSigni.Signi;
                signi.Rule = 12;
                signi.WhichPlanet = 8;
                if (!(
                    from Map in kp_chart
                    where Map.Planet == 8
                    select Map).SingleOrDefault<KPPlanetMappingVO>().Signi.Exists((KPSigniVO Map) => (Map.Signi != planetSigni.Signi ? false : Map.Rule == signi.Rule)))
                {
                    kp_chart[7].Signi.Add(signi);
                }
            }
            foreach (KPSigniVO planetSigni1 in this.Get_Planet_Signis(kp_chart, swami1))
            {
                KPSigniVO signi1 = new KPSigniVO();
                kPSigniVOs = new List<KPSigniVO>();
                signi1.Signi = planetSigni1.Signi;
                signi1.Rule = 12;
                signi1.WhichPlanet = 9;
                if (!(
                    from Map in kp_chart
                    where Map.Planet == 9
                    select Map).SingleOrDefault<KPPlanetMappingVO>().Signi.Exists((KPSigniVO Map) => (Map.Signi != planetSigni1.Signi ? false : Map.Rule == signi1.Rule)))
                {
                    kp_chart[8].Signi.Add(signi1);
                }
            }
            short house = (
                from Map in kp_chart
                where Map.Planet == 8
                select Map).SingleOrDefault<KPPlanetMappingVO>().House;
            short house1 = (
                from Map in kp_chart
                where Map.Planet == 9
                select Map).SingleOrDefault<KPPlanetMappingVO>().House;
            foreach (KPPlanetsVO kPPlanetsVO1 in (
                from Map in KPBLL.planet_list
                where Map.Drishti.Length > 0
                select Map).ToList<KPPlanetsVO>())
            {
                string drishti1 = kPPlanetsVO1.Drishti;
                chrArray = new char[] { ',' };
                strArrays = drishti1.Split(chrArray);
                for (k = 0; k < (int)strArrays.Length; k++)
                {
                    str = strArrays[k];
                    num1 = Convert.ToInt16((int)((
                        from Map in kp_chart
                        where Map.Planet == kPPlanetsVO1.Planet
                        select Map).Single<KPPlanetMappingVO>().House + Convert.ToInt16(str)));
                    num1 = (short)(num1 - 1);
                    if (num1 > 12)
                    {
                        num1 = Convert.ToInt16(num1 - 12);
                    }
                    if (num1 == house)
                    {
                        nums.Add(kPPlanetsVO1.Planet);
                    }
                    if (num1 == house1)
                    {
                        nums1.Add(kPPlanetsVO1.Planet);
                    }
                }
            }
            foreach (short num in nums)
            {
                foreach (KPSigniVO planetSigni2 in this.Get_Planet_Signis(kp_chart, num))
                {
                    KPSigniVO kPSigniVO2 = new KPSigniVO();
                    kPSigniVOs = new List<KPSigniVO>();
                    kPSigniVO2.Signi = planetSigni2.Signi;
                    kPSigniVO2.Rule = 4;
                    kPSigniVO2.WhichPlanet = 8;
                    if (!(
                        from Map in kp_chart
                        where Map.Planet == 8
                        select Map).SingleOrDefault<KPPlanetMappingVO>().Signi.Exists((KPSigniVO Map) => (Map.Signi != planetSigni2.Signi ? false : Map.Rule == kPSigniVO2.Rule)))
                    {
                        kp_chart[7].Signi.Add(kPSigniVO2);
                    }
                }
            }
            foreach (short num9 in nums1)
            {
                foreach (KPSigniVO planetSigni3 in this.Get_Planet_Signis(kp_chart, num9))
                {
                    KPSigniVO signi2 = new KPSigniVO();
                    kPSigniVOs = new List<KPSigniVO>();
                    signi2.Signi = planetSigni3.Signi;
                    signi2.Rule = 4;
                    signi2.WhichPlanet = 9;
                    if (!(
                        from Map in kp_chart
                        where Map.Planet == 9
                        select Map).SingleOrDefault<KPPlanetMappingVO>().Signi.Exists((KPSigniVO Map) => (Map.Signi != planetSigni3.Signi ? false : Map.Rule == signi2.Rule)))
                    {
                        kp_chart[8].Signi.Add(signi2);
                    }
                }
            }
            short nakLord1 = (
                from Map in kp_chart
                where Map.Planet == 8
                select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
            short nakLord2 = (
                from Map in kp_chart
                where Map.Planet == 9
                select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
            foreach (KPPlanetsVO kPPlanetsVO2 in (
                from Map in KPBLL.planet_list
                where (Map.Drishti.Length <= 0 ? false : (Map.Planet == nakLord1 ? true : Map.Planet == nakLord2))
                orderby Map.Planet
                select Map).ToList<KPPlanetsVO>())
            {
                string drishti2 = kPPlanetsVO2.Drishti;
                chrArray = new char[] { ',' };
                strArrays = drishti2.Split(chrArray);
                for (k = 0; k < (int)strArrays.Length; k++)
                {
                    str = strArrays[k];
                    num1 = Convert.ToInt16((int)((
                        from Map in kp_chart
                        where Map.Planet == kPPlanetsVO2.Planet
                        select Map).Single<KPPlanetMappingVO>().House + Convert.ToInt16(str)));
                    num1 = (short)(num1 - 1);
                    if (num1 > 12)
                    {
                        num1 = Convert.ToInt16(num1 - 12);
                    }
                    kPSigniVOs = new List<KPSigniVO>();
                    KPSigniVO kPSigniVO3 = new KPSigniVO()
                    {
                        Signi = num1,
                        Rule = 7,
                        WhichPlanet = kPPlanetsVO2.Planet
                    };
                    if (!(
                        from Map in kp_chart
                        where Map.Planet == kPPlanetsVO2.Planet
                        select Map).SingleOrDefault<KPPlanetMappingVO>().Signi.Exists((KPSigniVO Map) => (Map.Signi != num1 ? false : Map.Rule == kPSigniVO3.Rule)))
                    {
                        kp_chart[kPPlanetsVO2.Planet - 1].Signi.Add(kPSigniVO3);
                    }
                }
            }
            foreach (KPPlanetsVO list3 in (
                from Map in KPBLL.planet_list
                where Map.Planet <= 7
                orderby Map.Planet
                select Map).ToList<KPPlanetsVO>())
            {
                short nakLord3 = (
                    from Map in kp_chart
                    where Map.Planet == list3.Planet
                    select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
                string drishti3 = KPBLL.planet_list[nakLord3 - 1].Drishti;
                if (drishti3.Length > 0)
                {
                    chrArray = new char[] { ',' };
                    strArrays = drishti3.Split(chrArray);
                    for (k = 0; k < (int)strArrays.Length; k++)
                    {
                        str = strArrays[k];
                        num1 = Convert.ToInt16((int)((
                            from Map in kp_chart
                            where Map.Planet == nakLord3
                            select Map).Single<KPPlanetMappingVO>().House + Convert.ToInt16(str)));
                        num1 = (short)(num1 - 1);
                        if (num1 > 12)
                        {
                            num1 = Convert.ToInt16(num1 - 12);
                        }
                        kPSigniVOs = new List<KPSigniVO>();
                        KPSigniVO kPSigniVO4 = new KPSigniVO()
                        {
                            Signi = num1,
                            Rule = 3,
                            WhichPlanet = list3.Planet
                        };
                        if (!(
                            from Map in kp_chart
                            where Map.Planet == list3.Planet
                            select Map).SingleOrDefault<KPPlanetMappingVO>().Signi.Exists((KPSigniVO Map) => (Map.Signi != num1 ? false : Map.Rule == kPSigniVO4.Rule)))
                        {
                            kp_chart[list3.Planet - 1].Signi.Add(kPSigniVO4);
                        }
                    }
                }
            }
            for (short l = 1; l <= 9; l = (short)(l + 1))
            {
                foreach (KPSigniVO planetSigni4 in this.Get_Planet_Signis(kp_chart, l))
                {
                    kPSigniVOs = new List<KPSigniVO>();
                    KPSigniVO kPSigniVO5 = new KPSigniVO()
                    {
                        Signi = l,
                        Rule = planetSigni4.Rule,
                        WhichPlanet = planetSigni4.WhichPlanet
                    };
                    kPSigniVOs = (
                        from Map in cusp_house
                        where Map.House == l
                        select Map).SingleOrDefault<KPHouseMappingVO>().Signi;
                    cusp_house[planetSigni4.Signi - 1].Signi.Add(kPSigniVO5);
                }
            }
        }

        public bool Saath_Lagte_Ghar(short master_planet, short slave_planet, List<KPPlanetMappingVO> kp_chart)
        {
            bool flag;
            bool flag1;
            bool flag2 = false;
            short bhavChalitHouse = kp_chart[master_planet - 1].Bhav_Chalit_House;
            short num = kp_chart[slave_planet - 1].Bhav_Chalit_House;
            short num1 = Convert.ToInt16((int)(bhavChalitHouse - num));
            if (bhavChalitHouse != 12)
            {
                flag = true;
            }
            else
            {
                flag = (num == 1 ? false : num != 11);
            }
            if (!flag)
            {
                flag2 = true;
            }
            if (bhavChalitHouse != 1)
            {
                flag1 = true;
            }
            else
            {
                flag1 = (num == 12 ? false : num != 2);
            }
            if (!flag1)
            {
                flag2 = true;
            }
            if ((bhavChalitHouse < 2 || bhavChalitHouse > 11 ? false : num1 == 1))
            {
                flag2 = true;
            }
            return flag2;
        }

        public void ScoreMM(bool isbad, bool verybad, bool married_life, bool occupation, bool santan, bool disease, bool male, string type)
        {
            short num = 0;
            if (isbad)
            {
                num = 5;
            }
            if (verybad)
            {
                num = 11;
            }
            if (type == "Maha")
            {
                num = Convert.ToInt16(num + 3);
            }
            if (male)
            {
                if ((married_life || occupation || santan ? true : disease))
                {
                    AstroGlobal.MM_total = (short)(AstroGlobal.MM_total + 5);
                }
                if (married_life)
                {
                    AstroGlobal.MM_married = (short)(AstroGlobal.MM_married + Convert.ToInt16(num + 3));
                }
                if (occupation)
                {
                    AstroGlobal.MM_profession = (short)(AstroGlobal.MM_profession + Convert.ToInt16(num + 6));
                }
                if (santan)
                {
                    AstroGlobal.MM_child = (short)(AstroGlobal.MM_child + Convert.ToInt16(num + 3));
                }
                if (disease)
                {
                    AstroGlobal.MM_health = (short)(AstroGlobal.MM_health + Convert.ToInt16(num + 4));
                }
            }
            if (!male)
            {
                if ((married_life || occupation || santan ? true : disease))
                {
                    AstroGlobal.MF_total = (short)(AstroGlobal.MF_total + 5);
                }
                if (married_life)
                {
                    AstroGlobal.MF_married = (short)(AstroGlobal.MF_married + Convert.ToInt16(num + 4));
                }
                if (occupation)
                {
                    AstroGlobal.MF_profession = (short)(AstroGlobal.MF_profession + Convert.ToInt16(num + 3));
                }
                if (santan)
                {
                    AstroGlobal.MF_child = (short)(AstroGlobal.MF_child + Convert.ToInt16(num + 5));
                }
                if (disease)
                {
                    AstroGlobal.MF_health = (short)(AstroGlobal.MF_health + Convert.ToInt16(num + 5));
                }
            }
        }

        public string ScoreTY(short planet, bool ShadiYog, bool Talak, bool VeryBad, string mtype, DateTime StartDate, DateTime EndDate, ProductSettingsVO prod, KundliVO persKV, List<KPPlanetMappingVO> kp_chart, List<KPHouseMappingVO> cusp_house, string signi, string nak_signi, short curage)
        {
            string str;
            bool flag;
            bool flag1;
            bool flag2;
            bool flag3;
            bool flag4;
            bool flag5;
            bool flag6;
            bool flag7;
            bool flag8;
            string str1 = "";
            PredictionBLL predictionBLL = new PredictionBLL();
            short bhavChalitHouse = (
                from Map in kp_chart
                where Map.Planet == planet
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            bool flag9 = false;
            short subLord = (
                from Map in cusp_house
                where Map.House == 7
                select Map).SingleOrDefault<KPHouseMappingVO>().Sub_Lord;
            short nakLord = (
                from Map in cusp_house
                where Map.House == 7
                select Map).SingleOrDefault<KPHouseMappingVO>().Nak_Lord;
            string[] strArrays = new string[] { StartDate.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", StartDate.ToString("%M")), persKV.Language, true, true), " ", StartDate.ToString("yyyy") };
            string str2 = string.Concat(strArrays);
            strArrays = new string[] { EndDate.ToString("dd"), " ", predictionBLL.GetCodeLang(string.Concat("M", EndDate.ToString("%M")), persKV.Language, true, true), " ", EndDate.ToString("yyyy") };
            string str3 = string.Concat(strArrays);
            char[] chrArray = new char[] { ' ' };
            string[] strArrays1 = signi.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
            chrArray = new char[] { ' ' };
            string[] strArrays2 = nak_signi.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
            if (!Talak)
            {
                if (!strArrays1.Contains<string>("6") || !strArrays1.Contains<string>("10"))
                {
                    flag5 = (!strArrays2.Contains<string>("6") ? true : !strArrays2.Contains<string>("10"));
                }
                else
                {
                    flag5 = false;
                }
                if (!flag5)
                {
                    Talak = true;
                }
                if (!strArrays1.Contains<string>("6") || !strArrays1.Contains<string>("10") || !strArrays1.Contains<string>("3"))
                {
                    flag6 = (!strArrays2.Contains<string>("6") || !strArrays2.Contains<string>("10") ? true : !strArrays2.Contains<string>("3"));
                }
                else
                {
                    flag6 = false;
                }
                if (!flag6)
                {
                    Talak = true;
                }
                if (!strArrays1.Contains<string>("3") || !strArrays1.Contains<string>("8"))
                {
                    flag7 = (!strArrays2.Contains<string>("3") ? true : !strArrays2.Contains<string>("8"));
                }
                else
                {
                    flag7 = false;
                }
                if (!flag7)
                {
                    Talak = true;
                }
                if (!strArrays1.Contains<string>("3") || !strArrays1.Contains<string>("8") || !strArrays1.Contains<string>("12"))
                {
                    flag8 = (!strArrays2.Contains<string>("3") || !strArrays2.Contains<string>("8") ? true : !strArrays2.Contains<string>("12"));
                }
                else
                {
                    flag8 = false;
                }
                if (!flag8)
                {
                    Talak = true;
                }
            }
            if (!strArrays1.Contains<string>("2") || !strArrays1.Contains<string>("7") || !strArrays1.Contains<string>("11"))
            {
                flag = (!strArrays2.Contains<string>("7") || !strArrays2.Contains<string>("2") ? true : !strArrays2.Contains<string>("11"));
            }
            else
            {
                flag = false;
            }
            if (!flag)
            {
                ShadiYog = true;
            }
            if (!strArrays1.Contains<string>("2") || !strArrays1.Contains<string>("12"))
            {
                flag1 = (!strArrays2.Contains<string>("12") ? true : !strArrays2.Contains<string>("2"));
            }
            else
            {
                flag1 = false;
            }
            if (!flag1)
            {
                ShadiYog = true;
            }
            if (!strArrays1.Contains<string>("2") || !strArrays1.Contains<string>("7"))
            {
                flag2 = (!strArrays2.Contains<string>("7") ? true : !strArrays2.Contains<string>("2"));
            }
            else
            {
                flag2 = false;
            }
            if (!flag2)
            {
                ShadiYog = true;
            }
            if (!strArrays1.Contains<string>("7") || !strArrays1.Contains<string>("11"))
            {
                flag3 = (!strArrays2.Contains<string>("7") ? true : !strArrays2.Contains<string>("11"));
            }
            else
            {
                flag3 = false;
            }
            if (!flag3)
            {
                ShadiYog = true;
            }
            if ((planet == nakLord ? true : planet == subLord))
            {
                ShadiYog = true;
            }
            if (strArrays1.Contains<string>("6") && (strArrays1.Contains<string>("8") || strArrays1.Contains<string>("3")))
            {
                flag4 = false;
            }
            else if (!strArrays2.Contains<string>("6"))
            {
                flag4 = true;
            }
            else
            {
                flag4 = (strArrays2.Contains<string>("8") ? false : !strArrays2.Contains<string>("3"));
            }
            if (!flag4)
            {
                if ((ShadiYog ? false : !Talak))
                {
                    flag9 = true;
                }
            }
            if ((!ShadiYog ? false : curage <= 36))
            {
                str = str1;
                strArrays = new string[] { str, "\r\n\r\n आपकी ", str2, " से ", str3, " तक शादी होने की सम्भावना है या कोई नया गहरा प्रेम सम्बन्ध बनेगा " };
                str1 = string.Concat(strArrays);
            }
            if ((!Talak ? false : curage >= 21))
            {
                str = str1;
                strArrays = new string[] { str, "\r\n\r\n आपका ", str2, " से ", str3, " के बीच में तलाक होने के प्रबल योग है और अगर शादीशुदा नहीं हैं तो आपका अपनी प्रेमिका से अलगाव हो सकता है " };
                str1 = string.Concat(strArrays);
            }
            if ((ShadiYog || Talak || !VeryBad || curage < 22 ? flag9 : true))
            {
                str = str1;
                strArrays = new string[] { str, "\r\n\r\n आपका वैवाहिक जीवन ", str2, " से ", str3, " तक बहुत ख़राब रहेगा या अगर आप लिविन रिलेशन में हैं या शादी के लिए रिश्ते ढूँढ रहे हैं तो काफी कठिनाइयाँ आएँगी " };
                str1 = string.Concat(strArrays);
            }
            return str1;
        }

        public bool Sitting_in_Shatru_House(short planet, List<KPPlanetMappingVO> kp_chart)
        {
            bool flag = false;
            short bhavChalitHouse = kp_chart[planet - 1].Bhav_Chalit_House;
            string shatru = KPBLL.planet_list[planet - 1].Shatru;
            char[] chrArray = new char[] { ',' };
            List<string> list = shatru.Split(chrArray, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            List<string> strs = new List<string>();
            foreach (string str in list)
            {
                string pakkeGhar = KPBLL.planet_list[Convert.ToInt16(str) - 1].Pakke_Ghar;
                chrArray = new char[] { ',' };
                if (pakkeGhar.Split(chrArray, StringSplitOptions.RemoveEmptyEntries).ToList<string>().Contains(bhavChalitHouse.ToString()))
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        public bool Sitting_with_Shatru(short planet, List<KPPlanetMappingVO> kp_chart)
        {
            bool flag = false;
            short bhavChalitHouse = kp_chart[planet - 1].Bhav_Chalit_House;
            string shatru = KPBLL.planet_list[planet - 1].Shatru;
            char[] chrArray = new char[] { ',' };
            List<string> list = shatru.Split(chrArray, StringSplitOptions.RemoveEmptyEntries).ToList<string>();
            List<string> strs = new List<string>();
            foreach (string str in list)
            {
                if (bhavChalitHouse != (
                    from Map in kp_chart
                    where Map.Planet == Convert.ToInt16(str)
                    select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House)
                {
                    flag = false;
                    break;
                }
                else
                {
                    flag = true;
                }
            }
            return flag;
        }

        public string Spl_Yog(ProductSettingsVO prod, List<KPPlanetMappingVO> kp_chart, List<KPHouseMappingVO> cusp_house, KundliVO persKV)
        {
            long num;
            KPUpayList kPUpayList;
            string str;
            object obj;
            object[] sno;
            short sno1;
            string str1;
            string[] codeLang;
            long fakeCode;
            List<KPMixDashaVO> kPMixDashaVOs = new List<KPMixDashaVO>();
            List<KPMixDashaVO> kPMixDashaVOs1 = new List<KPMixDashaVO>();
            PredictionBLL predictionBLL = new PredictionBLL();
            predictionBLL.GetCodeLang("umar_str", persKV.Language, true, true);
            string str2 = "<b><u>नीचे दिए गये विशेष योग या उमरों के आधार पर दिए गये फल का उपाय जीवन मे केवल एक बार करना है.</u></b>\r\n\r\n";
            string str3 = "<u>उमरों के आधार पर शुभ फल</u>\r\n";
            string str4 = "<u>उमरों के आधार पर अशुभ फल</u>\r\n";
            string str5 = "<u>जीवन मे होने वाले कुछ शुभ योग</u>\r\n";
            string str6 = "<u>जीवन मे होने वाले कुछ अशुभ योग</u>\r\n";
            string str7 = "";
            string str8 = "";
            string str9 = "";
            string str10 = "";
            string str11 = "";
            kPMixDashaVOs = new List<KPMixDashaVO>();
            kPMixDashaVOs1 = new List<KPMixDashaVO>();
            KPDAO kPDAO = new KPDAO();
            foreach (KPPlanetMappingVO kpChart in kp_chart)
            {
                kPMixDashaVOs.AddRange(kPDAO.Get_Mix_Dasha(kpChart.Planet, kpChart.House, 1, prod.Product, "spl_yog").ToList<KPMixDashaVO>());
                kPMixDashaVOs1.AddRange(kPDAO.Get_Mix_Dasha(kpChart.Planet, kpChart.House, 1, prod.Product, "age").ToList<KPMixDashaVO>());
            }
            List<short> nums = new List<short>();
            List<short> nums1 = new List<short>();
            foreach (KPMixDashaVO kPMixDashaVO in kPMixDashaVOs)
            {
                KPRemediesVO kPRemediesVO = new KPRemediesVO();
                if (!nums.Exists((short Map) => Map == kPMixDashaVO.Sno))
                {
                    if (this.isAllConditionMet(kPMixDashaVO, kp_chart, "", ""))
                    {
                        if (prod.Lang.ToLower() == "hindi")
                        {
                            if (!kPMixDashaVO.Isbad)
                            {
                                if (persKV.ShowRef)
                                {
                                    obj = str9;
                                    sno = new object[] { obj, "A_mix_dasha : ", kPMixDashaVO.Sno, " " };
                                    str9 = string.Concat(sno);
                                }
                                str9 = string.Concat(str9, kPMixDashaVO.Pred_Hindi, "\r\n\r\n");
                            }
                            if (kPMixDashaVO.Isbad)
                            {
                                if (persKV.ShowRef)
                                {
                                    obj = str10;
                                    sno = new object[] { obj, "A_mix_dasha : ", kPMixDashaVO.Sno, " " };
                                    str10 = string.Concat(sno);
                                }
                                str10 = string.Concat(str10, kPMixDashaVO.Pred_Hindi, "\r\n\r\n");
                            }
                        }
                        nums.Add(kPMixDashaVO.Sno);
                        if ((!kPMixDashaVO.Isbad || kPMixDashaVO.Pred_Hindi.Trim().Length < 20 ? false : prod.ShowUpayCode))
                        {
                            kPRemediesVO = (
                                from Map in KPBLL.Remedy_List_General
                                where (long)Map.RuleCode == kPMixDashaVO.Upay
                                select Map).FirstOrDefault<KPRemediesVO>();
                            if (kPRemediesVO == null)
                            {
                                kPRemediesVO = (
                                    from Map in KPBLL.Remedy_List_IA
                                    where (Map.Planet != kPMixDashaVO.Planet1 ? false : Map.House == kPMixDashaVO.House1)
                                    select Map).FirstOrDefault<KPRemediesVO>();
                            }
                            if (kPRemediesVO != null)
                            {
                                kPUpayList = new KPUpayList();
                                if (this.upay_list.Exists((KPUpayList Map) => Map.Sno == (long)kPRemediesVO.Sno))
                                {
                                    fakeCode = (
                                        from Map in this.upay_list
                                        where Map.Sno.ToString() == kPRemediesVO.Sno.ToString()
                                        select Map).SingleOrDefault<KPUpayList>().FakeCode;
                                    str = fakeCode.ToString();
                                    if (!persKV.ShowRef)
                                    {
                                        str1 = str10;
                                        codeLang = new string[] { str1, "  <I>", predictionBLL.GetCodeLang("upay", persKV.Language, true, true), "</I> ", str.ToString(), this.Gen_Link((long)kPRemediesVO.Sno, prod.Gen_Link, Convert.ToInt64(str), false, (long)kPMixDashaVO.Sno, "R"), "\r\n\r\n" };
                                        str10 = string.Concat(codeLang);
                                    }
                                    else
                                    {
                                        str1 = str10;
                                        codeLang = new string[] { str1, "  [ A_kp_remedy : ", kPRemediesVO.Ptype, "  ", null, null, null, null, null, null };
                                        sno1 = kPRemediesVO.Sno;
                                        codeLang[4] = sno1.ToString();
                                        codeLang[5] = " ] ";
                                        codeLang[6] = predictionBLL.GetCodeLang("upay", persKV.Language, true, true);
                                        codeLang[7] = " ";
                                        codeLang[8] = str.ToString();
                                        codeLang[9] = "\r\n\r\n";
                                        str10 = string.Concat(codeLang);
                                    }
                                }
                                else
                                {
                                    num = (long)(this.upay_list.Count<KPUpayList>() + 1);
                                    sno1 = kPRemediesVO.Sno;
                                    kPUpayList.Sno = (long)Convert.ToInt16(sno1.ToString());
                                    sno1 = kPRemediesVO.Sno;
                                    kPUpayList.Code = (long)Convert.ToInt16(sno1.ToString());
                                    kPUpayList.FakeCode = num;
                                    if (persKV.Language.ToLower() == "hindi")
                                    {
                                        kPUpayList.Upay = kPRemediesVO.Pred_Hindi;
                                    }
                                    if (persKV.Language.ToLower() == "english")
                                    {
                                        kPUpayList.Upay = kPRemediesVO.Pred_English;
                                    }
                                    this.upay_list.Add(kPUpayList);
                                    if (!persKV.ShowRef)
                                    {
                                        str1 = str10;
                                        codeLang = new string[] { str1, "  <I>", predictionBLL.GetCodeLang("upay", persKV.Language, true, true), "</I> ", num.ToString(), this.Gen_Link((long)kPRemediesVO.Sno, prod.Gen_Link, num, false, (long)kPMixDashaVO.Sno, "R"), "\r\n\r\n" };
                                        str10 = string.Concat(codeLang);
                                    }
                                    else
                                    {
                                        str1 = str10;
                                        codeLang = new string[] { str1, "  [ A_kp_remedy : ", kPRemediesVO.Ptype, "  ", null, null, null, null, null, null };
                                        sno1 = kPRemediesVO.Sno;
                                        codeLang[4] = sno1.ToString();
                                        codeLang[5] = " ] ";
                                        codeLang[6] = predictionBLL.GetCodeLang("upay", persKV.Language, true, true);
                                        codeLang[7] = " ";
                                        codeLang[8] = num.ToString();
                                        codeLang[9] = "\r\n\r\n";
                                        str10 = string.Concat(codeLang);
                                    }
                                }
                            }
                        }
                        if ((!kPMixDashaVO.Isbad || kPRemediesVO == null || !prod.ShowUpayCode ? str10.Length >= 50 : false))
                        {
                            str10 = string.Concat(str10, "\r\n\r\n");
                        }
                    }
                }
            }
            foreach (KPMixDashaVO kPMixDashaVO1 in kPMixDashaVOs1)
            {
                KPRemediesVO kPRemediesVO1 = new KPRemediesVO();
                if (!nums1.Exists((short Map) => Map == kPMixDashaVO1.Sno))
                {
                    if (this.isAllConditionMet(kPMixDashaVO1, kp_chart, "", ""))
                    {
                        if (prod.Lang.ToLower() == "hindi")
                        {
                            if (!kPMixDashaVO1.Isbad)
                            {
                                if (persKV.ShowRef)
                                {
                                    obj = str7;
                                    sno = new object[] { obj, "A_mix_dasha : ", kPMixDashaVO1.Sno, " " };
                                    str7 = string.Concat(sno);
                                }
                                str7 = string.Concat(str7, kPMixDashaVO1.Pred_Hindi, "\r\n\r\n");
                            }
                            if (kPMixDashaVO1.Isbad)
                            {
                                if (persKV.ShowRef)
                                {
                                    obj = str8;
                                    sno = new object[] { obj, "A_mix_dasha : ", kPMixDashaVO1.Sno, " " };
                                    str8 = string.Concat(sno);
                                }
                                str8 = string.Concat(str8, kPMixDashaVO1.Pred_Hindi, "\r\n\r\n");
                            }
                        }
                        nums1.Add(kPMixDashaVO1.Sno);
                        if ((!kPMixDashaVO1.Isbad || kPMixDashaVO1.Pred_Hindi.Trim().Length < 20 ? false : prod.ShowUpayCode))
                        {
                            kPRemediesVO1 = (
                                from Map in KPBLL.Remedy_List_General
                                where (long)Map.RuleCode == kPMixDashaVO1.Upay
                                select Map).FirstOrDefault<KPRemediesVO>();
                            if (kPRemediesVO1 == null)
                            {
                                kPRemediesVO1 = (
                                    from Map in KPBLL.Remedy_List_IA
                                    where (Map.Planet != kPMixDashaVO1.Planet1 ? false : Map.House == kPMixDashaVO1.House1)
                                    select Map).FirstOrDefault<KPRemediesVO>();
                            }
                            if (kPRemediesVO1 != null)
                            {
                                kPUpayList = new KPUpayList();
                                if (this.upay_list.Exists((KPUpayList Map) => Map.Sno == (long)kPRemediesVO1.Sno))
                                {
                                    fakeCode = (
                                        from Map in this.upay_list
                                        where Map.Sno.ToString() == kPRemediesVO1.Sno.ToString()
                                        select Map).SingleOrDefault<KPUpayList>().FakeCode;
                                    str = fakeCode.ToString();
                                    if (!persKV.ShowRef)
                                    {
                                        str1 = str8;
                                        codeLang = new string[] { str1, "  <I>", predictionBLL.GetCodeLang("upay", persKV.Language, true, true), "</I> ", str.ToString(), this.Gen_Link((long)kPRemediesVO1.Sno, prod.Gen_Link, Convert.ToInt64(str), false, (long)kPMixDashaVO1.Sno, "R"), "\r\n\r\n" };
                                        str8 = string.Concat(codeLang);
                                    }
                                    else
                                    {
                                        str1 = str8;
                                        codeLang = new string[] { str1, "  [ A_kp_remedy : ", kPRemediesVO1.Ptype, "  ", null, null, null, null, null, null };
                                        sno1 = kPRemediesVO1.Sno;
                                        codeLang[4] = sno1.ToString();
                                        codeLang[5] = " ] ";
                                        codeLang[6] = predictionBLL.GetCodeLang("upay", persKV.Language, true, true);
                                        codeLang[7] = " ";
                                        codeLang[8] = str.ToString();
                                        codeLang[9] = "\r\n\r\n";
                                        str8 = string.Concat(codeLang);
                                    }
                                }
                                else
                                {
                                    num = (long)(this.upay_list.Count<KPUpayList>() + 1);
                                    sno1 = kPRemediesVO1.Sno;
                                    kPUpayList.Sno = (long)Convert.ToInt16(sno1.ToString());
                                    sno1 = kPRemediesVO1.Sno;
                                    kPUpayList.Code = (long)Convert.ToInt16(sno1.ToString());
                                    kPUpayList.FakeCode = num;
                                    if (persKV.Language.ToLower() == "hindi")
                                    {
                                        kPUpayList.Upay = kPRemediesVO1.Pred_Hindi;
                                    }
                                    if (persKV.Language.ToLower() == "english")
                                    {
                                        kPUpayList.Upay = kPRemediesVO1.Pred_English;
                                    }
                                    this.upay_list.Add(kPUpayList);
                                    if (!persKV.ShowRef)
                                    {
                                        str1 = str8;
                                        codeLang = new string[] { str1, "  <I>", predictionBLL.GetCodeLang("upay", persKV.Language, true, true), "</I> ", num.ToString(), this.Gen_Link((long)kPRemediesVO1.Sno, prod.Gen_Link, num, false, (long)kPMixDashaVO1.Sno, "R"), "\r\n\r\n" };
                                        str8 = string.Concat(codeLang);
                                    }
                                    else
                                    {
                                        str1 = str8;
                                        codeLang = new string[] { str1, "  [ A_kp_remedy : ", kPRemediesVO1.Ptype, "  ", null, null, null, null, null, null };
                                        sno1 = kPRemediesVO1.Sno;
                                        codeLang[4] = sno1.ToString();
                                        codeLang[5] = " ] ";
                                        codeLang[6] = predictionBLL.GetCodeLang("upay", persKV.Language, true, true);
                                        codeLang[7] = " ";
                                        codeLang[8] = num.ToString();
                                        codeLang[9] = "\r\n\r\n";
                                        str8 = string.Concat(codeLang);
                                    }
                                }
                            }
                        }
                        if ((!kPMixDashaVO1.Isbad || kPRemediesVO1 == null || !prod.ShowUpayCode ? str8.Length >= 50 : false))
                        {
                            str8 = string.Concat(str8, "\r\n\r\n");
                        }
                    }
                }
            }
            string str12 = "";
            string str13 = "";
            if (str7.Trim().Length >= 50)
            {
                str1 = str12;
                codeLang = new string[] { str1, str3, "\r\n\r\n", str7, "\r\n\r\n" };
                str12 = string.Concat(codeLang);
            }
            if (str8.Trim().Length >= 50)
            {
                str1 = str12;
                codeLang = new string[] { str1, str4, "\r\n\r\n", str8, "\r\n\r\n" };
                str12 = string.Concat(codeLang);
            }
            if (str9.Trim().Length >= 50)
            {
                str1 = str13;
                codeLang = new string[] { str1, str5, "\r\n\r\n", str9, "\r\n\r\n" };
                str13 = string.Concat(codeLang);
            }
            if (str10.Trim().Length >= 50)
            {
                str1 = str13;
                codeLang = new string[] { str1, str6, "\r\n\r\n", str10, "\r\n\r\n" };
                str13 = string.Concat(codeLang);
            }
            if (str13.Trim().Length >= 50)
            {
                str11 = string.Concat(str11, str13);
            }
            if (str12.Trim().Length >= 50)
            {
                str11 = string.Concat(str11, str12);
            }
            str11 = (str11.Trim().Length <= 50 ? "" : string.Concat(str2, str11));
            return str11;
        }

        public string Tenth_Kamkaj_Pred(List<KPHouseMappingVO> cusp_house, List<KPPlanetMappingVO> kp_chart, KundliVO persKV)
        {
            bool flag;
            bool flag1;
            bool flag2;
            string str = "";
            List<short> nums = new List<short>();
            List<KPMixDashaVO> kPMixDashaVOs = new List<KPMixDashaVO>();
            KPDAO kPDAO = new KPDAO();
            KPBLL kPBLL = new KPBLL();
            short subLord = (
                from Map in cusp_house
                where Map.House == 10
                select Map).SingleOrDefault<KPHouseMappingVO>().Sub_Lord;
            short nakLord = (
                from Map in kp_chart
                where Map.Planet == subLord
                select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
            short num = (
                from Map in kp_chart
                where Map.Planet == nakLord
                select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
            List<short> list = new List<short>();
            bool flag3 = false;
            bool flag4 = false;
            bool flag5 = false;
            List<KPSigniVO> kPSigniVOs = new List<KPSigniVO>();
            List<KPSigniVO> signi = new List<KPSigniVO>();
            List<KPSigniVO> kPSigniVOs1 = new List<KPSigniVO>();
            List<KPSigniVO> signi1 = new List<KPSigniVO>();
            List<KPSigniVO> kPSigniVOs2 = new List<KPSigniVO>();
            List<KPSigniVO> signi2 = new List<KPSigniVO>();
            short num1 = 0;
            short num2 = 0;
            num1 = Convert.ToInt16((
                from Map in cusp_house
                where Map.House == 6
                select Map).SingleOrDefault<KPHouseMappingVO>().Sub_Lord);
            num2 = Convert.ToInt16((
                from Map in kp_chart
                where Map.Planet == num1
                select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord);
            kPSigniVOs2 = (
                from Map in kp_chart
                where Map.Planet == num1
                select Map).SingleOrDefault<KPPlanetMappingVO>().Signi;
            signi = (
                from Map in kp_chart
                where Map.Planet == num2
                select Map).SingleOrDefault<KPPlanetMappingVO>().Signi;
            num1 = Convert.ToInt16((
                from Map in cusp_house
                where Map.House == 7
                select Map).SingleOrDefault<KPHouseMappingVO>().Sub_Lord);
            num2 = Convert.ToInt16((
                from Map in kp_chart
                where Map.Planet == num1
                select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord);
            signi1 = (
                from Map in kp_chart
                where Map.Planet == num1
                select Map).SingleOrDefault<KPPlanetMappingVO>().Signi;
            kPSigniVOs = (
                from Map in kp_chart
                where Map.Planet == num2
                select Map).SingleOrDefault<KPPlanetMappingVO>().Signi;
            num1 = Convert.ToInt16((
                from Map in cusp_house
                where Map.House == 10
                select Map).SingleOrDefault<KPHouseMappingVO>().Sub_Lord);
            num2 = Convert.ToInt16((
                from Map in kp_chart
                where Map.Planet == num1
                select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord);
            signi2 = (
                from Map in kp_chart
                where Map.Planet == num1
                select Map).SingleOrDefault<KPPlanetMappingVO>().Signi;
            kPSigniVOs1 = (
                from Map in kp_chart
                where Map.Planet == num2
                select Map).SingleOrDefault<KPPlanetMappingVO>().Signi;
            if ((
                from Map in signi1
                where Map.Signi == 2
                select Map).Count<KPSigniVO>() < 1)
            {
                if ((
                    from Map in signi1
                    where Map.Signi == 7
                    select Map).Count<KPSigniVO>() < 1)
                {
                    if ((
                        from Map in signi1
                        where Map.Signi == 11
                        select Map).Count<KPSigniVO>() >= 1)
                    {
                        goto Label1;
                    }
                    if ((
                        from Map in kPSigniVOs
                        where Map.Signi == 2
                        select Map).Count<KPSigniVO>() < 1)
                    {
                        if ((
                            from Map in kPSigniVOs
                            where Map.Signi == 7
                            select Map).Count<KPSigniVO>() >= 1)
                        {
                            goto Label3;
                        }
                        flag = (
                            from Map in kPSigniVOs
                            where Map.Signi == 11
                            select Map).Count<KPSigniVO>() < 1;
                        goto Label0;
                    }
                    Label3:
                    flag = false;
                    goto Label0;
                }
            }
            Label1:
            flag = false;
            Label0:
            if (!flag)
            {
                flag4 = true;
            }
            if ((
                from Map in kPSigniVOs2
                where Map.Signi == 2
                select Map).Count<KPSigniVO>() < 1)
            {
                if ((
                    from Map in kPSigniVOs2
                    where Map.Signi == 6
                    select Map).Count<KPSigniVO>() < 1)
                {
                    if ((
                        from Map in kPSigniVOs2
                        where Map.Signi == 11
                        select Map).Count<KPSigniVO>() >= 1)
                    {
                        goto Label5;
                    }
                    if ((
                        from Map in signi
                        where Map.Signi == 2
                        select Map).Count<KPSigniVO>() < 1)
                    {
                        if ((
                            from Map in signi
                            where Map.Signi == 6
                            select Map).Count<KPSigniVO>() >= 1)
                        {
                            goto Label7;
                        }
                        flag1 = (
                            from Map in signi
                            where Map.Signi == 11
                            select Map).Count<KPSigniVO>() < 1;
                        goto Label4;
                    }
                    Label7:
                    flag1 = false;
                    goto Label4;
                }
            }
            Label5:
            flag1 = false;
            Label4:
            if (!flag1)
            {
                flag3 = true;
            }
            if ((
                from Map in signi2
                where Map.Signi == 2
                select Map).Count<KPSigniVO>() < 1)
            {
                if ((
                    from Map in signi2
                    where Map.Signi == 10
                    select Map).Count<KPSigniVO>() < 1)
                {
                    if ((
                        from Map in signi2
                        where Map.Signi == 11
                        select Map).Count<KPSigniVO>() >= 1)
                    {
                        goto Label9;
                    }
                    if ((
                        from Map in kPSigniVOs1
                        where Map.Signi == 2
                        select Map).Count<KPSigniVO>() < 1)
                    {
                        if ((
                            from Map in kPSigniVOs1
                            where Map.Signi == 10
                            select Map).Count<KPSigniVO>() >= 1)
                        {
                            goto Label11;
                        }
                        flag2 = (
                            from Map in kPSigniVOs1
                            where Map.Signi == 11
                            select Map).Count<KPSigniVO>() < 1;
                        goto Label8;
                    }
                    Label11:
                    flag2 = false;
                    goto Label8;
                }
            }
            Label9:
            flag2 = false;
            Label8:
            if (!flag2)
            {
                flag5 = true;
            }
            List<KPSigniVO> signi3 = (
                from Map in kp_chart
                where Map.Planet == num1
                select Map).SingleOrDefault<KPPlanetMappingVO>().Signi;
            short bhavChalitHouse = (
                from Map in kp_chart
                where Map.Planet == nakLord
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            short bhavChalitHouse1 = (
                from Map in kp_chart
                where Map.Planet == num
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            list.Add(bhavChalitHouse);
            string signiStringOnlyRashi = kPBLL.Get_Signi_String_Only_Rashi(subLord, kp_chart, false);
            char[] chrArray = new char[] { ' ' };
            string[] strArrays = signiStringOnlyRashi.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                list.Add(Convert.ToInt16(strArrays[i]));
            }
            list = list.Distinct<short>().ToList<short>();
            foreach (short num3 in list)
            {
                kPMixDashaVOs.AddRange((
                    from Map in kPDAO.Get_Mix_Dasha(nakLord, num3, 1, "work_pred", "dasha")
                    where (!Map.work_pred || Map.Planet2 != 0 ? false : Map.lawtype != "KP")
                    select Map).ToList<KPMixDashaVO>());
            }
            foreach (KPMixDashaVO kPMixDashaVO in kPMixDashaVOs)
            {
                if (persKV.ShowRef)
                {
                    str = string.Concat(str, kPMixDashaVO.Sno, " ");
                }
                if (!kPMixDashaVO.Isbad)
                {
                    if (!nums.Exists((short Map) => Map == kPMixDashaVO.Sno))
                    {
                        str = string.Concat(str, this.Get_KP_Lang(kPMixDashaVO.Sno, persKV.Language, false, false, false), "\r\n");
                    }
                    nums.Add(kPMixDashaVO.Sno);
                }
            }
            str = string.Concat(str, this.Tenth_Kamkaj_Pred_NEW(cusp_house, kp_chart, persKV));
            return str;
        }

        public string Tenth_Kamkaj_Pred_NEW(List<KPHouseMappingVO> cusp_house, List<KPPlanetMappingVO> kp_chart, KundliVO persKV)
        {
            string str = "";
            List<short> nums = new List<short>();
            List<KPMixDashaVO> kPMixDashaVOs = new List<KPMixDashaVO>();
            KPDAO kPDAO = new KPDAO();
            KPBLL kPBLL = new KPBLL();
            short subLord = (
                from Map in cusp_house
                where Map.House == 10
                select Map).SingleOrDefault<KPHouseMappingVO>().Sub_Lord;
            short nakLord = (
                from Map in kp_chart
                where Map.Planet == subLord
                select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
            short num = (
                from Map in kp_chart
                where Map.Planet == nakLord
                select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
            List<short> list = new List<short>();
            short bhavChalitHouse = (
                from Map in kp_chart
                where Map.Planet == nakLord
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            short bhavChalitHouse1 = (
                from Map in kp_chart
                where Map.Planet == num
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            list.Add(bhavChalitHouse);
            string signiStringOnlyRashi = kPBLL.Get_Signi_String_Only_Rashi(subLord, kp_chart, false);
            char[] chrArray = new char[] { ' ' };
            string[] strArrays = signiStringOnlyRashi.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                list.Add(Convert.ToInt16(strArrays[i]));
            }
            list = list.Distinct<short>().ToList<short>();
            foreach (short num1 in list)
            {
                kPMixDashaVOs.AddRange((
                    from Map in kPDAO.Get_Mix_Dasha(nakLord, num1, 1, "work_pred", "dasha")
                    where (!Map.work_pred || Map.Planet2 != 0 ? false : Map.lawtype == "KP")
                    select Map).ToList<KPMixDashaVO>());
            }
            str = string.Concat(str, "\r\n\r\n");
            foreach (KPMixDashaVO kPMixDashaVO in kPMixDashaVOs)
            {
                if (persKV.ShowRef)
                {
                    str = string.Concat(str, kPMixDashaVO.Sno, " ");
                }
                if (!nums.Exists((short Map) => Map == kPMixDashaVO.Sno))
                {
                    str = string.Concat(str, this.Get_KP_Lang(kPMixDashaVO.Sno, persKV.Language, false, false, false), "\r\n");
                }
                nums.Add(kPMixDashaVO.Sno);
            }
            return str;
        }

        public string Tenth_Sublord_Pred(List<KPHouseMappingVO> cusp_house, List<KPPlanetMappingVO> kp_chart, KundliVO persKV)
        {
            string predHindi = "";
            short subLord = 0;
            double degreePlanetDecimal = 0;
            short rashi = 0;
            KPDAO kPDAO = new KPDAO();
            subLord = (
                from Map in cusp_house
                where Map.House == 10
                select Map).SingleOrDefault<KPHouseMappingVO>().Sub_Lord;
            rashi = (
                from Map in kp_chart
                where Map.Planet == subLord
                select Map).SingleOrDefault<KPPlanetMappingVO>().Rashi;
            degreePlanetDecimal = (
                from Map in kp_chart
                where Map.Planet == subLord
                select Map).SingleOrDefault<KPPlanetMappingVO>().DegreePlanet_Decimal;
            short sno = (
                from Map in KPBLL.kp249
                where (degreePlanetDecimal <= Map.From_Degree_Decimal || degreePlanetDecimal > Map.To_Degree_Decimal ? false : Map.Rashi == rashi)
                select Map).SingleOrDefault<KP249VO>().Sno;
            if (persKV.Language.ToLower() == "hindi")
            {
                predHindi = (
                    from Map in kPDAO.Get_KP_Occupation_Pred()
                    where Map.KPno == (long)sno
                    select Map).SingleOrDefault<KP_Occupation>().Pred_Hindi;
            }
            if (persKV.Language.ToLower() == "english")
            {
                predHindi = (
                    from Map in kPDAO.Get_KP_Occupation_Pred()
                    where Map.KPno == (long)sno
                    select Map).SingleOrDefault<KP_Occupation>().Pred_English;
            }
            if (persKV.Language.ToLower() == "tamil")
            {
                predHindi = (
                    from Map in kPDAO.Get_KP_Occupation_Pred()
                    where Map.KPno == (long)sno
                    select Map).SingleOrDefault<KP_Occupation>().pred_tamil;
            }
            if ((persKV.Language.ToLower() == "bangla" ? true : persKV.Language.Trim().ToLower() == "bengali"))
            {
                predHindi = (
                    from Map in kPDAO.Get_KP_Occupation_Pred()
                    where Map.KPno == (long)sno
                    select Map).SingleOrDefault<KP_Occupation>().pred_bengali;
            }
            if (persKV.Language.ToLower() == "telugu")
            {
                predHindi = (
                    from Map in kPDAO.Get_KP_Occupation_Pred()
                    where Map.KPno == (long)sno
                    select Map).SingleOrDefault<KP_Occupation>().pred_telugu;
            }
            if (persKV.Language.ToLower() == "kannada")
            {
                predHindi = (
                    from Map in kPDAO.Get_KP_Occupation_Pred()
                    where Map.KPno == (long)sno
                    select Map).SingleOrDefault<KP_Occupation>().pred_kannada;
            }
            if (persKV.Language.ToLower() == "marathi")
            {
                predHindi = (
                    from Map in kPDAO.Get_KP_Occupation_Pred()
                    where Map.KPno == (long)sno
                    select Map).SingleOrDefault<KP_Occupation>().pred_marathi;
            }
            if (persKV.Language.ToLower() == "gujarati")
            {
                predHindi = (
                    from Map in kPDAO.Get_KP_Occupation_Pred()
                    where Map.KPno == (long)sno
                    select Map).SingleOrDefault<KP_Occupation>().pred_gujarati;
            }
            if (persKV.Language.ToLower() == "punjabi")
            {
                predHindi = (
                    from Map in kPDAO.Get_KP_Occupation_Pred()
                    where Map.KPno == (long)sno
                    select Map).SingleOrDefault<KP_Occupation>().pred_punjabi;
            }
            if (persKV.Language.ToLower() == "oriya")
            {
                predHindi = (
                    from Map in kPDAO.Get_KP_Occupation_Pred()
                    where Map.KPno == (long)sno
                    select Map).SingleOrDefault<KP_Occupation>().pred_oriya;
            }
            if (persKV.Language.ToLower() == "malayalam")
            {
                predHindi = (
                    from Map in kPDAO.Get_KP_Occupation_Pred()
                    where Map.KPno == (long)sno
                    select Map).SingleOrDefault<KP_Occupation>().pred_malayalam;
            }
            if (persKV.Language.ToLower() == "assamese")
            {
                predHindi = (
                    from Map in kPDAO.Get_KP_Occupation_Pred()
                    where Map.KPno == (long)sno
                    select Map).SingleOrDefault<KP_Occupation>().pred_assamese;
            }
            return predHindi;
        }
    }
}