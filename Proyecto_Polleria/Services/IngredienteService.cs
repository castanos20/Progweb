using Proyecto_Polleria.Models;
using Proyecto_Polleria.Repository;

namespace Proyecto_Polleria.Services
{
    public class IngredienteService
    {
        private readonly IngredienteRepository repository;

        public IngredienteService(IngredienteRepository repository)
        {
            this.repository = repository;
        }

        public void Crear(Ingrediente ing)
        {
            repository.create(ing);
        }

        public List<Ingrediente> GetAll()
        {
            return repository.GetAll();
        }

        public Ingrediente GetById(int id)
        {
            return repository.GetById(id);
        }

        public void Update(Ingrediente ing)
        {
            repository.update(ing);
        }

        public bool Delete(int id)
        {
            int filasAfectadas = repository.delete(id);
            return filasAfectadas > 0;
        }
    }
}
