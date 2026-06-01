using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto_Polleria.Models;
using Proyecto_Polleria.Models.temp;
using Proyecto_Polleria.Services;

namespace Proyecto_Polleria.Controllers
{
    public class Gestion_Movimiento_VentaController:Controller
    {
        public readonly MesaService mesaService;
        public readonly TrabajadorService trabajadorService;
        public readonly Registrar_IngresoService servicioService;
        public Gestion_Movimiento_VentaController(MesaService mesaService, TrabajadorService trabajadorService, Registrar_IngresoService ris)         
        {   
            this.servicioService= ris;
             this.mesaService = mesaService;
            this.trabajadorService = trabajadorService;
        }

        [HttpGet]
        public IActionResult Registrar_Ingreso() {
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
            servicio.id_cliente=tmp.id_cliente;
            servicioService.Crear(servicio);
            return RedirectToAction("Registrar_Ingreso");
        }
    }
}
