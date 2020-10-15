using AutoMapper;
using eCommerce.Dtos;
using eCommerce.Models;

namespace eCommerce.Profiles
{
    public class EcommerceProfile : Profile
    {
        public EcommerceProfile()
        {
            CreateMap<Products, ProductsDto>();
            CreateMap<ProductsDto, Products>();
        }
    }
}