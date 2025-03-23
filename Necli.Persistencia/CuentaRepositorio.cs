using Microsoft.Data.SqlClient;
using Necli.Entidades;

namespace Necli.Persistencia
{
    public class CuentaRepositorio
    {
        private readonly string _cadena_conexion = "Server=LAPTOP-UVUGVE35\\WEB2DB;Database=Necli;Trusted_Connection=True; TrustServerCertificate=True;";
        private string sql = "";

        private bool RegistarCuenta(Cuentas cuenta)
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
    }
}
