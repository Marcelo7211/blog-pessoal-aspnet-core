﻿using blogPessoal.Data;
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

        public async Task<Postagem> Create(Postagem postagem)
        {
            Postagem aux = await _context.Postagens.FirstOrDefaultAsync(c => c.Id.Equals(postagem.Id));
            if (aux != null)
                return aux;

            if (postagem.Tema != null)
                postagem.Tema = await this.temaRepository.Create(postagem.Tema);


            if (postagem.User != null)
                postagem.User = await this.userRepository.Create(postagem.User);

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

        public async Task<List<Postagem>> Get()
        {
            return await _context.Postagens.Include(p => p.Tema).Include(p=> p.User).ToListAsync();
        }

        public async Task<Postagem> Get(int id)
        {
            var PostagemReturn = _context.Postagens.Include(p => p.Tema).Include(p => p.User).FirstAsync(i => i.Id == id);
            return await PostagemReturn;

        }

        public async Task<List<Postagem>> GetTitulo(string Titulo)
        {
            var PostagemReturn = _context.Postagens.Include(p => p.Tema).Include(p => p.User).Where(p => p.Titulo.ToLower().Contains(Titulo.ToLower())).ToListAsync();
            return await PostagemReturn;
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
