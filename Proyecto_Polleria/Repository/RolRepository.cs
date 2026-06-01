using Dapper;
using Proyecto_Polleria.Data;
using Proyecto_Polleria.Models;

namespace Proyecto_Polleria.Repository
{
    public class RolRepository
    {
        private readonly Conexion db;
        public RolRepository(Conexion db) { this.db = db; }

        public void create(Rol rol)
        {
            using var conn = db.GetConnection();
            conn.Open();
            conn.Execute("INSERT INTO rol (id, nombre) VALUES (@id, @nombre)", rol);
        }

        public List<Rol> GetAll()
        {
            using var conn = db.GetConnection();
            conn.Open();
            return conn.Query<Rol>("SELECT * FROM rol ORDER BY id").ToList();
        }

        public Rol GetById(int id)
        {
            using var conn = db.GetConnection();
            conn.Open();
            return conn.QueryFirstOrDefault<Rol>("SELECT * FROM rol WHERE id = @id", new { id });
        }

        public void update(Rol rol)
        {
            using var conn = db.GetConnection();
            conn.Open();
            conn.Execute("UPDATE rol SET nombre = @nombre WHERE id = @id", rol);
        }

        public int delete(int id)
        {
            using var conn = db.GetConnection();
            conn.Open();
            return conn.Execute("DELETE FROM rol WHERE id = @id", new { id });
        }
    }
}
