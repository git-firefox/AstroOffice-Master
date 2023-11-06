using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ASDLL.AstroScienceWeb.BLL;
using ASDLL.DataAccess.Core;
using ASDLL.ASDLL.ValueObjects;
using AstroOffice.Helper;
using System.Drawing.Printing;
using ASBAL;
using Microsoft.Extensions.DependencyInjection;
using AstroShared.Models;

namespace AstroOffice
{
    public partial class FrmNewKP : Form
    {
        private string Online_Result;
        private string RP_Online_Result;

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
        private KPPredBLL kppred = new KPPredBLL();

        private List<PlanetVO> pvl = new List<PlanetVO>();

        private List<short> Varshfal_month = new List<short>();
        private List<short> Varshfal_years = new List<short>();

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

        //private readonly Loader _loader;
        #region Support Methods


        public void Show_Falla(string falla)
        {
            var bitmapBhavChalit = this.kkbl.Gen_Image(this.persKV.Lagna.ToString(), this.kp_chart, this.Online_Result, true, 1, this.persKV.Language); ;
            var bitmapLagan = this.kkbl.Gen_Image(this.persKV.Lagna.ToString(), this.kp_chart, this.Online_Result, false, 1, this.persKV.Language);
            var html = new StringBuilder();

            html.Append("<!DOCTYPE html>")
                .Append("<html lang='en'>")
                .Append("<head>")
                .Append("<meta charset='UTF-8'><meta name='viewport' content='width=device-width, initial-scale=1.0'>")
                .Append("<title>Document</title>")
                .Append("<style>")
                .Append(".content { font-size: 20px; word-wrap: break-word; white-space: pre-wrap; word-wrap: break-word; }")
                .Append(".image-table { width: 100%; }")
                .Append(".image-table th, .image-table td { padding: 10px; }")
                .Append("fieldset { text-align: center; font-size: 20px; }")
                .Append("img { display: block; margin: 0 auto; padding: 10px; }")
                .Append("</style>")
                .Append("</head>")
                .Append("<body>")
                .Append("<table class='image-table'>")
                .Append("<tr>")
                .Append("<td>")
                .AppendFormat("<fieldset><legend>भाव चलित</legend><img src='{0}' alt='भाव चलित'></fieldset>", bitmapBhavChalit.ToString_PNG())
                .Append("</td>")
                .Append("<td>")
                .AppendFormat("<fieldset><legend>लगन</legend><img src='{0}' alt='लगन'></fieldset>", bitmapLagan.ToString_PNG())
                .Append("</td>")
                .Append("</tr>")
                .Append("</table>")
                .AppendFormat("<pre class='content'> {0} </pre>", falla)
                .Append("</body>")
                .Append("</html>");

            this.WebBrowser_GBP.DocumentText = html.ToString();
            this.GrpBPrediction.Visible = true;

            //this.GrpBPrediction.Left = 0;
            //this.GrpBPrediction.Top = 5;
            //this.GrpBPrediction.Width = 2305;
            //this.WebBrowser_GBP.Height = 600;
            //this.GrpBPrediction.Height = 650;
            Toggle_TabControl_Main();
        }

        public void sel_text(object s)
        {
            this.listView_Ruling_Planets.Items.Clear();
            this.LstVHouses.Items.Clear();
            this.LstVPlanets.Items.Clear();
            TextBox textBox = new TextBox();
            TextBox textBox1 = (TextBox)s;
            this.lblday.Text = "";
            if (textBox1.Name != "dobyy")
            {
                if (textBox1.Text.Trim().Length >= 2)
                {
                    textBox1.SelectAll();
                }
                else if (textBox1.Text.Trim().Length >= 4)
                {
                    textBox1.SelectAll();
                }
                if ((textBox1.Text.Trim().Length < 2 ? false : textBox1.Name != "dobyy"))
                {
                    string name = textBox1.Name;
                    if (name != null)
                    {
                        if (name == "dobdd")
                        {
                            textBox = this.dobmm;
                        }
                        else if (name == "dobmm")
                        {
                            textBox = this.dobyy;
                        }
                        else if (name == "tobhh")
                        {
                            textBox = this.tobmm;
                        }
                    }
                }
            }
            textBox.Focus();
            textBox.SelectAll();
            this.Gen_Kundali_Chart();
        }

        public void set_fields()
        {
            this.TxtName.Focus();
        }

