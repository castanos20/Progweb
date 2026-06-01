using Proyecto_Polleria.Models;
using Proyecto_Polleria.Repository;

namespace Proyecto_Polleria.Services
{
    public class InventarioService
    {
        private readonly InventarioRepository repository;
        private readonly IngredienteRepository ingredienteRepo;

        public InventarioService(InventarioRepository repository, IngredienteRepository ingredienteRepo)
        {
            this.repository = repository;
            this.ingredienteRepo = ingredienteRepo;
        }

        public bool Crear(Inventario inv, int id_tipo_movimiento)
        {
            if (id_tipo_movimiento == 1)
            {
                repository.create(inv);
                return true;
            }
            double totalinv = repository.TotalInventario(inv.id_ingrediente);
            if (totalinv - inv.cantidad < 0)
            {
                return false;
            }
            repository.create(inv);
            return true;
        }

        public List<Inventario> GetAll()
        {
            return repository.GetAll();
        }

        public Inventario GetById(int id)
        {
            return repository.GetById(id);
        }

        public void Update(Inventario inv)
        {
            repository.update(inv);
        }

        public bool Delete(int id)
        {
            int filasAfectadas = repository.delete(id);
            return filasAfectadas > 0;
        }

        public List<Inventario> GetByIdCompra(int id_compra)
        {
            return repository.GetByIdCompra(id_compra);
        }

        public List<Ingrediente> GetAllIngredientes()
        {
            return ingredienteRepo.GetAll();
        }
    }
}
