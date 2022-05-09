using blogPessoal.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogPessoal.Repository.impl
{
    public class TemaRepository : ITemaRepository
    {
        public readonly Data.AppContext _context;

        public TemaRepository(Data.AppContext context)
        {
            _context = context;
        }

        public async Task<Tema> Create(Tema tema)
        {
            var aux = await _context.Temas.FirstOrDefaultAsync(c => c.Id.Equals(tema.Id));
            if (aux != null)
                return aux;
            _context.Temas.AddAsync(tema);
            await _context.SaveChangesAsync();

            return tema;
        }

        public async Task<Tema> Delete(int id)
        {
            var temaDelete = await _context.Temas.FindAsync(id);
            _context.Temas.Remove(temaDelete);
            await _context.SaveChangesAsync();

            return null;
        }

        public async Task<Tema> GetById(int Id)
        {
            try
            {
                var TemaReturn = await _context.Temas.FirstAsync(i => i.Id == Id);
                return TemaReturn;
            }
            catch
            {
                return null;
            }
        }

        public List<Tema> GetAll()
        {
            return _context.Temas.ToListAsync().Result;
        }

        public List<Tema> GetByDescricao(string descricao)
        {
            var TemaReturn = _context.Temas.Where(p => p.Descricao.ToLower().Contains(descricao.ToLower())).ToListAsync().Result;
            return TemaReturn;
        }

        public async Task<Tema> Update(Tema tema)
        {
            _context.Entry(tema).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return tema;
        }
    }
}
