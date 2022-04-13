using Microsoft.EntityFrameworkCore;

namespace estágio.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {


        }

        public DbSet<entidades> entidade { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            _ = modelBuilder.Entity<entidades>()
                   .Property(p => p.data)
                   .HasPrecision(8);

            _ = modelBuilder.Entity<entidades>()

                    .HasData(

                new entidades { nome = "Consertar carro", data = "01/04/2002", status = "concluido" },
                new entidades { nome = "Cortar grama", data = "03/04/2002", status = "Em processo" },
                new entidades { nome = "Montar computador", data = "2/04/2002", status = "Em processo" });



        }



    }

}

