namespace Proyecto_Polleria.Models
{
    public class Pedido
    {
        public int id { get; set; }
        public string novedad { get; set; }
        public decimal precio { get; set; }
        public int id_proceso { get; set; }
        public string id_cocinero { get; set; }
        public int id_servicio { get; set; }
        public int id_plato { get; set; }

        public Pedido() { }
        public Pedido(int id, string novedad, decimal precio,
                      int id_proceso, string id_cocinero, int id_servicio, int id_plato)
        {
            this.id = id;
            this.novedad = novedad;
            this.precio = precio;
            this.id_proceso = id_proceso;
            this.id_cocinero = id_cocinero;
            this.id_servicio = id_servicio;
            this.id_plato = id_plato;
        }
    }
}
