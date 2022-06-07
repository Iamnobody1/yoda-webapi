using Microsoft.AspNetCore.Mvc;
using Yoda.Services.Services.User;

namespace Yoda.Services.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService UserService;

    public UsersController(IUserService userService)
    {
        UserService = userService;
    }

    [HttpGet("{userId}")]
    public IActionResult Get([FromRoute] Guid userId)
    {
        var result = UserService.GetUserById(userId);
        if (result == null)
            return NotFound();
        return Ok(result);
    }
}
