using WebAPI.Models;

namespace WebAPI.Interfaces
{
    public interface IUserRepository 
    {
        ICollection<User> GetUsers();

    }
}
