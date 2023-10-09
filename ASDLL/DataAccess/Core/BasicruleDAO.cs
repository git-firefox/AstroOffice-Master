using ASDLL;
using System;
using System.Data;
using System.Data.Common;
using AstroShared.Models;

namespace ASDLL.DataAccess.Core
{
    public class BasicruleDAO
    {
        public BasicruleDAO()
        {
        }

        public void AddBasicRule(BasicruleVO bv)
        {
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "AddBasicRule";
            DbParameter house = dbCommand.CreateParameter();
            house.ParameterName = "@house";
            house.DbType = DbType.Int32;
            house.Value = bv.House;
            DbParameter planet = dbCommand.CreateParameter();
            planet.ParameterName = "@planet";
            planet.DbType = DbType.Int32;
            planet.Value = bv.Planet;
            DbParameter basicrule = dbCommand.CreateParameter();
            basicrule.ParameterName = "@rule";
            basicrule.DbType = DbType.String;
            basicrule.Value = bv.Basicrule;
            dbCommand.Parameters.Add(house);
            dbCommand.Parameters.Add(planet);
            dbCommand.Parameters.Add(basicrule);
            GenericDataAccess.ExecuteSelectCommand(dbCommand);
        }

        public DataTable GetBasicRuleByHousePlanet(int house, int planet)
        {
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "GetBasicRuleByHousePlanet";
            DbParameter dbParameter = dbCommand.CreateParameter();
            dbParameter.ParameterName = "@house";
            dbParameter.DbType = DbType.Int32;
            dbParameter.Value = house;
            DbParameter dbParameter1 = dbCommand.CreateParameter();
            dbParameter1.ParameterName = "@planet";
            dbParameter1.DbType = DbType.Int32;
            dbParameter1.Value = planet;
            dbCommand.Parameters.Add(dbParameter);
            dbCommand.Parameters.Add(dbParameter1);
            return GenericDataAccess.ExecuteSelectCommand(dbCommand);
        }

        public DataTable GetBasicRuleById(int id)
        {
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "GetBasicRuleById";
            DbParameter dbParameter = dbCommand.CreateParameter();
            dbParameter.ParameterName = "@id";
            dbParameter.DbType = DbType.Int32;
            dbParameter.Value = id;
            dbCommand.Parameters.Add(dbParameter);
            return GenericDataAccess.ExecuteSelectCommand(dbCommand);
        }

        public DataTable GetBasicRulesByHouse(int house)
        {
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "GetBasicRulesByHouse";
            DbParameter dbParameter = dbCommand.CreateParameter();
            dbParameter.DbType = DbType.Int32;
            dbParameter.ParameterName = "@house";
            dbParameter.Value = house;
            dbCommand.Parameters.Add(dbParameter);
            return GenericDataAccess.ExecuteSelectCommand(dbCommand);
        }

        public DataTable GetKundliPredicates(long kundliid)
        {
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "GetKundliPredicates";
            DbParameter dbParameter = dbCommand.CreateParameter();
            dbParameter.DbType = DbType.Int32;
            dbParameter.ParameterName = "@kundliid";
            dbParameter.Value = kundliid;
            dbCommand.Parameters.Add(dbParameter);
            return GenericDataAccess.ExecuteSelectCommand(dbCommand);
        }
    }
}