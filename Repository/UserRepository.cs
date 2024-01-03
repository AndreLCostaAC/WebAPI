using WebAPI.Data;
using WebAPI.Enum;
using WebAPI.Interfaces;
using WebAPI.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WebAPI.Repository
{
    public class UserRepository : IUserRepository
    { 
        private readonly DataContext _context;

        public UserRepository(DataContext context) 
        {
            _context = context;
        }

        public bool CreateUser(User user)
        {
            _context.Users.Add(user);
            return Save();
        }

        public User GetUser(int id)
        {
            return _context.Users.Where(x => x.Id == id).FirstOrDefault();
        }

        public User GetUser(string name)
        {
            return _context.Users.Where(x => x.Name == name).FirstOrDefault();
        }

        public User GetUserCompany(Company company)
        {
            return _context.Users.Where(x => x.Company == company).FirstOrDefault();
        }

        public User GetUserDkx(string dkx)
        {
            return _context.Users.Where(x => x.DKX == dkx).FirstOrDefault();
        }

        public User GetUserEmail(string email)
        {
            return _context.Users.Where(x => x.Email == email).FirstOrDefault();
        }

        public User GetUserJob(JobPosition job)
        {
            return _context.Users.Where(x => x.JobPosition == job).FirstOrDefault();
        }

        public ICollection<User> GetUsers()
        {
            return _context.Users.OrderBy(x => x.Id).ToList();

        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UserExists(int userId)
        {
            return _context.Users.Any(x => x.Id == userId);
        }
    }
}
