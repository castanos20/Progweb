using Npgsql;
namespace Proyecto_Polleria.Data
{
    public class Conexion
    {
        private readonly string connectionString;

        public Conexion(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connectionString);
        }
    }
}
