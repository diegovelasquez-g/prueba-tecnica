using PruebaTecnica.Contracts;
using PruebaTecnica.Models;
using System.Text.RegularExpressions;

namespace PruebaTecnica.Repositories
{
    public class EquipoRepository : IEquipoRepository
    {

        private readonly EquiposDbContext _equiposDbContext;

        public EquipoRepository(EquiposDbContext equiposDbContext)
        {
            _equiposDbContext = equiposDbContext;
        }

        public Equipo CreateEquipo(Equipo equipo)
        {
            _equiposDbContext.Equipos.Add(equipo);
            _equiposDbContext.SaveChanges();
            return equipo;
        }

        public Equipo DeleteEquipo(int id)
        {
            Equipo equipo = _equiposDbContext.Equipos.Find(id);
            if (equipo != null)
            {
                _equiposDbContext.Equipos.Remove(equipo);
                _equiposDbContext.SaveChanges();
            }
            return equipo;
        }

        public IEnumerable<Equipo> GetAllEquipos()
        {
            return _equiposDbContext.Equipos;
        }

        public Equipo GetEquipo(int id)
        {
            return _equiposDbContext.Equipos.FirstOrDefault(m => m.IdEquipo  == id);
        }

        public Equipo UpdateEquipo(Equipo equipo)
        {
            _equiposDbContext.Update(equipo);
            _equiposDbContext.SaveChanges();
            return equipo;
        }
    }
}
