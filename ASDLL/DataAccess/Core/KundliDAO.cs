using ASDLL;
using AstroOfficeWeb.Shared.VOs;
using Kunda;
using System;
using System.Data;
using System.Data.Common;
//using AstroShared.Models;
namespace ASDLL.DataAccess.Core
{
    public class KundliDAO
    {
        public KundliDAO()
        {
        }

        public long AddKundli(KundliVO kv)
        {
            long num = (long)0;
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "AddKundli";
            DbParameter name = dbCommand.CreateParameter();
            name.ParameterName = "@name";
            name.DbType = DbType.String;
            name.Value = kv.Name;
            DbParameter dob = dbCommand.CreateParameter();
            dob.ParameterName = "@dob";
            dob.DbType = DbType.DateTime;
            dob.Value = kv.Dob;
            DbParameter tob = dbCommand.CreateParameter();
            tob.ParameterName = "@tob";
            tob.DbType = DbType.DateTime;
            tob.Value = kv.Tob;
            DbParameter placeofbirth = dbCommand.CreateParameter();
            placeofbirth.ParameterName = "@placeofbirth";
            placeofbirth.DbType = DbType.String;
            placeofbirth.Value = kv.Placeofbirth;
            DbParameter lagna = dbCommand.CreateParameter();
            lagna.ParameterName = "@lagna";
            lagna.DbType = DbType.Int64;
            lagna.Value = kv.Lagna;
            DbParameter dbParameter = dbCommand.CreateParameter();
            dbParameter.ParameterName = "@kid";
            dbParameter.DbType = DbType.Int64;
            dbParameter.Direction = ParameterDirection.Output;
            DbParameter lon = dbCommand.CreateParameter();
            lon.ParameterName = "@lon";
            lon.DbType = DbType.Double;
            lon.Value = kv.Lon;
            DbParameter lat = dbCommand.CreateParameter();
            lat.ParameterName = "@lat";
            lat.DbType = DbType.Double;
            lat.Value = kv.Lat;
            DbParameter timeZone = dbCommand.CreateParameter();
            timeZone.ParameterName = "@timezone";
            timeZone.DbType = DbType.Double;
            timeZone.Value = kv.TimeZone;
            DbParameter remarks = dbCommand.CreateParameter();
            remarks.ParameterName = "@remarks";
            remarks.DbType = DbType.String;
            remarks.Value = kv.Remarks;
            DbParameter username = dbCommand.CreateParameter();
            username.ParameterName = "@username";
            username.DbType = DbType.String;
            username.Value = AstroGlobal.Username;
            DbParameter orderno = dbCommand.CreateParameter();
            orderno.ParameterName = "@orderno";
            orderno.DbType = DbType.Int64;
            orderno.Value = kv.Orderno;
            DbParameter product = dbCommand.CreateParameter();
            product.ParameterName = "@product";
            product.DbType = DbType.String;
            product.Value = kv.Product;
            DbParameter paid = dbCommand.CreateParameter();
            paid.ParameterName = "@paid";
            paid.DbType = DbType.Boolean;
            paid.Value = kv.Paid;
            DbParameter lonstr = dbCommand.CreateParameter();
            lonstr.ParameterName = "@lonstr";
            lonstr.DbType = DbType.String;
            lonstr.Value = kv.Lonstr;
            DbParameter latstr = dbCommand.CreateParameter();
            latstr.ParameterName = "@latstr";
            latstr.DbType = DbType.String;
            latstr.Value = kv.Latstr;
            DbParameter timezonestr = dbCommand.CreateParameter();
            timezonestr.ParameterName = "@timezonestr";
            timezonestr.DbType = DbType.String;
            timezonestr.Value = kv.Timezonestr;
            DbParameter language = dbCommand.CreateParameter();
            language.ParameterName = "@language";
            language.DbType = DbType.String;
            language.Value = kv.Language;
            DbParameter manual = dbCommand.CreateParameter();
            manual.ParameterName = "@manual";
            manual.DbType = DbType.Boolean;
            manual.Value = kv.Manual;
            DbParameter source = dbCommand.CreateParameter();
            source.ParameterName = "@source";
            source.DbType = DbType.String;
            source.Value = kv.Source;
            DbParameter dD = dbCommand.CreateParameter();
            dD.ParameterName = "@dd";
            dD.DbType = DbType.String;
            dD.Value = kv.DD;
            DbParameter mM = dbCommand.CreateParameter();
            mM.ParameterName = "@mm";
            mM.DbType = DbType.String;
            mM.Value = kv.MM;
            DbParameter yY = dbCommand.CreateParameter();
            yY.ParameterName = "@yy";
            yY.DbType = DbType.String;
            yY.Value = kv.YY;
            DbParameter hH = dbCommand.CreateParameter();
            hH.ParameterName = "@hh";
            hH.DbType = DbType.String;
            hH.Value = kv.HH;
            DbParameter mIN = dbCommand.CreateParameter();
            mIN.ParameterName = "@min";
            mIN.DbType = DbType.String;
            mIN.Value = kv.MIN;
            DbParameter sS = dbCommand.CreateParameter();
            sS.ParameterName = "@ss";
            sS.DbType = DbType.String;
            sS.Value = kv.SS;
            DbParameter male = dbCommand.CreateParameter();
            male.ParameterName = "@male";
            male.DbType = DbType.Boolean;
            male.Value = kv.Male;
            DbParameter machine = dbCommand.CreateParameter();
            machine.ParameterName = "@machine";
            machine.DbType = DbType.String;
            machine.Value = kv.Machine;
            dbCommand.Parameters.Add(name);
            dbCommand.Parameters.Add(dob);
            dbCommand.Parameters.Add(tob);
            dbCommand.Parameters.Add(placeofbirth);
            dbCommand.Parameters.Add(lagna);
            dbCommand.Parameters.Add(dbParameter);
            dbCommand.Parameters.Add(lon);
            dbCommand.Parameters.Add(lat);
            dbCommand.Parameters.Add(timeZone);
            dbCommand.Parameters.Add(remarks);
            dbCommand.Parameters.Add(username);
            dbCommand.Parameters.Add(orderno);
            dbCommand.Parameters.Add(product);
            dbCommand.Parameters.Add(paid);
            dbCommand.Parameters.Add(lonstr);
            dbCommand.Parameters.Add(latstr);
            dbCommand.Parameters.Add(timezonestr);
            dbCommand.Parameters.Add(language);
            dbCommand.Parameters.Add(manual);
            dbCommand.Parameters.Add(source);
            dbCommand.Parameters.Add(dD);
            dbCommand.Parameters.Add(mM);
            dbCommand.Parameters.Add(yY);
            dbCommand.Parameters.Add(hH);
            dbCommand.Parameters.Add(mIN);
            dbCommand.Parameters.Add(sS);
            dbCommand.Parameters.Add(male);
            dbCommand.Parameters.Add(machine);
            GenericDataAccess.ExecuteSelectCommand(dbCommand);
            num = Convert.ToInt64(dbCommand.Parameters["@kid"].Value);
            return num;
        }

