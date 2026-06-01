namespace Proyecto_Polleria.Models
{
    public class Ingrediente
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string unidad_medida { get; set; }

        public Ingrediente() { }

        public Ingrediente(int id, string nombre, string descripcion, string unidad_medida)
        {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.unidad_medida = unidad_medida;
        }
    }
}
