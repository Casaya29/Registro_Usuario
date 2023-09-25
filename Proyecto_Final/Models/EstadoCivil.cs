using System.ComponentModel.DataAnnotations;

namespace Proyecto_Final.Models
{
    public class EstadoCivil
    {
        public int Id { get; set; }

        [Required]
        [StringLength(64)]
        public string Nombre { get; set; }

        public List<Usuario>? Usuarios { get; set; }
    }
}
