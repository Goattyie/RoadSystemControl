using Microsoft.EntityFrameworkCore;
using RoadSystemControl.DAL.Interfaces;
using RoadSystemControl.Database;
using RoadSystemControl.Domains.Models;

namespace RoadSystemControl.DAL;

public abstract class Repository<TModel> : IRepository<TModel> where TModel : BaseModel
{
    private readonly RscContext _context;
    private readonly DbSet<TModel> _dbSet;

    public Repository(RscContext context)
    {
        _context = context;
        _dbSet = context.Set<TModel>();
    }
    
    public async Task CreateRangeAsync(params TModel[] entities)
    {
        await _dbSet.AddRangeAsync(entities);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateRangeAsync(params TModel[] entities)
    {
        _dbSet.UpdateRange(entities);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveRangeAsync(TModel[] entities)
    {
        _dbSet.RemoveRange(entities);
        await _context.SaveChangesAsync();
    }

    public async Task<TModel> FindByIdAsync(int id) => await _dbSet.FindAsync(id);

    public async Task<IEnumerable<TModel>> GetAsync() => await _dbSet.AsNoTracking().ToListAsync();

    public IQueryable<TModel> GetQueryAsync() => _dbSet.AsQueryable();
}