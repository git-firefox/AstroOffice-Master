using ASDLL;
using AstroOfficeWeb.Shared.VOs;
using Kunda;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
//using AstroShared.Models;
namespace ASDLL.DataAccess.Core
{
    public class RuleBLL
    {
        public static List<PlanetHouseMappingVO> pakkerehlist;

        public static List<PlanetHouseMappingVO> mandegrehlist;

        public static List<PlanetHouseMappingVO> uchgrehlist;

        public static List<PlanetHouseMappingVO> neechgrehlist;

        public static List<PlanetHouseMappingVO> shreshtgrehlist;

        public static List<PlanetRelationsVO> planetrelationslist;

        public static List<PlanetVO> planetlist;

        static RuleBLL()
        {
            PlanetBLL planetBLL = new PlanetBLL();
            RuleBLL.pakkerehlist = planetBLL.GetPakkeGhar();
            RuleBLL.planetlist = planetBLL.GetAllPlanets();
            RuleBLL.mandegrehlist = planetBLL.GetAllMandeGhar();
            RuleBLL.shreshtgrehlist = planetBLL.GetAllShreshtGhar();
            RuleBLL.neechgrehlist = planetBLL.GetAllNeechGhar();
            RuleBLL.uchgrehlist = planetBLL.GetAllUchGhar();
            RuleBLL.planetrelationslist = planetBLL.GetAllPlanetRelations();
        }

        public RuleBLL()
        {
        }

        public void AddRule(RulesVO rv, LangVO pred, string lang)
        {
            (new RuleDAO()).AddRule(rv, pred, lang);
        }

        public int AddUpayIndex(int code, string lang, string upay)
        {
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "AddUpayIndex";
            DbParameter dbParameter = dbCommand.CreateParameter();
            dbParameter.ParameterName = "@code";
            dbParameter.DbType = DbType.Int32;
            dbParameter.Value = code;
            dbCommand.Parameters.Add(dbParameter);
            DbParameter dbParameter1 = dbCommand.CreateParameter();
            dbParameter1.ParameterName = "@lang";
            dbParameter1.DbType = DbType.String;
            dbParameter1.Value = lang;
            dbCommand.Parameters.Add(dbParameter1);
            DbParameter dbParameter2 = dbCommand.CreateParameter();
            dbParameter2.ParameterName = "@upay";
            dbParameter2.DbType = DbType.String;
            dbParameter2.Value = upay;
            dbCommand.Parameters.Add(dbParameter2);
            DbParameter dbParameter3 = dbCommand.CreateParameter();
            dbParameter3.ParameterName = "@sno";
            dbParameter3.DbType = DbType.Int32;
            dbParameter3.Direction = ParameterDirection.Output;
            dbCommand.Parameters.Add(dbParameter3);
            GenericDataAccess.ExecuteSelectCommand(dbCommand);
            return Convert.ToInt32(dbCommand.Parameters["@sno"].Value);
        }

