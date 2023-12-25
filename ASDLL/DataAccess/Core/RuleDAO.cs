using ASDLL;
using AstroOfficeWeb.Shared.VOs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
//using AstroShared.Models;
namespace ASDLL.DataAccess.Core
{
    public class RuleDAO
    {
        public RuleDAO()
        {
        }

        public void AddRule(RulesVO rv, LangVO pred, string lang)
        {
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "AddRule";
            DbParameter ruleformula = dbCommand.CreateParameter();
            ruleformula.ParameterName = "@ruleformula";
            ruleformula.DbType = DbType.String;
            ruleformula.Value = rv.Ruleformula;
            DbParameter isbad = dbCommand.CreateParameter();
            isbad.ParameterName = "@isbad";
            isbad.DbType = DbType.Boolean;
            isbad.Value = rv.Isbad;
            DbParameter title = dbCommand.CreateParameter();
            title.ParameterName = "@title";
            title.DbType = DbType.String;
            title.Value = rv.Title;
            DbParameter actualformula = dbCommand.CreateParameter();
            actualformula.ParameterName = "@actualformula";
            actualformula.DbType = DbType.String;
            actualformula.Value = rv.Actualformula;
            DbParameter reference = dbCommand.CreateParameter();
            reference.ParameterName = "@ref";
            reference.DbType = DbType.String;
            reference.Value = rv.Reference;
            DbParameter ruleType = dbCommand.CreateParameter();
            ruleType.ParameterName = "@ruletype";
            ruleType.DbType = DbType.String;
            ruleType.Value = rv.RuleType;
            DbParameter commonPred = dbCommand.CreateParameter();
            commonPred.ParameterName = "@common_pred";
            commonPred.DbType = DbType.String;
            commonPred.Value = pred.Common_Pred;
            DbParameter malePred = dbCommand.CreateParameter();
            malePred.ParameterName = "@male_pred";
            malePred.DbType = DbType.String;
            malePred.Value = pred.Male_Pred;
            DbParameter femalePred = dbCommand.CreateParameter();
            femalePred.ParameterName = "@female_pred";
            femalePred.DbType = DbType.String;
            femalePred.Value = pred.Female_Pred;
            DbParameter childPred = dbCommand.CreateParameter();
            childPred.ParameterName = "@child_pred";
            childPred.DbType = DbType.String;
            childPred.Value = pred.Child_Pred;
            DbParameter dbParameter = dbCommand.CreateParameter();
            dbParameter.ParameterName = "@lang";
            dbParameter.DbType = DbType.String;
            dbParameter.Value = lang;
            DbParameter upay = dbCommand.CreateParameter();
            upay.ParameterName = "@upay";
            upay.DbType = DbType.Int32;
            upay.Value = rv.Upay;
            DbParameter priority = dbCommand.CreateParameter();
            priority.ParameterName = "@priority";
            priority.DbType = DbType.Int16;
            priority.Value = rv.Priority;
            DbParameter refNo = dbCommand.CreateParameter();
            refNo.ParameterName = "@refno";
            refNo.DbType = DbType.Int64;
            refNo.Value = rv.RefNo;
            DbParameter profit = dbCommand.CreateParameter();
            profit.ParameterName = "@profit";
            profit.DbType = DbType.Boolean;
            profit.Value = rv.Profit;
            DbParameter motherFather = dbCommand.CreateParameter();
            motherFather.ParameterName = "@mother_father";
            motherFather.DbType = DbType.Boolean;
            motherFather.Value = rv.Mother_father;
            DbParameter santan = dbCommand.CreateParameter();
            santan.ParameterName = "@santan";
            santan.DbType = DbType.Boolean;
            santan.Value = rv.Santan;
            DbParameter brother = dbCommand.CreateParameter();
            brother.ParameterName = "@brother";
            brother.DbType = DbType.Boolean;
            brother.Value = rv.Brother;
            DbParameter loveAffair = dbCommand.CreateParameter();
            loveAffair.ParameterName = "@love_affair";
            loveAffair.DbType = DbType.Boolean;
            loveAffair.Value = rv.Love_affair;
            DbParameter disease = dbCommand.CreateParameter();
            disease.ParameterName = "@disease";
            disease.DbType = DbType.Boolean;
            disease.Value = rv.Disease;
            DbParameter marriedlife = dbCommand.CreateParameter();
            marriedlife.ParameterName = "@marriedlife";
            marriedlife.DbType = DbType.Boolean;
            marriedlife.Value = rv.Marriedlife;
            DbParameter occupation = dbCommand.CreateParameter();
            occupation.ParameterName = "@occupation";
            occupation.DbType = DbType.Boolean;
            occupation.Value = rv.Occupation;
            DbParameter memory = dbCommand.CreateParameter();
            memory.ParameterName = "@memory";
            memory.DbType = DbType.Boolean;
            memory.Value = rv.Memory;
            DbParameter ruleNature = dbCommand.CreateParameter();
            ruleNature.ParameterName = "@rulenature";
            ruleNature.DbType = DbType.Int16;
            ruleNature.Value = rv.Rule_Nature;
            DbParameter vfalYears = dbCommand.CreateParameter();
            vfalYears.ParameterName = "@vfalyears";
            vfalYears.DbType = DbType.String;
            vfalYears.Value = rv.VfalYears;
            DbParameter confidence = dbCommand.CreateParameter();
            confidence.ParameterName = "@confidence";
            confidence.DbType = DbType.Boolean;
            confidence.Value = rv.Confidence;
            DbParameter common = dbCommand.CreateParameter();
            common.ParameterName = "@common";
            common.DbType = DbType.Boolean;
            common.Value = rv.Common;
            DbParameter male = dbCommand.CreateParameter();
            male.ParameterName = "@male";
            male.DbType = DbType.Boolean;
            male.Value = rv.Male;
            DbParameter female = dbCommand.CreateParameter();
            female.ParameterName = "@female";
            female.DbType = DbType.Boolean;
            female.Value = rv.Female;
            DbParameter bachpan = dbCommand.CreateParameter();
            bachpan.ParameterName = "@bachpan";
            bachpan.DbType = DbType.Boolean;
            bachpan.Value = rv.Bachpan;
            DbParameter kishor = dbCommand.CreateParameter();
            kishor.ParameterName = "@kishor";
            kishor.DbType = DbType.Boolean;
            kishor.Value = rv.Kishor;
            DbParameter yuva = dbCommand.CreateParameter();
            yuva.ParameterName = "@yuva";
            yuva.DbType = DbType.Boolean;
            yuva.Value = rv.Yuva;
            DbParameter madhya = dbCommand.CreateParameter();
            madhya.ParameterName = "@madhya";
            madhya.DbType = DbType.Boolean;
            madhya.Value = rv.Madhya;
            DbParameter budhapa = dbCommand.CreateParameter();
            budhapa.ParameterName = "@budhapa";
            budhapa.DbType = DbType.Boolean;
            budhapa.Value = rv.Budhapa;
            DbParameter mainplanet = dbCommand.CreateParameter();
            mainplanet.ParameterName = "@mainplanet";
            mainplanet.DbType = DbType.Int16;
            mainplanet.Value = rv.Mainplanet;
            DbParameter shishu = dbCommand.CreateParameter();
            shishu.ParameterName = "@shishu";
            shishu.DbType = DbType.Boolean;
            shishu.Value = rv.Shishu;
            DbParameter good = dbCommand.CreateParameter();
            good.ParameterName = "@good";
            good.DbType = DbType.String;
            good.Value = rv.Good;
            DbParameter bad = dbCommand.CreateParameter();
            bad.ParameterName = "@bad";
            bad.DbType = DbType.String;
            bad.Value = rv.Bad;
            DbParameter kayam = dbCommand.CreateParameter();
            kayam.ParameterName = "@kayam";
            kayam.DbType = DbType.String;
            kayam.Value = rv.Kayam;
            DbParameter multiUpay = dbCommand.CreateParameter();
            multiUpay.ParameterName = "@multiupay";
            multiUpay.DbType = DbType.String;
            multiUpay.Value = rv.MultiUpay;
            DbParameter planetUpay = dbCommand.CreateParameter();
            planetUpay.ParameterName = "@planetupay";
            planetUpay.DbType = DbType.String;
            planetUpay.Value = rv.PlanetUpay;
            DbParameter lagan = dbCommand.CreateParameter();
            lagan.ParameterName = "@lagan";
            lagan.DbType = DbType.String;
            lagan.Value = rv.Lagan;
            DbParameter rashi = dbCommand.CreateParameter();
            rashi.ParameterName = "@rashi";
            rashi.DbType = DbType.String;
            rashi.Value = rv.Rashi;
            dbCommand.Parameters.Add(ruleformula);
            dbCommand.Parameters.Add(isbad);
            dbCommand.Parameters.Add(title);
            dbCommand.Parameters.Add(actualformula);
            dbCommand.Parameters.Add(reference);
            dbCommand.Parameters.Add(ruleType);
            dbCommand.Parameters.Add(commonPred);
            dbCommand.Parameters.Add(malePred);
            dbCommand.Parameters.Add(femalePred);
            dbCommand.Parameters.Add(childPred);
            dbCommand.Parameters.Add(dbParameter);
            dbCommand.Parameters.Add(upay);
            dbCommand.Parameters.Add(priority);
            dbCommand.Parameters.Add(refNo);
            dbCommand.Parameters.Add(profit);
            dbCommand.Parameters.Add(motherFather);
            dbCommand.Parameters.Add(santan);
            dbCommand.Parameters.Add(brother);
            dbCommand.Parameters.Add(loveAffair);
            dbCommand.Parameters.Add(disease);
            dbCommand.Parameters.Add(marriedlife);
            dbCommand.Parameters.Add(occupation);
            dbCommand.Parameters.Add(memory);
            dbCommand.Parameters.Add(ruleNature);
            dbCommand.Parameters.Add(vfalYears);
            dbCommand.Parameters.Add(confidence);
            dbCommand.Parameters.Add(common);
            dbCommand.Parameters.Add(male);
            dbCommand.Parameters.Add(female);
            dbCommand.Parameters.Add(bachpan);
            dbCommand.Parameters.Add(kishor);
            dbCommand.Parameters.Add(yuva);
            dbCommand.Parameters.Add(madhya);
            dbCommand.Parameters.Add(budhapa);
            dbCommand.Parameters.Add(mainplanet);
            dbCommand.Parameters.Add(shishu);
            dbCommand.Parameters.Add(good);
            dbCommand.Parameters.Add(bad);
            dbCommand.Parameters.Add(kayam);
            dbCommand.Parameters.Add(multiUpay);
            dbCommand.Parameters.Add(planetUpay);
            dbCommand.Parameters.Add(lagan);
            dbCommand.Parameters.Add(rashi);
            GenericDataAccess.ExecuteSelectCommand(dbCommand);
        }

