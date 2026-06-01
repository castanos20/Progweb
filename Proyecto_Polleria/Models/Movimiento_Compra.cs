namespace Proyecto_Polleria.Models
{
    public class Movimiento_Compra
    {
        public int id { get; set; }
        public string id_proveedor { get; set; }
        public string descripcion { get; set; }
        public int id_metodo_pago { get; set; } //1-Efectivo, 2-Tarjeta débito, 3-Tarjeta crédito, 4-Transferencia.1-Efectivo, 2-Tarjeta débito, 3-Tarjeta crédito, 4-Transferencia.
        public Inventario[] inventarios { get; set; }
        public Movimiento_Compra() { }

        public Movimiento_Compra(string nit_proveedor, string descripcion, int metodo_pago, Inventario[] inventarios)
        {
            this.id_proveedor = nit_proveedor;
            this.descripcion = descripcion;
            this.id_metodo_pago = metodo_pago;
            this.inventarios = inventarios;
        }
        public Movimiento_Compra(string nit_proveedor, string descripcion, int metodo_pago)
        {
            this.id_proveedor = nit_proveedor;
            this.descripcion = descripcion;
            this.id_metodo_pago = metodo_pago;
        }


    }
    
}
