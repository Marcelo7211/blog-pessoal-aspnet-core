using blogPessoal.Model;
using blogPessoal.Repository;
using blogPessoal.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace blogPessoal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;


        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public ActionResult<dynamic> Login([FromBody] User model)
        {

            var user = _userRepository.GetUserName(model.Usuario, model.Senha);
            if (user == null)
                return Unauthorized(new { message = "Usuário ou senha inválidos" });
            else
            {
                var userResult = new User { Id = user.Id, Nome = user.Nome, Usuario = user.Usuario, Senha = "" };

                var token = TokenService.GenerateToken(userResult);
                return new
                {
                    user = userResult,
                    token = "Bearer " + token
                };
            }
        }


        [HttpPost]
        [Route("cadastrar")]
        [AllowAnonymous]
        public async Task<ActionResult<User>> Cadastrar([FromBody] User user)
        {

            var newBook = await _userRepository.CreateUser(user);
            return newBook;

        }

    }

}