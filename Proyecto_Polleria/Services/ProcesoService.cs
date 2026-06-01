using Proyecto_Polleria.Models;
using Proyecto_Polleria.Repository;
using System.Collections.Generic;

namespace Proyecto_Polleria.Services
{
    public class ProcesoService
    {
        private readonly ProcesoRepository repository;

        public ProcesoService(ProcesoRepository repository)
        {
            this.repository = repository;
        }

        public bool Crear(Proceso proceso)
        {
            if (repository.GetById(proceso.id) == null)
            {
                repository.Create(proceso);
                return true;
            }
            return false;
        }

        public List<Proceso> GetAll()
        {
            return repository.GetAll();
        }

        public Proceso GetById(int id)
        {
            return repository.GetById(id);
        }

        public void Update(Proceso proceso)
        {
            repository.Update(proceso);
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