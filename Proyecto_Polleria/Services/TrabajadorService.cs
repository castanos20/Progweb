using Proyecto_Polleria.Models;
using Proyecto_Polleria.Repository;

namespace Proyecto_Polleria.Services
{
    public class TrabajadorService
    {
        private readonly TrabajadorRepository repository;

        public TrabajadorService(TrabajadorRepository repository)
        {
            this.repository = repository;
        }

        public bool CrearTrabajador(Trabajador traba)
        {
            if (repository.GetById(traba.cc)==null)
            {
                repository.create(traba);
                return true;
            }
            return false;
        }

        public List<Trabajador> GetAllTrabajadors() { 
            return repository.GetAll();
        }
        public Trabajador GetById(string cc) 
        { 
            return repository.GetById(cc);
        }

        public void Update(Trabajador traba) 
        { 
            repository.upgrate(traba);
        }
        public bool Delete(string cc) 
        {
            int filasAfectadas = repository.delete(cc);
            if (filasAfectadas==0)
            {
                return false;
            }
            return true;
        }

        public List<Trabajador> GetAllMesero() { 
            return repository.GetAllMesero();
        }
        public List<Trabajador> GetAllCocineros()
        {
            return repository.GetAllCocineros();
        }
    }
}
