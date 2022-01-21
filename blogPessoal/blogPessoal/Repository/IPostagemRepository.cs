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

        Postagem Get(int Id);

        List<Postagem> GetTitulo(string Titulo);

        Postagem Create(Postagem postagem);

        Postagem Update(Postagem postagem);

        void Delete(int Id);
    }
}
