
using blogPessoal.Model;
using blogPessoal.Repository;
using blogPessoal.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public async Task<ActionResult<dynamic>> Login([FromBody] User model)
        {
           
                var user = _userRepository.GetUserName(model.Usuario, model.Senha);
                if (user.Result == null)
                    return Unauthorized(new { message = "Usuário ou senha inválidos" });
                else
                {
                    var userResult = new User { Id = user.Result.Id, Nome = user.Result.Nome, Usuario = user.Result.Usuario, Senha = "", Role = user.Result.Role };

                    var token = TokenService.GenerateToken(userResult);
                    return new
                    {
                        user = userResult,
                        token = "Bearer "+token
                    };
                }
            }


        [HttpPost]
        [Route("cadastrar")]
        [AllowAnonymous]
        public async Task<ActionResult<User>> Cadastrar([FromBody] User user)
        {
   
                await _userRepository.Create(user);
                return Created("/api/User/cadastrar", user);
               
        }

    }

}
