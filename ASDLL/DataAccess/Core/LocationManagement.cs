using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using AstroShared.Models;
namespace ASDLL.DataAccess.Core
{
    public class LocationManagement
    {
        public LocationManagement()
        {
        }

        public int AddCity(CityVO cv)
        {
            return (new LocationDAO()).AddCity(cv);
        }

        public int AddCountry(string countryname)
        {
            return (new LocationDAO()).AddCountry(countryname);
        }

        public void DeleteCity(long cityid)
        {
            (new LocationDAO()).DeleteCity(new long?(cityid));
        }

        public List<CountryVO> getAllCountries()
        {
            List<CountryVO> countryVOs = new List<CountryVO>();
            foreach (DataRow row in (new LocationDAO()).getAllCountries().Rows)
            {
                CountryVO countryVO = new CountryVO()
                {
                    Sno = Convert.ToInt64(row["sno"].ToString()),
                    Countryname = row["country"].ToString()
                };
                countryVOs.Add(countryVO);
            }
            return countryVOs;
        }

        public List<CityVO> GetCities(long ccode)
        {
            List<CityVO> cityVOs = new List<CityVO>();
            foreach (DataRow row in (new LocationDAO()).GetCities().Rows)
            {
                CityVO cityVO = new CityVO()
                {
                    Sno = Convert.ToInt64(row["code"].ToString()),
                    Cityname = row["city"].ToString(),
                    Latitude = row["latitude"].ToString(),
                    Longitude = row["longitude"].ToString()
                };
                cityVOs.Add(cityVO);
            }
            return cityVOs;
        }

        public CityVO GetCityById(long sno)
        {
            CityVO cityVO = new CityVO();
            DataTable cityById = (new LocationDAO()).GetCityById(sno);
            if (cityById.Rows.Count > 0)
            {
                cityVO.Sno = sno;
                cityVO.Ccode = Convert.ToInt64(cityById.Rows[0]["ccode"].ToString());
                cityVO.Cityname = cityById.Rows[0]["city"].ToString();
                cityVO.Latitude = cityById.Rows[0]["latitude"].ToString();
                cityVO.Longitude = cityById.Rows[0]["longitude"].ToString();
            }
            return cityVO;
        }

        public DataTable GetCityLikeName(string cityname)
        {
            return (new LocationDAO()).GetCityLikeName(cityname);
        }

        public DataTable GetTimeZone()
        {
            return (new LocationDAO()).GetTimeZone();
        }

        public int UpdateCity(CityVO cv)
        {
            return (new LocationDAO()).UpdateCity(cv);
        }
    }
}