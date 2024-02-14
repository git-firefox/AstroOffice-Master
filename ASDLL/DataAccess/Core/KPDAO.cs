using ASDLL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
//using AstroShared.Models;
using AstroOfficeWeb.Shared.VOs;

namespace ASDLL.DataAccess.Core
{
    public class KPDAO
    {
        public KPDAO()
        {
        }

        public List<KPDashafalVO> Get_Dashafal(short planet, short house)
        {
            List<KPDashafalVO> kPDashafalVOs = new List<KPDashafalVO>();
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            dbCommand.CommandText = string.Concat("select * from A_mix_dasha (nolock)  where  planet1=", planet.ToString(), " and house1=", house.ToString());
            KundliBLL kundliBLL = new KundliBLL();
            foreach (DataRow row in GenericDataAccess.ExecuteSelectCommand(dbCommand).Rows)
            {
                KPDashafalVO kPDashafalVO = new KPDashafalVO()
                {
                    Sno = Convert.ToInt16(row["sno"]),
                    Planet = Convert.ToInt16(row["planet1"]),
                    Planet2 = Convert.ToInt16(row["planet2"]),
                    House = Convert.ToInt16(row["house1"]),
                    Isbad = Convert.ToBoolean(row["isbad"]),
                    VeryBad = Convert.ToBoolean(row["verybad"]),
                    Pred_Hindi = row["pred_hindi"].ToString(),
                    Pred_English = row["pred_english"].ToString(),
                    wealth = Convert.ToBoolean(row["wealth"]),
                    children = Convert.ToBoolean(row["santan"]),
                    married = Convert.ToBoolean(row["married_life"]),
                    occupation = Convert.ToBoolean(row["occupation"]),
                    disease = Convert.ToBoolean(row["disease"]),
                    love_affair = Convert.ToBoolean(row["love_affair"]),
                    general = Convert.ToBoolean(row["general"]),
                    brother = Convert.ToBoolean(row["sibling"]),
                    mother_father = Convert.ToBoolean(row["parents"]),
                    LawType = row["lawtype"].ToString(),
                    common = Convert.ToBoolean(row["common"]),
                    male = Convert.ToBoolean(row["male"]),
                    female = Convert.ToBoolean(row["female"])
                };
                if (Convert.ToInt64(row["age1"]) == (long)1)
                {
                    kPDashafalVO.Talak = true;
                }
                if (Convert.ToInt64(row["age2"]) == (long)1)
                {
                    kPDashafalVO.ShadiYog = true;
                }
                kPDashafalVO.Ptype = row["ptype"].ToString();
                kPDashafalVO.Upay = Convert.ToInt64(row["upay"]);
                kPDashafalVOs.Add(kPDashafalVO);
            }
            return kPDashafalVOs;
        }

        public List<KPDashafalChainVO> Get_Dashafal_Chain()
        {
            List<KPDashafalChainVO> kPDashafalChainVOs = new List<KPDashafalChainVO>();
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            dbCommand.CommandText = "select *from A_kp_dasha_chain (nolock)";
            KundliBLL kundliBLL = new KundliBLL();
            foreach (DataRow row in GenericDataAccess.ExecuteSelectCommand(dbCommand).Rows)
            {
                KPDashafalChainVO kPDashafalChainVO = new KPDashafalChainVO()
                {
                    Sno = Convert.ToInt16(row["sno"]),
                    Signi = row["signi"].ToString(),
                    Pred_Hindi = row["pred_hindi"].ToString(),
                    Pred_English = row["pred_english"].ToString(),
                    Ptype = row["ptype"].ToString(),
                    wealth = Convert.ToBoolean(row["wealth"]),
                    children = Convert.ToBoolean(row["children"]),
                    married = Convert.ToBoolean(row["married"]),
                    occupation = Convert.ToBoolean(row["occupation"]),
                    disease = Convert.ToBoolean(row["disease"]),
                    love_affair = Convert.ToBoolean(row["love_affair"]),
                    general = Convert.ToBoolean(row["general"]),
                    brother = Convert.ToBoolean(row["brother"]),
                    mother_father = Convert.ToBoolean(row["mother_father"]),
                    Isbad = Convert.ToBoolean(row["isbad"]),
                    VeryBad = Convert.ToBoolean(row["verybad"]),
                    common = Convert.ToBoolean(row["common"]),
                    male = Convert.ToBoolean(row["male"]),
                    female = Convert.ToBoolean(row["female"]),
                    shishu = Convert.ToBoolean(row["shishu"]),
                    bachpan = Convert.ToBoolean(row["bachpan"]),
                    kishor = Convert.ToBoolean(row["kishor"]),
                    yuva = Convert.ToBoolean(row["yuva"]),
                    madhya = Convert.ToBoolean(row["madhya"]),
                    budhapa = Convert.ToBoolean(row["budhapa"])
                };
                kPDashafalChainVOs.Add(kPDashafalChainVO);
            }
            return kPDashafalChainVOs;
        }

        public List<KPDashafalHouseSwamiVO> Get_Dashafal_House_Swami()
        {
            List<KPDashafalHouseSwamiVO> kPDashafalHouseSwamiVOs = new List<KPDashafalHouseSwamiVO>();
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            dbCommand.CommandText = "select *from A_kp_dasha_house_swami (nolock)";
            KundliBLL kundliBLL = new KundliBLL();
            foreach (DataRow row in GenericDataAccess.ExecuteSelectCommand(dbCommand).Rows)
            {
                KPDashafalHouseSwamiVO kPDashafalHouseSwamiVO = new KPDashafalHouseSwamiVO()
                {
                    Sno = Convert.ToInt16(row["sno"]),
                    House_Swami = Convert.ToInt16(row["house_swami"]),
                    Pred_Hindi = row["pred_hindi"].ToString(),
                    Pred_English = row["pred_english"].ToString(),
                    Isbad = Convert.ToBoolean(row["isbad"]),
                    VeryBad = Convert.ToBoolean(row["verybad"]),
                    wealth = Convert.ToBoolean(row["wealth"]),
                    children = Convert.ToBoolean(row["children"]),
                    married = Convert.ToBoolean(row["married"]),
                    occupation = Convert.ToBoolean(row["occupation"]),
                    disease = Convert.ToBoolean(row["disease"]),
                    love_affair = Convert.ToBoolean(row["love_affair"]),
                    general = Convert.ToBoolean(row["general"]),
                    brother = Convert.ToBoolean(row["brother"]),
                    mother_father = Convert.ToBoolean(row["mother_father"]),
                    common = Convert.ToBoolean(row["common"]),
                    male = Convert.ToBoolean(row["male"]),
                    female = Convert.ToBoolean(row["female"]),
                    shishu = Convert.ToBoolean(row["shishu"]),
                    bachpan = Convert.ToBoolean(row["bachpan"]),
                    kishor = Convert.ToBoolean(row["kishor"]),
                    yuva = Convert.ToBoolean(row["yuva"]),
                    madhya = Convert.ToBoolean(row["madhya"]),
                    budhapa = Convert.ToBoolean(row["budhapa"])
                };
                kPDashafalHouseSwamiVOs.Add(kPDashafalHouseSwamiVO);
            }
            return kPDashafalHouseSwamiVOs;
        }

        public List<KPDashafalMahaAntarVO> Get_Dashafal_MahaAntar(short mahadasha, short antardasha)
        {
            List<KPDashafalMahaAntarVO> kPDashafalMahaAntarVOs = new List<KPDashafalMahaAntarVO>();
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            dbCommand.CommandText = string.Concat("select *from A_kp_dasha_mahantar (nolock) where mahadasha= ", mahadasha.ToString(), " and antardasha=", antardasha.ToString());
            KundliBLL kundliBLL = new KundliBLL();
            foreach (DataRow row in GenericDataAccess.ExecuteSelectCommand(dbCommand).Rows)
            {
                KPDashafalMahaAntarVO kPDashafalMahaAntarVO = new KPDashafalMahaAntarVO()
                {
                    Sno = Convert.ToInt16(row["sno"]),
                    Mahadasha = Convert.ToInt16(row["mahadasha"]),
                    Antardasha = Convert.ToInt16(row["antardasha"]),
                    House = row["house"].ToString(),
                    House_Pos = row["house_pos"].ToString(),
                    House_Swami = row["house_swami"].ToString(),
                    Pred_Hindi = row["pred_hindi"].ToString(),
                    Pred_English = row["pred_english"].ToString(),
                    wealth = Convert.ToBoolean(row["wealth"]),
                    children = Convert.ToBoolean(row["children"]),
                    married = Convert.ToBoolean(row["married"]),
                    occupation = Convert.ToBoolean(row["occupation"]),
                    disease = Convert.ToBoolean(row["disease"]),
                    love_affair = Convert.ToBoolean(row["love_affair"]),
                    general = Convert.ToBoolean(row["general"]),
                    brother = Convert.ToBoolean(row["brother"]),
                    mother_father = Convert.ToBoolean(row["mother_father"]),
                    Isbad = Convert.ToBoolean(row["isbad"]),
                    VeryBad = Convert.ToBoolean(row["verybad"]),
                    common = Convert.ToBoolean(row["common"]),
                    male = Convert.ToBoolean(row["male"]),
                    female = Convert.ToBoolean(row["female"]),
                    shishu = Convert.ToBoolean(row["shishu"]),
                    bachpan = Convert.ToBoolean(row["bachpan"]),
                    kishor = Convert.ToBoolean(row["kishor"]),
                    yuva = Convert.ToBoolean(row["yuva"]),
                    madhya = Convert.ToBoolean(row["madhya"]),
                    budhapa = Convert.ToBoolean(row["budhapa"])
                };
                kPDashafalMahaAntarVOs.Add(kPDashafalMahaAntarVO);
            }
            return kPDashafalMahaAntarVOs;
        }

