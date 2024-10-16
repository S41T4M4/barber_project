using BarberAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace BarberAPI.Infraestrutura
{
    public class ConnectionContext :DbContext
    {

        public DbSet<Usuarios> Usuarios { get; set; }


         public ConnectionContext(DbContextOptions<ConnectionContext> options)
           : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         => optionsBuilder.UseNpgsql(
             "Server=localhost;" +
             "Port=5432;Database=barber_db;" +
             "User Id=postgres;" +
             "Password=Staff4912;");
    }
}
