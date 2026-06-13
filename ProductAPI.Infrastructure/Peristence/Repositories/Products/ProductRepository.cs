using ProductAPI.Application.Interfaces.Persistence;
using ProductAPI.Domain.Entities;
using ProductAPI.Infrastructure.Peristence.Context;
using ProductAPI.Infrastructure.Peristence.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductAPI.Infrastructure.Peristence.Repositories.Products
{
    public class ProductRepository(AppDbContext context) : GenericRepository<Product, int>(context), IProductRepository
    {
    }
}
