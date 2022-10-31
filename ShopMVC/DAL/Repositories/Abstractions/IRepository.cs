using System.Linq.Expressions;

namespace DAL.Repositories.Abstractions;

public interface IRepository <TEntity, TId> where TEntity : class
{
    public Task<TEntity> Create(TEntity entity);
    public Task<TEntity> Update(TEntity entity);
    public Task Delete(TEntity entity);
    public Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity,bool>> filter);
    public Task<TEntity> GetById(TId id);
    public IQueryable<TEntity> GetAll();
}