using AstroOffice.DAl;
using System;

namespace AstroOffice.BAL
{
    internal class BALProduct
    {
        private readonly DALProduct dlp;

        public BALProduct()
        {
            dlp = new DALProduct();
        }

        public string GetUpayeByPlanetHouse(int planet, int house, string gender, string lang, bool showref, bool bad, bool gudupay)
        {
            string str = this.dlp.GetUpayeByPlanetHouse(planet, house, gender, lang, showref, bad, gudupay).ToString();
            return str;
        }
    }
}