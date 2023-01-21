using Outlou.DataModels;
using System.Threading.Tasks;

namespace Outlou.Reposetories
{
    public interface IUserRepository
    {
        Task<User> Register(User user);
        Task<User> LogIn(User userRequest);
    }
}
