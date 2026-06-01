namespace Proyecto_Polleria.Models
{
    public class Trabajador
    {
        public string cc {  get; set; }
        public string nombre { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public double salario { get; set; }
        public int rol {  get; set; }

        public Trabajador() { }
        public Trabajador(string cc, string nombre, string telefono,
                      string direccion, double salario, int rol)
        {
            this.cc = cc;
            this.nombre = nombre;
            this.telefono = telefono;
            this.direccion = direccion;
            this.salario = salario;
            this.rol = rol;
        }


    }
}
