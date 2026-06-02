using Proyecto_Polleria.Models;
using Proyecto_Polleria.Models.temp;
using Proyecto_Polleria.Models.tempGraficos;
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
        public Grafico_CompraTemp ObtenerTendencia(Grafico_CompraTemp tmp)
        {
            List<GraficoCompraTendVolu> gtv = repository.ObtenerTendencia(tmp);
            Grafico_CompraTemp grafico_CompraTemp = new Grafico_CompraTemp();


            grafico_CompraTemp.fecha_inicio = tmp.fecha_inicio;
            grafico_CompraTemp.fecha_fin = tmp.fecha_fin;
            grafico_CompraTemp.periodo = tmp.periodo;


            string formato = tmp.periodo switch
            {
                "hora" => "yyyy-MM-dd HH:mm",
                "dia" => "yyyy-MM-dd",
                "semana" => "yyyy-MM-dd",
                "mes" => "yyyy-MM",
                _ => "yyyy-MM-dd"
            };

            grafico_CompraTemp.periodos = gtv.Select(x => x.periodo.ToString(formato)).ToList();
            grafico_CompraTemp.total_ingresos = gtv.Select(x => x.total_ingresos).ToList();
            grafico_CompraTemp.cantidad_pedidos = gtv.Select(x => x.cantidad_pedidos).ToList();
            return grafico_CompraTemp;
        }
    }
}
