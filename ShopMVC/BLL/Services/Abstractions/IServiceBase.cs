namespace BLL.Services.Abstractions;

public interface IServiceBase<TDto, TId>
    where TDto : class
{
    public Task<TDto> Create(TDto entity);
    public Task<TDto> Update(TDto entity);
    public Task Delete(TDto entity);
    public Task<IEnumerable<TDto>> GetAll(int? take, int? skip);
    public Task<TDto> GetById(TId id);
}