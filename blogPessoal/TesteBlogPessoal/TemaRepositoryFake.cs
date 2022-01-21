using blogPessoal.Model;
using blogPessoal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteBlogPessoal
{
    public class TemaRepositoryFake : ITemaRepository
    {
        private readonly List<Tema> _temas;
        public TemaRepositoryFake()
        {
            _temas = new List<Tema>()
            {
                new Tema() { Id = 1, Descricao = "Asp.net"},
                new Tema() { Id = 2, Descricao = "CSharp"},
                new Tema() { Id = 3, Descricao = "React"},
                new Tema() { Id = 4, Descricao = "SqlServer"},
                new Tema() { Id = 5, Descricao = "JavaScript"},

            };
        }

        public Tema Create(Tema tema)
        {
            tema.Id = GeraId();
            _temas.Add(tema);
            return tema;
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Tema Get(int Id)
        {
            return _temas.Where(a => a.Id == Id)
               .FirstOrDefault();
        }

        public List<Tema> GetAll()
        {
            return _temas;
        }

        public List<Tema> GetByDescricao(string descricao)
        {
            throw new System.NotImplementedException();
        }

        public Tema Update(Tema tema)
        {
            throw new System.NotImplementedException();
        }
        static int GeraId()
        {
            Random random = new Random();
            return random.Next(1, 100);
        }
    }
}
