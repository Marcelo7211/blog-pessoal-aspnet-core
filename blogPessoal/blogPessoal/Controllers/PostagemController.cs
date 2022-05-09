using blogPessoal.Model;
using blogPessoal.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace blogPessoal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostagemController : ControllerBase
    {

        private readonly IPostagemRepository _postagemRepository;

        public PostagemController(IPostagemRepository postagemRepository)
        {
            _postagemRepository = postagemRepository;
        }

        [HttpGet]
        [Authorize]
        public List<Postagem> GetAllPostagens()
        {
            return _postagemRepository.GetAll();
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Postagem>> GetByIdPostagem(int id)
        {
            var postagem = await _postagemRepository.GetById(id);
            if (postagem == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(postagem);
            }
        }

        [HttpGet("titulo/{titulo}")]
        [Authorize]
        public List<Postagem> GetByTituloPostagem(string titulo)
        {
            return _postagemRepository.GetTitulo(titulo);
        }

        [HttpPost]
        public async Task<ActionResult<Tema>> PostPostagem([FromBody] Postagem postagem)
        {
            var newPostagem = await _postagemRepository.Create(postagem);
            return Ok(newPostagem);
        }


        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeletePostagem(int id)
        {
            var postagemToDelete = await _postagemRepository.GetById(id);

            if (postagemToDelete == null)
                return NotFound();

            await _postagemRepository.Delete(postagemToDelete.Id);
            return NoContent();


        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<Postagem>> PutPostagem([FromBody] Postagem postagem)
        {
            if (postagem.Id <= 0)
                return BadRequest();

            var postagemResult = await _postagemRepository.Update(postagem);

            return Ok(postagemResult);
        }
    }
}