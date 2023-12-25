using AstroOfficeServices.IServices;
using AstroOfficeWeb.Shared.Models;
using AstroShared.Helper;
using AstroShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroOfficeServices
{
    public class KPDAOService
    {
        private readonly ISwaggerApiService Swagger;

        public KPDAOService(ISwaggerApiService swagger)
        {
            Swagger = swagger;
        }

        public async Task<List<KPMixDashaVO>> Get_Mix_Dasha(short nakLord, short signi, short v1, string product, string v2)
        {
            var request = new GetMixDashaRequest()
            {
                Planet = nakLord,
                House = signi,
                FieldNumber = v1,
                Category = product,
                PType = v2
            };

            var response = await Swagger!.PostAsync<GetMixDashaRequest, List<KPMixDashaVO>>(KPDAOApiConst.POST_GetMixDasha, request);
            if (response == null)
                return new();
            return response;
        }

        public async Task<List<KP_Sublord_Pred>> Get_KP_Cusp_Pred(bool showRef, short num)
        {
            var response = await Swagger!.GetAsync<List<KP_Sublord_Pred>>(string.Format(KPDAOApiConst.GET_GetKPCuspPred, showRef, num));
            if (response == null)
                return new();
            return response;
        }
    }
}
