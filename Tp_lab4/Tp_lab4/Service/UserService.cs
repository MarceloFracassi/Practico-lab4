using Practico_labIV.dbContext;
using Tp_lab4.Entities;

namespace Tp_lab4.Service
{
    public class UserService
    {
        private readonly DbContextPractico _context;

        public UserService(DbContextPractico context)
        {
            _context = context;
        }

        public User GetUserById(int Id)
        {
            return _context.Users.FirstOrDefault(p => p.Id == Id);
        }

        public int CreateUser(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
            return user.Id;
        }

        public void DeleteUser(User user)
        {
            _context.Remove(user);
            _context.SaveChanges();
        }
    }
}
