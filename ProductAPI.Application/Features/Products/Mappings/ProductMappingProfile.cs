using AutoMapper;
using ProductAPI.Application.Features.Products.DTOs.Requests;
using ProductAPI.Application.Features.Products.DTOs.Responses;
using ProductAPI.Domain.Entities;

namespace ProductAPI.Application.Features.Products.Mappings
{
    public class ProductMappingProfile:Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();

         
            CreateMap<CreateProductRequest, Product>();

            
            CreateMap<UpdateProductRequest, Product>();
        }
    }
}
