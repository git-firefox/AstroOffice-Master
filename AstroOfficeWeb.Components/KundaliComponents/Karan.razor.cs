using System;
using System.Collections.Generic;
using System.Linq;
using AstroOfficeWeb.Shared.Methods;
using AstroOfficeWeb.Shared.ViewModels;
using AstroOfficeWeb.Shared.VOs;
using Microsoft.AspNetCore.Components;

namespace AstroOfficeWeb.Components.KundaliComponents
{
    public partial class Karan
    {
        private List<KaranTableModel>? KaranModelTableData { get; set; }
        private KPBLL KPBL { get; set; } = new();

        private List<KPPlanetsVO> PlanetList = new List<KPPlanetsVO>();

        protected override void OnInitialized()
        {
            PlanetList = KPBL.Fill_Planets();
            Gen_Upay_Chart(KPPlanetMappingVOs, KPHouseMappingVOs);
        }

        private void Gen_Upay_Chart(IEnumerable<KPPlanetMappingVO> kp_chart, IEnumerable<KPHouseMappingVO> cusp_house)
        {
            if (KaranModelTableData == null)
            {
                KaranModelTableData = new List<KaranTableModel>();
            }
            else
            {
                KaranModelTableData.Clear();
            }

            List<KPSigniVO>? signi = null;
            char[] chrArray;
            string str;
            string[] hindi;

            List<KPUpay> kPUpays = new List<KPUpay>();


            foreach (KPUpay upayLogic in this.KPUpays)
            {
                short rule = 0;
                string red = "";
                string darkSeaGreen = "";
                string str1 = "";
                string str2 = "";

                KPPlanetMappingVO kPPlanetMappingVO = new KPPlanetMappingVO();

                short subLord = cusp_house.SingleOrDefault<KPHouseMappingVO>(Map => Map.House == upayLogic.House)?.Sub_Lord ?? default;

                short nakLord = kp_chart.SingleOrDefault<KPPlanetMappingVO>(Map => Map.Planet == subLord)?.Nak_Lord ?? default;

                short num = cusp_house.SingleOrDefault<KPHouseMappingVO>(Map => Map.House == upayLogic.House)?.Nak_Lord ?? default;

                short rashiLord = cusp_house.SingleOrDefault<KPHouseMappingVO>(Map => Map.House == upayLogic.House)?.Rashi_Lord ?? default;

                kPPlanetMappingVO = kp_chart.SingleOrDefault<KPPlanetMappingVO>(Map => Map.Planet == nakLord) ?? new KPPlanetMappingVO();

                foreach (KPSigniVO kPSigniVO1 in kPPlanetMappingVO.Signi.OrderBy(Map => Map.Rule))
                {
                    if (IsSahasaneLogic)
                    {
                        if (rule != kPSigniVO1.Rule)
                        {
                            str1 = string.Concat(str1, " | ");
                            rule = kPSigniVO1.Rule;
                        }
                        string str3 = upayLogic.Good.ToString();
                        chrArray = new char[] { ',' };
                        if (str3.Split(chrArray).ToList<string>().Contains(kPSigniVO1.Signi.ToString()))
                        {
                            darkSeaGreen = string.Concat(darkSeaGreen, kPSigniVO1.Signi, "-");
                        }
                        string str4 = upayLogic.Bad.ToString();
                        chrArray = new char[] { ',' };
                        if (str4.Split(chrArray).ToList<string>().Contains(kPSigniVO1.Signi.ToString()))
                        {
                            red = string.Concat(red, kPSigniVO1.Signi, "-");
                        }
                        str1 = string.Concat(str1, kPSigniVO1.Signi, " ");
                    }
                    else if ((kPSigniVO1.Rule == 1 || kPSigniVO1.Rule == 2 || kPSigniVO1.Rule == 8 ? true : kPSigniVO1.Rule == 9))
                    {
                        if (rule != kPSigniVO1.Rule)
                        {
                            str1 = string.Concat(str1, " | ");
                            rule = kPSigniVO1.Rule;
                        }
                        string str5 = upayLogic.Good.ToString();
                        chrArray = new char[] { ',' };
                        if (str5.Split(chrArray).ToList<string>().Contains(kPSigniVO1.Signi.ToString()))
                        {
                            darkSeaGreen = string.Concat(darkSeaGreen, kPSigniVO1.Signi, "-");
                        }
                        string str6 = upayLogic.Bad.ToString();
                        chrArray = new char[] { ',' };
                        if (str6.Split(chrArray).ToList<string>().Contains(kPSigniVO1.Signi.ToString()))
                        {
                            red = string.Concat(red, kPSigniVO1.Signi, "-");
                        }
                        str1 = string.Concat(str1, kPSigniVO1.Signi, " ");
                    }
                }
                string str7 = darkSeaGreen.Trim();
                chrArray = new char[] { '-' };
                darkSeaGreen = str7.TrimEnd(chrArray);
                string str8 = red.Trim();
                chrArray = new char[] { '-' };
                red = str8.TrimEnd(chrArray);
                string str9 = str1.Trim();
                chrArray = new char[] { '|' };
                str1 = str9.TrimEnd(chrArray);
                List<KPSigniVO> kPSigniVOs = new List<KPSigniVO>();

                kPSigniVOs = (
                    from Map in cusp_house
                    where Map.House == upayLogic.House
                    select Map).SingleOrDefault<KPHouseMappingVO>()?.Signi ?? new List<KPSigniVO>();

                foreach (KPSigniVO kPSigniVO2 in
                    from Map in kPSigniVOs
                    where (Map.Rule == 1 || Map.Rule == 2 || Map.Rule == 8 ? true : Map.Rule == 9)
                    select Map)
                {
                    signi = (
                        from Map in kp_chart
                        where Map.Planet == kPSigniVO2.Signi
                        select Map).SingleOrDefault<KPPlanetMappingVO>()?.Signi ?? new List<KPSigniVO>();

                    foreach (KPSigniVO kPSigniVO in
                        from Map in signi
                        where (Map.Rule == 1 || Map.Rule == 2 || Map.Rule == 8 ? true : Map.Rule == 9)
                        select Map)
                    {
                        chrArray = new char[] { '-' };
                        if (red.Split(chrArray).ToList<string>().Contains(kPSigniVO.Signi.ToString()))
                        {
                            chrArray = new char[] { '-' };
                            if (!str2.Split(chrArray).ToList<string>().Contains(this.PlanetList[kPSigniVO2.Signi - 1].Hindi))
                            {
                                object obj = str2;
                                object[] objArray = new object[] { obj, this.PlanetList[kPSigniVO2.Signi - 1].Hindi, "(", kPSigniVO.Signi, ")-" };
                                str2 = string.Concat(objArray);
                            }
                        }
                    }
                }
                chrArray = new char[] { '-' };
                if (red.Split(chrArray).ToList<string>().Contains(num.ToString()))
                {
                    chrArray = new char[] { '-' };
                    if (!str2.Split(chrArray).ToList<string>().Contains(this.PlanetList[num - 1].Hindi))
                    {
                        signi = (
                            from Map in kp_chart
                            where Map.Planet == num
                            select Map).SingleOrDefault<KPPlanetMappingVO>()?.Signi ?? new List<KPSigniVO>();

                        string str10 = "";
                        foreach (KPSigniVO kPSigniVO3 in
                            from Map in signi
                            where (Map.Rule == 1 || Map.Rule == 2 || Map.Rule == 8 ? true : Map.Rule == 9)
                            select Map)
                        {
                            chrArray = new char[] { '-' };
                            if (red.Split(chrArray).ToList<string>().Contains(kPSigniVO3.Signi.ToString()))
                            {
                                chrArray = new char[] { '-' };
                                if (!str2.Split(chrArray).ToList<string>().Contains(this.PlanetList[num - 1].Hindi))
                                {
                                    str10 = string.Concat(str10, kPSigniVO3.Signi, ",");
                                }
                            }
                        }
                        string str11 = str10.Trim();
                        chrArray = new char[] { ',' };
                        str10 = str11.TrimEnd(chrArray);
                        str = str2;
                        hindi = new string[] { str, this.PlanetList[num - 1].Hindi, "(", str10, ")-" };
                        str2 = string.Concat(hindi);
                    }
                }
                string str12 = "";
                chrArray = new char[] { '-' };
                if (red.Split(chrArray).ToList<string>().Contains(rashiLord.ToString()))
                {
                    chrArray = new char[] { '-' };
                    if (!str2.Split(chrArray).ToList<string>().Contains(this.PlanetList[rashiLord - 1].Hindi))
                    {
                        signi = (
                            from Map in kp_chart
                            where Map.Planet == rashiLord
                            select Map).SingleOrDefault<KPPlanetMappingVO>()?.Signi ?? new List<KPSigniVO>();

                        foreach (KPSigniVO kPSigniVO4 in
                            from Map in signi
                            where (Map.Rule == 1 || Map.Rule == 2 || Map.Rule == 8 ? true : Map.Rule == 9)
                            select Map)
                        {
                            chrArray = new char[] { '-' };
                            if (red.Split(chrArray).ToList<string>().Contains(kPSigniVO4.Signi.ToString()))
                            {
                                chrArray = new char[] { '-' };
                                if (!str2.Split(chrArray).ToList<string>().Contains(this.PlanetList[rashiLord - 1].Hindi))
                                {
                                    str12 = string.Concat(str12, kPSigniVO4.Signi, ",");
                                }
                            }
                        }
                        string str13 = str12.Trim();
                        chrArray = new char[] { ',' };
                        str12 = str13.TrimEnd(chrArray);
                        if (str12.Length >= 1)
                        {
                            str = str2;
                            hindi = new string[] { str, this.PlanetList[rashiLord - 1].Hindi, "(", str12, ")-" };
                            str2 = string.Concat(hindi);
                        }
                    }
                }
                List<KPPlanetMappingVO> kPPlanetMappingVOs = new List<KPPlanetMappingVO>();
                kPPlanetMappingVOs = (
                    from Map in kp_chart
                    where Map.House == upayLogic.House
                    select Map).ToList<KPPlanetMappingVO>();
                string str14 = "";
                foreach (KPPlanetMappingVO kPPlanetMappingVO1 in kPPlanetMappingVOs)
                {
                    chrArray = new char[] { '-' };
                    if (red.Split(chrArray).ToList<string>().Contains(kPPlanetMappingVO1.Planet.ToString()))
                    {
                        chrArray = new char[] { '-' };
                        if (!str2.Split(chrArray).ToList<string>().Contains(this.PlanetList[kPPlanetMappingVO1.Planet - 1].Hindi))
                        {
                            signi = (
                                from Map in kp_chart
                                where Map.Planet == kPPlanetMappingVO1.Planet
                                select Map).SingleOrDefault<KPPlanetMappingVO>()?.Signi ?? new List<KPSigniVO>();

                            foreach (KPSigniVO kPSigniVO5 in
                                from Map in signi
                                where (Map.Rule == 1 || Map.Rule == 2 || Map.Rule == 8 ? true : Map.Rule == 9)
                                select Map)
                            {
                                chrArray = new char[] { '-' };
                                if (red.Split(chrArray).ToList<string>().Contains(kPSigniVO5.Signi.ToString()))
                                {
                                    chrArray = new char[] { '-' };
                                    if (!str2.Split(chrArray).ToList<string>().Contains(this.PlanetList[rashiLord - 1].Hindi))
                                    {
                                        str14 = string.Concat(str14, kPPlanetMappingVO1.Planet, ",");
                                    }
                                }
                            }
                            string str15 = str14.Trim();
                            chrArray = new char[] { ',' };
                            str14 = str15.TrimEnd(chrArray);
                            if (str14.Length >= 1)
                            {
                                str = str2;
                                hindi = new string[] { str, this.PlanetList[kPPlanetMappingVO1.Planet - 1].Hindi, "(", str14, ")-" };
                                str2 = string.Concat(hindi);
                            }
                        }
                    }
                }
                string str16 = str2.Trim();
                chrArray = new char[] { '-' };
                str2 = str16.TrimEnd(chrArray);



                var tr = new KaranTableModel
                {
                    Problem = upayLogic.Problem,
                    House = upayLogic.House,
                    Significators = str1,
                    Good = darkSeaGreen, // .BackColor = Color.DarkSeaGreen;
                    Bad = red, // .ForeColor = Color.Red;
                    KaranPlanet = str2,
                    Position = upayLogic.Good
                };

                KaranModelTableData.Add(tr);
            }
        }
    }
}
