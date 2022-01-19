using blogPessoal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogPessoal.Repository
{
    public interface IUserRepository
    {
        Task<User> GetUserName(string usuario, string senha);


        Task<User> CreateUser(User user);

        Task<User> Create(User user);
    }
}
