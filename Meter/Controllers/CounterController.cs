using Meter.Dtos;
using Meter.Repositories;
using Meter.Requests.Counter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meter.Controllers;

[Route("counters")]
[Authorize]
public class CounterController
{
    private readonly CounterRepository _counterRepository;

    public CounterController(CounterRepository counterRepository)
    {
        _counterRepository = counterRepository;
    }
    
    [Route("")]
    [HttpGet]
    public async Task<IEnumerable<CounterDto>> Index()
    {
        return await _counterRepository.All();
    }

    [Route("{id}")]
    [HttpGet]
    public async Task<CounterDto> Show(int id)
    {
        return await _counterRepository.Find(id);
    }

    [Route("")]
    [HttpPost]
    public async Task<CounterDto> Store([FromBody] CounterCreateRequest request)
    {
        return await _counterRepository.Create(request);
    }

    [Route("{id}")]
    [HttpPatch]
    public async Task<CounterDto> Update(int id, [FromBody] CounterUpdateRequest request)
    {
        return await _counterRepository.Edit(id, request);
    }
    
    [Route("{id}")]
    [HttpDelete]
    public async Task Destroy(int id)
    {
        await _counterRepository.Delete(id);
    }
}