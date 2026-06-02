using Dapper;
using Proyecto_Polleria.Data;
using Proyecto_Polleria.Models;
using Proyecto_Polleria.Models.temp;
using Proyecto_Polleria.Models.tempGraficos;
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
                var sql = @"INSERT INTO pedido (novedad, id_proceso, id_cocinero, id_servicio, id_plato, precio) 
                            VALUES (@novedad, @id_proceso, @id_cocinero, @id_servicio, @id_plato, (SELECT precio FROM plato WHERE id = @id_plato))";
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
        public List<Pedido> PedidosMesa(int id)
        {
            using (var conn = db.GetConnection())
            {
                var sql = "SELECT * FROM pedido WHERE id_servicio IN (SELECT s.id FROM servicio s JOIN mesa m ON s.id_mesa = m.id WHERE m.id = @id AND s.hora_salida IS NULL)";
                return conn.Query<Pedido>(sql, new { id }).ToList();
            }
        }
        public int ActualizaEstado(Pedido tmp)
        {
            using (var conn = db.GetConnection())
            {
                var sql = "UPDATE pedido SET id_proceso = @id_proceso WHERE id = @id";
                return conn.Execute(sql,tmp);
            }
        }
        public List<GraficoVentaTendVolu> ObtenerTendencia(Grafico_VentaTemp tmp)
        {
            using (var conn = db.GetConnection())
            {
            
                var truncador = tmp.periodo switch
                    {
                        "hora" => "hour",
                        "dia" => "day",
                        "semana" => "week",
                        "mes" => "month",
                        _ => throw new ArgumentException($"Periodo inválido: {tmp.periodo}")
                    };
                var sql = $"""
                SELECT
                    DATE_TRUNC('{truncador}', s.hora_ingreso) AS periodo,
                    SUM(p.precio)                                AS total_ingresos,
                    COUNT(*)                                  AS cantidad_pedidos
                FROM pedido p
                JOIN servicio s ON p.id_servicio = s.id 
                WHERE s.hora_ingreso BETWEEN @fecha_inicio AND @fecha_fin
                GROUP BY 1
                ORDER BY 1
                """;
                return conn.Query<GraficoVentaTendVolu>(sql, tmp).ToList();
            }
            


        }
    }
}