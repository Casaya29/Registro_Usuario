using Proyecto_Final.Models;

namespace Proyecto_Final.Data
{
    public class DbInitializer
    {
        public static void Initialize(DBContext dbC)
        {
            dbC.Database.EnsureCreated();
            if (dbC.Localidad.Any())
            {
                return;
            }
            dbC.Localidad.AddRange(
                               new Localidad { Nombre = "Atlántico Norte" },
                               new Localidad { Nombre = "Atlántico Sur" },
                               new Localidad { Nombre = "Boaco" },
                               new Localidad { Nombre = "Carazo" },
                               new Localidad { Nombre = "Chinandega" },
                               new Localidad { Nombre = "Chontales" },
                               new Localidad { Nombre = "Esteli" },
                               new Localidad { Nombre = "Granada" },
                               new Localidad { Nombre = "Jinotega" },
                               new Localidad { Nombre = "León" },
                               new Localidad { Nombre = "Madriz" },
                               new Localidad { Nombre = "Managua" },
                               new Localidad { Nombre = "Masaya" },
                               new Localidad { Nombre = "Matagalpa" },
                               new Localidad { Nombre = "Nueva Segovia" },
                               new Localidad { Nombre = "Río San Juan" },
                               new Localidad { Nombre = "Rivas" }
                               );
            dbC.SaveChanges();

            dbC.Database.EnsureCreated();
            if (dbC.EstadoCivils.Any())
            {
                return;
            }
            dbC.EstadoCivils.AddRange(
                               new EstadoCivil { Nombre = "Soltero" },
                               new EstadoCivil { Nombre = "Casado" },
                               new EstadoCivil { Nombre = "Comprometido" }
                               );
            dbC.SaveChanges();
        }
    }
}
