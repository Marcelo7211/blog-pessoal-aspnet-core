using blogPessoal.Data;
using blogPessoal.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blogPessoal.Repository
{
    public  class UserRepository: IUserRepository
    {
        public readonly Data.AppContext _context;

        public UserRepository(AppContext context)
        {
            _context = context;
        }

        public User Create(User user)
        {
            User aux =  _context.Users.FirstOrDefaultAsync(c => c.Id.Equals(user.Id)).Result;
            if (aux != null)
                return aux;

            _context.Users.Add(user);
             _context.SaveChangesAsync();

            return user;
        }

        public User CreateUser(User user)
        {
            var userResult = _context.Users.Where(u => u.Usuario == user.Usuario).FirstOrDefaultAsync();
            if (userResult.Result != null)
            {
                return null;
            }
            else
            {
                var valueBytes = Encoding.UTF8.GetBytes(user.Senha);
                user.Senha = System.Convert.ToBase64String(valueBytes);
                _context.Users.Add(user);
                _context.SaveChangesAsync();

                return user;
            }
           
        }

        public User GetUserName(string usuario, string senha)
        {
            
            Task<User> UserReturn = _context.Users.Where(u => u.Usuario == usuario).FirstOrDefaultAsync();
            var valueBytes = System.Convert.FromBase64String(UserReturn.Result.Senha);
            string passwordDecode = Encoding.UTF8.GetString(valueBytes);
            if ( passwordDecode == senha)
            {
                return  UserReturn.Result;
            }
            else
            {
                return null;
            }

            

        }
    }
}
