using kredibu_server;
using kredibu_server.Data;

public interface IAuthRepository
{
    Task<IndividualUser> RegisterIndividualUser(IndividualUser user);
    Task<BusinessUser> RegisterBusinessUser(BusinessUser user);
    Task<IndividualUser?> LoginIndividualUser(string username, string password);
    Task<BusinessUser?> LoginBusinessUser(string username, string password);
}

