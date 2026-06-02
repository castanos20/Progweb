namespace Proyecto_Polleria.Models.temp
{
    public class Grafico_CompraTemp
    {
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
        public string periodo { get; set; }

        public List<string> periodos { get; set; }
        public List<decimal> total_ingresos { get; set; }
        public List<long> cantidad_pedidos { get; set; }
    }
}
