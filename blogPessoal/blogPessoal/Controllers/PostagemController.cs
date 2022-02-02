using blogPessoal.Model;
using blogPessoal.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public List<Postagem> GetPostagens()
        {
            return _postagemRepository.GetAll();
        }

        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<Postagem> GetPostagens(int id)
        {
            return _postagemRepository.Get(id);
        }

        [HttpGet("titulo/{titulo}")]
        [Authorize]
        public List<Postagem> GetTituloPostagens(string titulo)
        {
            return _postagemRepository.GetTitulo(titulo);
        }

        [HttpPost]
        [Authorize]
        public ActionResult<Postagem> PostPostagens([FromBody] Postagem postagem)
        {
            var newPostagem = _postagemRepository.Create(postagem);
            return CreatedAtAction(nameof(GetPostagens), new { id = newPostagem.Id }, newPostagem);
        }


        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult Delete(int id)
        {
            var postagemToDelete = _postagemRepository.Get(id);

            if (postagemToDelete == null)
                return NotFound();

            _postagemRepository.Delete(postagemToDelete.Id);
            return NoContent();


        }

        [HttpPut]
        [Authorize]
        public ActionResult<Postagem> PutPostagens([FromBody] Postagem postagem)
        {
            if (postagem.Id <= 0)
                return BadRequest();

            var postagemResult = _postagemRepository.Update(postagem);

            return postagemResult;
        }
    }
}