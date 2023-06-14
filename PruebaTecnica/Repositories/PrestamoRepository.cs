using PruebaTecnica.Contracts;
using PruebaTecnica.Models;
using System.Text.RegularExpressions;

namespace PruebaTecnica.Repositories
{
    public class PrestamoRepository : IPrestamoRepository
    {
        private readonly EquiposDbContext _equiposDbContext;

        public PrestamoRepository(EquiposDbContext equiposDbContext)
        {
            _equiposDbContext = equiposDbContext;
        }

        public Prestamo CreatePrestamo(Prestamo prestamo)
        {
            _equiposDbContext.Prestamos.Add(prestamo);
            _equiposDbContext.SaveChanges();
            return prestamo;
        }

        public Prestamo DeletePrestamo(int id)
        {
            Prestamo prestamo = _equiposDbContext.Prestamos.Find(id);
            if (prestamo != null)
            {
                _equiposDbContext.Prestamos.Remove(prestamo);
                _equiposDbContext.SaveChanges();
            }
            return prestamo;
        }

        public IEnumerable<Prestamo> GetAllPrestamos()
        {
            return _equiposDbContext.Prestamos;
        }

        public Prestamo GetPrestamo(int id)
        {
            Prestamo prestamo = _equiposDbContext.Prestamos.Find(id);
            return prestamo;
        }

        public Prestamo UpdatePrestamo(Prestamo prestamo)
        {
            _equiposDbContext.Update(prestamo);
            _equiposDbContext.SaveChanges();
            return prestamo;
        }
    }
}
