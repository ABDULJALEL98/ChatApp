using ChatApp.Application.Persistance.Contracts;
using ChatApp.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly AppliactionDbContext _context;

    public GenericRepository(AppliactionDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(T entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
       var _old = await _context.Set<T>().FindAsync(id);
        if(_old is not null)
        {
            _context.Set<T>().Remove(_old);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    
       =>await _context.Set<T>().AsNoTracking().ToListAsync();


    public async Task<T?> GetAsync(int id)
    => await _context.Set<T>().FindAsync(id);

    public async Task UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
