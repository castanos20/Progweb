using System;

namespace Proyecto_Polleria.Models
{
    public class Inventario
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public double cantidad { get; set; }
        public double precio_unitario { get; set; }
        public int id_tipo_movimiento { get; set; } // 1 = Ingreso, 2 = Salida
        public int id_ingrediente { get; set; }
        public int? id_compra { get; set; }

        // Additional properties for display
        public string? nombre_ingrediente { get; set; }
        public string? tipo_movimiento_desc { get; set; }

        public Inventario() { }

        public Inventario(int id, DateTime fecha, double cantidad, double precio_unitario, int id_tipo_movimiento, int id_ingrediente, int? id_compra)
        {
            this.id = id;
            this.fecha = fecha;
            this.cantidad = cantidad;
            this.precio_unitario = precio_unitario;
            this.id_tipo_movimiento = id_tipo_movimiento;
            this.id_ingrediente = id_ingrediente;
            this.id_compra = id_compra;
        }
        public Inventario( DateTime fecha, double cantidad, double precio_unitario, int id_tipo_movimiento, int id_ingrediente)
        {
            
            this.fecha = fecha;
            this.cantidad = cantidad;
            this.precio_unitario = precio_unitario;
            this.id_tipo_movimiento = id_tipo_movimiento;
            this.id_ingrediente = id_ingrediente;
            this.id_compra = id_compra;
        }
    }
}
