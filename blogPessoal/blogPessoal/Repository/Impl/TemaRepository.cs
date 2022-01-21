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

        public Tema Create(Tema tema)
        {
            Tema aux =  _context.Temas.FirstOrDefaultAsync(c => c.Id.Equals(tema.Id)).Result;
            if (aux != null)
                return aux;

            _context.Temas.Add(tema);
             _context.SaveChangesAsync();

            return tema;
        }

        public void Delete(int id)
        {
            var temaDelete =  _context.Temas.FindAsync(id).Result;
            _context.Temas.Remove(temaDelete);
             _context.SaveChangesAsync();
        }

        public  Tema Get(int id)
        {
            var TemaReturn = _context.Temas.Include(t => t.Postagem).FirstAsync(i => i.Id == id).Result;
            return  TemaReturn;

        }

        public List<Tema> GetAll()
        {
            return _context.Temas.Include(t => t.Postagem).ToListAsync().Result;
        }

        public  List<Tema> GetByDescricao(string descricao)
        {
            var TemaReturn = _context.Temas.Include(t => t.Postagem).Where(p => p.Descricao.ToLower().Contains(descricao.ToLower())).ToListAsync().Result;
            return  TemaReturn;
        }
            public  Tema Update(Tema tema)
        {
            _context.Entry(tema).State = EntityState.Modified;
             _context.SaveChangesAsync();

            return tema;
        }
    }
}
