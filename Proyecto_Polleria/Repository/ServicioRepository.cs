using Dapper;
using Proyecto_Polleria.Data;
using Proyecto_Polleria.Models;

namespace Proyecto_Polleria.Repository
{
    public class ServicioRepository
    {
        private readonly Conexion db;
        public ServicioRepository(Conexion db) { this.db = db; }

        public void create(Servicio servicio)
        {
            using var conn = db.GetConnection();
            conn.Open();
            var sql = @"INSERT INTO servicio (id, hora_ingreso, hora_salida, id_mesa, id_agenteservicio, id_tipo_servicio, id_cliente)
                        VALUES (@id, @hora_ingreso, @hora_salida, @id_mesa, @id_agenteservicio, @id_tipo_servicio, @id_cliente)";
            conn.Execute(sql, servicio);
        }

        public List<Servicio> GetAll()
        {
            using var conn = db.GetConnection();
            conn.Open();
            return conn.Query<Servicio>("SELECT * FROM servicio ORDER BY id").ToList();
        }

        public Servicio GetById(int id)
        {
            using var conn = db.GetConnection();
            conn.Open();
            return conn.QueryFirstOrDefault<Servicio>("SELECT * FROM servicio WHERE id = @id", new { id });
        }

        public void update(Servicio servicio)
        {
            using var conn = db.GetConnection();
            conn.Open();
            var sql = @"UPDATE servicio SET hora_ingreso = @hora_ingreso, hora_salida = @hora_salida,
                        id_mesa = @id_mesa, id_agenteservicio = @id_agenteservicio,
                        id_tipo_servicio = @id_tipo_servicio, id_cliente = @id_cliente
                        WHERE id = @id";
            conn.Execute(sql, servicio);
        }

        public int delete(int id)
        {
            using var conn = db.GetConnection();
            conn.Open();
            return conn.Execute("DELETE FROM servicio WHERE id = @id", new { id });
        }
    }
}
