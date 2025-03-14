namespace kredibu_server.Data;

public class Rating
{
    public Guid Id=Guid.NewGuid();
    public string? comment {get;set;}
    public int score{get;set;}
    public Guid ownerId{get;set;}
}