using blogPessoal.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogPessoal.Repository
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
            Tema aux = await _context.Temas.FirstOrDefaultAsync(c => c.Id.Equals(tema.Id));
            if (aux != null)
                return aux;

            _context.Temas.Add(tema);
            await _context.SaveChangesAsync();

            return tema;
        }

        public async Task Delete(int id)
        {
            var temaDelete = await _context.Temas.FindAsync(id);
            _context.Temas.Remove(temaDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Tema>> Get()
        {
            return await _context.Temas.Include(t=>t.Postagem).ToListAsync();
        }

        public async Task<Tema> Get(int id)
        {
            var TemaReturn = _context.Temas.Include(t => t.Postagem).FirstAsync(i => i.Id == id);
            return await TemaReturn;

        }

        public async Task<List<Tema>> GetByDescricao(string descricao)
        {
            var TemaReturn = _context.Temas.Include(t => t.Postagem).Where(p => p.Descricao.ToLower().Contains(descricao.ToLower())).ToListAsync();
            return await TemaReturn;
        }
            public async Task<Tema> Update(Tema tema)
        {
            _context.Entry(tema).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return tema;
        }
    }
}