        private string Show_House_Wise_Pred()
        {
            string str = "";
            short num = Convert.ToInt16(this.LstVHouses.SelectedItems[0].SubItems[0].Text);
            string str1 = "";
            PredictionBLL predictionBLL = new PredictionBLL();
            ProductSettingsVO productSettingsVO = new ProductSettingsVO()
            {
                Online_Result = this.Online_Result,
                Include = this.ChkSahasaneLogic.Checked,
                Lang = this.CmbLanguage.Text,
                Male = this.male,
                PredFor = 0,
                ShowRef = this.ChkShowRef.Checked,
                ShowUpay = false,
                ShowUpayCode = true,
                Sno = (long)555,
                Category = "",
                Product = "all",
                Karyesh = true,
                Rotate = Convert.ToInt16(this.CmbRotate.Text)
            };
            KPDAO kPDAO = new KPDAO();
            List<short> nums = new List<short>();
            List<short> nums1 = new List<short>();
            List<KP_Sublord_Pred> kPSublordPreds = new List<KP_Sublord_Pred>();
            List<KP_Sublord_Pred> kPSublordPreds1 = new List<KP_Sublord_Pred>();
            kPSublordPreds = kPDAO.Get_KP_Cusp_Pred(this.persKV.ShowRef, num);
            short subLord = (
                from Map in this.cusp_house
                where Map.House == num
                select Map).SingleOrDefault<KPHouseMappingVO>().Sub_Lord;
            short nakLord = (
                from Map in this.kp_chart
                where Map.Planet == subLord
                select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
            List<KPSigniVO> signi = (
                from Map in this.kp_chart
                where Map.Planet == nakLord
                select Map).SingleOrDefault<KPPlanetMappingVO>().Signi;
            List<KPMixDashaVO> kPMixDashaVOs = new List<KPMixDashaVO>();
            KPDAO kPDAO1 = new KPDAO();
            signi = (
                from Map in signi
                where (Map.Rule == 1 || Map.Rule == 2 || Map.Rule == 8 ? true : Map.Rule == 9)
                select Map).ToList<KPSigniVO>();
            foreach (KPSigniVO kPSigniVO in signi)
            {
                if (num == 1)
                {
                    kPMixDashaVOs = (
                        from Map in kPDAO1.Get_Mix_Dasha(nakLord, kPSigniVO.Signi, 1, this.prod.Product, "house_dasha")
                        where (Map.general ? true : Map.nature)
                        select Map).ToList<KPMixDashaVO>();
                }
                if (num == 2)
                {
                    kPMixDashaVOs = (
                        from Map in kPDAO1.Get_Mix_Dasha(nakLord, kPSigniVO.Signi, 1, this.prod.Product, "house_dasha")
                        where (Map.family ? true : Map.wealth)
                        select Map).ToList<KPMixDashaVO>();
                }
                if (num == 3)
                {
                    kPMixDashaVOs = (
                        from Map in kPDAO1.Get_Mix_Dasha(nakLord, kPSigniVO.Signi, 1, this.prod.Product, "house_dasha")
                        where Map.sibling
                        select Map).ToList<KPMixDashaVO>();
                }
                if (num == 4)
                {
                    kPMixDashaVOs = (
                        from Map in kPDAO1.Get_Mix_Dasha(nakLord, kPSigniVO.Signi, 1, this.prod.Product, "house_dasha")
                        where (Map.education ? true : Map.parents)
                        select Map).ToList<KPMixDashaVO>();
                }
                if (num == 5)
                {
                    kPMixDashaVOs = (
                        from Map in kPDAO1.Get_Mix_Dasha(nakLord, kPSigniVO.Signi, 1, this.prod.Product, "house_dasha")
                        where (Map.santan ? true : Map.love_affair)
                        select Map).ToList<KPMixDashaVO>();
                }
                if (num == 6)
                {
                    kPMixDashaVOs = (
                        from Map in kPDAO1.Get_Mix_Dasha(nakLord, kPSigniVO.Signi, 1, this.prod.Product, "house_dasha")
                        where (Map.disease ? true : Map.occupation)
                        select Map).ToList<KPMixDashaVO>();
                }
                if (num == 7)
                {
                    kPMixDashaVOs = (
                        from Map in kPDAO1.Get_Mix_Dasha(nakLord, kPSigniVO.Signi, 1, this.prod.Product, "house_dasha")
                        where (Map.married_life ? true : Map.occupation)
                        select Map).ToList<KPMixDashaVO>();
                }
                if (num == 8)
                {
                    kPMixDashaVOs = (
                        from Map in kPDAO1.Get_Mix_Dasha(nakLord, kPSigniVO.Signi, 1, this.prod.Product, "house_dasha")
                        where Map.disease
                        select Map).ToList<KPMixDashaVO>();
                }
                if (num == 9)
                {
                    kPMixDashaVOs = (
                        from Map in kPDAO1.Get_Mix_Dasha(nakLord, kPSigniVO.Signi, 1, this.prod.Product, "house_dasha")
                        where (Map.education ? true : Map.nature)
                        select Map).ToList<KPMixDashaVO>();
                }
                if (num == 10)
                {
                    kPMixDashaVOs = (
                        from Map in kPDAO1.Get_Mix_Dasha(nakLord, kPSigniVO.Signi, 1, this.prod.Product, "house_dasha")
                        where (Map.occupation ? true : Map.work_pred)
                        select Map).ToList<KPMixDashaVO>();
                }
                if (num == 11)
                {
                    kPMixDashaVOs = (
                        from Map in kPDAO1.Get_Mix_Dasha(nakLord, kPSigniVO.Signi, 1, this.prod.Product, "house_dasha")
                        where (Map.parents ? true : Map.occupation)
                        select Map).ToList<KPMixDashaVO>();
                }
                if (num == 12)
                {
                    kPMixDashaVOs = (
                        from Map in kPDAO1.Get_Mix_Dasha(nakLord, kPSigniVO.Signi, 1, this.prod.Product, "house_dasha")
                        where Map.disease
                        select Map).ToList<KPMixDashaVO>();
                }
                kPMixDashaVOs = (
                    from Map in kPMixDashaVOs
                    where Map.House1 == kPSigniVO.Signi
                    select Map).ToList<KPMixDashaVO>();
                foreach (KPMixDashaVO kPMixDashaVO in kPMixDashaVOs)
                {
                    if (this.kpbl.isFewConditionMet(kPMixDashaVO, this.kp_chart, kPSigniVO.Signi.ToString()))
                    {
                        if (!nums.Exists((short Map) => Map == kPMixDashaVO.Sno))
                        {
                            string str2 = str1;
                            string[] strArrays = new string[] { str2, num.ToString(), " : ", null, null };
                            strArrays[3] = kPSigniVO.Signi.ToString();
                            strArrays[4] = " ";
                            str1 = string.Concat(strArrays);
                            str1 = string.Concat(str1, this.kpbl.Get_KP_Lang(kPMixDashaVO.Sno, this.persKV.Language, false, false, this.prod.Mini), "\r\n\r\n");
                            nums.Add(kPMixDashaVO.Sno);
                        }
                    }
                }
            }
            if (num == 10)
            {
                str1 = string.Concat(this.kpbl.Tenth_Kamkaj_Pred(this.cusp_house, this.kp_chart, this.persKV), "\r\n", str1);
            }
            str = string.Concat(str, str1);
            return str;
        }

        private void Toggle_TabControl_Main()
        {
            TabControl_Main.Visible = !TabControl_Main.Visible;
            //if (TabControl_Main.Visible)
            //    TabControl_Main.Visible = false;
            //else
            //    TabControl_Main.Visible = true;
        }

        //
        private void loadcountry()
        {
            string stateName;
            if (this.TxtBirthplace.Text.Trim().Length > 2)
            {
                LocationBLL locationBLL = new LocationBLL();
                List<APlaceMaster> placeListLike = locationBLL.GetPlaceListLike(this.TxtBirthplace.Text, this.CmbCountry.SelectedValue.ToString());
                this.LstBCity.Items.Clear();
                foreach (var place in placeListLike)
                {
                    var countryCode = new APlaceMaster();
                    if ((place.StateOrCountryCode == null ? false : place.StateOrCountryCode.Length > 0))
                    {
                        var state = new AStateMaster();
                        stateName = locationBLL.GetStateByCode(place.StateOrCountryCode).StateName;
                    }
                    else
                    {
                        stateName = locationBLL.GetCountryByCode(place.CountryCode).Country;
                    }
                    countryCode.Sno = place.Sno;
                    countryCode.Place = string.Concat(place.Place, " [", stateName, "]");
                    countryCode.CountryCode = place.CountryCode;
                    countryCode.Latitude = place.Latitude;
                    countryCode.StateOrCountryCode = place.StateOrCountryCode;
                    countryCode.Longitude = place.Longitude;
                    countryCode.TimeCorrectionCode = place.TimeCorrectionCode;
                    this.LstBCity.Items.Add(countryCode);
                }
                if (this.LstBCity.Items.Count > 0)
                {
                    this.LstBCity.SelectedIndex = 0;
                }
            }
        }

        //
        private void Gen_KP_Chart(List<KPPlanetMappingVO> kp_chart)
        {
            this.LstVPlanets.Items.Clear();
            foreach (KPPlanetMappingVO list in kp_chart.Where(map => map.Planet <= 9).ToList<KPPlanetMappingVO>())
            {
                ListViewItem listViewItem = new ListViewItem();
                string str = "";// 1st col
                if (list.IsPakka)
                {
                    str = string.Concat(str, "P");
                }
                if (list.isManda)
                {
                    str = string.Concat(str, "M");
                }
                if (list.isJadKharab)
                {
                    str = string.Concat(str, "Z");
                }
                listViewItem.Text = string.Concat(this.planet_list[list.Planet - 1].Hindi, " ", str);
                if (!list.isbad)
                {
                    listViewItem.ForeColor = Color.Green;
                }
                else
                {
                    listViewItem.ForeColor = Color.Red;
                }
                if (!this.LstVPlanets.InvokeRequired)
                {
                    this.LstVPlanets.Items.Add(listViewItem);
                }
                else
                {
                    this.LstVPlanets.Invoke(new MethodInvoker(() => this.LstVPlanets.Items.Add(listViewItem)));
                }
                ListViewItem.ListViewSubItemCollection subItems = this.LstVPlanets.Items[this.LstVPlanets.Items.Count - 1].SubItems;

                //send column
                string[] hindi = new string[] { this.planet_list[list.Rashi_Lord - 1].Hindi, "--", this.planet_list[list.Nak_Lord - 1].Hindi, "--", this.planet_list[list.Sub_Lord - 1].Hindi, "--", this.planet_list[list.Sub_Sub_Lord].Hindi };

                subItems.Add(string.Concat(hindi));
                short rule = 0;
                string str1 = ""; // 3rd column
                string str2 = ""; // toltip
                foreach (KPSigniVO kPSigniVO in list.Signi.OrderBy(map => map.Rule))
                {
                    if (this.ChkSahasaneLogic.Checked)
                    {
                        if (rule != kPSigniVO.Rule)
                        {
                            str1 = string.Concat(str1, " | ");
                            rule = kPSigniVO.Rule;
                        }
                        str1 = string.Concat(str1, kPSigniVO.Signi, " ");
                    }
                    else if ((kPSigniVO.Rule == 1 || kPSigniVO.Rule == 2 || kPSigniVO.Rule == 8 ? true : kPSigniVO.Rule == 9))
                    {
                        if (rule != kPSigniVO.Rule)
                        {
                            str1 = string.Concat(str1, " | ");
                            rule = kPSigniVO.Rule;
                        }
                        object obj = str2;
                        object[] signi = new object[] { obj, kPSigniVO.Signi, "(", null, null };
                        signi[3] = kPSigniVO.Rule.ToString();
                        signi[4] = ") ";
                        str2 = string.Concat(signi);
                        str1 = string.Concat(str1, kPSigniVO.Signi, " ");
                    }
                }
                str1 = str1.Trim();
                this.LstVPlanets.Items[this.LstVPlanets.Items.Count - 1].SubItems.Add(str1);
                this.LstVPlanets.Items[this.LstVPlanets.Items.Count - 1].ToolTipText = str2;
            }
            this.LstVPlanets.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.LstVPlanets.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        //
        private void Gen_Cusp_Chart(List<KPHouseMappingVO> cusp_house)
        {
            char[] chrArray;
            List<KPSigniGoodBad> kPSigniGoodBads = new List<KPSigniGoodBad>();
            kPSigniGoodBads = this.kpbl.Fill_Signi_GoodBad();//Move
            if (this.last_cusp_house == null)
            {
                this.last_cusp_house = cusp_house;
            }
            if (this.last_kp_chart == null)
            {
                this.last_kp_chart = this.kp_chart;
            }
            this.LstVHouses.Items.Clear();
            foreach (KPHouseMappingVO cuspHouse in cusp_house)
            {
                ListViewItem listViewItem = new ListViewItem()
                {
                    ForeColor = Color.Black,
                    Text = cuspHouse.House.ToString()
                };
                string signiString = "";
                string str = "";
                if (this.last_cusp_house.Count > 0)
                {
                    short subLord = (
                        from Map in this.last_cusp_house
                        where Map.House == cuspHouse.House
                        select Map).SingleOrDefault<KPHouseMappingVO>().Sub_Lord;
                    short nakLord = (
                        from Map in this.kp_chart
                        where Map.Planet == subLord
                        select Map).Single<KPPlanetMappingVO>().Nak_Lord;
                    short num = (
                        from Map in cusp_house
                        where Map.House == cuspHouse.House
                        select Map).SingleOrDefault<KPHouseMappingVO>().Sub_Lord;
                    short nakLord1 = (
                        from Map in this.kp_chart
                        where Map.Planet == num
                        select Map).Single<KPPlanetMappingVO>().Nak_Lord;
                    signiString = this.kpbl.Get_Signi_String(nakLord, this.last_kp_chart, this.ChkSahasaneLogic.Checked);//move
                    str = this.kpbl.Get_Signi_String(nakLord1, this.kp_chart, this.ChkSahasaneLogic.Checked);//move
                }
                if ((this.last_cusp_house.Count <= 0 ? false : signiString != str))
                {
                    listViewItem.ForeColor = Color.Blue;
                }
                if (!this.LstVHouses.InvokeRequired)
                {
                    this.LstVHouses.Items.Add(listViewItem);
                }
                else
                {
                    this.LstVHouses.Invoke(new MethodInvoker(() => this.LstVHouses.Items.Add(listViewItem)));
                }
                ListViewItem.ListViewSubItemCollection subItems = this.LstVHouses.Items[this.LstVHouses.Items.Count - 1].SubItems;
                string[] hindi = new string[] { this.planet_list[cuspHouse.Rashi_Lord - 1].Hindi, "--", this.planet_list[cuspHouse.Nak_Lord - 1].Hindi, "--", this.planet_list[cuspHouse.Sub_Lord - 1].Hindi, "--", this.planet_list[cuspHouse.Sub_Sub_Lord].Hindi };
                subItems.Add(string.Concat(hindi));
                short rule = 0;
                string str1 = "";
                string str2 = "";
                string str3 = "";
                List<KPSigniVO> signi = (
                    from Map in cusp_house
                    where Map.House == cuspHouse.House
                    select Map).SingleOrDefault<KPHouseMappingVO>().Signi;
                foreach (KPSigniVO kPSigniVO in
                    from Map in signi
                    orderby Map.Rule
                    select Map)
                {
                    if (this.ChkSahasaneLogic.Checked)
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
                short num1 = (
                    from Map in this.kp_chart
                    where Map.Planet == cuspHouse.Sub_Lord
                    select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
                List<KPSigniVO> kPSigniVOs = (
                    from Map in this.kp_chart
                    where Map.Planet == num1
                    select Map).SingleOrDefault<KPPlanetMappingVO>().Signi;
                foreach (KPSigniVO kPSigniVO1 in
                    from Map in kPSigniVOs
                    orderby Map.Rule
                    select Map)
                {
                    if (this.ChkSahasaneLogic.Checked)
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
                kPSigniVOs = (
                    from Map in this.kp_chart
                    where Map.Planet == cuspHouse.Sub_Lord
                    select Map).SingleOrDefault<KPPlanetMappingVO>().Signi;
                string str4 = "";
                rule = 0;
                foreach (KPSigniVO kPSigniVO2 in
                    from Map in kPSigniVOs
                    orderby Map.Rule
                    select Map)
                {
                    if (this.ChkSahasaneLogic.Checked)
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
                this.LstVHouses.Items[this.LstVHouses.Items.Count - 1].ToolTipText = str1;
                this.LstVHouses.Items[this.LstVHouses.Items.Count - 1].SubItems.Add(str3);
                this.LstVHouses.Items[this.LstVHouses.Items.Count - 1].SubItems.Add(str4);
            }
            this.last_cusp_house = cusp_house;
            this.last_kp_chart = this.kp_chart;
            this.LstVHouses.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.LstVHouses.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        //
        private void Gen_Ruling_Planets(List<KPPlanetMappingVO> kp_chart, List<KPHouseMappingVO> cusp_house, string wday, string birthday)
        {
            KPBLL kPBLL = new KPBLL();
            this.listView_Ruling_Planets.Items.Clear();
            List<KPDashaVO> kPDashaVOs = new List<KPDashaVO>();
            List<KPDashaVO> antarDasha = new List<KPDashaVO>();
            List<KPDashaVO> prayatntarDasha = new List<KPDashaVO>();
            List<KPDashaVO> sukhsmaDasha = new List<KPDashaVO>();
            kPDashaVOs = this.kpbl.Get_Dasha(cusp_house, kp_chart, this.persKV, this.ChkSahasaneLogic.Checked);//
            short planet = (
                from Map in kPDashaVOs
                where (DateTime.Now.Date < Map.StartDate ? false : DateTime.Now.Date <= Map.EndDate)
                select Map).SingleOrDefault<KPDashaVO>().Planet;
            DateTime startDate = (
                from Map in kPDashaVOs
                where Map.Planet == planet
                select Map).SingleOrDefault<KPDashaVO>().StartDate;
            DateTime endDate = (
                from Map in kPDashaVOs
                where Map.Planet == planet
                select Map).SingleOrDefault<KPDashaVO>().EndDate;
            antarDasha = this.kpbl.Get_Antar_Dasha(startDate, endDate, planet, kp_chart, this.ChkSahasaneLogic.Checked);
            short num = (
                from Map in antarDasha
                where (DateTime.Now.Date < Map.StartDate ? false : DateTime.Now.Date <= Map.EndDate)
                select Map).SingleOrDefault<KPDashaVO>().Planet;
            DateTime dateTime = (
                from Map in antarDasha
                where Map.Planet == num
                select Map).SingleOrDefault<KPDashaVO>().StartDate;
            DateTime endDate1 = (
                from Map in antarDasha
                where Map.Planet == num
                select Map).SingleOrDefault<KPDashaVO>().EndDate;
            prayatntarDasha = this.kpbl.Get_Prayatntar_Dasha(antarDasha, dateTime, endDate1, planet, num, kp_chart, this.ChkSahasaneLogic.Checked);
            short planet1 = (
                from Map in prayatntarDasha
                where (DateTime.Now.Date < Map.StartDate ? false : DateTime.Now.Date <= Map.EndDate)
                select Map).SingleOrDefault<KPDashaVO>().Planet;
            DateTime startDate1 = (
                from Map in prayatntarDasha
                where Map.Planet == planet1
                select Map).SingleOrDefault<KPDashaVO>().StartDate;
            DateTime dateTime1 = (
                from Map in prayatntarDasha
                where Map.Planet == planet1
                select Map).SingleOrDefault<KPDashaVO>().EndDate;
            sukhsmaDasha = this.kpbl.Get_Sukhsma_Dasha(prayatntarDasha, startDate1, dateTime1, planet, num, planet1, kp_chart, this.ChkSahasaneLogic.Checked);
            short num1 = (
                from Map in sukhsmaDasha
                where (DateTime.Now.Date < Map.StartDate ? false : DateTime.Now.Date <= Map.EndDate)
                select Map).FirstOrDefault<KPDashaVO>().Planet;
            this.listView_Ruling_Planets.Items.Add("महादशा").SubItems.Add(string.Concat(this.planet_list[planet - 1].Hindi, " ", kPBLL.Get_Signi_String(planet, kp_chart, this.ChkSahasaneLogic.Checked)));
            this.listView_Ruling_Planets.Items[this.listView_Ruling_Planets.Items.Count - 1].SubItems.Add("");

            this.listView_Ruling_Planets.Items.Add("अन्तर्दशा").SubItems.Add(string.Concat(this.planet_list[num - 1].Hindi, " ", kPBLL.Get_Signi_String(num, kp_chart, this.ChkSahasaneLogic.Checked)));
            this.listView_Ruling_Planets.Items[this.listView_Ruling_Planets.Items.Count - 1].SubItems.Add("");

            this.listView_Ruling_Planets.Items.Add("प्रयंतरदशा").SubItems.Add(string.Concat(this.planet_list[planet1 - 1].Hindi, " ", kPBLL.Get_Signi_String(planet1, kp_chart, this.ChkSahasaneLogic.Checked)));
            this.listView_Ruling_Planets.Items[this.listView_Ruling_Planets.Items.Count - 1].SubItems.Add("");

            this.listView_Ruling_Planets.Items.Add("सुक्ष्मदशा").SubItems.Add(string.Concat(this.planet_list[num1 - 1].Hindi, " ", kPBLL.Get_Signi_String(num1, kp_chart, this.ChkSahasaneLogic.Checked)));
            this.listView_Ruling_Planets.Items[this.listView_Ruling_Planets.Items.Count - 1].SubItems.Add("");

            this.listView_Ruling_Planets.Items.Add("लाल दशा").SubItems.Add((
                from Map in this.planet_list
                where Map.Roman == this.persKV.Dasha35
                select Map).First<KPPlanetsVO>().Hindi);
            this.listView_Ruling_Planets.Items[this.listView_Ruling_Planets.Items.Count - 1].SubItems.Add("");

            this.listView_Ruling_Planets.Items.Add("भाग्यशाली अंक").SubItems.Add(this.persKV.Lucky_number);
            this.listView_Ruling_Planets.Items[this.listView_Ruling_Planets.Items.Count - 1].SubItems.Add("");

            PredictionBLL predictionBLL = new PredictionBLL();
            this.listView_Ruling_Planets.Items.Add("भाग्यशाली दिन").SubItems.Add(predictionBLL.GetCodeLang(this.persKV.Lucky_day1, "hindi", true, true));
            this.listView_Ruling_Planets.Items[this.listView_Ruling_Planets.Items.Count - 1].SubItems.Add("");

            ListViewItem.ListViewSubItemCollection subItems = this.listView_Ruling_Planets.Items.Add("जनमदिन").SubItems;
            DateTime dob = this.persKV.Dob;
            subItems.Add(predictionBLL.GetCodeLang(dob.DayOfWeek.ToString(), this.persKV.Language, true, true));
            this.listView_Ruling_Planets.Items[this.listView_Ruling_Planets.Items.Count - 1].SubItems.Add("");

            this.listView_Ruling_Planets.Items.Add("जनमदिन ग्रह").SubItems.Add((
                from Map in this.planet_list
                where Map.English == this.persKV.JanamDin
                select Map).First<KPPlanetsVO>().Hindi);
            this.listView_Ruling_Planets.Items[this.listView_Ruling_Planets.Items.Count - 1].SubItems.Add("");

            this.listView_Ruling_Planets.Items.Add("जनमसमय ग्रह").SubItems.Add((
                from Map in this.planet_list
                where Map.English == this.persKV.JanamSamay
                select Map).First<KPPlanetsVO>().Hindi);
            this.listView_Ruling_Planets.Items[this.listView_Ruling_Planets.Items.Count - 1].SubItems.Add("");

            this.listView_Ruling_Planets.Items.Add("राशि").SubItems.Add((
                from Map in this.rashi_list
                where Map.English == this.persKV.Janam_rashi
                select Map).First<KPRashiVO>().Hindi);
            this.listView_Ruling_Planets.Items[this.listView_Ruling_Planets.Items.Count - 1].SubItems.Add("");

            ListViewItem.ListViewSubItemCollection listViewSubItemCollections = this.listView_Ruling_Planets.Items.Add("नक्षत्र").SubItems;
            string hindi = (
                from Map in this.nak_list
                where (long)Map.NakNumber == this.persKV.Nak
                select Map).First<KPNAKVO>().Hindi;
            long charan = this.persKV.Charan;
            listViewSubItemCollections.Add(string.Concat(hindi, " ", charan.ToString()));
            this.listView_Ruling_Planets.Items[this.listView_Ruling_Planets.Items.Count - 1].SubItems.Add("");
            this.listView_Ruling_Planets.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.listView_Ruling_Planets.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        //
        private void Gen_Upay_Chart(List<KPPlanetMappingVO> kp_chart, List<KPHouseMappingVO> cusp_house)
        {
            List<KPSigniVO> signi;
            char[] chrArray;
            string str;
            string[] hindi;
            this.LstViewKPUpay.Items.Clear();
            List<KPUpay> kPUpays = new List<KPUpay>();
            foreach (KPUpay upayLogic in (new KPDAO()).Get_Upay_Logic())
            {
                if (!this.LstViewKPUpay.InvokeRequired)
                {
                    this.LstViewKPUpay.Items.Add(upayLogic.Problem).SubItems.Add(upayLogic.House.ToString());
                }
                else
                {
                    this.LstViewKPUpay.Invoke(new MethodInvoker(() => this.LstViewKPUpay.Items.Add(upayLogic.Problem).SubItems.Add(upayLogic.House.ToString())));
                }
                short rule = 0;
                string red = "";
                string darkSeaGreen = "";
                string str1 = "";
                string str2 = "";
                KPPlanetMappingVO kPPlanetMappingVO = new KPPlanetMappingVO();
                short subLord = (
                    from Map in cusp_house
                    where Map.House == upayLogic.House
                    select Map).SingleOrDefault<KPHouseMappingVO>().Sub_Lord;
                short nakLord = (
                    from Map in kp_chart
                    where Map.Planet == subLord
                    select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
                short num = (
                    from Map in cusp_house
                    where Map.House == upayLogic.House
                    select Map).SingleOrDefault<KPHouseMappingVO>().Nak_Lord;
                short rashiLord = (
                    from Map in cusp_house
                    where Map.House == upayLogic.House
                    select Map).SingleOrDefault<KPHouseMappingVO>().Rashi_Lord;
                kPPlanetMappingVO = (
                    from Map in kp_chart
                    where Map.Planet == nakLord
                    select Map).SingleOrDefault<KPPlanetMappingVO>();
                foreach (KPSigniVO kPSigniVO1 in
                    from Map in kPPlanetMappingVO.Signi
                    orderby Map.Rule
                    select Map)
                {
                    if (this.ChkSahasaneLogic.Checked)
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
                    select Map).SingleOrDefault<KPHouseMappingVO>().Signi;
                foreach (KPSigniVO kPSigniVO2 in
                    from Map in kPSigniVOs
                    where (Map.Rule == 1 || Map.Rule == 2 || Map.Rule == 8 ? true : Map.Rule == 9)
                    select Map)
                {
                    signi = (
                        from Map in kp_chart
                        where Map.Planet == kPSigniVO2.Signi
                        select Map).SingleOrDefault<KPPlanetMappingVO>().Signi;
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
                            select Map).SingleOrDefault<KPPlanetMappingVO>().Signi;
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
                            select Map).SingleOrDefault<KPPlanetMappingVO>().Signi;
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
                                select Map).SingleOrDefault<KPPlanetMappingVO>().Signi;
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
                this.LstViewKPUpay.Items[this.LstViewKPUpay.Items.Count - 1].SubItems.Add(str1);
                this.LstViewKPUpay.Items[this.LstViewKPUpay.Items.Count - 1].SubItems.Add(darkSeaGreen).BackColor = Color.DarkSeaGreen;
                this.LstViewKPUpay.Items[this.LstViewKPUpay.Items.Count - 1].SubItems.Add(red).ForeColor = Color.Red;
                this.LstViewKPUpay.Items[this.LstViewKPUpay.Items.Count - 1].SubItems.Add(str2);
                this.LstViewKPUpay.Items[this.LstViewKPUpay.Items.Count - 1].SubItems.Add(upayLogic.Good);
            }
            this.LstViewKPUpay.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.LstViewKPUpay.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }


        private void Gen_Mahadasha(List<KPDashaVO> dasha_list, List<KPPlanetMappingVO> kp_chart)
        {
            //KPBLL kPBLL = new KPBLL();
            this.LstVMahadasha.Items.Clear();
            this.LstVAntar.Items.Clear();
            this.LstVPratyantar.Items.Clear();
            this.LstVSukhsma.Items.Clear();
            this.LblMahadasha.Text = "-";
            this.LblAntar.Text = "-";
            this.LblParyan.Text = "-";
            this.LblSukhsmadasha.Text = "-";
            foreach (KPDashaVO dashaList in dasha_list)
            {
                ListViewItem.ListViewSubItemCollection subItems = this.LstVMahadasha.Items.Add((
                    from Map in this.planet_list
                    where Map.Planet == dashaList.Planet
                    select Map).SingleOrDefault<KPPlanetsVO>().Hindi).SubItems;
                DateTime startDate = dashaList.StartDate;
                string str = startDate.ToString("dd MMM yyyy");
                startDate = dashaList.EndDate;
                subItems.Add(string.Concat(str, " - ", startDate.ToString("dd MMM yyyy")));
                this.LstVMahadasha.Items[this.LstVMahadasha.Items.Count - 1].SubItems.Add(string.Concat(dashaList.Signi_String, " | ", dashaList.Nak_Signi_String));
            }
            this.LstVMahadasha.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.LstVMahadasha.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        //
        private void Gen_Kundali_Chart()
        {
            bool flag = false;
            try
            {
                DateTime dateTime = new DateTime(Convert.ToInt16(this.dobyy.Text), Convert.ToInt16(this.dobmm.Text), Convert.ToInt16(this.dobdd.Text), Convert.ToInt16(this.tobhh.Text), Convert.ToInt16(this.tobmm.Text), 0);
            }
            catch (Exception)
            {
                flag = true;
            }
            if (!flag)
            {
                if (Convert.ToInt16(this.dobyy.Text) >= 1900)
                {
                    string str = "";
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
                    PredictionBLL predictionBLL = new PredictionBLL();
                    string[] text = new string[] { this.dobdd.Text, "/", this.dobmm.Text, "/", this.dobyy.Text, ",", this.tobhh.Text, ":", this.tobmm.Text, ",", str1, ",", str2, ",", str3, ",", this.ayan, ",", this.full_time_corr };
                    str = string.Concat(text);
                    this.Online_Result = this.kkbl.Gen_Kunda(str, 500f, Convert.ToInt16(this.CmbRotate.Text));
                    this.persKV = predictionBLL.map_persKV(this.Online_Result, this.TxtName.Text, this.LstBCity.Text, this.dobdd.Text, this.dobmm.Text, this.dobyy.Text, this.tobhh.Text, this.tobmm.Text, "00", "admin", this.TxtLatitude.Text, this.TxtLongitude.Text, this.TxtTimezone.Text, true, this.CmbLanguage.Text.ToString(), this.ChkShowRef.Checked, this.male, "YICC", "YICC", "YICC", "YICC", "YICC", "New Product", "01", "01", "2000", 1);
                    this.kp_chart = new List<KPPlanetMappingVO>();
                    this.cusp_house = new List<KPHouseMappingVO>();
                    this.kpbl.Process_Planet_Lagan(this.Online_Result, ref this.kp_chart, ref this.cusp_house, Convert.ToInt16(this.CmbRotate.Text), false);//
                    this.kp_chart = this.kpbl.Process_KPChart_GoodBad(this.kp_chart, this.persKV, this.prod);//
                    PictureBox pictureBox = this.PicKundliChart;
                    KundliBLL kundliBLL = this.kkbl;
                    long lagna = this.persKV.Lagna;
                    pictureBox.Image = kundliBLL.Gen_Image(lagna.ToString(), this.kp_chart, this.Online_Result, true, 1, this.persKV.Language);
                }
            }
        }

        private void Gen_SukhsmaDasha(List<KPDashaVO> dasha_list, List<KPPlanetMappingVO> kp_chart)
        {
            KPBLL kPBLL = new KPBLL();
            this.LstVSukhsma.Items.Clear();
            foreach (KPDashaVO dashaList in dasha_list)
            {
                ListViewItem.ListViewSubItemCollection subItems = this.LstVSukhsma.Items.Add((
                    from Map in this.planet_list
                    where Map.Planet == dashaList.Planet
                    select Map).SingleOrDefault<KPPlanetsVO>().Hindi).SubItems;
                DateTime startDate = dashaList.StartDate;
                string str = startDate.ToString("dd MMM yyyy");
                startDate = dashaList.EndDate;
                subItems.Add(string.Concat(str, " - ", startDate.ToString("dd MMM yyyy")));
                this.LstVSukhsma.Items[this.LstVSukhsma.Items.Count - 1].SubItems.Add(string.Concat(dashaList.Signi_String, " | ", dashaList.Nak_Signi_String));
            }
            this.LstVSukhsma.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.LstVSukhsma.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void Gen_PryantarDasha(List<KPDashaVO> dasha_list, List<KPPlanetMappingVO> kp_chart)
        {
            KPBLL kPBLL = new KPBLL();
            this.LstVPratyantar.Items.Clear();
            foreach (KPDashaVO dashaList in dasha_list)
            {
                ListViewItem.ListViewSubItemCollection subItems = this.LstVPratyantar.Items.Add((
                    from Map in this.planet_list
                    where Map.Planet == dashaList.Planet
                    select Map).SingleOrDefault<KPPlanetsVO>().Hindi).SubItems;
                DateTime startDate = dashaList.StartDate;
                string str = startDate.ToString("dd MMM yyyy");
                startDate = dashaList.EndDate;
                subItems.Add(string.Concat(str, " - ", startDate.ToString("dd MMM yyyy")));
                this.LstVPratyantar.Items[this.LstVPratyantar.Items.Count - 1].SubItems.Add(string.Concat(dashaList.Signi_String, " | ", dashaList.Nak_Signi_String));
            }
            this.LstVPratyantar.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.LstVPratyantar.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void Gen_AntarDasha(List<KPDashaVO> dasha_list, List<KPPlanetMappingVO> kp_chart)
        {
            KPBLL kPBLL = new KPBLL();
            this.LstVAntar.Items.Clear();
            foreach (KPDashaVO dashaList in dasha_list)
            {
                ListViewItem.ListViewSubItemCollection subItems = this.LstVAntar.Items.Add((
                    from Map in this.planet_list
                    where Map.Planet == dashaList.Planet
                    select Map).SingleOrDefault<KPPlanetsVO>().Hindi).SubItems;
                DateTime startDate = dashaList.StartDate;
                string str = startDate.ToString("dd MMM yyyy");
                startDate = dashaList.EndDate;
                subItems.Add(string.Concat(str, " - ", startDate.ToString("dd MMM yyyy")));
                this.LstVAntar.Items[this.LstVAntar.Items.Count - 1].SubItems.Add(string.Concat(dashaList.Signi_String, " | ", dashaList.Nak_Signi_String));
            }
            this.LstVAntar.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            this.LstVAntar.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        #endregion

        public FrmNewKP()
        {
            InitializeComponent();
            //_loader = new Loader();
            LblLogo.Text = Properties.Settings.Default.AppName.ToUpper();
        }

        protected override void WndProc(ref Message message)
        {
            if (message.Msg == ApplicationConst.WM_NCCALCSIZE && message.WParam.ToInt32() == 1) return;
            base.WndProc(ref message);
        }

        //private void frmnewkp_Load_1(object sender, EventArgs e)
        private void FrmNewKP_Load(object sender, EventArgs e)
        {
            this.CmbRotate.SelectedIndex = 0;  //
            this.show_vfal = false;//
            this.NumUDVYears.Visible = false;//
            this.pick_start_date.Value = DateTime.Now.Date;//
            this.pick_end_date.Value = DateTime.Now.Date.AddDays(1);//
            this.comborating.SelectedIndex = 0;//   !
            this.CmbTime.SelectedIndex = 0;//   !
            this.CmbSkipBad.SelectedIndex = 0;//    !
            BALCountry balCountry = Program.ServiceProvider.GetRequiredService<BALCountry>();//
            this.CmbCountry.DataSource = balCountry.GetCountry();//
            this.CmbCountry.DisplayMember = "Country";//
            this.CmbCountry.ValueMember = "CountryCode";//
            this.CmbCountry.SelectedValue = "Ind.";//
            ASDLL.AstroGlobal.Online = false;//
            this.pvl = (new PlanetBLL()).GetAllPlanets();//
            this.CmbLanguage.SelectedIndex = 0;//
            this.CmbCategory.SelectedIndex = 0;//
            if (!Helper.AstroGlobal.IsAdmin)//
            {
                this.TxtTimezone.ReadOnly = true;//
                this.TxtBirthplace.ReadOnly = true;//
                this.TxtName.ReadOnly = true;//
            }
            if (Helper.AstroGlobal.CanModify)//
            {
                this.TxtTimezone.ReadOnly = false;//
                this.TxtBirthplace.ReadOnly = false;//
                this.TxtName.ReadOnly = false;//
            }
            this.CmbAyanansh.SelectedIndex = 0;//   !
            this.planet_list = this.kpbl.Fill_Planets();//
            this.house_list = this.kpbl.Fill_Houses();//
            this.nak_list = this.kpbl.Fill_Nak();//
            this.rashi_list = this.kpbl.Fill_Rashi();//


            //===========================
            this.kp249 = this.kpbl.Fill_249();//
            this.set_fields();//    !
            this.TxtBirthPlace_KeyDown(sender, new KeyEventArgs(Keys.KeyCode));//   !


            this.TxtBirthplace.Text = "Delhi";//


            if (!this.no_countryload && this.CmbCountry.SelectedValue != null)//
            {
                this.loadcountry();//           !
            }//
            this.no_countryload = false;//
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
            //==================================


            this.dobdd.Text = "12";//  !
            this.dobmm.Text = "05";// !
            this.dobyy.Text = "2006";// !
            this.tobhh.Text = "13";//   !
            this.tobmm.Text = "25";//  !


            string[] text = new string[] { this.dobdd.Text, "/", this.dobmm.Text, "/", this.dobyy.Text, ",", this.tobhh.Text, ":", this.tobmm.Text, ",", str, ",", str1, ",", str2, ",", this.ayan, ",", this.full_time_corr };
            string str3 = string.Concat(text);
            PredictionBLL predictionBLL = new PredictionBLL();//
            this.Online_Result = this.kkbl.Gen_Kunda(str3, 500f, Convert.ToInt16(this.CmbRotate.Text));//
            this.persKV = predictionBLL.map_persKV(this.Online_Result, this.TxtName.Text, this.LstBCity.Text, this.dobdd.Text, this.dobmm.Text, this.dobyy.Text, this.tobhh.Text, this.tobmm.Text, "00", "admin", this.TxtLatitude.Text, this.TxtLongitude.Text, this.TxtTimezone.Text, true, this.CmbLanguage.Text.ToString(), this.ChkShowRef.Checked, this.male, "YICC", "YICC", "YICC", "YICC", "YICC", "New Product", "01", "01", "2000", 1);//
            PictureBox pictureBox = this.PicKundliChart;
            KundliBLL kundliBLL = this.kkbl;
            long lagna = this.persKV.Lagna;
            pictureBox.Image = kundliBLL.Gen_Image(lagna.ToString(), this.kp_chart, this.Online_Result, false, 1, this.persKV.Language);
            this.BtnChart_Click(sender, e);
        }

        //private void frmnewkp_FormClosed(object sender, FormClosedEventArgs e)
        private void FrmNewKP_FormClosed(object sender, FormClosedEventArgs e)
        {
            base.Dispose();
            Application.Exit();
            Application.ExitThread();
        }

        //private void listView_planets_SelectedIndexChanged(object sender, EventArgs e)
        private void ListViewPlanets_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //private void listView_houses_SelectedIndexChanged(object sender, EventArgs e)
        private void ListViewHouses_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //private void listView_houses_MouseDoubleClick(object sender, MouseEventArgs e)
        private void ListViewHouses_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string str = "";
            str = string.Concat(str, this.Show_House_Wise_Pred());
            str = string.Concat(str, "-------------------------------------");
            str = string.Concat(str, "\r\n");
            short num = Convert.ToInt16(this.LstVHouses.SelectedItems[0].SubItems[0].Text);
            string str1 = "";
            //PredictionBLL predictionBLL = new PredictionBLL();
            ProductSettingsVO productSettingsVO = new ProductSettingsVO()
            {
                Online_Result = this.Online_Result,
                Include = this.ChkSahasaneLogic.Checked,
                Lang = this.CmbLanguage.Text,
                Male = this.male,
                PredFor = 0,
                ShowRef = this.ChkShowRef.Checked,
                ShowUpay = false,
                ShowUpayCode = true,
                Sno = (long)555,
                Category = "",
                Product = this.CmbCategory.Text,
                Karyesh = true,
                Rotate = Convert.ToInt16(this.CmbRotate.Text)
            };
            KPDAO kPDAO = new KPDAO();
            List<short> nums = new List<short>();
            List<KP_Sublord_Pred> kPSublordPreds = new List<KP_Sublord_Pred>();
            List<KP_Sublord_Pred> kPSublordPreds1 = new List<KP_Sublord_Pred>();
            kPSublordPreds = kPDAO.Get_KP_Cusp_Pred(this.persKV.ShowRef, num);
            short subLord = this.cusp_house.Where(Map => Map.House == num).SingleOrDefault<KPHouseMappingVO>().Sub_Lord;
            short nakLord = this.kp_chart.Where(Map => Map.Planet == subLord).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
            List<KPSigniVO> signi = this.kp_chart.Where(Map => Map.Planet == nakLord).SingleOrDefault<KPPlanetMappingVO>().Signi;
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
                    string[] predHindi = new string[] { str2, null, null, null, null, null, null };
                    short house = kPSublordPred.House;
                    predHindi[1] = house.ToString();
                    predHindi[2] = " : ";
                    house = kPSublordPred.Sublord;
                    predHindi[3] = house.ToString();
                    predHindi[4] = "  ";
                    //predHindi[5] = kPSublordPred.Pred_Hindi;
                    predHindi[5] = kPSublordPred.Pred_English;
                    predHindi[6] = "\r\n\r\n";
                    str1 = string.Concat(predHindi);
                }
                nums.Add(Convert.ToInt16(kPSublordPred.Sno));
            }
            str = string.Concat(str, str1);
            this.Show_Falla(str);
        }

        //private void tabPage2_Click(object sender, EventArgs e)
        private void TabReports_Click(object sender, EventArgs e)
        {

        }

        //private void button3_Click(object sender, EventArgs e)
        private void BtnVarsh_Click(object sender, EventArgs e)
        {
            this.NumUDVYears.Visible = true;
            this.show_vfal = true;
            List<KPPlanetMappingVO> kPPlanetMappingVOs = new List<KPPlanetMappingVO>();
            KundliBLL kundliBLL = new KundliBLL();
            kPPlanetMappingVOs = kundliBLL.NEW_GetVarshaphalKundliMapping(Convert.ToInt16(this.NumUDVYears.Value), this.persKV, this.kp_chart);
            PictureBox pictureBox = this.PicKundliChart;
            KundliBLL kundliBLL1 = this.kkbl;
            long lagna = this.persKV.Lagna;
            pictureBox.Image = kundliBLL1.Gen_Image(lagna.ToString(), kPPlanetMappingVOs, this.Online_Result, false, 1, this.persKV.Language);
        }

        //private void button13_Click(object sender, EventArgs e)
        private void BtnGochar_Click(object sender, EventArgs e)
        {
            this.show_vfal = false;
            this.NumUDVYears.Visible = false;
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
            PredictionBLL predictionBLL = new PredictionBLL();
            str = this.kkbl.Gen_Kunda(str1, 500f, Convert.ToInt16(this.CmbRotate.Text));
            PredictionBLL predictionBLL1 = new PredictionBLL();
            KundliVO kundliVO = new KundliVO();
            string text = this.TxtName.Text;
            string text1 = this.LstBCity.Text;
            string str2 = DateTime.Now.ToString("dd");
            string str3 = DateTime.Now.ToString("MM");
            string str4 = DateTime.Now.ToString("yyyy");
            string str5 = DateTime.Now.ToString("HH");
            now = DateTime.Now;
            kundliVO = predictionBLL1.map_persKV(str, text, text1, str2, str3, str4, str5, now.ToString("mm"), "00", "admin", "28.38", "077.12", "05.30", true, this.CmbLanguage.Text.ToString(), this.ChkShowRef.Checked, this.male, "YICC", "YICC", "YICC", "YICC", "YICC", "New Product", "01", "01", "2000", 1);
            List<KPPlanetMappingVO> kPPlanetMappingVOs = new List<KPPlanetMappingVO>();
            List<KPHouseMappingVO> kPHouseMappingVOs = new List<KPHouseMappingVO>();
            ProductSettingsVO productSettingsVO = new ProductSettingsVO();
            this.kpbl.Process_Planet_Lagan(str, ref kPPlanetMappingVOs, ref kPHouseMappingVOs, Convert.ToInt16(this.CmbRotate.Text), true);
            kPPlanetMappingVOs = this.kpbl.Process_KPChart_GoodBad(kPPlanetMappingVOs, this.persKV, productSettingsVO);
            PictureBox pictureBox = this.PicKundliChart;
            KundliBLL kundliBLL = this.kkbl;
            long lagna = kundliVO.Lagna;
            pictureBox.Image = kundliBLL.Gen_Image(lagna.ToString(), kPPlanetMappingVOs, str, true, 1, kundliVO.Language);
        }

        //private void button12_Click(object sender, EventArgs e)
        private void BtnChandra_Click(object sender, EventArgs e)
        {
            List<KPPlanetMappingVO> kPPlanetMappingVOs = new List<KPPlanetMappingVO>();
            List<KPHouseMappingVO> kPHouseMappingVOs = new List<KPHouseMappingVO>();
            string str = "";
            KundliBLL kundliBLL = new KundliBLL();
            short rashi = (
                from Map in this.kp_chart
                where Map.Planet == 2
                select Map).FirstOrDefault<KPPlanetMappingVO>().Rashi;
            short num = Convert.ToInt16(Convert.ToInt16((long)rashi - this.persKV.Lagna) + 1);
            if (num <= 0)
            {
                num = Convert.ToInt16(12 - Math.Abs(num));
            }
            if (num > 12)
            {
                num = Convert.ToInt16(num - 12);
            }
            str = this.kkbl.Gen_Kunda(this.prod.Online_Result, (float)rashi, Convert.ToInt16(num));
            this.kpbl.Process_Planet_Lagan(str, ref kPPlanetMappingVOs, ref kPHouseMappingVOs, Convert.ToInt16(this.CmbRotate.Text), false);
            this.PicKundliChart.Image = this.kkbl.Gen_Image(rashi.ToString(), kPPlanetMappingVOs, str, false, 1, this.persKV.Language);
            this.show_vfal = false;
            this.NumUDVYears.Visible = false;
        }

        //private void button13_Click(object sender, EventArgs e)
        private void BtnBhavChalit_Click(object sender, EventArgs e)
        {
            this.show_vfal = false;
            this.NumUDVYears.Visible = false;
            PictureBox pictureBox = this.PicKundliChart;
            KundliBLL kundliBLL = this.kkbl;
            long lagna = this.persKV.Lagna;
            pictureBox.Image = kundliBLL.Gen_Image(lagna.ToString(), this.kp_chart, this.Online_Result, true, 1, this.persKV.Language);
        }

        //private void button10_Click(object sender, EventArgs e)
        private void BtnLagan_Click(object sender, EventArgs e)
        {
            this.show_vfal = false;
            this.NumUDVYears.Visible = false;
            PictureBox pictureBox = this.PicKundliChart;
            KundliBLL kundliBLL = this.kkbl;
            long lagna = this.persKV.Lagna;
            pictureBox.Image = kundliBLL.Gen_Image(lagna.ToString(), this.kp_chart, this.Online_Result, false, 1, this.persKV.Language);
        }

        //private void button2_Click_2(object sender, EventArgs e)
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
            Application.ExitThread();
        }

        //private void button5_Click_1(object sender, EventArgs e)
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            this.last_cusp_house = null;
            this.last_kp_chart = null;
            this.BtnChart_Click(sender, e);
        }

        //private void cmbLang_SelectedIndexChanged(object sender, EventArgs e)
        private void ComboLang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //private void combotime_SelectedIndexChanged(object sender, EventArgs e)
        private void ComboTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.CmbTime.Text.ToLower() == "lagan")
            {
                this.TxtTimeValue.Text = "1";
            }
        }

        //private void button4_Click(object sender, EventArgs e)
        private void BtnFaladesh_Click(object sender, EventArgs e)
        {
            this.kpbl = new KPBLL();
            this.show_vfal = false;
            this.NumUDVYears.Visible = false;
            if ((this.full_lat.Length <= 0 ? false : this.full_lon.Length > 0))
            {
                Loader.Show();
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
                string[] text = new string[] { this.dobdd.Text, "/", this.dobmm.Text, "/", this.dobyy.Text, ",", this.tobhh.Text, ":", this.tobmm.Text, ",", str, ",", str1, ",", str2, ",", this.ayan, ",", this.full_time_corr };
                string str3 = string.Concat(text);
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
                PredictionBLL predictionBLL = new PredictionBLL();
                this.Online_Result = this.kkbl.Gen_Kunda(str3, 500f, Convert.ToInt16(this.CmbRotate.Text));
                this.RP_Online_Result = this.kkbl.Gen_Kunda(str4, 500f, Convert.ToInt16(this.CmbRotate.Text));
                PredictionBLL predictionBLL1 = new PredictionBLL();
                this.persKV = predictionBLL1.map_persKV(this.Online_Result, this.TxtName.Text, this.LstBCity.Text, this.dobdd.Text, this.dobmm.Text, this.dobyy.Text, this.tobhh.Text, this.tobmm.Text, "00", "admin", this.TxtLatitude.Text, this.TxtLongitude.Text, this.TxtTimezone.Text, true, this.CmbLanguage.Text.ToString(), this.ChkShowRef.Checked, this.male, "YICC", "YICC", "YICC", "YICC", "YICC", "New Product", "01", "01", "2000", 1);
                this.persKV.FileCode = "500";
                KundliBLL kundliBLL = new KundliBLL();
                ProductSettingsVO productSettingsVO = new ProductSettingsVO()
                {
                    Online_Result = str3,
                    Include = this.ChkSahasaneLogic.Checked,
                    Lang = this.CmbLanguage.Text,
                    Male = this.male,
                    PredFor = 0,
                    ShowRef = this.ChkShowRef.Checked,
                    ShowUpay = true,
                    ShowUpayCode = true,
                    Sno = (long)555,
                    Category = "",
                    Rotate = Convert.ToInt16(this.CmbRotate.Text),
                    Mini = false,
                    ShowManyavar = true,
                    NoCategory = true
                };
                this.kp_chart = new List<KPPlanetMappingVO>();
                this.cusp_house = new List<KPHouseMappingVO>();
                this.kpbl.Process_Planet_Lagan(this.Online_Result, ref this.kp_chart, ref this.cusp_house, Convert.ToInt16(this.CmbRotate.Text), false);
                this.kp_chart = this.kpbl.Process_KPChart_GoodBad(this.kp_chart, this.persKV, productSettingsVO);
                ProductSettingsVO lower = new ProductSettingsVO()
                {
                    Online_Result = str3,
                    Include = this.ChkSahasaneLogic.Checked,
                    Lang = this.CmbLanguage.Text,
                    Male = this.male,
                    PredFor = 0,
                    ShowRef = this.ChkShowRef.Checked,
                    ShowUpay = true,
                    ShowUpayCode = true,
                    Sno = (long)555,
                    Rotate = Convert.ToInt16(this.CmbRotate.Text),
                    Mini = false,
                    ShowManyavar = true,
                    Category = "all",
                    Product_Name = "",
                    Product = this.CmbCategory.Text,
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
                this.TxtBrief.Text = this.kpbl.Get_New_Products(lower);
                this.Show_Falla(this.TxtBrief.Text);
                Loader.Close();
            }
            else
            {
                MessageBox.Show("Please choose City from list.");
                this.TxtBirthplace.SelectAll();
                this.TxtBirthplace.Focus();
            }
        }

        //private void btn_minus_Click(object sender, EventArgs e)
        private void BtnMinus_Click(object sender, EventArgs e)
        {
            short num = Convert.ToInt16(this.TxtTimeValue.Text);
            DateTime tob = this.persKV.Tob;
            if (this.CmbTime.Text.ToLower() == "minute")
            {
                tob = tob.AddMinutes((double)(-num));
            }
            if (this.CmbTime.Text.ToLower() == "hour")
            {
                tob = tob.AddHours((double)(-num));
            }
            if (this.CmbTime.Text.ToLower() == "day")
            {
                tob = tob.AddDays((double)(-num));
            }
            if (this.CmbTime.Text.ToLower() == "lagan")
            {
                short num1 = 120;
                short num2 = 0;
                double degreeHouseDecimal = (
                    from Map in this.cusp_house
                    where Map.House == 1
                    select Map).SingleOrDefault<KPHouseMappingVO>().DegreeHouse_Decimal;
                num2 = Convert.ToInt16(num1 - Convert.ToInt16(degreeHouseDecimal) * 4);
                if (num2 <= 5)
                {
                    num2 = 5;
                }
                num2 = Convert.ToInt16(num2 + 20);
                tob = tob.AddMinutes((double)(-num2));
            }
            TextBox str = this.dobdd;
            int day = tob.Day;
            str.Text = day.ToString();
            TextBox textBox = this.dobmm;
            day = tob.Month;
            textBox.Text = day.ToString();
            TextBox str1 = this.dobyy;
            day = tob.Year;
            str1.Text = day.ToString();
            TextBox textBox1 = this.tobhh;
            day = tob.Hour;
            textBox1.Text = day.ToString();
            TextBox str2 = this.tobmm;
            day = tob.Minute;
            str2.Text = day.ToString();
            this.BtnChart_Click(sender, e);
            BestBLL bestBLL = new BestBLL();
            short num3 = 0;
            if (this.CmbSkipBad.Text == "Skip Average")
            {
                num3 = 1;
            }
            if (this.CmbSkipBad.Text == "Skip Bad")
            {
                num3 = 2;
            }
            if (this.CmbSkipBad.Text == "Skip Worst")
            {
                num3 = 3;
            }
            string[] globalFullLonNew = new string[19];
            day = tob.Day;
            globalFullLonNew[0] = day.ToString();
            globalFullLonNew[1] = "/";
            day = tob.Month;
            globalFullLonNew[2] = day.ToString();
            globalFullLonNew[3] = "/";
            day = tob.Year;
            globalFullLonNew[4] = day.ToString();
            globalFullLonNew[5] = ",";
            day = tob.Hour;
            globalFullLonNew[6] = day.ToString();
            globalFullLonNew[7] = ":";
            day = tob.Minute;
            globalFullLonNew[8] = day.ToString();
            globalFullLonNew[9] = ",";
            globalFullLonNew[10] = this.global_full_lonNew;
            globalFullLonNew[11] = ",";
            globalFullLonNew[12] = this.global_full_latNew;
            globalFullLonNew[13] = ",";
            globalFullLonNew[14] = this.global_newtz;
            globalFullLonNew[15] = ",";
            globalFullLonNew[16] = this.ayan;
            globalFullLonNew[17] = ",";
            globalFullLonNew[18] = this.full_time_corr;
            string str3 = string.Concat(globalFullLonNew);
            PredictionBLL predictionBLL = new PredictionBLL();
            if ((bestBLL.isBestKundali_KP_Auto(this.kkbl.Gen_Kunda(str3, 500f, Convert.ToInt16(this.CmbRotate.Text)), num3) ? false : this.CmbSkipBad.Text != "Show All"))
            {
                this.BtnMinus_Click(sender, e);
            }
        }

        //private void txtbrief_TextChanged(object sender, EventArgs e)
        private void TxtBrief_TextChanged(object sender, EventArgs e)
        {
        }

        //private void chk35sala_CheckedChanged_1(object sender, EventArgs e)
        private void Chk35SalaChakkar_CheckedChanged(object sender, EventArgs e)
        {
            this.LstVYears35.Visible = this.Chk35Sala.Checked;
            this.LstVAntar.Visible = !this.LstVYears35.Visible;
            if (!this.Chk35Sala.Checked)
            {
                //this.LstVPratyantar.Visible = true;
                //this.LblHindiPratyantar.Visible = true;
                //this.LstVSukhsma.Visible = true;
                //this.LblHindiSukshma.Visible = true;
                this.Panel_View_Pratyantar.Visible = true;
                this.Panel_View_Sukshmadasha.Visible = true;
            }
            else
            {
                //this.LstVPratyantar.Visible = false;
                //this.LstVSukhsma.Visible = false;
                //this.LblHindiPratyantar.Visible = false;
                //this.LblHindiSukshma.Visible = false;
                this.Panel_View_Pratyantar.Visible = false;
                this.Panel_View_Sukshmadasha.Visible = false;

                this.LblAntar.Text = "-";
                this.LblParyan.Text = "-";
                this.LblSukhsmadasha.Text = "-";
                this.maha_dasha_click = true;
                this.sukshma_dasha_click = false;
                //this.LstVMahadasha.Width = 440;
                //this.LstVAntar.Width = 440;
                //this.LstVPratyantar.Width = 75;
                //this.LstVSukhsma.Width = 75;
                //this.LstVAntar.Left = this.LstVMahadasha.Width + 20;
                //this.LstVPratyantar.Left = this.LstVMahadasha.Width + this.LstVAntar.Width + 20;
                //this.LstVSukhsma.Left = this.LstVMahadasha.Width + this.LstVAntar.Width + this.LstVPratyantar.Width + 30;
                //this.LblHindiMahadasha.Left = this.LstVMahadasha.Left;
                //this.LblHindiAntar.Left = this.LstVAntar.Left;
                //this.LblHindiPratyantar.Left = this.LstVPratyantar.Left;
                //this.LblHindiSukshma.Left = this.LstVSukhsma.Left;
            }
        }

        //private void combocat_SelectedIndexChanged(object sender, EventArgs e)
        private void ComboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        //private void cmbAyanansh_SelectedIndexChanged(object sender, EventArgs e)
        private void ComboAyanansh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.CmbAyanansh.Text == "KP")
            {
                this.ayan = "K";
            }
            if (this.CmbAyanansh.Text == "Lahiri")
            {
                this.ayan = "L";
            }
        }

        //private void cmbrotate_SelectedIndexChanged(object sender, EventArgs e)
        private void ComboRotate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((this.full_lat.Length <= 0 ? false : this.full_lon.Length > 0))
            {
                if (this.CmbRotate.Text == "1")
                {
                    this.BtnChart_Click(sender, e);
                    this.dobdd.Enabled = true;
                    this.dobmm.Enabled = true;
                    this.dobyy.Enabled = true;
                    this.tobhh.Enabled = true;
                    this.tobmm.Enabled = true;
                    this.tobss.Enabled = true;
                    this.TxtBirthplace.Enabled = true;
                }
            }
            if (Convert.ToInt16(this.CmbRotate.Text) > 1)
            {
                this.dobdd.Enabled = false;
                this.dobmm.Enabled = false;
                this.dobyy.Enabled = false;
                this.tobhh.Enabled = false;
                this.tobmm.Enabled = false;
                this.tobss.Enabled = false;
                this.TxtBirthplace.Enabled = false;
                string str = "";
                //KundliBLL kundliBLL = new KundliBLL();
                this.kp_chart = new List<KPPlanetMappingVO>();
                this.cusp_house = new List<KPHouseMappingVO>();
                short num = Convert.ToInt16(this.persKV.Base_Lagna + (long)Convert.ToInt16(this.CmbRotate.Text) - (long)1);
                if (num > 12)
                {
                    num = Convert.ToInt16(num - 12);
                }
                short num1 = Convert.ToInt16(Convert.ToInt16(this.CmbRotate.Text));
                this.persKV.Lagna = (long)num;
                str = this.kkbl.Gen_Kunda(this.prod.Online_Result, (float)num, Convert.ToInt16(num1));
                this.Online_Result = str;
                this.kpbl.Process_Planet_Lagan(str, ref this.kp_chart, ref this.cusp_house, 1, true);
                this.kp_chart = this.kpbl.Process_KPChart_GoodBad(this.kp_chart, this.persKV, this.prod);
                PictureBox pictureBox = this.PicKundliChart;
                KundliBLL kundliBLL1 = this.kkbl;
                long lagna = this.persKV.Lagna;
                pictureBox.Image = kundliBLL1.Gen_Image(lagna.ToString(), this.kp_chart, str, true, 1, this.persKV.Language);
                this.BtnBhavChalit_Click(sender, e);
                this.BtnChart_Click(sender, e);
            }
        }

        //private void chkinclude_CheckedChanged(object sender, EventArgs e)
        private void ChkSahasaneLogic_CheckedChanged(object sender, EventArgs e)
        {
            //this.Button1_Click_1(sender, e);
        }

        //private void Button1_Click_1(object sender, EventArgs e)
        //{
        //}

        //private void btn_plus_Click(object sender, EventArgs e)
        private void BtnPlus_Click(object sender, EventArgs e)
        {
            short num = Convert.ToInt16(this.TxtTimeValue.Text);
            DateTime tob = this.persKV.Tob;
            if (this.CmbTime.Text.ToLower() == "minute")
            {
                tob = tob.AddMinutes((double)num);
            }
            if (this.CmbTime.Text.ToLower() == "hour")
            {
                tob = tob.AddHours((double)num);
            }
            if (this.CmbTime.Text.ToLower() == "day")
            {
                tob = tob.AddDays((double)num);
            }
            if (this.CmbTime.Text.ToLower() == "lagan")
            {
                short num1 = 120;
                short num2 = 0;
                double degreeHouseDecimal = (
                    from Map in this.cusp_house
                    where Map.House == 1
                    select Map).SingleOrDefault<KPHouseMappingVO>().DegreeHouse_Decimal;
                num2 = Convert.ToInt16(num1 - Convert.ToInt16(degreeHouseDecimal) * 4);
                if (num2 <= 5)
                {
                    num2 = 5;
                }
                num2 = Convert.ToInt16(num2 + 20);
                tob = tob.AddMinutes((double)num2);
            }
            TextBox str = this.dobdd;
            int day = tob.Day;
            str.Text = day.ToString();
            TextBox textBox = this.dobmm;
            day = tob.Month;
            textBox.Text = day.ToString();
            TextBox str1 = this.dobyy;
            day = tob.Year;
            str1.Text = day.ToString();
            TextBox textBox1 = this.tobhh;
            day = tob.Hour;
            textBox1.Text = day.ToString();
            TextBox str2 = this.tobmm;
            day = tob.Minute;
            str2.Text = day.ToString();
            this.BtnChart_Click(sender, e);
            BestBLL bestBLL = new BestBLL();
            short num3 = 0;
            if (this.CmbSkipBad.Text == "Skip Average")
            {
                num3 = 1;
            }
            if (this.CmbSkipBad.Text == "Skip Bad")
            {
                num3 = 2;
            }
            if (this.CmbSkipBad.Text == "Skip Worst")
            {
                num3 = 3;
            }
            string[] globalFullLonNew = new string[19];
            day = tob.Day;
            globalFullLonNew[0] = day.ToString();
            globalFullLonNew[1] = "/";
            day = tob.Month;
            globalFullLonNew[2] = day.ToString();
            globalFullLonNew[3] = "/";
            day = tob.Year;
            globalFullLonNew[4] = day.ToString();
            globalFullLonNew[5] = ",";
            day = tob.Hour;
            globalFullLonNew[6] = day.ToString();
            globalFullLonNew[7] = ":";
            day = tob.Minute;
            globalFullLonNew[8] = day.ToString();
            globalFullLonNew[9] = ",";
            globalFullLonNew[10] = this.global_full_lonNew;
            globalFullLonNew[11] = ",";
            globalFullLonNew[12] = this.global_full_latNew;
            globalFullLonNew[13] = ",";
            globalFullLonNew[14] = this.global_newtz;
            globalFullLonNew[15] = ",";
            globalFullLonNew[16] = this.ayan;
            globalFullLonNew[17] = ",";
            globalFullLonNew[18] = this.full_time_corr;
            string str3 = string.Concat(globalFullLonNew);
            PredictionBLL predictionBLL = new PredictionBLL();
            if ((bestBLL.isBestKundali_KP_Auto(this.kkbl.Gen_Kunda(str3, 500f, Convert.ToInt16(this.CmbRotate.Text)), num3) ? false : this.CmbSkipBad.Text != "Show All"))
            {
                this.BtnPlus_Click(sender, e);
            }
        }

        //private void button1_Click(object sender, EventArgs e)
        private void BtnChart_Click(object sender, EventArgs e)
        {
            this.kpbl = new KPBLL();
            this.show_vfal = false;
            this.NumUDVYears.Visible = false;
            if ((this.full_lat.Length <= 0 ? false : this.full_lon.Length > 0))
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
                string[] text = new string[] { this.dobdd.Text, "/", this.dobmm.Text, "/", this.dobyy.Text, ",", this.tobhh.Text, ":", this.tobmm.Text, ",", str, ",", str1, ",", str2, ",", this.ayan, ",", this.full_time_corr };
                string str3 = string.Concat(text);
                //PredictionBLL predictionBLL = new PredictionBLL();
                PredictionBLL predictionBLL1 = new PredictionBLL();
                //KundliBLL kundliBLL = new KundliBLL();
                ProductSettingsVO productSettingsVO = new ProductSettingsVO()
                {
                    Online_Result = str3,
                    Include = this.ChkSahasaneLogic.Checked,
                    Lang = this.CmbLanguage.Text,
                    Male = this.male,
                    PredFor = 0,
                    ShowRef = this.ChkShowRef.Checked,
                    ShowUpay = false,
                    ShowUpayCode = true,
                    Sno = (long)555,
                    Category = "all",
                    Product = "",
                    Rotate = Convert.ToInt16(this.CmbRotate.Text)
                };
                if (this.CmbRotate.Text == "1")
                {
                    this.kp_chart = new List<KPPlanetMappingVO>();
                    this.cusp_house = new List<KPHouseMappingVO>();
                    this.Online_Result = this.kkbl.Gen_Kunda(str3, 500f, Convert.ToInt16(this.CmbRotate.Text));
                    this.persKV = predictionBLL1.map_persKV(this.Online_Result, this.TxtName.Text, this.LstBCity.Text, this.dobdd.Text, this.dobmm.Text, this.dobyy.Text, this.tobhh.Text, this.tobmm.Text, "00", "admin", this.TxtLatitude.Text, this.TxtLongitude.Text, this.TxtTimezone.Text, true, this.CmbLanguage.Text.ToString(), this.ChkShowRef.Checked, this.male, "YICC", "YICC", "YICC", "YICC", "YICC", "New Product", "01", "01", "2000", Convert.ToInt16(this.CmbRotate.Text));
                    this.persKV.FileCode = "555";
                    this.kpbl.Process_Planet_Lagan(this.Online_Result, ref this.kp_chart, ref this.cusp_house, Convert.ToInt16(this.CmbRotate.Text), false);
                    this.kp_chart = this.kpbl.Process_KPChart_GoodBad(this.kp_chart, this.persKV, productSettingsVO);
                    PictureBox pictureBox = this.PicKundliChart;
                    KundliBLL kundliBLL1 = this.kkbl;
                    long lagna = this.persKV.Lagna;
                    pictureBox.Image = kundliBLL1.Gen_Image(lagna.ToString(), this.kp_chart, this.Online_Result, true, 1, this.persKV.Language);
                }
                this.Gen_KP_Chart(this.kp_chart);
                this.Gen_Cusp_Chart(this.cusp_house);
                List<KPPlanetMappingVO> kpChart = this.kp_chart;
                List<KPHouseMappingVO> cuspHouse = this.cusp_house;
                string str4 = DateTime.Now.ToString("dddd");
                DateTime dob = this.persKV.Dob;
                this.Gen_Ruling_Planets(kpChart, cuspHouse, str4, dob.ToString("dddd"));
                this.Gen_Upay_Chart(this.kp_chart, this.cusp_house);
                this.main_mahadasha = this.kpbl.Get_Dasha(this.cusp_house, this.kp_chart, this.persKV, this.ChkSahasaneLogic.Checked);
                this.Gen_Mahadasha(this.main_mahadasha, this.kp_chart);
                Font font = new Font("Kruti Dev 011", 16f, FontStyle.Bold);
                if (this.persKV.Language.ToLower() == "english")
                {
                    font = new Font("Arial", 13f, FontStyle.Regular);
                }
                this.prod = productSettingsVO;
                if (this.persKV.Current_Age <= 0)
                {
                    this.persKV.Current_Age = 1;
                }
                this.NumUDVYears.Value = this.persKV.Current_Age + 1;
            }
            else
            {
                MessageBox.Show("Please choose City from list.");
                this.TxtBirthplace.SelectAll();
                this.TxtBirthplace.Focus();
            }
        }

        //private void txttimevalue_TextChanged(object sender, EventArgs e)
        private void TxtTimeValue_TextChanged(object sender, EventArgs e)
        {
        }

        //private void tobmm_TextChanged(object sender, EventArgs e)
        private void TxtToBMinute_TextChanged(object sender, EventArgs e)
        {
            this.Gen_Kundali_Chart();
        }

        //private void tobmm_Enter(object sender, EventArgs e)
        private void TxtToBMinute_Enter(object sender, EventArgs e)
        {
            this.tobmm.SelectAll();
        }

        //private void tobmm_GotFocus(object sender, EventArgs e)
        private void TxtToBMinute_GotFocus(object sender, EventArgs e)
        {
            this.tobmm.SelectAll();
        }

        //private void tobhh_TextChanged(object sender, EventArgs e)
        private void TxtToBHours_TextChanged(object sender, EventArgs e)
        {
            this.sel_text(sender);
        }

        //private void tobhh_Enter(object sender, EventArgs e)
        private void TxtToBHours_Enter(object sender, EventArgs e)
        {
            this.tobhh.SelectAll();
        }

        //private void dobyy_TextChanged(object sender, EventArgs e)
        private void TxtDOBYear_TextChanged(object sender, EventArgs e)
        {
            this.sel_text(sender);
        }

        //private void dobyy_Enter(object sender, EventArgs e)
        private void TxtDOBYear_Enter(object sender, EventArgs e)
        {
            this.dobyy.SelectAll();
        }

        //private void dobmm_TextChanged(object sender, EventArgs e)
        private void TxtDOBMonth_TextChanged(object sender, EventArgs e)
        {
            this.sel_text(sender);
        }

        //private void TxtDOBMonth_Enter(object sender, EventArgs e)
        private void TxtDOBMonth_Enter(object sender, EventArgs e)
        {
            this.dobmm.SelectAll();
        }

        //private void TxtDOBDay_TextChanged(object sender, EventArgs e)
        private void TxtDOBDay_TextChanged(object sender, EventArgs e)
        {
            this.sel_text(sender);
        }

        //private void TxtDOBDay_Enter(object sender, EventArgs e)
        private void TxtDOBDay_Enter(object sender, EventArgs e)
        {
            this.dobdd.SelectAll();
        }

        //private void listcity_SelectedIndexChanged(object sender, EventArgs e)
        private void ListBoxCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            var place = new APlaceMaster();//
            LocationBLL locationBLL = new LocationBLL();//
            var country = new ACountryMaster();//
            place = locationBLL.GetPlaceByID(((APlaceMaster)this.LstBCity.SelectedItem).Sno);//
            country = locationBLL.GetCountryByCode(((APlaceMaster)this.LstBCity.SelectedItem).CountryCode.ToString());//
            this.full_lon = ((APlaceMaster)this.LstBCity.SelectedItem).Longitude.ToString().Trim();
            this.full_lat = ((APlaceMaster)this.LstBCity.SelectedItem).Latitude.ToString().Trim();
            this.full_time_corr = ((APlaceMaster)this.LstBCity.SelectedItem).TimeCorrectionCode;
            //var timeCorrection = new TimeCorrection();
            //string str = "";
            //string timeCorrectionCode = "";
            //string fullTimeCorr = this.full_time_corr;
            //string[] text = new string[] { this.dobdd.Text, "/", this.dobmm.Text, "/", this.dobyy.Text };
            //timeCorrectionCode = timeCorrection.GetTimeCorrectionCode(fullTimeCorr, string.Concat(text), ref str);
            AStateMaster stateByCode = null;
            stateByCode = locationBLL.GetStateByCode(place.CountryCode);
            if (stateByCode == null)
            {
                this.full_tz = country.ZoneStart;
            }
            else
            {
                this.full_tz = stateByCode.Zone;
            }
            this.TxtLongitude.Text = ((APlaceMaster)this.LstBCity.SelectedItem).Longitude.ToString().Replace(':', '.').Replace('E', ' ').Replace('W', ' ').Replace('S', ' ').Replace('N', ' ').Trim();
            this.TxtLatitude.Text = ((APlaceMaster)this.LstBCity.SelectedItem).Latitude.ToString().Replace(':', '.').Replace('E', ' ').Replace('W', ' ').Replace('S', ' ').Replace('N', ' ').Trim();
            this.TxtTimezone.Text = country.ZoneStart.Replace(':', '.').Replace('E', ' ').Replace('W', ' ').Replace('S', ' ').Replace('N', ' ').Trim();
            this.Gen_Kundali_Chart();
        }

