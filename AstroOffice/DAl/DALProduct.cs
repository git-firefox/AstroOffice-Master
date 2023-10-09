using System;
using System.Collections;
using System.Linq;
using System.Runtime.CompilerServices;
using DataAccess.core;
//using AstroOffice.VO;
using AstroOffice.Models;

namespace AstroOffice.DAl
{
    internal class DALProduct
    {
        private readonly astroDataContainer _adc;

        public DALProduct()
        {
            _adc = new astroDataContainer();
        }

        public string GetUpayeByPlanetHouse(int planet, int house, string gender, string lang, bool showref, bool bad, bool gudupay)
        {
            string str = "";
            bool flag = false;
            BasicruleBLL basicruleBLL = new BasicruleBLL();
            long sno = (long)basicruleBLL.GetBasicRuleByHousePlanet(house, planet).Sno;
            RuleBLL ruleBLL = new RuleBLL();
            ArrayList arrayLists = new ArrayList((
                from Map in ruleBLL.GetAllAdvanceRules()
                where (Map.RuleType != "upay_b" ? false : Map.Ruleformula == sno.ToString())
                select Map).ToList<RulesVO>());
            RuleDAO ruleDAO = new RuleDAO();
            try
            {
                foreach (RulesVO arrayList in arrayLists)
                {
                    string str1 = gender;
                    if (str1 != null)
                    {
                        if (str1 == "M")
                        {
                            str = string.Concat(str, (ruleDAO.Get_Lang(arrayList.Sno, lang, flag, false).Male_Pred.ToString().Length < 1 ? ruleDAO.Get_Lang(arrayList.Sno, lang, flag, false).Common_Pred : ruleDAO.Get_Lang(arrayList.Sno, lang, flag, false).Male_Pred.ToString()));
                        }
                        else if (str1 == "F")
                        {
                            str = string.Concat(str, (ruleDAO.Get_Lang(arrayList.Sno, lang, flag, false).Female_Pred.ToString().Length < 1 ? ruleDAO.Get_Lang(arrayList.Sno, lang, flag, false).Common_Pred : ruleDAO.Get_Lang(arrayList.Sno, lang, flag, false).Female_Pred.ToString()));
                        }
                    }
                    str = string.Concat(str, "\r\n");
                    if (showref)
                    {
                        str = string.Concat(str, arrayList.Sno, "BUPAYE");
                    }
                }
            }
            catch (Exception exception)
            {
                _ = exception;
            }
            return str;
        }
    }
}