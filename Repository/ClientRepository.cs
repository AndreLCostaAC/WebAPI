

using Microsoft.EntityFrameworkCore.Diagnostics;
using WebAPI.Data;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataContext _context;

        public ClientRepository(DataContext context)
        {
            _context = context;
        }
        public bool ClientExists(int clientId)
        {
            return _context.Clients.Any(c => c.Id  == clientId);
        }

        public Client GetClient(int clientId)
        {
            return _context.Clients.Where(c => c.Id == clientId).FirstOrDefault();
        }

        public ICollection<Client> GetClients()
        {
            return _context.Clients.OrderBy(c => c.Id).ToList();
        }

        public bool HasClientHoursPackage(int cliendId)
        {
            return _context.Clients.Any(c => c.Id == cliendId && c.HoursPackage);
        }

        public bool CreateClient(Client client)
        {
            // change tracker
            // add, updating, modifying
            // connected ou disconnected
            //EntityState.Added
            _context.Clients.Add(client);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateClient(Client client)
        {
            _context.Update(client);
            return Save();
        }

        public bool DeleteClient(Client client)
        {
            _context.Remove(client);
            return Save();
        }
    }
}
