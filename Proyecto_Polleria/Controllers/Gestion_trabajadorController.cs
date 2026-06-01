using Microsoft.AspNetCore.Mvc;
using Proyecto_Polleria.Models;
using Proyecto_Polleria.Services;

namespace Proyecto_Polleria.Controllers
{
    public class Gestion_trabajadorController : Controller
    {
        private readonly TrabajadorService _service;

        public Gestion_trabajadorController(TrabajadorService service)
        {
            _service = service;
        }
        public IActionResult Registrar()
        {
            return View();
        }

        public IActionResult Consultar()
        {
            List<Trabajador> traba=_service.GetAllTrabajadors();
            return View(traba);
        }
        [HttpGet]
        public IActionResult Actualizar(string? cc_buscar)
        {
            if (string.IsNullOrEmpty(cc_buscar))
                return View();

            Trabajador traba = _service.GetById(cc_buscar);
            if (traba == null) { 
                ViewBag.mensaje = "Trabajador No encontrado";
            }
            else
            {
                return View(traba);
            }
            return View();
        }

        public IActionResult Eliminar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registrar(string cc, string nombre, string telefono, string direccion, double salario, int rol)
        {
            Trabajador traba = new Trabajador(cc,nombre,telefono,direccion,salario,rol);
            if (!_service.CrearTrabajador(traba))
            {
                ViewBag.mensajereg = "Trabajador ya asignado";
            }
            return View();
        }

        [HttpPost]
        public IActionResult Actualizar(Trabajador traba) 
        {
            _service.Update(traba);
            return View();
        }
        [HttpPost]
        public IActionResult Eliminar(string cc)
        {
            bool flag=_service.Delete(cc);
            if (!flag)
            {
                ViewBag.mensajeEliminar = "Trabajor no encontrado";
            }
            return View();
        }

    }
}
