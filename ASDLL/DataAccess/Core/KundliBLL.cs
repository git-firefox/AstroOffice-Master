using Kunda;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using AstroShared.Models;

namespace ASDLL.DataAccess.Core
{
    public class KundliBLL
    {
        public KundliBLL()
        {
        }

        public long AddKundli(KundliVO kv)
        {
            return (new KundliDAO()).AddKundli(kv);
        }

        public void AddKundliMapping(List<KundliMappingVO> kml)
        {
            foreach (KundliMappingVO kundliMappingVO in kml)
            {
                (new KundliDAO()).AddKundliMapping(kundliMappingVO);
            }
        }

        public string BirthTimeCorrection(string? stt)
        {
            if (string.IsNullOrEmpty(stt))
            {
                return "";
            }
            int day;
            char[] chrArray = new char[] { ',' };
            string[] strArrays = stt.Split(chrArray);
            string str = strArrays[0];
            chrArray = new char[] { '/' };
            string[] strArrays1 = str.Split(chrArray);
            string str1 = strArrays[1];
            chrArray = new char[] { ':' };
            string[] strArrays2 = str1.Split(chrArray);
            DateTime dateTime = new DateTime(Convert.ToInt16(strArrays1[2]), Convert.ToInt16(strArrays1[1]), Convert.ToInt16(strArrays1[0]), Convert.ToInt16(strArrays2[0]), Convert.ToInt16(strArrays2[1]), 0);
            double num = 0;
            TimeCorrection timeCorrection = new TimeCorrection();
            string str2 = "";
            string timeCorrectionCode = "";
            string str3 = strArrays[6];
            string[] strArrays3 = new string[] { strArrays1[0], "/", strArrays1[1], "/", strArrays1[2] };
            timeCorrectionCode = timeCorrection.GetTimeCorrectionCode(str3, string.Concat(strArrays3), ref str2);
            string str4 = timeCorrectionCode;
            if (str4 != null)
            {
                switch (str4)
                {
                    case "S":
                        {
                            num = 0;
                            break;
                        }
                    case "D":
                        {
                            num = -1;
                            break;
                        }
                    case "T":
                        {
                            num = -2;
                            break;
                        }
                    case "H":
                        {
                            num = -0.5;
                            break;
                        }
                    case "L":
                        {
                            num = 0;
                            break;
                        }
                    case "W":
                        {
                            num = -1;
                            break;
                        }
                    default:
                        {
                            goto Label0;
                        }
                }
            }
            else
            {
                goto Label0;
            }
            Label1:
            dateTime = dateTime.AddHours(num);
            object[] year = new object[17];
            day = dateTime.Day;
            year[0] = day.ToString("00");
            year[1] = "/";
            day = dateTime.Month;
            year[2] = day.ToString("00");
            year[3] = "/";
            year[4] = dateTime.Year;
            year[5] = ",";
            day = dateTime.Hour;
            year[6] = day.ToString("00");
            year[7] = ":";
            day = dateTime.Minute;
            year[8] = day.ToString("00");
            year[9] = ",";
            year[10] = strArrays[2];
            year[11] = ",";
            year[12] = strArrays[3];
            year[13] = ",";
            year[14] = strArrays[4];
            year[15] = ",";
            year[16] = strArrays[5];
            return string.Concat(year);
            Label0:
            num = 0;
            goto Label1;
        }

        public string Dasha_DecimalToDMS(double coord)
        {
            string str;
            int num = (int)Math.Round(coord * 3600);
            int num1 = num / 3600;
            num = Math.Abs(num % 3600);
            int num2 = num / 60;
            num %= 60;
            str = (num2.ToString().Length != 1 ? string.Concat(num1, ":", num2) : string.Concat(num1, ":0", num2));
            str = (num.ToString().Length != 1 ? string.Concat(str, ":", num) : string.Concat(str, ":0", num));
            return str;
        }

        public string DecimalToDMS(double coord)
        {
            string str;
            int num = (int)Math.Round(coord * 3600);
            int num1 = num / 3600;
            num = Math.Abs(num % 3600);
            int num2 = num / 60;
            num %= 60;
            str = (num2.ToString().Length != 1 ? string.Concat(num1, ":", num2) : string.Concat(num1, ":0", num2));
            return str;
        }

        public double DMStoDecimal(double degrees, double minutes, double seconds)
        {
            double num = degrees + minutes / 60 + seconds / 3600;
            return num;
        }

        public PlanetVO findplanet(int pid)
        {
            List<PlanetVO> allPlanets = (new PlanetBLL()).GetAllPlanets();
            PlanetVO planetVO = allPlanets.Find((PlanetVO p) => p.Sno == pid);
            return planetVO;
        }

        public Bitmap Gen_Image(string lagna, List<KPPlanetMappingVO> lkmv, string Online_Result, bool bhav_chalit, short Kund_Size, string lang)
        {
            List<KPPlanetsVO> kPPlanetsVOs = (new KPBLL()).Fill_Planets();
            Kundali kundali = new Kundali();
            List<Kunda.KundliMappingVO> kundliMappingVOs = new List<Kunda.KundliMappingVO>();
            foreach (KPPlanetMappingVO kPPlanetMappingVO in lkmv)
            {
                Kunda.KundliMappingVO kundliMappingVO = new Kunda.KundliMappingVO();
                //kundliMappingVO.set_Degree(kPPlanetMappingVO.DegreePlanet);
                //kundliMappingVO.set_House(kPPlanetMappingVO.House);
                //kundliMappingVO.set_IsBad(kPPlanetMappingVO.isbad);
                //kundliMappingVO.set_Planet(kPPlanetMappingVO.Planet);
                //kundliMappingVO.set_PlanetName(kPPlanetsVOs[kPPlanetMappingVO.Planet - 1].Roman);
                //kundliMappingVO.set_PlanetNameEnglish(kPPlanetsVOs[kPPlanetMappingVO.Planet - 1].English);
                //kundliMappingVO.set_PlanetNameHindi(kPPlanetsVOs[kPPlanetMappingVO.Planet - 1].Hindi);
                //kundliMappingVO.set_Rashi(kPPlanetMappingVO.Rashi);
                kundliMappingVO.Degree = kPPlanetMappingVO.DegreePlanet;
                kundliMappingVO.House = kPPlanetMappingVO.House;
                kundliMappingVO.IsBad = kPPlanetMappingVO.isbad;
                kundliMappingVO.Planet = kPPlanetMappingVO.Planet;
                kundliMappingVO.PlanetName = kPPlanetsVOs[kPPlanetMappingVO.Planet - 1].Roman;
                kundliMappingVO.PlanetNameEnglish = kPPlanetsVOs[kPPlanetMappingVO.Planet - 1].English;
                kundliMappingVO.PlanetNameHindi = kPPlanetsVOs[kPPlanetMappingVO.Planet - 1].Hindi;
                kundliMappingVO.Rashi = kPPlanetMappingVO.Rashi;
                kundliMappingVOs.Add(kundliMappingVO);
            }
            Bitmap bitmap = kundali.KunImage(lagna, kundliMappingVOs, Online_Result, bhav_chalit, Kund_Size, lang);
            return bitmap;
        }

        public Bitmap Gen_Image(string lagna, List<KundliMappingVO> lkmv, string Online_Result, bool bhav_chalit, short Kund_Size, string lang)
        {
            Kundali kundali = new Kundali();
            List<Kunda.KundliMappingVO> kundliMappingVOs = new List<Kunda.KundliMappingVO>();
            foreach (KundliMappingVO kundliMappingVO in lkmv)
            {
                Kunda.KundliMappingVO kundliMappingVO1 = new Kunda.KundliMappingVO();
                //kundliMappingVO1.set_Degree(kundliMappingVO.Degree);
                //kundliMappingVO1.set_House(kundliMappingVO.House);
                //kundliMappingVO1.set_IsBad(kundliMappingVO.IsBad);
                //kundliMappingVO1.set_Planet(kundliMappingVO.Planet);
                //kundliMappingVO1.set_PlanetName(kundliMappingVO.PlanetName);
                //kundliMappingVO1.set_PlanetNameEnglish(kundliMappingVO.PlanetNameEnglish);
                //kundliMappingVO1.set_PlanetNameHindi(kundliMappingVO.PlanetNameHindi);
                //kundliMappingVO1.set_Rashi(kundliMappingVO.Rashi);

                kundliMappingVO1.Degree = kundliMappingVO.Degree;
                kundliMappingVO1.House = kundliMappingVO.House;
                kundliMappingVO1.IsBad = kundliMappingVO.IsBad;
                kundliMappingVO1.Planet = kundliMappingVO.Planet;
                kundliMappingVO1.PlanetName = kundliMappingVO.PlanetName;
                kundliMappingVO1.PlanetNameEnglish = kundliMappingVO.PlanetNameEnglish;
                kundliMappingVO1.PlanetNameHindi = kundliMappingVO.PlanetNameHindi;
                kundliMappingVO1.Rashi = kundliMappingVO.Rashi;

                kundliMappingVOs.Add(kundliMappingVO1);
            }
            Bitmap bitmap = kundali.KunImage(lagna, kundliMappingVOs, Online_Result, bhav_chalit, Kund_Size, lang);
            return bitmap;
        }

        public string Gen_Kunda(string? detail, float lagan)
        {
            Kundali kundali = new Kundali();
            return kundali.Gen_Kundali(this.BirthTimeCorrection(detail), lagan);
        }

        public string Gen_Kunda(string? detail, float lagan, short rotate)
        {
            short i;
            string str = "";
            Kundali kundali = new Kundali();
            str = kundali.Gen_Kundali(this.BirthTimeCorrection(detail), 500f);
            if (rotate > 1)
            {
                rotate = Convert.ToInt16((int)(rotate - Convert.ToInt16(1)));
                char[] chrArray = new char[] { '-' };
                string[] strArrays = str.Split(chrArray);
                PredictionBLL predictionBLL = new PredictionBLL();
                string str1 = strArrays[0];
                chrArray = new char[] { '#' };
                string[] strArrays1 = str1.Split(chrArray);
                string str2 = strArrays[1];
                chrArray = new char[] { '#' };
                string[] strArrays2 = str2.Split(chrArray);
                string str3 = strArrays[2];
                chrArray = new char[] { '#' };
                string[] strArrays3 = str3.Split(chrArray);
                string str4 = strArrays[3];
                chrArray = new char[] { '#' };
                string[] strArrays4 = str4.Split(chrArray);
                short num = 0;
                string str5 = "";
                string str6 = "";
                string str7 = "";
                short num1 = 0;
                for (i = 0; i < strArrays1.Count<string>(); i = (short)(i + 1))
                {
                    num1 = Convert.ToInt16((int)(Convert.ToInt16(strArrays1[i]) - rotate));
                    if (num1 <= 0)
                    {
                        num1 = Convert.ToInt16(12 - Math.Abs(num1));
                    }
                    if (num1 > 12)
                    {
                        num1 = Convert.ToInt16(num1 - 12);
                    }
                    if ((i != 0 ? false : lagan != 500f))
                    {
                        strArrays1[0] = lagan.ToString();
                        num1 = Convert.ToInt16(lagan);
                    }
                    str5 = string.Concat(str5, num1.ToString(), "#");
                    if (i == 2)
                    {
                        chrArray = new char[] { '#' };
                        num = Convert.ToInt16(Convert.ToInt16(strArrays1[i]) + (rotate - 1) + Convert.ToInt16(str5.Split(chrArray)[0]));
                        num = (short)(num - 1);
                        if (num > 12)
                        {
                            num = Convert.ToInt16(num - 12);
                        }
                    }
                    if (num > 12)
                    {
                        num = Convert.ToInt16(num - 12);
                    }
                }
                for (i = 0; i < strArrays2.Count<string>(); i = (short)(i + 1))
                {
                    num1 = Convert.ToInt16((int)(Convert.ToInt16(strArrays2[i]) - rotate));
                    if (num1 <= 0)
                    {
                        num1 = Convert.ToInt16(12 - Math.Abs(num1));
                    }
                    if (num1 > 12)
                    {
                        num1 = Convert.ToInt16(num1 - 12);
                    }
                    if ((i != 0 ? false : lagan != 500f))
                    {
                        strArrays2[0] = lagan.ToString();
                        num1 = Convert.ToInt16(lagan);
                    }
                    str6 = string.Concat(str6, num1.ToString(), "#");
                }
                for (i = 0; i < strArrays3.Count<string>(); i = (short)(i + 1))
                {
                    num1 = Convert.ToInt16((int)(Convert.ToInt16(strArrays1[0]) + i));
                    if (num1 > 12)
                    {
                        num1 = Convert.ToInt16(num1 - 12);
                    }
                    if ((i != 0 ? false : lagan != 500f))
                    {
                        strArrays3[0] = lagan.ToString();
                        num1 = Convert.ToInt16(lagan);
                    }
                    str7 = string.Concat(str7, num1.ToString(), "#");
                }
                chrArray = new char[] { '#' };
                str5 = str5.TrimEnd(chrArray);
                chrArray = new char[] { '#' };
                str6 = str6.TrimEnd(chrArray);
                chrArray = new char[] { '#' };
                str7 = str7.TrimEnd(chrArray);
                string[] strArrays5 = new string[] { num.ToString(), "#", strArrays4[1], "#", strArrays4[2] };
                string str8 = string.Concat(strArrays5);
                strArrays5 = new string[] { str5, "-", str6, "-", str7, "-", str8, "-", strArrays[4], "-", strArrays[5] };
                str = string.Concat(strArrays5);
            }
            return str;
        }

