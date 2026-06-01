using Dapper;
using Proyecto_Polleria.Data;
using Proyecto_Polleria.Models;

namespace Proyecto_Polleria.Repository
{
    public class ClienteRepository
    {
        private readonly Conexion db;
        public ClienteRepository(Conexion conexion) { 
            this.db = conexion;
        }
        public void create(Cliente cli) {
            using (var conn=db.GetConnection())
            {
                conn.Open();
                var sql = "INSERT INTO cliente (cc,nombre,telefono, direccion) VALUES (@cc,@nombre,@telefono,@direccion)";
                conn.Execute(sql,cli);
            }
        }
        public List<Cliente> GetAll()
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = "SELECT * FROM cliente";
                return conn.Query<Cliente>(sql).ToList();
            }
        }
        public Cliente GetById(string cc) {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = "SELECT * FROM cliente WHERE cc=@cc";
                return conn.QueryFirstOrDefault<Cliente>(sql, new {cc});
            }
        }
        public void update(Cliente cli) {

            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = "UPDATE cliente SET nombre = @nombre, telefono = @telefono,direccion = @direccion WHERE cc = @cc;";
                conn.Execute(sql,cli);
            }

        }
        public int delete(string cc) {

            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = "DELETE FROM cliente WHERE cc = @cc";
                return conn.Execute(sql, new { cc });

            }
        }
    }
}
