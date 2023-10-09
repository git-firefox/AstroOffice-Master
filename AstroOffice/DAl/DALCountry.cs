using System.Collections.Generic;
using System.Linq;
using AstroOffice.Models;
using AstroOffice.Models.Astrooff;

namespace AstroOffice.DAl
{
    internal class DALCountry
    {
        private readonly AstrooffContext _context;

        public DALCountry()
        {
            _context = new AstrooffContext();
        }

        public IEnumerable<ACountryMaster> GetCountry()
        {
            IEnumerable<ACountryMaster> list = _context.ACountryMasters.OrderBy(acn => acn.Country).ToList<ACountryMaster>();
            return list;
        }
    }
}