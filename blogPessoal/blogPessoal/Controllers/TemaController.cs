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
        public List<Tema> GetAllTemas()
        {
            return _temaRepository.GetAll();
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Tema>> GetByIdTema(int id)
        {
            var tema = await _temaRepository.GetById(id);
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
        [Authorize]
        public List<Tema> GetByDescricao(string descricao)
        {
            return _temaRepository.GetByDescricao(descricao);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Tema>> PostTema([FromBody] Tema tema)
        {
            var temaReturn = await _temaRepository.Create(tema);
            return CreatedAtAction(nameof(GetAllTemas), new { id = temaReturn.Id }, temaReturn);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> PutTema([FromBody] Tema tema)
        {

            if (tema.Id == 0)
                return BadRequest();
            else
            {
                var temaUpdate = await _temaRepository.Update(tema);

                return Ok(temaUpdate);

            }

        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteTema(int id)
        {
            var temaToDelete = await _temaRepository.GetById(id);

            if (temaToDelete == null)
                return NotFound();

            await _temaRepository.Delete(temaToDelete.Id);
            return NoContent();


        }
    }

}
