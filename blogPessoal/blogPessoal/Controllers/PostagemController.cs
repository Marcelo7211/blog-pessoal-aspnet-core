
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
        public async Task<IEnumerable<Postagem>> GetPostagens()
        {
            return await _postagemRepository.Get();
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Postagem>> GetPostagens(int id)
        {
            return await _postagemRepository.Get(id);
        }

        [HttpGet("titulo/{titulo}")]
        [Authorize]
        public async Task<IEnumerable<Postagem>> GetTituloPostagens(string titulo)
        {
            return await _postagemRepository.GetTitulo(titulo);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Postagem>> PostPostagens([FromBody] Postagem postagem)
        {
            var newPostagem = await _postagemRepository.Create(postagem);
            return CreatedAtAction(nameof(GetPostagens), new { id = newPostagem.Id }, newPostagem);
        }


        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            var postagemToDelete = await _postagemRepository.Get(id);

            if (postagemToDelete == null)
                return NotFound();

            await _postagemRepository.Delete(postagemToDelete.Id);
            return NoContent();


        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<Postagem>> PutPostagens([FromBody] Postagem postagem)
        {
            if (postagem.Id <= 0)
                return BadRequest();

            var postagemResult = await _postagemRepository.Update(postagem);

            return postagemResult;
        }
    }
}
