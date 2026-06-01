using Proyecto_Polleria.Models;
using Proyecto_Polleria.Repository;

namespace Proyecto_Polleria.Services
{
    public class ProveedorService
    {
        private readonly ProveedorRepository repository;

        public ProveedorService(ProveedorRepository repository)
        {
            this.repository = repository;
        }

        public bool Crear(Proveedor prov)
        {
            if (repository.GetById(prov.nit) == null)
            {
                repository.create(prov);
                return true;
            }
            return false;
        }

        public List<Proveedor> GetAll()
        {
            return repository.GetAll();
        }

        public Proveedor GetById(string nit)
        {
            return repository.GetById(nit);
        }

        public void Update(Proveedor prov)
        {
            repository.update(prov);
        }

        public bool Delete(string nit)
        {
            int filasAfectadas = repository.delete(nit);
            if (filasAfectadas == 0)
            {
                return false;
            }
            return true;
        }
    }
}