        public List<DrishtiVO> CalcDrishti(List<KundliMappingVO> lkmv)
        {
            //KundliMappingVO kundliMappingVO = null;
            DrishtiVO drishtiVO;
            List<DrishtiVO> drishtiVOs = new List<DrishtiVO>();
            int num = 1;
            foreach (KundliMappingVO kundliMappingVO1 in lkmv)
            {
                List<KundliMappingVO> kundliMappingVOs = new List<KundliMappingVO>();
                switch (kundliMappingVO1.House)
                {
                    case 1:
                        {
                            kundliMappingVOs = (
                                from Map in lkmv
                                where Map.House == 7
                                select Map).ToList<KundliMappingVO>();
                            if (kundliMappingVOs.Count > 0)
                            {
                                foreach (KundliMappingVO kundliMappingVO in kundliMappingVOs)
                                {
                                    drishtiVO = new DrishtiVO()
                                    {
                                        Sno = num,
                                        Planet1 = kundliMappingVO.Planet,
                                        Planet2 = kundliMappingVO1.Planet,
                                        House1 = kundliMappingVO.House,
                                        House2 = kundliMappingVO1.House,
                                        Percentage = 100
                                    };
                                    num++;
                                    drishtiVOs.Add(drishtiVO);
                                }
                            }
                            goto case 7;
                        }
                    case 2:
                        {
                            kundliMappingVOs = (
                                from Map in lkmv
                                where (Map.House == 8 ? true : Map.House == 6)
                                select Map).ToList<KundliMappingVO>();
                            if (kundliMappingVOs.Count > 0)
                            {
                                foreach (KundliMappingVO kundliMappingVO2 in kundliMappingVOs)
                                {
                                    drishtiVO = new DrishtiVO()
                                    {
                                        Sno = num,
                                        Planet1 = kundliMappingVO2.Planet,
                                        Planet2 = kundliMappingVO1.Planet,
                                        House1 = kundliMappingVO2.House,
                                        House2 = kundliMappingVO1.House,
                                        Percentage = 100
                                    };
                                    num++;
                                    drishtiVOs.Add(drishtiVO);
                                }
                            }
                            goto case 7;
                        }
                    case 3:
                        {
                            kundliMappingVOs = (
                                from Map in lkmv
                                where (Map.House == 9 ? true : Map.House == 11)
                                select Map).ToList<KundliMappingVO>();
                            if (kundliMappingVOs.Count > 0)
                            {
                                foreach (KundliMappingVO kundliMappingVO3 in kundliMappingVOs)
                                {
                                    drishtiVO = new DrishtiVO()
                                    {
                                        Sno = num,
                                        Planet1 = kundliMappingVO3.Planet,
                                        Planet2 = kundliMappingVO1.Planet,
                                        House1 = kundliMappingVO3.House,
                                        House2 = kundliMappingVO1.House,
                                        Percentage = 50
                                    };
                                    num++;
                                    drishtiVOs.Add(drishtiVO);
                                }
                            }
                            goto case 7;
                        }
                    case 4:
                        {
                            kundliMappingVOs = (
                                from Map in lkmv
                                where Map.House == 10
                                select Map).ToList<KundliMappingVO>();
                            if (kundliMappingVOs.Count > 0)
                            {
                                foreach (KundliMappingVO kundliMappingVO4 in kundliMappingVOs)
                                {
                                    drishtiVO = new DrishtiVO()
                                    {
                                        Sno = num,
                                        Planet1 = kundliMappingVO4.Planet,
                                        Planet2 = kundliMappingVO1.Planet,
                                        House1 = kundliMappingVO4.House,
                                        House2 = kundliMappingVO1.House,
                                        Percentage = 100
                                    };
                                    num++;
                                    drishtiVOs.Add(drishtiVO);
                                }
                            }
                            goto case 7;
                        }
                    case 5:
                        {
                            kundliMappingVOs = (
                                from Map in lkmv
                                where (Map.House == 9 ? true : Map.House == 11)
                                select Map).ToList<KundliMappingVO>();
                            if (kundliMappingVOs.Count > 0)
                            {
                                foreach (KundliMappingVO kundliMappingVO5 in kundliMappingVOs)
                                {
                                    drishtiVO = new DrishtiVO()
                                    {
                                        Sno = num,
                                        Planet1 = kundliMappingVO5.Planet,
                                        Planet2 = kundliMappingVO1.Planet,
                                        House1 = kundliMappingVO5.House,
                                        House2 = kundliMappingVO1.House,
                                        Percentage = 50
                                    };
                                    num++;
                                    drishtiVOs.Add(drishtiVO);
                                }
                            }
                            goto case 7;
                        }
                    case 6:
                        {
                            kundliMappingVOs = (
                                from Map in lkmv
                                where (Map.House == 2 ? true : Map.House == 12)
                                select Map).ToList<KundliMappingVO>();
                            if (kundliMappingVOs.Count > 0)
                            {
                                foreach (KundliMappingVO kundliMappingVO6 in kundliMappingVOs)
                                {
                                    drishtiVO = new DrishtiVO()
                                    {
                                        Sno = num,
                                        Planet1 = kundliMappingVO6.Planet,
                                        Planet2 = kundliMappingVO1.Planet,
                                        House1 = kundliMappingVO6.House,
                                        House2 = kundliMappingVO1.House,
                                        Percentage = 25
                                    };
                                    num++;
                                    drishtiVOs.Add(drishtiVO);
                                }
                            }
                            goto case 7;
                        }
                    case 7:
                        {
                            continue;
                        }
                    case 8:
                        {
                            kundliMappingVOs = (
                                from Map in lkmv
                                where Map.House == 2
                                select Map).ToList<KundliMappingVO>();
                            if (kundliMappingVOs.Count > 0)
                            {
                                foreach (KundliMappingVO kundliMappingVO7 in kundliMappingVOs)
                                {
                                    drishtiVO = new DrishtiVO()
                                    {
                                        Sno = num,
                                        Planet1 = kundliMappingVO7.Planet,
                                        Planet2 = kundliMappingVO1.Planet,
                                        House1 = kundliMappingVO7.House,
                                        House2 = kundliMappingVO1.House,
                                        Percentage = 25
                                    };
                                    num++;
                                    drishtiVOs.Add(drishtiVO);
                                }
                            }
                            goto case 7;
                        }
                    default:
                        {
                            goto case 7;
                        }
                }
            }
            return drishtiVOs;
        }

