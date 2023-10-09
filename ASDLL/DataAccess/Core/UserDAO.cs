using ASDLL;
using System;
using System.Data;
using System.Data.Common;

namespace ASDLL.DataAccess.Core
{
    public class UserDAO
    {
        public UserDAO()
        {
        }

        public DataTable AstroLogin(string username, string password)
        {
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "AstroLogin";
            DbParameter dbParameter = dbCommand.CreateParameter();
            dbParameter.ParameterName = "@username";
            dbParameter.DbType = DbType.String;
            dbParameter.Value = username;
            DbParameter dbParameter1 = dbCommand.CreateParameter();
            dbParameter1.ParameterName = "@password";
            dbParameter1.DbType = DbType.String;
            dbParameter1.Value = password;
            dbCommand.Parameters.Add(dbParameter);
            dbCommand.Parameters.Add(dbParameter1);
            return GenericDataAccess.ExecuteSelectCommand(dbCommand);
        }
    }
}