        public List<RulesVO> GetAdvancePredictions(List<KundliMappingVO> lkmv, int planet, int yog)
        {
            List<RulesVO> rulesVOs = new List<RulesVO>();
            KundliDAO kundliDAO = new KundliDAO();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<root>");
            foreach (KundliMappingVO kundliMappingVO in lkmv)
            {
                stringBuilder.Append("<mappings>");
                int house = kundliMappingVO.House;
                stringBuilder.AppendFormat("<house>{0}</house>", house.ToString());
                house = kundliMappingVO.Planet;
                stringBuilder.AppendFormat("<planet>{0}</planet>", house.ToString());
                stringBuilder.Append("</mappings>");
            }
            stringBuilder.Append("</root>");
            foreach (DataRow row in kundliDAO.GetAdvancePredictions(stringBuilder.ToString(), planet, yog).Rows)
            {
                RulesVO rulesVO = new RulesVO()
                {
                    Sno = (long)Convert.ToInt32(row["sno"].ToString()),
                    Isbad = Convert.ToBoolean(row["isbad"]),
                    Ruleformula = row["ruleformula"].ToString(),
                    Actualformula = row["actualformula"].ToString(),
                    RuleType = row["ruletype"].ToString(),
                    Priority = Convert.ToInt16(row["priority"].ToString()),
                    Reference = row["reference"].ToString(),
                    RefNo = Convert.ToInt64(row["refno"].ToString()),
                    Sno_Orgin = Convert.ToInt64(row["sno"].ToString()),
                    Rule_Nature = Convert.ToInt16(row["rulenature"].ToString()),
                    Upay = Convert.ToInt32(row["upay"].ToString()),
                    VfalYears = row["vfalyears"].ToString(),
                    Confidence = Convert.ToBoolean(row["confidence"].ToString()),
                    Profit = Convert.ToBoolean(row["profit"].ToString()),
                    Mother_father = Convert.ToBoolean(row["mother_father"].ToString()),
                    Santan = Convert.ToBoolean(row["santan"].ToString()),
                    Brother = Convert.ToBoolean(row["brother"].ToString()),
                    Love_affair = Convert.ToBoolean(row["love_affair"].ToString()),
                    Disease = Convert.ToBoolean(row["disease"].ToString()),
                    Marriedlife = Convert.ToBoolean(row["married"].ToString()),
                    Occupation = Convert.ToBoolean(row["occupation"].ToString()),
                    Memory = Convert.ToBoolean(row["memory"].ToString()),
                    Common = Convert.ToBoolean(row["common"].ToString()),
                    Male = Convert.ToBoolean(row["male"].ToString()),
                    Female = Convert.ToBoolean(row["female"].ToString()),
                    Shishu = Convert.ToBoolean(row["shishu"].ToString()),
                    Bachpan = Convert.ToBoolean(row["bachpan"].ToString()),
                    Kishor = Convert.ToBoolean(row["kishor"].ToString()),
                    Yuva = Convert.ToBoolean(row["yuva"].ToString()),
                    Madhya = Convert.ToBoolean(row["madhya"].ToString()),
                    Budhapa = Convert.ToBoolean(row["budhapa"].ToString()),
                    Mainplanet = Convert.ToInt16(row["mainplanet"].ToString()),
                    Good = row["good"].ToString(),
                    Bad = row["bad"].ToString(),
                    Kayam = row["kayam"].ToString(),
                    MultiUpay = row["multiupay"].ToString(),
                    PlanetUpay = row["planetupay"].ToString(),
                    Lagan = row["lagan"].ToString(),
                    Rashi = row["rashi"].ToString()
                };
                rulesVOs.Add(rulesVO);
            }
            return rulesVOs;
        }

        public List<BasicruleVO> GetBasicRules(long kundliid)
        {
            List<BasicruleVO> basicruleVOs = new List<BasicruleVO>();
            foreach (DataRow row in (new KundliDAO()).GetBasicRulesByKundli(kundliid).Rows)
            {
                BasicruleVO basicruleVO = new BasicruleVO()
                {
                    Sno = Convert.ToInt32(row["sno"].ToString()),
                    Basicrule = row["basicrule"].ToString(),
                    House = Convert.ToInt32(row["house"].ToString()),
                    Planet = Convert.ToInt32(row["planet"].ToString())
                };
                basicruleVOs.Add(basicruleVO);
            }
            return basicruleVOs;
        }

        public List<KundliMappingVO> GetDayKundli(int age, int month, int day, KundliVO persKV, List<KundliMappingVO> janam_kundali)
        {
            List<KundliMappingVO> varshaphalKundliMapping = this.GetVarshaphalKundliMapping(age, persKV, janam_kundali);
            return this.RotateKundliMappings(varshaphalKundliMapping, month + day, persKV);
        }

        public List<KundliMappingVO> GetHourKundli(long kundliid, int age, int month, int day, int hour, KundliVO persKV, List<KundliMappingVO> janam_kundali)
        {
            List<KundliMappingVO> varshaphalKundliMapping = this.GetVarshaphalKundliMapping(age, persKV, janam_kundali);
            List<KundliMappingVO> kundliMappingVOs = this.RotateKundliMappings(varshaphalKundliMapping, month + day + hour - 1, persKV);
            return kundliMappingVOs;
        }

        public KundliVO GetKundliByID(long kundliid)
        {
            KundliVO kundliVO;
            KundliVO num = new KundliVO();
            DataTable kundliByID = (new KundliDAO()).GetKundliByID(kundliid);
            foreach (DataRow row in kundliByID.Rows)
            {
                num.Sno = (long)Convert.ToInt32(row["sno"].ToString());
                num.Remarks = row["remarks"].ToString();
                num.Lagna = Convert.ToInt64(row["lagna"]);
                num.Placeofbirth = row["placeofbirth"].ToString();
                num.Name = row["name"].ToString();
                num.Lat = Convert.ToDouble(row["lat"].ToString());
                num.Lon = Convert.ToDouble(row["lon"].ToString());
                num.Dob = Convert.ToDateTime(row["dob"].ToString());
                num.Tob = Convert.ToDateTime(row["tob"].ToString());
                num.EntryTime = Convert.ToDateTime(row["entrytime"].ToString());
                num.Male = Convert.ToBoolean(row["gender"].ToString());
                num.DD = row["dd"].ToString();
                num.MM = row["mm"].ToString();
                num.YY = row["yy"].ToString();
                num.HH = row["hh"].ToString();
                num.MIN = row["min"].ToString();
                num.SS = row["ss"].ToString();
                num.Language = row["language"].ToString();
                num.Latstr = row["latstr"].ToString();
                num.Lonstr = row["lonstr"].ToString();
                num.Timezonestr = row["timezonestr"].ToString();
                num.Machine = row["machine"].ToString();
                num.Manual = Convert.ToBoolean(row["manual"].ToString());
                num.Orderno = Convert.ToInt64(row["orderno"].ToString());
                num.Paid = Convert.ToBoolean(row["paid"].ToString());
                num.Product = row["product"].ToString();
            }
            if (kundliByID.Rows.Count > 0)
            {
                kundliVO = num;
            }
            else
            {
                kundliVO = null;
            }
            return kundliVO;
        }

        public KundliVO GetKundliByOrderNumber(long orderno)
        {
            KundliVO kundliVO;
            KundliVO num = new KundliVO();
            DataTable kundliByOrderNumber = (new KundliDAO()).GetKundliByOrderNumber(orderno);
            foreach (DataRow row in kundliByOrderNumber.Rows)
            {
                num.Sno = (long)Convert.ToInt32(row["sno"].ToString());
                num.Remarks = row["remarks"].ToString();
                num.Lagna = Convert.ToInt64(row["lagna"]);
                num.Placeofbirth = row["placeofbirth"].ToString();
                num.Name = row["name"].ToString();
                num.Lat = Convert.ToDouble(row["lat"].ToString());
                num.Lon = Convert.ToDouble(row["lon"].ToString());
                num.Dob = Convert.ToDateTime(row["dob"].ToString());
                num.Tob = Convert.ToDateTime(row["tob"].ToString());
                num.EntryTime = Convert.ToDateTime(row["entrytime"].ToString());
                num.Male = Convert.ToBoolean(row["gender"].ToString());
                num.DD = row["dd"].ToString();
                num.MM = row["mm"].ToString();
                num.YY = row["yy"].ToString();
                num.HH = row["hh"].ToString();
                num.MIN = row["min"].ToString();
                num.SS = row["ss"].ToString();
                num.Language = row["language"].ToString();
                num.Latstr = row["latstr"].ToString();
                num.Lonstr = row["lonstr"].ToString();
                num.Timezonestr = row["timezonestr"].ToString();
                num.Machine = row["machine"].ToString();
                num.Manual = Convert.ToBoolean(row["manual"].ToString());
                num.Orderno = Convert.ToInt64(row["orderno"].ToString());
                num.Paid = Convert.ToBoolean(row["paid"].ToString());
                num.Product = row["product"].ToString();
            }
            if (kundliByOrderNumber.Rows.Count > 0)
            {
                kundliVO = num;
            }
            else
            {
                kundliVO = null;
            }
            return kundliVO;
        }

        public List<KundliVO> GetKundlisLikeName(string name)
        {
            List<KundliVO> kundliVOs = new List<KundliVO>();
            foreach (DataRow row in (new KundliDAO()).GetKundliLikeName(name).Rows)
            {
                KundliVO kundliVO = new KundliVO()
                {
                    Sno = (long)Convert.ToInt32(row["sno"].ToString()),
                    Remarks = row["remarks"].ToString(),
                    Lagna = Convert.ToInt64(row["lagna"]),
                    Placeofbirth = row["placeofbirth"].ToString(),
                    Name = row["name"].ToString(),
                    Dob = Convert.ToDateTime(row["dob"].ToString()),
                    Tob = Convert.ToDateTime(row["tob"].ToString()),
                    EntryTime = Convert.ToDateTime(row["entrytime"].ToString()),
                    Male = Convert.ToBoolean(row["gender"].ToString()),
                    DD = row["dd"].ToString(),
                    MM = row["mm"].ToString(),
                    YY = row["yy"].ToString(),
                    HH = row["hh"].ToString(),
                    MIN = row["min"].ToString(),
                    SS = row["ss"].ToString(),
                    Language = row["language"].ToString(),
                    Latstr = row["latstr"].ToString(),
                    Lonstr = row["lonstr"].ToString(),
                    Timezonestr = row["timezonestr"].ToString(),
                    Machine = row["machine"].ToString(),
                    Manual = Convert.ToBoolean(row["manual"].ToString()),
                    Orderno = Convert.ToInt64(row["orderno"].ToString()),
                    Paid = Convert.ToBoolean(row["paid"].ToString()),
                    Product = row["product"].ToString()
                };
                kundliVOs.Add(kundliVO);
            }
            return kundliVOs;
        }

        public List<Life35VO> GetLife35(string planet)
        {
            string planetname = planet;
            List<Life35VO> life35VOs = new List<Life35VO>();
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            PlanetBLL planetBLL = new PlanetBLL();
            planetname = (
                from Map in planetBLL.GetAllPlanets()
                where Map.PlanetnameEnglish == planetname
                select Map).FirstOrDefault<PlanetVO>().Planetname;
            string[] strArrays = new string[] { "select a1.planet planet from A_35years as a1 where a1.sno>=(select sno from A_35years where planet='", planetname, "') union all select planet from A_35years where sno<(select sno from A_35years where planet='", planetname, "')" };
            dbCommand.CommandText = string.Concat(strArrays);
            foreach (DataRow row in GenericDataAccess.ExecuteSelectCommand(dbCommand).Rows)
            {
                Life35VO life35VO = new Life35VO()
                {
                    Planet = row["planet"].ToString()
                };
                life35VOs.Add(life35VO);
            }
            return life35VOs;
        }

