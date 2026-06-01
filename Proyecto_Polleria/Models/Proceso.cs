namespace Proyecto_Polleria.Models
{
    public class Proceso
    {
        public int id { get; set; }
        public string descripcion { get; set; }

        public Proceso() { }
        public Proceso(int id, string descripcion)
        {
            this.id = id;
            this.descripcion = descripcion;
        }
    }
}
