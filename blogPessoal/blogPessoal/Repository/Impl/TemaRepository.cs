using blogPessoal.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace blogPessoal.Repository.impl
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
            Tema aux = _context.Temas.FirstOrDefaultAsync(c => c.Id.Equals(tema.Id)).Result;
            if (aux != null)
                return aux;

            _context.Temas.Add(tema);
            _context.SaveChangesAsync();

            return tema;
        }

        public void Delete(int id)
        {
            var temaDelete = _context.Temas.FindAsync(id);
            _context.Temas.Remove(temaDelete.Result);
            _context.SaveChangesAsync();
        }

        public Tema Get(int id)
        {
            try{
                var TemaReturn = _context.Temas.FirstAsync(i => i.Id == id).Result;
                return TemaReturn;
            }catch 
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

        public Tema Update(Tema tema)
        {
           

            _context.Entry(tema).State = EntityState.Modified;
            _context.SaveChangesAsync();

            return tema;
        }
    }
}