        public List<PlanetVO> GetMandeGharPlanets(List<KundliMappingVO> lkmv)
        {
            KundliDAO kundliDAO = new KundliDAO();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<root>");
            foreach (KundliMappingVO kundliMappingVO in lkmv)
            {
                stringBuilder.Append("<mappings>");
                int house = kundliMappingVO.House;
                stringBuilder.AppendFormat("<house>{0}</house>", house.ToString());
                house = kundliMappingVO.Planet;
                stringBuilder.AppendFormat("<planet>{0}</planet>", house.ToString());
                stringBuilder.Append("</mappings>");
            }
            stringBuilder.Append("</root>");
            List<PlanetVO> planetVOs = new List<PlanetVO>();
            foreach (DataRow row in kundliDAO.GetMandeGharPlanets(stringBuilder.ToString()).Rows)
            {
                PlanetVO planetVO = new PlanetVO()
                {
                    Sno = Convert.ToInt32(row["sno"].ToString()),
                    Planetname = row["planet"].ToString(),
                    Color = row["color"].ToString(),
                    Din = row["din"].ToString(),
                    Karya = row["karya"].ToString(),
                    Samay = row["samay"].ToString(),
                    Pakka_ghar = Convert.ToInt32(row["pakka_ghar"].ToString())
                };
                planetVOs.Add(planetVO);
            }
            return planetVOs;
        }

        public List<KundliMappingVO> GetMinutesKundli(long kundliid, int age, int month, int day, int hour, int minute, KundliVO persKV, List<KundliMappingVO> janam_kundali)
        {
            List<KundliMappingVO> varshaphalKundliMapping = this.GetVarshaphalKundliMapping(age, persKV, janam_kundali);
            List<KundliMappingVO> kundliMappingVOs = this.RotateKundliMappings(varshaphalKundliMapping, month + day + hour + minute - 2, persKV);
            return kundliMappingVOs;
        }

        public List<KundliMappingVO> GetMonthlyKundli(int age, int month, KundliVO persKV, List<KundliMappingVO> janam_kundali)
        {
            List<KundliMappingVO> varshaphalKundliMapping = this.GetVarshaphalKundliMapping(age, persKV, janam_kundali);
            return this.RotateKundliMappings(varshaphalKundliMapping, month, persKV);
        }

        public List<PlanetVO> GetNeechGharPlanets(List<KundliMappingVO> lkmv)
        {
            KundliDAO kundliDAO = new KundliDAO();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<root>");
            foreach (KundliMappingVO kundliMappingVO in lkmv)
            {
                stringBuilder.Append("<mappings>");
                int house = kundliMappingVO.House;
                stringBuilder.AppendFormat("<house>{0}</house>", house.ToString());
                house = kundliMappingVO.Planet;
                stringBuilder.AppendFormat("<planet>{0}</planet>", house.ToString());
                stringBuilder.Append("</mappings>");
            }
            stringBuilder.Append("</root>");
            List<PlanetVO> planetVOs = new List<PlanetVO>();
            foreach (DataRow row in kundliDAO.GetNeechGharPlanets(stringBuilder.ToString()).Rows)
            {
                PlanetVO planetVO = new PlanetVO()
                {
                    Sno = Convert.ToInt32(row["sno"].ToString()),
                    Planetname = row["planet"].ToString(),
                    Color = row["color"].ToString(),
                    Din = row["din"].ToString(),
                    Karya = row["karya"].ToString(),
                    Samay = row["samay"].ToString(),
                    Pakka_ghar = Convert.ToInt32(row["pakka_ghar"].ToString())
                };
                planetVOs.Add(planetVO);
            }
            return planetVOs;
        }

        public List<PlanetVO> GetPakkeGharPlanets(List<KundliMappingVO> lkmv)
        {
            KundliDAO kundliDAO = new KundliDAO();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<root>");
            foreach (KundliMappingVO kundliMappingVO in lkmv)
            {
                stringBuilder.Append("<mappings>");
                int house = kundliMappingVO.House;
                stringBuilder.AppendFormat("<house>{0}</house>", house.ToString());
                house = kundliMappingVO.Planet;
                stringBuilder.AppendFormat("<planet>{0}</planet>", house.ToString());
                stringBuilder.Append("</mappings>");
            }
            stringBuilder.Append("</root>");
            DataTable pakkeGharPlanets = kundliDAO.GetPakkeGharPlanets(stringBuilder.ToString());
            List<PlanetVO> planetVOs = new List<PlanetVO>();
            foreach (DataRow row in pakkeGharPlanets.Rows)
            {
                PlanetVO planetVO = new PlanetVO()
                {
                    Sno = Convert.ToInt32(row["sno"].ToString()),
                    Planetname = row["planet"].ToString(),
                    Color = row["color"].ToString(),
                    Din = row["din"].ToString(),
                    Karya = row["karya"].ToString(),
                    Samay = row["samay"].ToString(),
                    Pakka_ghar = Convert.ToInt32(row["pakka_ghar"].ToString())
                };
                planetVOs.Add(planetVO);
            }
            return planetVOs;
        }

        public short GetPapiManda(List<KundliMappingVO> lkmv)
        {
            bool flag;
            bool flag1;
            bool flag2;
            bool flag3;
            bool flag4;
            bool flag5;
            bool flag6;
            bool flag7;
            bool flag8;
            bool flag9;
            bool flag10;
            bool flag11;
            short num = 0;
            short num1 = Convert.ToInt16((
                from Map in lkmv
                where Map.PlanetName.Contains("Rahu")
                select Map.House).SingleOrDefault<int>());
            short num2 = Convert.ToInt16((
                from Map in lkmv
                where Map.PlanetName.Contains("Ketu")
                select Map.House).SingleOrDefault<int>());
            short num3 = Convert.ToInt16((
                from Map in lkmv
                where Map.PlanetName.Contains("Shani")
                select Map.House).SingleOrDefault<int>());
            if (num3 != 1)
            {
                flag = true;
            }
            else
            {
                flag = (num1 == 12 ? false : num2 != 12);
            }
            if (!flag)
            {
                num = 2;
            }
            if (num3 != 2)
            {
                flag1 = true;
            }
            else
            {
                flag1 = (num1 == 1 ? false : num2 != 1);
            }
            if (!flag1)
            {
                num = 3;
            }
            if (num3 != 3)
            {
                flag2 = true;
            }
            else
            {
                flag2 = (num1 == 2 ? false : num2 != 2);
            }
            if (!flag2)
            {
                num = 4;
            }
            if (num3 != 4)
            {
                flag3 = true;
            }
            else
            {
                flag3 = (num1 == 3 ? false : num2 != 3);
            }
            if (!flag3)
            {
                num = 5;
            }
            if (num3 != 5)
            {
                flag4 = true;
            }
            else
            {
                flag4 = (num1 == 4 ? false : num2 != 4);
            }
            if (!flag4)
            {
                num = 6;
            }
            if (num3 != 6)
            {
                flag5 = true;
            }
            else
            {
                flag5 = (num1 == 5 ? false : num2 != 5);
            }
            if (!flag5)
            {
                num = 7;
            }
            if (num3 != 7)
            {
                flag6 = true;
            }
            else
            {
                flag6 = (num1 == 6 ? false : num2 != 6);
            }
            if (!flag6)
            {
                num = 8;
            }
            if (num3 != 8)
            {
                flag7 = true;
            }
            else
            {
                flag7 = (num1 == 7 ? false : num2 != 7);
            }
            if (!flag7)
            {
                num = 9;
            }
            if (num3 != 9)
            {
                flag8 = true;
            }
            else
            {
                flag8 = (num1 == 8 ? false : num2 != 8);
            }
            if (!flag8)
            {
                num = 10;
            }
            if (num3 != 10)
            {
                flag9 = true;
            }
            else
            {
                flag9 = (num1 == 9 ? false : num2 != 9);
            }
            if (!flag9)
            {
                num = 11;
            }
            if (num3 != 11)
            {
                flag10 = true;
            }
            else
            {
                flag10 = (num1 == 10 ? false : num2 != 10);
            }
            if (!flag10)
            {
                num = 12;
            }
            if (num3 != 12)
            {
                flag11 = true;
            }
            else
            {
                flag11 = (num1 == 11 ? false : num2 != 11);
            }
            if (!flag11)
            {
                num = 1;
            }
            return num;
        }

        public List<KundliMappingVO> GetSecondsKundli(long kundliid, int age, int month, int day, int hour, int minute, int second, KundliVO persKV, List<KundliMappingVO> janam_kundali)
        {
            List<KundliMappingVO> varshaphalKundliMapping = this.GetVarshaphalKundliMapping(age, persKV, janam_kundali);
            List<KundliMappingVO> kundliMappingVOs = this.RotateKundliMappings(varshaphalKundliMapping, month + day + hour + minute + second - 3, persKV);
            return kundliMappingVOs;
        }

        public List<PlanetVO> GetShreshtGharPlanets(List<KundliMappingVO> lkmv)
        {
            KundliDAO kundliDAO = new KundliDAO();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<root>");
            foreach (KundliMappingVO kundliMappingVO in lkmv)
            {
                stringBuilder.Append("<mappings>");
                int house = kundliMappingVO.House;
                stringBuilder.AppendFormat("<house>{0}</house>", house.ToString());
                house = kundliMappingVO.Planet;
                stringBuilder.AppendFormat("<planet>{0}</planet>", house.ToString());
                stringBuilder.Append("</mappings>");
            }
            stringBuilder.Append("</root>");
            List<PlanetVO> planetVOs = new List<PlanetVO>();
            foreach (DataRow row in kundliDAO.GetShreshtGharPlanets(stringBuilder.ToString()).Rows)
            {
                PlanetVO planetVO = new PlanetVO()
                {
                    Sno = Convert.ToInt32(row["sno"].ToString()),
                    Planetname = row["planet"].ToString(),
                    Color = row["color"].ToString(),
                    Din = row["din"].ToString(),
                    Karya = row["karya"].ToString(),
                    Samay = row["samay"].ToString(),
                    Pakka_ghar = Convert.ToInt32(row["pakka_ghar"].ToString())
                };
                planetVOs.Add(planetVO);
            }
            return planetVOs;
        }

        public List<PlanetVO> GetUchGharPlanets(List<KundliMappingVO> lkmv)
        {
            KundliDAO kundliDAO = new KundliDAO();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<root>");
            foreach (KundliMappingVO kundliMappingVO in lkmv)
            {
                stringBuilder.Append("<mappings>");
                int house = kundliMappingVO.House;
                stringBuilder.AppendFormat("<house>{0}</house>", house.ToString());
                house = kundliMappingVO.Planet;
                stringBuilder.AppendFormat("<planet>{0}</planet>", house.ToString());
                stringBuilder.Append("</mappings>");
            }
            stringBuilder.Append("</root>");
            List<PlanetVO> planetVOs = new List<PlanetVO>();
            foreach (DataRow row in kundliDAO.GetUchGharPlanets(stringBuilder.ToString()).Rows)
            {
                PlanetVO planetVO = new PlanetVO()
                {
                    Sno = Convert.ToInt32(row["sno"].ToString()),
                    Planetname = row["planet"].ToString(),
                    Color = row["color"].ToString(),
                    Din = row["din"].ToString(),
                    Karya = row["karya"].ToString(),
                    Samay = row["samay"].ToString(),
                    Pakka_ghar = Convert.ToInt32(row["pakka_ghar"].ToString())
                };
                planetVOs.Add(planetVO);
            }
            return planetVOs;
        }

        public List<KundliMappingVO> GetVarshaphalKundliMapping(int age, KundliVO persKV, List<KundliMappingVO> janam_kundali)
        {
            List<KundliMappingVO> kundliMappingVOs = new List<KundliMappingVO>();
            KundliDAO kundliDAO = new KundliDAO();
            List<KundliMappingVO> kundliMappingVOs1 = new List<KundliMappingVO>();
            foreach (KundliMappingVO janamKundali in janam_kundali)
            {
                KundliMappingVO kundliMappingVO = new KundliMappingVO();
                DbCommand dbCommand = GenericDataAccess.CreateCommand();
                dbCommand.CommandType = CommandType.Text;
                object[] house = new object[] { "select house", janamKundali.House, " from a_varshphal where age = ", age };
                dbCommand.CommandText = string.Concat(house);
                DataTable dataTable = GenericDataAccess.ExecuteSelectCommand(dbCommand);
                kundliMappingVO.Sno = janamKundali.Sno;
                kundliMappingVO.House = Convert.ToInt16(dataTable.Rows[0][0].ToString());
                if ((long)kundliMappingVO.House + (persKV.Lagna - (long)1) <= (long)12)
                {
                    kundliMappingVO.Rashi = Convert.ToInt32((long)kundliMappingVO.House + (persKV.Lagna - (long)1));
                }
                else
                {
                    kundliMappingVO.Rashi = Convert.ToInt32((long)kundliMappingVO.House + (persKV.Lagna - (long)1) - (long)12);
                }
                kundliMappingVO.Planet = janamKundali.Planet;
                kundliMappingVO.Kundliid = (long)0;
                kundliMappingVO.PlanetName = this.findplanet(janamKundali.Planet).Planetname;
                kundliMappingVO.PlanetNameHindi = this.findplanet(janamKundali.Planet).PlanetnameHindi;
                kundliMappingVO.PlanetNameEnglish = this.findplanet(janamKundali.Planet).PlanetnameEnglish;
                kundliMappingVOs.Add(kundliMappingVO);
            }
            this.Process_VarshPlanet_GoodBad(janam_kundali, ref kundliMappingVOs, persKV.Dob, persKV.Tob, (long)age, persKV);
            return kundliMappingVOs;
        }

