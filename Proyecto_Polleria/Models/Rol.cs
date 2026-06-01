namespace Proyecto_Polleria.Models
{
    public class Rol
    {
        public int id { get; set; }
        public string nombre { get; set; }

        public Rol() { }
        public Rol(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }
    }
}