        public List<KundliMappingVO> CalcKayamGreh(List<KundliMappingVO> lkmv)
        {
            int num = 1;
            foreach (KundliMappingVO kundliMappingVO in lkmv)
            {
                lkmv[num].Kayam = true;
                List<PlanetRelationsVO> planetRelationsVOs = this.SaathiShatru(kundliMappingVO.Planet, lkmv);
                List<DrishtiVO> list = (
                    from drishti in this.CalcDrishti(lkmv)
                    from shatru in RuleBLL.planetrelationslist
                    where (drishti.Planet2 != kundliMappingVO.Planet || drishti.Planet1 != shatru.Planet2 ? false : shatru.Planet1 == kundliMappingVO.Planet)
                    select drishti).ToList<DrishtiVO>();
                if ((planetRelationsVOs.Count > 0 || list.Count > 0 ? true : !lkmv[num].Pakke))
                {
                    lkmv[num].Kayam = false;
                }
            }
            return lkmv;
        }

        public List<KundliMappingVO> CalcKundliPlanets(List<KundliMappingVO> lkmv)
        {
            lkmv = this.CalcPakkeGreh(lkmv);
            lkmv = this.CalcMandeGreh(lkmv);
            lkmv = this.CalcNeechGreh(lkmv);
            lkmv = this.CalcShreshtGreh(lkmv);
            lkmv = this.CalcUchhGreh(lkmv);
            lkmv = this.CalcSoyeGreh(lkmv);
            lkmv = this.CalcKayamGreh(lkmv);
            return lkmv;
        }

        public List<KundliMappingVO> CalcMandeGreh(List<KundliMappingVO> lkmv)
        {
            int num = 0;
            foreach (KundliMappingVO kundliMappingVO in lkmv)
            {
                if (this.IsAkelaGreh(lkmv, kundliMappingVO.Planet))
                {
                    if ((
                        from M in RuleBLL.mandegrehlist
                        where (M.House != kundliMappingVO.House ? false : M.Planet == kundliMappingVO.Planet)
                        select M).Count<PlanetHouseMappingVO>() > 0)
                    {
                        lkmv[num].Mande = true;
                    }
                }
                num++;
            }
            return lkmv;
        }

        public List<KundliMappingVO> CalcNeechGreh(List<KundliMappingVO> lkmv)
        {
            int num = 0;
            foreach (KundliMappingVO kundliMappingVO in lkmv)
            {
                if ((
                    from N in RuleBLL.neechgrehlist
                    where (N.House != kundliMappingVO.House ? false : N.Planet == kundliMappingVO.Planet)
                    select N).Count<PlanetHouseMappingVO>() > 0)
                {
                    lkmv[num].Neech = true;
                }
                num++;
            }
            return lkmv;
        }

        public List<KundliMappingVO> CalcPakkeGreh(List<KundliMappingVO> lkmv)
        {
            int num = 0;
            foreach (KundliMappingVO kundliMappingVO in lkmv)
            {
                if ((
                    from P in RuleBLL.pakkerehlist
                    where (P.House != kundliMappingVO.House ? false : P.Planet == kundliMappingVO.Planet)
                    select P).Count<PlanetHouseMappingVO>() > 0)
                {
                    lkmv[num].Pakke = true;
                }
                num++;
            }
            return lkmv;
        }

