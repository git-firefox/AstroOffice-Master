using AstroOfficeWeb.Client.Helper;
using AstroOfficeWeb.Client.Models;
using AstroOfficeWeb.Client.Services.IService;
using DTOs = AstroOfficeWeb.Shared.DTOs;
using AstroOfficeWeb.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using AstroShared.Models;
using AstroShared.Methods;
using AstroOfficeWeb.Client.Services;
using AstroOfficeWeb.Client.Shared;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Collections.Generic;

namespace AstroOfficeWeb.Client.Pages
{
    public partial class Dashboard
    {
        #region Inject Services

        [Inject]
        ISwaggerApiService? Swagger { get; set; }

        [Inject]
        KaranService? KaranService { get; set; }

        #endregion

        #region Define Variables

        private string Online_Result = "";
        private string RP_Online_Result = "";

        private string full_lat = "";
        private string full_lon = "";
        private string full_tz = "";
        private string full_time_corr = "";
        private string global_full_lonNew = "";
        private string global_full_latNew = "";
        private string global_newtz = "";

        private string ayan = "L";

        private bool male = true;
        private bool show_vfal = false;
        private bool maha_dasha_click = true;
        private bool antar_dasha_click = true;
        private bool no_countryload = false;
        private bool sukshma_dasha_click = true;

        private KundliVO persKV = new KundliVO();
        private ProductSettingsVO prod = new ProductSettingsVO();
        private KPBLL kpbl = new KPBLL();
        private KundliBLL kkbl = new KundliBLL();
        //private KPPredBLL kppred = new KPPredBLL();

        private List<PlanetVO> pvl = new List<PlanetVO>();

        private List<short> Varshfal_month = new List<short>();
        private List<short> Varshfal_years = new List<short>();

        private List<KPHouseMappingVO> cusp_house = new List<KPHouseMappingVO>();
        private List<KPPlanetMappingVO> kp_chart = new List<KPPlanetMappingVO>();
        private List<KPPlanetsVO> planet_list = new List<KPPlanetsVO>();
        private List<KPHouseMappingVO>? last_cusp_house = new List<KPHouseMappingVO>();
        private List<KPPlanetMappingVO>? last_kp_chart = new List<KPPlanetMappingVO>();
        private List<KPRashiVO> rashi_list = new List<KPRashiVO>();
        private List<KPNAKVO> nak_list = new List<KPNAKVO>();
        private List<KPDashaVO> main_mahadasha = new List<KPDashaVO>();
        private List<KPHousesVO> house_list = new List<KPHousesVO>();
        private List<KP249VO> kp249 = new List<KP249VO>();
        private List<KPDashaVO> main_antardasha = new List<KPDashaVO>();
        private List<KPDashaVO> main_pryaantardasha = new List<KPDashaVO>();
        private List<KPDashaVO> main_sukhsmadasha = new List<KPDashaVO>();

        private bool isNumVarshVisible = false;
        private bool dobddEnabled = true;
        private bool dobmmEnabled = true;
        private bool dobyyEnabled = true;
        private bool tobhhEnabled = true;
        private bool tobmmEnabled = true;
        private bool tobssEnabled = true;
        private bool txtBirthPlaceEnabled = true;

        private int selectedBirthCityIndex = 0;

        private InputText? inputTextName;
        private InputText? inputTextBirthPlace;
        private FaladeshModal FaladeshModal = new();

        private string? imgSrc;
        private string? imgSrcLagan;
        private string? imgSrcBhavChalit;
        private string? htmlStringFalla;

        private List<DTOs.APlaceMaster>? ListBirthCities = new();
        private SavedStateModel SavedStateModel = new();

        #region View Models Data

        public List<SelectListItem>? CmbCountry { get; set; }
        private BirthDetails BirthDetails { get; set; } = new();
        private BirthDetailsLookups BirthDetailsLookups { get; set; } = new();
        private BestKundaliDatesModel BestKundaliDates { get; set; } = new();
        private DateFinderModel DateFinder { get; set; } = new();

        #endregion

        #region View Tables Data

        public List<ChartPlanetTableTRModel>? ListView_Planet { get; set; }
        public List<ChartHouseTableTRModel>? ListView_House { get; set; }
        public List<KundaliTableTRModel>? ListView_Ruling_Planet { get; set; }
        public List<MahadashaTableTRModel>? ListView_Mahadasha { get; set; }
        public List<AntardashaTableTRModel>? ListView_Antardasha { get; set; }
        public List<PrayantardashaTableTRModel>? ListView_Prayantardasha { get; set; }
        public List<SukhsmadashaTableTRModel>? ListView_Sukhsmadasha { get; set; }
        public List<Years35TableTRModel>? ListView_Years35 { get; set; }

        #endregion

        #region  Mahadasha Lables
        public string LblMahadasha
        {
            get { return string.IsNullOrEmpty(lblMahadasha) ? "-" : lblMahadasha; }
            set { lblMahadasha = value; }
        }

        public string LblAntar
        {
            get { return string.IsNullOrEmpty(lblAntar) ? "-" : lblAntar; }
            set { lblAntar = value; }
        }

        public string LblParyan
        {
            get { return string.IsNullOrEmpty(lblParyan) ? "-" : lblParyan; }
            set { lblParyan = value; }
        }

        public string LblSukhsmadasha
        {
            get { return string.IsNullOrEmpty(lblSukhsmadasha) ? "-" : lblSukhsmadasha; }
            set { lblSukhsmadasha = value; }
        }


        private string lblMahadasha = string.Empty;
        private string lblAntar = string.Empty;
        private string lblParyan = string.Empty;
        private string lblSukhsmadasha = string.Empty;
        #endregion

        #endregion

        protected override void OnInitialized()
        {
            this.show_vfal = false;
            this.isNumVarshVisible = false;
            this.BestKundaliDates.Pick_start_date = DateTime.Now.Date;
            this.BestKundaliDates.Pick_end_date = DateTime.Now.AddDays(1);

            this.planet_list = this.kpbl.Fill_Planets();
            this.house_list = this.kpbl.Fill_Houses();
            this.nak_list = this.kpbl.Fill_Nak();
            this.rashi_list = this.kpbl.Fill_Rashi();

            this.BirthDetails.TxtBirthPlace = "Delhi";

            this.BirthDetails.Dobdd = 12;
            this.BirthDetails.Dobmm = 05;
            this.BirthDetails.Dobyy = 2006;
            this.BirthDetails.Tobhh = 13;
            this.BirthDetails.Tobmm = 25;

            OnChange_CmbTime(new ChangeEventArgs { Value = BirthDetailsLookups.CmbTimeItems.First().Text });
            OnChange_CmbAyanansh(new ChangeEventArgs { Value = BirthDetailsLookups.CmbAyananshItems.First().Text });
            OnChange_CmbSkipBad(new ChangeEventArgs { Value = BirthDetailsLookups.SkipBadItems.First().Text });
            OnChange_CmbLanguage(new ChangeEventArgs { Value = BirthDetailsLookups.LanguageItems.First().Text });
        }

        protected override async Task OnInitializedAsync()
        {
            var countryMasters = await Swagger!.GetAsync<List<DTOs.ACountryMaster>>(CountryApiConst.GET_GetCountry);
            var planetVOs = (await Swagger!.GetAsync<List<PlanetVO>>(PlanetBLLApiConst.GET_GetKPPlanetsVOs)) ?? new List<PlanetVO>();
            var kP249s = (await Swagger!.GetAsync<List<KP249VO>>(KPBLLApiConst.GET_Fill_249)) ?? new List<KP249VO>();


            #region LoadCountry
            this.CmbCountry = countryMasters?.Select(cm => new SelectListItem(cm.Country, cm.CountryCode)).ToList();

            if (!this.no_countryload && this.BirthDetails.CmbCountry != null)
            {
                await this.LoadCountry();// !
            }
            this.no_countryload = false;
            #endregion

            string str = this.full_lon.Replace(":", ".");
            string str1 = this.full_lat.Replace(":", ".");
            str = string.Concat(this.kkbl.DecimalToDMS(Convert.ToDouble(str.Substring(0, str.Length - 1))).ToString(), str.Substring(str.Length - 1, 1));
            str1 = string.Concat(this.kkbl.DecimalToDMS(Convert.ToDouble(str1.Substring(0, str1.Length - 1))).ToString(), str1.Substring(str1.Length - 1, 1));
            string str2 = this.kkbl.longi2timezone(this.full_tz);

            if (str.Length == 6)
            {
                str = string.Concat("0", str);
            }
            if (str1.Length == 5)
            {
                str1 = string.Concat("0", str1);
            }

            string text = $"{this.BirthDetails.Dobdd}/{this.BirthDetails.Dobmm}/{this.BirthDetails.Dobyy},{this.BirthDetails.Tobhh}:{this.BirthDetails.Tobmm},{str},{str1},{str2},{this.ayan},{this.full_time_corr}";

            this.Online_Result = await Gen_Kunda(text, 500f, this.BirthDetails.CmbRotate);
            this.pvl = planetVOs;
            this.kp249 = kP249s;

            var kundliVO = await Map_PersKV(Online_Result, BirthDetails.TxtName, BirthDetails.BirthCity, BirthDetails.Dobdd.ToString(), BirthDetails.Dobmm.ToString(), BirthDetails.Dobyy.ToString(), BirthDetails.Tobhh.ToString(), BirthDetails.Tobmm.ToString(), "00", "admin", BirthDetails.Longtitude, BirthDetails.Latitude, BirthDetails.TxtTimezone, true, BirthDetails.CmbLanguage, BirthDetails.ChkShowRef, this.male, "YICC", "YICC", "YICC", "YICC", "YICC", "New Product", "01", "01", "2000", 1);
            if (kundliVO != null)
            {
                this.persKV = kundliVO;
            }

            await Gen_Image(this.persKV!.Lagna.ToString(), this.kp_chart, Online_Result, false, 1, this.persKV.Language);

            await this.OnKeyDown_TxtBirthplace(new KeyboardEventArgs());
            await this.OnClick_BtnChart(new MouseEventArgs());

            await base.OnInitializedAsync();
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
            if (firstRender)
            {
                await JSRuntime.FocusAsync(inputTextName?.Element);
            }
        }

        #region Methods

        private async Task<bool> IsBestKundali(string best_Online_Result, short rating, short engine)
        {
            var request = new BestKundaliRequest() { Best_Online_Result = best_Online_Result, Rating = rating, Engine = engine };

            var response = await Swagger!.PostAsync<BestKundaliRequest, ApiResponse<bool>>(BestBLLApiConst.POST_IsBestKundali, request);

            return response?.Data ?? false;
        }

        private async Task Sel_Text(InputText s)
        {
            ListView_Planet?.Clear();
            ListView_Ruling_Planet?.Clear();
            ListView_House?.Clear();
            await this.Gen_Kundali_Chart();
        }

        private async Task<ProcessPlanetLaganResponse?> Process_Planet_Lagan(string Online_Result, List<KPPlanetMappingVO> kp_chart, List<KPHouseMappingVO> cusp_house, short rotate, bool bhav_chalit)
        {
            var processPlanetLaganRequest = new ProcessPlanetLaganRequest()
            {
                OnlineResult = Online_Result,
                KpChart = kp_chart,
                CuspHouse = cusp_house,
                Rotate = rotate,
                BhavChalit = bhav_chalit
            };

            var processPlanetLaganResponse = await Swagger!.PostAsync<ProcessPlanetLaganRequest, ProcessPlanetLaganResponse>(KPBLLApiConst.POST_ProcessPlanetLagan, processPlanetLaganRequest);

            return processPlanetLaganResponse;
        }

        private async Task<KundliVO?> Map_PersKV(string Online_Result, string name, string city, string dd, string mm, string yy, string hh, string min, string ss, string username, string lon, string lat, string tz, bool paid, string lang, bool showref, bool male, string domain, string file_prefix, string vcn_prefix, string source, string headertitle, string product, string wdd, string wmm, string wyy, short rotate)
        {

            var mapPersKVRequest = new MapPersKVRequest
            {
                Online_Result = Online_Result,
                Name = name,
                City = city,
                DD = dd,
                MM = mm,
                YY = yy,
                HH = hh,
                Min = min,
                SS = ss,
                Username = username,
                Lon = lon,
                Lat = lat,
                TZ = tz,
                Paid = paid,
                Lang = lang,
                ShowRef = showref,
                Male = male,
                Domain = domain,
                FilePrefix = file_prefix,
                VcnPrefix = vcn_prefix,
                Source = source,
                HeaderTitle = headertitle,
                Product = product,
                WDD = wdd,
                WMM = wmm,
                WYY = wyy,
                Rotate = rotate
            };

            var kundliVO = await Swagger!.PostAsync<MapPersKVRequest, KundliVO>(PredictionBLLApiConst.POST_MapPersKV, mapPersKVRequest);
            return kundliVO;

        }

