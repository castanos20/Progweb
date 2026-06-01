using Dapper;
using Proyecto_Polleria.Data;
using Proyecto_Polleria.Models;

namespace Proyecto_Polleria.Repository
{
    public class InventarioRepository
    {
        private readonly Conexion db;

        public InventarioRepository(Conexion db)
        {
            this.db = db;
        }

        public void create(Inventario inv)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = @"INSERT INTO movimiento_inventario (fecha, cantidad, precio_unitario, id_tipo_movimiento, id_ingrediente, id_compra) 
                            VALUES (@fecha, @cantidad, @precio_unitario, @id_tipo_movimiento, @id_ingrediente, @id_compra)";
                conn.Execute(sql, inv);
            }
        }

        public List<Inventario> GetAll()
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = @"SELECT m.id, m.fecha::timestamp, m.cantidad, m.precio_unitario, m.id_tipo_movimiento, m.id_ingrediente, m.id_compra,
                                   i.nombre AS nombre_ingrediente, t.descripcion AS tipo_movimiento_desc
                            FROM movimiento_inventario m
                            INNER JOIN ingrediente i ON m.id_ingrediente = i.id
                            INNER JOIN tipo_movimiento t ON m.id_tipo_movimiento = t.id
                            ORDER BY m.fecha DESC, m.id DESC";
                return conn.Query<Inventario>(sql).ToList();
            }
        }

        public Inventario GetById(int id)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = @"SELECT m.id, m.fecha::timestamp, m.cantidad, m.precio_unitario, m.id_tipo_movimiento, m.id_ingrediente, m.id_compra,
                                   i.nombre AS nombre_ingrediente, t.descripcion AS tipo_movimiento_desc
                            FROM movimiento_inventario m
                            INNER JOIN ingrediente i ON m.id_ingrediente = i.id
                            INNER JOIN tipo_movimiento t ON m.id_tipo_movimiento = t.id
                            WHERE m.id = @id";
                return conn.QueryFirstOrDefault<Inventario>(sql, new { id });
            }
        }

        public List<Inventario> GetByIdCompra(int id_compra)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = @"SELECT m.id, m.fecha::timestamp, m.cantidad, m.precio_unitario, m.id_tipo_movimiento, m.id_ingrediente, m.id_compra,
                                   i.nombre AS nombre_ingrediente
                            FROM movimiento_inventario m
                            INNER JOIN ingrediente i ON m.id_ingrediente = i.id
                            WHERE m.id_compra = @id_compra";
                return conn.Query<Inventario>(sql, new { id_compra }).ToList();
            }
        }

        public void update(Inventario inv)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = @"UPDATE movimiento_inventario 
                            SET fecha = @fecha, cantidad = @cantidad, precio_unitario = @precio_unitario,
                                id_tipo_movimiento = @id_tipo_movimiento, id_ingrediente = @id_ingrediente, id_compra = @id_compra
                            WHERE id = @id";
                conn.Execute(sql, inv);
            }
        }

        public int delete(int id)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = "DELETE FROM movimiento_inventario WHERE id = @id";
                return conn.Execute(sql, new { id });
            }
        }

        public double TotalInventario(int id_ingrediente)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = "SELECT COALESCE(SUM(cantidad), 0) FROM movimiento_inventario WHERE id_tipo_movimiento = @id_tipo_movimiento AND id_ingrediente = @id_ingrediente";
                var totalIngres = conn.ExecuteScalar<double>(sql, new { id_tipo_movimiento = 1, id_ingrediente });
                var totalSalida = conn.ExecuteScalar<double>(sql, new { id_tipo_movimiento = 2, id_ingrediente });
                return totalIngres - totalSalida;
            }
        }
    }
}
