using System;
using System.Collections.Generic;
using System.Text;

namespace ProductAPI.Application.Interfaces.Persistence
{
    public interface IUnitOfWork
    {
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
         
    }
}
