namespace kredibu_server.Data;


public class IndividualUser
{
    // public IndividualUser(){
    //     Id= Guid.NewGuid();
    //     rating=new List<Rating>();
    // }
    public Guid Id { get; init; } = Guid.NewGuid();
    public required string firstName { get; init; }
    public required string lastName { get; init; }
    public required string password { get; set; }
    public required string email { get; init; }
    public required string phone { get; init; }
    public required string address { get; init; }
    public required string gender { get; init; }
    public required string dob { get; init; }
    public required string occupation { get; init; }
    public required string state { get; init; }
    public required string country { get; init; }
    // public required List<Rating> rating { get; init; } = new List<Rating>();
}







