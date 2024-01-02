using WebAPI.Enum;

namespace WebAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }   
        public string? Email { get; set; }

        public JobPosition JobPosition { get; set; }
        public string? DKX { get; set; }
        public Company Company { get; set; }

        public Country? Country { get; set; }

        public ICollection<UserTickets>? UserTickets { get; set; }



    }
}
