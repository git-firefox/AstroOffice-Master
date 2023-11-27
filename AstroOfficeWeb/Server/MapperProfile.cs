using ASModels.Astrooff;
using VO = ASDLL.ASDLL.ValueObjects;
using AutoMapper;
using AstroOfficeWeb.Shared.Models;
using AstroShared.DTOs;

namespace AstroOfficeWeb.Server
{
    public class MapperProfile : Profile
    {
        /// <summary>
        /// CreateMap<TSource, TDestination>()
        /// </summary>
        public MapperProfile()
        {
            CreateMap<ACountryMaster, CountryDTO>();
            CreateMap<VO.ACountryMaster, CountryDTO>();
            CreateMap<VO.APlaceMaster, PlaceDTO>();
            CreateMap<VO.AStateMaster, StateDTO>();
            CreateMap<SaveKundaliRequest, AKundali>();
            CreateMap<AKundali, KundaliDTO>();
            CreateMap<AProduct, ViewProductDTO>();
            CreateMap<ViewProductDTO, AProduct>();
            CreateMap<SaveProductDTO, AProduct>();
            CreateMap<Address, AddressDTO>().ForMember(dest => dest.Country, act => act.MapFrom(src => (src.ACountrySnoNavigation != null) ? src.ACountrySnoNavigation.Country : ""));
            CreateMap<AddressDTO, Address>();
        }
    }
}
