using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blogPessoal.Model
{
    public class User
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string Role { get; set; }

      
    }
}
