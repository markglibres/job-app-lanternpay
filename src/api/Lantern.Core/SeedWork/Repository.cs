using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Lantern.Domain.SeedWork;
using Marten;
using Marten.Linq;

namespace Lantern.Core.SeedWork
{
    public class Repository<T> : IRepository<T>
        where T: Entity
    {
        private readonly IDocumentStore _documentStore;

        public Repository(IDocumentStore documentStore)
        {
            _documentStore = documentStore;
        }
        
        public async Task<T> FindByIdAsync(Guid entityId)
        {
            using (var session = _documentStore.OpenSession())
            {
                var query = await session.Query<T>()
                    .FirstOrDefaultAsync(ag => ag.Id == entityId );
                return query;
            }
        }

        public async Task<IEnumerable<T>> FindByIdAsync(IEnumerable<Guid> entityIds)
        {
            var ids = entityIds.ToList();
            
            var entities = new List<T>();
            
            if(!ids?.Any() ?? true) return entities;
            
            //due to a bug in Marten, we can't fetch multiple using list.contains on query
            //so let's iterate for now
            
            var tasks = new List<Task<T>>();
            
            ids.ForEach(id => tasks.Add(FindByIdAsync(id)));

            entities.AddRange(await Task.WhenAll(tasks));

            return entities;
        }

        public async Task<IEnumerable<T>> FindByPredicate(Expression<Func<T, bool>> predicate)
        {
            using (var session = _documentStore.OpenSession())
            {
                var query = await session
                    .Query<T>()
                    .Where(predicate)
                    .ToListAsync();
                return query;
            }
        }

        public async Task SaveAsync(T entity)
        {
            using (var session = _documentStore.OpenSession())
            {
                session.Store(entity);
                await session.SaveChangesAsync();
            }
        }

        public async Task<bool> IsExists(Guid entityId)
        {
            using (var session = _documentStore.OpenSession())
            {
                var query = await session.Query<T>()
                    .AnyAsync(ag => ag.Id == entityId);
                return query;
            }
        }

        public async Task<IEnumerable<T>> FindAll()
        {
            using (var session = _documentStore.OpenSession())
            {
                var query = await session
                    .Query<T>()
                    .ToListAsync()
                    .ConfigureAwait(false);
                
                return query;
            }
        }
    }
}