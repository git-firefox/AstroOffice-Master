using AstroShared.Helper;
using Microsoft.AspNetCore.Components;
using AstroOfficeMobile.Shared;
using AstroShared.DTOs;
using AstroShared;
using AstroShared.Models;
using AstroOfficeWeb.Shared.Models;
using AstroOfficeMobile.Methods;
using AstroOfficeMobile.Services;
using Microsoft.AspNetCore.Components.Web;
using AstroShared.ViewModels;



namespace AstroOfficeMobile.Pages
{
    public partial class Dashboard
    {
        [CascadingParameter]
        private MainLayout MainLayout { get; set; }
        public List<SelectListItem> CmbCountry { get; set; } = new List<SelectListItem>();
        private List<PlaceDTO> ListBirthCities = new();
        private BirthDetails BirthDetails { get; set; } = new BirthDetails();
        private BirthDetailsLookups BirthDetailsLookups { get; set; } = new();

        private string full_lat = "";
        private string full_lon = "";
        private string full_tz = "";
        private string full_time_corr = "";
        private string global_full_lonNew = "";
        private string global_full_latNew = "";
        private string global_newtz = "";
        private string imgSrc;
        private string Online_Result = "";
        private string ayan = "L";
        private bool male = true;
        private bool show_vfal = false;
        private bool maha_dasha_click = true;
        private bool antar_dasha_click = true;
        private bool no_countryload = false;
        private bool sukshma_dasha_click = true;

        private bool isNumVarshVisible = false;


        private bool tobhhEnabled = true;
        private bool tobmmEnabled = true;
        private bool tobssEnabled = true;
        private bool inputBirthDateEnabled = true;
        private bool inputBirthPlaceEnabled = true;

        private KPBLL kpbl = new KPBLL();
        private KundliBLL kkbl = new KundliBLL();
        private KundliVO persKV = new KundliVO();
        private ProductSettingsVO prod = new ProductSettingsVO();
        private List<PlanetVO> pvl = new List<PlanetVO>();

        private SavedStateModel SavedStateModel = new();


        public List<ChartPlanetTableTRModel> ListView_Planet { get; set; }
        public List<ChartHouseTableTRModel> ListView_House { get; set; }
        public List<KundaliTableTRModel> ListView_Ruling_Planet { get; set; }
        public List<MahadashaTableTRModel> ListView_Mahadasha { get; set; }
        public List<AntardashaTableTRModel> ListView_Antardasha { get; set; }
        public List<PrayantardashaTableTRModel> ListView_Prayantardasha { get; set; }
        public List<SukhsmadashaTableTRModel> ListView_Sukhsmadasha { get; set; }
        public List<Years35TableTRModel> ListView_Years35 { get; set; } = new();


        private List<KPHouseMappingVO> cusp_house = new List<KPHouseMappingVO>();
        private List<KPPlanetMappingVO> kp_chart = new List<KPPlanetMappingVO>();
        private List<KPPlanetsVO> planet_list = new List<KPPlanetsVO>();
        private List<KPHouseMappingVO> last_cusp_house = new List<KPHouseMappingVO>();
        private List<KPPlanetMappingVO> last_kp_chart = new List<KPPlanetMappingVO>();
        private List<KPRashiVO> rashi_list = new List<KPRashiVO>();
        private List<KPNAKVO> nak_list = new List<KPNAKVO>();
        private List<KPDashaVO> main_mahadasha = new List<KPDashaVO>();
        private List<KPHousesVO> house_list = new List<KPHousesVO>();
        private List<KP249VO> kp249 = new List<KP249VO>();
        private List<KPDashaVO> main_antardasha = new List<KPDashaVO>();
        private List<KPDashaVO> main_pryaantardasha = new List<KPDashaVO>();
        private List<KPDashaVO> main_sukhsmadasha = new List<KPDashaVO>();

        bool OnInitialized_IsComplatedSuccessfully = false;

