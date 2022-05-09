using blogPessoal.Data;
using blogPessoal.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogPessoal.Repository
{
    public class PostagemRepository : IPostagemRepository
    {
        public readonly Data.AppContext _context;
        private readonly ITemaRepository temaRepository;

        public PostagemRepository(AppContext context, ITemaRepository temaRepository)
        {
            _context = context;
            this.temaRepository = temaRepository;

        }

        public async Task<Postagem> Create(Postagem postagem)
        {


            var aux = await _context.Postagens.FirstOrDefaultAsync(c => c.Id.Equals(postagem.Id));
            if (aux != null)
                return aux;

            if (postagem.Tema != null)
                postagem.Tema = await this.temaRepository.Create(postagem.Tema);

            _context.Postagens.AddAsync(postagem);
            await _context.SaveChangesAsync();

            return postagem;
        }


        public async Task<Postagem> Delete(int id)
        {
            var postagemDelete = await _context.Postagens.FindAsync(id);
            _context.Postagens.Remove(postagemDelete);
            await _context.SaveChangesAsync();

            return null;
        }

        public List<Postagem> GetAll()
        {
            return _context.Postagens.Include(p => p.Tema).ToListAsync().Result;
        }

        public async Task<Postagem> GetById(int id)
        {
            try
            {
                var PostagemReturn = await _context.Postagens.Include(p => p.Tema).FirstAsync(i => i.Id == id);
                return PostagemReturn;
            }
            catch
            {
                return null;
            }

        }

        public List<Postagem> GetTitulo(string Titulo)
        {
            var PostagemReturn = _context.Postagens.Include(p => p.Tema).Where(p => p.Titulo.ToLower().Contains(Titulo.ToLower())).ToListAsync();
            return PostagemReturn.Result;
        }

        public async Task<Postagem> Update(Postagem postagem)
        {
            if (postagem.Tema != null)
                postagem.Tema = await this.temaRepository.Create(postagem.Tema);

            _context.Entry(postagem).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return postagem;

        }
    }
}