        public List<KundliMappingVO> CalcShreshtGreh(List<KundliMappingVO> lkmv)
        {
            int num = 0;
            foreach (KundliMappingVO kundliMappingVO in lkmv)
            {
                if (this.IsAkelaGreh(lkmv, kundliMappingVO.Planet))
                {
                    if ((
                        from S in RuleBLL.shreshtgrehlist
                        where (S.House != kundliMappingVO.House ? false : S.Planet == kundliMappingVO.Planet)
                        select S).Count<PlanetHouseMappingVO>() > 0)
                    {
                        lkmv[num].Shresht = true;
                    }
                }
                num++;
            }
            return lkmv;
        }

        public List<KundliMappingVO> CalcSoyeGreh(List<KundliMappingVO> lkmv)
        {
            int num = 0;
            foreach (KundliMappingVO kundliMappingVO in lkmv)
            {
                List<DrishtiVO> drishtiVOs = this.CalcDrishti(lkmv);
                if (kundliMappingVO.Pakke)
                {
                    lkmv[num].Soya = false;
                }
                else if (!((
                    from L in lkmv
                    where L.House == kundliMappingVO.House
                    select L).Count<KundliMappingVO>() > 1 || kundliMappingVO.PlanetName == "Rahu" ? false : !(kundliMappingVO.PlanetName == "Ketu")))
                {
                    lkmv[num].Soya = false;
                }
                else if ((
                    from Drishti in drishtiVOs
                    where (Drishti.Planet1 == kundliMappingVO.Planet ? true : Drishti.Planet2 == kundliMappingVO.Planet)
                    select Drishti).Count<DrishtiVO>() <= 0)
                {
                    lkmv[num].Soya = true;
                }
                else
                {
                    lkmv[num].Soya = false;
                }
                num++;
            }
            return lkmv;
        }

        public List<KundliMappingVO> CalcUchhGreh(List<KundliMappingVO> lkmv)
        {
            int num = 0;
            foreach (KundliMappingVO kundliMappingVO in lkmv)
            {
                if ((
                    from U in RuleBLL.uchgrehlist
                    where (U.House != kundliMappingVO.House ? false : U.Planet == kundliMappingVO.Planet)
                    select U).Count<PlanetHouseMappingVO>() > 0)
                {
                    lkmv[num].Uch = true;
                }
                num++;
            }
            return lkmv;
        }

        public bool CheckBhavDrishti(List<KundliMappingVO> lkmv, int house)
        {
            bool flag = false;
            switch (house)
            {
                case 1:
                    {
                        if ((
                            from Map in lkmv
                            where Map.House == 7
                            select Map).Count<KundliMappingVO>() > 0)
                        {
                            flag = true;
                        }
                        break;
                    }
                case 2:
                    {
                        if ((
                            from Map in lkmv
                            where Map.House == 8
                            select Map).Count<KundliMappingVO>() > 0)
                        {
                            flag = true;
                        }
                        break;
                    }
                case 3:
                    {
                        if ((
                            from Map in lkmv
                            where Map.House == 9
                            select Map).Count<KundliMappingVO>() > 0)
                        {
                            flag = true;
                        }
                        break;
                    }
                case 4:
                    {
                        if ((
                            from Map in lkmv
                            where Map.House == 10
                            select Map).Count<KundliMappingVO>() > 0)
                        {
                            flag = true;
                        }
                        break;
                    }
                case 5:
                    {
                        if ((
                            from Map in lkmv
                            where Map.House == 11
                            select Map).Count<KundliMappingVO>() > 0)
                        {
                            flag = true;
                        }
                        break;
                    }
                case 6:
                    {
                        if ((
                            from Map in lkmv
                            where (Map.House == 2 ? true : Map.House == 12)
                            select Map).Count<KundliMappingVO>() > 0)
                        {
                            flag = true;
                        }
                        break;
                    }
                case 7:
                    {
                        if ((
                            from Map in lkmv
                            where Map.House == 1
                            select Map).Count<KundliMappingVO>() > 0)
                        {
                            flag = true;
                        }
                        break;
                    }
                case 8:
                    {
                        if (((
                            from Map in lkmv
                            where Map.House == 2
                            select Map).Count<KundliMappingVO>() > 0 ? true : (
                            from Map in lkmv
                            where Map.House == 12
                            select Map).Count<KundliMappingVO>() > 0))
                        {
                            flag = true;
                        }
                        break;
                    }
                case 9:
                    {
                        if ((
                            from Map in lkmv
                            where (Map.House == 3 ? true : Map.House == 5)
                            select Map).Count<KundliMappingVO>() > 0)
                        {
                            flag = true;
                        }
                        break;
                    }
                case 10:
                    {
                        if ((
                            from Map in lkmv
                            where Map.House == 4
                            select Map).Count<KundliMappingVO>() > 0)
                        {
                            flag = true;
                        }
                        break;
                    }
                case 11:
                    {
                        if ((
                            from Map in lkmv
                            where (Map.House == 3 ? true : Map.House == 5)
                            select Map).Count<KundliMappingVO>() > 0)
                        {
                            flag = true;
                        }
                        break;
                    }
                case 12:
                    {
                        if ((
                            from Map in lkmv
                            where (Map.House == 6 ? true : Map.House == 8)
                            select Map).Count<KundliMappingVO>() > 0)
                        {
                            flag = true;
                        }
                        break;
                    }
            }
            return flag;
        }