        public List<KPDashafalRashiVO> Get_Dashafal_Rashi()
        {
            List<KPDashafalRashiVO> kPDashafalRashiVOs = new List<KPDashafalRashiVO>();
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            dbCommand.CommandText = "select *from A_kp_dasha_rashi (nolock)";
            KundliBLL kundliBLL = new KundliBLL();
            foreach (DataRow row in GenericDataAccess.ExecuteSelectCommand(dbCommand).Rows)
            {
                KPDashafalRashiVO kPDashafalRashiVO = new KPDashafalRashiVO()
                {
                    Sno = Convert.ToInt16(row["sno"]),
                    Planet = Convert.ToInt16(row["house"]),
                    Rashi = Convert.ToInt16(row["rashi"]),
                    Pred_Hindi = row["pred_hindi"].ToString(),
                    Pred_English = row["pred_english"].ToString(),
                    Isbad = Convert.ToBoolean(row["isbad"]),
                    VeryBad = Convert.ToBoolean(row["verybad"]),
                    wealth = Convert.ToBoolean(row["wealth"]),
                    children = Convert.ToBoolean(row["children"]),
                    married = Convert.ToBoolean(row["married"]),
                    occupation = Convert.ToBoolean(row["occupation"]),
                    disease = Convert.ToBoolean(row["disease"]),
                    love_affair = Convert.ToBoolean(row["love_affair"]),
                    general = Convert.ToBoolean(row["general"]),
                    brother = Convert.ToBoolean(row["brother"]),
                    mother_father = Convert.ToBoolean(row["mother_father"]),
                    common = Convert.ToBoolean(row["common"]),
                    male = Convert.ToBoolean(row["male"]),
                    female = Convert.ToBoolean(row["female"]),
                    shishu = Convert.ToBoolean(row["shishu"]),
                    bachpan = Convert.ToBoolean(row["bachpan"]),
                    kishor = Convert.ToBoolean(row["kishor"]),
                    yuva = Convert.ToBoolean(row["yuva"]),
                    madhya = Convert.ToBoolean(row["madhya"]),
                    budhapa = Convert.ToBoolean(row["budhapa"])
                };
                kPDashafalRashiVOs.Add(kPDashafalRashiVO);
            }
            return kPDashafalRashiVOs;
        }

        public List<KPGoodBadVO> Get_GoodBad()
        {
            List<KPGoodBadVO> kPGoodBadVOs = new List<KPGoodBadVO>();
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            dbCommand.CommandText = "select *from A_goodbad (nolock)";
            KundliBLL kundliBLL = new KundliBLL();
            foreach (DataRow row in GenericDataAccess.ExecuteSelectCommand(dbCommand).Rows)
            {
                KPGoodBadVO kPGoodBadVO = new KPGoodBadVO()
                {
                    sno = Convert.ToInt16(row["sno"]),
                    planet = Convert.ToInt16(row["planet"]),
                    house = Convert.ToInt16(row["house"]),
                    isbad = Convert.ToBoolean(row["isbad"])
                };
                kPGoodBadVOs.Add(kPGoodBadVO);
            }
            return kPGoodBadVOs;
        }

        public List<KPKaryeshVO> Get_Karyesh_List()
        {
            List<KPKaryeshVO> kPKaryeshVOs = new List<KPKaryeshVO>();
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            dbCommand.CommandText = "select  * from  A_karyesh order by sno";
            KundliBLL kundliBLL = new KundliBLL();
            foreach (DataRow row in GenericDataAccess.ExecuteSelectCommand(dbCommand).Rows)
            {
                KPKaryeshVO kPKaryeshVO = new KPKaryeshVO()
                {
                    Sno = Convert.ToInt16(row["sno"]),
                    KType = row["ktype"].ToString(),
                    MainHose = Convert.ToInt16(row["main_house"]),
                    Pos_Houses = row["pos_house"].ToString(),
                    Neg_House = row["neg_house"].ToString()
                };
                kPKaryeshVOs.Add(kPKaryeshVO);
            }
            return kPKaryeshVOs;
        }

        public List<KP_Sublord_Pred> Get_KP_Cusp_Pred(bool showref, short house)
        {
            string[] str;
            long sno;
            List<KP_Sublord_Pred> kPSublordPreds = new List<KP_Sublord_Pred>();
            List<KPPlanetsVO> kPPlanetsVOs = new List<KPPlanetsVO>();
            kPPlanetsVOs = (new KPBLL()).Fill_Planets();
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            dbCommand.CommandText = string.Concat("select *from A_kp_cusp (nolock) where house=", house, " order by sublord");
            KundliBLL kundliBLL = new KundliBLL();
            foreach (DataRow row in GenericDataAccess.ExecuteSelectCommand(dbCommand).Rows)
            {
                KP_Sublord_Pred kPSublordPred = new KP_Sublord_Pred()
                {
                    Sno = Convert.ToInt64(row["sno"]),
                    Sublord = Convert.ToInt16(row["sublord"]),
                    House = Convert.ToInt16(row["house"])
                };
                if (!showref)
                {
                    kPSublordPred.Pred_Hindi = row["pred_hindi"].ToString();
                }
                else
                {
                    str = new string[] { row["house"].ToString(), " [ ", row["sublord"].ToString(), " ] ", row["pred_hindi"].ToString(), " [A_kp_cusp : ", null, null };
                    sno = kPSublordPred.Sno;
                    str[6] = sno.ToString();
                    str[7] = "]  ";
                    kPSublordPred.Pred_Hindi = string.Concat(str);
                }
                kPSublordPred.Pred_English = row["pred_english"].ToString();
                kPSublordPred.PType = row["ptype"].ToString();
                kPSublordPred.RuleType = row["ruletype"].ToString();
                kPSublordPred.Isbad = Convert.ToBoolean(row["isbad"]);
                kPSublordPred.VeryBad = Convert.ToBoolean(row["verybad"]);
                kPSublordPred.wealth = Convert.ToBoolean(row["wealth"]);
                kPSublordPred.children = Convert.ToBoolean(row["children"]);
                kPSublordPred.married = Convert.ToBoolean(row["married"]);
                kPSublordPred.occupation = Convert.ToBoolean(row["occupation"]);
                kPSublordPred.disease = Convert.ToBoolean(row["disease"]);
                kPSublordPred.love_affair = Convert.ToBoolean(row["love_affair"]);
                kPSublordPred.general = Convert.ToBoolean(row["general"]);
                kPSublordPred.brother = Convert.ToBoolean(row["brother"]);
                kPSublordPred.mother_father = Convert.ToBoolean(row["mother_father"]);
                kPSublordPred.common = Convert.ToBoolean(row["common"]);
                kPSublordPred.male = Convert.ToBoolean(row["male"]);
                kPSublordPred.female = Convert.ToBoolean(row["female"]);
                kPSublordPred.shishu = Convert.ToBoolean(row["shishu"]);
                kPSublordPred.bachpan = Convert.ToBoolean(row["bachpan"]);
                kPSublordPred.kishor = Convert.ToBoolean(row["kishor"]);
                kPSublordPred.yuva = Convert.ToBoolean(row["yuva"]);
                kPSublordPred.madhya = Convert.ToBoolean(row["madhya"]);
                kPSublordPred.budhapa = Convert.ToBoolean(row["budhapa"]);
                str = new string[] { "सबलॉर्ड : ", row["sublord"].ToString(), " - ", row["house"].ToString(), " [A_kp_cusp : ", null, null };
                sno = kPSublordPred.Sno;
                str[5] = sno.ToString();
                str[6] = "]  ";
                kPSublordPred.ShowRef = string.Concat(str);
                kPSublordPreds.Add(kPSublordPred);
            }
            return kPSublordPreds;
        }

