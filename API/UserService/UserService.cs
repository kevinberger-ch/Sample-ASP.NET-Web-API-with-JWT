using API.Authorization;
using API.Entities;
using API.Models;

namespace API.UserService;

public class UserService : IUserService
{
    // TODO: this is just for demo, you must obviously save the user in your database
    private static readonly User dbUser = new User() { UserId = 1, Username = "test"};
    
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IJwtUtils _jwtUtils;


    public UserService(IHttpContextAccessor httpContextAccessor, IJwtUtils jwtUtils)
    {
        _httpContextAccessor = httpContextAccessor;
        _jwtUtils = jwtUtils;
    }

    public UserResponse GetMyUser()
    {
        var user = (User)_httpContextAccessor.HttpContext!.Items["User"]!;
        return new UserResponse(user.Username);
    }

    // because the jwt token is not saved in the database, the token is only returned by login
    // but you could save the token in the database, check for it an also return for example in GetMyUser();
    public UserResponseWithToken Authenticate(UserLoginRequest userLoginRequest)
    {
        // TODO: Replace dbUser with the user from your db (you can get over the userLoginRequest)

        // TODO: Validate username & password and return response when incorrect

        // if authentication successful
        var token = _jwtUtils.GenerateToken(dbUser);
        return new UserResponseWithToken(dbUser.Username, token);
    }

    public User GetUserById(int id)
    {
        // TODO: Replace dbUser with the user from your db (you can get over the id)
        return dbUser;
    }
}