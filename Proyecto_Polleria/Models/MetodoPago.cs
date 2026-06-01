namespace Proyecto_Polleria.Models
{
    public class MetodoPago
    {
        public int id { get; set; }
        public string metodo { get; set; }

        public MetodoPago() { }
        public MetodoPago(int id, string metodo)
        {
            this.id = id;
            this.metodo = metodo;
        }
    }
}