        public int CheckFormula(string actualformula)
        {
            int num;
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "CheckFormula";
            DbParameter dbParameter = dbCommand.CreateParameter();
            dbParameter.ParameterName = "@actualformula";
            dbParameter.DbType = DbType.String;
            dbParameter.Value = actualformula;
            DbParameter dbParameter1 = dbCommand.CreateParameter();
            dbParameter1.ParameterName = "@kundliid";
            dbParameter1.DbType = DbType.Int64;
            dbParameter1.Value = 26;
            dbCommand.Parameters.Add(dbParameter);
            dbCommand.Parameters.Add(dbParameter1);
            try
            {
                DataTable dataTable = GenericDataAccess.ExecuteSelectCommand(dbCommand);
                num = Convert.ToInt16(dataTable.Rows[0][0].ToString());
            }
            catch (Exception exception)
            {
                num = 2;
                _ = exception;

            }
            return num;
        }

        public List<AdditionalRulesVO> Get_AdditionalRules()
        {
            List<AdditionalRulesVO> additionalRulesVOs = new List<AdditionalRulesVO>();
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            dbCommand.CommandText = "select * from a_additionalrules (nolock) ";
            foreach (DataRow row in GenericDataAccess.ExecuteSelectCommand(dbCommand).Rows)
            {
                AdditionalRulesVO additionalRulesVO = new AdditionalRulesVO()
                {
                    Sno = Convert.ToInt64(row["sno"]),
                    RuleNo = Convert.ToInt64(row["ruleno"]),
                    Lagan = row["lagan"].ToString(),
                    Rashi = row["rashi"].ToString()
                };
                additionalRulesVOs.Add(additionalRulesVO);
            }
            return additionalRulesVOs;
        }

        public List<AstroLFVO> Get_AstroLF()
        {
            List<AstroLFVO> astroLFVOs = new List<AstroLFVO>();
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            dbCommand.CommandText = "select * from A_Astro_lf (nolock) ";
            foreach (DataRow row in GenericDataAccess.ExecuteSelectCommand(dbCommand).Rows)
            {
                AstroLFVO astroLFVO = new AstroLFVO()
                {
                    sno = Convert.ToInt16(row["sno"]),
                    lagna = Convert.ToInt16(row["lagna"]),
                    pred = row["pred"].ToString(),
                    english = row["english"].ToString(),
                    marathi = row["marathi"].ToString(),
                    punjabi = row["punjabi"].ToString()
                };
                astroLFVOs.Add(astroLFVO);
            }
            return astroLFVOs;
        }

