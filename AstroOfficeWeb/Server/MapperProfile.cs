using ASModels.Astrooff;
using VO = ASDLL.ASDLL.ValueObjects;
using AutoMapper;
using AstroOfficeWeb.Shared.Models;
using AstroOfficeWeb.Shared.DTOs;
using System.Diagnostics.Eventing.Reader;

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
            CreateMap<ProductMedia, MediaDTO>();
            CreateMap<AProduct, ProductDTO>();
            CreateMap<ProductMetaData, MetaDataDTO>();
            CreateMap<ViewProductDTO, AProduct>();
            CreateMap<AUser, BaseUserDTO>();
            CreateMap<ProductCategory, CategoryDTO>().ReverseMap();
            CreateMap<SaveProductDTO, AProduct>()
                .ForMember(x => x.ProductMedia, opt => opt.Ignore())
                .ForMember(x => x.ImageUrl, opt => opt.Ignore());

            CreateMap<Address, AddressDTO>().ForMember(dest => dest.Country, act => act.MapFrom(src => (src.ACountrySnoNavigation != null) ? src.ACountrySnoNavigation.Country : ""));
            CreateMap<AddressDTO, Address>();
        }
    }
}
