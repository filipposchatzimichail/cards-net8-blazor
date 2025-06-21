using Logicea.Cards.Business.Interfaces;
using Logicea.Cards.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

public class CrudService<T> : ICrudService<T> where T : BaseEntity
{
    protected readonly ApplicationDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public CrudService(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public virtual async Task<bool> AddAsync(T item)
    {
        var now = DateTime.Now;

        item.CreatedDate = now;
        item.UpdatedDate = now;

        await _dbSet.AddAsync(item);
        return await _context.SaveChangesAsync() > 0;
    }
    public virtual async Task<bool> AddRangeAsync(IEnumerable<T> items)
    {
        var now = DateTime.Now;

        foreach (var v in items)
        {
            v.CreatedDate = now;
            v.UpdatedDate = now;
        }

        await _dbSet.AddRangeAsync(items);
        return await _context.SaveChangesAsync() > 0;
    }

    public virtual async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null) 
            return false;

        _dbSet.Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task<T> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual async Task<bool> UpdateAsync(T item)
    {
        var now = DateTime.Now;

        item.UpdatedDate = now;

        _dbSet.Update(item);

        return await _context.SaveChangesAsync() > 0;
    }
}