        public List<AstroNFEVO> Get_AstroNFE()
        {
            List<AstroNFEVO> astroNFEVOs = new List<AstroNFEVO>();
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            dbCommand.CommandText = "select * from A_Astro_nfe (nolock) ";
            foreach (DataRow row in GenericDataAccess.ExecuteSelectCommand(dbCommand).Rows)
            {
                AstroNFEVO astroNFEVO = new AstroNFEVO()
                {
                    sno = Convert.ToInt16(row["sno"]),
                    planet = Convert.ToInt16(row["planet"]),
                    relation = Convert.ToInt16(row["relation"]),
                    pred = row["pred"].ToString(),
                    english = row["english"].ToString(),
                    marathi = row["marathi"].ToString(),
                    punjabi = row["punjabi"].ToString()
                };
                astroNFEVOs.Add(astroNFEVO);
            }
            return astroNFEVOs;
        }

        public List<AstroPHFVO> Get_AstroPHF()
        {
            List<AstroPHFVO> astroPHFVOs = new List<AstroPHFVO>();
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            dbCommand.CommandText = "select * from A_Astro_phf (nolock) ";
            foreach (DataRow row in GenericDataAccess.ExecuteSelectCommand(dbCommand).Rows)
            {
                AstroPHFVO astroPHFVO = new AstroPHFVO()
                {
                    sno = Convert.ToInt16(row["sno"]),
                    planet = Convert.ToInt16(row["planet"]),
                    house = Convert.ToInt16(row["house"]),
                    pred = row["pred"].ToString(),
                    english = row["english"].ToString(),
                    marathi = row["marathi"].ToString(),
                    punjabi = row["punjabi"].ToString()
                };
                astroPHFVOs.Add(astroPHFVO);
            }
            return astroPHFVOs;
        }

        public List<AstroPRDFVO> Get_AstroPRDF()
        {
            List<AstroPRDFVO> astroPRDFVOs = new List<AstroPRDFVO>();
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            dbCommand.CommandText = "select * from A_Astro_prdf (nolock) ";
            foreach (DataRow row in GenericDataAccess.ExecuteSelectCommand(dbCommand).Rows)
            {
                AstroPRDFVO astroPRDFVO = new AstroPRDFVO()
                {
                    sno = Convert.ToInt16(row["sno"]),
                    planet = Convert.ToInt16(row["planet"]),
                    rashi = Convert.ToInt16(row["rashi"]),
                    drishti = Convert.ToInt16(row["drishti"]),
                    pred = row["pred"].ToString(),
                    english = row["english"].ToString(),
                    marathi = row["marathi"].ToString(),
                    punjabi = row["punjabi"].ToString()
                };
                astroPRDFVOs.Add(astroPRDFVO);
            }
            return astroPRDFVOs;
        }

        public List<AstroRelation> Get_AstroRelation()
        {
            List<AstroRelation> astroRelations = new List<AstroRelation>();
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            dbCommand.CommandText = "select * from A_Astro_relation (nolock) ";
            foreach (DataRow row in GenericDataAccess.ExecuteSelectCommand(dbCommand).Rows)
            {
                AstroRelation astroRelation = new AstroRelation()
                {
                    sno = Convert.ToInt16(row["sno"]),
                    planet1 = Convert.ToInt16(row["planet1"]),
                    planet2 = Convert.ToInt16(row["planet2"]),
                    relation = Convert.ToInt16(row["relation"])
                };
                astroRelations.Add(astroRelation);
            }
            return astroRelations;
        }

        public List<CodeLangVO> Get_Code_Lang(bool paid, bool unicode)
        {
            List<CodeLangVO> codeLangVOs = new List<CodeLangVO>();
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            dbCommand.CommandText = "select * from A_code_lang (nolock) ";
            foreach (DataRow row in GenericDataAccess.ExecuteSelectCommand(dbCommand).Rows)
            {
                CodeLangVO codeLangVO = new CodeLangVO()
                {
                    sno = Convert.ToInt16(row["sno"]),
                    rulecode = row["rulecode"].ToString()
                };
                if (!unicode)
                {
                    codeLangVO.bangla = row["bangla"].ToString();
                    codeLangVO.english = row["english"].ToString();
                    codeLangVO.gujrati = row["gujrati"].ToString();
                    codeLangVO.kannada = row["kannada"].ToString();
                    codeLangVO.marathi = row["marathi"].ToString();
                    codeLangVO.punjabi = row["punjabi"].ToString();
                    codeLangVO.tamil = row["tamil"].ToString();
                    codeLangVO.telugu = row["telugu"].ToString();
                    codeLangVO.hindi = row["hindi"].ToString();
                }
                if (unicode)
                {
                    codeLangVO.hindi = row["hindi_unicode"].ToString();
                    codeLangVO.bangla = row["bangla_unicode"].ToString();
                    codeLangVO.english = row["english"].ToString();
                    codeLangVO.gujrati = row["gujarati_unicode"].ToString();
                    codeLangVO.kannada = row["kannada_unicode"].ToString();
                    codeLangVO.marathi = row["marathi_unicode"].ToString();
                    codeLangVO.punjabi = row["punjabi_unicode"].ToString();
                    codeLangVO.tamil = row["tamil_unicode"].ToString();
                    codeLangVO.telugu = row["telugu_unicode"].ToString();
                    codeLangVO.malayalam = row["malayalam_unicode"].ToString();
                    codeLangVO.oriya = row["oriya_unicode"].ToString();
                    codeLangVO.assamese = row["assamese_unicode"].ToString();
                }
                codeLangVOs.Add(codeLangVO);
            }
            return codeLangVOs;
        }

