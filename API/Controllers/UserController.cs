using API.Authorization;
using API.Models;
using API.UserService;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public ActionResult<UserResponse> GetMe()
    {
        var myUser = _userService.GetMyUser();
        return Ok(myUser);
    }

    [HttpPost("login"), AllowAnonymous]
    public ActionResult<UserResponseWithToken> Login(UserLoginRequest userLoginRequest)
    {
        return Ok(_userService.Authenticate(userLoginRequest));
    }
}