using System.Collections.Concurrent;
using kredibu_server.Data;


namespace kredibu_server.Repositories;

public class AuthServices:IAuthRepository
{
    private readonly UserDbContext _userdb;
    private static ConcurrentDictionary<string, IndividualUser> _users = new ConcurrentDictionary<string, IndividualUser>();    

    public AuthServices(UserDbContext AuthUserdb)
    {
        _userdb = AuthUserdb;
    }

    public bool EnsureDbCreated()
    {
        WriteLine("User db is created");
        return _userdb.Database.EnsureCreated();
    }



    public async Task<IndividualUser> RegisterIndividualUser(IndividualUser user)
    {
          user.password = Utils.HashPassword(user.password);
        await _userdb.AddAsync(user);
        await _userdb.SaveChangesAsync();
        return user;
    }

    public async Task<BusinessUser> RegisterBusinessUser(BusinessUser user)
    {
          user.password = Utils.HashPassword(user.password);
        await _userdb.AddAsync(user);
        await _userdb.SaveChangesAsync();
        return user;
        // throw new NotImplementedException();
    }

    public async Task<IndividualUser?> LoginIndividualUser(string username, string password)
    {
        var user=await _userdb.FindAsync<IndividualUser>(username);
        // var user=await _userdb.IndividualUsers.FirstOrDefaultAsync(x=>x.Username==username && x.Password==password);
        // throw new NotImplementedException();
        if (user is null)
        {
            return null;
            
        }
        return user;
    }

    public async Task<BusinessUser?> LoginBusinessUser(string username, string password)
    {
        var user=await _userdb.FindAsync<BusinessUser>(username);
        if (user is null)
        {
            return null;
        }
        return user;
        // throw new NotImplementedException();
    }

}