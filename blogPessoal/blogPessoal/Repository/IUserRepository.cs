using blogPessoal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogPessoal.Repository
{
    public interface IUserRepository
    {
        User GetUserName(string usuario, string senha);


        User CreateUser(User user);

        User Create(User user);
    }
}