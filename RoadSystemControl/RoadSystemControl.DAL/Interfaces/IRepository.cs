using RoadSystemControl.Domains.Models;

namespace RoadSystemControl.DAL.Interfaces;

public interface IRepository<TEntity> where  TEntity: BaseModel
{
    public Task CreateRangeAsync(params TEntity[] entities);
    public Task UpdateRangeAsync(params TEntity[] entities);
    public Task RemoveRangeAsync(params TEntity[] entity);
    public Task<TEntity> FindByIdAsync(int id);
    public Task<IEnumerable<TEntity>> GetAsync();
    public IQueryable<TEntity> GetQueryAsync();
}