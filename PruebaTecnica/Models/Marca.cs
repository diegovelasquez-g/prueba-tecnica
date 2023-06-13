using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnica.Models
{
    public class Marca
    {
        [Key]
        public int IdMarca { get; set; }
        public string? NombreMarca { get; set; }
        [Column(TypeName = "nvarchar(250)")]
        public string? Descripcion { get; set; }
        public string? Herramienta { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Exactitud { get; set; }

    }
}
