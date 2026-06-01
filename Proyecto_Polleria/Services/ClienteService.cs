using Proyecto_Polleria.Models;
using Proyecto_Polleria.Repository;

namespace Proyecto_Polleria.Services
{
    public class ClienteService
    {
        private readonly ClienteRepository repository;

        public ClienteService(ClienteRepository repository)
        {
            this.repository = repository;
        }

        public bool Crear(Cliente clie)
        {
            if (repository.GetById(clie.cc) == null)
            {
                repository.create(clie);
                return true;
            }
            return false;
        }

        public List<Cliente> GetAll()
        {
            return repository.GetAll();
        }
        public Cliente GetById(string cc)
        {
            return repository.GetById(cc);
        }

        public void Update(Cliente cli)
        {
            repository.update(cli);
        }
        public bool Delete(string cc)
        {
            int filasAfectadas = repository.delete(cc);
            if (filasAfectadas == 0)
            {
                return false;
            }
            return true;
        }
    }
}
