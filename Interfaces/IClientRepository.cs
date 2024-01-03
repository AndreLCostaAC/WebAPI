using WebAPI.Models;

namespace WebAPI.Interfaces
{
    public interface IClientRepository
    {
        ICollection<Client> GetClients();

        Client GetClient(int clientId);

        bool HasClientHoursPackage(int cliendId);

        bool ClientExists(int clientId);

        bool CreateClient(Client client);

        bool UpdateClient(Client client);
        bool Save();

        bool DeleteClient(Client client);

    }
}
