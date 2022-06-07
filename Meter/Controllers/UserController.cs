using Meter.Dtos;
using Meter.Repositories;
using Meter.Requests.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Meter.Controllers;

[Route("users")]
[Authorize]
public class UserController : Controller
{
    private readonly UserRepository _userRepository;
    public UserController(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [Route("")]
    [HttpGet]
    public Task<IEnumerable<UserDto>> Index()
    {
        return _userRepository.All();
    }

    [Route("{id}")]
    [HttpPatch]
    public async Task<IActionResult> Update(int id, [FromBody]UserUpdateRequest request)    // TODO
    {
        throw new NotImplementedException();
        
        // if (await _userRepository.Find(id) == null)
        // {
        //     return NotFound();
        // }
        //
        // return Json(await _userRepository.Update(id, request));
    }

    [Route("{id}")]
    [HttpGet]
    public async Task<IActionResult> Show(int id)    // TODO: 404 on null
    {
        var user = await _userRepository.Find(id);

        if (user == null)
        {
            return NotFound();
        }

        return Json(user);
    }
}