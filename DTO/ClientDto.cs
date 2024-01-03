using WebAPI.Enum;
using WebAPI.Models;

namespace WebAPI.DTO
{
    public class ClientDto
    {
        public int Id { get; set; }
        public bool HoursPackage { get; set; }

        public Company Company { get; set; }

    }
}
