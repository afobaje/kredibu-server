using System.ComponentModel.DataAnnotations;

namespace kredibu_server.Data;


public class BusinessUser
{
    public BusinessUser(){
        Id = Guid.NewGuid();
    }

    public Guid Id { get; init; }
    public required Guid ownerId { get; init; }
    public required string CAC { get; init; }
    public required string companyName { get; init; }
    public required string password{ get; set; }
    public required string email { get; init; }
    public required string phoneNumber { get; init; }
    public required string address { get; init; }
    
    
    public required string established { get; init; }
    
    public required string state { get; init; }
    public required string country { get; init; }


}