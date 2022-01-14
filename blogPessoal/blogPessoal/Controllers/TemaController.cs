﻿
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
        public async Task<IEnumerable<Tema>> GetTemas()
        {
            return await _temaRepository.Get();
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Tema>> GetTemas(int id)
        {
            return await _temaRepository.Get(id);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Tema>> PostTemas([FromBody] Tema tema)
        {
            var newTema = await _temaRepository.Create(tema);
            return CreatedAtAction(nameof(GetTemas), new { id = newTema.Id }, newTema);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            var temaToDelete = await _temaRepository.Get(id);

            if (temaToDelete == null)
                return NotFound();

            await _temaRepository.Delete(temaToDelete.Id);
            return NoContent();


        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<Tema>> PutTemas( [FromBody] Tema tema)
        {
            if (tema.Id <= 0)
                return BadRequest();

            var temaResult = await _temaRepository.Update(tema);

            return temaResult;
        }
    }
}