        public List<GocharVO> Get_Gochar(short lagna)
        {
            List<GocharVO> gocharVOs = new List<GocharVO>();
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            lagna = Convert.ToInt16(lagna - 1);
            string[] str = new string[] { "select *,case when(rashi-", lagna.ToString(), ")>0 then rashi-", lagna.ToString(), " else 12+(rashi-", lagna.ToString(), ") end  house from A_gochar (nolock)  where exitdate>GetDate() and exitdate<dateadd(year,4,GetDate()) order by entrydate" };
            dbCommand.CommandText = string.Concat(str);
            foreach (DataRow row in GenericDataAccess.ExecuteSelectCommand(dbCommand).Rows)
            {
                GocharVO gocharVO = new GocharVO()
                {
                    Sno = Convert.ToInt16(row["sno"]),
                    Planet = Convert.ToInt16(row["planet"]),
                    Rashi = Convert.ToInt16(row["rashi"]),
                    House = Convert.ToInt16(row["house"]),
                    Entrydate = Convert.ToDateTime(row["entrydate"]),
                    Exitdate = Convert.ToDateTime(row["exitdate"])
                };
                gocharVOs.Add(gocharVO);
            }
            return gocharVOs;
        }

        public List<GocharVO> Get_Gochar_By_Planet(short planetcode)
        {
            List<GocharVO> gocharVOs = new List<GocharVO>();
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            dbCommand.CommandText = string.Concat("select *from A_gochar (nolock)  where planet=", planetcode, " and convert(varchar, getdate(), 106)>=entrydate and convert(varchar, getdate(), 106)<=exitdate");
            foreach (DataRow row in GenericDataAccess.ExecuteSelectCommand(dbCommand).Rows)
            {
                GocharVO gocharVO = new GocharVO()
                {
                    Sno = Convert.ToInt16(row["sno"]),
                    Planet = Convert.ToInt16(row["planet"]),
                    Rashi = Convert.ToInt16(row["rashi"]),
                    Entrydate = Convert.ToDateTime(row["entrydate"]),
                    Exitdate = Convert.ToDateTime(row["exitdate"])
                };
                gocharVOs.Add(gocharVO);
            }
            return gocharVOs;
        }

        public List<HouseDetailsVO> Get_HouseDetails()
        {
            List<HouseDetailsVO> houseDetailsVOs = new List<HouseDetailsVO>();
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            dbCommand.CommandText = "select *from A_house_details (nolock) ";
            foreach (DataRow row in GenericDataAccess.ExecuteSelectCommand(dbCommand).Rows)
            {
                HouseDetailsVO houseDetailsVO = new HouseDetailsVO()
                {
                    Sno = Convert.ToInt32(row["sno"]),
                    Hcode = Convert.ToInt32(row["hcode"]),
                    Place = row["place"].ToString(),
                    BodyPart = row["bodypart"].ToString(),
                    Quality = row["quality"].ToString(),
                    Relative = row["relative"].ToString(),
                    Things = row["things"].ToString(),
                    Power = row["power"].ToString(),
                    Home = row["home"].ToString(),
                    Direction = row["direction"].ToString(),
                    Animal = row["animal"].ToString(),
                    Plants = row["plants"].ToString()
                };
                houseDetailsVOs.Add(houseDetailsVO);
            }
            return houseDetailsVOs;
        }

        public List<iAstroUpayVO> Get_iAstroUpay()
        {
            List<iAstroUpayVO> iAstroUpayVOs = new List<iAstroUpayVO>();
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            dbCommand.CommandText = "select * from A_iastroupaye (nolock) ";
            foreach (DataRow row in GenericDataAccess.ExecuteSelectCommand(dbCommand).Rows)
            {
                iAstroUpayVO _iAstroUpayVO = new iAstroUpayVO()
                {
                    sno = Convert.ToInt16(row["sno"]),
                    ruleno = Convert.ToInt16(row["ruleno"]),
                    vfal = row["vfal"].ToString(),
                    skip = row["skip"].ToString(),
                    pred = row["pred"].ToString(),
                    pred_bangla = row["pred_bangla"].ToString(),
                    pred_english = row["pred_english"].ToString(),
                    pred_gujarati = row["pred_gujarati"].ToString(),
                    pred_kannada = row["pred_kannada"].ToString(),
                    pred_marathi = row["pred_marathi"].ToString(),
                    pred_punjabi = row["pred_punjabi"].ToString(),
                    pred_tamil = row["pred_tamil"].ToString(),
                    pred_telugu = row["pred_telugu"].ToString()
                };
                iAstroUpayVOs.Add(_iAstroUpayVO);
            }
            return iAstroUpayVOs;
        }

        public List<LagnaVO> Get_Laganfal(int lagna)
        {
            List<LagnaVO> lagnaVOs = new List<LagnaVO>();
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            dbCommand.CommandText = string.Concat("select *from A_lagna (nolock)  where rashi=", lagna.ToString());
            foreach (DataRow row in GenericDataAccess.ExecuteSelectCommand(dbCommand).Rows)
            {
                LagnaVO lagnaVO = new LagnaVO()
                {
                    sno = Convert.ToInt16(row["sno"]),
                    house = Convert.ToInt16(row["house"]),
                    planet1 = Convert.ToInt16(row["planet1"]),
                    planet2 = Convert.ToInt16(row["planet2"]),
                    rashi = Convert.ToInt16(row["rashi"]),
                    pred = row["pred"].ToString()
                };
                lagnaVOs.Add(lagnaVO);
            }
            return lagnaVOs;
        }

        public LangVO Get_Lang(long ruleno, string lang, bool Paid, bool unicode)
        {
            LangVO langVO = new LangVO();
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            if (unicode)
            {
                dbCommand.CommandText = "get_mobile";
            }
            else
            {
                dbCommand.CommandText = "get_lang";
            }
            DbParameter dbParameter = dbCommand.CreateParameter();
            dbParameter.DbType = DbType.Int64;
            dbParameter.Value = ruleno;
            dbParameter.ParameterName = "@ruleno";
            DbParameter dbParameter1 = dbCommand.CreateParameter();
            dbParameter1.DbType = DbType.String;
            dbParameter1.Value = lang;
            dbParameter1.ParameterName = "@lang";
            DbParameter paid = dbCommand.CreateParameter();
            paid.DbType = DbType.Boolean;
            paid.Value = Paid;
            paid.ParameterName = "@paid";
            dbCommand.Parameters.Add(dbParameter);
            dbCommand.Parameters.Add(dbParameter1);
            dbCommand.Parameters.Add(paid);
            DataTable dataTable = GenericDataAccess.ExecuteSelectCommand(dbCommand);
            foreach (DataRow row in dataTable.Rows)
            {
                langVO.Rule_Number = Convert.ToInt32(row["ruleno"]);
                langVO.Common_Pred = row["common_pred"].ToString();
                langVO.Male_Pred = row["male_pred"].ToString();
                langVO.Female_Pred = row["female_pred"].ToString();
                langVO.Child_Pred = row["child_pred"].ToString();
            }
            if ((langVO == null ? true : dataTable == null))
            {
                langVO.Rule_Number = 0;
                langVO.Common_Pred = string.Empty;
                langVO.Male_Pred = string.Empty;
                langVO.Female_Pred = string.Empty;
                langVO.Child_Pred = string.Empty;
            }
            return langVO;
        }

