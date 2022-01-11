

using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace blogPessoal.Model
{
    public class User
    {
        public int Id { get; set; }


        [Required]
        [MinLength(2)]
        [MaxLength(600)]
        public string Nome { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(600)]
        public string Usuario { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(600)]
        public string Role { get; set; }

        public static explicit operator User(Task<User> v)
        {
            throw new NotImplementedException();
        }
    }
}
