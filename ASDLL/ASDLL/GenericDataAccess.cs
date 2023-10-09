using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace ASDLL
{
    public class GenericDataAccess
    {
        static GenericDataAccess()
        {
            DbProviderFactories.RegisterFactory(ApplicationConfiguration.DbProviderName, SqlClientFactory.Instance);
        }

        public GenericDataAccess() { }

        public static DbCommand CreateCommand()
        {
            string dbProviderName = ApplicationConfiguration.DbProviderName;
            string dbConnectionString = ApplicationConfiguration.DbConnectionString;
            DbConnection dbConnection = DbProviderFactories.GetFactory(dbProviderName).CreateConnection();
            dbConnection.ConnectionString = dbConnectionString;
            DbCommand dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandType = CommandType.StoredProcedure;
            return dbCommand;
        }

        public static DataTable ExecuteSelectCommand(DbCommand command)
        {
            DataTable dataTable;
            try
            {
                try
                {
                    command.Connection.Open();
                    DbDataReader dbDataReaders = command.ExecuteReader();
                    dataTable = new DataTable();
                    dataTable.Load(dbDataReaders);
                    dbDataReaders.Close();
                }
                catch (Exception exception)
                {
                    _ = exception;
                    throw;
                }
            }
            finally
            {
                command.Connection.Close();
            }
            return dataTable;
        }
    }
}