        public List<LangVO> Get_Lang_by_Words(string words)
        {
            List<LangVO> langVOs = new List<LangVO>();
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            dbCommand.CommandText = words;
            foreach (DataRow row in GenericDataAccess.ExecuteSelectCommand(dbCommand).Rows)
            {
                LangVO langVO = new LangVO()
                {
                    Rule_Number = Convert.ToInt32(row["ruleno"]),
                    Common_Pred = row["common_pred"].ToString(),
                    Male_Pred = row["male_pred"].ToString(),
                    Female_Pred = row["female_pred"].ToString(),
                    Child_Pred = row["child_pred"].ToString()
                };
                langVO.Child_Pred = row["child_pred"].ToString();
                langVOs.Add(langVO);
            }
            return langVOs;
        }

        public DataTable get_planet_by_ruleno(long ruleno)
        {
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "get_planet_by_ruleno";
            DbParameter dbParameter = dbCommand.CreateParameter();
            dbParameter.DbType = DbType.Int64;
            dbParameter.Value = ruleno;
            dbParameter.ParameterName = "@ruleno";
            dbCommand.Parameters.Add(dbParameter);
            return GenericDataAccess.ExecuteSelectCommand(dbCommand);
        }

        public List<PlanetDetailsVO> Get_PlanetDetails()
        {
            List<PlanetDetailsVO> planetDetailsVOs = new List<PlanetDetailsVO>();
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            dbCommand.CommandText = "select *from A_planet_details (nolock) ";
            foreach (DataRow row in GenericDataAccess.ExecuteSelectCommand(dbCommand).Rows)
            {
                PlanetDetailsVO planetDetailsVO = new PlanetDetailsVO()
                {
                    Sno = Convert.ToInt32(row["sno"]),
                    Pcode = Convert.ToInt32(row["pcode"]),
                    Place = row["place"].ToString(),
                    BodyPart = row["bodypart"].ToString(),
                    Quality = row["quality"].ToString(),
                    Relative = row["relative"].ToString(),
                    Things = row["things"].ToString(),
                    Work = row["works"].ToString()
                };
                planetDetailsVOs.Add(planetDetailsVO);
            }
            return planetDetailsVOs;
        }

        public List<RashiDetailsVO> Get_RashiDetails()
        {
            List<RashiDetailsVO> rashiDetailsVOs = new List<RashiDetailsVO>();
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            dbCommand.CommandText = "select *from A_rashi_details (nolock) ";
            foreach (DataRow row in GenericDataAccess.ExecuteSelectCommand(dbCommand).Rows)
            {
                RashiDetailsVO rashiDetailsVO = new RashiDetailsVO()
                {
                    Sno = Convert.ToInt32(row["sno"]),
                    Rcode = Convert.ToInt32(row["rcode"]),
                    Place = row["place"].ToString(),
                    BodyPart = row["bodypart"].ToString(),
                    Quality = row["quality"].ToString(),
                    Relative = row["relative"].ToString(),
                    Things = row["things"].ToString(),
                    Work = row["works"].ToString()
                };
                rashiDetailsVOs.Add(rashiDetailsVO);
            }
            return rashiDetailsVOs;
        }

        public int Get_Rule_Number(long predicate, string ruletype)
        {
            int num = 0;
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "get_pred";
            DbParameter dbParameter = dbCommand.CreateParameter();
            dbParameter.DbType = DbType.Int64;
            dbParameter.Value = predicate;
            dbParameter.ParameterName = "@predicate";
            DbParameter dbParameter1 = dbCommand.CreateParameter();
            dbParameter1.DbType = DbType.String;
            dbParameter1.Value = ruletype;
            dbParameter1.ParameterName = "@ruletype";
            dbCommand.Parameters.Add(dbParameter);
            dbCommand.Parameters.Add(dbParameter1);
            foreach (DataRow row in GenericDataAccess.ExecuteSelectCommand(dbCommand).Rows)
            {
                num = Convert.ToInt32(row["sno"].ToString());
            }
            return num;
        }

        public UpayIndex Get_UpayIndex(int code)
        {
            UpayIndex upayIndex = new UpayIndex();
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            dbCommand.CommandText = string.Concat("select *from A_upayindex (nolock)  where sno=", code);
            foreach (DataRow row in GenericDataAccess.ExecuteSelectCommand(dbCommand).Rows)
            {
                upayIndex.Sno = Convert.ToInt16(row["sno"]);
                upayIndex.Bangla = row["bangla"].ToString();
                upayIndex.Eng = row["english"].ToString();
                upayIndex.Gujarati = row["gujarati"].ToString();
                upayIndex.Kannada = row["kannada"].ToString();
                upayIndex.Marathi = row["marathi"].ToString();
                upayIndex.Punjabi = row["punjabi"].ToString();
                upayIndex.Tamil = row["tamil"].ToString();
                upayIndex.Telugu = row["telugu"].ToString();
                upayIndex.Hindi = row["hindi"].ToString();
            }
            return upayIndex;
        }

        public UpayIndex Get_UpayIndex(int code, bool unicode)
        {
            UpayIndex upayIndex = new UpayIndex();
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            dbCommand.CommandText = string.Concat("select *from A_upayindex (nolock)  where sno=", code);
            foreach (DataRow row in GenericDataAccess.ExecuteSelectCommand(dbCommand).Rows)
            {
                upayIndex.Sno = Convert.ToInt16(row["sno"]);
                upayIndex.Bangla = row["bangla"].ToString();
                upayIndex.Eng = row["english"].ToString();
                upayIndex.Gujarati = row["gujarati"].ToString();
                upayIndex.Kannada = row["kannada"].ToString();
                upayIndex.Marathi = row["marathi"].ToString();
                upayIndex.Punjabi = row["punjabi"].ToString();
                upayIndex.Tamil = row["tamil"].ToString();
                upayIndex.Telugu = row["telugu"].ToString();
                upayIndex.Hindi = row["hindi"].ToString();
                if (unicode)
                {
                    upayIndex.Hindi = row["hindi_unicode"].ToString();
                    upayIndex.Marathi = row["marathi_unicode"].ToString();
                }
            }
            return upayIndex;
        }