        public int CheckFormula(string actualformula)
        {
            return (new RuleDAO()).CheckFormula(actualformula);
        }

        public PlanetVO findplanet(int pid)
        {
            PlanetVO planetVO = RuleBLL.planetlist.Find((PlanetVO p) => p.Sno == pid);
            return planetVO;
        }

        public PlanetVO findplanetbyname(string name)
        {
            PlanetVO planetVO = (
                from P in RuleBLL.planetlist
                where P.Planetname.ToUpper() == name.ToUpper()
                select P).FirstOrDefault<PlanetVO>();
            return planetVO;
        }

        public long Get_Drishti_To(long house, long drishti)
        {
            long num = (long)0;
            num = house + (drishti - (long)1);
            if (num > (long)12)
            {
                num -= (long)12;
            }
            return num;
        }

        public ExtraRulesVO GetAdvanceExtraRuleById(long ruleno)
        {
            ExtraRulesVO extraRulesVO = new ExtraRulesVO();
            foreach (DataRow row in (new RuleDAO()).GetAdvanceExtraRuleById(ruleno).Rows)
            {
                extraRulesVO.Sno = Convert.ToInt64(row["sno"].ToString());
                extraRulesVO.RuleNo = Convert.ToInt64(row["ruleno"].ToString());
                extraRulesVO.Good = Convert.ToBoolean(row["good"]);
                extraRulesVO.Planet = row["planet"].ToString();
                extraRulesVO.IsPlanet = Convert.ToBoolean(row["isplanet"].ToString());
            }
            return extraRulesVO;
        }

        public RulesVO GetAdvanceRuleById(long sno)
        {
            RulesVO rulesVO = new RulesVO();
            foreach (DataRow row in (new RuleDAO()).GetAdvanceRuleById(sno).Rows)
            {
                rulesVO.Sno = Convert.ToInt64(row["sno"].ToString());
                rulesVO.Ruleformula = row["ruleformula"].ToString();
                rulesVO.Isbad = Convert.ToBoolean(row["isbad"]);
                rulesVO.Actualformula = row["actualformula"].ToString();
                rulesVO.Title = row["title"].ToString();
                rulesVO.RuleType = row["ruletype"].ToString();
                rulesVO.RefNo = Convert.ToInt64(row["refno"].ToString());
                rulesVO.Sno_Orgin = Convert.ToInt64(row["sno"].ToString());
                rulesVO.Rule_Nature = Convert.ToInt16(row["rulenature"].ToString());
                rulesVO.Upay = Convert.ToInt32(row["upay"].ToString());
                rulesVO.VfalYears = row["vfalyears"].ToString();
                rulesVO.Confidence = Convert.ToBoolean(row["confidence"].ToString());
                rulesVO.Profit = Convert.ToBoolean(row["profit"].ToString());
                rulesVO.Mother_father = Convert.ToBoolean(row["mother_father"].ToString());
                rulesVO.Santan = Convert.ToBoolean(row["santan"].ToString());
                rulesVO.Brother = Convert.ToBoolean(row["brother"].ToString());
                rulesVO.Love_affair = Convert.ToBoolean(row["love_affair"].ToString());
                rulesVO.Disease = Convert.ToBoolean(row["disease"].ToString());
                rulesVO.Marriedlife = Convert.ToBoolean(row["married"].ToString());
                rulesVO.Occupation = Convert.ToBoolean(row["occupation"].ToString());
                rulesVO.Memory = Convert.ToBoolean(row["memory"].ToString());
                rulesVO.Common = Convert.ToBoolean(row["common"].ToString());
                rulesVO.Male = Convert.ToBoolean(row["male"].ToString());
                rulesVO.Female = Convert.ToBoolean(row["female"].ToString());
                rulesVO.Shishu = Convert.ToBoolean(row["shishu"].ToString());
                rulesVO.Bachpan = Convert.ToBoolean(row["bachpan"].ToString());
                rulesVO.Kishor = Convert.ToBoolean(row["kishor"].ToString());
                rulesVO.Yuva = Convert.ToBoolean(row["yuva"].ToString());
                rulesVO.Madhya = Convert.ToBoolean(row["madhya"].ToString());
                rulesVO.Budhapa = Convert.ToBoolean(row["budhapa"].ToString());
                rulesVO.Mainplanet = Convert.ToInt16(row["mainplanet"].ToString());
                rulesVO.Kayam = row["kayam"].ToString();
                rulesVO.Good = row["good"].ToString();
                rulesVO.Bad = row["bad"].ToString();
                rulesVO.MultiUpay = row["multiupay"].ToString();
                rulesVO.PlanetUpay = row["planetupay"].ToString();
                rulesVO.Lagan = row["lagan"].ToString();
                rulesVO.Rashi = row["rashi"].ToString();
            }
            return rulesVO;
        }

