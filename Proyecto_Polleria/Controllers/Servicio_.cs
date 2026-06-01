using System;

namespace Proyecto_Polleria.Models
{
    public class Servicio_
    {
        public int id { get; set; }

        public DateTime hora_ingreso { get; set; }

        // El '?' permite que sea NULL en C#, ya que al ingresar el cliente la hora de salida está vacía
        public DateTime? hora_salida { get; set; }

        public int id_mesa { get; set; }

        public string id_agenteservicio { get; set; }

        public int id_tipo_servicio { get; set; }

        public string id_cliente { get; set; }
    }
}