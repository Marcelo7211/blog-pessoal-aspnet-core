
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
    public class TemaController : ControllerBase
    {

        private readonly ITemaRepository _temaRepository;

        public TemaController(ITemaRepository temaRepository)
        {
            _temaRepository = temaRepository;
        }

        [HttpGet]
        [Authorize]
        public List<Tema> GetTemas()
        {
            return  _temaRepository.GetAll();
        }

        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<Tema> GetTemas(int id)
        {
            return  _temaRepository.Get(id);
        }

        [HttpGet("descricao/{descricao}")]
        [Authorize]
        public List<Tema> GetTituloPostagens(string descricao)
        {
            return  _temaRepository.GetByDescricao(descricao);
        }

        [HttpPost]
        [Authorize]
        public ActionResult<Tema> PostTemas([FromBody] Tema tema)
        {
            var newTema =  _temaRepository.Create(tema);
            return CreatedAtAction(nameof(GetTemas), new { id = newTema.Id }, newTema);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public  ActionResult Delete(int id)
        {
            var temaToDelete =  _temaRepository.Get(id);

            if (temaToDelete == null)
                return NotFound();

             _temaRepository.Delete(temaToDelete.Id);
            return NoContent();


        }

        [HttpPut]
        [Authorize]
        public  ActionResult PutTemas(int id, [FromBody] Tema tema)
        {
            if (id != tema.Id)
                return BadRequest();

             _temaRepository.Update(tema);

            return NoContent();
        }
    }
}
