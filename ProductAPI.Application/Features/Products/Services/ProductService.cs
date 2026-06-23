using AutoMapper;
using ProductAPI.Application.Features.Products.DTOs.Requests;
using ProductAPI.Application.Features.Products.DTOs.Responses;
using ProductAPI.Application.Interfaces.Persistence;
using ProductAPI.Application.Results;
using ProductAPI.Domain.Entities;
using System.Net;

namespace ProductAPI.Application.Features.Products.Services
{
    public class ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper) : IProductService
    {
        public async Task<ServiceResult<CreateProductResponse>> CreateAsync(CreateProductRequest request)
        {
            var anyProduct = await productRepository.AnyAsync(c => c.Name == request.Name);

            if (anyProduct)
                return ServiceResult<CreateProductResponse>.Fail("A product with the same name already exists.", HttpStatusCode.Conflict);

            var product = mapper.Map<Product>(request);

            await productRepository.AddAsync(product);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult<CreateProductResponse>.SuccessAsCreated(new CreateProductResponse(product.Id), $"/api/products/{product.Id}");

        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var anyProduct = await productRepository.AnyAsync(x => x.Id == id);

            if (!anyProduct)
                return ServiceResult.Fail("Product not found.", HttpStatusCode.NotFound);

            await productRepository.DeleteByIdAsync(id);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult<List<ProductDto>>> GetAllAsync()
        {
              var products = await productRepository.GetAllAsync();
            var productDtos = mapper.Map<List<ProductDto>>(products);

            return ServiceResult<List<ProductDto>>.Success(productDtos);
        }

        public async Task<ServiceResult<ProductDto?>> GetByIdAsync(int id)
        {
            var product = await productRepository.GetByIdAsync(id);

            if (product is null)
                return ServiceResult<ProductDto?>.Fail("Product not found.", HttpStatusCode.NotFound);

            var productDto = mapper.Map<ProductDto>(product);

            return ServiceResult<ProductDto?>.Success(productDto);
        }

        public async Task<ServiceResult<List<ProductDto>>> GetPagedAsync(int pageNumber, int pageSize)
        {
            if (pageNumber <= 0 || pageSize <= 0)
                return ServiceResult<List<ProductDto>>.Fail("Invalid pagination parameters.", HttpStatusCode.BadRequest);

            var products = await productRepository.GetAllPagedAsync(pageNumber, pageSize);

            var productDtos = mapper.Map<List<ProductDto>>(products);

            return ServiceResult<List<ProductDto>>.Success(productDtos);
        }

        public async Task<ServiceResult> UpdateAsync(int id, UpdateProductRequest request)
        {
            if (id != request.Id)
                return ServiceResult.Fail("Id mismatch.", HttpStatusCode.BadRequest);

            var product = await productRepository.GetByIdAsync(id);

            if (product is null)
                return ServiceResult.Fail("Product not found.", HttpStatusCode.NotFound);

            var isSameNameProduct = await productRepository
                .AnyAsync(x => x.Name == request.Name && x.Id != id);

            if (isSameNameProduct)
                return ServiceResult.Fail("A product with the same name already exists.", HttpStatusCode.Conflict);

            
            mapper.Map(request, product);

            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }
    }
}