        public List<KP_Karyesh_Pred> Get_KP_Karyesh_Pred()
        {
            List<KP_Karyesh_Pred> kPKaryeshPreds = new List<KP_Karyesh_Pred>();
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            dbCommand.CommandText = "select *from A_kp_karyesh_pred (nolock) ";
            KundliBLL kundliBLL = new KundliBLL();
            foreach (DataRow row in GenericDataAccess.ExecuteSelectCommand(dbCommand).Rows)
            {
                KP_Karyesh_Pred kPKaryeshPred = new KP_Karyesh_Pred()
                {
                    Sno = Convert.ToInt64(row["sno"]),
                    Karyesh = row["karyesh"].ToString(),
                    House = Convert.ToInt16(row["house"]),
                    Pred_Hindi = row["pred_hindi"].ToString()
                };
                kPKaryeshPreds.Add(kPKaryeshPred);
            }
            return kPKaryeshPreds;
        }

        public KPLangVO Get_KP_Lang(short mixsno, bool dashafal, bool upay, string lang, bool mini)
        {
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            if (!(lang != "hindi"))
            {
                dbCommand.CommandText = string.Concat("select *from A_mix_dasha (nolock)  where  sno=", mixsno.ToString());
            }
            else
            {
                dbCommand.CommandText = string.Concat("select *from editor_content (nolock)  where rtype = 1 and  mixsno=", mixsno.ToString());
            }
            if (upay)
            {
                if (!(lang != "hindi"))
                {
                    dbCommand.CommandText = string.Concat("select *from A_kp_remedy (nolock)  where sno=", mixsno.ToString());
                }
                else
                {
                    dbCommand.CommandText = string.Concat("select *from editor_content (nolock)  where rtype = 2 and mixsno=", mixsno.ToString());
                }
            }
            if (mini)
            {
                dbCommand.CommandText = string.Concat("select *from A_mini_dasha (nolock)  where  sno=", mixsno.ToString());
                if (upay)
                {
                    if (!(lang != "hindi"))
                    {
                        dbCommand.CommandText = string.Concat("select *from A_kp_remedy (nolock)  where sno=", mixsno.ToString());
                    }
                    else
                    {
                        dbCommand.CommandText = string.Concat("select *from editor_content (nolock)  where rtype = 2 and mixsno=", mixsno.ToString());
                    }
                }
            }
            KundliBLL kundliBLL = new KundliBLL();
            DataTable dataTable = GenericDataAccess.ExecuteSelectCommand(dbCommand);
            KPLangVO kPLangVO = new KPLangVO();
            foreach (DataRow row in dataTable.Rows)
            {
                if (!(lang != "hindi"))
                {
                    kPLangVO.mixno = Convert.ToInt16(row["sno"]);
                    kPLangVO.pred_hindi = row["pred_hindi"].ToString();
                    //kPLangVO.pred_english = row["pred_english"].ToString(); // 
                }
                else
                {
                    kPLangVO.mixno = Convert.ToInt16(row["mixsno"]);
                    kPLangVO.pred_punjabi = row["pred_punjabi"].ToString();
                    kPLangVO.pred_tamil = row["pred_tamil"].ToString();
                    kPLangVO.pred_telugu = row["pred_telugu"].ToString();
                    kPLangVO.pred_oriya = row["pred_oriya"].ToString();
                    kPLangVO.pred_english = row["pred_english"].ToString();
                    kPLangVO.pred_bengali = row["pred_bengali"].ToString();
                    kPLangVO.pred_malayalam = row["pred_malayalam"].ToString();
                    kPLangVO.pred_marathi = row["pred_marathi"].ToString();
                    kPLangVO.pred_assamese = row["pred_assamese"].ToString();
                    kPLangVO.pred_gujarati = row["pred_gujarati"].ToString();
                    kPLangVO.pred_kannada = row["pred_kannada"].ToString();
                }
            }
            return kPLangVO;
        }

        public List<KP_Occupation> Get_KP_Occupation_Pred()
        {
            List<KP_Occupation> kPOccupations = new List<KP_Occupation>();
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            dbCommand.CommandText = "select *from A_kp (nolock)";
            KundliBLL kundliBLL = new KundliBLL();
            foreach (DataRow row in GenericDataAccess.ExecuteSelectCommand(dbCommand).Rows)
            {
                KP_Occupation kPOccupation = new KP_Occupation()
                {
                    Sno = (long)Convert.ToInt16(row["sno"]),
                    KPno = (long)Convert.ToInt16(row["kpno"]),
                    Pred_English = row["english"].ToString(),
                    Pred_Hindi = row["hindi"].ToString(),
                    pred_assamese = row["assamese_unicode"].ToString(),
                    pred_bengali = row["bangla_unicode"].ToString(),
                    pred_gujarati = row["gujarati_unicode"].ToString(),
                    pred_kannada = row["kannada_unicode"].ToString(),
                    pred_malayalam = row["malayalam_unicode"].ToString(),
                    pred_marathi = row["marathi_unicode"].ToString(),
                    pred_oriya = row["oriya_unicode"].ToString(),
                    pred_punjabi = row["punjabi_unicode"].ToString(),
                    pred_tamil = row["tamil_unicode"].ToString(),
                    pred_telugu = row["telugu_unicode"].ToString()
                };
                kPOccupations.Add(kPOccupation);
            }
            return kPOccupations;
        }

        public List<KP_Planet_Pred> Get_KP_Planet_Pred()
        {
            List<KP_Planet_Pred> kPPlanetPreds = new List<KP_Planet_Pred>();
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            dbCommand.CommandText = "select *from A_kp_planet_pred (nolock) ";
            KundliBLL kundliBLL = new KundliBLL();
            foreach (DataRow row in GenericDataAccess.ExecuteSelectCommand(dbCommand).Rows)
            {
                KP_Planet_Pred kPPlanetPred = new KP_Planet_Pred()
                {
                    Sno = Convert.ToInt64(row["sno"]),
                    Planet = Convert.ToInt16(row["planet"]),
                    House = Convert.ToInt16(row["house"]),
                    Pred_Hindi = row["pred_hindi"].ToString()
                };
                kPPlanetPreds.Add(kPPlanetPred);
            }
            return kPPlanetPreds;
        }

        public List<KP_Sublord_Pred> Get_KP_Sublord_Pred()
        {
            List<KP_Sublord_Pred> kPSublordPreds = new List<KP_Sublord_Pred>();
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            dbCommand.CommandText = "select *from A_kp_sublord_pred (nolock) ";
            KundliBLL kundliBLL = new KundliBLL();
            foreach (DataRow row in GenericDataAccess.ExecuteSelectCommand(dbCommand).Rows)
            {
                KP_Sublord_Pred kPSublordPred = new KP_Sublord_Pred()
                {
                    Sno = Convert.ToInt64(row["sno"]),
                    Sublord = Convert.ToInt16(row["sublord"]),
                    House = Convert.ToInt16(row["house"]),
                    Pred_Hindi = row["pred_hindi"].ToString(),
                    Pred_English = row["pred_english"].ToString(),
                    pred_assamese = row["assamese_unicode"].ToString(),
                    pred_bengali = row["bangla_unicode"].ToString(),
                    pred_gujarati = row["gujarati_unicode"].ToString(),
                    pred_kannada = row["kannada_unicode"].ToString(),
                    pred_malayalam = row["malayalam_unicode"].ToString(),
                    pred_marathi = row["marathi_unicode"].ToString(),
                    pred_oriya = row["oriya_unicode"].ToString(),
                    pred_punjabi = row["punjabi_unicode"].ToString(),
                    pred_tamil = row["tamil_unicode"].ToString(),
                    pred_telugu = row["telugu_unicode"].ToString()
                };
                kPSublordPreds.Add(kPSublordPred);
            }
            return kPSublordPreds;
        }