        public List<RulesVO> GetAllAdvanceRules()
        {
            List<RulesVO> rulesVOs = new List<RulesVO>();
            foreach (DataRow row in (new RuleDAO()).GetAllAdvanceRules().Rows)
            {
                RulesVO rulesVO = new RulesVO()
                {
                    Sno = Convert.ToInt64(row["sno"].ToString()),
                    Ruleformula = row["ruleformula"].ToString(),
                    Isbad = Convert.ToBoolean(row["isbad"]),
                    Actualformula = row["actualformula"].ToString(),
                    Title = row["title"].ToString(),
                    RuleType = row["ruletype"].ToString(),
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
                    Kayam = row["kayam"].ToString(),
                    Good = row["good"].ToString(),
                    Bad = row["bad"].ToString(),
                    MultiUpay = row["multiupay"].ToString(),
                    PlanetUpay = row["planetupay"].ToString(),
                    Lagan = row["lagan"].ToString(),
                    Rashi = row["rashi"].ToString()
                };
                rulesVOs.Add(rulesVO);
            }
            return rulesVOs;
        }

        public PlanetVO GetPlanetByFormula(long ruleformula)
        {
            PlanetVO planetVO = new PlanetVO();
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            dbCommand.CommandText = string.Concat("select *from A_basic_rules (nolock)  where sno=", ruleformula);
            foreach (DataRow row in GenericDataAccess.ExecuteSelectCommand(dbCommand).Rows)
            {
                planetVO.Sno = Convert.ToInt16(row["planet"]);
                planetVO.Planetname = this.findplanet(Convert.ToInt16(row["planet"])).Planetname;
                planetVO.PlanetnameEnglish = this.findplanet(Convert.ToInt16(row["planet"])).PlanetnameEnglish;
                planetVO.PlanetnameHindi = this.findplanet(Convert.ToInt16(row["planet"])).PlanetnameHindi;
            }
            return planetVO;
        }

        public GetPlanetVO GetPlanetByRuleNo(long ruleno)
        {
            GetPlanetVO getPlanetVO = new GetPlanetVO();
            foreach (DataRow row in (new RuleDAO()).get_planet_by_ruleno(ruleno).Rows)
            {
                getPlanetVO.Planet = row["planet"].ToString();
                getPlanetVO.House = row["house"].ToString();
            }
            return getPlanetVO;
        }

        public List<PredicateVO> GetPredicates(long ruleno)
        {
            List<PredicateVO> predicateVOs = new List<PredicateVO>();
            long num = (long)1;
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            object[] objArray = new object[] { "select *from A_basic_rules (nolock)  where sno=", ruleno, " or planet=(select planet from A_basic_rules where sno=", ruleno, ") order by sno" };
            dbCommand.CommandText = string.Concat(objArray);
            foreach (DataRow row in GenericDataAccess.ExecuteSelectCommand(dbCommand).Rows)
            {
                PredicateVO predicateVO = new PredicateVO()
                {
                    Sno = num,
                    RuleNo = Convert.ToInt64(row["sno"])
                };
                num += (long)1;
                predicateVOs.Add(predicateVO);
            }
            return predicateVOs;
        }

