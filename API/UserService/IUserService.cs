using API.Entities;
using API.Models;

namespace API.UserService;

public interface IUserService
{
    UserResponse GetMyUser();
    UserResponseWithToken Authenticate(UserLoginRequest userLoginRequest);

    User GetUserById(int id);
}