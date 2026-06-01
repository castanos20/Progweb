using Proyecto_Polleria.Models;
using Proyecto_Polleria.Repository;
using System.Collections.Generic;

namespace Proyecto_Polleria.Services
{
    public class PlatoService
    {
        private readonly PlatoRepository repository;

        public PlatoService(PlatoRepository repository)
        {
            this.repository = repository;
        }

        public bool Crear(Plato plato)
        {
            if (repository.GetById(plato.id) == null)
            {
                repository.Create(plato);
                return true;
            }
            return false;
        }

        public List<Plato> GetAll()
        {
            return repository.GetAll();
        }

        public Plato GetById(int id)
        {
            return repository.GetById(id);
        }

        public void Update(Plato plato)
        {
            repository.Update(plato);
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