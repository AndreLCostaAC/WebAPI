using WebAPI.Enum;
using WebAPI.Models;

namespace WebAPI.Interfaces
{
    public interface IUserRepository 
    {
        ICollection<User> GetUsers();

        User GetUser(int id);
        User GetUser(string name);

        User GetUserDkx(string dkx);

        User GetUserEmail(string email);

        User GetUserJob(JobPosition job);

        User GetUserCompany(Company company);

        bool UserExists(int userId);

        bool CreateUser(User user);

        bool Save();
    }
}
