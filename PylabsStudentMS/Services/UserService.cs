using Microsoft.EntityFrameworkCore;
using PylabsStudentMS.Data;
using PylabsStudentMS.Entity;
using PylabsStudentMS.Services.IService;
using System.Linq.Expressions;

namespace PylabsStudentMS.Services
{
    public class UserService : IUserService
    {
        private readonly ApiContext _context;
        public UserService(IConfiguration configuration)
        {
            _context = new ApiContext(configuration);
        }
        public User Add(User entity)
        {
            var oldUser = Get(x => x.UserName == entity.UserName);
            if (oldUser != null)
            {
                return null;
            }
            var response = _context.Add(entity);
            Save();
            return response.Entity;
        }

        public void Delete(int id)
        {
            var user = _context.User.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                _context.User.Remove(user);
                Save();
            }
        }

        public void Delete(User entity)
        {
            _context.User.Remove(entity);
            Save();
        }

        public List<User> Get(Expression<Func<User, bool>> exp = null)
        {
            List<User> users;
            if (exp != null)

            {
                users = _context.User.Where(exp).ToList();
            }
            else
            {
                users = _context.User.ToList();
            }
            return users;
        }

        public User Get(int id)
        {
            return _context.User.FirstOrDefault(x => x.Id == id);
        }

        public void Update(User entity)
        {
            _context.User.Add(entity);
            _context.Entry(entity).State = EntityState.Modified;
            Save();
        }
        public User? Authenticate(string userName, string password)
        {
            var user = _context.User.FirstOrDefault(x => x.UserName == userName && x.Password == password);
            if (user == null)
            {
                return null;
            }
            return user;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
