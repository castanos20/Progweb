namespace Proyecto_Polleria.Models
{
    public class Servicio
    {
        public int id { get; set; }
        public DateTime hora_ingreso { get; set; }
        public DateTime? hora_salida { get; set; }
        public int id_mesa { get; set; }
        public string id_agenteservicio { get; set; }
        public int id_tipo_servicio { get; set; }
        public string id_cliente { get; set; }

        public string DescripcionServicio => $"Mesa {id_mesa} cc {id_cliente} ";

        public Servicio() { }
        public Servicio(int id, DateTime hora_ingreso, DateTime hora_salida,
                        int id_mesa, string id_agenteservicio, int id_tipo_servicio, string id_cliente)
        {
            this.id = id;
            this.hora_ingreso = hora_ingreso;
            this.hora_salida = hora_salida;
            this.id_mesa = id_mesa;
            this.id_agenteservicio = id_agenteservicio;
            this.id_tipo_servicio = id_tipo_servicio;
            this.id_cliente = id_cliente;
        }
    }
}
