using Microsoft.Data.SqlClient;
using Necli.Entidades;

namespace Necli.Persistencia
{
    public class CuentaRepositorio
    {
        private readonly string _cadena_conexion = "Server=LAPTOP-UVUGVE35\\WEB2DB;Database=Necli;Trusted_Connection=True; TrustServerCertificate=True;";
        private string sql = "";

        public bool RegistarCuenta(Cuenta cuenta)
        {
            using (var conexion = new SqlConnection(_cadena_conexion))
            {
                conexion.Open();
                sql = "INSERT INTO Cuentas (Id, Contraseña, Nombres, Apellidos, Email, NumeroTelefono, Saldo, FechaCreacion) VALUES (@Id,@Contraseña,@Nombres,@Apellidos,@Email,@NumeroTelefono,@Saldo,@FechaCreacion)";
                using (var comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@Id", cuenta.Id);
                    comando.Parameters.AddWithValue("@Contraseña", cuenta.Contraseña);
                    comando.Parameters.AddWithValue("@Nombres", cuenta.Nombres);
                    comando.Parameters.AddWithValue("@Apellidos", cuenta.Apellidos);
                    comando.Parameters.AddWithValue("@Email", cuenta.Email);
                    comando.Parameters.AddWithValue("@NumeroTelefono", cuenta.NumeroTelefono);
                    comando.Parameters.AddWithValue("@Saldo", cuenta.Saldo);
                    comando.Parameters.AddWithValue("@FechaCreacion", cuenta.FechaCreacion);
                    comando.ExecuteNonQuery();
                }

            }



            return true;
        }

        
        public List<Cuenta> ListarCuentas()
        {

            var cuentas = new List<Cuenta>();

            using (var conexion = new SqlConnection(_cadena_conexion))
            {
                sql = "SELECT * FROM Cuentas";
                using (var comando = new SqlCommand(sql, conexion))
                {
                    conexion.Open();
                    var lector = comando.ExecuteReader();
                    while (lector.Read())
                    {
                        var cuenta = new Cuenta
                        {
                            Apellidos = lector["Apellidos"].ToString(),
                            Contraseña = lector["Contraseña"].ToString(),
                            Email = lector["Email"].ToString(),
                            FechaCreacion = DateTime.Parse(lector["FechaCreacion"].ToString()),
                            Id = Convert.ToInt32(lector["Id"].ToString()),
                            Nombres = lector["Nombres"].ToString(),
                            NumeroTelefono = lector["NumeroTelefono"].ToString(),
                            Saldo = Convert.ToSingle(lector["Saldo"].ToString())

                        };
                        cuentas.Add(cuenta);
                    }
                }


            }

                return cuentas;
        }

        public Cuenta ConsultarCuenta(string telefono)
        {
            using (var conexion = new SqlConnection(_cadena_conexion))
            {
                sql = "SELECT * FROM Cuentas WHERE NumeroTelefono =@NumeroTelefono";

                using (var comando = new SqlCommand(sql, conexion))
                {

                    comando.Parameters.AddWithValue("@NumeroTelefono", telefono);
                    conexion.Open();
                    var lector = comando.ExecuteReader();
                    while (lector.Read())
                    {
                        var cuenta = new Cuenta
                        {
                            Apellidos = lector["Apellidos"].ToString(),
                            Contraseña = lector["Contraseña"].ToString(),
                            Email = lector["Email"].ToString(),
                            FechaCreacion = DateTime.Parse(lector["FechaCreacion"].ToString()),
                            Id = Convert.ToInt32(lector["Id"].ToString()),
                            Nombres = lector["Nombres"].ToString(),
                            NumeroTelefono = lector["NumeroTelefono"].ToString(),
                            Saldo = Convert.ToSingle(lector["Saldo"].ToString())

                        };
                        return cuenta;
                    }
                }
            }



            return null;
        }


        public bool ActualizarCuenta(Cuenta cuenta)
        {
            using (var conexion = new SqlConnection(_cadena_conexion))
            {
                sql = "UPDATE Cuentas SET Contraseña = @Contraseña, Nombres = @Nombres, Apellidos = @Apellidos, " +
                      "Email = @Email, NumeroTelefono = @NumeroTelefono, Saldo = @Saldo WHERE NumeroTelefono =@NumeroTelefono";
                using (var comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@Id", cuenta.Id);
                    comando.Parameters.AddWithValue("@Contraseña", cuenta.Contraseña);
                    comando.Parameters.AddWithValue("@Nombres", cuenta.Nombres);
                    comando.Parameters.AddWithValue("@Apellidos", cuenta.Apellidos);
                    comando.Parameters.AddWithValue("@Email", cuenta.Email);
                    comando.Parameters.AddWithValue("@NumeroTelefono", cuenta.NumeroTelefono);
                    comando.Parameters.AddWithValue("@Saldo", cuenta.Saldo);
                    conexion.Open();
                    int filasAfectadas = comando.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }


        public bool EliminarCuenta(int id)
        {
            using (var conexion = new SqlConnection(_cadena_conexion))
            {
                sql = "DELETE FROM Cuentas WHERE Id = @Id";
                using (var comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@Id", id);
                    conexion.Open();
                    int filasAfectadas = comando.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }



    }
}
