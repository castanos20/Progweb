using Proyecto_Polleria.Models;
using Proyecto_Polleria.Models.temp;
using Proyecto_Polleria.Repository;
using System.Collections.Generic;

namespace Proyecto_Polleria.Services
{
    public class Registrar_IngresoService
    {
        private readonly Registrar_IngresoRepository repository;

        public Registrar_IngresoService(Registrar_IngresoRepository repository)
        {
            this.repository = repository;
        }

        public bool Crear(Servicio servicio)
        {
            if (repository.GetById(servicio.id) == null)
            {
                repository.Create(servicio);
                return true;
            }
            return false;
        }

        public List<Servicio> GetAll()
        {
            return repository.GetAll();
        }

        public Servicio GetById(int id)
        {
            return repository.GetById(id);
        }

        public void Update(Servicio servicio)
        {
            repository.Update(servicio);
        }

        public bool Delete(int id)
        {
            int filasAfectadas = repository.Delete(id);
            if (filasAfectadas == 0)
            {
                return false;
            }
            return true;
        }
        public double TotalPedido(int id)
        {
            List<Pedido> pedidos = repository.GetPedidos(id);
            return (double)pedidos.Sum(p => p.precio);
        }
        public int RegistrarSalida(Servicio serv)
        {
            return repository.ActualizarSalida(serv);
        }
        public List<Servicio> GetHistorialServicios()
        {
            return repository.GetHistorial();
        }
        public List<DetallePedidoTemp> GetDetallesPorServicio(int idServicio)
        {
            return repository.GetDetallesPorServicio(idServicio);
        }
    }
}