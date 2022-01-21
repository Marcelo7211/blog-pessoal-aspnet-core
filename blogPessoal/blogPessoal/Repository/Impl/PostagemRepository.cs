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
        private readonly IUserRepository userRepository;

        public PostagemRepository(AppContext context, ITemaRepository temaRepository, IUserRepository userRepository)
        {
            _context = context;
            this.temaRepository = temaRepository;
            this.userRepository = userRepository;
        }

        public Postagem Create(Postagem postagem)
        {
            Postagem aux =  _context.Postagens.FirstOrDefaultAsync(c => c.Id.Equals(postagem.Id)).Result;
            if (aux != null)
                return aux;

            if (postagem.Tema != null)
                postagem.Tema =  this.temaRepository.Create(postagem.Tema);


            if (postagem.User != null)
                postagem.User =  this.userRepository.Create(postagem.User);

            _context.Postagens.Add(postagem);
             _context.SaveChangesAsync();

            return postagem;
        }


        public void Delete(int id)
        {
            var postagemDelete =  _context.Postagens.FindAsync(id);
            _context.Postagens.Remove(postagemDelete.Result);
            _context.SaveChangesAsync();
        }

        public List<Postagem> GetAll()
        {
            return  _context.Postagens.Include(p => p.Tema).Include(p=> p.User).ToListAsync().Result;
        }

        public Postagem Get(int id)
        {
            var PostagemReturn = _context.Postagens.Include(p => p.Tema).Include(p => p.User).FirstAsync(i => i.Id == id);
            return  PostagemReturn.Result;

        }

        public List<Postagem> GetTitulo(string Titulo)
        {
            var PostagemReturn = _context.Postagens.Include(p => p.Tema).Include(p => p.User).Where(p => p.Titulo.ToLower().Contains(Titulo.ToLower())).ToListAsync();
            return  PostagemReturn.Result;
        }

        public Postagem Update(Postagem postagem)
        {
            if (postagem.Tema != null)
                postagem.Tema =  this.temaRepository.Create(postagem.Tema);

            _context.Entry(postagem).State = EntityState.Modified;
            _context.SaveChangesAsync();

            return postagem;

        }
    }
}
