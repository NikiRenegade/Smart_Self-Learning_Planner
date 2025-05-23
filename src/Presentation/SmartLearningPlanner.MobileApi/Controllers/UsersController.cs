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

    [HttpPost("register")]
    public async Task<ActionResult> RegisterUser(RegisterUserDto registerUserDto)
    {
        await _userService.CreateUserAsync(registerUserDto);
        return NoContent();
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

    [HttpPost("change-password")]
    public async Task<ActionResult> ChangePassword(ChangePasswordDto changePasswordDto)
    {
        await _userService.ChangeUserPasswordAsync(changePasswordDto.Id, changePasswordDto.CurrentPassword, changePasswordDto.NewPassword);
        return NoContent();
    }
    [HttpGet("check-password")]
    public async Task<ActionResult> CheckPassword(string id, string password)
    {
        var result = await _userService.CheckUserPasswordAsync(id, password);
        return Ok(result);
    }
    [HttpGet("confirm-email")]
    public async Task<IActionResult> ConfirmEmail([FromQuery] string id, [FromQuery] string token)
    {
        await _userService.ConfirmUserEmailAsync(id, token);
        return Ok("Email успешно подтвержден!");
    }
}
//24602593-5cfb-4733-9ff2-c5e2dbb4191a
//123456789azAZ!