        private async Task<List<KPPlanetMappingVO>> Process_KPChart_GoodBad(List<KPPlanetMappingVO> kp_chart, KundliVO persKV, ProductSettingsVO prod)
        {
            var processKPChartGoodBadRequest = new ProcessKPChartGoodBadRequest()
            {
                KpChart = this.kp_chart,
                PersKV = this.persKV,
                Prod = this.prod
            };

            var kpPlanetMappingVOs = await Swagger!.PostAsync<ProcessKPChartGoodBadRequest, List<KPPlanetMappingVO>>(KPBLLApiConst.POST_ProcessKPChartGoodBad, processKPChartGoodBadRequest);

            if (kpPlanetMappingVOs != null)
            {
                return kpPlanetMappingVOs;
            }
            return new List<KPPlanetMappingVO>();
        }

        private void Gen_KP_Chart(List<KPPlanetMappingVO> kp_chart)
        {
            if (ListView_Planet == null)
            {
                ListView_Planet = new List<ChartPlanetTableTRModel>();
            }
            else
            {
                ListView_Planet.Clear();
            }

            foreach (KPPlanetMappingVO list in kp_chart.Where(map => map.Planet <= 9).ToList<KPPlanetMappingVO>())
            {
                //   ListViewItem listViewItem = new ListViewItem();
                string planets = "";// 1st col
                if (list.IsPakka)
                {
                    planets = string.Concat(planets, "P");
                }
                if (list.isManda)
                {
                    planets = string.Concat(planets, "M");
                }
                if (list.isJadKharab)
                {
                    planets = string.Concat(planets, "Z");
                }

                planets = string.Concat(this.planet_list[list.Planet - 1].Hindi, " ", planets);

                //if (!list.IsBad)
                //{
                //    listViewItem.ForeColor = Color.Green;
                //}
                //else
                //{
                //    listViewItem.ForeColor = Color.Red;
                //}

                //send column
                string[] hindi = new string[] { this.planet_list[list.Rashi_Lord - 1].Hindi, "--", this.planet_list[list.Nak_Lord - 1].Hindi, "--", this.planet_list[list.Sub_Lord - 1].Hindi, "--", this.planet_list[list.Sub_Sub_Lord].Hindi };

                //subItems.Add(string.Concat(hindi));
                short rule = 0;
                string significators = ""; // 3rd column
                string str2 = ""; // toltip
                foreach (KPSigniVO kPSigniVO in list.Signi.OrderBy(map => map.Rule))
                {
                    if (this.BirthDetails.ChkSahasaneLogic)
                    {
                        if (rule != kPSigniVO.Rule)
                        {
                            significators = string.Concat(significators, " | ");
                            rule = kPSigniVO.Rule;
                        }
                        significators = string.Concat(significators, kPSigniVO.Signi, " ");
                    }
                    else if ((kPSigniVO.Rule == 1 || kPSigniVO.Rule == 2 || kPSigniVO.Rule == 8 ? true : kPSigniVO.Rule == 9))
                    {
                        if (rule != kPSigniVO.Rule)
                        {
                            significators = string.Concat(significators, " | ");
                            rule = kPSigniVO.Rule;
                        }
                        object obj = str2;
                        object?[] signi = new object?[] { obj, kPSigniVO.Signi, "(", null, null };
                        signi[3] = kPSigniVO.Rule.ToString();
                        signi[4] = ") ";
                        str2 = string.Concat(signi);
                        significators = string.Concat(significators, kPSigniVO.Signi, " ");
                    }
                }
                var tr = new ChartPlanetTableTRModel();
                tr.Significators = significators.Trim();
                tr.Planet = planets;
                tr.RL_NL_SL_SSL = string.Concat(hindi);
                ListView_Planet.Add(tr);
            }
        }

