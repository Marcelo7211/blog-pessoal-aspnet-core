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

        Task<Tema> GetById(int Id);

        List<Tema> GetByDescricao(string descricao);

        Task<Tema> Create(Tema tema);

        Task<Tema> Update(Tema tema);

        Task<Tema> Delete(int Id);
    }
}