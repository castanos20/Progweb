using Microsoft.AspNetCore.Mvc;
using Proyecto_Polleria.Models;
using Proyecto_Polleria.Services;
using System;
using System.Collections.Generic;

namespace Proyecto_Polleria.Controllers
{
    public class Gestion_inventarioController : Controller
    {
        private readonly InventarioService _service;

        public Gestion_inventarioController(InventarioService service)
        {
            _service = service;
        }

        public IActionResult Registrar()
        {
            ViewBag.ingredientes = _service.GetAllIngredientes();
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(Inventario inv, int id_tipo_movimiento)
        {
            inv.fecha = DateTime.Now;
            ViewBag.mensajereg = _service.Crear(inv, id_tipo_movimiento) ? "Movimiento registrado correctamente" : "Se excede el inventario";
            ViewBag.ingredientes = _service.GetAllIngredientes();
            return View();
        }

        public IActionResult Consultar()
        {
            List<Inventario> lista = _service.GetAll();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Actualizar(int? id_buscar)
        {
            ViewBag.ingredientes = _service.GetAllIngredientes();
            if (!id_buscar.HasValue)
                return View();

            Inventario inv = _service.GetById(id_buscar.Value);
            if (inv == null)
            {
                ViewBag.mensaje = "Movimiento no encontrado";
            }
            else
            {
                return View(inv);
            }
            return View();
        }

        [HttpPost]
        public IActionResult Actualizar(Inventario inv)
        {
            inv.fecha = DateTime.Now;
            _service.Update(inv);
            ViewBag.mensajeExito = "Movimiento actualizado correctamente";
            ViewBag.ingredientes = _service.GetAllIngredientes();
            return View();
        }

        public IActionResult Eliminar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            bool flag = _service.Delete(id);
            if (!flag)
            {
                ViewBag.mensajeEliminar = "Movimiento no encontrado";
            }
            else
            {
                ViewBag.mensajeEliminarExito = "Movimiento eliminado correctamente";
            }
            return View();
        }
    }
}