        public List<KPMixDashaVO> Get_Mix_Dasha(short planet, short house, short fieldno, string cat, string ptype)
        {
            string[] strArrays;
            object[] str;
            List<KPMixDashaVO> kPMixDashaVOs = new List<KPMixDashaVO>();
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            if (ptype == "dasha")
            {
                if (!(cat == "all"))
                {
                    if (cat == "disease")
                    {
                        dbCommand.CommandText = string.Concat("select *from A_mix_dasha (nolock)  where  ptype='dasha' and disease=1 and  planethouse like('%", planet.ToString(), "#%')");
                    }
                    if (cat == "married_life")
                    {
                        dbCommand.CommandText = string.Concat("select *from A_mix_dasha (nolock)  where (married_life=1 or inlaw=1 or love_affair=1) and  ptype='dasha' and  planethouse like('%", planet.ToString(), "#%')");
                    }
                    if (cat == "occupation")
                    {
                        dbCommand.CommandText = string.Concat("select *from A_mix_dasha (nolock)  where (occupation=1 or education=1 or wealth=1) and  ptype='dasha' and  planethouse like('%", planet.ToString(), "#%')");
                    }
                    if (cat == "work_pred")
                    {
                        dbCommand.CommandText = string.Concat("select *from A_mix_dasha (nolock)  where (work_pred=1) and  ptype='dasha' and   planethouse like('%", planet.ToString(), "#%')");
                    }
                    if (cat == "parents")
                    {
                        dbCommand.CommandText = string.Concat("select *from A_mix_dasha (nolock)  where (parents=1) and  ptype='dasha' and   planethouse like('%", planet.ToString(), "#%')");
                    }
                    if (cat == "santan")
                    {
                        dbCommand.CommandText = string.Concat("select *from A_mix_dasha (nolock)  where (santan=1) and   ptype='dasha' and  planethouse like('%", planet.ToString(), "#%')");
                    }
                    if (cat == "nature")
                    {
                        dbCommand.CommandText = string.Concat("select *from A_mix_dasha (nolock)  where (nature=1 or general=1) and   ptype='dasha' and  planethouse like('%", planet.ToString(), "#%')");
                    }
                }
                else
                {
                    dbCommand.CommandText = string.Concat("select *from A_mix_dasha (nolock)  where ptype='dasha' and  planethouse like('%", planet.ToString(), "#%')");
                }
            }
            if ((ptype == "spl_yog" ? true : ptype == "age"))
            {
                strArrays = new string[] { "select *from A_mix_dasha (nolock)  where  ", ptype, "=1 and planethouse like('%", planet.ToString(), "%')" };
                dbCommand.CommandText = string.Concat(strArrays);
            }
            if ((ptype == "multi" ? true : ptype == "yuti"))
            {
                if ((cat == "all" ? false : cat.Trim().Length > 0))
                {
                    if (cat == "disease")
                    {
                        strArrays = new string[] { "select *from A_mix_dasha (nolock)  where ptype='", ptype, "' and disease=1 and  planethouse like('%", planet.ToString(), "%')" };
                        dbCommand.CommandText = string.Concat(strArrays);
                    }
                    if (cat == "married_life")
                    {
                        strArrays = new string[] { "select *from A_mix_dasha (nolock)  where ptype='", ptype, "' and  (married_life=1 or inlaw=1 or love_affair=1) and  planethouse like('%", planet.ToString(), "%')" };
                        dbCommand.CommandText = string.Concat(strArrays);
                    }
                    if (cat == "occupation")
                    {
                        strArrays = new string[] { "select *from A_mix_dasha (nolock)  where  ptype='", ptype, "' and (occupation=1 or education=1 or wealth=1) and  planethouse like('%", planet.ToString(), "%')" };
                        dbCommand.CommandText = string.Concat(strArrays);
                    }
                    if (cat == "work_pred")
                    {
                        strArrays = new string[] { "select *from A_mix_dasha (nolock)  where  ptype='", ptype, "' and (work_pred=1) and   planethouse like('%", planet.ToString(), "%')" };
                        dbCommand.CommandText = string.Concat(strArrays);
                    }
                    if (cat == "parents")
                    {
                        strArrays = new string[] { "select *from A_mix_dasha (nolock)  where  ptype='", ptype, "' and (parents=1) and   planethouse like('%", planet.ToString(), "%')" };
                        dbCommand.CommandText = string.Concat(strArrays);
                    }
                    if (cat == "santan")
                    {
                        strArrays = new string[] { "select *from A_mix_dasha (nolock)  where  ptype='", ptype, "' and (santan=1) and   planethouse like('%", planet.ToString(), "%')" };
                        dbCommand.CommandText = string.Concat(strArrays);
                    }
                    if (cat == "nature")
                    {
                        strArrays = new string[] { "select *from A_mix_dasha (nolock)  where  ptype='", ptype, "' and (nature=1 or general=1) and   planethouse like('%", planet.ToString(), "%')" };
                        dbCommand.CommandText = string.Concat(strArrays);
                    }
                }
                else
                {
                    strArrays = new string[] { "select *from A_mix_dasha (nolock)  where   ptype='", ptype, "' and planethouse like('%", planet.ToString(), "%')" };
                    dbCommand.CommandText = string.Concat(strArrays);
                }
                if (ptype == "multi")
                {
                    if ((cat == "all" ? true : cat.Trim().Length <= 0))
                    {
                        dbCommand.CommandText = string.Concat("select *from A_mix_dasha (nolock)  where   ptype='", ptype, "' and planet1=", planet.ToString());
                    }
                }
            }
            if ((ptype == "fulllifeadult" ? true : ptype == "fulllifechild"))
            {
                str = new object[] { "select *from A_mix_dasha (nolock)  where   ptype='", ptype, "' and planethouse like('%", planet.ToString(), "#", house, "%')" };
                dbCommand.CommandText = string.Concat(str);
            }
            if (ptype == "fullyog")
            {
                dbCommand.CommandText = string.Concat("select *from A_mix_dasha (nolock)  where ptype='fullyog' and  planethouse like('%", planet.ToString(), "#%')");
            }
            if (ptype == "fullyuti")
            {
                dbCommand.CommandText = string.Concat("select *from A_mix_dasha (nolock)  where ptype='fullyuti' and  yuticombi like('%", planet.ToString(), ",%')  order by lawtype DESC");
            }
            if (ptype == "fulltriangle")
            {
                dbCommand.CommandText = string.Concat("select *from A_mix_dasha (nolock)  where ptype='fulltriangle' and  planethouse like('%", planet.ToString(), "#%')");
            }
            if (cat == "work_pred")
            {
                str = new object[] { "select *from A_mix_dasha (nolock)  where (work_pred=1) and  planethouse like('%", planet.ToString(), "#", house, "%')" };
                dbCommand.CommandText = string.Concat(str);
            }
            if (ptype == "fulllife_gems")
            {
                str = new object[] { "select *from A_mix_dasha (nolock)  where ptype='fulllife_gems' and planethouse like('%", planet.ToString(), "#", house, "%')" };
                dbCommand.CommandText = string.Concat(str);
            }
            if (ptype == "khabar")
            {
                dbCommand.CommandText = string.Concat("select *from A_mix_dasha (nolock)  where ptype='khabar' and planet1=", planet.ToString(), " and house1=", house.ToString());
            }
            if (ptype == "redsigni")
            {
                dbCommand.CommandText = "select *from A_mix_dasha (nolock)  where ptype='redsigni'";
            }
            if (ptype == "restredsigni")
            {
                dbCommand.CommandText = "select *from A_mix_dasha (nolock) where ptype='dasha' and planet2=0 and planet3=0 and planet4=0 and planet5=0 and ref!='vfal' and lawtype='dasha'";
            }
            if (ptype == "house_dasha")
            {
                str = new object[] { "select *from A_mix_dasha (nolock) where ptype='dasha' and house2=0 and ref!='vfal' and lawtype!='mangalbad' and planethouse like('%", planet.ToString(), "#", house, "%')" };
                dbCommand.CommandText = string.Concat(str);
            }
            if (ptype == "all_varshfal")
            {
                dbCommand.CommandText = "select *from A_mix_dasha (nolock) where ptype='fullvfal'";
            }
            if (ptype == "all_monthfal")
            {
                dbCommand.CommandText = "select *from A_mix_dasha (nolock) where ptype='fullmfal'";
            }
            if (ptype == "general_varshfal")
            {
                str = new object[] { "select *from A_mix_dasha (nolock)  where ptype='dasha' and lawtype='dasha' and work_pred=0 and planethouse like('%", planet.ToString(), "#", house, "%')" };
                dbCommand.CommandText = string.Concat(str);
            }
            KundliBLL kundliBLL = new KundliBLL();
            foreach (DataRow row in GenericDataAccess.ExecuteSelectCommand(dbCommand).Rows)
            {
                KPMixDashaVO kPMixDashaVO = new KPMixDashaVO()
                {
                    Sno = Convert.ToInt16(row["sno"]),
                    tid = Convert.ToInt16(row["tid"]),
                    Planet1 = Convert.ToInt16(row["planet1"]),
                    House1 = Convert.ToInt16(row["house1"]),
                    Planet2 = Convert.ToInt16(row["planet2"]),
                    House2 = Convert.ToInt16(row["house2"]),
                    Planet3 = Convert.ToInt16(row["planet3"]),
                    House3 = Convert.ToInt16(row["house3"]),
                    Planet4 = Convert.ToInt16(row["planet4"]),
                    House4 = Convert.ToInt16(row["house4"]),
                    Planet5 = Convert.ToInt16(row["planet5"]),
                    House5 = Convert.ToInt16(row["house5"]),
                    Isbad = Convert.ToBoolean(row["isbad"]),
                    verybad = Convert.ToBoolean(row["verybad"]),
                    planethouse = row["planethouse"].ToString(),
                    yuticombi = row["yuticombi"].ToString(),
                    orplanet = row["orplanet"].ToString(),
                    not_orplanet = row["not_orplanet"].ToString(),
                    andplanet = row["andplanet"].ToString(),
                    not_andplanet = row["not_andplanet"].ToString(),
                    yutihouse = row["yutihouse"].ToString(),
                    conj = row["conj"].ToString(),
                    not_conj = row["not_conj"].ToString(),
                    drishti = row["drishti"].ToString(),
                    not_drishti = row["not_drishti"].ToString(),
                    not_empty = row["not_empty"].ToString(),
                    lawtype = row["lawtype"].ToString(),
                    ptype = row["ptype"].ToString(),
                    Pred_Hindi = row["pred_hindi"].ToString(),
                    Pred_English = row["pred_english"].ToString(),
                    shubh = row["shubh"].ToString(),
                    ashubh = row["ashubh"].ToString(),
                    empty = row["empty"].ToString(),
                    common = Convert.ToBoolean(row["common"]),
                    male = Convert.ToBoolean(row["male"]),
                    female = Convert.ToBoolean(row["female"]),
                    Signi = row["signi"].ToString(),
                    wealth = Convert.ToBoolean(row["wealth"]),
                    santan = Convert.ToBoolean(row["santan"]),
                    married_life = Convert.ToBoolean(row["married_life"]),
                    work_pred = Convert.ToBoolean(row["work_pred"]),
                    occupation = Convert.ToBoolean(row["occupation"]),
                    disease = Convert.ToBoolean(row["disease"]),
                    love_affair = Convert.ToBoolean(row["love_affair"]),
                    general = Convert.ToBoolean(row["general"]),
                    sibling = Convert.ToBoolean(row["sibling"]),
                    parents = Convert.ToBoolean(row["parents"]),
                    nature = Convert.ToBoolean(row["nature"]),
                    precaution = Convert.ToBoolean(row["precaution"]),
                    uncle = Convert.ToBoolean(row["uncle"]),
                    inlaw = Convert.ToBoolean(row["inlaw"]),
                    family = Convert.ToBoolean(row["family"]),
                    travel = Convert.ToBoolean(row["travel"]),
                    education = Convert.ToBoolean(row["education"]),
                    age = Convert.ToBoolean(row["age"]),
                    spl_yog = Convert.ToBoolean(row["spl_yog"]),
                    reff = row["ref"].ToString(),
                    rules = row["rules"].ToString()
                };
                if (Convert.ToInt64(row["age1"]) == (long)1)
                {
                    kPMixDashaVO.Talak = true;
                }
                if (Convert.ToInt64(row["age2"]) == (long)1)
                {
                    kPMixDashaVO.ShadiYog = true;
                }
                kPMixDashaVO.Upay = Convert.ToInt64(row["upay"]);
                kPMixDashaVOs.Add(kPMixDashaVO);
            }
            if (cat != "work_pred")
            {
                kPMixDashaVOs = (
                    from Map in kPMixDashaVOs
                    where !Map.work_pred
                    select Map).ToList<KPMixDashaVO>();
            }
            return kPMixDashaVOs;
        }

