using ASDLL;
using System;
using System.Data;
using System.Data.Common;

namespace ASDLL.DataAccess.Core
{
    public class PlanetDAO
    {
        public PlanetDAO()
        {
        }

        public DataTable GetAllMandeGhar()
        {
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "GetAllMandeGhar";
            return GenericDataAccess.ExecuteSelectCommand(dbCommand);
        }

        public DataTable GetAllNeechGhar()
        {
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "GetAllNeechGhar";
            return GenericDataAccess.ExecuteSelectCommand(dbCommand);
        }

        public DataTable GetAllPakkeGhar()
        {
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "GetAllPakkeGhar";
            return GenericDataAccess.ExecuteSelectCommand(dbCommand);
        }

        public DataTable GetAllPlanetRealtions()
        {
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "GetAllPlanetRelations";
            return GenericDataAccess.ExecuteSelectCommand(dbCommand);
        }

        public DataTable GetAllPlanets()
        {
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "GetAllPlanets";
            return GenericDataAccess.ExecuteSelectCommand(dbCommand);
        }

        public DataTable GetAllShreshtGhar()
        {
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "GetAllShreshtGhar";
            return GenericDataAccess.ExecuteSelectCommand(dbCommand);
        }

        public DataTable GetAllSoyeGrehUpaye()
        {
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "GetAllSoyeGrehUpaye";
            return GenericDataAccess.ExecuteSelectCommand(dbCommand);
        }

        public DataTable GetAllUchGhar()
        {
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "GetAllUchGhar";
            return GenericDataAccess.ExecuteSelectCommand(dbCommand);
        }
    }
}