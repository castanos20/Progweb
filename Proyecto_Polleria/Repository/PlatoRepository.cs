using Dapper;
using Proyecto_Polleria.Data;
using Proyecto_Polleria.Models;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto_Polleria.Repository
{
    public class PlatoRepository
    {
        private readonly Conexion db;

        public PlatoRepository(Conexion db)
        {
            this.db = db;
        }

        public void Create(Plato plato)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = @"INSERT INTO plato (id, nombre, precio, descripcion) 
                            VALUES (@id, @nombre, @precio, @descripcion)";
                conn.Execute(sql, plato);
            }
        }

        public List<Plato> GetAll()
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = "SELECT * FROM plato";
                return conn.Query<Plato>(sql).ToList();
            }
        }

        public Plato GetById(int id)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = "SELECT * FROM plato WHERE id = @id";
                return conn.QueryFirstOrDefault<Plato>(sql, new { id });
            }
        }

        public void Update(Plato plato)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = @"UPDATE plato 
                            SET nombre = @nombre, 
                                precio = @precio, 
                                descripcion = @descripcion 
                            WHERE id = @id";
                conn.Execute(sql, plato);
            }
        }

        public int Delete(int id)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = "DELETE FROM plato WHERE id = @id";
                return conn.Execute(sql, new { id });
            }
        }
    }
}