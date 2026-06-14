using AutoMapper;
using ProductAPI.Application.Features.Products.DTOs.Requests;
using ProductAPI.Application.Features.Products.DTOs.Responses;
using ProductAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