        public List<VarshPhalVO> Get_VarshPhal()
        {
            List<VarshPhalVO> varshPhalVOs = new List<VarshPhalVO>();
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            dbCommand.CommandText = "select * from a_varshphal (nolock) ";
            foreach (DataRow row in GenericDataAccess.ExecuteSelectCommand(dbCommand).Rows)
            {
                VarshPhalVO varshPhalVO = new VarshPhalVO()
                {
                    sno = Convert.ToInt16(row["sno"]),
                    age = Convert.ToInt16(row["age"]),
                    house1 = Convert.ToInt16(row["house1"]),
                    house2 = Convert.ToInt16(row["house2"]),
                    house3 = Convert.ToInt16(row["house3"]),
                    house4 = Convert.ToInt16(row["house4"]),
                    house5 = Convert.ToInt16(row["house5"]),
                    house6 = Convert.ToInt16(row["house6"]),
                    house7 = Convert.ToInt16(row["house7"]),
                    house8 = Convert.ToInt16(row["house8"]),
                    house9 = Convert.ToInt16(row["house9"]),
                    house10 = Convert.ToInt16(row["house10"]),
                    house11 = Convert.ToInt16(row["house11"]),
                    house12 = Convert.ToInt16(row["house12"])
                };
                varshPhalVOs.Add(varshPhalVO);
            }
            return varshPhalVOs;
        }

        public List<VDaanVO> Get_VDAAN()
        {
            List<VDaanVO> vDaanVOs = new List<VDaanVO>();
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            dbCommand.CommandText = "select * from A_vdaan (nolock) ";
            foreach (DataRow row in GenericDataAccess.ExecuteSelectCommand(dbCommand).Rows)
            {
                VDaanVO vDaanVO = new VDaanVO()
                {
                    sno = Convert.ToInt16(row["sno"]),
                    planet = row["planet"].ToString(),
                    vdaan = row["vdaan"].ToString(),
                    vdaan_unicode = row["vdaan_unicode"].ToString(),
                    color = row["color"].ToString(),
                    color_unicode = row["color_unicode"].ToString(),
                    english_vdaan = row["english_vdaan"].ToString(),
                    english_color = row["english_color"].ToString(),
                    tamil_vdaan = row["tamil_vdaan"].ToString(),
                    tamil_color = row["tamil_color"].ToString(),
                    telugu_vdaan = row["telugu_vdaan"].ToString(),
                    telugu_color = row["telugu_color"].ToString(),
                    bangla_vdaan = row["bangla_vdaan"].ToString(),
                    bangla_color = row["bangla_color"].ToString(),
                    kannada_vdaan = row["kannada_vdaan"].ToString(),
                    kannada_color = row["kannada_color"].ToString(),
                    marathi_vdaan = row["marathi_vdaan"].ToString(),
                    marathi_color = row["marathi_color"].ToString(),
                    punjabi_vdaan = row["punjabi_vdaan"].ToString(),
                    punjabi_color = row["punjabi_color"].ToString(),
                    gujarati_vdaan = row["gujarati_vdaan"].ToString(),
                    gujarati_color = row["gujarati_color"].ToString(),
                    tamil_vdaan_unicode = row["tamil_vdaan_unicode"].ToString(),
                    tamil_color_unicode = row["tamil_color_unicode"].ToString(),
                    telugu_vdaan_unicode = row["telugu_vdaan_unicode"].ToString(),
                    telugu_color_unicode = row["telugu_color_unicode"].ToString(),
                    bangla_vdaan_unicode = row["bangla_vdaan_unicode"].ToString(),
                    bangla_color_unicode = row["bangla_color_unicode"].ToString(),
                    kannada_vdaan_unicode = row["kannada_vdaan_unicode"].ToString(),
                    kannada_color_unicode = row["kannada_color_unicode"].ToString(),
                    marathi_vdaan_unicode = row["marathi_vdaan_unicode"].ToString(),
                    marathi_color_unicode = row["marathi_color_unicode"].ToString(),
                    punjabi_vdaan_unicode = row["punjabi_vdaan_unicode"].ToString(),
                    punjabi_color_unicode = row["punjabi_color_unicode"].ToString(),
                    gujarati_vdaan_unicode = row["gujarati_vdaan_unicode"].ToString(),
                    gujarati_color_unicode = row["gujarati_color_unicode"].ToString(),
                    oriya_vdaan_unicode = row["oriya_vdaan_unicode"].ToString(),
                    oriya_color_unicode = row["oriya_color_unicode"].ToString(),
                    malayalam_vdaan_unicode = row["malayalam_vdaan_unicode"].ToString(),
                    malayalam_color_unicode = row["malayalam_color_unicode"].ToString(),
                    assamese_vdaan_unicode = row["assamese_vdaan_unicode"].ToString(),
                    assamese_color_unicode = row["assamese_color_unicode"].ToString(),
                    inhouse = row["inhouse"].ToString(),
                    outhouse = row["outhouse"].ToString()
                };
                vDaanVOs.Add(vDaanVO);
            }
            return vDaanVOs;
        }

        public List<VfalUpayVO> Get_VfalUpay()
        {
            List<VfalUpayVO> vfalUpayVOs = new List<VfalUpayVO>();
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            dbCommand.CommandText = "select *from A_vfal_upay (nolock) ";
            foreach (DataRow row in GenericDataAccess.ExecuteSelectCommand(dbCommand).Rows)
            {
                VfalUpayVO vfalUpayVO = new VfalUpayVO()
                {
                    Sno = Convert.ToInt32(row["sno"]),
                    Ruleno1 = Convert.ToInt32(row["ruleno1"]),
                    Ruleno2 = Convert.ToInt32(row["ruleno2"]),
                    Child_Bangla = row["child_bangla"].ToString(),
                    Child_Eng = row["child_eng"].ToString(),
                    Child_Gujarati = row["child_gujarati"].ToString(),
                    Child_Hindi = row["child_hindi"].ToString(),
                    Child_Kannada = row["child_kannada"].ToString(),
                    Child_Marathi = row["child_marathi"].ToString(),
                    Child_Punjabi = row["child_punjabi"].ToString(),
                    Child_Tamil = row["child_tamil"].ToString(),
                    Child_Telugu = row["child_telugu"].ToString(),
                    Bangla = row["bangla"].ToString(),
                    Eng = row["eng"].ToString(),
                    Gujarati = row["gujarati"].ToString(),
                    Hindi = row["hindi"].ToString(),
                    Kannada = row["kannada"].ToString(),
                    Marathi = row["marathi"].ToString(),
                    Punjabi = row["punjabi"].ToString(),
                    Tamil = row["tamil"].ToString(),
                    Telugu = row["telugu"].ToString(),
                    Hindi_Unicode = row["hindi_unicode"].ToString(),
                    Child_Hindi_Unicode = row["child_hindi_unicode"].ToString()
                };
                vfalUpayVOs.Add(vfalUpayVO);
            }
            return vfalUpayVOs;
        }

