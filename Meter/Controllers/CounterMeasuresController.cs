using Meter.Dtos;
using Meter.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meter.Controllers;

[Authorize]
public class CounterMeasuresController : Controller
{
    private readonly MeasureRepository _measureRepository;

    public CounterMeasuresController(MeasureRepository measureRepository)
    {
        _measureRepository = measureRepository;
    }

    [Route("counters/{id}/measures")]
    [HttpGet]
    public async Task<IEnumerable<MeasureDto>> Index(int id)
    {
        return await _measureRepository.FindByCounterId(id);
    }
}