        //private void txtbirthplace_TextChanged(object sender, EventArgs e)
        private void TxtBirthPlace_TextChanged(object sender, EventArgs e)
        {
            if (!this.no_countryload)
            {
                this.loadcountry();
            }
            this.no_countryload = false;
        }

        //private void txtbirthplace_Enter_1(object sender, EventArgs e)
        private void TxtBirthPlace_Enter(object sender, EventArgs e)
        {
            this.TxtBirthplace.SelectAll();
        }

        //private void txtbirthplace_KeyDown(object sender, KeyEventArgs e)
        private void TxtBirthPlace_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                if (this.LstBCity.SelectedIndex > 0)
                {
                    this.LstBCity.SelectedIndex = this.LstBCity.SelectedIndex - 1;
                }
            }
            if (e.KeyCode == Keys.Down)
            {
                if (this.LstBCity.SelectedIndex < this.LstBCity.Items.Count - 1)
                {
                    this.LstBCity.SelectedIndex = this.LstBCity.SelectedIndex + 1;
                }
            }
        }

        //private void txtname_TextChanged(object sender, EventArgs e)
        private void TxtName_TextChanged(object sender, EventArgs e)
        {
        }

        //private void tabPage5_Click(object sender, EventArgs e)
        private void TabMahadasha_Click(object sender, EventArgs e)
        {
        }

        //private void listyears35_DoubleClick(object sender, EventArgs e)
        private void ListViewYears35_DoubleClick(object sender, EventArgs e)
        {
            string falAntar = "";
            if (this.LstVMahadasha.SelectedItems.Count > 0)
            {
                short planet = (
                    from Map in this.planet_list
                    where Map.Hindi == this.LstVYears35.SelectedItems[0].SubItems[0].Text
                    select Map).SingleOrDefault<KPPlanetsVO>().Planet;
                short num = planet;
                PredictionBLL predictionBLL = new PredictionBLL();
                this.prod.ShowUpay = true;
                this.prod.ShowUpayCode = true;
                this.persKV.Paid = true;
                this.prod.ShowUpayBelow = true;
                this.prod.Paid = true;
                if (!(this.LstVYears35.SelectedItems[0].SubItems[1].Text == "-"))
                {
                    this.prod.Vfal = true;
                    falAntar = predictionBLL.Get_Fal_Antar(this.Online_Result, num, this.LstVYears35.SelectedItems[0].SubItems[1].Text, this.LstVYears35.SelectedItems[0].SubItems[3].Text, this.persKV, this.prod, this.ChkMfal.Checked);
                    this.prod.Vfal = false;
                }
                else
                {
                    short planet1 = (
                        from Map in this.planet_list
                        where Map.Hindi == this.LstVMahadasha.SelectedItems[0].SubItems[0].Text
                        select Map).SingleOrDefault<KPPlanetsVO>().Planet;
                    falAntar = predictionBLL.Get_Fal_Double_Antar_Hyphen_Wala(this.LstVYears35.SelectedItems[0].SubItems[1].Text, this.LstVYears35.SelectedItems[0].SubItems[3].Text, planet, planet1, this.prod, this.persKV);
                }
                this.Show_Falla(falAntar);
            }
            else
            {
                MessageBox.Show("Please Select Mahadasha");
            }
        }

        //private void listsukhsma_SelectedIndexChanged(object sender, EventArgs e)
        private void ListViewSukhsma_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        //private void listsukhsma_Click(object sender, EventArgs e)
        private void ListViewSukhsma_Click(object sender, EventArgs e)
        {
            this.sukshma_dasha_click = true;
            //this.LstVMahadasha.Width = 70;
            //this.LstVAntar.Width = 70;
            //this.LstVPratyantar.Width = 470;
            //this.LstVSukhsma.Width = 470;
            this.antar_dasha_click = false;
            //this.LstVAntar.Left = this.LstVMahadasha.Width + 10;
            //this.LstVPratyantar.Left = this.LstVMahadasha.Width + this.LstVAntar.Width + 20;
            //this.LstVSukhsma.Left = this.LstVMahadasha.Width + this.LstVAntar.Width + this.LstVPratyantar.Width + 30;
            //this.LblHindiMahadasha.Left = this.LstVMahadasha.Left;
            //this.LblHindiAntar.Left = this.LstVAntar.Left;
            //this.LblHindiPratyantar.Left = this.LstVPratyantar.Left;
            //this.LblHindiSukshma.Left = this.LstVSukhsma.Left;
            Label label = this.LblSukhsmadasha;
            string[] text = new string[] { this.LstVSukhsma.SelectedItems[0].SubItems[0].Text, " ", this.LstVSukhsma.SelectedItems[0].SubItems[1].Text, "    कार्येश :  ", null, null, null };
            string str = this.LstVSukhsma.SelectedItems[0].SubItems[2].Text;
            char[] chrArray = new char[] { '|' };
            text[4] = str.Split(chrArray)[0];
            text[5] = "   नक्षत्र स्वामी : ";
            string text1 = this.LstVSukhsma.SelectedItems[0].SubItems[2].Text;
            chrArray = new char[] { '|' };
            text[6] = text1.Split(chrArray)[1];
            label.Text = string.Concat(text);
        }

        //private void listsukhsma_MouseDoubleClick(object sender, MouseEventArgs e)
        private void ListCiewSukhsma_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string redSigniPlanetWise = "";
            short planet = (
                from Map in this.planet_list
                where Map.Hindi == this.LstVSukhsma.SelectedItems[0].SubItems[0].Text
                select Map).SingleOrDefault<KPPlanetsVO>().Planet;
            short num = planet;
            short planet1 = (
                from Map in this.planet_list
                where Map.Hindi == this.LstVPratyantar.SelectedItems[0].SubItems[0].Text
                select Map).SingleOrDefault<KPPlanetsVO>().Planet;
            DateTime startDate = (
                from Map in this.main_sukhsmadasha
                where Map.Planet == planet
                select Map).SingleOrDefault<KPDashaVO>().StartDate;
            DateTime endDate = (
                from Map in this.main_sukhsmadasha
                where Map.Planet == planet
                select Map).SingleOrDefault<KPDashaVO>().EndDate;
            ProductSettingsVO productSettingsVO = new ProductSettingsVO()
            {
                Online_Result = this.Online_Result,
                Include = this.ChkSahasaneLogic.Checked,
                Lang = this.CmbLanguage.Text,
                Male = this.male,
                PredFor = 0,
                ShowRef = this.ChkShowRef.Checked,
                ShowUpay = false,
                ShowUpayCode = true,
                Sno = (long)555,
                Category = "all",
                Product = "all",
                Karyesh = true,
                Rotate = Convert.ToInt16(this.CmbRotate.Text)
            };
            planet = (
                from Map in this.kp_chart
                where Map.Planet == planet
                select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
            BestBLL bestBLL = new BestBLL();
            KPPredBLL kPPredBLL = new KPPredBLL();
            redSigniPlanetWise = kPPredBLL.Get_Red_Signi_PlanetWise(this.kp_chart, this.cusp_house, this.prod, this.persKV, num);
            redSigniPlanetWise = string.Concat(redSigniPlanetWise, "-------------------------------- \r\n\r\n");
            redSigniPlanetWise = string.Concat(redSigniPlanetWise, this.kpbl.Get_Dasha_Pred(planet, (
                from Map in this.main_sukhsmadasha
                where Map.Planet == planet
                select Map).SingleOrDefault<KPDashaVO>().Signi_String, startDate, endDate, this.persKV, "life", productSettingsVO, this.kp_chart));
            this.Show_Falla(redSigniPlanetWise);
        }

        //private void lblmaha_Click(object sender, EventArgs e)
        private void LblMaha_Click(object sender, EventArgs e)
        {
        }

        //private void lblantar_Click(object sender, EventArgs e)
        private void LblAntar_Click(object sender, EventArgs e)
        {
        }

        //private void lblparyan_Click(object sender, EventArgs e)
        private void LblParyan_Click(object sender, EventArgs e)
        {
        }

        //private void lblsukhsma_Click(object sender, EventArgs e)
        private void LblSukhsma_Click(object sender, EventArgs e)
        {
        }

        //private void listPratyantar_SelectedIndexChanged(object sender, EventArgs e)
        private void ListViewPratyantar_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        //private void listPratyantar_Click(object sender, EventArgs e)
        private void ListViewPratyantar_Click(object sender, EventArgs e)
        {
            //if (this.antar_dasha_click)
            //{
            //    this.LstVMahadasha.Width = 70;
            //    this.LstVAntar.Width = 470;
            //    this.LstVPratyantar.Width = 470;
            //    this.LstVSukhsma.Width = 70;
            //}
            //else if (!this.sukshma_dasha_click)
            //{
            //    this.LstVMahadasha.Width = 70;
            //    this.LstVAntar.Width = 470;
            //    this.LstVPratyantar.Width = 470;
            //    this.LstVSukhsma.Width = 70;
            //}
            //else
            //{
            //    this.LstVMahadasha.Width = 70;
            //    this.LstVAntar.Width = 70;
            //    this.LstVPratyantar.Width = 470;
            //    this.LstVSukhsma.Width = 470;
            //}
            this.maha_dasha_click = false;
            //this.LstVAntar.Left = this.LstVMahadasha.Width + 10;
            //this.LstVPratyantar.Left = this.LstVMahadasha.Width + this.LstVAntar.Width + 20;
            //this.LstVSukhsma.Left = this.LstVMahadasha.Width + this.LstVAntar.Width + this.LstVPratyantar.Width + 30;
            //this.LblHindiMahadasha.Left = this.LstVMahadasha.Left;
            //this.LblHindiAntar.Left = this.LstVAntar.Left;
            //this.LblHindiPratyantar.Left = this.LstVPratyantar.Left;
            //this.LblHindiSukshma.Left = this.LstVSukhsma.Left;
            this.kpbl = new KPBLL();
            short planet = (
                from Map in this.planet_list
                where Map.Hindi == this.LstVMahadasha.SelectedItems[0].SubItems[0].Text
                select Map).SingleOrDefault<KPPlanetsVO>().Planet;
            DateTime startDate = (
                from Map in this.main_mahadasha
                where Map.Planet == planet
                select Map).SingleOrDefault<KPDashaVO>().StartDate;
            DateTime endDate = (
                from Map in this.main_mahadasha
                where Map.Planet == planet
                select Map).SingleOrDefault<KPDashaVO>().EndDate;
            this.main_antardasha = this.kpbl.Get_Antar_Dasha(startDate, endDate, planet, this.kp_chart, this.ChkSahasaneLogic.Checked);
            short num = (
                from Map in this.planet_list
                where Map.Hindi == this.LstVAntar.SelectedItems[0].SubItems[0].Text
                select Map).SingleOrDefault<KPPlanetsVO>().Planet;
            DateTime dateTime = (
                from Map in this.main_antardasha
                where Map.Planet == num
                select Map).SingleOrDefault<KPDashaVO>().StartDate;
            DateTime endDate1 = (
                from Map in this.main_antardasha
                where Map.Planet == num
                select Map).SingleOrDefault<KPDashaVO>().EndDate;
            this.main_pryaantardasha = this.kpbl.Get_Prayatntar_Dasha(this.main_antardasha, dateTime, endDate1, planet, num, this.kp_chart, this.ChkSahasaneLogic.Checked);
            short planet1 = (
                from Map in this.planet_list
                where Map.Hindi == this.LstVPratyantar.SelectedItems[0].SubItems[0].Text
                select Map).SingleOrDefault<KPPlanetsVO>().Planet;
            DateTime startDate1 = (
                from Map in this.main_pryaantardasha
                where Map.Planet == planet1
                select Map).SingleOrDefault<KPDashaVO>().StartDate;
            DateTime dateTime1 = (
                from Map in this.main_pryaantardasha
                where Map.Planet == planet1
                select Map).SingleOrDefault<KPDashaVO>().EndDate;
            this.main_sukhsmadasha = this.kpbl.Get_Sukhsma_Dasha(this.main_pryaantardasha, startDate1, dateTime1, planet, num, planet1, this.kp_chart, this.ChkSahasaneLogic.Checked);
            this.Gen_SukhsmaDasha(this.main_sukhsmadasha, this.kp_chart);
            this.LblSukhsmadasha.Text = "-";
            this.LblParyan.Text = "-";
            Label label = this.LblParyan;
            string[] text = new string[] { this.LstVPratyantar.SelectedItems[0].SubItems[0].Text, " ", this.LstVPratyantar.SelectedItems[0].SubItems[1].Text, "    कार्येश :  ", null, null, null };
            string str = this.LstVPratyantar.SelectedItems[0].SubItems[2].Text;
            char[] chrArray = new char[] { '|' };
            text[4] = str.Split(chrArray)[0];
            text[5] = "   नक्षत्र स्वामी : ";
            string text1 = this.LstVPratyantar.SelectedItems[0].SubItems[2].Text;
            chrArray = new char[] { '|' };
            text[6] = text1.Split(chrArray)[1];
            label.Text = string.Concat(text);
        }

        //private void listPratyantar_MouseDoubleClick(object sender, MouseEventArgs e)
        private void ListViewPratyantar_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string planetNakPlanetSublordFal = "";
            short planet = (
                from Map in this.planet_list
                where Map.Hindi == this.LstVPratyantar.SelectedItems[0].SubItems[0].Text
                select Map).SingleOrDefault<KPPlanetsVO>().Planet;
            short num = (
                from Map in this.planet_list
                where Map.Hindi == this.LstVAntar.SelectedItems[0].SubItems[0].Text
                select Map).SingleOrDefault<KPPlanetsVO>().Planet;
            short planet1 = (
                from Map in this.planet_list
                where Map.Hindi == this.LstVMahadasha.SelectedItems[0].SubItems[0].Text
                select Map).SingleOrDefault<KPPlanetsVO>().Planet;
            short nakLord = (
                from Map in this.kp_chart
                where Map.Planet == num
                select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
            short nakLord1 = (
                from Map in this.kp_chart
                where Map.Planet == planet1
                select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
            ProductSettingsVO productSettingsVO = new ProductSettingsVO()
            {
                Online_Result = this.Online_Result,
                Include = this.ChkSahasaneLogic.Checked,
                Lang = this.CmbLanguage.Text,
                Male = this.male,
                PredFor = 0,
                ShowRef = this.ChkShowRef.Checked,
                ShowUpay = true,
                ShowUpayCode = true,
                ShowUpayBelow = true
            };
            this.persKV.Paid = true;
            productSettingsVO.Sno = (long)555;
            productSettingsVO.Category = "all";
            productSettingsVO.Product = "all";
            productSettingsVO.Karyesh = true;
            productSettingsVO.Rotate = Convert.ToInt16(this.CmbRotate.Text);
            DateTime startDate = (
                from Map in this.main_pryaantardasha
                where Map.Planet == planet
                select Map).SingleOrDefault<KPDashaVO>().StartDate;
            DateTime endDate = (
                from Map in this.main_pryaantardasha
                where Map.Planet == planet
                select Map).SingleOrDefault<KPDashaVO>().EndDate;
            PredictionBLL predictionBLL = new PredictionBLL();
            short num1 = Convert.ToInt16(predictionBLL.CalculateAgeCorrect(this.persKV.Dob, startDate));
            KPBLL kPBLL = new KPBLL();
            short bhavChalitHouse = 0;
            string str = "";
            short num2 = planet;
            short bhavChalitHouse1 = (
                from Map in this.kp_chart
                where Map.Planet == num2
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            planet = (
                from Map in this.kp_chart
                where Map.Planet == planet
                select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
            bhavChalitHouse = (
                from Map in this.kp_chart
                where Map.Planet == planet
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            string[] signiString = new string[] { (
                from Map in this.main_mahadasha
                where Map.Planet == planet1
                select Map).SingleOrDefault<KPDashaVO>().Signi_String, " ", (
                from Map in this.main_antardasha
                where Map.Planet == num
                select Map).SingleOrDefault<KPDashaVO>().Signi_String, " ", (
                from Map in this.main_pryaantardasha
                where Map.Planet == num2
                select Map).SingleOrDefault<KPDashaVO>().Signi_String };
            str = string.Concat(signiString);
            string str1 = "";
            string signiString1 = (
                from Map in this.main_pryaantardasha
                where Map.Planet == planet
                select Map).SingleOrDefault<KPDashaVO>().Signi_String;
            char[] chrArray = new char[] { ' ' };
            signiString1.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
            string signiString2 = (
                from Map in this.main_antardasha
                where Map.Planet == nakLord
                select Map).SingleOrDefault<KPDashaVO>().Signi_String;
            chrArray = new char[] { ' ' };
            signiString2.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
            string str2 = (
                from Map in this.main_mahadasha
                where Map.Planet == planet1
                select Map).SingleOrDefault<KPDashaVO>().Signi_String;
            chrArray = new char[] { ' ' };
            str2.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
            short nakLord2 = (
                from Map in this.kp_chart
                where Map.Planet == planet
                select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
            short bhavChalitHouse2 = (
                from Map in this.kp_chart
                where Map.Planet == planet
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            short bhavChalitHouse3 = (
                from Map in this.kp_chart
                where Map.Planet == nakLord2
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            str1 = (nakLord2 == planet ? bhavChalitHouse2.ToString() : string.Concat(bhavChalitHouse2.ToString(), " ", bhavChalitHouse3.ToString()));
            if (nakLord2 == planet)
            {
                str1 = string.Concat(str1, " ", this.kpbl.Get_Signi_String_Only_Rashi(planet, this.kp_chart, false));
            }
            KPBLL kPBLL1 = new KPBLL();
            planetNakPlanetSublordFal = kPBLL1.Get_Planet_Nak_Planet_Sublord_Fal(this.persKV, bhavChalitHouse, (
                from Map in this.main_pryaantardasha
                where Map.Planet == num2
                select Map).SingleOrDefault<KPDashaVO>().Signi_String);
            planetNakPlanetSublordFal = string.Concat(planetNakPlanetSublordFal, "################################################### \r\n\r\n");
            planetNakPlanetSublordFal = string.Concat(planetNakPlanetSublordFal, this.kpbl.Get_Planet_Chain_Pred(str, startDate, endDate, this.persKV, "multi", num2, productSettingsVO, num1));
            planetNakPlanetSublordFal = string.Concat(planetNakPlanetSublordFal, "-------------------------------- \r\n\r\n");
            KPBLL kPBLL2 = new KPBLL();
            if (num1 > 16)
            {
                planetNakPlanetSublordFal = string.Concat(planetNakPlanetSublordFal, kPBLL2.Get_Dasha_Pred_Intelli(planet, str1, startDate, endDate, this.persKV, "oldmfal", productSettingsVO, this.kp_chart, num2, bhavChalitHouse1, bhavChalitHouse2));
                planetNakPlanetSublordFal = string.Concat(planetNakPlanetSublordFal, "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ \r\n\r\n");
                if (bhavChalitHouse1 != bhavChalitHouse2)
                {
                    planetNakPlanetSublordFal = string.Concat(planetNakPlanetSublordFal, this.kpbl.Get_Dasha_Pred(num2, bhavChalitHouse1.ToString(), startDate, endDate, this.persKV, "oldmfal", productSettingsVO, this.kp_chart));
                }
                planetNakPlanetSublordFal = string.Concat(planetNakPlanetSublordFal, this.kpbl.Get_Dasha_Pred(planet, str1, startDate, endDate, this.persKV, "oldmfal", productSettingsVO, this.kp_chart));
            }
            else
            {
                planetNakPlanetSublordFal = string.Concat(planetNakPlanetSublordFal, kPBLL2.Get_Dasha_Pred_Intelli(planet, str1, startDate, endDate, this.persKV, "oldcmfal", productSettingsVO, this.kp_chart, num2, bhavChalitHouse1, bhavChalitHouse2));
                planetNakPlanetSublordFal = string.Concat(planetNakPlanetSublordFal, "\r\n\r\n $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ \r\n\r\n");
                if (bhavChalitHouse1 != bhavChalitHouse2)
                {
                    planetNakPlanetSublordFal = string.Concat(planetNakPlanetSublordFal, this.kpbl.Get_Dasha_Pred(num2, bhavChalitHouse1.ToString(), startDate, endDate, this.persKV, "oldcmfal", productSettingsVO, this.kp_chart));
                }
                planetNakPlanetSublordFal = string.Concat(planetNakPlanetSublordFal, this.kpbl.Get_Dasha_Pred(planet, str1, startDate, endDate, this.persKV, "oldcmfal", productSettingsVO, this.kp_chart));
            }
            this.Show_Falla(planetNakPlanetSublordFal);
        }

        //private void listAntar_SelectedIndexChanged(object sender, EventArgs e)
        private void ListViewAntar_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        //private void listAntar_Click(object sender, EventArgs e)
        private void ListViewAntar_Click(object sender, EventArgs e)
        {
            this.antar_dasha_click = true;
            //if (!this.maha_dasha_click)
            //{
            //    this.LstVMahadasha.Width = 70;
            //    this.LstVAntar.Width = 470;
            //    this.LstVPratyantar.Width = 470;
            //    this.LstVSukhsma.Width = 70;
            //}
            //else
            //{
            //    this.LstVMahadasha.Width = 470;
            //    this.LstVAntar.Width = 470;
            //    this.LstVPratyantar.Width = 70;
            //    this.LstVSukhsma.Width = 70;
            //}
            this.sukshma_dasha_click = false;
            //this.LstVAntar.Left = this.LstVMahadasha.Width + 10;
            //this.LstVPratyantar.Left = this.LstVMahadasha.Width + this.LstVAntar.Width + 20;
            //this.LstVSukhsma.Left = this.LstVMahadasha.Width + this.LstVAntar.Width + this.LstVPratyantar.Width + 30;
            //this.LblHindiMahadasha.Left = this.LstVMahadasha.Left;
            //this.LblHindiAntar.Left = this.LstVAntar.Left;
            //this.LblHindiPratyantar.Left = this.LstVPratyantar.Left;
            //this.LblHindiSukshma.Left = this.LstVSukhsma.Left;
            this.kpbl = new KPBLL();
            List<KPDashaVO> kPDashaVOs = new List<KPDashaVO>();
            List<KPDashaVO> prayatntarDasha = new List<KPDashaVO>();
            short planet = (
                from Map in this.planet_list
                where Map.Hindi == this.LstVMahadasha.SelectedItems[0].SubItems[0].Text
                select Map).SingleOrDefault<KPPlanetsVO>().Planet;
            DateTime startDate = (
                from Map in this.main_mahadasha
                where Map.Planet == planet
                select Map).SingleOrDefault<KPDashaVO>().StartDate;
            DateTime endDate = (
                from Map in this.main_mahadasha
                where Map.Planet == planet
                select Map).SingleOrDefault<KPDashaVO>().EndDate;
            kPDashaVOs = this.kpbl.Get_Antar_Dasha(startDate, endDate, planet, this.kp_chart, this.ChkSahasaneLogic.Checked);
            short num = (
                from Map in this.planet_list
                where Map.Hindi == this.LstVAntar.SelectedItems[0].SubItems[0].Text
                select Map).SingleOrDefault<KPPlanetsVO>().Planet;
            DateTime dateTime = (
                from Map in kPDashaVOs
                where Map.Planet == num
                select Map).SingleOrDefault<KPDashaVO>().StartDate;
            DateTime endDate1 = (
                from Map in kPDashaVOs
                where Map.Planet == num
                select Map).SingleOrDefault<KPDashaVO>().EndDate;
            prayatntarDasha = this.kpbl.Get_Prayatntar_Dasha(kPDashaVOs, dateTime, endDate1, planet, num, this.kp_chart, this.ChkSahasaneLogic.Checked);
            this.Gen_PryantarDasha(prayatntarDasha, this.kp_chart);
            this.LstVSukhsma.Items.Clear();
            this.LblParyan.Text = "-";
            this.LblSukhsmadasha.Text = "-";
            Label label = this.LblAntar;
            string[] text = new string[] { this.LstVAntar.SelectedItems[0].SubItems[0].Text, " ", this.LstVAntar.SelectedItems[0].SubItems[1].Text, "    कार्येश :  ", null, null, null };
            string str = this.LstVAntar.SelectedItems[0].SubItems[2].Text;
            char[] chrArray = new char[] { '|' };
            text[4] = str.Split(chrArray)[0];
            text[5] = "   नक्षत्र स्वामी : ";
            string text1 = this.LstVAntar.SelectedItems[0].SubItems[2].Text;
            chrArray = new char[] { '|' };
            text[6] = text1.Split(chrArray)[1];
            label.Text = string.Concat(text);
        }

        //private void listAntar_MouseDoubleClick(object sender, MouseEventArgs e)
        private void ListViewAntar_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string planetNakPlanetSublordFal = "";
            short planet = (
                from Map in this.planet_list
                where Map.Hindi == this.LstVMahadasha.SelectedItems[0].SubItems[0].Text
                select Map).SingleOrDefault<KPPlanetsVO>().Planet;
            short nakLord = (
                from Map in this.planet_list
                where Map.Hindi == this.LstVAntar.SelectedItems[0].SubItems[0].Text
                select Map).SingleOrDefault<KPPlanetsVO>().Planet;
            ProductSettingsVO productSettingsVO = new ProductSettingsVO()
            {
                Online_Result = this.Online_Result,
                Include = this.ChkSahasaneLogic.Checked,
                Lang = this.CmbLanguage.Text,
                Male = this.male,
                PredFor = 0,
                ShowRef = this.ChkShowRef.Checked,
                Sno = (long)555,
                Category = "all",
                Product = "all",
                Karyesh = true,
                Rotate = Convert.ToInt16(this.CmbRotate.Text),
                ShowUpay = true,
                ShowUpayCode = true
            };
            this.persKV.Paid = true;
            productSettingsVO.ShowUpayBelow = true;
            productSettingsVO.Paid = true;
            DateTime startDate = (
                from Map in this.main_antardasha
                where Map.Planet == nakLord
                select Map).SingleOrDefault<KPDashaVO>().StartDate;
            DateTime endDate = (
                from Map in this.main_antardasha
                where Map.Planet == nakLord
                select Map).SingleOrDefault<KPDashaVO>().EndDate;
            short num = nakLord;
            short bhavChalitHouse = (
                from Map in this.kp_chart
                where Map.Planet == num
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            PredictionBLL predictionBLL = new PredictionBLL();
            short num1 = Convert.ToInt16(predictionBLL.CalculateAgeCorrect(this.persKV.Dob, startDate));
            nakLord = (
                from Map in this.kp_chart
                where Map.Planet == nakLord
                select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
            short bhavChalitHouse1 = 0;
            string str = "";
            short num2 = nakLord;
            short nakLord1 = (
                from Map in this.kp_chart
                where Map.Planet == planet
                select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
            bhavChalitHouse1 = (
                from Map in this.kp_chart
                where Map.Planet == num2
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            str = string.Concat((
                from Map in this.main_mahadasha
                where Map.Planet == planet
                select Map).SingleOrDefault<KPDashaVO>().Signi_String, " ", (
                from Map in this.main_antardasha
                where Map.Planet == num
                select Map).SingleOrDefault<KPDashaVO>().Signi_String);
            string str1 = "";
            string signiStringWithoutNakRashi = this.kpbl.Get_Signi_String_Without_NakRashi(nakLord, this.kp_chart, this.ChkSahasaneLogic.Checked);
            char[] chrArray = new char[] { ' ' };
            signiStringWithoutNakRashi.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
            string signiStringWithoutNakRashi1 = this.kpbl.Get_Signi_String_Without_NakRashi(planet, this.kp_chart, this.ChkSahasaneLogic.Checked);
            chrArray = new char[] { ' ' };
            signiStringWithoutNakRashi1.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
            KPBLL kPBLL = new KPBLL();
            planetNakPlanetSublordFal = kPBLL.Get_Planet_Nak_Planet_Sublord_Fal(this.persKV, bhavChalitHouse1, (
                from Map in this.main_antardasha
                where Map.Planet == num
                select Map).SingleOrDefault<KPDashaVO>().Signi_String);
            planetNakPlanetSublordFal = string.Concat(planetNakPlanetSublordFal, "################################################### \r\n\r\n");
            planetNakPlanetSublordFal = string.Concat(planetNakPlanetSublordFal, this.kpbl.Get_Planet_Chain_Pred(str, startDate, endDate, this.persKV, "multi", num, productSettingsVO, num1));
            planetNakPlanetSublordFal = string.Concat(planetNakPlanetSublordFal, "-------------------------------- \r\n\r\n");
            short nakLord2 = (
                from Map in this.kp_chart
                where Map.Planet == num2
                select Map).SingleOrDefault<KPPlanetMappingVO>().Nak_Lord;
            short bhavChalitHouse2 = (
                from Map in this.kp_chart
                where Map.Planet == num2
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            short bhavChalitHouse3 = (
                from Map in this.kp_chart
                where Map.Planet == nakLord2
                select Map).SingleOrDefault<KPPlanetMappingVO>().Bhav_Chalit_House;
            str1 = (nakLord2 == num2 ? bhavChalitHouse2.ToString() : string.Concat(bhavChalitHouse2.ToString(), " ", bhavChalitHouse3.ToString()));
            if (nakLord2 == num2)
            {
                str1 = string.Concat(str1, " ", this.kpbl.Get_Signi_String_Only_Rashi(num2, this.kp_chart, false));
            }
            KPBLL kPBLL1 = new KPBLL();
            if (num1 > 16)
            {
                planetNakPlanetSublordFal = string.Concat(planetNakPlanetSublordFal, kPBLL1.Get_Dasha_Pred_Intelli(nakLord, str1, startDate, endDate, this.persKV, "oldvfal", productSettingsVO, this.kp_chart, num, bhavChalitHouse, bhavChalitHouse2));
                planetNakPlanetSublordFal = string.Concat(planetNakPlanetSublordFal, "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ \r\n\r\n");
                if (bhavChalitHouse != bhavChalitHouse2)
                {
                    planetNakPlanetSublordFal = string.Concat(planetNakPlanetSublordFal, this.kpbl.Get_Dasha_Pred(num, bhavChalitHouse.ToString(), startDate, endDate, this.persKV, "oldvfal", productSettingsVO, this.kp_chart));
                }
                planetNakPlanetSublordFal = string.Concat(planetNakPlanetSublordFal, this.kpbl.Get_Dasha_Pred(nakLord, str1, startDate, endDate, this.persKV, "oldvfal", productSettingsVO, this.kp_chart));
            }
            else
            {
                planetNakPlanetSublordFal = string.Concat(planetNakPlanetSublordFal, kPBLL1.Get_Dasha_Pred_Intelli(nakLord, str1, startDate, endDate, this.persKV, "oldcvfal", productSettingsVO, this.kp_chart, num, bhavChalitHouse, bhavChalitHouse2));
                planetNakPlanetSublordFal = string.Concat(planetNakPlanetSublordFal, "$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ \r\n\r\n");
                if (bhavChalitHouse != bhavChalitHouse2)
                {
                    planetNakPlanetSublordFal = string.Concat(planetNakPlanetSublordFal, this.kpbl.Get_Dasha_Pred(num, bhavChalitHouse.ToString(), startDate, endDate, this.persKV, "oldcvfal", productSettingsVO, this.kp_chart));
                }
                planetNakPlanetSublordFal = string.Concat(planetNakPlanetSublordFal, this.kpbl.Get_Dasha_Pred(nakLord, str1, startDate, endDate, this.persKV, "oldcvfal", productSettingsVO, this.kp_chart));
            }
            this.Show_Falla(planetNakPlanetSublordFal);
        }

        //private void LstVMahadasha_SelectedIndexChanged(object sender, EventArgs e)
        private void ListViewMahadasha_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        //private void LstVMahadasha_Click(object sender, EventArgs e)
        private void ListViewMahadasha_Click(object sender, EventArgs e)
        {
            this.maha_dasha_click = true;
            this.sukshma_dasha_click = false;
            //this.LstVMahadasha.Width = 440;
            //this.LstVAntar.Width = 440;
            //this.LstVPratyantar.Width = 75;
            //this.LstVSukhsma.Width = 75;
            this.LstVYears35.Items.Clear();
            //this.LstVAntar.Left = this.LstVMahadasha.Width + 20;
            //this.LstVPratyantar.Left = this.LstVMahadasha.Width + this.LstVAntar.Width + 20;
            //this.LstVSukhsma.Left = this.LstVMahadasha.Width + this.LstVAntar.Width + this.LstVPratyantar.Width + 30;
            //this.LblHindiMahadasha.Left = this.LstVMahadasha.Left;
            //this.LblHindiAntar.Left = this.LstVAntar.Left;
            //this.LblHindiPratyantar.Left = this.LstVPratyantar.Left;
            //this.LblHindiSukshma.Left = this.LstVSukhsma.Left;
            this.kpbl = new KPBLL();
            short planet = (
                from Map in this.planet_list
                where Map.Hindi == this.LstVMahadasha.SelectedItems[0].SubItems[0].Text
                select Map).SingleOrDefault<KPPlanetsVO>().Planet;
            DateTime startDate = (
                from Map in this.main_mahadasha
                where Map.Planet == planet
                select Map).SingleOrDefault<KPDashaVO>().StartDate;
            DateTime endDate = (
                from Map in this.main_mahadasha
                where Map.Planet == planet
                select Map).SingleOrDefault<KPDashaVO>().EndDate;
            this.main_antardasha = this.kpbl.Get_Antar_Dasha(startDate, endDate, planet, this.kp_chart, this.ChkSahasaneLogic.Checked);
            if (!this.Chk35Sala.Checked)
            {
                this.Gen_AntarDasha(this.main_antardasha, this.kp_chart);
            }
            this.LstVPratyantar.Items.Clear();
            this.LstVSukhsma.Items.Clear();
            this.LblParyan.Text = "-";
            this.LblAntar.Text = "-";
            this.LblSukhsmadasha.Text = "-";
            Label label = this.LblMahadasha;
            string[] text = new string[] { this.LstVMahadasha.SelectedItems[0].SubItems[0].Text, " ", this.LstVMahadasha.SelectedItems[0].SubItems[1].Text, "    कार्येश :  ", null, null, null };
            string str = this.LstVMahadasha.SelectedItems[0].SubItems[2].Text;
            char[] chrArray = new char[] { '|' };
            text[4] = str.Split(chrArray)[0];
            text[5] = "   नक्षत्र स्वामी : ";
            string text1 = this.LstVMahadasha.SelectedItems[0].SubItems[2].Text;
            chrArray = new char[] { '|' };
            text[6] = text1.Split(chrArray)[1];
            label.Text = string.Concat(text);
            PredictionBLL predictionBLL = new PredictionBLL();
            if (this.Chk35Sala.Checked)
            {
                List<KPDashaVO> list35Sala = predictionBLL.Get_List_35_Sala(this.Online_Result, this.persKV, startDate, endDate);
                this.LstVYears35.Visible = true;
                this.LstVYears35.Items.Clear();
                foreach (KPDashaVO kPDashaVO in list35Sala)
                {
                    text = new string[5];
                    DateTime dateTime = kPDashaVO.StartDate;
                    text[0] = dateTime.ToString("dd");
                    text[1] = " ";
                    dateTime = kPDashaVO.StartDate;
                    text[2] = predictionBLL.GetCodeLang(string.Concat("M", dateTime.ToString("%M")), this.persKV.Language, this.persKV.Paid, true);
                    text[3] = " ";
                    dateTime = kPDashaVO.StartDate;
                    text[4] = dateTime.ToString("yyyy");
                    string str1 = string.Concat(text);
                    text = new string[5];
                    dateTime = kPDashaVO.EndDate;
                    text[0] = dateTime.ToString("dd");
                    text[1] = " ";
                    dateTime = kPDashaVO.EndDate;
                    text[2] = predictionBLL.GetCodeLang(string.Concat("M", dateTime.ToString("%M")), this.persKV.Language, this.persKV.Paid, true);
                    text[3] = " ";
                    dateTime = kPDashaVO.EndDate;
                    text[4] = dateTime.ToString("yyyy");
                    string str2 = string.Concat(text);
                    this.LstVYears35.Items.Add((
                        from Map in this.planet_list
                        where Map.Planet == kPDashaVO.Planet
                        select Map).FirstOrDefault<KPPlanetsVO>().Hindi).SubItems.Add(kPDashaVO.Duration);
                    this.LstVYears35.Items[this.LstVYears35.Items.Count - 1].SubItems.Add(string.Concat(str1, " - ", str2));
                    this.LstVYears35.Items[this.LstVYears35.Items.Count - 1].SubItems.Add(kPDashaVO.Nak_Signi_String);
                }
                this.LstVYears35.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                this.LstVYears35.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        //private void LstVMahadasha_MouseDoubleClick(object sender, MouseEventArgs e)
        private void ListViewMahadasha_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.TxtBrief.Text = "";
            PredictionBLL predictionBLL = new PredictionBLL();
            short planet = (
                from Map in this.planet_list
                where Map.Hindi == this.LstVMahadasha.SelectedItems[0].SubItems[0].Text
                select Map).SingleOrDefault<KPPlanetsVO>().Planet;
            this.prod.ShowUpay = true;
            this.prod.ShowUpayCode = true;
            this.persKV.Paid = true;
            this.prod.ShowUpayBelow = true;
            this.prod.Paid = true;
            string falDoubleMahadasha = this.kpbl.Get_Fal_Double_Mahadasha(planet, this.persKV, this.Online_Result, this.prod);
            this.TxtBrief.Text = falDoubleMahadasha;
            this.Show_Falla(this.TxtBrief.Text);
        }

        //private void groupBox1_Enter(object sender, EventArgs e)
        private void GroupBoxPeriod_Enter(object sender, EventArgs e)
        {
        }

        //private void button8_Click(object sender, EventArgs e)
        private void BtnShow_TabDateFinder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.CmbBOccassion.Text))
            {
                MessageBox.Show("Please select an occassion.", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Application.UseWaitCursor = true;
            List<KPDashaVO> kPDashaVOs = new List<KPDashaVO>();
            string str = "";
            string datesChain = "";
            short num = 0;
            this.txtdatelist.Text = "";
            if (this.radiomaha.Checked)
            {
                num = 1;
            }
            if (this.radioantar.Checked)
            {
                num = 2;
            }
            if (this.radiopryantar.Checked)
            {
                num = 3;
            }

            string text = this.CmbBOccassion.Text;

            char[] chrArray = new char[] { '-' };
            str = text.Split(chrArray, StringSplitOptions.RemoveEmptyEntries)[1];
            string text1 = this.CmbBOccassion.Text;
            chrArray = new char[] { '-' };
            string str1 = text1.Split(chrArray, StringSplitOptions.RemoveEmptyEntries)[2];
            chrArray = new char[] { '~' };
            short num1 = Convert.ToInt16(str1.Split(chrArray, StringSplitOptions.RemoveEmptyEntries)[0]);
            string text2 = this.CmbBOccassion.Text;
            chrArray = new char[] { '-' };
            string str2 = text2.Split(chrArray, StringSplitOptions.RemoveEmptyEntries)[2];
            chrArray = new char[] { '~' };
            short num2 = Convert.ToInt16(str2.Split(chrArray, StringSplitOptions.RemoveEmptyEntries)[1]);
            datesChain = this.kpbl.Get_Dates_Chain(this.kp_chart, this.cusp_house, this.persKV, str, this.prod, this.radionakswami.Checked, this.radioboth.Checked, this.ChkSahasane.Checked, num1, num2, this.checkfullmatch.Checked, num);
            this.txtdatelist.Text = datesChain;
            Application.UseWaitCursor = false;
        }

        //private void combooccassion_SelectedIndexChanged(object sender, EventArgs e)
        private void ComboOccassion_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        //private void listyears35_SelectedIndexChanged(object sender, EventArgs e)
        private void ListViewYears35_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        //private void tabPage8_Click(object sender, EventArgs e)
        private void TabKundaliDates_Click(object sender, EventArgs e)
        {
        }

        //private void button9_Click(object sender, EventArgs e)
        private void BtnShow_TabKundaliDates_Click(object sender, EventArgs e)
        {
            if ((this.full_lat.Length <= 0 ? false : this.full_lon.Length > 0))
            {
                Application.UseWaitCursor = true;
                string str = this.full_lon.Replace(":", ".");
                string str1 = this.full_lat.Replace(":", ".");
                this.txtbestdate.Text = "";
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
                BestBLL bestBLL = new BestBLL();
                short num = 0;
                DateTime date = this.pick_start_date.Value.Date;
                DateTime value = this.pick_start_time.Value;
                DateTime timeOfDay = date + value.TimeOfDay;
                DateTime dateTime = this.pick_end_date.Value.Date;
                value = this.pick_end_time.Value;
                DateTime timeOfDay1 = dateTime + value.TimeOfDay;
                long num1 = (long)0;
                short num2 = 0;
                short num3 = 0;
                if (this.comborating.Text == "Good")
                {
                    num2 = 1;
                }
                if (this.comborating.Text == "Best")
                {
                    num2 = 2;
                }
                if (this.comborating.Text == "Excellent")
                {
                    num2 = 3;
                }
                if (this.radioRedBook.Checked)
                {
                    num3 = 1;
                }
                if (this.radiokp.Checked)
                {
                    num3 = 2;
                }
                string str5 = "";
                string str6 = "";
                while (true)
                {
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
                    fullTimeCorr[10] = str;
                    fullTimeCorr[11] = ",";
                    fullTimeCorr[12] = str1;
                    fullTimeCorr[13] = ",";
                    fullTimeCorr[14] = str2;
                    fullTimeCorr[15] = ",";
                    fullTimeCorr[16] = this.ayan;
                    fullTimeCorr[17] = ",";
                    fullTimeCorr[18] = this.full_time_corr;
                    str3 = string.Concat(fullTimeCorr);
                    str4 = kundliBLL.Gen_Kunda(str3, 500f, 1);
                    char[] chrArray = new char[] { '-' };
                    str5 = str4.Split(chrArray)[0];
                    if (num3 == 1)
                    {
                        if (str5 != str6)
                        {
                            if (bestBLL.isBestKundali(str4, num2, num3))
                            {
                                TextBox textBox = this.txtbestdate;
                                textBox.Text = string.Concat(textBox.Text, timeOfDay.ToString(), "\r\n\r\n");
                            }
                            num1 += (long)1;
                        }
                    }
                    if (num3 == 2)
                    {
                        if (bestBLL.isBestKundali(str4, num2, num3))
                        {
                            TextBox textBox1 = this.txtbestdate;
                            textBox1.Text = string.Concat(textBox1.Text, timeOfDay.ToString(), "\r\n\r\n");
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
                    if (timeOfDay >= timeOfDay1)
                    {
                        break;
                    }
                }
                this.lblkundli_nos.Text = string.Concat(num1.ToString(), " Kundalis processed.");
                Application.UseWaitCursor = false;
            }
            else
            {
                MessageBox.Show("Please choose City from list.");
                this.TxtBirthplace.SelectAll();
                this.TxtBirthplace.Focus();
            }
        }

        //private void button6_Click(object sender, EventArgs e)
        private void BtnClose_GroupPrediction_Click(object sender, EventArgs e)
        {
            this.TxtBrief.Text = "";
            this.GrpBPrediction.Visible = false;
            Toggle_TabControl_Main();
        }

        private void CmbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void FrmNewKP_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.Padding = new Padding(8, 8, 8, 8);
                //PnlHeader.Padding = new Padding(0, 2, 2, 0);
                //case FormWindowState.Normal:
                //    //if (Padding.Top != 2) Padding = new Padding(2);
                //    break;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            LblTimeZone.Text = TimeZoneInfo.Local.DisplayName;
            {
                int x = (PnlFooter.Width / 2) - (LblTimeZone.Width / 2);
                int y = (PnlFooter.Height / 2) - (LblTimeZone.Height / 2);
                if (LblTimeZone.Location.X != x || LblTimeZone.Location.Y != y)
                    LblTimeZone.Location = new Point(x, y);
            }
        }

        private void Pick_end_date_ValueChanged(object sender, EventArgs e)
        {

        }

        private Bitmap printBitmap;

        private void IBtnPrint_GBP_Click(object sender, EventArgs e)
        {
            WebBrowser_GBP.Document.Title = "Prediction";
            WebBrowser_GBP.Print();
        }
        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {

        }

        private void LblHindiPratyantar_Click(object sender, EventArgs e)
        {

        }

        private void NumUDVYears_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
