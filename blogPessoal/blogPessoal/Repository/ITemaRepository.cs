using blogPessoal.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace blogPessoal.Repository
{
    public interface ITemaRepository
    {
        Task<List<Tema>> Get();

        Task<Tema> Get(int Id);

        Task<Tema> Create(Tema tema);

        Task Update(Tema tema);

        Task Delete(int Id);
    }
}
