using blogPessoal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogPessoal.Repository
{
    public interface ITemaRepository
    {
        List<Tema> GetAll();

        Tema Get(int Id);

        List<Tema> GetByDescricao(string descricao);

        Tema Create(Tema tema);

        Tema Update(Tema tema);

        void Delete(int Id);
    }
}