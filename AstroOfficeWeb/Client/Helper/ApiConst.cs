﻿namespace AstroOfficeWeb.Client.Helper
{
    public static class KPBLLApiConst
    {
        public static string Base = "api/KPBLL/";
        public static string GET_Fill_249 = Base + "GetKP249VOs";
        public static string POST_GetFalDoubleMahadasha = Base + "GetFalDoubleMahadasha";
        public static string GET_GetKPHousesVOs = Base + "GetKPHousesVOs";
        public static string POST_ProcessPlanetLagan = Base + "ProcessPlanetLagan";
        public static string POST_ProcessKPChartGoodBad = Base + "ProcessKPChartGoodBad";
        public static string POST_GetNewProducts = Base + "GetNewProducts";
        public static string GET_GetKPLang = Base + "GetKPLang";
        public static string POST_TenthKamkajPred = Base + "TenthKamkajPred";
        public static string POST_GetPlanetNakPlanetSublordFal = Base + "GetPlanetNakPlanetSublordFal";
        public static string POST_GetPlanetChainPred = Base + "GetPlanetChainPred";
        public static string POST_GetDashaPred = Base + "GetDashaPred";
        public static string POST_GetDashaPredIntelli = Base + "GetDashaPredIntelli";
    }

    public static class CountryApiConst
    {
        public static string Base = "api/Country/";
        public static string GET_GetCountry = Base + "GetCountry";
    }

    public static class AccountApiConst
    {
        public static string Base = "api/Account/";
        public static string POST_SignIn = Base + "SignIn";
        public static string POST_SignUp = Base + "SignUp";
        public static string POST_SignInWithOtp = Base + "SignInWithOtp";
        public static string PUT_UpdateUserPasswordByOtp = Base + "UpdateUserPasswordByOtp";
    }

    public static class PlanetBLLApiConst
    {
        public static string Base = "api/PlanetBLL/";
        public static string GET_GetKPPlanetsVOs = Base + "GetKPPlanetsVOs";
    }

    public static class LocationBLLApiConst
    {
        public static string Base = "api/LocationBLL/";
        public static string GET_GetPlaceListLike = Base + "GetPlaceListLike?place={0}&countryCode={1}";
        public static string GET_GetPlaceByID = Base + "GetPlaceByID?sno={0}";
        public static string GET_GetCountryByCode = Base + "GetCountryByCode?countryCode={0}";
        public static string GET_GetStateByCode = Base + "GetStateByCode?stateCode={0}";
    }

    public static class KundliBLLApiConst
    {
        public static string Base = "api/KundliBLL/";
        public static string POST_GenKunda = Base + "GenKunda";
        public static string POST_GenImage = Base + "GenImage";
        public static string POST_NEWGetVarshaphalKundliMapping = Base + "NEWGetVarshaphalKundliMapping";
    }

    public static class PredictionBLLApiConst
    {
        public static string Base = "api/PredictionBLL/";
        public static string POST_MapPersKV = Base + "MapPersKV";
        public static string POST_GetList35Sala = Base + "GetList35Sala";
        public static string POST_GetFalAntar = Base + "GetFalAntar";
        public static string POST_GetFalDoubleAntarHyphenWala = Base + "GetFalDoubleAntarHyphenWala";
        public static string GET_GetCodeLang = Base + "GetCodeLang?rulecode={0}&lang={1}&paid={2}&unicode={3}";
    }

    public static class KPDAOApiConst
    {
        public static string Base = "api/KPDAO/";
        public static string GET_GetUpayLogic = Base + "GetUpayLogic";
        public static string POST_GetMixDasha = Base + "GetMixDasha";
        public static string GET_GetKPCuspPred = Base + "GetKPCuspPred?showref={0}&house={1}";
    }

    public static class BestBLLApiConst
    {
        public static string Base = "api/BestBLL/";
        public static string POST_IsBestKundali = Base + "IsBestKundali";
        public static string POST_IsBestKundaliKPAuto = Base + "IsBestKundaliKPAuto";

    }

    public static class KPPredBLLApiConst
    {
        public static string Base = "api/KPPredBLL/";
        public static string POST_GetRedSigniPlanetWise = Base + "GetRedSigniPlanetWise";
    }

    public static class PdfApiConst
    {
        public static string Base = "api/Pdf/";
        public static string POST_GeneratePDF = Base + "GeneratePDF";
    }
    public static class SMSApiConst
    {
        public static string Base = "api/SMS/";
        public static string GET_VerifyOtp = Base + "VerifyOtp?mobileNumber={0}&otp={1}";
        public static string GET_SendOtp = Base + "SendOtp?mobileNumber={0}";
    }

    public static class KundaliHistoryApiConst
    {
        public static string Base = "api/KundaliHistory/";
        public static string POST_SaveKundali = Base + "SaveKundali";
        public static string GET_GetAllUserKundalies = Base + "GetAllUserKundalies";
    }
}
