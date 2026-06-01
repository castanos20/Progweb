using Microsoft.AspNetCore.Mvc;
using Proyecto_Polleria.Models;
using Proyecto_Polleria.Services;

namespace Proyecto_Polleria.Controllers
{
    public class Gestion_clienteController : Controller
    {
        private readonly ClienteService _service;

        public Gestion_clienteController(ClienteService service)
        {
            _service = service;
        }

        public IActionResult Registrar()
        {

            return View();
        }

        public IActionResult Consultar()
        {
            List<Cliente> clie = _service.GetAll();
            return View(clie);
        }

        [HttpGet]
        public IActionResult Actualizar(string? cc_buscar)
        {
            if (string.IsNullOrEmpty(cc_buscar))
                return View();

            Cliente clie = _service.GetById(cc_buscar);
            if (clie == null) { 
                ViewBag.mensaje = "Cliente No encontrado";
            }
            else
            {
                return View(clie);
            }
            return View();
        }

        public IActionResult Eliminar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(string cc, string nombre, string telefono, string direccion)
        {
            Cliente clie = new Cliente(cc, nombre, telefono, direccion);
            if (!_service.Crear(clie))
            {
                ViewBag.mensajereg = "Cliente ya asignado";
            }
            return View();
        }

        [HttpPost]
        public IActionResult Actualizar(Cliente clie) 
        {
            _service.Update(clie);
            return View();
        }

        [HttpPost]
        public IActionResult Eliminar(string cc)
        {
            bool flag = _service.Delete(cc);
            if (!flag)
            {
                ViewBag.mensajeEliminar = "Cliente no encontrado";
            }
            return View();
        }
    }
}
