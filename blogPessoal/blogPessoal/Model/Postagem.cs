using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace blogPessoal.Model
{
    public class Postagem
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Titulo { get; set; }

        [Required]
        [StringLength(140)]
        public string Descricao { get; set; }

        [ForeignKey("TemaId")]
        public Tema Tema { get; set; }

    }
}