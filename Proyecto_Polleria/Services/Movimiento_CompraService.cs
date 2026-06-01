using Proyecto_Polleria.Models;
using Proyecto_Polleria.Repository;

namespace Proyecto_Polleria.Services
{
    public class Movimiento_CompraService
    {
        private readonly Movimiento_CompraRepository repository;
        private readonly InventarioRepository repository2;

        public Movimiento_CompraService(Movimiento_CompraRepository repository, InventarioRepository repository2)
        {
            this.repository = repository;
            this.repository2 = repository2;
        }

        public bool Crear(Movimiento_Compra compra)
        {
            int metodoPago = compra.id_metodo_pago;
            metodoPago=metodoPago;
            int id_compra = repository.create(compra);
            foreach (var i in compra.inventarios)
            {
                i.id_compra = id_compra;
                i.id_tipo_movimiento = 1;
                repository2.create(i);
            }
            return true;
        }

        public List<Movimiento_Compra> GetAll()
        {
            return repository.GetAll();
        }

        public Movimiento_Compra GetById(int id)
        {
            return repository.GetById(id);
        }

        public void Update(Movimiento_Compra compra)
        {
            repository.update(compra);
        }

        public bool Delete(int id)
        {
            int filasAfectadas = repository.delete(id);
            if (filasAfectadas == 0)
            {
                return false;
            }
            return true;
        }
    }
}