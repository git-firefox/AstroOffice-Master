using AstroOffice.DAl;
using System;
using System.Collections;

namespace AstroOffice.BAL
{
    internal class BALCountry
    {
        private readonly DALCountry _dalCountry;

        public BALCountry()
        {
            _dalCountry = new DALCountry();
        }

        public IEnumerable GetCountry()
        {
            return _dalCountry.GetCountry();
        }
    }
}