        public List<KundliMappingVO> GetWeekKundli(int age, int month, int week, KundliVO persKV, List<KundliMappingVO> janam_kundali)
        {
            List<KundliMappingVO> varshaphalKundliMapping = this.GetVarshaphalKundliMapping(age, persKV, janam_kundali);
            return this.RotateKundliMappings(varshaphalKundliMapping, week, persKV);
        }

        public short Is_Mangal_Bad(List<KundliMappingVO> lkmv)
        {
            bool flag;
            bool flag1;
            short num = 0;
            short num1 = Convert.ToInt16((
                from Map in lkmv
                where Map.PlanetName == "Mangal"
                select Map.House).SingleOrDefault<int>());
            short num2 = Convert.ToInt16((
                from Map in lkmv
                where Map.PlanetName == "Surya"
                select Map.House).SingleOrDefault<int>());
            short num3 = Convert.ToInt16((
                from Map in lkmv
                where Map.PlanetName == "Shani"
                select Map.House).SingleOrDefault<int>());
            short num4 = Convert.ToInt16((
                from Map in lkmv
                where Map.PlanetName == "Chandra"
                select Map.House).SingleOrDefault<int>());
            short num5 = Convert.ToInt16((
                from Map in lkmv
                where Map.PlanetName == "Shukra"
                select Map.House).SingleOrDefault<int>());
            short num6 = Convert.ToInt16((
                from Map in lkmv
                where Map.PlanetName == "Budh"
                select Map.House).SingleOrDefault<int>());
            short num7 = Convert.ToInt16((
                from Map in lkmv
                where Map.PlanetName == "Rahu"
                select Map.House).SingleOrDefault<int>());
            short num8 = Convert.ToInt16((
                from Map in lkmv
                where Map.PlanetName == "Ketu"
                select Map.House).SingleOrDefault<int>());
            Convert.ToInt16((
                from Map in lkmv
                where Map.PlanetName == "Guru"
                select Map.House).SingleOrDefault<int>());
            if (num2 == num3)
            {
                num = 2;
            }
            if (num1 != 8)
            {
                flag = true;
            }
            else
            {
                flag = (num3 == 1 ? false : num3 != 2);
            }
            if (!flag)
            {
                num = 2;
            }
            if (num5 == num6)
            {
                num = 2;
            }
            if (num5 == 9)
            {
                num = 2;
            }
            if (Convert.ToInt16((
                from Map in lkmv
                where Map.House == num2
                select Map).Count<KundliMappingVO>()) != 1)
            {
                flag1 = true;
            }
            else
            {
                flag1 = (num2 == 6 || num2 == 7 || num2 == 10 ? false : num2 != 12);
            }
            if (!flag1)
            {
                num = 2;
            }
            if ((num7 == 5 ? true : num7 == 9))
            {
                num = 2;
            }
            if ((num8 == 3 ? true : num8 == 8))
            {
                num = 2;
            }
            if (num6 == num8)
            {
                num = 2;
            }
            if ((num6 != num1 ? false : num6 != 8))
            {
                num = 2;
            }
            if ((num4 == 1 || num4 == 3 || num4 == 4 || num4 == 8 ? true : num4 == 9))
            {
                num = Convert.ToInt16(num != 2 ? 1 : 3);
            }
            if (num2 == num6)
            {
                num = 1;
            }
            if ((Convert.ToInt16((
                from Map in lkmv
                where Map.House == num2
                select Map).Count<KundliMappingVO>()) != 1 ? false : num2 == 3))
            {
                num = 1;
            }
            return num;
        }

        public bool Is_Manglik(List<KundliMappingVO> lkmv)
        {
            bool flag = false;
            short num = Convert.ToInt16((
                from Map in lkmv
                where Map.PlanetName == "Mangal"
                select Map.House).SingleOrDefault<int>());
            if ((num == 1 || num == 4 || num == 7 || num == 8 ? true : num == 12))
            {
                flag = true;
            }
            return flag;
        }

        public bool Is_Manglik(List<KPPlanetMappingVO> kp_chart)
        {
            bool flag = false;
            short num = Convert.ToInt16((
                from Map in kp_chart
                where Map.Planet == 3
                select Map.Bhav_Chalit_House).SingleOrDefault<short>());
            if ((num == 1 || num == 4 || num == 7 || num == 8 ? true : num == 12))
            {
                flag = true;
            }
            return flag;
        }

        public void janam_greh(string dt1, string tm1, ref string JanamDin, ref string JanamSamay)
        {
            TimeSpan timeOfDay;
            bool dateTime;
            bool flag;
            bool dateTime1;
            bool flag1;
            bool dateTime2;
            bool flag2;
            bool dateTime3;
            bool flag3;
            bool dateTime4;
            bool flag4;
            bool dateTime5;
            bool flag5;
            char[] chrArray = new char[] { '/' };
            short num = Convert.ToInt16(dt1.Split(chrArray)[2]);
            chrArray = new char[] { '/' };
            short num1 = Convert.ToInt16(dt1.Split(chrArray)[1]);
            chrArray = new char[] { '/' };
            DateTime dateTime6 = new DateTime(num, num1, Convert.ToInt16(dt1.Split(chrArray)[0]));
            chrArray = new char[] { '/' };
            short num2 = Convert.ToInt16(dt1.Split(chrArray)[2]);
            chrArray = new char[] { '/' };
            short num3 = Convert.ToInt16(dt1.Split(chrArray)[1]);
            chrArray = new char[] { '/' };
            short num4 = Convert.ToInt16(dt1.Split(chrArray)[0]);
            chrArray = new char[] { ':' };
            short num5 = Convert.ToInt16(tm1.Split(chrArray)[0]);
            chrArray = new char[] { ':' };
            DateTime dateTime7 = new DateTime(num2, num3, num4, num5, Convert.ToInt16(tm1.Split(chrArray)[1]), 0);
            if (Convert.ToDateTime(dateTime6).DayOfWeek.ToString() == "Thursday")
            {
                JanamDin = "Guru";
            }
            if (Convert.ToDateTime(dateTime6).DayOfWeek.ToString() == "Sunday")
            {
                JanamDin = "Surya";
            }
            if (Convert.ToDateTime(dateTime6).DayOfWeek.ToString() == "Monday")
            {
                JanamDin = "Chandra";
            }
            if (Convert.ToDateTime(dateTime6).DayOfWeek.ToString() == "Tuesday")
            {
                JanamDin = "Mangal";
            }
            if (Convert.ToDateTime(dateTime6).DayOfWeek.ToString() == "Friday")
            {
                JanamDin = "Shukra";
            }
            if (Convert.ToDateTime(dateTime6).DayOfWeek.ToString() == "Wednesday")
            {
                JanamDin = "Budh";
            }
            DateTime dateTime8 = Convert.ToDateTime("18:29");
            if (Convert.ToDateTime(dateTime6).DayOfWeek.ToString() != "Thursday")
            {
                dateTime = true;
            }
            else
            {
                timeOfDay = Convert.ToDateTime(dateTime7).TimeOfDay;
                dateTime = !(Convert.ToDateTime(timeOfDay.ToString()) >= dateTime8);
            }
            if (!dateTime)
            {
                JanamDin = "Rahu";
            }
            if (Convert.ToDateTime(dateTime6).DayOfWeek.ToString() == "Saturday")
            {
                JanamDin = "Shani";
            }
            dateTime8 = Convert.ToDateTime("11:59");
            if (Convert.ToDateTime(dateTime6).DayOfWeek.ToString() != "Sunday")
            {
                flag = true;
            }
            else
            {
                timeOfDay = Convert.ToDateTime(dateTime7).TimeOfDay;
                flag = !(Convert.ToDateTime(timeOfDay.ToString()) <= dateTime8);
            }
            if (!flag)
            {
                JanamDin = "Rahu";
            }
            dateTime8 = Convert.ToDateTime("05:30");
            DateTime dateTime9 = Convert.ToDateTime("07:59");
            if (Convert.ToDateTime(Convert.ToDateTime(dateTime7).TimeOfDay.ToString()) < dateTime8)
            {
                dateTime1 = true;
            }
            else
            {
                timeOfDay = Convert.ToDateTime(dateTime7).TimeOfDay;
                dateTime1 = !(Convert.ToDateTime(timeOfDay.ToString()) <= dateTime9);
            }
            if (!dateTime1)
            {
                JanamSamay = "Guru";
            }
            dateTime8 = Convert.ToDateTime("08:00");
            dateTime9 = Convert.ToDateTime("09:59");
            if (Convert.ToDateTime(Convert.ToDateTime(dateTime7).TimeOfDay.ToString()) < dateTime8)
            {
                flag1 = true;
            }
            else
            {
                timeOfDay = Convert.ToDateTime(dateTime7).TimeOfDay;
                flag1 = !(Convert.ToDateTime(timeOfDay.ToString()) <= dateTime9);
            }
            if (!flag1)
            {
                JanamSamay = "Surya";
            }
            dateTime8 = Convert.ToDateTime("10:00");
            dateTime9 = Convert.ToDateTime("10:59");
            if (Convert.ToDateTime(Convert.ToDateTime(dateTime7).TimeOfDay.ToString()) < dateTime8)
            {
                dateTime2 = true;
            }
            else
            {
                timeOfDay = Convert.ToDateTime(dateTime7).TimeOfDay;
                dateTime2 = !(Convert.ToDateTime(timeOfDay.ToString()) <= dateTime9);
            }
            if (!dateTime2)
            {
                JanamSamay = "Chandra";
            }
            dateTime8 = Convert.ToDateTime("11:00");
            dateTime9 = Convert.ToDateTime("12:59");
            if (Convert.ToDateTime(Convert.ToDateTime(dateTime7).TimeOfDay.ToString()) < dateTime8)
            {
                flag2 = true;
            }
            else
            {
                timeOfDay = Convert.ToDateTime(dateTime7).TimeOfDay;
                flag2 = !(Convert.ToDateTime(timeOfDay.ToString()) <= dateTime9);
            }
            if (!flag2)
            {
                JanamSamay = "Mangal";
            }
            dateTime8 = Convert.ToDateTime("13:00");
            dateTime9 = Convert.ToDateTime("15:59");
            if (Convert.ToDateTime(Convert.ToDateTime(dateTime7).TimeOfDay.ToString()) < dateTime8)
            {
                dateTime3 = true;
            }
            else
            {
                timeOfDay = Convert.ToDateTime(dateTime7).TimeOfDay;
                dateTime3 = !(Convert.ToDateTime(timeOfDay.ToString()) <= dateTime9);
            }
            if (!dateTime3)
            {
                JanamSamay = "Shukra";
            }
            dateTime8 = Convert.ToDateTime("16:00");
            dateTime9 = Convert.ToDateTime("18:29");
            if (Convert.ToDateTime(Convert.ToDateTime(dateTime7).TimeOfDay.ToString()) < dateTime8)
            {
                flag3 = true;
            }
            else
            {
                timeOfDay = Convert.ToDateTime(dateTime7).TimeOfDay;
                flag3 = !(Convert.ToDateTime(timeOfDay.ToString()) <= dateTime9);
            }
            if (!flag3)
            {
                JanamSamay = "Budh";
            }
            dateTime8 = Convert.ToDateTime("18:30");
            dateTime9 = Convert.ToDateTime("19:59");
            if (Convert.ToDateTime(Convert.ToDateTime(dateTime7).TimeOfDay.ToString()) < dateTime8)
            {
                dateTime4 = true;
            }
            else
            {
                timeOfDay = Convert.ToDateTime(dateTime7).TimeOfDay;
                dateTime4 = !(Convert.ToDateTime(timeOfDay.ToString()) <= dateTime9);
            }
            if (!dateTime4)
            {
                JanamSamay = "Rahu";
            }
            dateTime8 = Convert.ToDateTime("20:00");
            dateTime9 = Convert.ToDateTime("23:59");
            if (Convert.ToDateTime(Convert.ToDateTime(dateTime7).TimeOfDay.ToString()) < dateTime8)
            {
                flag4 = true;
            }
            else
            {
                timeOfDay = Convert.ToDateTime(dateTime7).TimeOfDay;
                flag4 = !(Convert.ToDateTime(timeOfDay.ToString()) <= dateTime9);
            }
            if (!flag4)
            {
                JanamSamay = "Shani";
            }
            dateTime8 = Convert.ToDateTime("00:00");
            dateTime9 = Convert.ToDateTime("03:29");
            if (Convert.ToDateTime(Convert.ToDateTime(dateTime7).TimeOfDay.ToString()) < dateTime8)
            {
                dateTime5 = true;
            }
            else
            {
                timeOfDay = Convert.ToDateTime(dateTime7).TimeOfDay;
                dateTime5 = !(Convert.ToDateTime(timeOfDay.ToString()) <= dateTime9);
            }
            if (!dateTime5)
            {
                JanamSamay = "Shani";
            }
            dateTime8 = Convert.ToDateTime("03:30");
            dateTime9 = Convert.ToDateTime("05:29");
            if (Convert.ToDateTime(Convert.ToDateTime(dateTime7).TimeOfDay.ToString()) < dateTime8)
            {
                flag5 = true;
            }
            else
            {
                timeOfDay = Convert.ToDateTime(dateTime7).TimeOfDay;
                flag5 = !(Convert.ToDateTime(timeOfDay.ToString()) <= dateTime9);
            }
            if (!flag5)
            {
                JanamSamay = "Ketu";
            }
        }

