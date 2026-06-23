using ProductAPI.Application.Features.Products.DTOs.Requests;
using ProductAPI.Application.Features.Products.DTOs.Responses;
using ProductAPI.Application.Results;

namespace ProductAPI.Application.Features.Products.Services
{
    public interface IProductService
    {
        Task<ServiceResult<List<ProductDto>>> GetAllAsync();
        Task<ServiceResult<ProductDto?>> GetByIdAsync(int id);
        Task<ServiceResult<List<ProductDto>>> GetPagedAsync(int pageNumber, int pageSize);
        Task<ServiceResult<CreateProductResponse>> CreateAsync(CreateProductRequest request);
        Task<ServiceResult> UpdateAsync(int id, UpdateProductRequest request);
        Task<ServiceResult> DeleteAsync(int id);
    }
}
