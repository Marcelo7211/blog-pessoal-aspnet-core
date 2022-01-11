using blogPessoal.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace blogPessoal.Repository
{
    public interface IPostagemRepository
    {
        Task<List<Postagem>> Get();

        Task<Postagem> Get(int Id);

        Task<Postagem> Create(Postagem postagem);

        Task Update(Postagem postagem);

        Task Delete(int Id);
    }
}