        public string longi2timezone(string full_tz)
        {
            string str;
            if (full_tz.IndexOf(':') <= 0)
            {
                str = full_tz.Substring(0, full_tz.Length - 1).ToString();
                str = Convert.ToString(Convert.ToDouble(str) / 15);
                str = this.DecimalToDMS(Convert.ToDouble(str)).ToString();
                str = str.Replace(":", ".");
                if (str.Length == 4)
                {
                    str = string.Concat("0", str);
                }
            }
            else
            {
                string str1 = full_tz.Substring(0, full_tz.Length - 1).ToString();
                char[] chrArray = new char[] { ':' };
                string[] strArrays = str1.Split(chrArray);
                double num = this.DMStoDecimal(Convert.ToDouble(strArrays[0]), Convert.ToDouble(strArrays[1]), 0);
                str = num.ToString();
                str = Convert.ToString(Convert.ToDouble(str) / 15);
                str = this.DecimalToDMS(Convert.ToDouble(str)).ToString();
                chrArray = new char[] { ':' };
                strArrays = str.Split(chrArray);
                if (strArrays[0].Length == 1)
                {
                    strArrays[0] = string.Concat("0", strArrays[0]);
                }
                str = string.Concat(strArrays[0], ".", strArrays[1]);
            }
            str = (!(full_tz.Substring(full_tz.Length - 1, 1).ToString() == "E") ? string.Concat("-", str) : string.Concat("+", str));
            return str;
        }

        public List<KPPlanetMappingVO> NEW_GetMonthlyKundli(int age, int month, KundliVO persKV, List<KPPlanetMappingVO> janam_kundali)
        {
            List<KPPlanetMappingVO> kPPlanetMappingVOs = new List<KPPlanetMappingVO>();
            kPPlanetMappingVOs = this.NEW_GetVarshaphalKundliMapping(age, persKV, janam_kundali);
            return this.NEW_RotateKundliMappings(kPPlanetMappingVOs, month, persKV);
        }

        public List<KPPlanetMappingVO> NEW_GetVarshaphalKundliMapping(int age, KundliVO persKV, List<KPPlanetMappingVO> kp_chart)
        {
            List<KPPlanetMappingVO> kPPlanetMappingVOs = new List<KPPlanetMappingVO>();
            List<KPPlanetsVO> kPPlanetsVOs = (new KPBLL()).Fill_Planets();
            KundliDAO kundliDAO = new KundliDAO();
            foreach (KPPlanetMappingVO kpChart in kp_chart)
            {
                KPPlanetMappingVO kPPlanetMappingVO = new KPPlanetMappingVO();
                DbCommand dbCommand = GenericDataAccess.CreateCommand();
                dbCommand.CommandType = CommandType.Text;
                object[] bhavChalitHouse = new object[] { "select house", kpChart.Bhav_Chalit_House, " from a_varshphal where age = ", age };
                dbCommand.CommandText = string.Concat(bhavChalitHouse);
                DataTable dataTable = GenericDataAccess.ExecuteSelectCommand(dbCommand);
                kPPlanetMappingVO.Planet = kpChart.Planet;
                kPPlanetMappingVO.Bhav_Chalit_House = Convert.ToInt16(dataTable.Rows[0][0].ToString());
                kPPlanetMappingVO.House = kPPlanetMappingVO.Bhav_Chalit_House;
                if ((long)kPPlanetMappingVO.Bhav_Chalit_House + (persKV.Lagna - (long)1) <= (long)12)
                {
                    kPPlanetMappingVO.Rashi = Convert.ToInt16((long)kPPlanetMappingVO.Bhav_Chalit_House + (persKV.Lagna - (long)1));
                }
                else
                {
                    kPPlanetMappingVO.Rashi = Convert.ToInt16((long)kPPlanetMappingVO.Bhav_Chalit_House + (persKV.Lagna - (long)1) - (long)12);
                }
                string pakkeGhar = kPPlanetsVOs[kPPlanetMappingVO.Planet - 1].Pakke_Ghar;
                char[] chrArray = new char[] { ',' };
                string[] strArrays = pakkeGhar.Split(chrArray, StringSplitOptions.RemoveEmptyEntries);
                short num = kPPlanetMappingVO.Bhav_Chalit_House;
                kPPlanetMappingVO.IsPakka = strArrays.Contains<string>(num.ToString());
                kPPlanetMappingVOs.Add(kPPlanetMappingVO);
            }
            this.NEW_Process_VarshPlanet_GoodBad(kp_chart, kPPlanetMappingVOs, persKV, (long)age);
            return kPPlanetMappingVOs;
        }

        public void NEW_Process_VarshPlanet_GoodBad(List<KPPlanetMappingVO> kp_chart, List<KPPlanetMappingVO> vfal_chart, KundliVO persKV, long age)
        {
            DateTime dob = persKV.Dob;
            DateTime tob = persKV.Tob;
            int num = 0;
            int item = 0;
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            foreach (KPPlanetMappingVO vfalChart in vfal_chart)
            {
                int house = vfalChart.House;
                int planet = vfalChart.Planet;
                num1 = 0;
                num2 = 0;
                num3 = 0;
                num4 = 0;
                int num5 = 0;
                vfal_chart[item].isbad = false;
                List<KPPlanetMappingVO> kPPlanetMappingVOs = new List<KPPlanetMappingVO>();
                if ((house < 1 ? false : house <= 5))
                {
                    num = house + 7;
                }
                if ((house < 6 ? false : house <= 12))
                {
                    num = house - 5;
                }
                if (Convert.ToInt16((
                    from Map in vfal_chart
                    where Map.House == num
                    select Map).ToList<KPPlanetMappingVO>().Count) > 0)
                {
                    vfal_chart[item].isbad = true;
                }
                if ((house != 3 ? false : vfalChart.Planet == 1))
                {
                    num1 = Convert.ToInt16((
                        from Map in vfal_chart
                        where Map.Planet == 7
                        select Map.House).SingleOrDefault<short>());
                    num3 = Convert.ToInt16((
                        from Map in vfal_chart
                        where Map.Planet == 8
                        select Map.House).SingleOrDefault<short>());
                    num4 = Convert.ToInt16((
                        from Map in vfal_chart
                        where Map.Planet == 6
                        select Map.House).SingleOrDefault<short>());
                    num2 = Convert.ToInt16((
                        from Map in vfal_chart
                        where Map.Planet == 4
                        select Map.House).SingleOrDefault<short>());
                    if ((num1 == 3 || num3 == 3 ? true : num4 == 3))
                    {
                        vfal_chart[item].isbad = true;
                    }
                }
                if ((house != 1 ? false : vfalChart.Planet == 2))
                {
                    if (Convert.ToInt16((
                        from Map in kp_chart
                        where Map.Planet == 2
                        select Map.House).SingleOrDefault<short>()) == 12)
                    {
                        vfal_chart[item].isbad = true;
                    }
                }
                if (vfalChart.Planet == 5)
                {
                    num1 = Convert.ToInt16((
                        from Map in kp_chart
                        where Map.Planet == 7
                        select Map.House).SingleOrDefault<short>());
                    num3 = Convert.ToInt16((
                        from Map in kp_chart
                        where Map.Planet == 8
                        select Map.House).SingleOrDefault<short>());
                    num2 = Convert.ToInt16((
                        from Map in kp_chart
                        where Map.Planet == 4
                        select Map.House).SingleOrDefault<short>());
                    num5 = Convert.ToInt16((
                        from Map in kp_chart
                        where Map.Planet == 9
                        select Map.House).SingleOrDefault<short>());
                    num4 = Convert.ToInt16((
                        from Map in kp_chart
                        where Map.Planet == 6
                        select Map.House).SingleOrDefault<short>());
                    if ((num4 == 2 || num4 == 5 || num4 == 9 || num4 == 11 || num4 == 12 || num1 == 2 || num1 == 5 || num1 == 9 || num1 == 11 || num1 == 12 || num3 == 2 || num3 == 5 || num3 == 9 || num3 == 11 || num3 == 12 || num2 == 2 || num2 == 5 || num2 == 9 || num2 == 11 ? true : num2 == 12))
                    {
                        vfal_chart[item].isbad = true;
                    }
                }
                Years35BLL years35BLL = new Years35BLL();
                long num6 = (long)0;
                long num7 = (long)0;
                KundliBLL kundliBLL = new KundliBLL();
                KundliMappingVO kundliMappingVO = new KundliMappingVO();
                List<Years35VO> years35VOs = years35BLL.Get35Years(persKV.JanamSamay);
                List<KPPlanetsVO> kPPlanetsVOs = (new KPBLL()).Fill_Planets();
                Years35VO years35VO = (
                    from Map in years35VOs
                    where Map.Years == age
                    select Map).SingleOrDefault<Years35VO>();
                if (years35VO.Planet == (
                    from Map in kPPlanetsVOs
                    where Map.Planet == vfalChart.Planet
                    select Map).FirstOrDefault<KPPlanetsVO>().Roman)
                {
                    kundliMappingVO.PlanetName = years35VO.Planet;
                    num6 = (long)kp_chart.FindIndex((KPPlanetMappingVO Map) => Map.Planet == (
                        from Map1 in kPPlanetsVOs
                        where Map1.Roman == years35VO.Planet
                        select Map1).FirstOrDefault<KPPlanetsVO>().Planet);
                    num7 = (long)vfal_chart.FindIndex((KPPlanetMappingVO Map) => Map.Planet == (
                        from Map1 in kPPlanetsVOs
                        where Map1.Roman == years35VO.Planet
                        select Map1).FirstOrDefault<KPPlanetsVO>().Planet);
                    vfal_chart[item].isbad = kp_chart[item].isbad;
                }
                if ((vfalChart.Planet != 8 ? false : house == 7))
                {
                    vfal_chart[item].isbad = true;
                }
                item++;
            }
        }

        public List<KPPlanetMappingVO> NEW_RotateKundliMappings(List<KPPlanetMappingVO> lkmv_orig, int rotateno, KundliVO persKV)
        {
            List<KPPlanetMappingVO> kPPlanetMappingVOs = new List<KPPlanetMappingVO>();
            int num = rotateno % 12;
            foreach (KPPlanetMappingVO lkmvOrig in lkmv_orig)
            {
                lkmvOrig.House = Convert.ToInt16(lkmvOrig.House + num);
                if (lkmvOrig.House > 12)
                {
                    short num1 = Convert.ToInt16(lkmvOrig.House - 12);
                    lkmvOrig.House = num1;
                    if ((long)lkmvOrig.House + (persKV.Lagna - (long)1) <= (long)12)
                    {
                        lkmvOrig.Rashi = Convert.ToInt16((long)lkmvOrig.House + (persKV.Lagna - (long)1));
                    }
                    else
                    {
                        lkmvOrig.Rashi = Convert.ToInt16((long)lkmvOrig.House + (persKV.Lagna - (long)1) - (long)12);
                    }
                }
                kPPlanetMappingVOs.Add(lkmvOrig);
            }
            return kPPlanetMappingVOs;
        }

