using WebAPI.Enum;

namespace WebAPI.Models
{
    public class Client
    {
        public int Id { get; set; }
        public Company Name { get; set; }
        public bool HoursPackage { get; set; }

        public Country? Country { get; set; }

        public ICollection<User>? Responsibles { get; set; }

    }
}
