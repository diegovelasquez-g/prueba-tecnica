using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Contracts;
using PruebaTecnica.Models;
using PruebaTecnica.ViewModels;

namespace PruebaTecnica.Controllers
{
    public class PrestamoController : Controller
    {
        private readonly IPrestamoRepository _prestamoRepository;
        private readonly IMarcaRepository _marcaRepository;
        private readonly IEquipoRepository _equipoRepository;

        public PrestamoController(IMarcaRepository marcaRepository, IPrestamoRepository prestamoRepository, IEquipoRepository equipoRepository)
        {
            _marcaRepository = marcaRepository;
            _prestamoRepository = prestamoRepository;
            _equipoRepository = equipoRepository;
        }

        public IActionResult Index()
        {
            var prestamos = _prestamoRepository.GetAllPrestamos().AsQueryable().Include(prestamo => prestamo.Equipo).ThenInclude(equipo => equipo.Marca);
            return View(prestamos);
        }

        public IActionResult _NuevoPrestamo()
        {
            var lstMarcas = _marcaRepository.GetAllMarcas();
            var viewModel = new NewPrestamoViewModel
            {
                LstMarcas = lstMarcas
            };

            return PartialView("_NewPrestamo", viewModel);
        }

        [HttpPost]
        public IActionResult ObtenerEquipos(int marcaId)
        {
            var lstEquipos = _equipoRepository.GetEquiposByMarca(marcaId);
            return Json(new { success = true, equipos = lstEquipos });
        }

        [HttpPost]
        public IActionResult NuevoPrestamo(Prestamo prestamo)
        {
            _prestamoRepository.CreatePrestamo(prestamo);
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public IActionResult EliminarPrestamo(int prestamoId)
        {
            Prestamo prestamo = _prestamoRepository.GetPrestamo(prestamoId);
            _prestamoRepository.DeletePrestamo(prestamoId);
            return Json(new { success = true, message = "Registro eliminado correctamente" });
        }

        [HttpPost]
        public IActionResult _ModificarPrestamo(int prestamoId)
        {
            Prestamo prestamo = _prestamoRepository.GetPrestamo(prestamoId);
            prestamo.Equipo = _equipoRepository.GetEquipo(prestamo.IdEquipo);
            var lstMarcas = _marcaRepository.GetAllMarcas();
            var viewModel = new UpdatePrestamoViewModelcs
            {
                LstMarcas = lstMarcas,
                Prestamo = prestamo,
            };
            return PartialView("_UpdatePrestamo", viewModel);
        }

        [HttpPost]
        public IActionResult ModificarPrestamo(Prestamo prestamo)
        {
            Prestamo prestamoToUpdate = _prestamoRepository.GetPrestamo(prestamo.IdPrestamo);
            prestamoToUpdate.IdEquipo = prestamo.IdEquipo;
            prestamoToUpdate.NombrePersona = prestamo.NombrePersona;
            prestamoToUpdate.FechaInicio = prestamo.FechaInicio;
            prestamoToUpdate.FechaFin = prestamo.FechaFin;
            _prestamoRepository.UpdatePrestamo(prestamoToUpdate);
            return Json(new { success = true, message = "Registro modificado con éxito" }); 
        }
    }
}