        public void AddKundliMapping(KundliMappingVO kmv)
        {
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "AddKundliMapping";
            DbParameter house = dbCommand.CreateParameter();
            house.ParameterName = "@house";
            house.DbType = DbType.Int32;
            house.Value = kmv.House;
            DbParameter rashi = dbCommand.CreateParameter();
            rashi.ParameterName = "@rashi";
            rashi.DbType = DbType.Int32;
            rashi.Value = kmv.Rashi;
            DbParameter planet = dbCommand.CreateParameter();
            planet.ParameterName = "@planet";
            planet.DbType = DbType.Int32;
            planet.Value = kmv.Planet;
            DbParameter kundliid = dbCommand.CreateParameter();
            kundliid.ParameterName = "@kundliid";
            kundliid.DbType = DbType.Int64;
            kundliid.Value = kmv.Kundliid;
            DbParameter degree = dbCommand.CreateParameter();
            degree.ParameterName = "@degree";
            degree.DbType = DbType.Double;
            degree.Value = kmv.Degree;
            dbCommand.Parameters.Add(house);
            dbCommand.Parameters.Add(rashi);
            dbCommand.Parameters.Add(planet);
            dbCommand.Parameters.Add(kundliid);
            dbCommand.Parameters.Add(degree);
            GenericDataAccess.ExecuteSelectCommand(dbCommand);
        }

        public DataTable GetAdvancePredictions(string xmlmaps, int planet, int yog)
        {
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "GetAdvancePredictions";
            DbParameter dbParameter = dbCommand.CreateParameter();
            dbParameter.ParameterName = "@xmlmaps";
            dbParameter.DbType = DbType.String;
            dbParameter.Value = xmlmaps;
            DbParameter dbParameter1 = dbCommand.CreateParameter();
            dbParameter1.ParameterName = "@planet";
            dbParameter1.DbType = DbType.Int32;
            dbParameter1.Value = planet;
            DbParameter dbParameter2 = dbCommand.CreateParameter();
            dbParameter2.ParameterName = "@yog";
            dbParameter2.DbType = DbType.Int32;
            dbParameter2.Value = yog;
            dbCommand.Parameters.Add(dbParameter);
            dbCommand.Parameters.Add(dbParameter1);
            dbCommand.Parameters.Add(dbParameter2);
            return GenericDataAccess.ExecuteSelectCommand(dbCommand);
        }

