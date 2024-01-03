using Microsoft.AspNetCore.Components.Web;
using WebAPI.Models;

namespace WebAPI.Interfaces
{
    public interface ITicketsRepository
    {
        ICollection<Tickets> GetTickets();

        Tickets GetUserByTicketId(int id);
        
        string GetDescriptionByTicketId(int ticketId);

        bool TicketExists(int ticketId);

        bool CreateTicket(Tickets tickets);

        bool Save();
    }
}
