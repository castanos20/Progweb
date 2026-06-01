using Microsoft.AspNetCore.Mvc;
using Proyecto_Polleria.Models;
using Proyecto_Polleria.Services;

namespace Proyecto_Polleria.Controllers
{
    public class Gestion_proveedorController : Controller
    {
        private readonly ProveedorService _service;

        public Gestion_proveedorController(ProveedorService service)
        {
            _service = service;
        }

        public IActionResult Registrar()
        {
            return View();
        }

        public IActionResult Consultar()
        {
            List<Proveedor> provs = _service.GetAll();
            return View(provs);
        }

        [HttpGet]
        public IActionResult Actualizar(string? nit_buscar)
        {
            if (string.IsNullOrEmpty(nit_buscar))
                return View();

            Proveedor prov = _service.GetById(nit_buscar);
            if (prov == null)
            {
                ViewBag.mensaje = "Proveedor No encontrado";
            }
            else
            {
                return View(prov);
            }
            return View();
        }

        public IActionResult Eliminar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(string nit, string nombre, string direccion, string telefono)
        {
            Proveedor prov = new Proveedor(nit, nombre, direccion, telefono);
            if (!_service.Crear(prov))
            {
                ViewBag.mensajereg = "Proveedor ya asignado";
            }
            return View();
        }

        [HttpPost]
        public IActionResult Actualizar(Proveedor prov)
        {
            _service.Update(prov);
            return View();
        }

        [HttpPost]
        public IActionResult Eliminar(string nit)
        {
            bool flag = _service.Delete(nit);
            if (!flag)
            {
                ViewBag.mensajeEliminar = "Proveedor no encontrado";
            }
            return View();
        }
    }
}
