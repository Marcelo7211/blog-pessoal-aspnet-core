using blogPessoal.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogPessoal.Repository
{
    public interface ITemaRepository
    {
        Task<IEnumerable<Tema>> Get();

        Task<Tema> Get(int Id);

        Task<Tema> Create(Tema tema);

        Task Update(Tema tema);

        Task Delete(int Id);
    }
}
