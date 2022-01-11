using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace blogPessoal.Model
{
    public class Tema
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(140)]
        public string Descricao { get; set; }

        [JsonIgnore]
        public List<Postagem> Postagem { get; set; }

    }
}
