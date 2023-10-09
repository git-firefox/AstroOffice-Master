using ASDLL;
using System;
using System.Data;
using System.Data.Common;
namespace ASDLL.DataAccess.Core
{
    public class Years35DAO
    {
        public Years35DAO()
        {
        }

        public DataTable Antar(string planet)
        {
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "GetAntar";
            DbParameter dbParameter = dbCommand.CreateParameter();
            dbParameter.ParameterName = "@planet";
            dbParameter.DbType = DbType.String;
            dbParameter.Value = planet;
            dbCommand.Parameters.Add(dbParameter);
            return GenericDataAccess.ExecuteSelectCommand(dbCommand);
        }

        public DataTable GetYears35(string planet)
        {
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "GetYears35";
            DbParameter dbParameter = dbCommand.CreateParameter();
            dbParameter.ParameterName = "@planet";
            dbParameter.DbType = DbType.String;
            dbParameter.Value = planet;
            dbCommand.Parameters.Add(dbParameter);
            return GenericDataAccess.ExecuteSelectCommand(dbCommand);
        }

        public DataTable GetYears35_Umra(string planet)
        {
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "GetYears35_Umra";
            DbParameter dbParameter = dbCommand.CreateParameter();
            dbParameter.ParameterName = "@planet";
            dbParameter.DbType = DbType.String;
            dbParameter.Value = planet;
            dbCommand.Parameters.Add(dbParameter);
            return GenericDataAccess.ExecuteSelectCommand(dbCommand);
        }

        public DataTable GetYears35All()
        {
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "select * from A_35years (nolock) ";
            return GenericDataAccess.ExecuteSelectCommand(dbCommand);
        }

        public DataTable JanamAam()
        {
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "GetAam";
            return GenericDataAccess.ExecuteSelectCommand(dbCommand);
        }
    }
}