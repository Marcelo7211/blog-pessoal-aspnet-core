using blogPessoal.Model;
using System.Threading.Tasks;

namespace blogPessoal.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUserName(string usuario, string senha);


        Task<User> Create(User user);
    }
}
