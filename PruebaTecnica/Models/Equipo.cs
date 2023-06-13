using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnica.Models
{
    public class Equipo
    {
        [Key]
        public int IdEquipo { get; set; }

        [Required]
        public int IdMarca { get; set; }

        [ForeignKey("IdMarca")]
        public Marca Marca { get; set; }

        [Required]
        public string NombreEquipo { get; set; }

        [Required]
        public string NumeroSerie { get; set; }

        [StringLength(250)]
        public string Descripcion { get; set; }
    }
}
