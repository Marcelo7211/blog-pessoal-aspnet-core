using blogPessoal.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace blogPessoal.Repository
{
    public class PostagemRepository : IPostagemRepository
    {
        public readonly Data.AppContext _context;

        public PostagemRepository(Data.AppContext context)
        {
            _context = context;
        }

        public async Task<Postagem> Create(Postagem postagem)
        {
            _context.Postagens.Add(postagem);
            await _context.SaveChangesAsync();

            return postagem;
        }

        public async Task Delete(int id)
        {
            var postagemDelete = await _context.Postagens.FindAsync(id);
            _context.Postagens.Remove(postagemDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Postagem>> Get()
        {
            return await _context.Postagens.Include(p => p.Tema).ToListAsync();
        }

        public async Task<Postagem> Get(int id)
        {
            var PostagemReturn = _context.Postagens.Include(p => p.Tema).FirstAsync(i => i.Id == id);
            return await PostagemReturn;

        }

        public async Task Update(Postagem postagem)
        {
            _context.Entry(postagem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
