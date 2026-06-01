using Dapper;
using Proyecto_Polleria.Data;
using Proyecto_Polleria.Models;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto_Polleria.Repository
{
    public class ProcesoRepository
    {
        private readonly Conexion db;

        public ProcesoRepository(Conexion db)
        {
            this.db = db;
        }

        public void Create(Proceso proceso)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = "INSERT INTO proceso (id, descripcion) VALUES (@id, @descripcion)";
                conn.Execute(sql, proceso);
            }
        }

        public List<Proceso> GetAll()
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = "SELECT * FROM proceso";
                return conn.Query<Proceso>(sql).ToList();
            }
        }

        public Proceso GetById(int id)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = "SELECT * FROM proceso WHERE id = @id";
                return conn.QueryFirstOrDefault<Proceso>(sql, new { id });
            }
        }

        public void Update(Proceso proceso)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = "UPDATE proceso SET descripcion = @descripcion WHERE id = @id";
                conn.Execute(sql, proceso);
            }
        }

        public int Delete(int id)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = "DELETE FROM proceso WHERE id = @id";
                return conn.Execute(sql, new { id });
            }
        }
    }
}