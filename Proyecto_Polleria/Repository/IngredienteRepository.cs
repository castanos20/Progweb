using Dapper;
using Proyecto_Polleria.Data;
using Proyecto_Polleria.Models;

namespace Proyecto_Polleria.Repository
{
    public class IngredienteRepository
    {
        private readonly Conexion db;

        public IngredienteRepository(Conexion db)
        {
            this.db = db;
        }

        public void create(Ingrediente ing)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = "INSERT INTO ingrediente (nombre, descripcion, unidad_medida) VALUES (@nombre, @descripcion, @unidad_medida)";
                conn.Execute(sql, ing);
            }
        }

        public List<Ingrediente> GetAll()
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = "SELECT * FROM ingrediente ORDER BY nombre";
                return conn.Query<Ingrediente>(sql).ToList();
            }
        }

        public Ingrediente GetById(int id)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = "SELECT * FROM ingrediente WHERE id = @id";
                return conn.QueryFirstOrDefault<Ingrediente>(sql, new { id });
            }
        }

        public void update(Ingrediente ing)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = "UPDATE ingrediente SET nombre = @nombre, descripcion = @descripcion, unidad_medida = @unidad_medida WHERE id = @id";
                conn.Execute(sql, ing);
            }
        }

        public int delete(int id)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = "DELETE FROM ingrediente WHERE id = @id";
                return conn.Execute(sql, new { id });
            }
        }
    }
}
