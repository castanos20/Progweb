using Proyecto_Polleria.Models;
using Proyecto_Polleria.Models.temp;
using Proyecto_Polleria.Models.tempGraficos;
using Proyecto_Polleria.Repository;
using System.Collections.Generic;

namespace Proyecto_Polleria.Services
{
    public class PedidoService
    {
        private readonly PedidoRepository repository;

        public PedidoService(PedidoRepository repository)
        {
            this.repository = repository;
        }

        public bool Crear(Pedido pedido)
        {
            
            
                repository.Create(pedido);
                return true;
            
            return false;
        }

        public List<Pedido> GetAll()
        {
            return repository.GetAll();
        }

        public Pedido GetById(int id)
        {
            return repository.GetById(id);
        }

        public void Update(Pedido pedido)
        {
            repository.Update(pedido);
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
        public List<Pedido> PedidosMesa(int id)
        {
            return repository.PedidosMesa(id);
        }
        public int ActualizaEstado(Pedido tmp)
        {
            return repository.ActualizaEstado(tmp);
        }
        public Grafico_VentaTemp ObtenerTendencia(Grafico_VentaTemp tmp)
        {
            List<GraficoVentaTendVolu> gtv = repository.ObtenerTendencia(tmp);
            Grafico_VentaTemp grafico_VentaTemp = new Grafico_VentaTemp();
            
            
            grafico_VentaTemp.fecha_inicio = tmp.fecha_inicio;
            grafico_VentaTemp.fecha_fin = tmp.fecha_fin;
            grafico_VentaTemp.periodo = tmp.periodo;

           
            string formato = tmp.periodo switch
            {
                "hora" => "yyyy-MM-dd HH:mm",
                "dia" => "yyyy-MM-dd",
                "semana" => "yyyy-MM-dd",
                "mes" => "yyyy-MM",
                _ => "yyyy-MM-dd"
            };

            grafico_VentaTemp.periodos = gtv.Select(x => x.periodo.ToString(formato)).ToList();
            grafico_VentaTemp.total_ingresos = gtv.Select(x => x.total_ingresos).ToList();
            grafico_VentaTemp.cantidad_pedidos = gtv.Select(x => x.cantidad_pedidos).ToList();
            return grafico_VentaTemp;
        }
    }
}