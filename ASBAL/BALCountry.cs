using System;
using System.Collections;
using ASDAL;
using ASModels.Astrooff;

namespace ASBAL
{
    public class BALCountry
    {
        private readonly DALCountry _dalCountry;

        public BALCountry(DALCountry dalCountry)
        {
            _dalCountry = dalCountry;
        }

        public IEnumerable<ACountryMaster> GetCountry()
        {
            return _dalCountry.GetCountry();
        }
    }
}