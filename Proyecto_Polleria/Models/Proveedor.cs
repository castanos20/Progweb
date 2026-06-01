namespace Proyecto_Polleria.Models
{
    public class Proveedor
    {
        public string nit { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }

        public Proveedor() { }

        public Proveedor(string nit, string nombre, string direccion, string telefono)
        {
            this.nit = nit;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
        }
    }
}