        protected override void OnInitialized()
        {
            MainLayout.NavTitle = "Edit Kundali";
        }
        protected override async Task OnInitializedAsync()
        {
            var countryMasters = await GetCountry();
            var planetVOs = await GetAllPlanets();
            var kP249s = await Fill_249();


            CmbCountry = countryMasters?.Select(cm => new SelectListItem(cm.Country, cm.CountryCode)).ToList();

            if (!this.no_countryload && this.BirthDetails.CmbCountry != null && BirthDetails?.TxtBirthPlace?.Trim().Length > 2)
            {
                this.ListBirthCities = await this.GetPlaceListLike(place: BirthDetails?.TxtBirthPlace?.Trim(), countrycode: this.BirthDetails?.CmbCountry);

            }
            if (KundaliHistroy.SelectedSavedKundali != null)
            {
                BirthDetails = KundaliHistroy.SelectedSavedKundali;
            }

      //      await Gen_Kundali_Chart();

            //string str = this.full_lon.Replace(":", ".");
            //string str1 = this.full_lat.Replace(":", ".");
            //str = string.Concat(this.kkbl.DecimalToDMS(Convert.ToDouble(str.Substring(0, str.Length - 1))).ToString(), str.Substring(str.Length - 1, 1));
            //str1 = string.Concat(this.kkbl.DecimalToDMS(Convert.ToDouble(str1.Substring(0, str1.Length - 1))).ToString(), str1.Substring(str1.Length - 1, 1));
            //string str2 = this.kkbl.longi2timezone(this.full_tz);

            //if (str.Length == 6)
            //{
            //    str = string.Concat("0", str);
            //}
            //if (str1.Length == 5)
            //{
            //    str1 = string.Concat("0", str1);
            //}

            //string text = $"{this.BirthDetails!.Dobdd}/{this.BirthDetails.Dobmm}/{this.BirthDetails.Dobyy},{this.BirthDetails.Tobhh}:{this.BirthDetails.Tobmm},{str},{str1},{str2},{this.ayan},{this.full_time_corr}";

            //this.Online_Result = await KundaliBLL.Gen_Kunda(text, 500f, this.BirthDetails.CmbRotate);       

            //if (planetVOs != null)
            //{
            //    this.pvl = planetVOs;
            //}

            //if (kP249s != null)
            //{
            //    this.kp249 = kP249s;
            //}

            //var kundliVO = await PredictionBLL.Map_PersKV(Online_Result, BirthDetails.TxtName, BirthDetails.BirthCity, BirthDetails.Dobdd.ToString(), BirthDetails.Dobmm.ToString(), BirthDetails.Dobyy.ToString(), BirthDetails.Tobhh.ToString(), BirthDetails.Tobmm.ToString(), "00", "admin", BirthDetails.Longtitude, BirthDetails.Latitude, BirthDetails.TxtTimezone, true, BirthDetails.CmbLanguage, BirthDetails.ChkShowRef, this.male, "YICC", "YICC", "YICC", "YICC", "YICC", "New Product", "01", "01", "2000", 1);

            //if (kundliVO != null)
            //{
            //    this.persKV = kundliVO;
            //}

            //await Gen_Image(this.persKV!.Lagna.ToString(), this.kp_chart, Online_Result, false, 1, this.persKV.Language);
            //await this.OnClick_BtnChart(new MouseEventArgs());
            //await base.OnInitializedAsync();

            //if (KundaliHistroy.SelectedSavedKundali != null)
            //{
            //    await OnChange_CmbRotate(new ChangeEventArgs { Value = BirthDetails.CmbRotate });
            //}

            //OnInitialized_IsComplatedSuccessfully = true;


            await MainLayout.NotifyChangeAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime.CloseSidebar();
            }
        }

        private async Task<List<CountryDTO>> GetCountry()
        {
            var countryMasters = await Swagger!.GetAsync<List<CountryDTO>>(CountryApiConst.GET_GetCountry);
            return countryMasters;
        }


