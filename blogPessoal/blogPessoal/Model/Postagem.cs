using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace blogPessoal.Model
{
    public class Postagem
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }
        [ForeignKey("TemaId")]
        public Tema Tema { get; set; }

        [ForeignKey("TemaId")]
        public User User { get; set; }
    }
}
