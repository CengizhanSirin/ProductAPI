namespace ProductAPI.Application.Features.Products.DTOs.Requests;

public record CreateProductRequest(string Name, decimal Price, int Stock);

