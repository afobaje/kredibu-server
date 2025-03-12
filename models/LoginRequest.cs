namespace kredibu_server.Models;



public class LoginRequestDTO
{
    public required string email { get; init; }
    public required string password { get; init; }
}