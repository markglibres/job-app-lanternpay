using System.Collections.Generic;
using System.Threading.Tasks;
using Lantern.Api.Application.Lectures.ResponseModels;
using Lantern.Domain.Lectures;

namespace Lantern.Api.Application.Mappers.Services
{
    public interface IEntityMapperService<T>
        where T : new()
    {
        Task<T> Map(T entity);
        Task<IEnumerable<T>> Map(IEnumerable<T> entities);
    }
}