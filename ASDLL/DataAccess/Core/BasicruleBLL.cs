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
    public class BasicruleBLL
    {
        public BasicruleBLL()
        {
        }

        public void AddBasicRule(BasicruleVO bv)
        {
            (new BasicruleDAO()).AddBasicRule(bv);
        }

        public List<BasicruleVO> GetAllBasicRule()
        {
            List<BasicruleVO> basicruleVOs = new List<BasicruleVO>();
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandType = CommandType.Text;
            dbCommand.CommandText = "select *from A_basic_rules (nolock)";
            foreach (DataRow row in GenericDataAccess.ExecuteSelectCommand(dbCommand).Rows)
            {
                BasicruleVO basicruleVO = new BasicruleVO()
                {
                    Sno = Convert.ToInt32(row["sno"]),
                    House = Convert.ToInt32(row["house"]),
                    Planet = Convert.ToInt32(row["planet"]),
                    Basicrule = row["basicrule"].ToString()
                };
                basicruleVOs.Add(basicruleVO);
            }
            return basicruleVOs;
        }

        public BasicruleVO GetBasicRuleByHousePlanet(int house, int planet)
        {
            BasicruleDAO basicruleDAO = new BasicruleDAO();
            BasicruleVO basicruleVO = new BasicruleVO();
            DataTable basicRuleByHousePlanet = basicruleDAO.GetBasicRuleByHousePlanet(house, planet);
            if (basicRuleByHousePlanet.Rows.Count > 0)
            {
                basicruleVO.Sno = Convert.ToInt32(basicRuleByHousePlanet.Rows[0]["sno"]);
                basicruleVO.House = Convert.ToInt32(basicRuleByHousePlanet.Rows[0]["house"]);
                basicruleVO.Planet = planet;
                basicruleVO.Basicrule = basicRuleByHousePlanet.Rows[0]["basicrule"].ToString();
            }
            return basicruleVO;
        }

        public BasicruleVO GetBasicRuleById(int id)
        {
            BasicruleDAO basicruleDAO = new BasicruleDAO();
            BasicruleVO basicruleVO = new BasicruleVO();
            DataTable basicRuleById = basicruleDAO.GetBasicRuleById(id);
            if (basicRuleById.Rows.Count > 0)
            {
                basicruleVO.Sno = Convert.ToInt32(basicRuleById.Rows[0]["sno"]);
                basicruleVO.House = Convert.ToInt32(basicRuleById.Rows[0]["house"]);
                basicruleVO.Planet = Convert.ToInt32(basicRuleById.Rows[0]["planet"]);
                basicruleVO.Basicrule = basicRuleById.Rows[0]["basicrule"].ToString();
            }
            return basicruleVO;
        }

        public DataTable GetBasicRulesByHouse(int house)
        {
            return (new BasicruleDAO()).GetBasicRulesByHouse(house);
        }

        public List<BasicruleVO> GetKundliPredicates(long kundliid)
        {
            DataTable kundliPredicates = (new BasicruleDAO()).GetKundliPredicates(kundliid);
            List<BasicruleVO> basicruleVOs = new List<BasicruleVO>();
            foreach (DataRow row in kundliPredicates.Rows)
            {
                BasicruleVO basicruleVO = new BasicruleVO()
                {
                    Sno = Convert.ToInt32(row["sno"]),
                    House = Convert.ToInt32(row["house"]),
                    Planet = Convert.ToInt32(row["planet"]),
                    Basicrule = row["basicrule"].ToString()
                };
                basicruleVOs.Add(basicruleVO);
            }
            return basicruleVOs;
        }
    }
}