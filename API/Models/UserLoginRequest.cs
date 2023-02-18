namespace API.Models;

public class UserLoginRequest
{
    public UserLoginRequest(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public string Email { get; set; }

    public string Password { get; set; }
}