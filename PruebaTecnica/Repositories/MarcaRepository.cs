using PruebaTecnica.Contracts;
using PruebaTecnica.Models;

namespace PruebaTecnica.Repositories
{
    public class MarcaRepository : IMarcaRepository
    {
        private readonly EquiposDbContext _equiposDbContext;
        public MarcaRepository(EquiposDbContext equiposDbContext)
        {
            _equiposDbContext = equiposDbContext;
        }

        public Marca CreateMarca(Marca marca)
        {
            throw new NotImplementedException();
        }

        public Marca UpdateMarca(Marca marca)
        {
            throw new NotImplementedException();
        }

        public Marca DeleteMarca(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Marca> GetAllMarcas()
        {
            return _equiposDbContext.Marcas;
        }

        public Marca GetMarca(int id)
        {
            throw new NotImplementedException();
        }
    }
}
