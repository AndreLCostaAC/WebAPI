using WebAPI.Enum;
using WebAPI.Models;

namespace WebAPI.DTO
{
    public class TicketsDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public User? Creator { get; set; }
        public ICollection<UserTickets>? UserTickets { get; set; }

    }
}
