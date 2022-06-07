using Meter.Dtos;
using Meter.Repositories;
using Meter.Requests.Group;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meter.Controllers;

[Route("groups")]
[Authorize]
public class GroupController
{
    private readonly GroupRepository _groupRepository;

    public GroupController(GroupRepository groupRepository)    // TODO: Add checks
    {
        _groupRepository = groupRepository;
    }

    [Route("")]
    [HttpGet]
    public async Task<IEnumerable<GroupDto>> Index()
    {
        return await _groupRepository.All();
    }

    [Route("{id}")]
    [HttpGet]
    public async Task<GroupDto> Show(int id)
    {
        return await _groupRepository.Find(id);
    }

    [Route("")]
    [HttpPost]
    public async Task<GroupDto> Store([FromBody] GroupCreateRequest request)
    {
        return await _groupRepository.Create(request);
    }

    [Route("{id}")]
    [HttpPatch]
    public async Task<GroupDto> Update(int id, [FromBody] GroupUpdateRequest request)
    {
        return await _groupRepository.Edit(id, request);
    }
    
    [Route("{id}")]
    [HttpDelete]
    public async Task Destroy(int id)
    {
        await _groupRepository.Delete(id);
    }
}