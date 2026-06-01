using Dapper;
using Proyecto_Polleria.Data;
using Proyecto_Polleria.Models;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto_Polleria.Repository
{
    public class PedidoRepository
    {
        private readonly Conexion db;

        public PedidoRepository(Conexion db)
        {
            this.db = db;
        }

        public void Create(Pedido pedido)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = @"INSERT INTO pedido (novedad, id_proceso, id_cocinero, id_servicio, id_plato) 
                            VALUES (@novedad, @id_proceso, @id_cocinero, @id_servicio, @id_plato)";
                conn.Execute(sql, pedido);
            }
        }

        public List<Pedido> GetAll()
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = "SELECT * FROM pedido";
                return conn.Query<Pedido>(sql).ToList();
            }
        }

        public Pedido GetById(int id)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = "SELECT * FROM pedido WHERE id = @id";
                return conn.QueryFirstOrDefault<Pedido>(sql, new { id });
            }
        }

        public void Update(Pedido pedido)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = @"UPDATE pedido 
                            SET novedad = @novedad, 
                                precio = @precio, 
                                id_proceso = @id_proceso, 
                                id_cocinero = @id_cocinero, 
                                id_servicio = @id_servicio, 
                                id_plato = @id_plato 
                            WHERE id = @id";
                conn.Execute(sql, pedido);
            }
        }

        public int Delete(int id)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = "DELETE FROM pedido WHERE id = @id";
                return conn.Execute(sql, new { id });
            }
        }
    }
}