        private async Task<List<PlaceDTO>> GetPlaceListLike(string place, string countrycode)
        {
            var response = await Swagger!.GetAsync<List<PlaceDTO>>(string.Format(LocationBLLApiConst.GET_GetPlaceListLike, place, countrycode));
            return response;
        }

        private async Task<List<PlanetVO>> GetAllPlanets()
        {
            var planetVOs = await Swagger!.GetAsync<List<PlanetVO>>(PlanetBLLApiConst.GET_GetKPPlanetsVOs);
            return planetVOs;
        }

        private async Task<List<KP249VO>> Fill_249()
        {
            var kP249s = await Swagger!.GetAsync<List<KP249VO>>(KPBLLApiConst.GET_Fill_249);
            return kP249s;
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

                    this.Online_Result = await KundaliBLL.Gen_Kunda(text, 500f, BirthDetails.CmbRotate);
                   
                    #endregion

                    #region Map Pers KVRequest

                    var kundliVO = await PredictionBLL.Map_PersKV(Online_Result, BirthDetails.TxtName, BirthDetails.BirthCity, BirthDetails.Dobdd.ToString(), BirthDetails.Dobmm.ToString(), BirthDetails.Dobyy.ToString(), BirthDetails.Tobhh.ToString(), BirthDetails.Tobmm.ToString(), "00", "admin", BirthDetails.Longtitude.ToString(), BirthDetails.Latitude.ToString(), BirthDetails.TxtTimezone.ToString(), true, BirthDetails.CmbLanguage, BirthDetails.ChkShowRef, this.male, "YICC", "YICC", "YICC", "YICC", "YICC", "New Product", "01", "01", "2000", this.BirthDetails.CmbRotate);

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
        private async Task Gen_Image(string lagna, List<KPPlanetMappingVO> lkmv, string Online_Result, bool bhav_chalit, short Kund_Size, string lang)
        {
            imgSrc = await KundaliBLL.Gen_Image(lagna, lkmv, Online_Result, bhav_chalit, Kund_Size, lang);
        }


        bool OnClick_BtnChart_IsComplated = true;
        private async Task OnClick_BtnChart(MouseEventArgs e)
        {
            if (!OnClick_BtnChart_IsComplated) return;

            OnClick_BtnChart_IsComplated = false;
            //await Task.Delay(10000);
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

                    this.Online_Result = await KundaliBLL.Gen_Kunda(str3, 500f, BirthDetails.CmbRotate); ;

                    var kundliVO = await PredictionBLL.Map_PersKV(Online_Result, BirthDetails.TxtName, BirthDetails.BirthCity, BirthDetails.Dobdd.ToString(), BirthDetails.Dobmm.ToString(), BirthDetails.Dobyy.ToString(), BirthDetails.Tobhh.ToString(), BirthDetails.Tobmm.ToString(), "00", "admin", BirthDetails.Longtitude.ToString(), BirthDetails.Latitude.ToString(), BirthDetails.TxtTimezone.ToString(), true, BirthDetails.CmbLanguage, BirthDetails.ChkShowRef, this.male, "YICC", "YICC", "YICC", "YICC", "YICC", "New Product", "01", "01", "2000", BirthDetails.CmbRotate);

                    if (kundliVO != null)
                    {
                        this.persKV = kundliVO;
                    }

                    this.persKV.FileCode = "555";

                    #region Process Planet Lagan Request

                    this.kp_chart = new List<KPPlanetMappingVO>();
                    this.cusp_house = new List<KPHouseMappingVO>();

                    var processPlanetLaganResponse = await KPBLL.Process_Planet_Lagan(Online_Result, kp_chart, cusp_house, BirthDetails.CmbRotate, false);

                    this.kp_chart = processPlanetLaganResponse!.KpChart;
                    this.cusp_house = processPlanetLaganResponse!.CuspHouse;

                    #endregion

                    #region  Process KPChart GoodBad Request

                    var kpPlanetMappingVOs = await KPBLL.Process_KPChart_GoodBad(this.kp_chart, this.persKV, productSettingsVO);

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

                //await KaranService!.SaveKPHouseMappingVOs(this.cusp_house);
                //await KaranService!.SaveKPPlanetMappingVOs(this.kp_chart);
                //await KaranService!.SaveStateModel(SavedStateModel);

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
            OnClick_BtnChart_IsComplated = true;
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
                var tr = new ChartPlanetTableTRModel();
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

                if (!list.isbad)
                {
                    tr.ForeColor = "text-success";
                }
                else
                {
                    tr.ForeColor = "text-danger";
                }

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
                        object[] signi = new object[] { obj, kPSigniVO.Signi, "(", null, null };
                        signi[3] = kPSigniVO.Rule.ToString();
                        signi[4] = ") ";
                        str2 = string.Concat(signi);
                        significators = string.Concat(significators, kPSigniVO.Signi, " ");
                    }
                }

