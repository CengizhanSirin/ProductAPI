using ProductAPI.Domain.Entities;

namespace ProductAPI.Application.Interfaces.Persistence
{
    public interface IProductRepository: IGenericRepository<Product,int>
    {
    }
}
