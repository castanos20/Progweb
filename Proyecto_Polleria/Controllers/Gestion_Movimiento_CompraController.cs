using Microsoft.AspNetCore.Mvc;
using Proyecto_Polleria.Models;
using Proyecto_Polleria.Models.temp;
using Proyecto_Polleria.Services;
using System.Text.Json;

namespace Proyecto_Polleria.Controllers
{
    public class Gestion_Movimiento_CompraController : Controller
    {

        private static Movimiento_CompraTemp mct = new Movimiento_CompraTemp();
        private readonly InventarioService _service1;
        private readonly Movimiento_CompraService _service2;

        public Gestion_Movimiento_CompraController(InventarioService service1, Movimiento_CompraService service2)
        {
            _service1 = service1;
            _service2 = service2;
        }
        [HttpGet]
        public IActionResult Registrar() {
            mct.ingredientes = _service1.GetAllIngredientes();
            mct.Estado = false;
            return View(mct); 
        }
        [HttpPost]
        public IActionResult Registrar(Movimiento_CompraTemp nuevo)
        {
            mct.mc = nuevo.mc;
            mct.ingredientes = _service1.GetAllIngredientes();
            mct.Estado = true;
            return View(mct);
        }

        [HttpPost]
        public IActionResult AgregarPedido(int id_ingrediente, double cantidad, double precio_unitario, int id_tipo_movimiento)
        {
            DateTime fecha = DateTime.Now;
            Inventario inv = new Inventario(fecha, cantidad, precio_unitario, id_tipo_movimiento, id_ingrediente);
            string nombre = _service1.GetAllIngredientes().Where(x => x.id == id_ingrediente).FirstOrDefault()?.nombre;
            Console.WriteLine("ingrediente: " +nombre);
            inv.nombre_ingrediente = nombre;
            mct.pedidos.Add(inv);
            mct.ingredientes = _service1.GetAllIngredientes();
            return View("Registrar", mct);
        }
        [HttpPost]
        public IActionResult Confirmar()
        {
            Movimiento_Compra mc = mct.mc;
            mc.inventarios = mct.pedidos.ToArray();
            _service2.Crear(mc);
            mct = new Movimiento_CompraTemp();
            return Redirect("Registrar");
        }
        public IActionResult Consultar()
        {
            var lista = _service2.GetAll();
            return View(lista);
        }

        public IActionResult DetallePedidos(int id)
        {
            var pedidos = _service1.GetByIdCompra(id);
            ViewBag.id_compra = id;
            return View(pedidos);
        }

        [HttpGet]
        public IActionResult Actualizar(int? id)
        {
            if (id == null) return View(null);
            var compra = _service2.GetById(id.Value);
            if (compra == null) ViewBag.mensaje = "No se encontró la compra con ese ID.";
            return View(compra);
        }

        [HttpPost]
        public IActionResult Actualizar(Movimiento_Compra compra)
        {
            _service2.Update(compra);
            ViewBag.mensaje = "Compra actualizada correctamente.";
            return View(compra);
        }

        [HttpGet]
        public IActionResult Eliminar(int? id)
        {
            if (id == null) return View(null);
            var compra = _service2.GetById(id.Value);
            if (compra == null) ViewBag.mensaje = "No se encontró la compra con ese ID.";
            return View(compra);
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            _service2.Delete(id);
            ViewBag.mensaje = "Compra eliminada correctamente.";
            return View(null);
        }
    }
}
