using Microsoft.EntityFrameworkCore;
using ProductAPI.Application.Interfaces.Persistence;
using ProductAPI.Infrastructure.Peristence.Context;

namespace ProductAPI.Infrastructure.Peristence.UnitOfWork;

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
         => context.SaveChangesAsync(cancellationToken);
}