        public bool[] GetSoyeBhav(List<KundliMappingVO> lkmv)
        {
            bool[] flagArray = new bool[12];
            this.CalcDrishti(lkmv);
            for (int i = 0; i <= 11; i++)
            {
                flagArray[i] = false;
                if (((
                    from Map in lkmv
                    where Map.House == i + 1
                    select Map).Count<KundliMappingVO>() != 0 ? false : !this.CheckBhavDrishti(lkmv, i + 1)))
                {
                    flagArray[i] = true;
                }
            }
            return flagArray;
        }

        public List<VarshPhalVO> GetVfalYearList(int house, int houselagna)
        {
            List<VarshPhalVO> varshPhalVOs = new List<VarshPhalVO>();
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "GetVfalyearlist";
            DbParameter dbParameter = dbCommand.CreateParameter();
            dbParameter.ParameterName = "@house";
            dbParameter.DbType = DbType.Int32;
            dbParameter.Value = house;
            dbCommand.Parameters.Add(dbParameter);
            DbParameter dbParameter1 = dbCommand.CreateParameter();
            dbParameter1.ParameterName = "@houselagna";
            dbParameter1.DbType = DbType.Int32;
            dbParameter1.Value = houselagna;
            dbCommand.Parameters.Add(dbParameter1);
            foreach (DataRow row in GenericDataAccess.ExecuteSelectCommand(dbCommand).Rows)
            {
                VarshPhalVO varshPhalVO = new VarshPhalVO()
                {
                    sno = Convert.ToInt32(row["sno"]),
                    age = Convert.ToInt32(row["age"]),
                    house1 = Convert.ToInt32(row["house1"]),
                    house2 = Convert.ToInt32(row["house2"]),
                    house3 = Convert.ToInt32(row["house3"]),
                    house4 = Convert.ToInt32(row["house4"]),
                    house5 = Convert.ToInt32(row["house5"]),
                    house6 = Convert.ToInt32(row["house6"]),
                    house7 = Convert.ToInt32(row["house7"]),
                    house8 = Convert.ToInt32(row["house8"]),
                    house9 = Convert.ToInt32(row["house9"]),
                    house10 = Convert.ToInt32(row["house10"]),
                    house11 = Convert.ToInt32(row["house11"]),
                    house12 = Convert.ToInt32(row["house12"])
                };
                varshPhalVOs.Add(varshPhalVO);
            }
            return varshPhalVOs;
        }

        public bool IsAkelaGreh(List<KundliMappingVO> lkmv, int planet)
        {
            Func<KundliMappingVO, int> func = null;
            bool flag = true;
            List<DrishtiVO> drishtiVOs = this.CalcDrishti(lkmv);
            if (lkmv.Where<KundliMappingVO>((KundliMappingVO Map) =>
            {
                int house = Map.House;
                IEnumerable<KundliMappingVO> kundliMappingVOs =
                    from M in lkmv
                    where M.Planet == planet
                    select M;
                if (func == null)
                {
                    func = (KundliMappingVO Mp) => Mp.House;
                }
                return (house != Convert.ToInt32(kundliMappingVOs.Select<KundliMappingVO, int>(func).SingleOrDefault<int>()) ? false : Map.Planet != planet);
            }).Count<KundliMappingVO>() == 0)
            {
                flag = true;
            }
            else if ((
                from Drishti in drishtiVOs
                where Drishti.Planet2 == planet
                select Drishti).Count<DrishtiVO>() > 0)
            {
                flag = false;
            }
            return flag;
        }

