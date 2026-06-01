namespace Proyecto_Polleria.Models.temp
{
    public class MonitoreoCocinaTemp
    {
        public int id_pedido { get; set; }
        public int id_mesa { get; set; }
        public string nombre_plato { get; set; }
        public string novedad { get; set; }
        public string estado_proceso { get; set; }
        public int id_proceso { get; set; }
        public DateTime hora_ingreso { get; set; }
    }
}