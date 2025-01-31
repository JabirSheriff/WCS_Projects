using ClinicAPI.Contexts;
using ClinicAPI.Exceptions;
using ClinicAPI.Models;

namespace ClinicAPI.Repositories
{
    public class UserRepository : Repository<string, User>
    {
        public UserRepository(ClinicContext context) : base(context)
        {
        }
        public async override Task<User> Get(string key)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == key);
            if (user == null)
            {
                throw new EntityNotFoundException("User not found");
            }
            return user;
        }

        public async override Task<IEnumerable<User>> GetAll()
        {
            var users = _context.Users.ToList();
            if (users.Count == 0)
            {
                throw new NoEntitiesFoundException("No users found in database");
            }
            return users;
        }
    }
}
