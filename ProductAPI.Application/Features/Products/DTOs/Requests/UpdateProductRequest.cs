namespace ProductAPI.Application.Features.Products.DTOs.Requests;

public record UpdateProductRequest(int Id, string Name, decimal Price, int Stock);