        public List<KPMixDashaVO> Get_Mix_Dasha_Planet_Wise(short planet, short house, short fieldno, string cat, string ptype)
        {
            string[] strArrays;
            List<KPMixDashaVO> kPMixDashaVOs = new List<KPMixDashaVO>();
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            if (!(cat == "all"))
            {
                if (cat == "disease")
                {
                    strArrays = new string[] { "select *from A_mix_dasha (nolock)  where ptype='", ptype, "' and disease=1 and  planethouse like('%", planet.ToString(), "#", house.ToString(), "')" };
                    dbCommand.CommandText = string.Concat(strArrays);
                }
                if (cat == "married_life")
                {
                    strArrays = new string[] { "select *from A_mix_dasha (nolock)  where ptype='", ptype, "' and  (married_life=1 or inlaw=1 or love_affair=1) and  planethouse like('%", planet.ToString(), "#", house.ToString(), "')" };
                    dbCommand.CommandText = string.Concat(strArrays);
                }
                if (cat == "occupation")
                {
                    strArrays = new string[] { "select *from A_mix_dasha (nolock)  where ptype='", ptype, "' and  (occupation=1 or education=1 or wealth=1) and  planethouse like('%", planet.ToString(), "#", house.ToString(), "')" };
                    dbCommand.CommandText = string.Concat(strArrays);
                }
                if (cat == "work_pred")
                {
                    strArrays = new string[] { "select *from A_mix_dasha (nolock)  where  ptype='", ptype, "' and (work_pred=1) and   planethouse like('%", planet.ToString(), "#", house.ToString(), "')" };
                    dbCommand.CommandText = string.Concat(strArrays);
                }
                if (cat == "parents")
                {
                    strArrays = new string[] { "select *from A_mix_dasha (nolock)  where ptype='", ptype, "' and  (parents=1) and   planethouse like('%", planet.ToString(), "#", house.ToString(), "')" };
                    dbCommand.CommandText = string.Concat(strArrays);
                }
                if (cat == "santan")
                {
                    strArrays = new string[] { "select *from A_mix_dasha (nolock)  where  ptype='", ptype, "' and (santan=1) and   planethouse like('%", planet.ToString(), "#", house.ToString(), "')" };
                    dbCommand.CommandText = string.Concat(strArrays);
                }
                if (cat == "nature")
                {
                    strArrays = new string[] { "select *from A_mix_dasha (nolock)  where  ptype='", ptype, "' and (nature=1 or general=1) and   planethouse like('%", planet.ToString(), "#')" };
                    dbCommand.CommandText = string.Concat(strArrays);
                }
            }
            else
            {
                strArrays = new string[] { "select *from A_mix_dasha (nolock)  where ptype='", ptype, "' and planethouse like('%", planet.ToString(), "#", house.ToString(), "')" };
                dbCommand.CommandText = string.Concat(strArrays);
            }
            KundliBLL kundliBLL = new KundliBLL();
            foreach (DataRow row in GenericDataAccess.ExecuteSelectCommand(dbCommand).Rows)
            {
                KPMixDashaVO kPMixDashaVO = new KPMixDashaVO()
                {
                    Sno = Convert.ToInt16(row["sno"]),
                    tid = Convert.ToInt16(row["tid"]),
                    Planet1 = Convert.ToInt16(row["planet1"]),
                    House1 = Convert.ToInt16(row["house1"]),
                    Planet2 = Convert.ToInt16(row["planet2"]),
                    House2 = Convert.ToInt16(row["house2"]),
                    Planet3 = Convert.ToInt16(row["planet3"]),
                    House3 = Convert.ToInt16(row["house3"]),
                    Planet4 = Convert.ToInt16(row["planet4"]),
                    House4 = Convert.ToInt16(row["house4"]),
                    Planet5 = Convert.ToInt16(row["planet5"]),
                    House5 = Convert.ToInt16(row["house5"]),
                    Isbad = Convert.ToBoolean(row["isbad"]),
                    verybad = Convert.ToBoolean(row["verybad"]),
                    planethouse = row["planethouse"].ToString(),
                    yuticombi = row["yuticombi"].ToString(),
                    orplanet = row["orplanet"].ToString(),
                    not_orplanet = row["not_orplanet"].ToString(),
                    andplanet = row["andplanet"].ToString(),
                    not_andplanet = row["not_andplanet"].ToString(),
                    yutihouse = row["yutihouse"].ToString(),
                    conj = row["conj"].ToString(),
                    not_conj = row["not_conj"].ToString(),
                    drishti = row["drishti"].ToString(),
                    not_drishti = row["not_drishti"].ToString(),
                    not_empty = row["not_empty"].ToString(),
                    lawtype = row["lawtype"].ToString(),
                    ptype = row["ptype"].ToString(),
                    Pred_Hindi = row["pred_hindi"].ToString(),
                    Pred_English = row["pred_english"].ToString(),
                    shubh = row["shubh"].ToString(),
                    ashubh = row["ashubh"].ToString(),
                    empty = row["empty"].ToString(),
                    common = Convert.ToBoolean(row["common"]),
                    male = Convert.ToBoolean(row["male"]),
                    female = Convert.ToBoolean(row["female"]),
                    Signi = row["signi"].ToString(),
                    wealth = Convert.ToBoolean(row["wealth"]),
                    santan = Convert.ToBoolean(row["santan"]),
                    married_life = Convert.ToBoolean(row["married_life"]),
                    work_pred = Convert.ToBoolean(row["work_pred"]),
                    occupation = Convert.ToBoolean(row["occupation"]),
                    disease = Convert.ToBoolean(row["disease"]),
                    love_affair = Convert.ToBoolean(row["love_affair"]),
                    general = Convert.ToBoolean(row["general"]),
                    sibling = Convert.ToBoolean(row["sibling"]),
                    parents = Convert.ToBoolean(row["parents"]),
                    nature = Convert.ToBoolean(row["nature"]),
                    precaution = Convert.ToBoolean(row["precaution"]),
                    uncle = Convert.ToBoolean(row["uncle"]),
                    inlaw = Convert.ToBoolean(row["inlaw"]),
                    family = Convert.ToBoolean(row["family"]),
                    travel = Convert.ToBoolean(row["travel"]),
                    education = Convert.ToBoolean(row["education"]),
                    age = Convert.ToBoolean(row["age"]),
                    spl_yog = Convert.ToBoolean(row["spl_yog"]),
                    reff = row["ref"].ToString(),
                    rules = row["rules"].ToString()
                };
                if (Convert.ToInt64(row["age1"]) == (long)1)
                {
                    kPMixDashaVO.Talak = true;
                }
                if (Convert.ToInt64(row["age2"]) == (long)1)
                {
                    kPMixDashaVO.ShadiYog = true;
                }
                kPMixDashaVO.Upay = Convert.ToInt64(row["upay"]);
                kPMixDashaVOs.Add(kPMixDashaVO);
            }
            return kPMixDashaVOs;
        }

