using Proyecto_Polleria.Models;
using Proyecto_Polleria.Repository;
using System.Collections.Generic;

namespace Proyecto_Polleria.Services
{
    public class PedidoService
    {
        private readonly PedidoRepository repository;

        public PedidoService(PedidoRepository repository)
        {
            this.repository = repository;
        }

        public bool Crear(Pedido pedido)
        {
            
            
                repository.Create(pedido);
                return true;
            
            return false;
        }

        public List<Pedido> GetAll()
        {
            return repository.GetAll();
        }

        public Pedido GetById(int id)
        {
            return repository.GetById(id);
        }

        public void Update(Pedido pedido)
        {
            repository.Update(pedido);
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
    }
}