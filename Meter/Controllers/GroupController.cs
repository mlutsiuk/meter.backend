using System.Security.Claims;
using Meter.Dtos;
using Meter.Repositories;
using Meter.Requests.Group;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meter.Controllers;

[Route("groups")]
[Authorize]
public class GroupController : Controller
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
        string userIdString = User.Claims
            .ToList()
            .First(x => x.Type.Equals(ClaimTypes.Name))
            .Value;
        int userId = int.Parse(userIdString);
        
        return await _groupRepository.Create(request, userId);
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