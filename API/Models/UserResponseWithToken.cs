namespace API.Models;

public class UserResponseWithToken : UserResponse
{
    public UserResponseWithToken(string username, string token) : base(username)
    {
        Username = username;
        Token = token;
    }

    public string Token { get; set; }
}