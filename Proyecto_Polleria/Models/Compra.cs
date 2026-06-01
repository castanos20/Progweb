namespace Proyecto_Polleria.Models
{
    public class Compra

    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public int id_metodo_pago { get; set; }
        public string id_proveedor { get; set; }
    }
}