        public List<KPPlanetChainVO> Get_Planet_Chain()
        {
            List<KPPlanetChainVO> kPPlanetChainVOs = new List<KPPlanetChainVO>();
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            dbCommand.CommandText = "select *from A_kp_planet_chain (nolock)";
            KundliBLL kundliBLL = new KundliBLL();
            foreach (DataRow row in GenericDataAccess.ExecuteSelectCommand(dbCommand).Rows)
            {
                KPPlanetChainVO kPPlanetChainVO = new KPPlanetChainVO()
                {
                    Sno = Convert.ToInt16(row["sno"]),
                    Signi = row["signi"].ToString(),
                    Planet = Convert.ToInt16(row["Planet"]),
                    Pred_Hindi = row["pred_hindi"].ToString(),
                    Pred_English = row["pred_english"].ToString(),
                    Ptype = row["ptype"].ToString(),
                    wealth = Convert.ToBoolean(row["wealth"]),
                    children = Convert.ToBoolean(row["children"]),
                    married = Convert.ToBoolean(row["married"]),
                    occupation = Convert.ToBoolean(row["occupation"]),
                    disease = Convert.ToBoolean(row["disease"]),
                    love_affair = Convert.ToBoolean(row["love_affair"]),
                    general = Convert.ToBoolean(row["general"]),
                    brother = Convert.ToBoolean(row["brother"]),
                    mother_father = Convert.ToBoolean(row["mother_father"]),
                    Isbad = Convert.ToBoolean(row["isbad"]),
                    VeryBad = Convert.ToBoolean(row["verybad"]),
                    common = Convert.ToBoolean(row["common"]),
                    male = Convert.ToBoolean(row["male"]),
                    female = Convert.ToBoolean(row["female"]),
                    shishu = Convert.ToBoolean(row["shishu"]),
                    bachpan = Convert.ToBoolean(row["bachpan"]),
                    kishor = Convert.ToBoolean(row["kishor"]),
                    yuva = Convert.ToBoolean(row["yuva"]),
                    madhya = Convert.ToBoolean(row["madhya"]),
                    budhapa = Convert.ToBoolean(row["budhapa"])
                };
                kPPlanetChainVOs.Add(kPPlanetChainVO);
            }
            return kPPlanetChainVOs;
        }

        public List<KPRemediesVO> Get_Remedies(string ptype)
        {
            List<KPRemediesVO> kPRemediesVOs = new List<KPRemediesVO>();
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            dbCommand.CommandText = string.Concat("select *from A_kp_remedy (nolock) where ptype='", ptype, "'");
            KundliBLL kundliBLL = new KundliBLL();
            foreach (DataRow row in GenericDataAccess.ExecuteSelectCommand(dbCommand).Rows)
            {
                KPRemediesVO kPRemediesVO = new KPRemediesVO()
                {
                    Sno = Convert.ToInt16(row["sno"]),
                    Planet = Convert.ToInt16(row["planet"].ToString()),
                    House = Convert.ToInt16(row["house"].ToString()),
                    RuleCode = Convert.ToInt16(row["rulecode"].ToString()),
                    Pred_Hindi = row["pred_hindi"].ToString(),
                    Pred_English = row["pred_english"].ToString(),
                    Pred_Marathi = row["pred_marathi"].ToString(),
                    Ptype = row["ptype"].ToString(),
                    Planethouse = row["planethouse"].ToString()
                };
                kPRemediesVOs.Add(kPRemediesVO);
            }
            return kPRemediesVOs;
        }

        public List<KPRinnPitriVO> Get_Rinn_Pitri()
        {
            List<KPRinnPitriVO> kPRinnPitriVOs = new List<KPRinnPitriVO>();
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            dbCommand.CommandText = "select *from A_kp_rinn_pitri";
            foreach (DataRow row in GenericDataAccess.ExecuteSelectCommand(dbCommand).Rows)
            {
                KPRinnPitriVO kPRinnPitriVO = new KPRinnPitriVO()
                {
                    Sno = Convert.ToInt16(row["sno"]),
                    InHouse = row["inhouse"].ToString(),
                    OutHouse = row["outhouse"].ToString(),
                    pred_hindi = row["pred_hindi"].ToString(),
                    pred_english = row["pred_english"].ToString(),
                    pred_punjabi = row["pred_punjabi"].ToString(),
                    pred_tamil = row["pred_tamil"].ToString(),
                    pred_telugu = row["pred_telugu"].ToString(),
                    pred_oriya = row["pred_oriya"].ToString(),
                    pred_bengali = row["pred_bengali"].ToString(),
                    pred_malayalam = row["pred_malayalam"].ToString(),
                    pred_marathi = row["pred_marathi"].ToString(),
                    pred_assamese = row["pred_assamese"].ToString(),
                    pred_gujarati = row["pred_gujarati"].ToString(),
                    pred_kannada = row["pred_kannada"].ToString()
                };
                kPRinnPitriVOs.Add(kPRinnPitriVO);
            }
            return kPRinnPitriVOs;
        }

        public List<KPUpay> Get_Upay_Logic()
        {
            List<KPUpay> kPUpays = new List<KPUpay>();
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            dbCommand.CommandText = "select *from A_kp_upay (nolock)  order by main_house";
            KundliBLL kundliBLL = new KundliBLL();
            foreach (DataRow row in GenericDataAccess.ExecuteSelectCommand(dbCommand).Rows)
            {
                KPUpay kPUpay = new KPUpay()
                {
                    House = Convert.ToInt16(row["main_house"]),
                    Problem = row["ktype"].ToString(),
                    Good = row["pos_house"].ToString(),
                    Bad = row["neg_house"].ToString()
                };
                kPUpays.Add(kPUpay);
            }
            return kPUpays;
        }

