using AstroOfficeWeb.Client.Helper;
using AstroOfficeWeb.Client.Models;
using AstroOfficeWeb.Client.Services;
using AstroOfficeWeb.Client.Services.IService;
using AstroOfficeWeb.Shared.Models;
using AstroShared.Methods;
using AstroShared.Models;
using Microsoft.AspNetCore.Components;

namespace AstroOfficeWeb.Client.Pages
{
    public partial class Karan
    {

        [Inject]
        ISwaggerApiService? Swagger { get; set; }

        [Inject]
        KaranService? KaranService { get; set; }

        public List<KaranTableModel>? KaranModelTableData { get; set; }
        public SavedStateModel SavedStateModel { get; set; } = new();

        private KPBLL kpbl = new();

        private List<KPPlanetsVO> planet_list = new List<KPPlanetsVO>();
        private List<KPUpay> KPUpays = new();

        protected override void OnInitialized()
        {
            planet_list = kpbl.Fill_Planets();
        }

        protected override async Task OnInitializedAsync()
        {
            var planetMappingVOs = await KaranService!.GetKPPlanetMappingVOs();
            var houseMappingVOs = await KaranService!.GetKPHouseMappingVOs();
            var savedStateModel = await KaranService!.GetSavedStateModel();
            var kPs = await Swagger!.GetAsync<List<KPUpay>>(KPDAOApiConst.GET_GetUpayLogic);

            this.SavedStateModel = savedStateModel;
            this.KPUpays = kPs ?? new List<KPUpay>();

            Gen_Upay_Chart(planetMappingVOs, houseMappingVOs);
        }

        private void Gen_Upay_Chart(List<KPPlanetMappingVO> kp_chart, List<KPHouseMappingVO> cusp_house)
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
                //if (!this.LstViewKPUpay.InvokeRequired)
                //{
                //    this.LstViewKPUpay.Items.Add(upayLogic.Problem).SubItems.Add(upayLogic.House.ToString());
                //}
                //else
                //{
                //    this.LstViewKPUpay.Invoke(new MethodInvoker(() => this.LstViewKPUpay.Items.Add(upayLogic.Problem).SubItems.Add(upayLogic.House.ToString())));
                //}
                short rule = 0;
                string red = "";
                string darkSeaGreen = "";
                string str1 = "";
                string str2 = "";

                KPPlanetMappingVO kPPlanetMappingVO = new KPPlanetMappingVO();

                short subLord = (
                    from Map in cusp_house
                    where Map.House == upayLogic.House
                    select Map).SingleOrDefault<KPHouseMappingVO>()?.Sub_Lord ?? default;

                short nakLord = (
                    from Map in kp_chart
                    where Map.Planet == subLord
                    select Map).SingleOrDefault<KPPlanetMappingVO>()?.Nak_Lord ?? default;

                short num = (
                    from Map in cusp_house
                    where Map.House == upayLogic.House
                    select Map).SingleOrDefault<KPHouseMappingVO>()?.Nak_Lord ?? default;

                short rashiLord = (
                    from Map in cusp_house
                    where Map.House == upayLogic.House
                    select Map).SingleOrDefault<KPHouseMappingVO>()?.Rashi_Lord ?? default;

                kPPlanetMappingVO = (
                    from Map in kp_chart
                    where Map.Planet == nakLord
                    select Map).SingleOrDefault<KPPlanetMappingVO>() ?? new KPPlanetMappingVO();

                foreach (KPSigniVO kPSigniVO1 in kPPlanetMappingVO.Signi.OrderBy(Map => Map.Rule))
                {
                    if (this.SavedStateModel!.ChkSahasaneLogic)
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
                            if (!str2.Split(chrArray).ToList<string>().Contains(this.planet_list[kPSigniVO2.Signi - 1].Hindi))
                            {
                                object obj = str2;
                                object[] objArray = new object[] { obj, this.planet_list[kPSigniVO2.Signi - 1].Hindi, "(", kPSigniVO.Signi, ")-" };
                                str2 = string.Concat(objArray);
                            }
                        }
                    }
                }
                chrArray = new char[] { '-' };
                if (red.Split(chrArray).ToList<string>().Contains(num.ToString()))
                {
                    chrArray = new char[] { '-' };
                    if (!str2.Split(chrArray).ToList<string>().Contains(this.planet_list[num - 1].Hindi))
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
                                if (!str2.Split(chrArray).ToList<string>().Contains(this.planet_list[num - 1].Hindi))
                                {
                                    str10 = string.Concat(str10, kPSigniVO3.Signi, ",");
                                }
                            }
                        }
                        string str11 = str10.Trim();
                        chrArray = new char[] { ',' };
                        str10 = str11.TrimEnd(chrArray);
                        str = str2;
                        hindi = new string[] { str, this.planet_list[num - 1].Hindi, "(", str10, ")-" };
                        str2 = string.Concat(hindi);
                    }
                }
                string str12 = "";
                chrArray = new char[] { '-' };
                if (red.Split(chrArray).ToList<string>().Contains(rashiLord.ToString()))
                {
                    chrArray = new char[] { '-' };
                    if (!str2.Split(chrArray).ToList<string>().Contains(this.planet_list[rashiLord - 1].Hindi))
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
                                if (!str2.Split(chrArray).ToList<string>().Contains(this.planet_list[rashiLord - 1].Hindi))
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
                            hindi = new string[] { str, this.planet_list[rashiLord - 1].Hindi, "(", str12, ")-" };
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
                        if (!str2.Split(chrArray).ToList<string>().Contains(this.planet_list[kPPlanetMappingVO1.Planet - 1].Hindi))
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
                                    if (!str2.Split(chrArray).ToList<string>().Contains(this.planet_list[rashiLord - 1].Hindi))
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
                                hindi = new string[] { str, this.planet_list[kPPlanetMappingVO1.Planet - 1].Hindi, "(", str14, ")-" };
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
                    Good = darkSeaGreen,
                    Bad = red,
                    KaranPlanet = str2,
                    Position = upayLogic.Good
                };

                KaranModelTableData.Add(tr);
                //this.LstViewKPUpay.Items[this.LstViewKPUpay.Items.Count - 1].SubItems.Add(str1);
                //this.LstViewKPUpay.Items[this.LstViewKPUpay.Items.Count - 1].SubItems.Add(darkSeaGreen).BackColor = Color.DarkSeaGreen;
                //this.LstViewKPUpay.Items[this.LstViewKPUpay.Items.Count - 1].SubItems.Add(red).ForeColor = Color.Red;
                //this.LstViewKPUpay.Items[this.LstViewKPUpay.Items.Count - 1].SubItems.Add(str2);
                //this.LstViewKPUpay.Items[this.LstViewKPUpay.Items.Count - 1].SubItems.Add(upayLogic.Good);
            }
            //this.LstViewKPUpay.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            //this.LstViewKPUpay.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }




    }



}
