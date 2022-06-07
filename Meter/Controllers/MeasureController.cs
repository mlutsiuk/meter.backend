using Meter.Dtos;
using Meter.Repositories;
using Meter.Requests.Measure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meter.Controllers;

[Route("measures")]
[Authorize]
public class MeasureController
{
    private readonly MeasureRepository _measureRepository;

    public MeasureController(MeasureRepository measureRepository)
    {
        _measureRepository = measureRepository;
    }
    
    [Route("")]
    [HttpGet]
    public async Task<IEnumerable<MeasureDto>> Index()
    {
        return await _measureRepository.All();
    }

    [Route("{id}")]
    [HttpGet]
    public async Task<MeasureDto> Show(int id)
    {
        return await _measureRepository.Find(id);
    }

    [Route("")]
    [HttpPost]
    public async Task<MeasureDto> Store([FromBody] MeasureCreateRequest request)
    {
        return await _measureRepository.Create(request);
    }

    [Route("{id}")]
    [HttpPatch]
    public async Task<MeasureDto> Update(int id, [FromBody] MeasureUpdateRequest request)
    {
        return await _measureRepository.Edit(id, request);
    }
    
    [Route("{id}")]
    [HttpDelete]
    public async Task Destroy(int id)
    {
        await _measureRepository.Delete(id);
    }
}