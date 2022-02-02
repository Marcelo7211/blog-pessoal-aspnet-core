using blogPessoal.Model;
using blogPessoal.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public ActionResult<List<Tema>> GetAllTemas()
        {
            return Ok(_temaRepository.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Tema> GetByIdTema(int id)
        {
            var tema = _temaRepository.Get(id);
            if (tema == null)
            {
            return NotFound();
            }
            else
            {
                return Ok(tema);
            }
          
        }


        [HttpGet("descricao/{descricao}")]
        public List<Tema> GetByDescricao(string descricao)
        {
            return _temaRepository.GetByDescricao(descricao);
        }

        [HttpPost]
        public ActionResult<Tema> PostTema([FromBody] Tema tema)
        {
            var newTema = _temaRepository.Create(tema);
            return CreatedAtAction(nameof(GetAllTemas), new { id = newTema.Id }, newTema);
        }

        [HttpPut]
        public ActionResult PutTema([FromBody] Tema tema)
        {
          
            if (tema.Id == 0)
                return BadRequest();
            else
            {
                var temaUpdate = _temaRepository.Update(tema);

                return Ok(temaUpdate);

            }
          
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var temaToDelete = _temaRepository.Get(id);

            if (temaToDelete == null)
                return NotFound();

            _temaRepository.Delete(temaToDelete.Id);
            return NoContent();


        }
    }

}
