using PruebaTecnica.Models;

namespace PruebaTecnica.Contracts
{
    public interface IMarcaRepository
    {
        IEnumerable<Marca> GetAllMarcas();

        Marca GetMarca(int id);

        Marca CreateMarca(Marca marca);

        Marca UpdateMarca(Marca marca);

        Marca DeleteMarca(int id);
    }
}
