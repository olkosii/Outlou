using Microsoft.EntityFrameworkCore;
using Outlou.DataModels;
using System.Threading.Tasks;

namespace Outlou.Reposetories
{
    public class SqlUserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;
        public SqlUserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<User> Register(User user)
        {
            var createdUser = await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();

            return createdUser.Entity;
        }

        public async Task<User> LogIn(User userRequest)
        {
            var user = await _context.Users.
                    FirstOrDefaultAsync(u => u.UserEmail == userRequest.UserEmail && u.UserPassword == userRequest.UserPassword);

            if (user != null)
                return user;

            return null;
        }
    }
}
