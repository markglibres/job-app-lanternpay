using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Lantern.Domain.SeedWork
{
    public interface IRepository<T>
        where T : Entity
    {
        Task<T> FindByIdAsync(Guid entityId);
        Task<IEnumerable<T>> FindByIdAsync(IEnumerable<Guid> entityIds);
        Task<IEnumerable<T>> FindByPredicate(Expression<Func<T, bool>> predicate);
        Task SaveAsync(T entity);
        Task<bool> IsExists(Guid entityId);
        Task<IEnumerable<T>> FindAll();
    }
}