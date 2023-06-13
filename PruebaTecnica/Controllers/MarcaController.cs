using Microsoft.AspNetCore.Mvc;
using PruebaTecnica.Contracts;
using PruebaTecnica.Models;

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

        [HttpGet]
        public IActionResult _NuevaMarca()
        {
            return PartialView("_NewMarca");
        }

        [HttpPost]
        public IActionResult NuevaMarca(Marca marca)
        {
            _marcaRepository.CreateMarca(marca);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult _ModificarMarca(int marcaId)
        {
            Marca marca = _marcaRepository.GetMarca(marcaId);
            return PartialView("_UpdateMarca", marca);
        }

        [HttpPost]
        public IActionResult ModificarMarca(Marca marca)
        {
            Marca marcaToUpdate = _marcaRepository.GetMarca(marca.IdMarca);
            marcaToUpdate.NombreMarca = marca.NombreMarca;
            marcaToUpdate.Descripcion = marca.Descripcion;
            marcaToUpdate.Herramienta = marca.Herramienta;
            marcaToUpdate.Exactitud = marca.Exactitud;
            _marcaRepository.UpdateMarca(marcaToUpdate);
            return Json(new { success = true, message = "Registro actualizado correctamente" });
        }

        [HttpDelete]
        public IActionResult EliminarMarca (int marcaId)
        {
            Marca marca = _marcaRepository.GetMarca(marcaId);
            _marcaRepository.DeleteMarca(marcaId);
            return Json(new { success = true, message = "Registro eliminado correctamente" });
        }

    }
}
