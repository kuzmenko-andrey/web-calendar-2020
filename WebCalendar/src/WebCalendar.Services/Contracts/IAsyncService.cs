﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebCalendar.Services.Contracts
{
    public interface IAsyncService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(Guid id);
        Task RemoveAsync(T entity);
    }
}