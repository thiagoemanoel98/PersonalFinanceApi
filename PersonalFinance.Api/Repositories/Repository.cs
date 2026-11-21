using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PersonalFinance.Api.Context;
using PersonalFinance.Api.Repositories.Interfaces;

namespace PersonalFinance.Api.Repositories;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public T Create(T entity)
    {
        _context.Set<T>().Add(entity);
        return entity;
    }

    public T Update(T entity)
    {
        _context.Set<T>().Update(entity);
        return entity;
    }

    public T Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        return entity;
    }

    protected IQueryable<T> GetAllQueryable()
    {
        return _context.Set<T>().AsNoTracking();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await GetAllQueryable().ToListAsync();
    }

    public Task<T?> GetAsync(Expression<Func<T, bool>> predicate)
    {
        return _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate);
    }
}
