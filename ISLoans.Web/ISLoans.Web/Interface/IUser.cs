using ISLoans.Web.Models;
using System.Threading.Tasks;

namespace ISLoans.Web.Interface
{
    public interface IUser
    {
        Task<Users> FindByNameAsync(string username);
        Task<Users> CreateAsync(Users user);
        Task<long> Post(Users user);
        Task<bool> PutUpdateAsync(Users user);
        Task<Users> FindByIdAsync(int userId);
        Task<Users> CheckIfEmailExist(string email);
    }
}
