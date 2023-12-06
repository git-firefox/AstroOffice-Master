using ASModels.Astrooff;
using VO = ASDLL.ASDLL.ValueObjects;
using AutoMapper;
using AstroOfficeWeb.Shared.Models;
using AstroShared.DTOs;
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
            CreateMap<ProductImage, ImagesDTO>();
            CreateMap<AProduct, ProductDTO>();
            CreateMap<ProductMetaData, MetaDataDTO>();
            CreateMap<ViewProductDTO, AProduct>();
            CreateMap<SaveProductDTO, AProduct>().ForMember(x => x.ProductImages, opt => opt.Ignore());
            CreateMap<Address, AddressDTO>().ForMember(dest => dest.Country, act => act.MapFrom(src => (src.ACountrySnoNavigation != null) ? src.ACountrySnoNavigation.Country : ""));
            CreateMap<AddressDTO, Address>();
        }
    }
}