        public DataTable GetAdvanceExtraRuleById(long ruleno)
        {
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "GetAdvanceExtraRuleById";
            DbParameter dbParameter = dbCommand.CreateParameter();
            dbParameter.DbType = DbType.Int64;
            dbParameter.Value = ruleno;
            dbParameter.ParameterName = "@ruleno";
            dbCommand.Parameters.Add(dbParameter);
            return GenericDataAccess.ExecuteSelectCommand(dbCommand);
        }

        public DataTable GetAdvanceRuleById(long sno)
        {
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "GetAdvanceRuleById";
            DbParameter dbParameter = dbCommand.CreateParameter();
            dbParameter.DbType = DbType.Int64;
            dbParameter.Value = sno;
            dbParameter.ParameterName = "@sno";
            dbCommand.Parameters.Add(dbParameter);
            return GenericDataAccess.ExecuteSelectCommand(dbCommand);
        }

        public DataTable GetAllAdvanceRules()
        {
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "GetAllAdvanceRules";
            return GenericDataAccess.ExecuteSelectCommand(dbCommand);
        }

        public DataTable SearchRules(string title, int house, int planet)
        {
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "SearchAdvanceRules";
            DbParameter dbParameter = dbCommand.CreateParameter();
            dbParameter.DbType = DbType.String;
            dbParameter.Value = title;
            dbParameter.ParameterName = "@title";
            DbParameter dbParameter1 = dbCommand.CreateParameter();
            dbParameter1.Value = house;
            dbParameter1.DbType = DbType.Int32;
            dbParameter1.ParameterName = "@house";
            DbParameter dbParameter2 = dbCommand.CreateParameter();
            dbParameter2.DbType = DbType.Int32;
            dbParameter2.Value = planet;
            dbParameter2.ParameterName = "@planet";
            dbCommand.Parameters.Add(dbParameter);
            dbCommand.Parameters.Add(dbParameter1);
            dbCommand.Parameters.Add(dbParameter2);
            return GenericDataAccess.ExecuteSelectCommand(dbCommand);
        }

