using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;

namespace RazorApp.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(string id);
        Task<IReadOnlyList<T>> GetAll();
        Task<bool> Exist(string id);
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Update(T entity, List<Expression<Func<T, object>>> updatedProperties = null);
        Task Delete(T entity);
    }
}
