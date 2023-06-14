using PruebaTecnica.Models;

namespace PruebaTecnica.Contracts
{
    public interface IPrestamoRepository
    {
        IEnumerable<Prestamo> GetAllPrestamos();

        Prestamo GetPrestamo(int id);

        Prestamo CreatePrestamo(Prestamo prestamo);

        Prestamo UpdatePrestamo(Prestamo prestamo);

        Prestamo DeletePrestamo(int id);
    }
}
