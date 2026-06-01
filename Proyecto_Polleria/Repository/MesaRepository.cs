using Dapper;
using Proyecto_Polleria.Data;
using Proyecto_Polleria.Models;

namespace Proyecto_Polleria.Repository
{
    public class MesaRepository
    {
        private readonly Conexion db;
        public MesaRepository(Conexion db) { this.db = db; }

        public void create(Mesa mesa)
        {
            using var conn = db.GetConnection();
            conn.Open();
            conn.Execute("INSERT INTO mesa (id, nro_sillas) VALUES (@id, @nro_sillas)", mesa);
        }

        public List<Mesa> GetAll()
        {
            using var conn = db.GetConnection();
            conn.Open();
            return conn.Query<Mesa>("SELECT * FROM mesa ORDER BY id").ToList();
        }

        public Mesa GetById(int id)
        {
            using var conn = db.GetConnection();
            conn.Open();
            return conn.QueryFirstOrDefault<Mesa>("SELECT * FROM mesa WHERE id = @id", new { id });
        }

        public void update(Mesa mesa)
        {
            using var conn = db.GetConnection();
            conn.Open();
            conn.Execute("UPDATE mesa SET nro_sillas = @nro_sillas WHERE id = @id", mesa);
        }

        public int delete(int id)
        {
            using var conn = db.GetConnection();
            conn.Open();
            return conn.Execute("DELETE FROM mesa WHERE id = @id", new { id });
        }

        public List<Mesa> mesalibre()
        {
            using var conn = db.GetConnection();
            conn.Open();
            var sql = "SELECT * FROM mesa m WHERE m.id NOT IN (SELECT id_mesa FROM servicio WHERE hora_salida IS NULL);";
           return conn.Query<Mesa>(sql).ToList();
        }
    }
}
