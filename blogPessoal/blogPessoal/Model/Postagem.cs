using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace blogPessoal.Model
{
    public class Postagem
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(140)]
        public string Titulo { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(800)]
        public string Descricao { get; set; }

        [ForeignKey("TemaId")]
        public Tema Tema { get; set; }


    }
}
