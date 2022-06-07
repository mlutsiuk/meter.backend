using Meter.Dtos;
using Meter.Repositories;
using Meter.Requests.Icon;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meter.Controllers;

[Route("icons")]
[Authorize]
public class IconController
{
    private readonly IconRepository _iconRepository;

    public IconController(IconRepository iconRepository)
    {
        _iconRepository = iconRepository;
    }
    
    [Route("")]
    [HttpGet]
    public async Task<IEnumerable<IconDto>> Index()
    {
        return await _iconRepository.All();
    }

    [Route("{id}")]
    [HttpGet]
    public async Task<IconDto> Show(int id)
    {
        return await _iconRepository.Find(id);
    }

    [Route("")]
    [HttpPost]
    public async Task<IconDto> Store([FromBody] IconCreateRequest request)
    {
        return await _iconRepository.Create(request);
    }

    [Route("{id}")]
    [HttpPatch]
    public async Task<IconDto> Update(int id, [FromBody] IconUpdateRequest request)
    {
        return await _iconRepository.Edit(id, request);
    }
    
    [Route("{id}")]
    [HttpDelete]
    public async Task Destroy(int id)
    {
        await _iconRepository.Delete(id);
    }
}