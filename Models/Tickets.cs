using WebAPI.Enum;

namespace WebAPI.Models
{
    public class Tickets
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<User>? Responsibles { get; set; }
        public User? Creator { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; } = DateTime.Now;
        public Client? Organization { get; set; }

        public RequestType RequestType { get; set; }

        public string? Description { get; set; }
        public ICollection<UserTickets>? UserTickets { get; set; }


    }
}