        public void Process_Kundali_Planet_GoodBad(ref List<KundliMappingVO> lkmv)
        {
            bool flag;
            bool flag1;
            bool flag2;
            bool flag3;
            bool flag4;
            bool flag5;
            bool flag6;
            bool flag7;
            bool num;
            bool flag8;
            bool flag9;
            bool num1;
            bool flag10;
            bool flag11;
            bool flag12;
            bool flag13;
            bool flag14;
            bool flag15;
            bool flag16;
            bool flag17;
            bool flag18;
            bool flag19;
            bool flag20;
            bool flag21;
            bool flag22;
            int num2 = 0;
            foreach (KundliMappingVO kundliMappingVO in lkmv)
            {
                lkmv[num2].IsBad = false;
                if (kundliMappingVO.PlanetName != "Guru")
                {
                    flag = true;
                }
                else
                {
                    flag = (kundliMappingVO.House == 6 || kundliMappingVO.House == 7 ? false : kundliMappingVO.House != 10);
                }
                if (!flag)
                {
                    lkmv[num2].IsBad = true;
                }
                if (kundliMappingVO.PlanetName != "Chandra")
                {
                    flag1 = true;
                }
                else
                {
                    flag1 = (kundliMappingVO.House == 6 || kundliMappingVO.House == 8 || kundliMappingVO.House == 10 || kundliMappingVO.House == 11 ? false : kundliMappingVO.House != 12);
                }
                if (!flag1)
                {
                    lkmv[num2].IsBad = true;
                }
                if (kundliMappingVO.PlanetName != "Shukra")
                {
                    flag2 = true;
                }
                else
                {
                    flag2 = (kundliMappingVO.House == 1 || kundliMappingVO.House == 6 || kundliMappingVO.House == 9 ? false : kundliMappingVO.House != 8);
                }
                if (!flag2)
                {
                    lkmv[num2].IsBad = true;
                }
                if (kundliMappingVO.PlanetName != "Mangal")
                {
                    flag3 = true;
                }
                else
                {
                    flag3 = (kundliMappingVO.House == 4 ? false : kundliMappingVO.House != 8);
                }
                if (!flag3)
                {
                    lkmv[num2].IsBad = true;
                }
                if (kundliMappingVO.PlanetName != "Budh")
                {
                    flag4 = true;
                }
                else
                {
                    flag4 = (kundliMappingVO.House == 3 || kundliMappingVO.House == 8 || kundliMappingVO.House == 9 || kundliMappingVO.House == 10 || kundliMappingVO.House == 11 ? false : kundliMappingVO.House != 12);
                }
                if (!flag4)
                {
                    lkmv[num2].IsBad = true;
                }
                if (kundliMappingVO.PlanetName != "Shani")
                {
                    flag5 = true;
                }
                else
                {
                    flag5 = (kundliMappingVO.House == 1 || kundliMappingVO.House == 4 || kundliMappingVO.House == 5 ? false : kundliMappingVO.House != 6);
                }
                if (!flag5)
                {
                    lkmv[num2].IsBad = true;
                }
                if (kundliMappingVO.PlanetName != "Rahu")
                {
                    flag6 = true;
                }
                else
                {
                    flag6 = (kundliMappingVO.House == 1 || kundliMappingVO.House == 2 || kundliMappingVO.House == 5 || kundliMappingVO.House == 7 || kundliMappingVO.House == 8 || kundliMappingVO.House == 9 || kundliMappingVO.House == 10 || kundliMappingVO.House == 11 ? false : kundliMappingVO.House != 12);
                }
                if (!flag6)
                {
                    lkmv[num2].IsBad = true;
                }
                if (kundliMappingVO.PlanetName != "Ketu")
                {
                    flag7 = true;
                }
                else
                {
                    flag7 = (kundliMappingVO.House == 3 || kundliMappingVO.House == 4 || kundliMappingVO.House == 5 || kundliMappingVO.House == 6 ? false : kundliMappingVO.House != 8);
                }
                if (!flag7)
                {
                    lkmv[num2].IsBad = true;
                }
                if ((kundliMappingVO.PlanetName != "Surya" ? false : Convert.ToInt64((
                    from Map in lkmv
                    where Map.PlanetName.Contains("Surya")
                    select Map.House).SingleOrDefault<int>()) == (long)1))
                {
                    lkmv[num2].IsBad = false;
                }
                if ((kundliMappingVO.PlanetName != "Surya" ? false : Convert.ToInt64((
                    from Map in lkmv
                    where Map.PlanetName.Contains("Ketu")
                    select Map.House).SingleOrDefault<int>()) == (long)1))
                {
                    lkmv[num2].IsBad = false;
                }
                if ((kundliMappingVO.PlanetName != "Surya" ? false : Convert.ToInt64((
                    from Map in lkmv
                    where Map.PlanetName.Contains("Rahu")
                    select Map.House).SingleOrDefault<int>()) == (long)1))
                {
                    lkmv[num2].IsBad = true;
                }
                if ((kundliMappingVO.PlanetName != "Guru" ? false : Convert.ToInt64((
                    from Map in lkmv
                    where Map.PlanetName.Contains("Budh")
                    select Map.House).SingleOrDefault<int>()) == (long)2))
                {
                    lkmv[num2].IsBad = true;
                }
                if ((kundliMappingVO.PlanetName != "Chandra" ? false : Convert.ToInt64((
                    from Map in lkmv
                    where Map.PlanetName.Contains("Budh")
                    select Map.House).SingleOrDefault<int>()) == (long)4))
                {
                    lkmv[num2].IsBad = true;
                }
                if ((kundliMappingVO.PlanetName != "Surya" ? false : Convert.ToInt64((
                    from Map in lkmv
                    where Map.PlanetName.Contains("Mangal")
                    select Map.House).SingleOrDefault<int>()) == (long)6))
                {
                    lkmv[num2].IsBad = false;
                }
                if (kundliMappingVO.PlanetName != "Surya")
                {
                    num = true;
                }
                else
                {
                    if (Convert.ToInt64((
                        from Map in lkmv
                        where Map.PlanetName.Contains("Rahu")
                        select Map.House).SingleOrDefault<int>()) != (long)5)
                    {
                        if (Convert.ToInt64((
                            from Map in lkmv
                            where Map.PlanetName.Contains("Shukra")
                            select Map.House).SingleOrDefault<int>()) == (long)5)
                        {
                            goto Label1;
                        }
                        num = Convert.ToInt64((
                            from Map in lkmv
                            where Map.PlanetName.Contains("Shani")
                            select Map.House).SingleOrDefault<int>()) != (long)5;
                        goto Label0;
                    }
                    Label1:
                    num = false;
                    Label0: { }

                }
                if (!num)
                {
                    lkmv[num2].IsBad = true;
                }
                if ((kundliMappingVO.PlanetName != "Ketu" ? false : Convert.ToInt64((
                    from Map in lkmv
                    where Map.PlanetName.Contains("Mangal")
                    select Map.House).SingleOrDefault<int>()) == (long)6))
                {
                    lkmv[num2].IsBad = true;
                }
                if ((kundliMappingVO.PlanetName != "Guru" ? false : Convert.ToInt64((
                    from Map in lkmv
                    where Map.PlanetName.Contains("Rahu")
                    select Map.House).SingleOrDefault<int>()) == (long)11))
                {
                    lkmv[num2].IsBad = true;
                }
                if (kundliMappingVO.PlanetName != "Chandra")
                {
                    flag8 = true;
                }
                else
                {
                    flag8 = (Convert.ToInt64((
                        from Map in lkmv
                        where Map.PlanetName.Contains("Ketu")
                        select Map.House).SingleOrDefault<int>()) != (long)11 ? true : Convert.ToInt64((
                        from Map in lkmv
                        where Map.PlanetName.Contains("Budh")
                        select Map.House).SingleOrDefault<int>()) == (long)9);
                }
                if (!flag8)
                {
                    lkmv[num2].IsBad = true;
                }
                if ((kundliMappingVO.PlanetName != "Rahu" ? false : Convert.ToInt64((
                    from Map in lkmv
                    where Map.PlanetName.Contains("Mangal")
                    select Map.House).SingleOrDefault<int>()) == (long)12))
                {
                    lkmv[num2].IsBad = false;
                }
                if ((!(kundliMappingVO.PlanetName == "Mangal") || kundliMappingVO.House != 1 ? false : Convert.ToInt64((
                    from Map in lkmv
                    where Map.PlanetName.Contains("Shani")
                    select Map.House).SingleOrDefault<int>()) == (long)7))
                {
                    lkmv[num2].IsBad = true;
                }
                if ((!(kundliMappingVO.PlanetName == "Mangal") || kundliMappingVO.House != 4 ? false : Convert.ToInt64((
                    from Map in lkmv
                    where Map.PlanetName.Contains("Shani")
                    select Map.House).SingleOrDefault<int>()) == (long)10))
                {
                    lkmv[num2].IsBad = true;
                }
                if ((!(kundliMappingVO.PlanetName == "Mangal") || kundliMappingVO.House != 5 ? false : Convert.ToInt64((
                    from Map in lkmv
                    where Map.PlanetName.Contains("Shani")
                    select Map.House).SingleOrDefault<int>()) == (long)11))
                {
                    lkmv[num2].IsBad = true;
                }
                if ((!(kundliMappingVO.PlanetName == "Mangal") || kundliMappingVO.House != 6 ? false : Convert.ToInt64((
                    from Map in lkmv
                    where Map.PlanetName.Contains("Shani")
                    select Map.House).SingleOrDefault<int>()) == (long)12))
                {
                    lkmv[num2].IsBad = true;
                }
                if ((kundliMappingVO.PlanetName != "Mangal" ? false : Convert.ToInt64((
                    from Map in lkmv
                    where Map.PlanetName.Contains("Shukra")
                    select Map.House).SingleOrDefault<int>()) == (long)8))
                {
                    lkmv[num2].IsBad = true;
                }
                if (kundliMappingVO.PlanetName != "Ketu")
                {
                    flag9 = true;
                }
                else
                {
                    flag9 = (Convert.ToInt64((
                        from Map in lkmv
                        where Map.PlanetName.Contains("Chandra")
                        select Map.House).SingleOrDefault<int>()) == (long)11 ? false : Convert.ToInt64((
                        from Map in lkmv
                        where Map.PlanetName.Contains("Chandra")
                        select Map.House).SingleOrDefault<int>()) != (long)12);
                }
                if (!flag9)
                {
                    lkmv[num2].IsBad = true;
                }
                if ((kundliMappingVO.PlanetName != "Ketu" ? false : Convert.ToInt64((
                    from Map in lkmv
                    where Map.PlanetName.Contains("Budh")
                    select Map.House).SingleOrDefault<int>()) < Convert.ToInt64((
                    from Map in lkmv
                    where Map.PlanetName.Contains("Shukra")
                    select Map.House).SingleOrDefault<int>())))
                {
                    lkmv[num2].IsBad = false;
                }
                if ((kundliMappingVO.PlanetName != "Rahu" ? false : Convert.ToInt64((
                    from Map in lkmv
                    where Map.PlanetName.Contains("Budh")
                    select Map.House).SingleOrDefault<int>()) > Convert.ToInt64((
                    from Map in lkmv
                    where Map.PlanetName.Contains("Shukra")
                    select Map.House).SingleOrDefault<int>())))
                {
                    lkmv[num2].IsBad = true;
                }
                if (kundliMappingVO.PlanetName != "Mangal")
                {
                    num1 = true;
                }
                else
                {
                    if (Convert.ToInt64((
                        from Map in lkmv
                        where Map.PlanetName.Contains("Ketu")
                        select Map.House).SingleOrDefault<int>()) != (long)3)
                    {
                        if (Convert.ToInt64((
                            from Map in lkmv
                            where Map.PlanetName.Contains("Ketu")
                            select Map.House).SingleOrDefault<int>()) == (long)8)
                        {
                            goto Label3;
                        }
                        num1 = Convert.ToInt64((
                            from Map in lkmv
                            where Map.PlanetName.Contains("Shukra")
                            select Map.House).SingleOrDefault<int>()) != (long)9;
                        goto Label2;
                    }
                    Label3:
                    num1 = false;
                    Label2: { }

                }
                if (!num1)
                {
                    lkmv[num2].IsBad = true;
                }
                if (kundliMappingVO.PlanetName != "Budh")
                {
                    flag10 = true;
                }
                else
                {
                    flag10 = (Convert.ToInt64((
                        from Map in lkmv
                        where Map.PlanetName.Contains("Rahu")
                        select Map.House).SingleOrDefault<int>()) == (long)7 ? false : Convert.ToInt64((
                        from Map in lkmv
                        where Map.PlanetName.Contains("Mangal")
                        select Map.House).SingleOrDefault<int>()) != (long)6);
                }
                if (!flag10)
                {
                    lkmv[num2].IsBad = true;
                }
                if ((kundliMappingVO.PlanetName != "Shani" ? false : Convert.ToInt64((
                    from Map in lkmv
                    where Map.PlanetName.Contains("Chandra")
                    select Map.House).SingleOrDefault<int>()) == (long)11))
                {
                    lkmv[num2].IsBad = true;
                }
                if ((kundliMappingVO.PlanetName != "Shukra" ? false : Convert.ToInt64((
                    from Map in lkmv
                    where Map.PlanetName.Contains("Rahu")
                    select Map.House).SingleOrDefault<int>()) == (long)7))
                {
                    lkmv[num2].IsBad = true;
                }
                if (kundliMappingVO.PlanetName == "Rahu" || kundliMappingVO.PlanetName == "Budh")
                {
                    flag11 = (Convert.ToInt64((
                        from Map in lkmv
                        where Map.PlanetName.Contains("Surya")
                        select Map.House).SingleOrDefault<int>()) != (long)3 ? true : Convert.ToInt64((
                        from Map in lkmv
                        where Map.PlanetName.Contains("Budh")
                        select Map.House).SingleOrDefault<int>()) != (long)3);
                }
                else
                {
                    flag11 = true;
                }
                if (!flag11)
                {
                    lkmv[num2].IsBad = false;
                }
                long num3 = Convert.ToInt64((
                    from Map in lkmv
                    where Map.PlanetName.Contains("Surya")
                    select Map.House).SingleOrDefault<int>());
                long num4 = Convert.ToInt64((
                    from Map in lkmv
                    where Map.PlanetName.Contains("Rahu")
                    select Map.House).SingleOrDefault<int>());
                long num5 = Convert.ToInt64((
                    from Map in lkmv
                    where Map.PlanetName.Contains("Ketu")
                    select Map.House).SingleOrDefault<int>());
                long num6 = Convert.ToInt64((
                    from Map in lkmv
                    where Map.PlanetName.Contains("Shani")
                    select Map.House).SingleOrDefault<int>());
                long num7 = Convert.ToInt64((
                    from Map in lkmv
                    where Map.PlanetName.Contains("Budh")
                    select Map.House).SingleOrDefault<int>());
                long num8 = Convert.ToInt64((
                    from Map in lkmv
                    where Map.PlanetName.Contains("Shukra")
                    select Map.House).SingleOrDefault<int>());
                long num9 = Convert.ToInt64((
                    from Map in lkmv
                    where Map.PlanetName.Contains("Mangal")
                    select Map.House).SingleOrDefault<int>());
                long num10 = Convert.ToInt64((
                    from Map in lkmv
                    where Map.PlanetName.Contains("Chandra")
                    select Map.House).SingleOrDefault<int>());
                long num11 = Convert.ToInt64((
                    from Map in lkmv
                    where Map.PlanetName.Contains("Guru")
                    select Map.House).SingleOrDefault<int>());
                if (kundliMappingVO.PlanetName == "Budh")
                {
                    if ((num4 == num7 ? true : Convert.ToInt64((
                        from Map in lkmv
                        where Map.PlanetName.Contains("Shani")
                        select Map.House).SingleOrDefault<int>()) == (long)6))
                    {
                        lkmv[num2].IsBad = true;
                    }
                }
                if ((kundliMappingVO.PlanetName == "Rahu" ? true : kundliMappingVO.PlanetName == "Budh"))
                {
                    if (num4 == num7)
                    {
                        if (num4 <= (long)6)
                        {
                            lkmv[num2].IsBad = false;
                        }
                        if (num4 >= (long)7)
                        {
                            lkmv[num2].IsBad = true;
                        }
                    }
                }
                if (kundliMappingVO.PlanetName == "Rahu")
                {
                    long num12 = (long)0;
                    long num13 = (long)0;
                    long num14 = (long)0;
                    long num15 = (long)0;
                    if ((num6 < (long)1 ? false : num6 <= (long)10))
                    {
                        num12 = num6 + (long)2;
                    }
                    if ((num6 < (long)11 ? false : num6 <= (long)12))
                    {
                        num12 = num6 - (long)10;
                    }
                    if ((num6 < (long)1 ? false : num6 <= (long)6))
                    {
                        num13 = num6 + (long)6;
                    }
                    if ((num6 < (long)7 ? false : num6 <= (long)12))
                    {
                        num13 = num6 - (long)6;
                    }
                    if ((num6 < (long)1 ? false : num6 <= (long)5))
                    {
                        num14 = num6 + (long)7;
                    }
                    if ((num6 < (long)6 ? false : num6 <= (long)12))
                    {
                        num14 = num6 - (long)5;
                    }
                    if ((num6 < (long)1 ? false : num6 <= (long)3))
                    {
                        num15 = num6 + (long)9;
                    }
                    if ((num6 < (long)4 ? false : num6 <= (long)12))
                    {
                        num15 = num6 - (long)3;
                    }
                    if ((num12 == num4 || num13 == num4 || num14 == num4 ? true : num15 == num4))
                    {
                        lkmv[num2].IsBad = true;
                    }
                }
                if ((kundliMappingVO.PlanetName == "Guru" ? true : kundliMappingVO.PlanetName == "Chandra"))
                {
                    if (num4 == num7)
                    {
                        lkmv[num2].IsBad = true;
                    }
                }
                if (kundliMappingVO.PlanetName == "Chandra")
                {
                    if ((num11 > (long)6 ? false : num5 >= (long)7))
                    {
                        lkmv[num2].IsBad = true;
                    }
                    if ((num6 != (long)4 ? false : num4 == (long)4))
                    {
                        lkmv[num2].IsBad = true;
                    }
                }
                if (kundliMappingVO.PlanetName == "Surya")
                {
                    if ((num3 != num4 ? false : num3 == num6))
                    {
                        lkmv[num2].IsBad = true;
                    }
                    if (num3 == num4)
                    {
                        lkmv[num2].IsBad = true;
                    }
                    if (num4 == (long)1)
                    {
                        lkmv[num2].IsBad = true;
                    }
                    if (num3 == num9)
                    {
                        lkmv[num2].IsBad = false;
                    }
                    if ((num3 != (long)10 || num11 != (long)4 ? false : num10 == (long)4))
                    {
                        lkmv[num2].IsBad = false;
                    }
                    if ((num7 != (long)4 ? false : num8 == (long)4))
                    {
                        lkmv[num2].IsBad = false;
                    }
                    if ((num6 == (long)1 || num6 == (long)5 || num4 == (long)1 || num4 == (long)5 || num8 == (long)1 ? true : num8 == (long)5))
                    {
                        lkmv[num2].IsBad = true;
                    }
                }
                if (kundliMappingVO.PlanetName == "Guru")
                {
                    if ((num4 == (long)2 || num4 == (long)5 || num4 == (long)9 || num4 == (long)11 || num4 == (long)12 || num6 == (long)2 || num6 == (long)5 || num6 == (long)9 || num6 == (long)11 || num6 == (long)12 || num7 == (long)2 || num7 == (long)5 || num7 == (long)9 || num7 == (long)11 || num7 == (long)12 || num8 == (long)2 || num8 == (long)5 || num8 == (long)9 || num8 == (long)11 ? true : num8 == (long)12))
                    {
                        lkmv[num2].IsBad = true;
                    }
                }
                if (kundliMappingVO.PlanetName == "Ketu")
                {
                    if ((num9 != num5 ? false : num9 == num10))
                    {
                        lkmv[num2].IsBad = true;
                    }
                    if (num6 == num10)
                    {
                        lkmv[num2].IsBad = true;
                    }
                    if (num7 < (long)1 || num7 > (long)6)
                    {
                        flag22 = true;
                    }
                    else
                    {
                        flag22 = (num8 < (long)7 ? true : num8 > (long)12);
                    }
                    if (!flag22)
                    {
                        lkmv[num2].IsBad = false;
                    }
                    if (num5 == num7)
                    {
                        lkmv[num2].IsBad = true;
                    }
                }
                if (kundliMappingVO.PlanetName == "Shani")
                {
                    if ((num4 >= num6 ? false : num5 > num6))
                    {
                        lkmv[num2].IsBad = true;
                    }
                    if ((num4 >= num5 ? false : num6 > num5))
                    {
                        lkmv[num2].IsBad = true;
                    }
                    if ((num4 != num5 ? false : num6 > num5))
                    {
                        lkmv[num2].IsBad = true;
                    }
                    if ((num6 != num5 ? false : num4 < num6))
                    {
                        lkmv[num2].IsBad = true;
                    }
                    if ((num4 != num6 ? false : num5 > num6))
                    {
                        lkmv[num2].IsBad = true;
                    }
                    if ((num6 >= num4 ? false : num5 > num4))
                    {
                        lkmv[num2].IsBad = true;
                    }
                    if ((num6 != (long)1 ? false : num4 == (long)1))
                    {
                        lkmv[num2].IsBad = false;
                    }
                    if (num3 == (long)10)
                    {
                        lkmv[num2].IsBad = true;
                    }
                }
                if ((kundliMappingVO.PlanetName == "Shani" || kundliMappingVO.PlanetName == "Chandra" ? true : kundliMappingVO.PlanetName == "Rahu"))
                {
                    if (num7 == num8)
                    {
                        lkmv[num2].IsBad = false;
                    }
                }
                if (kundliMappingVO.PlanetName == "Guru")
                {
                    if (this.Is_Mangal_Bad(lkmv) == 2)
                    {
                        if ((
                            from Map in lkmv
                            where Map.PlanetName.Contains("Shani")
                            select Map.IsBad).SingleOrDefault<bool>())
                        {
                            if (!(
                                from Map in lkmv
                                where Map.PlanetName.Contains("Rahu")
                                select Map.IsBad).SingleOrDefault<bool>())
                            {
                                goto Label5;
                            }
                            flag21 = !(
                                from Map in lkmv
                                where Map.PlanetName.Contains("Ketu")
                                select Map.IsBad).SingleOrDefault<bool>();
                            goto Label4;
                        }
                    }
                    Label5:
                    flag21 = true;
                    Label4:
                    if (!flag21)
                    {
                        lkmv[num2].IsBad = true;
                    }
                    if ((num5 > (long)6 ? false : num11 >= (long)7))
                    {
                        lkmv[num2].IsBad = true;
                    }
                }
                if ((kundliMappingVO.PlanetName == "Guru" || kundliMappingVO.PlanetName == "Chandra" ? true : kundliMappingVO.PlanetName == "Rahu"))
                {
                    if ((num11 != num10 ? false : num4 == num11))
                    {
                        if (num11 > (long)11)
                        {
                            lkmv[num2].IsBad = true;
                        }
                        else
                        {
                            lkmv[num2].IsBad = false;
                        }
                    }
                }
                if (kundliMappingVO.PlanetName == "Rahu")
                {
                    if ((num3 != num8 ? false : (
                        from Map in lkmv
                        where (long)Map.House == num3
                        select Map).Count<KundliMappingVO>() == 2))
                    {
                        lkmv[num2].IsBad = true;
                    }
                }
                if ((kundliMappingVO.PlanetName == "Shukra" ? true : kundliMappingVO.PlanetName == "Ketu"))
                {
                    if (num8 == num5)
                    {
                        if ((num8 == (long)2 || num8 == (long)5 || num8 == (long)6 || num8 == (long)9 || num8 == (long)11 ? true : num8 == (long)12))
                        {
                            lkmv[num2].IsBad = false;
                        }
                    }
                }
                if ((kundliMappingVO.PlanetName != "Budh" ? false : (
                    from Map in lkmv
                    where (long)Map.House == num7
                    select Map).Count<KundliMappingVO>() == 1))
                {
                    if (num7 == (long)1)
                    {
                        lkmv[Convert.ToInt16((
                            from Map in lkmv
                            where (Map.House != 9 ? false : Map.PlanetName.Contains("Mangal"))
                            select Map.Sno).SingleOrDefault<long>())].IsBad = true;
                    }
                    if (num7 == (long)2)
                    {
                        lkmv[Convert.ToInt16((
                            from Map in lkmv
                            where (Map.House != 9 ? false : Map.PlanetName.Contains("Shukra"))
                            select Map.Sno).SingleOrDefault<long>())].IsBad = true;
                    }
                    if (num7 == (long)3)
                    {
                        lkmv[Convert.ToInt16((
                            from Map in lkmv
                            where (Map.House != 9 ? false : Map.PlanetName.Contains("Shukra"))
                            select Map.Sno).SingleOrDefault<long>())].IsBad = true;
                    }
                    if (num7 == (long)4)
                    {
                        lkmv[Convert.ToInt16((
                            from Map in lkmv
                            where (Map.House != 9 ? false : Map.PlanetName.Contains("Chandra"))
                            select Map.Sno).SingleOrDefault<long>())].IsBad = true;
                    }
                    if (num7 == (long)5)
                    {
                        lkmv[Convert.ToInt16((
                            from Map in lkmv
                            where (Map.House != 9 ? false : Map.PlanetName.Contains("Surya"))
                            select Map.Sno).SingleOrDefault<long>())].IsBad = true;
                    }
                    if (num7 == (long)6)
                    {
                        lkmv[Convert.ToInt16((
                            from Map in lkmv
                            where (Map.House != 9 ? false : Map.PlanetName.Contains("Ketu"))
                            select Map.Sno).SingleOrDefault<long>())].IsBad = true;
                    }
                    if (num7 == (long)7)
                    {
                        lkmv[Convert.ToInt16((
                            from Map in lkmv
                            where (Map.House != 9 ? false : Map.PlanetName.Contains("Shukra"))
                            select Map.Sno).SingleOrDefault<long>())].IsBad = true;
                    }
                    if (num7 == (long)8)
                    {
                        lkmv[Convert.ToInt16((
                            from Map in lkmv
                            where (Map.House != 9 ? false : Map.PlanetName.Contains("Mangal"))
                            select Map.Sno).SingleOrDefault<long>())].IsBad = true;
                    }
                    if (num7 == (long)9)
                    {
                        lkmv[Convert.ToInt16((
                            from Map in lkmv
                            where (Map.House != 9 ? false : Map.PlanetName.Contains("Guru"))
                            select Map.Sno).SingleOrDefault<long>())].IsBad = true;
                    }
                    if (num7 == (long)10)
                    {
                        lkmv[Convert.ToInt16((
                            from Map in lkmv
                            where (Map.House != 9 ? false : Map.PlanetName.Contains("Shani"))
                            select Map.Sno).SingleOrDefault<long>())].IsBad = true;
                    }
                    if (num7 == (long)11)
                    {
                        lkmv[Convert.ToInt16((
                            from Map in lkmv
                            where (Map.House != 9 ? false : Map.PlanetName.Contains("Shani"))
                            select Map.Sno).SingleOrDefault<long>())].IsBad = true;
                    }
                    if (num7 == (long)12)
                    {
                        lkmv[Convert.ToInt16((
                            from Map in lkmv
                            where (Map.House != 9 ? false : Map.PlanetName.Contains("Rahu"))
                            select Map.Sno).SingleOrDefault<long>())].IsBad = true;
                        lkmv[Convert.ToInt16((
                            from Map in lkmv
                            where (Map.House != 9 ? false : Map.PlanetName.Contains("Guru"))
                            select Map.Sno).SingleOrDefault<long>())].IsBad = true;
                    }
                }
                if ((kundliMappingVO.PlanetName == "Surya" || kundliMappingVO.PlanetName == "Guru" || kundliMappingVO.PlanetName == "Rahu" || kundliMappingVO.PlanetName == "Shani" ? true : kundliMappingVO.PlanetName == "Budh"))
                {
                    if ((num11 != num3 ? false : num4 == num11))
                    {
                        lkmv[num2].IsBad = true;
                    }
                }
                if (kundliMappingVO.PlanetName == "Shani")
                {
                    if ((num10 == (long)10 ? true : num3 == (long)10))
                    {
                        lkmv[num2].IsBad = true;
                    }
                }
                if (kundliMappingVO.PlanetName == "Mangal")
                {
                    if (this.Is_Mangal_Bad(lkmv) == 2)
                    {
                        lkmv[num2].IsBad = true;
                    }
                }
                if (kundliMappingVO.PlanetName == "Rahu")
                {
                    if (num3 != (long)3 || num7 != (long)3)
                    {
                        flag20 = true;
                    }
                    else if (!(
                        from Map in lkmv
                        where Map.PlanetName.Contains("Shukra")
                        select Map.IsBad).SingleOrDefault<bool>())
                    {
                        flag20 = false;
                    }
                    else
                    {
                        flag20 = (num8 == (long)2 || num8 == (long)7 ? false : num8 != (long)12);
                    }
                    if (!flag20)
                    {
                        lkmv[num2].IsBad = false;
                    }
                }
                if (kundliMappingVO.PlanetName == "Guru")
                {
                    if ((num3 != (long)10 ? false : num10 == (long)4))
                    {
                        lkmv[num2].IsBad = true;
                    }
                }
                if (!(kundliMappingVO.PlanetName == "Surya") || num3 != (long)1)
                {
                    flag12 = true;
                }
                else
                {
                    flag12 = (num8 == (long)7 || num4 == (long)7 || num5 == (long)7 ? false : num6 != (long)7);
                }
                if (!flag12)
                {
                    lkmv[num2].IsBad = true;
                }
                if (!(kundliMappingVO.PlanetName == "Chandra") || num10 != (long)2)
                {
                    flag13 = true;
                }
                else
                {
                    flag13 = (num8 == (long)6 || num8 == (long)12 || num7 == (long)6 ? false : num7 != (long)12);
                }
                if (!flag13)
                {
                    lkmv[num2].IsBad = true;
                }
                if (!(kundliMappingVO.PlanetName == "Mangal") || num9 != (long)10)
                {
                    flag14 = true;
                }
                else
                {
                    flag14 = (num5 == (long)2 ? false : num7 != (long)2);
                }
                if (!flag14)
                {
                    lkmv[num2].IsBad = true;
                }
                if (!(kundliMappingVO.PlanetName == "Guru") || num11 != (long)4)
                {
                    flag15 = true;
                }
                else
                {
                    flag15 = (num8 == (long)10 ? false : num7 != (long)10);
                }
                if (!flag15)
                {
                    lkmv[num2].IsBad = true;
                }
                if (!(kundliMappingVO.PlanetName == "Shukra") || num8 != (long)12)
                {
                    flag16 = true;
                }
                else
                {
                    flag16 = (num3 == (long)2 || num10 == (long)2 ? false : num4 != (long)2);
                }
                if (!flag16)
                {
                    lkmv[num2].IsBad = true;
                }
                if (!(kundliMappingVO.PlanetName == "Shani") || num6 != (long)7)
                {
                    flag17 = true;
                }
                else
                {
                    flag17 = (num3 == (long)1 || num10 == (long)1 ? false : num9 != (long)1);
                }
                if (!flag17)
                {
                    lkmv[num2].IsBad = true;
                }
                if (!(kundliMappingVO.PlanetName == "Rahu") || num4 < (long)3 || num4 > (long)6)
                {
                    flag18 = true;
                }
                else
                {
                    flag18 = (num3 == (long)12 || num8 == (long)12 ? false : num9 != (long)12);
                }
                if (!flag18)
                {
                    lkmv[num2].IsBad = true;
                }
                if (!(kundliMappingVO.PlanetName == "Ketu") || num5 != (long)9 && num5 != (long)12)
                {
                    flag19 = true;
                }
                else
                {
                    flag19 = (num10 == (long)2 ? false : num9 != (long)2);
                }
                if (!flag19)
                {
                    lkmv[num2].IsBad = true;
                }
                if ((kundliMappingVO.PlanetName != "Rahu" ? false : num4 == (long)12))
                {
                    lkmv[Convert.ToInt16((
                        from Map in lkmv
                        where (Map.House != 12 ? false : Map.PlanetName.Contains("Rahu"))
                        select Map.Sno).SingleOrDefault<long>())].IsBad = lkmv[Convert.ToInt16((
                        from Map in lkmv
                        where Map.PlanetName.Contains("Budh")
                        select Map.Sno).SingleOrDefault<long>())].IsBad;
                }
                if ((kundliMappingVO.PlanetName != "Ketu" ? false : num4 == (long)6))
                {
                    lkmv[Convert.ToInt16((
                        from Map in lkmv
                        where (Map.House != 6 ? false : Map.PlanetName.Contains("Ketu"))
                        select Map.Sno).SingleOrDefault<long>())].IsBad = lkmv[Convert.ToInt16((
                        from Map in lkmv
                        where Map.PlanetName.Contains("Guru")
                        select Map.Sno).SingleOrDefault<long>())].IsBad;
                }
                num2++;
            }
        }

