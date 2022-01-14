using blogPessoal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogPessoal.Repository
{
    public interface IPostagemRepository
    {
        Task<IEnumerable<Postagem>> Get();

        Task<Postagem> Get(int Id);

        Task<Postagem> Create(Postagem postagem);

        Task<Postagem> Update(Postagem postagem);

        Task Delete(int Id);
    }
}
