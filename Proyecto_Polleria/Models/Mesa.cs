namespace Proyecto_Polleria.Models
{
    public class Mesa
    {
        public int id { get; set; }
        public int nro_sillas { get; set; }
        public string DescripcionMesa => $"Mesa {id} tiene {nro_sillas} sillas";
        public Mesa() { }
        public Mesa(int id, int nro_sillas)
        {
            this.id = id;
            this.nro_sillas = nro_sillas;
        }
    }
}
