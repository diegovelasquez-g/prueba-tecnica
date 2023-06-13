using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Contracts;
using PruebaTecnica.Models;
using PruebaTecnica.ViewModels;

namespace PruebaTecnica.Controllers
{
    public class EquipoController : Controller
    {
        private readonly IEquipoRepository _equipoRepository;
        private readonly IMarcaRepository _marcaRepository;

        public EquipoController(IEquipoRepository equipoRepository, IMarcaRepository marcaRepository)
        {
            _equipoRepository = equipoRepository;
            _marcaRepository = marcaRepository;
        }

        public IActionResult Index()
        {
            var equipos = _equipoRepository.GetAllEquipos().AsQueryable().Include(equipo => equipo.Marca);
            return View(equipos);
        }

        [HttpGet]
        public IActionResult _NuevoEquipo()
        {
            var lstMarcas = _marcaRepository.GetAllMarcas();
            return PartialView("_NewEquipo", lstMarcas);
        }

        [HttpPost]
        public IActionResult NuevoEquipo(Equipo equipo)
        {
            _equipoRepository.CreateEquipo(equipo);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult _ModificarEquipo(int equipoId)
        {
            var lstMarcas = _marcaRepository.GetAllMarcas();
            Equipo equipo = _equipoRepository.GetEquipo(equipoId);

            var viewModel = new UpdateEquipoViewModel
            {
                LstMarcas = lstMarcas,
                Equipo = equipo
            };

            return PartialView("_UpdateEquipo", viewModel);
        }

        [HttpPost]
        public IActionResult ModificarEquipo(Equipo equipo)
        {
            Equipo equipoToUpdate = _equipoRepository.GetEquipo(equipo.IdEquipo);
            equipoToUpdate.IdMarca = equipo.IdMarca;
            equipoToUpdate.Descripcion = equipo.Descripcion;
            equipoToUpdate.NombreEquipo = equipo.NombreEquipo;
            equipoToUpdate.NumeroSerie = equipo.NumeroSerie;
            _equipoRepository.UpdateEquipo(equipoToUpdate);
            return Json(new { success = true, message = "Registro actualizado correctamente" });
        }

        [HttpDelete]
        public IActionResult EliminarEquipo(int equipoId)
        {
            Equipo equipo = _equipoRepository.GetEquipo(equipoId);
            _equipoRepository.DeleteEquipo(equipoId);
            return Json(new { success = true, message = "Registro eliminado correctamente" });
        }
    }
}
