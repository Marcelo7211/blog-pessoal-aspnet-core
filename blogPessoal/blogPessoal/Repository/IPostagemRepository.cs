using blogPessoal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogPessoal.Repository
{
    public interface IPostagemRepository
    {
        List<Postagem> GetAll();

        Task<Postagem> GetById(int Id);

        List<Postagem> GetTitulo(string Titulo);

        Task<Postagem> Create(Postagem postagem);

        Task<Postagem> Update(Postagem postagem);

        Task<Postagem> Delete(int Id);
    }
}