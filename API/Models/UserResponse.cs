namespace API.Models;

public class UserResponse
{
    public UserResponse(string username)
    {
        Username = username;
    }

    public string Username { get; set; }
}