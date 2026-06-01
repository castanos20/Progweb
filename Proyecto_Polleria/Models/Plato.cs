namespace Proyecto_Polleria.Models
{
    public class Plato
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }
        public string descripcion { get; set; }

        public Plato() { }
        public Plato(int id, string nombre, decimal precio, string descripcion)
        {
            this.id = id;
            this.nombre = nombre;
            this.precio = precio;
            this.descripcion = descripcion;
        }
    }
}
