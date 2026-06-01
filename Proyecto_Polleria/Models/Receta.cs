namespace Proyecto_Polleria.Models
{
    public class Receta
    {
        public int id { get; set; }
        public string unidad_medida { get; set; }
        public decimal cantidad { get; set; }
        public int id_plato { get; set; }
        public int id_ingrediente { get; set; }

        public Receta() { }
        public Receta(int id, string unidad_medida, decimal cantidad, int id_plato, int id_ingrediente)
        {
            this.id = id;
            this.unidad_medida = unidad_medida;
            this.cantidad = cantidad;
            this.id_plato = id_plato;
            this.id_ingrediente = id_ingrediente;
        }
    }
}
