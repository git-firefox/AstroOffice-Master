using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AstroOfficeWeb.Services.IServices;
using AstroOfficeWeb.Shared.Helper;
using AstroOfficeWeb.Shared.Models;
using AstroOfficeWeb.Shared.VOs;

namespace AstroOfficeWeb.Services
{
    public class KPDAOService
    {
        private readonly ISwaggerApiService _swagger;

        public KPDAOService(ISwaggerApiService swagger)
        {
            _swagger = swagger;
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

            var response = await _swagger!.PostAsync<GetMixDashaRequest, List<KPMixDashaVO>>(KPDAOApiConst.POST_GetMixDasha, request);
            if (response == null)
                return new();
            return response;
        }

        public async Task<List<KP_Sublord_Pred>> Get_KP_Cusp_Pred(bool showRef, short num)
        {
            var response = await _swagger!.GetAsync<List<KP_Sublord_Pred>>(string.Format(KPDAOApiConst.GET_GetKPCuspPred, showRef, num));
            if (response == null)
                return new();
            return response;
        }

        public async Task<List<KPUpay>?> GetUpayLogic()
        {
            var kPs = await _swagger!.GetAsync<List<KPUpay>>(KPDAOApiConst.GET_GetUpayLogic);
            return kPs;
        }
    }
}
