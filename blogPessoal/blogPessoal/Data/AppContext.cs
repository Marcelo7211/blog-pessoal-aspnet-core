using blogPessoal.Model;
using Microsoft.EntityFrameworkCore;


namespace blogPessoal.Data
{
    public class AppContext : DbContext
    {

        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {

        }

        public DbSet<Tema> Temas { get; set; }
        public DbSet<Postagem> Postagens { get; set; }

        public DbSet<User> Users { get; set; }


    }
}
