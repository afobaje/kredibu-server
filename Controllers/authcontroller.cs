using kredibu_server.Data;
using kredibu_server.Models;
using Microsoft.AspNetCore.Mvc;



[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{

    private readonly IHttpClientFactory _clientFactory;
    private IAuthRepository _repo;
    public AuthController(IAuthRepository context, IHttpClientFactory httpClientFactory)
    {
        _clientFactory = httpClientFactory;
        _repo = context;

    }


    [HttpPost("register/individual")]
    public async Task<IActionResult> CreateIndividualUser([FromBody] IndividualUser user)
    {
        if (user == null)
        {
            return BadRequest();
        }
      
        var newIndividualUser = await _repo.RegisterIndividualUser(user);
        return CreatedAtAction(nameof(CreateIndividualUser), new { newIndividualUser });
    }


    [HttpPost("register/business")]
    public async Task<IActionResult> CreateBusinessUser([FromBody] BusinessUser user)
    {
        if (user == null)
        {
            return BadRequest();
        }
        var newBusinessUser = await _repo.RegisterBusinessUser(user);
        return CreatedAtAction(nameof(CreateBusinessUser), new { newBusinessUser });
    }

    [HttpPost("login/individual")]
    public async Task<ActionResult> LoginIndividual([FromBody] LoginRequestDTO user)
    {

        var UserExist = await _repo.LoginIndividualUser(user.email, user.password);
        if (UserExist is null)
        {
            return NotFound("User not found");
        }
        return Ok(UserExist);
    }


    [HttpPost("login/business")]
    public async Task<ActionResult> LoginBusiness([FromBody] LoginRequestDTO user)
    {
        var UserExist = await _repo.LoginBusinessUser(user.email, user.password);
        if (UserExist is null)
        {
            return NotFound("User not found");
        }
        return Ok(UserExist);

    }


}