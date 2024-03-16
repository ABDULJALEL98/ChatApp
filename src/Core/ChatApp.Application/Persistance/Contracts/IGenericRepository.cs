using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Application.Persistance.Contracts;

public interface IGenericRepository<T> where T : class
{
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T?> GetAsync(int id);
    Task DeleteAsync (int id);
    Task AddAsync (T entity);
    Task UpdateAsync (T entity);

}
