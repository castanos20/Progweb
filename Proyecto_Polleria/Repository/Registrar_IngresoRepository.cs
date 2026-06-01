using Dapper;
using Proyecto_Polleria.Data;
using Proyecto_Polleria.Models;
using Proyecto_Polleria.Models.temp;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto_Polleria.Repository
{
    public class Registrar_IngresoRepository
    {
        private readonly Conexion db;

        public Registrar_IngresoRepository(Conexion db)
        {
            this.db = db;
        }

        public void Create(Servicio servicio)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                // Nota: Usamos NOW() para capturar de forma automática la fecha y hora de ingreso actual en PostgreSQL
                var sql = @"INSERT INTO servicio (hora_ingreso, id_mesa, id_agenteservicio, id_tipo_servicio, id_cliente) 
                            VALUES (NOW(), @id_mesa, @id_agenteservicio,1,  @id_cliente)";
                conn.Execute(sql, servicio);
            }
        }

        public List<Servicio> GetAll()
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = "SELECT * FROM servicio";
                return conn.Query<Servicio>(sql).ToList();
            }
        }

        public Servicio GetById(int id)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = "SELECT * FROM servicio WHERE id = @id";
                return conn.QueryFirstOrDefault<Servicio>(sql, new { id });
            }
        }

        public void Update(Servicio servicio)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = @"UPDATE servicio 
                            SET hora_ingreso = @hora_ingreso, 
                                hora_salida = @hora_salida, 
                                id_mesa = @id_mesa, 
                                id_agenteservicio = @id_agenteservicio, 
                                id_tipo_servicio = @id_tipo_servicio, 
                                id_cliente = @id_cliente 
                            WHERE id = @id";
                conn.Execute(sql, servicio);
            }
        }

        public int Delete(int id)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = "DELETE FROM servicio WHERE id = @id";
                return conn.Execute(sql, new { id });
            }
        }

        public List<Pedido> GetPedidos(int id)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = "SELECT * FROM pedido WHERE id_servicio=@id ";
                return conn.Query<Pedido>(sql, new {id}).ToList();
            }
        }
        public int ActualizarSalida(Servicio serv)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = "UPDATE servicio SET hora_salida = NOW() WHERE id = @id";
                return conn.Execute(sql, serv);
            }
        }
        public List<Servicio> GetHistorial()
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = "SELECT * FROM servicio WHERE hora_salida IS NOT NULL ORDER BY hora_salida DESC";
                return conn.Query<Servicio>(sql).ToList();
            }
        }
        public List<DetallePedidoTemp> GetDetallesPorServicio(int idServicio)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();

          
                var sql = "SELECT * FROM v_detalle_pedidos_servicio WHERE id_servicio = @idServicio";

                return conn.Query<DetallePedidoTemp>(sql, new { idServicio }).ToList();
            }
        }

    }
}