        private void Gen_Cusp_Chart(List<KPHouseMappingVO> cusp_house)
        {
            if (ListView_House == null)
            {
                ListView_House = new List<ChartHouseTableTRModel>();
            }
            else
            {
                ListView_House.Clear();
            }

            char[] chrArray;
            List<KPSigniGoodBad> kPSigniGoodBads = new List<KPSigniGoodBad>();
            kPSigniGoodBads = this.kpbl.Fill_Signi_GoodBad();
            if (this.last_cusp_house == null)
            {
                this.last_cusp_house = cusp_house;
            }
            if (this.last_kp_chart == null)
            {
                this.last_kp_chart = this.kp_chart;
            }

            foreach (KPHouseMappingVO cuspHouse in cusp_house)
            {
                //ListViewItem listViewItem = new ListViewItem()
                //{
                //    ForeColor = Color.Black,
                //    Text = cuspHouse.House.ToString()
                //};
                string signiString = "";
                string str = "";
                if (this.last_cusp_house.Count > 0)
                {
                    short subLord = this.last_cusp_house.Where(Map => Map.House == cuspHouse.House).SingleOrDefault<KPHouseMappingVO>()?.Sub_Lord ?? 0;
                    short nakLord = this.kp_chart.Where(Map => Map.Planet == subLord).Single<KPPlanetMappingVO>().Nak_Lord;
                    short num = cusp_house.Where(Map => Map.House == cuspHouse.House).SingleOrDefault<KPHouseMappingVO>()?.Sub_Lord ?? 0;
                    short nakLord1 = this.kp_chart.Where(Map => Map.Planet == num).Single<KPPlanetMappingVO>().Nak_Lord;
                    signiString = this.kpbl.Get_Signi_String(nakLord, this.last_kp_chart, BirthDetails.ChkSahasaneLogic);
                    str = this.kpbl.Get_Signi_String(nakLord1, this.kp_chart, BirthDetails.ChkSahasaneLogic);
                }
                //if ((this.last_cusp_house.Count <= 0 ? false : signiString != str))
                //{
                //    listViewItem.ForeColor = Color.Blue;
                //}
                //if (!this.LstVHouses.InvokeRequired)
                //{
                //    this.LstVHouses.Items.Add(listViewItem);
                //}
                //else
                //{
                //    this.LstVHouses.Invoke(new MethodInvoker(() => this.LstVHouses.Items.Add(listViewItem)));
                //}
                //ListViewItem.ListViewSubItemCollection subItems = this.LstVHouses.Items[this.LstVHouses.Items.Count - 1].SubItems;
                string[] hindi = new string[] { this.planet_list[cuspHouse.Rashi_Lord - 1].Hindi, "--", this.planet_list[cuspHouse.Nak_Lord - 1].Hindi, "--", this.planet_list[cuspHouse.Sub_Lord - 1].Hindi, "--", this.planet_list[cuspHouse.Sub_Sub_Lord].Hindi };
                //subItems.Add(string.Concat(hindi));
                short rule = 0;
                //string str1 = "";
                string str2 = "";
                string str3 = "";
                List<KPSigniVO> signi = cusp_house.Where(Map => Map.House == cuspHouse.House).SingleOrDefault<KPHouseMappingVO>()?.Signi ?? new List<KPSigniVO>();

                foreach (KPSigniVO kPSigniVO in signi.OrderBy(Map => Map.Rule))
                {
                    if (this.BirthDetails.ChkSahasaneLogic)
                    {
                        if (rule != kPSigniVO.Rule)
                        {
                            str2 = string.Concat(str2, " | ");
                            rule = kPSigniVO.Rule;
                        }
                        str2 = string.Concat(str2, this.planet_list[kPSigniVO.Signi - 1].Hindi, " ");
                    }
                    else if ((kPSigniVO.Rule == 1 || kPSigniVO.Rule == 2 || kPSigniVO.Rule == 8 ? true : kPSigniVO.Rule == 9))
                    {
                        if (rule != kPSigniVO.Rule)
                        {
                            str2 = string.Concat(str2, " | ");
                            rule = kPSigniVO.Rule;
                        }
                        str2 = string.Concat(str2, this.planet_list[kPSigniVO.Signi - 1].Hindi, " ");
                    }
                }
                short num1 = this.kp_chart.Where(Map => Map.Planet == cuspHouse.Sub_Lord).SingleOrDefault<KPPlanetMappingVO>()?.Nak_Lord ?? 0;

                List<KPSigniVO> kPSigniVOs = this.kp_chart.Where(Map => Map.Planet == num1).SingleOrDefault<KPPlanetMappingVO>()?.Signi ?? new List<KPSigniVO>();

                foreach (KPSigniVO kPSigniVO1 in kPSigniVOs.OrderBy(Map => Map.Rule))
                {
                    if (this.BirthDetails.ChkSahasaneLogic)
                    {
                        if (rule != kPSigniVO1.Rule)
                        {
                            str3 = string.Concat(str3, " | ");
                            rule = kPSigniVO1.Rule;
                        }
                        string goodHouse = kPSigniGoodBads[cuspHouse.House - 1].Good_House;
                        chrArray = new char[] { ',' };
                        if (goodHouse.Split(chrArray, StringSplitOptions.RemoveEmptyEntries).ToArray<string>().Contains<string>(kPSigniVO1.Signi.ToString()))
                        {
                            str3 = string.Concat(str3, "+");
                        }
                        string badHouse = kPSigniGoodBads[cuspHouse.House - 1].Bad_House;
                        chrArray = new char[] { ',' };
                        if (badHouse.Split(chrArray, StringSplitOptions.RemoveEmptyEntries).ToArray<string>().Contains<string>(kPSigniVO1.Signi.ToString()))
                        {
                            str3 = string.Concat(str3, "-");
                        }
                        str3 = string.Concat(str3, kPSigniVO1.Signi, " ");
                    }
                    else if ((kPSigniVO1.Rule == 1 || kPSigniVO1.Rule == 2 || kPSigniVO1.Rule == 8 ? true : kPSigniVO1.Rule == 9))
                    {
                        if (rule != kPSigniVO1.Rule)
                        {
                            str3 = string.Concat(str3, " | ");
                            rule = kPSigniVO1.Rule;
                        }
                        string goodHouse1 = kPSigniGoodBads[cuspHouse.House - 1].Good_House;
                        chrArray = new char[] { ',' };
                        if (goodHouse1.Split(chrArray, StringSplitOptions.RemoveEmptyEntries).ToArray<string>().Contains<string>(kPSigniVO1.Signi.ToString()))
                        {
                            str3 = string.Concat(str3, "+");
                        }
                        string badHouse1 = kPSigniGoodBads[cuspHouse.House - 1].Bad_House;
                        chrArray = new char[] { ',' };
                        if (badHouse1.Split(chrArray, StringSplitOptions.RemoveEmptyEntries).ToArray<string>().Contains<string>(kPSigniVO1.Signi.ToString()))
                        {
                            str3 = string.Concat(str3, "-");
                        }
                        str3 = string.Concat(str3, kPSigniVO1.Signi, " ");
                    }
                }
                kPSigniVOs = this.kp_chart.Where(Map => Map.Planet == cuspHouse.Sub_Lord).SingleOrDefault<KPPlanetMappingVO>()?.Signi ?? new List<KPSigniVO>();
                string str4 = "";
                rule = 0;
                foreach (KPSigniVO kPSigniVO2 in kPSigniVOs.OrderBy(Map => Map.Rule))
                {
                    if (this.BirthDetails.ChkSahasaneLogic)
                    {
                        if (rule != kPSigniVO2.Rule)
                        {
                            str4 = string.Concat(str4, " | ");
                            rule = kPSigniVO2.Rule;
                        }
                        string goodHouse2 = kPSigniGoodBads[cuspHouse.House - 1].Good_House;
                        chrArray = new char[] { ',' };
                        if (goodHouse2.Split(chrArray, StringSplitOptions.RemoveEmptyEntries).ToArray<string>().Contains<string>(kPSigniVO2.Signi.ToString()))
                        {
                            str4 = string.Concat(str4, "+");
                        }
                        string badHouse2 = kPSigniGoodBads[cuspHouse.House - 1].Bad_House;
                        chrArray = new char[] { ',' };
                        if (badHouse2.Split(chrArray, StringSplitOptions.RemoveEmptyEntries).ToArray<string>().Contains<string>(kPSigniVO2.Signi.ToString()))
                        {
                            str4 = string.Concat(str4, "-");
                        }
                        str4 = string.Concat(str4, kPSigniVO2.Signi, " ");
                    }
                    else if ((kPSigniVO2.Rule == 1 || kPSigniVO2.Rule == 2 || kPSigniVO2.Rule == 8 ? true : kPSigniVO2.Rule == 9))
                    {
                        if (rule != kPSigniVO2.Rule)
                        {
                            str4 = string.Concat(str4, " | ");
                            rule = kPSigniVO2.Rule;
                        }
                        string goodHouse3 = kPSigniGoodBads[cuspHouse.House - 1].Good_House;
                        chrArray = new char[] { ',' };
                        if (goodHouse3.Split(chrArray, StringSplitOptions.RemoveEmptyEntries).ToArray<string>().Contains<string>(kPSigniVO2.Signi.ToString()))
                        {
                            str4 = string.Concat(str4, "+");
                        }
                        string badHouse3 = kPSigniGoodBads[cuspHouse.House - 1].Bad_House;
                        chrArray = new char[] { ',' };
                        if (badHouse3.Split(chrArray, StringSplitOptions.RemoveEmptyEntries).ToArray<string>().Contains<string>(kPSigniVO2.Signi.ToString()))
                        {
                            str4 = string.Concat(str4, "-");
                        }
                        str4 = string.Concat(str4, kPSigniVO2.Signi, " ");
                    }
                }
                str4 = str4.Trim();
                str2 = str2.Trim();
                //this.LstVHouses.Items[this.LstVHouses.Items.Count - 1].ToolTipText = str1;
                //this.LstVHouses.Items[this.LstVHouses.Items.Count - 1].SubItems.Add(str3);
                //this.LstVHouses.Items[this.LstVHouses.Items.Count - 1].SubItems.Add(str4);

                var tr = new ChartHouseTableTRModel();
                tr.House = cuspHouse.House;
                tr.RL_NL_SL_SSL = string.Concat(hindi);
                tr.NakSigni = str3;
                tr.SubSigni = str4;

                ListView_House.Add(tr);

            }
            this.last_cusp_house = cusp_house;
            this.last_kp_chart = this.kp_chart;
            //this.LstVHouses.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            //this.LstVHouses.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private async Task Gen_Ruling_Planets(List<KPPlanetMappingVO> kp_chart, List<KPHouseMappingVO> cusp_house, string wday, string birthday)
        {
            if (ListView_Ruling_Planet == null)
            {
                ListView_Ruling_Planet = new List<KundaliTableTRModel>();
            }
            else
            {
                ListView_Ruling_Planet.Clear();
            }
            //  KPBLL kPBLL = new KPBLL();
            //this.listView_Ruling_Planets.Items.Clear();
            List<KPDashaVO> kPDashaVOs = new List<KPDashaVO>();
            List<KPDashaVO> antarDasha = new List<KPDashaVO>();
            List<KPDashaVO> prayatntarDasha = new List<KPDashaVO>();
            List<KPDashaVO> sukhsmaDasha = new List<KPDashaVO>();
            kPDashaVOs = this.kpbl.Get_Dasha(cusp_house, kp_chart, this.persKV, BirthDetails.ChkSahasaneLogic);//
            short planet = kPDashaVOs.Where(Map => DateTime.Now.Date < Map.StartDate ? false : DateTime.Now.Date <= Map.EndDate).SingleOrDefault<KPDashaVO>()?.Planet ?? 0;

            DateTime startDate = (
                from Map in kPDashaVOs
                where Map.Planet == planet
                select Map).SingleOrDefault<KPDashaVO>()?.StartDate ?? default;

            DateTime endDate = (
                from Map in kPDashaVOs
                where Map.Planet == planet
                select Map).SingleOrDefault<KPDashaVO>()?.EndDate ?? default;

            antarDasha = this.kpbl.Get_Antar_Dasha(startDate, endDate, planet, kp_chart, BirthDetails.ChkSahasaneLogic);
            short num = (
                from Map in antarDasha
                where (DateTime.Now.Date < Map.StartDate ? false : DateTime.Now.Date <= Map.EndDate)
                select Map).SingleOrDefault<KPDashaVO>()?.Planet ?? default;

            DateTime dateTime = (
                from Map in antarDasha
                where Map.Planet == num
                select Map).SingleOrDefault<KPDashaVO>()?.StartDate ?? default;

            DateTime endDate1 = (
                from Map in antarDasha
                where Map.Planet == num
                select Map).SingleOrDefault<KPDashaVO>()?.EndDate ?? default;

            prayatntarDasha = this.kpbl.Get_Prayatntar_Dasha(antarDasha, dateTime, endDate1, planet, num, kp_chart, BirthDetails.ChkSahasaneLogic);

            short planet1 = (
                from Map in prayatntarDasha
                where (DateTime.Now.Date < Map.StartDate ? false : DateTime.Now.Date <= Map.EndDate)
                select Map).SingleOrDefault<KPDashaVO>()?.Planet ?? default;

            DateTime startDate1 = (
                from Map in prayatntarDasha
                where Map.Planet == planet1
                select Map).SingleOrDefault<KPDashaVO>()?.StartDate ?? default;

            DateTime dateTime1 = (
                from Map in prayatntarDasha
                where Map.Planet == planet1
                select Map).SingleOrDefault<KPDashaVO>()?.EndDate ?? default;

            sukhsmaDasha = this.kpbl.Get_Sukhsma_Dasha(prayatntarDasha, startDate1, dateTime1, planet, num, planet1, kp_chart, BirthDetails.ChkSahasaneLogic);
            short num1 = (
                from Map in sukhsmaDasha
                where (DateTime.Now.Date < Map.StartDate ? false : DateTime.Now.Date <= Map.EndDate)
                select Map).FirstOrDefault<KPDashaVO>()?.Planet ?? default;

            // Add "महादशा"
            ListView_Ruling_Planet.Add(new KundaliTableTRModel
            {
                Item = "महादशा",
                SubItem = string.Concat(this.planet_list[planet - 1].Hindi, " ", this.kpbl.Get_Signi_String(planet, kp_chart, this.BirthDetails.ChkSahasaneLogic))
            });

            // Add "अन्तर्दशा"
            ListView_Ruling_Planet.Add(new KundaliTableTRModel
            {
                Item = "अन्तर्दशा",
                SubItem = string.Concat(this.planet_list[num - 1].Hindi, " ", this.kpbl.Get_Signi_String(num, kp_chart, this.BirthDetails.ChkSahasaneLogic))
            });

            // Add "प्रयंतरदशा"
            ListView_Ruling_Planet.Add(new KundaliTableTRModel
            {
                Item = "प्रयंतरदशा",
                SubItem = string.Concat(this.planet_list[planet1 - 1].Hindi, " ", kpbl.Get_Signi_String(planet1, kp_chart, this.BirthDetails.ChkSahasaneLogic))
            });

            // Add "सुक्ष्मदशा"
            ListView_Ruling_Planet.Add(new KundaliTableTRModel
            {
                Item = "सुक्ष्मदशा",
                SubItem = string.Concat(this.planet_list[num1 - 1].Hindi, " ", kpbl.Get_Signi_String(num1, kp_chart, this.BirthDetails.ChkSahasaneLogic))
            });

            // Add "लाल दशा"
            ListView_Ruling_Planet.Add(new KundaliTableTRModel
            {
                Item = "लाल दशा",
                SubItem = this.planet_list.Where(Map => Map.Roman == this.persKV.Dasha35).First<KPPlanetsVO>().Hindi
            });

            // Add "भाग्यशाली अंक"
            ListView_Ruling_Planet.Add(new KundaliTableTRModel
            {
                Item = "भाग्यशाली अंक",
                SubItem = this.persKV.Lucky_number
            });

            // Add "भाग्यशाली दिन"
            var bhagya = await GetCodeLang(this.persKV.Lucky_day1, "hindi", true, true);
            ListView_Ruling_Planet.Add(new KundaliTableTRModel
            {
                Item = "भाग्यशाली दिन",
                SubItem = bhagya
            });

            // Add "जनमदिन"
            DateTime dob = this.persKV.Dob;
            var janama = await GetCodeLang(dob.DayOfWeek.ToString(), this.persKV.Language, true, true);
            ListView_Ruling_Planet.Add(new KundaliTableTRModel
            {
                Item = "जनमदिन",
                SubItem = janama
            });

            //// Add "जनमदिन ग्रह"
            ListView_Ruling_Planet.Add(new KundaliTableTRModel
            {
                Item = "जनमदिन ग्रह",
                SubItem = this.planet_list.Where(Map => Map.English == this.persKV.JanamDin).First<KPPlanetsVO>().Hindi
            });

            //// Add "जनमसमय ग्रह"
            ListView_Ruling_Planet.Add(new KundaliTableTRModel
            {
                Item = "जनमसमय ग्रह",
                SubItem = this.planet_list.Where(Map => Map.English == this.persKV.JanamSamay).First<KPPlanetsVO>().Hindi
            });

            //// Add "राशि"
            ListView_Ruling_Planet.Add(new KundaliTableTRModel
            {
                Item = "राशि",
                SubItem = this.rashi_list.Where(Map => Map.English == this.persKV.Janam_rashi).First<KPRashiVO>().Hindi
            });

            //// Add "नक्षत्र"
            string hindi = this.nak_list.Where(Map => Convert.ToInt64(Map.NakNumber) == this.persKV.Nak).First<KPNAKVO>().Hindi;
            long charan = this.persKV.Charan;
            ListView_Ruling_Planet.Add(new KundaliTableTRModel
            {
                Item = "नक्षत्र",
                SubItem = string.Concat(hindi, " ", charan.ToString())
            });
        }

        private async Task Gen_Kundali_Chart()
        {
            imgSrc = "";
            bool flag = false;
            try
            {
                DateTime dateTime = new DateTime(Convert.ToInt16(BirthDetails.Dobyy), Convert.ToInt16(BirthDetails.Dobmm), Convert.ToInt16(BirthDetails.Dobdd), Convert.ToInt16(BirthDetails.Tobhh), Convert.ToInt16(BirthDetails.Tobmm), 0);
            }
            catch (Exception)
            {
                flag = true;
            }
            if (!flag)
            {
                if (Convert.ToInt16(BirthDetails.Dobyy) >= 1900)
                {
                    #region Gen Kunda Request

                    string text = "";
                    string str1 = this.full_lon.Replace(":", ".");
                    string str2 = this.full_lat.Replace(":", ".");
                    str1 = string.Concat(this.kkbl.DecimalToDMS(Convert.ToDouble(str1.Substring(0, str1.Length - 1))).ToString(), str1.Substring(str1.Length - 1, 1));
                    str2 = string.Concat(this.kkbl.DecimalToDMS(Convert.ToDouble(str2.Substring(0, str2.Length - 1))).ToString(), str2.Substring(str2.Length - 1, 1));
                    string str3 = this.kkbl.longi2timezone(this.full_tz);

                    if (str1.Length == 6)
                    {
                        str1 = string.Concat("0", str1);
                    }
                    if (str2.Length == 5)
                    {
                        str2 = string.Concat("0", str2);
                    }

                    text = BirthDetails.Dobdd + "/" + BirthDetails.Dobmm + "/" + BirthDetails.Dobyy + "," + BirthDetails.Tobhh + ":" + BirthDetails.Tobmm + "," + str1 + "," + str2 + "," + str3 + "," + this.ayan + "," + full_time_corr;

                    var kundaRequest = new GenKundaRequest()
                    {
                        Detail = text,
                        Lagan = 500f,
                        Rotate = BirthDetails.CmbRotate,
                    };

                    var kundaResponse = await Swagger!.PostAsync<GenKundaRequest, ApiResponse<string>>(KundliBLLApiConst.POST_GenKunda, kundaRequest);

                    this.Online_Result = kundaResponse?.Data ?? "";

                    #endregion

                    #region Map Pers KVRequest

                    MapPersKVRequest mapPersKVRequest = new MapPersKVRequest
                    {
                        Online_Result = Online_Result,
                        Name = BirthDetails.TxtName,
                        City = BirthDetails.BirthCity,
                        DD = BirthDetails.Dobdd.ToString(),
                        MM = BirthDetails.Dobmm.ToString(),
                        YY = BirthDetails.Dobyy.ToString(),
                        HH = BirthDetails.Tobhh.ToString(),
                        Min = BirthDetails.Tobmm.ToString(),
                        SS = "00", // Default value
                        Username = "admin", // Dsefault value
                        Lon = BirthDetails.Longtitude.ToString(),
                        Lat = BirthDetails.Latitude.ToString(),
                        TZ = BirthDetails.TxtTimezone.ToString(),
                        Paid = true, // Default value
                        Lang = BirthDetails.CmbLanguage,
                        ShowRef = BirthDetails.ChkShowRef, // Set to true or false as needed
                        Male = this.male, // Set to true or false as needed
                        Domain = "YICC", // Default value
                        FilePrefix = "YICC", // Default value
                        VcnPrefix = "YICC", // Default value
                        Source = "YICC", // Default value
                        HeaderTitle = "YICC", // Default value
                        Product = "New Product", // Default value
                        WDD = "01", // Default value
                        WMM = "01", // Default value
                        WYY = "2000", // Default value
                        Rotate = 1 // Default value
                    };

                    var kundliVO = await Swagger!.PostAsync<MapPersKVRequest, KundliVO>(PredictionBLLApiConst.POST_MapPersKV, mapPersKVRequest);
                    if (kundliVO != null)
                    {
                        this.persKV = kundliVO;
                    }

                    #endregion

                    #region Process Planet Lagan Request

                    this.kp_chart = new List<KPPlanetMappingVO>();
                    this.cusp_house = new List<KPHouseMappingVO>();

                    var processPlanetLaganRequest = new ProcessPlanetLaganRequest()
                    {
                        OnlineResult = Online_Result,
                        KpChart = kp_chart,
                        CuspHouse = cusp_house,
                        Rotate = BirthDetails.CmbRotate,
                        BhavChalit = false
                    };
                    var processPlanetLaganResponse = await Swagger!.PostAsync<ProcessPlanetLaganRequest, ProcessPlanetLaganResponse>(KPBLLApiConst.POST_ProcessPlanetLagan, processPlanetLaganRequest);

                    this.kp_chart = processPlanetLaganResponse!.KpChart;
                    this.cusp_house = processPlanetLaganResponse!.CuspHouse;

                    #endregion

                    #region  Process KPChart GoodBad Request

                    var processKPChartGoodBadRequest = new ProcessKPChartGoodBadRequest()
                    {
                        KpChart = this.kp_chart,
                        PersKV = this.persKV,
                        Prod = this.prod
                    };

                    var kpPlanetMappingVOs = await Swagger!.PostAsync<ProcessKPChartGoodBadRequest, List<KPPlanetMappingVO>>(KPBLLApiConst.POST_ProcessKPChartGoodBad, processKPChartGoodBadRequest);

                    if (kpPlanetMappingVOs != null)
                    {

                        this.kp_chart = kpPlanetMappingVOs;
                    }

                    #endregion

                    #region Gen Image Request

                    var genImageRequest = new GenImageRequest()
                    {
                        Lagna = this.persKV!.Lagna.ToString(),
                        Lkmv = this.kp_chart,
                        Online_Result = Online_Result,
                        Bhav_Chalit = true,
                        Kund_Size = 1,
                        Lang = this.persKV.Language
                    };

                    var imgResponse = await Swagger!.PostAsync<GenImageRequest, ApiResponse<string>>(KundliBLLApiConst.POST_GenImage, genImageRequest);

                    imgSrc = imgResponse?.Data ?? "";

                    #endregion
                }
            }
        }

        private async Task<string> GetCodeLang(string rulecode, string lang, bool paid, bool unicode)
        {
            var response = await Swagger!.GetAsync<ApiResponse<string>>(string.Format(PredictionBLLApiConst.GET_GetCodeLang, rulecode, lang, paid, unicode));
            if (response != null)
                return response.Data ?? string.Empty;
            return string.Empty;
        }

        private async Task<string> Gen_Kunda(string? detail, float lagan, short rotate)
        {
            var kundaRequest = new GenKundaRequest()
            {
                Detail = detail,
                Lagan = lagan,
                Rotate = rotate,
            };

            var kundaResponse = await Swagger!.PostAsync<GenKundaRequest, ApiResponse<string>>(KundliBLLApiConst.POST_GenKunda, kundaRequest);
            if (kundaResponse == null)
            {
                return string.Empty;
            }
            return kundaResponse.Data ?? string.Empty;
        }

        private async Task LoadCountry()
        {
            if (BirthDetails?.TxtBirthPlace?.Trim().Length > 2)
            {
                this.ListBirthCities = await Swagger!.GetAsync<List<DTOs.APlaceMaster>>(string.Format(LocationBLLApiConst.GET_GetPlaceListLike, BirthDetails!.TxtBirthPlace, BirthDetails!.CmbCountry));
            }
            if (this.ListBirthCities != null && this.ListBirthCities.Any())
            {
                await OnChange_ListBirthCities(new ChangeEventArgs { Value = 0 });
            }
        }

        private async Task Show_Falla(string falla)
        {
            imgSrcBhavChalit = await this.Get_Gen_Image(this.persKV.Lagna.ToString(), this.kp_chart, this.Online_Result, true, 1, this.persKV.Language); ;
            imgSrcLagan = await this.Get_Gen_Image(this.persKV.Lagna.ToString(), this.kp_chart, this.Online_Result, false, 1, this.persKV.Language);
            htmlStringFalla = falla;

            await FaladeshModal.ShowAsync();
        }

        private async Task<string> Get_Fal_Double_Mahadasha(short planet, KundliVO persKV, string online_Result, ProductSettingsVO prod)
        {
            var request = new GetFalDoubleMahadashaRequest()
            {
                PlanetNo = planet,
                PersonalKundli = persKV,
                OnlineResult = online_Result,
                TemporaryProduct = prod
            };

            var response = await Swagger!.PostAsync<GetFalDoubleMahadashaRequest, ApiResponse<string>>(KPBLLApiConst.POST_GetFalDoubleMahadasha, request);

            return response?.Data ?? string.Empty;
        }

        private void Gen_AntarDasha(List<KPDashaVO> dasha_list, List<KPPlanetMappingVO> kp_chart)
        {

            if (ListView_Antardasha == null)
            {
                ListView_Antardasha = new();
            }
            else
            {
                ListView_Antardasha.Clear();
            }

            foreach (KPDashaVO dashaList in dasha_list)
            {
                var tr = new AntardashaTableTRModel();

                tr.Planet = this.planet_list.Where(Map => Map.Planet == dashaList.Planet).SingleOrDefault<KPPlanetsVO>()?.Hindi ?? string.Empty;

                string startDate = dashaList.StartDate.ToString("dd MMM yyyy");
                string endDate = dashaList.EndDate.ToString("dd MMM yyyy");

                tr.Period = string.Concat(startDate, " - ", endDate);

                tr.Signi = string.Concat(dashaList.Signi_String, " | ", dashaList.Nak_Signi_String);

                ListView_Antardasha.Add(tr);
            }
        }

        private async Task Gen_Image(string lagna, List<KPPlanetMappingVO> lkmv, string Online_Result, bool bhav_chalit, short Kund_Size, string lang)
        {
            #region Gen Image Request

            var genImageRequest = new GenImageRequest()
            {
                Lagna = lagna,
                Lkmv = lkmv,
                Online_Result = Online_Result,
                Bhav_Chalit = bhav_chalit,
                Kund_Size = Kund_Size,
                Lang = lang
            };

            var imgResponse = await Swagger!.PostAsync<GenImageRequest, ApiResponse<string>>(KundliBLLApiConst.POST_GenImage, genImageRequest);

            imgSrc = imgResponse?.Data ?? "";

            #endregion
        }

        private async Task<string> Get_Gen_Image(string lagna, List<KPPlanetMappingVO> lkmv, string Online_Result, bool bhav_chalit, short Kund_Size, string lang)
        {
            var genImageRequest = new GenImageRequest()
            {
                Lagna = lagna,
                Lkmv = lkmv,
                Online_Result = Online_Result,
                Bhav_Chalit = bhav_chalit,
                Kund_Size = Kund_Size,
                Lang = lang
            };

            var imgResponse = await Swagger!.PostAsync<GenImageRequest, ApiResponse<string>>(KundliBLLApiConst.POST_GenImage, genImageRequest);

            return imgResponse?.Data ?? "";
        }

        #endregion

        #region Handle events

        private async Task OnDBLClick_TR_ListView_Mahadasha(MahadashaTableTRModel selectedTR)
        {
            //this.TxtBrief.Text = "";
            //PredictionBLL predictionBLL = new PredictionBLL();
            short planet = (
                from Map in this.planet_list
                where Map.Hindi == selectedTR.Planet
                select Map).SingleOrDefault<KPPlanetsVO>()?.Planet ?? default;

            this.prod.ShowUpay = true;
            this.prod.ShowUpayCode = true;
            this.persKV.Paid = true;
            this.prod.ShowUpayBelow = true;
            this.prod.Paid = true;
            string falDoubleMahadasha = await Get_Fal_Double_Mahadasha(planet, this.persKV, this.Online_Result, this.prod);

            await this.Show_Falla(falDoubleMahadasha);

        }

        private async Task OnClick_TR_ListView_Mahadasha(MahadashaTableTRModel selectedTR)
        {
            this.maha_dasha_click = true;
            this.sukshma_dasha_click = false;

            short planet = (
                from Map in this.planet_list
                where Map.Hindi == selectedTR.Planet
                select Map).SingleOrDefault<KPPlanetsVO>()?.Planet ?? default;

            DateTime startDate = (
                from Map in this.main_mahadasha
                where Map.Planet == planet
                select Map).SingleOrDefault<KPDashaVO>()?.StartDate ?? default;

            DateTime endDate = (
                from Map in this.main_mahadasha
                where Map.Planet == planet
                select Map).SingleOrDefault<KPDashaVO>()?.EndDate ?? default;

            this.main_antardasha = this.kpbl.Get_Antar_Dasha(startDate, endDate, planet, this.kp_chart, this.BirthDetails.ChkSahasaneLogic);

            string?[] text = new string?[] { selectedTR.Planet, "&nbsp;", selectedTR.Period, "&nbsp;&nbsp;&nbsp;&nbsp;कार्येश :&nbsp;&nbsp;", null, null, null };
            string? str = selectedTR.Signi;
            char[] chrArray = new char[] { '|' };
            text[4] = str?.Split(chrArray)[0];
            text[5] = "&nbsp;&nbsp;&nbsp;नक्षत्र स्वामी :&nbsp;";
            string? text1 = selectedTR.Signi;
            chrArray = new char[] { '|' };
            text[6] = text1?.Split(chrArray)[1];
            this.lblMahadasha = string.Concat(text);

            if (this.BirthDetails.SalaChakkar)
            {
                if (ListView_Years35 == null)
                {
                    ListView_Years35 = new();
                }
                else
                {
                    ListView_Years35.Clear();
                }
                List<KPDashaVO>? list35Sala = await Get_List_35_Sala(this.Online_Result, this.persKV, startDate, endDate);

                if (list35Sala != null)
                {
                    foreach (KPDashaVO kPDashaVO in list35Sala)
                    {
                        text = new string[5];
                        DateTime dateTime = kPDashaVO.StartDate;
                        text[0] = dateTime.ToString("dd");
                        text[1] = " ";
                        dateTime = kPDashaVO.StartDate;
                        text[2] = await GetCodeLang(string.Concat("M", dateTime.ToString("%M")), this.persKV.Language, this.persKV.Paid, true);
                        text[3] = " ";
                        dateTime = kPDashaVO.StartDate;
                        text[4] = dateTime.ToString("yyyy");
                        string str1 = string.Concat(text);
                        text = new string[5];
                        dateTime = kPDashaVO.EndDate;
                        text[0] = dateTime.ToString("dd");
                        text[1] = " ";
                        dateTime = kPDashaVO.EndDate;
                        text[2] = await GetCodeLang(string.Concat("M", dateTime.ToString("%M")), this.persKV.Language, this.persKV.Paid, true);
                        text[3] = " ";
                        dateTime = kPDashaVO.EndDate;
                        text[4] = dateTime.ToString("yyyy");
                        string str2 = string.Concat(text);

                        var tr = new Years35TableTRModel();

                        tr.Planet = this.planet_list.Where(Map => Map.Planet == kPDashaVO.Planet).FirstOrDefault<KPPlanetsVO>()?.Hindi ?? string.Empty;
                        tr.Antar = kPDashaVO.Duration;
                        tr.Period = string.Concat(str1, " - ", str2);
                        tr.Age = kPDashaVO.Nak_Signi_String;
                        ListView_Years35.Add(tr);
                    }
                }
            }
            else
            {
                this.Gen_AntarDasha(this.main_antardasha, this.kp_chart);
            }

            this.ListView_Prayantardasha?.Clear();
            this.ListView_Sukhsmadasha?.Clear();
            this.lblParyan = string.Empty;
            this.lblAntar = string.Empty;
            this.lblSukhsmadasha = string.Empty;
        }

        private async Task<List<KPDashaVO>?> Get_List_35_Sala(string online_Result, KundliVO persKV, DateTime startDate, DateTime endDate)
        {
            var request = new GetList35SalaRequest()
            {
                Online_Result = online_Result,
                PersKV = persKV,
                Dasha_Starts = startDate,
                Dasha_Ends = endDate
            };

            var response = await Swagger!.PostAsync<GetList35SalaRequest, List<KPDashaVO>>(PredictionBLLApiConst.POST_GetList35Sala, request);

            return response;
        }

        private void OnChange_CmbAyanansh(ChangeEventArgs e)
        {
            string value = e.Value?.ToString() ?? "";
            this.BirthDetails.CmbAyanansh = value;

            if (value == "KP")
            {
                this.ayan = "K";
            }
            if (value == "Lahiri")
            {
                this.ayan = "L";
            }
        }

        private void OnChange_CmbCategory(ChangeEventArgs e)
        {
            string value = e.Value.ToStringX();
            BirthDetails.CmbCategory = value;
        }

        private void OnChange_CmbLanguage(ChangeEventArgs e)
        {
            string value = e.Value.ToStringX();
            BirthDetails.CmbLanguage = value;
        }

        private void OnChange_CmbSkipBad(ChangeEventArgs e)
        {
            string value = e.Value.ToStringX();
            BirthDetails.CmbSkipBad = value;
        }

        private void OnChange_CmbTime(ChangeEventArgs e)
        {
            string value = e.Value.ToStringLower();
            this.BirthDetails.CmbTime = value;

            if (value == "lagan")
            {
                this.BirthDetails.TimeValue = 1;
            }
        }

        private void BtnShow_TabDateFinder_Click(MouseEventArgs e)
        {
            //if (string.IsNullOrEmpty(this.CmbBOccassion.Text))
            //{
            //    MessageBox.Show("Please select an occassion.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //   Application.UseWaitCursor = true;
            List<KPDashaVO> kPDashaVOs = new List<KPDashaVO>();
            string str = "";
            string datesChain = "";
            short num = 0;
            DateFinder.DateList = "";
            if (DateFinder.Period == Period.Maha)
            {
                num = 1;
            }
            if (DateFinder.Period == Period.Antar)
            {
                num = 2;
            }
            if (DateFinder.Period == Period.Pryan)
            {
                num = 3;
            }

            string text = this.DateFinder.Occassion;

            char[] chrArray = new char[] { '-' };
            str = text.Split(chrArray, StringSplitOptions.RemoveEmptyEntries)[1];
            string text1 = this.DateFinder.Occassion;
            chrArray = new char[] { '-' };
            string str1 = text1.Split(chrArray, StringSplitOptions.RemoveEmptyEntries)[2];
            chrArray = new char[] { '~' };
            short num1 = Convert.ToInt16(str1.Split(chrArray, StringSplitOptions.RemoveEmptyEntries)[0]);
            string text2 = this.DateFinder.Occassion;
            chrArray = new char[] { '-' };
            string str2 = text2.Split(chrArray, StringSplitOptions.RemoveEmptyEntries)[2];
            chrArray = new char[] { '~' };
            short num2 = Convert.ToInt16(str2.Split(chrArray, StringSplitOptions.RemoveEmptyEntries)[1]);
            datesChain = kpbl.Get_Dates_Chain(this.kp_chart, this.cusp_house, this.persKV, str, this.prod, DateFinder.Dasha == Dasha.NakSwami, DateFinder.Dasha == Dasha.Both, DateFinder.Sahasane, num1, num2, DateFinder.FullMatch, num);
            DateFinder.DateList = datesChain;
            //  Application.UseWaitCursor = false;
        }

        private async Task OnChange_CmbRotate(ChangeEventArgs e)
        {
            var value = Convert.ToInt16(e.Value);
            this.BirthDetails.CmbRotate = value;

            if ((this.full_lat.Length <= 0 ? false : this.full_lon.Length > 0))
            {
                if (value == 1)
                {
                    this.dobddEnabled = true;
                    this.dobmmEnabled = true;
                    this.dobyyEnabled = true;
                    this.tobhhEnabled = true;
                    this.tobmmEnabled = true;
                    this.tobssEnabled = true;
                    this.txtBirthPlaceEnabled = true;
                    await this.OnClick_BtnChart(new MouseEventArgs());
                }
            }
            if (value > 1)
            {
                this.dobddEnabled = false;
                this.dobmmEnabled = false;
                this.dobyyEnabled = false;
                this.tobhhEnabled = false;
                this.tobmmEnabled = false;
                this.tobssEnabled = false;
                this.txtBirthPlaceEnabled = false;
                //string str = "";
                //KundliBLL kundliBLL = new KundliBLL();
                this.kp_chart = new List<KPPlanetMappingVO>();
                this.cusp_house = new List<KPHouseMappingVO>();
                short num = Convert.ToInt16(this.persKV.Base_Lagna + (long)Convert.ToInt16(this.BirthDetails.CmbRotate) - (long)1);

                if (num > 12)
                {
                    num = Convert.ToInt16(num - 12);
                }

                short num1 = Convert.ToInt16(Convert.ToInt16(this.BirthDetails.CmbRotate));
                this.persKV.Lagna = (long)num;
                string str = await Gen_Kunda(this.prod.Online_Result, (float)num, Convert.ToInt16(num1));
                this.Online_Result = str;

                var laganResponse = await Process_Planet_Lagan(str, this.kp_chart, this.cusp_house, 1, true);

                if (laganResponse != null)
                {
                    this.kp_chart = laganResponse.KpChart;
                    this.cusp_house = laganResponse.CuspHouse;
                }

                this.kp_chart = await this.Process_KPChart_GoodBad(this.kp_chart, this.persKV, this.prod);

                long lagna = this.persKV.Lagna;

                await Gen_Image(lagna.ToString(), this.kp_chart, str, true, 1, this.persKV.Language);

                await this.OnClick_BhavChalit(new MouseEventArgs());

                await this.OnClick_BtnChart(new MouseEventArgs());
            }
        }

        private async Task OnClick_BtnChart(MouseEventArgs e)
        {
            await Task.Delay(10000);
            this.show_vfal = false;
            this.isNumVarshVisible = false;
            if (this.full_lat.Length <= 0 ? false : this.full_lon.Length > 0)
            {

                string str = this.full_lon.Replace(":", ".");
                string str1 = this.full_lat.Replace(":", ".");
                str = string.Concat(this.kkbl.DecimalToDMS(Convert.ToDouble(str.Substring(0, str.Length - 1))).ToString(), str.Substring(str.Length - 1, 1));
                str1 = string.Concat(this.kkbl.DecimalToDMS(Convert.ToDouble(str1.Substring(0, str1.Length - 1))).ToString(), str1.Substring(str1.Length - 1, 1));
                string str2 = this.kkbl.longi2timezone(this.full_tz);
                if (str.Length == 6)
                {
                    str = string.Concat("0", str);
                }
                if (str1.Length == 5)
                {
                    str1 = string.Concat("0", str1);
                }
                this.global_full_lonNew = str;
                this.global_full_latNew = str1;
                this.global_newtz = str2;

                string text = BirthDetails.Dobdd + "/" + BirthDetails.Dobmm + "/" + BirthDetails.Dobyy + "," + BirthDetails.Tobhh + ":" + BirthDetails.Tobmm + "," + str + "," + str1 + "," + str2 + "," + this.ayan + "," + this.full_time_corr;
                //string[] text = new string[] { this.dobdd.Text, "/", this.dobmm.Text, "/", this.dobyy.Text, ",", this.tobhh.Text, ":", this.tobmm.Text, ",", str, ",", str1, ",", str2, ",", this.ayan, ",", this.full_time_corr };
                string str3 = string.Concat(text);
                ProductSettingsVO productSettingsVO = new ProductSettingsVO()
                {
                    Online_Result = str3,
                    Include = this.BirthDetails.ChkSahasaneLogic,
                    Lang = this.BirthDetails.CmbLanguage,
                    Male = this.male,
                    PredFor = 0,
                    ShowRef = this.BirthDetails.ChkShowRef,
                    ShowUpay = false,
                    ShowUpayCode = true,
                    Sno = Convert.ToInt64(555),
                    Category = "all",
                    Product = "",
                    Rotate = Convert.ToInt16(this.BirthDetails.CmbRotate)
                };

                if (this.BirthDetails.CmbRotate == 1)
                {
                    this.kp_chart = new List<KPPlanetMappingVO>();
                    this.cusp_house = new List<KPHouseMappingVO>();

                    this.Online_Result = await Gen_Kunda(str3, 500f, BirthDetails.CmbRotate); ;

                    var kundliVO = await Map_PersKV(Online_Result, BirthDetails.TxtName, BirthDetails.BirthCity, BirthDetails.Dobdd.ToString(), BirthDetails.Dobmm.ToString(), BirthDetails.Dobyy.ToString(), BirthDetails.Tobhh.ToString(), BirthDetails.Tobmm.ToString(), "00", "admin", BirthDetails.Longtitude.ToString(), BirthDetails.Latitude.ToString(), BirthDetails.TxtTimezone.ToString(), true, BirthDetails.CmbLanguage, BirthDetails.ChkShowRef, this.male, "YICC", "YICC", "YICC", "YICC", "YICC", "New Product", "01", "01", "2000", BirthDetails.CmbRotate);

                    if (kundliVO != null)
                    {
                        this.persKV = kundliVO;
                    }

                    this.persKV.FileCode = "555";

                    #region Process Planet Lagan Request

                    this.kp_chart = new List<KPPlanetMappingVO>();
                    this.cusp_house = new List<KPHouseMappingVO>();

                    var processPlanetLaganResponse = await Process_Planet_Lagan(Online_Result, kp_chart, cusp_house, BirthDetails.CmbRotate, false);

                    this.kp_chart = processPlanetLaganResponse!.KpChart;
                    this.cusp_house = processPlanetLaganResponse!.CuspHouse;

                    #endregion

                    #region  Process KPChart GoodBad Request

                    var kpPlanetMappingVOs = await Process_KPChart_GoodBad(this.kp_chart, this.persKV, productSettingsVO);

                    if (kpPlanetMappingVOs != null)
                    {
                        this.kp_chart = kpPlanetMappingVOs;
                    }

                    #endregion

                    await Gen_Image(this.persKV!.Lagna.ToString(), this.kp_chart, Online_Result, true, 1, this.persKV.Language);
                }

                this.Gen_KP_Chart(this.kp_chart);
                this.Gen_Cusp_Chart(this.cusp_house);

                List<KPPlanetMappingVO> kpChart = this.kp_chart;
                List<KPHouseMappingVO> cuspHouse = this.cusp_house;
                string str4 = DateTime.Now.ToString("dddd");
                DateTime dob = this.persKV.Dob;

                await this.Gen_Ruling_Planets(kpChart, cuspHouse, str4, dob.ToString("dddd"));

                //this.Gen_Upay_Chart(this.kp_chart, this.cusp_house);  
                SavedStateModel.ChkSahasaneLogic = BirthDetails.ChkSahasaneLogic;
                await KaranService!.SaveKPHouseMappingVOs(this.cusp_house);
                await KaranService!.SaveKPPlanetMappingVOs(this.kp_chart);
                await KaranService!.SaveStateModel(SavedStateModel);

                this.main_mahadasha = this.kpbl.Get_Dasha(this.cusp_house, this.kp_chart, this.persKV, this.BirthDetails.ChkSahasaneLogic);

                this.Gen_Mahadasha(this.main_mahadasha, this.kp_chart);

                //this.Gen_Mahadasha(this.main_mahadasha, this.kp_chart);  !

                //Font font = new Font("Kruti Dev 011", 16f, FontStyle.Bold);
                //if (this.persKV.Language.ToLower() == "english")
                //{
                //    font = new Font("Arial", 13f, FontStyle.Regular);
                //}
                this.prod = productSettingsVO;
                if (this.persKV.Current_Age <= 0)
                {
                    this.persKV.Current_Age = 1;
                }
                //this.NumUDVYears.Value = this.persKV.Current_Age + 1; !
            }
            else
            {
                //MessageBox.Show("Please choose City from list.");
                //this.TxtBirthplace.SelectAll();
                //this.TxtBirthplace.Focus();
            }
        }

        private void Gen_Mahadasha(List<KPDashaVO> dasha_list, List<KPPlanetMappingVO> kp_chart)
        {
            if (ListView_Mahadasha == null)
            {
                ListView_Mahadasha = new();
            }
            else
            {
                ListView_Mahadasha.Clear();
            }
            this.ListView_Mahadasha.Clear();
            this.ListView_Antardasha?.Clear();
            this.ListView_Prayantardasha?.Clear();
            this.ListView_Sukhsmadasha?.Clear();

            foreach (KPDashaVO dashaList in dasha_list)
            {
                var tr = new MahadashaTableTRModel();

                tr.Planet = this.planet_list.Where(Map => Map.Planet == dashaList.Planet).SingleOrDefault<KPPlanetsVO>()?.Hindi ?? string.Empty;

                string startDate = dashaList.StartDate.ToString(format: "dd MMM yyyy");
                string endDate = dashaList.EndDate.ToString(format: "dd MMM yyyy");

                tr.Period = string.Concat(startDate, " - ", endDate);
                tr.Signi = string.Concat(dashaList.Signi_String, " | ", dashaList.Nak_Signi_String);

                ListView_Mahadasha.Add(tr);
            }
        }

        private async Task OnClick_BtnRefresh(MouseEventArgs e)
        {
            this.last_cusp_house = null;
            this.last_kp_chart = null;
            await this.OnClick_BtnChart(new MouseEventArgs());
        }

        private async Task OnFocus_TxtBirthplace(FocusEventArgs e)
        {
            await JSRuntime.SelectAsync(inputTextBirthPlace?.Element);
        }

        private async Task OnInput_TxtBirthplace(ChangeEventArgs e)
        {
            if (!no_countryload)
            {
                await LoadCountry();
            }
            no_countryload = false;
        }

        private async Task OnKeyDown_TxtBirthplace(KeyboardEventArgs e)
        {
            if (e.Key == "ArrowUp")
            {
                if (selectedBirthCityIndex > 0)
                {
                    selectedBirthCityIndex--;
                    await OnChange_ListBirthCities(new ChangeEventArgs() { Value = selectedBirthCityIndex });
                }
            }
            else if (e.Key == "ArrowDown")
            {
                if (selectedBirthCityIndex < ListBirthCities?.Count - 1)
                {
                    selectedBirthCityIndex++;
                    await OnChange_ListBirthCities(new ChangeEventArgs() { Value = selectedBirthCityIndex });
                }
            }
        }

        private async Task OnChange_ListBirthCities(ChangeEventArgs e)
        {
            string value = e.Value.ToStringLower();
            var selectedBirthCity = ListBirthCities![selectedBirthCityIndex];
            this.BirthDetails.TxtBirthPlace = selectedBirthCity?.Place ?? "";

            var place = await Swagger!.GetAsync<DTOs.APlaceMaster>(string.Format(LocationBLLApiConst.GET_GetPlaceByID, selectedBirthCity?.Sno));
            var country = await Swagger!.GetAsync<DTOs.ACountryMaster>(string.Format(LocationBLLApiConst.GET_GetCountryByCode, selectedBirthCity?.CountryCode));
            var state = await Swagger!.GetAsync<DTOs.AStateMaster>(string.Format(LocationBLLApiConst.GET_GetStateByCode, place?.CountryCode));

            full_lon = (selectedBirthCity!.Longitude ?? "").Trim();
            full_lat = (selectedBirthCity!.Latitude ?? "").Trim();
            full_time_corr = selectedBirthCity.TimeCorrectionCode ?? "";

            //var timeCorrection = new TimeCorrection();
            //string str = "";
            //string timeCorrectionCode = "";
            //string fullTimeCorr = this.full_time_corr;
            //string[] text = new string[] { this.BirthDetails.Dobdd.ToString(), "/", this.BirthDetails.Dobmm.ToString(), "/", this.BirthDetails.Dobyy.ToString() };
            //timeCorrectionCode = timeCorrection.GetTimeCorrectionCode(fullTimeCorr, string.Concat(text), ref str);


            if (state == null)
            {
                full_tz = country!.ZoneStart ?? "";
            }
            else
            {
                full_tz = state!.Zone ?? "";
            }

            if (selectedBirthCity.Longitude != null)
                BirthDetails.Longtitude = selectedBirthCity.Longitude.ToString().Replace(':', '.').Replace('E', ' ').Replace('W', ' ').Replace('S', ' ').Replace('N', ' ').Trim();

            if (selectedBirthCity.Latitude != null)
                BirthDetails.Latitude = selectedBirthCity.Latitude.ToString().Replace(':', '.').Replace('E', ' ').Replace('W', ' ').Replace('S', ' ').Replace('N', ' ').Trim();

            if (country!.ZoneStart != null)
                BirthDetails.TxtTimezone = country!.ZoneStart.Replace(':', '.').Replace('E', ' ').Replace('W', ' ').Replace('S', ' ').Replace('N', ' ').Trim();

            await Gen_Kundali_Chart();
        }

        private async Task OnClick_Lagan(MouseEventArgs e)
        {
            isNumVarshVisible = false;

            this.show_vfal = false;
            //this.NumUDVYears.Visible = false;
            //PictureBox pictureBox = this.PicKundliChart;
            //KundliBLL kundliBLL = this.kkbl;
            long lagna = this.persKV.Lagna;
            await Gen_Image(lagna.ToString(), this.kp_chart, this.Online_Result, false, 1, this.persKV.Language);
        }

        private async Task OnClick_Gochar(MouseEventArgs e)
        {
            isNumVarshVisible = false;

            this.show_vfal = false;
            //  this.NumUDVYears.Visible = false;
            string str = "";
            string[] strArrays = new string[10];
            DateTime now = DateTime.Now;
            strArrays[0] = now.ToString("dd");
            strArrays[1] = "/";
            now = DateTime.Now;
            strArrays[2] = now.ToString("MM");
            strArrays[3] = "/";
            now = DateTime.Now;
            strArrays[4] = now.ToString("yyyy");
            strArrays[5] = ",";
            now = DateTime.Now;
            strArrays[6] = now.ToString("HH");
            strArrays[7] = ":";
            now = DateTime.Now;
            strArrays[8] = now.ToString("mm");
            strArrays[9] = ",077.12E,28.38N,+05.30,L,null";
            string str1 = string.Concat(strArrays);
            //  PredictionBLL predictionBLL = new PredictionBLL();
            str = await Gen_Kunda(str1, 500f, Convert.ToInt16(BirthDetails.CmbRotate));
            // PredictionBLL predictionBLL1 = new PredictionBLL();
            KundliVO kundliVO = new KundliVO();
            string text = BirthDetails.TxtName;
            string text1 = BirthDetails.TxtBirthPlace;
            string str2 = DateTime.Now.ToString("dd");
            string str3 = DateTime.Now.ToString("MM");
            string str4 = DateTime.Now.ToString("yyyy");
            string str5 = DateTime.Now.ToString("HH");
            now = DateTime.Now;

            var kundli = await Map_PersKV(str, text, text1, str2, str3, str4, str5, now.ToString("mm"), "00", "admin", "28.38", "077.12", "05.30", true, BirthDetails.CmbLanguage, BirthDetails.ChkShowRef, this.male, "YICC", "YICC", "YICC", "YICC", "YICC", "New Product", "01", "01", "2000", 1);

            if (kundli != null)
            {
                kundliVO = kundli;
            }



            List<KPPlanetMappingVO> kPPlanetMappingVOs = new List<KPPlanetMappingVO>();
            List<KPHouseMappingVO> kPHouseMappingVOs = new List<KPHouseMappingVO>();
            ProductSettingsVO productSettingsVO = new ProductSettingsVO();

            var laganResponse = await Process_Planet_Lagan(str, kPPlanetMappingVOs, kPHouseMappingVOs, Convert.ToInt16(BirthDetails.CmbRotate), true);

            if (laganResponse != null)
            {
                kPPlanetMappingVOs = laganResponse.KpChart;
                kPHouseMappingVOs = laganResponse.CuspHouse;
            }

            kPPlanetMappingVOs = await Process_KPChart_GoodBad(kPPlanetMappingVOs, this.persKV, productSettingsVO);
            //PictureBox pictureBox = this.PicKundliChart;
            //KundliBLL kundliBLL = this.kkbl;
            long lagna = kundliVO.Lagna;
            await Gen_Image(lagna.ToString(), kPPlanetMappingVOs, str, true, 1, kundliVO.Language);

        }

        private async Task OnClick_Chandra(MouseEventArgs e)
        {
            isNumVarshVisible = false;

            List<KPPlanetMappingVO> kPPlanetMappingVOs = new List<KPPlanetMappingVO>();
            List<KPHouseMappingVO> kPHouseMappingVOs = new List<KPHouseMappingVO>();
            string str = "";
            KundliBLL kundliBLL = new KundliBLL();
            short rashi = (
                from Map in this.kp_chart
                where Map.Planet == 2
                select Map).FirstOrDefault<KPPlanetMappingVO>()?.Rashi ?? default;

            short num = Convert.ToInt16(Convert.ToInt16((long)rashi - this.persKV.Lagna) + 1);
            if (num <= 0)
            {
                num = Convert.ToInt16(12 - Math.Abs(num));
            }
            if (num > 12)
            {
                num = Convert.ToInt16(num - 12);
            }
            str = await Gen_Kunda(this.prod.Online_Result, (float)rashi, Convert.ToInt16(num));
            var laganResponse = await this.Process_Planet_Lagan(str, kPPlanetMappingVOs, kPHouseMappingVOs, Convert.ToInt16(BirthDetails.CmbRotate), false);
            if (laganResponse != null)
            {
                kPPlanetMappingVOs = laganResponse.KpChart;
                kPHouseMappingVOs = laganResponse.CuspHouse;
            }

            await Gen_Image(rashi.ToString(), kPPlanetMappingVOs, str, false, 1, this.persKV.Language);
            this.show_vfal = false;

        }

        private async Task OnClick_Varsh(MouseEventArgs e)
        {
            isNumVarshVisible = true;
            this.show_vfal = true;
            List<KPPlanetMappingVO> kPPlanetMappingVOs = new List<KPPlanetMappingVO>();
            KundliBLL kundliBLL = new KundliBLL();
            kPPlanetMappingVOs = await NEW_GetVarshaphalKundliMapping(Convert.ToInt16(BirthDetails.KundaliUdvYear), this.persKV, this.kp_chart);
            long lagna = this.persKV.Lagna;
            await Gen_Image(lagna.ToString(), kPPlanetMappingVOs, this.Online_Result, false, 1, this.persKV.Language);
        }

        private async Task<List<KPPlanetMappingVO>> NEW_GetVarshaphalKundliMapping(int age, KundliVO persKV, List<KPPlanetMappingVO> kp_chart)
        {
            var request = new GetVarshaphalKundliMappingRequest()
            {
                Age = age,
                KP_Chart = kp_chart,
                PersKV = persKV
            };

            var reponse = await Swagger!.PostAsync<GetVarshaphalKundliMappingRequest, List<KPPlanetMappingVO>>(KundliBLLApiConst.POST_NEWGetVarshaphalKundliMapping, request);

            if (reponse != null)
            {
                return reponse;
            }
            return new List<KPPlanetMappingVO>();
        }

        private async Task OnClick_BhavChalit(MouseEventArgs e)
        {
            this.isNumVarshVisible = false;
            this.show_vfal = false;
            long lagna = this.persKV.Lagna;
            await Gen_Image(lagna.ToString(), this.kp_chart, this.Online_Result, true, 1, this.persKV.Language);
        }

        private async Task BtnShow_TabKundaliDates_Click(MouseEventArgs e)
        {
            if ((this.full_lat.Length <= 0 ? false : this.full_lon.Length > 0))
            {
                //  Application.UseWaitCursor = true;
                string str = this.full_lon.Replace(":", ".");
                string str1 = this.full_lat.Replace(":", ".");
                //  this.txtbestdate.Text = "";
                BestKundaliDates.BestDate = "";

                str = string.Concat(this.kkbl.DecimalToDMS(Convert.ToDouble(str.Substring(0, str.Length - 1))).ToString(), str.Substring(str.Length - 1, 1));
                str1 = string.Concat(this.kkbl.DecimalToDMS(Convert.ToDouble(str1.Substring(0, str1.Length - 1))).ToString(), str1.Substring(str1.Length - 1, 1));
                string str2 = this.kkbl.longi2timezone(this.full_tz);
                if (str.Length == 6)
                {
                    str = string.Concat("0", str);
                }
                if (str1.Length == 5)
                {
                    str1 = string.Concat("0", str1);
                }
                string str3 = "";
                string str4 = "";
                KundliBLL kundliBLL = new KundliBLL();
                // BestBLL bestBLL = new BestBLL();
                short num = 0;

                DateTime date = BestKundaliDates.Pick_start_date.Date;
                DateTime value = BestKundaliDates.StartingTime;


                DateTime timeOfDay = date + value.TimeOfDay;
                DateTime dateTime = BestKundaliDates.Pick_end_date.Date;
                value = BestKundaliDates.EndingTime;
                DateTime timeOfDay1 = dateTime + value.TimeOfDay;


                long num1 = (long)0;
                short num2 = 0;
                short num3 = 0;
                if (BestKundaliDates.Comborating == "Good")
                {
                    num2 = 1;
                }
                if (BestKundaliDates.Comborating == "Best")
                {
                    num2 = 2;
                }
                if (BestKundaliDates.Comborating == "Excellent")
                {
                    num2 = 3;
                }
                if (BestKundaliDates.KundaliDatesRadio == KundaliDatesRadio.RedBook)
                {
                    num3 = 1;
                }
                if (BestKundaliDates.KundaliDatesRadio == KundaliDatesRadio.Kp)
                {
                    num3 = 2;
                }
                string str5 = "";
                string str6 = "";
                while (true)
                {

                    string[] fullTimeCorrs = new string[15];
                    string[] fullTimeCorr = new string[19];
                    int day = timeOfDay.Day;
                    fullTimeCorr[0] = day.ToString();
                    fullTimeCorr[1] = "/";
                    day = timeOfDay.Month;
                    fullTimeCorr[2] = day.ToString();
                    fullTimeCorr[3] = "/";
                    day = timeOfDay.Year;
                    fullTimeCorr[4] = day.ToString();
                    fullTimeCorr[5] = ",";
                    day = timeOfDay.Hour;
                    fullTimeCorr[6] = day.ToString();
                    fullTimeCorr[7] = ":";
                    day = timeOfDay.Minute;
                    fullTimeCorr[8] = day.ToString();

                    fullTimeCorr[9] = ",";
                    fullTimeCorrs[0] = ",";

                    fullTimeCorr[10] = str;
                    fullTimeCorrs[1] = str;


                    fullTimeCorr[11] = ",";
                    fullTimeCorrs[2] = ",";


                    fullTimeCorr[12] = str1;
                    fullTimeCorrs[3] = str1;


                    fullTimeCorr[13] = ",";
                    fullTimeCorrs[4] = ",";


                    fullTimeCorr[14] = str2;
                    fullTimeCorrs[5] = str2;


                    fullTimeCorr[15] = ",";
                    fullTimeCorrs[6] = ",";


                    fullTimeCorr[16] = this.ayan;
                    fullTimeCorrs[7] = this.ayan;


                    fullTimeCorr[17] = ",";
                    fullTimeCorrs[8] = ",";


                    fullTimeCorr[18] = this.full_time_corr;
                    fullTimeCorrs[9] = this.full_time_corr;

                    //string timeAndDay = timeOfDay;

                    //timeAndDay += string.Concat(fullTimeCorr);

                    //  str3 = string.Concat(fullTimeCorr);
                    str3 = string.Concat(fullTimeCorr);


                    str4 = await Gen_Kunda(str3, 500f, 1);
                    char[] chrArray = new char[] { '-' };
                    str5 = str4.Split(chrArray)[0];
                    if (num3 == 1)
                    {
                        if (str5 != str6)
                        {
                            if (await IsBestKundali(str4, num2, num3))
                            {
                                //TextBox textBox = this.txtbestdate;
                                //textBox.Text = string.Concat(textBox.Text, timeOfDay, "\r\n\r\n");

                                BestKundaliDates.BestDate = string.Concat(BestKundaliDates.BestDate, timeOfDay, "\r\n\r\n");

                            }
                            num1 += (long)1;
                        }
                    }
                    if (num3 == 2)
                    {
                        if (await IsBestKundali(str4, num2, num3))
                        {
                            //TextBox textBox1 = this.txtbestdate;
                            //textBox1.Text = string.Concat(textBox1.Text, timeOfDay.ToString(), "\r\n\r\n");

                            BestKundaliDates.BestDate = string.Concat(BestKundaliDates.BestDate, timeOfDay, "\r\n\r\n");

                        }
                        num1 += (long)1;
                    }
                    str6 = str5;
                    if (num3 == 2)
                    {
                        num = 5;
                    }
                    if (num3 == 1)
                    {
                        num = 30;
                    }


                    timeOfDay = timeOfDay.AddMinutes((double)num);

                    BestKundaliDates.countProcess = string.Concat(num1.ToString(), " Kundalis processed.");

                    if (timeOfDay >= timeOfDay1)
                    {
                        break;
                    }
                }
                //this.lblkundli_nos.Text = string.Concat(num1.ToString(), " Kundalis processed.");
                //Application.UseWaitCursor = false;
            }
            else
            {
                //MessageBox.Show("Please choose City from list.");
                //this.TxtBirthplace.SelectAll();
                //this.TxtBirthplace.Focus();
            }
        }

        #endregion


        private async Task<string> Get_New_Products(ProductSettingsVO prod)
        {
            var response = await Swagger!.PostAsync<ProductSettingsVO, ApiResponse<string>>(KPBLLApiConst.POST_GetNewProducts, prod);

            return response?.Data ?? "";

        }

        private async Task OnClick_BtnFaladesh(MouseEventArgs e)
        {
            this.show_vfal = false;
            this.isNumVarshVisible = false;
            if ((this.full_lat.Length <= 0 ? false : this.full_lon.Length > 0))
            {
                //    Loader.Show();
                string str = this.full_lon.Replace(":", ".");
                string str1 = this.full_lat.Replace(":", ".");
                str = string.Concat(this.kkbl.DecimalToDMS(Convert.ToDouble(str.Substring(0, str.Length - 1))).ToString(), str.Substring(str.Length - 1, 1));
                str1 = string.Concat(this.kkbl.DecimalToDMS(Convert.ToDouble(str1.Substring(0, str1.Length - 1))).ToString(), str1.Substring(str1.Length - 1, 1));
                string str2 = this.kkbl.longi2timezone(this.full_tz);
                if (str.Length == 6)
                {
                    str = string.Concat("0", str);
                }
                if (str1.Length == 5)
                {
                    str1 = string.Concat("0", str1);
                }
                string[] text;
                //string str3 = string.Concat(text);
                string str3 = $"{BirthDetails.Dobdd}/{BirthDetails.Dobmm}/{BirthDetails.Dobyy},{BirthDetails.Tobhh}:{BirthDetails.Tobmm},{str},{str1},{str2},{this.ayan},{this.full_time_corr}";
                text = new string[19];
                DateTime date = DateTime.Now.Date;
                int day = date.Day;
                text[0] = day.ToString();
                text[1] = "/";
                date = DateTime.Now.Date;
                day = date.Month;
                text[2] = day.ToString();
                text[3] = "/";
                date = DateTime.Now.Date;
                day = date.Year;
                text[4] = day.ToString();
                text[5] = ",";
                date = DateTime.Now.Date;
                day = date.Hour;
                text[6] = day.ToString();
                text[7] = ":";
                date = DateTime.Now.Date;
                day = date.Minute;
                text[8] = day.ToString();
                text[9] = ",";
                text[10] = str;
                text[11] = ",";
                text[12] = str1;
                text[13] = ",";
                text[14] = str2;
                text[15] = ",";
                text[16] = this.ayan;
                text[17] = ",";
                text[18] = this.full_time_corr;
                string str4 = string.Concat(text);
                //  PredictionBLL predictionBLL = new PredictionBLL();
                this.Online_Result = await this.Gen_Kunda(str3, 500f, BirthDetails.CmbRotate);
                this.RP_Online_Result = await this.Gen_Kunda(str4, 500f, BirthDetails.CmbRotate);
                //    PredictionBLL predictionBLL1 = new PredictionBLL();

                var responseMrap_PersKV = await Map_PersKV(this.Online_Result, BirthDetails.TxtName, BirthDetails.BirthCity, BirthDetails.Dobdd.ToString(), BirthDetails.Dobmm.ToString(), BirthDetails.Dobyy.ToString(), BirthDetails.Tobhh.ToString(), BirthDetails.Tobmm.ToString(), "00", "admin", BirthDetails.Latitude.ToString(), BirthDetails.Longtitude.ToString(), BirthDetails.TxtTimezone, true, BirthDetails.CmbLanguage, BirthDetails.ChkShowRef, this.male, "YICC", "YICC", "YICC", "YICC", "YICC", "New Product", "01", "01", "2000", 1);
                if (responseMrap_PersKV != null)
                    this.persKV = responseMrap_PersKV;

                this.persKV.FileCode = "500";
                KundliBLL kundliBLL = new KundliBLL();
                ProductSettingsVO productSettingsVO = new ProductSettingsVO()
                {
                    Online_Result = str3,
                    Include = BirthDetails.ChkSahasaneLogic,
                    Lang = BirthDetails.CmbLanguage,
                    Male = this.male,
                    PredFor = 0,
                    ShowRef = BirthDetails.ChkShowRef,
                    ShowUpay = true,
                    ShowUpayCode = true,
                    Sno = (long)555,
                    Category = "",
                    Rotate = BirthDetails.CmbRotate,
                    Mini = false,
                    ShowManyavar = true,
                    NoCategory = true
                };
                this.kp_chart = new List<KPPlanetMappingVO>();
                this.cusp_house = new List<KPHouseMappingVO>();
                var responseLagan = await Process_Planet_Lagan(this.Online_Result, this.kp_chart, this.cusp_house, BirthDetails.CmbRotate, false);

                if (responseLagan != null)
                {
                    this.kp_chart = responseLagan.KpChart;
                    this.cusp_house = responseLagan.CuspHouse;
                }



                this.kp_chart = await Process_KPChart_GoodBad(this.kp_chart, this.persKV, productSettingsVO);
                ProductSettingsVO lower = new ProductSettingsVO()
                {
                    Online_Result = str3,
                    Include = BirthDetails.ChkSahasaneLogic,
                    Lang = BirthDetails.CmbLanguage,
                    Male = this.male,
                    PredFor = 0,
                    ShowRef = BirthDetails.ChkShowRef,
                    ShowUpay = true,
                    ShowUpayCode = true,
                    Sno = (long)555,
                    Rotate = BirthDetails.CmbRotate,
                    Mini = false,
                    ShowManyavar = true,
                    Category = "all",
                    Product_Name = "",
                    Product = BirthDetails.CmbCategory,
                    Karyesh = true
                };

                lower.ShowUpay = true;
                lower.ShowUpayCode = true;
                lower.OnlyMahadasha = false;
                lower.Tool = false;
                lower.ShowManyavar = false;
                if (lower.Product.Contains("YICCCOMBO"))
                {
                    lower.Tool = false;
                    lower.ShowUpay = true;
                    lower.ShowUpayCode = true;
                    lower.ShowManyavar = true;
                }
                if (lower.Product.ToLower() == "tradefair")
                {
                    lower.Tool = false;
                    lower.ShowUpay = true;
                    lower.ShowUpayCode = true;
                    lower.ShowManyavar = false;
                    lower.CurrentMahadasha = true;
                    lower.NoCategory = true;
                    lower.FreeUpay = true;
                    lower.Tool507 = true;
                    lower.Product = "YICCCOMBO1";
                }
                if (lower.Product.ToLower() == "tradefair_upay")
                {
                    lower.Tool = false;
                    lower.ShowUpay = true;
                    lower.ShowUpayCode = true;
                    lower.ShowManyavar = false;
                    lower.CurrentMahadasha = true;
                    lower.NoCategory = true;
                    lower.FreeUpay = true;
                    lower.OnlyUpay = true;
                    lower.Product = "YICCCOMBO1";
                }
                if (lower.Product.Contains("kpcusp"))
                {
                    lower.Tool = false;
                    lower.ShowUpay = false;
                    lower.ShowUpayCode = false;
                    lower.ShowManyavar = false;
                }
                if ((lower.Product.ToLower() == "ratna" ? true : lower.Product.ToLower() == "ratnaonly"))
                {
                    lower.Tool = false;
                    lower.ShowUpay = true;
                    lower.ShowUpayCode = true;
                    lower.ShowManyavar = false;
                    lower.CurrentMahadasha = true;
                    lower.NoCategory = true;
                    lower.FreeUpay = true;
                    lower.Product = lower.Product.ToLower();
                }
                if (lower.Product.ToLower() == "onlyyogyuti")
                {
                    lower.Tool = false;
                    lower.ShowUpay = true;
                    lower.ShowUpayCode = true;
                    lower.ShowManyavar = false;
                    lower.CurrentMahadasha = false;
                    lower.NoCategory = false;
                    lower.FreeUpay = false;
                    lower.Product_Name = "onlyyogyuti";
                    lower.Product = "YICCCOMBO2";
                }
                if (lower.Product.ToLower() == "scorety")
                {
                    lower.Tool = false;
                    lower.ShowUpay = false;
                    lower.ShowUpayCode = false;
                    lower.ShowManyavar = false;
                    lower.CurrentMahadasha = false;
                    lower.NoCategory = false;
                    lower.FreeUpay = false;
                    lower.Product_Name = "scorety";
                    lower.Product = "scorety";
                }
                if (lower.Product.ToLower() == "kamkaj")
                {
                    lower.Tool = false;
                    lower.ShowUpay = false;
                    lower.ShowUpayCode = false;
                    lower.ShowManyavar = false;
                    lower.CurrentMahadasha = false;
                    lower.NoCategory = false;
                    lower.FreeUpay = false;
                    lower.Product_Name = "work_pred";
                    lower.Product = "work_pred";
                }
                if (lower.Product.ToLower() == "toolonlyyogyuti")
                {
                    lower.Tool = false;
                    lower.ShowUpay = false;
                    lower.ShowUpayCode = false;
                    lower.ShowManyavar = false;
                    lower.CurrentMahadasha = false;
                    lower.NoCategory = false;
                    lower.FreeUpay = false;
                    lower.Tool507 = true;
                    lower.Product_Name = "toolonlyyogyuti";
                    lower.Product = "YICCCOMBO2";
                }
                if (lower.Product.ToLower() == "manglik")
                {
                    lower.Tool = false;
                    lower.ShowUpay = false;
                    lower.ShowUpayCode = false;
                    lower.ShowManyavar = false;
                    lower.CurrentMahadasha = false;
                    lower.NoCategory = false;
                    lower.FreeUpay = false;
                    lower.Tool507 = true;
                    lower.Product_Name = "manglik";
                    lower.Product = "manglik";
                }
                if (lower.Product.ToLower() == "redsigni")
                {
                    lower.Tool = false;
                    lower.ShowUpay = false;
                    lower.ShowUpayCode = false;
                    lower.ShowManyavar = false;
                    lower.CurrentMahadasha = false;
                    lower.NoCategory = false;
                    lower.FreeUpay = false;
                    lower.Category = "";
                    lower.Product_Name = "";
                    lower.Product = "RedSigni";
                }
                if (lower.Product.ToLower() == "tool")
                {
                    lower.Category = "all";
                    lower.ShowRef = false;
                    lower.ShowUpay = false;
                    lower.ShowUpayCode = false;
                    lower.ShowManyavar = false;
                    lower.CurrentMahadasha = true;
                    lower.NoCategory = true;
                    lower.FreeUpay = false;
                    lower.Mobile = false;
                    lower.Tool = false;
                    lower.Tool507 = true;
                    lower.Product_Name = "YICCCOMBO1";
                    lower.Product = "married_life";
                }
                if ((lower.Product.ToLower() == "tool_disease" || lower.Product.ToLower() == "tool_married_life" || lower.Product.ToLower() == "tool_occupation" || lower.Product.ToLower() == "tool_parents" ? true : lower.Product.ToLower() == "tool_santan"))
                {
                    lower.Category = "all";
                    lower.ShowRef = false;
                    lower.ShowUpay = false;
                    lower.ShowUpayCode = false;
                    lower.ShowManyavar = false;
                    lower.CurrentMahadasha = true;
                    lower.NoCategory = true;
                    lower.FreeUpay = false;
                    lower.Mobile = false;
                    lower.Tool = false;
                    lower.Tool507 = true;
                    lower.Product_Name = "YICCCOMBO1";
                    lower.Product = lower.Product.Substring(5);
                }
                if (lower.Product.ToLower() == "firstpage")
                {
                    lower.Tool = false;
                    lower.ShowUpay = false;
                    lower.ShowUpayCode = false;
                    lower.ShowManyavar = false;
                    lower.CurrentMahadasha = false;
                    lower.NoCategory = false;
                    lower.FreeUpay = false;
                    lower.Tool507 = true;
                    lower.Product_Name = "firstpage";
                    lower.Product = "firstpage";
                }
                var htmlString = await Get_New_Products(lower);
                if (htmlString != null)
                    await Show_Falla(htmlString);
                //Loader.Close();
            }
            else
            {
                //MessageBox.Show("Please choose City from list.");
                //this.TxtBirthplace.SelectAll();
                //this.TxtBirthplace.Focus();
            }
        }

        private async Task<string> Show_House_Wise_Pred(ChartHouseTableTRModel selectedTR)
        {
            string str = "";
            short num = Convert.ToInt16(selectedTR.House);
            string str1 = "";
            //PredictionBLL predictionBLL = new PredictionBLL();
            ProductSettingsVO productSettingsVO = new ProductSettingsVO()
            {
                Online_Result = this.Online_Result,
                Include = BirthDetails.ChkSahasaneLogic,
                Lang = BirthDetails.CmbLanguage,
                Male = this.male,
                PredFor = 0,
                ShowRef = BirthDetails.ChkShowRef,
                ShowUpay = false,
                ShowUpayCode = true,
                Sno = (long)555,
                Category = "",
                Product = "all",
                Karyesh = true,
                Rotate = BirthDetails.CmbRotate
            };
            //KPDAO kPDAO = new KPDAO();
            List<short> nums = new List<short>();
            List<short> nums1 = new List<short>();
            List<KP_Sublord_Pred> kPSublordPreds = new List<KP_Sublord_Pred>();
            List<KP_Sublord_Pred> kPSublordPreds1 = new List<KP_Sublord_Pred>();

            kPSublordPreds = await Get_KP_Cusp_Pred(this.persKV.ShowRef, num);//

            short subLord = this.cusp_house.Where(Map => Map.House == num).SingleOrDefault<KPHouseMappingVO>()?.Sub_Lord ?? default;

            short nakLord = this.kp_chart.Where(Map => Map.Planet == subLord).SingleOrDefault<KPPlanetMappingVO>()?.Nak_Lord ?? default;

            List<KPSigniVO> signi = this.kp_chart.Where(Map => Map.Planet == nakLord).SingleOrDefault<KPPlanetMappingVO>()?.Signi ?? new();

            List<KPMixDashaVO> kPMixDashaVOs = new List<KPMixDashaVO>();
            //KPDAO kPDAO1 = new KPDAO();
            signi = (
                from Map in signi
                where (Map.Rule == 1 || Map.Rule == 2 || Map.Rule == 8 ? true : Map.Rule == 9)
                select Map).ToList<KPSigniVO>();
            foreach (KPSigniVO kPSigniVO in signi)
            {
                if (num == 1)
                {
                    kPMixDashaVOs = (
                        from Map in await Get_Mix_Dasha(nakLord, kPSigniVO.Signi, 1, this.prod.Product, "house_dasha")//
                        where (Map.general ? true : Map.nature)
                        select Map).ToList<KPMixDashaVO>();
                }
                if (num == 2)
                {
                    kPMixDashaVOs = (
                        from Map in await Get_Mix_Dasha(nakLord, kPSigniVO.Signi, 1, this.prod.Product, "house_dasha")
                        where (Map.family ? true : Map.wealth)
                        select Map).ToList<KPMixDashaVO>();
                }
                if (num == 3)
                {
                    kPMixDashaVOs = (
                        from Map in await Get_Mix_Dasha(nakLord, kPSigniVO.Signi, 1, this.prod.Product, "house_dasha")
                        where Map.sibling
                        select Map).ToList<KPMixDashaVO>();
                }
                if (num == 4)
                {
                    kPMixDashaVOs = (
                        from Map in await Get_Mix_Dasha(nakLord, kPSigniVO.Signi, 1, this.prod.Product, "house_dasha")
                        where (Map.education ? true : Map.parents)
                        select Map).ToList<KPMixDashaVO>();
                }
                if (num == 5)
                {
                    kPMixDashaVOs = (
                        from Map in await Get_Mix_Dasha(nakLord, kPSigniVO.Signi, 1, this.prod.Product, "house_dasha")
                        where (Map.santan ? true : Map.love_affair)
                        select Map).ToList<KPMixDashaVO>();
                }
                if (num == 6)
                {
                    kPMixDashaVOs = (
                        from Map in await Get_Mix_Dasha(nakLord, kPSigniVO.Signi, 1, this.prod.Product, "house_dasha")
                        where (Map.disease ? true : Map.occupation)
                        select Map).ToList<KPMixDashaVO>();
                }
                if (num == 7)
                {
                    kPMixDashaVOs = (
                        from Map in await Get_Mix_Dasha(nakLord, kPSigniVO.Signi, 1, this.prod.Product, "house_dasha")
                        where (Map.married_life ? true : Map.occupation)
                        select Map).ToList<KPMixDashaVO>();
                }
                if (num == 8)
                {
                    kPMixDashaVOs = (
                        from Map in await Get_Mix_Dasha(nakLord, kPSigniVO.Signi, 1, this.prod.Product, "house_dasha")
                        where Map.disease
                        select Map).ToList<KPMixDashaVO>();
                }
                if (num == 9)
                {
                    kPMixDashaVOs = (
                        from Map in await Get_Mix_Dasha(nakLord, kPSigniVO.Signi, 1, this.prod.Product, "house_dasha")
                        where (Map.education ? true : Map.nature)
                        select Map).ToList<KPMixDashaVO>();
                }
                if (num == 10)
                {
                    kPMixDashaVOs = (
                        from Map in await Get_Mix_Dasha(nakLord, kPSigniVO.Signi, 1, this.prod.Product, "house_dasha")
                        where (Map.occupation ? true : Map.work_pred)
                        select Map).ToList<KPMixDashaVO>();
                }
                if (num == 11)
                {
                    kPMixDashaVOs = (
                        from Map in await Get_Mix_Dasha(nakLord, kPSigniVO.Signi, 1, this.prod.Product, "house_dasha")
                        where (Map.parents ? true : Map.occupation)
                        select Map).ToList<KPMixDashaVO>();
                }
                if (num == 12)
                {
                    kPMixDashaVOs = (
                        from Map in await Get_Mix_Dasha(nakLord, kPSigniVO.Signi, 1, this.prod.Product, "house_dasha")
                        where Map.disease
                        select Map).ToList<KPMixDashaVO>();
                }
                kPMixDashaVOs = (
                    from Map in kPMixDashaVOs
                    where Map.House1 == kPSigniVO.Signi
                    select Map).ToList<KPMixDashaVO>();
                foreach (KPMixDashaVO kPMixDashaVO in kPMixDashaVOs)
                {
                    if (this.kpbl.isFewConditionMet(kPMixDashaVO, this.kp_chart, kPSigniVO.Signi.ToString()))//
                    {
                        if (!nums.Exists((short Map) => Map == kPMixDashaVO.Sno))
                        {
                            string str2 = str1;
                            string?[] strArrays = new string?[] { str2, num.ToString(), " : ", null, null };
                            strArrays[3] = kPSigniVO.Signi.ToString();
                            strArrays[4] = " ";
                            str1 = string.Concat(strArrays);
                            str1 = string.Concat(str1, await Get_KP_Lang(kPMixDashaVO.Sno, this.persKV.Language, false, false, this.prod.Mini), "&nbsp;<br />&nbsp;<br />");
                            nums.Add(kPMixDashaVO.Sno);
                        }
                    }
                }
            }
            if (num == 10)
            {
                str1 = string.Concat(await Tenth_Kamkaj_Pred(this.cusp_house, this.kp_chart, this.persKV), "&nbsp;<br />", str1);//
            }
            str = string.Concat(str, str1);
            return str;
        }

        private async Task<string> Get_KP_Lang(short sno, string language, bool v1, bool v2, bool mini)
        {
            var response = await Swagger!.GetAsync<ApiResponse<string>>(string.Format(KPBLLApiConst.GET_GetKPLang, sno, language, v1, v2, mini));
            if (response != null)
                return response.Data ?? string.Empty;
            return string.Empty;
        }

        private async Task<string> Tenth_Kamkaj_Pred(List<KPHouseMappingVO> cusp_house, List<KPPlanetMappingVO> kp_chart, KundliVO persKV)
        {
            var request = new TenthKamkajPredRequestModel() { CuspHouse = cusp_house, KPChart = kp_chart, PersonalKundli = persKV };
            var response = await Swagger!.PostAsync<TenthKamkajPredRequestModel, ApiResponse<string>>(KPBLLApiConst.POST_TenthKamkajPred, request);
            return response?.Data ?? "";
        }

        private async Task<List<KPMixDashaVO>> Get_Mix_Dasha(short nakLord, short signi, short v1, string product, string v2)
        {
            var request = new GetMixDashaRequest()
            {
                Planet = nakLord,
                House = signi,
                FieldNumber = v1,
                Category = product,
                PType = v2

            };

            var response = await Swagger!.PostAsync<GetMixDashaRequest, List<KPMixDashaVO>>(KPDAOApiConst.POST_GetMixDasha, request);
            if (response == null)
                return new();
            return response;
        }

        private async Task<List<KP_Sublord_Pred>> Get_KP_Cusp_Pred(bool showRef, short num)
        {
            var response = await Swagger!.GetAsync<List<KP_Sublord_Pred>>(string.Format(KPDAOApiConst.GET_GetKPCuspPred, showRef, num));
            if (response == null)
                return new();
            return response;
        }

        private async Task OnDblClick_tr_ListView_House(ChartHouseTableTRModel selectedTR)
        {
            //       var d = Show_House_Wise_Pred(selectedTR);

            string str = "";
            str = string.Concat(str, await Show_House_Wise_Pred(selectedTR));
            str = string.Concat(str, "-------------------------------------");
            str = string.Concat(str, "&nbsp;<br/>");
            short num = Convert.ToInt16(selectedTR.House);
            string str1 = "";
            //PredictionBLL predictionBLL = new PredictionBLL();
            ProductSettingsVO productSettingsVO = new ProductSettingsVO()
            {
                Online_Result = this.Online_Result,
                Include = BirthDetails.ChkSahasaneLogic,
                Lang = BirthDetails.CmbLanguage,
                Male = this.male,
                PredFor = 0,
                ShowRef = BirthDetails.ChkShowRef,
                ShowUpay = false,
                ShowUpayCode = true,
                Sno = (long)555,
                Category = "",
                Product = BirthDetails.CmbCategory,
                Karyesh = true,
                Rotate = BirthDetails.CmbRotate
            };
            //    KPDAO kPDAO = new KPDAO();
            List<short> nums = new List<short>();
            List<KP_Sublord_Pred> kPSublordPreds = new List<KP_Sublord_Pred>();
            List<KP_Sublord_Pred> kPSublordPreds1 = new List<KP_Sublord_Pred>();
            kPSublordPreds = await Get_KP_Cusp_Pred(this.persKV.ShowRef, num);
            short subLord = this.cusp_house.Where(Map => Map.House == num).SingleOrDefault<KPHouseMappingVO>()?.Sub_Lord ?? default;
            short nakLord = this.kp_chart.Where(Map => Map.Planet == subLord).SingleOrDefault<KPPlanetMappingVO>()?.Nak_Lord ?? default;
            List<KPSigniVO> signi = this.kp_chart.Where(Map => Map.Planet == nakLord).SingleOrDefault<KPPlanetMappingVO>()?.Signi ?? new List<KPSigniVO>();
            foreach (KPSigniVO kPSigniVO in signi)
            {
                if ((kPSigniVO.Rule == 1 || kPSigniVO.Rule == 2 || kPSigniVO.Rule == 8 ? true : kPSigniVO.Rule == 9))
                {
                    kPSublordPreds1.AddRange(kPSublordPreds.Where(Map => Map.House != num ? false : Map.Sublord == kPSigniVO.Signi).ToList<KP_Sublord_Pred>());

                }
            }
            foreach (KP_Sublord_Pred kPSublordPred in kPSublordPreds1)
            {
                if (!nums.Exists((short Map) => (long)Map == kPSublordPred.Sno))
                {
                    string str2 = str1;
                    string?[] predHindi = new string?[] { str2, null, null, null, null, null, null };
                    short house = kPSublordPred.House;
                    predHindi[1] = house.ToString();
                    predHindi[2] = " : ";
                    house = kPSublordPred.Sublord;
                    predHindi[3] = house.ToString();
                    predHindi[4] = "  ";
                    predHindi[5] = kPSublordPred.Pred_Hindi;
                    predHindi[6] = "&nbsp;<br />&nbsp;<br />";
                    str1 = string.Concat(predHindi);
                }
                nums.Add(Convert.ToInt16(kPSublordPred.Sno));
            }
            str = string.Concat(str, str1);
            await Show_Falla(str);




        }
    }
}
