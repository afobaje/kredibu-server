namespace kredibu_server.Data;


public class BusinessUser
{
   
    public Guid Id { get; init; } = Guid.NewGuid();
    public required Guid ownerId { get; init; }
    // public List<Guid> owners {get;init;}
    public required string CAC { get; init; }
    public required string companyName { get; init; }
    public required string password { get; set; }
    public required string email { get; init; }
    public required string phoneNumber { get; init; }
    public required string address { get; init; }
    public required string established { get; init; }
    public required string state { get; init; }
    public required string country { get; init; }
    public required List<Rating> rating { get; init; } = new List<Rating>();
}