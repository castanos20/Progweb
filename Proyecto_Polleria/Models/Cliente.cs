namespace Proyecto_Polleria.Models
{
    public class Cliente
    {
        public string cc {  get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }

        public Cliente() { }
        public Cliente(string cc, string nombre, string telefono, string direccion)
        {
            this.cc = cc;
            this.nombre = nombre;
            this.telefono = telefono;
            this.direccion = direccion;
        }
    }

}
