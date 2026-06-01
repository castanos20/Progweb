using Proyecto_Polleria.Data;
using Proyecto_Polleria.Models;
using Dapper;
namespace Proyecto_Polleria.Repository
{
    public class Movimiento_CompraRepository
    {
        private readonly Conexion db;

        public Movimiento_CompraRepository(Conexion db)
        {
            this.db = db;
        }

        public int create(Movimiento_Compra compra)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = "INSERT INTO compra (descripcion, id_metodo_pago, id_proveedor) VALUES (@descripcion, @id_metodo_pago, @id_proveedor) RETURNING id";
                return conn.ExecuteScalar<int>(sql, compra);
            }
        }

        public List<Movimiento_Compra> GetAll()
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = "SELECT * FROM compra";
                return conn.Query<Movimiento_Compra>(sql).ToList();
            }
        }

        public Movimiento_Compra GetById(int id)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = "SELECT * FROM compra WHERE id = @id";
                return conn.QueryFirstOrDefault<Movimiento_Compra>(sql, new { id });
            }
        }

        public void update(Movimiento_Compra compra)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = "UPDATE compra SET descripcion = @descripcion, id_metodo_pago = @id_metodo_pago WHERE id = @id";
                conn.Execute(sql, compra);
            }
        }

        public int delete(int id)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = "DELETE FROM compra WHERE id = @id";
                return conn.Execute(sql, new { id });
            }
        }
    }
}