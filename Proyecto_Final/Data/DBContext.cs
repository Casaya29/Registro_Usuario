using Microsoft.EntityFrameworkCore;
using Proyecto_Final.Models;

namespace Proyecto_Final.Data
{
    public class DBContext : DbContext  
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<EstadoCivil> EstadoCivils { get; set; }
        public DbSet<Localidad> Localidad { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("Usuario");
            modelBuilder.Entity<EstadoCivil>().ToTable("EstadoCivil");
            modelBuilder.Entity<Localidad>().ToTable("Localidad");

        }
    }
}
