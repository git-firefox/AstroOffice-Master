using ASDLL.ASDLL.ValueObjects;
using ASDLL.AstroScienceWeb.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ASDLL.AstroScienceWeb.BLL
{
    public class LocationBLL
    {
        public LocationBLL()
        {
        }

        public string CalculateTimeZone(string zone)
        {
            double num = Convert.ToDouble(zone.Replace("W", "").Replace("E", "").Replace(":", "."));
            int num1 = Convert.ToInt32(num);
            double num2 = Math.Round(num - (double)num1, 2);
            num1 *= 4;
            int num3 = num1 % 60;
            int num4 = Convert.ToInt32(num1 / 60);
            int num5 = Convert.ToInt32(num2 * 100);
            num3 = num3 + num5 * 4 / 60;
            string str = string.Concat(num4.ToString(), ":", num3.ToString());
            str = (!zone.EndsWith("E") ? string.Concat("-", str) : string.Concat("+", str));
            return str;
        }

        public ACountryMaster GetCountryByCode(string code)
        {
            return (new LocationDAL()).GetCountryByCode(code);
        }

        public APlaceMaster GetPlaceByID(long sno)
        {
            return (new LocationDAL()).GetPlaceById(sno);
        }

        public List<APlaceMaster> GetPlaceLikeInCountry(string placename, string countrycode)
        {
            return (new LocationDAL()).GetPlaceLikeInCountry(placename, countrycode);
        }

        public List<APlaceMaster> GetPlaceListLike(string place, string countrycode)
        {
            LocationDAL locationDAL = new LocationDAL();
            List<APlaceMaster> list = (
                from Map in locationDAL.GetPlaceLike(place)
                where Map.CountryCode == countrycode
                select Map).ToList<APlaceMaster>();
            list = (
                from oo in list
                orderby oo.Place
                select oo).ToList<APlaceMaster>();
            return list;
        }

        public AStateMaster GetStateByCode(string code)
        {
            return (new LocationDAL()).GetStateByCode(code);
        }
    }
}