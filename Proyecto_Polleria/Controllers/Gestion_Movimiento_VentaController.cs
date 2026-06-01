using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto_Polleria.Models;
using Proyecto_Polleria.Models.temp;
using Proyecto_Polleria.Services;

namespace Proyecto_Polleria.Controllers
{
    public class Gestion_Movimiento_VentaController : Controller
    {
        public readonly MesaService mesaService;
        public readonly TrabajadorService trabajadorService;
        public readonly Registrar_IngresoService servicioService;
        public readonly ProcesoService procesoService;
        public readonly PlatoService platoService;
        public readonly PedidoService pedidoService;

        public Gestion_Movimiento_VentaController(MesaService mesaService, TrabajadorService trabajadorService, Registrar_IngresoService ris, ProcesoService procesoService, PlatoService platoService, PedidoService pedidoService)
        {
            this.servicioService = ris;
            this.mesaService = mesaService;
            this.trabajadorService = trabajadorService;
            this.procesoService = procesoService;
            this.platoService = platoService;
            this.pedidoService = pedidoService;
        }

        [HttpGet]
        public IActionResult Registrar_Ingreso()
        {
            List<Mesa> mesas = mesaService.MesaLibres();
            List<Trabajador> meseros = trabajadorService.GetAllMesero();
            ViewBag.Mesas = mesas;
            ViewBag.Meseros = meseros;
            ViewBag.Mesas = new SelectList(mesas, "id", "DescripcionMesa");
            ViewBag.Meseros = new SelectList(meseros, "cc", "nombre");
            return View();
        }
        [HttpPost]
        public IActionResult Registrar_Ingreso(Registrar_IngresoTemp tmp)
        {
            Servicio servicio = new Servicio();
            servicio.id_mesa = tmp.id_mesa;
            servicio.id_agenteservicio = tmp.id_agentesevicio;
            servicio.id_cliente = tmp.id_cliente;
            servicioService.Crear(servicio);
            return RedirectToAction("Registrar_Ingreso");
        }
        [HttpGet]
        public IActionResult Registrar_Pedido()
        {
            List<Proceso> procesos = procesoService.GetAll();
            List<Trabajador> cocineros = trabajadorService.GetAllCocineros();
            List<Servicio> servicios = servicioService.GetAll()
                                         .Where(s => s.hora_salida == null)
                                         .ToList();
            List<Plato> platos = platoService.GetAll();
            ViewBag.Servicios = new SelectList(servicios, "id", "DescripcionServicio");
            ViewBag.Platos = new SelectList(platos, "id", "nombre");
            ViewBag.Cocineros = new SelectList(cocineros, "cc", "nombre");
            ViewBag.Procesos = new SelectList(procesos, "id", "descripcion");
            return View();
        }

        [HttpPost]
        public IActionResult Registrar_Pedido(Registrar_PedidoTemp tmp)
        {
            Pedido pedido = new Pedido();
            pedido.novedad = tmp.novedad;
            pedido.id_proceso = tmp.id_proceso;
            pedido.id_cocinero = tmp.id_cocinero;
            pedido.id_servicio = tmp.id_servicio;
            pedido.id_plato = tmp.id_plato;
            pedidoService.Crear(pedido);
            return RedirectToAction("Registrar_Pedido");
        }
        [HttpGet]
        public IActionResult Registrar_Salida()
        {
            Servicio servicio = new Servicio();
            List<Servicio> servicios = servicioService.GetAll()
                                         .Where(s => s.hora_salida == null)
                                         .ToList();
            ViewBag.Servicios = new SelectList(servicios, "id", "DescripcionServicio");
            return View();
        }
        [HttpPost]
        public IActionResult Registrar_Salida(Servicio ser)
        {
            ViewBag.TotalServicio = servicioService.TotalPedido(ser.id);
            List<Servicio> servicios = servicioService.GetAll()
                                         .Where(s => s.hora_salida == null)
                                         .ToList();
            ViewBag.Servicios = new SelectList(servicios, "id", "DescripcionServicio");
            return View(ser);
        }
        [HttpPost]
        public IActionResult ConfirmarSalida(Servicio ser)
        {
            Servicio serv = new Servicio();
            serv.id = ser.id;
            servicioService.RegistrarSalida(serv);
            return RedirectToAction("Registrar_Salida");

        }
        [HttpGet]
        public IActionResult Consultar_Servicios()
        {
            List<Servicio> historial = servicioService.GetHistorialServicios();
            return View(historial);
        }
    }
}
