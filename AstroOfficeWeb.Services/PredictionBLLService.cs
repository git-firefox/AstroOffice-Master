﻿using System;
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
    public class PredictionBLLService
    {
        private readonly ISwaggerApiService _swagger;
        private readonly ISnackbarService _snackbar;

        public PredictionBLLService(ISwaggerApiService swagger, ISnackbarService snackbar)
        {
            _swagger = swagger;
            _snackbar = snackbar;
        }

        public async Task<List<KPDashaVO>?> Get_List_35_Sala(string online_Result, KundliVO persKV, DateTime startDate, DateTime endDate)
        {
            var request = new GetList35SalaRequest()
            {
                Online_Result = online_Result,
                PersKV = persKV,
                Dasha_Starts = startDate,
                Dasha_Ends = endDate
            };

            var response = await _swagger!.PostAsync<GetList35SalaRequest, List<KPDashaVO>>(PredictionBLLApiConst.POST_GetList35Sala, request);

            return response;
        }

        public async Task<KundliVO?> Map_PersKV(string Online_Result, string name, string city, string dd, string mm, string yy, string hh, string min, string ss, string username, string lon, string lat, string tz, bool paid, string lang, bool showref, bool male, string domain, string file_prefix, string vcn_prefix, string source, string headertitle, string product, string wdd, string wmm, string wyy, short rotate)
        {

            var mapPersKVRequest = new MapPersKVRequest
            {
                Online_Result = Online_Result,
                Name = name,
                City = city,
                DD = dd,
                MM = mm,
                YY = yy,
                HH = hh,
                Min = min,
                SS = ss,
                Username = username,
                Lon = lon,
                Lat = lat,
                TZ = tz,
                Paid = paid,
                Lang = lang,
                ShowRef = showref,
                Male = male,
                Domain = domain,
                FilePrefix = file_prefix,
                VcnPrefix = vcn_prefix,
                Source = source,
                HeaderTitle = headertitle,
                Product = product,
                WDD = wdd,
                WMM = wmm,
                WYY = wyy,
                Rotate = rotate
            };

            var response = await _swagger!.PostAsync<MapPersKVRequest, ApiResponse<KundliVO>>(PredictionBLLApiConst.POST_MapPersKV, mapPersKVRequest);
            if (response?.Success == true)
            {
                return response.Data;
            }
            else
            {
                _snackbar.ShowErrorSnackbar(response?.Message);
                return null;
            }

        }

        public async Task<string> GetCodeLang(string rulecode, string lang, bool paid, bool unicode)
        {
            var response = await _swagger!.GetAsync<ApiResponse<string>>(string.Format(PredictionBLLApiConst.GET_GetCodeLang, rulecode, lang, paid, unicode));
            if (response != null)
                return response.Data ?? string.Empty;
            return string.Empty;
        }
    }
}
