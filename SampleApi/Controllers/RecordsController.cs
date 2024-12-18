using Microsoft.AspNetCore.Mvc;
using SampleApi.Data.Entities;
using SampleApi.Data.Interfaces;

namespace SampleApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecordsController : ControllerBase
{
    private readonly IRecordsRepository _repository;

    public RecordsController(IRecordsRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() => Ok(await _repository.GetAll());

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await _repository.Get(id);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Record record) => Ok(await _repository.Create(record));

    [HttpPut]
    public async Task<IActionResult> Update(Record record)
    {
        var result = await _repository.Update(record);
        return result == null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var isDeleted = await _repository.Delete(id);
        return !isDeleted ? NotFound() : Ok();
    }
}