namespace Proyecto_Polleria.Models.temp
{
    public class Movimiento_CompraTemp
    {
        public Movimiento_Compra mc { get; set; }
        public List<Ingrediente> ingredientes { get; set; }
        public List<Inventario> pedidos { get; set; }
        public bool Estado { get; set; }

        public Movimiento_CompraTemp()
        {
            ingredientes=new List<Ingrediente>();
            pedidos = new List<Inventario>();
        }
    }
}
