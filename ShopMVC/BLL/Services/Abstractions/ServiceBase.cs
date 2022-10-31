using AutoMapper;
using DAL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services.Abstractions;

public class ServiceBase<TRepository, TId, TDto, TEntity> : IServiceBase<TDto, TId>
    where TRepository : IRepository<TEntity, TId>
    where TEntity : class
    where TDto : class
{
    protected readonly TRepository Repository;
    protected readonly IMapper Mapper;

    public ServiceBase(TRepository repository, IMapper mapper)
    {
        Repository = repository;
        Mapper = mapper;
    }

    public async Task<TDto> Create(TDto entity)
    {
        var entityToCreate = Mapper.Map<TEntity>(entity);
        var createdEntity = await Repository.Create(entityToCreate);

        var result = Mapper.Map<TDto>(createdEntity);
        return result;
    }

    public async Task Delete(TDto entity)
    {
        var entityToDelete = Mapper.Map<TEntity>(entity);
        await Repository.Delete(entityToDelete);
    }

    public async Task<IEnumerable<TDto>> GetAll(int? take, int? skip)
    {
        var query = Repository.GetAll();
        if (skip.HasValue)
        {
            query = query
                .Skip(skip.Value);
        }
        if (take.HasValue)
        {
            query = query
                .Take(take.Value);
        }

        var queryResult = await query
            .ToListAsync();

        var result = Mapper.Map<List<TDto>>(queryResult);
        return result;
    }

    public async Task<TDto> GetById(TId id)
    {
        var dbEntity = await Repository.GetById(id);

        var mappedEntity = Mapper.Map<TDto>(dbEntity);

        return mappedEntity;
    }

    public async Task<TDto> Update(TDto entity)
    {
        var entityToUpdate = Mapper.Map<TEntity>(entity);
        var updatedEntity = await Repository.Update(entityToUpdate);

        var result = Mapper.Map<TDto>(updatedEntity);
        return result;
    }
}