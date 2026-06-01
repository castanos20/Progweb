using Dapper;
using Proyecto_Polleria.Data;
using Proyecto_Polleria.Models;

namespace Proyecto_Polleria.Repository
{
    public class TipoServicioRepository
    {
        private readonly Conexion db;
        public TipoServicioRepository(Conexion db) { this.db = db; }

        public void create(TipoServicio ts)
        {
            using var conn = db.GetConnection();
            conn.Open();
            conn.Execute("INSERT INTO tipo_servicio (id, tipo) VALUES (@id, @tipo)", ts);
        }

        public List<TipoServicio> GetAll()
        {
            using var conn = db.GetConnection();
            conn.Open();
            return conn.Query<TipoServicio>("SELECT * FROM tipo_servicio ORDER BY id").ToList();
        }

        public TipoServicio GetById(int id)
        {
            using var conn = db.GetConnection();
            conn.Open();
            return conn.QueryFirstOrDefault<TipoServicio>("SELECT * FROM tipo_servicio WHERE id = @id", new { id });
        }

        public void update(TipoServicio ts)
        {
            using var conn = db.GetConnection();
            conn.Open();
            conn.Execute("UPDATE tipo_servicio SET tipo = @tipo WHERE id = @id", ts);
        }

        public int delete(int id)
        {
            using var conn = db.GetConnection();
            conn.Open();
            return conn.Execute("DELETE FROM tipo_servicio WHERE id = @id", new { id });
        }
    }
}
