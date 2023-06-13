using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Contracts;
using PruebaTecnica.Repositories;

namespace PruebaTecnica.Controllers
{
    public class MarcaController : Controller
    {
        private readonly IMarcaRepository _marcaRepository;

        public MarcaController(IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

        public IActionResult Index()
        {
            var marcas = _marcaRepository.GetAllMarcas();
            return View(marcas);
        }
    }
}