        public bool IsAndhi(List<KundliMappingVO> lkmv)
        {
            bool flag = false;
            List<KundliMappingVO> list = (
                from Map in lkmv
                where Map.House == 10
                select Map).ToList<KundliMappingVO>();
            IEnumerable<PlanetRelationsVO> planet =
                from saathi in list
                join shatru in RuleBLL.planetrelationslist on saathi.Planet equals shatru.Planet1
                where shatru.Relation == 2
                join pp in list on shatru.Planet2 equals pp.Planet
                select shatru;
            int num = (
                from ss in planet
                join ss1 in planet on new { Planet2 = ss.Planet2, Planet1 = ss.Planet1 } equals new { Planet2 = ss1.Planet1, Planet1 = ss1.Planet2 }
                where (ss.Relation != 2 ? false : ss1.Relation == 2)
                select new { SNO = ss.Sno }).Count();
            List<DrishtiVO> drishtiVOs = this.CalcDrishti(lkmv);
            List<KundliMappingVO> kundliMappingVOs = (
                from lk in lkmv
                join shatru in RuleBLL.planetrelationslist on lk.Planet equals shatru.Planet1
                join ld1 in drishtiVOs on new { Planet2 = shatru.Planet2, Planet1 = shatru.Planet1 } equals new { Planet2 = ld1.Planet1, Planet1 = ld1.Planet2 }
                where (lk.House != 10 ? false : shatru.Relation == 2)
                select lk).ToList<KundliMappingVO>();
            if ((num <= 0 ? false : kundliMappingVOs.Count<KundliMappingVO>() > 0))
            {
                flag = true;
            }
            return flag;
        }

        public bool IsAndhRati(List<KundliMappingVO> lkmv)
        {
            bool flag = false;
            int num = (
                from Map in lkmv
                where (Map.House != 7 ? false : Map.Planet == this.findplanetbyname("Surya").Sno)
                select Map).Count<KundliMappingVO>();
            int num1 = (
                from Map in lkmv
                where (Map.House != 4 ? false : Map.Planet == this.findplanetbyname("shani").Sno)
                select Map).Count<KundliMappingVO>();
            if ((num <= 0 ? false : num1 > 0))
            {
                flag = true;
            }
            return flag;
        }

        public bool isDharmi(List<KundliMappingVO> lkmv)
        {
            bool flag;
            bool flag1 = false;
            int num = Convert.ToInt32((
                from Map in lkmv
                where Map.Planet == this.findplanetbyname("Rahu").Sno
                select Map.House).SingleOrDefault<int>());
            int num1 = Convert.ToInt32((
                from Map in lkmv
                where Map.Planet == this.findplanetbyname("Ketu").Sno
                select Map.House).SingleOrDefault<int>());
            int num2 = Convert.ToInt32((
                from Map in lkmv
                where Map.Planet == this.findplanetbyname("Chandra").Sno
                select Map.House).SingleOrDefault<int>());
            int num3 = Convert.ToInt32((
                from Map in lkmv
                where Map.Planet == this.findplanetbyname("Shani").Sno
                select Map.House).SingleOrDefault<int>());
            int num4 = Convert.ToInt32((
                from Map in lkmv
                where Map.Planet == this.findplanetbyname("Guru").Sno
                select Map.House).SingleOrDefault<int>());
            if (num == 4 || num1 == 4 || num == num2 || num1 == num2)
            {
                flag = (num3 == 11 ? false : num3 != num4);
            }
            else
            {
                flag = true;
            }
            if (!flag)
            {
                flag1 = true;
            }
            return flag1;
        }

        public List<PlanetRelationsVO> SaathiShatru(int planet, List<KundliMappingVO> lkmv)
        {
            List<PlanetRelationsVO> list = (
                from map in lkmv
                from map1 in lkmv
                from shatru in RuleBLL.planetrelationslist
                where (map.House != map1.House || map.Planet == map.Planet || shatru.Planet1 != map.Planet || shatru.Planet2 != map.Planet ? false : shatru.Relation == 2)
                select shatru).ToList<PlanetRelationsVO>();
            return list;
        }

        public List<RulesVO> SearchRules(string title, int house, int planet)
        {
            RuleDAO ruleDAO = new RuleDAO();
            List<RulesVO> rulesVOs = new List<RulesVO>();
            foreach (DataRow row in ruleDAO.SearchRules(title, house, planet).Rows)
            {
                RulesVO rulesVO = new RulesVO()
                {
                    Sno = Convert.ToInt64(row["sno"].ToString()),
                    Ruleformula = row["ruleformula"].ToString(),
                    Isbad = Convert.ToBoolean(row["isbad"]),
                    Actualformula = row["actualformula"].ToString(),
                    Title = row["title"].ToString()
                };
                rulesVOs.Add(rulesVO);
            }
            return rulesVOs;
        }

        public void UpdateRule(RulesVO rv, LangVO pred, string lang)
        {
            (new RuleDAO()).UpdateAdvanceRule(rv, pred, lang);
        }
    }
}