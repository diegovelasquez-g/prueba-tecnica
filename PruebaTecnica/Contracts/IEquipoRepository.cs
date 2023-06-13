using PruebaTecnica.Models;

namespace PruebaTecnica.Contracts
{
    public interface IEquipoRepository
    {
        IEnumerable<Equipo> GetAllEquipos();

        Equipo GetEquipo(int id);

        Equipo CreateEquipo(Equipo equipo);

        Equipo UpdateEquipo(Equipo equipo);

        Equipo DeleteEquipo(int id);
    }
}