                tr.Significators = significators.Trim();
                tr.Planet = planets;
                tr.RL_NL_SL_SSL = string.Concat(hindi);
                tr.ToolTipText = str2;
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
                var tr = new ChartHouseTableTRModel();
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
                if ((this.last_cusp_house.Count <= 0 ? false : signiString != str))
                {
                    tr.ForeColor = "text-primary";
                }
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
            var bhagya = await PredictionBLL.GetCodeLang(this.persKV.Lucky_day1, "hindi", true, true);
            ListView_Ruling_Planet.Add(new KundaliTableTRModel
            {
                Item = "भाग्यशाली दिन",
                SubItem = bhagya
            });

            // Add "जनमदिन"
            DateTime dob = this.persKV.Dob;
            var janama = await PredictionBLL.GetCodeLang(dob.DayOfWeek.ToString(), this.persKV.Language, true, true);
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
        private async Task OnChange_CmbRotate(ChangeEventArgs e)
        {
            var value = Convert.ToInt16(e.Value);
            this.BirthDetails.CmbRotate = value;

            if ((this.full_lat.Length <= 0 ? false : this.full_lon.Length > 0))
            {
                if (value == 1)
                {
                    //this.dobddEnabled = true;
                    //this.dobmmEnabled = true;
                    //this.dobyyEnabled = true;
                    this.tobhhEnabled = true;
                    this.tobmmEnabled = true;
                    this.tobssEnabled = true;
                    this.inputBirthDateEnabled = true;
                    this.inputBirthPlaceEnabled = true;
                    await this.OnClick_BtnChart(new MouseEventArgs());
                }
            }
            if (value > 1)
            {
                //this.dobddEnabled = false;
                //this.dobmmEnabled = false;
                //this.dobyyEnabled = false;
                this.tobhhEnabled = false;
                this.tobmmEnabled = false;
                this.tobssEnabled = false;
                this.inputBirthDateEnabled = false;
                this.inputBirthPlaceEnabled = false;
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
                string str = await KundaliBLL.Gen_Kunda(this.prod.Online_Result, (float)num, Convert.ToInt16(num1));
                this.Online_Result = str;

                var laganResponse = await KPBLL.Process_Planet_Lagan(str, this.kp_chart, this.cusp_house, 1, true);

                if (laganResponse != null)
                {
                    this.kp_chart = laganResponse.KpChart;
                    this.cusp_house = laganResponse.CuspHouse;
                }

                this.kp_chart = await KPBLL.Process_KPChart_GoodBad(this.kp_chart, this.persKV, this.prod);

                long lagna = this.persKV.Lagna;

                await Gen_Image(lagna.ToString(), this.kp_chart, str, true, 1, this.persKV.Language);

                await this.OnClick_BhavChalit(new MouseEventArgs());

                await this.OnClick_BtnChart(new MouseEventArgs());
            }
        }

        private async Task OnClick_BhavChalit(MouseEventArgs e)
        {
            this.isNumVarshVisible = false;
            this.show_vfal = false;
            long lagna = this.persKV.Lagna;
            await Gen_Image(lagna.ToString(), this.kp_chart, this.Online_Result, true, 1, this.persKV.Language);
        }

    }
}
