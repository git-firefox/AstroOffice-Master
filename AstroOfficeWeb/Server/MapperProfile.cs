using ASModels.Astrooff;
using DTOs = AstroOfficeWeb.Shared.DTOs;
using VO = ASDLL.ASDLL.ValueObjects;
using AutoMapper;
using AstroOfficeWeb.Shared.Models;

namespace AstroOfficeWeb.Server
{
    public class MapperProfile : Profile
    {
        /// <summary>
        /// CreateMap<TSource, TDestination>()
        /// </summary>
        public MapperProfile()
        {
            CreateMap<ACountryMaster, DTOs.ACountryMaster>();
            CreateMap<VO.ACountryMaster, DTOs.ACountryMaster>();
            CreateMap<VO.APlaceMaster, DTOs.APlaceMaster>();
            CreateMap<VO.AStateMaster, DTOs.AStateMaster>();
            CreateMap<SaveKundaliRequest, AKundali>();

        }
    }
}
