using API.Authorization;
using API.Models;
using API.UserService;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet, Authorize]
    public ActionResult<UserResponse> GetMe()
    {
        var myUser = _userService.GetMyUser();
        return Ok(myUser);
    }

    [HttpPost("login")]
    public ActionResult<UserResponseWithToken> Login(UserLoginRequest userLoginRequest)
    {
        return Ok(_userService.Authenticate(userLoginRequest));
    }
}