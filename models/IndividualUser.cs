using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace kredibu_server.Data;


public class IndividualUser
{
    public IndividualUser(){
        Id= Guid.NewGuid();
    }
    public Guid Id { get; init; }
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
    // public required BusinessUser BusinessUser { get; init; }

}







// public class IndividualUser
// {
//     public required string name { get; init; }
//     public required string password { get; init; }
//     public required string email { get; init; }
//     public required string phoneNumber { get; init; }
//     public required string address { get; init; }
//     public required string gender { get; init; }
//     public required DateTime dob { get; init; }
//     public required string occupation { get; init; }
//     public required string state { get; init; }
//     public required string country { get; init; }


// }