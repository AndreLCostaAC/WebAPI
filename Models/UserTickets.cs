namespace WebAPI.Models
{
    public class UserTickets
    {
        public int UserId { get; set; }
        public int TicketId { get; set; }

        public User User { get; set; }
        public Tickets Tickets { get; set; }

    }
}
