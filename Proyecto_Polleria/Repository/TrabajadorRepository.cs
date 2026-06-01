using Proyecto_Polleria.Data;
using Proyecto_Polleria.Models;
using Dapper;
namespace Proyecto_Polleria.Repository
{
    public class TrabajadorRepository
    {
        private readonly Conexion db;

        public TrabajadorRepository(Conexion db)
        {
            this.db = db;
        }

        public void create(Trabajador traba)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();

                var sql = traba.rol == 3
                    ? "INSERT INTO cocinero(cc,nombre,telefono,direccion,salario) VALUES (@cc,@nombre,@telefono,@direccion,@salario)"
                    : "INSERT INTO agente_servicio(cc,nombre,telefono,direccion,salario,id_rol) VALUES (@cc,@nombre,@telefono,@direccion,@salario,@rol)";

                conn.Execute(sql, traba);
            }
        }

        public List<Trabajador> GetAll()
        {
            using(var conn = db.GetConnection())
            {
                conn.Open ();
                var sql = "SELECT * FROM vista_empleados";
                return conn.Query<Trabajador>(sql).ToList();
            }
        }

        public Trabajador GetById(string cc)
        {
            using (var conn = db.GetConnection()) 
            {
                conn.Open();
                var sql = "SELECT * FROM vista_empleados WHERE cc=@cc";
                return conn.QueryFirstOrDefault<Trabajador>(sql, new {cc});
            }
        }

        public void upgrate(Trabajador traba) 
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var rolActual = conn.QueryFirstOrDefault<int>(
                    "SELECT rol FROM vista_empleados WHERE cc = @cc",
                    new { traba.cc }
                    );

                var sql = rolActual==3
                    ? "UPDATE cocinero SET nombre=@nombre, telefono=@telefono, direccion=@direccion, salario=@salario WHERE cc=@cc"
                    : "UPDATE agente_servicio SET nombre=@nombre, telefono=@telefono, direccion=@direccion, salario=@salario, id_rol=@rol WHERE cc=@cc";
                conn.Execute(sql,traba);
            }
        }

        public int delete(string cc)
        {
            using(var conn = db.GetConnection())
            {
                conn.Open();
                var rolActual = conn.QueryFirstOrDefault<int>(
                    "SELECT rol FROM vista_empleados WHERE cc = @cc",
                    new { cc }
                    );
                var sql = rolActual == 3
                   ? "DELETE FROM cocinero WHERE cc = @cc"
                   : "DELETE FROM agente_servicio WHERE cc = @cc";
               return conn.Execute(sql,new { cc });
            }
        }
        public List<Trabajador> GetAllMesero()
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = "SELECT * FROM vista_empleados2 WHERE rol = 1 ";
                return conn.Query<Trabajador>(sql).ToList();
            }
        }
        
        public List<Trabajador> GetAllCocineros()
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                var sql = "SELECT * FROM vista_empleados2 WHERE rol = 3 ";
                return conn.Query<Trabajador>(sql).ToList();
            }
        }
    }
}
