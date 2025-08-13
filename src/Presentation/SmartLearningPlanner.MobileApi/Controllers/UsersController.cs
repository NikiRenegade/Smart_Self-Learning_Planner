using Microsoft.AspNetCore.Mvc;
using SmartLearningPlanner.Application.DTOs;
using SmartLearningPlanner.Application.Interfaces;

namespace SmartLearningPlanner.MobileApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto>> GetUser(string id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        if (user == null) return NotFound();

        return Ok(user);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
    {
        var users = await _userService.GetAllUsersAsync();

        return Ok(users);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateUser(string id, UserDto userDto)
    {
        if (id != userDto.Id) return BadRequest();
        await _userService.UpdateUserAsync(userDto);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUser(string id)
    {
        await _userService.DeleteUserAsync(id);

        return NoContent();
    }
}
//24602593-5cfb-4733-9ff2-c5e2dbb4191a
//123456789azAZ!