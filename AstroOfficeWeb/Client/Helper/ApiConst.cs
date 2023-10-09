namespace AstroOfficeWeb.Client.Helper
{
    public static class ApiConst
    {
        public static string GET_KPBLL_Fill_249 = "api/KPBLL/GetKP249VOs";
        public static string GET_Country_GetCountry = "api/Country/GetCountry";
        public static string POST_SignIn = "api/Account/SignIn";
        public static string POST_SignUp = "api/Account/SignUp";
        public static string GET_PlanetBLL_GetKPPlanetsVOs = "api/PlanetBLL/GetKPPlanetsVOs";
        public static string GET_GetKPHousesVOs = "api/KPBLL/GetKPHousesVOs";
        public static string GET_LocationBLL_GetPlaceListLike = "api/LocationBLL/GetPlaceListLike?place={0}&countryCode={1}";
        public static string GET_LocationBLL_GetPlaceByID = "api/LocationBLL/GetPlaceByID?sno={0}";
        public static string GET_LocationBLL_GetCountryByCode = "api/LocationBLL/GetCountryByCode?countryCode={0}";
        public static string GET_LocationBLL_GetStateByCode = "api/LocationBLL/GetStateByCode?stateCode={0}";
        public static string POST_GenKunda = "api/KundliBLL/GenKunda";
        public static string POST_GenImage = "api/KundliBLL/GenImage";
        public static string POST_MapPersKV = "api/PredictionBLL/MapPersKV";
        public static string GET_KPDAO_GetUpayLogic = "api/KPDAO/GetUpayLogic";
        public static string POST_KundliBLL_GenKunda = "api/KundliBLL/GenKunda";
        public static string POST_KundliBLL_GenImage = "api/KundliBLL/GenImage";
        public static string POST_PredictionBLL_MapPersKV = "api/PredictionBLL/MapPersKV";
        public static string GET_PredictionBLL_GetCodeLang = "api/PredictionBLL/GetCodeLang?rulecode={0}&lang={1}&paid={2}&unicode={3}";
        public static string POST_KPBLL_ProcessPlanetLagan = "api/KPBLL/ProcessPlanetLagan";
        public static string POST_KPBLL_ProcessKPChartGoodBad = "api/KPBLL/ProcessKPChartGoodBad";
        public static string GET_BestBLL_IsBestKundali = "api/BestBLL/IsBestKundali?best_Online_Result={0}&rating={1}&engine={2}";
    }
}
