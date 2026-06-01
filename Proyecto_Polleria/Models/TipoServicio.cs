namespace Proyecto_Polleria.Models
{
    public class TipoServicio
    {
        public int id { get; set; }
        public string tipo { get; set; }

        public TipoServicio() { }
        public TipoServicio(int id, string tipo)
        {
            this.id = id;
            this.tipo = tipo;
        }
    }
}
