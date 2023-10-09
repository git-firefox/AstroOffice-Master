using System.Collections.Generic;
using System.Linq;
using ASModels;
using ASModels.Astrooff;

namespace ASDAL
{
    public class DALCountry
    {
        private readonly AstrooffContext _context;

        public DALCountry(AstrooffContext context)
        {
            _context = context;
        }

        public IEnumerable<ACountryMaster> GetCountry()
        {
            IEnumerable<ACountryMaster> list = _context.ACountryMasters.OrderBy(acn => acn.Country).ToList<ACountryMaster>();
            return list;
        }
    }
}