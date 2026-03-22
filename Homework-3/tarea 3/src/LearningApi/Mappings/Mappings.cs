using AutoMapper;
using LearningApi.Domain.Entities;
using LearningApi.Models.Dtos;
using LearningApi.Models.Dtos;
namespace LearningApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductReadDto>()
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.ProductName))
                .ForMember(dest => dest.Precio, opt => opt.MapFrom(src => src.Price));

            CreateMap<ProductCreateDto, Product>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Precio));

            CreateMap<ProductUpdateDto, Product>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Precio));
        }
    }
}