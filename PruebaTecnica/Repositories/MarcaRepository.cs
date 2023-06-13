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
            _equiposDbContext.Marcas.Add(marca);
            _equiposDbContext.SaveChanges();
            return marca;
        }

        public Marca UpdateMarca(Marca marca)
        {
            _equiposDbContext.Update(marca);
            _equiposDbContext.SaveChanges();
            return marca;
        }

        public Marca DeleteMarca(int id)
        {
            Marca marca = _equiposDbContext.Marcas.Find(id);
            if(marca != null)
            {
                _equiposDbContext.Marcas.Remove(marca);
                _equiposDbContext.SaveChanges();
            } 
            return marca;
        }

        public IEnumerable<Marca> GetAllMarcas()
        {
            return _equiposDbContext.Marcas;
        }

        public Marca GetMarca(int id)
        {
            return _equiposDbContext.Marcas.FirstOrDefault(m => m.IdMarca == id);
        }
    }
}
