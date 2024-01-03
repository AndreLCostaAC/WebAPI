using WebAPI.Data;
using WebAPI.Interfaces;
using WebAPI.Models;

namespace WebAPI.Repository
{
    public class TicketsRepository : ITicketsRepository
    {
        private readonly DataContext _context;

        public TicketsRepository(DataContext context)
        {
            _context = context;
        }

        public Tickets GetUserByTicketId(int id)
        {
            return _context.Tickets.Where(t => t.Id == id).FirstOrDefault();
        }

        public ICollection<Tickets> GetTickets()
        {
            return _context.Tickets.ToList();
        }

        public bool TicketExists(int ticketId)
        {
            return _context.Tickets.Any(t => t.Id == ticketId);
        }

        public string GetDescriptionByTicketId(int ticketId)
        {
            var desc = _context.Tickets.Where(t => t.Id == ticketId).Select(d => d.Description).FirstOrDefault();
            return desc;
        }

        public bool CreateTicket(Tickets tickets)
        {
            _context.Tickets.Add(tickets);
            return Save();

        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