        public List<KP249VO> Get249()
        {
            List<KP249VO> kP249VOs = new List<KP249VO>();
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            dbCommand.CommandText = "select  * from  A_kp_nak order by rashi";
            KundliBLL kundliBLL = new KundliBLL();
            foreach (DataRow row in GenericDataAccess.ExecuteSelectCommand(dbCommand).Rows)
            {
                KP249VO kP249VO = new KP249VO()
                {
                    Sno = Convert.ToInt16(row["sno"]),
                    Rashi = Convert.ToInt16(row["rashi"]),
                    From_Degree = row["from_degree"].ToString(),
                    To_Degree = row["to_degree"].ToString()
                };
                string fromDegree = kP249VO.From_Degree;
                char[] chrArray = new char[] { ':' };
                double num = Convert.ToDouble(fromDegree.Split(chrArray)[0]);
                string str = kP249VO.From_Degree;
                chrArray = new char[] { ':' };
                double num1 = Convert.ToDouble(str.Split(chrArray)[1]);
                string fromDegree1 = kP249VO.From_Degree;
                chrArray = new char[] { ':' };
                kP249VO.From_Degree_Decimal = kundliBLL.DMStoDecimal(num, num1, Convert.ToDouble(fromDegree1.Split(chrArray)[2]));
                string toDegree = kP249VO.To_Degree;
                chrArray = new char[] { ':' };
                double num2 = Convert.ToDouble(toDegree.Split(chrArray)[0]);
                string toDegree1 = kP249VO.To_Degree;
                chrArray = new char[] { ':' };
                double num3 = Convert.ToDouble(toDegree1.Split(chrArray)[1]);
                string str1 = kP249VO.To_Degree;
                chrArray = new char[] { ':' };
                kP249VO.To_Degree_Decimal = kundliBLL.DMStoDecimal(num2, num3, Convert.ToDouble(str1.Split(chrArray)[2]));
                kP249VO.Rashi_Lord = Convert.ToInt16(row["rashi_lord"]);
                kP249VO.Nak_Lord = Convert.ToInt16(row["nak_lord"]);
                kP249VO.Sub_Lord = Convert.ToInt16(row["sub_lord"]);
                KP249SubSubLordVO kP249SubSubLordVO = new KP249SubSubLordVO()
                {
                    Planet = Convert.ToInt16(row["greh1"]),
                    From_Degree = row["time1_from"].ToString(),
                    To_Degree = row["time1_to"].ToString()
                };
                string fromDegree2 = kP249SubSubLordVO.From_Degree;
                chrArray = new char[] { ':' };
                double num4 = Convert.ToDouble(fromDegree2.Split(chrArray)[0]);
                string str2 = kP249SubSubLordVO.From_Degree;
                chrArray = new char[] { ':' };
                double num5 = Convert.ToDouble(str2.Split(chrArray)[1]);
                string fromDegree3 = kP249SubSubLordVO.From_Degree;
                chrArray = new char[] { ':' };
                kP249SubSubLordVO.From_Degree_Decimal = kundliBLL.DMStoDecimal(num4, num5, Convert.ToDouble(fromDegree3.Split(chrArray)[2]));
                string toDegree2 = kP249SubSubLordVO.To_Degree;
                chrArray = new char[] { ':' };
                double num6 = Convert.ToDouble(toDegree2.Split(chrArray)[0]);
                string toDegree3 = kP249SubSubLordVO.To_Degree;
                chrArray = new char[] { ':' };
                double num7 = Convert.ToDouble(toDegree3.Split(chrArray)[1]);
                string str3 = kP249SubSubLordVO.To_Degree;
                chrArray = new char[] { ':' };
                kP249SubSubLordVO.To_Degree_Decimal = kundliBLL.DMStoDecimal(num6, num7, Convert.ToDouble(str3.Split(chrArray)[2]));
                kP249VO.Sub_Sub_Lord.Add(kP249SubSubLordVO);
                kP249SubSubLordVO = new KP249SubSubLordVO()
                {
                    Planet = Convert.ToInt16(row["greh2"]),
                    From_Degree = row["time2_from"].ToString(),
                    To_Degree = row["time2_to"].ToString()
                };
                string fromDegree4 = kP249SubSubLordVO.From_Degree;
                chrArray = new char[] { ':' };
                double num8 = Convert.ToDouble(fromDegree4.Split(chrArray)[0]);
                string str4 = kP249SubSubLordVO.From_Degree;
                chrArray = new char[] { ':' };
                double num9 = Convert.ToDouble(str4.Split(chrArray)[1]);
                string fromDegree5 = kP249SubSubLordVO.From_Degree;
                chrArray = new char[] { ':' };
                kP249SubSubLordVO.From_Degree_Decimal = kundliBLL.DMStoDecimal(num8, num9, Convert.ToDouble(fromDegree5.Split(chrArray)[2]));
                string toDegree4 = kP249SubSubLordVO.To_Degree;
                chrArray = new char[] { ':' };
                double num10 = Convert.ToDouble(toDegree4.Split(chrArray)[0]);
                string toDegree5 = kP249SubSubLordVO.To_Degree;
                chrArray = new char[] { ':' };
                double num11 = Convert.ToDouble(toDegree5.Split(chrArray)[1]);
                string str5 = kP249SubSubLordVO.To_Degree;
                chrArray = new char[] { ':' };
                kP249SubSubLordVO.To_Degree_Decimal = kundliBLL.DMStoDecimal(num10, num11, Convert.ToDouble(str5.Split(chrArray)[2]));
                kP249VO.Sub_Sub_Lord.Add(kP249SubSubLordVO);
                kP249SubSubLordVO = new KP249SubSubLordVO()
                {
                    Planet = Convert.ToInt16(row["greh3"]),
                    From_Degree = row["time3_from"].ToString(),
                    To_Degree = row["time3_to"].ToString()
                };
                string fromDegree6 = kP249SubSubLordVO.From_Degree;
                chrArray = new char[] { ':' };
                double num12 = Convert.ToDouble(fromDegree6.Split(chrArray)[0]);
                string str6 = kP249SubSubLordVO.From_Degree;
                chrArray = new char[] { ':' };
                double num13 = Convert.ToDouble(str6.Split(chrArray)[1]);
                string fromDegree7 = kP249SubSubLordVO.From_Degree;
                chrArray = new char[] { ':' };
                kP249SubSubLordVO.From_Degree_Decimal = kundliBLL.DMStoDecimal(num12, num13, Convert.ToDouble(fromDegree7.Split(chrArray)[2]));
                string toDegree6 = kP249SubSubLordVO.To_Degree;
                chrArray = new char[] { ':' };
                double num14 = Convert.ToDouble(toDegree6.Split(chrArray)[0]);
                string toDegree7 = kP249SubSubLordVO.To_Degree;
                chrArray = new char[] { ':' };
                double num15 = Convert.ToDouble(toDegree7.Split(chrArray)[1]);
                string str7 = kP249SubSubLordVO.To_Degree;
                chrArray = new char[] { ':' };
                kP249SubSubLordVO.To_Degree_Decimal = kundliBLL.DMStoDecimal(num14, num15, Convert.ToDouble(str7.Split(chrArray)[2]));
                kP249VO.Sub_Sub_Lord.Add(kP249SubSubLordVO);
                kP249SubSubLordVO = new KP249SubSubLordVO()
                {
                    Planet = Convert.ToInt16(row["greh4"]),
                    From_Degree = row["time4_from"].ToString(),
                    To_Degree = row["time4_to"].ToString()
                };
                string fromDegree8 = kP249SubSubLordVO.From_Degree;
                chrArray = new char[] { ':' };
                double num16 = Convert.ToDouble(fromDegree8.Split(chrArray)[0]);
                string str8 = kP249SubSubLordVO.From_Degree;
                chrArray = new char[] { ':' };
                double num17 = Convert.ToDouble(str8.Split(chrArray)[1]);
                string fromDegree9 = kP249SubSubLordVO.From_Degree;
                chrArray = new char[] { ':' };
                kP249SubSubLordVO.From_Degree_Decimal = kundliBLL.DMStoDecimal(num16, num17, Convert.ToDouble(fromDegree9.Split(chrArray)[2]));
                string toDegree8 = kP249SubSubLordVO.To_Degree;
                chrArray = new char[] { ':' };
                double num18 = Convert.ToDouble(toDegree8.Split(chrArray)[0]);
                string toDegree9 = kP249SubSubLordVO.To_Degree;
                chrArray = new char[] { ':' };
                double num19 = Convert.ToDouble(toDegree9.Split(chrArray)[1]);
                string str9 = kP249SubSubLordVO.To_Degree;
                chrArray = new char[] { ':' };
                kP249SubSubLordVO.To_Degree_Decimal = kundliBLL.DMStoDecimal(num18, num19, Convert.ToDouble(str9.Split(chrArray)[2]));
                kP249VO.Sub_Sub_Lord.Add(kP249SubSubLordVO);
                kP249SubSubLordVO = new KP249SubSubLordVO()
                {
                    Planet = Convert.ToInt16(row["greh5"]),
                    From_Degree = row["time5_from"].ToString(),
                    To_Degree = row["time5_to"].ToString()
                };
                string fromDegree10 = kP249SubSubLordVO.From_Degree;
                chrArray = new char[] { ':' };
                double num20 = Convert.ToDouble(fromDegree10.Split(chrArray)[0]);
                string str10 = kP249SubSubLordVO.From_Degree;
                chrArray = new char[] { ':' };
                double num21 = Convert.ToDouble(str10.Split(chrArray)[1]);
                string fromDegree11 = kP249SubSubLordVO.From_Degree;
                chrArray = new char[] { ':' };
                kP249SubSubLordVO.From_Degree_Decimal = kundliBLL.DMStoDecimal(num20, num21, Convert.ToDouble(fromDegree11.Split(chrArray)[2]));
                string toDegree10 = kP249SubSubLordVO.To_Degree;
                chrArray = new char[] { ':' };
                double num22 = Convert.ToDouble(toDegree10.Split(chrArray)[0]);
                string toDegree11 = kP249SubSubLordVO.To_Degree;
                chrArray = new char[] { ':' };
                double num23 = Convert.ToDouble(toDegree11.Split(chrArray)[1]);
                string str11 = kP249SubSubLordVO.To_Degree;
                chrArray = new char[] { ':' };
                kP249SubSubLordVO.To_Degree_Decimal = kundliBLL.DMStoDecimal(num22, num23, Convert.ToDouble(str11.Split(chrArray)[2]));
                kP249VO.Sub_Sub_Lord.Add(kP249SubSubLordVO);
                kP249SubSubLordVO = new KP249SubSubLordVO()
                {
                    Planet = Convert.ToInt16(row["greh6"]),
                    From_Degree = row["time6_from"].ToString(),
                    To_Degree = row["time6_to"].ToString()
                };
                string fromDegree12 = kP249SubSubLordVO.From_Degree;
                chrArray = new char[] { ':' };
                double num24 = Convert.ToDouble(fromDegree12.Split(chrArray)[0]);
                string str12 = kP249SubSubLordVO.From_Degree;
                chrArray = new char[] { ':' };
                double num25 = Convert.ToDouble(str12.Split(chrArray)[1]);
                string fromDegree13 = kP249SubSubLordVO.From_Degree;
                chrArray = new char[] { ':' };
                kP249SubSubLordVO.From_Degree_Decimal = kundliBLL.DMStoDecimal(num24, num25, Convert.ToDouble(fromDegree13.Split(chrArray)[2]));
                string toDegree12 = kP249SubSubLordVO.To_Degree;
                chrArray = new char[] { ':' };
                double num26 = Convert.ToDouble(toDegree12.Split(chrArray)[0]);
                string toDegree13 = kP249SubSubLordVO.To_Degree;
                chrArray = new char[] { ':' };
                double num27 = Convert.ToDouble(toDegree13.Split(chrArray)[1]);
                string str13 = kP249SubSubLordVO.To_Degree;
                chrArray = new char[] { ':' };
                kP249SubSubLordVO.To_Degree_Decimal = kundliBLL.DMStoDecimal(num26, num27, Convert.ToDouble(str13.Split(chrArray)[2]));
                kP249VO.Sub_Sub_Lord.Add(kP249SubSubLordVO);
                kP249SubSubLordVO = new KP249SubSubLordVO()
                {
                    Planet = Convert.ToInt16(row["greh7"]),
                    From_Degree = row["time7_from"].ToString(),
                    To_Degree = row["time7_to"].ToString()
                };
                string fromDegree14 = kP249SubSubLordVO.From_Degree;
                chrArray = new char[] { ':' };
                double num28 = Convert.ToDouble(fromDegree14.Split(chrArray)[0]);
                string str14 = kP249SubSubLordVO.From_Degree;
                chrArray = new char[] { ':' };
                double num29 = Convert.ToDouble(str14.Split(chrArray)[1]);
                string fromDegree15 = kP249SubSubLordVO.From_Degree;
                chrArray = new char[] { ':' };
                kP249SubSubLordVO.From_Degree_Decimal = kundliBLL.DMStoDecimal(num28, num29, Convert.ToDouble(fromDegree15.Split(chrArray)[2]));
                string toDegree14 = kP249SubSubLordVO.To_Degree;
                chrArray = new char[] { ':' };
                double num30 = Convert.ToDouble(toDegree14.Split(chrArray)[0]);
                string toDegree15 = kP249SubSubLordVO.To_Degree;
                chrArray = new char[] { ':' };
                double num31 = Convert.ToDouble(toDegree15.Split(chrArray)[1]);
                string str15 = kP249SubSubLordVO.To_Degree;
                chrArray = new char[] { ':' };
                kP249SubSubLordVO.To_Degree_Decimal = kundliBLL.DMStoDecimal(num30, num31, Convert.ToDouble(str15.Split(chrArray)[2]));
                kP249VO.Sub_Sub_Lord.Add(kP249SubSubLordVO);
                kP249SubSubLordVO = new KP249SubSubLordVO()
                {
                    Planet = Convert.ToInt16(row["greh8"]),
                    From_Degree = row["time8_from"].ToString(),
                    To_Degree = row["time8_to"].ToString()
                };
                string fromDegree16 = kP249SubSubLordVO.From_Degree;
                chrArray = new char[] { ':' };
                double num32 = Convert.ToDouble(fromDegree16.Split(chrArray)[0]);
                string str16 = kP249SubSubLordVO.From_Degree;
                chrArray = new char[] { ':' };
                double num33 = Convert.ToDouble(str16.Split(chrArray)[1]);
                string fromDegree17 = kP249SubSubLordVO.From_Degree;
                chrArray = new char[] { ':' };
                kP249SubSubLordVO.From_Degree_Decimal = kundliBLL.DMStoDecimal(num32, num33, Convert.ToDouble(fromDegree17.Split(chrArray)[2]));
                string toDegree16 = kP249SubSubLordVO.To_Degree;
                chrArray = new char[] { ':' };
                double num34 = Convert.ToDouble(toDegree16.Split(chrArray)[0]);
                string toDegree17 = kP249SubSubLordVO.To_Degree;
                chrArray = new char[] { ':' };
                double num35 = Convert.ToDouble(toDegree17.Split(chrArray)[1]);
                string str17 = kP249SubSubLordVO.To_Degree;
                chrArray = new char[] { ':' };
                kP249SubSubLordVO.To_Degree_Decimal = kundliBLL.DMStoDecimal(num34, num35, Convert.ToDouble(str17.Split(chrArray)[2]));
                kP249VO.Sub_Sub_Lord.Add(kP249SubSubLordVO);
                kP249SubSubLordVO = new KP249SubSubLordVO()
                {
                    Planet = Convert.ToInt16(row["greh9"]),
                    From_Degree = row["time9_from"].ToString(),
                    To_Degree = row["time9_to"].ToString()
                };
                string fromDegree18 = kP249SubSubLordVO.From_Degree;
                chrArray = new char[] { ':' };
                double num36 = Convert.ToDouble(fromDegree18.Split(chrArray)[0]);
                string str18 = kP249SubSubLordVO.From_Degree;
                chrArray = new char[] { ':' };
                double num37 = Convert.ToDouble(str18.Split(chrArray)[1]);
                string fromDegree19 = kP249SubSubLordVO.From_Degree;
                chrArray = new char[] { ':' };
                kP249SubSubLordVO.From_Degree_Decimal = kundliBLL.DMStoDecimal(num36, num37, Convert.ToDouble(fromDegree19.Split(chrArray)[2]));
                string toDegree18 = kP249SubSubLordVO.To_Degree;
                chrArray = new char[] { ':' };
                double num38 = Convert.ToDouble(toDegree18.Split(chrArray)[0]);
                string toDegree19 = kP249SubSubLordVO.To_Degree;
                chrArray = new char[] { ':' };
                double num39 = Convert.ToDouble(toDegree19.Split(chrArray)[1]);
                string str19 = kP249SubSubLordVO.To_Degree;
                chrArray = new char[] { ':' };
                kP249SubSubLordVO.To_Degree_Decimal = kundliBLL.DMStoDecimal(num38, num39, Convert.ToDouble(str19.Split(chrArray)[2]));
                kP249VO.Sub_Sub_Lord.Add(kP249SubSubLordVO);
                kP249VOs.Add(kP249VO);
            }
            return kP249VOs;
        }
    }
}