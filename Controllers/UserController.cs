using Microsoft.AspNetCore.Mvc;

namespace kredibu_server.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{

    static private List<string> users = new List<string>
{
    "user1",
    "user2",
    "user3",
    "David","Daniel","Afobaje",
};



    [HttpGet]

    public ActionResult<List<string>> Get()
    {
        users.Add("Stephen");
        WriteLine($"{nameof(Get)} gave us this");
        return users;
        // return Ok(users);
    }


    [HttpGet("{id}")]
    public ActionResult<string> Get(int id){
        var user=users[id];
        return user;
        // return CreatedAtAction(nameof(Get),new{id,user});
    }
}