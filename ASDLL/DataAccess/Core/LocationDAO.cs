using ASDLL;
using AstroOfficeWeb.Shared.VOs;
using System;
using System.Data;
using System.Data.Common;
//using AstroShared.Models;
namespace ASDLL.DataAccess.Core
{
    public class LocationDAO
    {
        public LocationDAO()
        {
        }

        public int AddCity(CityVO cv)
        {
            int num = 0;
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "AddCity";
            DbParameter ccode = dbCommand.CreateParameter();
            ccode.DbType = DbType.Int64;
            ccode.ParameterName = "@ccode";
            ccode.Value = cv.Ccode;
            DbParameter dbParameter = dbCommand.CreateParameter();
            dbParameter.ParameterName = "@cnt";
            dbParameter.DbType = DbType.Int32;
            dbParameter.Direction = ParameterDirection.Output;
            DbParameter cityname = dbCommand.CreateParameter();
            cityname.DbType = DbType.String;
            cityname.ParameterName = "@cityname";
            cityname.Value = cv.Cityname;
            DbParameter longitude = dbCommand.CreateParameter();
            longitude.DbType = DbType.String;
            longitude.ParameterName = "@longitude";
            longitude.Value = cv.Longitude;
            DbParameter latitude = dbCommand.CreateParameter();
            latitude.DbType = DbType.String;
            latitude.ParameterName = "@latitude";
            latitude.Value = cv.Latitude;
            dbCommand.Parameters.Add(ccode);
            dbCommand.Parameters.Add(dbParameter);
            dbCommand.Parameters.Add(cityname);
            dbCommand.Parameters.Add(longitude);
            dbCommand.Parameters.Add(latitude);
            GenericDataAccess.ExecuteSelectCommand(dbCommand);
            num = Convert.ToInt32(dbCommand.Parameters["@cnt"].Value);
            return num;
        }

        public int AddCountry(string countryname)
        {
            int num = 0;
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "AddCountry";
            DbParameter dbParameter = dbCommand.CreateParameter();
            dbParameter.ParameterName = "@countryname";
            dbParameter.DbType = DbType.String;
            dbParameter.Value = countryname;
            DbParameter dbParameter1 = dbCommand.CreateParameter();
            dbParameter1.ParameterName = "@cnt";
            dbParameter1.DbType = DbType.Int32;
            dbParameter1.Direction = ParameterDirection.Output;
            dbCommand.Parameters.Add(dbParameter);
            dbCommand.Parameters.Add(dbParameter1);
            GenericDataAccess.ExecuteSelectCommand(dbCommand);
            num = Convert.ToInt32(dbCommand.Parameters["@cnt"].Value);
            return num;
        }

        public void DeleteCity(long? cityid)
        {
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "DeleteCity";
            DbParameter dbParameter = dbCommand.CreateParameter();
            dbParameter.ParameterName = "@cityid";
            dbParameter.DbType = DbType.Int64;
            dbParameter.Value = cityid;
            dbCommand.Parameters.Add(dbParameter);
            GenericDataAccess.ExecuteSelectCommand(dbCommand);
        }

        public DataTable getAllCountries()
        {
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "GetAllCountries";
            return GenericDataAccess.ExecuteSelectCommand(dbCommand);
        }

        public DataTable GetCities()
        {
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "GetAllCities";
            return GenericDataAccess.ExecuteSelectCommand(dbCommand);
        }

        public DataTable GetCityById(long sno)
        {
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "GetCityById";
            DbParameter dbParameter = dbCommand.CreateParameter();
            dbParameter.ParameterName = "@sno";
            dbParameter.DbType = DbType.Int64;
            dbParameter.Value = sno;
            dbCommand.Parameters.Add(dbParameter);
            return GenericDataAccess.ExecuteSelectCommand(dbCommand);
        }

        public DataTable GetCityLikeName(string citylike)
        {
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "GetCitiesLikeName";
            DbParameter dbParameter = dbCommand.CreateParameter();
            dbParameter.ParameterName = "@cityname";
            dbParameter.DbType = DbType.String;
            dbParameter.Value = citylike;
            dbCommand.Parameters.Add(dbParameter);
            return GenericDataAccess.ExecuteSelectCommand(dbCommand);
        }

        public DataTable GetTimeZone()
        {
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "GetAllTimeZone";
            return GenericDataAccess.ExecuteSelectCommand(dbCommand);
        }

        public int UpdateCity(CityVO cv)
        {
            int num = 0;
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "UpdateCity";
            DbParameter ccode = dbCommand.CreateParameter();
            ccode.DbType = DbType.Int64;
            ccode.ParameterName = "@ccode";
            ccode.Value = cv.Ccode;
            DbParameter dbParameter = dbCommand.CreateParameter();
            dbParameter.ParameterName = "@cnt";
            dbParameter.DbType = DbType.Int32;
            dbParameter.Direction = ParameterDirection.Output;
            DbParameter cityname = dbCommand.CreateParameter();
            cityname.DbType = DbType.String;
            cityname.ParameterName = "@cityname";
            cityname.Value = cv.Cityname;
            DbParameter longitude = dbCommand.CreateParameter();
            longitude.DbType = DbType.String;
            longitude.ParameterName = "@longitude";
            longitude.Value = cv.Longitude;
            DbParameter latitude = dbCommand.CreateParameter();
            latitude.DbType = DbType.String;
            latitude.ParameterName = "@latitude";
            latitude.Value = cv.Latitude;
            DbParameter sno = dbCommand.CreateParameter();
            sno.DbType = DbType.Int64;
            sno.ParameterName = "@sno";
            sno.Value = cv.Sno;
            dbCommand.Parameters.Add(ccode);
            dbCommand.Parameters.Add(dbParameter);
            dbCommand.Parameters.Add(cityname);
            dbCommand.Parameters.Add(longitude);
            dbCommand.Parameters.Add(latitude);
            dbCommand.Parameters.Add(sno);
            GenericDataAccess.ExecuteSelectCommand(dbCommand);
            num = Convert.ToInt32(dbCommand.Parameters["@cnt"].Value);
            return num;
        }
    }
}