        public DataTable GetBasicRulesByKundli(long kundliid)
        {
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "GetBasicRuleByKundli";
            DbParameter dbParameter = dbCommand.CreateParameter();
            dbParameter.ParameterName = "@kundliid";
            dbParameter.DbType = DbType.Int64;
            dbParameter.Value = kundliid;
            dbCommand.Parameters.Add(dbParameter);
            return GenericDataAccess.ExecuteSelectCommand(dbCommand);
        }

        public DataTable GetKundliByID(long kundliid)
        {
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = string.Concat("select *from A_kundlis (nolock)  where sno=", kundliid);
            dbCommand.CommandType = CommandType.Text;
            return GenericDataAccess.ExecuteSelectCommand(dbCommand);
        }

        public DataTable GetKundliByOrderNumber(long orderno)
        {
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = string.Concat("select *from A_kundlis (nolock) where orderno=", orderno.ToString());
            dbCommand.CommandType = CommandType.Text;
            return GenericDataAccess.ExecuteSelectCommand(dbCommand);
        }

        public DataTable GetKundliLikeName(string name)
        {
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "GetKunlisLikeName";
            DbParameter dbParameter = dbCommand.CreateParameter();
            dbParameter.ParameterName = "@name";
            dbParameter.DbType = DbType.String;
            dbParameter.Value = name;
            dbCommand.Parameters.Add(dbParameter);
            return GenericDataAccess.ExecuteSelectCommand(dbCommand);
        }

        public DataTable GetKundliMappings(long kundliid)
        {
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "GetKundliMappings";
            DbParameter dbParameter = dbCommand.CreateParameter();
            dbParameter.ParameterName = "@kundliid";
            dbParameter.DbType = DbType.Int64;
            dbParameter.Value = kundliid;
            dbCommand.Parameters.Add(dbParameter);
            return GenericDataAccess.ExecuteSelectCommand(dbCommand);
        }

        public DataTable GetMandeGharPlanets(string kundlimaps)
        {
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "GetMandeGharPlanetsInKundli";
            DbParameter dbParameter = dbCommand.CreateParameter();
            dbParameter.ParameterName = "@xmlmaps";
            dbParameter.DbType = DbType.String;
            dbParameter.Value = kundlimaps;
            dbCommand.Parameters.Add(dbParameter);
            return GenericDataAccess.ExecuteSelectCommand(dbCommand);
        }

        public DataTable GetNeechGharPlanets(string kundlimaps)
        {
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "GetNeechGharPlanetsInKundli";
            DbParameter dbParameter = dbCommand.CreateParameter();
            dbParameter.ParameterName = "@xmlmaps";
            dbParameter.DbType = DbType.String;
            dbParameter.Value = kundlimaps;
            dbCommand.Parameters.Add(dbParameter);
            return GenericDataAccess.ExecuteSelectCommand(dbCommand);
        }

        public DataTable GetPakkeGharPlanets(string kundlimaps)
        {
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "GetAllPakkeGharPlanetsInKundli";
            DbParameter dbParameter = dbCommand.CreateParameter();
            dbParameter.ParameterName = "@xmlmaps";
            dbParameter.DbType = DbType.String;
            dbParameter.Value = kundlimaps;
            dbCommand.Parameters.Add(dbParameter);
            return GenericDataAccess.ExecuteSelectCommand(dbCommand);
        }

        public DataTable GetShreshtGharPlanets(string kundlimaps)
        {
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "GetShresthGharPlanetsInKundli";
            DbParameter dbParameter = dbCommand.CreateParameter();
            dbParameter.ParameterName = "@xmlmaps";
            dbParameter.DbType = DbType.String;
            dbParameter.Value = kundlimaps;
            dbCommand.Parameters.Add(dbParameter);
            return GenericDataAccess.ExecuteSelectCommand(dbCommand);
        }

        public DataTable GetUchGharPlanets(string kundlimaps)
        {
            DbCommand dbCommand = GenericDataAccess.CreateCommand();
            dbCommand.CommandText = "GetUchGharPlanetsInKundli";
            DbParameter dbParameter = dbCommand.CreateParameter();
            dbParameter.ParameterName = "@xmlmaps";
            dbParameter.DbType = DbType.String;
            dbParameter.Value = kundlimaps;
            dbCommand.Parameters.Add(dbParameter);
            return GenericDataAccess.ExecuteSelectCommand(dbCommand);
        }
    }
}