using Dapper;
using Proyecto_Polleria.Data;
using Proyecto_Polleria.Models;

namespace Proyecto_Polleria.Repository
{
    public class ProveedorRepository
    {
        private readonly Conexion db;

        public ProveedorRepository(Conexion db)
        {
            this.db = db;
        }

        public void create(Proveedor prov)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = "INSERT INTO proveedor (nit, nombre, direccion, telefono) VALUES (@nit, @nombre, @direccion, @telefono)";
                conn.Execute(sql, prov);
            }
        }

        public List<Proveedor> GetAll()
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = "SELECT * FROM proveedor";
                return conn.Query<Proveedor>(sql).ToList();
            }
        }

        public Proveedor GetById(string nit)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = "SELECT * FROM proveedor WHERE nit = @nit";
                return conn.QueryFirstOrDefault<Proveedor>(sql, new { nit });
            }
        }

        public void update(Proveedor prov)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = "UPDATE proveedor SET nombre = @nombre, direccion = @direccion, telefono = @telefono WHERE nit = @nit";
                conn.Execute(sql, prov);
            }
        }

        public int delete(string nit)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = "DELETE FROM proveedor WHERE nit = @nit";
                return conn.Execute(sql, new { nit });
            }
        }
    }
}
