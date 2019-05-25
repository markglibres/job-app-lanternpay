using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Lantern.Domain.SeedWork;

namespace Lantern.Core.SeedWork
{
    public class Repository<T> : IRepository<T>
        where T: Entity
    {
        public Task<T> FindByIdAsync(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> FindByPredicate(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}