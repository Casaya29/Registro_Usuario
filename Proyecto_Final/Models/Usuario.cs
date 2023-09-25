using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Proyecto_Final.Models
{
    public class Usuario
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nombres")]
        public string Nombres { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Apellido")]
        public string Apellidos { get; set; }

        [StringLength(16)]
        public string? Cedula { get; set; }

        [Required]
        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        public DateTime? Fecha { get; set; }

        [StringLength(32)]
        [Display(Name = @"Teléfono")]
        public string? Telefono { get; set; }

        [Display(Name = @"EstadoCivil")]
        public int EstadoCivilId { get; set; }

        [Display(Name = @"EstadoCivil")]
        public EstadoCivil? EstadoCivil { get; set; }        
        
        [Display(Name = @"Localidad")]
        public int LocalidadId { get; set; }

        [Display(Name = @"Localidad")]
        public Localidad? Localidad { get; set; }
    }
}
