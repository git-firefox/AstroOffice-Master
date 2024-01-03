using ASDLL.ASDLL.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace ASDLL.AstroScienceWeb.DAL
{
    public class LocationDAL
    {
        private readonly AstroEntities _astroEntities;

        public LocationDAL()
        {
            _astroEntities = new AstroEntities();
        }

        public List<ACountryMaster> GetAllCountries()
        {
            return _astroEntities.ACountryMasters.ToList<ACountryMaster>();
        }

        public ACountryMaster GetCountryByCode(string code)
        {
            ACountryMaster country = _astroEntities.ACountryMasters.FirstOrDefault(cc => cc.CountryCode == code);
            return country;
        }

        public APlaceMaster GetPlaceById(long sno)
        {
            APlaceMaster place = _astroEntities.APlaceMasters.FirstOrDefault(pp => pp.Sno == sno);
            return place;
        }

        public List<APlaceMaster> GetPlaceLike(string place)
        {
            List<APlaceMaster> list = _astroEntities.APlaceMasters.Where(pp => pp.Place.ToLower().StartsWith(place.ToLower())).ToList();
            return list;
        }

        public List<APlaceMaster> GetPlaceLikeInCountry(string placename, string countrycode)
        {
            List<APlaceMaster> list = _astroEntities.APlaceMasters.Where(pp => pp.Place.ToLower().StartsWith(placename.ToLower()) && pp.CountryCode == countrycode).ToList();
            return list;
        }

        public AStateMaster GetStateByCode(string code)
        {
            AStateMaster state = _astroEntities.AStateMasters.FirstOrDefault(ss => ss.StateCode == code);
            return state;
        }
    }
}