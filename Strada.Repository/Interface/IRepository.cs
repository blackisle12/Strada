﻿using System.Linq.Expressions;

namespace Strada.Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        Task<T?> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes);
        Task AddAsync(T entity);
        void Update(T entity);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
        void Detach(T entity);
    }
}
