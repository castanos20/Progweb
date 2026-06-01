using Proyecto_Polleria.Models;
using Proyecto_Polleria.Repository;

namespace Proyecto_Polleria.Services
{
    public class MesaService
    {
        private readonly MesaRepository repository;

        public MesaService(MesaRepository repository)
        {
            this.repository = repository;
        }

        public bool Crear(Mesa mesa)
        {
            repository.create(mesa);
            return true;
        }

        public List<Mesa> GetAll()
        {
            return repository.GetAll();
        }

        public Mesa GetById(int id)
        {
            return repository.GetById(id);
        }

        public void Update(Mesa mesa)
        {
            repository.update(mesa);
        }

        public bool Delete(int id)
        {
            int filasAfectadas = repository.delete(id);
            return filasAfectadas > 0;
        }

        public List<Mesa> MesaLibres()
        {
            return repository.mesalibre();
        }
    }
}