        public void Process_VarshPlanet_GoodBad(List<KundliMappingVO> lkmv1, ref List<KundliMappingVO> Vlkmv, DateTime dt, DateTime tm, long age, KundliVO persKV)
        {
            int num = 0;
            int isBad = 0;
            int num1 = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            foreach (KundliMappingVO vlkmv in Vlkmv)
            {
                int house = vlkmv.House;
                int planet = vlkmv.Planet;
                num1 = 0;
                num2 = 0;
                num3 = 0;
                num4 = 0;
                int num5 = 0;
                Vlkmv[isBad].VIsBad = false;
                List<KundliMappingVO> kundliMappingVOs = new List<KundliMappingVO>();
                if ((house < 1 ? false : house <= 5))
                {
                    num = house + 7;
                }
                if ((house < 6 ? false : house <= 12))
                {
                    num = house - 5;
                }
                if (Convert.ToInt16((
                    from Map in Vlkmv
                    where Map.House == num
                    select Map).ToList<KundliMappingVO>().Count) > 0)
                {
                    Vlkmv[isBad].VIsBad = true;
                }
                if ((house != 3 ? false : vlkmv.PlanetName == "Surya"))
                {
                    num1 = Convert.ToInt16((
                        from Map in Vlkmv
                        where Map.Planet == 3
                        select Map.House).SingleOrDefault<int>());
                    num3 = Convert.ToInt16((
                        from Map in Vlkmv
                        where Map.Planet == 1
                        select Map.House).SingleOrDefault<int>());
                    num4 = Convert.ToInt16((
                        from Map in Vlkmv
                        where Map.Planet == 7
                        select Map.House).SingleOrDefault<int>());
                    num2 = Convert.ToInt16((
                        from Map in Vlkmv
                        where Map.Planet == 8
                        select Map.House).SingleOrDefault<int>());
                    if ((num1 == 3 || num3 == 3 ? true : num4 == 3))
                    {
                        Vlkmv[isBad].VIsBad = true;
                    }
                }
                if ((house != 1 ? false : vlkmv.PlanetName == "Chandra"))
                {
                    if (Convert.ToInt16((
                        from Map in lkmv1
                        where Map.Planet == 4
                        select Map.House).SingleOrDefault<int>()) == 12)
                    {
                        Vlkmv[isBad].VIsBad = true;
                    }
                }
                if (vlkmv.PlanetName == "Guru")
                {
                    num1 = Convert.ToInt16((
                        from Map in lkmv1
                        where Map.Planet == 3
                        select Map.House).SingleOrDefault<int>());
                    num3 = Convert.ToInt16((
                        from Map in lkmv1
                        where Map.Planet == 1
                        select Map.House).SingleOrDefault<int>());
                    num2 = Convert.ToInt16((
                        from Map in lkmv1
                        where Map.Planet == 8
                        select Map.House).SingleOrDefault<int>());
                    num5 = Convert.ToInt16((
                        from Map in lkmv1
                        where Map.Planet == 2
                        select Map.House).SingleOrDefault<int>());
                    num4 = Convert.ToInt16((
                        from Map in lkmv1
                        where Map.Planet == 7
                        select Map.House).SingleOrDefault<int>());
                    if ((num4 == 2 || num4 == 5 || num4 == 9 || num4 == 11 || num4 == 12 || num1 == 2 || num1 == 5 || num1 == 9 || num1 == 11 || num1 == 12 || num3 == 2 || num3 == 5 || num3 == 9 || num3 == 11 || num3 == 12 || num2 == 2 || num2 == 5 || num2 == 9 || num2 == 11 ? true : num2 == 12))
                    {
                        Vlkmv[isBad].VIsBad = true;
                    }
                }
                Years35BLL years35BLL = new Years35BLL();
                long num6 = (long)0;
                long num7 = (long)0;
                KundliBLL kundliBLL = new KundliBLL();
                KundliMappingVO kundliMappingVO = new KundliMappingVO();
                List<Years35VO> years35VOs = years35BLL.Get35Years(persKV.JanamSamay);
                Years35VO years35VO = (
                    from Map in years35VOs
                    where Map.Years == age
                    select Map).SingleOrDefault<Years35VO>();
                if (years35VO.Planet == vlkmv.PlanetName)
                {
                    kundliMappingVO.PlanetName = years35VO.Planet;
                    num6 = (long)lkmv1.FindIndex((KundliMappingVO Map) => Map.PlanetName == years35VO.Planet);
                    num7 = (long)Vlkmv.FindIndex((KundliMappingVO Map) => Map.PlanetName == years35VO.Planet);
                    Vlkmv[isBad].VIsBad = lkmv1[isBad].IsBad;
                }
                if ((vlkmv.PlanetName != "Rahu" ? false : house == 7))
                {
                    Vlkmv[isBad].VIsBad = true;
                }
                isBad++;
            }
        }

        public List<KundliMappingVO> RotateKundliMappings(List<KundliMappingVO> lkmv_orig, int rotateno, KundliVO persKV)
        {
            List<KundliMappingVO> kundliMappingVOs = new List<KundliMappingVO>();
            int num = rotateno % 12;
            foreach (KundliMappingVO lkmvOrig in lkmv_orig)
            {
                lkmvOrig.House = lkmvOrig.House + num;
                if (lkmvOrig.House > 12)
                {
                    lkmvOrig.House = lkmvOrig.House - 12;
                    if ((long)lkmvOrig.House + (persKV.Lagna - (long)1) <= (long)12)
                    {
                        lkmvOrig.Rashi = Convert.ToInt32((long)lkmvOrig.House + (persKV.Lagna - (long)1));
                    }
                    else
                    {
                        lkmvOrig.Rashi = Convert.ToInt32((long)lkmvOrig.House + (persKV.Lagna - (long)1) - (long)12);
                    }
                }
                kundliMappingVOs.Add(lkmvOrig);
            }
            return kundliMappingVOs;
        }
    }
}