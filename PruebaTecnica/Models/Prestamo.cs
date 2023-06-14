using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnica.Models
{
    public class Prestamo
    {
        [Key]
        public int IdPrestamo { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? NombrePersona { get; set; }

        [Required]
        public int IdEquipo { get; set; }

        [ForeignKey("IdEquipo")]
        public Equipo? Equipo { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        [NotMapped]
        public string Estado
        {
            get
            {
                if ( DateTime.Now < FechaFin)
                {
                    return "Inactivo";
                }
                else
                {
                    return "Activo";
                }
            }
        }
    }
}
