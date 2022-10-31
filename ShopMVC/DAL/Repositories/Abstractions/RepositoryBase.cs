using Domain.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.Repositories.Abstractions;

internal abstract class RepositoryBase<TEntity, TId> : IRepository<TEntity, TId>, IDisposable where TEntity : class
{
    private bool disposed;

    protected ShopContext Context { get; }

    public RepositoryBase(ShopContext shopContext)
    {
        Context = shopContext;
    }

    public virtual async Task<TEntity> Create(TEntity entity)
    {
        await Context.AddAsync(entity);
        await Context.SaveChangesAsync();
        DetachEntity(entity);
        return await GetById(GetId(entity));
    }

    public virtual async Task<TEntity> Update(TEntity entity)
    {
        Context.Update(entity);
        await Context.SaveChangesAsync();
        DetachEntity(entity);
        return await GetById(GetId(entity));
    }

    public virtual async Task Delete(TEntity entity)
    {
        Context.Remove(entity);
        await Context.SaveChangesAsync();
    }

    protected abstract TId GetId(TEntity entity);

    protected abstract Expression<Func<TEntity,bool>> GetExpressionById(TId id);

    protected abstract IQueryable<TEntity> IncludeAllChildren(IQueryable<TEntity> query);

    protected void DetachEntity(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Detached;
    }

    protected IQueryable<TEntity> QueryEntities()
    {
        var query = Context.Set<TEntity>().AsQueryable();
        query = IncludeAllChildren(query);
        return query.AsNoTracking();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose (bool disposing)
    {
        if (disposed)
        {
            return;
        }

        if (disposing)
        {
            Context.Dispose();
        }
        disposed = true;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter)
    {
        if (filter is not null)
            return await QueryEntities().Where(filter).ToListAsync();

        return await QueryEntities().ToListAsync();
    }

    public virtual async Task<TEntity> GetById(TId id)
    {
        var expression = GetExpressionById(id);
        var entity = await QueryEntities().FirstOrDefaultAsync(expression);

        if (entity == null)
        {
            throw new EntityNotFoundException(id, nameof(id), nameof(entity));
        }

        DetachEntity(entity);
        return entity;
    }

    public IQueryable<TEntity> GetAll()
    {
        var query = Context.Set<TEntity>()
            .AsNoTracking();

        return query;
    }
}