        public void UpdateAdvanceRule(RulesVO rv, LangVO pred, string lang)
        {
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "UpdateRule";
            DbParameter isbad = dbCommand.CreateParameter();
            isbad.ParameterName = "@isbad";
            isbad.DbType = DbType.Boolean;
            isbad.Value = rv.Isbad;
            DbParameter sno = dbCommand.CreateParameter();
            sno.ParameterName = "@sno";
            sno.DbType = DbType.Int64;
            sno.Value = rv.Sno;
            DbParameter ruleType = dbCommand.CreateParameter();
            ruleType.ParameterName = "@ruletype";
            ruleType.DbType = DbType.String;
            ruleType.Value = rv.RuleType;
            DbParameter commonPred = dbCommand.CreateParameter();
            commonPred.ParameterName = "@common_pred";
            commonPred.DbType = DbType.String;
            commonPred.Value = pred.Common_Pred;
            DbParameter malePred = dbCommand.CreateParameter();
            malePred.ParameterName = "@male_pred";
            malePred.DbType = DbType.String;
            malePred.Value = pred.Male_Pred;
            DbParameter femalePred = dbCommand.CreateParameter();
            femalePred.ParameterName = "@female_pred";
            femalePred.DbType = DbType.String;
            femalePred.Value = pred.Female_Pred;
            DbParameter childPred = dbCommand.CreateParameter();
            childPred.ParameterName = "@child_pred";
            childPred.DbType = DbType.String;
            childPred.Value = pred.Child_Pred;
            DbParameter dbParameter = dbCommand.CreateParameter();
            dbParameter.ParameterName = "@lang";
            dbParameter.DbType = DbType.String;
            dbParameter.Value = lang;
            DbParameter priority = dbCommand.CreateParameter();
            priority.ParameterName = "@priority";
            priority.DbType = DbType.Int16;
            priority.Value = rv.Priority;
            DbParameter refNo = dbCommand.CreateParameter();
            refNo.ParameterName = "@refno";
            refNo.DbType = DbType.Int64;
            refNo.Value = rv.RefNo;
            DbParameter profit = dbCommand.CreateParameter();
            profit.ParameterName = "@profit";
            profit.DbType = DbType.Boolean;
            profit.Value = rv.Profit;
            DbParameter motherFather = dbCommand.CreateParameter();
            motherFather.ParameterName = "@mother_father";
            motherFather.DbType = DbType.Boolean;
            motherFather.Value = rv.Mother_father;
            DbParameter santan = dbCommand.CreateParameter();
            santan.ParameterName = "@santan";
            santan.DbType = DbType.Boolean;
            santan.Value = rv.Santan;
            DbParameter brother = dbCommand.CreateParameter();
            brother.ParameterName = "@brother";
            brother.DbType = DbType.Boolean;
            brother.Value = rv.Brother;
            DbParameter loveAffair = dbCommand.CreateParameter();
            loveAffair.ParameterName = "@love_affair";
            loveAffair.DbType = DbType.Boolean;
            loveAffair.Value = rv.Love_affair;
            DbParameter disease = dbCommand.CreateParameter();
            disease.ParameterName = "@disease";
            disease.DbType = DbType.Boolean;
            disease.Value = rv.Disease;
            DbParameter marriedlife = dbCommand.CreateParameter();
            marriedlife.ParameterName = "@marriedlife";
            marriedlife.DbType = DbType.Boolean;
            marriedlife.Value = rv.Marriedlife;
            DbParameter occupation = dbCommand.CreateParameter();
            occupation.ParameterName = "@occupation";
            occupation.DbType = DbType.Boolean;
            occupation.Value = rv.Occupation;
            DbParameter memory = dbCommand.CreateParameter();
            memory.ParameterName = "@memory";
            memory.DbType = DbType.Boolean;
            memory.Value = rv.Memory;
            DbParameter ruleNature = dbCommand.CreateParameter();
            ruleNature.ParameterName = "@rulenature";
            ruleNature.DbType = DbType.Int16;
            ruleNature.Value = rv.Rule_Nature;
            DbParameter ruleformula = dbCommand.CreateParameter();
            ruleformula.ParameterName = "@ruleformula";
            ruleformula.DbType = DbType.String;
            ruleformula.Value = rv.Ruleformula;
            DbParameter actualformula = dbCommand.CreateParameter();
            actualformula.ParameterName = "@actualformula";
            actualformula.DbType = DbType.String;
            actualformula.Value = rv.Actualformula;
            DbParameter vfalYears = dbCommand.CreateParameter();
            vfalYears.ParameterName = "@vfalyears";
            vfalYears.DbType = DbType.String;
            vfalYears.Value = rv.VfalYears;
            DbParameter upay = dbCommand.CreateParameter();
            upay.ParameterName = "@upay";
            upay.DbType = DbType.Int32;
            upay.Value = rv.Upay;
            DbParameter confidence = dbCommand.CreateParameter();
            confidence.ParameterName = "@confidence";
            confidence.DbType = DbType.Boolean;
            confidence.Value = rv.Confidence;
            DbParameter common = dbCommand.CreateParameter();
            common.ParameterName = "@common";
            common.DbType = DbType.Boolean;
            common.Value = rv.Common;
            DbParameter male = dbCommand.CreateParameter();
            male.ParameterName = "@male";
            male.DbType = DbType.Boolean;
            male.Value = rv.Male;
            DbParameter female = dbCommand.CreateParameter();
            female.ParameterName = "@female";
            female.DbType = DbType.Boolean;
            female.Value = rv.Female;
            DbParameter bachpan = dbCommand.CreateParameter();
            bachpan.ParameterName = "@bachpan";
            bachpan.DbType = DbType.Boolean;
            bachpan.Value = rv.Bachpan;
            DbParameter kishor = dbCommand.CreateParameter();
            kishor.ParameterName = "@kishor";
            kishor.DbType = DbType.Boolean;
            kishor.Value = rv.Kishor;
            DbParameter yuva = dbCommand.CreateParameter();
            yuva.ParameterName = "@yuva";
            yuva.DbType = DbType.Boolean;
            yuva.Value = rv.Yuva;
            DbParameter madhya = dbCommand.CreateParameter();
            madhya.ParameterName = "@madhya";
            madhya.DbType = DbType.Boolean;
            madhya.Value = rv.Madhya;
            DbParameter budhapa = dbCommand.CreateParameter();
            budhapa.ParameterName = "@budhapa";
            budhapa.DbType = DbType.Boolean;
            budhapa.Value = rv.Budhapa;
            DbParameter mainplanet = dbCommand.CreateParameter();
            mainplanet.ParameterName = "@mainplanet";
            mainplanet.DbType = DbType.Int16;
            mainplanet.Value = rv.Mainplanet;
            DbParameter shishu = dbCommand.CreateParameter();
            shishu.ParameterName = "@shishu";
            shishu.DbType = DbType.Boolean;
            shishu.Value = rv.Shishu;
            DbParameter title = dbCommand.CreateParameter();
            title.ParameterName = "@title";
            title.DbType = DbType.String;
            title.Value = rv.Title;
            DbParameter good = dbCommand.CreateParameter();
            good.ParameterName = "@good";
            good.DbType = DbType.String;
            good.Value = rv.Good;
            DbParameter bad = dbCommand.CreateParameter();
            bad.ParameterName = "@bad";
            bad.DbType = DbType.String;
            bad.Value = rv.Bad;
            DbParameter kayam = dbCommand.CreateParameter();
            kayam.ParameterName = "@kayam";
            kayam.DbType = DbType.String;
            kayam.Value = rv.Kayam;
            DbParameter multiUpay = dbCommand.CreateParameter();
            multiUpay.ParameterName = "@multiupay";
            multiUpay.DbType = DbType.String;
            multiUpay.Value = rv.MultiUpay;
            DbParameter planetUpay = dbCommand.CreateParameter();
            planetUpay.ParameterName = "@planetupay";
            planetUpay.DbType = DbType.String;
            planetUpay.Value = rv.PlanetUpay;
            DbParameter lagan = dbCommand.CreateParameter();
            lagan.ParameterName = "@lagan";
            lagan.DbType = DbType.String;
            lagan.Value = rv.Lagan;
            DbParameter rashi = dbCommand.CreateParameter();
            rashi.ParameterName = "@rashi";
            rashi.DbType = DbType.String;
            rashi.Value = rv.Rashi;
            dbCommand.Parameters.Add(isbad);
            dbCommand.Parameters.Add(sno);
            dbCommand.Parameters.Add(ruleType);
            dbCommand.Parameters.Add(commonPred);
            dbCommand.Parameters.Add(malePred);
            dbCommand.Parameters.Add(femalePred);
            dbCommand.Parameters.Add(childPred);
            dbCommand.Parameters.Add(dbParameter);
            dbCommand.Parameters.Add(priority);
            dbCommand.Parameters.Add(refNo);
            dbCommand.Parameters.Add(profit);
            dbCommand.Parameters.Add(motherFather);
            dbCommand.Parameters.Add(santan);
            dbCommand.Parameters.Add(brother);
            dbCommand.Parameters.Add(loveAffair);
            dbCommand.Parameters.Add(disease);
            dbCommand.Parameters.Add(marriedlife);
            dbCommand.Parameters.Add(occupation);
            dbCommand.Parameters.Add(memory);
            dbCommand.Parameters.Add(ruleNature);
            dbCommand.Parameters.Add(ruleformula);
            dbCommand.Parameters.Add(actualformula);
            dbCommand.Parameters.Add(vfalYears);
            dbCommand.Parameters.Add(upay);
            dbCommand.Parameters.Add(confidence);
            dbCommand.Parameters.Add(common);
            dbCommand.Parameters.Add(male);
            dbCommand.Parameters.Add(female);
            dbCommand.Parameters.Add(bachpan);
            dbCommand.Parameters.Add(kishor);
            dbCommand.Parameters.Add(yuva);
            dbCommand.Parameters.Add(madhya);
            dbCommand.Parameters.Add(budhapa);
            dbCommand.Parameters.Add(mainplanet);
            dbCommand.Parameters.Add(shishu);
            dbCommand.Parameters.Add(title);
            dbCommand.Parameters.Add(good);
            dbCommand.Parameters.Add(bad);
            dbCommand.Parameters.Add(kayam);
            dbCommand.Parameters.Add(multiUpay);
            dbCommand.Parameters.Add(planetUpay);
            dbCommand.Parameters.Add(lagan);
            dbCommand.Parameters.Add(rashi);
            GenericDataAccess.ExecuteSelectCommand(dbCommand);
        }
    }
}