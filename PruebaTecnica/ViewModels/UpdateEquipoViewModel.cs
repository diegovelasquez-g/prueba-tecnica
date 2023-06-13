using PruebaTecnica.Models;

namespace PruebaTecnica.ViewModels
{
    public class UpdateEquipoViewModel
    {
        public IEnumerable<Marca> LstMarcas { get; set; }
        public Equipo Equipo { get; set; }
    }
}
