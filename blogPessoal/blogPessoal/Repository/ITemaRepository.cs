using blogPessoal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogPessoal.Repository
{
    public interface ITemaRepository
    {
        Task<List<Tema>> Get();

        Task<Tema> Get(int Id);

        Task<List<Tema>> GetByDescricao(string descricao);

        Task<Tema> Create(Tema tema);

        Task<Tema> Update(Tema tema);

        Task Delete(int Id);
    }
}
