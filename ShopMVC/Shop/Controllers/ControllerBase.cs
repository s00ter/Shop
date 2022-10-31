using BLL.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Shop.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public abstract class ControllerBase<TDto, TId, TService> : ControllerBase
    where TDto : class
    where TService : IServiceBase<TDto, TId>
{
    protected TService Service;

    protected ControllerBase(TService service)
    {
        Service = service;
    }

    [HttpGet("GetById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<TDto>> GetById(TId id)
    {
        var result = await Service.GetById(id);

        return Ok(result);
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<TDto>>> GetById(int? take, int? skip)
    {
        var result = await Service.GetAll(take, skip);

        return Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<TDto>> Create(TDto model)
    {
        var createdEntity = await Service.Create(model);

        return Created(string.Empty, createdEntity);
    }
    
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<TDto>> Update(TDto model)
    {
        var updatedEntity = await Service.Update(model);

        return Ok(updatedEntity);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Delete(TId id)
    {
        var entityToDelete = await Service.GetById(id);
        await Service.Delete(entityToDelete);

        return NoContent();
    }
}